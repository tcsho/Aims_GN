using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Globalization;



public partial class PresentationLayer_TCS_LmsSchEventView : System.Web.UI.Page
{
    
    DALBase objBase = new DALBase();

    DateTime _Eventdate = System.DateTime.Now;


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
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (!IsPostBack)
        {
            try
            {

            //======== Page Access Settings ========================
            ////////////////////////////DALBase objBase = new DALBase();
            ////////////////////////////DataRow row = (DataRow)Session["rightsRow"];
            ////////////////////////////string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            ////////////////////////////System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            ////////////////////////////string sRet = oInfo.Name;


            ////////////////////////////DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            ////////////////////////////Session["User_Type_Id"]= Convert.ToInt32(row["User_Type_Id"].ToString());
            ////////////////////////////this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            //////////////////////////////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            ////////////////////////////if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            ////////////////////////////{
            ////////////////////////////    Session.Abandon();
            ////////////////////////////    Response.Redirect("~/login.aspx",false);
            ////////////////////////////}

            //====== End Page Access settings ======================

            FillEventTypeDropDown();

            FillFrequencyEventDropDown();

            BindGrid();

            // Comment For New Structure
            //FillWorkSiteForAnnouncements();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


            
        }
    }
    


   


    private void FillEventTypeDropDown()
    {
        try
        {

        BLLLmsSchEventType obj = new BLLLmsSchEventType();

        ////////obj.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());

        //int CenterId = Convert.ToInt32(Session["cId"].ToString());
        DataTable dt = (DataTable)obj.LmsSchEventTypeFetch(obj);

        objBase.FillDropDown(dt, list_EventType, "EventType_ID", "EventType");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void FillFrequencyEventDropDown()
    {



        try
        {

            BLLLmsSchFrequencyType objCS = new BLLLmsSchFrequencyType();


            ////////////objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.LmsSchFrequencyTypeFetch(objCS);


            objBase.FillDropDown(_dt, list_Frqtype, "Frequency_ID", "FrequencyType");



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
        BLLLmsSchEvent objClsSec = new BLLLmsSchEvent();

        BLLSection_Subject objsect = new BLLSection_Subject();


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();

        // Comment For New Structure

        //if (ddlWorkSite.SelectedIndex > 0)
        //{

            //////////////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
            /////////////////////

            //////////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            //////////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



            //////////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(objsect);


            //////////////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());

        //////////////int aaaa = Convert.ToInt32(Session["User_Type_Id"].ToString());

            lblWorksitename.Text = Session["WorkSiteName"].ToString();

            objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
            objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());


            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.LmsSchEventSelectAllBySectionSubjectIdWrkToolId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                gvDetail.DataSource = dtsub;
                gvDetail.DataBind();
                ViewState["tMood"] = "check";
            }
            else
            {
                gvDetail.DataSource = null;
                gvDetail.DataBind();
            }
         
        

        // Comment For New Structure

        //////}
        //////else
        //////{
        //////    gvDetail.DataSource = null;
        //////    gvDetail.DataBind();
        //////}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void SaveNewEvent()
    {
        int freqGap = 1;
        int occurances = 1;//0;
        int lastEvtGrpID = 0;

        // Save LmsSch

        int ScheduleID = 0;

        int AlreadyIn = 0;



        BLLLmsSch objClsSec = new BLLLmsSch();
        DataTable dt = new DataTable();


        objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
        objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());


        dt = (DataTable)objClsSec.LmsSchSelectAllBySectionSubjectIdWrkToolId(objClsSec);
        if (dt.Rows.Count == 0)
        {


            ScheduleID = objClsSec.LmsSchAdd(objClsSec);
        }
        else
        {
            ScheduleID = Convert.ToInt32(dt.Rows[0]["Schedule_ID"].ToString().Trim());
        }


        // ok ////////// ok 

        //

        if (list_Frqtype.SelectedValue != "1")
        {
            freqGap = Convert.ToInt32(txtEvery.Text);
            occurances = Convert.ToInt32(txtAfter.Text);
        }
        string eventDate, format;
        CultureInfo provider = CultureInfo.InvariantCulture;

        eventDate = txtDate.Text;

        format = "M/d/yyyy";

        _Eventdate = DateTime.ParseExact(eventDate, format, provider);


        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "M/d/yy";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "MM/dd/yy";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "MM/dd/yyyy";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "yy/MM/dd";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "yyyy-MM-dd";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}
        ////format = "dd-MMM-yy";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}

        ////format = "dd MMM yyyy";
        ////try
        ////{
        ////    _Eventdate = DateTime.ParseExact(eventDate, format, provider);
        ////}
        ////catch (FormatException)
        ////{

        ////}

       

        BLLLmsSchEvent objBll = new BLLLmsSchEvent();

       objBll.EFrequency_ID = SaveEventFrequency();

        occurances = Convert.ToInt32(ViewState["Occurances"]);
        if (occurances > 1 || freqGap > 1)
        {
            BLLLmsSchEventGroup objBllGrp = new BLLLmsSchEventGroup();
            objBllGrp.GroupTitle = txtTitle.Text;
            objBllGrp.CreatedOn = DateTime.Now;
            objBllGrp.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            lastEvtGrpID = objBllGrp.LmsSchEventGroupAdd(objBllGrp);
            objBll.EGroup_ID = lastEvtGrpID;
        }
        else
        {
            objBll.EGroup_ID = 1;   //No Group
        }

        for (int i = 0; i < occurances; i++)
        {
            if (i == 0)
            {
                objBll.EventDate = _Eventdate;
            }
            else
            {
                switch (list_Frqtype.SelectedValue)
                {
                    case "1":   //Once
                        objBll.EventDate = _Eventdate;
                        break;
                    case "2":   //Daily
                        objBll.EventDate = objBll.EventDate.AddDays(freqGap);
                        break;
                    case "3":   //weekly
                        objBll.EventDate = objBll.EventDate.AddDays(freqGap * 7);
                        break;
                    case "5":   //Monthly
                        objBll.EventDate = objBll.EventDate.AddMonths(freqGap);
                        break;
                    case "6":   //Yearly
                        objBll.EventDate = objBll.EventDate.AddYears(freqGap);
                        break;
                }
            }

            
            objBll.EventTitle = txtTitle.Text;
            objBll.StartTime = Convert.ToDateTime(txtStartTime.Text);
            objBll.EndTime = Convert.ToDateTime(txtEndTime.Text);
            objBll.Message = Editor1.Content;

            objBll.EventType_ID = Convert.ToInt32(list_EventType.SelectedValue);
            ///// already save and have value 
            //////////objBll.EFrequency_ID = SaveEventFrequency();    //Frequency
            objBll.EventLocation = txtEventLoc.Text;
           
            objBll.CreatedOn = DateTime.Now;
            objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);
            objBll.Status_Id = 1;

            objBll.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
            //////////objBll.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());



            ////////////////objBll.Section_Subject_Id = worksiteID;
            AlreadyIn = objBll.LmsSchEventAdd(objBll);//Event insertion
        }
    }

    public int SaveEventFrequency()
    {
        BLLLmsSchEventFrequency objBll = new BLLLmsSchEventFrequency();
        int freqGap = 1;
        int occurances = 1;
        DateTime eventEndDate = new DateTime();
        occurances = txtAfter.Text != "" ? Convert.ToInt32(txtAfter.Text) : 1;
        freqGap = txtEvery.Text != "" ? Convert.ToInt32(txtEvery.Text) : 1;


        // ================== No of occurances provided ===============================================
        if (txtAfter.Text == "")
        {
            
            objBll.EFreqGap = freqGap;
            objBll.EndsAfter = occurances;
            objBll.Frequency_ID = Convert.ToInt32(list_Frqtype.SelectedValue);


            switch (list_Frqtype.SelectedValue)
            {
                case "1":   //Once
                    objBll.EndDate = _Eventdate;
                    break;
                case "2":   //Daily
                    objBll.EndDate = _Eventdate.AddDays((freqGap * occurances) - freqGap);
                    break;
                case "3":   //weekly
                    objBll.EndDate = _Eventdate.AddDays(((freqGap * occurances) - freqGap) * 7);
                    break;
                case "5":   //Monthly
                    objBll.EndDate = _Eventdate.AddMonths((freqGap * occurances) - freqGap);
                    break;
                case "6":   //Yearly
                    objBll.EndDate = _Eventdate.AddYears((freqGap * occurances) - freqGap);
                    break;

            }
            //ViewState["EndDate"] = objBll.EndDate;
        }
        //================== End Date Provided ========================================================
        else if (txtAfter.Text != "")
        {
            TimeSpan objTimeSpan = new TimeSpan();
            objBll.EFreqGap = freqGap;
            eventEndDate = Convert.ToDateTime(txtOn.Text);
            objBll.EndDate = eventEndDate;
            objBll.Frequency_ID = Convert.ToInt32(list_Frqtype.SelectedValue);
            objTimeSpan = eventEndDate.Subtract(_Eventdate);

            switch (list_Frqtype.SelectedValue)
            {
                case "1":   //Once
                    occurances = 1;
                    break;
                case "2":   //Daily
                    occurances = (objTimeSpan.Days + freqGap) / freqGap;
                    break;
                case "3":   //weekly
                    occurances = ((objTimeSpan.Days / 7) + freqGap) / freqGap;
                    break;
                case "5":   //Monthly
                    occurances = ((objTimeSpan.Days / 30) + freqGap) / freqGap;
                    break;
                case "6":   //Yearly
                    occurances = ((objTimeSpan.Days / 365) + freqGap) / freqGap;
                    break;
            }
            objBll.EndsAfter = occurances;//to be checked
           
        }
        objBll.CreatedOn = System.DateTime.Now;
        objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);
        ViewState["EndDate"] = objBll.EndDate;
        ViewState["Occurances"] = occurances;


        int lastEventFreqID = 0;
       lastEventFreqID = objBll.LmsSchEventFrequencyAdd(objBll); //commented
        return lastEventFreqID;
    }


   
    
    protected void but_save_Click(object sender, EventArgs e)
    {

        try
        {
            string mode = Convert.ToString(ViewState["mode"]);
            if (mode != "Edit")
        
            {
            SaveNewEvent();
            ResetControls();
            ImpromptuHelper.ShowPrompt("Event added successfully.");
        
            }
             else 
             {
                 if (list_Modifytype.SelectedValue == "1")
                 {
                     RemoveEvent(Convert.ToInt32(Session["EventID"]), 1);
                     SaveNewEvent();
                 }
                 else if (list_Modifytype.SelectedValue == "2")
                 {
                     RemoveEvent(Convert.ToInt32(Session["EventID"]), 2);
                     SaveNewEvent();
                 }
                 ResetControls();
                 ImpromptuHelper.ShowPrompt("Event modified successfully.");
             }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }





    }

    protected void RemoveEvent(int eventID, int delType)
    {
        BLLLmsSchEvent objBll = new BLLLmsSchEvent();
        objBll.Event_ID = eventID;
        ////////////////////objBll.DeletionType = delType;// delete all occurances
        objBll.LmsSchEventDelete(objBll);
        //message to be displayed.
    }


    protected void ResetControls()
    {
        try
        {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
       
        btns.Visible = false;
        btnGen.Visible = false;
        trDate.Visible = false;
        
        txtDate.Text = "";
        txtEndTime.Text = "";
        txtTitle.Text = "";
        trDayType.Visible = false;
        TrDate2.Visible = false;
        //trchkbox.Visible = false;
        //chPublised.Checked = false;

        Editor1.Content = "";
        trstarttime.Visible = false;
        trevduration.Visible = false;
        treventhead.Visible = false;

        Treventtype.Visible = false;
        // new //
        treventloc.Visible = false;
        trfreqhead.Visible = false;
        Trfreqevent.Visible = false;
        trevery.Visible = false;
        trend.Visible = false;
        trafter.Visible = false;
        tron.Visible = false;
        Trmodftype.Visible = false;
        Trremove.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

       


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
        
        ResetControls();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnCompose_Click(object sender, EventArgs e)
    {
        try
        {
        // Comment For New Structure
        //if (ddlWorkSite.SelectedIndex > 0)
        //{
            trCDT.Visible = true;
            trCDTEnt.Visible = true;
            trDayType.Visible = true;
            btns.Visible = true;
            btnGen.Visible = true;
            trDate.Visible = true;
            TrDate2.Visible = true;
            //trchkbox.Visible = true;
            
            txtDate.Text = "";
            txtEndTime.Text = "";

           

            ViewState["mode"] = "Add";
            Editor1.Content = "";
            txtTitle.Text = "";
            trevduration.Visible = true;
            trstarttime.Visible = true;
            treventhead.Visible = true;
            Treventtype.Visible = true;

            // new //
            treventloc.Visible = true;
            trfreqhead.Visible = true;
            Trfreqevent.Visible = true;
            ////////////////////////trevery.Visible = true;
            ////////////////////////trend.Visible = true;
            ////////////////////////trafter.Visible = true;
            ////////////////////////tron.Visible = true;
            Trmodftype.Visible = true;
            Trremove.Visible = true;
            

            //chPublised.Checked = false;


        // Comment For New Structure   
        //}
        //else
        //{
        //    ImpromptuHelper.ShowPrompt("Please select WorkSite!");
        //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        BLLLmsSchEvent objClsSec = new BLLLmsSchEvent();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;




        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        trDayType.Visible = true;
        btns.Visible = true;
        trDate.Visible = true;
        TrDate2.Visible = true;
        trstarttime.Visible = true;
        trevduration.Visible = true;
        treventhead.Visible = true;
        Treventtype.Visible = true;
        // new //
        treventloc.Visible = true;
        trfreqhead.Visible = true;
        Trfreqevent.Visible = true;
        //////////trevery.Visible = true;
        //////////trend.Visible = true;
        //////////trafter.Visible = true;
        //////////tron.Visible = true;
        Trmodftype.Visible = true;
        Trremove.Visible = true;
        

        //trchkbox.Visible = true;
        //chPublised.Visible = true;

        //trOpt.Visible = true;

        ViewState["ReferenceId"] = ReferenceIdValue;



        objClsSec.Event_ID = Convert.ToInt32(ReferenceIdValue);


        dtsub = (DataTable)objClsSec.LmsSchEventSelectAllByEventID(objClsSec);

        txtTitle.Text = dtsub.Rows[0]["EventTitle"].ToString().Trim();

        Editor1.Content = dtsub.Rows[0]["Message"].ToString().Trim();

        txtDate.Text = dtsub.Rows[0]["EventDate"].ToString().Trim();
        txtEndTime.Text = dtsub.Rows[0]["EndTime"].ToString().Trim();

        txtStartTime.Text = dtsub.Rows[0]["StartTime"].ToString().Trim();
        //list_Hour.SelectedValue = dtsub.Rows[0]["EventDate"].ToString().Trim();
        //list_minute.SelectedValue = dtsub.Rows[0]["EventDate"].ToString().Trim();
        list_EventType.SelectedValue = dtsub.Rows[0]["EventType_ID"].ToString().Trim();
        txtEventLoc.Text = dtsub.Rows[0]["EventLocation"].ToString().Trim();
        list_Frqtype.SelectedValue = dtsub.Rows[0]["Frequency_ID"].ToString().Trim();
        ToggleDisplay();
        //txtEvery.Text = dtsub.Rows[0]["EventDate"].ToString().Trim();
        //txtAfter.Text = dtsub.Rows[0]["EventDate"].ToString().Trim();
        txtOn.Text = dtsub.Rows[0]["EventDate"].ToString().Trim();
        //////////////////////////////list_Modifytype.SelectedValue = dtsub.Rows[0]["EventDate"].ToString().Trim();
        //////////////////////////////list_Removetype.SelectedValue = dtsub.Rows[0]["EventDate"].ToString().Trim();



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
        BLLLmsSchEvent objClsSec = new BLLLmsSchEvent();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;


        ViewState["ReferenceId"] = ReferenceIdValue;

        objClsSec.Event_ID = Convert.ToInt32(ReferenceIdValue);


        AlreadyIn = objClsSec.LmsSchEventDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        ViewState["dtDetails"] = null;

        ResetControls();
        BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


       
    }
    

    protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvDetail.PageIndex = e.NewPageIndex;
        gvDetail.DataSource = ViewState["LoadData"];
        gvDetail.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlWorkSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        ResetControls();
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    
    protected void gvDetail_Sorting(object sender, GridViewSortEventArgs e)
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
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        try
        {

        Response.Redirect("~/PresentationLayer/TCS/LmsSchEventMainStudentLevel.aspx");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    protected void CalculateDurationByMinHrs()
    {
        DateTime startTime = new DateTime();

        if (txtStartTime.Text != "")
        {
            if (list_Hour.SelectedIndex >= 0 || list_minute.SelectedIndex >= 0)
            {

                startTime = Convert.ToDateTime(txtStartTime.Text);
                startTime = startTime.AddHours(Convert.ToDouble(list_Hour.SelectedValue));

                startTime = startTime.AddMinutes(Convert.ToDouble(list_minute.SelectedValue));
                txtEndTime.Text = startTime.ToLongTimeString();

            }
        }

    }


    protected void txtStartTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
        CalculateDurationByMinHrs();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_Hour_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        CalculateDurationByMinHrs();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void CalculateDurationByStrtEnd()
    {
        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();

        if (txtStartTime.Text != "" && txtEndTime.Text != "")
        {
            startTime = Convert.ToDateTime(txtStartTime.Text);
            endTime = Convert.ToDateTime(txtEndTime.Text);
            TimeSpan ts = new TimeSpan();

            ts = endTime.Subtract(startTime);

            list_Hour.SelectedValue = ts.Hours.ToString();
            list_minute.SelectedValue = ts.Minutes.ToString();

        }
    }


    protected void txtEndTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
        CalculateDurationByStrtEnd();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ToggleDisplay()
    {
        switch (list_Frqtype.SelectedItem.Text)
        {
            case "Once":
                lblFreqGap.Text = "Event occures once.";

                trevery.Visible = false;
                trend.Visible = false;
                trafter.Visible = false;
                tron.Visible = false;
                ////txtEvery.Visible = false;

                ////mngfreqSection.Visible = false;
                ////endSection.Visible = false;
                ////freqGapSection.Visible = false;
                
                ////txtEvery.Text = "1";
                ////txtAfter.Text = "1";



                break;

            case "Daily":
                lblFreqGap.Text = "day(s)";

                 trevery.Visible = true;
                 trend.Visible = true;
                 trafter.Visible = true;
                 tron.Visible = true;


                ////////////////txtEvery.Visible = true;

                ////////////////mngfreqSection.Visible = true;
                ////////////////endSection.Visible = true;
                ////////////////freqGapSection.Visible = true;
                
                break;

            case "Weekly":
                lblFreqGap.Text = "week(s)";

                trevery.Visible = true;
                 trend.Visible = true;
                 trafter.Visible = true;
                 tron.Visible = true;


                ////////////txtEvery.Visible = true;
                ////////////mngfreqSection.Visible = true;
                ////////////endSection.Visible = true;
                ////////////freqGapSection.Visible = true;
                
                break;

            case "Monthly":
                lblFreqGap.Text = "month(s)";

                trevery.Visible = true;
                 trend.Visible = true;
                 trafter.Visible = true;
                 tron.Visible = true;


                ////////////txtEvery.Visible = true;
                ////////////mngfreqSection.Visible = true;
                ////////////endSection.Visible = true;
                ////////////freqGapSection.Visible = true;
                
                break;

            case "Yearly":
                lblFreqGap.Text = "year(s)";

                trevery.Visible = true;
                 trend.Visible = true;
                 trafter.Visible = true;
                 tron.Visible = true;


                ////////////txtEvery.Visible = true;
                ////////////mngfreqSection.Visible = true;
                ////////////endSection.Visible = true;
                ////////////freqGapSection.Visible = true;
                
                break;

        }
    }


    protected void list_Frqtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        ToggleDisplay();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
