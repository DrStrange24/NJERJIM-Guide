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

namespace NJERJIM_Guide
{
    public partial class Client : Form
    {
        private Sex SelectedSex 
        {
            get
            {
                if (maleRadioButton.Checked)
                    return Sex.Male;
                return Sex.Female;
            }
        }
        public Client()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            var db_helper = new DatabaseHelper();
            var query = "select * from client";
            db_helper.SetDataGridView(clientDataGridView, query);
        }
        private void addClientButton_Click(object sender, EventArgs e)
        {
            bool ValidInputs()
            {
                if (String.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                    String.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                    String.IsNullOrWhiteSpace(contactNumberTextBox.Text) ||
                    String.IsNullOrWhiteSpace(addressTextBox.Text) ||
                    (!maleRadioButton.Checked && !femaleRadioButton.Checked))
                    return false;
                return true;
            }

            if (ValidInputs())
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"INSERT INTO {DTClient.Table} ({DTClient.FirstName}, {DTClient.MiddleName}, {DTClient.LastName}, {DTClient.Sex}, {DTClient.ContactNumber}, {DTClient.Addess}) " +
                    $"VALUES('{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{lastNameTextBox.Text}', '{SelectedSex}', '{contactNumberTextBox.Text}', '{addressTextBox.Text}');");
                InitializeData();
                clearButton_Click(null,null);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedIdLabel.Text))
            {
                var db_helper = new DatabaseHelper();
                db_helper.Manipulate($"DELETE FROM {DTClient.Table} WHERE {DTClient.Id}={selectedIdLabel.Text};");
                InitializeData();
                clearButton_Click(null, null);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }

        private void addClientTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) addClientButton_Click(null, null);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            selectedIdLabel.Visible = false;
            selectedIdLabel.Text = string.Empty;
            firstNameTextBox.Text = string.Empty;
            middleNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            maleRadioButton.Checked = false;
            femaleRadioButton.Checked = false;
            contactNumberTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.SetDataGridView(clientDataGridView, $"select * from {DTClient.Table} where {DTClient.FirstName} like '%{searchTextBox.Text}%'");
        }

        private void clientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !String.IsNullOrWhiteSpace(clientDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                var selectedRow = clientDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[0].Value.ToString();
                firstNameTextBox.Text = selectedRow[1].Value.ToString();
                middleNameTextBox.Text = selectedRow[2].Value.ToString();
                lastNameTextBox.Text = selectedRow[3].Value.ToString();
                if (selectedRow[4].Value.ToString() == Sex.Male.ToString()) maleRadioButton.Checked = true; else femaleRadioButton.Checked = true;
                contactNumberTextBox.Text = selectedRow[5].Value.ToString();
                addressTextBox.Text = selectedRow[6].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }
    }
}
