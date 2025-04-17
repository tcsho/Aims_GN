using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_TcsHlpDskResourceView : System.Web.UI.Page
{
    BLLTCS_HlpDskComplaintBox objBll = new BLLTCS_HlpDskComplaintBox();
    BLLTCS_HlpDskCompSolution objCompSol = new BLLTCS_HlpDskCompSolution();
    DALBase objBase = new DALBase();
    DataTable dtFeedback = new DataTable();
    int complaintID = 0;
    int resourceID = 0;
    BLLTCS_HlpDskResource objres = new BLLTCS_HlpDskResource();

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
        }
    }

    protected void bindgrid()
    {
        try
        {
        DataRow row = (DataRow)Session["rightsRow"];

        objBll.Status_Id = 1;
        //objBll.Center_ID = Convert.ToInt32(row.Center_Id);

        //objBll.HD_Resource_ID = 1;//to be updated
        DataTable _dt = new DataTable();

        string aaa = Session["EmployeeCode"].ToString();
        string bbbb = Session["ContactID"].ToString();
        //=============================
        if (Session["ContactID"].ToString() != "0")
        {
            objres.EmployeeCode = Session["ContactID"].ToString();
            _dt = objres.TCS_HlpDskResourceIDSelectByEmployeeCode(objres);
            if (_dt.Rows.Count > 0)
            {
                resourceID = Convert.ToInt32(_dt.Rows[0]["HD_Resource_ID"]);
            }
        }
        objBll.HD_Resource_ID = resourceID;

        //////////objBll.HD_Resource_ID = Convert.ToInt32(Session["ContactID"].ToString());

        //=============================

        _dt = new DataTable();

        if (ViewState["countries"] == null)
            _dt = objBll.TCS_HlpDskComplaintBoxSelectByResourceID(objBll);
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

            DataRow row = (DataRow)Session["rightsRow"];

            objCompSol.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
            //objCompSol.HDComplaint_ID = complaintID;
            objCompSol.SolutionRemarks = txtDescription.Text;
            objCompSol.SolutionOn = DateTime.Now;
            objCompSol.SolutionBy = Convert.ToInt32(Session["ContactID"]);
            //objCompSol.HD_Resource_ID = 1;// *To be updated
            DataTable _dt = new DataTable();
            //=============================
            if (Session["ContactID"].ToString() != "0")
            {
                objres.EmployeeCode = Session["ContactID"].ToString();
                _dt = objres.TCS_HlpDskResourceIDSelectByEmployeeCode(objres);
                if (_dt.Rows.Count > 0)
                {
                    resourceID = Convert.ToInt32(_dt.Rows[0]["HD_Resource_ID"]);
                }
            }
            objCompSol.HD_Resource_ID = resourceID;

            //=============================

            BLLTCS_HlpDskResource ObjHR = new BLLTCS_HlpDskResource();
            ObjHR.EmployeeCode = Session["ContactID"].ToString();
            DataTable dt = ObjHR.TCS_HlpDskResourceIDSelectByEmployeeCode(ObjHR);

            if (dt.Rows.Count > 0)
            {
                objCompSol.HD_Resource_ID = Convert.ToInt32(dt.Rows[0]["HD_Resource_ID"].ToString());// *To be updated
            }
            else
            {
                objCompSol.HD_Resource_ID = 1;// *To be updated
            }

            int nAlreadyIn;
            if (mode != "Edit")
            {
                nAlreadyIn = objCompSol.TCS_HlpDskCompSolutionInsert(objCompSol);

                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                //error.Visible = false;
                BindSolutionsGrid(Convert.ToInt32(ViewState["EditID"]));
                ImpromptuHelper.ShowPrompt("Solution has been submitted sucessfully.");

            }
            else
            {
                objCompSol.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
                nAlreadyIn = objCompSol.TCS_HlpDskCompSolutionUpdate(objCompSol);
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                //error.Visible = false;
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    /*ImageButton ib = (ImageButton)e.Row.FindControl("ImageButton2");
        //    ib.Attributes.Add("onclick", "javascript:return " +
        //    "confirm('Are you sure you want to delete this complaint?') ");

        //    //LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");*/

        //    if (e.Row.Cells[10].Text != "&nbsp;")
        //    {
        //        if (Convert.ToDateTime(e.Row.Cells[10].Text) == DateTime.Today || DateTime.Today > Convert.ToDateTime(e.Row.Cells[10].Text))
        //        {
        //            e.Row.ForeColor = System.Drawing.Color.Red;
        //        }
        //    }

        //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_new_Click1(object sender, EventArgs e)
    {

        try
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        //pan_Feedback.Attributes.CssStyle.Add("display", "none");
        ViewState["mode"] = "Add";
        ResetControls();

        //error.Visible = false;
        //gvComplaints.SelectedRowStyle.Reset();
        //Reset Controls       
        txtDescription.Text = "";
        but_save.Visible = true;
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
            ViewState["EditID"] = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[0].Text;

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
            String fltertype = ddlFilter.SelectedValue;
            FilterSet(txtFilter.Text.Trim(),fltertype);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void FilterSet(string FilterText,string fltertype)
    {
        if (ViewState["countries"] != null)
        {
            DataTable dt = (DataTable)ViewState["countries"];
            DataView dv;
            dv = dt.DefaultView;
            string strFilter = "";
            switch (fltertype)
            {
                case "1":
                    {
                        strFilter = "Convert([HDComplaint_ID], 'System.String') LIKE '%" + FilterText + "%'";
                        break;
                    }

                case "2":
                    {
                        strFilter = "PriorityTypeDesc like '%" + FilterText+ "%'";
                        break;
                    }

                case "3":
                    {
                        strFilter = "ComplaintStatus like '%" + FilterText + "%'";
                        break;
                    }

            }
            dv.RowFilter = strFilter;
            gvComplaints.DataSource = dv;
            ViewState["countries"] = dv.ToTable();
            gvComplaints.DataBind();

            gvComplaints.SelectedIndex = -1;
            //pan_Feedback.Attributes.CssStyle.Add("display", "none");

        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFilter.Text = "";
        ddlFilter.SelectedIndex = 0;

        ResetFilter();
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
        ResetFilter();
        btnFilter_Click(null, null);

    }

    //=======================================================================================================

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
        pan_Feedback.Attributes.CssStyle.Add("display", "inline");
        pan_New.Attributes.CssStyle.Add("display", "none");
        pan_Feedback.Visible = true;
        ImageButton btn = (ImageButton)sender;

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvComplaints.SelectedIndex = gvr.RowIndex;
        complaintID = Convert.ToInt32(btn.CommandArgument);
        BindSolutionsGrid(complaintID);
        Literal ltrFeedBack;
        LinkButton btnAddSolution;
        GridViewRow gvrSol;
        if (gvSolutions.Rows.Count > 0)
        {
            btnAddFSoution.Visible = false;
            gvrSol = gvSolutions.Rows[gvSolutions.Rows.Count - 1];
            ltrFeedBack = (Literal)gvrSol.FindControl("ltrFeedBack");
            btnAddSolution = (LinkButton)gvrSol.FindControl("btnAddSolution");

            //if (ltrFeedBack.Text == "")
            //{
            //    btnAddSolution.Visible = false;
            //}
            //else
            //{
            //    btnAddSolution.Visible = gvrSol.Cells[5].Text == "True" ? false : true;
            //}
        }
        else
        {
            btnAddFSoution.Visible = true;
        }

        FilterSet(btn.CommandArgument, "1");

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
        ViewState["EditID"] = complaintID;

        dtFeedback = objCompSol.TCS_HlpDskCompSolutionSelectByComplaintId(objCompSol);
        ViewState["SolGrid"] = dtFeedback;


        if (dtFeedback.Rows.Count == 0)
            lab_SolStatus.Visible = true;
        else
        {
            gvSolutions.DataSource = dtFeedback;
            ViewState["SolGrid"] = dtFeedback;
            lab_SolStatus.Visible = false;
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
            if (ViewState["EditID"] != null)
            {
                gvSolutions.PageIndex = e.NewPageIndex;
                BindSolutionsGrid(Convert.ToInt32(ViewState["EditID"]));
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSolutions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            
        }*/
    }

    protected void gvSolutions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAddSolution_Click(object sender, EventArgs e)
    {
        try
        {
        LinkButton btn = (LinkButton)sender;
        complaintID = Convert.ToInt32(btn.CommandArgument);
        ViewState["EditID"] = complaintID;


        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        ResetControls();

       // error.Visible = false;
        gvComplaints.SelectedRowStyle.Reset();

        //Reset Controls        
        txtDescription.Text = "";
        but_save.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
    protected void gvSolution_PreRender(object sender, EventArgs e)
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





}

