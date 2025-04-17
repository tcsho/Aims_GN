using City.Library.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_Studentzeromarksandatt : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 0; //--Bifurcation Class 8--\\
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadRegions();
            FillActiveSessions();
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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            loadCenter();
            ddlterm.SelectedValue = null;
            ddlSession.SelectedValue = null;
            Grid_IEPStudents.DataSource = null;
            Grid_IEPStudents.DataBind();
            lblmsg.Visible = false;
            // DataTable dt_class = exec_sp_Studentzeromarksandatt(Session["Session_id"].ToString(), ddlterm.SelectedItem.Value, ddl_region.SelectedItem.Value, ddl_center.SelectedItem.Value);
            // Grid_IEPStudents.DataSource = dt_class;
            // Grid_IEPStudents.DataBind();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        

    }

    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dt_class = exec_sp_Studentzeromarksandatt(Session["Session_id"].ToString(), ddlterm.SelectedItem.Value, ddl_region.SelectedItem.Value, ddl_center.SelectedItem.Value);
        //Grid_IEPStudents.DataSource = dt_class;
        //Grid_IEPStudents.DataBind();
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void loadRegions()
    {
        try
        {

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            DataRow row = (DataRow)Session["rightsRow"];
            if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3) || (Convert.ToInt32(row["User_Type_Id"].ToString()) == 25) || (Convert.ToInt32(row["User_Type_Id"].ToString()) == 4 || (Convert.ToInt32(row["User_Type_Id"].ToString()) == 33)))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                ddl_region.Enabled = false;
                loadCenter();
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

            BLLCenter objCen = new BLLCenter();
            if (Region_Id != 0)
            {
                objCen.Region_Id = Region_Id;
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            DataRow row = (DataRow)Session["rightsRow"];
            if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                ddl_center.SelectedValue = row["Center_Id"].ToString();
                ddl_region.Enabled = false;
                ddl_center.Enabled = false;
            }
            if (Center_Id != 0)
            {
                ddl_center.SelectedValue = Center_Id.ToString();
                ddl_center.Enabled = false;
                ddl_center_SelectedIndexChanged(this, EventArgs.Empty);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    public DataTable exec_SP(string Center, string Class, string Action)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Center_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);
        param[2] = new SqlParameter("@Term", 1);
        param[3] = new SqlParameter("@Action", Action);
        DataTable dt = objBase.sqlcmdFetch("Sp_View_IEP", param);
        dt.Dispose();
        return dt;
    }
    public DataTable exec_sp_Studentzeromarksandatt(string session, string Term,string region, string Campus)
    {
        try
        {

    
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@session", session);
        param[1] = new SqlParameter("@Term", Term);
        param[2] = new SqlParameter("@region", region == "0" ? "" : region);
        param[3] = new SqlParameter("@Campus", ddl_center.SelectedItem.Value == "0" ? "" : ddl_center.SelectedItem.Value);
        DataTable dt = objBase.sqlcmdFetch("sp_Studentzeromarksandatt", param);
        dt.Dispose();
        return dt;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public DataTable sp_bifurcatedlist(string Center, string Class, string Action)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Center_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);

        DataTable dt = objBase.sqlcmdFetch("sp_bifrcatedstudentlist", param);
        dt.Dispose();
        return dt;
    }
    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid_IEPStudents.Rows.Count > 0)
            {
                Grid_IEPStudents.UseAccessibleHeader = false;
                Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_IEP_bifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("Term_id", Term_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


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





    protected void Grid_IEPStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (ddlClass.SelectedItem.Value != "12")
        //{
        //    e.Row.Cells[7].Visible = false;
        //    e.Row.Cells[8].Visible = false;
        //    e.Row.Cells[9].Visible = false;
        //}
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
    }

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (ddl_region.SelectedItem.Value == "0" || ddlSession.SelectedItem.Value == "0" || ddlterm.SelectedItem.Value == "0")
        {
            lblmsg.Text = "Please Select Mandatory fields";
            lblmsg.Visible = true;
        }
        else
        {

            DataTable dt_class = exec_sp_Studentzeromarksandatt(ddlSession.SelectedItem.Value, ddlterm.SelectedItem.Value, ddl_region.SelectedItem.Value, "");
            Grid_IEPStudents.DataSource = dt_class;
            Grid_IEPStudents.DataBind();
        }
    }
}