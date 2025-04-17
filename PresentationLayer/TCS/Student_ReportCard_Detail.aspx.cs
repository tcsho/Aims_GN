using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Configuration;


public partial class PresentationLayer_TCS_Student_ReportCard_Detail : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    public static int MOId = 1, Region_Id = 0, Center_Id = 0, Class_Id = 0, Session_Id = 13, TermGroup_Id = 2;


    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            dt.Dispose();
            objBase.FillDropDown(dt, ddl_session, "Session_ID", "Description");
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
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();
            dt.Dispose();
            oDALRegion.Main_Organisation_Country_Id = MOId;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");

            if (Region_Id != 0)
            {
                ddl_region.SelectedValue = Region_Id.ToString();
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
            dt.Dispose();
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

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
    protected void loadClass()
    {
        try
        {
            BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            int center = Convert.ToInt32(ddl_center.SelectedValue);
            dt = obj.Class_CenterFetch(center);
            dt.Dispose();
            objBase.FillDropDown(dt, ddl_class, "Class_Id", "Class_Name");
            ddl_class.SelectedValue = "0";

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void ResetFilter()
    {
        ddl_region.SelectedIndex = 0;
        ddl_center.SelectedIndex = 0;
        ddl_class.SelectedIndex = 0;
        ddl_session.SelectedIndex = 0;
        BindGrid();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"];
        string queryStr = Request.QueryString["id"];
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = 0;
                    Center_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                    ddl_session_SelectedIndexChanged(this, EventArgs.Empty);
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = row["Center_Id"].ToString();
                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    loadRegions();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                    ddl_session_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                }

            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }

    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public DataTable exec_sp()
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = Class_Id;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[4].Value = TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            objBase.OpenConnection();
            _dt = objBase.sqlcmdFetch("sp_get_ReportCard_URL", param);
            _dt.Dispose();
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            objBase.CloseConnection();
        }

        return _dt;
    }

    private void BindGrid()
    {
        try
        {
            Session_Id = Convert.ToInt32(ddl_session.SelectedValue);
            Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            Class_Id = Convert.ToInt32(ddl_class.SelectedValue);
            TermGroup_Id = 2;

            DataTable dtsub = exec_sp();
            dtsub.Dispose();

            if (dtsub.Rows.Count > 0)
            {
                gv_details.DataSource = dtsub;
                gv_details.DataBind();

            }
            else
            {
                gv_details.DataSource = null;
                gv_details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void ddl_session_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_session.SelectedItem.Text == "Select")
            {
                gv_details.DataSource = null;
                gv_details.DataBind();
            }
            if (ddl_session.SelectedIndex > 0 && ddl_region.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            {
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Region,Center and Session!");
            }

            //if (ddl_class.SelectedIndex > 0)
            //{
            //    ddl_class.SelectedIndex = -1;
            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void DDLReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }
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
            loadCenter();

            if (ddl_region.SelectedItem.Text == "Select")
            {

                ddl_center.SelectedIndex = 0;
                ddl_session.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();

            }

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
            if (ddl_center.SelectedItem.Text == "Select")
            {
                ddl_session.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();
            }
            else
                loadClass();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{

        //    TextBox txttotaldays;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {



        //        txttotaldays = (TextBox)e.Row.FindControl("txttermdays");
        //        DataRow row = ((DataRowView)e.Row.DataItem).Row;

        //        if (Convert.ToInt32(row["Submit_RD"]) == 1)//Generated
        //        {

        //            txttotaldays.Enabled = false;
        //        }
        //        else if (Convert.ToInt32(row["Submit_RD"]) == 0)//Not Generated
        //        {


        //            txttotaldays.Enabled = true;
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}