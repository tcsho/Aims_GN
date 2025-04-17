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
/// Summary description for _DALAdmTestQuestions
/// </summary>
public class DALAdmTestQuestions
{
    DALBase dalobj = new DALBase();


    public DALAdmTestQuestions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestQuestionsAdd(BLLAdmTestQuestions objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@AnsPointValue", SqlDbType.Decimal); 
        param[0].Value = objbll.AnsPointValue;
        param[1] = new SqlParameter("@QuesText", SqlDbType.NVarChar);
        param[1].Value = objbll.QuesText;
        param[2] = new SqlParameter("@NegtvPointValue", SqlDbType.Decimal);
        param[2].Value = objbll.NegtvPointValue;
        
        param[3] = new SqlParameter("@Comments", SqlDbType.NVarChar); 
        param[3].Value = objbll.Comments;
     
        
        param[4] = new SqlParameter("@Pool_Id", SqlDbType.Int);
        param[4].Value = objbll.Pool_Id;
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int AdmTestQuestionsUpdate(BLLAdmTestQuestions objbll)
    {
        SqlParameter[] param = new SqlParameter[7];



        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;
        
        param[1] = new SqlParameter("@AnsPointValue", SqlDbType.Decimal);
        param[1].Value = objbll.AnsPointValue;
        param[2] = new SqlParameter("@QuesText", SqlDbType.NVarChar);
        param[2].Value = objbll.QuesText;
        param[3] = new SqlParameter("@NegtvPointValue", SqlDbType.Decimal);
        param[3].Value = objbll.NegtvPointValue;
       
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;
      
        param[5] = new SqlParameter("@Pool_Id", SqlDbType.Int);
        param[5].Value = objbll.Pool_Id;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }
    public int AdmTestQuestionsDelete(BLLAdmTestQuestions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("AdmTestQuestionsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestQuestionsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsSelectById", param);
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
  
    public DataTable AdmTestQuestionsSelect(BLLAdmTestQuestions objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsSelectAll", param);
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


    public DataTable AdmTestQuestionsSelectAllByAdmTestDetailId(BLLAdmTestQuestions objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Pool_Id", SqlDbType.Int);
        param[0].Value = objbll.Pool_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsSelectAllByPoolId", param);
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


    public DataTable AdmTestQuestionsSelectAllByAdmTestDetailIdQuestId(BLLAdmTestQuestions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Pool_Id", SqlDbType.Int);
        param[0].Value = objbll.Pool_Id;


        param[1] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[1].Value = objbll.Quest_ID;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsSelectAllByAdmTestDetailIdQuestId", param);
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





    public DataTable AdmTestQuestionsSelectByStatusID(BLLAdmTestQuestions objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsSelectByStatusID");
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
