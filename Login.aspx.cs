using System;
using System.Data;
using System.Web.UI;


public partial class Login : System.Web.UI.Page
{
    BLLLogin Objbll = new BLLLogin();
    BLLLoginLog ObjbllLog = new BLLLoginLog();
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadOrganisationsList();
            ////GetSAdminHomePhone();
            //DisplayNews();
        }
    }
    public void LoadOrganisationsList()
    {
        BLLMain_Organisation objBll = new BLLMain_Organisation();
        DataTable dt = new DataTable();
        dt = objBll.Main_OrganisationFetch(objBll);
        objBase.FillDropDown(dt, ddlistOrganisation, "Main_Organisation_Id", "Main_Organisation_Name");
        ddlistOrganisation.SelectedValue = "1";

    }

    protected void imagebutton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //string OrgId = this.ddlistOrganisation.SelectedValue;
            string OrgId = "1";
            DataTable dt = new DataTable();
            Objbll.User_Name = text_login.Text;
            Objbll.Password = text_password.Text;
            Session["UserId"] = text_login.Text;
            BLLSession objSes = new BLLSession();
            DataTable dtSes = objSes.SessionSelectAll();
            if (dtSes.Rows.Count > 0)
            {
                Session["Session_Id"] = (dtSes.Rows[0]["Session_Id"].ToString());
            }

            if (OrgId == "")
            {
                dt = Objbll.LoginFetchAuthenticateSuperAdmin(Objbll);
            }
            else
            {
                Objbll.Main_Organisation_Id = Convert.ToInt32(OrgId);
                dt = Objbll.LoginFetchAuthenticateUser(Objbll);
            }
            if (dt.Rows.Count != 0)
            {
                DataRow row = dt.Rows[0];
                Session["cId"] = row["Center_Id"];
                Session["ContactID"] = row["User_Id"];
                Session["UserType_Id"] = row["User_Type_Id"];
                Session["UserLevel_Id"] = row["UserLevel_Id"];
                if (!String.IsNullOrEmpty(row["Region_Id"].ToString()))
                    Session["RegionID"] = row["Region_Id"].ToString();
                else
                    Session["RegionId"] = 0;
                if (!String.IsNullOrEmpty(row["Center_Id"].ToString()))
                    Session["Center_Id"] = row["Center_Id"].ToString();
                else
                    Session["Center_Id"] = 0;
                if (!String.IsNullOrEmpty(row["User_Name"].ToString()))
                    Session["User_Name"] = row["User_Name"].ToString();
                else
                    Session["User_Name"] = 0;
                if (row["EmployeeCode"] != null)
                {
                    Session["EmployeeCode"] = row["EmployeeCode"];
                }
                else
                {
                    Session["EmployeeCode"] = 0;
                }

                Session["isClassTeacher"] = row["isClassTeacher"];
                Session["rightsRow"] = row;
                if (row["Main_Organisation_Id"] != null)
                {
                    Session["moID"] = row["Main_Organisation_Id"];
                    if (Convert.ToInt32(row["Parent"].ToString()) == 1)
                    {
                        Response.Redirect("~/PresentationLayer/DefaultParent.aspx", false);
                    }
                    else
                    {
                        if (row["Center"] != null)
                        {
                            if (Convert.ToBoolean(row["Center"]) == true || Convert.ToBoolean(row["Teacher"]) == true || Convert.ToBoolean(row["Student"]) == true)
                            {
                                BLLCenter bllCenter = new BLLCenter();
                                DataTable centerDt = new DataTable();
                                int contactID = Int32.Parse(Session["ContactID"].ToString());
                                centerDt = bllCenter.CenterFetch(contactID);
                                DataRow centerRow = centerDt.Rows[0];
                                Session["cId"] = centerRow["Center_Id"];
                                objSes.Center_Id = Convert.ToInt32(centerRow["Center_Id"]);
                                dtSes = objSes.SessionSelectActiveByCenter(objSes);
                                if (dtSes.Rows.Count > 0)
                                {
                                    Session["Session_Id"] = (dtSes.Rows[0]["Session_Id"].ToString());
                                }
                            }
                        }
                        if (row["User_Type_Id"].ToString() == "27")
                        {
                            Response.Redirect("~/PresentationLayer/TCS/AdmTestInst.aspx", false);
                        }
                        else if (row["User_Type_Id"].ToString() == "37" || 
                            row["User_Type_Id"].ToString() == "38" || 
                            row["User_Type_Id"].ToString() == "39" ||
                            row["User_Type_Id"].ToString() == "40" ||
                            row["User_Type_Id"].ToString() == "41")
                        {
                            Response.Redirect("~/PresentationLayer/BIDashboard/dashboardBIMIS.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("~/PresentationLayer/Default.aspx", false);
                        }
                    }
                }
                else
                {
                    if (row["User_Type"].ToString() == "SAdmin")
                    {
                        Response.Redirect("~/PresentationLayer/Default.aspx", false);
                    }
                    else
                        Response.Redirect("~/PresentationLayer/DefaultParent.aspx", false);
                }

                //Add here in case of success Login
                MaintainLoginLog(true);
                if (Session["cId"] != null && (String.IsNullOrEmpty(Session["cId"].ToString())) || Session["cId"].ToString().Contains("null"))
                {
                    Session["cId"] = 0;
                }
                PassSessions(Convert.ToInt32(Session["cId"]),
                    Convert.ToInt32(Session["ContactID"]),
                    (DataRow)Session["rightsRow"], Convert.ToInt32(Session["UserType_Id"]), Session["UserId"].ToString());
            }
            else
            {
                //Add here in case of Un SuccessFull Login
                MaintainLoginLog(false);
                lab_status.Text = "Wrong credentials";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    public void PassSessions(int CenterId, int contactId, DataRow row, int UserTypeId, string userId)
    {
        MySession.Sessions(CenterId, contactId, row, UserTypeId, userId);
    }
    private void MaintainLoginLog(bool _isSuc)
    {
        ObjbllLog.User_Name = text_login.Text;
        ObjbllLog.Password = text_password.Text;
        ObjbllLog.CreatedOn = DateTime.Now;
        ObjbllLog.IsSuccess = _isSuc;
        if (ddlistOrganisation.SelectedValue == "")
        {
            ObjbllLog.MO_Id = 0;
        }
        else
        {
            ObjbllLog.MO_Id = Convert.ToInt32(ddlistOrganisation.SelectedValue);
        }

        ObjbllLog.IP_Add = GetIP();
        ObjbllLog.LoginLogAdd(ObjbllLog);
    }
    //protected void DisplayNews()
    //    {
    //    BLLLmsNews bll = new BLLLmsNews();
    //    DataTable dt = new DataTable();
    //    bll.MainPageStatus_ID = 1;//Selected by Campus Officer

    //    dt = bll.LmsNewsSelectByMainPageStatusID(bll);
    //    if (dt != null && dt.Rows.Count > 0)
    //        {
    //        DataView dv = new DataView(dt);
    //        dv.RowFilter = "MainPageStatus_ID = 1";
    //        RepeaterNews.DataSource = dv;
    //        RepeaterNews.DataBind();
    //        }
    //    }
    protected string GetIP()
    {
        string ip;
        ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            string trueIP = ipRange[le];
        }
        else
        {
            ip = Request.ServerVariables["REMOTE_ADDR"];
            //HTTP_X_CLUSTER_CLIENT_IP
        }
        return ip;
    }
    protected void lnkBtnNewsTitle_Click(object sender, EventArgs e)
    {
    }
}