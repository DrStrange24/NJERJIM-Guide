﻿using NJERJIM_Guide.Apps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide
{
    /// <summary>
    ///     DT stands for Database Table.
    ///     Client Table with column names.
    /// </summary>
    static class DTClient
    {
        internal static readonly string Table = "[client]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string FirstName = Table + ".[first_name]";
        internal static readonly string MiddleName = Table + ".[middle_name]";
        internal static readonly string LastName = Table + ".[last_name]";
        internal static readonly string Sex = Table + ".[sex]";
        internal static readonly string ContactNumber = Table + ".[contact_number]";
        internal static readonly string Addess = Table + ".[address]";

        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DId = "ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DFirstName = "First Name";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DMiddleName = "Middle Name";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DLastName = "Last Name";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DSex = "Sex";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DContactNumber = "Contact Number";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DAddess = "Address";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Loan Table with column names.
    /// </summary>
    static class DTLoan
    {
        internal static readonly string Table = "[loan]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string ClientId = Table + ".[client_id]";
        internal static readonly string Item = Table + ".[item]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string Interest = Table + ".[interest]";
        internal static readonly string DailyPayment = Table + ".[daily_payment]";
        internal static readonly string DateTime = Table + ".[datetime]";
        internal static readonly string Remarks = Table + ".[remarks]";

        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DId = "ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DClientId = "Client ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DItem = "Item";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DAmount = "Amount";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DInterest = "Interest";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DDailyPayment = "Daily Payment";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DDateTime = "Date";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DRemarks = "Remarks";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Collection Table with column names.
    /// </summary>
    static class DTCollection
    {
        internal static readonly string Table = "[collection]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string LoanId = Table + ".[loan_id]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
        internal static readonly string Remarks = Table + ".[remarks]";

        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DId = "ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DLoanId = "Loan ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DAmount = "Amount";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DDateTime = "Date";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DRemarks = "Remarks";
    }
    /// <summary>
    ///     DT stands for Database Table.
    ///     Transaction Table with column names.
    /// </summary>
    static class DTTransaction
    {
        internal static readonly string Table = "[supply]";

        internal static readonly string Id = Table + ".[Id]";
        internal static readonly string Type = Table + ".[type]";
        internal static readonly string Amount = Table + ".[amount]";
        internal static readonly string DateTime = Table + ".[datetime]";
        internal static readonly string Remarks = Table + ".[remarks]";

        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DId = "ID";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DType = "Type";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DAmount = "Amount";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DDateTime = "Date";
        /// <summary>
        ///     D represent as "Display". Display column name as string for UI/GUI. example: in table column string.
        /// </summary>
        internal static readonly string DRemarks = "Remarks";
    }
}