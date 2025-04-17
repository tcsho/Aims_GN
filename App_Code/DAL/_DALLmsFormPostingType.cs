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
/// Summary description for _DALLmsFormPostingType
/// </summary>
public class DALLmsFormPostingType
{
    DALBase dalobj = new DALBase();


    public DALLmsFormPostingType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsFormPostingTypeAdd(BLLLmsFormPostingType objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@PostingType_ID", SqlDbType.Int); param[0].Value = objbll.PostingType_ID;
        param[0] = new SqlParameter("@PostType", SqlDbType.NVarChar); param[0].Value = objbll.PostType;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int); param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[5].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@Description", SqlDbType.NVarChar); param[6].Value = objbll.Description;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormPostingTypeInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsFormPostingTypeUpdate(BLLLmsFormPostingType objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@PostingType_ID", SqlDbType.Int); param[0].Value = objbll.PostingType_ID;
        param[0] = new SqlParameter("@PostType", SqlDbType.NVarChar); param[0].Value = objbll.PostType;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int); param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[5].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@Description", SqlDbType.NVarChar); param[6].Value = objbll.Description;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormPostingTypeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsFormPostingTypeDelete(BLLLmsFormPostingType objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsFormPostingType_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsFormPostingType_Id;


        int k = dalobj.sqlcmdExecute("LmsFormPostingTypeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsFormPostingTypeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormPostingTypeSelectById", param);
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
    
    public DataTable LmsFormPostingTypeSelect(BLLLmsFormPostingType objbll)
    {
  ////////  SqlParameter[] param = new SqlParameter[3];

  ////////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormPostingTypeSelectAll");
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

    public DataTable LmsFormPostingTypeSelectByStatusID(BLLLmsFormPostingType objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormPostingTypeSelectByStatusID");
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
