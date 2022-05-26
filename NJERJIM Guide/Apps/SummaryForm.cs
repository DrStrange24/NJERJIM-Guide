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

            double available_money = 0;
            double total_money = 0;
            double profit = 0;

            if (records!=null)
            {
                foreach (var record in records)
                {
                    available_money += record.TotalTransactions();
                    total_money += record.TotalTransactions();
                    available_money -= record.TotalLoans();
                    available_money += record.TotalCapital();
                    profit += record.TotalProfit();
                }
            }

            availableMoneyValueLabel.Text = CurrencyFormat.ToString(available_money);
            moneyValueLabel.Text = CurrencyFormat.ToString(total_money);
            profitValueLabel.Text = CurrencyFormat.ToString(profit);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Program.MainMenuForm.Show();
            this.Close();
        }
    }
}
