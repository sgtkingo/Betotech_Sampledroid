using System;
using System.Diagnostics;
using System.Windows.Forms;

using ControlModul.FileControl;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    public partial class HomeForm : Form
    {
        private Processer LocalProcesser;
        private VirtualFile virtualFileIN;
        private AutopilotWatcher autopilot;

        public HomeForm()
        {
            InitializeComponent();
            btn_openfile.Click += CheckLoadedFileEvent;
            btn_Process.Click += CheckProcessResultEvent;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LocalProcesser = new Processer(txt_Console);
            virtualFileIN=null;

            UseSettings();
            EnableProcess(false);

            CheckForUpdates();
        }

        //Background check of GitHub Releases, user decides about installation
        private async void CheckForUpdates()
        {
            var console = Processer.ConsoleBox;
            try
            {
                if (!PropertiesManager.checkForUpdates)
                {
                    console.Detail("Updates: disabled");
                    return;
                }

                var updater = new AppUpdater();
                if (!updater.IsInstalled)
                {
                    console.Detail("Updates: not installed app");
                    return;
                }

                var update = await updater.CheckForUpdatesAsync();
                if (update == null)
                {
                    console.Detail($"Up to date ({updater.CurrentVersion})");
                    return;
                }

                string newVersion = update.TargetFullRelease.Version.ToString();
                console.Info($"Update {newVersion} available");

                var answer = MessageBox.Show(this,
                    $"New version {newVersion} is available (current {updater.CurrentVersion}).\n\nDownload and install now? The application will restart.",
                    "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (answer != DialogResult.Yes)
                {
                    console.Detail("Update postponed");
                    return;
                }

                int reported = -1;
                await updater.DownloadAsync(update, progress =>
                {
                    //Progress comes from background thread, report every 25 %
                    int step = progress / 25;
                    if (step == reported) return;
                    reported = step;
                    BeginInvoke((MethodInvoker)(() => console.Detail($"Downloading {progress} %")));
                });

                console.Success("Update ready - restarting");
                PropertiesManager.SaveSettings();
                updater.ApplyAndRestart(update);
            }
            catch (Exception e)
            {
                console.Warning($"Update check failed: {e.Message}");
            }
        }

        private void UseSettings() {
            SetInitialInputDirectory();
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Browse file to transform:";
            this.openFileDialog.DefaultExt = "*.*";
            this.openFileDialog.Filter = "All files (*.*)|*.*";
            this.openFileDialog.HelpRequest += (sender, eventArgs) => {
                MessageBox.Show("Open TXT file to process sample.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
            };

            switch (PropertiesManager.ActualFileType)
            {
                case TypesEnums.FileType.CSV:
                    rdbtn_CSV.Checked = true;
                    break;
                case TypesEnums.FileType.DATABASE:
                    rdbtn_Object.Checked = true;
                    break;
                case TypesEnums.FileType.ALL:
                    rdbtn_Both.Checked = true;
                    break;
                default:
                    break;
            }

            chbox_autosave.Checked = PropertiesManager.autosaveFunction;
        }

        private void Process(){
            LocalProcesser.MakeSamples(virtualFileIN);
            if (LocalProcesser.Result)
            {
                LocalProcesser.FlushStats();
                if (PropertiesManager.autosaveFunction)
                {
                    SaveFileRoutine();
                }
                else
                {
                    Processer.ConsoleBox.Info("Check result and SAVE");
                }
            }
            else
            {
                MessageBox.Show(LocalProcesser.GetFinalMessage(), "Proccess error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void CheckProcessResultEvent(object sender, EventArgs e)
        {
            btn_savefile.Enabled = LocalProcesser.Result;
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            FileLoadRoutine();
        }

        private void btn_savefile_Click(object sender, EventArgs e)
        {
            SaveFileRoutine();
        }

        //Load and Save
        private void FileLoadRoutine(){
            //Set init directory by settings
            SetInitialInputDirectory();

            string fp=string.Empty;
            if(this.openFileDialog.ShowDialog() == DialogResult.OK){ 
                fp=this.openFileDialog.FileName;   
            }
            else
            {
                return;
            }
            virtualFileIN = new VirtualFile();
            virtualFileIN.AppendFile(fp);
            intxt_filename_in.Text = virtualFileIN.FILENAME;
        }

        //Input folder from Settings only if it exists, otherwise dialog uses its default
        private void SetInitialInputDirectory()
        {
            this.openFileDialog.InitialDirectory = PropertiesManager.IsValidDirectory(PropertiesManager.inputDataPath)
                ? PropertiesManager.inputDataPath
                : string.Empty;
        }

        private void CheckLoadedFileEvent(object sender, EventArgs e){
            EnableProcess(virtualFileIN != null);
        }

        private void SaveFileRoutine(){
            //CSV output needs existing output folder, check before user reviews the data
            if (PropertiesManager.ActualFileType != TypesEnums.FileType.DATABASE
                && !PropertiesManager.IsValidDirectory(PropertiesManager.outputDataPath))
            {
                Processer.ConsoleBox.Error("Output folder not set - see Settings");
                MessageBox.Show("Output folder is not set or does not exist.\nSet Output path in Settings.", "Output folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ( ShowDataTablesForm().DialogResult != DialogResult.OK ){
                MessageBox.Show("Result was REJECTED by user!", "Reject by user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Processer.ConsoleBox.Warning("Rejected by user - not saved");
                return;
            }

            if(intxt_filename_out.Text == string.Empty && rdbtn_CSV.Checked) { 
                MessageBox.Show("File name is EMPTY!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!LocalProcesser.MakeFiles()){
                Processer.ConsoleBox.Error("Saving failed");
                MessageBox.Show("Saving failed - see console.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Processer.ConsoleBox.Success("Saved - open next file");
        }

        //Form control
        private void EnableProcess(bool process)
        {
            btn_Process.Enabled = process;
            btn_savefile.Enabled = false;
        }

        //Debug and report 
        private void btn_reportConsole_Click(object sender, EventArgs e)
        {
            string DateTimeString = DateTime.Now.ToString("MM_dd_hh_ss");
            Processer.ConsoleBox.SaveToFile(DateTimeString);
            MessageBox.Show("Debug REPORT " + DateTimeString + " SAVED!\n\n" + PropertiesManager.currentDirectoryPath + PropertiesManager.reportDataPath, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_clearConsole_Click(object sender, EventArgs e)
        {
            Processer.ConsoleBox.ClearConsole();
        }

        //Autosave
        private void chbox_autosave_CheckedChanged(object sender, EventArgs e)
        {
            PropertiesManager.autosaveFunction = chbox_autosave.Checked;
            Debug.WriteLine("AUTOSAVE FUNCTION: "+ PropertiesManager.autosaveFunction);
        }

        //File name
        private void intxt_filename_out_TextChanged(object sender, EventArgs e)
        {
            PropertiesManager.fileNameOUT = intxt_filename_out.Text;
        }

        private void intxt_filename_in_TextChanged(object sender, EventArgs e)
        {
            PropertiesManager.fileNameIN = intxt_filename_in.Text;
            intxt_filename_out.Text = SuggestOutputName(intxt_filename_in.Text);
        }

        //Output name from input name: text file extensions are dropped (data.csv -> data_Cube.csv),
        //other names are kept (26.11.24.K -> 26.11.24.K_Cube.csv)
        private static string SuggestOutputName(string inputName)
        {
            string extension = System.IO.Path.GetExtension(inputName).ToLowerInvariant();
            bool textExtension = extension == ".csv" || extension == ".txt" || extension == ".dat" || extension == ".tsv";
            return textExtension ? System.IO.Path.GetFileNameWithoutExtension(inputName) : inputName;
        }

        //Change output mode 
        private void rdbtn_CSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_CSV.Checked) { 
                PropertiesManager.ActualFileType = TypesEnums.FileType.CSV;
                Debug.WriteLine("File type change to: " + PropertiesManager.ActualFileType);
                txt_filetype.Text = PropertiesManager.GetOutputFileType;
            }
        }

        private void rdbtn_Object_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_Object.Checked) {
                PropertiesManager.ActualFileType = TypesEnums.FileType.DATABASE;
                Debug.WriteLine("File type change to: " + PropertiesManager.ActualFileType);
                txt_filetype.Text = PropertiesManager.GetOutputFileType;
            }
        }

        private void rdbtn_Both_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_Both.Checked)
            {
                PropertiesManager.ActualFileType = TypesEnums.FileType.ALL;
                Debug.WriteLine("File type change to: " + PropertiesManager.ActualFileType);
                txt_filetype.Text = PropertiesManager.GetOutputFileType;
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        //About program
        private void btn_about_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        //Create another forms
        private void ShowSettingsForm(){
            var form = new AppSettingsForm(LocalProcesser.DataManager);
            form.FormClosed += (sender_, e_) => { this.Enabled = true; };
            form.ShowDialog(this);

            Processer.ConsoleBox.Header("SETTINGS");
            LocalProcesser.WriteSettingsSummary();
        }

        private DataViewForm ShowDataTablesForm()
        {
            var form = new DataViewForm(LocalProcesser.ViewerManager);
            form.FormClosed += (sender_, e_) => { this.Enabled = true; };
            form.ShowDialog(this);

            return form;
        }
        //Form closing
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAutopilot();
            PropertiesManager.SaveSettings();
        }

        //Autopilot: watch input folder, process every new file and save CSV to output folder
        private void chbox_autopilot_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_autopilot.Checked) StartAutopilot();
            else StopAutopilot();
        }

        private void StartAutopilot()
        {
            if (autopilot != null) return;

            string problem = null;
            if (!PropertiesManager.IsValidDirectory(PropertiesManager.inputDataPath)) problem = "Input folder is not set or does not exist.";
            else if (!PropertiesManager.IsValidDirectory(PropertiesManager.outputDataPath)) problem = "Output folder is not set or does not exist.";
            if (problem != null)
            {
                MessageBox.Show(problem + "\nSet Input/Output path in Settings.", "Autopilot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chbox_autopilot.Checked = false;
                return;
            }

            var watcher = new AutopilotWatcher(PropertiesManager.inputDataPath, this, IsAutopilotIgnored);
            watcher.FileReady += AutopilotProcessFile;
            watcher.Problem += message => Processer.ConsoleBox.Warning(message);
            try
            {
                watcher.Start();
            }
            catch (Exception ex)
            {
                watcher.Dispose();
                Processer.ConsoleBox.Error($"Autopilot: {ex.Message}");
                chbox_autopilot.Checked = false;
                return;
            }
            autopilot = watcher;

            SetManualControls(false);
            Processer.ConsoleBox.Header("AUTOPILOT ON");
            Processer.ConsoleBox.Detail($"In : {PropertiesManager.inputDataPath}");
            Processer.ConsoleBox.Detail($"Out: {PropertiesManager.outputDataPath}");
            Processer.ConsoleBox.Info("Waiting for new files...");
        }

        private void StopAutopilot()
        {
            if (autopilot == null) return;

            autopilot.Dispose();
            autopilot = null;
            SetManualControls(true);
            Processer.ConsoleBox.Header("AUTOPILOT OFF");
        }

        //Manual workflow and Settings are locked while autopilot runs
        private void SetManualControls(bool enabled)
        {
            btn_openfile.Enabled = enabled;
            btn_Settings.Enabled = enabled;
            if (enabled) EnableProcess(virtualFileIN != null);
            else
            {
                btn_Process.Enabled = false;
                btn_savefile.Enabled = false;
            }
        }

        //Skip generated output files (no processing loop when input = output folder) and temporary files
        private static bool IsAutopilotIgnored(string path)
        {
            string name = System.IO.Path.GetFileName(path);
            string extension = System.IO.Path.GetExtension(path).ToLowerInvariant();

            if (name.StartsWith("~") || name.StartsWith(".")) return true;
            if (extension == ".tmp" || extension == ".part" || extension == ".crdownload") return true;
            foreach (var type in new[] { TypesEnums.SampleType.Cube, TypesEnums.SampleType.Cylinder })
            {
                if (name.EndsWith(ProperitiesSamples.GetSampleExtensionNameByType(type) + PropertiesManager.fileTypeCSV, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

        private void AutopilotProcessFile(string path)
        {
            try
            {
                virtualFileIN = new VirtualFile();
                virtualFileIN.AppendFile(path);
                intxt_filename_in.Text = virtualFileIN.FILENAME; //also sets output file name

                LocalProcesser.MakeSamples(virtualFileIN);
                if (!LocalProcesser.Result)
                {
                    Processer.ConsoleBox.Error("Autopilot: file skipped");
                    return;
                }
                LocalProcesser.FlushStats();

                //Autopilot always writes CSV files, no data review
                if (LocalProcesser.FileMaker.MakeFiles(TypesEnums.FileType.CSV))
                    Processer.ConsoleBox.Success("Autopilot: saved");
                else
                    Processer.ConsoleBox.Error("Autopilot: saving failed");
            }
            catch (Exception ex)
            {
                Processer.ConsoleBox.Error($"Autopilot: {ex.Message}");
            }
        }
    }
}
