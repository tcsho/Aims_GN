using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

/// <summary>
/// Summary description for DllCaieStudentGradeRevision
/// </summary>
public class DllCaieStudentGradeRevision
{
    DALBase dalBase = new DALBase();

    internal DataTable GetStudentGrade(CaieStudentGradeRevision grade)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = grade.SessionId };
        param[1] = new SqlParameter("@Qual", SqlDbType.NVarChar) { Value = grade.GradeLevel };
        param[2] = new SqlParameter("@RollNumber", SqlDbType.Int) { Value = grade.RollNumber };
        DataTable _dt = new DataTable();
        try
        {
            dalBase.OpenConnection();
            _dt = dalBase.sqlcmdFetch("GetStudentResultForGradeRevision", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalBase.CloseConnection();
        }
    }

    internal void SaveComments(CaieStudentGradeRevision grade)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Comments", SqlDbType.NVarChar) { Value = grade.Comments };
        param[1] = new SqlParameter("@StudentId", SqlDbType.Int) { Value = grade.StudentId };
        param[2] = new SqlParameter("@ResultSeriesId", SqlDbType.Int) { Value = grade.SeriesId };
        param[3] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = grade.SessionId };
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalBase.sqlcmdExecute("AddCaieGradeRevisionComments", param);
        int k = (int)param[4].Value;
    }

    internal void UpdateComments(CaieStudentGradeRevision grade)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id", SqlDbType.Int) { Value = grade.Id };
            param[1] = new SqlParameter("@Comment", SqlDbType.NVarChar) { Value = grade.Comments };

            param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
            dalBase.sqlcmdExecute("UpdateCaieGradeRevisionComments", param);
            int k = (int)param[2].Value;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable BindComment(int rollNumbre, int seriesId, int sessionId)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@RollNumber", SqlDbType.Int) { Value = rollNumbre };
        param[1] = new SqlParameter("@SeriesId", SqlDbType.Int) { Value =seriesId };
        param[2] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = sessionId };
        DataTable _dt = new DataTable();
        try
        {
            dalBase.OpenConnection();
            _dt = dalBase.sqlcmdFetch("GetCaieGradeComment", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalBase.CloseConnection();
        }

    }

    internal int UpdateCaieStudentResultGrade(CaieStudentGradeRevision grade)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@UpId", SqlDbType.Int) { Value = grade.PuId };
        param[1] = new SqlParameter("@Result", SqlDbType.NVarChar) { Value = grade.Result };
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalBase.sqlcmdExecute("UpdateCaieStudentResultGrade", param);
        int k = (int)param[2].Value;
        return k;
    }

    public int GetLastAddedCommentId()
    {
        var param = new SqlParameter[0];
        try
        {
            dalBase.OpenConnection();
            var dt = dalBase.sqlcmdFetch("GetLastAddedCommentId", param);
            var row = dt.Rows[0];
            var id = Convert.ToInt32( row["Id"]);
            return id;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            dalBase.CloseConnection();
        }
    }
}