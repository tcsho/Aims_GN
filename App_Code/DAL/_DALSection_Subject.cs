using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSection_Subject
/// </summary>
public class DALSection_Subject
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_SubjectAdd(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Section_Subject_Id;
        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int); 
        param[2].Value = objbll.Session_Id;
        param[3] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[3].Value = objbll.Employee_Id;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_SubjectInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Section_SubjectUpdate(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = objbll.Employee_Id;

 
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_SubjectUpdateTeacher", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Section_SubjectDelete(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Id;


        int k = dalobj.sqlcmdExecute("Section_SubjectDelete", param);

        return k;
    }

    public int Section_SubjectWorkSiteUpdate(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[1].Value = objbll.Description;
        param[2] = new SqlParameter("@SpecialInstructions", SqlDbType.NVarChar);
        param[2].Value = objbll.SpecialInstructions;
        
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_SubjectWorkSiteUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }



    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_SubjectSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_SubjectSelectById", param);
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

    public DataTable Section_SubjectByEmployeeIdSectionId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = _obj.Employee_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectByEmployeeIdSectionId", param);
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


    public DataTable Section_SubjectSelectSubjectBySectionId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = _obj.Session_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectSubjectBySectionId", param);
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

    public DataTable Section_SubjectSelectSubjectBySectionIdSubjectId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = _obj.Center_Id;

        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = _obj.Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectSubjectBySectionIdSubjectId", param);
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

    public DataTable GetStudents_AssignedForSubjectWiseAllocation(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = _obj.Session_Id;

        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = _obj.Center_Id;

        param[2] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[2].Value = _obj.Section_Id;

        param[3] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[3].Value = _obj.Section_Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudents_AssignedForSubjectWiseAllocation", param);
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


    public DataTable Section_SubjectByEmployeeIdSessionSectionId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;
 
        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = _obj.Employee_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = _obj.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectByEmployeeIdSessionSectionId", param);
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
    public DataTable Evaluation_Criteria_TypeByClassId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Org_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeByClassId", param);
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

    public DataTable Evaluation_Criteria_TypeBySectionId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Org_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = _obj.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeBySectionId", param);
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


    public DataTable Evaluation_Criteria_BySectionIdSubjectEvlId(BLLSection_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = _obj.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Section_Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_BySectionIdSubjectEvlId", param);
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



    public DataTable Evaluation_TypeSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _id;

        ////////////////param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        ////////////////param[1].Value = _obj.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_TypeSelect", param);
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


    
    
    public DataTable Section_SubjectSelect(BLLSection_Subject objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAll", param);
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

    public DataTable Section_SubjectSelectByStatusID(BLLSection_Subject objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectByStatusID");
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




    public DataTable Section_SubjectSelectBySectionTeacherPerformance(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSubjectSelectByPerformance", param);
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
    public DataTable Section_SubjectSelectBySectionTeacherActivity(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSubjectSelectByActivity", param);
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
    public DataTable Section_SubjectSelectTeacherByCenter_Id(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@sp_center_id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectTeacherByCenter_Id", param);
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




    public DataTable Section_SubjectSelectWorkSiteBySection_Id(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteBySection_Id", param);
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



    public DataTable Section_SubjectSelectWorkSiteALLBySection_Id(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteALLBySection_Id", param);
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



    public DataTable Section_SubjectSelectWorkSiteBySection_Subject_Id(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteBySection_Subject_Id", param);
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

public DataTable Techer_SubjectSelectByClassId(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

 

 

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

 

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

 

        DataTable _dt = new DataTable();

 

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSubjectSelectByTeacherID", param);
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

    public DataTable Section_SubjectSelectTeacherWorkSpace(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = objbll.Employee_Id;

        param[2] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Section_Subject_Id;

        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectTeacherWorkSpace", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherId(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

      

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

       

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherId", param);
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

    public DataTable Section_SubjectSelectAllWorkSiteByStudentId(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByStudentId", param);
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



    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForNews(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdForNews", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForPolls(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdForPolls", param);
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



    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForResources(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdForResources", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForDropBox(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdForDropBox", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForResources(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;


        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForResources", param);
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


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForDropBox(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;


        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForDropBox", param);
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

    public DataTable Section_SubjectSelectAllStudentByTeacherIdForDropBox(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;


        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectAllStudentByTeacherIdForDropBox", param);
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


    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement", param);
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


    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews", param);
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



    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls", param);
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


    public DataTable Section_SubjectSelectBySectionTeacherEvaluation(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSubjectSelectByEvaluationCriteria", param);
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


    public DataTable SectionSubjectSelectWithoutEvaluationCriteria(BLLSection_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];



        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.Employee_Id;

        param[1] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SectionSubjectSelectWithoutEvaluationCriteria", param);
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









    public DataTable StudentBySectionSubjectId(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentBySectionSubjectId", param);
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

