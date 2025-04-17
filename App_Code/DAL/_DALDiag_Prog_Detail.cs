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
/// Summary description for _DALDiag_Prog_Detail
/// </summary>
public class DALDiag_Prog_Detail
{
    DALBase dalobj = new DALBase();


    public DALDiag_Prog_Detail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Diag_Prog_DetailLockMarks(BLLDiag_Prog_Detail obj)
    {
        SqlParameter[] param = new SqlParameter[2];

       
        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = obj.DP_Id;       

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_DetailLockMarks", param);
        int k = (int)param[1].Value;
        return k;
    }
    public int Diag_Prog_DetailAdd(BLLDiag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        ////////////param[0] = new SqlParameter("@DPD_Id", SqlDbType.Int); 
        ////////////param[0].Value = objbll.DPD_Id;
        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int); 
        param[0].Value = objbll.DP_Id;
        param[1] = new SqlParameter("@Question_Name", SqlDbType.NVarChar); 
        param[1].Value = objbll.Question_Name;
        param[2] = new SqlParameter("@Total_Marks", SqlDbType.Decimal); 
        param[2].Value = objbll.Total_Marks;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@Marks_Percentage", SqlDbType.Decimal);
        param[6].Value = objbll.Marks_Percentage;
        param[7] = new SqlParameter("@Diag_Prog_Question_Type_Id", SqlDbType.Decimal);
        param[7].Value = objbll.Diag_Prog_Question_Type_Id;
        param[8] = new SqlParameter("@Topic_Id", SqlDbType.Decimal);
        param[8].Value = objbll.Topic_Id;

        param[9] = new SqlParameter("@Seq_Id", SqlDbType.Decimal);
        param[9].Value = objbll.Seq_Id;
        ////////////////////param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        ////////////////////param[6].Value = objbll.ModifiedOn;
        ////////////////////param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        ////////////////////param[7].Value = objbll.ModifiedBy;


        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_DetailInsert", param);
        int k = (int)param[10].Value;
        return k;

    }
    public int Diag_Prog_DetailUpdate(BLLDiag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        param[0] = new SqlParameter("@DPD_Id", SqlDbType.Int); 
        param[0].Value = objbll.DPD_Id;
        param[1] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[1].Value = objbll.DP_Id;
        param[2] = new SqlParameter("@Question_Name", SqlDbType.NVarChar);
        param[2].Value = objbll.Question_Name;
        param[3] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[3].Value = objbll.Total_Marks;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[4].Value = objbll.Status_Id;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[6].Value = objbll.ModifiedBy;

        param[7] = new SqlParameter("@Marks_Percentage", SqlDbType.Decimal);
        param[7].Value = objbll.Marks_Percentage;
        param[8] = new SqlParameter("@Diag_Prog_Question_Type_Id", SqlDbType.Decimal);
        param[8].Value = objbll.Diag_Prog_Question_Type_Id;
        param[9] = new SqlParameter("@Topic_Id", SqlDbType.Decimal);
        param[9].Value = objbll.Topic_Id;
 
        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_DetailUpdate", param);
        int k = (int)param[10].Value;
        return k;
    }
    public int Diag_Prog_DetailDelete(BLLDiag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DPD_Id", SqlDbType.Int);
        param[0].Value = objbll.DPD_Id;


        int k = dalobj.sqlcmdExecute("Diag_Prog_DetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Diag_Prog_DetailSelectLockMarks(BLLDiag_Prog_Detail obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = obj.DP_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectLockMarks", param);
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
    public DataTable Diag_Prog_DetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectById", param);
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
    
    public DataTable Diag_Prog_DetailSelect(BLLDiag_Prog_Detail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectAll", param);
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

    public DataTable Diag_Prog_DetailSelectByStatusID(BLLDiag_Prog_Detail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectByStatusID");
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


    public DataTable Diag_Prog_DetailSelectAllByDPId(BLLDiag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = objbll.DP_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectAllByDPId", param);
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



    public DataTable Diag_Prog_DetailSelectAllByDPDId(BLLDiag_Prog_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = objbll.DP_Id;


        param[1] = new SqlParameter("@DPD_Id", SqlDbType.Int);
        param[1].Value = objbll.DPD_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_DetailSelectAllByDPDId", param);
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
