using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Section_Subject
/// </summary>
public class DALStudent_Section_Subject
{
    DALBase dalobj = new DALBase();


    public DALStudent_Section_Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Section_SubjectAdd(BLLStudent_Section_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;

        //param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //param[14].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_Section_SubjectInsert", param);
        //int k = (int)param[14].Value;
        return k;

    }
    public int Student_Secttion_Subject_AssignUpdate(BLLStudent_Section_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        param[2] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Secttion_Subject_AssignUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Student_Secttion_Subject_UnAssign(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        param[2] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Secttion_Subject_UnAssign", param);
        int k = (int)param[3].Value;
        return k;
    }

    public int Student_Section_SubjectUpdate(BLLStudent_Section_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Student_Section_Subject_Id;
        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;
        param[3] = new SqlParameter("@isAssignedToWrk", SqlDbType.Bit);
        param[3].Value = objbll.isAssignedToWrk;

 
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Section_SubjectUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Student_Section_SubjectDelete(BLLStudent_Section_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Section_Subject_Id;


        int k = dalobj.sqlcmdExecute("Student_Section_SubjectDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Section_SubjectSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectById", param);
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
    public DataTable student_section_subjectSelectBySectionStudent_Id(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("student_section_subjectSelectBySectionStudent_Id", param);
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



    public DataTable Student_Section_SubjectSelectStudentWorkSpace(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectStudentWorkSpace", param);
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


    
    public DataTable Student_Section_SubjectSelect(BLLStudent_Section_Subject objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectAll", param);
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

    public DataTable Student_Section_SubjectSelectByStatusID(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        param[1] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Status_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectByStatusID",param);
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


    public DataTable Student_Section_SubjectSelectBySectionID(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Status_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectBySectionID", param);
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

    public DataTable Student_Section_SubjectSelectBySessionSectionID(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Student_Status_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectBySessionSectionID", param);
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

    public DataTable StudentByCenterEvaluationId(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentByCenterEvaluationId", param);
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

    public DataTable student_section_subjectSelectBySectionSubjectStudent_Id(BLLStudent_Section_Subject objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Section_SubjectSelectBySectionSubjectStudent_Id", param);
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
