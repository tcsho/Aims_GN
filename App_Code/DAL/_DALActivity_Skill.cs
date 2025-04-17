using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALActivity_Skill
/// </summary>
public class DALActivity_Skill
{
    DALBase dalobj = new DALBase();


    public DALActivity_Skill()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Activity_SkillAdd(BLLActivity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Activity_Skill_Id;
        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int); 
        param[0].Value = objbll.Activity_Id;
        param[1] = new SqlParameter("@Skill", SqlDbType.NVarChar); 
        param[1].Value = objbll.Skill;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Activity_SkillInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Activity_SkillUpdate(BLLActivity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int);
        param[0].Value = objbll.Activity_Skill_Id;
        param[1] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[1].Value = objbll.Activity_Id;
        param[2] = new SqlParameter("@Skill", SqlDbType.NVarChar);
        param[2].Value = objbll.Skill;

 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Activity_SkillUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Activity_SkillDelete(BLLActivity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int);
         param[0].Value = objbll.Activity_Skill_Id;


        int k = dalobj.sqlcmdExecute("Activity_SkillDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Activity_SkillSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Activity_SkillSelectById", param);
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
    
    public DataTable Activity_SkillSelect(BLLActivity_Skill objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Activity_SkillSelectAll", param);
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

    public DataTable Activity_SkillSelectByStatusID(BLLActivity_Skill objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_SkillSelectByStatusID");
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

    public DataTable Activity_Skill_SelectAllByActivityId(BLLActivity_Skill _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = _obj.Activity_Id;

        

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_Skill_SelectAllByActivityId", param);
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

    public DataTable Activity_Skill_SelectAllValuesByActivityIdSkillId(BLLActivity_Skill _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = _obj.Activity_Id;

        param[1] = new SqlParameter("@Activity_Skill_Id", SqlDbType.Int);
        param[1].Value = _obj.Activity_Skill_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_Skill_SelectAllValuesByActivityIdSkillId", param);
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


    public DataTable Activity_Skill_SelectToCheckExistingActivitySkillDescription(BLLActivity_Skill _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = _obj.Activity_Id;

        param[1] = new SqlParameter("@Skill", SqlDbType.Int);
        param[1].Value = _obj.Skill;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_Skill_SelectToCheckExistingActivitySkillDescription", param);
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
