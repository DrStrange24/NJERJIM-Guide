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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            new Client().Show();
            this.Hide();
        }

        private void loanButton_Click(object sender, EventArgs e)
        {
            new Loan().Show();
            this.Hide();
        }

        private void collectionButton_Click(object sender, EventArgs e)
        {
            new CollectionForm().Show();
            this.Hide();
        }

        private void transactionButton_Click(object sender, EventArgs e)
        {
            new Transaction().Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void summaryButton_Click(object sender, EventArgs e)
        {
            new SummaryForm().Show();
            this.Hide();
        }
    }
}
