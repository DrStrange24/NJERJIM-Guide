using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJERJIM_Guide
{
    public partial class Transaction : Form
    {
        public Transaction()
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
            var query = $"select * from {DTTransaction.TableName}";
            db_helper.SetDataGridView(transactionDataGridView, query);
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"INSERT INTO {DTTransaction.TableName} ({DTTransaction.Type}, {DTTransaction.Amount}, {DTTransaction.DateTime}) " +
                $"VALUES('{typeTextBox.Text}', '{amountTextBox.Text}', '{dateTimeTextBox.Text}');");
            SetDGV();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"DELETE FROM {DTTransaction.TableName} WHERE {DTTransaction.Id}={selectedIdLabel.Text};");
            SetDGV();
        }

        private void collectionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = transactionDataGridView.Rows[e.RowIndex].Cells;

            selectedIdLabel.Text = selectedRow[0].Value.ToString();
            typeTextBox.Text = selectedRow[1].Value.ToString();
            amountTextBox.Text = selectedRow[2].Value.ToString();
            dateTimeTextBox.Text = selectedRow[3].Value.ToString();

            idLabel.Visible = true;
            selectedIdLabel.Visible = true;
        }
    }
}
