using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Activity_Skill
/// </summary>
public class DALStudent_Activity_Skill
{
    DALBase dalobj = new DALBase();


    public DALStudent_Activity_Skill()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Activity_SkillAdd(BLLStudent_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Section_Subject_Id;

        param[1] = new SqlParameter("@SSAS_Id", SqlDbType.Int);
        param[1].Value = objbll.SSAS_Id;

        param[2] = new SqlParameter("@Marks", SqlDbType.Int);
        param[2].Value = objbll.Marks;

        param[3] = new SqlParameter("@Lock_Mark", SqlDbType.Bit);
        param[3].Value = objbll.Lock_Mark;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Activity_SkillInsert", param);
        int k = (int)param[4].Value;
        return k;


    }
    public int Student_Activity_SkillUpdate(BLLStudent_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Student_Activity_Skill_Id", SqlDbType.Int); param[0].Value = objbll.Student_Activity_Skill_Id;
        param[1] = new SqlParameter("@SSAS_Id", SqlDbType.Int); param[1].Value = objbll.SSAS_Id;
        param[2] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int); param[2].Value = objbll.Student_Section_Subject_Id;
        param[3] = new SqlParameter("@Marks", SqlDbType.Int); param[3].Value = objbll.Marks;
        param[4] = new SqlParameter("@Lock_Mark", SqlDbType.Bit); param[4].Value = objbll.Lock_Mark;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Activity_SkillUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Activity_SkillDelete(BLLStudent_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Activity_Skill_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Activity_Skill_Id;


        int k = dalobj.sqlcmdExecute("Student_Activity_SkillDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Activity_SkillSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Activity_SkillSelectById", param);
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
    
    public DataTable Student_Activity_SkillSelect(BLLStudent_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Activity_SkillSelectAll", param);
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
    public DataTable Student_Activity_SkillSelectBySectionSkill(BLLStudent_Activity_Skill objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;

        param[1] = new SqlParameter("@SSAS_Id", SqlDbType.Int);
        param[1].Value = objbll.SSAS_Id;    

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Activity_SkillSelectBySectionSkill", param);
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

    
    public DataTable Student_Activity_SkillSelectByStatusID(BLLStudent_Activity_Skill objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Activity_SkillSelectByStatusID");
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
