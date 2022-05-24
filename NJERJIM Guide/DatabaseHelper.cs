﻿using System;
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
        internal static string MDFToDDF(DateTime dateTime)
        {
            //"My DateTime Format" To "Database Datetime"
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss:ff");
        }
        internal static string MDFToDDF()
        {
            //"My DateTime Format" To "Database Datetime"
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ff");
        }
        internal static DateTime MDDFToDF(string DatabaseDateTimeFormat)
        {
            //"My Database DateTime Format" To "DateTime"
            return DateTime.ParseExact(DatabaseDateTimeFormat, "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        internal static DateTime MDDFToDF(object DatabaseDateTimeFormat)
        {
            //"My Database DateTime Format" To "DateTime"
            return DateTime.ParseExact(DatabaseDateTimeFormat.ToString(), "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
    }
}
