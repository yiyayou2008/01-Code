using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace CommClass
{
    public class DBConnection
    {
        private string dBserver;
        public string DBServer
        {
            get { return dBserver; }
            set { dBserver = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string dBName;
        public string DBName
        {
            get { return dBName; }
            set { dBName = value; }
        }
    }

    public abstract class DBSource
    {
        protected DBConnection DC;
        public DBConnection DataCon
        {
            get { return DC; }
            set { DC = value; }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        private Boolean connected;
        public Boolean Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public abstract Boolean Connect();
        public abstract void DisConnect();
        public abstract DataSet GetRecord(string strcmd);
        public abstract String[] GetTableNames();
        public abstract Boolean ExecuteSQL(string strcmd);
    }

    public class SqlsvrDBSource : DBSource
    {
        private SqlConnection Con;
        public SqlsvrDBSource(DBConnection dc)
        {
            this.DC = dc;
            string ConStr = "Server=" + dc.DBServer + ";user id=" + dc.UserName + ";pwd=" + dc.Password + ";database=" + dc.DBName;
            Con = new SqlConnection(ConStr);
        }

        public override Boolean Connect()
        {
            Connected = true;
            try
            {
                Con.Open();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Connected = false;
            }
            return Connected;
        }

        public override void DisConnect()
        {
            Con.Close();
        }

        public override DataSet GetRecord(string strcmd)
        {
            DataSet ds;
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strcmd, Con);
            da.Fill(ds);
            this.DisConnect();
            return ds;
        }

        public override string[] GetTableNames()
        {
            string[] TableNames = new string[10];
            return TableNames;
        }

        public override Boolean ExecuteSQL(string strcmd)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Connect();
            try
            {
                cmd.CommandText = strcmd;              
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
            finally
            {
                DisConnect();
            }
            return true;
        }

    }

    public class ExcelDBSource : DBSource
    {
        private OleDbConnection Con;
        public ExcelDBSource(DBConnection dc)
        {
            this.DC = dc;
            string Constr = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source=" + dc.DBName + ";Extended Properties=\"Excel 12.0;HDR=Yes\"";
        //   string Constr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\aa.xls;Extended Properties=Excel 8.0;HDR=Yes;IMEX=1";
            Con = new OleDbConnection(Constr);
        }
        public override Boolean Connect()
        {
            Connected = true;
            try
            {
                Con.Open();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Connected = false;
                MessageBox.Show(e.Message);
            }
            return Connected;
        }

        public override void DisConnect()
        {
            Con.Close();
        }

        public override string[] GetTableNames()
        {

            System.Data.DataTable dt = null;
            Connect();
            dt = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }
            ArrayList TmpSheets = new ArrayList();

            string TableName;
            foreach (DataRow row in dt.Rows)
            {
                TableName = row["TABLE_NAME"].ToString();
                if (TableName.Substring(TableName.Length - 1, 1) == "$")
                {
                    TmpSheets.Add(TableName);
                }
            }
            String[] Sheets = new String[TmpSheets.Count];
            int i = 0;
            foreach (string Table in TmpSheets)
            {
                Sheets[i] = Table;
                ++i;
            }
            DisConnect();
            return Sheets;
        }

        public override DataSet GetRecord(string strcmd)
        {
            DataSet ds;
            OleDbDataAdapter OleDat = new OleDbDataAdapter(strcmd, Con);
            ds = new DataSet();
            OleDat.Fill(ds);
            this.DisConnect();
            return ds;
        }
        public override bool ExecuteSQL(string strcmd)
        {
            Con.Open();
            OleDbCommand cmd = new OleDbCommand(strcmd, Con);


            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
            finally
            {
                DisConnect();
            }
            return true;
        }


    }
}
