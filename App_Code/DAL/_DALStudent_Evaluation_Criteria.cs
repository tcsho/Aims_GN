using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Evaluation_Criteria
/// </summary>
public class DALStudent_Evaluation_Criteria
{
    DALBase dalobj = new DALBase();


    public DALStudent_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Evaluation_CriteriaAdd(BLLStudent_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        //param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Student_Section_Subject_Id;
        param[0] = new SqlParameter("@SSEC_Id", SqlDbType.Int); 
        param[0].Value = objbll.SSEC_Id;
        param[1] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal); 
        param[1].Value = objbll.Marks_Obtained;
        param[2] = new SqlParameter("@Lock_Mark", SqlDbType.Bit); 
        param[2].Value = objbll.Lock_Mark;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[3].Value = objbll.Status_Id;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_CriteriaInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Student_Evaluation_CriteriaUpdate(BLLStudent_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Section_Subject_Id;
        param[1] = new SqlParameter("@SSEC_Id", SqlDbType.Int);
        param[1].Value = objbll.SSEC_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal);
        param[2].Value = objbll.Marks_Obtained;
        //param[3] = new SqlParameter("@Lock_Mark", SqlDbType.Bit);
        //param[3].Value = objbll.Lock_Mark;
        //param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        //param[4].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_CriteriaUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }

    public int Student_Evaluation_CriteriaUpdateXML(BLLStudent_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@xmlStudentCriteriaMarks", SqlDbType.NText);
        param[0].Value = objbll.XMLData;
        //param[1] = new SqlParameter("@SSEC_Id", SqlDbType.Int);
        //param[1].Value = objbll.SSEC_Id;
        //param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal);
        //param[2].Value = objbll.Marks_Obtained;
        ////param[3] = new SqlParameter("@Lock_Mark", SqlDbType.Bit);
        ////param[3].Value = objbll.Lock_Mark;
        ////param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        ////param[4].Value = objbll.Status_Id;
        //param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_CriteriaUpdateXML", param);
        //int k = (int)param[1].Value;
        int k = 1;
        return k;
    }
    public int Student_Evaluation_CriteriaDelete(BLLStudent_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Evaluation_Criteria_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Evaluation_Criteria_Id;


        int k = dalobj.sqlcmdExecute("Student_Evaluation_CriteriaDelete", param);

        return k;
    }

    public int Student_Evaluation_CriteriaInsertMissingStudent(BLLStudent_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@StudentId", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Decimal);
        param[1].Value = objbll.Section_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_CriteriaInsertMissingStudent", param);
        int k = (int)param[2].Value;
        return k;

    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Evaluation_CriteriaSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Evaluation_CriteriaSelectById", param);
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
    
    public DataTable Student_Evaluation_CriteriaSelect(BLLStudent_Evaluation_Criteria objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Evaluation_CriteriaSelectAll", param);
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

    public DataTable Student_Evaluation_CriteriaSelectByStatusID(BLLStudent_Evaluation_Criteria objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_CriteriaSelectByStatusID");
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

    public DataTable Student_Evaluation_CriteriaBySectionSubjectId(BLLStudent_Evaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = _obj.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Section_Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_CriteriaBySectionSubjectId", param);
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




    public DataTable Result_ByEmployeeSubjectWise(BLLStudent_Evaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Subject_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;





        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = _obj.Session_Id;

        param[3] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[3].Value = _obj.Employee_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_ByEmployeeSubjectWise", param);
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


    public DataTable Result_ByEmployeeCenterWise(BLLStudent_Evaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[2].Value = _obj.Student_Id;

        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = _obj.Session_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_ByEmployeeCenterWise", param);
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


    public DataTable Student_Evaluation_CriteriaByMissingStudent(BLLStudent_Evaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = _obj.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Section_Subject_Id;

        param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[2].Value = _obj.Student_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_CriteriaByMissingStudent", param);
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
