using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_NetworkStandAloneCenters : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLNetworkStandAloneCenters objnetwork = new BLLNetworkStandAloneCenters();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                loadRegions();
                if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level
                {
                    ddlRegion.Enabled = true;
                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO Level
                {

                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion.Enabled = false;
                }
            }
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public void BindGrid()
    {
        try
        {
            objnetwork.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            DataTable dt = objnetwork.NetworkStandAloneCentersFetch(objnetwork);
            if (dt.Rows.Count > 0)
            {
                SAcampusTite.Visible = true;
                gvCenter.DataSource = dt;
            }
            else
            {
                SAcampusTite.Visible = false;
                gvCenter.DataSource = null;
            }
            gvCenter.DataBind();

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
            ViewState["MainOrgId"] = 1;
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnCenter = (LinkButton)sender;
            objnetwork.Center_Id = Convert.ToInt32(btnCenter.CommandArgument);
            int k = objnetwork.NetworkStandAloneCentersAdd(objnetwork);

            BindGrid();
            BindAllCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvAllCenter_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvAllCenter.Rows.Count > 0)
            {
                gvAllCenter.UseAccessibleHeader = false;
                gvAllCenter.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAllCenter.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvCenter_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvCenter.Rows.Count > 0)
            {
                gvCenter.UseAccessibleHeader = false;
                gvCenter.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvCenter.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddCenter_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegion.SelectedIndex > 0)
            {
                btnAddPanel.Visible = false;
                btnCancel.Visible = true;
                divAddNew.Visible = true;
                BindAllCenter();
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Region!");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancelCenter_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = false;
            btnAddPanel.Visible = true;
            divAddNew.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void BindAllCenter()
    {
        try
        {
            objnetwork.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            DataTable dt = objnetwork.NetworkStandAloneCentersFetchAllCenter(objnetwork);
            gvAllCenter.DataSource = dt;
            gvAllCenter.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnCenter = (LinkButton)sender;
            objnetwork.Net_Cent_Id = Convert.ToInt32(btnCenter.CommandArgument);
            int k = objnetwork.NetworkStandAloneCentersDelete(objnetwork);

            BindGrid();
            BindAllCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
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