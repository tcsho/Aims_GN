using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_ResultIssuanceDate : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLIssuanceDate bllIssuanceDate = new BLLIssuanceDate();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnIssuanceSubmit.Visible = false;
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            ResultIssue.Visible = false;
            Applied.Visible = false;
            NotApplied.Visible = false;
            btnSaveDateApplied.Visible = false;


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (IsPostBack) return;
        {
            try
            {
                // ======== Page Access Settings ========================//
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //  ====== End Page Access settings ======================//
                FillSessions();
                FillClassGroup();
                FillTerm();

                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }

    private void BindIssuanceDateGrid()
    {
        try
        {
            bllIssuanceDate.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
            bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            gv_IssuanceDate.DataSource = null;
            gv_IssuanceDate.DataBind();
            var dt = bllIssuanceDate.GetListofIssuanceDates(bllIssuanceDate.TermGroup_Id, bllIssuanceDate.Session_Id);
            gv_IssuanceDate.DataSource = dt;
            gv_IssuanceDate.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void FillPool()
    {
        try
        {
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
            DataTable dt = new DataTable();
            obj.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
            dt = obj.AdmTestQuestionsPoolFetch(obj.AdmTestDetail_Id);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void OnRowDeletingAppliedGrid(object sender, GridViewDeleteEventArgs e)
    {
        bllIssuanceDate.ResultIssueDateId = Convert.ToInt32(grdIssuanceDateApplied.DataKeys[e.RowIndex].Values[0]);
        int k = bllIssuanceDate.ResultCardIssuanceDateDetailClassCenterDelete(bllIssuanceDate);
        int i = bllIssuanceDate.DeleteAppliedCenter(bllIssuanceDate.ResultIssueDateId);
        if (i == 0)
        {
            grdIssuanceDateAppliedBindGrid();
            BindGrid();
            ResultIssue.Visible = true;
            Applied.Visible = true;
            NotApplied.Visible = true;
            btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
            return;
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int deleteR = Convert.ToInt32(gv_IssuanceDate.DataKeys[e.RowIndex].Values[0]);
        if (deleteR > 0)
        {
            bllIssuanceDate.deleterR = deleteR;
            int k = bllIssuanceDate.checkIdExistinAppliedCenters(bllIssuanceDate);
            if (k == 0)
            {
                bllIssuanceDate.DeleteIssuanceDate(deleteR);
                grdIssuanceDateAppliedBindGrid();
                ResultIssue.Visible = true;
                btnSaveDateApplied.Visible = true;
                btnIssuanceSubmit.Visible = true;
                BindIssuanceDateGrid();
                ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
                return;
            }
            else
            {
                ResultIssue.Visible = true;
                grdIssuanceDateAppliedBindGrid();
                Applied.Visible = true;
                btnIssuanceSubmit.Visible = true;
                ImpromptuHelper.ShowPrompt("Please Delete Child Record first, from the List of Result Date Applied Campuses!");
                return;
            }
        }

    }

    protected void FillSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            foreach (DataRow r in dt.Rows)
            {
                if (r["Status_Id"].ToString() != "1") continue;
                ddlSession.SelectedValue = r["Session_Id"].ToString();
                break;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void FillClassGroup()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = bllIssuanceDate.SelectAllClassGroups();
            objBase.FillDropDown(dt, ddlClassGroup, "ClassGroupId", "ClassGroupName");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void FillTerm()
    {
        try
        {
            var term = new DALEvaluation_Criteria_Type();
            var eve = new BLLEvaluation_Criteria_Type();
            var dataTable = term.Evaluation_Criteria_TypeSelect(eve);
            objBase.FillDropDown(dataTable, dllTerm, "TermGroup_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public void BindGrid()
    {
        try
        {
            if (Session["RptIssuanceId"] != null)
            {
                BLLIssuanceDate obj = new BLLIssuanceDate();
                obj.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
                obj.Session_Id = Convert.ToInt32(ddlSession.Text);


                obj.ResultIssueDateId = Convert.ToInt32(Session["RptIssuanceId"].ToString());

                gvTest.DataSource = null;
                gvTest.DataBind();
                DataTable dt = new DataTable();
                dt = bllIssuanceDate.GetListofCampusClass(obj);
                gvTest.DataSource = dt;
                gvTest.DataBind();
                ViewState["Data"] = dt;

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvIssuanceDate_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_IssuanceDate.Rows.Count > 0)
            {
                gv_IssuanceDate.UseAccessibleHeader = false;
                gv_IssuanceDate.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void grdIssuanceDateApplied_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (grdIssuanceDateApplied.Rows.Count > 0)
            {
                grdIssuanceDateApplied.UseAccessibleHeader = false;
                grdIssuanceDateApplied.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public void grdIssuanceDateAppliedBindGrid()
    {
        try
        {
            grdIssuanceDateApplied.DataSource = null;
            grdIssuanceDateApplied.DataBind();
            DataTable dt = new DataTable();
            bllIssuanceDate.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
            bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.Text);

            dt = bllIssuanceDate.getAllDatAppliedCneterClasses(bllIssuanceDate);
            grdIssuanceDateApplied.DataSource = dt;
            grdIssuanceDateApplied.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvTest.Rows.Count > 0)
            {
                gvTest.UseAccessibleHeader = false;
                gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public void AddIssuanceDate(object sender, EventArgs e)
    {
        try
        {
            var button = (Button)(sender);
            if (button.Text == "Add")
            {
                bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.Text);
                bllIssuanceDate.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
                bllIssuanceDate.ResultDesc = txtDescription.Text;
                bllIssuanceDate.ClassGroupId = Convert.ToInt32(ddlClassGroup.Text);
                bllIssuanceDate.ResultDate = Convert.ToDateTime(txtIssuanceDate.Text);
                bllIssuanceDate.CreatedOn = DateTime.Now;
                bllIssuanceDate.ModifedOn = DateTime.Now;

                bllIssuanceDate.Status_Id = 1;

                var k = bllIssuanceDate.AddIssuanceDate(bllIssuanceDate);

                if (k > 0)
                {

                    BindIssuanceDateGrid();
                    ResultIssue.Visible = true;
                    btnIssuanceSubmit.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record added successfuly!");
                    return;
                }
            }
            else
            {
                bllIssuanceDate.ResultIssueDateId = Convert.ToInt32(Session["updateId"]);
                bllIssuanceDate.ResultDesc = txtDescription.Text;
                bllIssuanceDate.ResultDate = Convert.ToDateTime(txtIssuanceDate.Text);
                bllIssuanceDate.ModifedOn = DateTime.Now;
                var k = bllIssuanceDate.UpdateIssuanceDateMaster(bllIssuanceDate);
                if (k == 0)
                {
                    BindIssuanceDateGrid();
                    ResultIssue.Visible = true;
                    btnIssuanceSubmit.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record updated successfuly!");
                    return;
                }
            }

            //upModal.Update();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

    }

    // popup model for form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ResultIssue.Visible = true;
        btnIssuanceSubmit.Visible = true;
        var btn = (Button)sender;
        lblModalTitle.Text = "Add Result Date";
        if (btn.Text == "Update")
        {
            var argument = ((Button)sender).CommandArgument;
            string[] words = argument.Split(';');
            DateTime date = DateTime.Parse(words[2]);
            Session["updateId"] = words[0];
            txtDescription.Text = words[1];
            if (ddlClassGroup.Items.Count > 1)
            {
                ddlClassGroup.SelectedValue = words[3];
            }
            else
            {
                ddlClassGroup.SelectedIndex = 0;
            }
            txtIssuanceDate.Text = date.ToString("yyyy-MM-dd");
            btnAddIssuanceDate.Text = "Update";
        }
        else
        {
            btnAddIssuanceDate.Text = "Add";
            txtIssuanceDate.Text = "";
            txtDescription.Text = "";
            ddlClassGroup.SelectedIndex = 0;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();
    }

    protected void ddlTermGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dllTerm.Text == "0")
        {
            ResultIssue.Visible = false;
            btnIssuanceSubmit.Visible = false;
        }
        else
        {
            ResultIssue.Visible = true;
            btnIssuanceSubmit.Visible = true;
            BindGrid();
            BindIssuanceDateGrid();
            grdIssuanceDateAppliedBindGrid();
        }
    }

    protected void IssuanceDateApplyToCenter(object sender, EventArgs e)
    {
        try
        {
            Session["RptIssuanceId"] = ((Button)sender).CommandArgument;
            ResultIssue.Visible = true;
            Applied.Visible = true;
            NotApplied.Visible = true;
            btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            BindGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void DateAppliedOnCampuses(object sender, EventArgs e)
    {
        try
        {
            int k = 0;
            foreach (GridViewRow row in gvTest.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkCenter");
                if (check.Checked)
                {
                    bllIssuanceDate.Center_Id = Convert.ToInt32(row.Cells[3].Text);
                    bllIssuanceDate.ResultIssueDateId = Convert.ToInt32(Session["RptIssuanceId"]);
                    k = bllIssuanceDate.AddCenterIssuanceDate(bllIssuanceDate);
                    //int p = bllIssuanceDate.ResultCardIssuanceDateDetailClassCenterInsert(bllIssuanceDate);

                }
            }
            if (k > 0)
            {
                ImpromptuHelper.ShowPrompt("Issuance date applied on selected center class!");
                BindGrid();
                //BindIssuanceDateGrid();
                grdIssuanceDateAppliedBindGrid();
                ResultIssue.Visible = true;
                Applied.Visible = true;
                NotApplied.Visible = true;
                btnSaveDateApplied.Visible = true;
            }
            btnIssuanceSubmit.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}