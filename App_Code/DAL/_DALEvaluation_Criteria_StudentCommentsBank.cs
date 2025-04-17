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
/// Summary description for _DALEvaluation_Criteria_StudentCommentsBank
/// </summary>
public class _DALEvaluation_Criteria_StudentCommentsBank
{
    DALBase dalobj = new DALBase();


    public _DALEvaluation_Criteria_StudentCommentsBank()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_StudentCommentsBankAdd(BLLEvaluation_Criteria_StudentCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[3].Value = objbll.TermGroup_Id;
        param[4] = new SqlParameter("@CommCat_Id", SqlDbType.Int);
        param[4].Value = objbll.CommCat_Id;
        param[5] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[5].Value = objbll.Comments;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[7].Value = objbll.CreatedOn;

        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_StudentCommentsBankInsert", param);
        int k = (int)param[8].Value;
        return k;

    }
    public int Evaluation_Criteria_StudentCommentsBankUpdate(BLLEvaluation_Criteria_StudentCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

       
        param[0] = new SqlParameter("@ComBank_Id", SqlDbType.Int);
        param[0].Value = objbll.ComBank_Id;
        param[1] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[1].Value = objbll.Comments;

        param[2] = new SqlParameter("@CommCat_Id", SqlDbType.Int);
        param[2].Value = objbll.CommCat_Id;


        param[3] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[3].Value = objbll.ModifiedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[4].Value = objbll.ModifiedOn;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_StudentCommentsBankUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int Evaluation_Criteria_StudentCommentsBankDelete(BLLEvaluation_Criteria_StudentCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Criteria_StudentCommentsBank_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Evaluation_Criteria_StudentCommentsBank_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_StudentCommentsBankDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_StudentCommentsBankSelectById(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_StudentCommentsBankSelectById", param);
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
    
    public DataTable Evaluation_Criteria_StudentCommentsBankSelectByParam(BLLEvaluation_Criteria_StudentCommentsBank objbll)
    {
    SqlParameter[] param = new SqlParameter[4];
 
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int); param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); param[3].Value = objbll.TermGroup_Id;
 

        DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_StudentCommentsBankSelectByParam", param);
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

    public DataTable Evaluation_Criteria_StudentCommentsBankSelectAll(BLLEvaluation_Criteria_StudentCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int); param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); param[3].Value = objbll.TermGroup_Id;
        param[4] = new SqlParameter("@CommCat_Id", SqlDbType.Int); param[4].Value = objbll.CommCat_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_StudentCommentsBankSelectAll", param);
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
