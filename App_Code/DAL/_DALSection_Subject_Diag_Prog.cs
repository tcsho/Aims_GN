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
/// Summary description for _DALSection_Subject_Diag_Prog
/// </summary>
public class DALSection_Subject_Diag_Prog
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Diag_Prog()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_Diag_ProgAdd(BLLSection_Subject_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@SSDP_Id", SqlDbType.Int); param[0].Value = objbll.SSDP_Id;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@DP_Id", SqlDbType.Int); param[1].Value = objbll.DP_Id;
        param[2] = new SqlParameter("@Section_Name", SqlDbType.NVarChar); param[2].Value = objbll.Section_Name;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[4].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[6].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); param[7].Value = objbll.Status_Id;




        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Diag_ProgInsert", param);
        int k = (int)param[14].Value;
        return k;

    }

    public int Diag_Prog_Manage_Center_AccessAdd(BLLSection_Subject_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Region_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Region_Name;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Center_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Center_Name;
        param[4] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[4].Value = objbll.isAllow;
        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = objbll.Subject_Id;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_Manage_Center_AccessInsert", param);
        int k = (int)param[6].Value;
        return k;

    }

    public int Section_Subject_Diag_ProgUpdate(BLLSection_Subject_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@SSDP_Id", SqlDbType.Int); param[0].Value = objbll.SSDP_Id;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@DP_Id", SqlDbType.Int); param[1].Value = objbll.DP_Id;
        param[2] = new SqlParameter("@Section_Name", SqlDbType.NVarChar); param[2].Value = objbll.Section_Name;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[4].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[6].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); param[7].Value = objbll.Status_Id;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Diag_ProgUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_Diag_ProgDelete(BLLSection_Subject_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Diag_Prog_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Diag_Prog_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_Diag_ProgDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_Diag_ProgSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_ProgSelectById", param);
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
    
    public DataTable Section_Subject_Diag_ProgSelect(BLLSection_Subject_Diag_Prog objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_ProgSelectAll", param);
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

    public DataTable Diag_Prog_Manage_Center_AccessSelectAll(BLLSection_Subject_Diag_Prog objbll)
    {
        


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_Manage_Center_AccessSelectAll");
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

    public int Section_Subject_Diag_Prog_GenerateMasterDetailValues(BLLSection_Subject_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Diag_Prog_GenerateMasterDetailValues", param);
        int k = (int)param[2].Value;
        return k;


      

    }


    public DataTable Section_Subject_Diag_ProgSelectByStatusID(BLLSection_Subject_Diag_Prog objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_ProgSelectByStatusID");
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
