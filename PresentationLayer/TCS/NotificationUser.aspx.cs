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
    BLLNotifications objnotif = new BLLNotifications();

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

        if (!IsPostBack)
        {
            try
            {

                BindNotif();
                objnotif.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                int k = objnotif.Notification_DetailUpdate(objnotif);
              

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }
    protected void BindNotif()
    {
        try
        {
            objnotif.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = objnotif.NotificationsSelectByUserID(objnotif);
            gvNotifications.DataSource = dt;
            gvNotifications.DataBind();

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
    protected void btnRead_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton imgBtn = (LinkButton)sender;
            objnotif.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            objnotif.Notification_Id = Convert.ToInt32(imgBtn.CommandArgument);
            int k = objnotif.Notification_DetailUpdate(objnotif);
            ImpromptuHelper.ShowPrompt("Notification Marked Read!");
            BindNotif();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

}