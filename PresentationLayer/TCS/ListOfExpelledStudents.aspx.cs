using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_ListOfExpelledStudents : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];
        if (!IsPostBack)
        {
            try
            {
                ViewState["MainOrgId"] = 0;
                ViewState["RegionId"] = 0;
                ViewState["CenterId"] = 0;
                /////////Setting ///////////////
                if (row["User_Type"].ToString() != "SAdmin")
                {
                }

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = 0;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = row["Center_Id"].ToString();
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                }
                loadRegions();
                FillActiveSessions();
                ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                ViewState["Mode"] = "Expel";
                ViewState["Class"] = null;
                ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                FillClass();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }
        }
    }
    #region 'Common'
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 13).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
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

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                ddl_region.SelectedValue = ViewState["RegionId"].ToString();
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
            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                objCen.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            {
                ddl_center.SelectedValue = ViewState["CenterId"].ToString();
                ddl_center.Enabled = false;

            }

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
            ViewState["Expel"] = null;
            loadCenter();
            BindExpelGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedIndex > 0)
            {
                ViewState["Expel"] = null;
                BindExpelGrid();
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
            ViewState["Expel"] = null;
            BindExpelGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Expel"] = null;
            BindExpelGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    #endregion
    #region 'Expel'
    protected void BindExpelGrid()
    {
        try
        {
           

            if (ddlClass.SelectedIndex > 0)
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            else
                obj.Class_Id = null;
            if (ddl_center.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            else
                obj.Center_Id = 0;
            if (ddl_region.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            else
                obj.Region_Id = 0;
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            DataTable dt = new DataTable();
            if (ViewState["Expel"] == null)
            {
                dt = obj.Student_Expelled(obj);
                ViewState["Expel"] = dt;
            }
            else
                dt = (DataTable)ViewState["Expel"];

            if (dt.Rows.Count > 0)
            {
                tdSearch.Visible = true;
                gvExpel.DataSource = dt;
                gvExpel.DataBind();
                lblGridStatus.Text = "";
            }
            else
            {
                tdSearch.Visible = false;
                gvExpel.DataSource = null;
                gvExpel.DataBind();
                lblGridStatus.Text = "No Record Found!";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvExpel_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvExpel.Rows.Count > 0)
            {
                gvExpel.UseAccessibleHeader = false;
                gvExpel.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvExpel.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnExpel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlClass.Visible = true;

            ViewState["Mode"] = "Expel";
            if (ddlSession.SelectedIndex > 0)
                BindExpelGrid();
            else
                ImpromptuHelper.ShowPrompt("Please select a Session");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    #endregion

    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            Button btnEdit = (Button)sender;
            int status = Convert.ToInt32(btnEdit.CommandArgument);
            ViewReport obj = new ViewReport();
            obj.TermGroup_Id= 2; //Students are explled after final term 
            string url = "../TCS";
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvExpel.SelectedIndex = gvr.RowIndex;
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;

            obj.Class_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Student_Id=Convert.ToInt32(gvr.Cells[0].Text);
            if (status == 1)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.Section_Id= Convert.ToInt32(gvr.Cells[4].Text);
            }
            else if (status == 2)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue) - 1;
                obj.Section_Id= Convert.ToInt32(gvr.Cells[5].Text);
            }
            url =url+ obj.OpenReport(obj);  
            if (!String.IsNullOrEmpty(url))
            {
                //url = "../PresentationLayer/TCS/" + url;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

}

