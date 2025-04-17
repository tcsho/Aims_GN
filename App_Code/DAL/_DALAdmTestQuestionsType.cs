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
/// Summary description for _DALAdmTestQuestionsType
/// </summary>
public class DALAdmTestQuestionsType
{
    DALBase dalobj = new DALBase();


    public DALAdmTestQuestionsType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestQuestionsTypeAdd(BLLAdmTestQuestionsType objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        //param[0] = new SqlParameter("@QuestType_ID", SqlDbType.Int); 
        //param[0].Value = objbll.QuestType_ID;
        param[0] = new SqlParameter("@QuestionTypeDesc", SqlDbType.NVarChar); 
        param[0].Value = objbll.QuestionTypeDesc;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@CraetedBy", SqlDbType.Int); 
        param[2].Value = objbll.CraetedBy;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[4].Value = objbll.ModifiedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[5].Value = objbll.ModifiedOn;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsTypeInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int AdmTestQuestionsTypeUpdate(BLLAdmTestQuestionsType objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        //param[0] = new SqlParameter("@QuestType_ID", SqlDbType.Int);
        //param[0].Value = objbll.QuestType_ID;
        param[0] = new SqlParameter("@QuestionTypeDesc", SqlDbType.NVarChar);
        param[0].Value = objbll.QuestionTypeDesc;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@CraetedBy", SqlDbType.Int);
        param[2].Value = objbll.CraetedBy;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[5].Value = objbll.ModifiedOn;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsTypeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int AdmTestQuestionsTypeDelete(BLLAdmTestQuestionsType objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestQuestionsType_Id", SqlDbType.Int);
     //   param[0].Value = objbll.AdmTestQuestionsType_Id;


        int k = dalobj.sqlcmdExecute("AdmTestQuestionsTypeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestQuestionsTypeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsTypeSelectById", param);
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
    
    public DataTable AdmTestQuestionsTypeSelect(BLLAdmTestQuestionsType objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsTypeSelectAll", param);
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

    public DataTable AdmTestQuestionsTypeSelectByStatusID(BLLAdmTestQuestionsType objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsTypeSelectByStatusID");
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
