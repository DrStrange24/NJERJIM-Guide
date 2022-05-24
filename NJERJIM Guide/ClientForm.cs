﻿using System;
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
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"INSERT INTO {DTClient.TableName} ({DTClient.FirstName}, {DTClient.MiddleName}, {DTClient.LastName}, {DTClient.Sex}, {DTClient.ContactNumber}, {DTClient.Addess}) " +
                $"VALUES('{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{lastNameTextBox.Text}', '{sexTextBox.Text}', '{contactNumberTextBox.Text}', '{addressTextBox.Text}');");
            SetDGV();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var db_helper = new DatabaseHelper();
            db_helper.Manipulate($"DELETE FROM {DTClient.TableName} WHERE {DTClient.Id}={selectedIdLabel.Text};");
            SetDGV();
        }

        private void clientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = clientDataGridView.Rows[e.RowIndex].Cells;

            selectedIdLabel.Text = selectedRow[0].Value.ToString();
            firstNameTextBox.Text = selectedRow[1].Value.ToString();
            middleNameTextBox.Text = selectedRow[2].Value.ToString();
            lastNameTextBox.Text = selectedRow[3].Value.ToString();
            sexTextBox.Text = selectedRow[4].Value.ToString();
            contactNumberTextBox.Text = selectedRow[5].Value.ToString();
            addressTextBox.Text = selectedRow[6].Value.ToString();

            idLabel.Visible = true;
            selectedIdLabel.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Close();
        }
    }
}
