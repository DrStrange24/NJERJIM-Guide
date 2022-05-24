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
    public partial class Client : Form
    {
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
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"INSERT INTO {DTClient.TableName} ({DTClient.FirstName}, {DTClient.MiddleName}, {DTClient.LastName}, {DTClient.Sex}, {DTClient.ContactNumber}, {DTClient.Addess}) " +
                $"VALUES('{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{lastNameTextBox.Text}', '{sexTextBox.Text}', '{contactNumberTextBox.Text}', '{addressTextBox.Text}');");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //var db_helper = new DatabaseHelper();
            //db_helper.Manipulate($"DELETE FROM {DTClient.TableName} WHERE {DTClient.Id}={0};");
        }
    }
}
