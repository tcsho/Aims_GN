using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Reflection;
using City.Library.SQL;

public partial class PresentationLayer_TCS_IEP_Form : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    public DataSet exec_SP(string action, string Optional1 = null, string Optional2 = null,
        string json_intrest_code = null, string json_Subject_detal = null, string json_ExtraCurricularActivities = null, string json_CounsellorRecommendation = null,
        string json_Honors_Awards = null, string json_DreamUniversities = null, string json_DU_CounsellorRecommendation = null, string json_A_LEVEL_SUBJECTS = null
        )
    {


        SqlParameter[] param = new SqlParameter[25];

        param[0] = new SqlParameter("@user_id", Session["UserId"].ToString());
        param[1] = new SqlParameter("@Session_Id", Session["Session_Id"].ToString());//Session["Session_Id"].ToString()
        param[2] = new SqlParameter("@Term_Group_Id", "1");
        param[3] = new SqlParameter("@Student_id", Request.QueryString["s"].ToString());
        param[4] = new SqlParameter("@Optional1", Optional1);
        param[5] = new SqlParameter("@Optional2", Optional2);
        param[6] = new SqlParameter("@json_intrest_code", json_intrest_code);
        param[7] = new SqlParameter("@json_Subject_detal", json_Subject_detal);
        param[8] = new SqlParameter("@AcademicConcerns", txtE_AcademicConcerns.Text);
        param[9] = new SqlParameter("@json_ExtraCurricularActivities", json_ExtraCurricularActivities);
        param[10] = new SqlParameter("@json_CounsellorRecommendation", json_CounsellorRecommendation);
        param[11] = new SqlParameter("@json_Honors_Awards", json_Honors_Awards);
        param[12] = new SqlParameter("@json_DreamUniversities", json_DreamUniversities);
        param[13] = new SqlParameter("@json_DU_CounsellorRecommendation", json_DU_CounsellorRecommendation);
        param[14] = new SqlParameter("@json_A_LEVEL_SUBJECTS", json_A_LEVEL_SUBJECTS);
        param[15] = new SqlParameter("@Remarks1", txtE_Remarks1.Text);
        param[16] = new SqlParameter("@Remarks2", txtE_Remarks2.Text);
        param[17] = new SqlParameter("@Remarks3", txtE_Remarks3.Text);
        param[18] = new SqlParameter("@TeacherName1", txtTeacherName1.Text);
        param[19] = new SqlParameter("@TeacherName2", txtTeacherName2.Text);
        param[20] = new SqlParameter("@SubjectTaught1", txtSubjectTaught1.Text);
        param[21] = new SqlParameter("@SubjectTaught2", txtSubjectTaught2.Text);
        param[22] = new SqlParameter("@Expected_Graduation_Year", txtExpected_Graduation_Year.Text);
        param[23] = new SqlParameter("@Progressto_A_Level", ViewState["Progress"]);
        param[24] = new SqlParameter("@Action", action);


        DataSet ds = objBase.sqlcmdFetch_DS("SP_IEP_FullForms", param);
        ds.Dispose();
        return ds;
    }

    private void Credentials()
    {
       // DIV_Teacher01.Enabled = false;
        DIV_Teacher011.Enabled = false;
        DIV_Teacher02.Enabled = false;
     //   DIV_Counsellor01.Enabled = false;
     //   DIV_Counsellor02.Enabled = false;
     //   DIV_Counsellor04.Enabled = false;
      // DIV_Counsellor03.Enabled = false;
        Counselor_div1.Enabled = false;

        string a = Session["UserType_Id"].ToString();
       

        //if (Session["UserType_Id"].ToString() == "1")
        //{
        //    DIV_Teacher01.Enabled = true;
        //    DIV_Teacher011.Enabled = true;
        //    DIV_Teacher02.Enabled = true;
        //    btnSave.Visible = true;
        //    //DisableControls(Page);
        //}
        //else if (Session["UserType_Id"].ToString() == "34")
        //{
        //    DIV_Counsellor01.Enabled = true;
        //    DIV_Counsellor02.Enabled = true;
        //    DIV_Counsellor04.Enabled = true;
        //    DIV_Counsellor03.Enabled = true;
        //    Counselor_div1.Enabled = true;
        //    btnSave.Visible = true;


        //}
        //else if (Session["UserType_Id"].ToString() == "5")
        //{

        //    btnSave.Visible = false;
        //    btnReset.Visible = false;

        //}
        //else
        if (Session["UserType_Id"].ToString() == "3" || Session["UserType_Id"].ToString() == "25" || Session["UserType_Id"].ToString() == "5" || Session["UserType_Id"].ToString() == "34"  ||  Session["UserType_Id"].ToString() == "4")
        {
            DisableControls(Page, false);
        }
        else
        {
            Response.Redirect("~/PresentationLayer/Default.aspx", false);
        }
    }
    public void init()
    {
        try
        {

            // DataSet ds = exec_SP(action: "GET_IEP", Optional1: Request.QueryString["ses"].ToString());
            DataSet ds = exec_SP(action: "GET_IEP", Optional1: "1");
            ViewState["vs_dataset"] = ds;
            ds.Dispose();
            if (ds.Tables[0].Rows[0]["PromotedToClass"].ToString() != "0")
            {
                ieplbl.InnerText = ieplbl.InnerText + " " + ds.Tables[0].Rows[0]["session"].ToString();
                BindStudentDetail(ds.Tables[0]);
                Bind_ResultsoftheRAISECTest_Detail(ds.Tables[1]);
                //Elective SUbjects
                DataTable dt = new DataTable(); //declare a new table
                                                // dTable.TableName = "CloneTable";
                                                // dt = dTable(); //dTabel is the existing table

                dt.NewRow();
                if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {

                    Bind_AcademicOverviewSubject_Detail(ds);
                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        txtRemarks1.Text = ds.Tables[7].Rows[0]["Remarks1"].ToString();
                        txtRemarks2.Text = ds.Tables[7].Rows[0]["Remarks2"].ToString();
                        txtRemarks3.Text = ds.Tables[7].Rows[0]["Remarks3"].ToString();
                        txtTeacherName1.Text = ds.Tables[7].Rows[0]["Recommendation_Teacher_Name_1"].ToString();
                        txtTeacherName2.Text = ds.Tables[7].Rows[0]["Recommendation_Teacher_Name_2"].ToString();
                        txtSubjectTaught1.Text = ds.Tables[7].Rows[0]["Recommendation_Subject_Taught_1"].ToString();
                        txtSubjectTaught2.Text = ds.Tables[7].Rows[0]["Recommendation_Subject_Taught_2"].ToString();

                        Counselor_div2.Visible = true;
                        Counselor_div2_2nd.Visible = true;
                    }
                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        //for (int i = 0; i < ds.Tables[8].Columns.Count; i++)
                        //{
                        //    dt.Columns.Add(Convert.ToString(ds.Tables[8].Columns[0].ColumnName));
                        //   // dt.NewRow();
                        //   // dt.Rows[0][i] = ds.Tables[8].Rows[0][i];

                        //}

                        for (int i = 0; i <= ds.Tables[8].Rows.Count; i++)
                        {
                            dt.Columns.Add(i.ToString());
                        }
                        for (int i = 0; i < ds.Tables[8].Columns.Count; i++)
                        {
                            dt.Rows.Add();
                            dt.Rows[i][0] = ds.Tables[8].Columns[i].ColumnName;
                        }
                        for (int i = 0; i < ds.Tables[8].Columns.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[8].Rows.Count; j++)
                            {
                                dt.Rows[i][j + 1] = ds.Tables[8].Rows[j][i];
                            }
                        }
                        dt.Columns.Remove("0");
                        ViewState["vs_Elective_subjects"] = dt;



                    }

                    //if (ds.Tables[10].Rows.Count > 0)
                    //    lblAcknowledge_By_School_Head.InnerText = ds.Tables[10].Rows[0]["signature"].ToString();
                    //else
                    //    lblAcknowledge_By_School_Head.InnerText = "";


                }
                else
                {
                    Counselor_div2.Visible = false;
                    Counselor_div2_2nd.Visible = false;
                }



                //----------------------------------------------------------------------------------------\\
                DataSet dsE = exec_SP(action: "ENT", Optional1: "1", Optional2: "1");
                dsE.Dispose();
                ViewState["vs_datasetE"] = dsE;
                BindEntryFormDetail(ds.Tables[0], dsE);
            }
            else
            {

                iepstatus.InnerText = " Student Is  Promoted To 9 M (Matric)";
            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }
    protected void DisableControls(Control parent, bool State)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is DropDownList)
            {
                ((DropDownList)(c)).Enabled = State;
            }
            if (c is TextBox)
            {
                ((TextBox)(c)).ReadOnly = State;
            }
            if (c is RadioButton)
            {
                ((RadioButton)(c)).Enabled = State;
            }
        }

    }
    private void Bind_ResultsoftheRAISECTest_Detail(DataTable dt)
    {
        try
        {
            DataTable dt_ResultsoftheRAISECTest = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Interest_Code").CopyToDataTable();
            dt_ResultsoftheRAISECTest.Dispose();
            if (dt_ResultsoftheRAISECTest.Rows.Count > 0)
            {
                ctrlIntrestCode.DataSource = dt_ResultsoftheRAISECTest;
                ctrlIntrestCode.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_CareerGoals = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Career_Goals").CopyToDataTable();
            dt_CareerGoals.Dispose();
            if (dt_CareerGoals.Rows.Count > 0)
            {
                ctrlCareerGoals.DataSource = dt_CareerGoals;
                ctrlCareerGoals.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_PersonalStrengths = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Personal_Strengths").CopyToDataTable();
            dt_PersonalStrengths.Dispose();

            if (dt_PersonalStrengths.Rows.Count > 0)
            {
                ctrlPersonalStrengths.DataSource = dt_PersonalStrengths;
                ctrlPersonalStrengths.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_QualitiestoDevelop = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Qualities_to_Develop").CopyToDataTable();
            dt_QualitiestoDevelop.Dispose();

            if (dt_QualitiestoDevelop.Rows.Count > 0)
            {
                ctrlQualitiestoDevelop.DataSource = dt_QualitiestoDevelop;
                ctrlQualitiestoDevelop.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_HobbiesInterests = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Hobbies_Interests").CopyToDataTable();
            dt_HobbiesInterests.Dispose();

            if (dt_HobbiesInterests.Rows.Count > 0)
            {
                ctrlHobbiesInterests.DataSource = dt_HobbiesInterests;
                ctrlHobbiesInterests.DataBind();
            }



        }
        catch (Exception ex)
        {

            lblerror.Text = "Something went Wrong..";// ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }
    private void BindEntryFormDetail(DataTable dt, DataSet dsE)
    {

        hdE_Class_Id.Value = dt.Rows[0]["prevclassid"].ToString();
        //lblE_Class_Name.InnerText =  dt.Rows[0]["prevclassname"].ToString();

        hd_section_id.Value = dt.Rows[0]["Section_Id"].ToString();

        if (dt.Rows[0]["PromotedClass"].ToString() == "17")
            rb_2.Checked = true;
        else
            rb_1.Checked = true;
        if (hdE_Class_Id.Value == "12")
            birfurcation.Visible = false;

        if (hdE_Class_Id.Value != "12")
        {

            // elective1.Visible = true;
            elective1.Visible = false;
        }

        if (hdE_Class_Id.Value == "15")
        {
            div_OLevels.Visible = true;

        }
        else
        {
            div_OLevels.Visible = false;
        }

        if (dsE.Tables[0].Rows.Count > 0)
        {
           if (dsE.Tables[0].Rows[0]["Progressto_A_Level"].ToString() == "True")
                rd_progress2.Checked = true;
            else
                rd_progress1.Checked = true;


            htmlE_SubjectBody.Text = Generate_AcademicOverview_SubjectDetail(dsE.Tables[0]);
            htmlE_SubjectBody1.Text = Generate_AcademicOverview_SubjectDetail(dsE.Tables[9]);
            txtE_Remarks1.Text = dsE.Tables[0].Rows[0]["Remarks1"].ToString();
            txtE_Remarks2.Text = dsE.Tables[0].Rows[0]["Remarks2"].ToString();
            txtE_Remarks3.Text = dsE.Tables[0].Rows[0]["Remarks3"].ToString();
            txtE_AcademicConcerns.Text = dsE.Tables[0].Rows[0]["Academic_Concerns_Struggles"].ToString();
            txtTeacherName1.Text = dsE.Tables[0].Rows[0]["Recommendation_Teacher_Name_1"].ToString();
            txtTeacherName2.Text = dsE.Tables[0].Rows[0]["Recommendation_Teacher_Name_2"].ToString();
            txtSubjectTaught1.Text = dsE.Tables[0].Rows[0]["Recommendation_Subject_Taught_1"].ToString();
            txtSubjectTaught2.Text = dsE.Tables[0].Rows[0]["Recommendation_Subject_Taught_2"].ToString();
            txtExpected_Graduation_Year.Text = dsE.Tables[0].Rows[0]["Expected_Graduation_Year"].ToString();
            Batch_Id.Value = dsE.Tables[0].Rows[0]["batch_Id"].ToString();
            //if (dsE.Tables[0].Rows[0]["Acknowledge_By_Class_Teacher"].ToString() != "")
            //{
            //    lblAcknowledge_By_Class_Teacher.InnerText = dsE.Tables[0].Rows[0]["Acknowledge_By_Class_Teacher"].ToString();
            //}

            //if (dsE.Tables[13].Rows.Count > 0)
            //    lblAcknowledge_By_School_Head.InnerText = dsE.Tables[13].Rows[0]["signature"].ToString();
            //else
            //    lblAcknowledge_By_School_Head.InnerText = "";
            //if (dsE.Tables[0].Rows[0]["Acknowledge_By_Counselor"].ToString() != "")
            //{
            //    lblAcknowledge_By_Counselor.InnerText = "Acknowledged";
            //}

            if (dsE.Tables[0].Rows[0]["Acknowledge_By_Parent"].ToString() != "")
            {
                lblAcknowledge_By_Parent.InnerText = dt.Rows[0][5].ToString();
            }
            hfE_Trrm_Group_Id.Value = dsE.Tables[0].Rows[0]["Term_Group_Id"].ToString();

        }
        else
        {
            belowmarks.Visible = false;
            belowmarks1.Visible = false;
            tbl_EYE.Visible = false;
            tbl_MYE.Visible = false;
        }
        if (dsE.Tables[10].Rows.Count > 0)
        {



        }
        else
        {
            belowmarks1.Visible = false;
            tbl_EYE.Visible = false;
        }
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        ds.Dispose();
        // DateTime dt2 = DateTime.Parse("2023-12-26"); //  DateTime.Now; //Temporaroy Disabled this condition for result date compare to todayy date
        if (dsE.Tables[1].Rows.Count > 0)
        {
            lblE_Term.InnerText = dsE.Tables[1].Rows[0]["Term"].ToString();

            hfE_Trrm_Group_Id.Value = dsE.Tables[0].Rows[0]["Term_Group_Id"].ToString();
            int result = 0; //Temporaroy Disabled this condition for result date compare to todayy date      DateTime.Compare(dt2.Date, DateTime.Parse(ds.Tables[0].Rows[0]["ResultCardIssuanceDateMidYear"].ToString()));
            if (result != -1)
            {
                grdE_SubjectDetail.DataSource = dsE.Tables[1];
                grdE_SubjectDetail.DataBind();
            }
            else
            {

                belowmarks.Visible = false;
            }

        }
        else
        {
            belowmarks.Visible = false;
            lblE_Term.InnerText = "MYE";
        }
        if (dsE.Tables[10].Rows.Count > 0)
        {

            lblE_Term1.InnerText = dsE.Tables[10].Rows[0]["Term"].ToString();
            int result = 0;//DateTime.Compare(dt2.Date, DateTime.Parse(ds.Tables[0].Rows[0]["ResultCardIssuanceDateEOYYear"].ToString()));
            if (result != -1)
            {
                grdE_SubjectDetail1.DataSource = dsE.Tables[10];
                grdE_SubjectDetail1.DataBind();
            }
            else
            {

                belowmarks1.Visible = false;
            }
        }
        else
        {
            belowmarks1.Visible = false;
            lblE_Term1.InnerText = "EOY";
        }
        gridelective1.DataSource = ViewState["vs_Elective_subjects"];
        gridelective1.DataBind();

        dsTimline.ConnectionString = objBase._cn.ConnectionString;
        dsTimline.SelectCommand = "exec Sp_Iep_Form_Councellor @user_id = 'Aims.Ho',@Action = 'GET_TYPE',@Optional1 = 19";

        dsStatus.ConnectionString = objBase._cn.ConnectionString;
        dsStatus.SelectCommand = "exec Sp_Iep_Form_Councellor @user_id = 'Aims.Ho',@Action = 'GET_TYPE',@Optional1 = 22";



        if (dsE.Tables[2].Rows.Count <= 1)
        {
            for (int i = 0; i < 4; i++)
                dsE.Tables[2].Rows.Add();

            grdE_ExtraCurricularActivities.DataSource = dsE.Tables[2];
            grdE_ExtraCurricularActivities.DataBind();
        }
        else
        {
            grdE_ExtraCurricularActivities.DataSource = dsE.Tables[2];
            grdE_ExtraCurricularActivities.DataBind();
        }
        if (dsE.Tables[3].Rows.Count <= 1)
        {
            for (int i = 0; i < 4; i++)
                dsE.Tables[3].Rows.Add();

            grdE_CounselorRecommendations.DataSource = dsE.Tables[3];
            grdE_CounselorRecommendations.DataBind();
        }
        else
        {
            grdE_CounselorRecommendations.DataSource = dsE.Tables[3];
            grdE_CounselorRecommendations.DataBind();
        }

        if (dt.Rows[0]["classid"].ToString() == "13" || dt.Rows[0]["classid"].ToString() == "14" || dt.Rows[0]["classid"].ToString() == "15")
        {
            if (dsE.Tables[4].Rows.Count <= 1)
            {
                for (int i = 0; i < 1; i++)
                    dsE.Tables[4].Rows.Add();
                repHonors_Awards.DataSource = dsE.Tables[4];
                repHonors_Awards.DataBind();
            }
            else
            {
                repHonors_Awards.DataSource = dsE.Tables[4];
                repHonors_Awards.DataBind();
            }
            divE_Honors_Awards.Visible = true;
        }

        if (dt.Rows[0]["classid"].ToString() == "14")
        {
            if (dsE.Tables[5].Rows.Count <= 1)
            {
                for (int i = 0; i < 2; i++)
                    dsE.Tables[5].Rows.Add();
                repDreamUniversities.DataSource = dsE.Tables[5];
                repDreamUniversities.DataBind();
            }
            else
            {
                repDreamUniversities.DataSource = dsE.Tables[5];
                repDreamUniversities.DataBind();
            }
            divE_DreamUniversities.Visible = true;
            if (dsE.Tables[6].Rows.Count <= 1)
            {
                for (int i = 0; i < 2; i++)
                    dsE.Tables[6].Rows.Add();
                repCounsellorRecommendation.DataSource = dsE.Tables[6];
                repCounsellorRecommendation.DataBind();
            }
            else
            {
                repCounsellorRecommendation.DataSource = dsE.Tables[6];
                repCounsellorRecommendation.DataBind();
            }
            divE_CounsellorRecommendation.Visible = true;
        }

        if (dt.Rows[0]["classid"].ToString() == "15")
        {
            divE_CAIE_ResultDetail.Visible = true;
            Div_progressing.Visible = true;
            div_undertaking.Visible = true;
            htmlE_CAIE_ResultDetail.Text = Generate_CAIE_ResultDetail(dsE.Tables[8]);
            div_subjects.Visible = true;

            if (dsE.Tables[12].Rows.Count <= 1)
            {
                for (int i = 0; i < 2; i++)
                    dsE.Tables[12].Rows.Add();
                rep_subjects.DataSource = dsE.Tables[12];
                rep_subjects.DataBind();
            }
            else
            {
                rep_subjects.DataSource = dsE.Tables[12];
                rep_subjects.DataBind();
            }
            if (dsE.Tables[13].Rows.Count <= 1)
            {
                for (int i = 0; i < 6; i++)
                    dsE.Tables[13].Rows.Add();
                rpt_undertakingissued.DataSource = dsE.Tables[13];
                rpt_undertakingissued.DataBind();
            }
            else
            {
                rpt_undertakingissued.DataSource = dsE.Tables[13];
                rpt_undertakingissued.DataBind();
            }

            //  rpt_undertakingissued.DataSource = 
        }
        if (dt.Rows[0]["classid"].ToString() != "12")
        {
            div_undertaking.Visible = true;
            if (dsE.Tables[13].Rows.Count <= 1)
            {
                for (int i = 0; i < 6; i++)
                    dsE.Tables[13].Rows.Add();
                rpt_undertakingissued.DataSource = dsE.Tables[13];
                rpt_undertakingissued.DataBind();
            }
            else
            {
                rpt_undertakingissued.DataSource = dsE.Tables[13];
                rpt_undertakingissued.DataBind();
            }
        }

    }
    private void BindStudentDetail(DataTable dt)
    {
        dt.Dispose();
        if (dt.Rows.Count > 0)
        {
            spnStudentName.InnerText = dt.Rows[0]["fullname"].ToString();
            spnErpNo.InnerText = dt.Rows[0]["student_id"].ToString();
            spnClass.InnerText = dt.Rows[0]["className"].ToString();
            spnEmail.InnerText = dt.Rows[0]["student_email"].ToString();
            spnContactNo.InnerText = dt.Rows[0]["PrimaryContactNo"].ToString();
            txtExpected_Graduation_Year.Text = dt.Rows[0]["Expected_Graduation_Year"].ToString();
            lblAcknowledge_By_Class_Teacher.InnerText = dt.Rows[0]["Acknowledge_By_Class_Teacher"].ToString();
            lblAcknowledge_By_School_Head.InnerText = dt.Rows[0]["headname"].ToString();
            lblAcknowledge_By_Counselor.InnerText = dt.Rows[0]["Counselor"].ToString();
            if (dt.Rows[0]["erpclass"].ToString() == "12")
            {
                btn_bifurcation.Text = "Bifurcation";
            }
            else
            {

                btn_bifurcation.Text = "Undertaking";
            }
        }
        if (Session["UserId"].ToString() == dt.Rows[0]["ClassTeacher_Id"].ToString())
        {
            txtE_AcademicConcerns.Enabled = true;
            // btn_bifurcation.Visible = true;
            btnSend.Visible = true;
        }

    }
    private void Bind_AcademicOverviewSubject_Detail(DataSet ds)
    {
        DataTable dt_overview = new DataTable();
        dt_overview.Columns.Add("Class_Name");
        dt_overview.Columns.Add("Term");
        dt_overview.Columns.Add("Body");
        dt_overview.Columns.Add("Class_Id");

        dt_overview.Columns.Add("Acknowledge_By_Class_Teacher");
        dt_overview.Columns.Add("Acknowledge_On_Class_Teacher");
        dt_overview.Columns.Add("Acknowledge_By_School_Head");
        dt_overview.Columns.Add("Acknowledge_On_School_Head");
        dt_overview.Columns.Add("Acknowledge_By_Counselor");
        dt_overview.Columns.Add("Acknowledge_On_Counselor");
        dt_overview.Columns.Add("Acknowledge_By_Parent");
        dt_overview.Columns.Add("Acknowledge_On_Parent");




        for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
        {
            //DataTable dt = ds.Tables[2].AsEnumerable().Where(row => row.Field<Int32>("Class_Id") == Convert.ToInt32(ds.Tables[3].Rows[i]["Class_Id"])).CopyToDataTable();


            DataTable dt = null;
            var rows = ds.Tables[2].AsEnumerable()
                .Where(x => (Int32)x["Class_Id"] == Convert.ToInt32(ds.Tables[7].Rows[i]["Class_Id"]));

            if (rows.Any())
                dt = rows.CopyToDataTable();



            string a = Generate_AcademicOverview_SubjectDetail(dt);
            DataRow dr = dt_overview.NewRow();
            dr[0] = ds.Tables[7].Rows[i]["Class_Name"].ToString();
            dr[1] = dt.Rows[0]["Term"].ToString();
            dr[2] = a;
            dr[3] = ds.Tables[7].Rows[i]["Class_Id"].ToString();
            dr[4] = ds.Tables[7].Rows[i]["Acknowledge_By_Class_Teacher"].ToString();
            dr[5] = ds.Tables[7].Rows[i]["Acknowledge_On_Class_Teacher"].ToString();
            dr[6] = ds.Tables[7].Rows[i]["Acknowledge_By_School_Head"].ToString();
            dr[7] = ds.Tables[7].Rows[i]["Acknowledge_On_School_Head"].ToString();
            dr[8] = ds.Tables[7].Rows[i]["Acknowledge_By_Counselor"].ToString();
            dr[9] = ds.Tables[7].Rows[i]["Acknowledge_On_Counselor"].ToString();
            dr[10] = ds.Tables[7].Rows[i]["Acknowledge_By_Parent"].ToString();
            dr[11] = ds.Tables[7].Rows[i]["Acknowledge_On_Parent"].ToString();




            dt_overview.Rows.Add(dr);
        }
        if (dt_overview.Rows.Count > 0)
        {
            repAcademicOverview.DataSource = dt_overview;
            repAcademicOverview.DataBind();
        }
    }

    public DataTable Data_ResultsoftheRAISECTest()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("IEP_Type_Id");
            dt_GetValues.Columns.Add("Field_Name");
            dt_GetValues.Columns.Add("SN");
            dt_GetValues.Columns.Add("Value");

            for (int i = 0; i < ctrlIntrestCode.Items.Count; i++)
            {
                DropDownList ddlInterest_Code = ctrlIntrestCode.Items[i].FindControl("DdlInterest_Code") as DropDownList;
                HiddenField hdIEP_Type_Id = ctrlIntrestCode.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Interest_Code";
                dr[2] = (i + 1).ToString();
                dr[3] = ddlInterest_Code.SelectedItem.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlCareerGoals.Items.Count; i++)
            {
                TextBox txtCareer_Goals = ctrlCareerGoals.Items[i].FindControl("txtCareer_Goals") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlCareerGoals.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Career_Goals";
                dr[2] = (i + 1).ToString();
                dr[3] = txtCareer_Goals.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlPersonalStrengths.Items.Count; i++)
            {
                TextBox Personal_Strengths = ctrlPersonalStrengths.Items[i].FindControl("txtPersonal_Strengths") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlPersonalStrengths.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Personal_Strengths";
                dr[2] = (i + 1).ToString();
                dr[3] = Personal_Strengths.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlQualitiestoDevelop.Items.Count; i++)
            {
                TextBox txtQualities_to_Develop = ctrlQualitiestoDevelop.Items[i].FindControl("txtQualities_to_Develop") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlQualitiestoDevelop.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Qualities_to_Develop";
                dr[2] = (i + 1).ToString();
                dr[3] = txtQualities_to_Develop.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlHobbiesInterests.Items.Count; i++)
            {
                TextBox txtHobbies_Interests = ctrlHobbiesInterests.Items[i].FindControl("txtHobbies_Interests") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlHobbiesInterests.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Hobbies_Interests";
                dr[2] = (i + 1).ToString();
                dr[3] = txtHobbies_Interests.Text;
                dt_GetValues.Rows.Add(dr);
            }
            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public DataTable Data_SubjectDetail()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();

            dt_GetValues.Columns.Add("Subject_Id");
            dt_GetValues.Columns.Add("Weak_Topic_Areas");
            dt_GetValues.Columns.Add("Academic_Potential");
            dt_GetValues.Columns.Add("Suggested_Study_Hours");
            dt_GetValues.Columns.Add("Suggested_Work_Plan");

            for (int i = 0; i < grdE_SubjectDetail.Rows.Count; i++)
            {
                HiddenField hdSubject_Id = grdE_SubjectDetail.Rows[i].FindControl("hdSubject_Id") as HiddenField;
                TextBox txtE_Weak_Topic_Areas = grdE_SubjectDetail.Rows[i].FindControl("txtE_Weak_Topic_Areas") as TextBox;
                TextBox txtE_Academic_Potential = grdE_SubjectDetail.Rows[i].FindControl("txtE_Academic_Potential") as TextBox;
                TextBox txtE_Suggested_Study_Hours = grdE_SubjectDetail.Rows[i].FindControl("txtE_Suggested_Study_Hours") as TextBox;
                TextBox txtE_Suggested_Work_Plan = grdE_SubjectDetail.Rows[i].FindControl("txtE_Suggested_Work_Plan") as TextBox;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdSubject_Id.Value;
                dr[1] = txtE_Weak_Topic_Areas.Text;
                dr[2] = txtE_Academic_Potential.Text;
                dr[3] = txtE_Suggested_Study_Hours.Text;
                dr[4] = txtE_Suggested_Work_Plan.Text;

                dt_GetValues.Rows.Add(dr);
              
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public DataTable Data_ExtraCurricularActivities()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("IEP_ECA_Id");
            dt_GetValues.Columns.Add("IEP_Id");
            dt_GetValues.Columns.Add("Extra_Curricular_Activities");
            dt_GetValues.Columns.Add("Activity_Title_and_Organization");
            dt_GetValues.Columns.Add("Role_and_Responsibilities");
            dt_GetValues.Columns.Add("Hours_Week");
            dt_GetValues.Columns.Add("Organization");
            dt_GetValues.Columns.Add("Timeline");

            for (int i = 0; i < grdE_ExtraCurricularActivities.Rows.Count; i++)
            {
                HiddenField hfE_IEP_ECA_Id = grdE_ExtraCurricularActivities.Rows[i].FindControl("hfE_IEP_ECA_Id") as HiddenField;
                HiddenField hfE_IEP_Id = grdE_ExtraCurricularActivities.Rows[i].FindControl("hfE_IEP_Id") as HiddenField;
                TextBox txtE_ExtraCurricularActivities = grdE_ExtraCurricularActivities.Rows[i].FindControl("txtE_ExtraCurricularActivities") as TextBox;
                TextBox txtE_ActivityTitleandOrganization = grdE_ExtraCurricularActivities.Rows[i].FindControl("txtE_ActivityTitleandOrganization") as TextBox;
                TextBox txtE_RoleandResponsibilities = grdE_ExtraCurricularActivities.Rows[i].FindControl("txtE_RoleandResponsibilities") as TextBox;
                TextBox txtE_HoursWeek = grdE_ExtraCurricularActivities.Rows[i].FindControl("txtE_HoursWeek") as TextBox;
                TextBox txtE_Organization = grdE_ExtraCurricularActivities.Rows[i].FindControl("txtorganization") as TextBox;
                DropDownList rdbE_Timeline = grdE_ExtraCurricularActivities.Rows[i].FindControl("rdbE_Timeline") as DropDownList;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hfE_IEP_ECA_Id.Value;
                dr[1] = hfE_IEP_Id.Value;
                dr[2] = txtE_ExtraCurricularActivities.Text;
                dr[3] = txtE_ActivityTitleandOrganization.Text;
                dr[4] = txtE_RoleandResponsibilities.Text;
                dr[5] = txtE_HoursWeek.Text;
                dr[6] = txtE_Organization.Text;
                dr[7] = rdbE_Timeline.SelectedValue;

                dt_GetValues.Rows.Add(dr);
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public DataTable Data_CounselorRecommendations()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("IEP_ECA_Id");
            dt_GetValues.Columns.Add("IEP_Id");
            dt_GetValues.Columns.Add("Extra_Curricular_Activities");
            dt_GetValues.Columns.Add("Activity_Title_and_Organization");
            dt_GetValues.Columns.Add("Role_and_Responsibilities");
            dt_GetValues.Columns.Add("Hours_Week");
            dt_GetValues.Columns.Add("Organization");
            dt_GetValues.Columns.Add("Timeline");

            for (int i = 0; i < grdE_CounselorRecommendations.Rows.Count; i++)
            {
                HiddenField hfE_IEP_ECA_Id = grdE_CounselorRecommendations.Rows[i].FindControl("hfE_IEP_ECA_Id") as HiddenField;
                HiddenField hfE_IEP_Id = grdE_CounselorRecommendations.Rows[i].FindControl("hfE_IEP_Id") as HiddenField;
                TextBox txtE_ExtraCurricularActivities = grdE_CounselorRecommendations.Rows[i].FindControl("txtE_ExtraCurricularActivities") as TextBox;
                TextBox txtE_ActivityTitleandOrganization = grdE_CounselorRecommendations.Rows[i].FindControl("txtE_ActivityTitleandOrganization") as TextBox;
                TextBox txtE_RoleandResponsibilities = grdE_CounselorRecommendations.Rows[i].FindControl("txtE_RoleandResponsibilities") as TextBox;
                TextBox txtE_HoursWeek = grdE_CounselorRecommendations.Rows[i].FindControl("txtE_HoursWeek") as TextBox;
                TextBox txtE_Organization = grdE_CounselorRecommendations.Rows[i].FindControl("txtorganization") as TextBox;
                DropDownList rdbE_Timeline = grdE_CounselorRecommendations.Rows[i].FindControl("rdbE_Timeline") as DropDownList;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hfE_IEP_ECA_Id.Value;
                dr[1] = hfE_IEP_Id.Value;
                dr[2] = txtE_ExtraCurricularActivities.Text;
                dr[3] = txtE_ActivityTitleandOrganization.Text;
                dr[4] = txtE_RoleandResponsibilities.Text;
                dr[5] = txtE_HoursWeek.Text;
                dr[6] = txtE_Organization.Text;
                dr[7] = rdbE_Timeline.SelectedValue;

                dt_GetValues.Rows.Add(dr);
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public DataTable Data_Honors_Awards()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("Award_Honor");
            dt_GetValues.Columns.Add("Awarding_Body");
            dt_GetValues.Columns.Add("Year");

            for (int i = 0; i < repHonors_Awards.Items.Count; i++)
            {
                TextBox txtE_Award_Honor = repHonors_Awards.Items[i].FindControl("txtE_Award_Honor") as TextBox;
                TextBox txtE_Awarding_Body = repHonors_Awards.Items[i].FindControl("txtE_Awarding_Body") as TextBox;
                TextBox txtE_Year = repHonors_Awards.Items[i].FindControl("txtE_Year") as TextBox;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = txtE_Award_Honor.Text;
                dr[1] = txtE_Awarding_Body.Text;
                dr[2] = txtE_Year.Text;
                dt_GetValues.Rows.Add(dr);
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public DataTable Data_A_LEVEL_SUBJECTS()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("SUBJECT_1");
            dt_GetValues.Columns.Add("SUBJECT_2");
            dt_GetValues.Columns.Add("SUBJECT_3");

            for (int i = 0; i < rep_subjects.Items.Count; i++)
            {
                TextBox txtE_SUBJECT_1 = rep_subjects.Items[i].FindControl("txtsubject1") as TextBox;
                TextBox txtE_SUBJECT_2 = rep_subjects.Items[i].FindControl("txtsubject2") as TextBox;
                TextBox txtE_SUBJECT_3 = rep_subjects.Items[i].FindControl("txtsubject3") as TextBox;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = txtE_SUBJECT_1.Text;
                dr[1] = txtE_SUBJECT_2.Text;
                dr[2] = txtE_SUBJECT_3.Text;
                dt_GetValues.Rows.Add(dr);
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }


    public DataTable DU_CR(Repeater rep)
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("International");
            dt_GetValues.Columns.Add("Local");
            for (int i = 0; i < rep.Items.Count; i++)
            {
                TextBox txtE_International = rep.Items[i].FindControl("txtE_International") as TextBox;
                TextBox txtE_Local = rep.Items[i].FindControl("txtE_Local") as TextBox;

                DataRow dr = dt_GetValues.NewRow();
                dr[0] = txtE_International.Text;
                dr[1] = txtE_Local.Text;
                dt_GetValues.Rows.Add(dr);
            }

            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public string Generate_CAIE_ResultDetail(DataTable dt)
    {
        string tbody = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbody += "<tr>";
                tbody += "<td style='width:50%'>" + dt.Rows[i]["Subject_Name"].ToString() + "</td><td style='width:50%'>" + dt.Rows[i]["Grade"].ToString() + "</td>";
                tbody += "</tr>";
            }
        }
        return tbody;
    }
    public string Generate_AcademicOverview_SubjectDetail(DataTable dt)
    {
        string tbody = "";
        int count_td = 0;
        if (dt.Rows.Count > 0)
        {
            //DIV_Teacher02.Visible = true;
            ViewState["Term"] = "2";
            tbody = "<tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbody += "<td style='width:18%'>" + dt.Rows[i]["Subject_Name"].ToString() + "</td><td style='width:7%'>" + dt.Rows[i]["Grade"].ToString() + "</td>";
                count_td++;
                if (count_td == 4)
                {
                    count_td = 0;
                    tbody += "</tr><tr>";
                }
            }

            int remaining_td = 4 - count_td;
            if (remaining_td > 0)
            {
                for (int i = 0; i < remaining_td; i++)
                {
                    tbody += "<td style='width:18%'></td><td style='width:7%'></td>";
                }
            }
            tbody += "</tr>";
        }
        else
        {
            ViewState["Term"] = "1";
        }
        return tbody;
    }
    public string Generate_AcademicOverview_OtherDetail(DataTable dt)
    {
        string _thead = "", _tbody = "", _tbl = "";

        if (dt.Rows.Count > 0)
        {
            _tbl += "<table class='table table-bordered'>";
            string _headings = "", _rowNo = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string _h = dt.Columns[i].ToString().Substring(0, dt.Columns[i].ToString().Length - 2);
                string _r = dt.Columns[i].ToString().Substring(dt.Columns[i].ToString().Length - 1, 1);
                if (!_headings.Contains(_h))
                {
                    _headings += _h + ",";
                    _rowNo += _r + ",";
                }
            }
            _headings = _headings.Substring(0, _headings.Length - 1);
            _rowNo = _rowNo.Substring(0, _rowNo.Length - 1);

            string[] _headingsArr = _headings.Replace("_", " ").Split(',');
            string[] _RowsArr = _rowNo.Split(',');
            int _break = _RowsArr.Length;
            int b = 0;

            _thead += "<thead><tr>";
            for (int i = 0; i < _headingsArr.Length; i++)
            {
                _thead += "<th>" + _headingsArr[i] + "</th>";
            }
            _thead += "</tr></thead>";
            _tbody += "<tbody><tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (b == _break && dt.Columns.Count - 1 != i)
                {
                    b = 0;
                    _tbody += "</tr><tr>";
                }

                _tbody += "<td>" + dt.Rows[0][i].ToString() + "</td>";
                b++;

            }
            _tbody += "</tr><tbody>";
            _tbl += _thead + _tbody;
            _tbl += "</table>";
        }
        return _tbl;
    }
    public string Generate_AcademicOverview_OtherDetail_New(DataTable dt)
    {
        string _tbl = "";

        if (dt.Rows.Count > 0)
        {
            _tbl += "<table class='table table-bordered'>";
            _tbl += "<thead><tr>";

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                _tbl += "<th>" + dt.Columns[i].ColumnName.ToString() + "</th>";
            }
            _tbl += "</tr></thead>";

            _tbl += "<tbody><tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    _tbl += "<td>" + dt.Rows[i][x].ToString() + "</td>";
                }
            }
            _tbl += "</tr><tbody>";

            _tbl += "</table>";
        }
        return _tbl;
    }
    public void Bind_grd_ECA_CR(string type, GridView grd, int IEP_Id)
    {
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        ds.Dispose();
        int table_index = -1;
        if (type == "ECA")
        {
            table_index = 4;
        }
        else if (type == "CR")
        {
            table_index = 6;
        }

        if (ds.Tables[table_index].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[table_index].AsEnumerable().Where(row => row.Field<Int32>("IEP_ECA_Id") == IEP_Id).CopyToDataTable();
            dt.Dispose();
            grd.DataSource = dt;
            grd.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            if (!IsPostBack)
            {
                init();
                Credentials();
                //DropDownList ddlInterest_Code = ctrlIntrestCode.Items[0].FindControl("DdlInterest_Code") as DropDownList;
                //TextBox txtCareer_Goals = ctrlCareerGoals.Items[0].FindControl("txtCareer_Goals") as TextBox;
                //if (txtE_AcademicConcerns.Text != "" && ddlInterest_Code.SelectedItem.Text != "" && txtCareer_Goals.Text != "")
                //{
                //    // btnSend.Visible = false;
                //    // btn_bifurcation.Visible = false;
                //}
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string json_intrest_code = JsonConvert.SerializeObject(Data_ResultsoftheRAISECTest());
            string json_Subject_detal =  JsonConvert.SerializeObject(Data_SubjectDetail());
            string json_ExtraCurricularActivities = JsonConvert.SerializeObject(Data_ExtraCurricularActivities());
            string json_CounsellorRecommendation = JsonConvert.SerializeObject(Data_CounselorRecommendations());
            string json_Honors_Awards = "";
            string json_A_LEVEL_SUBJECTS = "";
            if (hdE_Class_Id.Value == "13" || hdE_Class_Id.Value == "14" || hdE_Class_Id.Value == "15")
            {
                json_Honors_Awards = JsonConvert.SerializeObject(Data_Honors_Awards());

            }
            if (hdE_Class_Id.Value == "15")
            {
                json_A_LEVEL_SUBJECTS = JsonConvert.SerializeObject(Data_A_LEVEL_SUBJECTS());
            }

            string json_DreamUniversities = hdE_Class_Id.Value == "14" ? JsonConvert.SerializeObject(DU_CR(repDreamUniversities)) : "";
            string json_DU_CounsellorRecommendation = hdE_Class_Id.Value == "14" ? JsonConvert.SerializeObject(DU_CR(repCounsellorRecommendation)) : "";

            //string json_Honors_Awards = JsonConvert.SerializeObject(Data_Honors_Awards());
            //string json_DreamUniversities = JsonConvert.SerializeObject(DU_CR(repDreamUniversities));
            //string json_CounsellorRecommendation = JsonConvert.SerializeObject(DU_CR(repCounsellorRecommendation));

            if (rd_progress1.Checked == true)
                ViewState["Progress"] = 0;
            else
                ViewState["Progress"] = 1;

            DataSet ds = exec_SP("IN", null, null, json_intrest_code, json_Subject_detal, json_ExtraCurricularActivities, json_CounsellorRecommendation, json_Honors_Awards, json_DreamUniversities, json_DU_CounsellorRecommendation, json_A_LEVEL_SUBJECTS);
            if (ds.Tables.Count > 0)
                {
                lblerror.Text = ds.Tables[1].Rows[0][0].ToString();
                lblerror.CssClass = "label label-success text-center";
                Batch_Id.Value = ds.Tables[1].Rows[0][1].ToString();
            }
            else
                {
                lblerror.Text = "Record Not Saved";
                lblerror.CssClass = "label label-danger text-center";
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }

    protected void repAcademicOverview_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataSet vs_dataset = (DataSet)ViewState["vs_dataset"];
            vs_dataset.Dispose();

            HiddenField hd_Class_Id = e.Item.FindControl("hd_Class_Id") as HiddenField;
            DataTable dt = vs_dataset.Tables[3].AsEnumerable().Where(row => row.Field<Int32>("Class_Id") == Convert.ToInt32(hd_Class_Id.Value)).CopyToDataTable();
            GridView grdSubjectDetail = (GridView)e.Item.FindControl("grdSubjectDetail");

            grdSubjectDetail.DataSource = dt;
            grdSubjectDetail.DataBind();
            Label lblAcademicConcerns = e.Item.FindControl("lblAcademicConcerns") as Label;
            lblAcademicConcerns.Text = dt.Rows[0]["Academic_Concerns_Struggles"].ToString();
            if (Session["UserId"].ToString() == dt.Rows[0]["ClassTeacher_Id"].ToString())
                lblAcademicConcerns.Enabled = true;
            GridView grdExtraCurricularActivities = (GridView)e.Item.FindControl("grdExtraCurricularActivities");
            Bind_grd_ECA_CR("ECA", grdExtraCurricularActivities, Convert.ToInt32(vs_dataset.Tables[4].Rows[0]["IEP_Id"]));

            GridView grdCounselorRecommendations = (GridView)e.Item.FindControl("grdCounselorRecommendations");
            Bind_grd_ECA_CR("CR", grdCounselorRecommendations, Convert.ToInt32(dt.Rows[0]["IEP_Id"]));

            DataSet ds_AOD = exec_SP(action: "AOD", Optional1: dt.Rows[0]["Batch_Id"].ToString());
            if (ds_AOD.Tables.Count > 0)
            {
                if (hd_Class_Id.Value == "13")
                {
                    if (ds_AOD.Tables[0].Rows.Count > 0)
                    {
                        Literal tblHonors_Awards = e.Item.FindControl("tblHonors_Awards") as Literal;
                        HtmlGenericControl div_Honors_Awards = e.Item.FindControl("div_Honors_Awards") as HtmlGenericControl;
                        div_Honors_Awards.Visible = true;
                        string strHonors_Awards = Generate_AcademicOverview_OtherDetail_New(ds_AOD.Tables[0]);
                        tblHonors_Awards.Text = strHonors_Awards;

                    }
                }
                if (hd_Class_Id.Value == "14")
                {
                    if (ds_AOD.Tables[1].Rows.Count > 0)
                    {
                        Literal tblDreamUniversities = e.Item.FindControl("tblDreamUniversities") as Literal;
                        HtmlGenericControl div_DreamUniversities = e.Item.FindControl("div_DreamUniversities") as HtmlGenericControl;
                        div_DreamUniversities.Visible = true;
                        string strDreamUniversities = Generate_AcademicOverview_OtherDetail_New(ds_AOD.Tables[1]);
                        tblDreamUniversities.Text = strDreamUniversities;
                    }
                    if (ds_AOD.Tables[2].Rows.Count > 0)
                    {
                        Literal tblCounsellorRecommendation = e.Item.FindControl("tblCounsellorRecommendation") as Literal;
                        HtmlGenericControl div_CounsellorRecommendation = e.Item.FindControl("div_CounsellorRecommendation") as HtmlGenericControl;
                        div_CounsellorRecommendation.Visible = true;
                        string strCounsellorRecommendation = Generate_AcademicOverview_OtherDetail_New(ds_AOD.Tables[2]);
                        tblCounsellorRecommendation.Text = strCounsellorRecommendation;
                    }
                }
                if (hd_Class_Id.Value == "15")
                {
                    Literal html_CAIE_ResultDetail = e.Item.FindControl("html_CAIE_ResultDetail") as Literal;
                    HtmlGenericControl div_AIE_ResultDetail = e.Item.FindControl("div_AIE_ResultDetail") as HtmlGenericControl;
                    div_AIE_ResultDetail.Visible = true;
                    string str_CAIE_ResultDetail = Generate_CAIE_ResultDetail(ds_AOD.Tables[3]);
                    html_CAIE_ResultDetail.Text = str_CAIE_ResultDetail;
                    Div_progressing.Visible = true;
                }
            }
            GridView gridelective = (GridView)e.Item.FindControl("gridelective");
            gridelective1.DataSource = ViewState["vs_Elective_subjects"];
            gridelective1.DataBind();



        }
    }

    protected void grdE_ExtraCurricularActivities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtE_ExtraCurricularActivities = e.Row.FindControl("txtE_ExtraCurricularActivities") as TextBox;
            TextBox txtE_ActivityTitleandOrganization = e.Row.FindControl("txtE_ActivityTitleandOrganization") as TextBox;
            TextBox txtE_RoleandResponsibilities = e.Row.FindControl("txtE_RoleandResponsibilities") as TextBox;
            TextBox txtE_HoursWeek = e.Row.FindControl("txtE_HoursWeek") as TextBox;
            TextBox txtE_Organization = e.Row.FindControl("txtorganization") as TextBox;
            DropDownList rdbE_Timeline = e.Row.FindControl("rdbE_Timeline") as DropDownList;

            txtE_ExtraCurricularActivities.ReadOnly = true;
            txtE_ActivityTitleandOrganization.ReadOnly = true;
            txtE_RoleandResponsibilities.ReadOnly = true;
            txtE_HoursWeek.ReadOnly = true;
            txtE_Organization.ReadOnly = true;
            rdbE_Timeline.Enabled = false;



            (e.Row.FindControl("rdbE_Timeline") as DropDownList).SelectedValue = (e.Row.FindControl("hfE_Timeline") as HiddenField).Value;
        }
    }

    protected void grdE_CounselorRecommendations_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtE_Organization = e.Row.FindControl("txtorganization") as TextBox;
            TextBox txtE_ExtraCurricularActivities = e.Row.FindControl("txtE_ExtraCurricularActivities") as TextBox;
            TextBox txtE_ActivityTitleandOrganization = e.Row.FindControl("txtE_ActivityTitleandOrganization") as TextBox;
            TextBox txtE_HoursWeek = e.Row.FindControl("txtE_HoursWeek") as TextBox;
            TextBox txtE_RoleandResponsibilities = e.Row.FindControl("txtE_RoleandResponsibilities") as TextBox;
            DropDownList rdbE_Timeline = e.Row.FindControl("rdbE_Timeline") as DropDownList;

            txtE_Organization.ReadOnly = true;
            txtE_ExtraCurricularActivities.ReadOnly = true;
            txtE_ActivityTitleandOrganization.ReadOnly = true;
            txtE_HoursWeek.ReadOnly = true;
            txtE_RoleandResponsibilities.ReadOnly = true;
            rdbE_Timeline.Enabled = false;
            (e.Row.FindControl("rdbE_Timeline") as DropDownList).SelectedValue = (e.Row.FindControl("hfE_Timeline") as HiddenField).Value;
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        DataSet vs_dataset = (DataSet)ViewState["vs_dataset"];
        if (vs_dataset.Tables[4].Rows.Count == 0)
        {
            lblerror.Text = "Please Fill  the form Properly";
            lblerror.CssClass = "label label-danger text-center";
            return;
        }
        int iep_id = Convert.ToInt32(vs_dataset.Tables[4].Rows[0]["IEP_Id"]);
        ExecuteProcedure("0", spnErpNo.InnerText, vs_dataset.Tables[4].Rows[0]["IEP_Id"].ToString(), "0", "0", hdE_Class_Id.Value, "IN");

        Email();

    }
    public void Email()
    {

        //DataSet dsE = exec_SP(action: "ACK", Optional1: Batch_Id.Value, Optional2: "1[dbo].[TCS_Result_GenerateResultAll]");
        //dsE.Dispose();
        //if (dsE.Tables.Count > 0 && dsE.Tables[0].Rows.Count > 0)
        //{
        // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
        /*****************EMAIL***************/


        MailMessage mail = new MailMessage();
        var Body = "";
        var To = "";

        var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

        To = ConfigurationManager.AppSettings["Bifurcation_email"].ToString();//lblfatheremail.Text.Trim();
        var Subject = "IEP Acknowledgement";


        //  Body +=  txt_contents.Value;
        /***********HTML TEMPLET***/
        Body += "<body style='margin:0;padding:0;'>";
        Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
        Body += "<tr>";
        Body += "<td align='center' style='padding:0;'>";
        Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
        Body += "<tr>";
        Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2

        //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
        Body += "<img src = 'https://thecityschool.edu.pk/wp-content/uploads/2019/01/tcs-logo-wh.png'>";
        Body += "</td>";
        Body += "</tr>";
        Body += "<tr>";
        Body += "<td style='padding:36px 30px 42px 30px;'>";
        Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
        Body += "<tr>";
        Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
        Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";

        Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>Please find below the link to access your child’s Individual Education Plan. Once you have reviewed it, kindly acknowledge it./p><br/><br/>";



        // Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>I, as a parent / guardian of <strong>" + spnStudentName.InnerText + "</strong> studying in " + spnClass.InnerText + "</p>";

        //  Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press acknowledge button to submit</p>";


        Session["Batch_Id"] = Batch_Id.Value;
        byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["Batch_Id"].ToString());
        string encrypted_batch_Id = Convert.ToBase64String(b);

        string Student_Id = Request.QueryString["s"].ToString();
        Session["Student_Id"] = Student_Id;
        byte[] s = System.Text.ASCIIEncoding.ASCII.GetBytes(Student_Id);
        string encrypted_Student_Id = Convert.ToBase64String(s);
        //---get from request URL
        //http://trainingaims.thecityschool.edu.pk
        //
        var url = "http://www.tcsaims.com/PresentationLayer/tcs/Parent_IEP_Form.aspx?s=" + Student_Id + "&ses=" + Session["Session_Id"].ToString();//ddlStudent.SelectedValue
        Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + url + "'>Click to view the form</a></b></p>";

        Body += "</td>";
        Body += "</tr>";

        Body += "</table>";
        Body += "</td>";
        Body += "</tr>";
        Body += "<tr>";
        Body += "<td style='padding:30px;background:#FBEE26;'>";
        Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
        Body += "<tr>";
        Body += "<td style='padding:0;width:100%;' align='Center'>";
        Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

        Body += "</td>";

        Body += "</tr>";
        Body += "</table>";
        Body += "</td>";
        Body += "</tr>";
        Body += "</table>";
        Body += "</td>";
        Body += "</tr>";
        Body += "</table>";
        Body += "</body>";
        /*****HTML TEMPLET*********/


        //var Password = "Pakistan!@#$";//gmail//"@U13K$@CgMlG";
        var Password = "Jup31963";

        using (MailMessage mm = new MailMessage(Email.Address, To))
        {
            mm.Subject = Subject;
            mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
            //mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

            mm.Body = Body;


            mm.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient())
            {
                // smtp.Host = "smtp.gmail.com"; //"mail.bizar.pk";
                smtp.Host = "10.1.1.120"; //"mail.bizar.pk";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;//587;
                smtp.Timeout = 1000000000;




                try
                {
                    smtp.Send(mm);

                    lblerror.Text = "Email Sent Successfully";
                    lblerror.CssClass = "label label-success text-center";
                }
                catch (SmtpFailedRecipientException ex)
                {
                    lblerror.Text = "Error : " + ex;
                    lblerror.CssClass = "label label-danger text-center";

                }

            }
        }

        /********EMAIL******************/
        //}
        //else
        //{ //ImpromptuHelper.ShowPrompt("No Data Found"); }
        //}
    }

    protected void btn_bifurcation_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + spnErpNo.InnerText + "&C=" + hd_section_id.Value + "&T=" + 1);
    }

    protected void ctrlIntrestCode_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {

            DropDownList DdlInterest_Codes = (e.Item.FindControl("DdlInterest_Code") as DropDownList);
            DdlInterest_Codes.DataSourceID = null;

            DdlInterest_Codes.DataSource = ds.Tables[9];
            DdlInterest_Codes.DataTextField = "Raisec";
            DdlInterest_Codes.DataValueField = "ID";
            DdlInterest_Codes.DataBind();
            DdlInterest_Codes.Items.Insert(0, new ListItem("Please select"));

            if (ds.Tables[1].Columns.Count > 5)
                DdlInterest_Codes.SelectedItem.Text = ds.Tables[1].Rows[e.Item.ItemIndex][4].ToString();


        }
        else
        {


        }


    }
    DataTable ExecuteProcedure(string ID, string Student_id, string Iep_id, string Session_id, string Center_id, string Class_id, string Action)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_iep_acknowledgment");
        obj_Access.AddParameter("ID", ID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Student_id", Student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Iep_id", Iep_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Session_id", Session_id, DataAccess.SQLParameterType.VarChar, true);//
        obj_Access.AddParameter("Center_id", Center_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Class_id", Class_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Action", Action, DataAccess.SQLParameterType.VarChar, true);

        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }



    protected void grdE_SubjectDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        ds.Dispose();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox Weak_Topic_Areastxt = e.Row.FindControl("txtE_Weak_Topic_Areas") as TextBox;
            TextBox Academic_Potentialtxt = e.Row.FindControl("txtE_Academic_Potential") as TextBox;
            TextBox Suggested_Study_Hourstxt = e.Row.FindControl("txtE_Suggested_Study_Hours") as TextBox;
            Weak_Topic_Areastxt.ReadOnly = true;
            Academic_Potentialtxt.ReadOnly = true;
            Suggested_Study_Hourstxt.ReadOnly = true;
            HiddenField field = e.Row.FindControl("hdSubject_Id") as HiddenField;
            for (int i = 0; i < ds.Tables[10].Rows.Count; i++)
            {
                string rowvalue = ds.Tables[10].Rows[i]["Subject_Id"].ToString();
                if (field.Value != rowvalue)
                {
                    e.Row.Enabled = false;
                   
                }
                else
                {
                    e.Row.Enabled = true;
                    break;
                }

                //if (field.Value == ds.Tables[10].Rows[i]["Subject_Id"].ToString())
                //{
                //   // e.Row.Enabled = true;
                //}
                //else
                //{
                //    e.Row.Enabled = false;
                //}
            }

            TextBox txtInput = e.Row.FindControl("txtE_Weak_Topic_Areas") as TextBox;
            TextBox txttxtE_Suggested_Study_Hours = e.Row.FindControl("txtE_Suggested_Study_Hours") as TextBox;
            
            if (txtInput != null)
            {
              //  txtInput.Attributes["onkeyup"] = "javascript:this.value = this.value.substring(0, 120);";

                // Get the client-side ID of the TextBox
                string textBoxClientId = txtInput.ClientID;

                // Register the script to handle the input event for each TextBox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidationScript_" + textBoxClientId,
                    string.Format(@"
                    $(document).ready(function () {{
                        $('#{0}').on('input', function () {{
                            var inputValue = $(this).val();
                            if (inputValue.length > 120) {{
                              Swal.fire(
                                'Maximum 120 characters allowed.',
                                        '',
                        ''
                        )
                               

                                // alert('Maximum 120 characters allowed.');
                                $('#{0}').val(inputValue.substring(0, 120));
                            }} else {{
                             
                            }}
                        }});
                    }});
           
                ", textBoxClientId), true);
            }

            if (txttxtE_Suggested_Study_Hours != null)
            {
                //  txtInput.Attributes["onkeyup"] = "javascript:this.value = this.value.substring(0, 120);";

                // Get the client-side ID of the TextBox
                string txttxtE_Suggested_Study_HoursClientId = txttxtE_Suggested_Study_Hours.ClientID;

                // Register the script to handle the input event for each TextBox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidationScript_" + txttxtE_Suggested_Study_HoursClientId,
                    string.Format(@"
                    $(document).ready(function () {{
                        $('#{0}').on('input', function () {{
                            var inputValue = $(this).val();
                            if (inputValue.length > 120) {{
                              Swal.fire(
                                'Maximum 120 characters allowed.',
                                        '',
                        ''
                        )
                               

                                // alert('Maximum 120 characters allowed.');
                                $('#{0}').val(inputValue.substring(0, 120));
                            }} else {{
                             
                            }}
                        }});
                    }});
           
                ", txttxtE_Suggested_Study_HoursClientId), true);
            }

        }
    }

    protected void grdE_SubjectDetail1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        ds.Dispose();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField field = e.Row.FindControl("hdSubject_Id") as HiddenField;
            for (int i = 0; i < ds.Tables[10].Rows.Count; i++)
            {
                string rowvalue = ds.Tables[10].Rows[i]["Subject_Id"].ToString();
                if (field.Value != rowvalue)
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                    break;
                }

                //if (field.Value == ds.Tables[10].Rows[i]["Subject_Id"].ToString())
                //{
                //   // e.Row.Enabled = true;
                //}
                //else
                //{
                //    e.Row.Enabled = false;
                //}
            }

            TextBox txtInput = e.Row.FindControl("txtE_Weak_Topic_Areas") as TextBox;
            TextBox txttxtE_Suggested_Study_Hours = e.Row.FindControl("txtE_Suggested_Study_Hours") as TextBox;

            if (txtInput != null)
            {
                //  txtInput.Attributes["onkeyup"] = "javascript:this.value = this.value.substring(0, 120);";

                // Get the client-side ID of the TextBox
                string textBoxClientId = txtInput.ClientID;

                // Register the script to handle the input event for each TextBox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidationScript_" + textBoxClientId,
                    string.Format(@"
                    $(document).ready(function () {{
                        $('#{0}').on('input', function () {{
                            var inputValue = $(this).val();
                            if (inputValue.length > 120) {{
                              Swal.fire(
                                'Maximum 120 characters allowed.',
                                        '',
                        ''
                        )
                               

                                // alert('Maximum 120 characters allowed.');
                                $('#{0}').val(inputValue.substring(0, 120));
                            }} else {{
                             
                            }}
                        }});
                    }});
           
                ", textBoxClientId), true);
            }

            if (txttxtE_Suggested_Study_Hours != null)
            {
                //  txtInput.Attributes["onkeyup"] = "javascript:this.value = this.value.substring(0, 120);";

                // Get the client-side ID of the TextBox
                string txttxtE_Suggested_Study_HoursClientId = txttxtE_Suggested_Study_Hours.ClientID;

                // Register the script to handle the input event for each TextBox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidationScript_" + txttxtE_Suggested_Study_HoursClientId,
                    string.Format(@"
                    $(document).ready(function () {{
                        $('#{0}').on('input', function () {{
                            var inputValue = $(this).val();
                            if (inputValue.length > 120) {{
                              Swal.fire(
                                'Maximum 120 characters allowed.',
                                        '',
                        ''
                        )
                               

                                // alert('Maximum 120 characters allowed.');
                                $('#{0}').val(inputValue.substring(0, 120));
                            }} else {{
                             
                            }}
                        }});
                    }});
           
                ", txttxtE_Suggested_Study_HoursClientId), true);
            }

            //HiddenField field = e.Row.FindControl("hdSubject_Id") as HiddenField;
            //if (field.Value == ds.Tables[0].Rows[0]["Subject_Id"].ToString())
            //{

            //}
            //else
            //{
            //    e.Row.Enabled = false;
            //}
        }
    }
}