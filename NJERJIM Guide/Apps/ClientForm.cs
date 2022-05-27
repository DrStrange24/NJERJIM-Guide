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
            SetDGV();
        }

        private void SetDGV()
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
                db_helper.Manipulate($"INSERT INTO {DTClient.TableName} ({DTClient.FirstName}, {DTClient.MiddleName}, {DTClient.LastName}, {DTClient.Sex}, {DTClient.ContactNumber}, {DTClient.Addess}) " +
                    $"VALUES('{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{lastNameTextBox.Text}', {(int)SelectedSex}, '{contactNumberTextBox.Text}', '{addressTextBox.Text}');");
                SetDGV();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"DELETE FROM {DTClient.TableName} WHERE {DTClient.Id}={selectedIdLabel.Text};");
            SetDGV();
        }

        private void clientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && !String.IsNullOrWhiteSpace(clientDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                var selectedRow = clientDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[0].Value.ToString();
                firstNameTextBox.Text = selectedRow[1].Value.ToString();
                middleNameTextBox.Text = selectedRow[2].Value.ToString();
                lastNameTextBox.Text = selectedRow[3].Value.ToString();
                if ((Sex)selectedRow[4].Value == Sex.Male) maleRadioButton.Checked = true; else femaleRadioButton.Checked = true;
                contactNumberTextBox.Text = selectedRow[5].Value.ToString();
                addressTextBox.Text = selectedRow[6].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }
    }
}
