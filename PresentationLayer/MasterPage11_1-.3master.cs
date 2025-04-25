using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Drawing;
using ADG.JQueryExtenders.Impromptu;
public partial class PresentationLayer_MasterPage : System.Web.UI.MasterPage
{

    BLLLmsAppMenu objBllMenu = new BLLLmsAppMenu();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Page.Header.DataBind();
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            if (!Page.IsPostBack)
            {
               

                if (Session["Menu"] != null)
                {
                    lt_navMenu.Text = Session["Menu"].ToString();
                }
                else
                {
                    menuListRexv(0); //Menu should be in Session as string
                }
                if (Convert.ToInt32(row["Parent"].ToString()) == 0)
                {
                    if (row["User_Type"].ToString() == "SAdmin")
                    {
                        lab_main.Text = "Super Admin";
                    }
                    else
                        lab_main.Text = row["Main_Organisation_Name"].ToString();


                    if (Convert.ToBoolean(row["Region"].ToString()) == true)
                        lab_secInfo.Text = row["region_name"].ToString();
                    else if (Convert.ToBoolean(row["Center"]) == true || Convert.ToBoolean(row["Teacher"]) == true/**/)
                        lab_secInfo.Text = row["center_name"].ToString();
                    else
                        Label1.Visible = false;
                }
                lb_userName.Text = row["User_Name"].ToString();

            }
            if (!IsPostBack)
            {

                BindNotification();
            }
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/errorpage.aspx", false);
        }

    }
    //protected override void OnPreRender(EventArgs e)
    //{
    //    Configuration conn = WebConfigurationManager.OpenWebConfiguration("");
    //    AuthenticationSection section = (AuthenticationSection)conn.SectionGroups.Get("system.web").Sections.Get("authentication");
    //    long time = (System.Convert.ToInt64(section.Forms.Timeout.TotalMinutes) * 60); //convert minutes picked from web config time to seconds
    //    HttpContext context = HttpContext.Current;
    //    string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
    //    baseUrl += "PresentationLayer/SessionOut.aspx"; //
    //    base.OnPreRender(e);
    //    this.HeadContent.Controls.Add(new LiteralControl(
    //        String.Format("<meta http-equiv='refresh' content='{0};url={1}'>", time, baseUrl)));

    //}
    public void menuListRexv(int _PrntMenu)
    {

        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            BLLLmsAppMenu ObjMenu = new BLLLmsAppMenu();

            ObjMenu.User_Type_Id = Convert.ToInt32(row["User_Type_Id"].ToString());
            ObjMenu.PrntMenu_ID = _PrntMenu;
            DataTable _dtmenu = ObjMenu.LmsAppMenuFetch(ObjMenu);


            lt_navMenu.Text = lt_navMenu.Text + "<ul>";
            foreach (DataRow subMenu in _dtmenu.Rows)
            {
                if (Convert.ToBoolean(subMenu["isAllow"]))
                {
                    lt_navMenu.Text = lt_navMenu.Text + "<li><a href=\"" +
                    Page.ResolveUrl(subMenu["PagePath"].ToString()) + " \">" +
                    subMenu["MenuText"].ToString() + "</a>";

                    if (Convert.ToInt32(subMenu["isChild"].ToString()) > 0)
                    {
                        menuListRexv(Convert.ToInt32(subMenu["Menu_ID"].ToString()));
                    }

                    lt_navMenu.Text = lt_navMenu.Text + "</li>";
                }
            }
            lt_navMenu.Text = lt_navMenu.Text + "</ul>";
            Session["Menu"] = lt_navMenu.Text;
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/errorpage.aspx", false);
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            Session["user_id"] = Convert.ToInt32(row["User_Id"].ToString());
            Response.Redirect("~/PresentationLayer/ChangePassword.aspx", false);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void but_logout_Click(object sender, EventArgs e)
    {

        try
        {
            Session.Abandon();
            //Session.Remove("Session_Id");
            //Session.Remove("cId");
            //Session.Remove("ContactID");
            //Session.Remove("UserType_Id");
            //Session.Remove("UserLevel_Id");
            //Session.Remove("EmployeeCode");
            //Session.Remove("LibID");
            //Session.Remove("rightsRow");
            //Session.Remove("moID");
            //Session.Remove("centerForClassId");
            //Session.Remove("error");
            //Session.RemoveAll();

            Response.Redirect("~/login.aspx", false);
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/errorpage.aspx", false);
        }

    }

    public void BindNotification()
    {
        try
        {

            if (!String.IsNullOrEmpty(lb_userName.Text))
            {
                BLLNotifications obj = new BLLNotifications();
                obj.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = obj.NotificationsSelectByUserID(obj);
                if (dt.Rows.Count > 0)
                {
                    lblCounter.Text = dt.Rows[0]["CountTotal"].ToString();
                    gvNotify.DataSource = dt;
                    gvNotify.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/errorpage.aspx", false);
        }
    }
    protected void gvNotify_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNotify.Rows.Count > 0)
            {
                gvNotify.UseAccessibleHeader = false;
                gvNotify.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void btnsee_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "../PresentationLayer/TCS/NotificationUser.aspx";

            string currentPageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            if ("NotificationUser.aspx" == currentPageName)
            {
                return;
            }
            if (!String.IsNullOrEmpty(url))
            {
                //url = "../PresentationLayer/TCS/" + url;
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                Response.Redirect(url, false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvNotify_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isHot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "is_read").ToString()); //check if notification is read or not 

                if (!isHot)
                {
                    e.Row.BackColor = Color.Gainsboro;
                }

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }





    public void redirectToapp(string Code,string Center_id)
    {
        Code = Session["EmployeeCode"].ToString();
         
    }
   
}
