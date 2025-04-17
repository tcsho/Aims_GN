using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_LmsNews : System.Web.UI.Page
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
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================



            BindGrid();

            // Comment For New Structure
            //////FillWorkSiteForNews();

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }



            
        }
    }
   
    


    private void FillWorkSiteForNews()
    {



        try
        {

            BLLSection_Subject objCS = new BLLSection_Subject();

           
            objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.Section_SubjectSelectAllWorkSiteByTeacherIdForNews(objCS);


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
        BLLLmsNews objClsSec = new BLLLmsNews();

        BLLSection_Subject objsect = new BLLSection_Subject();


        DataTable dtsub = new DataTable();
        DataTable dtwrk = new DataTable();
        //////////////////if (ddlWorkSite.SelectedIndex > 0)
        //////////////////{

        //////////////////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
        

        //////////////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        //////////////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



        //////////////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews(objsect);


        //////////////////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());

        lblWorksitename.Text = Session["WorkSiteName"].ToString();

        objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
        objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());

       

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsNewsSelectAllBySectionSubjectIdWrkToolId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvDetail.DataSource = dtsub;
        }
        gvDetail.DataBind();
        ViewState["tMood"] = "check";
        
        ////////}
        ////////else
        ////////{
        ////////    gvDetail.DataSource = null;
        ////////    gvDetail.DataBind();
        ////////}

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

            BLLLmsNews objClsSec = new BLLLmsNews();

            BLLSection_Subject objsect = new BLLSection_Subject();


            DataTable dtsub = new DataTable();
            DataTable dtwrk = new DataTable();

            DateTime startDate;
            DateTime endDate;

            if (txtDate.Text != "" && txtDate2.Text != "" && txtTitle.Text != "")
            {

                // Comment For New Structure

            ////////objClsSec.Section_Subject_Id = Int32.Parse(ddlWorkSite.SelectedValue);
            

            ////////objsect.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            ////////objsect.Section_Subject_Id = Convert.ToInt32(ddlWorkSite.SelectedValue.ToString());



            ////////dtwrk = objsect.Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews(objsect);


            ////////objClsSec.WrkTool_ID = Int32.Parse(dtwrk.Rows[0]["WrkTool_ID"].ToString());

                startDate = Convert.ToDateTime(txtDate.Text);

                endDate = Convert.ToDateTime(txtDate2.Text);




            objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
            objClsSec.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());
            
            objClsSec.NewsTitle = txtTitle.Text.ToString();
            
            objClsSec.NewsDetail = Editor1.Content;
            objClsSec.PublishStatus_ID = chPublised.Checked;
            objClsSec.StartDateTime = DateTime.Parse(txtDate.Text);
            objClsSec.EndDateTime = DateTime.Parse(txtDate2.Text);
            objClsSec.Status_ID = 1;




            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {


                
                objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.CreatedOn = DateTime.Now;


                AlreadyIn = objClsSec.LmsNewsAdd(objClsSec);


                
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



                objClsSec.News_ID = Convert.ToInt32(ViewState["ReferenceId"]);
                objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.ModifiedOn = DateTime.Now;

                AlreadyIn = objClsSec.LmsNewsUpdate(objClsSec);


               
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
        trDate.Visible = false;
        
        txtDate.Text = "";
        txtDate2.Text = "";
        txtTitle.Text = "";
        trDayType.Visible = false;
        TrDate2.Visible = false;
        trchkbox.Visible = false;
        chPublised.Checked = false;
        Editor1.Content = "";

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
       //////if (ddlWorkSite.SelectedIndex > 0)
       ////// {
            trCDT.Visible = true;
            trCDTEnt.Visible = true;
            trDayType.Visible = true;
            btns.Visible = true;
            btnGen.Visible = true;
            trDate.Visible = true;
            TrDate2.Visible = true;
            trchkbox.Visible = true;
            
            txtDate.Text = "";
            txtDate2.Text = "";
            

            ViewState["mode"] = "Add";

            Editor1.Content = "";
            txtTitle.Text = "";
            chPublised.Checked = false;


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
        BLLLmsNews objClsSec = new BLLLmsNews();

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
       
        ViewState["ReferenceId"] = ReferenceIdValue;



        objClsSec.News_ID = Convert.ToInt32(ReferenceIdValue);


        dtsub = (DataTable)objClsSec.LmsNewsSelectAllByNewsId(objClsSec);

        txtTitle.Text = dtsub.Rows[0]["NewsTitle"].ToString().Trim();
        
        Editor1.Content = dtsub.Rows[0]["NewsDetail"].ToString().Trim();

        txtDate.Text = dtsub.Rows[0]["StartDateTime"].ToString().Trim();
        txtDate2.Text = dtsub.Rows[0]["EndDateTime"].ToString().Trim();

        if (dtsub.Rows[0]["IsPublished"].ToString().Trim() == "YES")
        {
            chPublised.Checked = true;
        }
        else
        {
            chPublised.Checked = false;
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
        BLLLmsNews objClsSec = new BLLLmsNews();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;


        ViewState["ReferenceId"] = ReferenceIdValue;

        objClsSec.News_ID = Convert.ToInt32(ReferenceIdValue);


        AlreadyIn = objClsSec.LmsNewsDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
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
}
