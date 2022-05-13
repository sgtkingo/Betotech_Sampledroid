using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ControlModul.DBControl.SQL;

namespace ConcreteSampleTransformers.Managers
{
    //TODO Pridat Entity Framework
    public class DataManager
    {
        private string _ConnectionString;
        public string ConnectionString { get { return _ConnectionString; } set { ParseConnectionString(value); _ConnectionString = value; } }
        public string ServerName { get; private set; }

        public DataManager(string connectionString){
            ConnectionString = connectionString;
            //Int Etnity here
        }

        //Todo use Entity FW and save list of samples 
        public bool SaveData(object samples)
        {
            return true;
        }

        private void ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                ServerName = string.Empty;

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString);
            var ServerAddress = scsb.DataSource;
            var DatabaseName = scsb.InitialCatalog;
            var Username = scsb.UserID;
            ServerName = $"{ServerAddress} -> {DatabaseName} ({Username})";
        }
    }
}
