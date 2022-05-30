using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NJERJIM_Guide.Apps.SummaryHelper;

namespace NJERJIM_Guide
{
    public partial class CollectionForm : Form
    {
        public CollectionForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            void SetDataGridView()
            {
                var db_helper = new DatabaseHelper();
                db_helper.SetDataGridView(collectionDataGridView, $"select {DTCollection.Id} as [ID],{DTCollection.LoanId} as [Loan ID],{DTClient.FirstName} as [First Name]," +
                    $"{DTCollection.Amount} as [Amount],{DTCollection.DateTime} as [Date],{DTCollection.Remarks} as [Remarks] from {DTCollection.Table} join {DTLoan.Table} on {DTCollection.LoanId}={DTLoan.Id} " +
                    $"join {DTClient.Table} on {DTLoan.ClientId}={DTClient.Id} order by {DTCollection.DateTime} desc;");
            }
            void SetTotalCollection()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select * from {DTCollection.Table}");
                totalCollectionValueLabel.Text = CurrencyFormat.ToString(DSCollection.TotalAmount(DSCollection.GetList(data)));
            }
            void SetComboBoxItems()
            {
                var db_helper = new DatabaseHelper();
                var data = db_helper.GetData($"select {DTLoan.Id},{DTLoan.Amount},{DTClient.FirstName} from {DTLoan.Table} join {DTClient.Table} on {DTLoan.ClientId}={DTClient.Id};");
                loanComboBox.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var loan = new DSLoan();
                    loan.Id = Convert.ToInt32(data.Rows[i][0]);
                    loan.Amount = Convert.ToDouble(data.Rows[i][1]);

                    if (!loan.IsFullyPaid)
                        loanComboBox.Items.Add(data.Rows[i][0] + " - " + data.Rows[i][2]);
                }
            }
            SetDataGridView();
            SetTotalCollection();
            SetComboBoxItems();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIdLabel.Text))
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"DELETE FROM {DTCollection.Table} WHERE {DTCollection.Id}={selectedIdLabel.Text};");
                InitializeData();
                clearInputsButton_Click(null, null);
            }
            else
                MessageBox.Show("Please select a loan first!");
            
        }

        private void collectionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = collectionDataGridView.Rows[e.RowIndex].Cells;

                //column name are base on InitializeData() SetDataGridView() method
                selectedIdLabel.Text = selectedRow["ID"].Value.ToString();
                loanComboBox.SelectedItem = selectedRow["Loan ID"].Value + " - " + selectedRow["First Name"].Value;
                amountTextBox.Text = selectedRow["Amount"].Value.ToString();
                collectionDateTimePicker.Value = DatabaseHelper.StringToDateTime(selectedRow["Date"].Value);
                remarksRichTextBox.Text = selectedRow["Remarks"].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void createLoanButton_Click(object sender, EventArgs e)
        {
            bool ValidInput()
            {
                if (loanComboBox.SelectedIndex < 0 || string.IsNullOrWhiteSpace(amountTextBox.Text))
                    return false;
                return true;
            }
            if (ValidInput())
            {
                int client_id = Convert.ToInt32(loanComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"INSERT INTO {DTCollection.Table} ({DTCollection.LoanId}, {DTCollection.Amount}, {DTCollection.DateTime},{DTCollection.Remarks}) " +
                    $"VALUES('{client_id}', '{amountTextBox.Text}', '{DatabaseHelper.DateTimeToString(collectionDateTimePicker.Value)}','{remarksRichTextBox.Text}');");
                InitializeData();
                clearInputsButton_Click(null, null);
            }
        }

        private void clearInputsButton_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = null;
            loanComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            collectionDateTimePicker.Value = DateTime.Now;
            remarksRichTextBox.Text = string.Empty;
        }

        private void creatCollectionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) createLoanButton_Click(null, null);
        }
    }
}
