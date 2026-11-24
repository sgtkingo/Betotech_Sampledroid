using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ConcreteSampleTransformers.Managers
{
    //Watches input folder and reports every new (or overwritten) file once it is completely written
    public class AutopilotWatcher : IDisposable
    {
        private const int CheckIntervalMs = 1000;
        private static readonly TimeSpan QuietTime = TimeSpan.FromSeconds(1);      //no change for this time = writing finished
        private static readonly TimeSpan ReadyTimeout = TimeSpan.FromMinutes(2);   //give up on files locked longer

        private class PendingFile
        {
            public DateTime FirstSeen;
            public DateTime LastEvent;
        }

        private readonly ISynchronizeInvoke _sync;
        private readonly Func<string, bool> _isIgnored;
        private readonly Timer _timer;
        private readonly Dictionary<string, PendingFile> _pending = new Dictionary<string, PendingFile>(StringComparer.OrdinalIgnoreCase);
        //Already reported files with their signature (size + last write), avoids double processing from repeated events
        private readonly Dictionary<string, string> _processed = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private FileSystemWatcher _watcher;
        private bool _busy;

        public string Folder { get; private set; }

        //Raised on UI thread with full path of file ready to process
        public event Action<string> FileReady;
        //Raised on UI thread with problem description (watcher error, locked file)
        public event Action<string> Problem;

        public AutopilotWatcher(string folder, ISynchronizeInvoke sync, Func<string, bool> isIgnored)
        {
            Folder = folder;
            _sync = sync;
            _isIgnored = isIgnored;
            _timer = new Timer { Interval = CheckIntervalMs };
            _timer.Tick += (s, e) => CheckPendingFiles();
        }

        public void Start()
        {
            _watcher = new FileSystemWatcher(Folder)
            {
                Filter = "*",
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
                SynchronizingObject = _sync,
            };
            _watcher.Created += (s, e) => Enqueue(e.FullPath);
            _watcher.Changed += (s, e) => Enqueue(e.FullPath);
            _watcher.Renamed += (s, e) => Enqueue(e.FullPath);
            _watcher.Error += (s, e) => Problem?.Invoke($"Watcher error: {e.GetException().Message}");
            _watcher.EnableRaisingEvents = true;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                _watcher = null;
            }
            _pending.Clear();
        }

        private void Enqueue(string path)
        {
            if (_isIgnored(path) || Directory.Exists(path)) return;

            PendingFile pending;
            if (!_pending.TryGetValue(path, out pending))
            {
                pending = new PendingFile { FirstSeen = DateTime.Now };
                _pending[path] = pending;
            }
            pending.LastEvent = DateTime.Now;
        }

        private void CheckPendingFiles()
        {
            if (_busy) return;
            _busy = true;
            try
            {
                foreach (var item in _pending.ToList())
                {
                    string path = item.Key;
                    var pending = item.Value;

                    if (!File.Exists(path))
                    {
                        _pending.Remove(path);
                        continue;
                    }
                    if (DateTime.Now - pending.LastEvent < QuietTime) continue;

                    if (!IsReady(path))
                    {
                        if (DateTime.Now - pending.FirstSeen > ReadyTimeout)
                        {
                            _pending.Remove(path);
                            Problem?.Invoke($"{Path.GetFileName(path)}: file locked, skipped");
                        }
                        continue;
                    }

                    _pending.Remove(path);
                    string signature = GetSignature(path);
                    string lastSignature;
                    if (_processed.TryGetValue(path, out lastSignature) && lastSignature == signature) continue;
                    _processed[path] = signature;

                    FileReady?.Invoke(path);
                }
            }
            finally
            {
                _busy = false;
            }
        }

        //File can be opened exclusively = nobody is writing it any more
        private static bool IsReady(string path)
        {
            try
            {
                using (File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)) { }
                return true;
            }
            catch (IOException) { return false; }
            catch (UnauthorizedAccessException) { return false; }
        }

        private static string GetSignature(string path)
        {
            var info = new FileInfo(path);
            return $"{info.Length}|{info.LastWriteTimeUtc.Ticks}";
        }

        public void Dispose()
        {
            Stop();
            _timer.Dispose();
        }
    }
}
