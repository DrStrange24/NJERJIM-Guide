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
            var transaction = db_helper.GetData($"select * from {DTTransaction.Table} order by {DTTransaction.DateTime} desc;");
            var transactions = DSTransaction.GetList(transaction);

            var loan = db_helper.GetData($"select * from {DTLoan.Table} order by {DTLoan.DateTime} desc;");
            var loans = DSLoan.GetList(loan);

            var collection = db_helper.GetData($"select * from {DTCollection.Table} order by {DTCollection.DateTime} desc;");
            var collections = DSCollection.GetList(collection);

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
                        if (current_date.Date == transactions[i].DateTimeFormat.Date)
                            records.Transactions.Add(transactions[i]);
                    }
                    for (int i = 0; i < loans.Count; i++)
                    {
                        if (current_date.Date == loans[i].DateTimeFormat.Date)
                            records.Loans.Add(loans[i]);
                    }
                    for (int i = 0; i < collections.Count; i++)
                    {
                        if (current_date.Date == collections[i].DateTimeFormat.Date)
                            records.Collections.Add(collections[i]);
                    }
                    Records.Add(records);
                    current_date = current_date.AddDays(1);
                }
            }
        }
        /// <summary>
        ///     Daily Records Class used to keep data on daily basis.
        /// </summary>
        internal class DailyRecords
        {
            internal DateTime DateTime { get; set; }
            internal List<DSTransaction> Transactions { get; set; }
            internal List<DSLoan> Loans { get; set; }
            internal List<DSCollection> Collections { get; set; }

            internal DailyRecords()
            {
                this.Transactions = new List<DSTransaction>();
                this.Loans = new List<DSLoan>();
                this.Collections = new List<DSCollection>();
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
