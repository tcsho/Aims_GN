using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TcsArchiveReports : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLLmsAppReports objLmsAppReports = new BLLLmsAppReports();
    BLLStudent objBllStd = new BLLStudent();
    protected void Page_Load(object sender, EventArgs e)
        {

        try
            {
            if (Session["ContactID"] == null)
                {
                Response.Redirect("~/login.aspx");
                }
            }
        catch (Exception ex)
            {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }

        DALBase objBase = new DALBase();
        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];


        //if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1)//Administrator Officer
        //    {
        //    if (queryStr != "20" && queryStr != "23" && queryStr != "28")
        //        {
        //        Session.Abandon();
        //        Response.Redirect("~/login.aspx");
        //        }
        //    }
        //else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2)//Head Officer
        //    {
        //    if (queryStr != "20" && queryStr != "23" && queryStr != "28")
        //        {
        //        Session.Abandon();
        //        Response.Redirect("~/login.aspx");
        //        }
        //    }
        //else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3)//Regional Officer
        //    {
        //    if (queryStr != "17" && queryStr != "21" && queryStr != "24" && queryStr != "27")
        //        {
        //        Session.Abandon();
        //        Response.Redirect("~/login.aspx");
        //        }
        //    }
        //else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4)//Campus Officer
        //    {
        //    if (queryStr != "15" && queryStr != "16" && queryStr != "22" && queryStr != "26")
        //        {
        //        Session.Abandon();
        //        Response.Redirect("~/login.aspx");
        //        }
        //    }
        //else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
        //    {
        //    if (queryStr != "35")
        //        {
        //        Session.Abandon();
        //        Response.Redirect("~/login.aspx");
        //        }
        //    }
        //else
        //    {
        //    Session.Abandon();
        //    Response.Redirect("~/login.aspx");

        //    }

        try
        {

        if (!IsPostBack)
            {
            //======== Page Access Settings ========================

            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();

            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                Session.Abandon();
                Response.Redirect("~/login.aspx");
                }
            Session["AddCriteria"] = null;

            //====== End Page Access settings ======================


            loadOrg(sender, e);
            loadReprts(sRet);
            FillActiveSessions();
            if (row["User_Type"].ToString() != "SAdmin")
                {
                ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                ddl_MOrg_SelectedIndexChanged(sender, e);
                }


            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = true;
                ddl_region.Enabled = true;
                ddl_center.Enabled = true;

                }

            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_region.SelectedValue = row["Region_Id"].ToString();
                ddl_Region_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;
                ddl_center.Enabled = true;

                }

            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_region.SelectedValue = row["Region_Id"].ToString();
                ddl_Region_SelectedIndexChanged(sender, e);

                ddl_center.SelectedValue = row["Center_Id"].ToString();
                ddl_center_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;

                ddl_center.Enabled = false;

                }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_region.SelectedValue = row["Region_Id"].ToString();
                ddl_Region_SelectedIndexChanged(sender, e);

                ddl_center.SelectedValue = row["Center_Id"].ToString();
                ddl_center_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;

                ddl_center.Enabled = false;

                }
            PageInformation();
            rblReportType.SelectedValue = "0";
            int ID = Convert.ToInt32(rblReportType.SelectedValue);
            FillReportControls(ID);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        }

    protected void PageInformation()
        {
        try
        {
        BLLLmsAppPages objPage = new BLLLmsAppPages();
        string queryStr = Request.QueryString["id"];



        DataTable dt = new DataTable();
        objPage.Page_ID = Convert.ToInt32(queryStr);
        dt = objPage.LmsAppPagesFetch(objPage);
        if (dt.Rows.Count > 0)
            {
            //wrkTitle.InnerHtml = dt.Rows[0]["PageCaption"].ToString();
            Session["LastPage"] = dt.Rows[0]["PagePath"].ToString();
            }

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

        bool _isok = false;
        string _cri = "";

        DataTable dt = (DataTable)ViewState["Reports"];

        string rblselected = rblReportType.SelectedItem.Text;

        DataRow[] row = dt.Select("rpt_Caption='" + rblselected + "'");

        Session["RptTitle"] = row[0]["rpt_Caption"].ToString();
        Session["reppath"] = Server.MapPath(row[0]["Rpt_Path"].ToString());
        Session["rep"] = row[0]["Rpt_Name"].ToString();
        _cri = SelectCriteria(_cri, row[0]["Rpt_View"].ToString());
        _isok = true;
        Session["CriteriaRpt"] = _cri;


        if (_isok == true)
            {
            Response.Redirect("~/PresentationLayer/TCS/TssCrystalReports.aspx",false);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        }

    protected void loadReprts(string _pageName)
        {

        try
        {
        string queryStr = Request.QueryString["id"];

        //char x = Convert.ToChar(queryStr);


        DataTable dt = new DataTable();
        //objLmsAppReports.Page_Name = _pageName;
        objLmsAppReports.Page_Id = Convert.ToInt32(queryStr);
        dt = objLmsAppReports.LmsAppReportsFetch(objLmsAppReports);
        ViewState["Reports"] = dt;
        rblReportType.DataSource = dt;
        rblReportType.DataValueField = "Rpt_Id";
        rblReportType.DataTextField = "Rpt_Caption";
        rblReportType.SelectedIndex = 0;
        rblReportType.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        }
    protected string SelectCriteria(string _cri, string _view)
        {

        //try
        //{

        string str = "";

        if (ddlSession.SelectedIndex > 0)
            {
            _cri = "{" + _view + ".Session_Id}=" + Convert.ToInt32(ddlSession.SelectedValue);//Convert.ToInt32(Session["Session_Id"]);
            }
        if (ddl_MOrg.SelectedIndex > 0)
            {
            if (_cri.Length > 0)
                {
                _cri = _cri + " and {" + _view + ".Main_Organisation_Id}=" + ddl_MOrg.SelectedValue;
                }
            else
                {
                _cri = " {" + _view + ".Main_Organisation_Id}=" + ddl_MOrg.SelectedValue;
                }
            str = str + "Main Organisation=" + ddl_MOrg.SelectedItem;
            }
        if (ddl_region.SelectedIndex > 0)
            {
            _cri = _cri + " and {" + _view + ".Region_Id}=" + ddl_region.SelectedValue;
            str = str + "  Region=" + ddl_region.SelectedItem;
            }

        if (ddl_center.SelectedIndex > 0)
            {
            _cri = _cri + " and {" + _view + ".Center_Id}=" + ddl_center.SelectedValue;
            str = str + "  Center=" + ddl_center.Text;
            }

        //if (ddlClass.SelectedIndex > 0)
        //    {
        //    _cri = _cri + " and {" + _view + ".Class_Id}=" + ddlClass.SelectedValue;
        //    str = str + "  Class=" + ddlClass.Text;
        //    }
        //if (ddlClass.SelectedIndex > 0)
        //    {
        //    _cri = _cri + " and {" + _view + ".Class_Id}=" + ddlClass.SelectedValue;
        //    str = str + "  Class=" + ddlClass.Text;
        //    }

        //if (list_section.SelectedIndex > 0)
        //    {
        //    _cri = _cri + " and {" + _view + ".Section_Id}=" + list_section.SelectedValue;
        //    str = str + "  Class=" + list_section.Text;
        //    }

        //if (list_student.SelectedIndex > 0)
        //    {
        //    _cri = _cri + " and {" + _view + ".Student_Id}=" + list_student.SelectedValue;
        //    str = str + "  Class=" + list_student.Text;
        //    }
        if (ddlTerm.SelectedIndex > 0)
            {
            _cri = _cri + " and {" + _view + ".Term}=" + ddlTerm.SelectedValue;
           // str = str + "  Class=" + ddlTerm.Text;
            }
        //if (list_Subject.SelectedIndex > 0)
        //    {
        //    _cri = _cri + " and {" + _view + ".Subject_Id}=" + list_Subject.SelectedValue;
        //    str = str + "  Class=" + list_Subject.Text;
        //    }

        //if (txtFrmDate.Text.Length > 0)
        //    {
        //    if (txtToDate.Text.Length < 1)
        //        {
        //        ImpromptuHelper.ShowPrompt("Plase select ToDate");
        //        }
        //    else
        //        {
        //        _cri = _cri + "and Date({vwTSS_PeriodicStudentRegistration.ParamDate})>=#" + txtFrmDate.Text + "# and Date({vwTSS_PeriodicStudentRegistration.ParamDate})<=#" + txtToDate.Text + "#";

        //        }
        //    }
        DataRow row = (DataRow)Session["rightsRow"];
        if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
            {

            _cri = _cri + " and {" + _view + ".Teacher_Id}=" + row["EmployeeCode"].ToString();

            }

        if (Session["AddCriteria"] != null)
            {
            _cri = _cri + Session["AddCriteria"].ToString();
            }
        Session["rptCmnt"] = str;
        return _cri;

        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}


        }


    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
        loadCenter();
        }

    protected void ddl_MOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
        try
        {
        loadCountries();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        }

    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
        try
        {
        loadRegions();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }

    protected void loadOrg(object sender, EventArgs e)
        {
        try
        {
        BLLMain_Organisation oDALMainOrgnization = new BLLMain_Organisation();
        DataTable dt = new DataTable();
        dt = oDALMainOrgnization.Main_OrganisationFetch(oDALMainOrgnization);

        DataRow row = (DataRow)Session["rightsRow"];


        if (row["User_Type"].ToString() == "Admin")
            {
            ddl_MOrg.Items.Add(new ListItem(row["Main_Organisation_Name"].ToString(), row["Main_Organisation_Id"].ToString()));

            ddl_MOrg.SelectedIndex = 1;

            ddl_MOrg_SelectedIndexChanged(sender, e);

            }
        else
            {
            objBase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
            }
        ddl_country.Items.Clear();
        ddl_country.Items.Add(new ListItem("Select", "0"));

        ddl_region.Items.Clear();
        ddl_region.Items.Add(new ListItem("Select", "0"));

        ddl_center.Items.Clear();
        ddl_center.Items.Add(new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }

    protected void loadCountries()
        {
        try
        {
        BLLMain_Organisation_Country oDALMainOrgCountry = new BLLMain_Organisation_Country();
        oDALMainOrgCountry.Main_Organisation_Id = Convert.ToInt32(ddl_MOrg.SelectedValue.ToString());

        DataTable dt = new DataTable();
        dt = oDALMainOrgCountry.Main_Organisation_CountryFetch(oDALMainOrgCountry);

        objBase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");

        ddl_region.Items.Clear();
        ddl_region.Items.Add(new ListItem("Select", "0"));

        ddl_center.Items.Clear();
        ddl_center.Items.Add(new ListItem("Select", "0"));

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

        oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ddl_country.SelectedValue.ToString());
        dt = oDALRegion.RegionFetch(oDALRegion);

        objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
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
        objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        DataTable dt = new DataTable();
        dt = objCen.CenterFetchByRegionID(objCen);
        objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
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
      //  FillClass();
        FillActiveSessions();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }

  

    private void ResetDropDownList()
        {
        try
        {
        ddlReset(ddl_region);
        ddlReset(ddl_center);

        ddlReset(ddlSession);
      //  ddlReset(ddlClass);
      //  ddlReset(list_section);
      //  ddlReset(list_Subject);
      //  ddlReset(list_student);
        ddlReset(ddlTerm);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



        }

    protected void ddlReset(DropDownList _ddl)
        {
        if (_ddl.Items.Count > 0)
            {
            _ddl.SelectedValue = "0";
            }
        }

   
    protected void rblReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
        try
        {
        DataTable dt = (DataTable)ViewState["Reports"];

        string rblselected = rblReportType.SelectedValue;

        int id = Convert.ToInt32(rblselected);
        dt = objLmsAppReports.LmsAppReportsFetch(id);
        if (dt.Rows.Count > 0)
            {
            Session["AddCriteria"] = null;
            FillReportControls(id);
            if (dt.Rows[0]["AddCriteria"].ToString() != String.Empty)
                {
                Session["AddCriteria"] = dt.Rows[0]["AddCriteria"].ToString();
                }
            else
                {
                Session["AddCriteria"] = null;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }
    protected void bindTermList()
        {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }
    private void FillReportControls(int id)
        {
        try
        {
        string str;
        bool isshow;
        DataTable dt1 = new DataTable();
        objLmsAppReports.Rpt_Id = id;
        dt1 = objLmsAppReports.FetchLmsAppReportsControlsbyRpt_Id(objLmsAppReports);
        System.Web.UI.HtmlControls.HtmlTableRow trrow;

        for (int i = 0; i < dt1.Rows.Count; i++)
            {
            ContentPlaceHolder mpContentPlaceHolder;
            mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

            if (mpContentPlaceHolder != null)
                {
                str = dt1.Rows[i]["Name"].ToString();
                isshow = Convert.ToBoolean(dt1.Rows[i]["isshow"].ToString());
                trrow = (System.Web.UI.HtmlControls.HtmlTableRow)mpContentPlaceHolder.FindControl(str);
                trrow.Visible = isshow;
                }

            }
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
        dt = objBll.SessionSelectAllActiveArchieve();
        objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
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
        bindTermList();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }
}
