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
    public partial class Collection : Form
    {
        private DatabaseHelper db_query = new DatabaseHelper();
        public Collection()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            void SetDataGridView()
            {

                void SetSearchLoanIdComboBox()
                {
                    var data = db_query.GetData($"select {DTLoan.Id} from {DTLoan.Table}");
                    for (int i = 0; i < data.Rows.Count; i++)
                        loanIdComboBox.Items.Add(data.Rows[i][0]);
                    loanIdComboBox.SelectedIndex = 0;
                }
                searchByComboBox.SelectedIndex = 1;
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
                fromDateTimePicker.Value = DateTime.Now.Date;
                toDateTimePicker.Value = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
                SetSearchLoanIdComboBox();
                moneyFormatComboBox.SelectedIndex = 0;
            }
            
            SetDataGridView();
            SetComboBoxItems();
            FilterDataGridView();

            this.moneyFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.moneyFormatComboBox_SelectedIndexChanged);
            this.toDateTimePicker.ValueChanged += new System.EventHandler(this.fromtoDateTimePicker_ValueChanged);
        }
        private void SetComboBoxItems()
        {
            var data = db_query.GetData($"select {DTLoan.SId},{DTLoan.SAmount},{DTLoan.SInterest},{DTClient.SFirstName} from {DTLoan.Table} join {DTClient.Table} on {DTLoan.CustomerId}={DTClient.Id};");
            loanComboBox.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var loan = new DSLoan();
                loan.Id = Convert.ToInt32(data.Rows[i][DTLoan.DId]);
                loan.Amount = Convert.ToDouble(data.Rows[i][DTLoan.DAmount]);
                loan.Interest = Convert.ToDouble(data.Rows[i][DTLoan.DInterest]);
                if (!loan.IsFullyPaid)
                    loanComboBox.Items.Add(loan.Id + " - " + data.Rows[i][DTClient.DFirstName]);
            }
        }
        private void FilterDataGridView()
        {
            string SearchFilter()
            {
                string condition = string.Empty;
                switch(searchByComboBox.SelectedItem.ToString())
                {
                    case "Loan ID":
                        condition = $"{DTLoan.Id}={loanIdComboBox.SelectedItem}";
                        return condition;
                    case "Customer Name":
                        condition = $"{DTClient.FirstName} like '%{searchTextBox.Text}%'";
                        return condition;
                }
                return condition;
            }
            string DateFilter()
            {
                string dateRange = string.Empty;
                if (dateTimeCheckBox.Checked)
                {
                    dateRange += " and ";
                    dateRange += $"{DTCollection.DateTime} between '{DateTimeFormatHelper.DateTimeToStringDB(fromDateTimePicker.Value)}' and '{DateTimeFormatHelper.DateTimeToStringDB(toDateTimePicker.Value)}'";
                    return dateRange;
                }
                return dateRange;
            }
            object MoneyFormat(object money)
            {
                switch (moneyFormatComboBox.SelectedItem.ToString())
                {
                    case "Finance":
                        return Convert.ToDouble(money);
                    case "Pesos":
                        return CurrencyFormat.ToString(money);
                }
                return 0;
            }
            Type MoneyDataTypes()
            {
                switch (moneyFormatComboBox.SelectedItem.ToString())
                {
                    case "Finance":
                        return typeof(double);
                    case "Pesos":
                        return typeof(string);
                }
                return null;
            }
            Func<int> getRandomNumber = () => new Random().Next(1, 100);
            getRandomNumber();
            var data = db_query.GetData($"select {DTCollection.SId},{DTCollection.SLoanId},{DTClient.SFirstName},{DTCollection.SAmount},{DTCollection.SDateTime},{DTCollection.SRemarks} from {DTCollection.Table} " +
                $"join {DTLoan.Table} on {DTCollection.LoanId}={DTLoan.Id} join {DTClient.Table} on {DTLoan.CustomerId}={DTClient.Id} where {SearchFilter()} {DateFilter()} order by {DTCollection.DateTime} desc;");
            DataTableHelper.ChangeColumnDatatypes(data, DTLoan.DAmount, MoneyDataTypes());
            double totalIncome = 0;
            double totalCollection = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i][DTCollection.DAmount] = MoneyFormat(data.Rows[i][DTCollection.DAmount]);
                data.Rows[i][DTCollection.DDateTime] = DateTimeFormatHelper.DateTimeToStringUI(data.Rows[i][DTCollection.DDateTime]);

                //to set total income
                var repayment = new DSCollection();
                repayment.LoanId = Convert.ToInt32(data.Rows[i][DTCollection.DLoanId]);
                double currentLoanAmount = CurrencyFormat.ToDouble(data.Rows[i][DTCollection.DAmount]);
                double currentLoanIncome = currentLoanAmount - currentLoanAmount / (1 + (repayment.Loan.InterestInPercent / 100));
                totalIncome += currentLoanIncome;
                totalCollection += currentLoanAmount;
            }
            collectionDataGridView.DataSource = data;
            totalIncomeValueLabel.Text = CurrencyFormat.ToString(totalIncome);
            totalCollectionValueLabel.Text = CurrencyFormat.ToString(totalCollection);
            totalPrincipalValueLabel.Text = CurrencyFormat.ToString(CurrencyFormat.ToDouble(totalCollectionValueLabel.Text)-totalIncome);
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
                FilterDataGridView();
                SetComboBoxItems();
                clearInputsButton_Click(null, null);
            }
            else
                MessageBox.Show("Please select a loan first!");
            
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            bool ValidInputs()
            {
                if(loanComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a loan account");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(amountTextBox.Text))
                {
                    MessageBox.Show("Please insert an amount");
                    return false;
                }

                return true;
            }

            if (ValidInputs())
            {
                int loan_id = Convert.ToInt32(loanComboBox.SelectedItem.ToString().Split(" - ")[0]);
                var db_helper = new DatabaseHelper();
                switch (collectButton.Text)
                {
                    case "Collect":
                        db_helper.Manipulate($"INSERT INTO {DTCollection.Table} ({DTCollection.LoanId}, {DTCollection.Amount}, {DTCollection.DateTime},{DTCollection.Remarks}) " +
                            $"VALUES('{loan_id}', '{amountTextBox.Text}', '{DateTimeFormatHelper.DateTimeToStringDB(collectionDateTimePicker.Value)}','{remarksRichTextBox.Text}');");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTCollection.Table} SET {DTCollection.LoanId} = {loan_id}, {DTCollection.Amount} = {CurrencyFormat.ToDouble(amountTextBox.Text)} , {DTCollection.DateTime} = '{DateTimeFormatHelper.DateTimeToStringDB(collectionDateTimePicker.Value)}' " +
                            $",{DTCollection.Remarks} = '{remarksRichTextBox.Text}' WHERE {DTCollection.Id}={selectedIdLabel.Text};");
                        break;
                }
                FilterDataGridView();
                var loan = loanComboBox.SelectedItem;// so that selected loan will not reset after collect button is clicked
                SetComboBoxItems();
                clearInputsButton_Click(null, null);
                loanComboBox.SelectedItem = loan;// so that selected loan will not reset after collect button is clicked

                NotifyCompleteOrOverPaymentLoan(loan_id);
            }
       
        }

        public static void NotifyCompleteOrOverPaymentLoan(int loanId)
        {
            DSCollection collection = new DSCollection();
            collection.LoanId = loanId;
            var loan = collection.Loan;
            if (loan.IsFullyPaid) MessageBox.Show($"Loan ID: {loan.Id} has completed the loan.");
            if (loan.CompletedBill > loan.TotalDebt) MessageBox.Show($"Loan ID: {loan.Id} has an overpayment.");
        }
        private void clearInputsButton_Click(object sender, EventArgs e)
        {
            SetComboBoxItems();
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = null;
            loanComboBox.SelectedIndex = -1;
            amountTextBox.Text = string.Empty;
            remarksRichTextBox.Text = string.Empty;
            collectionDateTimePicker.Value = collectionDateTimePicker.Value.Date + new TimeSpan(0,DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second,DateTime.Now.Millisecond);
        }

        private void creatCollectionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) collectButton_Click(null, null);
        }
        private void searchByTextBox_TextChanged(object sender, EventArgs e)
        {
            if(searchTextBox.Visible) FilterDataGridView();
        }

        private void dateTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dateTimeCheckBox.Checked)
            {
                fromDateTimePicker.Value = DateTime.Now.Date;
                toDateTimePicker.Value = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
            }
            else
            {
                fromDateTimePicker.Enabled = true;
                toDateTimePicker.Enabled = true;
            }
            FilterDataGridView();
        }

        private void fromtoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            toDateTimePicker.Value = fromDateTimePicker.Value.Date.AddDays(1).AddMilliseconds(-1);
        }

        private void loanIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loanIdComboBox.Visible) FilterDataGridView();
        }

        private void searchByComboBox_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                switch (searchByComboBox.SelectedItem.ToString())
                {
                    case "Loan ID":
                        searchTextBox.Visible = false;
                        searchTextBox.Text = string.Empty;
                        loanIdComboBox.Visible = true;
                        loanIdComboBox.SelectedIndex = 0;
                        break;
                    case "Customer Name":
                        searchTextBox.Visible = true;
                        searchTextBox.Text = string.Empty;
                        loanIdComboBox.Visible = false;
                        loanIdComboBox.SelectedIndex = 0;
                        break;
                }
                FilterDataGridView();
            }
            catch { }
        }

        private void collectionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = collectionDataGridView.Rows[e.RowIndex].Cells;

                //column name are base on InitializeData() SetDataGridView() method
                selectedIdLabel.Text = selectedRow["ID"].Value.ToString();
                void SetComboBoxItems()
                {
                    var selected_client = selectedRow["Loan ID"].Value + " - " + selectedRow["First Name"].Value;
                    loanComboBox.Items.Add(selected_client);
                    loanComboBox.SelectedItem = selected_client;
                }
                this.SetComboBoxItems();
                SetComboBoxItems();
                amountTextBox.Text = selectedRow["Amount"].Value.ToString();
                collectionDateTimePicker.Value = DateTimeFormatHelper.StringUIToDateTime(selectedRow["Date"].Value);
                remarksRichTextBox.Text = selectedRow["Remarks"].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void selectedIdLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (selectedIdLabel.Visible)
                collectButton.Text = "Save";
            else
                collectButton.Text = "Collect";
        }

        private void moneyFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            GoogleSheetHelper gsheetHelper = new GoogleSheetHelper();
            gsheetHelper.ImportData(collectionDateTimePicker.Value, "A3:D1000");
            FilterDataGridView();
        }
    }
}
