using System;
using System.Deployment.Application;
using System.Windows.Forms;

using ControlModul.FileControl;

namespace ConcreteSampleTransformers
{
    public partial class MainWindow : Form
    {
        private Processer LocalProcesser;
        private VirtualFile virtualFileIN;

        public MainWindow()
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
        }

        private void UseSettings() {
            this.openFileDialog.InitialDirectory = PropertiesManager.inputDataPath;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Browse file to transform:";
            this.openFileDialog.DefaultExt = "*.*";
            this.openFileDialog.Filter = "All files (*.*)|*.*";
            this.openFileDialog.HelpRequest += (sender, eventArgs) => {
                MessageBox.Show("Open TXT file to process sample.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
            };

            if(PropertiesManager.ActualFileType == TypesEnums.FileType.CSV)
                rdbtn_CSV.Checked = true;
            else
                rdbtn_Object.Checked = true;

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
                    Processer.ConsoleBox.WriteLineToConsole("Please, save the file...");
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
            this.openFileDialog.InitialDirectory = PropertiesManager.inputDataPath;

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

        private void CheckLoadedFileEvent(object sender, EventArgs e){
            EnableProcess(virtualFileIN != null);
        }

        private void SaveFileRoutine(){
            if ( ShowDataTablesForm().DialogResult != DialogResult.OK ){
                MessageBox.Show("Result was REJECTED by user!", "Reject by user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Processer.ConsoleBox.WriteLineToConsole($"FILE {PropertiesManager.fileNameOUT} DOES NOT SAVE!",ConsoleBox.LineType.Bold);
                return;
            }

            if (intxt_filename_out.Text == string.Empty) { 
                MessageBox.Show("File name is EMPTY!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!LocalProcesser.MakeFiles()){
                Processer.ConsoleBox.WriteLineToConsole("SAVE PROCESS FINISH: FAIL!");
                MessageBox.Show("Save file FAIL!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Processer.ConsoleBox.WriteLineToConsole("Please, load next file...");
        }

        //Form control
        private void EnableProcess(bool process)
        {
            btn_Process.Enabled = process;
            btn_savefile.Enabled = false;
        }

        //Console and report 
        private void btn_reportConsole_Click(object sender, EventArgs e)
        {
            string DateTimeString = "";
            DateTimeString = DateTime.Now.Month.ToString();
            DateTimeString += "_";
            DateTimeString += DateTime.Now.Day.ToString();
            DateTimeString += "_";
            DateTimeString += DateTime.Now.Hour.ToString();
            DateTimeString += "_";
            DateTimeString += DateTime.Now.Second.ToString();
            Processer.ConsoleBox.SaveToFile(DateTimeString);
            MessageBox.Show("CONSOLE REPORT " + DateTimeString + " SAVED!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_clearConsole_Click(object sender, EventArgs e)
        {
            Processer.ConsoleBox.ClearConsole();
        }

        //Autosave
        private void chbox_autosave_CheckedChanged(object sender, EventArgs e)
        {
            PropertiesManager.autosaveFunction = chbox_autosave.Checked;
            Console.WriteLine("AUTOSAVE FUNCTION: "+ PropertiesManager.autosaveFunction);
        }

        //File name
        private void intxt_filename_out_TextChanged(object sender, EventArgs e)
        {
            PropertiesManager.fileNameOUT = intxt_filename_out.Text;
        }

        private void intxt_filename_in_TextChanged(object sender, EventArgs e)
        {
            PropertiesManager.fileNameIN = intxt_filename_in.Text;
            intxt_filename_out.Text = intxt_filename_in.Text;
        }

        //Change output mode 
        private void rdbtn_CSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_CSV.Checked) { 
                PropertiesManager.ActualFileType = TypesEnums.FileType.CSV;
                Console.WriteLine("File type change to: " + PropertiesManager.ActualFileType);
                txt_filetype.Text = PropertiesManager.GetOutputFileType;
            }
        }

        private void rdbtn_Object_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_Object.Checked) {
                PropertiesManager.ActualFileType = TypesEnums.FileType.DATABASE;
                Console.WriteLine("File type change to: " + PropertiesManager.ActualFileType);
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
            PropertiesManager.SaveSettings();
        }
    }
}
