using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_LmsPolls : System.Web.UI.Page
{
    //DALBase objbase = new DALBase();
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
            pan_new2.Attributes.CssStyle.Add("display", "none");
            pan_QestGrid.Attributes.CssStyle.Add("display", "none");

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


           

            // Comment For New Structure
            //FillWorkSiteForPolls();

            BindGrid();
            BindGridQuestionOption();

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }




    private void FillWorkSiteForPolls()
    {



        try
        {

            BLLSection_Subject objCS = new BLLSection_Subject();

            ////////////objCS.Center_Id = Convert.ToInt32(Session["CId"]);
            objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.Section_SubjectSelectAllWorkSiteByTeacherIdForPolls(objCS);


            objBase.FillDropDown(_dt, ddlWorkSite, "Section_Subject_Id", "Title");



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
        BLLLmsPolls objClsSec = new BLLLmsPolls();

        BLLSection_Subject objsect = new BLLSection_Subject();


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();

        // Comment For New Structure

       

        ////if (ddlWorkSite.SelectedIndex > 0)
        ////{

        //////////////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
     

        //////////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        //////////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



        //////////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls(objsect);


        //////////////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());

        lblWorksitename.Text = Session["WorkSiteName"].ToString();

        objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
        objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());

       

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsPollsSelectAllBySectionSubjectIdWrkToolId(objClsSec);
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
        ////////trSave.Visible = true;
        ////}
        ////else
        ////{
        ////    gvDetail.DataSource = null;
        ////    gvDetail.DataBind();
        ////}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }




    private void BindGridQuestionDetail()
    {

        try
        {
        BLLLmsPollsDetail objClsSec = new BLLLmsPollsDetail();

   


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();

       

        ////////lblWorksitename.Text = Session["WorkSiteName"].ToString();

        objClsSec.Poll_ID = Convert.ToInt32(ViewState["QuestionReferenceId"]);
        ////////objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());



        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsPollsDetailSelectAllByPollId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvQuestion.DataSource = dtsub;
            gvQuestion.DataBind();
            ViewState["tMood"] = "check";
        }
        else
        {
            gvQuestion.DataSource = null;
            gvQuestion.DataBind();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        
    }





    private void BindGridQuestionOption()
    {

        try
        {
        BLLLmsPollsQuestionDetailOption objClsSec = new BLLLmsPollsQuestionDetailOption();

        ////BLLSection_Subject objsect = new BLLSection_Subject();


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();

       

       



        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsPollsQuestionDetailOptionFetch(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvQestOption.DataSource = dtsub;
            gvQestOption.DataBind();
            ViewState["tMood"] = "check";
        }
        else
        {
            gvQestOption.DataSource = null;
            gvQestOption.DataBind();
        }
        ////////trSave.Visible = true;
        ////}
        ////else
        ////{
        ////    gvDetail.DataSource = null;
        ////    gvDetail.DataBind();
        ////}
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

            BLLLmsPolls objClsSec = new BLLLmsPolls();

            BLLSection_Subject objsect = new BLLSection_Subject();


            DataTable dtsub = new DataTable();
            DataTable dtwrk = new DataTable();

            if (txtDate.Text != "" && txtDate2.Text != "" && txtTitle.Text != "")
            {

            //////////////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
            /////////////////////

            //////////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            //////////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



            //////////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls(objsect);


            //////////////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());


                objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
                objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());





            
            objClsSec.QstText = txtTitle.Text.ToString();
            
            objClsSec.AddInstructions = Editor1.Content;
            objClsSec.PublishStatus_ID = chPublised.Checked;
            objClsSec.GblAccessType_ID = chGlobal.Checked;
            objClsSec.OpningDate = DateTime.Parse(txtDate.Text);
            objClsSec.ClosingDate = DateTime.Parse(txtDate2.Text);
            objClsSec.Status_Id = 1;




            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {


                
                objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.CreatedOn = DateTime.Now;


                AlreadyIn = objClsSec.LmsPollsAdd(objClsSec);


               
                if (AlreadyIn == 0)
                {
                    ViewState["dtDetails"] = null;
                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                    ResetControls();
                    ////////pan_New.Attributes.CssStyle.Add("display", "none");
                    BindGrid();

                }


            }

            else
            {



                objClsSec.Poll_ID = Convert.ToInt32(ViewState["ReferenceId"]);
                objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.ModifiedOn = DateTime.Now;

                AlreadyIn = objClsSec.LmsPollsUpdate(objClsSec);


               
                if (AlreadyIn == 0)
                {
                    ViewState["dtDetails"] = null;
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    ResetControls();
                    ////////pan_New.Attributes.CssStyle.Add("display", "none");
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
        trchkbox2.Visible = false;
        chPublised.Checked = false;
        chGlobal.Checked = false;
        Editor1.Content = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void ResetDetailControls()
    {

        try
        {


        gvQestOption.DataSource = null;
        gvQestOption.DataBind();

        gvQuestion.DataSource = null;
        gvQuestion.DataBind();

        txtQuestion.Text = "";

        pan_new2.Attributes.CssStyle.Add("display", "none");
        pan_QestGrid.Attributes.CssStyle.Add("display", "none");


        //////////trCDT.Visible = false;
        //////////trCDTEnt.Visible = false;
        //////////////txtDescription.Text = "";
        //////////btns.Visible = false;
        //////////btnGen.Visible = false;
        //////////trDate.Visible = false;
        ////////////trOpt.Visible = false;
        //////////txtDate.Text = "";
        //////////txtDate2.Text = "";
        //////////txtTitle.Text = "";
        //////////trDayType.Visible = false;
        //////////TrDate2.Visible = false;
        //////////trchkbox.Visible = false;
        //////////trchkbox2.Visible = false;
        //////////chPublised.Checked = false;
        //////////chGlobal.Checked = false;
        //////////Editor1.Content = "";

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
            trchkbox.Visible = true;
            trchkbox2.Visible = true;
            //trOpt.Visible = true;
            txtDate.Text = "";
            txtDate2.Text = "";
            ////txtDescription.Text = "";
            ////btnSave.Text = "Save";
            //////ViewState["Mode"] = "add";

            ViewState["mode"] = "Add";

            Editor1.Content = "";
            txtTitle.Text = "";
            chPublised.Checked = false;
            chGlobal.Checked = false;

         // Comment For New Structure   

       //// }
       ////else
       ////{
       ////    ImpromptuHelper.ShowPrompt("Please select WorkSite!");
       ////}

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
        BLLLmsPolls objClsSec = new BLLLmsPolls();

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
        trchkbox.Visible = true;
        chPublised.Visible = true;
        trchkbox2.Visible = true;
        chGlobal.Checked = true;

        //trOpt.Visible = true;

        /////////////////////////
        ViewState["ReferenceId"] = ReferenceIdValue;



        objClsSec.Poll_ID = Convert.ToInt32(ReferenceIdValue);


        dtsub = (DataTable)objClsSec.LmsPollsSelectAllByPollId(objClsSec);

        txtTitle.Text = dtsub.Rows[0]["QstText"].ToString().Trim();
        ////////txtDescription.Text = dtsub.Rows[0]["AncmtBody"].ToString().Trim();
        Editor1.Content = dtsub.Rows[0]["AddInstructions"].ToString().Trim();

        txtDate.Text = dtsub.Rows[0]["OpningDate"].ToString().Trim();
        txtDate2.Text = dtsub.Rows[0]["ClosingDate"].ToString().Trim();

        if (dtsub.Rows[0]["IsPublished"].ToString().Trim() == "YES")
        {
            chPublised.Checked = true;
        }
        else
        {
            chPublised.Checked = false;
        }


        if (dtsub.Rows[0]["GblAccessType_ID"].ToString().Trim() == "YES")
        {
            chGlobal.Checked = true;
        }
        else
        {
           
            chGlobal.Checked = false;   

        }

        ResetDetailControls();


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
        BLLLmsPolls objClsSec = new BLLLmsPolls();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;


        ViewState["ReferenceId"] = ReferenceIdValue;

        objClsSec.Poll_ID = Convert.ToInt32(ReferenceIdValue);


        AlreadyIn = objClsSec.LmsPollsDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        ResetControls();
        ResetDetailControls();
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

    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
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

    protected void btnShowQuestion_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        pan_QestGrid.Attributes.CssStyle.Add("display", "inline");


        DataTable dtsub = new DataTable();
        ////ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string QuestionReferenceIdValue = btn.CommandArgument;

        ViewState["QuestionReferenceId"] = QuestionReferenceIdValue;



        BindGridQuestionDetail();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }
    protected void btnQuestionAdd_Click(object sender, ImageClickEventArgs e)
    {
        
        try
        {
        ImageButton btn = (ImageButton)(sender);
        string QuestionReferenceIdValue = btn.CommandArgument;

        ViewState["QuestionReferenceId"] = QuestionReferenceIdValue;



        pan_new2.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtQuestion.Text = "";


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        



    }


    private void AddQuestionDetail()
    {

        try
        {
        BLLLmsPollsQuestionDetail objBll = new BLLLmsPollsQuestionDetail();

        BLLLmsPollsQuestionDetailOption objClsSec = new BLLLmsPollsQuestionDetailOption();


        //BLLSection_Subject objClsSec = new BLLSection_Subject();

        string StudentFullName;
        string DpTitle;
        string strMode = "";
        DataTable dt = new DataTable();
        //////////objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        //////////objClsSec.Section_Subject_Id = Convert.ToInt32(ViewState["ResultGrade"]);


     


        dt = (DataTable)objClsSec.LmsPollsQuestionDetailOptionFetch(objClsSec);
        if (dt.Rows.Count != 0)
        {


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ////StudentFullName = dt.Rows[i]["StudentFullName"].ToString().Trim();
                ////DpTitle = dt.Rows[i]["Title"].ToString().Trim(); ;




                ////string strFolderPath = "D:\\TCS\\LMS\\" + DpTitle + "\\Dropbox\\" + StudentFullName;


             

                objBll.PollDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]);
                objBll.QuestionDetailOption_Id = Convert.ToInt32(dt.Rows[i]["QuestionDetailOption_Id"].ToString().Trim());
                objBll.QuestionDetailOption = dt.Rows[i]["QuestionDetailOption"].ToString().Trim();
                objBll.Status_Id = 1;
                objBll.Score = Convert.ToInt32(dt.Rows[i]["Score"].ToString().Trim());



                objBll.LmsPollsQuestionDetailAdd(objBll);

               

            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }





    }



    
    protected void btnQuestionSave_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();



            BLLLmsPollsDetail objClsSec = new BLLLmsPollsDetail();



            DataTable dtsub = new DataTable();



            objClsSec.Poll_ID = Convert.ToInt32(ViewState["QuestionReferenceId"]);
            //objClsSec.Activity_Id = Convert.ToInt32(ViewState["ActivityValue"]);
            objClsSec.QstDetails = txtQuestion.Text;
            string mode = Convert.ToString(ViewState["mode"]);

            


            if (mode != "Edit")
            {
               
                    AlreadyIn = objClsSec.LmsPollsDetailAdd(objClsSec);
                ///// without it 
                    //////////AddQuestionDetail();

                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Question was successfully added to this Poll.");
                        pan_new2.Attributes.CssStyle.Add("display", "none");
                        pan_QestGrid.Attributes.CssStyle.Add("display", "inline");
                        BindGridQuestionDetail();

                    }

                

            }
            else
            {
                objClsSec.PollDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]);



                AlreadyIn = objClsSec.LmsPollsDetailUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Question was successfully updated to this Poll.");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    pan_QestGrid.Attributes.CssStyle.Add("display", "inline");
                    BindGridQuestionDetail();

                }

            }




        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCalnalQuestion_Click(object sender, EventArgs e)
    {
        try
        {
        ResetDetailControls();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvQuestion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gvQuestion_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void btnQuestionDTEdit_Click(object sender, EventArgs e)
    {
        try
        {
        BLLLmsPollsDetail objClsSec = new BLLLmsPollsDetail();

        DataTable dtsub = new DataTable();



        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string QuestionDetailIdValue = btn.CommandArgument;

        ViewState["QuestionDetailId"] = QuestionDetailIdValue;


       


        pan_new2.Attributes.CssStyle.Add("display", "inline");
       
     



        objClsSec.PollDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]);


        dtsub = (DataTable)objClsSec.LmsPollsDetailSelectAllByPollDetailID(objClsSec);

        txtQuestion.Text = dtsub.Rows[0]["QstDetails"].ToString().Trim();




        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    
    }
    protected void btnQuestionDTdelete_Click(object sender, EventArgs e)
    {

    }

}
