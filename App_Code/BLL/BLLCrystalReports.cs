using System;


/// <summary>
/// Summary description for BLLLmsDpbPrtcpntFolder
/// </summary>







public class BLLCrystalReports
    {

    _DALCrystalReports DALObj = new _DALCrystalReports();
   //public ReportDocument rpt = new ReportDocument();
    public static bool isNav = false;

    public int StudentId { get; set; }
    public int TermId { get; set; }
    public int SectionId { get; set; }
    public string ReportPath { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TermGroup_Id { get; set; }
    public string critera { get; set; }


    _DALCrystalReports objdal = new _DALCrystalReports();

    public BLLCrystalReports()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    public int CR_LogAdd(BLLCrystalReports _obj)
    {
        return objdal.CR_LogAdd(_obj);
    }
    public void DisposeReports()
        {
        DALObj.DisposeReports();
        }




    }
