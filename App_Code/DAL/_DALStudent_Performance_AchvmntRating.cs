using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Performance_AchvmntRating
/// </summary>
public class DALStudent_Performance_AchvmntRating
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_AchvmntRating()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_AchvmntRatingAdd(BLLStudent_Performance_AchvmntRating objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@RateCode", SqlDbType.NVarChar);
        param[0].Value = objbll.RateCode;
        param[1] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organistion_Id;
        param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[2].Value = objbll.Description;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;
        //param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        //param[6].Value = objbll.ModifiedOn;
        //param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        //param[7].Value = objbll.ModifiedBy;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_AchvmntRatingInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int Student_Performance_AchvmntRatingUpdate(BLLStudent_Performance_AchvmntRating objbll)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@AchvRating_Id", SqlDbType.Int);
        param[0].Value = objbll.AchvRating_Id;
        param[1] = new SqlParameter("@RateCode", SqlDbType.NVarChar); 
        param[1].Value = objbll.RateCode;
        param[2] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); 
        param[2].Value = objbll.Main_Organistion_Id;
        param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[3].Value = objbll.Description;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[4].Value = objbll.Status_Id;
        //////param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        //////param[5].Value = objbll.CreatedOn;
        //////param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        //////param[6].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[6].Value = objbll.ModifiedBy;

 
        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_AchvmntRatingUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
    public int Student_Performance_AchvmntRatingDelete(BLLStudent_Performance_AchvmntRating objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AchvRating_Id", SqlDbType.Int);
        param[0].Value = objbll.AchvRating_Id;


        int k = dalobj.sqlcmdExecute("Student_Performance_AchvmntRatingDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_AchvmntRatingSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_AchvmntRatingSelectById", param);
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
    
    public DataTable Student_Performance_AchvmntRatingSelect(BLLStudent_Performance_AchvmntRating objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_AchvmntRatingSelectAll", param);
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

    public DataTable Student_Performance_AchvmntRatingSelectByStatusID(BLLStudent_Performance_AchvmntRating objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_AchvmntRatingSelectByStatusID");
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

    public DataTable Student_Performance_AchvmntRating_SelectAllByOrgId(BLLStudent_Performance_AchvmntRating _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MOId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_AchvmntRating_SelectAllByOrgId", param);
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


    public DataTable Student_Performance_AchvmntRating_SelectAllByAchvRatingId(BLLStudent_Performance_AchvmntRating _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@AchvRating_Id", SqlDbType.Int);
        param[1].Value = _obj.AchvRating_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_AchvmntRating_SelectAllByAchvRatingId", param);
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
