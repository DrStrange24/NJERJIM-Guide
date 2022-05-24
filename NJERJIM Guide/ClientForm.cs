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
            db_helper.SetDataGridView(dataGridView1, query);
        }
    }
}
