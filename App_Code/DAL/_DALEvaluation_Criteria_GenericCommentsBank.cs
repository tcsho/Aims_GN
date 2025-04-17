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
/// Summary description for _DALEvaluation_Criteria_GenericCommentsBank
/// </summary>
public class _DALEvaluation_Criteria_GenericCommentsBank
{
    DALBase dalobj = new DALBase();


    public _DALEvaluation_Criteria_GenericCommentsBank()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_GenericCommentsBankAdd(BLLEvaluation_Criteria_GenericCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[3].Value = objbll.TermGroup_Id;
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[6].Value = objbll.CreatedOn;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_GenericCommentsBankInsert", param);
        int k = (int)param[7].Value;
        return k;

    }
    public int Evaluation_Criteria_GenericCommentsBankUpdate(BLLEvaluation_Criteria_GenericCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@GenCom_Id", SqlDbType.Int); param[0].Value = objbll.GenCom_Id;
        param[1] = new SqlParameter("@Comments", SqlDbType.NVarChar); param[1].Value = objbll.Comments;
        param[2] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[2].Value = objbll.ModifiedOn;
        param[3] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[3].Value = objbll.ModifiedBy;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_GenericCommentsBankUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Evaluation_Criteria_GenericCommentsBankDelete(BLLEvaluation_Criteria_GenericCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GenCom_Id", SqlDbType.Int); param[0].Value = objbll.GenCom_Id;

        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_GenericCommentsBankDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_GenericCommentsBankSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GenCom_Id", SqlDbType.Int);

        param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_GenericCommentsBankSelect", param);
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



    
public DataTable Evaluation_Criteria_GenericCommentsBankSelect(BLLEvaluation_Criteria_GenericCommentsBank objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        
        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;
        
        param[3] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[3].Value = objbll.Region_id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_GenericCommentsBankSelectByClassSubject", param);
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

    public DataTable Evaluation_Criteria_GenericCommentsBankSelectAll()
    { 

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_GenericCommentsBankSelectAll");
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


    public int Evaluation_Criteria_GenericCommentsBankSelectField(int _Id)
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
