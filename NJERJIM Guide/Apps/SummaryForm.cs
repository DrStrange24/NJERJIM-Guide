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
            var records = Summary.Records;

            double cashOnHand = 0;
            double total_supply = 0;
            double profit = 0;

            if (records!=null)
            {
                foreach (var record in records)
                {
                    cashOnHand += record.TotalTransactions;
                    total_supply += record.TotalTransactions;
                    cashOnHand -= record.TotalLoans;
                    cashOnHand += record.TotalCapital;
                    profit += record.TotalProfit;
                    profit -= record.TotalWithdrawnProfit;
                }
            }

            cashOnHandValueLabel.Text = CurrencyFormat.ToString(cashOnHand);
            totalSupplyValueLabel.Text = CurrencyFormat.ToString(total_supply);
            profitValueLabel.Text = CurrencyFormat.ToString(profit);
            cashOnHandWithProfitValueLabel.Text = CurrencyFormat.ToString(profit+cashOnHand);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }
    }
}
