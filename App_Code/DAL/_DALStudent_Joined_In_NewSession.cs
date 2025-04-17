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
/// Summary description for _DALStudent_Joined_In_NewSession
/// </summary>
public class DALStudent_Joined_In_NewSession
{
    DALBase dalobj = new DALBase();


    public DALStudent_Joined_In_NewSession()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Joined_In_NewSessionAdd(BLLStudent_Joined_In_NewSession objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        
        param[0] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Student_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Student_Name;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[5].Value = objbll.Class_Name;
        param[6] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[6].Value = objbll.Section_Id;
        param[7] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[7].Value = objbll.Section_Name;
        param[8] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[8].Value = objbll.Session_Id;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;


        int k = dalobj.sqlcmdExecute("Student_Joined_In_NewSessionInsert", param);
        k = Convert.ToInt32(param[9].Value);
        return k;
        

    }
    public int Student_Joined_In_NewSessionUpdate(BLLStudent_Joined_In_NewSession objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Student_Joined_In_NewSession_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Joined_In_NewSession_Id;
        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Student_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Student_Name;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[5].Value = objbll.Class_Name;
        param[6] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[6].Value = objbll.Section_Id;
        param[7] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[7].Value = objbll.Section_Name;
        param[8] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[8].Value = objbll.Session_Id;
        param[9] = new SqlParameter("@IsProcess", SqlDbType.Bit);
        param[9].Value = objbll.IsProcess;
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Joined_In_NewSessionUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Joined_In_NewSessionDelete(BLLStudent_Joined_In_NewSession objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Joined_In_NewSession_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Joined_In_NewSession_Id;


        int k = dalobj.sqlcmdExecute("Student_Joined_In_NewSessionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Joined_In_NewSessionSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Joined_In_NewSessionSelectById", param);
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


    public DataTable Student_SelectAllByStudentNoForStudent_Joined_In_NewSession(BLLStudent_Joined_In_NewSession objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_No", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_SelectAllByStudentNoForStudent_Joined_In_NewSession", param);
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


    public DataTable Student_Joined_In_NewSessionSelect(BLLStudent_Joined_In_NewSession objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Joined_In_NewSessionSelectAll", param);
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

    public DataTable Student_Joined_In_NewSessionSelectByStatusID(BLLStudent_Joined_In_NewSession objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Joined_In_NewSessionSelectByStatusID");
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
