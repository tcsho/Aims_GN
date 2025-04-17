using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Performance_ClassAchvRating
/// </summary>
public class DALStudent_Performance_ClassAchvRating
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_ClassAchvRating()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_ClassAchvRatingAdd(BLLStudent_Performance_ClassAchvRating objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); param[0].Value = objbll.Main_Organistion_Id;
        param[1] = new SqlParameter("@AchvRating_Id", SqlDbType.Int); param[1].Value = objbll.AchvRating_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int); param[2].Value = objbll.Class_Id;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_ClassAchvRatingInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Student_Performance_ClassAchvRatingUpdate(BLLStudent_Performance_ClassAchvRating objbll)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@KindClassAchvRating_Id", SqlDbType.Int); param[0].Value = objbll.KindClassAchvRating_Id;
        param[1] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); param[1].Value = objbll.Main_Organistion_Id;
        param[2] = new SqlParameter("@AchvRating_Id", SqlDbType.Int); param[2].Value = objbll.AchvRating_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int); param[3].Value = objbll.Class_Id;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_ClassAchvRatingUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Performance_ClassAchvRatingDelete(BLLStudent_Performance_ClassAchvRating objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@KindClassAchvRating_Id", SqlDbType.Int) { Value = objbll.KindClassAchvRating_Id };

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_Performance_ClassAchvRatingDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_ClassAchvRatingSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_ClassAchvRatingSelectById", param);
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
    
    public DataTable Student_Performance_ClassAchvRatingSelect(BLLStudent_Performance_ClassAchvRating objbll)
    {
    SqlParameter[] param = new SqlParameter[2];

    param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
    param[0].Value = objbll.Main_Organistion_Id;

    param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
    param[1].Value = objbll.Section_Id;



    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_ClassAchvRatingSelectAll", param);
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

    public DataTable Student_Performance_ClassAchvRatingSelectByStatusID(BLLStudent_Performance_ClassAchvRating objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_ClassAchvRatingSelectByStatusID");
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

    public DataTable Student_Performance_ClassAchvRatingSelectAllByOrgId(BLLStudent_Performance_ClassAchvRating _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_ClassAchvRatingSelectAllByOrgId", param);
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
