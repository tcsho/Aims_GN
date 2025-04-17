using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

public partial class PresentationLayer_TCS_Notifications : System.Web.UI.Page
{

    BLLNotifications objnot = new BLLNotifications();
    DALBase objdal = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        //======== Page Access Settings ========================
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
            Response.Redirect("~/login.aspx");
        }

        //====== End Page Access settings ======================
        try
        {
            if (Session["EmployeeCode"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                ViewState["tMood"] = "";
                BindGrid();
                ViewState["totalrec"] = "";
                ViewState["Page"] = "1";
                LoadSize();
                ddlNotifType.Focus();
            }
        }
        catch (Exception)
        {

        }



    }
    protected void LoadSize()
    {
        DataTable st = new DataTable();
        st.Columns.Add("SizeValue");
        st.Columns.Add("Size");
        DataRow r0 = st.NewRow();
        r0["SizeValue"] = "500";
        r0["Size"] = "500";
        DataRow r = st.NewRow();
        r["SizeValue"] = "1000";
        r["Size"] = "1000";
        DataRow r1 = st.NewRow();
        r1["SizeValue"] = "3000";
        r1["Size"] = "3000";
        DataRow r2 = st.NewRow();
        r2["SizeValue"] = "5000";
        r2["Size"] = "5000";
        st.Rows.Add(r0);
        st.Rows.Add(r);
        st.Rows.Add(r1);
        st.Rows.Add(r2);
        if (!String.IsNullOrEmpty(ViewState["totalrec"].ToString()))
        {
            DataRow r3 = st.NewRow();
            r3["SizeValue"] = ViewState["totalrec"].ToString();
            r3["Size"] = "All";
            st.Rows.Add(r3);
        }
        objdal.FillDropDown(st, ddlPageSize, "SizeValue", "Size");
        ddlPageSize.SelectedIndex = 2;
    }
    protected void gvLogicalGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvLogicalGroup.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("cbAllow");

                    if (mood == "" || mood == "check")
                    {
                        cb.Checked = true;
                        ViewState["tMood"] = "uncheck";
                    }
                    else
                    {
                        cb.Checked = false;
                        ViewState["tMood"] = "check";
                    }

                }

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void BindGrid()
    {
        try
        {
            objnot.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = objnot.NotificationsFetch(objnot);
            gvNotifications.DataSource = dt;
            gvNotifications.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddLG_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkAllowAccess = new CheckBox();
            BLLNotifications obj = new BLLNotifications();
            string id = "";
            foreach (GridViewRow gvr in gvLogicalGroup.Rows)
            {
                chkAllowAccess = (CheckBox)gvr.FindControl("cbAllow");
                if (chkAllowAccess.Checked)
                {
                    id = id + gvr.Cells[2].Text + ",";
                    gvLogicalGroup.SelectedIndex = gvr.RowIndex;
                    gvLogicalGroup.SelectedRow.Visible = false;
                }
            }
            id = id.TrimEnd(',');
            DataTable dt = new DataTable();
            dt = obj.NotificationsLogicalGroups(Convert.ToInt32(Session["ContactID"].ToString()), id, 1, 1000);
            ViewState["SelectedGroups"] = dt;
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
            if (gvUsers.Rows.Count > 0)
                divselecteduser.Visible = true;
            else
                divselecteduser.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            gvUsers.DataSource = null;
            gvUsers.DataBind();
            divselecteduser.Visible = false;

            lbllength.Visible = false;
            DataTable dt = objnot.Notification_TypeSelectAll();
            objdal.FillDropDown(dt, ddlNotifType, "Nt_Type_Id", "Type_description");
            if (dt.Rows.Count > 0)
                ddlNotifType.SelectedIndex = ddlNotifType.Items.Count - 1;
            pan_NewNotif.Visible = true;
            divListOfNotif.Visible = false;
            btnAddNew.Visible = false;
            BindLogicalGroup(1);
            LoadSize();
            PopulatePager(Convert.ToInt32(ViewState["totalrec"].ToString()), 1);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindLogicalGroup(int pageno)
    {
        try
        {
            int user = Convert.ToInt32(Session["ContactID"].ToString());
            BLLNotifications obj = new BLLNotifications();
            DataTable dtgroup = obj.NotificationsLogicalGroups(user, "-", pageno, Convert.ToInt32(ddlPageSize.SelectedValue));
            if (dtgroup.Rows.Count > 0)
            {
                ViewState["LGDT"] = dtgroup;
                ViewState["totalrec"] = Convert.ToInt32(dtgroup.Rows[0]["TotalRec"].ToString().Trim());
                if (gvUsers.Rows.Count > 0)
                {
                    string value = "";
                    foreach (GridViewRow gvr in gvUsers.Rows)
                    {
                        value = value + gvr.Cells[2].Text + ",";
                    }
                    value = value.TrimEnd(',');

                    DataRow[] tblROWS = dtgroup.Select("Id not in(" + value + ")");
                    if (tblROWS.Length > 0)
                    {
                        dtgroup = dtgroup.Select("Id not in(" + value + ")").CopyToDataTable();
                    }
                }
                gvLogicalGroup.DataSource = dtgroup;
                gvLogicalGroup.DataBind();
            }
            foreach (RepeaterItem item in rptPager.Items)
            {
                LinkButton btnold = (LinkButton)item.FindControl("lnkPage");
                if (btnold != null)
                {
                    btnold.CssClass = "btn btn-primary";
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilter(int _FilterCondition, string value)
    {
        try
        {

            if (ViewState["LGDT"] != null)
            {
                DataTable dt = (DataTable)ViewState["LGDT"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // 9 Olevels Stream
                        {

                            strFilter = " Convert([Id], 'System.String') not in (' " + value + "')";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvLogicalGroup.DataSource = dv;
                gvLogicalGroup.DataBind();
                gvLogicalGroup.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilter()
    {
        try
        {
            BindLogicalGroup(1);
            gvLogicalGroup.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        this.BindLogicalGroup(1);
        this.PopulatePager(Convert.ToInt32(ViewState["totalrec"].ToString()), 1);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ViewState["Page"] = pageIndex;
        this.BindLogicalGroup(pageIndex);
        LinkButton btn = (LinkButton)sender;
        btn.CssClass = "btn btn-primary active";
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
    protected void gvNotifications_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNotifications.Rows.Count > 0)
            {
                gvNotifications.UseAccessibleHeader = false;
                gvNotifications.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvNotifications.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvLogicalGroups_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvLogicalGroup.Rows.Count > 0)
            {
                gvLogicalGroup.UseAccessibleHeader = false;
                gvLogicalGroup.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvLogicalGroup.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSaveNotif_Click(object sender, EventArgs e)
    {
        try
        {
            lbllength.Visible = false;
            objnot.Notif_Subject = txtSubject.Text;
            if (txtMessage.Text.Length > 4000)
            {
                lbllength.Visible = true;
                return;
            }
            objnot.Notif_Message = txtMessage.Text;
            objnot.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            objnot.NtType_Id = Convert.ToInt32(ddlNotifType.SelectedValue);
            if (gvUsers.Rows.Count > 0)
            {
                string userlist = " and ";
                for (int i = 0; i < gvUsers.Rows.Count; i++)
                {
                    if (i == gvUsers.Rows.Count - 1) //not to append 'or ' for the last element 
                        userlist += gvUsers.Rows[i].Cells[0].Text;
                    else
                        userlist += gvUsers.Rows[i].Cells[0].Text + " or ";
                }

                int k = objnot.NotificationsAdd(objnot, userlist);
                ImpromptuHelper.ShowPrompt("Notification Sent");
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select notification users");
                return;
            }
            BindGrid();
            btnDiscard_Click(this, EventArgs.Empty);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDiscard_Click(object sender, EventArgs e)
    {
        try
        {
            txtMessage.Text = "";
            txtSubject.Text = "";
            ddlNotifType.SelectedIndex = -1;
            pan_NewNotif.Visible = false;
            divListOfNotif.Visible = true;
            btnAddNew.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton bt = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)bt.NamingContainer;
            gvLogicalGroup.SelectedIndex = gvr.RowIndex;
            gvLogicalGroup.SelectedRow.Visible = false;
            string id = "";
            BLLNotifications obj = new BLLNotifications();
            for (int i = 0; i < gvUsers.Rows.Count; i++)
            {
                id = id + gvUsers.Rows[i].Cells[2].Text + ",";
            }
            id = id + bt.CommandArgument;
            DataTable dt = new DataTable();
            dt = obj.NotificationsLogicalGroups(Convert.ToInt32(Session["ContactID"].ToString()), id, 1, 1000);
            ViewState["SelectedGroups"] = dt;
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
            if (gvUsers.Rows.Count > 0)
                divselecteduser.Visible = true;
            else
                divselecteduser.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnRemove_click(object sender, EventArgs e)
    {
        try
        {
            LinkButton bt = (LinkButton)sender;
            int id = Convert.ToInt32(bt.CommandArgument);
            GridViewRow gvr = (GridViewRow)bt.NamingContainer;
            gvUsers.SelectedIndex = gvr.RowIndex;

            if (ViewState["SelectedGroups"] != null)
            {
                DataTable dt = (DataTable)ViewState["SelectedGroups"];
                dt.Rows.RemoveAt(gvr.RowIndex);
                if (dt.Rows.Count > 0)
                {
                    divselecteduser.Visible = true;
                    gvUsers.DataSource = dt;
                }
                else
                    divselecteduser.Visible = false;

                gvUsers.DataBind();

            }
            if (!String.IsNullOrEmpty(ViewState["Page"].ToString()) || ViewState["Page"] != null)
                BindLogicalGroup(Convert.ToInt32(ViewState["Page"].ToString()));
            else
                BindLogicalGroup(1);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    //private void LoadGroups()
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        StringBuilder sb = new StringBuilder();

    //        int mode = 1;  // for textbox 
    //        //  dt = obj.NotificationsLogicalGroups(txtUser.Text, mode);

    //        if (dt.Rows.Count > 0)
    //        {
    //            sb.Append("[");
    //            for (int i = 0; i < dt.Rows.Count; ++i)
    //            {
    //                sb.Append("\"" + dt.Rows[i][2].ToString().Replace("\"", "'") + "\"");
    //                if (i != (dt.Rows.Count - 1))
    //                {
    //                    sb.Append(",");
    //                }
    //            }

    //            sb.Append("]");
    //        }
    //        else
    //            sb.Append("null");

    //        GroupList = sb.ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    //protected void txtUser_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //  BLLNotifications obj = new BLLNotifications();
    //        //  int mode = 2;  // for getting criteria
    //        //  string userlist = "";
    //        //  string list="";// = txtUser.Text;
    //        //  //if (list.Contains("'"))
    //        //  //{
    //        //  //    list = list.Replace("'", "''''");
    //        //  //}
    //        //  for (int i = 0; i < gvUsers.Rows.Count; i++)
    //        //  {

    //        //      userlist += "'" + gvUsers.Rows[i].Cells[1].Text + "',";
    //        //  }
    //        //  userlist += "'" + list + "'";
    //        //  //DataTable dt = obj.NotificationsLogicalGroups(userlist.ToString(), mode);
    //        //  gvUsers.DataSource = dt;
    //        //  ViewState["SelectedGroups"] = dt;
    //        //  gvUsers.DataBind();
    //        ////  txtUser.Text = "";
    //        //  //txtUser.Focus();    
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}
}