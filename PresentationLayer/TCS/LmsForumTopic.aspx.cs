using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_LmsForumTopic : System.Web.UI.Page
{
    
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
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (!IsPostBack)
        {
            try
            {
            //======== Page Access Settings ========================
            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;


            DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            Session["User_Type_Id"]= Convert.ToInt32(row["User_Type_Id"].ToString());
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================

            FillForumDropDown();

            //////////BindGrid();

            //////////FillAccessiblityForForum();

            //////////FillPublishStatusForForum();

            //////////FillPostingForForum();

            //////////FillThreadTypeForForum();

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
    


    //////////////private void FillWorkSiteForAnnouncements()
    //////////////{



    //////////////    try
    //////////////    {

    //////////////        BLLSection_Subject objCS = new BLLSection_Subject();

            
    //////////////        objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
    //////////////        DataTable _dt = objCS.Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement(objCS);


    //////////////        objBase.FillDropDown(_dt, ddlWorkSite, "Section_Subject_Id", "Title");

           

    //////////////    }
    //////////////    catch (Exception ex)
    //////////////    {

    //////////////        Session["error"] = ex.Message;
    //////////////        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //////////////    }
    //////////////}

    private void FillForumDropDown()
    {
        try
        {


        BLLLmsForm obj = new BLLLmsForm();

        obj.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());

        //int CenterId = Convert.ToInt32(Session["cId"].ToString());
        DataTable dt = (DataTable)obj.LmsFormFetch(obj);

        objBase.FillDropDown(dt, List_Forum, "Forum_ID", "ForumTitle");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    private void FillAccessiblityForForum()
    {



        try
        {

            BLLLmsGloballyVisibleTo objCS = new BLLLmsGloballyVisibleTo();


            ////////////objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.LmsGloballyVisibleToFetch(objCS);


            objBase.FillDropDown(_dt, list_Accesible, "GlobalVisibleTo_ID", "GloballyVisibleTo");



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void FillPublishStatusForForum()
    {



        try
        {

            BLLLmsPublishStatus objCS = new BLLLmsPublishStatus();


            ////objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.LmsPublishStatusFetch(objCS);


            objBase.FillDropDown(_dt, list_publish, "PublishStatus_ID", "PublishStatus");



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void FillPostingForForum()
    {



        try
        {

            BLLLmsFormPostingType objCS = new BLLLmsFormPostingType();


            ////objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.LmsFormPostingTypeFetch(objCS);


            objBase.FillDropDown(_dt, list_posting, "PostingType_ID", "PostType");



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void FillThreadTypeForForum()
    {



        try
        {

            BLLLmsFormThreadType objCS = new BLLLmsFormThreadType();


            ////objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.LmsFormThreadTypeFetch(objCS);


            objBase.FillDropDown(_dt, list_treadtype, "ThreadType_ID", "ThreadType");



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
        BLLLmsFormTopic objClsSec = new BLLLmsFormTopic();

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
        if (List_Forum.SelectedIndex > 0)
        {


            lblWorksitename.Text = Session["WorkSiteName"].ToString();

            objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
            objClsSec.WrkTool_Id = Convert.ToInt32(Session["WorkToolId"].ToString());
            objClsSec.Forum_ID = Convert.ToInt32(List_Forum.SelectedValue);

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.LmsFormTopicSlectAllBySectionSubjectIdWrkToolId(objClsSec);
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



   

   
    
    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {



            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLLmsFormTopic objClsSec = new BLLLmsFormTopic();

            BLLSection_Subject objsect = new BLLSection_Subject();


            DataTable dtsub = new DataTable();
            DataTable dtwrk = new DataTable();
            ////////if (txtDate.Text != "" && txtDate2.Text != "" && txtTitle.Text != "")
            if (txtTitle.Text != "" && txtShDesc.Text != "" && list_Accesible.SelectedIndex > 0 && list_publish.SelectedIndex > 0 && list_posting.SelectedIndex > 0 && list_treadtype.SelectedIndex > 0)
            {
                // Comment For New Structure
                ////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
                ///////

                //////////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                //////////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



                //////////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(objsect);


                //////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());


                objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
                objClsSec.WrkTool_Id = Convert.ToInt32(Session["WorkToolId"].ToString());


                objClsSec.Forum_ID = Convert.ToInt32(List_Forum.SelectedValue.ToString());
                
                objClsSec.TopicTitle = txtTitle.Text.ToString();

                objClsSec.ShortDescription = txtShDesc.Text.ToString();

                
                objClsSec.LongDescription = Editor1.Content;
                objClsSec.isLock = chPublised.Checked;
                objClsSec.isGradeBook = chGradebook.Checked;
                objClsSec.TotalPoints = Convert.ToInt32(txtPoint.Text);
                objClsSec.GblAccessType_ID = Convert.ToInt32(list_Accesible.SelectedValue.ToString());
                objClsSec.PublishStatus_ID = Convert.ToInt32(list_publish.SelectedValue.ToString());
                objClsSec.PostingType_ID = Convert.ToInt32(list_posting.SelectedValue.ToString());
                objClsSec.ThreadType_ID = Convert.ToInt32(list_treadtype.SelectedValue.ToString());
                objClsSec.Status_Id = 1;




                string mode = Convert.ToString(ViewState["mode"]);

                if (mode != "Edit")
                {



                    objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    objClsSec.CreatedOn = DateTime.Now;


                    AlreadyIn = objClsSec.LmsFormTopicAdd(objClsSec);


                   
                    if (AlreadyIn == 0)
                    {
                        ViewState["dtDetails"] = null;
                        ImpromptuHelper.ShowPrompt("Record was successfully added.");
                        ResetControls();
                        
                        BindGrid();

                    }


                }

                else
                {



                    objClsSec.Topic_ID = Convert.ToInt32(ViewState["ReferenceId"]);
                    objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    objClsSec.ModifiedOn = DateTime.Now;

                    AlreadyIn = objClsSec.LmsFormTopicUpdate(objClsSec);


                   
                    if (AlreadyIn == 0)
                    {
                        ViewState["dtDetails"] = null;
                        ImpromptuHelper.ShowPrompt("Record successfully updated.");
                        ResetControls();
                       
                        BindGrid();

                    }


                }


            }
            else
            {
                ImpromptuHelper.ShowPrompt("Can't Save balnk Values!");
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
        try
        {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
       
        btns.Visible = false;
        btnGen.Visible = false;
        trShDes.Visible = false;
        //trDate.Visible = false;
        
        //txtDate.Text = "";
        //txtDate2.Text = "";
        txtTitle.Text = "";
        trDayType.Visible = false;
        //TrDate2.Visible = false;
        trchkbox.Visible = false;
        trchgrade.Visible = false;

        chPublised.Checked = false;
        trmarks.Visible = false;
        txtPoint.Visible = false;
        lstAcces.Visible = false;
        lstPub.Visible = false;
        lstposting.Visible = false;
        lstthread.Visible = false;


        Editor1.Content = "";

        list_Accesible.SelectedIndex = 0;

        list_publish.SelectedIndex = 0;

        list_posting.SelectedIndex = 0;

        list_treadtype.SelectedIndex = 0;

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
            //trDate.Visible = true;
            //TrDate2.Visible = true;
            trShDes.Visible = true;
            trchkbox.Visible = true;
            trchgrade.Visible = true;

            lstAcces.Visible = true;
            lstPub.Visible = true;
            lstposting.Visible = true;
            lstthread.Visible = true;
            
            //txtDate.Text = "";
            //txtDate2.Text = "";

           

            ViewState["mode"] = "Add";
            Editor1.Content = "";
            txtTitle.Text = "";
            chPublised.Checked = false;


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
        BLLLmsFormTopic objClsSec = new BLLLmsFormTopic();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;




        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        trDayType.Visible = true;
        btns.Visible = true;
        ////trDate.Visible = true;
        ////TrDate2.Visible = true;
        trShDes.Visible = true;
        trchkbox.Visible = true;
        trchgrade.Visible = true;
        chPublised.Visible = true;
        lstAcces.Visible = true;
        lstPub.Visible = true;
        lstposting.Visible = true;
        lstthread.Visible = true;

        //trOpt.Visible = true;

        ViewState["ReferenceId"] = ReferenceIdValue;



        objClsSec.Topic_ID = Convert.ToInt32(ReferenceIdValue);


        dtsub = (DataTable)objClsSec.LmsFormTopicSelectAllByTopicId(objClsSec);

        txtTitle.Text = dtsub.Rows[0]["TopicTitle"].ToString().Trim();

        txtShDesc.Text = dtsub.Rows[0]["ShortDescription"].ToString().Trim();


        Editor1.Content = dtsub.Rows[0]["LongDescription"].ToString().Trim();

        ////txtDate.Text = dtsub.Rows[0]["PublishStartDate"].ToString().Trim();
        ////txtDate2.Text = dtsub.Rows[0]["PublishEndDate"].ToString().Trim();

        if (dtsub.Rows[0]["isLock"].ToString().Trim() == "YES")
        {
            chPublised.Checked = true;
        }
        else
        {
            chPublised.Checked = false;
        }


        if (dtsub.Rows[0]["isGradeBook"].ToString().Trim() == "YES")
        {
            chGradebook.Checked = true;
        }
        else
        {
            chGradebook.Checked = false;
        }


        list_Accesible.SelectedValue = dtsub.Rows[0]["GblAccessType_ID"].ToString().Trim(); 
        list_publish.SelectedValue = dtsub.Rows[0]["PublishStatus_ID"].ToString().Trim(); 

        list_posting.SelectedValue = dtsub.Rows[0]["PostingType_ID"].ToString().Trim(); 
        list_treadtype.SelectedValue = dtsub.Rows[0]["ThreadType_ID"].ToString().Trim();

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
        BLLLmsFormTopic objClsSec = new BLLLmsFormTopic();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;


        ViewState["ReferenceId"] = ReferenceIdValue;

        objClsSec.Topic_ID = Convert.ToInt32(ReferenceIdValue);


        AlreadyIn = objClsSec.LmsFormTopicDelete(objClsSec);


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
        Response.Redirect("~/PresentationLayer/TCS/LMSTeacherWorkspaceDetail.aspx");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void chGradebook_CheckedChanged(object sender, EventArgs e)
    {
       try
       {

        if (chGradebook.Checked == true)
        {
            trmarks.Visible = true;
            txtPoint.Visible = true;
        }
        else
        {
            trmarks.Visible = false;
            txtPoint.Visible = false;
        }

       }
       catch (Exception ex)
       {
           Session["error"] = ex.Message;
           Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
       }




    }
    protected void chGradebook_Load(object sender, EventArgs e)
    {

    }
    protected void List_Forum_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();

        FillAccessiblityForForum();

        FillPublishStatusForForum();

        FillPostingForForum();

        FillThreadTypeForForum();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
