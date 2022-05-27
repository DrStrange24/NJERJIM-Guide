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
    //DT stands for Database Table
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
    static class DTLoan
    {
        internal static readonly string Table = "[loan]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string ClientId = Table + ".[client_id]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    static class DTCollection
    {
        internal static readonly string Table = "[collection]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string LoanId = Table + ".[loan_id]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    static class DTTransaction
    {
        internal static readonly string Table = "[transaction]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string Type = Table + ".[type]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
    }
    internal struct TransactionData
    {
        internal int Id { get; set; }
        internal TransactionType Type { get; set; }
        internal double Amount { get; set; }
        internal string DateTime { get; set; }

        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.Type}:{this.Amount}:{this.DateTime}");
        }
        internal DateTime GetDateTime()
        {
            return DatabaseHelper.StringToDateTime(this.DateTime);
        }
        internal static List<TransactionData> GetList(DataTable data)
        {
            var list = new List<TransactionData>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new TransactionData();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.Type = (TransactionType)data.Rows[i][1];
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        internal static double TotalDeposit(List<TransactionData> transactionList)
        {
            double amount = 0;
            foreach (var transaction in transactionList)
            {
                if (transaction.Type == TransactionType.Deposit)
                    amount += transaction.Amount;
            }
            return amount;
        }
    }
    internal struct LoanData
    {
        internal int Id { get; set; }
        internal int ClientId { get; set; }
        internal double Amount { get; set; }
        internal string DateTime { get; set; }

        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.ClientId}:{this.Amount}:{this.DateTime}");
        }
        internal DateTime GetDateTime()
        {
            return DatabaseHelper.StringToDateTime(this.DateTime);
        }
        internal static List<LoanData> GetList(DataTable data)
        {
            var list = new List<LoanData>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new LoanData();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.ClientId = Convert.ToInt32(data.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        internal static double TotalAmount(List<LoanData> loanList)
        {
            double amount = 0;
            foreach (var loan in loanList)
                amount += loan.Amount;
            return amount;
        }
    }
    internal struct CollectionData
    {
        internal int Id { get; set; }
        internal int LoanId { get; set; }
        internal double Amount { get; set; }
        internal string DateTime { get; set; }
        
        internal void Print()
        {
            Trace.WriteLine($"{this.Id}:{this.LoanId}:{this.Amount}:{this.DateTime}");
        }
        internal DateTime GetDateTime()
        {
            return DatabaseHelper.StringToDateTime(this.DateTime);
        }
        internal static List<CollectionData> GetList(DataTable data)
        {
            var list = new List<CollectionData>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new CollectionData();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.LoanId = Convert.ToInt32(data.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(data.Rows[i][3]);
                list.Add(temp_data);
            }
            return list;
        }
        internal static double TotalAmount(List<CollectionData> collectionList)
        {
            double amount = 0;
            foreach (var collection in collectionList)
                amount += collection.Amount;
            return amount;
        }
    }
}