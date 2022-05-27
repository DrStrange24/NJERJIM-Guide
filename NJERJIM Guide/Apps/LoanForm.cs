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
            void SetDataGridView()
            {
                var db_helper = new DatabaseHelper();
                db_helper.SetDataGridView(loanDataGridView, $"select {DTLoan.Id} as [ID],{DTLoan.ClientId} [Client ID],{DTClient.FirstName} as [First Name],{DTLoan.Amount} as [Amount],{DTLoan.DateTime} as [Date] from {DTLoan.Table} " +
                    $"join {DTClient.Table} on {DTLoan.ClientId}={DTClient.Id} order by {DTLoan.DateTime} desc;");
            }
            void SetTotalLoan()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select * from {DTLoan.Table}");
                totalLoanValueLabel.Text = CurrencyFormat.ToString(LoanData.TotalAmount(LoanData.GetList(data)));
            }
            void SetClientComboBox()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTClient.Id},{DTClient.FirstName} from {DTClient.Table};");
                clientComboBox.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                    clientComboBox.Items.Add(data.Rows[i][0] + " - " + data.Rows[i][1]);
            }

            SetDataGridView();
            SetTotalLoan();
            SetClientComboBox();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            bool ValidInput()
            {
                if (clientComboBox.SelectedIndex < 0 || string.IsNullOrWhiteSpace(amountTextBox.Text))
                    return false;
                return true;
            }
            if (ValidInput())
            {
                int client_id = Convert.ToInt32(clientComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"INSERT INTO {DTLoan.Table} ({DTLoan.ClientId}, {DTLoan.Amount}, {DTLoan.DateTime}) " +
                    $"VALUES({client_id}, {amountTextBox.Text}, '{DatabaseHelper.DateTimeToString(loanDateTimePicker.Value)}');");
                InitializeData();
                clearInputsButton_Click(null, null);
            }
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

        private void loanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                var selectedRow = loanDataGridView.Rows[e.RowIndex].Cells;

                //column name are base on SetData() method on setdatagridview query
                selectedIdLabel.Text = selectedRow["ID"].Value.ToString();
                clientComboBox.SelectedItem = selectedRow["Client ID"].Value+" - "+ selectedRow["First Name"].Value;
                amountTextBox.Text = selectedRow["Amount"].Value.ToString();
                loanDateTimePicker.Value = DatabaseHelper.StringToDateTime(selectedRow["Date"].Value);

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
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
        }
    }
}
