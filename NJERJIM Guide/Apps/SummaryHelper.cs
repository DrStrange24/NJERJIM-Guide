using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide.Apps
{
    class SummaryHelper
    {
        internal List<DailyRecords> Records { get; private set; }
        internal SummaryHelper()
        {
            var db_helper = new DatabaseHelper();

            var transaction = db_helper.GetData($"select * from {DTTransaction.TableName} order by {DTTransaction.DateTime} desc;");
            var transactions = new List<TransactionData>();
            for (int i = 0; i < transaction.Rows.Count; i++)
            {
                var temp_data = new TransactionData();
                temp_data.Id = Convert.ToInt32(transaction.Rows[i][0]);
                temp_data.Type = (TransactionType)transaction.Rows[i][1];
                temp_data.Amount = Convert.ToDouble(transaction.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(transaction.Rows[i][3]);
                transactions.Add(temp_data);
            }

            var loan = db_helper.GetData($"select * from {DTLoan.TableName} order by {DTLoan.DateTime} desc;");
            var loans = new List<LoanData>();
            for (int i = 0; i < loan.Rows.Count; i++)
            {
                var temp_data = new LoanData();
                temp_data.Id = Convert.ToInt32(loan.Rows[i][0]);
                temp_data.ClientId = Convert.ToInt32(loan.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(loan.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(loan.Rows[i][3]);
                loans.Add(temp_data);
            }

            var collection = db_helper.GetData($"select * from {DTCollection.TableName} order by {DTCollection.DateTime} desc;");
            var collections = new List<CollectionData>();
            for (int i = 0; i < collection.Rows.Count; i++)
            {
                var temp_data = new CollectionData();
                temp_data.Id = Convert.ToInt32(collection.Rows[i][0]);
                temp_data.LoadId = Convert.ToInt32(collection.Rows[i][1]);
                temp_data.Amount = Convert.ToDouble(collection.Rows[i][2]);
                temp_data.DateTime = Convert.ToString(collection.Rows[i][3]);
                collections.Add(temp_data);
            }

            var starting_date = transaction.Rows[transaction.Rows.Count - 1][3];
            var current_date = Convert.ToDateTime(starting_date);

            Records = new List<DailyRecords>();
            while(current_date<=DateTime.Now.Date)
            {
                var records = new DailyRecords();
                records.DateTime = current_date;
                for(int i = 0; i < transactions.Count; i++)
                {
                    if(current_date == transactions[i].GetDateTime())
                        records.Transactions.Add(transactions[i]);
                }
                for (int i = 0; i < loans.Count; i++)
                {
                    if (current_date == loans[i].GetDateTime())
                        records.Loans.Add(loans[i]);
                }
                for (int i = 0; i < collections.Count; i++)
                {
                    if (current_date == collections[i].GetDateTime())
                        records.Collections.Add(collections[i]);
                }
                Records.Add(records);
                current_date = current_date.AddDays(1);
            }
        }
        internal class DailyRecords
        {
            internal DateTime DateTime { get; set; }
            internal List<TransactionData> Transactions { get; set; }
            internal List<LoanData> Loans { get; set; }
            internal List<CollectionData> Collections { get; set; }

            internal DailyRecords()
            {
                this.Transactions = new List<TransactionData>();
                this.Loans = new List<LoanData>();
                this.Collections = new List<CollectionData>();
            }
            internal double TotalTransactions()
            {
                double amount = 0;
                if (Transactions.Count > 0)
                {
                    foreach (var data in Transactions)
                    {
                        if (data.Type == TransactionType.Deposit)
                            amount += data.Amount;
                        else
                            amount -= data.Amount;
                    }
                }
                return amount;
            }
            internal double TotalLoans()
            {
                double amount = 0;
                if (Loans.Count > 0)
                {
                    foreach (var data in Loans)
                        amount += data.Amount;
                }
                return amount;
            }
            internal double TotalCollections()
            {
                double amount = 0;
                if (Collections.Count > 0)
                {
                    foreach (var data in Transactions)
                        amount += data.Amount;
                }
                return amount;
            }
            internal double TotalCapital()
            {
                double amount = 0;
                if (Collections.Count > 0)
                {
                    foreach (var data in Transactions)
                        amount += data.Amount;
                    amount = amount * 0.8;
                }
                return amount;
            }
            internal double TotalProfit()
            {
                double amount = 0;
                if (Collections.Count > 0)
                {
                    foreach (var data in Transactions)
                        amount += data.Amount;
                    amount = amount * 0.2;
                }
                return amount;
            }
        }
        internal struct TransactionData
        {
            internal int Id { get; set; }
            internal TransactionType Type { get; set; }
            internal double Amount { get; set; }
            internal string DateTime { get; set; }
            //for testing
            internal void Print()
            {
                Trace.WriteLine($"{this.Id}:{this.Type}:{this.Amount}:{this.DateTime}");
            }
            internal DateTime GetDateTime()
            {
                return Convert.ToDateTime(this.DateTime);
            }
        }
        internal struct LoanData
        {
            internal int Id { get; set; }
            internal int ClientId { get; set; }
            internal double Amount { get; set; }
            internal string DateTime { get; set; }
            //for testing
            internal void Print()
            {
                Trace.WriteLine($"{this.Id}:{this.ClientId}:{this.Amount}:{this.DateTime}");
            }
            internal DateTime GetDateTime()
            {
                return Convert.ToDateTime(this.DateTime);
            }
        }
        internal struct CollectionData
        {
            internal int Id { get; set; }
            internal int LoadId { get; set; }
            internal double Amount { get; set; }
            internal string DateTime { get; set; }
            //for testing
            internal void Print()
            {
                Trace.WriteLine($"{this.Id}:{this.LoadId}:{this.Amount}:{this.DateTime}");
            }
            internal DateTime GetDateTime()
            {
                return Convert.ToDateTime(this.DateTime);
            }
        }
    }
}
