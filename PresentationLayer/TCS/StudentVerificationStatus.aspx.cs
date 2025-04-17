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
                var user = Session["User_Name"].ToString();
                bool isEnable = false;
                DateTime now = DateTime.Now;

                if (user == "Finance-CR")
                {
                    var startDate = new DateTime(now.Year, now.Month, 10);
                    var endDate = new DateTime(now.Year, now.Month, 16);

                    isEnable = Between(now, startDate, endDate);
                }
                else
                {
                    var startDate = new DateTime(now.Year, now.Month, 5);
                    var endDate = new DateTime(now.Year, now.Month, 11);

                    isEnable = Between(now, startDate, endDate);
                }
                EnableDisableGrid(isEnable);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public static bool Between(DateTime input, DateTime date1, DateTime date2)
    {
        return (input > date1 && input < date2);
    }
    public void EnableDisableGrid(bool isEnable)
    {
        gvUnidentifiedStudent.Enabled = isEnable;
        gvUnReconciledStudent.Enabled = isEnable;
        gvNonCompliant.Enabled = isEnable;
    }
    public void BindGrid()
    {
        try
        {
            objstudent.CenterId = Convert.ToInt32(Session["Center_Id"].ToString());
            objteacher.CenterId = Convert.ToInt32(Session["Center_Id"].ToString());
            objstudent.RegionId = Convert.ToInt32(Session["RegionId"].ToString());
            objteacher.RegionId = Convert.ToInt32(Session["RegionId"].ToString());

            DataTable dtUnidentified = null;
            dtUnidentified = objstudent.CenterWiseUnidentifiedStudents(objstudent);
            DataTable dtUnReconciled = null;
            dtUnReconciled = objstudent.CenterWiseUnReconciledStudents(objstudent);
            DataTable dtNonCompliant = null;
            dtNonCompliant = objteacher.CenterWiseNonCompliantTeachers(objteacher);

            if (dtUnidentified.Rows.Count > 0)
            {
                notFoundUnidentifiedStudents.Visible = false;
                ViewState["gvUnidentifiedStudent"] = dtUnidentified;
                gvUnidentifiedStudent.DataSource = dtUnidentified;
                gvUnidentifiedStudent.DataBind();
            }

            if (dtUnReconciled.Rows.Count > 0)
            {
                notFoundUnreconciledStudents.Visible = false;
                ViewState["gvUnReconciledStudent"] = dtUnReconciled;
                gvUnReconciledStudent.DataSource = dtUnReconciled;
                gvUnReconciledStudent.DataBind();
            }

            if (dtNonCompliant.Rows.Count > 0)
            {
                notFoundNonCompliantTeachers.Visible = false;
                ViewState["gvNonCompliant"] = dtNonCompliant;
                gvNonCompliant.DataSource = dtNonCompliant;
                gvNonCompliant.DataBind();
            }

            if (dtUnidentified.Rows.Count == 0)
            {
                //btnAddUnidentifiedStudentsRemarks.Visible = false;
                notFoundUnidentifiedStudents.Visible = true;
            }

            if (dtUnReconciled.Rows.Count == 0)
            {
                //btnAddUnreconciledStudentsRemarks.Visible = false;
                notFoundUnreconciledStudents.Visible = true;
            }

            if (dtNonCompliant.Rows.Count == 0)
            {
                //btnAddNonCompliantTeachersRemarks.Visible = false;
                notFoundNonCompliantTeachers.Visible = true;
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
            DropDownList ddlUnidentified = null;
            DropDownList ddlUnidenChangesERP = null;
            TextBox txtDescription = null;
            TextBox txtStudentId = null;
            Label lblStdId = null;
            int StudentId = 0;
            var user = Session["User_Name"].ToString();
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            int Id = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[7].Text);
            int Student_Verification_Id = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[12].Text);
            ddlUnidentified = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidentified");
            ddlUnidenChangesERP = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidenChangesERP");
            txtDescription = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");
            txtStudentId = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtStdRowId");
            lblStdId = (Label)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("lblStudentId");

            if (!txtStudentId.Visible)
            {
                StudentId = Convert.ToInt32(lblStdId.Text);
            }
            else
            {
                if (txtStudentId.Text.All(char.IsDigit) == false || txtStudentId.Text == "")
                {
                    ImpromptuHelper.ShowPromptGeneric("Student Number is numeric", 0);
                    return;
                }
                else
                {
                    StudentId = Convert.ToInt32(txtStudentId.Text);
                }
            }

            if (ddlUnidentified.SelectedValue == "" || ddlUnidenChangesERP.SelectedValue == "" || txtDescription.Text == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Student ERP number, Remarks, Changes made in ERP, Description are mandatory.", 0);
            }
            else
            {
                objstudent.Id = Id;
                objstudent.Student_Verification_Id = Student_Verification_Id;
                objstudent.StudentId = StudentId;
                objstudent.Remarks = ddlUnidentified.SelectedValue;
                objstudent.Description = txtDescription.Text;
                objstudent.ChangeMadeERP = ddlUnidenChangesERP.SelectedValue;
                objstudent.ModifiedBy = user;
                objstudent.AddStudentVerificationRemarks(objstudent);
                ImpromptuHelper.ShowPrompt("Unidentified Student Remarks Updated Successfully.");
            }
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
            DropDownList ddlUnreconciled = null;
            DropDownList ddlUnreconChangesERP = null;
            TextBox txtDescription = null;

            var user = Session["User_Name"].ToString();
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            int StudentId = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[2].Text);
            int Id = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[6].Text);
            int Student_Verification_Id = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[11].Text);
            ddlUnreconciled = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconciled");
            ddlUnreconChangesERP = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconChangesERP");
            txtDescription = (TextBox)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

            if (ddlUnreconciled.SelectedValue == "" || ddlUnreconChangesERP.SelectedValue == "" || txtDescription.Text == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Remarks, Changes made in ERP, Description are mandatory.", 0);
            }
            else
            {
                objstudent.Id = Id;
                objstudent.Student_Verification_Id = Student_Verification_Id;
                objstudent.StudentId = StudentId;
                objstudent.Remarks = ddlUnreconciled.SelectedValue;
                objstudent.Description = txtDescription.Text;
                objstudent.ChangeMadeERP = ddlUnreconChangesERP.SelectedValue;
                objstudent.ModifiedBy = user;
                objstudent.AddStudentVerificationRemarks(objstudent);
                ImpromptuHelper.ShowPrompt("Unreconciled Student Remarks Updated Successfully.");
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
            DropDownList ddlNonCompliant = null;
            DropDownList ddlNonCompChangesERP = null;
            TextBox txtDescription = null;

            var user = Session["User_Name"].ToString();
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            int Id = Convert.ToInt32(gvNonCompliant.Rows[clickedRow.RowIndex].Cells[6].Text);
            ddlNonCompliant = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompliant");
            ddlNonCompChangesERP = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompChangesERP");
            txtDescription = (TextBox)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("txtDescription");

            if (ddlNonCompliant.SelectedValue == "" || ddlNonCompChangesERP.SelectedValue == "" || txtDescription.Text == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Remarks, Changes made in ERP, Description are mandatory.", 0);
            }
            else
            {
                objteacher.Id = Id;
                objteacher.Remarks = ddlNonCompliant.SelectedValue;
                objteacher.Description = txtDescription.Text;
                objteacher.ChangeMadeERP = ddlNonCompChangesERP.SelectedValue;
                objteacher.ModifiedBy = user;
                objteacher.AddNonCompliantTeachersRemarks(objteacher);
                ImpromptuHelper.ShowPrompt("NonCompliant Teacher Remarks Updated Successfully.");
            }
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

    //protected void btnApproveUnidentified_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlUnidentified = null;
    //    DropDownList ddlUnidenChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnidentified");
    //    btnReject = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnidentified");
    //    ddlUnidentified = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidentified");
    //    ddlUnidenChangesERP = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidenChangesERP");
    //    txtDescription = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlUnidentified.SelectedValue == "" || ddlUnidenChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Approved";
    //        ddlUnidentified.Enabled = false;
    //        ddlUnidenChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }
    //}

    //protected void btnRejectUnidentified_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlUnidentified = null;
    //    DropDownList ddlUnidenChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvUnidentifiedStudent.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnidentified");
    //    btnReject = (Button)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnidentified");
    //    ddlUnidentified = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidentified");
    //    ddlUnidenChangesERP = (DropDownList)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnidenChangesERP");
    //    txtDescription = (TextBox)gvUnidentifiedStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlUnidentified.SelectedValue == "" || ddlUnidenChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Reject";
    //        ddlUnidentified.Enabled = false;
    //        ddlUnidenChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }        
    //}

    //protected void btnApproveUnreconciled_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlUnreconciled = null;
    //    DropDownList ddlUnreconChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnreconciled");
    //    btnReject = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnreconciled");
    //    ddlUnreconciled = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconciled");
    //    ddlUnreconChangesERP = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconChangesERP");
    //    txtDescription = (TextBox)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlUnreconciled.SelectedValue == "" || ddlUnreconChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Approved";
    //        ddlUnreconciled.Enabled = false;
    //        ddlUnreconChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }        
    //}

    //protected void btnRejectUnreconciled_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlUnreconciled = null;
    //    DropDownList ddlUnreconChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvUnReconciledStudent.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnApproveUnreconciled");
    //    btnReject = (Button)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("btnRejectUnreconciled");
    //    ddlUnreconciled = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconciled");
    //    ddlUnreconChangesERP = (DropDownList)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("ddlUnreconChangesERP");
    //    txtDescription = (TextBox)gvUnReconciledStudent.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlUnreconciled.SelectedValue == "" || ddlUnreconChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Reject";
    //        ddlUnreconciled.Enabled = false;
    //        ddlUnreconChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }        
    //}

    //protected void btnApproveNonCompliant_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlNonCompliant = null;
    //    DropDownList ddlNonCompChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvNonCompliant.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnApproveNonCompliant");
    //    btnReject = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnRejectNonCompliant");
    //    ddlNonCompliant = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompliant");
    //    ddlNonCompChangesERP = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompChangesERP");
    //    txtDescription = (TextBox)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlNonCompliant.SelectedValue == "" || ddlNonCompChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Approved";
    //        ddlNonCompliant.Enabled = false;
    //        ddlNonCompChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }        
    //}

    //protected void btnRejectNonCompliant_Click(object sender, EventArgs e)
    //{
    //    Label roRemarkslabel = null;
    //    Button btnApprove = null;
    //    Button btnReject = null;
    //    DropDownList ddlNonCompliant = null;
    //    DropDownList ddlNonCompChangesERP = null;
    //    TextBox txtDescription = null;

    //    GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
    //    int studentId = Convert.ToInt32(gvNonCompliant.Rows[clickedRow.RowIndex].Cells[1].Text);

    //    roRemarkslabel = (Label)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("RORemarks");
    //    btnApprove = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnApproveNonCompliant");
    //    btnReject = (Button)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("btnRejectNonCompliant");
    //    ddlNonCompliant = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompliant");
    //    ddlNonCompChangesERP = (DropDownList)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("ddlNonCompChangesERP");
    //    txtDescription = (TextBox)gvNonCompliant.Rows[clickedRow.RowIndex].FindControl("txtDescription");

    //    if (ddlNonCompliant.SelectedValue == "" || ddlNonCompChangesERP.SelectedValue == "" || txtDescription.Text == "")
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("There is no value selected for reason", 0);
    //    }
    //    else
    //    {
    //        roRemarkslabel.Text = "Reject";
    //        ddlNonCompliant.Enabled = false;
    //        ddlNonCompChangesERP.Enabled = false;
    //        txtDescription.Enabled = false;
    //        btnApprove.Visible = false;
    //        btnReject.Visible = false;
    //    }        
    //}

    //protected void gvUnidentifiedStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    TextBox txtStudentId = null;

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        txtStudentId = (TextBox)e.Row.FindControl("txtStdRowId");
    //        txtStudentId.Text = e.Row.Cells[2].Text.ToString();
    //        //if (e.Row.Cells[2].Text.ToString() == null || e.Row.Cells[2].Text.ToString() == "0")
    //        //{
    //        //    txtStudentId.Visible = false;
    //        //}
    //        //else
    //        //{
                
    //        //}
    //    }
    //}

    //protected void gvUnReconciledStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    Label roRemarks;
    //    Button btnApproveUnreconciled;
    //    Button btnRejectUnreconciled;
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        roRemarks = (Label)e.Row.FindControl("RORemarks");
    //        btnApproveUnreconciled = (Button)e.Row.FindControl("btnApproveUnreconciled");
    //        btnRejectUnreconciled = (Button)e.Row.FindControl("btnRejectUnreconciled");

    //        if (e.Row.Cells[10].Text.ToString() == null || e.Row.Cells[10].Text.ToString() == "0")
    //        {
    //            //btnApproveUnreconciled.Visible = true;
    //            //btnRejectUnreconciled.Visible = true;
    //            roRemarks.Visible = false;
    //        }
    //        else if(e.Row.Cells[10].Text.ToString() == "Approved" || e.Row.Cells[10].Text.ToString() == "Reject")
    //        {
    //            btnApproveUnreconciled.Visible = false;
    //            btnRejectUnreconciled.Visible = false;
    //        }
    //        else
    //        {
    //            roRemarks.Text = e.Row.Cells[10].Text.ToString();
    //            //btnApproveUnreconciled.Visible = false;
    //            //btnRejectUnreconciled.Visible = false;
    //        }


    //    }
    //}

    //protected void gvdtNonCompliantTeachers_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    Label roRemarks;
    //    Button btnApproveNonCompliant;
    //    Button btnRejectNonCompliant;
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        roRemarks = (Label)e.Row.FindControl("RORemarks");
    //        btnApproveNonCompliant = (Button)e.Row.FindControl("btnApproveNonCompliant");
    //        btnRejectNonCompliant = (Button)e.Row.FindControl("btnRejectNonCompliant");

    //        if (e.Row.Cells[10].Text.ToString() == null || e.Row.Cells[10].Text.ToString() == "0")
    //        {
    //            //btnApproveUnreconciled.Visible = true;
    //            //btnRejectUnreconciled.Visible = true;
    //            roRemarks.Visible = false;
    //        }
    //        else if (e.Row.Cells[10].Text.ToString() == "Approved" || e.Row.Cells[10].Text.ToString() == "Reject")
    //        {
    //            btnApproveNonCompliant.Visible = false;
    //            btnRejectNonCompliant.Visible = false;
    //        }
    //        else
    //        {
    //            roRemarks.Text = e.Row.Cells[10].Text.ToString();
    //            //btnApproveUnreconciled.Visible = false;
    //            //btnRejectUnreconciled.Visible = false;
    //        } 
    //    }
    //}    
}