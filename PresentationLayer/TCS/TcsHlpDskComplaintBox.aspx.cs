using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_TcsHlpDskComplaintBox : System.Web.UI.Page
{
    BLLTCS_HlpDskComplaintBox objBll = new BLLTCS_HlpDskComplaintBox();
    BLLTCS_HlpDskCompSolution objCompSol = new BLLTCS_HlpDskCompSolution();
    DALBase objBase = new DALBase();
    DataTable dtFeedback = new DataTable();
    int complaintID = 0;
    int solutionID = 0;
    BLLSendEmail objEmail = new BLLSendEmail();

    protected void Page_Load(object sender, EventArgs e)
    {
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
//            tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================
            pan_New.Attributes.CssStyle.Add("display", "none");
            pan_Feedback.Attributes.CssStyle.Add("display", "none");

            ViewState["SortDirection"] = "ASC";
            ViewState["mode"] = "Add";

            bindgrid();
            bindddlPriorityType();
            FillComplaintcatagory();
        }
    }
    protected void gvComplaints_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvComplaints.Rows.Count > 0)
            {
                gvComplaints.UseAccessibleHeader = false;
                gvComplaints.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvComplaints.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvSolutions_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvSolutions.Rows.Count > 0)
            {
                gvSolutions.UseAccessibleHeader = false;
                gvSolutions.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvSolutions.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
        protected void bindgrid()
    {
        try
        {
        DataRow row = (DataRow)Session["rightsRow"];

        objBll.Status_Id = 1;
        objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
        DataTable _dt = new DataTable();
        if (ViewState["countries"] == null)
            _dt = objBll.TCS_HlpDskComplaintBoxSelectByCenterId(objBll);
        else
            _dt = (DataTable)ViewState["countries"];

        if (_dt.Rows.Count == 0)
            lab_dataStatus.Visible = true;
        else
        {
            gvComplaints.DataSource = _dt;
            ViewState["countries"] = _dt;
            lab_dataStatus.Visible = false;
        }
        gvComplaints.DataBind();
        pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "none");
        gvComplaints.SelectedRowStyle.Reset();
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
            string mode = Convert.ToString(ViewState["mode"]);
            int id = 0;
            string strEmailMsg = "";

            DataRow row = (DataRow)Session["rightsRow"];

            objBll.Region_ID = Convert.ToInt32(row["Region_Id"].ToString());
            objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
            ////////////objBll.Cluster_ID = Convert.ToInt32(row["Cluster_Id"].ToString());
            objBll.HDSubCat_ID = Convert.ToInt32(ddlCompCatg.SelectedValue);
            objBll.ComplaintTitle = txtTitle.Text;
            objBll.HDComplaintDesc = txtDescription.Text;
            
            objBll.PriorityType_ID = Convert.ToInt32(ddlPriority.SelectedValue);

            ////////objBll.PriorityType_ID = 1;


            objBll.CreatedOn = DateTime.Now;
            objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);
            objBll.ModifiedOn = DateTime.Now;
            objBll.ModifiedBy = Convert.ToInt32(Session["ContactID"]);
            //// Assign Resource
            //////////objBllr.Center_ID = Convert.ToInt32(Session["CId"].ToString());

            objBll.Center_ID = Convert.ToInt32(Session["CId"].ToString());

            DataTable dtr = objBll.TCS_HlpDskComplaintBoxSelectResourceCenterIDROType(objBll);


            objBll.HD_Resource_ID = Convert.ToInt32(dtr.Rows[0]["HD_Resource_ID"].ToString());

            objBll.DueDate = DateTime.Today.AddDays(7);
            ////

            int nAlreadyIn;
            if (mode != "Edit")
            {
                nAlreadyIn = objBll.TCS_HlpDskComplaintBoxInsert(objBll);
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                error.Visible = false;


                //========================= Sending Email for Registered Complaints ========================================
                strEmailMsg = "Dear Sir,<br><br>A new complaint has been raised on help desk by '" + row["center_name"].ToString() + "'. Following are the details:";
                strEmailMsg += "<br><br><b>Complaint category:</b> " + ddlCompCatg.SelectedItem.Text;
                strEmailMsg += "<br><b>Priority:</b> " + ddlPriority.SelectedItem.Text;
                ////////strEmailMsg += "<br><b>Priority:</b> " ;
                strEmailMsg += "<br><b>Subject:</b> " + txtTitle.Text;
                strEmailMsg += "<br><br><b>Description:</b> " + txtDescription.Text;
                strEmailMsg += "<br><br><b>Note:</b><i>This is a system generated message. Please do not reply directly to this message.</i>";
                //objEmail.SendEmail("tsshomisbah@thesmartschools.edu.pk", "New complaint raised on help desk", strEmailMsg);
                objEmail.SendEmail(3, "New Query raised on help desk", strEmailMsg, "Help desk Notification");



                //===============================================================================================

                
                ImpromptuHelper.ShowPrompt("Complaint has been registered sucessfully.");
            }
            else
            {
                objBll.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
                nAlreadyIn = objBll.TCS_HlpDskComplaintBoxUpdate(objBll);
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                error.Visible = false;
                ImpromptuHelper.ShowPrompt("Complaint has been updated sucessfully.");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvComplaints_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable oDataSet = (DataTable)ViewState["countries"];
            oDataSet.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();
            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            bindgrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvComplaints_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvComplaints.PageIndex = e.NewPageIndex;
            bindgrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvComplaints_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objBll.HDComplaint_ID = Convert.ToInt32(gvComplaints.Rows[e.RowIndex].Cells[0].Text);
            objBll.TCS_HlpDskComplaintBoxDelete(objBll);

            ViewState["countries"] = null;
            bindgrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvComplaints_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton ib = (ImageButton)e.Row.FindControl("ImageButton2");
            //ib.Attributes.Add("onclick", "javascript:return " +
            //"confirm('Are you sure you want to delete this complaint?') ");

            //LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");

        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

   

    protected static void ResetControls()
    {
        //ddlCompCatg.SelectedValue = "0";
        //ddlPriority.SelectedValue = "0";
        //txtTitle.Text = "";
        //txtDescription.Text = "";
    }

    protected void gvComplaints_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            ddlCompCatg.SelectedValue = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[1].Text;
            ddlPriority.SelectedValue = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[2].Text;
            txtTitle.Text = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[6].Text;
            txtDescription.Text = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[3].Text;

            ViewState["mode"] = "Edit";
            ViewState["EditID"] = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[0].Text;
            error.Visible = false;
            pan_New.Attributes.CssStyle.Add("display", "inline");
            pan_Feedback.Attributes.CssStyle.Add("display", "none");
            if (this.gvComplaints.Rows[e.NewSelectedIndex].Cells[12].Text == "6") //Unassigned
            {
                //pan_New.Enabled = true;
                EnableDisableControls(1);
                but_save.Visible = true;
            }
            else
            {
                //pan_New.Enabled = false;
                EnableDisableControls(0);
                but_save.Visible = false;
                but_cancel.Enabled = true;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    protected void FillComplaintcatagory()
    {
        try
        {
        DataTable dt = new DataTable();
        BLLTCS_HlpDskSubCatg objBll = new BLLTCS_HlpDskSubCatg();
        objBll.MCatg_ID = 1;//Convert.ToInt32(ddlMainCatg.SelectedValue);


        dt = objBll.TCS_HlpDskSubCatgSelectByMCatgId(objBll);
        objBase.FillDropDown(dt, ddlCompCatg, "HDSubCat_ID", "HDSubDesc");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public void bindddlPriorityType()
    {
        try
        {
        BLLLmsMsgPriorityType objbll = new BLLLmsMsgPriorityType();
        DataTable dt = new DataTable();

        dt = objbll.LmsMsgPriorityTypeSelectAll();
        objBase.FillDropDown(dt, ddlPriority, "PriorityType_ID", "PriorityTypeDesc");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    // =================================== Filter Section ===================================================
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {

            if (ViewState["countries"] != null)
            {
                DataTable dt = (DataTable)ViewState["countries"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (ddlFilter.SelectedValue)
                {
                    case "1":
                        {
                            strFilter = "Convert([HDComplaint_ID], 'System.String') LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case "2":
                        {
                            //strFilter = "Convert([PriorityType_ID], 'System.String') LIKE '%" + txtFilter.Text.Trim() + "%'";
                            strFilter = "PriorityTypeDesc like '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case "3":
                        {
                            //strFilter = "Convert([HD_Complaint_Status_ID], 'System.String') LIKE '%" + txtFilter.Text.Trim() + "%'";
                            strFilter = "ComplaintStatus like '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvComplaints.DataSource = dv;
                ViewState["countries"] = dv.ToTable();
                gvComplaints.DataBind();
                gvComplaints.SelectedIndex = -1;
                pan_Feedback.Attributes.CssStyle.Add("display", "none");

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtFilter.Text = "";
            ddlFilter.SelectedIndex = 0;

            ResetFilter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        ResetFilter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void ResetFilter()
    {
        try
        {
        ViewState["countries"] = null;
        bindgrid();
        gvComplaints.SelectedIndex = -1;
        pan_Feedback.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void txtFilter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            btnFilter_Click(null, null);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    //=======================================================================================================

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
        pan_Feedback.Attributes.CssStyle.Add("display", "inline");
        pan_New.Attributes.CssStyle.Add("display", "none");
        ImageButton btn = (ImageButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvComplaints.SelectedIndex = gvr.RowIndex;
        complaintID = Convert.ToInt32(btn.CommandArgument);
        ViewState["ComplaintID"] = complaintID;
        BindSolutionsGrid(complaintID);
        FilterComplaintsByID(complaintID);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindSolutionsGrid(int complaintID)
    {
        try
        {
        objCompSol.HDComplaint_ID = complaintID;
        dtFeedback = objCompSol.TCS_HlpDskCompSolutionSelectByComplaintId(objCompSol);
        ViewState["SolGrid"] = dtFeedback;


        if (dtFeedback.Rows.Count == 0)
            lab_SolStatus.Visible = true;
        else
        {
            gvSolutions.DataSource = dtFeedback;
            ViewState["SolGrid"] = dtFeedback;
            lab_SolStatus.Visible = false;
            pan_Feedback.Visible = true;
        }
        gvSolutions.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    //======================= Solutions Grid Methods =======================================================
    protected void gvSolutions_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable oDataSet = (DataTable)ViewState["countries"];
            oDataSet.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();
            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            bindgrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSolutions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSolutions.PageIndex = e.NewPageIndex;
            BindSolutionsGrid(Convert.ToInt32(ViewState["ComplaintID"]));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSolutions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            /*ImageButton ib = (ImageButton)e.Row.FindControl("ImageButton2");
            ib.Attributes.Add("onclick", "javascript:return " +
            "confirm('Are you sure you want to delete this complaint?') ");

            //LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");*/

            //TextBox txtFeedBack = (TextBox)e.Row.FindControl("txtFeedBack");
            if (e.Row.Cells[2].Text == "True")
            {
                e.Row.Enabled = false;
            }
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSolutions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            ViewState["mode"] = "Edit";
            ViewState["EditID"] = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[0].Text;
            error.Visible = false;
            //pnlFeedback.Attributes.CssStyle.Add("display", "inline");

            but_save.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnSaveFB_Click(object sender, EventArgs e)
    {
        try
        {
            string mode = Convert.ToString(ViewState["mode"]);
            int id = 0;

            DataRow row = (DataRow)Session["rightsRow"];

            objBll.Region_ID = Convert.ToInt32(row["Region_Id"].ToString());
            objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
            objBll.HDSubCat_ID = Convert.ToInt32(ddlCompCatg.SelectedValue);
            objBll.ComplaintTitle = txtTitle.Text;
            objBll.HDComplaintDesc = txtDescription.Text;
            objBll.HD_Complaint_Status_ID = 1;//Pending 
            objBll.PriorityType_ID = Convert.ToInt32(ddlPriority.SelectedValue);
            objBll.CreatedOn = DateTime.Now;
            objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);
            objBll.ModifiedOn = DateTime.Now;
            objBll.ModifiedBy = Convert.ToInt32(Session["ContactID"]);


            int nAlreadyIn;
            if (mode != "Edit")
            {
                /*nAlreadyIn = objBll.TCS_HlpDskComplaintBoxInsert(objBll);               
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                error.Visible = false;
                ImpromptuHelper.ShowPrompt("Complaint has been registered sucessfully.");*/
            }
            else
            {
                objBll.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
                nAlreadyIn = objBll.TCS_HlpDskComplaintBoxUpdate(objBll);

                //if (nAlreadyIn != 0)
                //{
                //ImpromptuHelper.ShowPrompt("Menu already exists in the selected location.");
                //}
                //else
                //{
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_Feedback.Attributes.CssStyle.Add("display", "none");
                error.Visible = false;
                ImpromptuHelper.ShowPrompt("Complaint has been updated sucessfully.");
                //}
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnCancelFB_Click(object sender, EventArgs e)
    {

    }

    protected void btnAddFB_Click(object sender, EventArgs e)
    {
        try
        {
        string strEmailMsg = "";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        TextBox txtFeedBack = (TextBox)gvr.FindControl("txtFeedBack");
        CheckBox chkResolved = (CheckBox)gvr.FindControl("chkResolved");
        solutionID = Convert.ToInt32(btn.CommandArgument);
        objCompSol.HDCompSol_ID = solutionID;
        objCompSol.Feedback = txtFeedBack.Text;
        objCompSol.IsClear = chkResolved.Checked;
        objCompSol.FeedBackOn = DateTime.Now;
        objCompSol.FeedBackBy = Convert.ToInt32(Session["ContactID"]);
        objCompSol.TCS_HlpDskCompSolutionUpdate(objCompSol);
        //gvr.Enabled = false;
        BindSolutionsGrid(Convert.ToInt32(ViewState["ComplaintID"]));
        //========================= Sending Email for Complaints ========================================
        if (chkResolved.Checked)
        {
            //DataRow row = (DataRow)Session["rightsRow"];
            //strEmailMsg = "Dear Sir,<br><br>Complaint # " + gvr.Cells[1].Text + " by Campus '" + row["center_name"].ToString() + "' has been resolved.";
            //strEmailMsg += "<br><br><b>Feedback by NWA :</b>" + txtFeedBack.Text;
            //strEmailMsg += "<br><br><b>Note:</b><i>This is a system generated message. Please do not reply directly to this message.</i>";
            ////objEmail.SendEmail("tsshomisbah@thesmartschools.edu.pk", "Help Desk Complaint Resolved", strEmailMsg);
            //objEmail.SendEmail(2, "Help Desk Complaint Resolved", strEmailMsg, "Help desk Notification");

        }

        //===============================================================================================

        ImpromptuHelper.ShowPrompt("Your feedback has been submitted.");
        pan_Feedback.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void EnableDisableControls(int mode)
    {
        switch (mode)
        {
            case 0:
                {
                    ddlCompCatg.Enabled = false;
                    ddlPriority.Enabled = false;
                    txtTitle.Enabled = false;
                    txtDescription.Enabled = false;
                    break;
                }

            case 1:
                {
                    ddlCompCatg.Enabled = true;
                    ddlPriority.Enabled = true;
                    txtTitle.Enabled = true;
                    txtDescription.Enabled = true;
                    break;
                }
        }
    }


    protected void FilterComplaintsByID(int _id)
    {
        try
        {
        if (ViewState["countries"] != null)
        {
            DataTable dt = (DataTable)ViewState["countries"];
            DataView dv;
            dv = dt.DefaultView;
            string strFilter = "";
            strFilter = "Convert([HDComplaint_ID], 'System.String') LIKE '%" + _id.ToString() + "%'";
            dv.RowFilter = strFilter;
            gvComplaints.DataSource = dv;
            ViewState["countries"] = dv.ToTable();
            gvComplaints.DataBind();

        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }






    
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "inline");
            pan_Feedback.Attributes.CssStyle.Add("display", "none");
            //pan_New.Enabled = true;
            EnableDisableControls(1);

            ViewState["mode"] = "Add";
            ResetControls();

            error.Visible = false;
            gvComplaints.SelectedRowStyle.Reset();

            //Reset Controls
            ddlCompCatg.SelectedValue = "0";
            ddlPriority.SelectedValue = "0";
            txtTitle.Text = "";
            txtDescription.Text = "";
            but_save.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            txtFilter.Text = "";
            ddlFilter.SelectedIndex = 0;

            ResetFilter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}

