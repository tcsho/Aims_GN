using System;
using System.Data;


/// <summary>
/// Summary description for BLLSubject
/// </summary>



public class BLLSiqa
{
    public BLLSiqa()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALSiqa objdal = new DALSiqa();



    #region 'Start Properties Declaration'




    //**************************
    public int U_Id { get; set; }
    public string Uni_Name { get; set; }
    public int Status_Id { get; set; }
    public string Comments { get; set; }
    public bool _IsActive { get; set; }
    public string AddTag { get; set; }

    //*************************************
    public int Group_ID { get; set; }
    public string Group_Name { get; set; }
    public string Remarks { get; set; }
    public bool IsActive { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }

    public int Class_Id { get; set; }



    //*********************************
    public int Consolidatio_Id { get; set; }
    public int Session_id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public DateTime Document_Date { get; set; }
    public int Teacher_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Section_id { get; set; }
    public string Keystage_id { get; set; }
    public string Format { get; set; }
    public string Obj_Outcoms { get; set; }
    public string LP_Learning_Outcomes { get; set; }
    public string Cur_Adapted { get; set; }
    public string Cross_Curricular_Links { get; set; }
    public string Lesson_Evaluation { get; set; }
    public string Lesson_Grade { get; set; }
    public string Subject_Knowledge { get; set; }
    public string Clear_Lo { get; set; }
    public string Teaching_Learning_Outcomes { get; set; }
    public string Need_Ability_Group { get; set; }
    public string Collaboration { get; set; }
    public string Hot_and_Reflection { get; set; }
    public string Clear_Instruction { get; set; }
    public string Tech_Cross_Curricular_Links { get; set; }
    public string AFL { get; set; }
    public string Peer_Address { get; set; }
    public string Suppor_Feedback { get; set; }
    public string Time_Management { get; set; }
    public string Learning_Env { get; set; }
    public string Teaching_Grade { get; set; }
    public string Interaction { get; set; }
    public string Make_Connection { get; set; }
    public string Actively_Engaged { get; set; }
    public string Collaborate { get; set; }
    public string Reflect { get; set; }
    public string HOT { get; set; }
    public string Communicate_Effectively { get; set; }
    public string Student_Grade { get; set; }
    public string Self_Disciplined { get; set; }
    public string Positive_Relation_Student { get; set; }
    public string Positive_Relation_Adult { get; set; }
    public string Attitude_Relationship_Grade { get; set; }
    public string Care_Classroom_Positive_Relationship_Peers { get; set; }
    public string Care_Classroom_Relation_Adult { get; set; }
    public string Settled_Well { get; set; }
    public string Caring_Sharing { get; set; }
    public string Listen_Follow_Instruction { get; set; }
    public string Teacher_Children_Needs { get; set; }
    public string Care_Classroom_Grade { get; set; }
    public string Student_Progress { get; set; }
    public string Overall_Lesson_Grade { get; set; }
    public string EBI1 { get; set; }
    public string EBI2 { get; set; }
    public string EBI3 { get; set; }
    public string Siqa_Endorsed { get; set; }


    public string QOT_challenging_tasks { get; set; }
    public string QOT_Variety_of_tasks { get; set; }
    public string QOT_regular_independent_study { get; set; }
    public string QOT_regularly_assigned { get; set; }
    public string QOT_grade { get; set; }
    public string Assessment_work_checked_promptly { get; set; }
    public string Assessment_errors_identified { get; set; }
    public string Assessment_dev_comments { get; set; }
    public string Assessment_assessment_criteria { get; set; }
    public string Assessment_apprec_remarks { get; set; }
    public string Assessment_self_peer_assessment { get; set; }
    public string Assessment_follow_up { get; set; }
    public string Assessment_grade { get; set; }
    public string SP_impr_in_work { get; set; }
    public string SP_responded_to_feedback { get; set; }
    public string SP_suff_gains { get; set; }
    public string SP_age_appropriate_vocab { get; set; }
    public string SP_independence { get; set; }
    public string SP_grade { get; set; }
    public string WP_organised { get; set; }
    public string WP_neat { get; set; }
    public string WP_legible_handwriting { get; set; }
    public string WP_indices_filled { get; set; }
    public string WP_indices_signed_teachers { get; set; }
    public string WP_indices_signed_parents { get; set; }
    public string WP_grade { get; set; }
    public string overall_grade { get; set; }



