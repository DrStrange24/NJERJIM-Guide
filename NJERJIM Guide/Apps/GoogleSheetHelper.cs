using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJERJIM_Guide.Apps
{
    internal class GoogleSheetHelper
    {
        readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        readonly string ApplicationName = "Anything";
        readonly string SpreadSheetId = "1pxdTIt4Sjd8lfX1B_X1fBEYRQI7osq6Ii4-6Y_1XgiM";
        SheetsService service;

        public GoogleSheetHelper()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("g_sheet_api.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public void ImportData(DateTime SheetName,string SheetRange)
        {
            var range = $"{DateTimeFormatHelper.ToGoogleSheet(SheetName)}!{SheetRange}";
            var request = service.Spreadsheets.Values.Get(SpreadSheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                var db_helper = new DatabaseHelper();
                foreach (var row in values)
                {
                    DSCollection collection = new DSCollection();

                    collection.LoanId = Convert.ToInt32(row[0]);
                    collection.Amount = Convert.ToDouble(row[2]);

                    if (row.Count > 3) collection.Remarks = Convert.ToString(row[3]);
                    else collection.Remarks = "";

                    bool ValidInputs()
                    {
                        if (collection.Amount < 0)
                            return false;
                        return true;
                    }

                    if (ValidInputs())
                    {
                        db_helper.Manipulate($"INSERT INTO {DTCollection.Table} ({DTCollection.LoanId}, {DTCollection.Amount}, {DTCollection.DateTime},{DTCollection.Remarks}) " +
                            $"VALUES({collection.LoanId}, {collection.Amount}, '{DateTimeFormatHelper.DateTimeToStringDB(SheetName)}','{collection.Remarks}');");
                    }
                    else
                        MessageBox.Show($"ID: {collection.LoanId} has invalid inputs.");

                    Collection.NotifyCompleteOrOverPaymentLoan(collection.LoanId);
                }
            }
            else
            {
                MessageBox.Show("No data found.");
            }
        }
    }
}
