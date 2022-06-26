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

namespace NJERJIM_Guide.Apps.ISP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            var mikrotik = new MK("23.23.23.1");
            if (!mikrotik.Login("drstrange", "Jeremyboypogi24!"))
            {
                Trace.WriteLine("Could not log in");
                mikrotik.Close();
                return;
            }
            mikrotik.Send("/system/identity/getall");
            mikrotik.Send(".tag=sss", true);
            foreach (string h in mikrotik.Read())
            {
                Trace.WriteLine(h);
            }
        }
    }
}
