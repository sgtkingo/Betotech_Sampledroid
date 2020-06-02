using System;
using System.IO;
using System.Windows.Forms;

namespace ConcreteSampleTransformers
{
    public partial class MainWindow : Form
    {
        private Processer Processer;
        private VirtualFile virtualFileIN;
        private VirtualFile virtualFileOUT;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Processer=new Processer(txt_Console);
            virtualFileIN=null;
            virtualFileOUT=null;

            this.openFileDialog.InitialDirectory=Processer.PropertiesManager.pathIN;
            this.openFileDialog.RestoreDirectory = true; 
            this.openFileDialog.Title="Browse file to transform:";
            this.openFileDialog.DefaultExt="*.*";
            this.openFileDialog.Filter = "All files (*.*)|*.*";

            this.txt_filetype.Text=Processer.PropertiesManager.primalFileType;

            EnableProcess(false);
            return;
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            //Processer.Test_FILE(virtualFile);
            //Processer.Test_Convert(virtualFile);
            //Processer.Test_ALL(virtualFile);
            if(Processer.MakeSamples(virtualFileIN)){
                btn_savefile.Enabled=true;
                if(chbox_autosave.Checked){
                    SaveFileRoutine();
                }
                Processer.ConsoleBox.WriteLineToConsole(Processer.FinalMessage,ConsoleBox.LineType.Bold);
                MessageBox.Show("CONVERSION PROCESS DONE!");
            }else{ 
                Processer.ConsoleBox.WriteLineToConsole(Processer.FinalMessage,ConsoleBox.LineType.Bold);
                MessageBox.Show("CONVERSION PROCESS FAIL!!!");
             }     
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            FileLoadRoutine();
            intxt_filename_in.Text=virtualFileIN.FILENAME;
            intxt_filename_out.Text=virtualFileIN.FILENAME;
            EnableProcess(true);
        }

        private void btn_savefile_Click(object sender, EventArgs e)
        {
            SaveFileRoutine();
        }

        private void btn_reportConsole_Click(object sender, EventArgs e)
        {
            string DateTimeString="";
            DateTimeString=DateTime.Now.Month.ToString();
            DateTimeString+="_";
            DateTimeString+=DateTime.Now.Day.ToString();
            DateTimeString+="_";
            DateTimeString+=DateTime.Now.Hour.ToString();
            DateTimeString+="_";
            DateTimeString+=DateTime.Now.Second.ToString();
            Processer.ConsoleBox.SaveToFile(DateTimeString);
            MessageBox.Show("CONSOLE REPORT "+DateTimeString+" SAVED!");
        }

        private void btn_clearConsole_Click(object sender, EventArgs e)
        {
            Processer.ConsoleBox.ClearConsole();
        }

        private void FileLoadRoutine(){
            virtualFileIN=new VirtualFile();

            string fp="";
            this.openFileDialog.FileName=fp;
            if(this.openFileDialog.ShowDialog() == DialogResult.OK){ 
                fp=this.openFileDialog.FileName;   
            }
            if(fp=="")return;

            virtualFileIN.appendFile(fp);            
        }

        private void SaveFileRoutine(){
            virtualFileOUT=new VirtualFile();
            string fp="";
            string file="";
            file=intxt_filename_out.Text+txt_filetype.Text;
            fp=Processer.PropertiesManager.pathOUT+@"\"+file;
            virtualFileOUT.appendFile(fp);
            if(!Processer.MakeFile(virtualFileOUT)){
                Processer.ConsoleBox.WriteLineToConsole("SAVE PROCESS FINISH: ERROR!");  
            }              
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jiri Konecny; \tBETTACOMP \nAutoformating concrete sampler \nV1.3\t\t\t2020");
        }

        private void chbox_zeroless_CheckedChanged(object sender, EventArgs e)
        {
            Processer.Zeroless=chbox_zeroless.Checked;
            Processer.ConsoleBox.WriteLineToConsole("ZEROLESS FUNCTION: "+chbox_zeroless.Checked);
        }

        private void btn_input_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK){ 
                Processer.PropertiesManager.pathIN=this.folderBrowserDialog.SelectedPath;
                this.openFileDialog.InitialDirectory=Processer.PropertiesManager.pathIN;

                Processer.PropertiesManager.savePathFile();
                Processer.ConsoleBox.WriteLineToConsole("INPUT DIRECTORY CHANGE: "+Processer.PropertiesManager.pathIN);

            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK){ 
                Processer.PropertiesManager.pathOUT=this.folderBrowserDialog.SelectedPath;

                Processer.PropertiesManager.savePathFile();
                Processer.ConsoleBox.WriteLineToConsole("OUTPUT DIRECTORY CHANGE: "+Processer.PropertiesManager.pathOUT);
            }
        }

        private void chbox_autosave_CheckedChanged(object sender, EventArgs e)
        {
            Processer.ConsoleBox.WriteLineToConsole("AUTOSAVE FUNCTION: "+chbox_autosave.Checked);
        }

        private void printERRORS(){ 
            Processer.printERRORs();
        }

        private void EnableProcess(bool value){
             btn_Process.Enabled=value;
             btn_savefile.Enabled=false;
        }
    }
}
