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
            SetDGV();
        }

        private void SetDGV()
        {
            var db_helper = new DatabaseHelper();
            var query = $"select * from {DTCollection.TableName} order by {DTCollection.DateTime} desc;";
            db_helper.SetDataGridView(collectionDataGridView, query);

            var data = db_helper.GetData($"select * from {DTCollection.TableName}");
            totalCollectionValueLabel.Text = CurrencyFormat.ToString(CollectionData.TotalAmount(CollectionData.GetList(data)));
        } 
        private void addButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"INSERT INTO {DTCollection.TableName} ({DTCollection.LoanId}, {DTCollection.Amount}, {DTCollection.DateTime}) " +
                $"VALUES('{loanIdTextBox.Text}', '{amountTextBox.Text}', '{dateTimeTextBox.Text}');");
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
            db_helper.Manipulate($"DELETE FROM {DTCollection.TableName} WHERE {DTCollection.Id}={selectedIdLabel.Text};");
            SetDGV();
        }

        private void collectionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                var selectedRow = collectionDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[0].Value.ToString();
                loanIdTextBox.Text = selectedRow[1].Value.ToString();
                amountTextBox.Text = selectedRow[2].Value.ToString();
                dateTimeTextBox.Text = selectedRow[3].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void addCollectionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) addButton_Click(null, null);
        }
    }
}
