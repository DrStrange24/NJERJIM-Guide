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
        internal static readonly string Item = Table + ".[item]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string Interest = Table + ".[interest]";
        internal static readonly string DeadlineInDays = Table + ".[deadline_in_days]";
        internal static readonly string DateTime = Table + ".[datetime]";
        internal static readonly string Remarks = Table + ".[remarks]";
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
        internal static readonly string Remarks = Table + ".[remarks]";
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
                return DateTimeFormatHelper.StringDBToDateTime(this.DateTime);
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
        internal static double TotalSupply(List<DSTransaction> transactionList)
        {
            double amount = 0;
            foreach (var transaction in transactionList)
            {
                if (transaction.Type == TransactionType.Deposit.ToString())
                    amount += transaction.Amount;
                else if (transaction.Type == TransactionType.Withdraw.ToString())
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
        private readonly double DefaultInterstInPercent
        {
            get
            {
                return 20;
            }
        }
        internal int Id { get; set; }
        internal int ClientId { get; set; }
        internal double Amount { get; set; }
        /// <summary>
        ///     DateTime with string format from database format
        /// </summary>
        internal string DateTime { get; set; }
        internal string Remarks { get; set; }
        internal double TotalDebt
        {
            get
            {
                double amount = this.Amount * (1 + this.DefaultInterstInPercent / 100);
                return amount;
            }
        }
        internal double CompletedBill
        {
            get
            {
                double amount = 0;
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTCollection.Amount} from {DTCollection.Table} join {DTLoan.Table} on {DTCollection.LoanId}={DTLoan.Id} where {DTLoan.Id}={Id}");
                for (int i = 0; i < data.Rows.Count; i++)
                    amount += Convert.ToDouble(data.Rows[i][0]);
                return amount;
            }
        }
        internal double OutstandingBill
        {
            get
            {
                return TotalDebt-CompletedBill;
            }
        }
        internal bool IsFullyPaid
        {
            get
            {
                if(this.TotalDebt==this.CompletedBill)
                    return true;
                return false;
            }
        }
        internal DateTime DeadLine 
        { 
            get
            {
                int deadline_number_of_days = DeadLineNumberOfDays;
                var datetime = DateTimeFormat;
                while(deadline_number_of_days > 0)
                {
                    datetime = datetime.AddDays(1);
                    if (DateTimeFormatHelper.GetDay(datetime)=="Sunday")
                        datetime = datetime.AddDays(1);
                    deadline_number_of_days--;
                }
                return datetime;
            } 
        }
        /// <summary>
        ///     Convert DateTime string to DateTime datatypes.
        /// </summary>
        internal DateTime DateTimeFormat 
        {
            get
            {
                return DateTimeFormatHelper.StringDBToDateTime(this.DateTime);
            }
        }
        internal int DeadLineNumberOfDays
        {
            get
            {
                switch (Amount)
                {
                    case 2000:
                        return 40;
                    case 3000:
                        return 36;
                    case 5000:
                        return 40;
                    case 10000:
                        return 60;
                }
                return 0;
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
                temp_data.Remarks = Convert.ToString(data.Rows[i][4]);
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
        internal string Remarks { get; set; }

        /// <summary>
        ///     Convert DateTime string to DateTime datatypes.
        /// </summary>
        internal DateTime DateTimeFormat
        {
            get
            {
                return DateTimeFormatHelper.StringDBToDateTime(this.DateTime);
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
                temp_data.Remarks = Convert.ToString(data.Rows[i][4]);
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
    /// <summary>
    ///     DS stands for Data Structure.
    ///     Client data structure.
    /// </summary>
    internal struct DSClient
    {
        internal int Id { get; set; }
        internal string FirstName { get; set; }
        internal bool IsFullyPaid
        {
            get
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTLoan.Id} as [ID],{DTLoan.ClientId} [Client ID],{DTLoan.Amount} as [Amount] from {DTLoan.Table} where {DTLoan.ClientId}={Id};");
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var loan = new DSLoan();
                    loan.Id = Convert.ToInt32(data.Rows[i]["ID"]);
                    loan.Amount = Convert.ToDouble(data.Rows[i]["Amount"]);
                    if (!loan.IsFullyPaid)
                        return false;
                }
                return true;
            }
        }
    }
}