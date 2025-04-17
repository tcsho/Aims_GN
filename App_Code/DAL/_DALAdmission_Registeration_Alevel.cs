using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmission_Registeration_Alevel
/// </summary>
public class DALAdmission_Registeration_Alevel
{
    DALBase dalobj = new DALBase();


    public DALAdmission_Registeration_Alevel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Admission_Registeration_AlevelAdd(BLLAdmission_Registeration_Alevel objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[1].Value = objbll.Registeration_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.NVarChar);
        param[2].Value = objbll.Marks_Obtained;
        param[3] = new SqlParameter("@IntendtoStudy", SqlDbType.Bit);
        param[3].Value = objbll.IntendtoStudy;
        param[4] = new SqlParameter("@IsStudy", SqlDbType.Bit);
        param[4].Value = objbll.IsStudy;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Registeration_AlevelInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Admission_Registeration_AlevelUpdate(BLLAdmission_Registeration_Alevel objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@Registeration_Id", SqlDbType.Int); 
        param[1].Value = objbll.Registeration_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.NVarChar); 
        param[2].Value = objbll.Marks_Obtained;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Registeration_AlevelUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Admission_Registeration_AlevelDelete(BLLAdmission_Registeration_Alevel objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Admission_Registeration_Alevel_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Admission_Registeration_Alevel_Id;


        int k = dalobj.sqlcmdExecute("Admission_Registeration_AlevelDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Admission_Registeration_AlevelSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_AlevelSelectById", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;
    }

    public DataTable Admission_Registeration_AlevelSelect(BLLAdmission_Registeration_Alevel objbll)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = objbll.Registeration_Id;
        DataTable dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_AlevelSelectByRegId", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }

    public DataTable Admission_Registeration_AlevelSelectByStatusID(BLLAdmission_Registeration_Alevel objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_AlevelSelectByStatusID");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }




    #endregion


}
