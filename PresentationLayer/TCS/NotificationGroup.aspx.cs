using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
public partial class PresentationLayer_TCS_NotificationGroup : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
    BLLNotif_Group objGroup = new BLLNotif_Group();
    BLLNotif_Group_Members objMem = new BLLNotif_Group_Members();
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
        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];
        if (!IsPostBack)
        {
            try
            {
                ViewState["MainOrgId"] = 0;
                ViewState["RegionId"] = 0;
                ViewState["CenterId"] = 0;
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
                loadRegions();
                loadCenter();
                FillClass();
                BindGroups();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }
    protected void BindGroups()
    {
        try
        {
            DataTable dt = objGroup.Notif_GroupFetch();
            gvGroups.DataSource = dt;
            gvGroups.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGroupMembers(object sender, EventArgs e)
    {
        try
        {
            divGroups.Visible = true;
            LinkButton bt = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)bt.NamingContainer;
            objMem.NtGrp_Id = Convert.ToInt32(bt.CommandArgument);
            DataTable dt = objMem.Notif_Group_MembersFetch(objMem);
            gvMembers.DataSource = dt;
            gvMembers.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindUserGrid()
    {
        try
        {
            BLLUser objUser = new BLLUser();
            DataTable dt = objUser.UserFetchAll();
            gvUsers.DataSource = dt;
            gvUsers.DataBind();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvUsers_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvUsers.Rows.Count > 0)
            {
                gvUsers.UseAccessibleHeader = false;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvUsers.FooterRow.TableSection = TableRowSection.TableFooter;
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
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objbase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");


            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                ddlRegion.SelectedValue = ViewState["RegionId"].ToString();
                ddlRegion.Enabled = false;
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
                objCen.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objbase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");

            if (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            {
                ddlCenter.SelectedValue = ViewState["CenterId"].ToString();
                ddlCenter.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();

            DataTable dt = null;
            int c_id;
            if (ddlCenter.SelectedIndex < 0)
            {

                DataRow row = (DataRow)Session["rightsRow"];
                c_id = Convert.ToInt32(row["Center_Id"].ToString());
            }
            else
            {
                c_id = Convert.ToInt32(ddlCenter.SelectedValue);
            }
            objBLLClass.Center_Id = c_id;
            dt = objBLLClass.ClassFetchByCenterID(objBLLClass);
            objbase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void FillNetworks()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void btnNewGroup_Click(object sender, EventArgs e)
    {
        try
        {
            BindUserGrid();
            divNewGroup.Visible = true;
            divGroups.Visible = false;


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        try
        {
            objGroup.Group_Name = txtName.Text;
            objGroup.Group_Description = txtDescription.Text;
            objGroup.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            int k = objGroup.Notif_GroupAdd(objGroup);
            if (k == 1)
            {
                string user = "";
                foreach (GridViewRow r in gvUsers.Rows)
                {
                    CheckBox cb = (CheckBox)r.FindControl("cbAllow");
                    if (cb.Checked == true)
                    {
                        user = user + r.Cells[0].Text;
                    }
                }
                objMem.User_List = user;
                objMem.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objMem.Notif_Group_MembersAdd(objMem);

            }
            else
                ImpromptuHelper.ShowPrompt("Group Name already exists!");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}