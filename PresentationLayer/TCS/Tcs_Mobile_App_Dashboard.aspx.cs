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

public partial class PresentationLayer_Tcs_Mobile_App_Dashboard : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
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


                //search();
            }
            Get_Total_Registered_Parents();
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
        PresentationLayer_Tcs_Mobile_App_Dashboard p = new PresentationLayer_Tcs_Mobile_App_Dashboard();

        DataSet ds = new DataSet();
        //ds = p.exec_SP("1");
        string JSONresult;
        // string JSONresult1;
        //JavaScriptSerializer ser = new JavaScriptSerializer();
        //JSONresult = ser.Serialize(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });//JsonConvert.SerializeObject(ds.Tables[0]);


        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });
        return JSONresult;

    }
    [WebMethod]
    public static string grap2()
    {
        PresentationLayer_Tcs_Mobile_App_Dashboard p = new PresentationLayer_Tcs_Mobile_App_Dashboard();

        DataSet ds = new DataSet();
        //ds = p.exec_SP("2");
        string JSONresult;

        //JavaScriptSerializer ser = new JavaScriptSerializer();
        //JSONresult = ser.Serialize(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });//JsonConvert.SerializeObject(ds.Tables[0]);


        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0] });
        return JSONresult;



    }
    [WebMethod]
    public static string grap3(string schoolname)
    {


        PresentationLayer_Tcs_Mobile_App_Dashboard p = new PresentationLayer_Tcs_Mobile_App_Dashboard();

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
            //if (ddlTerm.SelectedIndex == 0 || list_Subject.SelectedIndex == 0 || ddlClass.SelectedIndex == 0 || ddl_center.SelectedIndex == 0)
            //{
            //    ViewState["Grid"] = null;
            //    BindGrid();
            //}
            loadCenter();
            // Get_Total_Registered_Parents();
            //search();
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
            ddl_region.SelectedValue = "40000000";
            ddl_region.Enabled = false;
            ddl_Region_SelectedIndexChanged(null, null);
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
            Get_Total_Registered_Parents();

            //LoadTeachers();
            // BindGrid();
            //FillClass();
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
            Get_Total_Registered_Parents();
            //DataTable DT = ExecuteProcedure("CS", ddlclass.SelectedValue, ddl_region.SelectedValue);
            //DT.Dispose();
            //if (DT.Rows.Count > 0)
            //{
            //    objBase.FillDropDown(DT, ddlsubjects, "Subject_ID", "Subject_Name");

            //}

            ////DataTable dtsections = objSiqa.Get_Sections(int.Parse(ddl_center.SelectedValue), int.Parse(ddlclass.SelectedValue));

            ////if (dtsections.Rows.Count > 0)
            ////{
            ////   // objBase.FillDropDown(dtsections, ddlsections, "Section_Id", "Section_Name");

            ////}
            //// BindGrid();
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
        if (ddlSession.SelectedValue != "")
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
        ods = null;
        ods = obj.Get_Total_Registered_Parents(obj);
        DataTable dtparents = ods.Tables[0];
        if (dtparents == null)
        {
            ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            // return;
        }
        else
        {
            lbltotalparents.Text = dtparents.Rows[0]["TotalParents"].ToString();
            lblregisteredparents.Text = dtparents.Rows[0]["RegisterdParent"].ToString();
            //lblunregisteredparents.Text = Convert.ToString(Convert.ToInt32(dtparents.Rows[0]["TotalParents"].ToString()) - Convert.ToInt32(dtparents.Rows[0]["RegisterdParent"].ToString()));
            lblunregisteredparents.Text = ((Convert.ToDouble(dtparents.Rows[0]["RegisterdParent"]) / Convert.ToDouble(dtparents.Rows[0]["TotalParents"])) * 100).ToString("F2") + "%";
        }




        DataTable dtstudents = ods.Tables[1];
        if (dtstudents.Rows.Count > 0)
        {
            if (dtstudents == null)
            {
                ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
                //return;
            }
            else
            {
                lbltotalstudents.Text = dtstudents.Rows[0]["TotalStudents"].ToString();
                lblregisteredstudents.Text = dtstudents.Rows[0]["RegisteredStudents"].ToString();
                lblunregisteredstudents.Text = Convert.ToString(Convert.ToInt32(dtstudents.Rows[0]["TotalStudents"].ToString()) - Convert.ToInt32(dtstudents.Rows[0]["RegisteredStudents"].ToString()));
            }
        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            //return;
        }


        DataTable dtstudentsattendance = ods.Tables[2];
        if (dtstudentsattendance == null)
        {
            ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            return;
        }
        else
        {
            lbltstudents.Text = dtstudentsattendance.Rows[0]["TotalStudents"].ToString();
            lblmarkedatten.Text = dtstudentsattendance.Rows[0]["Marked_Attendance"].ToString();
            lblunmarkedatt.Text = dtstudentsattendance.Rows[0]["UnMarked_Attendance"].ToString();
        }


        DataTable dtsections = ods.Tables[3];
        if (dtsections == null)
        {
            ImpromptuHelper.ShowPromptGeneric("No Data Found...", 0);
            //return;
        }
        else
        {
            lbltotalsections.Text = dtsections.Rows[0]["TotalSections"].ToString();
            lblactivesections.Text = dtsections.Rows[0]["ActiveSections"].ToString();
            lblinactivesections.Text = Convert.ToString(Convert.ToInt32(dtsections.Rows[0]["TotalSections"].ToString()) - Convert.ToInt32(dtsections.Rows[0]["ActiveSections"].ToString()));
        }
    }


}