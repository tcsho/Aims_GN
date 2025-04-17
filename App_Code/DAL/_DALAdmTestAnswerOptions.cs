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
/// Summary description for _DALAdmTestAnswerOptions
/// </summary>
public class DALAdmTestAnswerOptions
{
    DALBase dalobj = new DALBase();


    public DALAdmTestAnswerOptions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestAnswerOptionsAdd(BLLAdmTestAnswerOptions objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@AnswerOption_ID", SqlDbType.Int); 
        param[0].Value = objbll.AnswerOption_ID;
        param[0] = new SqlParameter("@AnswerOptionDesc", SqlDbType.NVarChar); 
        param[0].Value = objbll.AnswerOptionDesc;
        param[1] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[1].Value = objbll.Status_ID;
        param[2] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[2].Value = objbll.CreatedBy;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        param[5].Value = objbll.ModifiedOn;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestAnswerOptionsInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int AdmTestAnswerOptionsUpdate(BLLAdmTestAnswerOptions objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@AnswerOption_ID", SqlDbType.Int);
        param[0].Value = objbll.AnswerOption_ID;
        param[0] = new SqlParameter("@AnswerOptionDesc", SqlDbType.NVarChar);
        param[0].Value = objbll.AnswerOptionDesc;
        param[1] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[1].Value = objbll.Status_ID;
        param[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[2].Value = objbll.CreatedBy;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[5].Value = objbll.ModifiedOn;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestAnswerOptionsUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int AdmTestAnswerOptionsDelete(BLLAdmTestAnswerOptions objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestAnswerOptions_Id", SqlDbType.Int);
     //   param[0].Value = objbll.AdmTestAnswerOptions_Id;


        int k = dalobj.sqlcmdExecute("AdmTestAnswerOptionsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestAnswerOptionsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestAnswerOptionsSelectById", param);
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
    
    public DataTable AdmTestAnswerOptionsSelect(BLLAdmTestAnswerOptions objbll)
    {
  //////////  SqlParameter[] param = new SqlParameter[3];

  //////////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  ////////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestAnswerOptionsSelectAll");
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

    public DataTable AdmTestAnswerOptionsSelectByStatusID(BLLAdmTestAnswerOptions objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestAnswerOptionsSelectByStatusID");
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
