using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

using ControlModul.DBControl.SQL;

namespace ConcreteSampleTransformers
{
    public partial class AppSettingsForm : Form
    {
        private DataManager DataManager;

        public AppSettingsForm(DataManager dataManager)
        {
            InitializeComponent();
            DataManager = dataManager;

            this.Load += RefereshDirectoryPathsEvent;
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        { 
            this.btn_InPathSet.Click += RefereshDirectoryPathsEvent;
            this.btn_OutPathSet.Click += RefereshDirectoryPathsEvent;
            BindLanguageList();

            txt_langIn.Text = PropertiesManager.inputNfiSeparator.ToString();
            txt_langOut.Text = PropertiesManager.outputNfiSeparator.ToString();

            ShowConnectionStatus(DataManager.ServerName, string.Empty);
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

        //SQL settings

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            SetConnection();
        }


        private void SetConnection()
        {
            CreateConnectForm();
        }


        private void ShowConnectionStatus(string serverName, string status)
        {
            txt_SQLAddr.Text = serverName;
            l_status.Text = status;
        }

        private void CreateConnectForm(){
            //Test
            var form = new SQLConnectionFom(DataManager.ConnectionString, true);
            if( form.ShowDialog() == DialogResult.OK)
            {
                DataManager.ConnectionString = form.SQLConnector.ConnectionString;
            }
            ShowConnectionStatus(DataManager.ServerName, form.SQLConnector.LastTestMessage);
        }
    }
}
