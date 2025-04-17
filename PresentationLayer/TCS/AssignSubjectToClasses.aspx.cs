using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_AssignSubjectToClasses : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLIssuanceDate bllIssuanceDate = new BLLIssuanceDate();
    BllAssignSubjectToClass subject = new BllAssignSubjectToClass();


    protected void Page_Load(object sender, EventArgs e)
    {
        //  btnIssuanceSubmit.Visible = false;
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            //ResultIssue.Visible = false;
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
                BindIssuanceDateGrid();


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
            gv_IssuanceDate.DataSource = null;
            gv_IssuanceDate.DataBind();
            subject.Status_Id = 1;
            var dt = subject.GetAllSubjects(subject);
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
            ResultIssue.Visible = true;
            Applied.Visible = true;
            btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int deleteR = Convert.ToInt32(gv_IssuanceDate.DataKeys[e.RowIndex].Values[0]);
        if (deleteR <= 0) return;
        bllIssuanceDate.deleterR = deleteR;
        var k = bllIssuanceDate.checkIdExistinAppliedCenters(bllIssuanceDate);
        if (k == 0)
        {
            bllIssuanceDate.DeleteIssuanceDate(deleteR);
            grdIssuanceDateAppliedBindGrid();
            ResultIssue.Visible = true;
            btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            BindIssuanceDateGrid();
            ImpromptuHelper.ShowPrompt("Record deleted successfuly!");
        }
        else
        {
            ResultIssue.Visible = true;
            grdIssuanceDateAppliedBindGrid();
            Applied.Visible = true;
            btnIssuanceSubmit.Visible = true;
            ImpromptuHelper.ShowPrompt("Please Delete Child Record first, from the List of Result Date Applied Campuses!");
        }
    }




    protected void gvIssuanceDate_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_IssuanceDate.Rows.Count <= 0) return;
            gv_IssuanceDate.UseAccessibleHeader = false;
            gv_IssuanceDate.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            if (grdIssuanceDateApplied.Rows.Count <= 0) return;
            grdIssuanceDateApplied.UseAccessibleHeader = false;
            grdIssuanceDateApplied.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            subject.Status_Id = 1;
            subject.Subject_Id = Convert.ToInt32(Session["Subject_Id"]);
            var dt = subject.GetAllClasses(subject);
            grdIssuanceDateApplied.DataSource = dt;

            grdIssuanceDateApplied.DataBind();

            foreach (GridViewRow row in grdIssuanceDateApplied.Rows)
            {
                var accessType = row.Cells[4].Text;
                var access = accessType.Replace("&nbsp;", "");
                if (access == "") continue;
                var chbx = row.FindControl("chkclass") as CheckBox;
                if (chbx != null) chbx.Checked = true;
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

    public void AddNewSubject(object sender, EventArgs e)
    {
        try
        {
            var button = (Button)(sender);
            if (button.Text == "Add")
            {
                subject.Subject_Code = txtcode.Text;
                subject.Comments = txtcomments.Text;
                subject.Status_Id = 1;
                subject.Subject_Name = txtname.Text;
                var k = subject.AddNewSubject(subject);
                if (k <= 0) return;
                BindIssuanceDateGrid();
                ResultIssue.Visible = true;
                btnIssuanceSubmit.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                ImpromptuHelper.ShowPrompt("Record added successfuly!");
            }
            else
            {
                subject.Subject_Id = Convert.ToInt32(Session["Subject_Id"]);
                subject.Comments = txtcomments.Text;
                subject.Subject_Name = txtname.Text;
                subject.Subject_Code = txtcode.Text;
                var k = subject.UpdateSubject(subject);
                if (k != 1) return;
                BindIssuanceDateGrid();
                ResultIssue.Visible = true;
                btnIssuanceSubmit.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                ImpromptuHelper.ShowPrompt("Record updated successfuly!");
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
        lblModalTitle.Text = "Add Subjects";
        if (btn.Text == "Update")
        {
            var argument = ((Button)sender).CommandArgument;
            string[] words = argument.Split(';');
            Session["Subject_Id"] = Convert.ToInt32(words[0]);
            txtname.Text = words[1];
            txtcode.Text = words[2];
            txtcomments.Text = words[3];
            btnAddIssuanceDate.Text = "Update";
        }
        else
        {
            txtcode.Text = "";
            txtname.Text = "";
            txtcomments.Text = "";
            btnAddIssuanceDate.Text = "Add";
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();
    }



    protected void IssuanceDateApplyToCenter(object sender, EventArgs e)
    {
        try
        {
            Session["Subject_Id"] = ((Button)sender).CommandArgument;
            ResultIssue.Visible = true;
            grdIssuanceDateAppliedBindGrid();
            btnSaveDateApplied.Visible = true;
            btnIssuanceSubmit.Visible = true;
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
            foreach (GridViewRow row in grdIssuanceDateApplied.Rows)
            {
                var id = row.Cells[4].Text;
                var subjectId = id.Replace("&nbsp;", "");
                if (subjectId == "")
                {
                    CheckBox check = (CheckBox)row.FindControl("chkclass");
                    if (check.Checked)
                    {
                        subject.Class_ID = Convert.ToInt32(row.Cells[0].Text);
                        subject.Subject_ID = Convert.ToInt32(Session["Subject_Id"]);
                        subject.Status_Id = 1;
                        subject.OrderofSubject = 1;
                        k = subject.AddClassSubject(subject);
                    }
                }
                else
                {
                    CheckBox check = (CheckBox)row.FindControl("chkclass");
                    if (check.Checked == false)
                    {
                        subject.Status_Id = 2;
                        subject.Class_Subject_Id = Convert.ToInt32(row.Cells[5].Text);
                        k = subject.UpdateClassSubject(subject);
                    }              
                }
            }
            if (k > 0)
            {
                ImpromptuHelper.ShowPrompt("Record updated!");
                grdIssuanceDateAppliedBindGrid();
                ResultIssue.Visible = true;
                Applied.Visible = true;
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