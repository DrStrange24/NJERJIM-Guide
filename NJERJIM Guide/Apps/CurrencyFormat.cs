using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide.Apps
{
    class CurrencyFormat
    {
        internal static string ToString(object money)
        {
            var currency_format = new CultureInfo("fil-PH", false).NumberFormat;
            return Convert.ToDouble(money).ToString("C", currency_format);
        }
        internal static string ToString(double money)
        {
            var currency_format = new CultureInfo("fil-PH", false).NumberFormat;
            return money.ToString("C", currency_format);
        }
        internal static double ToDouble(string money)
        {
            return Convert.ToDouble(money.Replace("₱", ""));
        }
        internal static double ToDouble(object money)
        {
            return Convert.ToDouble(Convert.ToString(money).Replace("₱", ""));
        }
    }
}
