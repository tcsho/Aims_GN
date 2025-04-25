using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADG.JQueryExtenders.Impromptu;
using System.IO;
using System.Text;

public partial class PresentationLayer_GLReport : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnExport);

        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (!Page.IsPostBack)
            {
                btnExport.Enabled = false;
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                loadOrg(sender, e);
                FillActiveSessions();
                bindTermGroupList();
                FillClass();
                FillSubject();
                ClearControlGrid();

                btnExport.Visible = false;


                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_Region_SelectedIndexChanged(sender, e);
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
                    //ddl_center_SelectedIndexChanged(sender, e);

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
                    //ddl_center_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    //ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 10) //Network
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = false;
                    //ddl_region.Enabled = false;
                    ddl_center.Enabled = true;
                    //fillNetworkCenters();

                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ClearControlGrid()
    {
        DataTable dtclear = null;

        UIGridRegion.SetData(dtclear);
        UIGridCenter.SetData(dtclear);
        UIGridSession.SetData(dtclear);
        UIGridClass.SetData(dtclear);
        UIGridSubject.SetData(dtclear);
        //UiGridSubject.SetData(dtclear);
        UIGridTerm.SetData(dtclear);



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
            listTermGroup.Visible = false;
            listTermGroup.SelectedIndex = 0;
        }
        else
        {
            listTermGroup.Visible = true;
            GridView grd = (GridView)UIGridTerm.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstTerm.Visible = false;
        lbTermAdd.Visible = false;
    }

    protected void linkMultiClass_Click(object sender, EventArgs e)
    {
        lstClass.Visible = true;
        lbClassAdd.Visible = true;
    }


    protected void lbClassAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Class_Id", "Name", lstClass);
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

    protected void linkMultiSubject_Click(object sender, EventArgs e)
    {
        lstSubject.Visible = true;
        lbSubjectAdd.Visible = true;
    }


    protected void lbSubjectAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ListMultiple("Subject_Id", "Name", lstSubject);
        UIGridSubject.SetData(dt);
        if (dt.Rows.Count > 0)
        {
            ddlSubject.Visible = false;
            ddlSubject.SelectedIndex = 0;
        }
        else
        {
            ddlSubject.Visible = true;
            GridView grd = (GridView)UIGridSubject.FindControl("grdControl");
            SetGridViewControlEmtpy(grd);
        }
        lstSubject.Visible = false;
        lbSubjectAdd.Visible = false;
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
    protected void linkMultiRegion_Click(object sender, EventArgs e)
    {
        lstRegion.Visible = true;
        lbRegionAdd.Visible = true;
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

    private void SetGridViewControlEmtpy(GridView grd)
    {
        grd.DataSource = null;
        grd.DataBind();
    }

    private void BindCheckBoxListControl(DataTable dt, CheckBoxList cblList, string Id, string name)
    {
        cblList.DataSource = dt;
        cblList.DataTextField = name;
        cblList.DataValueField = Id;
        cblList.DataBind();
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
                ddlReset(ddlSubject);
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
                ddlReset(ddlSubject);
            }
            ddlReset(ddlSession);
            ddlReset(ddlClass);
            ddlReset(ddlSubject);
            ddlReset(listTermGroup);
            ddlReset(listTermGroup);

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

    protected string GetDataFromGrid(string Id, GridView grd)
    {
        string str = "";
        if (grd.Rows.Count > 0)
        {
            int row = grd.Rows.Count - 1;
            str = "(";
            foreach (GridViewRow gvr in grd.Rows)
            {
                str = str + Convert.ToInt32(gvr.Cells[1].Text);
                if (gvr.RowIndex < row)
                {
                    str = str + ",";
                }
                else
                {
                    str = str + ")";
                }
            }
        }
        return str;
    }

    protected string SelectCriteria(string _cri)
    {
        string str = "";
        //string sr = ViewState["User_Type_Id"].ToString();

        /////Region
        GridView grdRegion = (GridView)UIGridRegion.FindControl("grdControl");

        if (grdRegion.Rows.Count > 0)
        {
            string _strregion;
            _strregion = GetDataFromGrid("Region_Id", grdRegion);
            _cri = _cri + " and Region_Id IN " + _strregion;
        }
        else if (ddl_region.SelectedIndex > 0)
        {
            _cri = _cri + " and Region_Id = " + ddl_region.SelectedValue;
        }

        /////Session
        GridView grdSession = (GridView)UIGridSession.FindControl("grdControl");

        if (grdSession.Rows.Count > 0)
        {
            string _strsession;
            _strsession = GetDataFromGrid("Session_Id", grdSession);

            _cri = _cri + " and Session_Id IN " + _strsession;
        }

        else if (ddlSession.SelectedIndex > 0)
        {
            _cri = _cri + " and Session_Id = " + ddlSession.SelectedValue;
        }

        /////Term
        GridView grdterm = (GridView)UIGridTerm.FindControl("grdControl");

        if (grdterm.Rows.Count > 0)
        {
            string _strterm;
            _strterm = GetDataFromGrid("Session_Id", grdterm);

            _cri = _cri + " and TermGroupID IN " + _strterm;
        }

        else if (listTermGroup.SelectedIndex > 0)
        {
            _cri = _cri + " and TermGroupID = " + listTermGroup.SelectedValue;
        }


        /////Center
        GridView grdCenter = (GridView)UIGridCenter.FindControl("grdControl");

        if (grdCenter.Rows.Count > 0)
        {
            string _strcenter;
            _strcenter = GetDataFromGrid("Center_Id", grdCenter);
            _cri = _cri + " and Center_Id IN " + _strcenter;
        }
        else if (ddl_center.SelectedIndex > 0)
        {
            _cri = _cri + " and Center_Id = " + ddl_center.SelectedValue;
        }

        
        /////Class
        GridView grdClassList = (GridView)UIGridClass.FindControl("grdControl");

        if (grdClassList.Rows.Count > 0)
        {
            string _strclass;
            _strclass = GetDataFromGrid("Class_Id", grdClassList);

            _cri = _cri + " and Class_Id IN " + _strclass;
        }

        else if (ddlClass.SelectedIndex > 0)
        {
            _cri = _cri + " and Class_Id = " + ddlClass.SelectedValue;
        }

        /////Subject
        GridView grdSubject = (GridView)UIGridSubject.FindControl("grdControl");

        if (grdSubject.Rows.Count > 0)
        {
            string _strsubject;
            _strsubject = GetDataFromGrid("Subject_Id", grdSubject);

            _cri = _cri + " and Subject_Id IN " + _strsubject;
        }

        else if (ddlSubject.SelectedIndex > 0)
        {
            _cri = _cri + " and Subject_Id = " + ddlSubject.SelectedValue;
        }

        if (_cri != "")
        {
            string strcheck = _cri;
            if (strcheck.Substring(0, 5) == " and ")
                _cri = _cri.Substring(5);
        }

        return _cri;
    }

    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            string _cri = "";
            _cri = SelectCriteria(_cri);

            BLLGLResult objClass = new BLLGLResult();

            //SearchClassTableAdapters.SearchClassTableAdapter classDa = new SearchClassTableAdapters.SearchClassTableAdapter();

            //objClass.Class_Name = text_className.Text;
            //objClass.Class_Name = list_grade.SelectedValue.ToString();
            //objClass.Main_Organisation_IdS = Session["moID"].ToString();
            int RegionID = Convert.ToInt32(ddl_region.SelectedValue);
            int SessionID = Convert.ToInt32(ddlSession.SelectedValue);
            int TermGroupID = Convert.ToInt32(listTermGroup.SelectedValue);
            int CenterID = Convert.ToInt32(ddl_center.SelectedValue);
            int ClassID = Convert.ToInt32(ddlClass.SelectedValue);
            int SubjectID = Convert.ToInt32(ddlSubject.SelectedValue);
            //int TermGroup = Convert.ToInt32(listTermGroup.SelectedValue);


            DataTable dt = objClass.GLResultSearch(_cri);

            //SearchClass.SearchClassDataTable dt = classDa.GetData(, list_grade.SelectedValue.ToString(), Session["moID"].ToString());
            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                dg_class.DataSource = dt;
                lab_dataStatus.Visible = false;
                btnExport.Visible = true;

            }

            dg_class.DataBind();


            ViewState["classDT"] = dg_class.DataSource;
            btnExport.Enabled = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_export_Click(object sender, EventArgs e)
    {
        try
        {
            ////////Export to Word//////////////
            //Response.Clear();

            //Response.Buffer = true;

            //Response.AddHeader("content-disposition",

            //"attachment;filename=GridViewExport.doc");

            //Response.Charset = "";

            //Response.ContentType = "application/vnd.ms-word ";

            //StringWriter sw = new StringWriter();

            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //dg_class.AllowPaging = false;

            //dg_class.RenderControl(hw);

            //Response.Output.Write(sw.ToString());

            //Response.Flush();

            //Response.End();


            ////////Export to Excel//////////////
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            dg_class.AllowPaging = false;
            //Change the Header Row back to white color
            //dg_class.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Apply style to Individual Cells
            //dg_class.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //dg_class.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //dg_class.HeaderRow.Cells[2].Style.Add("background-color", "green");
            for (int i = 0; i < dg_class.Rows.Count; i++)
            {
                GridViewRow row = dg_class.Rows[i];
                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;
                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                //Apply style to Individual Cells of Alternating Row
                //if (i % 2 != 0)
                //{
                //    row.Cells[0].Style.Add("background-color", "#C2D69B");
                //    row.Cells[1].Style.Add("background-color", "#C2D69B");
                //    row.Cells[2].Style.Add("background-color", "#C2D69B");
                //}
            }
            dg_class.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            //style to format numbers to string
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            ////////Export to CSV//////////////
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GLData.csv");
            //Response.Charset = "";
            //Response.ContentType = "application/text";
            //dg_class.AllowPaging = false;

            //StringBuilder sb = new StringBuilder();
            //for (int k = 0; k < dg_class.Columns.Count; k++)
            //{
            //    //add separator
            //    sb.Append(dg_class.Columns[k].HeaderText + ',');
            //}
            ////append new line
            //sb.Append("\r\n");

            //for (int i = 0; i < dg_class.Rows.Count; i++)
            //{
            //    for (int k = 0; k < dg_class.Columns.Count; k++)
            //    {
            //        //add separator
            //        sb.Append(dg_class.Rows[i].Cells[k].Text + ',');
            //    }
            //    //append new line
            //    sb.Append("\r\n");
            //}
            //Response.Output.Write(sb.ToString());
            //Response.Flush();
            //Response.End();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void dg_class_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_class.Rows.Count > 0)
            {
                dg_class.UseAccessibleHeader = false;
                dg_class.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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

            //ddl_center.Items.Clear();
            //ddl_center.Items.Add(new ListItem("Select", "0"));

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

            //ddl_region.Items.Clear();
            //ddl_region.Items.Add(new ListItem("Select", "0"));

            //ddl_center.Items.Clear();
            //ddl_center.Items.Add(new ListItem("Select", "0"));

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

    protected void bindTermGroupList()
    {
        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, listTermGroup, "TermGroup_Id", "Type");
            BindCheckBoxListControl(dt, lstTerm, "TermGroup_Id", "Type");
            //ddlTerm.SelectedIndex = 1;
            //}

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

    protected void FillSubject()
    {
        try
        {
               
           
            DataColumn dc = new DataColumn("Subject_ID");
            DataTable dt = new DataTable();
            dt.Columns.Add(dc);
            dc = new DataColumn("Name");
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            DataRow dr1 = dt.NewRow();
            DataRow dr2 = dt.NewRow();
            dr[0] = "11";
            dr[1] = "English";
            dr1[0] = "13";
            dr1[1] = "Maths";
            dr2[0] = "14";
            dr2[1] = "Science";
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);

            BindCheckBoxListControl(dt, lstSubject, "Subject_Id", "Name");


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
            //LoadClassSection();
            //bindTermList();
            ////////// Comment on 22 Feb 2016 without class filter 
            //////////////////RetrieveAllSubjects();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

}
