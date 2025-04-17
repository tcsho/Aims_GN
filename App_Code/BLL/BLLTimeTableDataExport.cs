using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLTimeTableDataExport
/// </summary>
public class BLLTimeTableDataExport
{

    DALTimeTableDataExport objdal = new DALTimeTableDataExport();
    public BLLTimeTableDataExport()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int SessionId { get; set; }
    public int CenterId { get; set; }
    public int FromClassId { get; set; }
    public int ToClassId { get; set; }



    public DataTable TimeTableDataExport(BLLTimeTableDataExport obj)
    {
        return objdal.TimeTableDataExport(obj);
    }
}