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
/// Summary description for _DALStudent_Missing_Exam
/// </summary>
public class DALStudent_Missing_Exam
{
    DALBase dalobj = new DALBase();


    public DALStudent_Missing_Exam()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Missing_ExamAdd(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[16];


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
        param[9] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[9].Value = objbll.Subject_Id;
        param[10] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[10].Value = objbll.Subject_Name;
        param[11] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[11].Value = objbll.TermGroup_Id;

        param[12] = new SqlParameter("@SAbsent_Id", SqlDbType.Int);
        param[12].Value = objbll.SAbsent_Id;
        param[13] = new SqlParameter("@IsMissingExam", SqlDbType.Int);
        param[13].Value = objbll.IsMissingExam;
        param[14] = new SqlParameter("@IsMissingCoursework", SqlDbType.Int);
        param[14].Value = objbll.IsMissingCoursework;

        param[15] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[15].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_Missing_ExamInsert", param);
        k = Convert.ToInt32(param[15].Value);
        return k;
        
        
        
        /////////////
        ////SqlParameter[] param = new SqlParameter[15];


        ////param[0] = new SqlParameter("@Student_Missing_Exam_Id", SqlDbType.Int);
        ////param[0].Value = objbll.Student_Missing_Exam_Id;
        ////param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        ////param[0].Value = objbll.Student_Id;
        ////param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        ////param[1].Value = objbll.Region_Id;
        ////param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        ////param[2].Value = objbll.Center_Id;
        ////param[3] = new SqlParameter("@Student_Name", SqlDbType.NVarChar);
        ////param[3].Value = objbll.Student_Name;
        ////param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        ////param[4].Value = objbll.Class_Id;
        ////param[5] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        ////param[5].Value = objbll.Class_Name;
        ////param[6] = new SqlParameter("@Section_Id", SqlDbType.Int);
        ////param[6].Value = objbll.Section_Id;
        ////param[7] = new SqlParameter("@Section_Name", SqlDbType.NVarChar); 
        ////param[7].Value = objbll.Section_Name;
        ////param[8] = new SqlParameter("@Session_Id", SqlDbType.Int);
        ////param[8].Value = objbll.Session_Id;
        ////param[9] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////param[9].Value = objbll.Subject_Id;
        ////param[10] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        ////param[10].Value = objbll.Subject_Name;
        ////param[11] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        ////param[11].Value = objbll.TermGroup_Id;




        ////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        ////param[14].Direction = ParameterDirection.Output;

        ////dalobj.sqlcmdExecute("Student_Missing_ExamInsert", param);
        ////int k = (int)param[14].Value;
        ////return k;

    }
    public int Student_MissingExamOAAdd(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[4].Value = objbll.Section_Id;
        param[5] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[5].Value = objbll.Evaluation_Type_Id;
        param[6] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[6].Value = objbll.Evaluation_Criteria_Id;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_MissingExamOAInsert", param);
        k = Convert.ToInt32(param[7].Value);
        return k;
 
    }
    public int Student_Missing_ExamUpdate(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@SAbsent_Id", SqlDbType.Int);
        param[0].Value = objbll.SAbsent_Id;

 
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Missing_ExamUpdate", param);
        int k = (int)param[1].Value;
        return k;
    }
    public int Student_Missing_ExamDelete(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@SAbsent_Id", SqlDbType.Int);
        param[0].Value = objbll.SAbsent_Id;
        param[1] = new SqlParameter("@IsMissingCoursework", SqlDbType.Int);
        param[1].Value = objbll.IsMissingCoursework;
        param[2] = new SqlParameter("@IsMissingExam", SqlDbType.Int);
        param[2].Value = objbll.IsMissingExam;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Missing_ExamDelete", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Student_MissingExamOADelete(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@SDash_Id", SqlDbType.Int);
        param[0].Value = objbll.SDash_Id;


        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_MissingExamOADelete", param);
        int k = (int)param[1].Value;
        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Missing_ExamSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Missing_ExamSelectById", param);
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
    
    public DataTable Student_Missing_ExamSelect(BLLStudent_Missing_Exam objbll)
    {
  //////  SqlParameter[] param = new SqlParameter[3];

  //////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  ////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Missing_ExamSelectAll");
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


    public DataTable Evaluation_Criteria_TypeSelectByStudentId(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectByStudentId", param);
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


    public DataTable Student_SelectAllByStudentNoForStudentMissingExam(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_Id;
        

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_SelectAllByStudentNoForStudentMissingExam", param);
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

    public DataTable Student_MissingExamOASelectAll(BLLStudent_Missing_Exam objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

      

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_MissingExamOASelectAll", param);
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

    public DataTable Student_Missing_ExamSelectByStatusID(BLLStudent_Missing_Exam objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Missing_ExamSelectByStatusID");
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