    //**********************SEF PS1*************************
    public int Ps1_Id { get; set; }
    public string Learning_Skill_grade1 { get; set; }
    public string Learning_Skill_Judg_txt { get; set; }
    public string Subject_Name { get; set; }
    public string Attainment_grade1 { get; set; }
    public string Attainment_overall_grade { get; set; }
    public string Progress_grade1 { get; set; }
    public string Progress_overall_grade { get; set; }
    public string Attainment_grade2 { get; set; }
    public string Progress_grade2 { get; set; }
    public string Attainment_grade3 { get; set; }
    public int Ps1_Id_Fk { get; set; }




    //**********************SEF PS2*********************
    public int Ps2_Id { get; set; }
    public string Ps_Name { get; set; }
    public string Personal_dev_grade1 { get; set; }
    public string Personal_dev_overall_grade { get; set; }
    public bool Personal_dev_Lo_Form_chkbx1 { get; set; }
    public bool Personal_dev_Dlws_chkbx1 { get; set; }
    public bool Personal_dev_Incidentlog_chkbx1 { get; set; }
    public bool Personal_dev_Surveyres_chkbx1 { get; set; }
    public bool Personal_dev_Uniformdeflog_chkbx1 { get; set; }
    public string Personal_dev_Explain_Judg_txt { get; set; }
    public string Personal_dev_grade2 { get; set; }
    public bool Personal_dev_Dlws_chkbx2 { get; set; }
    public string Personal_dev_grade3 { get; set; }
    public bool Personal_dev_AttendanceReg_chkbx3 { get; set; }
    public bool Personal_dev_TardyLateArrival_chkbx3 { get; set; }
    public string Personal_dev_grade4 { get; set; }
    public bool Personal_dev_LoConsolidation_chkbx4 { get; set; }
    public string Social_Values_grade1 { get; set; }
    public bool Social_Values_Dlws_chkbx1 { get; set; }
    public bool Social_Values_Incidentlog_chkbx1 { get; set; }
    public bool Social_Values_SurveyResponses_chkbx1 { get; set; }
    public bool Social_Values_ImpressionLo_chkbx1 { get; set; }
    public string Social_Values_Explain_Judg_txt { get; set; }
    public string Social_Responsibility_grade1 { get; set; }
    public bool Social_Responsibility_Dlws_chkbx1 { get; set; }
    public bool Social_Responsibility_CoCurrricular_Act_chkbx1 { get; set; }
    public string Social_Responsibility_Explain_Judg_txt { get; set; }


    //**********************SEF PS2 END*********************

    //**********************SEF PS3*********************
    public int Ps3_Id { get; set; }
    
    public string Teaching_Eff_Learning_grade1 { get; set; }
    public string Teaching_Eff_Learning_Judg_txt { get; set; }
    public string Assessment_grade1 { get; set; }

    public string Assessment_overall_grade { get; set; }
    public bool Assessment_Progress_trckr_chkbx1 { get; set; }
    public bool Assessment_Ieps_chkbx1 { get; set; }

    public bool Assessment_Assessment_Formt_chkbx1 { get; set; }
    public bool Assessment_Aimsreport_chkbx1 { get; set; }
    public string Assessment_Judg_tx { get; set; }
    public string Assessment_grade2 { get; set; }
    public string Assessment_grade3 { get; set; }

    public bool Assessment_Nb_consolidation_chkbx3 { get; set; }


    //**********************SEF PS3 END*********************


