using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_ListOfPrivatizedStudents : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
    protected void Page_Load(object sender, EventArgs e)
    {
        DALBase objBase = new DALBase();
        BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
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
                 
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }
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
    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
            ViewState["Private"] = null;
            BindPrivateGrid();
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
            ViewState["Private"] = null;
            BindPrivateGrid();
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
            ViewState["Private"] = null;
            BindPrivateGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
  


    protected void BindPrivateGrid()
    {
        try
        {
           
            DataTable dt = new DataTable();
            if (ddl_center.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            else
                obj.Center_Id = 0;
            if (ddl_region.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            else
                obj.Region_Id = 0;
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            if (ViewState["Class"] == null)
                obj.Class_Id = 0;
            else
                obj.Class_Id = Convert.ToInt32(ViewState["Class"].ToString());
            if (ViewState["Private"] == null)
            {
                dt = obj.Student_Privatisation(obj);
                ViewState["Private"] = dt;
            }
            else
                dt = (DataTable)ViewState["Private"];
            if (dt.Rows.Count > 0)
            {
                divPrivate.Visible = true;
                tdSearch.Visible = true;
                gvPrivate.DataSource = dt;
                gvPrivate.DataBind();
                lblGridStatus.Text = "";
                
            }
            else
            {
                divPrivate.Visible = false;
                tdSearch.Visible = false;
                gvPrivate.DataSource = null;
                gvPrivate.DataBind();
                // SetEmptyGrid(gvPrivate);
                lblGridStatus.Text = "No Record Found!";
            }
         
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvPrivate_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvPrivate.Rows.Count > 0)
            {
                gvPrivate.UseAccessibleHeader = false;
                gvPrivate.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvPrivate.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnPrivate_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Private";
            
            ViewState["Class"] = null;
            BindPrivateGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnOlevels_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterPrivatisation();
            ApplyFilterPrivatisation(1);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAlevles_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterPrivatisation();
            ApplyFilterPrivatisation(2);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterPrivatisation();
            ApplyFilterPrivatisation(3);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilterPrivatisation(int _FilterCondition)
    {
        try
        {

            if (ViewState["Private"] != null)
            {
                DataTable dt = (DataTable)ViewState["Private"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // Olevels 
                        {

                            strFilter = " Convert([Class_Id], 'System.String')='15'";
                            break;
                        }

                    case 2: // Alevel
                        {
                            strFilter = " Convert([Class_Id], 'System.String')='20'";
                            break;
                        }

                    case 3: // All
                        {
                            //strFilter = " Convert([Class_Id], 'System.String')='1'";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvPrivate.DataSource = dv;
                gvPrivate.DataBind();
                gvPrivate.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilterPrivatisation()
    {
        try
        {
            //       ViewState["dtDetails"] = null;
            BindPrivateGrid();
            gvPrivate.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            string url = "../TCS";
            Button btnEdit = (Button)sender;
            
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvPrivate.SelectedIndex = gvr.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Class_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Section_Id= Convert.ToInt32(gvr.Cells[4].Text);
            obj.TermGroup_Id= 1; //Students are privatised after Midterm 
            obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;
            url = url+obj.OpenReport(obj);
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

    protected void btnCompile_Click(object sender, EventArgs e)
    {
        try
        {
            obj.Center_Id=Convert.ToInt32(ddl_center.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            int k= obj.Student_PrivatiseCenterWise(obj);
            if (k == 0)
            {
                ViewState["Private"] = null;
                BindPrivateGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}