using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_Announcements : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
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
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================



            FillWorkSiteForAnnouncements();


            //////bindddlYears();
            //////ddlYears.SelectedIndex = 0;
            //////bindGV(ddlYears.SelectedItem.Text);
        }
    }
    //////protected void bindddlDayType()
    //////{
    //////    ddlDayType.Items.Clear();
    //////    BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();
    //////    DataTable dt = new DataTable();
    //////    dt = bll.TCS_StdAttnCalenderDayTypeSelectAll();
    //////    objbase.FillDropDown(dt, ddlDayType, "CalDayType_Id", "CalTypeDesc");

    //////}
    protected void bindddlYears()
    {
        ddlYears.Items.Clear();
        BLLTCS_StdYears bll = new BLLTCS_StdYears();
        DataTable dt = new DataTable();

        dt = bll.TCS_StdYearsSelectAll();
        objbase.FillDropDown(dt, ddlYears, "id", "Year");

    }


    private void FillWorkSiteForAnnouncements()
    {



        try
        {

            BLLSection_Subject objCS = new BLLSection_Subject();

            ////////////objCS.Center_Id = Convert.ToInt32(Session["CId"]);
            objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement(objCS);


            objBase.FillDropDown(_dt, ddlYears, "Section_Subject_Id", "Title");

           

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }




    private void BindGrid()
    {
        BLLLmsAnnouncements objClsSec = new BLLLmsAnnouncements();

        BLLSection_Subject objsect = new BLLSection_Subject();


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();

        objClsSec.Section_Subject_Id = Int32.Parse(ddlYears.SelectedValue);
        ///////

        objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        objsect.Section_Subject_Id = Convert.ToInt32(ddlYears.SelectedValue.ToString());



        dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(objsect);


        objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());


       

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsAnnouncementSelectAllBySectionSubjectIdWrkToolId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvAttnType.DataSource = dtsub;
        }
        gvAttnType.DataBind();
        ViewState["tMood"] = "check";
        ////////trSave.Visible = true;
    }



   

   
    
    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {



            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLLmsAnnouncements objClsSec = new BLLLmsAnnouncements();

            BLLSection_Subject objsect = new BLLSection_Subject();


            DataTable dtsub = new DataTable();
            DataTable dtwrk = new DataTable();

            objClsSec.Section_Subject_Id = Int32.Parse(ddlYears.SelectedValue);
            ///////

            objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            objsect.Section_Subject_Id = Convert.ToInt32(ddlYears.SelectedValue.ToString());



            dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(objsect);


            objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());




            /////
            ////////objClsSec.WrkTool_ID = Int32.Parse(ddlYears.SelectedValue);
            objClsSec.AncmtTitle = txtTitle.Text.ToString();
            //objClsSec.AncmtBody = txtDescription.Text.ToString();
            objClsSec.AncmtBody = Editor1.Content;
            objClsSec.IsPublished = chPublised.Checked;
            objClsSec.PublishStartDate = DateTime.Parse(txtDate.Text);
            objClsSec.PublishEndDate = DateTime.Parse(txtDate2.Text);
            objClsSec.Status_Id = 1;




            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {


                
                objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.CreatedOn = DateTime.Now;


                AlreadyIn = objClsSec.LmsAnnouncementsAdd(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                    ResetControls();
                    ////////pan_New.Attributes.CssStyle.Add("display", "none");
                    BindGrid();

                }


            }

            else
            {



                objClsSec.Announcement_ID = Convert.ToInt32(ViewState["ResultGrade"]);
                objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.ModifiedOn = DateTime.Now;

                AlreadyIn = objClsSec.LmsAnnouncementsUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    ResetControls();
                    ////////pan_New.Attributes.CssStyle.Add("display", "none");
                   BindGrid();

                }


            }


        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }


    }

    //////////protected void GenerateCalander()
    //////////{
    //////////    BLLTCS_StdAttnCalender obj = new BLLTCS_StdAttnCalender();
    //////////    DataRow userrow = (DataRow)Session["rightsRow"];

    //////////    obj.Main_Organisation_Id = Convert.ToInt32(userrow["Main_Organisation_Id"].ToString());
    //////////    obj.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
    //////////    obj.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
    //////////    obj.Year = ddlYears.SelectedItem.Text;

    //////////    obj.TCS_StdAttnCalenderInsert(obj);
    //////////}

    protected void ResetControls()
    {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
        ////txtDescription.Text = "";
        btns.Visible = false;
        btnGen.Visible = false;
        trDate.Visible = false;
        //trOpt.Visible = false;
        txtDate.Text = "";
        txtDate2.Text = "";
        txtTitle.Text = "";
        trDayType.Visible = false;
        TrDate2.Visible = false;
        trchkbox.Visible = false;
        chPublised.Checked = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        ResetControls();
    }

    protected void btnCompose_Click(object sender, EventArgs e)
    {
        //if (ddlYears.SelectedIndex > 0)
        //{
            trCDT.Visible = true;
            trCDTEnt.Visible = true;
            trDayType.Visible = true;
            btns.Visible = true;
            btnGen.Visible = true;
            trDate.Visible = true;
            TrDate2.Visible = true;
            trchkbox.Visible = true;
            //trOpt.Visible = true;
            txtDate.Text = "";
            ////txtDescription.Text = "";
            ////btnSave.Text = "Save";
            //////ViewState["Mode"] = "add";

            ViewState["mode"] = "Add";


            //bindddlDayType();
        ////}
        ////else
        ////{
        ////    ImpromptuHelper.ShowPrompt("Please select an year.");
        ////}
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        BLLLmsAnnouncements objClsSec = new BLLLmsAnnouncements();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;




        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        trDayType.Visible = true;
        btns.Visible = true;
        trDate.Visible = true;
        TrDate2.Visible = true;
        trchkbox.Visible = true;
        chPublised.Visible = true;
        //trOpt.Visible = true;

        /////////////////////////
        ViewState["ResultGrade"] = ResultGradeValue;



        objClsSec.Announcement_ID = Convert.ToInt32(ResultGradeValue);


        dtsub = (DataTable)objClsSec.LmsAnnouncementSelectAllByAnnouncementId(objClsSec);

        txtTitle.Text = dtsub.Rows[0]["AncmtTitle"].ToString().Trim();
        ////////txtDescription.Text = dtsub.Rows[0]["AncmtBody"].ToString().Trim();
       Editor1.Content = dtsub.Rows[0]["AncmtBody"].ToString().Trim();

        txtDate.Text = dtsub.Rows[0]["PublishStartDate"].ToString().Trim();
        txtDate2.Text = dtsub.Rows[0]["PublishEndDate"].ToString().Trim();

        if (dtsub.Rows[0]["IsPublished"].ToString().Trim() == "YES")
        {
            chPublised.Checked = true;
        }
        else
        {
            chPublised.Checked = false;
        }

        ////////chPublised.Checked = dtsub.Rows[0]["IsPublished"].ToString().Trim();
       




        /////////////////////////////////////////////////
        //////////////////////////ViewState["Mode"] = "Edit";
        //////////////////////////ViewState["Call_ID"] = Call_ID;
        //////////////////////////btnSave.Text = "Update Year Calender";
        //////////////////////////txtDate.Enabled = false;
        //////////////////////////GridViewRow gvr;
        //////////////////////////gvr = (GridViewRow)imgbtn.NamingContainer;
        //////////////////////////gvAttnType.SelectedIndex = gvr.RowIndex;
        ////////////////////////////////loadFrm(Call_ID);


        //////////////////////////pan_New.Attributes.CssStyle.Add("display", "inline");
       

        //////////////////////////Result_GradeIdGe = ResultGradeValue;

        





    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        BLLLmsAnnouncements objClsSec = new BLLLmsAnnouncements();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;


        ViewState["ResultGrade"] = ResultGradeValue;

        objClsSec.Announcement_ID = Convert.ToInt32(ResultGradeValue);


        AlreadyIn = objClsSec.LmsAnnouncementsDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        ResetControls();
        BindGrid();

       
    }
    //protected void loadFrm(int Call_ID)
    //{
    //    BLLTCS_StdAttnCalenderHolidays bll = new BLLTCS_StdAttnCalenderHolidays();
    //    DataTable dt = new DataTable();

    //    bll.Call_ID = Call_ID;
    //    dt = bll.TCS_StdAttnCalenderHolidaysSelectByCall_ID(bll);
    //    if (dt.Rows.Count > 0)
    //    {
    //        ViewState["LoadData"] = dt;
    //        txtDate.Text = dt.Rows[0]["CallDate"].ToString();
    //        txtDescription.Text = dt.Rows[0]["Remarks"].ToString();
    //        //////bindddlDayType();
    //        //////ddlDayType.SelectedValue = dt.Rows[0]["CalDayType_Id"].ToString();
    //    }
    //}

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnType.PageIndex = e.NewPageIndex;
        gvAttnType.DataSource = ViewState["LoadData"];
        gvAttnType.DataBind();
    }

    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    ////protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    if (rblType.SelectedValue == "0")
    ////    {
    ////        TrDate2.Visible = false;
    ////    }
    ////    else if (rblType.SelectedValue == "1")
    ////    {
    ////        TrDate2.Visible = true;
    ////    }
    ////}
}
