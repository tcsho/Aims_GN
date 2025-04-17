using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class MySession
{
    // **** add your session properties here, e.g like this:
    public string Property1 { get; set; }
    public DateTime MyDate { get; set; }
    public static int CenterId { get; set; }
    public static int ContactId { get; set; }
    public static DataRow Row { get; set; }
    public static int UserTypeId { get; set; }
    public static string  LoginId { get; set; }

    public static void Sessions(int cId, int contactId, DataRow newRow, int userTypeId, string userId)
    {
        CenterId = cId;
        ContactId = contactId;
        Row = newRow;
        UserTypeId = userTypeId;
        LoginId = userId;
    }
}