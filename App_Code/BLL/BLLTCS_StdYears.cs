using System;
using System.Data;


/// <summary>
/// Summary description for BLLStdAttnType
/// </summary>
public class BLLTCS_StdYears
{
    _DALBLLTCS_StdYears objdal = new _DALBLLTCS_StdYears();

    public BLLTCS_StdYears()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int id { get { return Id; } set { Id = value; } }	private int Id;
    public string Year { get { return year; } set { year = value; } }	private string year;

    public DataTable TCS_StdYearsSelectAll()
    {
        return objdal.TCS_StdYearsSelectAll();
    }

    public DataTable Tcs_StdDaysByYearMonth(int year, int month)
    {
        return objdal.TCS_StdDaysByYearMonth(year, month);
        }
}
