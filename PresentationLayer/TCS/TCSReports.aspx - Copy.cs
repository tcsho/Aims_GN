using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI.HtmlControls;


public partial class PresentationLayer_TCS_TCSReports : System.Web.UI.Page
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
            ////}
            ////catch (Exception ex)
            ////{
            ////    Session["error"] = ex.Message;
            ////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            ////}

            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];

            string queryStr = Request.QueryString["id"];
            ViewState["queryStr"] = queryStr;
            //if (queryStr == "92")
            //{
            //    ProgresseEvaluation();
            //}
            ViewState["User_Type_Id"] = Convert.ToInt32(row["User_Type_Id"].ToString());
            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1)//Administrator Officer
            {
                if (queryStr != "20" && queryStr != "23" && queryStr != "28")
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2)//Head Officer 
            {
                if (queryStr != "20" && queryStr != "23" && queryStr != "28" && queryStr != "17" && queryStr != "21" && queryStr != "24" && queryStr != "27" && queryStr != "15" && queryStr != "16" && queryStr != "22" && queryStr != "26" && queryStr != "44" && queryStr != "90" && queryStr != "82" && queryStr != "89" && queryStr != "100" && queryStr != "112" && queryStr != "133" && queryStr != "141" && queryStr != "142" && queryStr != "118" && queryStr != "166")
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }

            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3)//Regional Officer
            {
                if (queryStr != "17" && queryStr != "21" && queryStr != "24" && queryStr != "27" && queryStr != "15" && queryStr != "16" && queryStr != "22" && queryStr != "26" && queryStr != "44" && queryStr != "112" && queryStr != "118" && queryStr != "133" && queryStr != "141" && queryStr != "142" && queryStr != "166")
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4)//Campus Officer
            {
                if (queryStr != "15" && queryStr != "16" && queryStr != "22" && queryStr != "26" && queryStr != "44" && queryStr != "55" && queryStr != "58" && queryStr != "112" && queryStr != "133" && queryStr != "141" && queryStr != "142" && queryStr != "166")
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
            {
                if (queryStr != "35")
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 10)//Network
            {

                //if (queryStr != "35")
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx");
                //}
            }
            else
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx");

            }



            if (!IsPostBack)
            {
                //======== Page Access Settings ========================//

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
                Session.Remove("LastPage");
                Session.Remove("AddCriteria");
                Session.Remove("RptTitle");
                Session.Remove("reppath");
                Session.Remove("rep");
                Session.Remove("CriteriaRpt");
                Session.Remove("rptCmnt");

                //====== End Page Access settings ======================


                loadOrg(sender, e);
                loadReprts(sRet);
                FillActiveSessions();
                loadResultMonth();

                ////////////////////////bindTermList();
                bindTermGroupList();
                bindGradeList();

                FillClass();
                RetrieveAllSubjects();
                FillSubjectDetails();
                string rblselected = rblReportType.SelectedValue;
                int id = Convert.ToInt32(rblselected);
                FillReportControls(id);
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
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 10) //Network
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;
                    fillNetworkCenters();

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


    private void fillNetworkCenters()
    {
        try
        {
            BLLNetworkCenter obj = new BLLNetworkCenter();
            obj.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = new DataTable();
            dt = obj.NetworkCenterSelectByUserID(obj);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            BindCheckBoxListControl(dt, lstCenter, "Center_Id", "Center_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    private void loadClassLevel()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objCen.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue.ToString());


            DataTable dt = new DataTable();
            dt = objCen.CIE_ClassLevelSelect(objCen);
            objBase.FillDropDown(dt, ddlGradeLevel, "GLevel", "GLevel");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlResultMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadClassLevel();
    }

    private void loadResultMonth()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            objBase.FillDropDown(dt, ddlResultMonth, "ResultSeries_Id", "ResultSeries");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void FillSubjectDetails()
    {
        BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
        try
        {
            int user_id = Convert.ToInt32(Session["ContactID"]);
            DataTable dt = objDPUnit.Diag_Prog_UnitSelectSubjectByUser_Id(user_id);
            if (dt.Rows.Count > 0)
            {
                String s = dt.Rows[0]["Subject_Id"].ToString();
                ViewState["SubjectInfo"] = dt.Rows[0]["Subject_Id"].ToString();
                list_Subject.SelectedValue = ViewState["SubjectInfo"].ToString();
                list_Subject.Enabled = false;
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
            Session["Rpt_ID"] = row[0]["Rpt_Id"].ToString();
            Session["RptTitle"] = row[0]["rpt_Caption"].ToString();
            Session["reppath"] = Server.MapPath(row[0]["Rpt_Path"].ToString());
            Session["rep"] = row[0]["Rpt_Name"].ToString();
            _cri = SelectCriteria(_cri, row[0]["Rpt_View"].ToString());
            _isok = true;
            Session["CriteriaRpt"] = _cri;


            if (_isok == true)
            {
                Response.Redirect("~/PresentationLayer/TCS/TssCrystalReports.aspx", false);
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


            string rblselected = rblReportType.SelectedValue;
            int id = Convert.ToInt32(rblselected);
            dt = AdditionalCritieraSet(id);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    protected string SelectCriteria(string _cri, string _view)
    {
        string str = "";
        string sr = ViewState["User_Type_Id"].ToString();


        if (Request.QueryString["id"] != "44")
        {
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
        }

        GridView grdSession = (GridView)UIGridSession.FindControl("grdControl");

        if (grdSession.Rows.Count > 0)
        {
            if (Session["Rpt_ID"].ToString() == "358" || Session["Rpt_ID"].ToString() == "359" || Session["Rpt_ID"].ToString() == "360")
            {
                _cri = _cri + "  and ( {" + _view + ".Session_Id} >=" + (Convert.ToInt32(ddlSession.SelectedValue) - 2) + " and {" + _view + ".Session_Id} <=" + ddlSession.SelectedValue + " )";
            }
            else if (Session["Rpt_ID"].ToString() == "361")
            {
                _cri = _cri + "  and ( {" + _view + ".Session_Id} >=" + (Convert.ToInt32(ddlSession.SelectedValue) - 1) + " and {" + _view + ".Session_Id} <=" + ddlSession.SelectedValue + " )";
            }
            else
            {
                string _strcenter;
                _strcenter = GetDataFromGrid("Session_Id", grdSession);

                _cri = _cri + " and {" + _view + ".Session_Id} IN " + _strcenter;
                Session["Rpt_Session_ID"] = ddlSession.SelectedValue;
            }
        }

        else if (ddlSession.SelectedIndex > 0)
        {
            if (Session["Rpt_ID"].ToString() == "358" || Session["Rpt_ID"].ToString() == "359" || Session["Rpt_ID"].ToString() == "360")
            {
                _cri = _cri + "  and ( {" + _view + ".Session_Id} >=" + (Convert.ToInt32(ddlSession.SelectedValue) - 2) + " and {" + _view + ".Session_Id} <=" + ddlSession.SelectedValue + " )";
            }
            else if (Session["Rpt_ID"].ToString() == "361")
            {
                _cri = _cri + "  and ( {" + _view + ".Session_Id} >=" + (Convert.ToInt32(ddlSession.SelectedValue) - 1) + " and {" + _view + ".Session_Id} <=" + ddlSession.SelectedValue + " )";
            }
            else if (Session["Rpt_ID"].ToString() == "364")
            {
                _cri = _cri + "  and ( {" + _view + ".Drop_Date} ==" + ddlSession.SelectedItem.ToString().Split('-')[1] + " )";
            }
            else
            {
                _cri = _cri + " and {" + _view + ".Session_Id}=" + ddlSession.SelectedValue;
            }
        }
         
        GridView grdRegion = (GridView)UIGridRegion.FindControl("grdControl");

        if (grdRegion.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Region_Id", grdRegion);
            _cri = _cri + " and {" + _view + ".Region_Id} IN " + _strcenter;

        }
        else if (ddl_region.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Region_Id}=" + ddl_region.SelectedValue;

        }


        GridView grdCenter = (GridView)UIGridCenter.FindControl("grdControl");

        if (grdCenter.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Center_Id", grdCenter);
            _cri = _cri + " and {" + _view + ".Center_Id} IN " + _strcenter;

        }
        else if (ddl_center.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Center_Id}=" + ddl_center.SelectedValue;

        }



        GridView grdClassList = (GridView)UIGridClass.FindControl("grdControl");

        if (grdClassList.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Class_Id", grdClassList);

            _cri = _cri + " and {" + _view + ".Class_Id} IN " + _strcenter;
        }

        else if (ddlClass.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Class_Id}=" + ddlClass.SelectedValue;
        }





        if (ddlResultMonth.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".ResultSeries_Id}=" + ddlResultMonth.SelectedValue;
        }

        if (ddlGradeLevel.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Glevel}='" + ddlGradeLevel.SelectedValue + "'";
        }




        if (list_section.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Section_Id}=" + list_section.SelectedValue;
            str = str + "  Section=" + list_section.Text;
        }

        if (List_ClassTeacher.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Employee_Id}=" + List_ClassTeacher.SelectedValue;

        }

        GridView grdGrade = (GridView)UIGridGrade.FindControl("grdControl");

        if (grdGrade.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Result_Grade_Id", grdGrade);
            _cri = _cri + " and {" + _view + ".G} IN " + _strcenter;
        }
        else if (ddlGrade.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".G}=" + ddlGrade.SelectedValue;
        }


        //if (ddlGrade.SelectedIndex > 0)
        //{
        //    GridView grdgradeList = (GridView)UIGridGrade.FindControl("grdControl");

        //    if (grdgradeList.Rows.Count > 0)
        //    {

        //        string _strcenter;

        //        _strcenter = loadGradeList();

        //        _cri = _cri + " and {" + _view + ".G} IN " + _strcenter;
        //        //////str = str + "  Term=" + ddlGrade.Text;

        //    }

        //    else
        //    {
        //        _cri = _cri + " and {" + _view + ".G}=" + "'" + ddlGrade.SelectedItem + "'";
        //        //////////str = str + "  Section=" + ddlGrade.Text;
        //    }
        //}

        if (list_student.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Student_Id}=" + list_student.SelectedValue;
            str = str + "  Student=" + list_student.Text;
        }

        if (listTermGroup.SelectedIndex > 0)
        {

            _cri = _cri + " and {" + _view + ".TermGroup_Id}=" + listTermGroup.SelectedValue;

        }
        if (ddlTerm.SelectedIndex > 0)
        {

            _cri = _cri + " and {" + _view + ".TermId}=" + ddlTerm.SelectedValue;



        }


        GridView grdTerm = (GridView)UIGridTerm.FindControl("grdControl");

        if (grdTerm.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Evaluation_Criteria_Type_Id", grdTerm);
            _cri = _cri + " and {" + _view + ".TermId} IN " + _strcenter;
        }
        else if (ddlTerm.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".TermId}=" + ddlTerm.SelectedValue;
        }


        GridView grdSubject = (GridView)UiGridSubject.FindControl("grdControl");

        if (grdSubject.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Subject_Id", grdSubject);
            _cri = _cri + " and {" + _view + ".Subject_Id} IN " + _strcenter;
        }
        else if (list_Subject.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Subject_Id}=" + list_Subject.SelectedValue;
        }

        if (txtFrmDate.Text.Length > 0)
        {
            if (txtToDate.Text.Length < 1)
            {
                ImpromptuHelper.ShowPrompt("Plase select ToDate");
            }
            else
            {
                _cri = _cri + "and Date({vwTSS_PeriodicStudentRegistration.ParamDate})>=#" + txtFrmDate.Text + "# and Date({vwTSS_PeriodicStudentRegistration.ParamDate})<=#" + txtToDate.Text + "#";

            }
        }
        DataRow row = (DataRow)Session["rightsRow"];
        if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
        {

            _cri = _cri + " and {" + _view + ".Teacher_Id}=" + row["EmployeeCode"].ToString();

        }

        else if (ddlGender.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Gender_Id}=" + ddlGender.SelectedValue;
        }


        if (Session["AddCriteria"] != null)
        {
            _cri = _cri + Session["AddCriteria"].ToString();
        }


        if (ViewState["User_Type_Id"].ToString() == "31" && ddl_center.SelectedIndex <= 0)
        {
            string s = "[";
            int count = 0;
            foreach (ListItem i in ddl_center.Items)
            {
                count++;
                if (Convert.ToInt32(i.Value) != 0)
                    s = s + i.Value + " , ";
                if (ddl_center.Items.Count == count)
                    s = s + i.Value;
            }
            _cri = _cri + " and {" + _view + ".Center_Id} IN " + s + "]";
        }
        Session["rptCmnt"] = str;
        return _cri;
    }


    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

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
            string q = Request.QueryString["id"];
            string s = Request.QueryString["id"];
            if (Convert.ToInt32(s) == 92 || Convert.ToInt32(s) > 92 || Convert.ToInt32(s) == 97 || Convert.ToInt32(s) < 97)
            {
                //lab_center.Text = "School*: ";
            }

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ddl_country.SelectedValue.ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            BindCheckBoxListControl(dt, lstRegion, "Region_Id", "Region_Name");
            ////////////UserInformationGrid2.SetData(dt);

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
            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            if (ddlSession.SelectedIndex > 0)
            {
                objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            }
            else
            {
                objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            }

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            BindCheckBoxListControl(dt, lstCenter, "Center_Id", "Center_Name");

            DataRow row = (DataRow)Session["rightsRow"];

            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
            {
                ddl_center.SelectedValue = row["Center_Id"].ToString();
            }

            //////////UserInformationGrid3.SetData(dt);
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
            FillClass();
            FillActiveTeacher();
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

             
                dt = objBLLClass.ClassFetch(objBLLClass);
             
             
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");

            BindCheckBoxListControl(dt, lstClass, "Class_Id", "Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void BindCheckBoxListControl(DataTable dt, CheckBoxList cblList, string Id, string name)
    {
        cblList.DataSource = dt;
        cblList.DataTextField = name;
        cblList.DataValueField = Id;
        cblList.DataBind();
    }

    private void FillClassDP()
    {
        BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
        try
        {

            objDPUnit.Subject_Id = Convert.ToInt16(ViewState["SubjectInfo"]);
            DataTable dtClass = objDPUnit.Diag_Prog_UnitSelectClassBySubject_Id(objDPUnit);

            objBase.FillDropDown(dtClass, ddlClass, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetDropDownList()
    {
        DataRow row = (DataRow)Session["rightsRow"];
        try
        {
            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
            {
                ddlReset(ddlSession);
                ddlReset(ddlClass);
                ddlReset(list_section);
                ddlReset(list_student);
                ddlReset(ddlTerm);
                ddlReset(ddlGrade);
                ddlReset(listTermGroup);
                // ddlReset(List_ClassTeacher);
                return;
            }
            if ((Convert.ToInt32(row["UserLevel_ID"].ToString()) != 3) && (Convert.ToInt32(row["UserLevel_ID"].ToString()) != 4) && (Convert.ToInt32(row["UserLevel_ID"].ToString()) != 10))//Regional Officer and Network Officer
            {
                ddlReset(ddl_region);
            }
            //////////ddlReset(ddl_region);
            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) != 4)//Campus Officer
            {
                ddlReset(ddl_center);
            }

            if (Convert.ToInt32(Session["UserType_Id"].ToString()) != 29)//SubjectHOD's Selected Subject will not change
            {
                ddlReset(list_Subject);
            }
            ddlReset(ddlSession);
            ddlReset(ddlClass);
            ddlReset(list_section);
            ddlReset(list_student);
            ddlReset(ddlTerm);
            ddlReset(ddlGrade);
            ddlReset(listTermGroup);
            ddlReset(List_ClassTeacher);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void ddlReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void RetrieveAllSubjects()
    {
        try
        {
            BLLSubject objBllSubject = new BLLSubject();
            DataTable dt = new DataTable();

            ////////// Comment on 22 Feb 2016 without class filter 
            ////////////objBllSubject.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);            
            ////////////dt = objBllSubject.SubjectFetchByClassID(objBllSubject);

            dt = objBllSubject.SubjectSelectAllWithSubNameGroup(objBllSubject);
            objBase.FillDropDown(dt, list_Subject, "Subject_Id", "Subject_Name");
            BindCheckBoxListControl(dt, lstSubject, "Subject_Id", "Subject_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void rblReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Reports"];

            ResetDropDownList();
            string rblselected = rblReportType.SelectedValue;

            int id = Convert.ToInt32(rblselected);

            dt = AdditionalCritieraSet(id);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private DataTable AdditionalCritieraSet(int id)
    {
        DataTable dt = objLmsAppReports.LmsAppReportsFetch(id);
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

        return dt;
    }

    protected void bindTermList()
    {
        try
        {
            //if (ddlClass.SelectedIndex > 0)
            //{

            //// * Comment of request of user to need filer for all reports without class id 2 feb 2016
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            ObjECT.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            if (ObjECT.Class_Id != null)
            {
                dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);
                objBase.FillDropDown(dt, ddlTerm, "Evaluation_Criteria_Type_Id", "Type");
                BindCheckBoxListControl(dt, lstTerm, "Evaluation_Criteria_Type_Id", "Type");
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void bindTermGroupList()
    {
        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, listTermGroup, "TermGroup_Id", "Type");
            ddlTerm.SelectedIndex = 1;
            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void bindGradeList()
    {
        try
        {

            DataTable dtgr = null;

            BLLResult_Grade objgrade = new BLLResult_Grade();
            dtgr = objgrade.Result_GradeSelectAllWithoutClassId(objgrade);
            objBase.FillDropDown(dtgr, ddlGrade, "Result_Grade_Id", "Grade");
            BindCheckBoxListControl(dtgr, lstGrade, "Result_Grade_Id", "Grade");



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

            ClearControlGrid();
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
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            BindCheckBoxListControl(dt, lstSessions, "Session_ID", "Description");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void FillActiveTeacher()
    {
        try
        {

            DataTable dt = new DataTable();

            BLLClass_Section obj = new BLLClass_Section();

            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

            dt = (DataTable)obj.Employee_ProfileByCenterId(obj);
            objBase.FillDropDown(dt, List_ClassTeacher, "Employee_Id", "TeacherFullName");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void LoadClassSection()
    {
        try
        {
            list_section.Items.Clear();
            BLLSection objSec = new BLLSection();
            DataRow row = (DataRow)Session["rightsRow"];
            if (ddlClass.SelectedValue != "")
            {
                objSec.Center_Id = Int32.Parse(ddl_center.SelectedValue);
                objSec.Class_Id = Int32.Parse(ddlClass.SelectedValue);

                DataTable dt = new DataTable();

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
                {
                    objSec.Teacher_Id = Convert.ToInt32(row["EmployeeCode"].ToString());
                    dt = objSec.SectionSelectByClassTeacherCenter(objSec);
                }
                else
                {
                    dt = objSec.SectionFetchByClassCenter(objSec);
                }


                objBase.FillDropDown(dt, list_section, "Section_Id", "Section_Name");






                if (list_section.Items.Count == 0)
                {
                    ImpromptuHelper.ShowPrompt("This class has no section assigned to it. Please assign section(s) to this class first.");
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadClassSection();
            bindTermList();
            ////////// Comment on 22 Feb 2016 without class filter 
            //////////////////RetrieveAllSubjects();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_section_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (list_section.SelectedValue.ToString() != "")
            {
                BindStudentsList();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BindStudentsList()
    {
        try
        {
            BLLStudent_Section_Subject objStd = new BLLStudent_Section_Subject();

            objStd.Section_Id = Convert.ToInt32(list_section.SelectedValue.ToString());
            objStd.Student_Status_Id = 5;
            DataTable dt = null;
            list_student.Enabled = true;
            dt = objStd.Student_Section_SubjectFetchBySectionID(objStd);
            ViewState["Students"] = dt;
            objBase.FillDropDown(dt, list_student, "Student_Id", "id_name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void linkCenter_Click(object sender, EventArgs e)
    {
        if (ddl_center.SelectedIndex > 0)
        {

            DataTable dt = null;
            DataRow dr;

            if (ViewState["centerlist"] != null)
            {
                dt = (DataTable)ViewState["centerlist"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Center_Id");
                dt.Columns.Add("Center Name");
            }
            dr = dt.NewRow();

            dr["Center_Id"] = ddl_center.Text;
            dr["Center Name"] = ddl_center.SelectedItem;
            ////dt.Rows.Add(dr);

            if (ViewState["centerlist"] != null)
            {
                string result = "";
                int row = dt.Rows.Count - 1;

                for (int i = 0; i <= row; i++)
                {
                    int cntid = Convert.ToInt32(dt.Rows[i]["Center_Id"].ToString());
                    if (cntid != Convert.ToInt32(ddl_center.Text.ToString()))
                    {
                        //dtreg.Rows.Add(drreg);
                        result = "True";
                    }
                    else
                    {
                        result = "False";
                    }

                }
                if (result == "True")
                {
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                dt.Rows.Add(dr);
            }

            ViewState["centerlist"] = dt;

            UIGridCenter.SetData(dt);


        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select Center!");
        }
    }
    protected void linkSubject_Click(object sender, EventArgs e)
    {
        if (list_Subject.SelectedIndex > 0)
        {
            DataTable dtsub = null;
            DataRow drsub;

            if (ViewState["Subjectlist"] != null)
            {
                dtsub = (DataTable)ViewState["Subjectlist"];
            }
            else
            {
                dtsub = new DataTable();
                dtsub.Columns.Add("Subject_Id");
                dtsub.Columns.Add("Subject Name");
            }
            drsub = dtsub.NewRow();

            drsub["Subject_Id"] = list_Subject.Text;
            drsub["Subject Name"] = list_Subject.SelectedItem;
            //////dtsub.Rows.Add(drsub);

            if (ViewState["Subjectlist"] != null)
            {
                string result = "";
                int row = dtsub.Rows.Count - 1;

                for (int i = 0; i <= row; i++)
                {
                    int cntid = Convert.ToInt32(dtsub.Rows[i]["Subject_Id"].ToString());
                    if (cntid != Convert.ToInt32(list_Subject.Text.ToString()))
                    {
                        //dtreg.Rows.Add(drreg);
                        result = "True";
                    }
                    else
                    {
                        result = "False";
                    }

                }
                if (result == "True")
                {
                    dtsub.Rows.Add(drsub);
                }
            }
            else
            {
                dtsub.Rows.Add(drsub);
            }

            ViewState["Subjectlist"] = dtsub;

            UiGridSubject.SetData(dtsub);
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select Subject!");
        }
    }


    //protected string loadCenterList()
    //{

    //    string str = "[";

    //    DataTable dtcenter = (DataTable)ViewState["centerlist"];

    //    int row = dtcenter.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        str = str + Convert.ToInt32(dtcenter.Rows[i]["Center_Id"].ToString());
    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}

    //protected string loadSubjectList()
    //{

    //    string str = "[";

    //    DataTable dtsubject = (DataTable)ViewState["Subjectlist"];

    //    int row = dtsubject.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        ////////// Comment on 22 Feb 2016 without class filter
    //        ////////////////str = str + Convert.ToInt32(dtsubject.Rows[i]["Subject_Id"].ToString());

    //        str = str + "'" + dtsubject.Rows[i]["Subject_Id"].ToString() + "'";

    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}

    protected void linkAddRegion_Click(object sender, EventArgs e)
    {
        if (ddl_region.SelectedIndex > 0)
        {
            DataTable dtreg = null;
            DataRow drreg;

            if (ViewState["Regionlist"] != null)
            {
                dtreg = (DataTable)ViewState["Regionlist"];
            }
            else
            {
                dtreg = new DataTable();
                dtreg.Columns.Add("Region_Id");
                dtreg.Columns.Add("Region Name");
                ////////////////////dtreg.Columns.Add("Delete");
            }
            drreg = dtreg.NewRow();

            drreg["Region_Id"] = ddl_region.Text;
            drreg["Region Name"] = ddl_region.SelectedItem;
            //drreg["Delete"] = "";
            if (ViewState["Regionlist"] != null)
            {
                string result = "";
                int row = dtreg.Rows.Count - 1;

                for (int i = 0; i <= row; i++)
                {
                    int Regid = Convert.ToInt32(dtreg.Rows[i]["Region_Id"].ToString());
                    if (Regid != Convert.ToInt32(ddl_region.Text.ToString()))
                    {
                        //dtreg.Rows.Add(drreg);
                        result = "True";
                    }
                    else
                    {
                        result = "False";
                    }

                }
                if (result == "True")
                {
                    dtreg.Rows.Add(drreg);
                }
            }
            else
            {
                dtreg.Rows.Add(drreg);
            }
            ViewState["Regionlist"] = dtreg;

            UIGridRegion.SetData(dtreg);

        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select Region!");
        }

    }

    //protected string loadRegionList()
    //{

    //    string str = "[";

    //    DataTable dtregion = (DataTable)ViewState["Regionlist"];

    //    int row = dtregion.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        str = str + Convert.ToInt32(dtregion.Rows[i]["Region_Id"].ToString());
    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}
    //protected void lnkSessionAdd_Click(object sender, EventArgs e)
    //{

    //    DataTable dtcls = ListMultiple("Session_Id", "Description", lstSessions);
    //    UIGridSession.SetData(dtcls);
    //    lstSessions.Visible = false;

    //    //if (ddlSession.SelectedIndex > 0)
    //    //{

    //    //    DataTable dtses = null;
    //    //    DataRow drses;

    //    //    if (ViewState["Sessionlist"] != null)
    //    //    {
    //    //        dtses = (DataTable)ViewState["Sessionlist"];
    //    //    }
    //    //    else
    //    //    {
    //    //        dtses = new DataTable();
    //    //        dtses.Columns.Add("Session_Id");
    //    //        dtses.Columns.Add("Description");
    //    //    }
    //    //    drses = dtses.NewRow();

    //    //    drses["Session_Id"] = ddlSession.Text;
    //    //    drses["Description"] = ddlSession.SelectedItem;
    //    //    ////////dtses.Rows.Add(drses);

    //    //    if (ViewState["Sessionlist"] != null)
    //    //    {
    //    //        string result = "";
    //    //        int row = dtses.Rows.Count - 1;

    //    //        for (int i = 0; i <= row; i++)
    //    //        {
    //    //            int sessid = Convert.ToInt32(dtses.Rows[i]["Session_Id"].ToString());
    //    //            if (sessid != Convert.ToInt32(ddlSession.Text.ToString()))
    //    //            {
    //    //                //dtreg.Rows.Add(drreg);
    //    //                result = "True";
    //    //            }
    //    //            else
    //    //            {
    //    //                result = "False";
    //    //            }

    //    //        }
    //    //        if (result == "True")
    //    //        {
    //    //            dtses.Rows.Add(drses);
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        dtses.Rows.Add(drses);
    //    //    }


    //    //    ViewState["Sessionlist"] = dtses;

    //    //    UserInformationGrid2.SetData(dtses);

    //    //}
    //    //else
    //    //{
    //    //    ImpromptuHelper.ShowPrompt("Please select Session!");
    //    //}

    //}

    //protected string loadSessionList()
    //{

    //    string str = "[";

    //    DataTable dtsession = (DataTable)ViewState["Sessionlist"];

    //    int row = dtsession.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        str = str + Convert.ToInt32(dtsession.Rows[i]["Session_Id"].ToString());
    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}



    private DataTable ListMultiple(string Id, string name, CheckBoxList cblitems)
    {
        DataTable dtcls = null;
        DataRow drcls;

        dtcls = new DataTable();
        dtcls.Columns.Add(Id);
        dtcls.Columns.Add(name);

        foreach (ListItem item in cblitems.Items)
        {
            if (item.Selected == true)
            {
                drcls = dtcls.NewRow();
                drcls[Id] = item.Value;
                drcls[name] = item.Text;
                dtcls.Rows.Add(drcls);
            }
        }

        return dtcls;
    }


    //protected string loadClassList()
    //{
    //    //nkClassAdd_Click(this, EventArgs.Empty);
    //    string str = "";
    //    DataTable dtclass = (DataTable)ViewState["Classlist"];
    //    if (ViewState["Classlist"]!=null && dtclass.Rows.Count > 0)
    //    {
    //        int row = dtclass.Rows.Count - 1;
    //        str = "[";
    //        for (int i = 0; i <= row; i++)
    //        {
    //            str = str + Convert.ToInt32(dtclass.Rows[i]["Class_Id"].ToString());
    //            if (i < row)
    //            {
    //                str = str + ",";
    //            }
    //            else
    //            {
    //                str = str + "]";
    //            }
    //        }
    //    }
    //    return str;
    //}

    //protected void lnkTerm_Click(object sender, EventArgs e)
    //{
    //    if (ddlTerm.SelectedIndex > 0)
    //    {
    //        DataTable dttrm = null;
    //        DataRow drtrm;

    //        if (ViewState["Termlist"] != null)
    //        {
    //            dttrm = (DataTable)ViewState["Termlist"];
    //        }
    //        else
    //        {
    //            dttrm = new DataTable();
    //            dttrm.Columns.Add("TermGroup_Id");
    //            dttrm.Columns.Add("Type");
    //        }
    //        drtrm = dttrm.NewRow();

    //        drtrm["TermGroup_Id"] = ddlTerm.Text;
    //        drtrm["Type"] = ddlTerm.SelectedItem;
    //        //////dttrm.Rows.Add(drtrm);

    //        if (ViewState["Termlist"] != null)
    //        {
    //            string result = "";
    //            int row = dttrm.Rows.Count - 1;

    //            for (int i = 0; i <= row; i++)
    //            {
    //                int trmid = Convert.ToInt32(dttrm.Rows[i]["TermGroup_Id"].ToString());
    //                if (trmid != Convert.ToInt32(ddlTerm.Text.ToString()))
    //                {
    //                    //dtreg.Rows.Add(drreg);
    //                    result = "True";
    //                }
    //                else
    //                {
    //                    result = "False";
    //                }

    //            }
    //            if (result == "True")
    //            {
    //                dttrm.Rows.Add(drtrm);
    //            }
    //        }
    //        else
    //        {
    //            dttrm.Rows.Add(drtrm);
    //        }


    //        ViewState["Termlist"] = dttrm;

    //        UIGridTerm.SetData(dttrm);
    //    }
    //    else
    //    {
    //        ImpromptuHelper.ShowPrompt("Please select Term!");
    //    }
    //}

    //protected string loadTermList()
    //{

    //    string str = "[";

    //    DataTable dtterm = (DataTable)ViewState["Termlist"];

    //    int row = dtterm.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        str = str + Convert.ToInt32(dtterm.Rows[i]["TermGroup_Id"].ToString());
    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}

    //protected void lnkGradeAdd_Click(object sender, EventArgs e)
    //{
    //    if (ddlGrade.SelectedIndex > 0)
    //    {
    //        DataTable dtgred = null;
    //        DataRow drgred;

    //        if (ViewState["Gradelist"] != null)
    //        {
    //            dtgred = (DataTable)ViewState["Gradelist"];
    //        }
    //        else
    //        {
    //            dtgred = new DataTable();
    //            dtgred.Columns.Add("Result_Grade_Id");
    //            dtgred.Columns.Add("Grade");
    //        }
    //        drgred = dtgred.NewRow();

    //        drgred["Result_Grade_Id"] = ddlGrade.Text;
    //        drgred["Grade"] = ddlGrade.SelectedItem;
    //        ////////////dtgred.Rows.Add(drgred);

    //        if (ViewState["Gradelist"] != null)
    //        {
    //            string result = "";
    //            int row = dtgred.Rows.Count - 1;

    //            for (int i = 0; i <= row; i++)
    //            {
    //                int cntid = Convert.ToInt32(dtgred.Rows[i]["Result_Grade_Id"].ToString());
    //                if (cntid != Convert.ToInt32(ddlGrade.Text.ToString()))
    //                {
    //                    //dtreg.Rows.Add(drreg);
    //                    result = "True";
    //                }
    //                else
    //                {
    //                    result = "False";
    //                }

    //            }
    //            if (result == "True")
    //            {
    //                dtgred.Rows.Add(drgred);
    //            }
    //        }
    //        else
    //        {
    //            dtgred.Rows.Add(drgred);
    //        }


    //        ViewState["Gradelist"] = dtgred;

    //        UIGridGrade.SetData(dtgred);
    //    }
    //    else
    //    {
    //        ImpromptuHelper.ShowPrompt("Please select Grade!");
    //    }
    //}

    //protected string loadGradeList()
    //{


    //    string str = "[";

    //    DataTable dtgrade = (DataTable)ViewState["Gradelist"];

    //    int row = dtgrade.Rows.Count - 1;

    //    for (int i = 0; i <= row; i++)
    //    {
    //        str = str + "'" + dtgrade.Rows[i]["Grade"].ToString() + "'";
    //        if (i < row)
    //        {
    //            str = str + ",";
    //        }
    //        else
    //        {
    //            str = str + "]";
    //        }
    //    }
    //    return str;
    //}

    protected void ClearControlGrid()
    {
        DataTable dtclear = null;

        UIGridRegion.SetData(dtclear);
        UIGridCenter.SetData(dtclear);
        UIGridSession.SetData(dtclear);
        UIGridClass.SetData(dtclear);
        UiGridSubject.SetData(dtclear);
        UIGridTerm.SetData(dtclear);
        UIGridGrade.SetData(dtclear);



    }


    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            loadCenter();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //protected void LinkButton2_Click(object sender, EventArgs e)
    //{
    //    lstSessions.Visible = true;
    //    ViewState["MultiSession"] = true;
    //}



    protected string GetDataFromGrid(string Id, GridView grd)
    {
        string str = "";
        if (grd.Rows.Count > 0)
        {
            int row = grd.Rows.Count - 1;
            str = "[";
            foreach (GridViewRow gvr in grd.Rows)
            {
                str = str + Convert.ToInt32(gvr.Cells[1].Text);
                if (gvr.RowIndex < row)
                {
                    str = str + ",";
                }
                else
                {
                    str = str + "]";
                }
            }
        }
        return str;
    }



    /*
     Following Code Added by Syed Fawad Ali - 10 June 2019
         */
    private void SetGridViewControlEmtpy(GridView grd)
    {
        grd.DataSource = null;
        grd.DataBind();
    }
    protected void linkMultiClass_Click(object sender, EventArgs e)
    {
        lstClass.Visible = true;
        lbClassAdd.Visible = true;
    }


    protected void lbClassAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Class_Id", "ClassName", lstClass);
        UIGridClass.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddlClass.Visible = false;
            ddlClass.SelectedIndex = 0;
        }
        else
        {
            ddlClass.Visible = true;
            GridView grd = (GridView)UIGridClass.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstClass.Visible = false;
        lbClassAdd.Visible = false;
    }



    protected void lnkMultiSession_Click(object sender, EventArgs e)
    {
        lstSessions.Visible = true;
        lbSessionAdd.Visible = true;
    }

    protected void lbSessionAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Session_Id", "Description", lstSessions);
        UIGridSession.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddlSession.Visible = false;
            ddlSession.SelectedIndex = 0;
        }
        else
        {
            ddlSession.Visible = true;
            GridView grd = (GridView)UIGridSession.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstSessions.Visible = false;
        lbSessionAdd.Visible = false;
    }

    protected void lbRegionAdd_Click(object sender, EventArgs e)
    {

        DataTable dt = ListMultiple("Region_Id", "Region_Name", lstRegion);
        UIGridRegion.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddl_region.Visible = false;
            ddl_region.SelectedIndex = 0;
        }
        else
        {
            ddl_region.Visible = true;
            GridView grd = (GridView)UIGridRegion.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstRegion.Visible = false;
        lbRegionAdd.Visible = false;

    }

    protected void linkMultiRegion_Click(object sender, EventArgs e)
    {
        lstRegion.Visible = true;
        lbRegionAdd.Visible = true;
    }

    protected void linkMultiCenter_Click(object sender, EventArgs e)
    {
        lstCenter.Visible = true;
        lbCenterAdd.Visible = true;
    }

    protected void lbCenterAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Center_Id", "Center_Name", lstCenter);
        UIGridCenter.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddl_center.Visible = false;
            ddl_center.SelectedIndex = 0;
        }
        else
        {
            ddl_center.Visible = true;
            GridView grd = (GridView)UIGridCenter.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstCenter.Visible = false;
        lbCenterAdd.Visible = false;
    }

    protected void linkMultiSubject_Click(object sender, EventArgs e)
    {
        lstSubject.Visible = true;
        lbSubjectAdd.Visible = true;
    }

    protected void lbSubjectAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Subject_Id", "Subject_Name", lstSubject);
        UiGridSubject.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            list_Subject.Visible = false;
            list_Subject.SelectedIndex = 0;
        }
        else
        {
            list_Subject.Visible = true;
            GridView grd = (GridView)UiGridSubject.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstSubject.Visible = false;
        lbSubjectAdd.Visible = false;
    }

    protected void lnkMultiTerm_Click(object sender, EventArgs e)
    {
        lstTerm.Visible = true;
        lbTermAdd.Visible = true;
    }

    protected void lbTermAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Evaluation_Criteria_Type_Id", "Type", lstTerm);

        UIGridTerm.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddlTerm.Visible = false;
            ddlTerm.SelectedIndex = 0;
        }
        else
        {
            ddlTerm.Visible = true;
            GridView grd = (GridView)UIGridTerm.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstTerm.Visible = false;
        lbTermAdd.Visible = false;
    }

    protected void lnkMultiGrade_Click(object sender, EventArgs e)
    {
        lstGrade.Visible = true;
        lbGradeAdd.Visible = true;
    }

    protected void lbGradeAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Result_Grade_Id", "Grade", lstGrade);

        UIGridGrade.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddlGrade.Visible = false;
            ddlGrade.SelectedIndex = 0;
        }
        else
        {
            ddlGrade.Visible = true;
            GridView grd = (GridView)UIGridGrade.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstGrade.Visible = false;
        lbGradeAdd.Visible = false;
    }
}