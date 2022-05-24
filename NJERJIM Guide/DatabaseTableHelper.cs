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
        static readonly string TableName = "[client]";

        static readonly string Id = TableName + ".[Id]";
        static readonly string FirstName = TableName + ".[first_name]";
        static readonly string MiddleName = TableName + ".[middle_name]";
        static readonly string LastName = TableName + ".[last_name]";
        static readonly string Sex = TableName + ".[sex]";
        static readonly string ContactNumber = TableName + ".[contact_number]";
        static readonly string Addess = TableName + ".[address]";
    }
    static class DTLoan
    {
        static readonly string TableName = "[loan]";

        static readonly string Id = TableName + ".[Id]";
        static readonly string ClientId = TableName + ".[client_id]";
        static readonly string Amount = TableName + ".[amount]";
        static readonly string DateTime = TableName + ".[datetime]";
    }
    static class DTCollection
    {
        static readonly string TableName = "[collection]";

        static readonly string Id = TableName + ".[Id]";
        static readonly string LoanId = TableName + ".[loan_id]";
        static readonly string Amount = TableName + ".[amount]";
        static readonly string DateTime = TableName + ".[datetime]";
    }
    static class DTTransaction
    {
        static readonly string TableName = "[transaction]";

        static readonly string Id = TableName + ".[Id]";
        static readonly string Type = TableName + ".[type]";
        static readonly string Amount = TableName + ".[amount]";
        static readonly string DateTime = TableName + ".[datetime]";
    }
}
