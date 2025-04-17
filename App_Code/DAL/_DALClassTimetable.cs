using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSubject
/// </summary>
public class DALClassTimetable
{
    DALBase dalobj = new DALBase();


    public DALClassTimetable()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable SubjectSelectAllWithSubNameGroup(BLLClassTimetable objbll)
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectSelectAllWithSubNameGroup");
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

   
    public DataTable SubjectSelectByStatusID(BLLClassTimetable objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectSelectByStatusID");
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






   
  



    public DataTable GetClasses()
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_Classes_Siqa");
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
    }



    
   


    public DataTable Get_Indicators(int Group_ID, int PS_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[0].Value = Group_ID;
        param[1] = new SqlParameter("@PS_ID", SqlDbType.Int);
        param[1].Value = PS_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_Get_Indicators", param);
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
    }

    //Sp_Get_Indicators



    public DataTable Get_Sections(int Center_ID, int Class_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = Center_ID;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = Class_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SP_GET_SECTIONS_BY_CENTER_CLASS_ID", param);
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
    }


    public int TimeTable_Insert(BLLClassTimetable objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[2].Value = objbll.Session_id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Teacher_Id", SqlDbType.Int);
        param[4].Value = objbll.Teacher_Id;
        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = objbll.Subject_Id;
        param[6] = new SqlParameter("@Starttime", SqlDbType.DateTime);
        param[6].Value = objbll.Starttime;
        param[7] = new SqlParameter("@Endtime", SqlDbType.DateTime);
        param[7].Value = objbll.Endtime;
        param[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
        param[8].Value = objbll.IsActive;
        param[9] = new SqlParameter("@CreateBy", SqlDbType.NVarChar);
        param[9].Value = objbll.CreateBy;

        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("[ClassTimetable_Insert]", param);
        int k = (int)param[10].Value;
        return k;

    }

   

  

   


    public DataTable Get_Timetabledata(
        string Region_ID, 
        string Center_id 
        //string teacher_id, 
        //string class_id, 
        //string subject_id, 
        //string Term_Group_id,
        //string keystage
        )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        //param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        //param[2].Value = teacher_id;

        //param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        //param[3].Value = class_id;

        //param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        //param[4].Value = subject_id;

        //param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        //param[5].Value = Term_Group_id;

        //param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        //param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Get_Timetable_Data]", param);
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
    }


  
    public int TimetableDelete(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@TimetableId", SqlDbType.Int);
        param[0].Value = id;


        int k = dalobj.sqlcmdExecute("[TimeTableDelete]", param);

        return k;
    }

}
