using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_StudentVerificationStatus : System.Web.UI.Page
{
    BLLStudentVerificationStatus objstudent = new BLLStudentVerificationStatus();
    BLLNonCompliantTeacher objteacher = new BLLNonCompliantTeacher();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // ======== Page Access Settings ========================//
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
                Response.Redirect("~/login.aspx", false);
            }

            //====== End Page Access settings ======================//
            if (!IsPostBack)
            {
                BindGrid();
            }
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
            string s = Session["isClassTeacher"].ToString();
            var test = Session["UserType_Id"];

            objstudent.CenterId = Convert.ToInt32(Session["Center_Id"].ToString());
            objteacher.CenterId = Convert.ToInt32(Session["Center_Id"].ToString());
            objstudent.RegionId = Convert.ToInt32(Session["RegionId"].ToString());
            objteacher.RegionId = Convert.ToInt32(Session["RegionId"].ToString());
            DataTable dtUnidentified = objstudent.CenterWiseUnidentifiedStudents(objstudent);
            DataTable dtUnReconciled = objstudent.CenterWiseUnReconciledStudents(objstudent);
            DataTable dtNonCompliant = objteacher.CenterWiseNonCompliantTeachers(objteacher);
            if (dtUnidentified.Rows.Count > 0)
            {
                ViewState["gvUnidentifiedStudent"] = dtUnidentified;
                gvUnidentifiedStudent.DataSource = dtUnidentified;
                gvUnidentifiedStudent.DataBind();
            }

            if (dtUnReconciled.Rows.Count > 0)
            {
                ViewState["gvUnReconciledStudent"] = dtUnReconciled;
                gvUnReconciledStudent.DataSource = dtUnReconciled;
                gvUnReconciledStudent.DataBind();
            }

            if (dtNonCompliant.Rows.Count > 0)
            {
                ViewState["gvNonCompliant"] = dtNonCompliant;
                gvNonCompliant.DataSource = dtNonCompliant;
                gvNonCompliant.DataBind();
            }

            if (dtUnidentified.Rows.Count == 0)
            {
                btnAddUnidentifiedStudentsRemarks.Visible = false;
                UnidentifiedHeading.Visible = false;
            }

            if (dtUnReconciled.Rows.Count == 0)
            {

                gvUnReconciledStudent.Visible = false;
                UnreconciledHeading.Visible = false;
                btnAddUnreconciledStudentsRemarks.Visible = false;
            }

            if (dtNonCompliant.Rows.Count == 0)
            {

                gvNonCompliant.Visible = false;
                NonCompliantHeading.Visible = false;
                btnAddNonCompliantTeachersRemarks.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnAddUnidentifiedStudentsRemarks_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList coRemarks = null;
            DropDownList ChangeMadeERP = null;
            Label roRemarks = null;
            TextBox txtDesc = null;

            var user = Session["User_Name"].ToString();

            foreach (GridViewRow gvRow in gvUnidentifiedStudent.Rows)
            {
                coRemarks = (DropDownList)gvRow.FindControl("ddlUnidentified");
                roRemarks = (Label)gvRow.FindControl("RORemarks");
                ChangeMadeERP = (DropDownList)gvRow.FindControl("ddlUnidenChangesERP");
                txtDesc = (TextBox)gvRow.FindControl("txtDescription");

                objstudent.StudentId = Convert.ToInt32(gvRow.Cells[0].Text.ToString());
                objstudent.ClassId = Convert.ToInt32(gvRow.Cells[3].Text.ToString());
                objstudent.SectionId = Convert.ToInt32(gvRow.Cells[4].Text.ToString());
                objstudent.CenterId = Convert.ToInt32(gvRow.Cells[5].Text.ToString());
                objstudent.RegionId = Convert.ToInt32(gvRow.Cells[6].Text.ToString());
                objstudent.PMonth = gvRow.Cells[7].Text.ToString();
                objstudent.CORemarks = coRemarks.SelectedValue;
                objstudent.RORemarks = roRemarks.Text == "&nbsp;" ? "" : roRemarks.Text;
                objstudent.Description = txtDesc.Text;
                objstudent.ChangeMadeERP = ChangeMadeERP.SelectedValue;
                objstudent.CreatedBy = user;
                objstudent.ModifiedBy = user;
                objstudent.Status = "Unidentified";

                //if (!string.IsNullOrEmpty(coRemarks.Text))
                objstudent.AddStudentVerificationRemarks(objstudent);
            }

            ImpromptuHelper.ShowPrompt("Unidentified Students Remarks Updated Successfully.");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnAddUnreconciledStudentsRemarks_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList coRemarks = null;
            DropDownList ChangeMadeERP = null;
            Label roRemarks = null;
            TextBox txtDesc = null;

            var user = Session["User_Name"].ToString();

            foreach (GridViewRow gvRow in gvUnReconciledStudent.Rows)
            {
                coRemarks = (DropDownList)gvRow.FindControl("ddlUnreconciled");
                roRemarks = (Label)gvRow.FindControl("RORemarks");
                ChangeMadeERP = (DropDownList)gvRow.FindControl("ddlUnreconChangesERP");
                txtDesc = (TextBox)gvRow.FindControl("txtDescription");

                objstudent.StudentId = Convert.ToInt32(gvRow.Cells[0].Text.ToString());
                objstudent.ClassId = Convert.ToInt32(gvRow.Cells[3].Text.ToString());
                objstudent.SectionId = Convert.ToInt32(gvRow.Cells[4].Text.ToString());
                objstudent.CenterId = Convert.ToInt32(gvRow.Cells[5].Text.ToString());
                objstudent.RegionId = Convert.ToInt32(gvRow.Cells[6].Text.ToString());
                objstudent.PMonth = gvRow.Cells[7].Text.ToString();
                objstudent.CORemarks = coRemarks.SelectedValue;
                objstudent.RORemarks = roRemarks.Text == "&nbsp;" ? "" : roRemarks.Text;
                objstudent.Description = txtDesc.Text;
                objstudent.ChangeMadeERP = ChangeMadeERP.SelectedValue;
                objstudent.CreatedBy = user;
                objstudent.ModifiedBy = user;
                objstudent.Status = "Unreconciled";

                //if (!string.IsNullOrEmpty(coRemarks.Text))
                objstudent.AddStudentVerificationRemarks(objstudent);
            }

            ImpromptuHelper.ShowPrompt("Unreconciled Students Remarks Updated Successfully.");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvUnidentifiedStudent_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvUnidentifiedStudent.Rows.Count > 0)
            {
                gvUnidentifiedStudent.UseAccessibleHeader = false;
                gvUnidentifiedStudent.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvUnReconciledStudent_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvUnReconciledStudent.Rows.Count > 0)
            {
                gvUnReconciledStudent.UseAccessibleHeader = false;
                gvUnReconciledStudent.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvdtNonCompliantTeachers_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNonCompliant.Rows.Count > 0)
            {
                gvNonCompliant.UseAccessibleHeader = false;
                gvNonCompliant.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnAddNonCompliantTeachersRemarks_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList coRemarks = null;
            DropDownList ChangeMadeERP = null;
            Label roRemarks = null;
            TextBox txtDesc = null;

            var user = Session["User_Name"].ToString();

            foreach (GridViewRow gvRow in gvNonCompliant.Rows)
            {
                coRemarks = (DropDownList)gvRow.FindControl("ddlNonCompliant");
                roRemarks = (Label)gvRow.FindControl("RORemarks");
                ChangeMadeERP = (DropDownList)gvRow.FindControl("ddlNonCompChangesERP");
                txtDesc = (TextBox)gvRow.FindControl("txtDescription");

                objteacher.TeacherId = Convert.ToInt32(gvRow.Cells[0].Text.ToString());
                objteacher.ClassId = Convert.ToInt32(gvRow.Cells[3].Text.ToString());
                objteacher.SectionId = Convert.ToInt32(gvRow.Cells[4].Text.ToString());
                objteacher.CenterId = Convert.ToInt32(gvRow.Cells[5].Text.ToString());
                objteacher.RegionId = Convert.ToInt32(gvRow.Cells[6].Text.ToString());
                objteacher.PMonth = gvRow.Cells[7].Text.ToString();
                objteacher.CORemarks = coRemarks.SelectedValue;
                objteacher.RORemarks = roRemarks.Text == "&nbsp;" ? "" : roRemarks.Text;
                objteacher.Description = txtDesc.Text;
                objteacher.ChangeMadeERP = ChangeMadeERP.SelectedValue;
                objteacher.CreatedBy = user;
                objteacher.ModifiedBy = user;
                objteacher.Status = "NonCompliantTeacher";

                //if (!string.IsNullOrEmpty(coRemarks.Text))
                objteacher.AddNonCompliantTeachersRemarks(objteacher);
            }

            ImpromptuHelper.ShowPrompt("Non-Compliant Teachers Remarks Updated Successfully.");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnApproveUnidentified_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlUnidentified = null;
        DropDownList ddlUnidenChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnidentified");
        btnReject = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnidentified");
        ddlUnidentified = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidentified");
        ddlUnidenChangesERP = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidenChangesERP");
        txtDescription = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlUnidentified.SelectedValue == "" || ddlUnidenChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Approved";
            ddlUnidentified.Enabled = false;
            ddlUnidenChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }
    }

    protected void btnRejectUnidentified_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlUnidentified = null;
        DropDownList ddlUnidenChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnidentified");
        btnReject = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnidentified");
        ddlUnidentified = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidentified");
        ddlUnidenChangesERP = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidenChangesERP");
        txtDescription = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlUnidentified.SelectedValue == "" || ddlUnidenChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Reject";
            ddlUnidentified.Enabled = false;
            ddlUnidenChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }        
    }

    protected void btnApproveUnreconciled_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlUnreconciled = null;
        DropDownList ddlUnreconChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnreconciled");
        btnReject = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnreconciled");
        ddlUnreconciled = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconciled");
        ddlUnreconChangesERP = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconChangesERP");
        txtDescription = (TextBox)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlUnreconciled.SelectedValue == "" || ddlUnreconChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Approved";
            ddlUnreconciled.Enabled = false;
            ddlUnreconChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }        
    }

    protected void btnRejectUnreconciled_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlUnreconciled = null;
        DropDownList ddlUnreconChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnreconciled");
        btnReject = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnreconciled");
        ddlUnreconciled = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconciled");
        ddlUnreconChangesERP = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconChangesERP");
        txtDescription = (TextBox)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlUnreconciled.SelectedValue == "" || ddlUnreconChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Reject";
            ddlUnreconciled.Enabled = false;
            ddlUnreconChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }        
    }

    protected void btnApproveNonCompliant_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlNonCompliant = null;
        DropDownList ddlNonCompChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvNonCompliant.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnApproveNonCompliant");
        btnReject = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnRejectNonCompliant");
        ddlNonCompliant = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompliant");
        ddlNonCompChangesERP = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompChangesERP");
        txtDescription = (TextBox)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlNonCompliant.SelectedValue == "" || ddlNonCompChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Approved";
            ddlNonCompliant.Enabled = false;
            ddlNonCompChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }        
    }

    protected void btnRejectNonCompliant_Click(object sender, EventArgs e)
    {
        Label roRemarkslabel = null;
        Button btnApprove = null;
        Button btnReject = null;
        DropDownList ddlNonCompliant = null;
        DropDownList ddlNonCompChangesERP = null;
        TextBox txtDescription = null;

        GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
        int studentId = Convert.ToInt32(gvNonCompliant.Rows[clickedRow.RowIndex].Cells[0].Text);

        roRemarkslabel = (Label)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("RORemarks");
        btnApprove = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnApproveNonCompliant");
        btnReject = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnRejectNonCompliant");
        ddlNonCompliant = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompliant");
        ddlNonCompChangesERP = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompChangesERP");
        txtDescription = (TextBox)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("txtDescription");

        if (ddlNonCompliant.SelectedValue == "" || ddlNonCompChangesERP.SelectedValue == "" || txtDescription.Text == "")
        {
            ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
        }
        else
        {
            roRemarkslabel.Text = "Reject";
            ddlNonCompliant.Enabled = false;
            ddlNonCompChangesERP.Enabled = false;
            txtDescription.Enabled = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }        
    }

    protected void gvUnidentifiedStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label roRemarks;
        Button btnApproveUnidentified;
        Button btnRejectUnidentified;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            roRemarks = (Label)e.Row.FindControl("RORemarks");
            btnApproveUnidentified = (Button)e.Row.FindControl("btnApproveUnidentified");
            btnRejectUnidentified = (Button)e.Row.FindControl("btnRejectUnidentified");

            if (e.Row.Cells[8].Text.ToString() == null || e.Row.Cells[8].Text.ToString() == "0")
            {
                //btnApproveUnidentified.Visible = true;
                //btnRejectUnidentified.Visible = true;
                roRemarks.Visible = false;
            }
            {
                roRemarks.Text = e.Row.Cells[8].Text.ToString();
                //btnApproveUnidentified.Visible = false;
                //btnRejectUnidentified.Visible = false;
            } 
        }
    }
    protected void gvUnReconciledStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label roRemarks;
        Button btnApproveUnreconciled;
        Button btnRejectUnreconciled;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            roRemarks = (Label)e.Row.FindControl("RORemarks");
            btnApproveUnreconciled = (Button)e.Row.FindControl("btnApproveUnreconciled");
            btnRejectUnreconciled = (Button)e.Row.FindControl("btnRejectUnreconciled");

            if (e.Row.Cells[8].Text.ToString() == null || e.Row.Cells[8].Text.ToString() == "0")
            {
                //btnApproveUnreconciled.Visible = true;
                //btnRejectUnreconciled.Visible = true;
                roRemarks.Visible = false;
            }
            else if(e.Row.Cells[8].Text.ToString() == "Approved" || e.Row.Cells[8].Text.ToString() == "Reject")
            {
                btnApproveUnreconciled.Visible = false;
                btnRejectUnreconciled.Visible = false;
            }
            else
            {
                roRemarks.Text = e.Row.Cells[8].Text.ToString();
                //btnApproveUnreconciled.Visible = false;
                //btnRejectUnreconciled.Visible = false;
            }


        }
    }
    protected void gvdtNonCompliantTeachers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label roRemarks;
        Button btnApproveNonCompliant;
        Button btnRejectNonCompliant;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            roRemarks = (Label)e.Row.FindControl("RORemarks");
            btnApproveNonCompliant = (Button)e.Row.FindControl("btnApproveNonCompliant");
            btnRejectNonCompliant = (Button)e.Row.FindControl("btnRejectNonCompliant");

            if (e.Row.Cells[8].Text.ToString() == null || e.Row.Cells[8].Text.ToString() == "0")
            {
                //btnApproveUnreconciled.Visible = true;
                //btnRejectUnreconciled.Visible = true;
                roRemarks.Visible = false;
            }
            else if (e.Row.Cells[8].Text.ToString() == "Approved" || e.Row.Cells[8].Text.ToString() == "Reject")
            {
                btnApproveNonCompliant.Visible = false;
                btnRejectNonCompliant.Visible = false;
            }
            else
            {
                roRemarks.Text = e.Row.Cells[8].Text.ToString();
                //btnApproveUnreconciled.Visible = false;
                //btnRejectUnreconciled.Visible = false;
            } 
        }
    }    
}