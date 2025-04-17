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
/// Summary description for _DALStudent_Without_First_Term
/// </summary>
public class DALMyTestStudent_Without_First_Term
{
    DALBase dalobj = new DALBase();


    public DALMyTestStudent_Without_First_Term()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Without_First_TermAdd(BLLStudent_Without_First_Term objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        //param[0] = new SqlParameter("@Student_Without_First_Term_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Student_Without_First_Term_Id;
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

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_Without_First_TermInsert", param);
        k = Convert.ToInt32(param[9].Value);
        return k;



        //////////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //////////param[14].Direction = ParameterDirection.Output;

        //////////dalobj.sqlcmdExecute("Student_Without_First_TermInsert", param);
        //////////int k = (int)param[14].Value;
        //////////return k;

    }
    public int Student_Without_First_TermUpdate(BLLStudent_Without_First_Term objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@Student_Without_First_Term_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Without_First_Term_Id;
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
        param[8] = new SqlParameter("@IsProcess", SqlDbType.Bit);
        param[8].Value = objbll.IsProcess;


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Without_First_TermUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Without_First_TermDelete(BLLStudent_Without_First_Term objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Without_First_Term_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Without_First_Term_Id;


        int k = dalobj.sqlcmdExecute("Student_Without_First_TermDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Without_First_TermSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Without_First_TermSelectById", param);
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
    
    public DataTable Student_Without_First_TermSelect(BLLStudent_Without_First_Term objbll)
    {
    //////////////SqlParameter[] param = new SqlParameter[3];

  ////////////////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //////////////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Without_First_TermSelectAll");
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

    public DataTable Student_Without_First_TermSelectByStatusID(BLLStudent_Without_First_Term objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Without_First_TermSelectByStatusID");
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


    public DataTable Student_SelectAllByStudentNoForStudentWithoutFirstTerm(BLLStudent_Without_First_Term objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_No", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_SelectAllByStudentNoForStudentWithoutFirstTerm", param);
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
