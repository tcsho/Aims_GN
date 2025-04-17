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

public partial class PresentationLayer_LoConsolidation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    BLLSiqa objSiqa = new BLLSiqa();
    private DataSet ds = null;
    private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //TabName.Value = Request.Form[TabName.UniqueID];

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
                    //ScriptManager.RegisterStartupScript(this, GetType(), "HideMenu2", "hideMenu2();", true);
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }
                BindGrid();
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
            if (ddlpositiverelationpeers.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Peers :", 0);
                return;
            }
            if (ddlpositiverelfamiliaradults.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Positive Relations Adults :", 0);
                return;
            }
            if (ddlsettledwell.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Settled Well :", 0);
                return;
            }
            if (ddlcaringsharing.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Caring/ Sharing :", 0);
                return;
            }
            if (ddllistenfollowinstructions.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Listen Follow Instructions :", 0);
                return;
            }
            if (ddlteachersenstowardschild.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Teacher Childrens Needs :", 0);
                return;
            }
            if (ddlgradecareandclassromroutine.SelectedValue.ToString() == "")
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


            DataRow row = (DataRow)Session["rightsRow"];
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
            BindGrid();
            // string jsonData = "tab1";
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "TabShowHide", "TabShowHide(" + jsonData + ");", true);

            //*****************************

        
         

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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    DataTable ExecuteProcedure(string sAction, string Class_ID, string Region_ID)
    {

        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_CampusSubjectCommentsCorrection");
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




    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable DT = ExecuteProcedure("CS", ddlclass.SelectedValue, ddl_region.SelectedValue);
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            }

            DataTable dtsections = objSiqa.Get_Sections(int.Parse(ddl_center.SelectedValue), int.Parse(ddlclass.SelectedValue));

            if (dtsections.Rows.Count > 0)
            {
                objBase.FillDropDown(dtsections, ddlsections, "Section_Id", "Section_Name");

            }
            BindGrid();
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


    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlsubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
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
        if (ddlkeystage.SelectedValue == "EYFS")
        {
            Group_ID = "1";
        }
        if (ddlkeystage.SelectedValue == "KS1")
        {
            Group_ID = "2";
        }
        if (ddlkeystage.SelectedValue == "KS2")
        {
            Group_ID = "3";
        }
        if (ddlkeystage.SelectedValue == "KS3")
        {
            Group_ID = "4";
        }
        if (ddlkeystage.SelectedValue == "KS4")
        {
            Group_ID = "5";
        }
        if (ddlkeystage.SelectedValue == "KS5")
        {
            Group_ID = "6";
        }
        if (ddlkeystage.SelectedValue == "Matric")
        {
            Group_ID = "7";
        }
        dtclass = obj.Get_Classes_Basedon_Keystage(Group_ID);
        objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");

        //DataTable dtsubjects = EvaluationGETSubject(Group_ID);
        //objBase.FillDropDown(dtsubjects, ddlsubjects, "Subject_ID", "Subject_Name");
        BindGrid();
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
        //    foreach (GridViewRow row in gvloconsolidation.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
        //            if (chkRow.Checked)
        //            {
        //                // do whatever your logic  
        //            }
        //        }
        //    }
    }
}