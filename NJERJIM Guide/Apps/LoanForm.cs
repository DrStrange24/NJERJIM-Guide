using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NJERJIM_Guide.Apps.SummaryHelper;

namespace NJERJIM_Guide
{
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent(); 
            InitializeData();
        }

        private void InitializeData()
        {
            paidComboBox.SelectedIndex = 0;
            SetClientComboBox();
            SetDataGridView();
        }
        private void SetClientComboBox()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTClient.Id},{DTClient.FirstName} from {DTClient.Table};");
            customersComboBox.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var client = new DSCustomer();
                client.Id = Convert.ToInt32(data.Rows[i][0]);
                client.FirstName = Convert.ToString(data.Rows[i][1]);
                customersComboBox.Items.Add(client.Id + " - " + client.FirstName);
            }
        }
        private void SetDataGridView()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTLoan.SId},{DTLoan.SCustomerId},{DTClient.SFirstName},{DTLoan.SItem},{DTLoan.SAmount},{DTLoan.SInterest}," +
                $"{DTLoan.SDailyPayment},{DTLoan.SDateTime},{DTLoan.SRemarks} from {DTLoan.Table} join {DTClient.Table} on {DTLoan.CustomerId}={DTClient.Id} " +
                $"where {DTClient.FirstName} like '%{searchTextBox.Text}%' order by {DTLoan.DateTime} desc;");
            DataTableHelper.ChangeColumnDatatypes(data,DTLoan.DAmount,typeof(string));
            DataTableHelper.ChangeColumnDatatypes(data,DTLoan.DInterest,typeof(string));
            DataTableHelper.ChangeColumnDatatypes(data,DTLoan.DDailyPayment,typeof(string));
            string totalDebt = "Total Debt";
            string completedBill = "Completed Bill";
            string outstandingBill = "Outstanding Bill";
            string deadline = "Deadline";
            string deadlineInNumberOfDays = "Deadline in # of days";
            string interestInPercent = "Interest In Percent";
            data.Columns.Add(new DataColumn(totalDebt, typeof(string)));
            data.Columns.Add(new DataColumn(completedBill, typeof(string)));
            data.Columns.Add(new DataColumn(outstandingBill, typeof(string)));
            data.Columns.Add(new DataColumn(deadline, typeof(string)));
            data.Columns.Add(new DataColumn(deadlineInNumberOfDays, typeof(int)));
            data.Columns.Add(new DataColumn(interestInPercent, typeof(string)));
            double totalLoanCapital = 0;
            double totalProfitReceive = 0;
            double expectedDailyRepayment = 0;
            double expectedDailyIncome = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var loan = new DSLoan();
                loan.Id = Convert.ToInt32(data.Rows[i][DTLoan.DId]);
                loan.Amount = Convert.ToDouble(data.Rows[i][DTLoan.DAmount]);
                loan.Interest = Convert.ToDouble(data.Rows[i][DTLoan.DInterest]);
                loan.DateTimeDB = Convert.ToString(data.Rows[i][DTLoan.DDateTime]);
                loan.ExpectedDailyPayment = Convert.ToDouble(data.Rows[i][DTLoan.DDailyPayment]);

                data.Rows[i][completedBill] = CurrencyFormat.ToString(loan.CompletedBill);
                data.Rows[i][totalDebt] = CurrencyFormat.ToString(loan.TotalDebt);
                data.Rows[i][DTLoan.DAmount] = CurrencyFormat.ToString(loan.Amount);
                data.Rows[i][DTLoan.DInterest] = CurrencyFormat.ToString(loan.Interest);
                data.Rows[i][outstandingBill] = CurrencyFormat.ToString(loan.OutstandingBill);
                data.Rows[i][DTLoan.DDateTime] = DateTimeFormatHelper.DateTimeToStringUI(data.Rows[i][DTLoan.DDateTime]);
                data.Rows[i][deadline] = DateTimeFormatHelper.DateTimeToStringUI(loan.DeadLine);
                data.Rows[i][deadlineInNumberOfDays] = loan.DeadlineInDays;
                data.Rows[i][DTLoan.DDailyPayment] = CurrencyFormat.ToString(loan.ExpectedDailyPayment);
                data.Rows[i][interestInPercent] = loan.InterestInPercent + "%";

                if (!loan.IsFullyPaid)
                {
                    expectedDailyRepayment += loan.ExpectedDailyPayment;
                    expectedDailyIncome += loan.ExpectedDailyIncome;
                }
                switch (paidComboBox.SelectedItem)
                {
                    case "All Records":
                        totalLoanCapital += loan.Amount;
                        totalProfitReceive += loan.CompletedBillProfit;
                        break;
                    case "Completed":
                        //if loan is not fully paid then remove current from the list
                        if (!loan.IsFullyPaid)
                        {
                            data.Rows.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            totalLoanCapital += loan.Amount;
                            totalProfitReceive += loan.CompletedBillProfit;
                        }
                        break;
                    case "Active":
                        //if loan is fully paid then remove current from the list
                        if (loan.IsFullyPaid)
                        {
                            data.Rows.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            totalLoanCapital += loan.Amount;
                            totalProfitReceive += loan.CompletedBillProfit;
                        }
                        break;
                }
            }
            data.Columns[DTLoan.DDateTime].SetOrdinal(3);
            data.Columns[DTLoan.DItem].SetOrdinal(4);
            data.Columns[DTLoan.DAmount].SetOrdinal(5);
            data.Columns[DTLoan.DInterest].SetOrdinal(6);
            data.Columns[totalDebt].SetOrdinal(7);
            data.Columns[interestInPercent].SetOrdinal(8);
            data.Columns[completedBill].SetOrdinal(9);
            data.Columns[outstandingBill].SetOrdinal(10);
            data.Columns[DTLoan.DDailyPayment].SetOrdinal(11);
            data.Columns[deadlineInNumberOfDays].SetOrdinal(12);
            data.Columns[deadline].SetOrdinal(13);
            data.Columns[DTLoan.DRemarks].SetOrdinal(14);
            totalLoanValueLabel.Text = CurrencyFormat.ToString(totalLoanCapital);
            totalProfitLabel.Text = CurrencyFormat.ToString(totalProfitReceive);
            expectedDailyRepaymentLabel.Text = CurrencyFormat.ToString(expectedDailyRepayment);
            loanDataGridView.DataSource = data;
            numberOfLoansLabel.Text = data.Rows.Count.ToString();
            expectedDailyIncomeLabel.Text = CurrencyFormat.ToString(expectedDailyIncome);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            bool ValidInputs()
            {
                if (customersComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a customers ID");
                    return false;
                }

                if(string.IsNullOrWhiteSpace(amountTextBox.Text))
                {
                    MessageBox.Show("Please Insert an amount");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(interestTextBox.Text))
                {
                    MessageBox.Show("Please Insert an interest");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(dailyPaymentTextBox.Text))
                {
                    MessageBox.Show("Please Insert a dailay payment");
                    return false;
                }

                bool IsSupplyAvailable()
                {
                    var summary = new SummaryHelper();
                    if (CurrencyFormat.ToDouble(summary.CashOnHand) - CurrencyFormat.ToDouble(amountTextBox.Text)>0)
                        return true;
                    MessageBox.Show("Supply is not available.");
                    return false;
                }

                if (!IsSupplyAvailable()) return false;

                return true;
            }

            if (ValidInputs())
            {
                object item()
                {
                    if (string.IsNullOrWhiteSpace(itemTextBox.Text))
                        return "null";
                    return $"'{itemTextBox.Text}'";
                }
                int client_id = Convert.ToInt32(customersComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                switch (loanButton.Text)
                {
                    case "Create":
                        db_helper.Manipulate($"INSERT INTO {DTLoan.Table} ({DTLoan.CustomerId}, {DTLoan.Amount}, {DTLoan.DateTime},{DTLoan.Remarks},{DTLoan.Interest},{DTLoan.Item},{DTLoan.DailyPayment}) " +
                            $"VALUES({client_id}, {CurrencyFormat.ToDouble(amountTextBox.Text)}, '{DateTimeFormatHelper.DateTimeToStringDB(loanDateTimePicker.Value)}','" +
                            $"{remarksRichTextBox.Text}',{CurrencyFormat.ToDouble(interestTextBox.Text)},{item()},{dailyPaymentTextBox.Text});");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTLoan.Table} SET {DTLoan.CustomerId} = {client_id}, {DTLoan.Amount} = {CurrencyFormat.ToDouble(amountTextBox.Text)} , {DTLoan.DateTime} = '{DateTimeFormatHelper.DateTimeToStringDB(loanDateTimePicker.Value)}' " +
                            $",{DTLoan.Remarks} = '{remarksRichTextBox.Text}',{DTLoan.Interest} = {CurrencyFormat.ToDouble(interestTextBox.Text)},{DTLoan.Item} = {item()}," +
                            $"{DTLoan.DailyPayment} = {dailyPaymentTextBox.Text} WHERE {DTLoan.Id}={selectedIdLabel.Text};");
                        break;
                }
                SetDataGridView();
                clearInputsButton_Click(null, null);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIdLabel.Text))
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"DELETE FROM {DTLoan.Table} WHERE {DTLoan.Id}={selectedIdLabel.Text};");
                SetDataGridView();
                clearInputsButton_Click(null,null);
            }
            else
                MessageBox.Show("Please select a loan first!");
        }

        private void clearInputsButton_Click(object sender, EventArgs e)
        {
            SetClientComboBox();
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = null;
            customersComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            loanDateTimePicker.Value = DateTime.Now;
            remarksRichTextBox.Text = string.Empty;
            interestTextBox.Text = string.Empty;
            itemTextBox.Text = string.Empty;
            dailyPaymentTextBox.Text = string.Empty;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void loanDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = loanDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[DTLoan.DId].Value.ToString();
                void SetClientComboBox()
                {
                    var selected_client = selectedRow[DTLoan.DCustomerId].Value + " - " + selectedRow[DTClient.DFirstName].Value;
                    customersComboBox.Items.Add(selected_client);
                    customersComboBox.SelectedItem = selected_client;
                }
                this.SetClientComboBox();
                SetClientComboBox();
                amountTextBox.Text = selectedRow[DTLoan.DAmount].Value.ToString();
                loanDateTimePicker.Value = DateTimeFormatHelper.StringUIToDateTime(selectedRow[DTLoan.DDateTime].Value);
                remarksRichTextBox.Text = selectedRow[DTLoan.DRemarks].Value.ToString();
                interestTextBox.Text = selectedRow[DTLoan.DInterest].Value.ToString();
                itemTextBox.Text = selectedRow[DTLoan.DItem].Value.ToString();
                dailyPaymentTextBox.Text = selectedRow[DTLoan.DDailyPayment].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void selectedIdLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (selectedIdLabel.Visible)
                loanButton.Text = "Save";
            else
                loanButton.Text = "Create";
        }

        private void enterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter) createButton_Click(null, null);
        }

        private void paidComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataGridView();
        }
    }
}
