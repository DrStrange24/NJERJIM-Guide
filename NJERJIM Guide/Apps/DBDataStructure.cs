using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide.Apps
{
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
        internal static List<DSTransaction> GetList(DataTable data)
        {
            var list = new List<DSTransaction>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new DSTransaction();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.Type = Convert.ToString(data.Rows[i][1]);
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
        internal int Id { get; set; }
        internal int ClientId { get; set; }
        internal string Item { get; set; }
        internal double Amount { get; set; }
        /// <summary>
        ///     Interest Amount.
        /// </summary>
        internal double Interest { get; set; }
        internal double DailyPayment { get; set; }
        /// <summary>
        ///     Date time in database format which is something string.
        /// </summary>
        internal string DateTimeDB { get; set; }
        internal string Remarks { get; set; }

        internal double TotalDebt
        {
            get
            {
                return Amount + Interest;
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
                return TotalDebt - CompletedBill;
            }
        }
        internal bool IsFullyPaid
        {
            get
            {
                if (this.TotalDebt == this.CompletedBill)
                    return true;
                return false;
            }
        }
        internal DateTime DeadLine
        {
            get
            {
                int deadline_number_of_days = DeadlineInDays;
                var datetime = DateTimeDT;
                while (deadline_number_of_days > 0)
                {
                    datetime = datetime.AddDays(1);
                    if (DateTimeFormatHelper.GetDay(datetime) == "Sunday")
                        datetime = datetime.AddDays(1);
                    deadline_number_of_days--;
                }
                return datetime;
            }
        }
        /// <summary>
        ///     Date time format of c# System.DateTime instead of database string format datetime.
        /// </summary>
        internal DateTime DateTimeDT
        {
            get
            {
                return DateTimeFormatHelper.StringDBToDateTime(this.DateTimeDB);
            }
        }
        internal int DeadlineInDays
        {
            get
            {
                return Convert.ToInt32(TotalDebt / DailyPayment);
            }
        }
        /// <summary>
        ///     Interest in percentage instead of interest amount. How many percent is the interest
        /// </summary>
        internal double InterestInPercent
        {
            get
            {
                //wait ka lang taposon taka.
                return 20;
            }
        }

        internal static List<DSLoan> GetList(DataTable data)
        {
            var list = new List<DSLoan>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var temp_data = new DSLoan();
                temp_data.Id = Convert.ToInt32(data.Rows[i][0]);
                temp_data.ClientId = Convert.ToInt32(data.Rows[i][1]);
                temp_data.Item = Convert.ToString(data.Rows[i][2]);
                temp_data.Amount = Convert.ToDouble(data.Rows[i][3]);
                temp_data.Interest = Convert.ToDouble(data.Rows[i][4]);
                temp_data.DailyPayment = Convert.ToDouble(data.Rows[i][5]);
                temp_data.DateTimeDB = Convert.ToString(data.Rows[i][6]);
                temp_data.Remarks = Convert.ToString(data.Rows[i][7]);
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
