using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALSection_Subject_Activity_Skill
/// </summary>
public class DALSection_Subject_Activity_Skill
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Activity_Skill()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_Activity_SkillAdd(BLLSection_Subject_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Activity_SkillInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Section_Subject_Activity_SkillUpdate(BLLSection_Subject_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Activity_SkillUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_Activity_SkillDelete(BLLSection_Subject_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Activity_Skill_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Activity_Skill_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_Activity_SkillDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_Activity_SkillSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Section_Subject_Activity_SkillSelectById", param);
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
    
    public DataTable Section_Subject_Activity_SkillSelect(BLLSection_Subject_Activity_Skill objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Section_Subject_Activity_SkillSelectAll", param);
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

    public DataTable Activity_SkillFetchByActivityId(BLLSection_Subject_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SSA_Id", SqlDbType.Int);
        param[0].Value = objbll.SSA_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_Activity_SkillSelectByActivityId", param);
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

    public DataTable Section_Subject_Activity_SkillSelectByStatusID(BLLSection_Subject_Activity_Skill objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Section_Subject_Activity_SkillSelectByStatusID");
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
