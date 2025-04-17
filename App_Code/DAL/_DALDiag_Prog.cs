using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALDiag_Prog
/// </summary>
public class DALDiag_Prog
{
    DALBase dalobj = new DALBase();


    public DALDiag_Prog()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Diag_ProgAdd(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int); 
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;
        
        param[3] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Section_Name;
        
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[4].Value = objbll.CreatedBy;
       
        param[5] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[5].Value = objbll.Evaluation_Criteria_Id;

        param[6] = new SqlParameter("@Unit_Id", SqlDbType.Int);
        param[6].Value = objbll.Unit_Id;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_ProgInsert", param);
        int k = (int)param[7].Value;
        return k;

    }

    public int Student_TermDaysAdd(BLLDiag_Prog objbll)
    {

        SqlParameter[] param = new SqlParameter[8];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;
        param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[2].Value = objbll.Student_Id;
        param[3] = new SqlParameter("@FirstTermDays", SqlDbType.Int);
        param[3].Value = objbll.FirstTermDays;
        param[4] = new SqlParameter("@FirstTermDaysCH", SqlDbType.NVarChar);
        param[4].Value = objbll.FirstTermDaysCH;
        param[5] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[5].Value = objbll.Section_Id;
        param[6] = new SqlParameter("@DaysAttend", SqlDbType.Int);
        param[6].Value = objbll.DaysAttend;
        //////////param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        //////////param[5].Value = objbll.CreatedOn;
        //////////param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //////////param[6].Value = objbll.CreatedBy;
        ////////////////param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        ////////////////param[7].Value = objbll.ModifiedOn;
        ////////////////param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        ////////////////param[8].Value = objbll.ModifiedBy;



        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_TermDaysInsert", param);
        int k = (int)param[7].Value;
        return k;

    }

    public int Student_TermDaysDelete(BLLDiag_Prog objbll)
    {

        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;
        param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[2].Value = objbll.Student_Id;
      
        param[3] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[3].Value = objbll.Section_Id;
    
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_TermDaysDelete", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Diag_ProgUpdate(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = objbll.DP_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[3].Value = objbll.Evaluation_Criteria_Type_Id;
        param[4] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[4].Value = objbll.Section_Name;
      
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[5].Value = objbll.ModifiedBy;

        param[6] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[6].Value = objbll.Evaluation_Criteria_Id;
      

        param[7] = new SqlParameter("@Unit_Id", SqlDbType.Int);
        param[7].Value = objbll.Unit_Id;

        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_ProgUpdate", param);
        int k = (int)param[8].Value;
        return k;
    }
    public int  Diag_Prog_DetailUpdateLockMarks(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        
        
        //param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //param[0].Value = objbll.Class_Id;
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_DetailUpdateLockMarks", param);
        int k = (int)param[1].Value;
        return k;
    }
    public int Diag_ProgDelete(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
       param[0].Value = objbll.DP_Id;


        int k = dalobj.sqlcmdExecute("Diag_ProgDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Diag_ProgSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Diag_ProgSelectById", param);
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
    public DataTable Diag_ProgSelectEvalCriteriaId(BLLDiag_Prog obj)
    {

        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = obj.Class_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = obj.Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = obj.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectEvalCriteriaId", param);
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
    public DataTable Diag_ProgSelectCenters(int region)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = region;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectCenters",param);
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
    public DataTable Diag_ProgSelect(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Diag_ProgSelectAll", param);
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


    public DataTable Diag_Prog_Question_TypeSelectAll(BLLDiag_Prog objbll)
    {
        //SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_Prog_Question_TypeSelectAll");
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
    public DataTable Diag_ProgSelectTopic(BLLDiag_Prog obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = obj.Class_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = obj.Subject_Id;
        param[2] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[2].Value = obj.Evaluation_Criteria_Type_Id;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectTopic", param);
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
    public DataTable Diag_ProgSelectAllByClassSubjectTermId(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;

        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;

    

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectAllByClassSubjectTermId", param);
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


    public DataTable Diag_ProgSelectAllByDPId(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = objbll.DP_Id;

        


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectAllByDPId", param);
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


    public DataTable Diag_ProgManageCenterWiseAccess(BLLDiag_Prog objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;

        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgManageCenterWiseAccess", param);
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




    public DataTable Diag_ProgSelectByStatusID(BLLDiag_Prog objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Diag_ProgSelectByStatusID");
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
