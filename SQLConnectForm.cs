using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteSampleTransformers.SQL;

namespace ConcreteSampleTransformers
{
    public partial class SQLConnectForm : Form
    {
        SQLConnector SQLConnector;

        public SQLConnectForm(SQLConnector connector)
        {
            InitializeComponent();
            SQLConnector = connector;
        }

        private void SQLConnectForm_Load(object sender, EventArgs e)
        {
            if(SQLConnector == null){
                CloseForm(DialogResult.Abort);
                return;
            }
            txt_server.Text = SQLConnector.ServerAddress;
            txt_database.Text = SQLConnector.DatabaseName;
            txt_username.Text = SQLConnector.Username;
            txt_password.Text = SQLConnector.Password;
        }

        private void CollectData(){
            SQLConnector.ServerAddress = txt_server.Text;
            SQLConnector.DatabaseName = txt_database.Text;
            SQLConnector.Username = txt_username.Text;
            SQLConnector.Password = txt_password.Text;
        }

        private async Task TryTestConnection()
        {
            await Task.Run(() => TestConnection());
            ShowTestResult();
        }

        private void TestConnection(){
            CollectData();
            SQLConnector.TestConnection();
        }

        private void ShowTestResult()
        {
            if (SQLConnector.LastTestResult)
            {
                l_test.ForeColor = Color.Green;
            }
            else
            {
                l_test.ForeColor = Color.Red;
            }
            l_test.Text = SQLConnector.LastTestMessage;
        }

        private async Task TryConnectToDatabase()
        {
            l_status.Text = "Try to connect...";
            l_status.ForeColor = Color.Violet;

            CollectData(); 
            await Task.Run(() => SQLConnector.Connect());
            ShowConnectionStatus();
        }

        private void ShowConnectionStatus(){
            if (SQLConnector.ConnectionStatus)
            {
                l_status.Text = "Connected!";
                l_status.ForeColor = Color.Green;
            }
            else
            {
                l_status.Text = "Disconnected...";
                l_status.ForeColor = Color.Red;
            }                
        }

        private async void btn_Connect_Click(object sender, EventArgs e)
        {
            await TryConnectToDatabase();
            if (SQLConnector.ConnectionStatus){
                //SQLConnector.Disconnect();
                CloseForm(DialogResult.OK);
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            TryTestConnection();
        }

        private void CloseForm(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
            this.Close();
        }

    }
}
