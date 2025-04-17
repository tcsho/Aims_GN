using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PresentationLayer_TCS_CIEStudentMapping_AllInOne : System.Web.UI.Page
{

    DALBase objbase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        showerror.InnerText = "";
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            DALBase objbase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];
            //highAch.Visible = false;
            if (!IsPostBack)
            {
                loadOrg(sender, e);
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }

                FillActiveSessions();
                loadResultMonth();

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country.Enabled = true;
                    highAch.Visible = true;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country.Enabled = false;
                    highAch.Visible = false;


                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country.Enabled = false;
                    highAch.Visible = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country.Enabled = false;
                    highAch.Visible = false;

                }
                // PageInformation();
                //2023-8-Aug
                bindGVDetail();
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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    //private void loadClassLevel()
    //{

    //    try
    //    {
    //        BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

    //        objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
    //        objCen.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue.ToString());


    //        DataTable dt = new DataTable();
    //        dt = objCen.CIE_ClassLevelSelect(objCen);
    //        objbase.FillDropDown(dt, ddlGradeLevel, "GLevel", "GLevel");

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    private void loadResultMonth()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            objbase.FillDropDown(dt, ddlResultMonth, "ResultSeries_Id", "ResultSeries");

            //if (DateTime.Now.Month > 9)
            //{
            //    ddlResultMonth.SelectedIndex = 2;
            //   // loadClassLevel();
            //}
            //else
            //{
            //    ddlResultMonth.SelectedIndex = 1;
            //   // loadClassLevel();
            //}


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

    protected void bindGVDetail()
    {
        //if (ddlSession.SelectedIndex > 0 && ddlResultMonth.SelectedIndex > 0 && ddlGradeLevel.SelectedIndex > 0)
        if (ddlSession.SelectedIndex > 0 && ddlResultMonth.SelectedIndex > 0)
        {



            gvAttnTypedt.DataSource = null;
            gvAttnTypedt.DataBind();

            BLLCIE_Student_Mapping bll = new BLLCIE_Student_Mapping();

            DataRow userrow = (DataRow)Session["rightsRow"];
            DataTable dtn = new DataTable();

            bll.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            //bll.Glevel = ddlGradeLevel.SelectedItem.Text;
            bll.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);


            if (Convert.ToInt32(userrow["UserLevel_ID"].ToString()) == 4) //Campus Officer
            {
                bll.Center_Id = Convert.ToInt32(Session["CId"].ToString());
            }
            else
            {
                bll.Center_Id = 0;
            }

            dtn = bll.CIE_Student_MappingSelectBySession_Id(bll);



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
                lblGrade_Id = (Label)e.Row.FindControl("lblGrade_Id");
                ddlRegis = (DropDownList)e.Row.FindControl("ddlRegis");


                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                if (e.Row.Cells[10].Text != "&nbsp;")
                {
                    txt_Student_Id.Text = (e.Row.Cells[10].Text);

                    lblName.Text = (e.Row.Cells[12].Text) + " ---  " + (e.Row.Cells[13].Text) + " ---  " + (e.Row.Cells[14].Text);
                    lblGrade_Id.Text = (e.Row.Cells[15].Text);
                    ddlRegis.SelectedValue = (e.Row.Cells[17].Text);

                }
                ddlRegis.SelectedValue = (e.Row.Cells[17].Text);



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

    protected void btnCompile_Click(object sender, EventArgs e)
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();

        DataTable dtstatus = new DataTable();
        DataTable dt = new DataTable();

        dt = ConvertGridViewtoDataTable();

        objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        //2023-Aug-8 hasan
        objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);

        dtstatus = objStd.CIE_Check_status_For_Compilation(objStd);
        if (dtstatus.Rows.Count > 0)
        {
            int ProcessStatus = objStd.CIE_FileHighAchieversProcess(objStd);

            if (ProcessStatus == 1)
            {
                ImpromptuHelper.ShowPrompt("High Achievers Student List Generated Successfully");
                showerror.InnerText = "";
            }
            else if (ProcessStatus == 2)
            {
                ImpromptuHelper.ShowPrompt("List of High Achievers can not be regenerated as records are locked");
                showerror.InnerText = "";
            }
            else if (ProcessStatus == 3)
            {
                ImpromptuHelper.ShowPrompt("There are few unmapped students, Complete the Mapping Process first");
                showerror.InnerText = "";
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Failed to generate High Achievers Student List!");
                showerror.InnerText = "";
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("You Can't Proceed this process due to Unavailability of Data");
            showerror.InnerText = "You Can't Proceed this process due to Unavailability of Data";
        }





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
                DropDownList ddlRegis = (DropDownList)gvr.Cells[15].FindControl("ddlRegis");


                if (txtStudent_Id.Text.Length > 0 && ddlRegis.SelectedIndex > 0)
                {


                    objClsSec.CIE_Can_Id = Convert.ToInt32(gvr.Cells[0].Text);
                    objClsSec.Student_Id = Convert.ToInt32(txtStudent_Id.Text);
                    objClsSec.RegisteredAs = Convert.ToInt16(ddlRegis.SelectedValue);
                    AlreadyIn = objClsSec.CIE_Student_MappingAddAllInOne(objClsSec);
                    issave = true;
                }

            }
            if (issave == true)
            {
                ImpromptuHelper.ShowPrompt("Records having valid Student ERP No. and Regisration Status are saved.");
                bindGVDetail();
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Failed to upload. There are duplicate Student No.s exists");
        }

    }
    //protected void ddlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bindGVDetail();
    //}
    protected void TextBox_TextChanged(object sender, EventArgs e)
    {

        try
        {
            TextBox txtStudent_Id = (TextBox)sender;
            GridViewRow gvr = ((GridViewRow)txtStudent_Id.Parent.Parent);
            LoadStudentDetail(gvr, txtStudent_Id);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void LoadStudentDetail(GridViewRow gvr, TextBox txtStudent_Id)
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
                    lblStdName.Text = dr["Center_Name"].ToString() + " --- " + dr["Class_Name"].ToString() + " --- " + dr["First_Name"].ToString();
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

            TextBox txb = (TextBox)gvr.FindControl("txt_Student_Id");
            Label lbl = (Label)gvr.FindControl("lblStudentName");

            if (txb.Text != "")
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

        if (duplicateList.Count > 0)
        {
            verify = true;
        }

        return verify;
    }


    protected void ddlResultMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loadClassLevel();
        bindGVDetail();
    }
}
