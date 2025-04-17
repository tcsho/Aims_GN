using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Performance_Grading_Det
/// </summary>
public class DALStudent_Performance_Grading_Det
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_Grading_Det()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_Grading_DetAdd(BLLStudent_Performance_Grading_Det objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@SSSKIL_Id", SqlDbType.Int);
        param[0].Value = objbll.SSSKIL_Id;

        param[1] = new SqlParameter("@KindClassAchvRating_Id", SqlDbType.Int);
        param[1].Value = objbll.KindClassAchvRating_Id;

        param[2] = new SqlParameter("@KindSubStdMst_Id", SqlDbType.Int);
        param[2].Value = objbll.KindSubStdMst_Id;

        param[3] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Section_Subject_Id;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("Student_Performance_Grading_DetInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Student_Performance_Grading_DetUpdate(BLLStudent_Performance_Grading_Det objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@KndSubStd_Id", SqlDbType.Int);
        param[0].Value = objbll.KndSubStd_Id;

        param[1] = new SqlParameter("@KindClassAchvRating_Id", SqlDbType.Int);
        param[1].Value = objbll.KindClassAchvRating_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("Student_Performance_Grading_DetUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Student_Performance_Grading_DetDelete(BLLStudent_Performance_Grading_Det objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Performance_Grading_Det_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Performance_Grading_Det_Id;


        int k = dalobj.sqlcmdExecute("Student_Performance_Grading_DetDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_Grading_DetSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_DetSelectById", param);
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
    
    public DataTable Student_Performance_Grading_DetSelect(BLLStudent_Performance_Grading_Det objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_DetSelectAll", param);
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

    public DataTable Student_Performance_Grading_DetSelectByStatusID(BLLStudent_Performance_Grading_Det objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_DetSelectByStatusID");
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
