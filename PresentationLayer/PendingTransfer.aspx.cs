using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using Microsoft.Ajax.Utilities;
public partial class PresentationLayer_PendingTransfer : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
   // private bool isPendingCenter = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            ViewState["BindMode"] = "";  //>>>>
            if (!IsPostBack)
            {
                
                // ======== Page Access Settings ========================//
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }

                //  ====== End Page Access settings ======================//
                loadRegions();
                if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level
                {
                    ddlCenter.Enabled = true;
                    ddlRegion.Enabled = true;

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO / RD Level
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = true;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                    //****************????
                    //ViewState["BindMode"] = "Center";


                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 4)//CO Level Or Campus Head
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = false;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlCenter.SelectedValue = Session["cId"].ToString();
                    ddlCenter_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 10)// NO level 
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = true;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                }
                ViewState["BindMode"] = "Center";
                if (ViewState["IsPendingCenter"] == null)
                {
                    isPendingCenter = true; 
                }
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
            if (Session["UserLevel_Id"].ToString() == "10") // for Network Heads only 
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");
            }
            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) >= 2 && Convert.ToInt32(Session["UserLevel_Id"].ToString()) <= 5)
            //for HO,RO ,CO 
            {
                BLLCenter objCen = new BLLCenter();

                objCen.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());

                DataTable dt = new DataTable();
                dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");
            }
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

            //*********************2023-Sep-28
            //if (int.Parse(Session["RegionID"].ToString()) != 0)
            //{
            //    ddlRegion.SelectedValue = Session["RegionID"].ToString(); ;
            //    ddlRegion.Enabled = false;
            //    loadCenter();
            //}


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            loadCenter();
            if (isPendingCenter)

                BindGrid();
            else
                BindGridSection();
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if(isPendingCenter)
                BindGrid();
            else
                BindGridSection();

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvPendingCenter_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvPendingCenter.Rows.Count > 0)
            {
                gvPendingCenter.UseAccessibleHeader = false;
                gvPendingCenter.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvSection_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvSection.Rows.Count > 0)
            {
                gvSection.UseAccessibleHeader = false;
                gvSection.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindGridSection()
    {
        try
        {
            BLLStudent obj = new BLLStudent();
            if (ddlRegion.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            else
                obj.Region_Id = 0;
            if (ddlCenter.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            else
                obj.Center_Id = 0;
            DataTable dt = obj.PendingStudentSectionTransferFetch(obj);
            if (dt.Rows.Count > 0)
            {
                divStudentTitle.Visible = true;
                 gvSection.DataSource = dt;
                gvSection.DataBind();
                isPendingCenter = false;

            }
            else  //*
            {
                divStudentTitle.Visible = true;
                gvSection.DataSourceID = null;
                gvSection.DataBind();
               // isPendingCenter = false;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindGrid()
    {
        try
        {
            BLLStudent obj = new BLLStudent();
            if (ddlRegion.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            else
                obj.Region_Id = 0;
            if (ddlCenter.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            else
            obj.Center_Id = 0;
            DataTable dt = obj.PendingStudentCenterTransferFetch(obj);
            if (dt.Rows.Count > 0)
            {
                divStudentTitle.Visible = true;
                gvPendingCenter.DataSource = dt;
                gvPendingCenter.DataBind();
                lblerror.Visible = false;
            }
            else
            {
                //**********
                gvPendingCenter.DataSourceID = null;
                gvPendingCenter.DataBind();
                //isPendingCenter=false;
                //**********
                lblerror.Text = "All students have been transfered according to ERP";
                lblerror.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCenter_Click(object sender, EventArgs e)
    {
        try
        {
            isPendingCenter = true;
            Button btn = (Button)sender;
            ViewState["BindMode"] = btn.CommandArgument.ToString();
            gvSection.DataSource = null;
            gvSection.DataBind();
            //**************************
            gvSection.Visible = false;
            gvPendingCenter.Visible = true;
            //**************************
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSection_Click(object sender, EventArgs e)
    {
        try
        {
            isPendingCenter = false;
            Button btn = (Button)sender;
            ViewState["BindMode"] = btn.CommandArgument.ToString();
            gvPendingCenter.DataSource = null;
            gvPendingCenter.DataBind();
            //*******************
            gvPendingCenter.Visible = false;
            gvSection.Visible = true;
            //*******************
            BindGridSection();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvPendingCenter.SelectedIndex = gvr.RowIndex;
            BLLStudent obj = new BLLStudent();
            obj.Center_Id = Convert.ToInt32(gvr.Cells[1].Text);
            obj.Center_IdOld = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Student_Id = Convert.ToInt32(gvr.Cells[0].Text);
            obj.Grade_Id = Convert.ToInt32(gvr.Cells[3].Text);
            obj.section_name = gvr.Cells[12].Text;
            int k = obj.StudentTransfer(obj, btn.CommandArgument);
            if (k == 0)
                ImpromptuHelper.ShowPrompt("Student Transfered");
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnTransferSection_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvPendingCenter.SelectedIndex = gvr.RowIndex;
            BLLStudent obj = new BLLStudent();
            obj.Student_Id = Convert.ToInt32(gvr.Cells[0].Text);
            obj.Section_Id = Convert.ToInt32(gvr.Cells[4].Text);
            obj.StudentSectionChange(obj);
            BindGridSection();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnUnassignSectionTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvPendingCenter.SelectedIndex = gvr.RowIndex;
            BLLStudent obj = new BLLStudent();
            obj.Student_Id = Convert.ToInt32(gvr.Cells[0].Text);
            obj.Session_Id = Convert.ToInt32(gvr.Cells[5].Text);
            obj.StudentUnassign(obj);

            BindGridSection();
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private bool isPendingCenter
    {
        get
        {
            if (ViewState["IsPendingCenter"] != null)
            {
                return (bool)ViewState["IsPendingCenter"];
            }
            return true; // Default value if not yet set
        }
        set
        {
            ViewState["IsPendingCenter"] = value;
        }
    }
}