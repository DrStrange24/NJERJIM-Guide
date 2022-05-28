using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            DatabasePath = "E:\\Dr Strange\\Work\\NJERJIM\\Programming\\NJERJIM Guide\\NJERJIM Guide\\";
            DatabaseName = "lending.mdf";
            Connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\""+DatabasePath+DatabaseName+"\";Integrated Security=True");
        }
        internal void ChangePath(string Path)
        {
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
        /// <summary>
        ///     Convert DateTime format to String format for database.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>String Format of DateTime</returns>
        internal static string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss:ff");
        }
        /// <summary>
        ///     Convert DateTime format to String format for database.
        /// </summary>
        /// <returns>String Format of DateTime</returns>
        internal static string DateTimeToString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ff");
        }
        /// <summary>
        ///     Convert String format from database to DateTime datatype.
        /// </summary>
        /// <param name="DatabaseDateTimeFormat">string</param>
        /// <returns>DateTime datatype</returns>
        internal static DateTime StringToDateTime(string DatabaseDateTimeFormat)
        {
            return DateTime.ParseExact(DatabaseDateTimeFormat, "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        /// <summary>
        ///     Convert String format from database to DateTime datatype.
        /// </summary>
        /// <param name="DatabaseDateTimeFormat">object</param>
        /// <returns>DateTime datatype</returns>
        internal static DateTime StringToDateTime(object DatabaseDateTimeFormat)
        {
            return DateTime.ParseExact(DatabaseDateTimeFormat.ToString(), "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
    }
}
