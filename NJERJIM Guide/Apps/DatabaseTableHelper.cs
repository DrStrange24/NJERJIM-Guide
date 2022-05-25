using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide
{
    //DT stands for Database Table
    static class DTClient
    {
        internal static readonly string TableName = "[client]";

        internal static readonly string Id = TableName + ".[Id]";
        internal static readonly string FirstName = TableName + ".[first_name]";
        internal static readonly string MiddleName = TableName + ".[middle_name]";
        internal static readonly string LastName = TableName + ".[last_name]";
        internal static readonly string Sex = TableName + ".[sex]";
        internal static readonly string ContactNumber = TableName + ".[contact_number]";
        internal static readonly string Addess = TableName + ".[address]";
    }
    static class DTLoan
    {
        internal static readonly string TableName = "[loan]";

        internal static readonly string Id = TableName + ".[Id]";
        internal static readonly string ClientId = TableName + ".[client_id]";
        internal static readonly string Amount = TableName + ".[amount]";
        internal static readonly string DateTime = TableName + ".[datetime]";
    }
    static class DTCollection
    {
        internal static readonly string TableName = "[collection]";

        internal static readonly string Id = TableName + ".[Id]";
        internal static readonly string LoanId = TableName + ".[loan_id]";
        internal static readonly string Amount = TableName + ".[amount]";
        internal static readonly string DateTime = TableName + ".[datetime]";
    }
    static class DTTransaction
    {
        internal static readonly string TableName = "[transaction]";

        internal static readonly string Id = TableName + ".[Id]";
        internal static readonly string Type = TableName + ".[type]";
        internal static readonly string Amount = TableName + ".[amount]";
        internal static readonly string DateTime = TableName + ".[datetime]";
    }
}
