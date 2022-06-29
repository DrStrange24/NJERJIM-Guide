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
        internal string CashOnHand { get; private set; }
        internal string TotalSupply { get; private set; }
        internal string Profit { get; private set; }
        internal string CashOnHandWithProfit { get; private set; }
        internal SummaryHelper()
        {
            void InitializeRecords()
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
                    var current_date = DateTimeFormatHelper.StringDBToDateTime(starting_date);

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
                            if (current_date.Date == loans[i].DateTimeDT.Date)
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
            void InitializeSummaryProperties()
            {
                var records = this.Records;

                double  CashOnHand = 0;
                double TotalSupply = 0;
                double Profit = 0;

                if (records != null)
                {
                    foreach (var record in records)
                    {
                        CashOnHand += record.TotalTransactions;
                        TotalSupply += record.TotalTransactions;
                        CashOnHand -= record.TotalLoans;
                        CashOnHand += record.TotalCapital;
                        Profit += record.TotalProfit;
                        Profit -= record.TotalWithdrawnProfit;
                    }
                }
                this.CashOnHand = CurrencyFormat.ToString(CashOnHand);
                this.TotalSupply = CurrencyFormat.ToString(TotalSupply);
                this.Profit = CurrencyFormat.ToString(Profit);
                this.CashOnHandWithProfit = CurrencyFormat.ToString(Profit + CashOnHand);
            }
            InitializeRecords();
            InitializeSummaryProperties();
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
            internal double TotalTransactions
            {
                get
                {
                    double amount = 0;
                    if (Transactions.Count > 0)
                    {
                        foreach (var data in Transactions)
                        {
                            if (data.Type == TransactionType.Deposit.ToString())
                                amount += data.Amount;
                            else if (data.Type == TransactionType.Withdraw.ToString())
                                amount -= data.Amount;
                        }
                    }
                    return amount;
                }
            }
            internal double TotalLoans
            {
                get
                {
                    double amount = 0;
                    if (Loans.Count > 0)
                    {
                        foreach (var data in Loans)
                            amount += data.Amount;
                    }
                    return amount;
                }
            }
            internal double TotalCollections
            {
                get
                {
                    double amount = 0;
                    if (Collections.Count > 0)
                    {
                        foreach (var data in Collections)
                            amount += data.Amount;
                    }
                    return amount;
                }
            }
            internal double TotalCapital
            {
                get
                {
                    double amount = 0;
                    if (Collections.Count > 0)
                    {
                        foreach (var data in Collections)
                        {
                            //wait ka lang taposon taka.
                            amount += data.Amount / (1 + data.LoanId / 100);
                        }
                    }
                    return amount;
                }
            }
            internal double TotalProfit
            {
                get
                {
                    double amount = this.TotalCollections - this.TotalCapital;
                    return amount;
                }
            }
            internal double TotalWithdrawnProfit
            {
                get
                {
                    double amount = 0;
                    if (Transactions.Count > 0)
                    {
                        foreach (var data in Transactions)
                        {
                            if (data.Type == TransactionType.WithdrawProfit.ToString())
                                amount += data.Amount;
                        }
                    }
                    return amount;
                }
            }
            internal DailyRecords()
            {
                this.Transactions = new List<DSTransaction>();
                this.Loans = new List<DSLoan>();
                this.Collections = new List<DSCollection>();
            }
        }
    }
}
