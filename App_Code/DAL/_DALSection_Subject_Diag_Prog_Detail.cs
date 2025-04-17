using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALSection_Subject_Diag_Prog_Detail
/// </summary>
public class DALSection_Subject_Diag_Prog_Detail
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Diag_Prog_Detail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_Diag_Prog_DetailAdd(BLLSection_Subject_Diag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[15];
        param[0] = new SqlParameter("@SSDPD_Id", SqlDbType.Int); param[0].Value = objbll.SSDPD_Id;
        param[0] = new SqlParameter("@DPD_Id", SqlDbType.Int); param[0].Value = objbll.DPD_Id;
        param[1] = new SqlParameter("@SSDP_Id", SqlDbType.Int); param[1].Value = objbll.SSDP_Id;
        param[2] = new SqlParameter("@Question_Name", SqlDbType.NVarChar); param[2].Value = objbll.Question_Name;
        param[3] = new SqlParameter("@Total_Marks", SqlDbType.Decimal); param[3].Value = objbll.Total_Marks;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); param[4].Value = objbll.Status_Id;


        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Diag_Prog_DetailInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Section_Subject_Diag_Prog_DetailUpdate(BLLSection_Subject_Diag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@SSDPD_Id", SqlDbType.Int); param[0].Value = objbll.SSDPD_Id;
        param[0] = new SqlParameter("@DPD_Id", SqlDbType.Int); param[0].Value = objbll.DPD_Id;
        param[1] = new SqlParameter("@SSDP_Id", SqlDbType.Int); param[1].Value = objbll.SSDP_Id;
        param[2] = new SqlParameter("@Question_Name", SqlDbType.NVarChar); param[2].Value = objbll.Question_Name;
        param[3] = new SqlParameter("@Total_Marks", SqlDbType.Decimal); param[3].Value = objbll.Total_Marks;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); param[4].Value = objbll.Status_Id;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Diag_Prog_DetailUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_Diag_Prog_DetailDelete(BLLSection_Subject_Diag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Diag_Prog_Detail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Diag_Prog_Detail_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_Diag_Prog_DetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_Diag_Prog_DetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_Prog_DetailSelectById", param);
        return _dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return _dt;
    }
    
    public DataTable Section_Subject_Diag_Prog_DetailSelect(BLLSection_Subject_Diag_Prog_Detail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_Prog_DetailSelectAll", param);
        return _dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return _dt;
    
    }

    public DataTable Section_Subject_Diag_Prog_DetailSelectByStatusID(BLLSection_Subject_Diag_Prog_Detail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_Prog_DetailSelectByStatusID");
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }




    #endregion


}
