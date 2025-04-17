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
/// Summary description for _DALStudent_Diag_Prog
/// </summary>
public class DALStudent_Diag_Prog
{
    DALBase dalobj = new DALBase();


    public DALStudent_Diag_Prog()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Diag_ProgAdd(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@SSDPD_Id", SqlDbType.Int);
        param[0].Value = objbll.SSDPD_Id;
        param[1] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Section_Subject_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal);
        param[2].Value = objbll.Marks_Obtained;
        param[3] = new SqlParameter("@Lock_Marks", SqlDbType.Int);
        param[3].Value = objbll.Lock_Marks;


        int k = dalobj.sqlcmdExecute("Student_Diag_ProgInsert", param);
        return k;



    }
    public int Student_Diag_ProgUpdate(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@SSDPD_Id", SqlDbType.Int); param[0].Value = objbll.SSDPD_Id;
        param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int); param[0].Value = objbll.Student_Section_Subject_Id;
        param[1] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal); param[1].Value = objbll.Marks_Obtained;
        param[2] = new SqlParameter("@Lock_Marks", SqlDbType.Int); param[2].Value = objbll.Lock_Marks;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Diag_ProgUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }

    public int Student_Diag_ProgInsertMissingStudent(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@StudentId", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Decimal);
        param[1].Value = objbll.Section_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Diag_ProgInsertMissingStudent", param);
        int k = (int)param[2].Value;
        return k;

    }

    public int Student_Diag_ProgDelete(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Diag_Prog_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Diag_Prog_Id;


        int k = dalobj.sqlcmdExecute("Student_Diag_ProgDelete", param);

        return k;
    }

    public int Student_Diag_ProgUpdateXML(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@xmlStudentCriteriaMarks", SqlDbType.NText);
        param[0].Value = objbll.XMLData;

        dalobj.sqlcmdExecute("Student_Diag_ProgUpdateXML", param);
        //int k = (int)param[1].Value;
        int k = 1;
        return k;
    }


    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Diag_ProgSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Diag_ProgSelectById", param);
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
    
    public DataTable Student_Diag_ProgSelect(BLLStudent_Diag_Prog objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Diag_ProgSelectAll", param);
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

    public DataTable Student_Diag_ProgBySectionSubjectIdForExistStudent(BLLStudent_Diag_Prog _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Subject_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;

        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Diag_ProgBySectionSubjectIdForExistStudent", param);
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

    public DataTable Student_Diag_ProgSelectBySectionSubjectIdForInsertStudent(BLLStudent_Diag_Prog _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Subject_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Diag_ProgSelectBySectionSubjectIdForInsertStudent", param);
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


    public DataTable Student_Diag_ProgSelectByStatusID(BLLStudent_Diag_Prog objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Diag_ProgSelectByStatusID");
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


    public DataTable Student_Diag_ProgSelectByGrid(BLLStudent_Diag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        param[2] = new SqlParameter("@Student_id", SqlDbType.Int);
        param[2].Value = objbll.Student_Id;
        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_Diag_Prog_DetailBySectionSubjectId", param);
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
