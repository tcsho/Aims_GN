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
/// Summary description for _DALSearchUser
/// </summary>
public class DALSearchUser
{
    DALBase dalobj = new DALBase();


    public DALSearchUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SearchUserAdd(BLLSearchUser objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchUserInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int SearchUserUpdate(BLLSearchUser objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchUserUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int SearchUserDelete(BLLSearchUser objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SearchUser_Id", SqlDbType.Int);
        //   param[0].Value = objbll.SearchUser_Id;


        int k = dalobj.sqlcmdExecute("SearchUserDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SearchUserSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchUserSelectById", param);
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

    public DataTable SearchUserSelect(BLLSearchUser objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.FirstName;

        param[1] = new SqlParameter("@sp_EmployeeId", SqlDbType.NVarChar);
        param[1].Value =objbll.EmployeeCode ;

        param[2] = new SqlParameter("@sp_Username", SqlDbType.NVarChar);
        param[2].Value = objbll.User_Name;

        param[3] = new SqlParameter("@sp_gender", SqlDbType.NVarChar);
        param[3].Value = objbll.Gender_Id;

        param[4] = new SqlParameter("@sp_groupName", SqlDbType.NVarChar);
        param[4].Value = objbll.User_Type_Id;

        param[5] = new SqlParameter("@sp_region", SqlDbType.NVarChar);
        param[5].Value = objbll.Region_Id;

        param[6] = new SqlParameter("@sp_center", SqlDbType.NVarChar);
        param[6].Value = objbll.Cetnter_Id;

        param[7] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NVarChar);
        param[7].Value = objbll.Mo_Id;





        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchUser", param);
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

    public DataTable SearchUserWithPassword(BLLSearchUser objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.FirstName;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.LastName;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.MiddleName;

        param[3] = new SqlParameter("@sp_gender", SqlDbType.NVarChar);
        param[3].Value = objbll.Gender_Id;

        param[4] = new SqlParameter("@sp_groupName", SqlDbType.NVarChar);
        param[4].Value = objbll.User_Type_Id;

        param[5] = new SqlParameter("@sp_region", SqlDbType.NVarChar);
        param[5].Value = objbll.Region_Id;

        param[6] = new SqlParameter("@sp_center", SqlDbType.NVarChar);
        param[6].Value = objbll.Cetnter_Id;

        param[7] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NVarChar);
        param[7].Value = objbll.Mo_Id;





        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchUserWithPassword", param);
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


    public DataTable SearchUserSelectByStatusID(BLLSearchUser objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchUserSelectByStatusID");
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
