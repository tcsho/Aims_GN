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
using System.Activities.Statements;
using System.Threading;
using System.Web;

using System.Web.Services;


using Newtonsoft.Json;



public partial class PresentationLayer_LoConsolidation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    BLLSiqa objSiqa = new BLLSiqa();
    private DataSet ds = null;
    int countallgrades_OS = 0;
    int countallgrades_G = 0;
    int countallgrades_A = 0;
    int countallgrades_UA = 0;
    private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnloconsolidationexport);
            scriptManager.RegisterPostBackControl(this.btnexportsiqaendorsedgrades);


            if (!Page.IsPostBack)
            {
                //TabName.Value = Request.Form[TabName.UniqueID];
                // ScriptManager.RegisterStartupScript(this, GetType(), "SetDefaultTab", "$('.nav-tabs a[href=\"#menu1\"]').tab('show');", true);
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
                if (userid == 43)      //QuratUlAin.Fatima     Region readonly
                {
                    btn_save.Enabled = false;
                    btnUpdateSIQAEndorsed.Enabled = false;
                    btnUpdateAllLoConsolidationData.Enabled = false;
                    btnloconsolidationexport.Enabled = false;
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    //ddl_center.SelectedValue = row["Center_Id"].ToString();
                    //ddl_center_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;

                }
                if (userid == 45  || userid == 44)    //maryum.imran   head ofc readonly
                {
                    btn_save.Enabled = false;
                    btnUpdateSIQAEndorsed.Enabled = false;
                    btnUpdateAllLoConsolidationData.Enabled = false;
                    btnloconsolidationexport.Enabled = false;
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    //ddl_center.SelectedValue = row["Center_Id"].ToString();
                    //ddl_center_SelectedIndexChanged(sender, e);
                    //ddl_region.Enabled = false;

                }
                //BindGrid(); 
                //cal_Overall_grades();

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
            if (ddlformat.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Format", 0);
                return;
            }
            if (ddlobjectiveoutcome.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Objectives/Outcomes :", 0);
                return;
            }
            if (ddlactivitieslearningoutcome.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Act & Learning Outcomes  :", 0);
                return;
            }
            if (ddlcurrentaddapted.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Curr Adapted  :", 0);
                return;
            }
            if (ddlcrosscurricularlinks.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Cross Curricular Links  :", 0);
                return;
            }
            if (ddllessoneva.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Lesson Eval  :", 0);
                return;
            }
            if (ddlgrade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade :", 0);
                return;
            }
            if (ddlsubjectknowledge.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Subject Knowledge :", 0);
                return;
            }
            if (ddlclearlo.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Clear LO :", 0);
                return;
            }
            if (ddltecactlearnoutcom.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Act & Learning Outcomes :", 0);
                return;
            }
            if (ddlabilitygroup.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Need of Ability Group :", 0);
                return;
            }
            if (ddlCollaboration.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Collaboration :", 0);
                return;
            }
            if (ddlhotandreflection.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select HOT and reflection :", 0);
                return;
            }

            if (ddlclearinst.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Clear Instruction :", 0);
                return;
            }
            if (ddlcclinks.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Cross-curricular links :", 0);
                return;
            }
            if (dddafl.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select AFL :", 0);
                return;
            }
            if (ddlselfpeeraccess.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Self/Peer Assess :", 0);
                return;
            }
            if (ddlsupportandfb.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Support & Feedback :", 0);
                return;
            }
            if (ddltimemanagement.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Time Management :", 0);
                return;
            }
            if (ddlLearningEnv.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Learning env :", 0);
                return;
            }
            if (ddltechgrade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade :", 0);
                return;
            }

            if (ddlinteraction.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Interaction :", 0);
                return;
            }
            if (ddlmarkconnections.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Make Connections :", 0);
                return;
            }
            if (ddlactivityengaged.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Actively Engaged :", 0);
                return;
            }
            if (ddlCollaborate.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Collaborate :", 0);
                return;
            }
            if (ddlReflect.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Reflect :", 0);
                return;
            }
            if (ddlhot.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select HOT :", 0);
                return;
            }
            if (ddlceffectively.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Communicate Effectively :", 0);
                return;
            }
            if (ddgradestudentlearningskills.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade :", 0);
                return;
            }
            //*****************
            if (ddlselfdisciplined.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Self-Disciplined :", 0);
                return;
            }
            if (ddlpositiverelationstudents.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Students :", 0);
                return;
            }
            if (ddlpositiverelationadults.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Adults :", 0);
                return;
            }
            if (ddlgradeattituderelationship.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade :", 0);
                return;
            }

            //************************************************
            if (ddlpositiverelationpeers.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Peers :", 0);
                return;
            }
            if (ddlpositiverelfamiliaradults.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Adults :", 0);
                return;
            }
            if (ddlsettledwell.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Settled Well :", 0);
                return;
            }
            if (ddlcaringsharing.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Caring/ Sharing :", 0);
                return;
            }
            if (ddllistenfollowinstructions.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Listen Follow Instructions :", 0);
                return;
            }
            if (ddlteachersenstowardschild.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Teacher Childrens Needs :", 0);
                return;
            }
            if (ddlgradecareandclassromroutine.SelectedValue.ToString() == "" && (ddlkeystage.SelectedValue.ToString() == "1" || ddlkeystage.SelectedValue.ToString() == "2"))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Grade :", 0);
                return;
            }
            if (ddlstudentprogress.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Students' Progress :", 0);
                return;
            }
            if (ddloveralllesssongrade.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Overall Lesson Grade :", 0);
                return;
            }




            obj.Section_id = Convert.ToInt32(ddlsections.SelectedValue.ToString());

            obj.Format = ddlformat.SelectedValue.ToString();
            obj.Obj_Outcoms = ddlobjectiveoutcome.SelectedValue.ToString();
            obj.LP_Learning_Outcomes = ddlactivitieslearningoutcome.SelectedValue.ToString();
            obj.Cur_Adapted = ddlcurrentaddapted.SelectedValue.ToString();
            obj.Cross_Curricular_Links = ddlcrosscurricularlinks.SelectedValue.ToString();
            obj.Lesson_Evaluation = ddllessoneva.SelectedValue.ToString();
            obj.Lesson_Grade = ddlgrade.SelectedValue.ToString();
            obj.Subject_Knowledge = ddlsubjectknowledge.SelectedValue.ToString();
            obj.Clear_Lo = ddlclearlo.SelectedValue.ToString();
            obj.Teaching_Learning_Outcomes = ddltecactlearnoutcom.SelectedValue.ToString();
            obj.Need_Ability_Group = ddlabilitygroup.SelectedValue.ToString();
            obj.Collaboration = ddlCollaboration.SelectedValue.ToString();
            obj.Hot_and_Reflection = ddlhotandreflection.SelectedValue.ToString();
            obj.Clear_Instruction = ddlclearinst.SelectedValue.ToString();
            obj.Tech_Cross_Curricular_Links = ddlcclinks.SelectedValue.ToString();
            obj.AFL = dddafl.SelectedValue.ToString();
            obj.Peer_Address = ddlselfpeeraccess.SelectedValue.ToString();
            obj.Suppor_Feedback = ddlsupportandfb.SelectedValue.ToString();
            obj.Time_Management = ddltimemanagement.SelectedValue.ToString();
            obj.Learning_Env = ddlLearningEnv.SelectedValue.ToString();
            obj.Teaching_Grade = ddltechgrade.SelectedValue.ToString();
            obj.Interaction = ddlinteraction.SelectedValue.ToString();
            obj.Make_Connection = ddlmarkconnections.SelectedValue.ToString();
            obj.Actively_Engaged = ddlactivityengaged.SelectedValue.ToString();
            obj.Collaborate = ddlCollaborate.SelectedValue.ToString();
            obj.Reflect = ddlReflect.SelectedValue.ToString();
            obj.HOT = ddlhot.SelectedValue.ToString();
            obj.Communicate_Effectively = ddlceffectively.SelectedValue.ToString();
            obj.Student_Grade = ddgradestudentlearningskills.SelectedValue.ToString();
            obj.Self_Disciplined = ddlselfdisciplined.SelectedValue.ToString();
            obj.Positive_Relation_Student = ddlpositiverelationstudents.SelectedValue.ToString();
            obj.Positive_Relation_Adult = ddlpositiverelationadults.SelectedValue.ToString();
            obj.Attitude_Relationship_Grade = ddlgradeattituderelationship.SelectedValue.ToString();
            obj.Care_Classroom_Positive_Relationship_Peers = ddlpositiverelationpeers.SelectedValue.ToString();
            obj.Care_Classroom_Relation_Adult = ddlpositiverelfamiliaradults.SelectedValue.ToString();
            obj.Settled_Well = ddlsettledwell.SelectedValue.ToString();
            obj.Caring_Sharing = ddlcaringsharing.SelectedValue.ToString();
            obj.Listen_Follow_Instruction = ddllistenfollowinstructions.SelectedValue.ToString();
            obj.Teacher_Children_Needs = ddlteachersenstowardschild.SelectedValue.ToString();
            obj.Care_Classroom_Grade = ddlgradecareandclassromroutine.SelectedValue.ToString();
            obj.Student_Progress = ddlstudentprogress.SelectedValue.ToString();
            obj.Overall_Lesson_Grade = ddloveralllesssongrade.SelectedValue.ToString();
            obj.EBI1 = "";//txtEBI1.Text.ToString();
            obj.EBI2 = "";//txtEBI2.Text.ToString();
            obj.EBI3 = "";//txtEBI3.Text.ToString();
            obj.Format = ddlformat.SelectedValue.ToString();
            obj.Format = ddlformat.SelectedValue.ToString();
            obj.CreateBy = Session["ContactID"].ToString();
            int result = obj.Lo_Consolidation_Insert(obj);
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
            BLLSiqa objhistorydata = new BLLSiqa();
            DataTable dthistory = new DataTable();
            DataRow row = (DataRow)Session["rightsRow"];
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

    

            dt = objdata.Search_Lo_Consolidated(
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
                    gvloconsolidation.DataSource = dt;
                    gvloconsolidation.DataBind();
                }
                else
                {
                    gvloconsolidation.DataSource = null;
                    gvloconsolidation.DataBind();

                }
            }
            else
            {
                gvloconsolidation.DataSource = null;
                gvloconsolidation.DataBind();
            }

            //Added by Maria

            int userid = Convert.ToInt32(row["User_Type_Id"].ToString());
            if (userid == 45 || userid == 43 || userid == 44)
            {
                // Disable buttons in the GridView
                foreach (GridViewRow gridRow in gvloconsolidation.Rows)
                {
                    CheckBox gv_chkbx_campus_head = gridRow.FindControl("gv_chkbx_campus_head") as CheckBox;
                    if(gv_chkbx_campus_head !=null)
                    {
                        gv_chkbx_campus_head.Enabled = false;
                    }


                    Button btnUpdate = gridRow.FindControl("btnUpdateLoConsolidationData") as Button;
                    if (btnUpdate != null)
                    {
                        // Disable the button based on your condition, or always
                        btnUpdate.Enabled = false; // Always disable for demonstration
                    }
                }
            }


            //**********************************Lo consolidation History*****************************
            dthistory = objdata.Search_Lo_Consolidated_History(
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
                    gvloconsolidationhistory.DataSource = dthistory;
                    gvloconsolidationhistory.DataBind();
                }
                else
                {
                    gvloconsolidationhistory.DataSource = null;
                    gvloconsolidationhistory.DataBind();

                }
            }
            else
            {
                gvloconsolidationhistory.DataSource = null;
                gvloconsolidationhistory.DataBind();
            }

            //***************************************************************************************


          
            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
            {
                gvloconsolidation.Columns[51].Visible = false;
                gvloconsolidation.Columns[52].Visible = false;
            }
            else
            {
                gvloconsolidation.Columns[51].Visible = true;
                gvloconsolidation.Columns[52].Visible = true;
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
        //try
        //{
        ////    if (ddlTerm.SelectedIndex > 0)
        ////    {
        ////        ViewState["Grid"] = null;
        ////        BindGrid();
        ////    }
        ////}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }


    //private void LoadSubject()
    //{
    //    try
    //    {

    //        DataTable DT = ExecuteProcedure("CS", ddlClass.SelectedValue, "");
    //        DT.Dispose();
    //        if (DT.Rows.Count > 0)
    //        {
    //            objBase.FillDropDown(DT, list_Subject, "Subject_ID", "Subject_Name");

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}


    //private void LoadStudent()
    //{
    //    try
    //    {

    //        BLLSection_Subject obj = new BLLSection_Subject();
    //        int SectionSubjectId = Convert.ToInt32(list_Subject.SelectedValue.ToString());

    //        DataTable dt = (DataTable)obj.StudentBySectionSubjectId(SectionSubjectId);
    //        objBase.FillDropDown(dt, , "Student_Id", "FullStudentName");
    //        ViewState["StudentList"] = dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}





    protected void gvRegStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }


    //protected void LoadClassSection()
    // {
    //     try
    //     {

    //         BLLClass_Section obj = new BLLClass_Section();

    //         int EmployeeId = Convert.ToInt32(Session["EmployeeCode"].ToString());

    //         DataTable dt = (DataTable)obj.Class_SectionByEmployeeId(EmployeeId);
    //         objBase.FillDropDown(dt, ddlClass, "Section_id", "FullClassSection");
    //     }
    //     catch (Exception ex)
    //     {
    //         Session["error"] = ex.Message;
    //         Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //     }

    // }

    protected void chkAbsent_OnCheckedChanged(Object sender, EventArgs e)
    {




    }


    private void loadRegions()
    {
        try
        {
            //string q = Request.QueryString["id"];
            //string s = Request.QueryString["id"];
            //if (Convert.ToInt32(s) == 92 || Convert.ToInt32(s) > 92 || Convert.ToInt32(s) == 97 || Convert.ToInt32(s) < 97)
            //{
            //    //lab_center.Text = "School*: ";
            //}

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            // BindCheckBoxListControl(dt, lstRegion, "Region_Id", "Region_Name");
            ////////////UserInformationGrid2.SetData(dt);


            //**********Fetch All subjects****************
            //DataTable DT = ExecuteProcedure("CS", "0", ddl_region.SelectedValue);

            //if (DT.Rows.Count > 0)
            //{
            //    DataRow rowMusic = DT.NewRow();
            //    rowMusic["Subject_ID"] = 64;
            //    rowMusic["Subject_Name"] = "Music and Art";
            //    DT.Rows.Add(rowMusic);

            //    DataRow rowLibrary = DT.NewRow();
            //    rowLibrary["Subject_ID"] = 9998;
            //    rowLibrary["Subject_Name"] = "Library";
            //    DT.Rows.Add(rowLibrary);


            //    DataRow rowPE = DT.NewRow();
            //    rowPE["Subject_ID"] = 9999;
            //    rowPE["Subject_Name"] = "PE";
            //    DT.Rows.Add(rowPE);
            //    objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");


            //}
          
            Get_subjects("0", ddl_region.SelectedValue);

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

    //protected void bindTermList()
    //{
    //    try
    //    {
    //        //if (ddlClass.SelectedIndex > 0)
    //        //{

    //        //// * Comment of request of user to need filer for all reports without class id 2 feb 2016
    //        DataTable dt = null;
    //        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
    //        ObjECT.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
    //        if (ObjECT.Class_Id != null)
    //        {
    //            dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);
    //            //objBase.FillDropDown(dt, ddlTerm, "Evaluation_Criteria_Type_Id", "Type");
    //        }
    //        else
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }


    //}
    protected void FillClass()
    {
        try
        {
            //string s=Request.QueryString["id"];
            //if (Convert.ToInt32(s) == 92 || Convert.ToInt32(s) > 92 || Convert.ToInt32(s) == 97 || Convert.ToInt32(s)<97)
            //{
            //    FillClassDP();

            //}
            //else
            //{
            //    BLLClass objBLLClass = new BLLClass();
            //    DataTable dt = null;
            //    dt = objBLLClass.ClassFetch(objBLLClass);
            //    objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");

            //}
            //DataTable DT = ExecuteProcedure("GetC", "", "");
            //DT.Dispose();
            //if (DT.Rows.Count > 0)
            //{
            //    objBase.FillDropDown(DT, ddlClass, "Class_Id", "Class_Name");

            //}


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

            //string activeTab = hfActiveTab.Text;

            //// Register the script to set the active tab


            //2024-10-09
            //DataTable DT = ExecuteProcedure("CS", "0", ddl_region.SelectedValue);
            //if (DT.Rows.Count > 0)
            //{
            //    objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");
            //}





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
                //objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                //dtclass = objCS.ClassFetch(objCS);
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

            //ViewState["Teachers"] = dt;


            //SR Work
            BLLSiqa siqaobj = new BLLSiqa();
            siqaobj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            DataTable dtteacherList = (DataTable)siqaobj.TeacherList_ProfileByCenterId_loConsolidation(siqaobj);

            //ViewState["Teachers"] = dt;

            gvLO_C_TeacherList.DataSource = dtteacherList;
            gvLO_C_TeacherList.DataBind();

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

            Get_subjects(ddlclass.SelectedValue, ddl_region.SelectedValue);
            //DataTable DT = ExecuteProcedure("CS", ddlclass.SelectedValue, ddl_region.SelectedValue);

            //if (DT.Rows.Count > 0)
            //{
            //    objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            //}
            //DT.Dispose();
            DataTable dtsections = objSiqa.Get_Sections(int.Parse(ddl_center.SelectedValue), int.Parse(ddlclass.SelectedValue));

            if (dtsections.Rows.Count > 0)
            {
                objBase.FillDropDown(dtsections, ddlsections, "Section_Id", "Section_Name");

            }

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


    protected void gvloconsolidation_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvloconsolidation.Rows.Count > 0)
            {
                gvloconsolidation.UseAccessibleHeader = false;
                gvloconsolidation.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void gvloconsolidationhistory_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvloconsolidationhistory.Rows.Count > 0)
            {
                gvloconsolidationhistory.UseAccessibleHeader = false;
                gvloconsolidationhistory.HeaderRow.TableSection = TableRowSection.TableHeader;

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

    }


    public void Clear_Data()
    {
        // this.ddl_region.SelectedIndex = -1;
        // this.ddl_center.SelectedIndex = -1;
        this.ddlteacher.SelectedIndex = -1;
        // this.ddl_grouphead.SelectedIndex = -1;
        this.ddlclass.SelectedIndex = -1;
        this.ddlsubjects.SelectedIndex = -1;
        this.ddlsections.SelectedIndex = -1;
        this.ddlformat.SelectedIndex = -1;
        //this.ddlkeystage.SelectedIndex = -1;
        this.ddlobjectiveoutcome.SelectedIndex = -1;
        this.ddlactivitieslearningoutcome.SelectedIndex = -1;
        this.ddlcurrentaddapted.SelectedIndex = -1;

        this.ddlcrosscurricularlinks.SelectedIndex = -1;
        this.ddllessoneva.SelectedIndex = -1;
        this.ddlgrade.SelectedIndex = -1;
        this.ddlclearlo.SelectedIndex = -1;
        this.ddltecactlearnoutcom.SelectedIndex = -1;
        this.ddlabilitygroup.SelectedIndex = -1;
        this.ddlCollaboration.SelectedIndex = -1;
        this.ddlhotandreflection.SelectedIndex = -1;
        this.ddlclearinst.SelectedIndex = -1;

        this.ddlcclinks.SelectedIndex = -1;
        this.dddafl.SelectedIndex = -1;
        this.ddlselfpeeraccess.SelectedIndex = -1;
        this.ddlsupportandfb.SelectedIndex = -1;
        this.ddltimemanagement.SelectedIndex = -1;
        this.ddlLearningEnv.SelectedIndex = -1;
        this.ddltechgrade.SelectedIndex = -1;
        this.ddlinteraction.SelectedIndex = -1;
        this.ddlmarkconnections.SelectedIndex = -1;
        this.ddlCollaborate.SelectedIndex = -1;

        this.ddlactivityengaged.SelectedIndex = -1;

        this.ddlReflect.SelectedIndex = -1;

        this.ddlhot.SelectedIndex = -1;

        this.ddlceffectively.SelectedIndex = -1;


        this.ddgradestudentlearningskills.SelectedIndex = -1;


        this.ddlselfdisciplined.SelectedIndex = -1;


        this.ddlpositiverelationadults.SelectedIndex = -1;
        this.ddlgradeattituderelationship.SelectedIndex = -1;
        this.ddlpositiverelationpeers.SelectedIndex = -1;


        this.ddlpositiverelfamiliaradults.SelectedIndex = -1;
        this.ddlsettledwell.SelectedIndex = -1;
        this.ddlcaringsharing.SelectedIndex = -1;


        this.ddllistenfollowinstructions.SelectedIndex = -1;
        this.ddlteachersenstowardschild.SelectedIndex = -1;
        this.ddlgradecareandclassromroutine.SelectedIndex = -1;

        this.ddlstudentprogress.SelectedIndex = -1;
        this.ddloveralllesssongrade.SelectedIndex = -1;
    }

    protected void ddlTeachingLov_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] TeachingLovSelectedValuesArray = new string[4];
        TeachingLovSelectedValuesArray[0] = ddlsubjectknowledge.SelectedValue.ToString();
        TeachingLovSelectedValuesArray[1] = ddltecactlearnoutcom.SelectedValue.ToString();
        TeachingLovSelectedValuesArray[2] = ddlabilitygroup.SelectedValue.ToString();
        TeachingLovSelectedValuesArray[3] = dddafl.SelectedValue.ToString();

        if (TeachingLovSelectedValuesArray.Contains("OS"))
        {
            this.ddltechgrade.SelectedIndex = 1;
        }
        if (TeachingLovSelectedValuesArray.Contains("G"))
        {
            this.ddltechgrade.SelectedIndex = 2;
        }
        if (TeachingLovSelectedValuesArray.Contains("A"))
        {
            this.ddltechgrade.SelectedIndex = 3;
        }
        if (TeachingLovSelectedValuesArray.Contains("UA"))
        {
            this.ddltechgrade.SelectedIndex = 4;
        }

        grade_overall_cal();
    }

    protected void ddlStudentLearningSkillsLov_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] StudentLearningSkillsLovSelectedValuesArray = new string[3];
        StudentLearningSkillsLovSelectedValuesArray[0] = ddlinteraction.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[1] = ddlactivityengaged.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[2] = ddlReflect.SelectedValue.ToString();

        if (StudentLearningSkillsLovSelectedValuesArray.Contains("OS"))
        {
            this.ddgradestudentlearningskills.SelectedIndex = 1;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("G"))
        {
            this.ddgradestudentlearningskills.SelectedIndex = 2;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("A"))
        {
            this.ddgradestudentlearningskills.SelectedIndex = 3;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("UA"))
        {
            this.ddgradestudentlearningskills.SelectedIndex = 4;
        }
        grade_overall_cal();
    }

    protected void btnUpdateLoConsolidationData_Click(object sender, EventArgs e)
    {
        Update_Data_And_Execute_Formula_calculation(sender, e);
    }


    protected void Update_Data_And_Execute_Formula_calculation(object sender, EventArgs e)
    {
        try
        {
            BLLSiqa obj = new BLLSiqa();

            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

            obj.Format = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlFormatValue")).SelectedValue;
            obj.Obj_Outcoms = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlObj_OutcomsValue")).SelectedValue;
            obj.LP_Learning_Outcomes = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlLP_Learning_OutcomesValue")).SelectedValue;
            obj.Cur_Adapted = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCur_AdaptedValue")).SelectedValue;
            obj.Cross_Curricular_Links = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCross_Curricular_LinksValue")).SelectedValue;
            obj.Lesson_Evaluation = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlLesson_EvaluationValue")).SelectedValue;
            obj.Lesson_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlLesson_GradeValue")).SelectedValue;
            obj.Subject_Knowledge = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlSubject_KnowledgeValue")).SelectedValue;
            obj.Clear_Lo = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlClear_LoValue")).SelectedValue;
            obj.Teaching_Learning_Outcomes = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlTeaching_Learning_OutcomesValue")).SelectedValue;
            obj.Need_Ability_Group = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlNeed_Ability_GroupValue")).SelectedValue;
            obj.Collaboration = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCollaborationValue")).SelectedValue;
            obj.Hot_and_Reflection = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlHot_and_ReflectionValue")).SelectedValue;
            obj.Clear_Instruction = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlClear_InstructionValue")).SelectedValue;
            obj.Tech_Cross_Curricular_Links = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlTech_Cross_Curricular_LinksValue")).SelectedValue;
            obj.AFL = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlAFLValue")).SelectedValue;
            obj.Peer_Address = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlPeer_AddressValue")).SelectedValue;
            obj.Suppor_Feedback = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlSuppor_FeedbackValue")).SelectedValue;
            obj.Time_Management = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlTime_ManagementValue")).SelectedValue;
            obj.Teaching_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlTeaching_GradeValue")).SelectedValue;
            obj.Interaction = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlInteractionValue")).SelectedValue;
            obj.Make_Connection = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlMake_ConnectionValue")).SelectedValue;
            obj.Actively_Engaged = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlActively_EngagedValue")).SelectedValue;
            obj.Collaborate = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCollaborateValue")).SelectedValue;
            obj.Reflect = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlReflectValue")).SelectedValue;
            obj.HOT = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlHOTValue")).SelectedValue;
            obj.Communicate_Effectively = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCommunicate_EffectivelyValue")).SelectedValue;
            obj.Student_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlStudent_GradeValue")).SelectedValue;
            obj.Self_Disciplined = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlSelf_DisciplinedValue")).SelectedValue;
            obj.Positive_Relation_Student = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlPositive_Relation_StudentValue")).SelectedValue;
            obj.Positive_Relation_Adult = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlPositive_Relation_AdultValue")).SelectedValue;
            obj.Attitude_Relationship_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlAttitude_Relationship_GradeValue")).SelectedValue;
            obj.Care_Classroom_Positive_Relationship_Peers = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCare_Classroom_Positive_Relationship_PeersValue")).SelectedValue;
            obj.Care_Classroom_Relation_Adult = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCare_Classroom_Relation_AdultValue")).SelectedValue;
            obj.Settled_Well = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlSettled_WellValue")).SelectedValue;
            obj.Caring_Sharing = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCaring_SharingValue")).SelectedValue;
            obj.Listen_Follow_Instruction = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlListen_Follow_InstructionValue")).SelectedValue;
            obj.Teacher_Children_Needs = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlTeacher_Children_NeedsValue")).SelectedValue;
            obj.Care_Classroom_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlCare_Classroom_GradeValue")).SelectedValue;
            obj.Student_Progress = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlOverallProgress_Student_Progress")).SelectedValue;
            obj.Overall_Lesson_Grade = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlOverallProgress_overall_lesson_grade")).SelectedValue;
            obj.EBI1 = ((TextBox)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlOverallProgress_EBI1")).Text;
            obj.EBI2 = ((TextBox)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlOverallProgress_EBI2")).Text;
            obj.EBI3 = ((TextBox)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlOverallProgress_EBI3")).Text;
            obj.Siqa_Endorsed = ((DropDownList)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvDdlSiqa_EndorsedValue")).SelectedValue;
            obj.Consolidatio_Id = Convert.ToInt32(((HiddenField)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvHfConsolidatio_IdValue")).Value);


            //Session["Region_Id"] = clickedRow.Cells[52].Text == "&nbsp;" ? "" : clickedRow.Cells[52].Text;
            //Session["Center_Id"] = clickedRow.Cells[53].Text == "&nbsp;" ? "" : clickedRow.Cells[53].Text;
            //Session["Keystage_id"] = clickedRow.Cells[54].Text == "&nbsp;" ? "" : clickedRow.Cells[54].Text;
            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            dt = objdata.Get_Value_Basedon_Loconsolidationid(obj.Consolidatio_Id);

            obj.UpdateBy = Session["ContactID"].ToString();

            int result = obj.Lo_Consolidation_Update(obj);
            if (result == 1)
            {
                obj.Exec_SEF_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                //Create History
                if (obj.Siqa_Endorsed == "YES")
                {
                    obj.Lo_consolidation_History(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                }

                BindGrid();
                cal_Overall_grades();
                cal_Overall_grades_Center();
                ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
            }
            obj = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SetActiveTab();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnUpdateAllLoConsolidationData_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in gvloconsolidation.Rows)
            {
                BLLSiqa obj = new BLLSiqa();
                if (row.RowType == DataControlRowType.DataRow)
                {


                    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;

                    obj.Format = ((DropDownList)row.FindControl("gvDdlFormatValue")).SelectedValue;
                    obj.Obj_Outcoms = ((DropDownList)row.FindControl("gvDdlObj_OutcomsValue")).SelectedValue;
                    obj.LP_Learning_Outcomes = ((DropDownList)row.FindControl("gvDdlLP_Learning_OutcomesValue")).SelectedValue;
                    obj.Cur_Adapted = ((DropDownList)row.FindControl("gvDdlCur_AdaptedValue")).SelectedValue;
                    obj.Cross_Curricular_Links = ((DropDownList)row.FindControl("gvDdlCross_Curricular_LinksValue")).SelectedValue;
                    obj.Lesson_Evaluation = ((DropDownList)row.FindControl("gvDdlLesson_EvaluationValue")).SelectedValue;
                    obj.Lesson_Grade = ((DropDownList)row.FindControl("gvDdlLesson_GradeValue")).SelectedValue;
                    obj.Subject_Knowledge = ((DropDownList)row.FindControl("gvDdlSubject_KnowledgeValue")).SelectedValue;
                    obj.Clear_Lo = ((DropDownList)row.FindControl("gvDdlClear_LoValue")).SelectedValue;
                    obj.Teaching_Learning_Outcomes = ((DropDownList)row.FindControl("gvDdlTeaching_Learning_OutcomesValue")).SelectedValue;
                    obj.Need_Ability_Group = ((DropDownList)row.FindControl("gvDdlNeed_Ability_GroupValue")).SelectedValue;
                    obj.Collaboration = ((DropDownList)row.FindControl("gvDdlCollaborationValue")).SelectedValue;
                    obj.Hot_and_Reflection = ((DropDownList)row.FindControl("gvDdlHot_and_ReflectionValue")).SelectedValue;
                    obj.Clear_Instruction = ((DropDownList)row.FindControl("gvDdlClear_InstructionValue")).SelectedValue;
                    obj.Tech_Cross_Curricular_Links = ((DropDownList)row.FindControl("gvDdlTech_Cross_Curricular_LinksValue")).SelectedValue;
                    obj.AFL = ((DropDownList)row.FindControl("gvDdlAFLValue")).SelectedValue;
                    obj.Peer_Address = ((DropDownList)row.FindControl("gvDdlPeer_AddressValue")).SelectedValue;
                    obj.Suppor_Feedback = ((DropDownList)row.FindControl("gvDdlSuppor_FeedbackValue")).SelectedValue;
                    obj.Time_Management = ((DropDownList)row.FindControl("gvDdlTime_ManagementValue")).SelectedValue;
                    obj.Teaching_Grade = ((DropDownList)row.FindControl("gvDdlTeaching_GradeValue")).SelectedValue;
                    obj.Interaction = ((DropDownList)row.FindControl("gvDdlInteractionValue")).SelectedValue;
                    obj.Make_Connection = ((DropDownList)row.FindControl("gvDdlMake_ConnectionValue")).SelectedValue;
                    obj.Actively_Engaged = ((DropDownList)row.FindControl("gvDdlActively_EngagedValue")).SelectedValue;
                    obj.Collaborate = ((DropDownList)row.FindControl("gvDdlCollaborateValue")).SelectedValue;
                    obj.Reflect = ((DropDownList)row.FindControl("gvDdlReflectValue")).SelectedValue;
                    obj.HOT = ((DropDownList)row.FindControl("gvDdlHOTValue")).SelectedValue;
                    obj.Communicate_Effectively = ((DropDownList)row.FindControl("gvDdlCommunicate_EffectivelyValue")).SelectedValue;
                    obj.Student_Grade = ((DropDownList)row.FindControl("gvDdlStudent_GradeValue")).SelectedValue;
                    obj.Self_Disciplined = ((DropDownList)row.FindControl("gvDdlSelf_DisciplinedValue")).SelectedValue;
                    obj.Positive_Relation_Student = ((DropDownList)row.FindControl("gvDdlPositive_Relation_StudentValue")).SelectedValue;
                    obj.Positive_Relation_Adult = ((DropDownList)row.FindControl("gvDdlPositive_Relation_AdultValue")).SelectedValue;
                    obj.Attitude_Relationship_Grade = ((DropDownList)row.FindControl("gvDdlAttitude_Relationship_GradeValue")).SelectedValue;
                    obj.Care_Classroom_Positive_Relationship_Peers = ((DropDownList)row.FindControl("gvDdlCare_Classroom_Positive_Relationship_PeersValue")).SelectedValue;
                    obj.Care_Classroom_Relation_Adult = ((DropDownList)row.FindControl("gvDdlCare_Classroom_Relation_AdultValue")).SelectedValue;
                    obj.Settled_Well = ((DropDownList)row.FindControl("gvDdlSettled_WellValue")).SelectedValue;
                    obj.Caring_Sharing = ((DropDownList)row.FindControl("gvDdlCaring_SharingValue")).SelectedValue;
                    obj.Listen_Follow_Instruction = ((DropDownList)row.FindControl("gvDdlListen_Follow_InstructionValue")).SelectedValue;
                    obj.Teacher_Children_Needs = ((DropDownList)row.FindControl("gvDdlTeacher_Children_NeedsValue")).SelectedValue;
                    obj.Care_Classroom_Grade = ((DropDownList)row.FindControl("gvDdlCare_Classroom_GradeValue")).SelectedValue;
                    obj.Student_Progress = ((DropDownList)row.FindControl("gvDdlOverallProgress_Student_Progress")).SelectedValue;
                    obj.Overall_Lesson_Grade = ((DropDownList)row.FindControl("gvDdlOverallProgress_overall_lesson_grade")).SelectedValue;
                    obj.EBI1 = ((TextBox)row.FindControl("gvDdlOverallProgress_EBI1")).Text;
                    obj.EBI2 = ((TextBox)row.FindControl("gvDdlOverallProgress_EBI2")).Text;
                    obj.EBI3 = ((TextBox)row.FindControl("gvDdlOverallProgress_EBI3")).Text;
                    obj.Siqa_Endorsed = ((DropDownList)row.FindControl("gvDdlSiqa_EndorsedValue")).SelectedValue;
                    obj.Consolidatio_Id = Convert.ToInt32(((HiddenField)row.FindControl("gvHfConsolidatio_IdValue")).Value);


                    //Session["Region_Id"] = clickedRow.Cells[52].Text == "&nbsp;" ? "" : clickedRow.Cells[52].Text;
                    //Session["Center_Id"] = clickedRow.Cells[53].Text == "&nbsp;" ? "" : clickedRow.Cells[53].Text;
                    //Session["Keystage_id"] = clickedRow.Cells[54].Text == "&nbsp;" ? "" : clickedRow.Cells[54].Text;
                    BLLSiqa objdata = new BLLSiqa();
                    DataTable dt = new DataTable();
                    dt = objdata.Get_Value_Basedon_Loconsolidationid(obj.Consolidatio_Id);

                    obj.UpdateBy = Session["ContactID"].ToString();

                    int result = obj.Lo_Consolidation_Update(obj);
                    if (result == 1)
                    {
                        obj.Exec_SEF_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                        //Create History
                        if (obj.Siqa_Endorsed == "YES")
                        {
                            obj.Lo_consolidation_History(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
                        }

                        BindGrid();
                        cal_Overall_grades();
                        cal_Overall_grades_Center();
                        ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
                    }
                    obj = null;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SetActiveTab();", true);
                }
            }
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
        int consolidatio_id = Convert.ToInt32(((HiddenField)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gvHfConsolidatio_IdValue")).Value);
        bool chkbx_v = ((CheckBox)gvloconsolidation.Rows[clickedRow.RowIndex].FindControl("gv_chkbx_campus_head")).Checked;
        string updated_by = Session["ContactID"].ToString();
        int result = obj.Lo_Consolidation_campus_head_operation(consolidatio_id, chkbx_v, updated_by);
        if (result == 1)
        {
            // BindGrid();
            // ImpromptuHelper.ShowPrompt("Record Updated Successfuly");
            BLLSiqa objdata = new BLLSiqa();
            DataTable dt = new DataTable();
            dt = objdata.Get_Value_Basedon_Loconsolidationid(consolidatio_id);
            obj.UpdateBy = Session["ContactID"].ToString();
            obj.Exec_SEF_Formulas(dt.Rows[0]["Region_Id"].ToString(), dt.Rows[0]["Center_Id"].ToString(), dt.Rows[0]["Keystage_id"].ToString(), dt.Rows[0]["Subject_Id"].ToString());
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
        else if(ddlkeystage.SelectedValue == "KS4" && ddl_region.SelectedValue == "30000000")
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

        Get_subjects(Class_ID, ddl_region.SelectedValue);
        //DataTable dtsubjects = ExecuteProcedure("CS", Class_ID, ddl_region.SelectedValue);
        //if (dtsubjects.Rows.Count > 0)
        //{

        //    objBase.FillDropDown(dtsubjects, ddlsubjects, "Subject_ID", "Subject_Name");
        //}


        BindGrid();
        cal_Overall_grades();
        cal_Overall_grades_Center();

        if (ddlkeystage.SelectedValue == "EYFS" || ddlkeystage.SelectedValue == "KS1")
        {
            HideDiv.Visible = true;
            HideDiv1.Visible = true;
        }
        else
        {
            HideDiv.Visible = false;
            HideDiv1.Visible = false;
        }

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "$('#" + ddlteacher.ClientID + "').select2();", true);
    }

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


    protected void gvloconsolidation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Check if the row is a data row
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
                    DropDownList ddl = cell.FindControl("gvDdlFormatValue") as DropDownList;

                    DropDownList ddl1 = cell.FindControl("gvDdlObj_OutcomsValue") as DropDownList;
                    DropDownList ddl2 = cell.FindControl("gvDdlLP_Learning_OutcomesValue") as DropDownList;
                    DropDownList ddl3 = cell.FindControl("gvDdlCur_AdaptedValue") as DropDownList;
                    DropDownList ddl4 = cell.FindControl("gvDdlCross_Curricular_LinksValue") as DropDownList;
                    DropDownList ddl5 = cell.FindControl("gvDdlLesson_EvaluationValue") as DropDownList;
                    DropDownList ddl6 = cell.FindControl("gvDdlLesson_GradeValue") as DropDownList;
                    DropDownList ddl7 = cell.FindControl("gvDdlSubject_KnowledgeValue") as DropDownList;
                    DropDownList ddl8 = cell.FindControl("gvDdlClear_LoValue") as DropDownList;
                    DropDownList ddl9 = cell.FindControl("gvDdlTeaching_Learning_OutcomesValue") as DropDownList;
                    DropDownList ddl10 = cell.FindControl("gvDdlNeed_Ability_GroupValue") as DropDownList;
                    DropDownList ddl11 = cell.FindControl("gvDdlCollaborationValue") as DropDownList;
                    DropDownList ddl12 = cell.FindControl("gvDdlHot_and_ReflectionValue") as DropDownList;
                    DropDownList ddl13 = cell.FindControl("gvDdlClear_InstructionValue") as DropDownList;
                    DropDownList ddl14 = cell.FindControl("gvDdlTech_Cross_Curricular_LinksValue") as DropDownList;

                    DropDownList ddl15 = cell.FindControl("gvDdlAFLValue") as DropDownList;
                    DropDownList ddl16 = cell.FindControl("gvDdlPeer_AddressValue") as DropDownList;
                    DropDownList ddl17 = cell.FindControl("gvDdlSuppor_FeedbackValue") as DropDownList;
                    DropDownList ddl18 = cell.FindControl("gvDdlTime_ManagementValue") as DropDownList;
                    DropDownList ddl19 = cell.FindControl("gvDdlTeaching_GradeValue") as DropDownList;
                    DropDownList ddl20 = cell.FindControl("gvDdlInteractionValue") as DropDownList;

                    DropDownList ddl21 = cell.FindControl("gvDdlMake_ConnectionValue") as DropDownList;
                    DropDownList ddl22 = cell.FindControl("gvDdlActively_EngagedValue") as DropDownList;
                    DropDownList ddl23 = cell.FindControl("gvDdlCollaborateValue") as DropDownList;
                    DropDownList ddl24 = cell.FindControl("gvDdlReflectValue") as DropDownList;

                    DropDownList ddl25 = cell.FindControl("gvDdlHOTValue") as DropDownList;
                    DropDownList ddl26 = cell.FindControl("gvDdlCommunicate_EffectivelyValue") as DropDownList;
                    DropDownList ddl27 = cell.FindControl("gvDdlStudent_GradeValue") as DropDownList;
                    DropDownList ddl28 = cell.FindControl("gvDdlSelf_DisciplinedValue") as DropDownList;

                    DropDownList ddl29 = cell.FindControl("gvDdlPositive_Relation_StudentValue") as DropDownList;
                    DropDownList ddl30 = cell.FindControl("gvDdlPositive_Relation_AdultValue") as DropDownList;
                    DropDownList ddl31 = cell.FindControl("gvDdlAttitude_Relationship_GradeValue") as DropDownList;
                    DropDownList ddl32 = cell.FindControl("gvDdlCare_Classroom_Positive_Relationship_PeersValue") as DropDownList;
                    DropDownList ddl33 = cell.FindControl("gvDdlCare_Classroom_Relation_AdultValue") as DropDownList;

                    DropDownList ddl34 = cell.FindControl("gvDdlSettled_WellValue") as DropDownList;
                    DropDownList ddl35 = cell.FindControl("gvDdlCaring_SharingValue") as DropDownList;
                    DropDownList ddl36 = cell.FindControl("gvDdlListen_Follow_InstructionValue") as DropDownList;
                    DropDownList ddl37 = cell.FindControl("gvDdlTeacher_Children_NeedsValue") as DropDownList;
                    DropDownList ddl38 = cell.FindControl("gvDdlCare_Classroom_GradeValue") as DropDownList;

                    DropDownList ddl39 = cell.FindControl("gvDdlOverallProgress_Student_Progress") as DropDownList;
                    DropDownList ddl40 = cell.FindControl("gvDdlOverallProgress_overall_lesson_grade") as DropDownList;
                    DropDownList ddl41 = cell.FindControl("gvDdlSiqa_EndorsedValue") as DropDownList;



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
                        ddl28.Enabled = false;
                        ddl29.Enabled = false;
                        ddl30.Enabled = false;
                        ddl31.Enabled = false;
                        ddl32.Enabled = false;
                        ddl33.Enabled = false;
                        ddl34.Enabled = false;
                        ddl35.Enabled = false;
                        ddl36.Enabled = false;
                        ddl37.Enabled = false;
                        ddl38.Enabled = false;
                        ddl39.Enabled = false;
                        ddl40.Enabled = false;
                        ddl41.Enabled = false;

                    }
                }
            }
        }

    }

    protected void btnUpdateSIQAEndorsed_Click(object sender, EventArgs e)
    {
        string selectedValue = ddlSiqaEndorsed.SelectedValue;

        // Iterate through the GridView rows and update the DropDownList values
        foreach (GridViewRow row in gvloconsolidation.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)row.FindControl("gvDdlSiqa_EndorsedValue");
                if (ddl != null)
                {
                    ddl.SelectedValue = selectedValue;
                }
            }
        }
    }

    protected void ddlgrade_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddlgrade.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddltechgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 3)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }
        //}
        //else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }

        //}
        //else
        //{
        //    ddlgrade.SelectedIndex = 0;
        //    ImpromptuHelper.errorShowPrompt("Please Select Key Stage");

        //}



    }

    protected void ddltechgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] StudentLearningSkillsLovSelectedValuesArray = new string[3];
        StudentLearningSkillsLovSelectedValuesArray[0] = ddltechgrade.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[1] = ddgradestudentlearningskills.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[2] = ddlstudentprogress.SelectedValue.ToString();

        if (StudentLearningSkillsLovSelectedValuesArray.Contains("OS"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 1;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("G"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 2;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("A"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 3;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("UA"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 4;
        }

        //if (ddlgrade.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddltechgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 3)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }
        //}
        //else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }

        //}
        //else
        //{
        //    ddltechgrade.SelectedIndex = 0;
        //    ImpromptuHelper.errorShowPrompt("Please Select Key Stage");
        //}
    }

    protected void ddgradestudentlearningskills_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlgrade.SelectedItem.Text == "OS")
        {
            countallgrades_OS += 1;
        }
        else if (ddlgrade.SelectedItem.Text == "G")
        {
            countallgrades_G += 1;
        }
        else if (ddlgrade.SelectedItem.Text == "A")
        {
            countallgrades_A += 1;
        }
        else if (ddlgrade.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }

        if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        {
            countallgrades_OS += 3;
        }
        else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        {
            countallgrades_G += 3;
        }
        else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        {
            countallgrades_A += 3;
        }
        else if (ddlstudentprogress.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }
        else if (ddltechgrade.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }
        else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }

        if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        {
            countallgrades_OS += 1;
        }
        else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        {
            countallgrades_G += 1;
        }
        else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        {
            countallgrades_A += 1;
        }
        else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }


        if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        {
            countallgrades_OS += 1;
        }
        else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        {
            countallgrades_G += 1;
        }
        else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        {
            countallgrades_A += 1;
        }
        else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        {
            countallgrades_UA += 1;
        }


        if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2)
        {
            if (countallgrades_OS >= 4 && countallgrades_G == 2)
            {
                ddloveralllesssongrade.SelectedIndex = 1;
            }
            else if (countallgrades_OS >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 1;
            }
            else if (countallgrades_G >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 2;
            }
            else if (countallgrades_A >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 3;
            }
            else if (countallgrades_UA >= 3)
            {
                ddloveralllesssongrade.SelectedIndex = 4;
            }
            else
            {
                ddloveralllesssongrade.SelectedIndex = 5;
            }
        }
        else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        {
            if (countallgrades_OS >= 4 && countallgrades_G == 2)
            {
                ddloveralllesssongrade.SelectedIndex = 1;
            }
            else if (countallgrades_OS >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 1;
            }
            else if (countallgrades_G >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 2;
            }
            else if (countallgrades_A >= 4)
            {
                ddloveralllesssongrade.SelectedIndex = 3;
            }
            else if (countallgrades_UA >= 2)
            {
                ddloveralllesssongrade.SelectedIndex = 4;
            }
            else
            {
                ddloveralllesssongrade.SelectedIndex = 5;
            }

        }
        else
        {
            ddgradestudentlearningskills.SelectedIndex = 0;
            // ImpromptuHelper.errorShowPrompt("Please Select Key Stage");
        }
    }

    protected void ddlgradeattituderelationship_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlgrade.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddltechgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 3)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }
        //}
        //else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }

        //}
        //else
        //{
        //    ddlgradeattituderelationship.SelectedIndex = 0;
        //    ImpromptuHelper.errorShowPrompt("Please Select Key Stage");
        //}
    }

    protected void ddlgradecareandclassromroutine_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlgrade.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddltechgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 3)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }
        //}
        //else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }

        //}
        //else
        //{
        //    ddlgradecareandclassromroutine.SelectedIndex = 0;
        //    ImpromptuHelper.errorShowPrompt("Please Select Key Stage");
        //}
    }

    protected void ddlstudentprogress_SelectedIndexChanged(object sender, EventArgs e)
    {
        grade_overall_cal();
        //if (ddlgrade.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if(ddlgrade.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgrade.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlstudentprogress.SelectedItem.Text == "OS" && ddltechgrade.SelectedItem.Text == "OS" && ddgradestudentlearningskills.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "G" && ddltechgrade.SelectedItem.Text == "G" && ddgradestudentlearningskills.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "A" && ddltechgrade.SelectedItem.Text == "A" && ddgradestudentlearningskills.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 3;
        //}
        //else if (ddlstudentprogress.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddltechgrade.SelectedItem.Text == "UA" )
        //{
        //    countallgrades_UA += 1;
        //}
        //else if (ddgradestudentlearningskills.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}

        //if (ddlgradeattituderelationship.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradeattituderelationship.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlgradecareandclassromroutine.SelectedItem.Text == "OS")
        //{
        //    countallgrades_OS += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "G")
        //{
        //    countallgrades_G += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "A")
        //{
        //    countallgrades_A += 1;
        //}
        //else if (ddlgradecareandclassromroutine.SelectedItem.Text == "UA")
        //{
        //    countallgrades_UA += 1;
        //}


        //if (ddlkeystage.SelectedIndex == 1 || ddlkeystage.SelectedIndex == 2 )
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 3)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }
        //}
        //else if (ddlkeystage.SelectedIndex == 3 || ddlkeystage.SelectedIndex == 4 || ddlkeystage.SelectedIndex == 5 || ddlkeystage.SelectedIndex == 6)
        //{
        //    if (countallgrades_OS >= 4 && countallgrades_G == 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_OS >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 1;
        //    }
        //    else if (countallgrades_G >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 2;
        //    }
        //    else if (countallgrades_A >= 4)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 3;
        //    }
        //    else if (countallgrades_UA >= 2)
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 4;
        //    }
        //    else
        //    {
        //        ddloveralllesssongrade.SelectedIndex = 5;
        //    }

        //}
        //else
        //{
        //    ddlstudentprogress.SelectedIndex = 0;
        //    ImpromptuHelper.errorShowPrompt("Please Select Key Stage");
        //}
    }



    //SR Work Start
    DataTable ExecuteProcedure(string sAction, string Class_ID, string Region_ID)
    {

        DataTable DT_Data = null;
        //obj_Access.CreateProcedureCommand("SP_CampusSubjectCommentsCorrection");
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
    public void cal_Overall_grades()
    {
        lblTotal.Text = gvloconsolidationhistory.Rows.Count.ToString();
        float countTotal = 0;// gvloconsolidationhistory.Rows.Count;
        float countUA = 0, countAcc = 0, countG = 0, countOS = 0;
        for (int i = 0; i < gvloconsolidationhistory.Rows.Count; i++)
        {
            GridViewRow row = gvloconsolidationhistory.Rows[i];
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbk = (CheckBox)row.FindControl("gv_chkbx_campus_head_History");
                if (cbk.Checked)
                {
                    countTotal += 1;
                    DropDownList ddl = (DropDownList)row.FindControl("gvDdlOverallProgress_overall_lesson_grade");
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

        }
        if (countTotal > 0)
        {
            lblUA.Text = Math.Round((countUA / countTotal) * 100, 2).ToString() + " %";
            lblAcc.Text = Math.Round((countAcc / countTotal) * 100, 2).ToString() + " %";
            lblGood.Text = Math.Round((countG / countTotal) * 100, 2).ToString() + " %";
            lblOS.Text = Math.Round((countOS / countTotal) * 100, 2).ToString() + " %";
        }
        else
        {
            lblUA.Text = "0 %";
            lblAcc.Text = "0 %";
            lblGood.Text = "0 %";
            lblOS.Text = "0 %";
        }
    }
    public void cal_Overall_grades_Center()
    {
        lblTotal_Center.Text = gvloconsolidation.Rows.Count.ToString();
        float countTotal = 0;// gvloconsolidation.Rows.Count;
        float countUA = 0, countAcc = 0, countG = 0, countOS = 0;
        for (int i = 0; i < gvloconsolidation.Rows.Count; i++)
        {
            GridViewRow row = gvloconsolidation.Rows[i];
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbk = (CheckBox)row.FindControl("gv_chkbx_campus_head");
                if (cbk.Checked)
                {
                    countTotal += 1;
                    DropDownList ddl = (DropDownList)row.FindControl("gvDdlOverallProgress_overall_lesson_grade");
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

    public void grade_overall_cal()
    {
        string[] StudentLearningSkillsLovSelectedValuesArray = new string[3];
        StudentLearningSkillsLovSelectedValuesArray[0] = ddltechgrade.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[1] = ddgradestudentlearningskills.SelectedValue.ToString();
        StudentLearningSkillsLovSelectedValuesArray[2] = ddlstudentprogress.SelectedValue.ToString();

        if (StudentLearningSkillsLovSelectedValuesArray.Contains("OS"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 1;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("G"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 2;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("A"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 3;
        }
        if (StudentLearningSkillsLovSelectedValuesArray.Contains("UA"))
        {
            this.ddloveralllesssongrade.SelectedIndex = 4;
        }
    }
    //SR Work END


    protected void btnloconsolidationexport_Click(object sender, EventArgs e)
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



            dt = objdata.Search_Lo_Consolidated_Export(
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



            dthistory = objdata.Siqa_Endorsed_Grades_Export(
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


    protected void Get_subjects(string Class_ID, string Region_ID)
    {
        DataTable DT = new DataTable();
        DT = ExecuteProcedure("CS", Class_ID, Region_ID);
        if (DT.Rows.Count > 0)
        {
            if (ddlkeystage.SelectedItem.Text.ToString() != "KS1")
            {
                DataRow rowMusic = DT.NewRow();
                rowMusic["Subject_ID"] = 64;
                rowMusic["Subject_Name"] = "Music and Art";
                DT.Rows.Add(rowMusic);
            }


            DataRow rowLibrary = DT.NewRow();
            rowLibrary["Subject_ID"] = 9998;
            rowLibrary["Subject_Name"] = "Library";
            DT.Rows.Add(rowLibrary);


            DataRow rowPE = DT.NewRow();
            rowPE["Subject_ID"] = 9999;
            rowPE["Subject_Name"] = "PE";
            DT.Rows.Add(rowPE);
            objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");
            DT.Dispose();

        }
        else
        {
            DT = null;
            objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");
        }

    }
}