    //**********************SEF PS4*************************
    public int Ps4_Id { get; set; }
    public string Curriculum_Imp_Cross_Curricular_grade_E123 { get; set; }
    public string Curriculum_Imp_Judg_txt_E123 { get; set; }
    public string Curriculum_Imp_Curricular_Choices_grade { get; set; }
    public string Curriculum_Imp_Overall_grade { get; set; }
    public string Curriculum_Imp_Judg_txt_K45 { get; set; }
    public string Curriculum_Imp_Cross_Curricular_grade_K45 { get; set; }
    public string Curriculum_Adaptation_grade { get; set; }
    public string Curriculum_Adaptation_Overall_grade { get; set; }
    public bool Curriculum_Adaptation_Lo_Consolidation_chkbx { get; set; }
    public bool Curriculum_Adaptation_Nb_Consolidation_chkbx { get; set; }
    public bool Curriculum_Adaptation_Co_And_Extra_Curricular_chkbx { get; set; }
    public bool Curriculum_Adaptation_Club_And_Societies_chkbx { get; set; }
    public bool Curriculum_Adaptation_Event_Log_chkbx { get; set; }
    public bool Curriculum_Adaptation_Morning_Assemblies_chkbx { get; set; }
    public bool Curriculum_Adaptation_Activity_Calendar_chkbx { get; set; }
    public string Curriculum_Adaptation_Judg_txt { get; set; }
    public string Curriculum_Adaptation_Enhancement_Enterprise_grade { get; set; }
    public string Curriculum_Adaptation_Link_Pakistani_grade { get; set; }


    //**********************SEF PS4 END*********************


    //**********************SEF PS5*************************
    public int Ps5_Id { get; set; }
    public string Health_And_Safety_grade1 { get; set; }
    public string Health_And_Safety_overall_grade { get; set; }
    public string Health_And_Safety_Evidence_Source_txt { get; set; }
    public string Health_And_Safety_Judg_txt { get; set; }
    public string Health_And_Safety_grade2 { get; set; }
    public string Health_And_Safety_grade3 { get; set; }
    public string Health_And_Safety_grade4 { get; set; }
    public string Care_And_Support_grade1 { get; set; }
    public string Care_And_Support_overall_grade { get; set; }
    public string Care_And_Support_Evidence_Source_txt { get; set; }
    public string Care_And_Support_Judg_txt { get; set; }
    public string Care_And_Support_grade2 { get; set; }
    public string Care_And_Support_grade3 { get; set; }
    public string Care_And_Support_grade4 { get; set; }



    //**********************SEF PS6*************************
    public int Ps6_Id { get; set; }
    public string Eff_of_Leadership_grade1 { get; set; }
    public string Eff_of_Leadership_overall_grade { get; set; }
    public string Eff_of_Leadership_Evidence_Source_txt { get; set; }
    public string Eff_of_Leadership_Judg_txt { get; set; }
    public string Eff_of_Leadership_grade2 { get; set; }
    public string Eff_of_Leadership_grade3 { get; set; }
    public string Eff_of_Leadership_grade4 { get; set; }
    public string Sef_Imp_Planning_grade1 { get; set; }
    public string Sef_Imp_Planning_overall_grade1 { get; set; }
    public string Sef_Imp_Planning_Evidence_Source_txt { get; set; }
    public string Sef_Imp_Planning_Judg_txt { get; set; }
    public string Sef_Imp_Planning_overall_grade2 { get; set; }
    public string Sef_Imp_Planning_overall_grade3 { get; set; }
    public string Sef_Imp_Planning_overall_grade4 { get; set; }
    public string Partnership_With_Parents_Comm_grade1 { get; set; }
    public string Partnership_With_Parents_Comm_overall_grade { get; set; }
    public string Partnership_With_Parents_Comm_Evidence_Source_txt { get; set; }
    public string Partnership_With_Parents_Comm_Judg_txt { get; set; }
    public string Partnership_With_Parents_Comm_grade2 { get; set; }
    public string Partnership_With_Parents_Comm_grade3 { get; set; }
    public string Partnership_With_Parents_Comm_grade4 { get; set; }
    public string Mgmt_Staff_Facilities_grade1 { get; set; }
    public string Mgmt_Staff_Facilities_overall_grade { get; set; }
    public string Mgmt_Staff_Facilities_Evidence_Source_txt { get; set; }
    public string Mgmt_Staff_Facilities_Judg_txt { get; set; }
    public string Mgmt_Staff_Facilities_grade2 { get; set; }
    public string Mgmt_Staff_Facilities_grade3 { get; set; }
    public string Mgmt_Staff_Facilities_grade4 { get; set; }





