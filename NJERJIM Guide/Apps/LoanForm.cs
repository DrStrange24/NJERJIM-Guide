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
            void SetClientComboBox()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTClient.Id},{DTClient.FirstName} from {DTClient.Table};");
                clientComboBox.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var client = new DSClient();
                    client.Id = Convert.ToInt32(data.Rows[i][0]);
                    client.FirstName = Convert.ToString(data.Rows[i][1]);
                    if(client.IsFullyPaid)
                        clientComboBox.Items.Add(client.Id + " - " + client.FirstName);
                }
            }

            SetDataGridView();
            SetTotalLoan();
            SetClientComboBox();
        }
        private void SetDataGridView()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTLoan.Id} as [ID],{DTLoan.ClientId} [Client ID],{DTClient.FirstName} as [First Name],{DTLoan.Amount} as [int Amount],{DTLoan.DateTime} as [Date]" +
                    $",{DTLoan.Remarks} as [Remarks] from {DTLoan.Table} join {DTClient.Table} on {DTLoan.ClientId}={DTClient.Id} where {DTClient.FirstName} like '%{searchTextBox.Text}%' order by {DTLoan.DateTime} desc;");
            data.Columns.Add(new DataColumn("Debt", typeof(string)));
            data.Columns.Add(new DataColumn("Total Debt", typeof(string)));
            data.Columns.Add(new DataColumn("Completed Bill", typeof(string)));
            data.Columns.Add(new DataColumn("Outstanding Bill", typeof(string)));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var loan = new DSLoan();
                loan.Id = Convert.ToInt32(data.Rows[i]["ID"]);
                loan.Amount = Convert.ToDouble(data.Rows[i]["int Amount"]);

                data.Rows[i]["Completed Bill"] = CurrencyFormat.ToString(loan.CompletedBill);
                data.Rows[i]["Total Debt"] = CurrencyFormat.ToString(loan.TotalDebt);
                data.Rows[i]["Debt"] = CurrencyFormat.ToString(loan.Amount);
                data.Rows[i]["Outstanding Bill"] = CurrencyFormat.ToString(loan.OutstandingBill);
                data.Rows[i]["Date"] = DatabaseHelper.DateTimeToStringUI(data.Rows[i]["Date"]);
            }
            data.Columns["Remarks"].SetOrdinal(data.Columns.Count-1);
            data.Columns.Remove("int Amount");
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
                if (clientComboBox.SelectedIndex < 0 || string.IsNullOrWhiteSpace(amountTextBox.Text))
                    return false;
                return true;
            }

            if (ValidInputs())
            {
                int client_id = Convert.ToInt32(clientComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                switch (loanButton.Text)
                {
                    case "Create":
                        db_helper.Manipulate($"INSERT INTO {DTLoan.Table} ({DTLoan.ClientId}, {DTLoan.Amount}, {DTLoan.DateTime},{DTLoan.Remarks}) " +
                            $"VALUES({client_id}, {amountTextBox.Text}, '{DatabaseHelper.DateTimeToStringDB(loanDateTimePicker.Value)}','{remarksRichTextBox.Text}');");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTLoan.Table} SET {DTLoan.ClientId} = {client_id}, {DTLoan.Amount} = {amountTextBox.Text} , {DTLoan.DateTime} = '{DatabaseHelper.DateTimeToStringDB(loanDateTimePicker.Value)}' " +
                            $",{DTLoan.Remarks} = '{remarksRichTextBox.Text}' WHERE {DTLoan.Id}={selectedIdLabel.Text};");
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

        private void dateTimeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) createButton_Click(null, null);
        }

        private void clearInputsButton_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = null;
            clientComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            loanDateTimePicker.Value = DateTime.Now;
            remarksRichTextBox.Text = string.Empty;
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
                clientComboBox.SelectedItem = selectedRow["Client ID"].Value + " - " + selectedRow["First Name"].Value;
                amountTextBox.Text = selectedRow["Debt"].Value.ToString();
                loanDateTimePicker.Value = DatabaseHelper.StringToDateTime(selectedRow["Date"].Value);
                remarksRichTextBox.Text = selectedRow["Remarks"].Value.ToString();

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
    }
}
