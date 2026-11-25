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
        //Output columns config edited in OutputColumnsForm, applied on Confirm
        private Dictionary<TypesEnums.SampleType, string> pendingColumnConfigs;

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

            chk_checkForUpdates.Checked = PropertiesManager.checkForUpdates;
            pendingColumnConfigs = new Dictionary<TypesEnums.SampleType, string> {
                { TypesEnums.SampleType.Cube, PropertiesManager.outputColumnsCube },
                { TypesEnums.SampleType.Cylinder, PropertiesManager.outputColumnsCylinder },
            };

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
            BindFieldSeparatorList();
        }

        private void BindFieldSeparatorList()
        {
            cbox_inputFieldSeparator.DisplayMember = "Value";
            cbox_inputFieldSeparator.ValueMember = "Key";
            cbox_inputFieldSeparator.DataSource = new BindingSource(PropertiesManager.fieldSeparatorMap, null);
            cbox_inputFieldSeparator.SelectedValue = PropertiesManager.inputFieldSeparator;

            cbox_outputFieldSeparator.DisplayMember = "Value";
            cbox_outputFieldSeparator.ValueMember = "Key";
            cbox_outputFieldSeparator.DataSource = new BindingSource(PropertiesManager.fieldSeparatorMap, null);
            cbox_outputFieldSeparator.SelectedValue = PropertiesManager.outputFieldSeparator;
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

        //Settings save and close
        private bool SaveSettings()
        {
            try
            {
                char inputNfi = ((KeyValuePair<char, string>)cbox_inputLang.SelectedItem).Key;
                char outputNfi = ((KeyValuePair<char, string>)cbox_outputLang.SelectedItem).Key;
                char fieldSeparator = cbox_inputFieldSeparator.SelectedValue is char selected
                    ? selected
                    : PropertiesManager.defaultFieldSeparator;

                char outputFieldSeparator = cbox_outputFieldSeparator.SelectedValue is char selectedOut
                    ? selectedOut
                    : PropertiesManager.defaultFieldSeparator;

                //Column separator must differ from decimal separator, otherwise numbers would be split
                if (fieldSeparator == inputNfi)
                {
                    MessageBox.Show(
                        $"Input data separator '{fieldSeparator}' is the same as input decimal separator!\nChoose different input number format or data separator.",
                        "Settings conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (outputFieldSeparator == outputNfi)
                {
                    MessageBox.Show(
                        $"Output data separator '{outputFieldSeparator}' is the same as output decimal separator!\nChoose different output number format or data separator.",
                        "Settings conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                PropertiesManager.inputNfiSeparator = inputNfi;
                PropertiesManager.outputNfiSeparator = outputNfi;
                PropertiesManager.inputFieldSeparator = fieldSeparator;
                PropertiesManager.outputFieldSeparator = outputFieldSeparator;
                PropertiesManager.checkForUpdates = chk_checkForUpdates.Checked;
                foreach (var config in pendingColumnConfigs)
                {
                    PropertiesManager.SetOutputColumnsConfig(config.Key, config.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exp: {e.Message}|{e.Source}");
            }
            return true;
        }

        private void btn_OutputColumns_Click(object sender, EventArgs e)
        {
            using (var form = new OutputColumnsForm(pendingColumnConfigs))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    pendingColumnConfigs = form.ResultConfigs;
                }
            }
        }

        private void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            if (!SaveSettings()) return;
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
            var form = new SQLConnectionForm(DataManager.ConnectionString, true);
            if( form.ShowDialog() == DialogResult.OK)
            {
                DataManager.ConnectionString = form.SQLConnector.ConnectionString;
            }

            if(form.SQLConnector != null)
            {
                ShowConnectionStatus(DataManager.ServerName, form.SQLConnector.LastTestMessage);
            }
            else
            {
                ShowConnectionStatus(DataManager.ServerName, "Not connected!");
            }
                
        }
    }
}
