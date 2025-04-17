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
/// Summary description for _DALResult_Grade
/// </summary>
public class DALResult_Grade
{
    DALBase dalobj = new DALBase();


    public DALResult_Grade()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'

    public int Result_GradeAdd(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        //param[0] = new SqlParameter("@Result_Grade_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Result_Grade_Id;
        param[0] = new SqlParameter("@Grade", SqlDbType.NVarChar);
        param[0].Value = objbll.Grade;
        param[1] = new SqlParameter("@Upper_Limit", SqlDbType.Decimal);
        param[1].Value = objbll.Upper_Limit;
        param[2] = new SqlParameter("@Lower_Limit", SqlDbType.Decimal);
        param[2].Value = objbll.Lower_Limit;
        param[3] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organisation_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@KPI", SqlDbType.Decimal);
        param[5].Value = objbll.KPI;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;





        dalobj.sqlcmdExecute("Result_GradeInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
 public int TCS_Assign_Student_By_Update_Subject_Id(BLLResult_Grade _obj)

    {

        SqlParameter[] param = new SqlParameter[7];




        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);

        param[0].Value = _obj.Center_Id;




        param[1] = new SqlParameter("@Teacher_Id", SqlDbType.Int);

        param[1].Value = _obj.Session_Id;




        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);

        param[2].Value = _obj.Class_Id;




        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);

        param[3].Value = _obj.Section_Id;




        param[4] = new SqlParameter("@Student_Id", SqlDbType.Int);

        param[4].Value = _obj.Student_Id;




        param[5] = new SqlParameter("@User_Id", SqlDbType.Int);

        param[5].Value = _obj.User_Id;




        param[6] = new SqlParameter("@Status", SqlDbType.Int);

        param[6].Value = _obj.TermGroup_Id;




        int k = dalobj.sqlcmdExecuteTimeOutMin("TCS_Assign_Student_By_Update_Subject_Id", param, 2);

