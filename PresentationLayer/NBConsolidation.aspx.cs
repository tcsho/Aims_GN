using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using City.Library.SQL;
using System.Web;

public partial class PresentationLayer_LoConsolidation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    BLLSiqa objSiqa = new BLLSiqa();
    private DataSet ds = null;
    private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnNbconsolidationexport);
        scriptManager.RegisterPostBackControl(this.btnexportsiqaendorsedgrades);
        try
        {
            if (!Page.IsPostBack)
            {
                //TabName.Value = Request.Form[TabName.UniqueID];
                ScriptManager.RegisterStartupScript(this, GetType(), "SetDefaultTab", "$('.nav-tabs a[href=\"#menu1\"]').tab('show');", true);
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }

                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["moID"].ToString());

             
                     
                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "check";
                // LoadClassSection();

                loadRegions();

                //*****************Group Head******************
                //DataTable dtgrouphead = new DataTable();
                //dtgrouphead = objSiqa.Get_Active_GroupHeads();
                //objBase.FillDropDown(dtgrouphead, ddl_grouphead, "Group_ID", "Group_Name");
                DataTable TermGroups = new DataTable();
                TermGroups = objSiqa.Evaluation_Criteria_TypeFetch();
                objBase.FillDropDown(TermGroups, ddl_grouphead, "TermGroup_Id", "Type");

                //***********************************
                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = false;
                    SiqaEndDiv.Visible = false;
                    //ScriptManager.RegisterStartupScript(this, GetType(), "HideMenu2", "hideMenu2();", true);
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }
                int userid = Convert.ToInt32(row["User_Type_Id"].ToString());
                if (userid == 43)
                {
                    btn_save.Enabled = false;
                    btnUpdateSIQAEndorsed.Enabled = false;
                    btnUpdateAllNbConsolidationData.Enabled = false;
                    btnNbconsolidationexport.Enabled = false;
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    // ddl_center.SelectedValue = row["Center_Id"].ToString();
                    // ddl_center_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                }
                if (userid == 45 || userid == 44)
                {
                    btn_save.Enabled = false;
                    btnUpdateSIQAEndorsed.Enabled = false;
                    btnUpdateAllNbConsolidationData.Enabled = false;
                    btnNbconsolidationexport.Enabled = false;
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                   
                }

            }
            else
            {

                // Get the active tab from the hidden field
                string activeTab = hfActiveTab.Value;

                // Register the script to set the active tab
                string script = "$('.nav-tabs a[href=\"" + activeTab + "\"]').tab('show');";
                ScriptManager.RegisterStartupScript(this, GetType(), "RestoreActiveTab", script, true);

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
            BLLSiqa obj = new BLLSiqa();

            if (ddl_region.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Region", 0);
                return;
            }
            obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

            if (ddl_center.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select School", 0);
                return;
            }
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());

            if (ddlteacher.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Teacher", 0);
                return;
            }
            obj.Teacher_Id = Convert.ToInt32(ddlteacher.SelectedValue.ToString());

            if (ddlclass.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Class", 0);
                return;
            }
            obj.Class_Id = Convert.ToInt32(ddlclass.SelectedValue.ToString());

            if (ddlsubjects.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Subject", 0);
                return;
            }
            obj.Subject_Id = Convert.ToInt32(ddlsubjects.SelectedValue.ToString());

            if (ddl_grouphead.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Term Group", 0);
                return;
            }
            obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());

            if (ddlkeystage.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Key Stage", 0);
                return;
            }
            obj.Keystage_id = ddlkeystage.SelectedValue.ToString();

            if (txtIssuanceDate.Text.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Date", 0);
                return;
            }
            obj.Document_Date = Convert.ToDateTime(txtIssuanceDate.Text.ToString());

            if (ddlsections.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Section", 0);
                return;
            }
            //*********************************************

            if (ddl_QOT_challenging_tasks.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Challenging Tasks", 0);
                return;
            }
            if (ddl_QOT_Variety_of_tasks.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Variety of tasks", 0);
                return;
            }
            if (ddl_QOT_regular_independent_study.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Regular independent study", 0);
                return;
            }
            if (ddl_QOT_regularly_assigned.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Regularly assigned", 0);
                return;
            }
            if (ddl_QOT_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Grade", 0);
                return;
            }

            if (ddl_Assessment_work_checked_promptly.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Work checked promptly", 0);
                return;
            }
            if (ddl_Assessment_errors_identified.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Errors identified", 0);
                return;
            }
            if (ddl_Assessment_dev_comments.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Dev comments", 0);
                return;
            }
            if (ddl_Assessment_assessment_criteria.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Assessment criteria", 0);
                return;
            }
            if (ddl_Assessment_apprec_remarks.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Apprec Remarks", 0);
                return;
            }
            if (ddl_Assessment_self_peer_assessment.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Self/Peer assessment", 0);
                return;
            }
            if (ddl_Assessment_follow_up.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Follow up", 0);
                return;
            }
            if (ddl_Assessment_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Grade", 0);
                return;
            }
            if (ddl_SP_impr_in_work.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Impr in work", 0);
                return;
            }
            if (ddl_SP_responded_to_feedback.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Responded to feedback", 0);
                return;
            }
            if (ddl_SP_suff_gains.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Suff gains", 0);
                return;
            }
            if (ddl_SP_age_appropriate_vocab.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Age-appropriate vocab", 0);
                return;
            }
            if (ddl_SP_independence.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Independence", 0);
                return;
            }
            if (ddl_SP_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade", 0);
                return;
            }
            //*****************************
            if (ddl_WP_organised.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Organised", 0);
                return;
            }
            if (ddl_WP_neat.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Neat", 0);
                return;
            }
            if (ddl_WP_legible_handwriting.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Legible handwriting", 0);
                return;
            }
            if (ddl_WP_indices_filled.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Indices filled", 0);
                return;
            }
            if (ddl_WP_indices_signed_teachers.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Indices signed Teachers", 0);
                return;
            }
            if (ddl_WP_indices_signed_parents.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Indices signed Parents", 0);
                return;
            }
            if (ddl_WP_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade", 0);
                return;
            }
            if (ddl_WP_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade", 0);
                return;
            }

            if (ddl_overall_grade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Overall Grade", 0);
                return;
            }

            obj.Section_id = Convert.ToInt32(ddlsections.SelectedValue.ToString());

            obj.QOT_challenging_tasks = ddl_QOT_challenging_tasks.SelectedValue.ToString();
            obj.QOT_Variety_of_tasks = ddl_QOT_Variety_of_tasks.SelectedValue.ToString();
            obj.QOT_regular_independent_study = ddl_QOT_regular_independent_study.SelectedValue.ToString();
            obj.QOT_regularly_assigned = ddl_QOT_regularly_assigned.SelectedValue.ToString();
            obj.QOT_grade = ddl_QOT_grade.SelectedValue.ToString();

            obj.Assessment_work_checked_promptly = ddl_Assessment_work_checked_promptly.SelectedValue.ToString();
            obj.Assessment_errors_identified = ddl_Assessment_errors_identified.SelectedValue.ToString();
            obj.Assessment_dev_comments = ddl_Assessment_dev_comments.SelectedValue.ToString();
            obj.Assessment_assessment_criteria = ddl_Assessment_assessment_criteria.SelectedValue.ToString();
            obj.Assessment_apprec_remarks = ddl_Assessment_apprec_remarks.SelectedValue.ToString();
            obj.Assessment_self_peer_assessment = ddl_Assessment_self_peer_assessment.SelectedValue.ToString();
            obj.Assessment_follow_up = ddl_Assessment_follow_up.SelectedValue.ToString();
            obj.Assessment_grade = ddl_Assessment_grade.SelectedValue.ToString();

            obj.SP_impr_in_work = ddl_SP_impr_in_work.SelectedValue.ToString();
            obj.SP_responded_to_feedback = ddl_SP_responded_to_feedback.SelectedValue.ToString();
            obj.SP_suff_gains = ddl_SP_suff_gains.SelectedValue.ToString();
            obj.SP_age_appropriate_vocab = ddl_SP_age_appropriate_vocab.SelectedValue.ToString();
            obj.SP_independence = ddl_SP_independence.SelectedValue.ToString();
            obj.SP_grade = ddl_SP_grade.SelectedValue.ToString();

            obj.WP_organised = ddl_WP_organised.SelectedValue.ToString();
            obj.WP_neat = ddl_WP_neat.SelectedValue.ToString();
            obj.WP_legible_handwriting = ddl_WP_legible_handwriting.SelectedValue.ToString();
            obj.WP_indices_filled = ddl_WP_indices_filled.SelectedValue.ToString();
            obj.WP_indices_signed_teachers = ddl_WP_indices_signed_teachers.SelectedValue.ToString();
            obj.WP_indices_signed_parents = ddl_WP_indices_signed_parents.SelectedValue.ToString();
            obj.WP_grade = ddl_WP_grade.SelectedValue.ToString();

            obj.overall_grade = ddl_overall_grade.SelectedValue.ToString();
            obj.EBI1 = "";//txtEBI1.Text.ToString();
            obj.EBI2 = "";//txtEBI2.Text.ToString();
            obj.EBI3 = "";//txtEBI3.Text.ToString();

            obj.CreateBy = Session["ContactID"].ToString();
            int result = obj.NB_Consolidation_Insert(obj);
            if (result == 1)
            {
                Clear_Data();
                BindGrid();
                cal_Overall_grades();
                cal_Overall_grades_Center();
                ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");

            }

            // BindGrid();
            // Response.Redirect("~/PresentationLayer/LoConsolidation.aspx");
            // Response.Redirect("~/PresentationLayer/TCS/LmsStudentDropbox.aspx");

            obj = null;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }






    }
    //protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (List_ClassSection.SelectedValue != "")
    //        {
    //            LoadSubject();
    //            LoadTerm();
    //            ViewState["Grid"] = null;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}


    //protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (list_Term.SelectedValue != "")
    //        {
    //            ViewState["Grid"] = null;
    //            BindGrid();   --check

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}

    private void BindGrid()
    {
        try
        {
            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            DataRow row = (DataRow)Session["rightsRow"];
            BLLSiqa objhistorydata = new BLLSiqa();
            DataTable dthistory = new DataTable();
            if (ddl_region.SelectedValue.ToString() != "0")
            {
                Session["Region_Id"] = ddl_region.SelectedValue.ToString();
            }
            if (ddl_center.SelectedValue.ToString() != "0")
            {
                Session["Center_Id"] = ddl_center.SelectedValue.ToString();
            }
            if (ddlkeystage.SelectedValue.ToString() != "")
            {
                Session["Keystage_id"] = ddlkeystage.SelectedItem.Text.ToString();
            }

            dt = objdata.NB_Consolidation_Search(
                ddl_region.SelectedValue.ToString(),
                ddl_center.SelectedValue.ToString(),
                ddlteacher.SelectedValue.ToString(),
                ddlclass.SelectedValue.ToString(),
                ddlsubjects.SelectedValue.ToString(),
                ddl_grouphead.SelectedValue.ToString(),
                ddlkeystage.SelectedValue.ToString()
                );
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gvNbConsolidation.DataSource = dt;
                    gvNbConsolidation.DataBind();
                }
                else
                {
                    gvNbConsolidation.DataSource = null;
                    gvNbConsolidation.DataBind();

                }
            }
            else
            {
                gvNbConsolidation.DataSource = null;
                gvNbConsolidation.DataBind();
            }
            int userid = Convert.ToInt32(row["User_Type_Id"].ToString());
            if (userid == 45 || userid == 43 || userid == 44)
            {
                foreach (GridViewRow gridRow in gvNbConsolidation.Rows)
                {
                    CheckBox gv_chkbx_campus_head = gridRow.FindControl("gv_chkbx_campus_head") as CheckBox;
                    if (gv_chkbx_campus_head != null)
                    {
                        gv_chkbx_campus_head.Enabled = false;
                    }

                    Button btnUpdate = gridRow.FindControl("btnUpdateNbConsolidationData") as Button;
                    if (btnUpdate != null)
                    {
                        // Disable the button based on your condition, or always
                        btnUpdate.Enabled = false; // Always disable for demonstration
                    }
                }
            }
               

            //**********************************Nb consolidation History*****************************
            dthistory = objdata.Search_Nb_Consolidated_History(
               ddl_region.SelectedValue.ToString(),
               ddl_center.SelectedValue.ToString(),
               ddlteacher.SelectedValue.ToString(),
               ddlclass.SelectedValue.ToString(),
               ddlsubjects.SelectedValue.ToString(),
               ddl_grouphead.SelectedValue.ToString(),
               ddlkeystage.SelectedValue.ToString()
               );
            if (dthistory != null)
            {
                if (dthistory.Rows.Count > 0)
                {
                    gvnbconsolidationhistory.DataSource = dthistory;
                    gvnbconsolidationhistory.DataBind();
                }
                else
                {
                    gvnbconsolidationhistory.DataSource = null;
                    gvnbconsolidationhistory.DataBind();

                }
            }
            else
            {
                gvnbconsolidationhistory.DataSource = null;
                gvnbconsolidationhistory.DataBind();
            }

            //***************************************************************************************


        
            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
            {
                gvNbConsolidation.Columns[37].Visible = false;
                gvNbConsolidation.Columns[38].Visible = false;
            }
            else
            {
                gvNbConsolidation.Columns[37].Visible = true;
                gvNbConsolidation.Columns[38].Visible = true;
            }


            //DataRow row1 = (DataRow)Session["rightsRow"];
            //if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "HideMenu2", "hideMenu2();", true);
            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void gvRegStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }

    protected void chkAbsent_OnCheckedChanged(Object sender, EventArgs e)
    {




    }


    private void loadRegions()
    {
        try
        {
            string q = Request.QueryString["id"];
            string s = Request.QueryString["id"];
            if (Convert.ToInt32(s) == 92 || Convert.ToInt32(s) > 92 || Convert.ToInt32(s) == 97 || Convert.ToInt32(s) < 97)
            {
                //lab_center.Text = "School*: ";
            }

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            // BindCheckBoxListControl(dt, lstRegion, "Region_Id", "Region_Name");
            ////////////UserInformationGrid2.SetData(dt);
            ///

            DataTable DT = ExecuteProcedure("CS", "0", ddl_region.SelectedValue);

            if (DT.Rows.Count > 0)
            {
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void loadCenter()
    {
        try
        {
            //ddlClass.Items.Clear();
            //list_Subject.Items.Clear();
            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            //if (ddlSession.SelectedIndex > 0)
            //{
            //    objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            //}
            //else
            //{
            //    objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            //}
            objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            // BindCheckBoxListControl(dt, lstCenter, "Center_Id", "Center_Name");

            DataRow row = (DataRow)Session["rightsRow"];

            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
            {
                ddl_center.SelectedValue = row["Center_Id"].ToString();
            }

            //////////UserInformationGrid3.SetData(dt);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlTerm.SelectedIndex == 0 || list_Subject.SelectedIndex == 0 || ddlClass.SelectedIndex == 0 || ddl_center.SelectedIndex == 0)
            //{
            //    ViewState["Grid"] = null;
            //    BindGrid();
            //}
            loadCenter();
            //BindGrid();
            //cal_Overall_grades();

            DataTable DT = ExecuteProcedure("CS", "0", ddl_region.SelectedValue);

            if (DT.Rows.Count > 0)
            {
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtclass = new DataTable();
            DataRow row = (DataRow)Session["rightsRow"];
            if (Convert.ToBoolean(row["Center"].ToString()) != true)
            {
                BLLClass objCS = new BLLClass();
                objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                dtclass = objCS.ClassFetch(objCS);
                objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");
            }
            else
            {
                BLLClass_Center objCC = new BLLClass_Center();
                DataRow rrow = (DataRow)Session["rightsRow"];
                objCC.Center_ID = Convert.ToInt32(rrow["Center_Id"].ToString());
                dtclass = objCC.Class_CenterFetch(objCC);
                objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");
            }
            LoadTeachers();
            BindGrid();
            cal_Overall_grades();
            cal_Overall_grades_Center();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
            //FillClass();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    //**************************************************
    private void LoadTeachers()
    {
        try
        {
            BLLClass_Section obj = new BLLClass_Section();
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            DataTable dt = (DataTable)obj.Employee_ProfileByCenterId(obj);
            objBase.FillDropDown(dt, ddlteacher, "Employee_Id", "FullName");



            //SR Work
            BLLSiqa siqaobj = new BLLSiqa();
            siqaobj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            DataTable dtteacherList = (DataTable)siqaobj.TeacherList_ProfileByCenterId_NBConsolidation(siqaobj);
            //ViewState["Teachers"] = dt;

            gvNB_C_TeacherList.DataSource = dtteacherList;
            gvNB_C_TeacherList.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

   



    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            DataTable DT = ExecuteProcedure("CS", ddlclass.SelectedValue, ddl_region.SelectedValue);

            if (DT.Rows.Count > 0)
            {
                DT.Rows.Add(99999, "Portfolio");
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            }
            else
            {
                DT = null;
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");
            }
           
            DataTable dtsections = objSiqa.Get_Sections(int.Parse(ddl_center.SelectedValue), int.Parse(ddlclass.SelectedValue));
            if (dtsections.Rows.Count > 0)
            {
                objBase.FillDropDown(dtsections, ddlsections, "Section_Id", "Section_Name");

            }
            DT = null;
            BindGrid();
            cal_Overall_grades();
            cal_Overall_grades_Center();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void gvNbConsolidation_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNbConsolidation.Rows.Count > 0)
            {
                gvNbConsolidation.UseAccessibleHeader = false;
                gvNbConsolidation.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void ddl_grouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        cal_Overall_grades();
        cal_Overall_grades_Center();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvNbConsolidation.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hiddenField = row.FindControl("HiddenField1") as HiddenField;
                if (hiddenField != null)
                {
                    string hiddenFieldValue = hiddenField.Value;
                }
                }
        }
    }


    public void Clear_Data()
    {
        //this.ddl_region.SelectedIndex = -1;
        //this.ddl_center.SelectedIndex = -1;
        this.ddlteacher.SelectedIndex = -1;
        //this.ddl_grouphead.SelectedIndex = -1;
        this.ddlclass.SelectedIndex = -1;
        this.ddlsubjects.SelectedIndex = -1;
        this.ddlsections.SelectedIndex = -1;
        //this.ddlkeystage.SelectedIndex = -1;
        this.ddl_QOT_challenging_tasks.SelectedIndex = -1;
        this.ddl_QOT_Variety_of_tasks.SelectedIndex = -1;
        this.ddl_QOT_regular_independent_study.SelectedIndex = -1;
        this.ddl_QOT_regularly_assigned.SelectedIndex = -1;
        this.ddl_QOT_grade.SelectedIndex = -1;
        this.ddl_Assessment_work_checked_promptly.SelectedIndex = -1;
        this.ddl_Assessment_errors_identified.SelectedIndex = -1;
        this.ddl_Assessment_dev_comments.SelectedIndex = -1;
        this.ddl_Assessment_assessment_criteria.SelectedIndex = -1;
        this.ddl_Assessment_apprec_remarks.SelectedIndex = -1;
        this.ddl_Assessment_self_peer_assessment.SelectedIndex = -1;
        this.ddl_Assessment_follow_up.SelectedIndex = -1;
        this.ddl_Assessment_grade.SelectedIndex = -1;
        this.ddl_SP_impr_in_work.SelectedIndex = -1;
        this.ddl_SP_responded_to_feedback.SelectedIndex = -1;
        this.ddl_SP_suff_gains.SelectedIndex = -1;
        this.ddl_SP_age_appropriate_vocab.SelectedIndex = -1;
        this.ddl_SP_independence.SelectedIndex = -1;
        this.ddl_SP_grade.SelectedIndex = -1;
        this.ddl_WP_organised.SelectedIndex = -1;
        this.ddl_WP_neat.SelectedIndex = -1;
        this.ddl_WP_legible_handwriting.SelectedIndex = -1;
        this.ddl_WP_indices_filled.SelectedIndex = -1;
        this.ddl_WP_indices_signed_teachers.SelectedIndex = -1;
        this.ddl_WP_indices_signed_parents.SelectedIndex = -1;
        this.ddl_WP_grade.SelectedIndex = -1;
        this.ddl_overall_grade.SelectedIndex = -1;
        //this.txtEBI1.Text = "";
        //this.txtEBI2.Text = "";
        //this.txtEBI3.Text = "";
    }
    protected void btnUpdateAllNbConsolidationData_Click(object sender, EventArgs e)
    {
        try
        {
            

            //GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            foreach (GridViewRow row in gvNbConsolidation.Rows)
            {
                BLLSiqa obj = new BLLSiqa();
                if (row.RowType == DataControlRowType.DataRow)
                {

                    obj.QOT_challenging_tasks = ((DropDownList)row.FindControl("gv_ddl_QOT_challenging_tasks")).SelectedValue;
                    obj.QOT_Variety_of_tasks = ((DropDownList)row.FindControl("gv_ddl_QOT_Variety_of_tasks")).SelectedValue;
                    obj.QOT_regular_independent_study = ((DropDownList)row.FindControl("gv_ddl_QOT_regular_independent_study")).SelectedValue;
                    obj.QOT_regularly_assigned = ((DropDownList)row.FindControl("gv_ddl_QOT_regularly_assigned")).SelectedValue;
                    obj.QOT_grade = ((DropDownList)row.FindControl("gv_ddl_QOT_grade")).SelectedValue;

                    obj.Assessment_work_checked_promptly = ((DropDownList)row.FindControl("gv_ddl_Assessment_work_checked_promptly")).SelectedValue;
                    obj.Assessment_errors_identified = ((DropDownList)row.FindControl("gv_ddl_Assessment_errors_identified")).SelectedValue;
                    obj.Assessment_dev_comments = ((DropDownList)row.FindControl("gv_ddl_Assessment_dev_comments")).SelectedValue;
                    obj.Assessment_assessment_criteria = ((DropDownList)row.FindControl("gv_ddl_Assessment_assessment_criteria")).SelectedValue;
                    obj.Assessment_apprec_remarks = ((DropDownList)row.FindControl("gv_ddl_Assessment_apprec_remarks")).SelectedValue;
                    obj.Assessment_self_peer_assessment = ((DropDownList)row.FindControl("gv_ddl_Assessment_self_peer_assessment")).SelectedValue;
                    obj.Assessment_follow_up = ((DropDownList)row.FindControl("gv_ddl_Assessment_follow_up")).SelectedValue;
                    obj.Assessment_grade = ((DropDownList)row.FindControl("gv_ddl_Assessment_grade")).SelectedValue;

                    obj.SP_impr_in_work = ((DropDownList)row.FindControl("gv_ddl_SP_impr_in_work")).SelectedValue;
                    obj.SP_responded_to_feedback = ((DropDownList)row.FindControl("gv_ddl_SP_responded_to_feedback")).SelectedValue;
                    obj.SP_suff_gains = ((DropDownList)row.FindControl("gv_ddl_SP_suff_gains")).SelectedValue;
                    obj.SP_age_appropriate_vocab = ((DropDownList)row.FindControl("gv_ddl_SP_age_appropriate_vocab")).SelectedValue;
                    obj.SP_independence = ((DropDownList)row.FindControl("gv_ddl_SP_independence")).SelectedValue;
                    obj.SP_grade = ((DropDownList)row.FindControl("gv_ddl_SP_grade")).SelectedValue;

                    obj.WP_organised = ((DropDownList)row.FindControl("gv_ddl_WP_organised")).SelectedValue;
                    obj.WP_neat = ((DropDownList)row.FindControl("gv_ddl_WP_neat")).SelectedValue;
                    obj.WP_legible_handwriting = ((DropDownList)row.FindControl("gv_ddl_WP_legible_handwriting")).SelectedValue;
                    obj.WP_indices_filled = ((DropDownList)row.FindControl("gv_ddl_WP_indices_filled")).SelectedValue;
                    obj.WP_indices_signed_teachers = ((DropDownList)row.FindControl("gv_ddl_WP_indices_signed_teachers")).SelectedValue;
                    obj.WP_indices_signed_parents = ((DropDownList)row.FindControl("gv_ddl_WP_indices_signed_parents")).SelectedValue;
                    obj.WP_grade = ((DropDownList)row.FindControl("gv_ddl_WP_grade")).SelectedValue;

                    obj.overall_grade = ((DropDownList)row.FindControl("gv_ddl_overall_grade")).SelectedValue;

                    obj.EBI1 = ((TextBox)row.FindControl("gv_txtbx_EBI1")).Text;
                    obj.EBI2 = ((TextBox)row.FindControl("gv_txtbx_EBI2")).Text;
                    obj.EBI3 = ((TextBox)row.FindControl("gv_txtbx_EBI3")).Text;
                    obj.Siqa_Endorsed = ((DropDownList)row.FindControl("gv_ddl_Siqa_EndorsedValue")).SelectedValue;
                    obj.Consolidatio_Id = Convert.ToInt32(((HiddenField)row.FindControl("gvHfConsolidation_IdValue")).Value);

                    BLLSiqa objdata = new BLLSiqa();
                    DataTable dt = new DataTable();
                    dt = objdata.Get_Value_Basedon_Nbconsolidationid(obj.Consolidatio_Id);


                    // Session["Region_Id"] = clickedRow.Cells[38].Text == "&nbsp;" ? "" : clickedRow.Cells[38].Text;
                    // Session["Center_Id"] = clickedRow.Cells[39].Text == "&nbsp;" ? "" : clickedRow.Cells[39].Text;
                    // Session["Keystage_id"] = clickedRow.Cells[40].Text == "&nbsp;" ? "" : clickedRow.Cells[40].Text;

                    obj.UpdateBy = Session["ContactID"].ToString();
                    int result = obj.NB_Consolidation_Update(obj);
                    if (result == 1)
                    {
                        //obj.Exec_NB_Formulas(Session["Region_Id"].ToString(), Session["Center_Id"].ToString(), Session["Keystage_id"].ToString());
                        obj.Exec_NB_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                        //Create History
                        if (obj.Siqa_Endorsed == "YES")
                        {
                            obj.Nb_consolidation_History(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                        }
                        BindGrid();
                        cal_Overall_grades();
                        cal_Overall_grades_Center();
                        ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
                    }
                    obj = null;
                    dt = null;
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SetActiveTab();", true);
           
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnUpdateNbConsolidationData_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSiqa obj = new BLLSiqa();

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            
            obj.QOT_challenging_tasks = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_QOT_challenging_tasks")).SelectedValue;
            obj.QOT_Variety_of_tasks = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_QOT_Variety_of_tasks")).SelectedValue;
            obj.QOT_regular_independent_study = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_QOT_regular_independent_study")).SelectedValue;
            obj.QOT_regularly_assigned = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_QOT_regularly_assigned")).SelectedValue;
            obj.QOT_grade = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_QOT_grade")).SelectedValue;

            obj.Assessment_work_checked_promptly = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_work_checked_promptly")).SelectedValue;
            obj.Assessment_errors_identified = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_errors_identified")).SelectedValue;
            obj.Assessment_dev_comments = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_dev_comments")).SelectedValue;
            obj.Assessment_assessment_criteria = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_assessment_criteria")).SelectedValue;
            obj.Assessment_apprec_remarks = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_apprec_remarks")).SelectedValue;
            obj.Assessment_self_peer_assessment = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_self_peer_assessment")).SelectedValue;
            obj.Assessment_follow_up = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_follow_up")).SelectedValue;
            obj.Assessment_grade = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Assessment_grade")).SelectedValue;

            obj.SP_impr_in_work = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_impr_in_work")).SelectedValue;
            obj.SP_responded_to_feedback = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_responded_to_feedback")).SelectedValue;
            obj.SP_suff_gains = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_suff_gains")).SelectedValue;
            obj.SP_age_appropriate_vocab = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_age_appropriate_vocab")).SelectedValue;
            obj.SP_independence = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_independence")).SelectedValue;
            obj.SP_grade = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_SP_grade")).SelectedValue;

            obj.WP_organised = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_organised")).SelectedValue;
            obj.WP_neat = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_neat")).SelectedValue;
            obj.WP_legible_handwriting = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_legible_handwriting")).SelectedValue;
            obj.WP_indices_filled = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_indices_filled")).SelectedValue;
            obj.WP_indices_signed_teachers = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_indices_signed_teachers")).SelectedValue;
            obj.WP_indices_signed_parents = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_indices_signed_parents")).SelectedValue;
            obj.WP_grade = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_WP_grade")).SelectedValue;

            obj.overall_grade = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_overall_grade")).SelectedValue;

            obj.EBI1 = ((TextBox)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_txtbx_EBI1")).Text;
            obj.EBI2 = ((TextBox)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_txtbx_EBI2")).Text;
            obj.EBI3 = ((TextBox)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_txtbx_EBI3")).Text;
            obj.Siqa_Endorsed = ((DropDownList)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_ddl_Siqa_EndorsedValue")).SelectedValue;
            obj.Consolidatio_Id = Convert.ToInt32(((HiddenField)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gvHfConsolidation_IdValue")).Value);

            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            dt = objdata.Get_Value_Basedon_Nbconsolidationid(obj.Consolidatio_Id);


            // Session["Region_Id"] = clickedRow.Cells[38].Text == "&nbsp;" ? "" : clickedRow.Cells[38].Text;
            // Session["Center_Id"] = clickedRow.Cells[39].Text == "&nbsp;" ? "" : clickedRow.Cells[39].Text;
            // Session["Keystage_id"] = clickedRow.Cells[40].Text == "&nbsp;" ? "" : clickedRow.Cells[40].Text;

            obj.UpdateBy = Session["ContactID"].ToString();
            int result = obj.NB_Consolidation_Update(obj);
            if (result == 1)
            {
                //obj.Exec_NB_Formulas(Session["Region_Id"].ToString(), Session["Center_Id"].ToString(), Session["Keystage_id"].ToString());
                obj.Exec_NB_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                //Create History
                if (obj.Siqa_Endorsed == "YES")
                {
                    obj.Nb_consolidation_History(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                }
                BindGrid();
                cal_Overall_grades();
                cal_Overall_grades_Center();
                ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
            }
            obj = null;
            dt = null;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SetActiveTab();", true);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        cal_Overall_grades();
        cal_Overall_grades_Center();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
    }
    protected void ddl_QOT_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_Assessment_grade.SelectedItem.Text == "OS" && ddl_SP_grade.SelectedItem.Text == "OS" && 
        //    (ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "OS") &&
        //    (ddl_QOT_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "G"))
        //{
        //    ddl_overall_grade.SelectedIndex = 1;
        //}

        //else if ((ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS")  && 
        //     (ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //    ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G")) &&
        //    (ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A"))
        //{
        //    ddl_overall_grade.SelectedIndex = 2;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "A" || ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS" ) &&
        //   (ddl_SP_grade.SelectedItem.Text == "A" ||  ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //  ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G" || ddl_QOT_grade.SelectedItem.Text == "A") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "A")) 
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 3;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_SP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_QOT_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA")
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  //
        //  //ddl_Assessment_grade  ddl_SP_grade  ddl_QOT_grade ddl_WP_grade
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 4;
        //}
        //else
        //{
        //    ddl_overall_grade.SelectedIndex = 5;
        //}
    }

    protected void ddl_Assessment_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        grade_overall_cal();

        //if (ddl_Assessment_grade.SelectedItem.Text == "OS" && ddl_SP_grade.SelectedItem.Text == "OS" &&
        //    (ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "OS") &&
        //    (ddl_QOT_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "G"))
        //{
        //    ddl_overall_grade.SelectedIndex = 1;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //    (ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //   ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G")) &&
        //   (ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A"))
        //{
        //    ddl_overall_grade.SelectedIndex = 2;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "A" || ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //   (ddl_SP_grade.SelectedItem.Text == "A" || ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //  ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G" || ddl_QOT_grade.SelectedItem.Text == "A") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "A"))
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 3;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_SP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_QOT_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA")
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  //
        //  //ddl_Assessment_grade  ddl_SP_grade  ddl_QOT_grade ddl_WP_grade
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 4;
        //}
        ////else if ((ddl_Assessment_grade.SelectedItem.Text == "UA") &&
        ////   (ddl_SP_grade.SelectedItem.Text == "UA") &&
        ////  (ddl_QOT_grade.SelectedItem.Text == "UA" || ddl_WP_grade.SelectedItem.Text == "UA")
        ////  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        ////  )
        ////{
        ////    ddl_overall_grade.SelectedIndex = 4;
        ////}
        //else
        //{
        //    ddl_overall_grade.SelectedIndex = 5;
        //}
    }
  

    protected void ddl_SP_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        grade_overall_cal();
        //if (ddl_Assessment_grade.SelectedItem.Text == "OS" && ddl_SP_grade.SelectedItem.Text == "OS" &&
        //    (ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "OS") &&
        //    (ddl_QOT_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "G"))
        //{
        //    ddl_overall_grade.SelectedIndex = 1;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //    (ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //   ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G")) &&
        //   (ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A"))
        //{
        //    ddl_overall_grade.SelectedIndex = 2;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "A" || ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //   (ddl_SP_grade.SelectedItem.Text == "A" || ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //  ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G" || ddl_QOT_grade.SelectedItem.Text == "A") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "A"))
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 3;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_SP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_QOT_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA")
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  //
        //  //ddl_Assessment_grade  ddl_SP_grade  ddl_QOT_grade ddl_WP_grade
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 4;
        //}
        //else
        //{
        //    ddl_overall_grade.SelectedIndex = 5;
        //}
    }

    protected void ddl_WP_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_Assessment_grade.SelectedItem.Text == "OS" && ddl_SP_grade.SelectedItem.Text == "OS" &&
        //    (ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "OS") &&
        //    (ddl_QOT_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "G"))
        //{
        //    ddl_overall_grade.SelectedIndex = 1;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //    (ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //   ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G")) &&
        //   (ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A"))
        //{
        //    ddl_overall_grade.SelectedIndex = 2;
        //}
        //else if ((ddl_Assessment_grade.SelectedItem.Text == "A" || ddl_Assessment_grade.SelectedItem.Text == "G" || ddl_Assessment_grade.SelectedItem.Text == "OS") &&
        //   (ddl_SP_grade.SelectedItem.Text == "A" || ddl_SP_grade.SelectedItem.Text == "OS" || ddl_SP_grade.SelectedItem.Text == "G") &&
        //  ((ddl_QOT_grade.SelectedItem.Text == "OS" || ddl_QOT_grade.SelectedItem.Text == "G" || ddl_QOT_grade.SelectedItem.Text == "A") || (ddl_WP_grade.SelectedItem.Text == "OS" || ddl_WP_grade.SelectedItem.Text == "G" || ddl_WP_grade.SelectedItem.Text == "A"))
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 3;
        //}

        //else if ((ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_SP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_Assessment_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_QOT_grade.SelectedItem.Text == "UA") ||
        //    (ddl_SP_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA") ||
        //    (ddl_QOT_grade.SelectedItem.Text == "UA") && (ddl_WP_grade.SelectedItem.Text == "UA")
        //  //(ddl_QOT_grade.SelectedItem.Text == "A" || ddl_WP_grade.SelectedItem.Text == "A")
        //  //
        //  //ddl_Assessment_grade  ddl_SP_grade  ddl_QOT_grade ddl_WP_grade
        //  )
        //{
        //    ddl_overall_grade.SelectedIndex = 4;
        //}
        //else
        //{
        //    ddl_overall_grade.SelectedIndex = 5;
        //}
    }

    protected void ddlsubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        cal_Overall_grades();
        cal_Overall_grades_Center();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
    }

    protected void gv_chkbx_campus_head_CheckedChanged(object sender, EventArgs e)
    {
        BLLSiqa obj = new BLLSiqa();
        GridViewRow clickedRow = ((CheckBox)sender).NamingContainer as GridViewRow;
        int consolidatio_id = Convert.ToInt32(((HiddenField)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gvHfConsolidation_IdValue")).Value);
        bool chkbx_v = ((CheckBox)gvNbConsolidation.Rows[clickedRow.RowIndex].FindControl("gv_chkbx_campus_head")).Checked;
        string updated_by = Session["ContactID"].ToString();
        int result = obj.NB_Consolidation_campus_head_operation(consolidatio_id, chkbx_v, updated_by);
        if (result == 1)
        {
            //BindGrid();
            //ImpromptuHelper.ShowPrompt("Record Updated Successfuly");

            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            //dt = objdata.Get_Value_Basedon_Loconsolidationid(consolidatio_id); Get_Value_Basedon_Nbconsolidationid
            dt = objdata.Get_Value_Basedon_Nbconsolidationid(consolidatio_id);
            obj.UpdateBy = Session["ContactID"].ToString();
            obj.Exec_NB_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
            BindGrid();
            cal_Overall_grades();
            cal_Overall_grades_Center();
            ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
        }
        obj = null;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SetActiveTab();", true);
    }

    protected void ddlkeystage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtclass = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        string Group_ID = "0";
        string Class_ID = "";
        if (ddlkeystage.SelectedValue == "EYFS")
        {
            Group_ID = "1";
            Class_ID = "2,3,4";
        }
        if (ddlkeystage.SelectedValue == "KS1")
        {
            Group_ID = "2";
            Class_ID = "5,6";
        }
        if (ddlkeystage.SelectedValue == "KS2")
        {
            Group_ID = "3";
            Class_ID = "7,8,9";
        }
        if (ddlkeystage.SelectedValue == "KS3")
        {
            Group_ID = "4";
            Class_ID = "10,11,12";
        }
        if (ddlkeystage.SelectedValue == "KS4" && ddl_region.SelectedValue != "30000000")
        {
            Group_ID = "5";
            Class_ID = "14,15";
        }
        else if (ddlkeystage.SelectedValue == "KS4" && ddl_region.SelectedValue == "30000000")
        {
            Group_ID = "5";
            Class_ID = "91,92,93";
        }
        if (ddlkeystage.SelectedValue == "KS5" && ddl_region.SelectedValue != "30000000")
        {
            Group_ID = "6";
            Class_ID = "19,20";
        }
        else if (ddlkeystage.SelectedValue == "KS5" && ddl_region.SelectedValue == "30000000")
        {
            Group_ID = "6";
            Class_ID = "91,92,93";
        }
        if (ddlkeystage.SelectedValue == "Matric")
        {
            Group_ID = "7";
            Class_ID = "17,18";
        }
        dtclass = obj.Get_Classes_Basedon_Keystage(Group_ID);
        objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");

        DataTable dtsubjects = ExecuteProcedure("CS", Class_ID, ddl_region.SelectedValue);
        if(dtsubjects.Rows.Count >0)
        {
            objBase.FillDropDown(dtsubjects, ddlsubjects, "Subject_ID", "Subject_Name");
        }
        else
        {
            dtsubjects = null;
            objBase.FillDropDown(dtsubjects, ddlsubjects, "Subject_ID", "Subject_Name");
        }
        
        BindGrid();
        cal_Overall_grades();
        cal_Overall_grades_Center();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
    }

    protected void gvNbConsolidation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass += " frozen-column frozen-column-1";
            e.Row.Cells[1].CssClass += " frozen-column frozen-column-2";
            e.Row.Cells[2].CssClass += " frozen-column frozen-column-3";
            e.Row.Cells[3].CssClass += " frozen-column frozen-column-4";
            e.Row.Cells[4].CssClass += " frozen-column frozen-column-5";
            //if (e.Row.RowIndex == 0)
            //    e.Row.Style.Add("height", "100px");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Retrieve the user level from the session
            DataRow row = (DataRow)Session["rightsRow"];
            int userLevel = Convert.ToInt32(row["User_Type_Id"].ToString());

            // Check if the user level is 3
            if (userLevel == 3)
            {
                // Loop through all cells in the row
                foreach (TableCell cell in e.Row.Cells)
                {
                    // Find the DropDownList controls within the cell
                    DropDownList ddl = cell.FindControl("gv_ddl_QOT_challenging_tasks") as DropDownList;

                    DropDownList ddl1 = cell.FindControl("gv_ddl_QOT_Variety_of_tasks") as DropDownList;
                    DropDownList ddl2 = cell.FindControl("gv_ddl_QOT_regular_independent_study") as DropDownList;
                    DropDownList ddl3 = cell.FindControl("gv_ddl_QOT_regularly_assigned") as DropDownList;
                    DropDownList ddl4 = cell.FindControl("gv_ddl_QOT_grade") as DropDownList;
                    DropDownList ddl5 = cell.FindControl("gv_ddl_Assessment_work_checked_promptly") as DropDownList;
                    DropDownList ddl6 = cell.FindControl("gv_ddl_Assessment_errors_identified") as DropDownList;
                    DropDownList ddl7 = cell.FindControl("gv_ddl_Assessment_dev_comments") as DropDownList;
                    DropDownList ddl8 = cell.FindControl("gv_ddl_Assessment_assessment_criteria") as DropDownList;
                    DropDownList ddl9 = cell.FindControl("gv_ddl_Assessment_apprec_remarks") as DropDownList;
                    DropDownList ddl10 = cell.FindControl("gv_ddl_Assessment_self_peer_assessment") as DropDownList;
                    DropDownList ddl11 = cell.FindControl("gv_ddl_Assessment_follow_up") as DropDownList;
                    DropDownList ddl12 = cell.FindControl("gv_ddl_Assessment_grade") as DropDownList;
                    DropDownList ddl13 = cell.FindControl("gv_ddl_SP_impr_in_work") as DropDownList;
                    DropDownList ddl14 = cell.FindControl("gv_ddl_SP_responded_to_feedback") as DropDownList;

                    DropDownList ddl15 = cell.FindControl("gv_ddl_SP_suff_gains") as DropDownList;
                    DropDownList ddl16 = cell.FindControl("gv_ddl_SP_age_appropriate_vocab") as DropDownList;
                    DropDownList ddl17 = cell.FindControl("gv_ddl_SP_independence") as DropDownList;
                    DropDownList ddl18 = cell.FindControl("gv_ddl_SP_grade") as DropDownList;
                    DropDownList ddl19 = cell.FindControl("gv_ddl_WP_organised") as DropDownList;
                    DropDownList ddl20 = cell.FindControl("gv_ddl_WP_neat") as DropDownList;

                    DropDownList ddl21 = cell.FindControl("gv_ddl_WP_legible_handwriting") as DropDownList;
                    DropDownList ddl22 = cell.FindControl("gv_ddl_WP_indices_filled") as DropDownList;
                    DropDownList ddl23 = cell.FindControl("gv_ddl_WP_indices_signed_teachers") as DropDownList;
                    DropDownList ddl24 = cell.FindControl("gv_ddl_WP_indices_signed_parents") as DropDownList;

                    DropDownList ddl25 = cell.FindControl("gv_ddl_WP_grade") as DropDownList;
                    DropDownList ddl26 = cell.FindControl("gv_ddl_overall_grade") as DropDownList;
                    DropDownList ddl27 = cell.FindControl("gv_ddl_Siqa_EndorsedValue") as DropDownList;
                    

                    // If a DropDownList is found, disable it
                    if (ddl != null)
                    {
                        ddl.Enabled = false;
                        ddl1.Enabled = false;
                        ddl2.Enabled = false;
                        ddl3.Enabled = false;
                        ddl4.Enabled = false;
                        ddl5.Enabled = false;
                        ddl6.Enabled = false;
                        ddl7.Enabled = false;
                        ddl8.Enabled = false;
                        ddl9.Enabled = false;
                        ddl10.Enabled = false;
                        ddl11.Enabled = false;
                        ddl12.Enabled = false;
                        ddl13.Enabled = false;
                        ddl14.Enabled = false;
                        ddl15.Enabled = false;
                        ddl16.Enabled = false;
                        ddl17.Enabled = false;
                        ddl18.Enabled = false;
                        ddl19.Enabled = false;
                        ddl20.Enabled = false;
                        ddl21.Enabled = false;
                        ddl22.Enabled = false;
                        ddl23.Enabled = false;
                        ddl24.Enabled = false;
                        ddl25.Enabled = false;
                        ddl26.Enabled = false;
                        ddl27.Enabled = false;
                    }
                }
            }
        }
    }


    //protected void gv_ddl_Siqa_EndorsedValue_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList dropDownList = (DropDownList)sender;
    //    GridViewRow row = (GridViewRow)dropDownList.Parent.Parent;
    //    HiddenField hiddenField = (HiddenField)row.FindControl("HiddenField1");
    //    hiddenField.Value = "true";
    //}

    DataTable EvaluationGETSubject(string Group_ID)
    {

        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_SEF_Evaluation_GET_Subject");
        obj_Access.AddParameter("GroupID", Group_ID, DataAccess.SQLParameterType.VarChar, true);


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

    protected void gvnbconsolidationhistory_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvnbconsolidationhistory.Rows.Count > 0)
            {
                gvnbconsolidationhistory.UseAccessibleHeader = false;
                gvnbconsolidationhistory.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    

    protected void Right_Side_Scroll_Click(object sender, EventArgs e)
    {
       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "alert('abc')", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "scrollToRight()", true);

    }

    // SR Work  START
    public void cal_Overall_grades()
    {
        lblTotal_Center.Text = gvnbconsolidationhistory.Rows.Count.ToString();
        float countTotal = gvnbconsolidationhistory.Rows.Count;
        float countUA = 0, countAcc = 0, countG = 0, countOS = 0;
        for (int i = 0; i < gvnbconsolidationhistory.Rows.Count; i++)
        {
            GridViewRow row = gvnbconsolidationhistory.Rows[i];
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)row.FindControl("gv_ddl_overall_grade");
                if (ddl != null)
                {

                    if (ddl.SelectedItem.Text == "UA")
                    {
                        countUA = countUA + 1;
                    }
                    else if (ddl.SelectedItem.Text == "A")
                    {
                        countAcc = countAcc + 1;

                    }
                    else if (ddl.SelectedItem.Text == "G")
                    {
                        countG = countG + 1;
                    }
                    else if (ddl.SelectedItem.Text == "OS")
                    {
                        countOS = countOS + 1;
                    }


                    //ddl.SelectedValue = selectedValue;
                }
            }

        }
        if (countTotal > 0)
        {
            lblUA_Center.Text = Math.Round((countUA / countTotal) * 100, 2).ToString() + " %";
            lblAcc_Center.Text = Math.Round((countAcc / countTotal) * 100, 2).ToString() + " %";
            lblGood_Center.Text = Math.Round((countG / countTotal) * 100, 2).ToString() + " %";
            lblOS_Center.Text = Math.Round((countOS / countTotal) * 100, 2).ToString() + " %";
        }
        else
        {
            lblUA_Center.Text = "0 %";
            lblAcc_Center.Text = "0 %";
            lblGood_Center.Text = "0 %";
            lblOS_Center.Text = "0 %";
        }
    }
    public void cal_Overall_grades_Center()
    {
        lblTotal_Center.Text = gvNbConsolidation.Rows.Count.ToString();
        float countTotal = gvNbConsolidation.Rows.Count;
        float countUA = 0, countAcc = 0, countG = 0, countOS = 0;
        for (int i = 0; i < gvNbConsolidation.Rows.Count; i++)
        {
            GridViewRow row = gvNbConsolidation.Rows[i];
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)row.FindControl("gv_ddl_overall_grade");
                if (ddl != null)
                {

                    if (ddl.SelectedItem.Text == "UA")
                    {
                        countUA = countUA + 1;
                    }
                    else if (ddl.SelectedItem.Text == "A")
                    {
                        countAcc = countAcc + 1;

                    }
                    else if (ddl.SelectedItem.Text == "G")
                    {
                        countG = countG + 1;
                    }
                    else if (ddl.SelectedItem.Text == "OS")
                    {
                        countOS = countOS + 1;
                    }


                    //ddl.SelectedValue = selectedValue;
                }
            }

        }
        if (countTotal > 0)
        {
            lblUA_Center.Text = Math.Round((countUA / countTotal) * 100, 2).ToString() + " %";
            lblAcc_Center.Text = Math.Round((countAcc / countTotal) * 100, 2).ToString() + " %";
            lblGood_Center.Text = Math.Round((countG / countTotal) * 100, 2).ToString() + " %";
            lblOS_Center.Text = Math.Round((countOS / countTotal) * 100, 2).ToString() + " %";
        }
        else
        {
            lblUA_Center.Text = "0 %";
            lblAcc_Center.Text = "0 %";
            lblGood_Center.Text = "0 %";
            lblOS_Center.Text = "0 %";
        }
    }
    protected void btnUpdateSIQAEndorsed_Click(object sender, EventArgs e)
    {
        string selectedValue = ddlSiqaEndorsed.SelectedValue;

        // Iterate through the GridView rows and update the DropDownList values
        foreach (GridViewRow row in gvNbConsolidation.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)row.FindControl("gv_ddl_Siqa_EndorsedValue");
                if (ddl != null)
                {
                    ddl.SelectedValue = selectedValue;
                }
            }
        }
    }
    public void grade_overall_cal()
    {
        string[] StudentLearningSkillsLovSelectedValuesArray = new string[2];
        StudentLearningSkillsLovSelectedValuesArray[0] = ddl_Assessment_grade.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[1] = ddl_SP_grade.SelectedValue.ToString();


        if (StudentLearningSkillsLovSelectedValuesArray.Contains("OS"))
        {
            this.ddl_overall_grade.SelectedIndex = 1;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("G"))
        {
            this.ddl_overall_grade.SelectedIndex = 2;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("A"))
        {
            this.ddl_overall_grade.SelectedIndex = 3;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("UA"))
        {
            this.ddl_overall_grade.SelectedIndex = 4;
        }
    }
    DataTable ExecuteProcedure(string sAction, string Class_ID, string Region_ID)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_CampusSubjectCommentsCorrection_ForSIQA");
        obj_Access.AddParameter("P_optional1", Class_ID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_optional2", Region_ID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
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

    //SR WORK END


    protected void btnNbconsolidationexport_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            BLLSiqa objhistorydata = new BLLSiqa();
            DataTable dthistory = new DataTable();

            if (ddl_region.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Region :", 0);
                return;
            }
            if (ddl_center.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Center :", 0);
                return;
            }
            if (ddlkeystage.SelectedValue.ToString() != "")
            {
                Session["Keystage_id"] = ddlkeystage.SelectedItem.Text.ToString();
            }



            dt = objdata.NB_Consolidation_Export(
                ddl_region.SelectedValue.ToString(),
                ddl_center.SelectedValue.ToString(),
                ddlteacher.SelectedValue.ToString(),
                ddlclass.SelectedValue.ToString(),
                ddlsubjects.SelectedValue.ToString(),
                ddl_grouphead.SelectedValue.ToString(),
                ddlkeystage.SelectedValue.ToString()
                );
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Export_View_Report_Data");
                dt = null;

            }
            else
            {
                ImpromptuHelper.ShowPrompt("There Are No Search Results To Export!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        // Required for Export to work
    }

    public void ExportToSpreadsheet(DataTable table, string name)
    {
        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + "\t");

        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(",", string.Empty) + "\t");
            }

            context.Response.Write(Environment.NewLine);
        }

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename = " + name + ".xls");
        context.Response.Flush();
        context.Response.SuppressContent = true;
        context.ApplicationInstance.CompleteRequest();
        ////////////context.Response.End();
    }

    protected void btnexportsiqaendorsedgrades_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            BLLSiqa objhistorydata = new BLLSiqa();
            DataTable dthistory = new DataTable();

            if (ddl_region.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Region :", 0);
                return;
            }
            if (ddl_center.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Center :", 0);
                return;
            }
            //if (ddlkeystage.SelectedValue.ToString() != "")
            //{
            //    Session["Keystage_id"] = ddlkeystage.SelectedItem.Text.ToString();
            //}



            dthistory = objdata.NB_Consolidation_Siqa_Endorsed_Export(
                ddl_region.SelectedValue.ToString(),
                ddl_center.SelectedValue.ToString(),
                ddlteacher.SelectedValue.ToString(),
                ddlclass.SelectedValue.ToString(),
                ddlsubjects.SelectedValue.ToString(),
                ddl_grouphead.SelectedValue.ToString(),
                ddlkeystage.SelectedValue.ToString()
                );
            if (dthistory != null)
            {
                ExportToSpreadsheet(dthistory, "Export_Siqa_Endorsed_Grades");
                dt = null;

            }
            else
            {
                ImpromptuHelper.ShowPrompt("There Are No Search Results To Export!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}