using System;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for _DALCrystalReports
/// </summary>
public class _DALCrystalReports
{
    DALBase dalobj = new DALBase();

//   public ReportDocument report= new ReportDocument();

    public _DALCrystalReports()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CR_LogAdd(BLLCrystalReports objbll)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@SectionId", SqlDbType.Int);
        param[0].Value = objbll.SectionId;

        param[1] = new SqlParameter("@critera", SqlDbType.NVarChar);
        param[1].Value = objbll.critera;

        param[2] = new SqlParameter("@StartTime", SqlDbType.DateTime);
        param[2].Value = objbll.StartTime;

        param[3] = new SqlParameter("@EndTime", SqlDbType.DateTime);
        param[3].Value = objbll.EndTime;
        
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CR_LogInsert", param);
        int k = (int)param[4].Value;
        return k;

    } 

    public void DisposeReports()
    {
    //report.Close();
    //report.Dispose();
        }



}
