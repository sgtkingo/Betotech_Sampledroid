using System;
using System.Threading.Tasks;

using Velopack;
using Velopack.Sources;

namespace ConcreteSampleTransformers.Managers
{
    //Automatic updates from GitHub Releases (packages are created by .github/workflows/release.yml)
    public class AppUpdater
    {
        public const string RepositoryUrl = "https://github.com/sgtkingo/Betotech_Sampledroid";

        private readonly UpdateManager _manager;

        public AppUpdater()
        {
            //Public repository: no access token, stable releases only
            _manager = new UpdateManager(new GithubSource(RepositoryUrl, null, false));
        }

        //False when running from build output (bin\...), updates work only in installed app
        public bool IsInstalled { get { return _manager.IsInstalled; } }

        public string CurrentVersion { get { return _manager.CurrentVersion?.ToString() ?? "-"; } }

        //Returns null when application is up to date
        public Task<UpdateInfo> CheckForUpdatesAsync()
        {
            return _manager.CheckForUpdatesAsync();
        }

        public Task DownloadAsync(UpdateInfo update, Action<int> progress)
        {
            return _manager.DownloadUpdatesAsync(update, progress);
        }

        //Exits application, applies downloaded update and starts new version
        public void ApplyAndRestart(UpdateInfo update)
        {
            _manager.ApplyUpdatesAndRestart(update.TargetFullRelease);
        }
    }
}