    //**********************SEF Consolidation Keystage Wise*************************
    public int Cons_KS_Id { get; set; }
    public string EYFS { get; set; }
    public string KS1 { get; set; }
    public string KS2 { get; set; }
    public string KS3 { get; set; }
    public string KS4 { get; set; }
    public string KS5 { get; set; }
    public string Matric { get; set; }
    public string OverallPerformance_Grade { get; set; }
    public bool IsSIQAEndrosed { get; set; }

    //**********************SEF Consolidation overall Wise*************************
    public int Cons_overall_Id { get; set; }
    public string overall_EYFS { get; set; }
    public string overall_KS1 { get; set; }
    public string overall_KS2 { get; set; }
    public string overall_KS3 { get; set; }
    public string overall_KS4 { get; set; }
    public string overall_KS5 { get; set; }
    public string overall_Matric { get; set; }











    #endregion

    #region 'Start Executaion Methods'

    public int Group_Add(BLLSiqa _obj)
    {
        return objdal.Group_Add(_obj);
    }

    public int Add_classes(BLLSiqa _obj)
    {
        return objdal.Add_classes(_obj);
    }

    public int Group_Inactive(BLLSiqa _obj)
    {
        return objdal.Group_Inactive(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'




    public DataTable SubjectSelectAllWithSubNameGroup(BLLSiqa _obj)
    {
        return objdal.SubjectSelectAllWithSubNameGroup(_obj);
    }


    public DataTable SubjectFetchByStatusID(BLLSiqa _obj)
    {
        return objdal.SubjectSelectByStatusID(_obj);
    }




    #endregion


    public DataTable Get_All_GroupHeads()
    {
        return objdal.Get_All_GroupHeads();
    }
    public int GroupNameAvailability(BLLSiqa _obj)
    {
        return objdal.GroupNameAvailability(_obj);
    }

    public DataTable GetClasses()
    {
        return objdal.GetClasses();
    }

    public DataTable Get_Classes_By_Group_ID(int Group_ID)
    {
        return objdal.Get_Classes_By_Group_ID(Group_ID);
    }

    //*********************************************************************
    public DataTable Evaluation_Criteria_TypeFetch()
    {
        return objdal.Evaluation_Criteria_TypeSelect();
    }

    public DataTable Get_Active_GroupHeads()
    {
        return objdal.Get_Active_GroupHeads();
    }
    public DataTable Get_Active_PerStandards()
    {
        return objdal.Get_Active_PerStandards();
    }


    public DataTable Get_Group_PS_Indicators(int Group_ID, int PS_ID)
    {
        return objdal.Get_Group_PS_Indicators(Group_ID, PS_ID);
    }

    public DataTable Get_Lovs_Against_Indicator_ID(int Indicator_ID, int Group_ID)
    {
        return objdal.Get_Lovs_Against_Indicator_ID(Indicator_ID, Group_ID);
    }


    public DataTable Get_Indicators(int Group_ID, int PS_ID)
    {
        return objdal.Get_Indicators(Group_ID, PS_ID);
    }

    public DataTable Get_Sections(int Center_ID, int Class_ID)
    {
        return objdal.Get_Sections(Center_ID, Class_ID);
    }

    public int Lo_Consolidation_Insert(BLLSiqa _obj)
    {
        return objdal.Lo_Consolidation_Insert(_obj);
    }

    public int NB_Consolidation_Insert(BLLSiqa _obj)
    {
        return objdal.NB_Consolidation_Insert(_obj);
    }

    public int Lo_Consolidation_Update(BLLSiqa _obj)
    {
        return objdal.Lo_Consolidation_Update(_obj);
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
        return objdal.Search_Lo_Consolidated(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
    }

    public int Lo_Consolidation_campus_head_operation(int consolidatio_id, bool chkbx_v, string updated_by) {
        return objdal.Lo_Consolidation_campus_head_operation(consolidatio_id, chkbx_v, updated_by);
    }


    //Umer Nawab created these methods
    public DataTable Get_PS_Indicators(int Group_ID)
    {
        return objdal.Get_PS_Indicators(Group_ID);
    }



    //***********************************************PS1 Insertion*******************************************************************

    public int SEF_PS1_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS1_Insert(_obj);
    }

    public int PS1_Child_Fields_Insert(BLLSiqa _obj)
    {
        return objdal.PS1_Child_Fields_Insert(_obj);
    }

    public DataTable Find_PS1_Child(int Group_ID)
    {
        return objdal.Find_PS1_Child(Group_ID);
    }

    public int PS1_Child_Delete(int ps1_id_fk)
    {
        return objdal.PS1_Child_Delete(ps1_id_fk);
    }


    //***********************************************PS2 Insertion*******************************************************************

    public DataTable SEF_PS2_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS2_Insert(_obj);
    }


    //***********************************************PS3 Insertion*******************************************************************

    public DataTable SEF_PS3_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS3_Insert(_obj);
    }


