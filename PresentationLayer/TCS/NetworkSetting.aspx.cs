using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_NetworkSetting : System.Web.UI.Page
{

    BLLNetworkCenter objBllCenter = new BLLNetworkCenter();
    BLLNetworkRegion objBllRegion = new BLLNetworkRegion();
    int UserLevel, UserType;
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["EmployeeCode"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
        catch (Exception)
        {
        }
        //  //======== Page Access Settings ========================
        //DALBase objBase = new DALBase();
        //DataRow row = (DataRow)Session["rightsRow"];
        //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        //string sRet = oInfo.Name;


        //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
        //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
        ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
        //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
        //{
        //    Session.Abandon();
        //    Response.Redirect("~/login.aspx");
        //}

        ////====== End Page Access settings ======================

        UserLevel = Convert.ToInt32(Session["UserLevel_Id"].ToString());
        UserType = Convert.ToInt32(Session["UserType_Id"].ToString());

        if (!IsPostBack)
        {
            Pan_NetworkName.Visible = false;
            pan_AssigCampus.Visible = false;
            divListOfCampus.Visible = false;
            ViewState["MarkEmployee"] = "check";
            ViewState["MarkCampus"] = "check";
            ViewState["Region_Id"] = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
            loadRegions();
            loadCenters();
            load_region_dept();
            setRightsControls();
            BindGridNetwork();
        }
    }
    protected void gvNetwork_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNetwork.Rows.Count > 0)
            {
                gvNetwork.UseAccessibleHeader = false;
                gvNetwork.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvNetwork.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvAssignCampus_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNetwork.Rows.Count > 0)
            {
                gvAssignCampus.UseAccessibleHeader = false;
                gvAssignCampus.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAssignCampus.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvCampuses_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvCampuses.Rows.Count > 0)
            {
                gvCampuses.UseAccessibleHeader = false;
                gvCampuses.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvCampuses.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCenters();
        ddlCenter_SelectedIndexChanged(sender, e);

        DataTable dt = new DataTable();

        objBllRegion.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
        // objBllRegion.NetworkRegion_Id objBllRegion.NetworkRegion_Id
        dt = objBllRegion.NetworkRegionFetch(objBllRegion);
        gvNetwork.DataSource = dt;
        gvNetwork.DataBind();
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["HOD"] = null;
    }
    protected void gvCampuses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton ib = (ImageButton)e.Row.FindControl("ImageButton2");
            ib.Attributes.Add("onclick", "javascript:return " +
            "confirm('Are you sure you want to delete this record?') ");
        }
    }

    protected void load_center_dept()
    {
        DataTable _dt = new DataTable();
        if (ViewState["Region_Id"] != null)
        {
            objBllCenter.NetworkRegion_Id = Convert.ToInt32(ViewState["Region_Id"]);
        }
        else
        {
            objBllCenter.NetworkRegion_Id = Convert.ToInt32(this.ddl_region_dept.SelectedValue);
        }
        _dt = objBllCenter.NetworkCenterFetch(objBllCenter);

        ddl_center_dept.DataTextField = "Center_Name";
        ddl_center_dept.DataValueField = "Center_ID";
        ddl_center_dept.DataSource = _dt;
        ddl_center_dept.DataBind();

        if (ddl_region_dept.SelectedValue == "0")
        {
            ddl_center_dept.Items.Insert(0, new ListItem("Head Office", "0"));
        }
        else
        {
            ddl_center_dept.Items.Insert(0, new ListItem("Regional Office", "0"));
        }

        ddl_center_dept.SelectedValue = (Session["CenterID"].ToString() == "") ? "0" : Session["CenterID"].ToString();
        load_ddl_Networks();
    }

    protected void BindGridNetwork()
    {
        try
        {
            gvNetwork.DataSource = null;
            gvNetwork.DataBind();
            DataTable dt = new DataTable();
            objBllRegion.Region_Id = Convert.ToInt32(ViewState["Region_Id"]);
            dt = objBllRegion.NetworkRegionFetch(objBllRegion);
            gvNetwork.DataSource = dt;
            gvNetwork.DataBind();
        }
        catch (Exception e)
        {
            string message = e.Message;
        }
    }
    public void setRightsControls()
    {
        try
        {
            //if (UserLevel == 4)
            //{
            //    ddlRegion.Enabled = false;
            //    ddlRegions.Enabled = false;
            //    ddlCenter.Enabled = false;

            //    ddlRegion.SelectedValue = Session["RegionID"].ToString();
            //    ddlCenter.SelectedValue = Session["CenterID"].ToString();


            //    ddl_region_dept.Enabled = false;
            //    ddl_center_dept.Enabled = false;

            //    ddl_region_dept.SelectedValue = Session["RegionID"].ToString();
            //    ddl_center_dept.SelectedValue = Session["CenterID"].ToString();
            //}
            //else if (UserLevel == 3)
            //{
            //    ddlRegion.Enabled = false;
            //    ddlRegions.Enabled = false;
            //    ddlCenter.Enabled = true;

            //    ddlRegion.SelectedValue = Session["RegionID"].ToString();

            //    ddl_region_dept.Enabled = false;
            //    ddl_center_dept.Enabled = true;
            //    ddl_Networks.Enabled = false;
            //    ddl_region_dept.SelectedValue = Session["RegionID"].ToString();
            //}
            //else if (UserLevel == 1 || UserLevel == 2)
            //{
            //    ddlRegion.Enabled = true;
            //    ddlCenter.Enabled = true;
            //    ddl_region_dept.Enabled = true;
            //    ddl_center_dept.Enabled = true;
            //}
        }
        catch (Exception e)
        { }
    }
    public void loadRegions()
    {
        try
        {
            DataTable _dt = new DataTable();

            _dt = objBllCenter.NetworkRegionFetch();

            ddlRegion.DataTextField = "Region_Name";
            ddlRegion.DataValueField = "Region_Id";
            ddlRegion.DataSource = _dt;
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Head Office", "0"));
            ddlRegion.SelectedValue = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
            ddlRegions.DataTextField = "Region_Name";
            ddlRegions.DataValueField = "Region_Id";
            ddlRegions.DataSource = _dt;
            ddlRegions.DataBind();
            ddlRegions.Items.Insert(0, new ListItem("Head Office", "0"));
            ddlRegions.SelectedValue = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
        }
        catch (Exception)
        {
        }
    }
    protected void loadCenters()
    {
        try
        {
            DataTable _dt = new DataTable();
            objBllCenter.NetworkRegion_Id = Convert.ToInt32(ViewState["Region_Id"]);
            _dt = objBllCenter.NetworkCenterGet(objBllCenter);

            ddlCenter.DataTextField = "Center_Name";
            ddlCenter.DataValueField = "Center_ID";
            ddlCenter.DataSource = _dt;
            ddlCenter.DataBind();

            if (ddlRegion.SelectedValue == "0")
            {
                ddlCenter.Items.Insert(0, new ListItem("Head Office", "0"));
            }
            else
            {
                ddlCenter.Items.Insert(0, new ListItem("--Regional Office--", "0"));
            }
        }
        catch (Exception)
        {
        }
    }
    public void load_region_dept()
    {
        try
        {
            DataTable _dt = new DataTable();

            _dt = objBllCenter.NetworkRegionFetch();

            ddl_region_dept.DataTextField = "Region_Name";
            ddl_region_dept.DataValueField = "Region_Id";
            ddl_region_dept.DataSource = _dt;
            ddl_region_dept.DataBind();

            ddl_region_dept.Items.Insert(0, new ListItem("Head Office", "0"));

            ddl_region_dept.SelectedValue = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
        }
        catch (Exception)
        {
        }
    }
    protected void ddl_region_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Region_Id"] = null;
        //BindGridNetwork();
        ViewState["NetworkRegion_Id"] = null;
        ViewState["Region_Id"] = ddl_region_dept.SelectedValue;
        ddl_center_dept_SelectedIndexChanged(sender, e);

        load_center_dept();

        BindAssignCampus();
        loadCenters();

    }
    protected void gvAssignCampus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["MarkCampus"].ToString();

                foreach (GridViewRow gvr in gvAssignCampus.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (mood == "" || mood == "check")
                    {
                        cb.Checked = true;
                        ViewState["MarkCampus"] = "uncheck";
                    }
                    else
                    {
                        cb.Checked = false;
                        ViewState["MarkCampus"] = "check";
                    }

                }

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("ErrorPage.aspx", false);
        }
    }
    protected void ddl_center_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    protected void btnSaveNetWorkName_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Region_Id"] = null;
            ViewState["Region_Id"] = ddlRegion.SelectedValue;
            objBllRegion.Region_Id = Convert.ToInt32(ddlRegions.SelectedValue);
            objBllRegion.NetworkName = txtNetworkName.Text;
            objBllRegion.NetworkHemail = txtEmail.Text;
            int alreadyexist = 0;
            if (ViewState["Mode"].ToString() == "Add")
            {
                alreadyexist = objBllRegion.NetworkRegionAdd(objBllRegion);
               
            }
            else if (ViewState["Mode"].ToString() == "Edit")
            {
                objBllRegion.NetworkRegion_Id = Convert.ToInt32(ViewState["NetworkRegion_Id"].ToString());
                alreadyexist = objBllRegion.NetworkRegionUpdate(objBllRegion);
            }
            if (alreadyexist == 0)
            {
                ImpromptuHelper.ShowPrompt("Record Updated!");
                txtNetworkName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                BindGridNetwork();
                ddlRegions.SelectedValue = ViewState["Region_Id"].ToString();
            }
            btnCancel_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    protected void btnAssignNetwork_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception)
        {
        }
    }

    protected void btnSaveAssignCampus_Click(object sender, EventArgs e)
    {
        ViewState["Region_Id"] = ddlRegion.SelectedValue;
        Boolean flag = false;
        try
        {

            foreach (GridViewRow gvr in gvAssignCampus.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (cb.Checked)
                {
                    objBllCenter.NetworkRegion_Id = Convert.ToInt32(ddl_Networks.SelectedValue);
                    objBllCenter.Center_Id = Convert.ToInt32(gvAssignCampus.Rows[gvr.RowIndex].Cells[0].Text);
                    objBllCenter.NetworkCenterAdd(objBllCenter);
                    flag = true;
                }

            }
            if (flag == true)
            {
                ImpromptuHelper.ShowPrompt("Campuses Saved Sucessfully");

                gvAssignCampus.DataSource = null;
                gvAssignCampus.DataBind();
                BindGridNetwork();
            }
            else
            {

                ImpromptuHelper.ShowPrompt("No Record Save");

            }
            pan_AssigCampus.Visible = false;
            divMainList.Visible = true;
        }
        catch (Exception oException)
        {
            throw oException;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Pan_NetworkName.Visible = false;
            divMainList.Visible = true;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void btnAddNetwork_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";
            Pan_NetworkName.Visible = true;
            divMainList.Visible = false;
            divListOfCampus.Visible = false;
            pan_AssigCampus.Visible = false;
            ViewState["Region_Id"] = null;
            txtNetworkName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ViewState["Region_Id"] = ddlRegion.SelectedValue;
            BindGridNetwork();
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }

    protected void btnDelNetworkRegion_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Region_Id"] = ddlRegion.SelectedValue;
            ImageButton imgBtn = (ImageButton)sender;
            objBllRegion.NetworkRegion_Id = Int32.Parse(imgBtn.CommandArgument);

            int AlreadyIn = 0;

            AlreadyIn = objBllRegion.NetworkRegionDelete(objBllRegion);
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Netowrk Name Removed Sucessfully");
                //BindgvNetworkRegion();
                BindGridNetwork();
            }
            else
            {

                ImpromptuHelper.ShowPrompt("Please First Remove Assigned Campuses");

            }
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void btnDelNetworkCampus_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            ViewState["Region_Id"] = ddlRegion.SelectedValue;
            ViewState["NetworkRegion_Id"] = null;
            objBllCenter.NetworkCenter_Id = Convert.ToInt32(btn.CommandArgument);
            ViewState["NetworkRegion_Id"] = Convert.ToInt32(gvr.Cells[1].Text);
            objBllCenter.NetworkCenterDelete(objBllCenter);

            BindGridNetwork();
            BindGridShowCampus();
            ImpromptuHelper.ShowPrompt("Campus Removed Sucessfully");
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }

    protected void btnAddCampuses_Click(object sender, EventArgs e)
    {
        try
        {
            pan_AssigCampus.Visible = true;
            Pan_NetworkName.Visible = false;
            divListOfCampus.Visible = false;
            divMainList.Visible = false;
            ViewState["Region_Id"] = null;
            ImageButton imgBtn = (ImageButton)sender;
            string Rid = Convert.ToString(Session["RegionID"]);

            ViewState["Region_Id"] = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
            ViewState["NetworkRegion_Id"] = Int32.Parse(imgBtn.CommandArgument);
            load_region_dept();
            load_ddl_Networks();
            BindAssignCampus();
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void btnEditNetwork_Click(object sender, EventArgs e)
    {
        try
        {

            Pan_NetworkName.Visible = true;
            divListOfCampus.Visible = false;
            divMainList.Visible = false;
            ViewState["Region_Id"] = null;
            LinkButton imgBtn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)imgBtn.NamingContainer;

            ViewState["Region_Id"] = (Session["RegionID"].ToString() == "") ? "0" : Session["RegionID"].ToString();
            ViewState["NetworkRegion_Id"] = Int32.Parse(imgBtn.CommandArgument);
            if (!String.IsNullOrEmpty(ViewState["Region_Id"].ToString()))
                ddlRegion.SelectedValue = ViewState["Region_Id"].ToString();
            txtEmail.Text = gvr.Cells[3].Text;
            txtNetworkName.Text = gvr.Cells[2].Text;
            ViewState["Mode"] = "Edit";
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void load_ddl_Networks()
    {
        try
        {
            DataTable _dt = new DataTable();
            objBllRegion.Region_Id = Convert.ToInt32(ViewState["Region_Id"]);
            _dt = objBllRegion.NetworkRegionFetchByRegionID(objBllRegion.Region_Id);
            ddl_Networks.Items.Clear();
            ddl_Networks.DataTextField = "NetworkName";
            ddl_Networks.DataValueField = "NetworkRegion_Id";
            ddl_Networks.DataSource = _dt;
            ddl_Networks.DataBind();
            ddl_Networks.Items.Insert(0, new ListItem("-- Select Network --", "0"));
            // string id = Convert.ToString(ViewState["NetworkRegion_Id"]);
            if (objBllRegion.Region_Id == 0)
            {
                ddl_Networks.SelectedValue = "0";
            }
            else
            {
                ddl_Networks.SelectedValue = (Convert.ToString(ViewState["NetworkRegion_Id"]) == "") ? "0" : ViewState["NetworkRegion_Id"].ToString();
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void BindAssignCampus()
    {
        try
        {
            DataTable dt = new DataTable();
            gvAssignCampus.DataSource = null;
            gvAssignCampus.DataBind();
            objBllCenter.NetworkRegion_Id = Convert.ToInt32(ViewState["Region_Id"]);
            dt = objBllRegion.NetworkCenterSelectByRegionID(objBllCenter.NetworkRegion_Id);
            gvAssignCampus.DataSource = dt;
            gvAssignCampus.DataBind();
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }

    private void BindGridShowCampus()
    {
        try
        {
            DataTable _dt = new DataTable();
            objBllCenter.NetworkRegion_Id = Convert.ToInt32(ViewState["NetworkRegion_Id"]);
            _dt = objBllCenter.NetworkCenterFetch(objBllCenter.NetworkRegion_Id);
            if (_dt.Rows.Count > 0)
            {
                gvCampuses.DataSource = _dt;
                gvCampuses.DataBind();
                divListOfCampus.Visible = true;
            }
            else
            {
                ImpromptuHelper.ShowPrompt("No Campus Assigned");
                divListOfCampus.Visible = false;
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
    protected void btnShowCampus_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["NetworkRegion_Id"] = null;
            ImageButton imgBtn = (ImageButton)sender;
            int NetworkRegion_Id = Int32.Parse(imgBtn.CommandArgument);
            ViewState["NetworkRegion_Id"] = imgBtn.CommandArgument;
            BindGridShowCampus();
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }

    protected void btnCancelAssign_Click(object sender, EventArgs e)
    {
        try
        {
            pan_AssigCampus.Visible = false;
            divMainList.Visible = true;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }
    }
}