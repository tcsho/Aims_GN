using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;




public partial class PresentationLayer_TCS_ScheduleTestAttendance : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

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
                Response.Redirect("~/login.aspx",false);
            }
            Session["AddCriteria"] = null;

            //====== End Page Access settings ======================


            //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];            

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {


    }

    protected void ResetControls()
    {
        try
        {
        lblStudentNo.Text = "";
        lblName.Text = "";
        lblDOB.Text = "";
        lblPhone.Text = "";

        lblGender.Text = "";
        lblClass.Text = "";
        lblSection.Text = "";
        lblsectionid.Text = "";

        lblRegion.Text = "";
        lblCenter.Text = "";

        if (lblsectionid.Text != "")
        {
            BindTerm();
        }
        lblsectionid.Visible = false;


        gvShowAck.DataSource = null;
        gvShowAck.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnSearchStudent_Click(object sender, EventArgs e)
    {
        try
        {
        ResetControls();
        LoadStudent();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void LoadStudent()
    {
        try
        {
        BLLStudent_Evaluation_Criteria_Detail objBllRes = new BLLStudent_Evaluation_Criteria_Detail();
        DataTable dt = new DataTable();
        DataRow row = (DataRow)Session["rightsRow"];

        objBllRes.Student_Id = Convert.ToInt32(txtStudentNo.Text);
        objBllRes.Session_Id =Convert.ToInt32(Session["Session_Id"].ToString());
        /////////////// Change rights center to teacher login
        //////////objBllRes.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());

        objBllRes.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                     
        dt = objBllRes.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfo(objBllRes);

        if (dt.Rows.Count > 0)
        {

            lblStudentNo.Text = dt.Rows[0]["Student_No"].ToString().Trim();
            lblName.Text = dt.Rows[0]["First_Name"].ToString().Trim();
            lblDOB.Text = dt.Rows[0]["Date_Of_Birth"].ToString().Trim();
            lblPhone.Text = dt.Rows[0]["Telephone_No"].ToString().Trim();

            lblGender.Text = dt.Rows[0]["Gender"].ToString().Trim();
            lblClass.Text = dt.Rows[0]["Class_Name"].ToString().Trim();
            lblSection.Text = dt.Rows[0]["Section_Name"].ToString().Trim();
            lblsectionid.Text = dt.Rows[0]["Section_Id"].ToString().Trim();

            lblRegion.Text = dt.Rows[0]["Region_Name"].ToString().Trim();
            lblCenter.Text = dt.Rows[0]["Center_Name"].ToString().Trim();
            if (lblsectionid.Text != "")
            {
                BindTerm();
            }
            lblsectionid.Visible = false;
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Student Not Found.");    
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindTerm()
    {

        try

        {
            BLLSection_Subject obj = new BLLSection_Subject();

            obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
            obj.Section_Id = Convert.ToInt32(lblsectionid.Text);

            DataTable dt = obj.Evaluation_Criteria_TypeBySectionId(obj);

            objBase.FillDropDown(dt, list_Term, "Id", "Type");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

      

    }



    protected void lnkAddCal_Click(object sender, EventArgs e)
    {

        try
        {
            int AlreadyIn = 0;
            int chktvalue = 0;
            BLLStudent_Evaluation_Criteria_Detail objClsSec = new BLLStudent_Evaluation_Criteria_Detail();

            

                CheckBox cb = null;
                foreach (GridViewRow gvr in gvShowAck.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("chkRating");

                    if (cb.Checked)
                    {


                        chktvalue = 88;

                        objClsSec.SSEC_Id = Convert.ToInt32(gvr.Cells[0].Text.ToString());
                        objClsSec.Student_Section_Subject_Id = Convert.ToInt32(gvr.Cells[1].Text.ToString());

                        objClsSec.Marks_Obtained = 0;
                        objClsSec.Lock_Mark = true;
                        objClsSec.isAbsent = true;


                        AlreadyIn = objClsSec.Student_Evaluation_Criteria_DetailIsAbsentUpdate(objClsSec);

                    }
                    else
                    {


                        if (chktvalue != 88)
                        {

                            chktvalue = 77;

                        }


                    }
                }


                int ActChkTvalue = chktvalue;
                if (ActChkTvalue != 77)
                {



                    if (AlreadyIn == 0)
                    {
                        ViewState["dtDetails"] = null;
                        ImpromptuHelper.ShowPrompt("Student is Marked as Absent for this Schedule Test.");

                       
                        BindGrid();

                    }
                    else
                    {
                        ImpromptuHelper.ShowPrompt("Record Alraedy Exist.");
                    }
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please Select Desired Student Attendance!");
                }
            

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void btnAbsent_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int AlreadyIn = 0;

            BLLStudent_Evaluation_Criteria_Detail objClsSec = new BLLStudent_Evaluation_Criteria_Detail();

            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            ImageButton btn = (ImageButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;

            ViewState["ReferenceId"] = ReferenceIdValue;



            DataRow row = (DataRow)Session["rightsRow"];

            objClsSec.Student_Id = Convert.ToInt32(txtStudentNo.Text);
            objClsSec.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());


            objClsSec.SSEC_Id = Convert.ToInt32(ReferenceIdValue);


            dtsub = (DataTable)objClsSec.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID(objClsSec);


            objClsSec.SSEC_Id = Convert.ToInt32(ReferenceIdValue);
            objClsSec.Student_Section_Subject_Id = Convert.ToInt32(dtsub.Rows[0]["Student_Section_Subject_Id"].ToString().Trim());

            objClsSec.Marks_Obtained = 0;
            objClsSec.Lock_Mark = true;
            objClsSec.isAbsent = true;

            AlreadyIn = objClsSec.Student_Evaluation_Criteria_DetailIsAbsentUpdate(objClsSec);


            if (AlreadyIn == 0)
            {
                ViewState["dtDetails"] = null;
                ImpromptuHelper.ShowPrompt("Student is Marked as Absent for this Schedule Test.");
                BindGrid();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        int AlreadyIn = 0;

        BLLStudent_Evaluation_Criteria_Detail objClsSec = new BLLStudent_Evaluation_Criteria_Detail();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;

        ViewState["ReferenceId"] = ReferenceIdValue;


       
        DataRow row = (DataRow)Session["rightsRow"];

        objClsSec.Student_Id = Convert.ToInt32(txtStudentNo.Text);
        objClsSec.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
        /////// to change center to teacher login
        //////objClsSec.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());

        objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());


        objClsSec.SSEC_Id = Convert.ToInt32(ReferenceIdValue);
        

        dtsub = (DataTable)objClsSec.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID(objClsSec);


        objClsSec.SSEC_Id = Convert.ToInt32(ReferenceIdValue);
        objClsSec.Student_Section_Subject_Id = Convert.ToInt32(dtsub.Rows[0]["Student_Section_Subject_Id"].ToString().Trim());

        objClsSec.Marks_Obtained = 0;
        objClsSec.Lock_Mark = true;
        objClsSec.isAbsent = false;

        AlreadyIn = objClsSec.Student_Evaluation_Criteria_DetailIsAbsentUpdate(objClsSec);


        if (AlreadyIn == 0)
        {
            ViewState["dtDetails"] = null;
            ImpromptuHelper.ShowPrompt("Student is Marked as Present for this Schedule Test.");
            BindGrid();

        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }
    private void BindGrid()
    {

        try
        {

        BLLStudent_Evaluation_Criteria_Detail objClsSec = new BLLStudent_Evaluation_Criteria_Detail();

        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();


        objClsSec.Student_Id = Convert.ToInt32(txtStudentNo.Text);
        objClsSec.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
        objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue);
        objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Student_Evaluation_Criteria_Detail_ScheduleTestAttendance(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvShowAck.DataSource = dtsub;
            gvShowAck.DataBind();
            ViewState["tMood"] = "check";
        }
        else
        {
            gvShowAck.DataSource = null;
            gvShowAck.DataBind();
        }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        

    }

    protected void gvShowAck_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "toggleCheck")
            {


                foreach (GridViewRow row in gvShowAck.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chkRating");
                    if (cb != null && cb.Checked == false)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("ErrorPage.aspx", false);
        }
    }
    protected void gvShowAck_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

}
