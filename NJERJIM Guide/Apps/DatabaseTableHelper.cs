using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide
{
    /// <summary>
    ///     DT stands for Database Table.
    ///     Client Table with column names.
    /// </summary>
    static class DTClient
    {
        internal static readonly string Table = "[client]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string FirstName = Table + ".[first_name]";
        internal static readonly string MiddleName = Table + ".[middle_name]";
        internal static readonly string LastName = Table + ".[last_name]";
        internal static readonly string Sex = Table + ".[sex]";
        internal static readonly string ContactNumber = Table + ".[contact_number]";
        internal static readonly string Addess = Table + ".[address]";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Loan Table with column names.
    /// </summary>
    static class DTLoan
    {
        internal static readonly string Table = "[loan]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string ClientId = Table + ".[client_id]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Collection Table with column names.
    /// </summary>
    static class DTCollection
    {
        internal static readonly string Table = "[collection]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string LoanId = Table + ".[loan_id]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Transaction Table with column names.
    /// </summary>
    static class DTTransaction
    {
        internal static readonly string Table = "[transaction]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string Type = Table + ".[type]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    /// <summary>
    ///     DS stands for Data Structure.
    ///     Transaction data structure.
    /// </summary>
    internal struct DSTransaction
    {
        internal int Id { get; set; }
        internal string Type { get; set; }
        internal double Amount { get; set; }
        /// <summary>
        ///     DateTime with string format from database format
        /// </summary>
        internal string DateTime { get; set; }

        /// <summary>
        ///     Convert DateTime string to DateTime datatypes.
        /// </summary>
        internal DateTime DateTimeFormat
        {
            get
            {
                return DatabaseHelper.StringToDateTime(this.DateTime);
            }
        }
        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.Type}:{this.Amount}:{this.DateTime}");
        }
        internal static List<DSTransaction> GetList(DataTable data)
        {
            var list = new List<DSTransaction>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new DSTransaction();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.Type =  Convert.ToString(data.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        /// <summary>
        ///     Total Supply from different transactions
        /// </summary>
        /// <param name="transactionList"></param>
        /// <returns>Supply Left</returns>
        internal static double TotalDeposit(List<DSTransaction> transactionList)
        {
            double amount = 0;
            foreach (var transaction in transactionList)
            {
                if (transaction.Type == TransactionType.Deposit.ToString())
                    amount += transaction.Amount;
                else
                    amount -= transaction.Amount;
            }
            return amount;
        }
    }
    /// <summary>
    ///     DS stands for Data Structure.
    ///     Loan data structure.
    /// </summary>
    internal struct DSLoan
    {
        internal int Id { get; set; }
        internal int ClientId { get; set; }
        internal double Amount { get; set; }
        /// <summary>
        ///     DateTime with string format from database format
        /// </summary>
        internal string DateTime { get; set; }

        /// <summary>
        ///     Convert DateTime string to DateTime datatypes.
        /// </summary>
        internal DateTime DateTimeFormat 
        {
            get
            {
                return DatabaseHelper.StringToDateTime(this.DateTime);
            }
        }

        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.ClientId}:{this.Amount}:{this.DateTime}");
        }
        internal static List<DSLoan> GetList(DataTable data)
        {
            var list = new List<DSLoan>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new DSLoan();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.ClientId = Convert.ToInt32(data.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        /// <summary>
        ///     Calculate all the amount within the list.
        /// </summary>
        /// <param name="loanList"></param>
        /// <returns>
        ///     Total Amount within the list.
        /// </returns>
        internal static double TotalAmount(List<DSLoan> loanList)
        {
            double amount = 0;
            foreach (var loan in loanList)
                amount += loan.Amount;
            return amount;
        }
    }
    /// <summary>
    ///     DS stands for Data Structure.
    ///     Collection data structure.
    /// </summary>
    internal struct DSCollection
    {
        internal int Id { get; set; }
        internal int LoanId { get; set; }
        internal double Amount { get; set; }
        /// <summary>
        ///     DateTime with string format from database format
        /// </summary>
        internal string DateTime { get; set; }

        /// <summary>
        ///     Convert DateTime string to DateTime datatypes.
        /// </summary>
        internal DateTime DateTimeFormat
        {
            get
            {
                return DatabaseHelper.StringToDateTime(this.DateTime);
            }
        }
        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.LoanId}:{this.Amount}:{this.DateTime}");
        }
        internal static List<DSCollection> GetList(DataTable data)
        {
            var list = new List<DSCollection>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new DSCollection();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.LoanId = Convert.ToInt32(data.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        internal static double TotalAmount(List<DSCollection> collectionList)
        {
            double amount = 0;
            foreach (var collection in collectionList)
                amount += collection.Amount;
            return amount;
        }
    }
}