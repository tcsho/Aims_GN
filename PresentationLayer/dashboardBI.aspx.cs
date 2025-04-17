using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Drawing;
using City.Library.SQL;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_dashboardBI : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        //BLLCenter objCen = new BLLCenter();
        //objCen.Region_Id = Convert.ToInt32(Session["RegionID"]);
        //DataTable dt = objCen.CenterFetchByRegionID(objCen);
        //objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
        //gridbind();


        try
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.but_Export);
            scriptManager.RegisterPostBackControl(this.btnunregisteredexport);
            scriptManager.RegisterPostBackControl(this.btnunregisteredstudentexport);
            scriptManager.RegisterPostBackControl(this.btnmissingclasstestresultexport);
            scriptManager.RegisterPostBackControl(this.Btnexportunmarkedclasswork);

            


            if (!Page.IsPostBack)
            {
                text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //TabName.Value = Request.Form[TabName.UniqueID];

                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["moID"].ToString());



                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "check";
                // LoadClassSection();
                FillActiveSessions();
                loadRegions();


                DataTable TermGroups = new DataTable();
                //* TermGroups = objSiqa.Evaluation_Criteria_TypeFetch();


                //***********************************
                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    //ddl_region.SelectedValue = row["Region_Id"].ToString();
                    //ddl_center.SelectedValue = row["Center_Id"].ToString();
                    //ddl_center_SelectedIndexChanged(sender, e);
                    //ddl_region.Enabled = false;
                    //ddl_center.Enabled = false;


                  

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

                //Get_Total_Registered_Parents();
                //search();
            }

            //Get_Total_Registered_Parents();
        }
        catch (Exception ex)
        {
            // Session["error"] = ex.Message;
            // Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gridbind()
    {
        //DataTable dt_class = exec_SPgrid("4");
        //Grid_IEPStudents.DataSource = dt_class;
        //Grid_IEPStudents.DataBind();
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            //    if (Grid_IEPStudents.Rows.Count > 0)
            //    {
            //        Grid_IEPStudents.UseAccessibleHeader = false;
            //        Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public DataTable exec_SPgrid(string Action)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_id", Convert.ToInt32(Session["Session_Id"]));
        param[1] = new SqlParameter("@Action", Action);
        //DataTable dt = objBase.sqlcmdFetch("sp_iep_kpis", param);
        DataTable dt = null;
        dt.Dispose();
        return dt;
    }
    protected void Grid_IEPStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cnt = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //If Salary is less than 10000 than set the row Background Color to Cyan  
            if (e.Row.Cells[3].Text == "Yes" && e.Row.Cells[4].Text == "Yes" && e.Row.Cells[5].Text == "Yes" && e.Row.Cells[6].Text == "Yes")
            {
                e.Row.BackColor = Color.Red;
            }
            if (e.Row.Cells[3].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[4].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[5].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[6].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[7].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[8].Text == "Yes")
            {
                cnt++;
            }
            e.Row.Cells[9].Text = cnt.ToString();

            if (cnt == 6)
            {
                e.Row.Cells[10].Text = "Privatized";
            }
            else
            {
                e.Row.Cells[10].Text = "Enrolled";

            }
        }
    }
    [WebMethod]

    public static string grap()
    {
        PresentationLayer_dashboardBI p = new PresentationLayer_dashboardBI();

        DataSet ds = new DataSet();
        //ds = p.exec_SP("1");
        string JSONresult;


        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });
        return JSONresult;

    }
    [WebMethod]
    public static string grap2()
    {
        PresentationLayer_dashboardBI p = new PresentationLayer_dashboardBI();

        DataSet ds = new DataSet();
        //ds = p.exec_SP("2");
        string JSONresult;




        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0] });
        return JSONresult;



    }
    [WebMethod]
    public static string grap3(string schoolname)
    {


        PresentationLayer_dashboardBI p = new PresentationLayer_dashboardBI();

        DataSet ds = new DataSet();
        //ds = p.exec_SP("3", schoolname);
        string JSONresult;



        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0] });
        return JSONresult;



    }




    //************************************

    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            loadCenter();
            Get_Total_Registered_Parents();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void loadRegions()
    {
        try
        {
            string q = Request.QueryString["id"];
            string s = Request.QueryString["id"];


            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);
            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
           // ddl_region.SelectedValue = "0";
           // ddl_region.Enabled = true;
           // ddl_Region_SelectedIndexChanged(null, null);
            //loadCenter();
            // BindCheckBoxListControl(dt, lstRegion, "Region_Id", "Region_Name");
            ////////////UserInformationGrid2.SetData(dt);

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
            //if (Convert.ToBoolean(row["Center"].ToString()) != true)
            //{
            BLLClass objCS = new BLLClass();
            // objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            objCS.Center_Id = Int32.Parse(ddl_center.SelectedValue);
            dtclass = objCS.Fetch_ClassesBasedonCenter_Dashboard(objCS);
            objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");
            //}
            //else
            //{
            //    BLLClass_Center objCC = new BLLClass_Center();

            //    DataRow rrow = (DataRow)Session["rightsRow"];
            //    objCC.Center_ID = Convert.ToInt32(rrow["Center_Id"].ToString());
            //    dtclass = objCC.Class_CenterFetch(objCC);
            //    objBase.FillDropDown(dtclass, ddlclass, "Class_Id", "Class_Name");
            //}
            Get_Total_Registered_Parents();

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


    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //***********2024-09-16***
            DataTable DT = FetchSubjects("CS", ddlclass.SelectedValue, ddl_region.SelectedValue);
            if (DT.Rows.Count > 0)
            {
                objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");
            }
            Get_Total_Registered_Parents();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    DataTable FetchSubjects(string sAction, string Class_ID, string Region_ID)
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

    private void loadCenter()
    {
        try
        {
            //ddlClass.Items.Clear();
            //list_Subject.Items.Clear();
            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

            objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");


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

    protected void Get_Total_Registered_Parents()
    {
        BLLTcs_Mobile_App_Dashboard obj = new BLLTcs_Mobile_App_Dashboard();
        DataSet ods = new DataSet();
        obj.Session_Id = 0;
        obj.Region_Id = 0;
        if (ddlSession.SelectedValue != "")
            obj.Session_Id = int.Parse(ddlSession.SelectedValue.ToString());
        if (ddl_region.SelectedValue != "")
            obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        if (ddl_center.SelectedValue.ToString() == "")
        {
            obj.Center_Id = 0;
        }
        else
        {
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        }
        if (ddlclass.SelectedValue.ToString() == "")
        {
            obj.Class_ID = 0;
        }
        else
        {
            obj.Class_ID = Convert.ToInt32(ddlclass.SelectedValue.ToString());
        }
        if (ddlsubjects.SelectedValue.ToString() == "")
        {
            obj.Subject_Id = 0;
        }
        else
        {
            obj.Subject_Id = Convert.ToInt32(ddlsubjects.SelectedValue.ToString());
        }
        obj.Current_Date = text_date.Text.ToString();
        ods = null;
        ods = obj.Get_Total_Registered_Parents(obj);
        DataTable dtparents = ods.Tables[0];
        if (dtparents.Rows.Count > 0)
        {
            if (dtparents == null)
            {
                ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                lbltotalparents.Text = dtparents.Rows[0]["TotalParents"].ToString();
                lblregisteredparents.Text = dtparents.Rows[0]["RegisterdParent"].ToString();
                lbltotalparents_percentage.Text = ((Convert.ToDouble(dtparents.Rows[0]["RegisterdParent"]) / Convert.ToDouble(dtparents.Rows[0]["TotalParents"])) * 100).ToString("F2") + "%";
            }
        }
        else
        {
            lbltotalparents.Text = "0";
            lblregisteredparents.Text = "0";
            lbltotalparents_percentage.Text = "0".ToString() + "%";
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }




        DataTable dtstudents = ods.Tables[1];
        if (dtstudents.Rows.Count > 0)
        {
            if (dtstudents == null)
            {
                //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                //return;
            }
            else
            {
                lbltotalstudents.InnerText = dtstudents.Rows[0]["TotalStudents"].ToString();
                lblregisteredstudents.Text = dtstudents.Rows[0]["RegisteredStudents"].ToString();
                lbltotalstudents_percentage.Text = ((Convert.ToDouble(dtstudents.Rows[0]["RegisteredStudents"]) / Convert.ToDouble(dtstudents.Rows[0]["TotalStudents"])) * 100).ToString("F2") + "%";
            }


        }
        else
        {


            lbltotalstudents.InnerText = "0";
            lblregisteredstudents.Text = "0";
            lbltotalstudents_percentage.Text = "0".ToString() + "%";
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            //return;
        }


        DataTable dtstudentsattendance = ods.Tables[2];
        if (dtstudentsattendance.Rows.Count > 0)
        {
            if (dtstudentsattendance == null)
            {
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);

            }
            else
            {
                lbltstudents.Text = dtstudentsattendance.Rows[0]["TotalStudents"].ToString();
                lblmarkedatten.Text = dtstudentsattendance.Rows[0]["Marked_Attendance"].ToString();
                lbltstudents_percentage.Text = ((Convert.ToDouble(dtstudentsattendance.Rows[0]["Marked_Attendance"]) / Convert.ToDouble(dtstudentsattendance.Rows[0]["TotalStudents"])) * 100).ToString("F2") + "%";
            }
        }
        else
        {
            lbltstudents.Text = "0";
            lblmarkedatten.Text = "0";
            lbltstudents_percentage.Text = "0".ToString() + "%";
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }

        DataTable dtsections = ods.Tables[3];
        if (dtsections.Rows.Count > 0)
        {
            if (dtsections == null)
            {
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                //return;
            }
            else
            {
                lbltotalsections.Text = dtsections.Rows[0]["TotalSections"].ToString();
                lblactivesections.Text = dtsections.Rows[0]["ActiveSections"].ToString();
                if (dtsections.Rows[0]["TotalSections"].ToString() != "0")
                {
                    lbltotalsections_percentage.Text = ((Convert.ToDouble(dtsections.Rows[0]["ActiveSections"]) / Convert.ToDouble(dtsections.Rows[0]["TotalSections"])) * 100).ToString("F2") + "%";
                }
                else
                {
                    lbltotalsections_percentage.Text = 0.ToString("F2") + "%";
                }
            }
        }
        else
        {
            lbltotalsections.Text = "0";
            lblactivesections.Text = "0";
            lbltotalsections_percentage.Text = "0".ToString() + "%";
        }


        //****************************Class Test Result****************************************

        DataTable dtclasstestresult = ods.Tables[4];
        if (dtclasstestresult.Rows.Count > 0)
        {
            if (dtclasstestresult == null)
            {
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            }
            else
            {
                lbltotalstudentsforclassresult.Text = dtclasstestresult.Rows[0]["TotalStudents"].ToString();
                lblclasstestresult.Text = dtclasstestresult.Rows[0]["Class_Test_Result"].ToString();
                lblResult_percentage.Text = ((Convert.ToDouble(dtclasstestresult.Rows[0]["Class_Test_Result"]) / Convert.ToDouble(dtclasstestresult.Rows[0]["TotalStudents"])) * 100).ToString("F2") + "%";
            }
        }
        else
        {
            lblclasstestresult.Text = "0";
            lblResult_percentage.Text = "0";
            lbltotalstudentsforclassresult.Text = "0".ToString() + "%";
        }



        //****************************ClassWork****************************************

        DataTable dtclasswork = ods.Tables[5];
        if (dtclasswork.Rows.Count > 0)
        {
            if (dtclasswork == null)
            {
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);

            }
            else
            {
                lblclassworktotal.InnerText = dtclasswork.Rows[0]["TotalSections"].ToString();
                lblclasswork.Text = dtclasswork.Rows[0]["ActiveSections"].ToString();
                lblclasswork_Percentage.Text = ((Convert.ToDouble(dtclasswork.Rows[0]["ActiveSections"]) / Convert.ToDouble(dtclasswork.Rows[0]["TotalSections"])) * 100).ToString("F2") + "%";
            }
        }
        else
        {
            lblclassworktotal.InnerText = "0";
            lblclasswork.Text = "0";
            lblclasswork_Percentage.Text = "0".ToString() + "%";
        }
    }



    protected void lbltstudents_percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewStudentDetail();", true);
        DataTable dtabsentstudents = ApplyFilter("Student_Attendance_Detail");
        if (dtabsentstudents.Rows.Count > 0)
        {
            if (dtabsentstudents == null)
            {
                gvstudentdetail.DataSource = null;
                gvstudentdetail.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvstudentdetail.DataSource = dtabsentstudents;
                gvstudentdetail.DataBind();
            }
            // System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvstudentdetail.DataSource = null;
            gvstudentdetail.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dtabsentstudents = null;
    }


    protected void gvstudentdetail_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvstudentdetail.Rows.Count > 0)
            {
                gvstudentdetail.UseAccessibleHeader = false;
                gvstudentdetail.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void but_Export_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewRejectionModal();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("Student_Attendance_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "StudentsData");
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


    public DataTable ApplyFilter(string dashboard_Name)
    {
        DataTable dt = new DataTable();
        BLLTcs_Mobile_App_Dashboard obj = new BLLTcs_Mobile_App_Dashboard();
        DataSet ods = new DataSet();
        obj.Session_Id = 0;
        obj.Region_Id = 0;
        if (ddlSession.SelectedValue != "")
            obj.Session_Id = int.Parse(ddlSession.SelectedValue.ToString());
        if (ddl_region.SelectedValue != "")
            obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        if (ddl_center.SelectedValue.ToString() == "")
        {
            obj.Center_Id = 0;
        }
        else
        {
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        }



        if (ddlclass.SelectedValue.ToString() == "")
        {
            obj.Class_ID = 0;
        }
        else
        {
            obj.Class_ID = Convert.ToInt32(ddlclass.SelectedValue.ToString());
        }
        if (ddlsubjects.SelectedValue.ToString() == "")
        {
            obj.Subject_Id = 0;
        }
        else
        {
            obj.Subject_Id = Convert.ToInt32(ddlsubjects.SelectedValue.ToString());
        }
        obj.Current_Date = text_date.Text.ToString();
        if (dashboard_Name == "Student_Attendance_Detail")
        {
            ods = obj.Get_Student_Attendance_Detail(obj);
            dt = ods.Tables[0];
        }

        if (dashboard_Name == "Unregistered_Parents_Detail")
        {
            ods = obj.Unregistered_Parents_Detail(obj);
            dt = ods.Tables[0];
        }
        if (dashboard_Name == "UnRegistered_Student_Detail")
        {
            ods = obj.Unregistered_Student_Detail(obj);
            dt = ods.Tables[0];
        }
        if (dashboard_Name == "Unmarked_HomeworkDiary_Detail")
        {
            ods = obj.Unmarked_HomeWork_Diary_Detail(obj);
            dt = ods.Tables[0];
        }
        if (dashboard_Name == "Unmarked_Classwork_Detail")
        {
            ods = obj.sp_Dashboard_Classwork_Detail(obj);
            dt = ods.Tables[0];
        }
        if (dashboard_Name == "Missing_ClassTest_Result_Detail")
        {
            ods = obj.Dashboard_ClassTestResult_Detail(obj);
            dt = ods.Tables[0];
        }
        return dt;
    }


    protected void lbltotalparents_percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnregisteredParents();", true);
        DataTable dt = ApplyFilter("Unregistered_Parents_Detail");
        if (dt.Rows.Count > 0)
        {
            if (dt == null)
            {
                gvunregisteredparents.DataSource = null;
                gvunregisteredparents.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvunregisteredparents.DataSource = dt;
                gvunregisteredparents.DataBind();
            }
            //System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvunregisteredparents.DataSource = null;
            gvunregisteredparents.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dt = null;
    }


    protected void gvunregisteredparents_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvunregisteredparents.Rows.Count > 0)
            {
                gvunregisteredparents.UseAccessibleHeader = false;
                gvunregisteredparents.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnunregisteredexport_Click(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnregisteredParents();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("Unregistered_Parents_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Unregistered_Parents");
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



    protected void lbltotalstudents_percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnRegisteredStudentDetail();", true);
        DataTable dt = ApplyFilter("UnRegistered_Student_Detail");
        if (dt.Rows.Count > 0)
        {
            if (dt == null)
            {
                gvunregisteredstudentdetail.DataSource = null;
                gvunregisteredstudentdetail.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvunregisteredstudentdetail.DataSource = dt;
                gvunregisteredstudentdetail.DataBind();
            }
            // System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvunregisteredstudentdetail.DataSource = null;
            gvunregisteredstudentdetail.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dt = null;
    }



    protected void btnunregisteredstudentexport_Click(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnRegisteredStudentDetail();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("UnRegistered_Student_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Unregistered_Students");
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


    protected void gvunregisteredstudentdetail_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvunregisteredstudentdetail.Rows.Count > 0)
            {
                gvunregisteredstudentdetail.UseAccessibleHeader = false;
                gvunregisteredstudentdetail.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvunmarkedhomeworkdiary_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvunmarkedhomeworkdiary.Rows.Count > 0)
            {
                gvunmarkedhomeworkdiary.UseAccessibleHeader = false;
                gvunmarkedhomeworkdiary.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    protected void lbltotalsections_percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedhomeworkdiaryDetail();", true);
        DataTable dt = ApplyFilter("Unmarked_HomeworkDiary_Detail");
        if (dt.Rows.Count > 0)
        {
            if (dt == null)
            {
                gvunmarkedhomeworkdiary.DataSource = null;
                gvunmarkedhomeworkdiary.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvunmarkedhomeworkdiary.DataSource = dt;
                gvunmarkedhomeworkdiary.DataBind();
            }
            //System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvunmarkedhomeworkdiary.DataSource = null;
            gvunmarkedhomeworkdiary.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dt = null;
    }

    protected void btnunmarkedhomeworkdiaryexport_Click(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedhomeworkdiaryDetail();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("Unmarked_HomeworkDiary_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Unmarked_HomeworkDiary");
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

    protected void ddlsubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Total_Registered_Parents();
    }

    protected void lblclasswork_Percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedDailyworkDetail();", true);
        DataTable dt = ApplyFilter("Unmarked_Classwork_Detail");
        if (dt.Rows.Count > 0)
        {
            if (dt == null)
            {
                gvunmarkedClasswork.DataSource = null;
                gvunmarkedClasswork.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvunmarkedClasswork.DataSource = dt;
                gvunmarkedClasswork.DataBind();
            }
            //System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvunmarkedClasswork.DataSource = null;
            gvunmarkedClasswork.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dt = null;
    }

    protected void text_date_TextChanged(object sender, EventArgs e)
    {
        Get_Total_Registered_Parents();
    }

    protected void lblResult_percentage_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedResultDetail();", true);
        DataTable dt = ApplyFilter("Missing_ClassTest_Result_Detail");
        if (dt.Rows.Count > 0)
        {
            if (dt == null)
            {
                gvclasstestresultdetail.DataSource = null;
                gvclasstestresultdetail.DataBind();
                // ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                // return;
            }
            else
            {
                gvclasstestresultdetail.DataSource = dt;
                gvclasstestresultdetail.DataBind();
            }
            //System.Threading.Thread.Sleep(3000);
        }
        else
        {
            gvclasstestresultdetail.DataSource = null;
            gvclasstestresultdetail.DataBind();
            //ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
        }
        dt = null;
    }
    protected void gvclasstestresultdetail_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvunregisteredstudentdetail.Rows.Count > 0)
            {
                gvunregisteredstudentdetail.UseAccessibleHeader = false;
                gvunregisteredstudentdetail.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnmissingclasstestresultexport_Click(object sender, EventArgs e)
    {
        try
        {

           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedhomeworkdiaryDetail();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("Missing_ClassTest_Result_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Missing_ClassTest_Result_Detail");
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


    //Unmarked_Classwork_Detail

    protected void Btnexportunmarkedclasswork_Click(object sender, EventArgs e)
    {
        try
        {

             ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewUnmarkedhomeworkdiaryDetail();", true);

            DataTable dt = new DataTable();
            dt = ApplyFilter("Unmarked_Classwork_Detail");
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Unmarked_Classwork_Detail");
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