        return k;


    }
    public int Result_GradeUpdate(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Result_Grade_Id", SqlDbType.Int);
        param[0].Value = objbll.Result_Grade_Id;
        param[1] = new SqlParameter("@Grade", SqlDbType.NVarChar);
        param[1].Value = objbll.Grade;
        param[2] = new SqlParameter("@Upper_Limit", SqlDbType.Decimal);
        param[2].Value = objbll.Upper_Limit;
        param[3] = new SqlParameter("@Lower_Limit", SqlDbType.Decimal);
        param[3].Value = objbll.Lower_Limit;
        param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[4].Value = objbll.Main_Organisation_Id;
        param[5] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[5].Value = objbll.Class_Id;
        param[6] = new SqlParameter("@KPI", SqlDbType.Decimal);
        param[6].Value = objbll.KPI;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Result_GradeUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
public int TCS_Result_GenerateResultAllBySection_Id_New(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[3];         
	param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;         
	param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = _obj.Session_Id;         
	param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = _obj.TermGroup_Id;
        int k = dalobj.sqlcmdExecuteTimeOut2Min("TCS_Result_GenerateResultAllByCenter_Id", param);
        return k;
    }
    public int Result_GradeDelete(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Result_Grade_Id", SqlDbType.Int);
        param[0].Value = objbll.Result_Grade_Id;



        int k = dalobj.sqlcmdExecute("Result_GradeDelete", param);

        return k;
    }

    public int Result_GradeUnlockedSectionsBySection_Id(BLLResult_Grade objbll , bool flag)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;
        param[2] = new SqlParameter("@flag", SqlDbType.Bit);
        param[2].Value = flag;
        param[3] = new SqlParameter("@Section_Id", SqlDbType.VarChar);
        param[3].Value = objbll.lstSection_Id;
        param[4] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[4].Value = objbll.Evaluation_Type_Id;
        param[5] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[5].Value = objbll.User_Id;
        int k = dalobj.sqlcmdExecute("___AimsUnlockedSectionsBySection_Id", param);

        return k;
    }
    public int MarksLockUnlockCompileLog_Insert(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

         param[0] = new SqlParameter("@Flag", SqlDbType.Int);
        param[0].Value = 2;
        param[1] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[1].Value = objbll.User_Id;
    
        param[2] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[2].Value = objbll.Section_Id;
        
        int k = dalobj.sqlcmdExecute("MarksLockUnlockCompileLog_Insert", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'

    public DataTable _AimsMarkslockUnlock(BLLResult_Grade obj)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = obj.Session_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = obj.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("_AimsMarkslockUnlock", param);
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
    public DataTable Result_Grade_AimsResultCompileStatus(BLLResult_Grade obj)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = obj.Session_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = obj.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("_AimsResultCompileStatus", param);
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
    public DataTable Result_GradeSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectById", param);
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

    public DataTable Result_GradeSelect(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectAll", param);
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


    public DataTable StudentResultMarksViewbyStudentId(BLLResult_Grade objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[4].Value = objbll.TermGroup_Id;
        param[5] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[5].Value = objbll.Student_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentResultMarksViewbyStudentId", param);
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


    public DataTable Result_GradeSelectAllWithoutClassId(BLLResult_Grade objbll)
    {



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectAllWithoutClassId");
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


    public DataTable Result_GradeSelectByStatusID(BLLResult_Grade objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectByStatusID");
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
    public DataTable ClassFetchByCenterIDMarks(BLLResult_Grade objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassFetchByCenterIDMarks");
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



    public DataTable ClassByOrgId(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassByOrgId", param);
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


    public DataTable Result_GradeSelectAll(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@ClassId", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectAll", param);
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

    public int TCS_Result_GenerateResultAllByCenter_Id(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = _obj.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = _obj.TermGroup_Id;



        int k = dalobj.sqlcmdExecute("TCS_Result_GenerateResultAllByCenter_Id", param);
        return k;




    }
    public int TCS_Result_GenerateResultAllBySection_Id(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = _obj.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = _obj.TermGroup_Id;



        int k = dalobj.sqlcmdExecuteTimeOutMin("TCS_Result_SectionInformation", param,2);
        return k;




    }





    public DataTable Class_SelectByOrgId(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SelectByOrgId", param);
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



    public DataTable HO_ResultCompilationRegionalComparisonClassWise(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = _obj.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = _obj.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HO_ResultCompilationRegionalComparisonClassWise", param);
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

 public int TCS_Assign_Student_By_Subject_Id(BLLResult_Grade _obj)

    {
        SqlParameter[] param = new SqlParameter[6];



        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);

        param[0].Value = _obj.Center_Id;



        param[1] = new SqlParameter("@Teacher_Id", SqlDbType.Int);

        param[1].Value = _obj.Session_Id;




        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = _obj.Class_Id;




        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = _obj.Section_Id;




        param[4] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[4].Value = _obj.Student_Id;




        param[5] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[5].Value = _obj.User_Id;




        int k = dalobj.sqlcmdExecuteTimeOutMin("TCS_Assign_Student_By_Subject_Id", param, 2);
        return k;
    }
    public DataTable HO_PromotionalRegionalComparisonClassWise(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = _obj.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = _obj.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HO_PromotionalRegionalComparisonClassWise", param);
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





    public DataTable Result_GradeSelectAllByResultGradeId(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@ClassId", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        param[2] = new SqlParameter("@ResultGradeId", SqlDbType.Int);
        param[2].Value = _obj.Result_Grade_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectAllByResultGradeId", param);
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




    public DataTable Result_GradeSelectAllByGradeDescription(BLLResult_Grade _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@ClassId", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        param[2] = new SqlParameter("@Grade", SqlDbType.NVarChar);
        param[2].Value = _obj.Grade;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Result_GradeSelectAllByGradeDescription", param);
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
