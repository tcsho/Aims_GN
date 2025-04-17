using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DllAssignSubjectToClass
/// </summary>
public class DllAssignSubjectToClass
{
    DALBase dalobj = new DALBase();

    internal int AddNewSubject(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[0].Value = subject.Subject_Name;

        param[1] = new SqlParameter("@Subject_Code", SqlDbType.NVarChar);
        param[1].Value = subject.Subject_Code;

        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = subject.Status_Id;

        param[3] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[3].Value = subject.Comments;

        param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[4].Value = 1;

        param[5] = new SqlParameter("@isKPI", SqlDbType.Bit);
        param[5].Value = 1;

        param[6] = new SqlParameter("@SortOrder", SqlDbType.Int);
        param[6].Value = 1;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AddNewSubject", param);
        int k = (int)param[7].Value;
        return k;
    }

    internal int AddClassSubject(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = subject.Class_ID;

        param[1] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[1].Value = subject.Subject_ID;

        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = subject.Status_Id;


        param[3] = new SqlParameter("@OrderofSubject", SqlDbType.Int);
        param[3].Value = subject.OrderofSubject;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AddSubjectClass", param);
        int k = (int)param[4].Value;
        return k;
    }

    internal int UpdateClassSubject(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Subject_Id", SqlDbType.Int);
        param[0].Value = subject.Class_Subject_Id;

        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[1].Value = subject.Status_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("UpdateSubjectToClass", param);
        int k = (int)param[2].Value;
        return k;
    }

    internal DataTable  GetAllClasses(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@statusId", SqlDbType.Int);
        param[0].Value = subject.Status_Id;

        param[1] = new SqlParameter("@subjectId", SqlDbType.Int);
        param[1].Value = subject.Subject_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetAllClasses", param);
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

    internal int UpdateSubject(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int) {Value = subject.Subject_Id};
        param[1] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar) {Value = subject.Subject_Name};
        param[2] = new SqlParameter("@Subject_Code", SqlDbType.NVarChar) {Value = subject.Subject_Code};
        param[3] = new SqlParameter("@Comments", SqlDbType.NVarChar) {Value = subject.Comments};
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int) {Direction = ParameterDirection.Output};
        dalobj.sqlcmdExecute("UpdateSubject", param);
        var k = (int)param[4].Value;
        return k;
    }

    internal DataTable GetAllSubjects(BllAssignSubjectToClass subject)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@statusId", SqlDbType.Int);
        param[0].Value = subject.Status_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SelectAllSubjects", param);
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
}