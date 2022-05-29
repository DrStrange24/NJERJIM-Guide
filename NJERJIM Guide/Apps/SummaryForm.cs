using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJERJIM_Guide
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            var Summary = new SummaryHelper();
            cashOnHandValueLabel.Text = Summary.CashOnHand;
            totalSupplyValueLabel.Text = Summary.TotalSupply;
            profitValueLabel.Text = Summary.Profit;
            cashOnHandWithProfitValueLabel.Text = Summary.CashOnHandWithProfit;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }
    }
}
