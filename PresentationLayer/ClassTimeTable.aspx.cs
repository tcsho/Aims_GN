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

public partial class PresentationLayer_ClassTimeTable : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    //BLLSiqa objSiqa = new BLLSiqa();
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
                FillActiveSessions();
       
                DataTable TermGroups = new DataTable();
               //* TermGroups = objSiqa.Evaluation_Criteria_TypeFetch();
                

                //***********************************
                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = false;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }
                search();
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
            BLLClassTimetable obj = new BLLClassTimetable();

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



            if (ddlSession.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Session", 0);
                return;
            }
            obj.Session_id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

            if (txtstarttime.Text.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Start Time", 0);
                return;
            }
            obj.Starttime = Convert.ToDateTime(txtstarttime.Text.ToString());
            if (txtendtime.Text.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select End Time", 0);
                return;
            }
            obj.Endtime = Convert.ToDateTime(txtendtime.Text.ToString());
            obj.IsActive = true;
            obj.CreateBy = Session["ContactID"].ToString();


            int result = obj.TimeTable_Insert(obj);
            if (result == 1)
            {
                ImpromptuHelper.ShowPrompt("Record Already Exist");
            }
            else if (result == 3)
            {
                ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
            }
            search();
            //    if (result == 1)
            //    {
            //        Clear_Data();
            //        BindGrid();
            //        ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");

            //    }

            //    // BindGrid();
            //    // Response.Redirect("~/PresentationLayer/LoConsolidation.aspx");
            //    // Response.Redirect("~/PresentationLayer/TCS/LmsStudentDropbox.aspx");

            //    obj = null;
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

    //private void BindGrid()
    //{
    //    try
    //    {
    //        BLLSiqa objdata = new BLLSiqa();
    //        DataTable dt = new DataTable();

    //        if (ddl_region.SelectedValue.ToString() != "0")
    //        {
    //            Session["Region_Id"] = ddl_region.SelectedValue.ToString();
    //        }
    //        if (ddl_center.SelectedValue.ToString() != "0")
    //        {
    //            Session["Center_Id"] = ddl_center.SelectedValue.ToString();
    //        }
    //        //if (ddlkeystage.SelectedValue.ToString() != "")
    //        //{
    //        //    Session["Keystage_id"] = ddlkeystage.SelectedItem.Text.ToString();
    //        //}



    //        //dt = objdata.Search_Lo_Consolidated(
    //        //    ddl_region.SelectedValue.ToString(),
    //        //    ddl_center.SelectedValue.ToString(),
    //        //    ddlteacher.SelectedValue.ToString(),
    //        //    ddlclass.SelectedValue.ToString(),
    //        //    ddlsubjects.SelectedValue.ToString(),
    //        //    //ddl_grouphead.SelectedValue.ToString(),
    //        //    ddlkeystage.SelectedValue.ToString()
    //        //    );
    //        if (dt != null)
    //        {
    //            if (dt.Rows.Count > 0)
    //            {
    //                //gvloconsolidation.DataSource = dt;
    //                //gvloconsolidation.DataBind();
    //            }
    //            else
    //            {
    //                //gvloconsolidation.DataSource = null;
    //                //gvloconsolidation.DataBind();

    //            }
    //        }
    //        else
    //        {
    //            //gvloconsolidation.DataSource = null;
    //            //gvloconsolidation.DataBind();
    //        }
    //        //if (ddlClass.SelectedValue != "0" && ddlTerm.SelectedValue != "0" && list_Subject.SelectedValue != "0")
    //        //{

    //        //    SetParams();

    //        //    objStudent.Session_Id = Convert.ToInt32(Session["Session_Id"]);

    //        //    objStudent.Term_Id = Convert.ToInt32(ddlTerm.SelectedValue);
    //        //    objStudent.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue);

    //        //    objStudent.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

    //        //    objStudent.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);


    //        //    if (ViewState["Grid"] != null)
    //        //    {
    //        //        dt = (DataTable)ViewState["Grid"];
    //        //    }
    //        //    else
    //        //    {
    //        //        dt = objStudent.StudentSelectBySection_IdForSubjectCommentsCorrection(objStudent);
    //        //    }


    //        //}
    //        //else
    //        //{

    //        //}

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}

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
            search();
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
            //if (ddlTerm.SelectedIndex == 0 || list_Subject.SelectedIndex == 0 || ddlClass.SelectedIndex == 0)
            //{
            //    ViewState["Grid"] = null;
            //    BindGrid();
            //}
            //row["Center_Id"].ToString();
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
           // BindGrid();
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

            //DataTable dtsections = objSiqa.Get_Sections(int.Parse(ddl_center.SelectedValue), int.Parse(ddlclass.SelectedValue));

            //if (dtsections.Rows.Count > 0)
            //{
            //   // objBase.FillDropDown(dtsections, ddlsections, "Section_Id", "Section_Name");

            //}
           // BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedValue = Session["Session_Id"].ToString();
            ddlSession.Enabled = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void gvloconsolidation_PreRender(object sender, EventArgs e)
    {
        try
        {
            //if (gvloconsolidation.Rows.Count > 0)
            //{
            //    gvloconsolidation.UseAccessibleHeader = false;
            //    gvloconsolidation.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void ddl_grouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }


    public void Clear_Data()
    {
        //// this.ddl_region.SelectedIndex = -1;
        //// this.ddl_center.SelectedIndex = -1;
        // this.ddlteacher.SelectedIndex = -1;
        //// this.ddl_grouphead.SelectedIndex = -1;
        // this.ddlclass.SelectedIndex = -1;
        // this.ddlsubjects.SelectedIndex = -1;
        // this.ddlsections.SelectedIndex = -1;
        // this.ddlformat.SelectedIndex = -1;
        // //this.ddlkeystage.SelectedIndex = -1;
        // this.ddlobjectiveoutcome.SelectedIndex = -1;
        // this.ddlactivitieslearningoutcome.SelectedIndex = -1;
        // this.ddlcurrentaddapted.SelectedIndex = -1;

        // this.ddlcrosscurricularlinks.SelectedIndex = -1;
        // this.ddllessoneva.SelectedIndex = -1;
        // this.ddlgrade.SelectedIndex = -1;
        // this.ddlclearlo.SelectedIndex = -1;
        // this.ddltecactlearnoutcom.SelectedIndex = -1;
        // this.ddlabilitygroup.SelectedIndex = -1;
        // this.ddlCollaboration.SelectedIndex = -1;
        // this.ddlhotandreflection.SelectedIndex = -1;
        // this.ddlclearinst.SelectedIndex = -1;

        // this.ddlcclinks.SelectedIndex = -1;
        // this.dddafl.SelectedIndex = -1;
        // this.ddlselfpeeraccess.SelectedIndex = -1;
        // this.ddlsupportandfb.SelectedIndex = -1;
        // this.ddltimemanagement.SelectedIndex = -1;
        // this.ddlLearningEnv.SelectedIndex = -1;
        // this.ddltechgrade.SelectedIndex = -1;
        // this.ddlinteraction.SelectedIndex = -1;
        // this.ddlmarkconnections.SelectedIndex = -1;
        // this.ddlCollaborate.SelectedIndex = -1;

        // this.ddlactivityengaged.SelectedIndex = -1;

        // this.ddlReflect.SelectedIndex = -1;

        // this.ddlhot.SelectedIndex = -1;

        // this.ddlceffectively.SelectedIndex = -1;


        // this.ddgradestudentlearningskills.SelectedIndex = -1;


        // this.ddlselfdisciplined.SelectedIndex = -1;


        // this.ddlpositiverelationadults.SelectedIndex = -1;
        // this.ddlgradeattituderelationship.SelectedIndex = -1;
        // this.ddlpositiverelationpeers.SelectedIndex = -1;


        // this.ddlpositiverelfamiliaradults.SelectedIndex = -1;
        // this.ddlsettledwell.SelectedIndex = -1;
        // this.ddlcaringsharing.SelectedIndex = -1;


        // this.ddllistenfollowinstructions.SelectedIndex = -1;
        // this.ddlteachersenstowardschild.SelectedIndex = -1;
        // this.ddlgradecareandclassromroutine.SelectedIndex = -1;

        // this.ddlstudentprogress.SelectedIndex = -1;
        // this.ddloveralllesssongrade.SelectedIndex = -1;

        // this.txtEBI1.Text = "";
        // this.txtEBI2.Text = "";
        // this.txtEBI3.Text = "";
    }

    protected void ddlTeachingLov_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string[] TeachingLovSelectedValuesArray = new string[4];
        //TeachingLovSelectedValuesArray[0] = ddlsubjectknowledge.SelectedValue.ToString();
        //TeachingLovSelectedValuesArray[1] = ddltecactlearnoutcom.SelectedValue.ToString();
        //TeachingLovSelectedValuesArray[2] = ddlabilitygroup.SelectedValue.ToString();
        //TeachingLovSelectedValuesArray[3] = dddafl.SelectedValue.ToString();

        //if (TeachingLovSelectedValuesArray.Contains("OS"))
        //{
        //    this.ddltechgrade.SelectedIndex = 1;
        //}
        //if (TeachingLovSelectedValuesArray.Contains("G"))
        //{
        //    this.ddltechgrade.SelectedIndex = 2;
        //}
        //if (TeachingLovSelectedValuesArray.Contains("A"))
        //{
        //    this.ddltechgrade.SelectedIndex = 3;
        //}
        //if (TeachingLovSelectedValuesArray.Contains("UA"))
        //{
        //    this.ddltechgrade.SelectedIndex = 4;
        //}
    }






    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
       // BindGrid();
    }

    protected void ddlsubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
    }



    protected void ddlkeystage_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
    }


    private void search()
    {
        try
        {
            ///searching
            ///
            BLLClassTimetable obj = new BLLClassTimetable();
            DataTable dt;

            //int moId = Int32.Parse(Session["moID"].ToString());

            dt = obj.Get_Timetabledata(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString());
            if (dt.Rows.Count == 0)
            {
                
                dg_timetable.DataSource = null;
                dg_timetable.DataBind();
                lab_dataStatus.Visible = true;
            }
            else
            {
                ViewState["subjectDT"] = dt;

                dg_timetable.DataSource = dt;
                dg_timetable.DataBind();
                lab_dataStatus.Visible = false;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void dg_timetable_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //int ind = Int32.Parse((string)e.CommandArgument);

            //if (e.CommandName == "name")
            //{
            //    Session["SubjectID"] = dg_Uni.DataKeys[ind].Value;
            //    Response.Redirect("SubjectDetail.aspx", false);
            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void lbtndelete_Click(object sender, EventArgs e)
    {
        BLLClassTimetable obj = new BLLClassTimetable();
        LinkButton btn = (LinkButton)sender;
        int Timetableid = Convert.ToInt32(btn.CommandArgument);
        int k = obj.TimetableDelete(Timetableid);
        if (k == 0) { ImpromptuHelper.ShowPrompt("Record Delete UnSuccessfull"); }
        if (k == 1) { ImpromptuHelper.ShowPrompt("Record Deleted Successfuly"); }
        search();
        search();
    }
}