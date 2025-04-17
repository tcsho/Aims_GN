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
/// Summary description for _DALMarksLockingCriteria
/// </summary>
public class _DALMarksLockingCriteria
{
    DALBase dalobj = new DALBase();


    public _DALMarksLockingCriteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    //public int MarksLockingCriteriaAdd(BLLMarksLockingCriteria objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[2];

    //    param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //    param[14].Direction = ParameterDirection.Output;

    //    dalobj.sqlcmdExecute("MarksLockingCriteriaInsert", param);
    //    int k = (int)param[14].Value;
    //    return k;

    //}
    public int MarksLockingCriteriaAdd(BLLMarksLockingCriteria objbll)
    {
        SqlParameter[] param = new SqlParameter[13];

        param[0] = new SqlParameter("@ML_Criteria", SqlDbType.NVarChar, 200);
        param[0].Value = objbll.ML_Criteria;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;

        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[3].Value = objbll.TermGroup_Id;

        param[4] = new SqlParameter("@MLC_Type_Id", SqlDbType.Int);
        param[4].Value = objbll.MLC_Type_Id;

        param[5] = new SqlParameter("@LockingDate", SqlDbType.DateTime);
        param[5].Value = objbll.LockingDate;

        param[6] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[6].Value = objbll.Evaluation_Type_Id;

        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[7].Value = objbll.Status_Id;

        param[8] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[8].Value = objbll.Class_Id;

        param[9] = new SqlParameter("@Current_Status", SqlDbType.NVarChar, 255);
        param[9].Value = objbll.Current_Status;

        param[10] = new SqlParameter("@IsProcessed", SqlDbType.Bit);
        param[10].Value = objbll.IsProcessed;
        param[11] = new SqlParameter("@islock", SqlDbType.Bit);
        param[11].Value = objbll.isLock;
        param[12] = new SqlParameter("@MLCri_Id", SqlDbType.Int);
        param[12].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("MarksLockingCriteriaInsert", param);

        int k = Convert.ToInt32(param[12].Value);
        return k;
    }
    public int MarksLockingCriteriaUpdate(BLLMarksLockingCriteria objbll)
    {
        SqlParameter[] param = new SqlParameter[14];

        param[0] = new SqlParameter("@MLCri_Id", SqlDbType.Int);
        param[0].Value = objbll.MLCri_Id;

        param[1] = new SqlParameter("@ML_Criteria", SqlDbType.NVarChar, 200);
        param[1].Value = objbll.ML_Criteria ?? (object)DBNull.Value;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        param[3] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[3].Value = objbll.Evaluation_Criteria_Type_Id;

        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[4].Value = objbll.TermGroup_Id;

        param[5] = new SqlParameter("@MLC_Type_Id", SqlDbType.Int);
        param[5].Value = objbll.MLC_Type_Id;

        param[6] = new SqlParameter("@LockingDate", SqlDbType.DateTime);
        param[6].Value = objbll.LockingDate;

        param[7] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[7].Value = objbll.Evaluation_Type_Id ;

        param[8] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[8].Value = objbll.Status_Id ;

        param[9] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[9].Value = objbll.Class_Id ;

        param[10] = new SqlParameter("@IsProcessed", SqlDbType.Bit);
        param[10].Value = objbll.IsProcessed;

        param[11] = new SqlParameter("@islock", SqlDbType.Bit);
        param[11].Value = objbll.isLock;

        param[12] = new SqlParameter("@Current_Status", SqlDbType.NVarChar, 255);
        param[12].Value = objbll.Current_Status;

        param[13] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
      param[13].Direction = ParameterDirection.Output;

          dalobj.sqlcmdExecute("MarksLockingCriteriaUpdate", param);
        int k = (int)param[13].Value;
        return k;
     
    }

    //public int MarksLockingCriteriaUpdate(BLLMarksLockingCriteria objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[3];

    //    param[0] = new SqlParameter("@MLCri_Id", SqlDbType.Int);
    //    param[0].Value = objbll.MLCri_Id;
    //    param[1] = new SqlParameter("@LockingDate", SqlDbType.DateTime);
    //    param[1].Value = objbll.LockingDate;
    //    //param[2] = new SqlParameter("@isLock", SqlDbType.Bit);
    //    //param[2].Value = objbll.isLock;
    //    param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //    param[2].Direction = ParameterDirection.Output;

    //    dalobj.sqlcmdExecute("MarksLockingCriteriaUpdate", param);
    //    int k = (int)param[2].Value;
    //    return k;
    //}
    public int MarksLockingCriteriaDelete(BLLMarksLockingCriteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MarksLockingCriteria_Id", SqlDbType.Int);
        //   param[0].Value = objbll.MarksLockingCriteria_Id;


        int k = dalobj.sqlcmdExecute("MarksLockingCriteriaDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable MarksLockingCriteriaSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("MarksLockingCriteriaSelect", param);
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

    public DataTable MarksLockingCriteriaTypesSelect(BLLMarksLockingCriteria objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("MarksLockingCriteria_TypesSelectAll");
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

    public DataTable MarksLockingCriteriaSelect(BLLMarksLockingCriteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;
        param[2] = new SqlParameter("@MLC_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.MCL_Type_Id;
        param[3] = new SqlParameter("@Term_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Term_Name;


        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("MarksLockingCriteria_Select", param);
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


    public int MarksLockingCriteriaSelectField(int _Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[1].Value;
        return k;

    }


    #endregion


}
