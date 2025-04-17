using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSection
/// </summary>
public class DALSection
{
    DALBase dalobj = new DALBase();


    public DALSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'

    public int ResultCompletion(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[0].Value = objbll.TermGroup_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        int k = dalobj.sqlcmdExecute("__Aims_ResultCompletionStatusMainOrganisation", param);

        return k;

    }
   
    public int SectionAdd(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Section_Name;

        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;

        param[3] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[3].Value = objbll.Comments;

        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SectionInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int SectionUpdate(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Section_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Section_Id;
        param[0] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Section_Name", SqlDbType.Int);
        param[1].Value = objbll.Section_Name;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.NVarChar);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@Comments", SqlDbType.Int);
        param[4].Value = objbll.Comments;


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SectionUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int SectionUpdateClassTeacher(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;
        param[1] = new SqlParameter("@Teacher_Id", SqlDbType.Int);
        param[1].Value = objbll.Teacher_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SectionUpdateClassTeacher", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int SectionDelete(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Section_Id;


        int k = dalobj.sqlcmdExecute("SectionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SectionSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectById", param);
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

    public DataTable SectionSelect(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectAll", param);
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

    public DataTable SectionSelectByStatusID(BLLSection objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectByStatusID");
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


    public DataTable Section_ClassTeacherResultCompletionStatus(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@ClassTeacher_Id", SqlDbType.Int);
        param[0].Value = objbll.ClassTeacher_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_ClassTeacherResultCompletionStatus", param);
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

    public DataTable Section_ClassCenterWiseResultCompletionStatus(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_ClassCenterWiseResultCompletionStatus", param);
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

    public DataTable Section_ClassMainOrganizationWiseResultCompletionStatus(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@MainOrganization_Id", SqlDbType.Int);
        param[0].Value = objbll.MainOrganization_Id;

        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;

        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[4].Value = objbll.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_ClassMainOrganizationWiseResultCompletionStatus", param);
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


    public DataTable Section_SelectForResultCard(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[2].Value = objbll.Student_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectByResultCard", param);
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

    public DataTable Section_ClassRegionWiseResultCompletionStatus(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_ClassRegionWiseResultCompletionStatus", param);
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



    public DataTable SectionSelectBySetionNameClassCenter_Id(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[2].Value = objbll.Section_Name;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectBySetionNameClassCenter_Id", param);
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

    public DataTable SectionSelectByClassCenter(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectByClassCenter_Id", param);
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

    public DataTable SectionSelectByClassTeacherCenter(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[2].Value = objbll.Teacher_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectByClassTeacherCenter_Id", param);
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

    public DataTable SectionSelectClassTeacherBySection_Id(BLLSection objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSelectClassTeacherBySectionId", param);
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

    public int Class_SectionDelete(BLLSection obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = obj.Class_Id;
        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = obj.Section_Id;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;
        int k = dalobj.sqlcmdExecute("Class_SectionDelete", param);
        return k;

    }
    #endregion


}
