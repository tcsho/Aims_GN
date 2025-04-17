using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALClass
/// </summary>
public class DALGL
{
    DALBase dalobj = new DALBase();


    public DALGL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Fetch Methods'
    public DataTable GLSearch(int Center, int Region, int Grade, int Class)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center", SqlDbType.Int);
        if (Center == 0)
        { param[0].Value = null; }
        else
        { param[0].Value = Center; }

        param[1] = new SqlParameter("@Region", SqlDbType.Int);
        if (Region == 0)
        { param[1].Value = null; }
        else
        { param[1].Value = Region; }


        param[2] = new SqlParameter("@Grade", SqlDbType.Int);
        if (Grade == 0)
        { param[2].Value = null; }
        else
        { param[2].Value = Grade; }

        param[3] = new SqlParameter("@Session", SqlDbType.Int);
        if (Class == 0)
        { param[3].Value = null; }
        else
        { param[3].Value = Class; }


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchGLStudents", param);
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

    public DataTable GLSearch(string selectionCriteria, int Session_Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@SelectionCriteria", SqlDbType.NVarChar);
        param[0].Value = selectionCriteria;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchGLStudents", param);
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

    public DataTable GLResultSearch(string SelectionCriteria)//int Center, int Region, int Session,int Term, int Class,int Subject
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];//6

        param[0] = new SqlParameter("@SelectionCriteria", SqlDbType.VarChar);//@RegionID
        if (SelectionCriteria == "")//Region==0
        { param[0].Value = 0; }
        else
        { param[0].Value = SelectionCriteria; }//Region

        //param[1] = new SqlParameter("@SessionID", SqlDbType.Int);
        //if (Session == 0)
        //{ param[1].Value = 0; }
        //else
        //{ param[1].Value = Session; }

        //param[2] = new SqlParameter("@TermGroup", SqlDbType.Int);
        //if (Term == 0)
        //{ param[2].Value = 0; }
        //else
        //{ param[2].Value = Term; }

        //param[3] = new SqlParameter("@CenterID", SqlDbType.Int);
        //if (Center == 0)
        //{ param[3].Value = 0; }
        //else
        //{ param[3].Value = Center; }
        
        //param[4] = new SqlParameter("@ClassID", SqlDbType.Int);
        //if (Class == 0)
        //{ param[4].Value = 0; }
        //else
        //{ param[4].Value = Class; }

        //param[5] = new SqlParameter("@SubjectID", SqlDbType.Int);
        //if (Subject == 0)
        //{ param[5].Value = 0; }
        //else
        //{ param[5].Value = Subject; }


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchGLResults",param);
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
    public void GlResultAdd(BLLGLResult objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@TestName", SqlDbType.VarChar);
        param[1].Value = objbll.TestName;
        param[2] = new SqlParameter("@StandardAgeScore", SqlDbType.Int);
        param[2].Value = objbll.StandardAgeScore;
        param[3] = new SqlParameter("@OverallStanine", SqlDbType.Int);
        param[3].Value = objbll.OverallStanine;
        param[4] = new SqlParameter("@PercentileRank", SqlDbType.Int);
        param[4].Value = objbll.PercentileRank;
        param[5] = new SqlParameter("@SessionID", SqlDbType.Int);
        param[5].Value = objbll.SessionID;
        param[6] = new SqlParameter("@TermGroupID", SqlDbType.Int);
        param[6].Value = objbll.TermGroupID;

        dalobj.sqlcmdExecute("GLStudentTestResultInsert", param);

    }

    #endregion


}
