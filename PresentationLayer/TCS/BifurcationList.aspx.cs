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

public partial class PresentationLayer_TCS_BifurcationList : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadRegions();
        }
    }

    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedIndex == 0 || ddl_center.SelectedIndex == 0)
            {
                ViewState["Grid"] = null;
                //BindGrid();
            }
            loadCenter_Class();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                loadCenter_Class();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void loadCenter_Class()
    {
        try
        {
            ddlClass.Items.Clear();

            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

            objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            DataRow row = (DataRow)Session["rightsRow"];

            //if (Convert.ToInt32(row["User_Type_Id"].ToString()) != 5)
            //{
            //    ddl_center.SelectedValue = row["Center_Id"].ToString();
            //}
             if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                ddl_center.SelectedValue = row["Center_Id"].ToString();
                ddl_region.Enabled = false;
                ddl_center.Enabled = false;
            }
            DataTable dt_class = exec_SP("", "", "LOV_Class");
            objBase.FillDropDown(dt_class, ddlClass, "Class_id", "Class_Name");
            //////////UserInformationGrid3.SetData(dt);
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


    protected void ddlClass_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataTable dt_class = sp_bifurcatedlist(ddl_center.SelectedItem.Value, ddlClass.SelectedItem.Value, "1");
        Grid_IEPStudents.DataSource = dt_class;
        Grid_IEPStudents.DataBind();
       
    }

    protected void Grid_IEPStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(ddlClass.SelectedItem.Value != "12")
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }
    }
}