using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TcsHlpDsk : System.Web.UI.Page
{
    BLLTCS_HlpDskComplaintBox objBll = new BLLTCS_HlpDskComplaintBox();
    BLLTCS_HlpDskCompSolution objCompSol = new BLLTCS_HlpDskCompSolution();
    DALBase objBase = new DALBase();
    DataTable dtFeedback = new DataTable();
    int complaintID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
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
                Response.Redirect("~/login.aspx", false);
            }

            //====== End Page Access settings ======================

            pan_New.Attributes.CssStyle.Add("display", "none");
            pan_Feedback.Attributes.CssStyle.Add("display", "none");

            ViewState["SortDirection"] = "ASC";
            ViewState["mode"] = "Add";
            loadOrg(sender, e);

            //DataRow row = (DataRow)Session["rightsRow"];

            if (row["User_Type"].ToString() != "SAdmin")
            {
                ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                ddl_MOrg_SelectedIndexChanged(sender, e);
                loadRegions();
            }

            bindgrid();
            FillResources();
        }
    }

    protected void bindgrid()
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];

            objBll.Status_Id = 1;
            //objBll.Center_ID = Convert.ToInt32(row.Center_Id);

            DataTable _dt = new DataTable();
            if (ViewState["countries"] == null)
                _dt = objBll.TCS_HlpDskComplaintBoxSelectAll();
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
            ResetFilter();
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




            objBll.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
            objBll.HD_Resource_ID = Convert.ToInt32(ddlResource.SelectedValue);



            objBll.ModifiedOn = DateTime.Now;
            objBll.DueDate = Convert.ToDateTime(txtDueDate.Text);
            objBll.AssignerRemarks = txtRemarks.Text;


            int nAlreadyIn;
            if (mode != "Edit")
            {
                nAlreadyIn = objBll.TCS_HlpDskComplaintBoxUpdateResource(objBll);

                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                //error.Visible = false;
                BindSolutionsGrid(Convert.ToInt32(ViewState["EditID"]));
                ImpromptuHelper.ShowPrompt("Selected resource has been assigned for this query.");

            }
            else
            {
                objBll.HDComplaint_ID = Convert.ToInt32(ViewState["EditID"]);
                nAlreadyIn = objBll.TCS_HlpDskComplaintBoxUpdateResource(objBll);
                ViewState["countries"] = null;
                bindgrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
                // error.Visible = false;
                ImpromptuHelper.ShowPrompt("Modifications saved successfully.");

            } ViewState["countries"] = null;
            bindgrid();
            ResetFilter();
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
        catch (Exception oException)
        {
            throw oException;
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


    }

    protected void but_new_Click1(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "inline");
            pan_Feedback.Attributes.CssStyle.Add("display", "none");
            ViewState["mode"] = "Add";
            ResetControls();

            //error.Visible = false;
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
            //ddlResource.SelectedValue = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[14].Text;
            //txtDueDate.Text = this.gvComplaints.Rows[e.NewSelectedIndex].Cells[11].Text;

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

                    case "4":
                        {
                            //strFilter = "Convert([HD_Complaint_Status_ID], 'System.String') LIKE '%" + txtFilter.Text.Trim() + "%'";
                            strFilter = "EmployeeCode like '%" + txtFilter.Text.Trim() + "%'";
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
            ddl_region.SelectedValue = "0";
            list_center.SelectedValue = "0";
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

            FilterComplaintsByID(complaintID);
            BindSolutionsGrid(complaintID);
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
            {
                //lab_SolStatus.Visible = true;
            }
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

            //error.Visible = false;
            gvComplaints.SelectedRowStyle.Reset();

            //Reset Controls        
            //txtDescription.Text = "";

            but_save.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            BLLTCS_HlpDskComplaintBox objBllr = new BLLTCS_HlpDskComplaintBox();

            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvComplaints.SelectedIndex = gvr.RowIndex;
            ViewState["EditID"] = btn.CommandArgument;
            int _id = Convert.ToInt32(ViewState["EditID"].ToString());
            FilterComplaintsByID(_id);
            but_new_Click1(sender, e);
            pan_New.Visible = true;
            if (list_center.SelectedIndex > 0)
                objBllr.Center_ID = Convert.ToInt32(list_center.SelectedValue);
            else
                objBllr.Center_ID = 0;
            DataTable dtr = objBllr.TCS_HlpDskComplaintBoxSelectResourceCenterIDROType(objBllr);
            ddlResource.Enabled = true;
            if (!String.IsNullOrEmpty(gvr.Cells[4].Text))
                ddlResource.SelectedValue = gvr.Cells[4].Text;
            else
                ddlResource.SelectedIndex = 0;
            txtDueDate.Text = gvr.Cells[5].Text != "&nbsp;" ? gvr.Cells[5].Text : "";
            txtRemarks.Text = gvr.Cells[6].Text != "&nbsp;" ? gvr.Cells[6].Text : "";

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void FillResources()
    {
        try
        {
            DataTable dt = new DataTable();
            BLLTCS_HlpDskResource objBll = new BLLTCS_HlpDskResource();
            dt = objBll.TCS_HlpDskResourceSelectAll();
            //////////////objBase.FillDropDown(dt, ddlResource, "HD_Resource_ID", "EmployeeCode");

            objBase.FillDropDown(dt, ddlResource, "HD_Resource_ID", "EmployeeName");
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
            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            list_center.Items.Clear();
            list_center.Items.Add(new ListItem("Select", "0"));

            loadRegions();
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

            list_center.Items.Clear();
            list_center.Items.Add(new ListItem("Select", "0"));

            loadCenter();
            ResetFilter();
            FilterByLocation(1);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_center_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            ResetFilter();
            FilterByLocation(3);
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

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
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
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, list_center, "Center_Id", "Center_Name");
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

            objBase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");
            if (ddl_country.Items.Count > 0)
            {
                ddl_country.SelectedIndex = ddl_country.Items.Count - 1;
                ddl_country_SelectedIndexChanged(this, EventArgs.Empty);
            }
            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            list_center.Items.Clear();
            list_center.Items.Add(new ListItem("Select", "0"));

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
                objBase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
            }
            ddl_country.Items.Clear();
            ddl_country.Items.Add(new ListItem("Select", "0"));

            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));


            list_center.Items.Clear();
            list_center.Items.Add(new ListItem("Select", "0"));
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

    protected void FilterByLocation(int locationType)
    {
        try
        {
            if (ViewState["countries"] != null)
            {
                DataTable dt = (DataTable)ViewState["countries"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (locationType)
                {
                    case 1://Region
                        {
                            strFilter = "Convert([Region_ID], 'System.String') LIKE '%" + ddl_region.SelectedValue.Trim() + "%'";
                            break;
                        }

                    case 3://Center
                        {
                            strFilter = "Convert([Center_ID], 'System.String') LIKE '%" + list_center.SelectedValue.Trim() + "%'";
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
    protected void txtDueDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtDueDate.Text != "")
            {
                if (Convert.ToDateTime(txtDueDate.Text) < DateTime.Today)
                {
                    txtDueDate.Text = "";
                    ImpromptuHelper.ShowPrompt("Due date can not be less than today's date.");

                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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

}

