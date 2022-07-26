using NJERJIM_Guide.Apps;
using System;
using System.Data;
using System.Windows.Forms;

namespace NJERJIM_Guide
{
    public partial class Customer : Form
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
        public Customer()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            var db_helper = new DatabaseHelper();
            var data = db_helper.GetData($"select {DTClient.SId},{DTClient.SFirstName},{DTClient.SMiddleName},{DTClient.SLastName},{DTClient.SSex}," +
                $"{DTClient.SContactNumber},{DTClient.SAddess} from {DTClient.Table} where {DTClient.FirstName} like '%{searchTextBox.Text}%'");
            clientDataGridView.DataSource = data;
            numberOfCustomerValueLabel.Text = data.Rows.Count.ToString();
        }
        private void clientButton_Click(object sender, EventArgs e)
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
                switch (clientButton.Text)
                {
                    case "Add":
                        db_helper.Manipulate($"INSERT INTO {DTClient.Table} ({DTClient.FirstName}, {DTClient.MiddleName}, {DTClient.LastName}, {DTClient.Sex}, {DTClient.ContactNumber}, {DTClient.Addess}) " +
                            $"VALUES('{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{lastNameTextBox.Text}', '{SelectedSex}', '{contactNumberTextBox.Text}', '{addressTextBox.Text}');");
                        break;
                    case "Save":
                        db_helper.Manipulate($"UPDATE {DTClient.Table} SET {DTClient.FirstName} = '{firstNameTextBox.Text}', {DTClient.MiddleName} = '{middleNameTextBox.Text}' , {DTClient.LastName} = '{lastNameTextBox.Text}' " +
                            $",{DTClient.Sex} = '{SelectedSex}', {DTClient.ContactNumber} = '{contactNumberTextBox.Text}',{DTClient.Addess} = '{addressTextBox.Text}' WHERE {DTClient.Id}={selectedIdLabel.Text};");
                        break;
                }
                InitializeData();
                clearButton_Click(null, null);
            }
            else
                MessageBox.Show("Invalid inputs");
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
            if (e.KeyCode == Keys.Enter) clientButton_Click(null, null);
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
            InitializeData();
        }

        private void clientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !String.IsNullOrWhiteSpace(clientDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                var selectedRow = clientDataGridView.Rows[e.RowIndex].Cells;

                selectedIdLabel.Text = selectedRow[DTClient.DId].Value.ToString();
                firstNameTextBox.Text = selectedRow[DTClient.DFirstName].Value.ToString();
                middleNameTextBox.Text = selectedRow[DTClient.DMiddleName].Value.ToString();
                lastNameTextBox.Text = selectedRow[DTClient.DLastName].Value.ToString();
                if (selectedRow[DTClient.DSex].Value.ToString() == Sex.Male.ToString()) maleRadioButton.Checked = true; else femaleRadioButton.Checked = true;
                contactNumberTextBox.Text = selectedRow[DTClient.DContactNumber].Value.ToString();
                addressTextBox.Text = selectedRow[DTClient.DAddess].Value.ToString();

                idLabel.Visible = true;
                selectedIdLabel.Visible = true;
            }
        }

        private void selectedIdLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (selectedIdLabel.Visible)
                clientButton.Text = "Save";
            else
                clientButton.Text = "Add";
        }
    }
}
