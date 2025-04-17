using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStudent_Performance_Grading_Mst
/// </summary>
public class DALStudent_Performance_Grading_Mst
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_Grading_Mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_Grading_MstAdd(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[14];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@ClassTeacherComments", SqlDbType.NVarChar);
        param[2].Value = objbll.ClassTeacherComments;

        param[3] = new SqlParameter("@isPromoted", SqlDbType.Bit);
        param[3].Value = objbll.isPromoted;

        param[4] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[4].Value = objbll.Main_Organistion_Id;

        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[5].Value = objbll.Status_Id;

        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[6].Value = objbll.CreatedOn;

        param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[7].Value = objbll.CreatedBy;

        param[8] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[8].Value = objbll.Section_Id;

        param[9] = new SqlParameter("@Section_subject_Id", SqlDbType.Int);
        param[9].Value = objbll.Section_subject_Id;

        param[10] = new SqlParameter("@IslamyatComments", SqlDbType.NVarChar);
        param[10].Value = objbll.IslamyatComments;

        param[11] = new SqlParameter("@ICTRemarks", SqlDbType.NVarChar);
        param[11].Value = objbll.ICTRemarks;

        param[12] = new SqlParameter("@DaysAttend", SqlDbType.NVarChar);
        param[12].Value = objbll.DaysAttend;

        param[13] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[13].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_Grading_MstInsert", param);
        int k = (int)param[13].Value;
        return k;

    }
    public int Student_Performance_Grading_MstUpdate(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@KindSubStdMst_Id", SqlDbType.Int);
        param[0].Value = objbll.KindSubStdMst_Id;

        param[1] = new SqlParameter("@ClassTeacherComments", SqlDbType.NVarChar);
        param[1].Value = objbll.ClassTeacherComments;

        param[2] = new SqlParameter("@isPromoted", SqlDbType.Bit);
        param[2].Value = objbll.isPromoted;

        param[3] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[3].Value = objbll.ModifiedOn;

        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;

        param[5] = new SqlParameter("@IslamyatComments", SqlDbType.NVarChar);
        param[5].Value = objbll.IslamyatComments;

        param[6] = new SqlParameter("@ICTRemarks", SqlDbType.NVarChar);
        param[6].Value = objbll.ICTRemarks;

        param[7] = new SqlParameter("@DaysAttend", SqlDbType.NVarChar);
        param[7].Value = objbll.DaysAttend;

        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_Grading_MstUpdate", param);
        int k = (int)param[8].Value;
        return k;
    }
    public int Student_Performance_Grading_MstUpdateMarks(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@DatSet", SqlDbType.NVarChar);
        param[2].Value = objbll.DatSet;

        dalobj.sqlcmdExecute("_AimsClassAverageMarksUpdateMSt_Temp", param);
        int k = 0;
        return k;
    }

    public int Student_Performance_Grading_MstUpdateLetterOfUndertakingAcknowledge(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@KindSubStdMst_Id", SqlDbType.Int);
        param[0].Value = objbll.KindSubStdMst_Id;
        
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_Grading_MstUpdateLetterOfUndertakingAcknowledge", param);
        int k = (int)param[1].Value;
        return k;



    }


    
    public int Student_Performance_Grading_MstAddAttenDaysComments(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@ClassTeacherComments", SqlDbType.NVarChar);
        param[2].Value = objbll.ClassTeacherComments;
        
        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organistion_Id;

        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[4].Value = objbll.Status_Id;

        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;

        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;

        param[7] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[7].Value = objbll.Section_Id;

        param[8] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[8].Value = objbll.Session_Id;

        param[9] = new SqlParameter("@DaysAttend", SqlDbType.NVarChar);
        param[9].Value = objbll.DaysAttend;

        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_Grading_MstInsertUpdateAtt", param);
        int k = (int)param[10].Value;
        return k;

    }

    public int Student_Performance_Grading_MstAddAttenDaysCommentsNew(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@ClassTeacherComments", SqlDbType.NVarChar);
        param[2].Value = objbll.ClassTeacherComments;

        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organistion_Id;

        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[4].Value = objbll.Status_Id;

        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;

        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;

        param[7] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[7].Value = objbll.Section_Id;

        param[8] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[8].Value = objbll.Session_Id;

        param[9] = new SqlParameter("@DaysAttend", SqlDbType.NVarChar);
        param[9].Value = objbll.DaysAttend;

        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_Grading_MstInsertUpdateComm", param);
        int k = (int)param[10].Value;
        return k;

    }
    
    public int Student_Performance_Grading_MstUpdatePromotion_3_6(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class3_6", param);
        int k = 0;
        return k;
    }

    public int Student_Performance_Grading_MstUpdatePromotion_7(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class7", param);
        int k = 0;
        return k;
    }


    public int Student_Performance_Grading_MstUpdatePromotion_8(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class8", param);
        int k = 0;
        return k;
    }

    public int Student_Performance_Grading_MstUpdatePromotion_9(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class9", param);
        int k = 0;
        return k;
    }


    public int Student_Performance_Grading_MstUpdatePromotion_10(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class10", param);
        int k = 0;
        return k;
    }


    public int Student_Performance_Grading_MstUpdatePromotion_11(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_Class11", param);
        int k = 0;
        return k;
    }

    public int Student_Performance_Grading_MstUpdatePromotion_AS(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@EC_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        dalobj.sqlcmdExecute("_ClassPromotionStudentWise_MstUpdate_ClassAS", param);
        int k = 0;
        return k;
    }




    public int Student_Performance_Grading_MstDelete(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Performance_Grading_Mst_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Performance_Grading_Mst_Id;


        int k = dalobj.sqlcmdExecute("Student_Performance_Grading_MstDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_Grading_MstSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectById", param);
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
    
    public DataTable Student_Performance_Grading_MstSelect(BLLStudent_Performance_Grading_Mst objbll)
    {
    SqlParameter[] param = new SqlParameter[4];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
    param[0].Value = objbll.Evaluation_Criteria_Type_Id;

    param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
    param[1].Value = objbll.Section_Id;

    param[2] = new SqlParameter("@Student_Id", SqlDbType.Int);
    param[2].Value = objbll.Student_Id;

    param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
    param[3].Value = objbll.Session_Id;
        

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectAll", param);
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

    public DataTable Student_Performance_Grading_MstSelectAllClass(BLLStudent_Performance_Grading_Mst objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[2].Value = objbll.Grade_Id;

        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;

        param[4] = new SqlParameter("@DaysAttend", SqlDbType.Int);
        param[4].Value = objbll.DaysAttend;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectAllClass", param);
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

    public DataTable Student_Performance_Grading_MstSelectByStudent(BLLStudent_Performance_Grading_Mst objbll)
    {

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectDetail", param);
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


     public DataTable Student_Performance_Grading_MstLetterOfUndertakingAcknowledge(BLLStudent_Performance_Grading_Mst objbll)
     {

         SqlParameter[] param = new SqlParameter[3];

         param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
         param[0].Value = objbll.Session_Id;

         param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
         param[1].Value = objbll.TermGroup_Id;

         param[2] = new SqlParameter("@Employee_Id", SqlDbType.Int);
         param[2].Value = objbll.Employee_Id;

         DataTable _dt = new DataTable();

         try
         {
             dalobj.OpenConnection();
             _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstLetterOfUndertakingAcknowledge", param);
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


     public DataTable Student_Performance_Grading_MstLetterOfUndTkCheck(BLLStudent_Performance_Grading_Mst objbll)
     {

         SqlParameter[] param = new SqlParameter[3];

         param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
         param[0].Value = objbll.Session_Id;

         param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
         param[1].Value = objbll.Section_Id;

         param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
         param[2].Value = objbll.Evaluation_Criteria_Type_Id;

         DataTable _dt = new DataTable();

         try
         {
             dalobj.OpenConnection();
             _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectUndertaking", param);
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



     public DataTable Student_Performance_Grading_MstSelectByStudentSection(BLLStudent_Performance_Grading_Mst objbll)
     {

         SqlParameter[] param = new SqlParameter[4];

         param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
         param[0].Value = objbll.Student_Id;

         param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
         param[1].Value = objbll.Section_Id;

         param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
         param[2].Value = objbll.Evaluation_Criteria_Type_Id;

         param[3] = new SqlParameter("@Employee_Id", SqlDbType.Int);
         param[3].Value = objbll.Employee_Id;
         DataTable _dt = new DataTable();

         try
         {
             dalobj.OpenConnection();
             _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectDetailSection", param);
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
     public DataTable Student_Performance_Grading_MstSelectByStudentSectionNew(BLLStudent_Performance_Grading_Mst objbll)
     {

         SqlParameter[] param = new SqlParameter[4];

         param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
         param[0].Value = objbll.Student_Id;

         param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
         param[1].Value = objbll.Section_Id;

         param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
         param[2].Value = objbll.Evaluation_Criteria_Type_Id;

         param[3] = new SqlParameter("@Employee_Id", SqlDbType.Int);
         param[3].Value = objbll.Employee_Id;

         DataTable _dt = new DataTable();

         try
         {
             dalobj.OpenConnection();
             _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectDetailSectionNew", param);
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


     public DataTable Student_Performance_Grading_MstSelectByStatusID(BLLStudent_Performance_Grading_Mst objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_Grading_MstSelectByStatusID");
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
