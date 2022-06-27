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
            void SetTotalLoan()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select * from {DTLoan.Table}");
                totalLoanValueLabel.Text = CurrencyFormat.ToString(DSLoan.TotalAmount(DSLoan.GetList(data)));
            }
            

            SetDataGridView();
            SetTotalLoan();
            SetClientComboBox();
        }
        private void SetClientComboBox()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTClient.Id},{DTClient.FirstName} from {DTClient.Table};");
            clientComboBox.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var client = new DSClient();
                client.Id = Convert.ToInt32(data.Rows[i][0]);
                client.FirstName = Convert.ToString(data.Rows[i][1]);
                if (client.IsFullyPaid)
                    clientComboBox.Items.Add(client.Id + " - " + client.FirstName);
            }
        }
        private void SetDataGridView()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTLoan.Id} as [ID],{DTLoan.ClientId} [Client ID],{DTClient.FirstName} as [First Name],{DTLoan.Item} as [Item]," +
                $"{DTLoan.Amount} as [Amount],{DTLoan.Interest} as [Interest],{DTLoan.DeadlineInDays} as [Deadline # Day],{DTLoan.DateTime} as [Date]" +
                    $",{DTLoan.Remarks} as [Remarks] from {DTLoan.Table} join {DTClient.Table} on {DTLoan.ClientId}={DTClient.Id} where {DTClient.FirstName} like '%{searchTextBox.Text}%' order by {DTLoan.DateTime} desc;");
            DataTableHelper.ChangeColumnDatatypes(data,"Amount",typeof(string));
            DataTableHelper.ChangeColumnDatatypes(data,"Interest",typeof(string));
            data.Columns.Add(new DataColumn("Total Debt", typeof(string)));
            data.Columns.Add(new DataColumn("Completed Bill", typeof(string)));
            data.Columns.Add(new DataColumn("Outstanding Bill", typeof(string)));
            data.Columns.Add(new DataColumn("Deadline", typeof(string)));
            data.Columns.Add(new DataColumn("Row", typeof(int)));
            data.Columns.Add(new DataColumn("Daily Payment", typeof(string)));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var loan = new DSLoan();
                loan.Id = Convert.ToInt32(data.Rows[i]["ID"]);
                loan.Amount = Convert.ToDouble(data.Rows[i]["Amount"]);
                loan.Interest = Convert.ToDouble(data.Rows[i]["Interest"]);
                loan.DateTime = Convert.ToString(data.Rows[i]["Date"]);
                loan.DeadlineInDays = Convert.ToInt32(data.Rows[i]["Deadline # Day"]);

                data.Rows[i]["Completed Bill"] = CurrencyFormat.ToString(loan.CompletedBill);
                data.Rows[i]["Total Debt"] = CurrencyFormat.ToString(loan.TotalDebt);
                data.Rows[i]["Amount"] = CurrencyFormat.ToString(loan.Amount);
                data.Rows[i]["Interest"] = CurrencyFormat.ToString(loan.Interest);
                data.Rows[i]["Outstanding Bill"] = CurrencyFormat.ToString(loan.OutstandingBill);
                data.Rows[i]["Date"] = DateTimeFormatHelper.DateTimeToStringUI(data.Rows[i]["Date"]);
                data.Rows[i]["Deadline"] = DateTimeFormatHelper.DateTimeToStringUI(loan.DeadLine);
                data.Rows[i]["Row"] = i+1;
                data.Rows[i]["Daily Payment"] = CurrencyFormat.ToString(loan.DailyPayment);
            }
            data.Columns["Row"].SetOrdinal(0);
            data.Columns["Date"].SetOrdinal(4);
            data.Columns["Item"].SetOrdinal(5);
            data.Columns["Amount"].SetOrdinal(6);
            data.Columns["Interest"].SetOrdinal(7);
            data.Columns["Total Debt"].SetOrdinal(8);
            data.Columns["Completed Bill"].SetOrdinal(9);
            data.Columns["Outstanding Bill"].SetOrdinal(10);
            data.Columns["Deadline # Day"].SetOrdinal(11);
            data.Columns["Daily Payment"].SetOrdinal(12);
            data.Columns["Deadline"].SetOrdinal(13);
            data.Columns["Remarks"].SetOrdinal(14);
            data.Columns["Amount"].ColumnName = "Debt";
            loanDataGridView.DataSource = data;
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
                if (clientComboBox.SelectedIndex < 0 || string.IsNullOrWhiteSpace(amountTextBox.Text) || string.IsNullOrWhiteSpace(interestTextBox.Text) || string.IsNullOrWhiteSpace(deadlineInDaysTextBox.Text))
                    return false;
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
                int client_id = Convert.ToInt32(clientComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                switch (loanButton.Text)
                {
                    case "Create":
                        db_helper.Manipulate($"INSERT INTO {DTLoan.Table} ({DTLoan.ClientId}, {DTLoan.Amount}, {DTLoan.DateTime},{DTLoan.Remarks},{DTLoan.Interest},{DTLoan.Item},{DTLoan.DeadlineInDays}) " +
                            $"VALUES({client_id}, {CurrencyFormat.ToDouble(amountTextBox.Text)}, '{DateTimeFormatHelper.DateTimeToStringDB(loanDateTimePicker.Value)}','" +
                            $"{remarksRichTextBox.Text}',{CurrencyFormat.ToDouble(interestTextBox.Text)},{item()},{deadlineInDaysTextBox.Text});");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTLoan.Table} SET {DTLoan.ClientId} = {client_id}, {DTLoan.Amount} = {CurrencyFormat.ToDouble(amountTextBox.Text)} , {DTLoan.DateTime} = '{DateTimeFormatHelper.DateTimeToStringDB(loanDateTimePicker.Value)}' " +
                            $",{DTLoan.Remarks} = '{remarksRichTextBox.Text}',{DTLoan.Interest} = {CurrencyFormat.ToDouble(interestTextBox.Text)},{DTLoan.Item} = {item()}," +
                            $"{DTLoan.DeadlineInDays} = {deadlineInDaysTextBox.Text} WHERE {DTLoan.Id}={selectedIdLabel.Text};");
                        break;
                }
                InitializeData();
                clearInputsButton_Click(null, null);
            }
            else
                MessageBox.Show("Invalid inputs");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIdLabel.Text))
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"DELETE FROM {DTLoan.Table} WHERE {DTLoan.Id}={selectedIdLabel.Text};");
                InitializeData();
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
            clientComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            loanDateTimePicker.Value = DateTime.Now;
            remarksRichTextBox.Text = string.Empty;
            interestTextBox.Text = string.Empty;
            itemTextBox.Text = string.Empty;
            deadlineInDaysTextBox.Text = string.Empty;
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

                //column name are base on InitializeData() method on setdatagridview query
                selectedIdLabel.Text = selectedRow["ID"].Value.ToString();
                void SetClientComboBox()
                {
                    var selected_client = selectedRow["Client ID"].Value + " - " + selectedRow["First Name"].Value;
                    clientComboBox.Items.Add(selected_client);
                    clientComboBox.SelectedItem = selected_client;
                }
                this.SetClientComboBox();
                SetClientComboBox();
                amountTextBox.Text = selectedRow["Debt"].Value.ToString();
                loanDateTimePicker.Value = DateTimeFormatHelper.StringUIToDateTime(selectedRow["Date"].Value);
                remarksRichTextBox.Text = selectedRow["Remarks"].Value.ToString();
                interestTextBox.Text = selectedRow["Interest"].Value.ToString();
                itemTextBox.Text = selectedRow["Item"].Value.ToString();
                deadlineInDaysTextBox.Text = selectedRow["Deadline # Day"].Value.ToString();

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
    }
}