    //***********************************************PS4 Insertion*******************************************************************
    public DataTable SEF_PS4_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS4_Insert(_obj);
    }

    //***********************************************PS5 Insertion*******************************************************************
    public DataTable SEF_PS5_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS5_Insert(_obj);
    }

    //***********************************************PS6 Insertion*******************************************************************
    public DataTable SEF_PS6_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_PS6_Insert(_obj);
    }

    //***********************************************Consolidations KeyStage Wise Insertion*******************************************************************
    public DataTable SEF_Consolidation_KeyStageWise_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_Consolidation_KeyStageWise_Insert(_obj);
    }

    //***********************************************Consolidations KeyStage Wise SIQA ENDROSED Update*******************************************************************
    public DataTable SEF_Consolidation_KeyStageWise_SiqaEndrosed(BLLSiqa _obj)
    {
        return objdal.SEF_Consolidation_KeyStageWise_SiqaEndrosed(_obj);
    }

    //***********************************************Consolidations Overall Judgment Insertion*******************************************************************
    public DataTable SEF_Consolidation_Overall_Insert(BLLSiqa _obj)
    {
        return objdal.SEF_Consolidation_Overall_Insert(_obj);
    }

    //******************************fetching data***********************************************************************

    public DataTable SEF_PS1_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS1_GET_DATA(Region_Id, Center_Id, Group_ID);
    }
    public DataTable SEF_PS1_CHILD_GET_DATA(string Region_Id, string Center_Id, string Group_ID, string Subject_Name)
    {
        return objdal.SEF_PS1_CHILD_GET_DATA(Region_Id, Center_Id, Group_ID, Subject_Name);
    }

    public DataTable SEF_PS1_CHILD_GET_DATA_FROM_FORMULA(string Region_Id, string Center_Id, string Group_ID, string Subject_Name)
    {
        return objdal.SEF_PS1_CHILD_GET_DATA_FROM_FORMULA(Region_Id, Center_Id, Group_ID, Subject_Name);
    }
    public DataTable SEF_PS1_CHILD_GET_DATA_FROM_FORMULA_NB(string Region_Id, string Center_Id, string Group_ID, string Subject_Name)
    {
        return objdal.SEF_PS1_CHILD_GET_DATA_FROM_FORMULA_NB(Region_Id, Center_Id, Group_ID, Subject_Name);
    }
    public DataTable SEF_PS2_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS2_GET_DATA(Region_Id, Center_Id, Group_ID);
    }

    public DataTable SEF_PS3_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS3_GET_DATA(Region_Id, Center_Id, Group_ID);
    }

    public DataTable SEF_PS4_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS4_GET_DATA(Region_Id, Center_Id, Group_ID);
    }

    public DataTable SEF_PS5_GET_DATA(string Region_Id, string Center_Id,string Group_ID)
    {
        return objdal.SEF_PS5_GET_DATA(Region_Id, Center_Id, Group_ID);
    }

    public DataTable SIQA_Grade_SEF_PS5_GET_DATA( string Center_Id, string Group_ID, string session_ID)
    {
        return objdal.SIQA_Grade_SEF_PS5_GET_DATA(Center_Id, Group_ID, session_ID);
    }
    public DataTable SIQA_SEF_Test_GET_DATA(string Center_Id)
    {
        return objdal.SIQA_SEF_Test_GET_DATA(Center_Id);
    }

    public DataTable SEF_PS6_GET_DATA(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS6_GET_DATA(Region_Id, Center_Id, Group_ID);
    }


    //******************************Fetching Formula Dropdowns Data***********************************************************************

    public DataTable SEF_PS1_GET_FORMULA_DROPDOWN(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_PS1_GET_FORMULA_DROPDOWN(Region_Id, Center_Id, Group_ID);
    }

    public DataTable SEF_GET_FORMULA_DROPDOWN_FROM_NB(string Region_Id, string Center_Id, string Group_ID)
    {
        return objdal.SEF_GET_FORMULA_DROPDOWN_FROM_NB(Region_Id, Center_Id, Group_ID);
    }




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
        return objdal.NB_Consolidation_Search(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
    }
    public int NB_Consolidation_Update(BLLSiqa _obj)
    {
        return objdal.NB_Consolidation_Update(_obj);
    }

    public int NB_Consolidation_campus_head_operation(int consolidatio_id, bool chkbx_v, string updated_by)
    {
        return objdal.NB_Consolidation_campus_head_operation(consolidatio_id, chkbx_v, updated_by);
    }



    //******************************Execute Procedure for Formula Calculations***********************************************************************

    public DataTable Exec_SEF_Formulas(string Region_Id, string Center_Id, string Group_ID,string Subject_Id)
    {
        return objdal.Exec_SEF_Formulas(Region_Id, Center_Id, Group_ID, Subject_Id);
    }

    public DataTable Exec_NB_Formulas(string Region_Id, string Center_Id, string Group_ID,string Subject_Id)
    {
        return objdal.Exec_NB_Formulas(Region_Id, Center_Id, Group_ID, Subject_Id);
    }



    public DataTable Get_Value_Basedon_Nbconsolidationid(int NB_Consolidation_Id)
    {
        return objdal.Get_Value_Basedon_Nbconsolidationid(NB_Consolidation_Id);
    }
    public DataTable Get_Value_Basedon_Loconsolidationid(int Consolidation_Id)
    {
        return objdal.Get_Value_Basedon_Loconsolidationid(Consolidation_Id);
    }


    public DataTable Get_Classes_Basedon_Keystage(string Group_ID)
    {
        return objdal.Get_Classes_Basedon_Keystage(Group_ID);
    }


    //****************************************LO CONSOLIDATION HISTORY CREATION*************************************************************
    public DataTable Lo_consolidation_History(string Region_Id, string Center_Id, string Group_ID, string Subject_Id)
    {
        return objdal.Lo_consolidation_History(Region_Id, Center_Id, Group_ID, Subject_Id);
    }

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
        return objdal.Search_Lo_Consolidated_History(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
    }


    public DataTable Nb_consolidation_History(string Region_Id, string Center_Id, string Group_ID, string Subject_Id)
    {
        return objdal.Nb_consolidation_History(Region_Id, Center_Id, Group_ID, Subject_Id);
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
        return objdal.Search_Nb_Consolidated_History(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
    }




    public DataTable TeacherList_ProfileByCenterId_loConsolidation(BLLSiqa _obj)
    {
        return objdal.TeacherList_ProfileByCenterId_loConsolidation(_obj);
    }
    public DataTable TeacherList_ProfileByCenterId_NBConsolidation(BLLSiqa _obj)
    {
        return objdal.TeacherList_ProfileByCenterId_NBConsolidation(_obj);
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
        return objdal.Search_Lo_Consolidated_Export(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
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
        return objdal.Siqa_Endorsed_Grades_Export(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
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
        return objdal.NB_Consolidation_Export(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
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
        return objdal.NB_Consolidation_Siqa_Endorsed_Export(Region_ID, Center_id, teacher_id, class_id, subject_id, Term_Group_id, keystage);
    }

}



