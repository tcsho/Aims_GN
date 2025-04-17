using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSubject
/// </summary>
public class DALSiqa
{
    DALBase dalobj = new DALBase();


    public DALSiqa()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Group_Add(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Subject_Id;
        param[0] = new SqlParameter("@Group_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Group_Name;
        param[1] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[1].Value = objbll.Remarks;
        param[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
        param[2].Value = objbll.IsActive;
        param[3] = new SqlParameter("@CreateBy", SqlDbType.NVarChar);
        param[3].Value = objbll.CreateBy;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Group_Head_Insert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Add_classes(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[0].Value = objbll.Group_ID;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        dalobj.sqlcmdExecute("Class_Insert", param);
        //int k = (int)param[4].Value;
        return 0;

    }
    //public int SubjectUpdate(BLLSiqa objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[7];

    //    //param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
    //    //param[0].Value = objbll.Subject_Id;
    //    param[0] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
    //    param[0].Value = objbll.Subject_Name;
    //    param[1] = new SqlParameter("@Subject_Code", SqlDbType.Int);
    //    param[1].Value = objbll.Subject_Code;
    //    param[2] = new SqlParameter("@Status_Id", SqlDbType.NVarChar);
    //    param[2].Value = objbll.Status_Id;
    //    param[3] = new SqlParameter("@Comments", SqlDbType.Int);
    //    param[3].Value = objbll.Comments;
    //    param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
    //    param[4].Value = objbll.Main_Organisation_Id;
    //    param[5] = new SqlParameter("@isKPI", SqlDbType.NVarChar);
    //    param[5].Value = objbll.isKPI;
    //    param[6] = new SqlParameter("@SortOrder", SqlDbType.NVarChar);
    //    param[6].Value = objbll.SortOrder;



    //    param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //    param[7].Direction = ParameterDirection.Output;

    //    dalobj.sqlcmdExecute("SubjectUpdate", param);
    //    int k = (int)param[7].Value;
    //    return k;
    //}
    public int Group_Inactive(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[0].Value = objbll.U_Id;


        int k = dalobj.sqlcmdExecute("[Group_Inactive]", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    //public DataTable SubjectSelect(int _id)
    //{
    //SqlParameter[] param = new SqlParameter[3];

    //param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    //param[0].Value = _id;


    //DataTable _dt = new DataTable();

    //try
    //    {
    //    dalobj.OpenConnection();
    //    _dt = dalobj.sqlcmdFetch("SubjectSelectById", param);
    //    return _dt;
    //    }
    //catch (Exception _exception)
    //    {
    //    throw _exception;
    //    }
    //finally
    //    {
    //    dalobj.CloseConnection();
    //    }

    //return _dt;
    //}

    //public DataTable SubjectSelect(BLLSiqa objbll)
    //{
    //SqlParameter[] param = new SqlParameter[1];

    //param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
    //param[0].Value = objbll.Main_Organisation_Id;


    //DataTable _dt = new DataTable();

    //try
    //    {
    //    dalobj.OpenConnection();
    //    _dt = dalobj.sqlcmdFetch("SubjectSelectAll", param);
    //    return _dt;
    //    }
    //catch (Exception _exception)
    //    {
    //    throw _exception;
    //    }
    //finally
    //    {
    //    dalobj.CloseConnection();
    //    }

    //return _dt;

    //}


    public DataTable SubjectSelectAllWithSubNameGroup(BLLSiqa objbll)
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

    //public DataTable SubjectFetchByClassIDSeatPlan(BLLSiqa objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
    //    param[0].Value = objbll.Class_ID;


    //    DataTable _dt = new DataTable();

    //    try
    //    {
    //        dalobj.OpenConnection();
    //        _dt = dalobj.sqlcmdFetch("SubjectFetchByClassIDSeatPlan", param);
    //        return _dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }

    //    return _dt;

    //}

    //public DataTable SubjectFetchByClassID(BLLSiqa objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
    //    param[0].Value = objbll.Class_ID;


    //    DataTable _dt = new DataTable();

    //    try
    //    {
    //        dalobj.OpenConnection();
    //        _dt = dalobj.sqlcmdFetch("SubjectFetchByClassID", param);
    //        return _dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }

    //    return _dt;

    //}
    public DataTable SubjectSelectByStatusID(BLLSiqa objbll)
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




    #endregion

    //public DataTable SubjectFetchByClassIDSeatPlan_(BLLSiqa objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
    //    param[0].Value = objbll.Class_ID;


    //    DataTable _dt = new DataTable();

    //    try
    //    {
    //        dalobj.OpenConnection();
    //        _dt = dalobj.sqlcmdFetch("SubjectFetchByClassIDSeatPlan_", param);
    //        return _dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }

    //    return _dt;
    //}
    //public int AssignSubject(BLLSiqa objbll)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[4];

    //        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
    //        param[0].Value = objbll.Class_ID;
    //        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
    //        param[1].Value = objbll.Subject_Id;
    //        param[2] = new SqlParameter("@Region_id", SqlDbType.Int);
    //        param[2].Value = objbll.Region_id;
    //        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //        param[3].Direction = ParameterDirection.Output;

    //        dalobj.sqlcmdExecute("Class_SubjectAssign", param);
    //        int k = (int)param[2].Value;
    //        return k;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }


    //}
    public DataTable Get_All_GroupHeads()
    {
        //SqlParameter[] param = new SqlParameter[1];

        // param[0] = new SqlParameter("@MoId", SqlDbType.Int);
        //param[0].Value = id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Get_All_Universities", param);
            _dt = dalobj.sqlcmdFetch("Get_All_GroupHead");
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
    public int GroupNameAvailability(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Group_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Group_Name;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("GroupNameAvailibility", param);
        int k = (int)param[1].Value;
        return k;

    }
    //public int SubjectCodeAvailability(BLLSiqa objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[2];

    //    param[0] = new SqlParameter("@Subject_Code", SqlDbType.NVarChar);
    //    param[0].Value = objbll.Subject_Code;
    //    param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //    param[1].Direction = ParameterDirection.Output;

    //    dalobj.sqlcmdExecute("SubjectCodeAvailibility", param);
    //    int k = (int)param[1].Value;
    //    return k;

    //}


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



    public DataTable Get_Classes_By_Group_ID(int Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[0].Value = Group_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_Get_Classes_By_Group_ID", param);
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


    //**************************************************************
    public DataTable Evaluation_Criteria_TypeSelect()
    {


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectAll");
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

    public DataTable Get_Active_GroupHeads()
    {
        //SqlParameter[] param = new SqlParameter[1];

        // param[0] = new SqlParameter("@MoId", SqlDbType.Int);
        //param[0].Value = id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Get_All_Universities", param);
            _dt = dalobj.sqlcmdFetch("Get_list_of_GroupHead");
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

    public DataTable Get_Active_PerStandards()
    {
        //SqlParameter[] param = new SqlParameter[1];

        // param[0] = new SqlParameter("@MoId", SqlDbType.Int);
        //param[0].Value = id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Get_All_Universities", param);
            _dt = dalobj.sqlcmdFetch("Get_list_of_Performancestandards");
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



    public DataTable Get_Group_PS_Indicators(int Group_ID, int PS_ID)
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
            _dt = dalobj.sqlcmdFetch("Sp_Get_Group_PS_Indicators", param);
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
    public DataTable Get_Lovs_Against_Indicator_ID(int Indicator_ID, int Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@PSI_ID", SqlDbType.Int);
        param[0].Value = Indicator_ID;
        param[1] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[1].Value = Group_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_Get_Lovs_Against_Indicator_ID", param);
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


    public int Lo_Consolidation_Insert(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[55];

        //param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Subject_Id;
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Document_Date", SqlDbType.DateTime);
        param[3].Value = objbll.Document_Date;
        param[4] = new SqlParameter("@Teacher_Id", SqlDbType.Int);
        param[4].Value = objbll.Teacher_Id;
        param[5] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[5].Value = objbll.Class_Id;
        param[6] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[6].Value = objbll.Subject_Id;
        param[7] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[7].Value = objbll.Section_id;
        param[8] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[8].Value = objbll.Keystage_id;
        param[9] = new SqlParameter("@Format", SqlDbType.NVarChar);
        param[9].Value = objbll.Format;



        param[10] = new SqlParameter("@Obj_Outcoms", SqlDbType.NVarChar);
        param[10].Value = objbll.Obj_Outcoms;
        param[11] = new SqlParameter("@LP_Learning_Outcomes", SqlDbType.NVarChar);
        param[11].Value = objbll.LP_Learning_Outcomes;
        param[12] = new SqlParameter("@Cur_Adapted", SqlDbType.NVarChar);
        param[12].Value = objbll.Cur_Adapted;
        param[13] = new SqlParameter("@Cross_Curricular_Links", SqlDbType.NVarChar);
        param[13].Value = objbll.Cross_Curricular_Links;
        param[14] = new SqlParameter("@Lesson_Evaluation", SqlDbType.NVarChar);
        param[14].Value = objbll.Lesson_Evaluation;
        param[15] = new SqlParameter("@Lesson_Grade", SqlDbType.NVarChar);
        param[15].Value = objbll.Lesson_Grade;
        param[16] = new SqlParameter("@Subject_Knowledge", SqlDbType.NVarChar);
        param[16].Value = objbll.Subject_Knowledge;
        param[17] = new SqlParameter("@Clear_Lo", SqlDbType.NVarChar);
        param[17].Value = objbll.Clear_Lo;
        param[18] = new SqlParameter("@Teaching_Learning_Outcomes", SqlDbType.NVarChar);
        param[18].Value = objbll.Teaching_Learning_Outcomes;

        param[19] = new SqlParameter("@Need_Ability_Group", SqlDbType.NVarChar);
        param[19].Value = objbll.Need_Ability_Group;
        param[20] = new SqlParameter("@Collaboration", SqlDbType.NVarChar);
        param[20].Value = objbll.Collaboration;
        param[21] = new SqlParameter("@Hot_and_Reflection", SqlDbType.NVarChar);
        param[21].Value = objbll.Hot_and_Reflection;

        param[22] = new SqlParameter("@Clear_Instruction", SqlDbType.NVarChar);
        param[22].Value = objbll.Clear_Instruction;


        param[23] = new SqlParameter("@Tech_Cross_Curricular_Links", SqlDbType.NVarChar);
        param[23].Value = objbll.Tech_Cross_Curricular_Links;
        param[24] = new SqlParameter("@AFL", SqlDbType.NVarChar);
        param[24].Value = objbll.AFL;

        param[25] = new SqlParameter("@Peer_Address", SqlDbType.NVarChar);
        param[25].Value = objbll.Peer_Address;
        param[26] = new SqlParameter("@Suppor_Feedback", SqlDbType.NVarChar);
        param[26].Value = objbll.Suppor_Feedback;
        param[27] = new SqlParameter("@Time_Management", SqlDbType.NVarChar);
        param[27].Value = objbll.Time_Management;
        param[28] = new SqlParameter("@Learning_Env", SqlDbType.NVarChar);
        param[28].Value = objbll.Learning_Env;
        param[29] = new SqlParameter("@Teaching_Grade", SqlDbType.NVarChar);
        param[29].Value = objbll.Teaching_Grade;
        param[30] = new SqlParameter("@Interaction", SqlDbType.NVarChar);
        param[30].Value = objbll.Interaction;

        param[31] = new SqlParameter("@Make_Connection", SqlDbType.NVarChar);
        param[31].Value = objbll.Make_Connection;
        param[32] = new SqlParameter("@Actively_Engaged", SqlDbType.NVarChar);
        param[32].Value = objbll.Actively_Engaged;
        param[33] = new SqlParameter("@Collaborate", SqlDbType.NVarChar);
        param[33].Value = objbll.Collaborate;
        param[34] = new SqlParameter("@Reflect", SqlDbType.NVarChar);
        param[34].Value = objbll.Reflect;
        param[35] = new SqlParameter("@HOT", SqlDbType.NVarChar);
        param[35].Value = objbll.HOT;
        param[36] = new SqlParameter("@Communicate_Effectively", SqlDbType.NVarChar);
        param[36].Value = objbll.Communicate_Effectively;
        param[37] = new SqlParameter("@Student_Grade", SqlDbType.NVarChar);
        param[37].Value = objbll.Student_Grade;
        param[38] = new SqlParameter("@Self_Disciplined", SqlDbType.NVarChar);
        param[38].Value = objbll.Self_Disciplined;
        param[39] = new SqlParameter("@Positive_Relation_Student", SqlDbType.NVarChar);
        param[39].Value = objbll.Positive_Relation_Student;
        param[40] = new SqlParameter("@Positive_Relation_Adult", SqlDbType.NVarChar);
        param[40].Value = objbll.Positive_Relation_Adult;
        param[41] = new SqlParameter("@Attitude_Relationship_Grade", SqlDbType.NVarChar);
        param[41].Value = objbll.Attitude_Relationship_Grade;
        param[42] = new SqlParameter("@Care_Classroom_Positive_Relationship_Peers", SqlDbType.NVarChar);
        param[42].Value = objbll.Care_Classroom_Positive_Relationship_Peers;
        param[43] = new SqlParameter("@Care_Classroom_Relation_Adult", SqlDbType.NVarChar);
        param[43].Value = objbll.Care_Classroom_Relation_Adult;
        param[44] = new SqlParameter("@Settled_Well", SqlDbType.NVarChar);
        param[44].Value = objbll.Settled_Well;
        param[45] = new SqlParameter("@Caring_Sharing", SqlDbType.NVarChar);
        param[45].Value = objbll.Caring_Sharing;
        param[46] = new SqlParameter("@Listen_Follow_Instruction", SqlDbType.NVarChar);
        param[46].Value = objbll.Listen_Follow_Instruction;
        param[47] = new SqlParameter("@Teacher_Children_Needs", SqlDbType.NVarChar);
        param[47].Value = objbll.Teacher_Children_Needs;
        param[48] = new SqlParameter("@Care_Classroom_Grade", SqlDbType.NVarChar);
        param[48].Value = objbll.Care_Classroom_Grade;
        param[49] = new SqlParameter("@Student_Progress", SqlDbType.NVarChar);
        param[49].Value = objbll.Student_Progress;
        param[50] = new SqlParameter("@Overall_Lesson_Grade", SqlDbType.NVarChar);
        param[50].Value = objbll.Overall_Lesson_Grade;
        param[51] = new SqlParameter("@EBI1", SqlDbType.NVarChar);
        param[51].Value = objbll.EBI1;
        param[52] = new SqlParameter("@EBI2", SqlDbType.NVarChar);
        param[52].Value = objbll.EBI2;
        param[53] = new SqlParameter("@EBI3", SqlDbType.NVarChar);
        param[53].Value = objbll.EBI3;
        param[54] = new SqlParameter("@CreateBy", SqlDbType.NVarChar);
        param[54].Value = objbll.CreateBy;

        dalobj.sqlcmdExecute("[Lo_Consolidation_Insert]", param);
        //int k = (int)param[4].Value;
        return 1;

    }

    public int NB_Consolidation_Insert(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[40];
        
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Document_Date", SqlDbType.DateTime);
        param[3].Value = objbll.Document_Date;
        param[4] = new SqlParameter("@Teacher_Id", SqlDbType.Int);
        param[4].Value = objbll.Teacher_Id;
        param[5] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[5].Value = objbll.Class_Id;
        param[6] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[6].Value = objbll.Subject_Id;
        param[7] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[7].Value = objbll.Section_id;
        param[8] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[8].Value = objbll.Keystage_id;


        param[9] = new SqlParameter("@QOT_challenging_tasks", SqlDbType.NVarChar);
        param[9].Value = objbll.QOT_challenging_tasks;
        param[10] = new SqlParameter("@QOT_Variety_of_tasks", SqlDbType.NVarChar);
        param[10].Value = objbll.QOT_Variety_of_tasks;
        param[11] = new SqlParameter("@QOT_regular_independent_study", SqlDbType.NVarChar);
        param[11].Value = objbll.QOT_regular_independent_study;
        param[12] = new SqlParameter("@QOT_regularly_assigned", SqlDbType.NVarChar);
        param[12].Value = objbll.QOT_regularly_assigned;
        param[13] = new SqlParameter("@QOT_grade", SqlDbType.NVarChar);
        param[13].Value = objbll.QOT_grade;

        param[14] = new SqlParameter("@Assessment_work_checked_promptly", SqlDbType.NVarChar);
        param[14].Value = objbll.Assessment_work_checked_promptly;
        param[15] = new SqlParameter("@Assessment_errors_identified", SqlDbType.NVarChar);
        param[15].Value = objbll.Assessment_errors_identified;
        param[16] = new SqlParameter("@Assessment_dev_comments", SqlDbType.NVarChar);
        param[16].Value = objbll.Assessment_dev_comments;
        param[17] = new SqlParameter("@Assessment_assessment_criteria", SqlDbType.NVarChar);
        param[17].Value = objbll.Assessment_assessment_criteria;
        param[18] = new SqlParameter("@Assessment_apprec_remarks", SqlDbType.NVarChar);
        param[18].Value = objbll.Assessment_apprec_remarks;
        param[19] = new SqlParameter("@Assessment_self_peer_assessment", SqlDbType.NVarChar);
        param[19].Value = objbll.Assessment_self_peer_assessment;
        param[20] = new SqlParameter("@Assessment_follow_up", SqlDbType.NVarChar);
        param[20].Value = objbll.Assessment_follow_up;
        param[21] = new SqlParameter("@Assessment_grade", SqlDbType.NVarChar);
        param[21].Value = objbll.Assessment_grade;

        param[22] = new SqlParameter("@SP_impr_in_work", SqlDbType.NVarChar);
        param[22].Value = objbll.SP_impr_in_work;
        param[23] = new SqlParameter("@SP_responded_to_feedback", SqlDbType.NVarChar);
        param[23].Value = objbll.SP_responded_to_feedback;
        param[24] = new SqlParameter("@SP_suff_gains", SqlDbType.NVarChar);
        param[24].Value = objbll.SP_suff_gains;
        param[25] = new SqlParameter("@SP_age_appropriate_vocab", SqlDbType.NVarChar);
        param[25].Value = objbll.SP_age_appropriate_vocab;
        param[26] = new SqlParameter("@SP_independence", SqlDbType.NVarChar);
        param[26].Value = objbll.SP_independence;
        param[27] = new SqlParameter("@SP_grade", SqlDbType.NVarChar);
        param[27].Value = objbll.SP_grade;

        param[28] = new SqlParameter("@WP_organised", SqlDbType.NVarChar);
        param[28].Value = objbll.WP_organised;
        param[29] = new SqlParameter("@WP_neat", SqlDbType.NVarChar);
        param[29].Value = objbll.WP_neat;
        param[30] = new SqlParameter("@WP_legible_handwriting", SqlDbType.NVarChar);
        param[30].Value = objbll.WP_legible_handwriting;
        param[31] = new SqlParameter("@WP_indices_filled", SqlDbType.NVarChar);
        param[31].Value = objbll.WP_indices_filled;
        param[32] = new SqlParameter("@WP_indices_signed_teachers", SqlDbType.NVarChar);
        param[32].Value = objbll.WP_indices_signed_teachers;
        param[33] = new SqlParameter("@WP_indices_signed_parents", SqlDbType.NVarChar);
        param[33].Value = objbll.WP_indices_signed_parents;
        param[34] = new SqlParameter("@WP_grade", SqlDbType.NVarChar);
        param[34].Value = objbll.WP_grade;

        param[35] = new SqlParameter("@overall_grade", SqlDbType.NVarChar);
        param[35].Value = objbll.overall_grade;

        param[36] = new SqlParameter("@EBI1", SqlDbType.NVarChar);
        param[36].Value = objbll.EBI1;
        param[37] = new SqlParameter("@EBI2", SqlDbType.NVarChar);
        param[37].Value = objbll.EBI2;
        param[38] = new SqlParameter("@EBI3", SqlDbType.NVarChar);
        param[38].Value = objbll.EBI3;
        param[39] = new SqlParameter("@CreateBy", SqlDbType.NVarChar);
        param[39].Value = objbll.CreateBy;

        dalobj.sqlcmdExecute("[NB_Consolidation_Insert]", param);
        return 1;

    }

    public int Lo_Consolidation_Update(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[47];
        
        
        param[0] = new SqlParameter("@Format", SqlDbType.NVarChar);
        param[0].Value = objbll.Format;

        param[1] = new SqlParameter("@Obj_Outcoms", SqlDbType.NVarChar);
        param[1].Value = objbll.Obj_Outcoms;

        param[2] = new SqlParameter("@LP_Learning_Outcomes", SqlDbType.NVarChar);
        param[2].Value = objbll.LP_Learning_Outcomes;

        param[3] = new SqlParameter("@Cur_Adapted", SqlDbType.NVarChar);
        param[3].Value = objbll.Cur_Adapted;

        param[4] = new SqlParameter("@Cross_Curricular_Links", SqlDbType.NVarChar);
        param[4].Value = objbll.Cross_Curricular_Links;

        param[5] = new SqlParameter("@Lesson_Evaluation", SqlDbType.NVarChar);
        param[5].Value = objbll.Lesson_Evaluation;

        param[6] = new SqlParameter("@Lesson_Grade", SqlDbType.NVarChar);
        param[6].Value = objbll.Lesson_Grade;

        param[7] = new SqlParameter("@Subject_Knowledge", SqlDbType.NVarChar);
        param[7].Value = objbll.Subject_Knowledge;

        param[8] = new SqlParameter("@Clear_Lo", SqlDbType.NVarChar);
        param[8].Value = objbll.Clear_Lo;

        param[9] = new SqlParameter("@Teaching_Learning_Outcomes", SqlDbType.NVarChar);
        param[9].Value = objbll.Teaching_Learning_Outcomes;

        param[10] = new SqlParameter("@Need_Ability_Group", SqlDbType.NVarChar);
        param[10].Value = objbll.Need_Ability_Group;

        param[11] = new SqlParameter("@Collaboration", SqlDbType.NVarChar);
        param[11].Value = objbll.Collaboration;

        param[12] = new SqlParameter("@Hot_and_Reflection", SqlDbType.NVarChar);
        param[12].Value = objbll.Hot_and_Reflection;

        param[13] = new SqlParameter("@Clear_Instruction", SqlDbType.NVarChar);
        param[13].Value = objbll.Clear_Instruction;

        param[14] = new SqlParameter("@Tech_Cross_Curricular_Links", SqlDbType.NVarChar);
        param[14].Value = objbll.Tech_Cross_Curricular_Links;

        param[15] = new SqlParameter("@AFL", SqlDbType.NVarChar);
        param[15].Value = objbll.AFL;

        param[16] = new SqlParameter("@Peer_Address", SqlDbType.NVarChar);
        param[16].Value = objbll.Peer_Address;

        param[17] = new SqlParameter("@Suppor_Feedback", SqlDbType.NVarChar);
        param[17].Value = objbll.Suppor_Feedback;

        param[18] = new SqlParameter("@Time_Management", SqlDbType.NVarChar);
        param[18].Value = objbll.Time_Management;

        param[19] = new SqlParameter("@Teaching_Grade", SqlDbType.NVarChar);
        param[19].Value = objbll.Teaching_Grade;

        param[20] = new SqlParameter("@Interaction", SqlDbType.NVarChar);
        param[20].Value = objbll.Interaction;

        param[21] = new SqlParameter("@Make_Connection", SqlDbType.NVarChar);
        param[21].Value = objbll.Make_Connection;

        param[22] = new SqlParameter("@Actively_Engaged", SqlDbType.NVarChar);
        param[22].Value = objbll.Actively_Engaged;

        param[23] = new SqlParameter("@Collaborate", SqlDbType.NVarChar);
        param[23].Value = objbll.Collaborate;

        param[24] = new SqlParameter("@Reflect", SqlDbType.NVarChar);
        param[24].Value = objbll.Reflect;

        param[25] = new SqlParameter("@HOT", SqlDbType.NVarChar);
        param[25].Value = objbll.HOT;

        param[26] = new SqlParameter("@Communicate_Effectively", SqlDbType.NVarChar);
        param[26].Value = objbll.Communicate_Effectively;

        param[27] = new SqlParameter("@Student_Grade", SqlDbType.NVarChar);
        param[27].Value = objbll.Student_Grade;

        param[28] = new SqlParameter("@Self_Disciplined", SqlDbType.NVarChar);
        param[28].Value = objbll.Self_Disciplined;

        param[29] = new SqlParameter("@Positive_Relation_Student", SqlDbType.NVarChar);
        param[29].Value = objbll.Positive_Relation_Student;

        param[30] = new SqlParameter("@Positive_Relation_Adult", SqlDbType.NVarChar);
        param[30].Value = objbll.Positive_Relation_Adult;

        param[31] = new SqlParameter("@Attitude_Relationship_Grade", SqlDbType.NVarChar);
        param[31].Value = objbll.Attitude_Relationship_Grade;

        param[32] = new SqlParameter("@Care_Classroom_Positive_Relationship_Peers", SqlDbType.NVarChar);
        param[32].Value = objbll.Care_Classroom_Positive_Relationship_Peers;

        param[33] = new SqlParameter("@Care_Classroom_Relation_Adult", SqlDbType.NVarChar);
        param[33].Value = objbll.Care_Classroom_Relation_Adult;

        param[34] = new SqlParameter("@Settled_Well", SqlDbType.NVarChar);
        param[34].Value = objbll.Settled_Well;

        param[35] = new SqlParameter("@Caring_Sharing", SqlDbType.NVarChar);
        param[35].Value = objbll.Caring_Sharing;

        param[36] = new SqlParameter("@Listen_Follow_Instruction", SqlDbType.NVarChar);
        param[36].Value = objbll.Listen_Follow_Instruction;

        param[37] = new SqlParameter("@Teacher_Children_Needs", SqlDbType.NVarChar);
        param[37].Value = objbll.Teacher_Children_Needs;

        param[38] = new SqlParameter("@Care_Classroom_Grade", SqlDbType.NVarChar);
        param[38].Value = objbll.Care_Classroom_Grade;

        param[39] = new SqlParameter("@Student_Progress", SqlDbType.NVarChar);
        param[39].Value = objbll.Student_Progress;

        param[40] = new SqlParameter("@Overall_Lesson_Grade", SqlDbType.NVarChar);
        param[40].Value = objbll.Overall_Lesson_Grade;

        param[41] = new SqlParameter("@EBI1", SqlDbType.NVarChar);
        param[41].Value = objbll.EBI1;

        param[42] = new SqlParameter("@EBI2", SqlDbType.NVarChar);
        param[42].Value = objbll.EBI2;

        param[43] = new SqlParameter("@EBI3", SqlDbType.NVarChar);
        param[43].Value = objbll.EBI3;

        param[44] = new SqlParameter("@Siqa_Endorsed", SqlDbType.NVarChar);
        param[44].Value = objbll.Siqa_Endorsed;

        param[45] = new SqlParameter("@UpdateBy", SqlDbType.NVarChar);
        param[45].Value = objbll.UpdateBy;

        param[46] = new SqlParameter("@Consolidatio_Id", SqlDbType.Int);
        param[46].Value = objbll.Consolidatio_Id;

        dalobj.sqlcmdExecute("[Lo_Consolidation_Update]", param);

        return 1;
    }

    public int Lo_Consolidation_campus_head_operation(int consolidatio_id, bool chkbx_v, string updated_by) {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@consolidatio_id", SqlDbType.Int);
        param[0].Value = consolidatio_id;

        param[1] = new SqlParameter("@chkbx_v", SqlDbType.TinyInt);
        param[1].Value = chkbx_v;

        param[2] = new SqlParameter("@updated_by", SqlDbType.NVarChar);
        param[2].Value = updated_by;

        param[3] = new SqlParameter("@Res", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        try
        {
            dalobj.sqlcmdExecute("[Lo_Consolidation_Campus_Head_Update]", param);
            int k = (int)param[3].Value;
            return k;
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


    public DataTable Search_Lo_Consolidated(
        string Region_ID, 
        string Center_id, 
        string teacher_id, 
        string class_id, 
        string subject_id, 
        string Term_Group_id,
        string keystage
        )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Search_Lo_Consolidation]", param);
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


    //By Umer Nawab
    public DataTable Get_PS_Indicators(int Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[0].Value = Group_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_Get_PS_Indicators", param);
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



    //********************************************************PS1 Insertion**********************************************************************

    public int SEF_PS1_Insert(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Learning_Skill_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Learning_Skill_grade1;
        param[5] = new SqlParameter("@Learning_Skill_Judg_txt", SqlDbType.NVarChar);
        param[5].Value = objbll.Learning_Skill_Judg_txt;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[6].Value = objbll.CreateBy;
        param[7] = new SqlParameter("@LastInsertedId", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;
        int id=dalobj.sqlcmdExecute("[SEF_PS1_INSERT]", param);
        int k = (int)param[7].Value;
        //int k = (int)param[4].Value;
        return k;

    }

    public int PS1_Child_Fields_Insert(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@Ps1_Id_Fk", SqlDbType.Int);
        param[0].Value = objbll.Ps1_Id_Fk;
        param[1] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Subject_Name;
        param[2] = new SqlParameter("@Attainment_grade1", SqlDbType.NVarChar);
        param[2].Value = objbll.Attainment_grade1;
        param[3] = new SqlParameter("@Attainment_overall_grade", SqlDbType.NVarChar);
        param[3].Value = objbll.Attainment_overall_grade;
        param[4] = new SqlParameter("@Progress_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Progress_grade1;
        param[5] = new SqlParameter("@Progress_overall_grade", SqlDbType.NVarChar);
        param[5].Value = objbll.Progress_overall_grade;
        param[6] = new SqlParameter("@Attainment_grade2", SqlDbType.NVarChar);
        param[6].Value = objbll.Attainment_grade2;
        param[7] = new SqlParameter("@Progress_grade2", SqlDbType.NVarChar);
        param[7].Value = objbll.Progress_grade2;
        param[8] = new SqlParameter("@Attainment_grade3", SqlDbType.NVarChar);
        param[8].Value = objbll.Attainment_grade3;

        int id = dalobj.sqlcmdExecute("[PS1_Child_Fields_Insert]", param);
        //int k = (int)param[4].Value;
        return id;

    }


    public DataTable Find_PS1_Child(int ps1_id_fk)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = ps1_id_fk;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_Find_PS1_Child", param);
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

    public int PS1_Child_Delete(int ps1_id_fk)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = ps1_id_fk;
        

        int id = dalobj.sqlcmdExecute("[Sp_Delete_PS1_Child]", param);
        //int k = (int)param[4].Value;
        return 1;

    }

    //********************************************************PS2 Insertion**********************************************************************

    public DataTable SEF_PS2_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[30];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Personal_dev_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Personal_dev_grade1;
        param[5] = new SqlParameter("@Personal_dev_overall_grade", SqlDbType.NVarChar);
        param[5].Value = objbll.Personal_dev_overall_grade;
        param[6] = new SqlParameter("@Personal_dev_Lo_Form_chkbx1", SqlDbType.Bit);
        param[6].Value = objbll.Personal_dev_Lo_Form_chkbx1;
        param[7] = new SqlParameter("@Personal_dev_Dlws_chkbx1", SqlDbType.Bit);
        param[7].Value = objbll.Personal_dev_Dlws_chkbx1;
        param[8] = new SqlParameter("@Personal_dev_Incidentlog_chkbx1", SqlDbType.Bit);
        param[8].Value = objbll.Personal_dev_Incidentlog_chkbx1;
        param[9] = new SqlParameter("@Personal_dev_Surveyres_chkbx1", SqlDbType.Bit);
        param[9].Value = objbll.Personal_dev_Surveyres_chkbx1;
        param[10] = new SqlParameter("@Personal_dev_Uniformdeflog_chkbx1", SqlDbType.Bit);
        param[10].Value = objbll.Personal_dev_Uniformdeflog_chkbx1;
        param[11] = new SqlParameter("@Personal_dev_Explain_Judg_txt", SqlDbType.NVarChar);
        param[11].Value = objbll.Personal_dev_Explain_Judg_txt;
        param[12] = new SqlParameter("@Personal_dev_grade2", SqlDbType.NVarChar);
        param[12].Value = objbll.Personal_dev_grade2;
        param[13] = new SqlParameter("@Personal_dev_Dlws_chkbx2", SqlDbType.Bit);
        param[13].Value = objbll.Personal_dev_Dlws_chkbx2;
        param[14] = new SqlParameter("@Personal_dev_grade3", SqlDbType.NVarChar);
        param[14].Value = objbll.Personal_dev_grade3;
        param[15] = new SqlParameter("@Personal_dev_AttendanceReg_chkbx3", SqlDbType.Bit);
        param[15].Value = objbll.Personal_dev_AttendanceReg_chkbx3;
        param[16] = new SqlParameter("@Personal_dev_TardyLateArrival_chkbx3", SqlDbType.Bit);
        param[16].Value = objbll.Personal_dev_TardyLateArrival_chkbx3;
        param[17] = new SqlParameter("@Personal_dev_grade4", SqlDbType.NVarChar);
        param[17].Value = objbll.Personal_dev_grade4;
        param[18] = new SqlParameter("@Personal_dev_LoConsolidation_chkbx4", SqlDbType.Bit);
        param[18].Value = objbll.Personal_dev_LoConsolidation_chkbx4;
        param[19] = new SqlParameter("@Social_Values_grade1", SqlDbType.NVarChar);
        param[19].Value = objbll.Social_Values_grade1;
        param[20] = new SqlParameter("@Social_Values_Dlws_chkbx1", SqlDbType.Bit);
        param[20].Value = objbll.Social_Values_Dlws_chkbx1;
        param[21] = new SqlParameter("@Social_Values_Incidentlog_chkbx1", SqlDbType.Bit);
        param[21].Value = objbll.Social_Values_Incidentlog_chkbx1;
        param[22] = new SqlParameter("@Social_Values_SurveyResponses_chkbx1", SqlDbType.Bit);
        param[22].Value = objbll.Social_Values_SurveyResponses_chkbx1;
        param[23] = new SqlParameter("@Social_Values_ImpressionLo_chkbx1", SqlDbType.Bit);
        param[23].Value = objbll.Social_Values_ImpressionLo_chkbx1;
        param[24] = new SqlParameter("@Social_Values_Explain_Judg_txt", SqlDbType.NVarChar);
        param[24].Value = objbll.Social_Values_Explain_Judg_txt;
        param[25] = new SqlParameter("@Social_Responsibility_grade1", SqlDbType.NVarChar);
        param[25].Value = objbll.Social_Responsibility_grade1;
        param[26] = new SqlParameter("@Social_Responsibility_Dlws_chkbx1", SqlDbType.Bit);
        param[26].Value = objbll.Social_Responsibility_Dlws_chkbx1;
        param[27] = new SqlParameter("@Social_Responsibility_CoCurrricular_Act_chkbx1", SqlDbType.Bit);
        param[27].Value = objbll.Social_Responsibility_CoCurrricular_Act_chkbx1;
        param[28] = new SqlParameter("@Social_Responsibility_Explain_Judg_txt", SqlDbType.NVarChar);
        param[28].Value = objbll.Social_Responsibility_Explain_Judg_txt;
        param[29] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[29].Value = objbll.CreateBy;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS2_INSERT_UPDATE", param);
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

        //dalobj.sqlcmdExecute("[SEF_PS2_INSERT]", param);
        //dalobj.sqlcmdExecute("[SEF_PS2_INSERT_UPDATE]", param);
        //int k = (int)param[4].Value;
        //return 1;

    }



    //********************************************************PS3 Insertion**********************************************************************

    public DataTable SEF_PS3_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[17];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Teaching_Eff_Learning_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Teaching_Eff_Learning_grade1;
        param[5] = new SqlParameter("@Teaching_Eff_Learning_Judg_txt", SqlDbType.NVarChar);
        param[5].Value = objbll.Teaching_Eff_Learning_Judg_txt;
        param[6] = new SqlParameter("@Assessment_grade1", SqlDbType.NVarChar);
        param[6].Value = objbll.Assessment_grade1;
        param[7] = new SqlParameter("@Assessment_overall_grade", SqlDbType.NVarChar);
        param[7].Value = objbll.Assessment_overall_grade;
        param[8] = new SqlParameter("@Assessment_Progress_trckr_chkbx1", SqlDbType.Bit);
        param[8].Value = objbll.Assessment_Progress_trckr_chkbx1;
        param[9] = new SqlParameter("@Assessment_Ieps_chkbx1", SqlDbType.Bit);
        param[9].Value = objbll.Assessment_Ieps_chkbx1;
        param[10] = new SqlParameter("@Assessment_Assessment_Formt_chkbx1", SqlDbType.Bit);
        param[10].Value = objbll.Assessment_Assessment_Formt_chkbx1;
        param[11] = new SqlParameter("@Assessment_Aimsreport_chkbx1", SqlDbType.Bit);
        param[11].Value = objbll.Assessment_Aimsreport_chkbx1;
        param[12] = new SqlParameter("@Assessment_Judg_tx", SqlDbType.NVarChar);
        param[12].Value = objbll.Assessment_Judg_tx;
        param[13] = new SqlParameter("@Assessment_grade2", SqlDbType.NVarChar);
        param[13].Value = objbll.Assessment_grade2;
        param[14] = new SqlParameter("@Assessment_grade3", SqlDbType.NVarChar);
        param[14].Value = objbll.Assessment_grade3;
        param[15] = new SqlParameter("@Assessment_Nb_consolidation_chkbx3", SqlDbType.Bit);
        param[15].Value = objbll.Assessment_Nb_consolidation_chkbx3;
        param[16] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[16].Value = objbll.CreateBy;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS3_INSERT_UPDATE", param);
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


        //dalobj.sqlcmdExecute("[SEF_PS3_INSERT]", param);
        //dalobj.sqlcmdExecute("[SEF_PS3_INSERT_UPDATE]", param);
        //int k = (int)param[4].Value;
        //return 1;

    }

    //********************************************************PS4 Insertion**********************************************************************

    public DataTable SEF_PS4_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[23];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Curriculum_Imp_Cross_Curricular_grade_E123", SqlDbType.NVarChar);
        param[4].Value = objbll.Curriculum_Imp_Cross_Curricular_grade_E123;
        param[5] = new SqlParameter("@Curriculum_Imp_Judg_txt_E123", SqlDbType.NVarChar);
        param[5].Value = objbll.Curriculum_Imp_Judg_txt_E123;
        param[6] = new SqlParameter("@Curriculum_Imp_Curricular_Choices_grade", SqlDbType.NVarChar);
        param[6].Value = objbll.Curriculum_Imp_Curricular_Choices_grade;
        param[7] = new SqlParameter("@Curriculum_Imp_Overall_grade", SqlDbType.NVarChar);
        param[7].Value = objbll.Curriculum_Imp_Overall_grade;
        param[8] = new SqlParameter("@Curriculum_Imp_Judg_txt_K45", SqlDbType.NVarChar);
        param[8].Value = objbll.Curriculum_Imp_Judg_txt_K45;
        param[9] = new SqlParameter("@Curriculum_Imp_Cross_Curricular_grade_K45", SqlDbType.NVarChar);
        param[9].Value = objbll.Curriculum_Imp_Cross_Curricular_grade_K45;
        param[10] = new SqlParameter("@Curriculum_Adaptation_grade", SqlDbType.NVarChar);
        param[10].Value = objbll.Curriculum_Adaptation_grade;
        param[11] = new SqlParameter("@Curriculum_Adaptation_Overall_grade", SqlDbType.NVarChar);
        param[11].Value = objbll.Curriculum_Adaptation_Overall_grade;
        param[12] = new SqlParameter("@Curriculum_Adaptation_Lo_Consolidation_chkbx", SqlDbType.Bit);
        param[12].Value = objbll.Curriculum_Adaptation_Lo_Consolidation_chkbx;
        param[13] = new SqlParameter("@Curriculum_Adaptation_Nb_Consolidation_chkbx", SqlDbType.Bit);
        param[13].Value = objbll.Curriculum_Adaptation_Nb_Consolidation_chkbx;
        param[14] = new SqlParameter("@Curriculum_Adaptation_Co_And_Extra_Curricular_chkbx", SqlDbType.Bit);
        param[14].Value = objbll.Curriculum_Adaptation_Co_And_Extra_Curricular_chkbx;
        param[15] = new SqlParameter("@Curriculum_Adaptation_Club_And_Societies_chkbx", SqlDbType.Bit);
        param[15].Value = objbll.Curriculum_Adaptation_Club_And_Societies_chkbx;
        param[16] = new SqlParameter("@Curriculum_Adaptation_Event_Log_chkbx", SqlDbType.Bit);
        param[16].Value = objbll.Curriculum_Adaptation_Event_Log_chkbx;
        param[17] = new SqlParameter("@Curriculum_Adaptation_Morning_Assemblies_chkbx", SqlDbType.Bit);
        param[17].Value = objbll.Curriculum_Adaptation_Morning_Assemblies_chkbx;
        param[18] = new SqlParameter("@Curriculum_Adaptation_Activity_Calendar_chkbx", SqlDbType.Bit);
        param[18].Value = objbll.Curriculum_Adaptation_Activity_Calendar_chkbx;
        param[19] = new SqlParameter("@Curriculum_Adaptation_Judg_txt", SqlDbType.NVarChar);
        param[19].Value = objbll.Curriculum_Adaptation_Judg_txt;
        param[20] = new SqlParameter("@Curriculum_Adaptation_Enhancement_Enterprise_grade", SqlDbType.NVarChar);
        param[20].Value = objbll.Curriculum_Adaptation_Enhancement_Enterprise_grade;
        param[21] = new SqlParameter("@Curriculum_Adaptation_Link_Pakistani_grade", SqlDbType.NVarChar);
        param[21].Value = objbll.Curriculum_Adaptation_Link_Pakistani_grade;
        param[22] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[22].Value = objbll.CreateBy;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS4_INSERT_UPDATE", param);
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


        //dalobj.sqlcmdExecute("[SEF_PS4_INSERT]", param);
        //dalobj.sqlcmdExecute("[SEF_PS4_INSERT_UPDATE]", param);
        //int k = (int)param[4].Value;
        //return 1;

    }



    //********************************************************PS5 Insertion**********************************************************************

    public DataTable SEF_PS5_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[19];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Health_And_Safety_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Health_And_Safety_grade1;
        param[5] = new SqlParameter("@Health_And_Safety_overall_grade", SqlDbType.NVarChar);
        param[5].Value = objbll.Health_And_Safety_overall_grade;
        param[6] = new SqlParameter("@Health_And_Safety_Evidence_Source_txt", SqlDbType.NVarChar);
        param[6].Value = objbll.Health_And_Safety_Evidence_Source_txt;
        param[7] = new SqlParameter("@Health_And_Safety_Judg_txt", SqlDbType.NVarChar);
        param[7].Value = objbll.Health_And_Safety_Judg_txt;
        param[8] = new SqlParameter("@Health_And_Safety_grade2", SqlDbType.NVarChar);
        param[8].Value = objbll.Health_And_Safety_grade2;
        param[9] = new SqlParameter("@Health_And_Safety_grade3", SqlDbType.NVarChar);
        param[9].Value = objbll.Health_And_Safety_grade3;
        param[10] = new SqlParameter("@Health_And_Safety_grade4", SqlDbType.NVarChar);
        param[10].Value = objbll.Health_And_Safety_grade4;
        param[11] = new SqlParameter("@Care_And_Support_grade1", SqlDbType.NVarChar);
        param[11].Value = objbll.Care_And_Support_grade1;
        param[12] = new SqlParameter("@Care_And_Support_overall_grade", SqlDbType.NVarChar);
        param[12].Value = objbll.Care_And_Support_overall_grade;
        param[13] = new SqlParameter("@Care_And_Support_Evidence_Source_txt", SqlDbType.NVarChar);
        param[13].Value = objbll.Care_And_Support_Evidence_Source_txt;
        param[14] = new SqlParameter("@Care_And_Support_Judg_txt", SqlDbType.NVarChar);
        param[14].Value = objbll.Care_And_Support_Judg_txt;
        param[15] = new SqlParameter("@Care_And_Support_grade2", SqlDbType.NVarChar);
        param[15].Value = objbll.Care_And_Support_grade2;
        param[16] = new SqlParameter("@Care_And_Support_grade3", SqlDbType.NVarChar);
        param[16].Value = objbll.Care_And_Support_grade3;
        param[17] = new SqlParameter("@Care_And_Support_grade4", SqlDbType.NVarChar);
        param[17].Value = objbll.Care_And_Support_grade4;
        param[18] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[18].Value = objbll.CreateBy;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS5_INSERT_UPDATE", param);
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

        //dalobj.sqlcmdExecute("[SEF_PS5_INSERT]", param);
       // dalobj.sqlcmdExecute("[SEF_PS5_INSERT_UPDATE]", param);
        //int k = (int)param[4].Value;
       // return 1;

    }


    //********************************************************PS6 Insertion**********************************************************************

    public DataTable SEF_PS6_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[33];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.Int);
        param[2].Value = objbll.Group_ID;
        param[3] = new SqlParameter("@Ps_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.Ps_Name;
        param[4] = new SqlParameter("@Eff_of_Leadership_grade1", SqlDbType.NVarChar);
        param[4].Value = objbll.Eff_of_Leadership_grade1;
        param[5] = new SqlParameter("@Eff_of_Leadership_overall_grade", SqlDbType.NVarChar);
        param[5].Value = objbll.Eff_of_Leadership_overall_grade;
        param[6] = new SqlParameter("@Eff_of_Leadership_Evidence_Source_txt", SqlDbType.NVarChar);
        param[6].Value = objbll.Eff_of_Leadership_Evidence_Source_txt;
        param[7] = new SqlParameter("@Eff_of_Leadership_Judg_txt", SqlDbType.NVarChar);
        param[7].Value = objbll.Eff_of_Leadership_Judg_txt;
        param[8] = new SqlParameter("@Eff_of_Leadership_grade2", SqlDbType.NVarChar);
        param[8].Value = objbll.Eff_of_Leadership_grade2;
        param[9] = new SqlParameter("@Eff_of_Leadership_grade3", SqlDbType.NVarChar);
        param[9].Value = objbll.Eff_of_Leadership_grade3;
        param[10] = new SqlParameter("@Eff_of_Leadership_grade4", SqlDbType.NVarChar);
        param[10].Value = objbll.Eff_of_Leadership_grade4;
        param[11] = new SqlParameter("@Sef_Imp_Planning_grade1", SqlDbType.NVarChar);
        param[11].Value = objbll.Sef_Imp_Planning_grade1;
        param[12] = new SqlParameter("@Sef_Imp_Planning_overall_grade1", SqlDbType.NVarChar);
        param[12].Value = objbll.Sef_Imp_Planning_overall_grade1;
        param[13] = new SqlParameter("@Sef_Imp_Planning_Evidence_Source_txt", SqlDbType.NVarChar);
        param[13].Value = objbll.Sef_Imp_Planning_Evidence_Source_txt;
        param[14] = new SqlParameter("@Sef_Imp_Planning_Judg_txt", SqlDbType.NVarChar);
        param[14].Value = objbll.Sef_Imp_Planning_Judg_txt;
        param[15] = new SqlParameter("@Sef_Imp_Planning_overall_grade2", SqlDbType.NVarChar);
        param[15].Value = objbll.Sef_Imp_Planning_overall_grade2;
        param[16] = new SqlParameter("@Sef_Imp_Planning_overall_grade3", SqlDbType.NVarChar);
        param[16].Value = objbll.Sef_Imp_Planning_overall_grade3;
        param[17] = new SqlParameter("@Sef_Imp_Planning_overall_grade4", SqlDbType.NVarChar);
        param[17].Value = objbll.Sef_Imp_Planning_overall_grade4;
        param[18] = new SqlParameter("@Partnership_With_Parents_Comm_grade1", SqlDbType.NVarChar);
        param[18].Value = objbll.Partnership_With_Parents_Comm_grade1;
        param[19] = new SqlParameter("@Partnership_With_Parents_Comm_overall_grade", SqlDbType.NVarChar);
        param[19].Value = objbll.Partnership_With_Parents_Comm_overall_grade;
        param[20] = new SqlParameter("@Partnership_With_Parents_Comm_Evidence_Source_txt", SqlDbType.NVarChar);
        param[20].Value = objbll.Partnership_With_Parents_Comm_Evidence_Source_txt;
        param[21] = new SqlParameter("@Partnership_With_Parents_Comm_Judg_txt", SqlDbType.NVarChar);
        param[21].Value = objbll.Partnership_With_Parents_Comm_Judg_txt;
        param[22] = new SqlParameter("@Partnership_With_Parents_Comm_grade2", SqlDbType.NVarChar);
        param[22].Value = objbll.Partnership_With_Parents_Comm_grade2;
        param[23] = new SqlParameter("@Partnership_With_Parents_Comm_grade3", SqlDbType.NVarChar);
        param[23].Value = objbll.Partnership_With_Parents_Comm_grade3;
        param[24] = new SqlParameter("@Partnership_With_Parents_Comm_grade4", SqlDbType.NVarChar);
        param[24].Value = objbll.Partnership_With_Parents_Comm_grade4;
        param[25] = new SqlParameter("@Mgmt_Staff_Facilities_grade1", SqlDbType.NVarChar);
        param[25].Value = objbll.Mgmt_Staff_Facilities_grade1;
        param[26] = new SqlParameter("@Mgmt_Staff_Facilities_overall_grade", SqlDbType.NVarChar);
        param[26].Value = objbll.Mgmt_Staff_Facilities_overall_grade;
        param[27] = new SqlParameter("@Mgmt_Staff_Facilities_Evidence_Source_txt", SqlDbType.NVarChar);
        param[27].Value = objbll.Mgmt_Staff_Facilities_Evidence_Source_txt;
        param[28] = new SqlParameter("@Mgmt_Staff_Facilities_Judg_txt", SqlDbType.NVarChar);
        param[28].Value = objbll.Mgmt_Staff_Facilities_Judg_txt;
        param[29] = new SqlParameter("@Mgmt_Staff_Facilities_grade2", SqlDbType.NVarChar);
        param[29].Value = objbll.Mgmt_Staff_Facilities_grade2;
        param[30] = new SqlParameter("@Mgmt_Staff_Facilities_grade3", SqlDbType.NVarChar);
        param[30].Value = objbll.Mgmt_Staff_Facilities_grade3;
        param[31] = new SqlParameter("@Mgmt_Staff_Facilities_grade4", SqlDbType.NVarChar);
        param[31].Value = objbll.Mgmt_Staff_Facilities_grade4;
        param[32] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[32].Value = objbll.CreateBy;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS6_INSERT_UPDATE", param);
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


    //********************************************************Consolidation  Key Stage Wise Judgment Insertion**********************************************************************

    public DataTable SEF_Consolidation_KeyStageWise_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[11];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@EYFS", SqlDbType.NVarChar);
        param[2].Value = objbll.EYFS;
        param[3] = new SqlParameter("@KS1", SqlDbType.NVarChar);
        param[3].Value = objbll.KS1;
        param[4] = new SqlParameter("@KS2", SqlDbType.NVarChar);
        param[4].Value = objbll.KS2;
        param[5] = new SqlParameter("@KS3", SqlDbType.NVarChar);
        param[5].Value = objbll.KS3;
        param[6] = new SqlParameter("@KS4", SqlDbType.NVarChar);
        param[6].Value = objbll.KS4;
        param[7] = new SqlParameter("@KS5", SqlDbType.NVarChar);
        param[7].Value = objbll.KS5;
        param[8] = new SqlParameter("@Matric", SqlDbType.NVarChar);
        param[8].Value = objbll.Matric;
        param[9] = new SqlParameter("@OverallPerformance_Grade", SqlDbType.NVarChar);
        param[9].Value = objbll.OverallPerformance_Grade;
        param[10] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[10].Value = objbll.CreateBy;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_Consolidation_KS_Wise_INSERT", param);
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


    //********************************************************Consolidation  Key Stage Wise Judgment SIQA ENDROESD**********************************************************************

    public DataTable SEF_Consolidation_KeyStageWise_SiqaEndrosed(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[12];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@EYFS", SqlDbType.NVarChar);
        param[2].Value = objbll.EYFS;
        param[3] = new SqlParameter("@KS1", SqlDbType.NVarChar);
        param[3].Value = objbll.KS1;
        param[4] = new SqlParameter("@KS2", SqlDbType.NVarChar);
        param[4].Value = objbll.KS2;
        param[5] = new SqlParameter("@KS3", SqlDbType.NVarChar);
        param[5].Value = objbll.KS3;
        param[6] = new SqlParameter("@KS4", SqlDbType.NVarChar);
        param[6].Value = objbll.KS4;
        param[7] = new SqlParameter("@KS5", SqlDbType.NVarChar);
        param[7].Value = objbll.KS5;
        param[8] = new SqlParameter("@Matric", SqlDbType.NVarChar);
        param[8].Value = objbll.Matric;
        param[9] = new SqlParameter("@IsSIQAEndrosed", SqlDbType.Bit);
        param[9].Value = objbll.IsSIQAEndrosed;

        param[10] = new SqlParameter("@OverallPerformance_Grade", SqlDbType.NVarChar);
        param[10].Value = objbll.OverallPerformance_Grade;
        param[11] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[11].Value = objbll.CreateBy;
    

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_Consolidation_KS_Wise_SiqaEndored_Upd", param);
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

    //********************************************************Consolidation Overall JudgmentJudgment Insertion**********************************************************************

    public DataTable SEF_Consolidation_Overall_Insert(BLLSiqa objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@EYFS", SqlDbType.NVarChar);
        param[2].Value = objbll.overall_EYFS;
        param[3] = new SqlParameter("@KS1", SqlDbType.NVarChar);
        param[3].Value = objbll.overall_KS1;
        param[4] = new SqlParameter("@KS2", SqlDbType.NVarChar);
        param[4].Value = objbll.overall_KS2;
        param[5] = new SqlParameter("@KS3", SqlDbType.NVarChar);
        param[5].Value = objbll.overall_KS3;
        param[6] = new SqlParameter("@KS4", SqlDbType.NVarChar);
        param[6].Value = objbll.overall_KS4;
        param[7] = new SqlParameter("@KS5", SqlDbType.NVarChar);
        param[7].Value = objbll.overall_KS5;
        param[8] = new SqlParameter("@Matric", SqlDbType.NVarChar);
        param[8].Value = objbll.overall_Matric;
        param[9] = new SqlParameter("@CreatedBy", SqlDbType.NVarChar);
        param[9].Value = objbll.CreateBy;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_Consolidation_OverallPerformance_INSERT", param);
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



    //***************************************Fetching Data**********************************************************

    public DataTable SEF_PS1_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS1_GET_DATA", param);
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
    public DataTable SEF_PS1_CHILD_GET_DATA(string Region_Id, string Center_Id, string Group_ID,string Subject_Name)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;
        param[3] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[3].Value = Subject_Name;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS1_CHILD_GET_DATA", param);
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

    public DataTable SEF_PS1_CHILD_GET_DATA_FROM_FORMULA(string Region_Id, string Center_Id, string Group_ID,string @Subject_Name)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;
        param[3] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[3].Value = Subject_Name;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS1_CHILD_GET_DATA_FROM_FORMULA", param);
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

    public DataTable SEF_PS1_CHILD_GET_DATA_FROM_FORMULA_NB(string Region_Id, string Center_Id, string Group_ID, string @Subject_Name)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;
        param[3] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[3].Value = Subject_Name;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS1_CHILD_GET_DATA_FROM_FORMULA_NB", param);
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

    public DataTable SEF_PS2_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS2_GET_DATA", param);
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

    public DataTable SEF_PS3_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS3_GET_DATA", param);
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

    public DataTable SEF_PS4_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS4_GET_DATA", param);
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
    public DataTable SEF_PS5_GET_DATA(string Region_Id, string Center_Id,string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS5_GET_DATA", param);
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
    
     public DataTable SIQA_Grade_SEF_PS5_GET_DATA(string Center_Id,string Group_ID, string session_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        //param[0].Value = Region_Id;
        param[0] = new SqlParameter("@centerID", SqlDbType.NVarChar);
        param[0].Value = Center_Id;
        param[1] = new SqlParameter("@ks_type", SqlDbType.NVarChar);
        param[1].Value = Group_ID;
        param[2] = new SqlParameter("@session_id", SqlDbType.NVarChar);
        param[2].Value = session_ID;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Sp_SIQA_SEF_Evalution_PS5", param);
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

    public DataTable SIQA_SEF_Test_GET_DATA(string Center_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        //param[0].Value = Region_Id;
        param[0] = new SqlParameter("@centerID", SqlDbType.NVarChar);
        param[0].Value = Center_Id;
       

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("sef_SIQATEST_Con", param);
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
    public DataTable SEF_PS6_GET_DATA(string Region_Id,string Center_Id, string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id; 
        param[2] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[2].Value = Group_ID;
        
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS6_GET_DATA", param);
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



    //***************************************Fetching Formula Dropdowns Data**********************************************************
    public DataTable SEF_PS1_GET_FORMULA_DROPDOWN(string Region_Id, string Center_Id, string Keystage_id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_PS1_GET_FORMULA_DROPDOWN", param);
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

    public DataTable SEF_GET_FORMULA_DROPDOWN_FROM_NB(string Region_Id, string Center_Id, string Keystage_id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_GET_FORMULA_DROPDOWN_FROM_NB", param);
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
    //**********************************************************************************************************************

    public DataTable NB_Consolidation_Search(
    string Region_ID,
    string Center_id,
    string teacher_id,
    string class_id,
    string subject_id,
    string Term_Group_id,
    string keystage
    )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[NB_Consolidation_Search]", param);
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

    public int NB_Consolidation_Update(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[33];

        param[0] = new SqlParameter("@QOT_challenging_tasks", SqlDbType.NVarChar);
        param[0].Value = objbll.QOT_challenging_tasks;
        param[1] = new SqlParameter("@QOT_Variety_of_tasks", SqlDbType.NVarChar);
        param[1].Value = objbll.QOT_Variety_of_tasks;
        param[2] = new SqlParameter("@QOT_regular_independent_study", SqlDbType.NVarChar);
        param[2].Value = objbll.QOT_regular_independent_study;
        param[3] = new SqlParameter("@QOT_regularly_assigned", SqlDbType.NVarChar);
        param[3].Value = objbll.QOT_regularly_assigned;
        param[4] = new SqlParameter("@QOT_grade", SqlDbType.NVarChar);
        param[4].Value = objbll.QOT_grade;

        param[5] = new SqlParameter("@Assessment_work_checked_promptly", SqlDbType.NVarChar);
        param[5].Value = objbll.Assessment_work_checked_promptly;
        param[6] = new SqlParameter("@Assessment_errors_identified", SqlDbType.NVarChar);
        param[6].Value = objbll.Assessment_errors_identified;
        param[7] = new SqlParameter("@Assessment_dev_comments", SqlDbType.NVarChar);
        param[7].Value = objbll.Assessment_dev_comments;
        param[8] = new SqlParameter("@Assessment_assessment_criteria", SqlDbType.NVarChar);
        param[8].Value = objbll.Assessment_assessment_criteria;
        param[9] = new SqlParameter("@Assessment_apprec_remarks", SqlDbType.NVarChar);
        param[9].Value = objbll.Assessment_apprec_remarks;
        param[10] = new SqlParameter("@Assessment_self_peer_assessment", SqlDbType.NVarChar);
        param[10].Value = objbll.Assessment_self_peer_assessment;
        param[11] = new SqlParameter("@Assessment_follow_up", SqlDbType.NVarChar);
        param[11].Value = objbll.Assessment_follow_up;
        param[12] = new SqlParameter("@Assessment_grade", SqlDbType.NVarChar);
        param[12].Value = objbll.Assessment_grade;

        param[13] = new SqlParameter("@SP_impr_in_work", SqlDbType.NVarChar);
        param[13].Value = objbll.SP_impr_in_work;
        param[14] = new SqlParameter("@SP_responded_to_feedback", SqlDbType.NVarChar);
        param[14].Value = objbll.SP_responded_to_feedback;
        param[15] = new SqlParameter("@SP_suff_gains", SqlDbType.NVarChar);
        param[15].Value = objbll.SP_suff_gains;
        param[16] = new SqlParameter("@SP_age_appropriate_vocab", SqlDbType.NVarChar);
        param[16].Value = objbll.SP_age_appropriate_vocab;
        param[17] = new SqlParameter("@SP_independence", SqlDbType.NVarChar);
        param[17].Value = objbll.SP_independence;
        param[18] = new SqlParameter("@SP_grade", SqlDbType.NVarChar);
        param[18].Value = objbll.SP_grade;

        param[19] = new SqlParameter("@WP_organised", SqlDbType.NVarChar);
        param[19].Value = objbll.WP_organised;
        param[20] = new SqlParameter("@WP_neat", SqlDbType.NVarChar);
        param[20].Value = objbll.WP_neat;
        param[21] = new SqlParameter("@WP_legible_handwriting", SqlDbType.NVarChar);
        param[21].Value = objbll.WP_legible_handwriting;
        param[22] = new SqlParameter("@WP_indices_filled", SqlDbType.NVarChar);
        param[22].Value = objbll.WP_indices_filled;
        param[23] = new SqlParameter("@WP_indices_signed_teachers", SqlDbType.NVarChar);
        param[23].Value = objbll.WP_indices_signed_teachers;
        param[24] = new SqlParameter("@WP_indices_signed_parents", SqlDbType.NVarChar);
        param[24].Value = objbll.WP_indices_signed_parents;
        param[25] = new SqlParameter("@WP_grade", SqlDbType.NVarChar);
        param[25].Value = objbll.WP_grade;

        param[26] = new SqlParameter("@overall_grade", SqlDbType.NVarChar);
        param[26].Value = objbll.overall_grade;

        param[27] = new SqlParameter("@EBI1", SqlDbType.NVarChar);
        param[27].Value = objbll.EBI1;

        param[28] = new SqlParameter("@EBI2", SqlDbType.NVarChar);
        param[28].Value = objbll.EBI2;

        param[29] = new SqlParameter("@EBI3", SqlDbType.NVarChar);
        param[29].Value = objbll.EBI3;

        param[30] = new SqlParameter("@Siqa_Endorsed", SqlDbType.NVarChar);
        param[30].Value = objbll.Siqa_Endorsed;

        param[31] = new SqlParameter("@UpdateBy", SqlDbType.NVarChar);
        param[31].Value = objbll.UpdateBy;

        param[32] = new SqlParameter("@Consolidatio_Id", SqlDbType.Int);
        param[32].Value = objbll.Consolidatio_Id;

        dalobj.sqlcmdExecute("[NB_Consolidation_Update]", param);

        return 1;
    }


    public int NB_Consolidation_campus_head_operation(int consolidatio_id, bool chkbx_v, string updated_by)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@NB_Consolidation_Id", SqlDbType.Int);
        param[0].Value = consolidatio_id;

        param[1] = new SqlParameter("@chkbx_v", SqlDbType.TinyInt);
        param[1].Value = chkbx_v;

        param[2] = new SqlParameter("@updated_by", SqlDbType.NVarChar);
        param[2].Value = updated_by;

        param[3] = new SqlParameter("@Res", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        try
        {
            dalobj.sqlcmdExecute("[NB_Consolidation_Campus_Head_Update]", param);
            int k = (int)param[3].Value;
            return k;
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




    //*********************************************Execute Procedure for Formula Calculations****************************

    public DataTable Exec_SEF_Formulas (string Region_Id, string Center_Id, string Keystage_id,string Subject_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.NVarChar);
        param[3].Value = Subject_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SEF_Learning_Skills_Formula", param);
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


    public DataTable Exec_NB_Formulas(string Region_Id, string Center_Id, string Keystage_id,string Subject_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.NVarChar);
        param[3].Value = Subject_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("NB_Dropdown_Formula", param);
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



    public DataTable Get_Value_Basedon_Nbconsolidationid(int NB_Consolidation_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@NB_Consolidation_Id", SqlDbType.NVarChar);
        param[0].Value = NB_Consolidation_Id;
      

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_Value_Basedon_Nbconsolidationid", param);
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


    public DataTable Get_Value_Basedon_Loconsolidationid(int Consolidation_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Consolidatio_Id", SqlDbType.NVarChar);
        param[0].Value = Consolidation_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_Value_Basedon_Loconsolidationid", param);
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

    //***********************************2024-APRIL-8*********************
    public DataTable Get_Classes_Basedon_Keystage(string Group_ID)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Group_ID", SqlDbType.NVarChar);
        param[0].Value = Group_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_Classes_Basedon_Keystage", param);
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

    //****************************************LO CONSOLIDATION HISTORY CREATION*************************************************************


    public DataTable Lo_consolidation_History(string Region_Id, string Center_Id, string Keystage_id, string Subject_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.NVarChar);
        param[3].Value = Subject_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SP_LO_Consolidation_History", param);
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

    //By Hasan Azez 2024-04-19
    public DataTable Search_Lo_Consolidated_History(
       string Region_ID,
       string Center_id,
       string teacher_id,
       string class_id,
       string subject_id,
       string Term_Group_id,
       string keystage
       )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Search_Lo_Consolidation_History]", param);
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




    //*********************************************Nb CONSOLIDATION HISTORY CREATION*******************************************
    public DataTable Nb_consolidation_History(string Region_Id, string Center_Id, string Keystage_id, string Subject_Id)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.NVarChar);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = Center_Id;
        param[2] = new SqlParameter("@Keystage_id", SqlDbType.NVarChar);
        param[2].Value = Keystage_id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.NVarChar);
        param[3].Value = Subject_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SP_NB_Consolidation_History", param);
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



    public DataTable Search_Nb_Consolidated_History(
   string Region_ID,
   string Center_id,
   string teacher_id,
   string class_id,
   string subject_id,
   string Term_Group_id,
   string keystage
   )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Search_Nb_Consolidation_History]", param);
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

    public DataTable TeacherList_ProfileByCenterId_loConsolidation(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SIQA_Lo_Consolidation_TeacherList", param);
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

    public DataTable TeacherList_ProfileByCenterId_NBConsolidation(BLLSiqa objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SIQA_NB_Consolidation_TeacherList", param);
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



    public DataTable Search_Lo_Consolidated_Export(
       string Region_ID,
       string Center_id,
       string teacher_id,
       string class_id,
       string subject_id,
       string Term_Group_id,
       string keystage
       )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Search_Lo_Consolidation_Export]", param);
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




    public DataTable Siqa_Endorsed_Grades_Export(
      string Region_ID,
      string Center_id,
      string teacher_id,
      string class_id,
      string subject_id,
      string Term_Group_id,
      string keystage
      )
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Sp_Siqa_Endorsed_Grades_Export]", param);
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




    public DataTable NB_Consolidation_Export(
string Region_ID,
string Center_id,
string teacher_id,
string class_id,
string subject_id,
string Term_Group_id,
string keystage
)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[NB_Consolidation_Export]", param);
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


    public DataTable NB_Consolidation_Siqa_Endorsed_Export(
string Region_ID,
string Center_id,
string teacher_id,
string class_id,
string subject_id,
string Term_Group_id,
string keystage
)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Region_id", SqlDbType.NVarChar);
        param[0].Value = Region_ID;

        param[1] = new SqlParameter("@School_id", SqlDbType.NVarChar);
        param[1].Value = Center_id;

        param[2] = new SqlParameter("@teacher_id", SqlDbType.NVarChar);
        param[2].Value = teacher_id;

        param[3] = new SqlParameter("@class_id", SqlDbType.NVarChar);
        param[3].Value = class_id;

        param[4] = new SqlParameter("@Subject_id", SqlDbType.NVarChar);
        param[4].Value = subject_id;

        param[5] = new SqlParameter("@Term_Group_id", SqlDbType.NVarChar);
        param[5].Value = Term_Group_id;

        param[6] = new SqlParameter("@keystage", SqlDbType.NVarChar);
        param[6].Value = keystage;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[NB_Consolidation_Siqa_Endorsed_Export]", param);
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


}
