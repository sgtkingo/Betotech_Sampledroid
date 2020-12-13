using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    public partial class AppSettingsForm : Form
    {
        private DatabaseManager DatabaseManager;

        public AppSettingsForm(DatabaseManager databaseManager)
        {
            InitializeComponent();
            DatabaseManager = databaseManager;
            this.Load += RefereshDirectoryPathsEvent;
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            TryConnectToDatabase();

            this.btn_InPathSet.Click += RefereshDirectoryPathsEvent;
            this.btn_OutPathSet.Click += RefereshDirectoryPathsEvent;
            BindLanguageList();

            txt_langIn.Text = PropertiesManager.inputNfiSeparator.ToString();
            txt_langOut.Text = PropertiesManager.outputNfiSeparator.ToString();
        }

        private void BindLanguageList()
        {
            cbox_inputLang.DataSource = bindingSource_LanguageIN;
            cbox_outputLang.DataSource = bindingSource_LanguageOUT;

            bindingSource_LanguageIN.DataSource = PropertiesManager.numberFormatInfoMap;
            bindingSource_LanguageIN.ResetBindings(false);
            bindingSource_LanguageOUT.DataSource = PropertiesManager.numberFormatInfoMap;
            bindingSource_LanguageOUT.ResetBindings(false);

            SetLanguageList();
        }

        private void SetLanguageList(){
            try
            {
                foreach (var item in cbox_inputLang.Items)
                {
                    char key = ((KeyValuePair<char, string>)item).Key;
                    if (key == PropertiesManager.inputNfiSeparator)
                    {
                        cbox_inputLang.SelectedItem = item;
                        break;
                    }
                }
                foreach (var item in cbox_outputLang.Items)
                {
                    char key = ((KeyValuePair<char, string>)item).Key;
                    if (key == PropertiesManager.outputNfiSeparator)
                    {
                        cbox_outputLang.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: {ex.Message}|{ex.Source}");
            }
        }

        private void btn_InPathSet_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                PropertiesManager.inputDataPath = this.folderBrowserDialog.SelectedPath;
                Console.WriteLine("INPUT DIRECTORY CHANGE: " + PropertiesManager.inputDataPath);
            }
        }

        private void btn_OutPathSet_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                PropertiesManager.outputDataPath = this.folderBrowserDialog.SelectedPath;
                Console.WriteLine("OUTPUT DIRECTORY CHANGE: " + PropertiesManager.outputDataPath);
            }
        }

        private void RefereshDirectoryPathsEvent(object sender, EventArgs e)
        {
            txtInputDataPath.Text = PropertiesManager.inputDataPath;
            txtOutputDataPath.Text = PropertiesManager.outputDataPath;
        }

        private void cbox_inputLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemIn = (KeyValuePair<char, string>)cbox_inputLang.SelectedItem;
                txt_langIn.Text = itemIn.Key.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: {ex.Message}|{ex.Source}");
            }
        }

        private void cbox_outputLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemOut = (KeyValuePair<char, string>)cbox_outputLang.SelectedItem;
                txt_langOut.Text = itemOut.Key.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: {ex.Message}|{ex.Source}");
            }
        }

        //Settings save and close
        private void SaveSettings()
        {
            try
            {
                PropertiesManager.inputNfiSeparator = txt_langIn.Text[0];
                PropertiesManager.outputNfiSeparator = txt_langOut.Text[0];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exp: {e.Message}|{e.Source}");
            }
        }

        private void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            ChangeConnection();
        }

        private void ParseServerAddress(){
            try
            {
                string cntStr = PropertiesManager.connectionString;
                txt_SQLAddr.Text = cntStr.Substring(0, cntStr.IndexOf(';'));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exp: {e.Message}|{e.Source}");
            }
        }

        private async Task TryConnectToDatabase(){
            l_status.Text = "Try to connect...";
            await Task.Run(() => DatabaseManager.ConnectToDatabase());
            ShowConnectionStatus();
        }

        private async void ChangeConnection()
        {
            if (ConnectForm().DialogResult == DialogResult.OK)
            {
                await TryConnectToDatabase();
            }
        }

        private void ShowConnectionStatus()
        {
            ParseServerAddress();
            if (DatabaseManager.ConnectionStatus)
            {
                l_status.Text = "Connected!";
            }
            else
            {
                l_status.Text = "Disconnected...";
            }
        }

        private SQLConnectForm ConnectForm(){
            var form = new SQLConnectForm();
            form.ShowDialog();

            return form;
        }
    }
}
