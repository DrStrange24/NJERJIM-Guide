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
    public partial class Supply : Form
    {
        public Supply()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            void SetDataGridView()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTTransaction.Id} as [ID],{DTTransaction.Type} as [Transaction Type],{DTTransaction.Amount} as [Amount]" +
                    $",{DTTransaction.DateTime} as [Date],{DTTransaction.Remarks} as [Remarks] from {DTTransaction.Table} order by {DTTransaction.DateTime} desc;");
                DataTableHelper.ChangeColumnDatatypes(data, "Amount", typeof(string));
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["Amount"] = CurrencyFormat.ToString(data.Rows[i]["Amount"]);
                    data.Rows[i]["Date"] = DateTimeFormatHelper.DateTimeToStringUI(data.Rows[i]["Date"]);
                }
                transactionDataGridView.DataSource = data;
            }
            void SetTotalSupplyAndTotalExpenses()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select * from {DTTransaction.Table}");
                var transactions = DSTransaction.GetList(data);
                totalSupplyValueLabel.Text = CurrencyFormat.ToString(DSTransaction.TotalSupply(transactions));
                totalExpensesLabel.Text = CurrencyFormat.ToString(DSTransaction.TotalExpenses(transactions));
            }
            void SetTypeComboBox()
            {
                var items = Enum.GetNames(typeof(TransactionType));
                transactionTypeComboBox.Items.Clear();
                transactionTypeComboBox.Items.AddRange(items);
            }

            SetDataGridView();
            SetTotalSupplyAndTotalExpenses();
            SetTypeComboBox();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            bool ValidInputs()
            {
                if (string.IsNullOrWhiteSpace(transactionTypeComboBox.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(amountTextBox.Text))
                    return false;
                return true;
            }

            if (ValidInputs())
            {
                var db_helper = new DatabaseHelper();
                switch (createButton.Text)
                {
                    case "Create":
                        db_helper.Manipulate($"INSERT INTO {DTTransaction.Table} ({DTTransaction.Type}, {DTTransaction.Amount}, {DTTransaction.DateTime}, {DTTransaction.Remarks}) " +
                            $"VALUES('{transactionTypeComboBox.SelectedItem}', '{amountTextBox.Text}', '{DateTimeFormatHelper.DateTimeToStringDB(transactionDateTimePicker.Value)}','{remarksRichTextBox.Text}');");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTTransaction.Table} SET {DTTransaction.Type} = '{transactionTypeComboBox.SelectedItem}', " +
                            $"{DTTransaction.Amount} = {CurrencyFormat.ToDouble(amountTextBox.Text)} , " +
                            $"{DTTransaction.DateTime} = '{DateTimeFormatHelper.DateTimeToStringDB(transactionDateTimePicker.Value)}'" +
                            $",{DTTransaction.Remarks} = '{remarksRichTextBox.Text}'" +
                            $" WHERE {DTTransaction.Id}={selectedIdLabel.Text};");
                        break;
                }
                InitializeData();
                clearInputsButton_Click(null, null);
            }
            else
                MessageBox.Show("Invalid inputs");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedIdLabel.Text))
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"DELETE FROM {DTTransaction.Table} WHERE {DTTransaction.Id}={selectedIdLabel.Text};");
                InitializeData();
                clearInputsButton_Click(null, null);
            }
        }
        private void createTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) createButton_Click(null, null);
        }

        private void clearInputsButton_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = string.Empty;
            transactionTypeComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            transactionDateTimePicker.Value = DateTime.Now;
            remarksRichTextBox.Text = string.Empty;
        }

        private void transactionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = transactionDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[0].Value.ToString();
                transactionTypeComboBox.SelectedItem = selectedRow[1].Value.ToString();
                amountTextBox.Text = selectedRow[2].Value.ToString();
                transactionDateTimePicker.Value = DateTimeFormatHelper.StringUIToDateTime(selectedRow[3].Value);
                remarksRichTextBox.Text = selectedRow[4].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void selectedIdLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (selectedIdLabel.Visible)
                createButton.Text = "Save";
            else
                createButton.Text = "Create";
        }
    }
}
