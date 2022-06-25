using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJERJIM_Guide
{
    /// <summary>
    ///     Helps to make easier to query for database in SQLServer
    /// </summary>
    class DatabaseHelper
    {
        private string DatabasePath { get; set; }
        private string DatabaseName { get; set; }
        private SqlConnection Connection { get; set; }
        private SqlCommand Command { get; set; }
        internal DatabaseHelper()
        {
            DatabasePath = $"{Directory.GetCurrentDirectory()}\\";
            DatabaseName = "lending.mdf";
            Connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\""+DatabasePath+DatabaseName+"\";Integrated Security=True");
        }
        internal void ChangePath(string Path)
        {
            Path += "\\";
            Connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + Path + DatabaseName + "\";Integrated Security=True";
        }
        internal void ChangDatabase(string DatabaseName)
        {
            DatabaseName += ".mdf";
            Connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + DatabasePath + DatabaseName + "\";Integrated Security=True";
        }
        /// <summary>
        ///     Retrieve data from database and return a DataTable Class
        /// </summary>
        /// <param name="Query">query for database</param>
        /// <returns>DataTable with complete data of query</returns>
        internal DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            SqlDataAdapter sda = new SqlDataAdapter(Command);
            sda.Fill(dt);
            Command.Dispose();
            Connection.Close();
            return dt;
        }
        /// <summary>
        ///    Automatically set datagridview from query you made.
        /// </summary>
        /// <param name="dataGridView">
        ///     for what datagridview you want to set
        /// </param>
        /// <param name="Query">
        ///     database query (example: CRUD etc...)
        /// </param>
        internal void SetDataGridView(DataGridView dataGridView, string Query)
        {
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            dataGridView.DataSource = table;
            Command.Dispose();
            Connection.Close();
        }
        internal void Manipulate(string Query)
        {
            //It can use to Add, Update, Delete Query 
            try
            {
                Connection.Open();
                Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                if (exception.ErrorCode == -2146232060)
                    Console.WriteLine("Ignore lang anay ini nga error: " + exception.Message);
            }
            Command.Dispose();
            Connection.Close();
        }
    }
    internal static class DataTableHelper
    {
        /// <summary>
        ///     Change datatypes of a column in datatable.
        /// </summary>
        /// <param name="dataTable">Datatable</param>
        /// <param name="ColumnName">what column to change</param>
        /// <param name="type">to what datatype to change</param>
        internal static void ChangeColumnDatatypes(DataTable dataTable,string ColumnName,Type type)
        {
            dataTable.Columns.Add(new DataColumn("temporary_column", type));
            for (int i = 0; i < dataTable.Rows.Count; i++)
                dataTable.Rows[i]["temporary_column"] = dataTable.Rows[i][ColumnName];
            dataTable.Columns["temporary_column"].SetOrdinal(dataTable.Columns.IndexOf(ColumnName));
            dataTable.Columns.Remove(ColumnName);
            dataTable.Columns["temporary_column"].ColumnName = ColumnName;
        }
    }
}
