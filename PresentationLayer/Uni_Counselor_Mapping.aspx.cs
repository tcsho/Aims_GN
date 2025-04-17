using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_Uni_Counselor_Mapping : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLUniCounselorMapping BLLCU = new BLLUniCounselorMapping();

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
            //Applied.Visible = false;
            //NotApplied.Visible = false;
            //btnSaveDateApplied.Visible = false;


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
                FillUniddl();
                FillCounselorddl();
                //FillTerm();


                //*********************************
                ResultIssue.Visible = true;
                btnIssuanceSubmit.Visible = true;
                BindMappingGrid();

                //*********************************


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

    private void BindMappingGrid()
    {
        try
        {
            //BLLCU.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
            BLLCU.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            gv_uni_coun.DataSource = null;
            gv_uni_coun.DataBind();
            var dt = BLLCU.GetList( BLLCU.Session_Id);
            gv_uni_coun.DataSource = dt;
            gv_uni_coun.DataBind();
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
        //BLLUniCounselorMapping.ResultIssueDateId = Convert.ToInt32(grdIssuanceDateApplied.DataKeys[e.RowIndex].Values[0]);
        int k = BLLCU.ResultCardIssuanceDateDetailClassCenterDelete(BLLCU);
        int i = BLLCU.DeleteAppliedCenter(BLLCU.ResultIssueDateId);
        if (i == 0)
        {
            grdIssuanceDateAppliedBindGrid();
            BindGrid();
            ResultIssue.Visible = true;
            //Applied.Visible = true;
            //NotApplied.Visible = true;
            //btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
            return;
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int deleteR = Convert.ToInt32(gv_uni_coun.DataKeys[e.RowIndex].Values[0]);
        if (deleteR > 0)
        {
            BLLCU.deleterR = deleteR;
            //int k = BLLCU.checkIdExistinAppliedCenters(BLLCU);
            //if (k == 0)
            //{
                BLLCU.InActivatemapping(deleteR);
                grdIssuanceDateAppliedBindGrid();
                ResultIssue.Visible = true;
                //btnSaveDateApplied.Visible = true;
                btnIssuanceSubmit.Visible = true;
                BindMappingGrid();
                ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
                return;
            //}
            //else
            //{
            //    ResultIssue.Visible = true;
            //    grdIssuanceDateAppliedBindGrid();
            //   // Applied.Visible = true;
            //    btnIssuanceSubmit.Visible = true;
            //    ImpromptuHelper.ShowPrompt("Please Delete Child Record first, from the List of Result Date Applied Campuses!");
            //    return;
            //}
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

    protected void FillUniddl()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = BLLCU.SelectAllCentersNames();
            objBase.FillDropDown(dt, ddlcenters, "Center_Id", "Center_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void FillCounselorddl()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = BLLCU.SelectAllCounselorsNames();
            objBase.FillDropDown(dt, ddlcounselor, "USER_ID", "First_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    //protected void FillTerm()
    //{
    //    try
    //    {
    //        var term = new DALEvaluation_Criteria_Type();
    //        var eve = new BLLEvaluation_Criteria_Type();
    //        var dataTable = term.Evaluation_Criteria_TypeSelect(eve);
    //        objBase.FillDropDown(dataTable, dllTerm, "TermGroup_Id", "Type");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}

    public void BindGrid()
    {
        try
        {
            //if (Session["RptIssuanceId"] != null)
            //{
            //    BLLUniCounselorMapping obj = new BLLUniCounselorMapping();
            //    obj.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
            //    obj.Session_Id = Convert.ToInt32(ddlSession.Text);


            //    obj.ResultIssueDateId = Convert.ToInt32(Session["RptIssuanceId"].ToString());

            //    //gvTest.DataSource = null;
            //    //gvTest.DataBind();
            //    DataTable dt = new DataTable();
            //    dt = BLLCU.GetListofCampusClass(obj);
            //    //gvTest.DataSource = dt;
            //    //gvTest.DataBind();
            //    ViewState["Data"] = dt;

            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_uni_coun_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_uni_coun.Rows.Count > 0)
            {
                gv_uni_coun.UseAccessibleHeader = false;
                gv_uni_coun.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        //try
        //{
        //    if (grdIssuanceDateApplied.Rows.Count > 0)
        //    {
        //        grdIssuanceDateApplied.UseAccessibleHeader = false;
        //        grdIssuanceDateApplied.HeaderRow.TableSection = TableRowSection.TableHeader;

        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }

    public void grdIssuanceDateAppliedBindGrid()
    {
        //try
        //{
        //   // grdIssuanceDateApplied.DataSource = null;
        //   // grdIssuanceDateApplied.DataBind();
        //    DataTable dt = new DataTable();
        //    BLLCU.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
        //    BLLCU.Session_Id = Convert.ToInt32(ddlSession.Text);

        //    dt = BLLCU.getAllDatAppliedCneterClasses(BLLCU);
        //   // grdIssuanceDateApplied.DataSource = dt;
        //   // grdIssuanceDateApplied.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }

    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        //try
        //{
        //    if (gvTest.Rows.Count > 0)
        //    {
        //        gvTest.UseAccessibleHeader = false;
        //        gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
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

    public void AddMapping(object sender, EventArgs e)
    {
        try
        {
            var button = (Button)(sender);
            if (button.Text == "Add")
            {
                BLLCU.Uc_Uni_Fk = Convert.ToInt32(ddlcenters.SelectedValue);
                BLLCU.Uc_Coun_Fk = Convert.ToInt32(ddlcounselor.SelectedValue);
                BLLCU.IsActive = true;
                BLLCU.Status_Id = 1;
                BLLCU.AddTag = Session["ContactID"].ToString();
                //BLLCU.TermGroup_Id = Convert.ToInt32(dllTerm.Text);
                // BLLCU.ResultDesc = txtDescription.Text;
                //BLLCU.ClassGroupId = Convert.ToInt32(ddlcenters.Text);
               // BLLCU.ResultDate = Convert.ToDateTime(txtIssuanceDate.Text);
                //BLLCU.CreatedOn = DateTime.Now;
                //BLLCU.ModifedOn = DateTime.Now;

                //BLLCU.Status_Id = 1;

                var k = BLLCU.AddUniCounMapping(BLLCU);

                if (k > 0)
                {

                    BindMappingGrid();
                    ResultIssue.Visible = true;
                    btnIssuanceSubmit.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record added successfuly!");
                    return;
                }
            }
            else
            {
                BLLCU.ResultIssueDateId = Convert.ToInt32(Session["updateId"]);
                //BLLCU.ResultDesc = txtDescription.Text;
                //BLLCU.ResultDate = Convert.ToDateTime(txtIssuanceDate.Text);
                BLLCU.ModifedOn = DateTime.Now;
                var k = BLLCU.UpdateIssuanceDateMaster(BLLCU);
                if (k == 0)
                {
                    BindMappingGrid();
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
        lblModalTitle.Text = "Add University & Counselor Mapping";
        if (btn.Text == "Update")
        {
            var argument = ((Button)sender).CommandArgument;
            string[] words = argument.Split(';');
            DateTime date = DateTime.Parse(words[2]);
            Session["updateId"] = words[0];
           // txtDescription.Text = words[1];
            if (ddlcenters.Items.Count > 1)
            {
                ddlcenters.SelectedValue = words[3];
            }
            else
            {
                ddlcenters.SelectedIndex = 0;
            }
            //txtIssuanceDate.Text = date.ToString("yyyy-MM-dd");
            btnAddMapping.Text = "Update";
        }
        else
        {
            btnAddMapping.Text = "Add";
           // txtIssuanceDate.Text = "";
           // txtDescription.Text = "";
            ddlcenters.SelectedIndex = 0;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSession.Text == "0")
        {
            ResultIssue.Visible = false;
            btnIssuanceSubmit.Visible = false;

        }
        else
        {
            ResultIssue.Visible = true;
            btnIssuanceSubmit.Visible = true;
            BindGrid();
            BindMappingGrid();
            grdIssuanceDateAppliedBindGrid();
        }
    }

    protected void IssuanceDateApplyToCenter(object sender, EventArgs e)
    {
        try
        {
            Session["RptIssuanceId"] = ((Button)sender).CommandArgument;
            ResultIssue.Visible = true;
            //Applied.Visible = true;
            //NotApplied.Visible = true;
            //btnSaveDateApplied.Visible = true;
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
            //foreach (GridViewRow row in gvTest.Rows)
            //{
            //    CheckBox check = (CheckBox)row.FindControl("chkCenter");
            //    if (check.Checked)
            //    {
            //        BLLUniCounselorMapping.Center_Id = Convert.ToInt32(row.Cells[3].Text);
            //        BLLUniCounselorMapping.ResultIssueDateId = Convert.ToInt32(Session["RptIssuanceId"]);
            //        k = BLLUniCounselorMapping.AddCenterIssuanceDate(BLLUniCounselorMapping);
            //        int p = BLLUniCounselorMapping.ResultCardIssuanceDateDetailClassCenterInsert(BLLUniCounselorMapping);

            //    }
            //}
            if (k > 0)
            {
                ImpromptuHelper.ShowPrompt("Issuance date applied on selected center class!");
                BindGrid();
                //BindMappingGrid();
                grdIssuanceDateAppliedBindGrid();
                ResultIssue.Visible = true;
                //Applied.Visible = true;
               // NotApplied.Visible = true;
                //btnSaveDateApplied.Visible = true;
            }
            btnIssuanceSubmit.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}