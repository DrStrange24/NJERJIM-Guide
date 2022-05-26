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
            SetDGV();
        }

        private void SetDGV()
        {
            var db_helper = new DatabaseHelper();
            var query = $"select * from {DTLoan.TableName} order by {DTLoan.DateTime} desc;";
            db_helper.SetDataGridView(loanDataGridView, query);

            var data = db_helper.GetData($"select * from {DTLoan.TableName}");
            totalLoanValueLabel.Text = CurrencyFormat.ToString(LoanData.TotalAmount(LoanData.GetList(data)));
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"INSERT INTO {DTLoan.TableName} ({DTLoan.ClientId}, {DTLoan.Amount}, {DTLoan.DateTime}) " +
                $"VALUES('{clientIdTextBox.Text}', '{amountTextBox.Text}', '{dateTimeTextBox.Text}');");
            SetDGV();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"DELETE FROM {DTLoan.TableName} WHERE {DTLoan.Id}={selectedIdLabel.Text};");
            SetDGV();
        }

        private void loanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                var selectedRow = loanDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[0].Value.ToString();
                clientIdTextBox.Text = selectedRow[1].Value.ToString();
                amountTextBox.Text = selectedRow[2].Value.ToString();
                dateTimeTextBox.Text = selectedRow[3].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void dateTimeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) addButton_Click(null, null);
        }
    }
}
