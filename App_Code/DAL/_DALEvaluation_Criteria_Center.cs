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
/// Summary description for _DALEvaluation_Criteria_Center
/// </summary>
public class DALEvaluation_Criteria_Center
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Criteria_Center()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_CenterAdd(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@ECC_Id", SqlDbType.Int);
        param[0].Value = objbll.ECC_Id;
        param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Id;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Criteria", SqlDbType.NVarChar);
        param[4].Value = objbll.Criteria;
        param[5] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[5].Value = objbll.Total_Marks;
        param[6] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[6].Value = objbll.Weightage;
        param[7] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[7].Value = objbll.Evaluation_Criteria_Type_Id;
        param[8] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[8].Value = objbll.Evaluation_Type_Id;
        param[9] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[9].Value = objbll.Status_Id;
        param[10] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[10].Value = objbll.Center_Id;
        param[11] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[11].Value = objbll.Session_Id;


        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_CenterInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Evaluation_Criteria_CenterUpdate(BLLEvaluation_Criteria_Center objbll)
     {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@ECC_Id", SqlDbType.Int);
        param[0].Value = objbll.ECC_Id;

        param[1] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[1].Value = objbll.Total_Marks;
        param[2] = new SqlParameter("@Weightage", SqlDbType.Float);
        param[2].Value = objbll.Weightage;

        param[3] = new SqlParameter("@Center_Id", SqlDbType.Float);
        param[3].Value = objbll.Center_Id;
        param[4] = new SqlParameter("@TermGroup_id", SqlDbType.Int);
        param[4].Value = objbll.Evaluation_Criteria_Type_Id;
        param[5] = new SqlParameter("@Class_id", SqlDbType.Int);
        param[5].Value = objbll.Class_Id;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_CenterUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }
    public int Evaluation_Criteria_CenterDelete(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ECC_Id", SqlDbType.Int);
        param[0].Value = objbll.ECC_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_CenterDelete", param);

        return k;
    }
    public int Evaluation_Criteria_CenterRevert(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ECC_Id", SqlDbType.Int);
        param[0].Value = objbll.ECC_Id;


        int k = dalobj.sqlcmdExecute("RestoreDataFromBackup", param);

        return k;
    }
    public int Evaluation_Criteria_CenterLockUnlock(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); 
         param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Lock", SqlDbType.Bit);
        param[1].Value = objbll.Lock;

        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_CenterLockUnLock", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_CenterSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectById", param);
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


    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterId(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;


        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;


        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectByClassSubjectCenterId", param);
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

    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterId_Delete (BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;


        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;


        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectByClassSubjectCenterId_Deleted", param);
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
    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterIdECC_Id(BLLEvaluation_Criteria_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;


        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;


        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;


        param[4] = new SqlParameter("@ECC_Id", SqlDbType.Int);
        param[4].Value = objbll.ECC_Id;






        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectByClassSubjectCenterIdECC_Id", param);
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




    public DataTable Evaluation_Criteria_CenterSelect(BLLEvaluation_Criteria_Center objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectAll", param);
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

    public DataTable Evaluation_Criteria_CenterSelectByStatusID(BLLEvaluation_Criteria_Center objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_CenterSelectByStatusID");
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
