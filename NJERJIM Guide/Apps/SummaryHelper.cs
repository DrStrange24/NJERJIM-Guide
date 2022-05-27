using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJERJIM_Guide.Apps
{
    class SummaryHelper
    {
        internal List<DailyRecords> Records { get; private set; }
        internal SummaryHelper()
        {
            var db_helper = new DatabaseHelper();

            var transaction = db_helper.GetData($"select * from {DTTransaction.TableName} order by {DTTransaction.DateTime} desc;");
            var transactions = TransactionData.GetList(transaction);

            var loan = db_helper.GetData($"select * from {DTLoan.TableName} order by {DTLoan.DateTime} desc;");
            var loans = LoanData.GetList(loan);

            var collection = db_helper.GetData($"select * from {DTCollection.TableName} order by {DTCollection.DateTime} desc;");
            var collections = CollectionData.GetList(collection);

            if (transaction.Rows.Count > 0)
            {
                var starting_date = transaction.Rows[transaction.Rows.Count - 1][3];
                var current_date = DatabaseHelper.StringToDateTime(starting_date);

                Records = new List<DailyRecords>();
                while (current_date.Date <= DateTime.Now.Date)
                {
                    var records = new DailyRecords();
                    records.DateTime = current_date;
                    for (int i = 0; i < transactions.Count; i++)
                    {
                        if (current_date == transactions[i].GetDateTime())
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
                    foreach (var data in Collections)
                        amount += data.Amount;
                }
                return amount;
            }
            internal double TotalCapital()
            {
                double amount = 0;
                if (Collections.Count > 0)
                {
                    foreach (var data in Collections)
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
                    foreach (var data in Collections)
                        amount += data.Amount;
                    amount = amount * 0.2;
                }
                return amount;
            }
        }
    }
}
