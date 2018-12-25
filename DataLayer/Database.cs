using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;




namespace DataLayer
{
    class Database
    {

        private SqlConnection mConnection;
        SqlTransaction mSqlTransaction = null;
        private static int TIMEOUT = 240;
        private static String CONNECTION_STRING = "server=dbsys.cs.vsb.cz\\STUDENT;database=ded0055;user=ded0055;password=eWPJhZqt6J;";

        public void getData()
        {
            string databaseName = Directory.GetCurrentDirectory() + @"\Database.db";
            //SQLiteConnection.;

        }


        public Database()
        {
            mConnection = new SqlConnection();
        }


        public void Close()
        {
            mConnection.Close();
        }


        public bool Connect()
        {
            bool ret = true;

            if (mConnection.State != System.Data.ConnectionState.Open)
            {
                ret = Connect(CONNECTION_STRING);
                //ret = Connect(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }

            return ret;
        }

        public bool Connect(String conString)
        {
            if (mConnection.State != System.Data.ConnectionState.Open)
            {
                mConnection.ConnectionString = conString;
                mConnection.Open();

                // mConnection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
            }
            return true;
        }

        public SqlDataReader Select(SqlCommand command)
        {
            command.Prepare();
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

        //Begin transaction
        public void BeginTransaction()
        {
            mSqlTransaction = mConnection.BeginTransaction(IsolationLevel.Serializable);
        }

        //End transaction
        public void EndTransaction()
        {
            mSqlTransaction.Commit();
            Close();
        }

        //Create command
        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, mConnection);

            if (mSqlTransaction != null)
            {
                command.Transaction = mSqlTransaction;
            }
            return command;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                command.Prepare();
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }



    }
}
