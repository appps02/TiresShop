using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TiresShop
{
    internal static class DBContext
    {
        static SqlConnection _sqlConnection =
            new(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\repos\TiresShop\ShopDB.mdf;Integrated Security=True;Connect Timeout=30");
        static SqlCommand _sqlCommand;
        static SqlDataReader _sqlDataReader;
        //SqlDataAdapter _sqldataAdapter;
        //DataSet _dataSet;
        static DataTable _dataTable = new();

        public static void ConnectToDB()
        {
            try
            {
                _sqlConnection.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception" + "\n" + e.Message);
            }
        }
        public static void DisconnectDB()
        {
            if(_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
            return;
        }
        public static DataTable GetProductTable()
        {
            try
            {
                using (_sqlCommand = new("SELECT * FROM Product", _sqlConnection))
                {
                    using (_sqlDataReader = _sqlCommand.ExecuteReader())
                    {
                        _dataTable.Load(_sqlDataReader);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (_dataTable != null)
                return _dataTable;
            else
                return _dataTable = new("NULL");
        }
    }
}
