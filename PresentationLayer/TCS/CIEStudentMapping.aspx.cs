using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Collections;

public partial class PresentationLayer_TCS_CIEStudentMapping : System.Web.UI.Page
{
    
    DALBase objbase = new DALBase();
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (Session["ContactID"] == null)
    //        {
    //            Response.Redirect("~/login.aspx", false);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //    if (!IsPostBack)
    //    {

    //        //======== Page Access Settings ========================
    //        DALBase objbase = new DALBase();
    //        DataRow row = (DataRow)Session["rightsRow"];
    //        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
    //        string sRet = oInfo.Name;


    //        DataTable _dtSettings = objbase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
    //        this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
    //        //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
    //        if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
    //        {
    //            Session.Abandon();
    //            Response.Redirect("~/login.aspx", false);
    //        }
    //        bindGVDetail();
    //        trSave.Visible = false;

    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            DALBase objbase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];

            if (!IsPostBack)
            {
                loadOrg(sender, e);
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }

                FillActiveSessions();

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
                // PageInformation();


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
                objbase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
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

            objbase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");

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

            objbase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
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
            dt = objCen.CenterFetchByRegionID_CIE(objCen); 
            objbase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

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
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddl_center.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                BLLCIE_Student_Mapping objcie = new BLLCIE_Student_Mapping();
                objcie.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                dt = objcie.CIE_CenterMappingSelectByCenter_Id(objcie);
                if (dt.Rows.Count > 0)
                {
                    txtPKNo.Text = dt.Rows[0]["PK_Id"].ToString();
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
            dt = objBll.SessionSelectAllActive();
            objbase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedValue = Session["Session_Id"].ToString();


            ddlSession.Items.Remove(ddlSession.Items.FindByText("AY 2014 - 2015"));
            ddlSession.Items.Remove(ddlSession.Items.FindByText("AY 2015 - 2016"));

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void bindGV()
    {
        //if (txtRollNo.Text != "")
        //{
        //    gvAttnType.DataSource = null;
        //    gvAttnType.DataBind();
        //    BLLCIE_Student_Mapping bll = new BLLCIE_Student_Mapping();
        //    DataRow userrow = (DataRow)Session["rightsRow"];
        //    DataTable dt = new DataTable();

        //    bll.Student_Id = Int32.Parse(txtRollNo.Text);
        //    bll.Center_Id = Convert.ToInt32(Session["cId"].ToString());
        //    dt = bll.CIE_StudentMappingSelectByStudent_Id(bll);
        //    if (dt.Rows.Count > 0)
        //    {
        //        ViewState["LoadData"] = dt;
        //        gvAttnType.DataSource = dt;
        //        gvAttnType.DataBind();
        //        lblNoData.Visible = false;
        //        lblNoData.Text = "";
        //        trSave.Visible = true;

        //    }
        //    else
        //    {
        //        ImpromptuHelper.ShowPrompt("Student Not Found!");
        //        lblNoData.Visible = true;
        //        lblNoData.Text = "No Data Found";
        //    }
        //}
        //else
        //{
        //    ImpromptuHelper.ShowPrompt("Please enter Student No!");
        //    txtRollNo.Focus();

        //}
    }

    protected void bindGVDetail()
    {
        gvAttnTypedt.DataSource = null;
        gvAttnTypedt.DataBind();

        BLLCIE_Student_Mapping bll = new BLLCIE_Student_Mapping();

        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dtn = new DataTable();


        bll.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
        bll.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        bll.Glevel = ddlGradeLevel.SelectedItem.Text;

        dtn = bll.CIE_Student_MappingUploadedDataSelectByCenter_Id(bll);
        if (dtn.Rows.Count > 0)
        {
            ViewState["LoadData"] = dtn;
            gvAttnTypedt.DataSource = dtn;
            gvAttnTypedt.DataBind();

        }
        else
        {
            lblNoDatadt.Visible = true;
            lblNoDatadt.Text = "No Data Found";
        }
    }



    protected void gvAttnTypedt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            TextBox txt_Student_Id;
            Label lblClass;
            Label lblMapCenter;
            Label lblName;
            Label lblGrade_Id;
            DropDownList ddlRegis;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txt_Student_Id = (TextBox)e.Row.FindControl("txt_Student_Id");

                lblName = (Label)e.Row.FindControl("lblStudentName");
                lblMapCenter = (Label)e.Row.FindControl("lblCampus");
                lblClass = (Label)e.Row.FindControl("lblclass");
                lblGrade_Id=(Label)e.Row.FindControl("lblGrade_Id");
                ddlRegis = (DropDownList)e.Row.FindControl("ddlRegis");


                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                if (e.Row.Cells[9].Text != "&nbsp;")
                {
                    txt_Student_Id.Text=(e.Row.Cells[9].Text);

                        lblName.Text=(e.Row.Cells[11].Text);
                        lblMapCenter.Text=(e.Row.Cells[12].Text);
                        lblClass.Text = (e.Row.Cells[13].Text);
                        lblGrade_Id.Text = (e.Row.Cells[14].Text);
                        ddlRegis .SelectedValue= (e.Row.Cells[16].Text);
                    
                }
                ddlRegis.SelectedValue = (e.Row.Cells[16].Text);



            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ResetControls()
    {
        trCDT.Visible = false;

        btns.Visible = false;
        btnGen.Visible = false;


    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (txtRollNo.Text != "")
        //    {
        //        bindGV();
        //    }
        //    else
        //    {
        //        ImpromptuHelper.ShowPrompt("Please enter Student No!");
        //        txtRollNo.Focus();

        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

        ResetControls();
    }


    protected void gvAttnTypedt_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvAttnTypedt.Rows.Count > 0)
            {
                gvAttnTypedt.UseAccessibleHeader = false;
                gvAttnTypedt.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            BLLCIE_Student_Mapping objClsSec = new BLLCIE_Student_Mapping();
            int AlreadyIn = 0;

            ImageButton btn = (ImageButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;


            ViewState["ReferenceId"] = ReferenceIdValue;

            objClsSec.CIE_Can_Id = Convert.ToInt32(ReferenceIdValue);


            AlreadyIn = objClsSec.CIE_Student_MappingDelete(objClsSec);


            ViewState["dtDetails"] = null;

            ImpromptuHelper.ShowPrompt("Delete Record successfully");
            ViewState["dtDetails"] = null;

            ResetControls();
            bindGVDetail();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }



    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        bindGV();
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        BLLCIE_Student_Mapping objClsSec = new BLLCIE_Student_Mapping();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Add";

        int AlreadyIn = 0;
        bool issave = false;
        DataTable dt = new DataTable();

        dt = ConvertGridViewtoDataTable();

        bool chk = HasDuplicateRows(dt, "Student_Id");

        if (chk == false)
        {
            foreach (GridViewRow gvr in gvAttnTypedt.Rows)
            {
                TextBox txtStudent_Id = (TextBox)gvr.Cells[4].FindControl("txt_Student_Id");
                Label LblStudentName = (Label)gvr.Cells[5].FindControl("lblStudentName");
                Label LblGrade_Id = (Label)gvr.Cells[8].FindControl("lblGrade_Id");
                DropDownList ddlRegis = (DropDownList)gvr.Cells[15].FindControl("ddlRegis");


                if (txtStudent_Id.Text.Length > 0 && ddlRegis.SelectedIndex>0)
                {


                    objClsSec.CIE_Can_Id = Convert.ToInt32(gvr.Cells[0].Text);
                    objClsSec.Student_Id = Convert.ToInt32(txtStudent_Id.Text);
                    objClsSec.StudentName = LblStudentName.Text;
                    objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                    objClsSec.Class_Id = Convert.ToInt32(LblGrade_Id.Text);
                    objClsSec.Section_Id = 0;
                    objClsSec.RegisteredAs = Convert.ToInt16(ddlRegis.SelectedValue);
                    AlreadyIn = objClsSec.CIE_Student_MappingAdd(objClsSec);
                    issave = true;
                }

            }
            if (issave == true)
            {
                ImpromptuHelper.ShowPrompt("Records having valid Student ERP No. and Regisration Status are saved.");
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Failed to upload. There are duplicate Student No.s exists");
        }

    }
    protected void ddlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGVDetail();
    }
    protected void TextBox_TextChanged(object sender, EventArgs e)
    {

            try
            {
                TextBox txtStudent_Id = (TextBox)sender;
                GridViewRow gvr = ((GridViewRow)txtStudent_Id.Parent.Parent);
                LoadStudentDetail(gvr,txtStudent_Id);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }

    }
    protected void LoadStudentDetail(GridViewRow gvr,TextBox txtStudent_Id)
    {
        try
        {

            Label lblStdName = (Label)gvr.Cells[4].FindControl("lblStudentName");
            Label lblStdCamp = (Label)gvr.Cells[5].FindControl("lblCampus");
            Label lblStdClass = (Label)gvr.Cells[6].FindControl("lblclass");
            Label lblGrade_Id = (Label)gvr.Cells[7].FindControl("lblGrade_Id"); 
            Label lblCenter_Id = (Label)gvr.Cells[9].FindControl("lblCenter_Id");
            
            
            
            if (txtStudent_Id.Text.Length > 0)
            {


                BLLStudent objBll = new BLLStudent();
                DataTable dt = new DataTable();
                objBll.Student_Id = Convert.ToInt32(txtStudent_Id.Text);

                dt = objBll.StudentSelectByStudentID(objBll);


                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    lblStdCamp.Text = dr["Center_Name"].ToString();
                    lblStdClass.Text = dr["Class_Name"].ToString();
                    lblStdName.Text = dr["First_Name"].ToString();
                    lblGrade_Id.Text = dr["Grade_Id"].ToString();
                    lblCenter_Id.Text = dr["Center_Id"].ToString();

                }
                else
                {
                    lblStdCamp.Text = "";
                    lblStdClass.Text = "";
                    lblStdName.Text = "";
                    lblGrade_Id.Text = "";
                    lblCenter_Id.Text = "";

                    ImpromptuHelper.ShowPrompt("No Student Record found!");

                }
            }
            else
            {
                lblStdCamp.Text = "";
                lblStdClass.Text = "";
                lblStdName.Text = "";
                lblGrade_Id.Text = "";
                lblCenter_Id.Text = "";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    public DataTable ConvertGridViewtoDataTable()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("Student_Id", typeof(int)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));


        foreach (GridViewRow gvr in gvAttnTypedt.Rows)
        {

            TextBox txb=(TextBox)gvr.FindControl("txt_Student_Id");
            Label lbl = (Label)gvr.FindControl("lblStudentName");

            if (txb.Text!="")
            {
                dt.NewRow();
                dt.Rows.Add(Convert.ToInt32(txb.Text), lbl.Text);
            }
            
        }

        return dt;
    }





    public bool HasDuplicateRows(DataTable dTable, string colName)
    {
        bool verify = false;

        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Check duplicate items in datatable.

        if (duplicateList.Count>0)
        {
            verify = true;
        }

        return verify;
    }
}
