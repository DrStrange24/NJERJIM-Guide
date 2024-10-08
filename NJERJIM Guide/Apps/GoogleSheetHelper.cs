﻿using Google.Apis.Auth.OAuth2;
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

                Dictionary<string, int> getRowHeader()
                {
                    var rowHeader = new Dictionary<string, int>();
                    var columnHeader = values[0];
                    //loop all the column header and save the index of a specified column
                    for (int i = 0; i < columnHeader.Count; i++)
                        rowHeader.Add(columnHeader[i].ToString(), i);
                    return rowHeader;
                }
                var rowHeader = getRowHeader();

                for (int i = 1; i < values.Count; i++)
                {
                    var row = values[i];
                    DSCollection collection = new DSCollection();

                    collection.LoanId = Convert.ToInt32(row[rowHeader["Loan ID"]]);
                    collection.Amount = Convert.ToDouble(row[rowHeader["Amount"]]);
                    collection.Remarks = row.Count == rowHeader.Count? Convert.ToString(row[rowHeader["Remarks"]]) : "";

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
                        MessageBox.Show($"ID: {collection.LoanId} has an invalid inputs.");

                    Collection.NotifyCompleteOrOverpaidLoan(collection.LoanId);
                }
            }
            else
                MessageBox.Show("No data found.");
        }
    }
}
