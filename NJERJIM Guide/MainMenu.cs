﻿using System;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            new Client().Show();
            this.Close();
        }

        private void loanButton_Click(object sender, EventArgs e)
        {
            new Loan().Show();
            this.Close();
        }

        private void collectionButton_Click(object sender, EventArgs e)
        {
            new CollectionForm().Show();
            this.Close();
        }
    }
}
