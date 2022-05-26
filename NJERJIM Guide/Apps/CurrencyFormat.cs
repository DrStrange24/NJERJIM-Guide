using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide.Apps
{
    class CurrencyFormat
    {
        internal static string ToString(double money)
        {
            var currency_format = new CultureInfo("fil-PH", false).NumberFormat;
            return money.ToString("C", currency_format);
        }
    }
}
