using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_StudentVerification : System.Web.UI.Page
{
    BLLStudent objstudent = new BLLStudent();
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
    protected void gvStudents_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudents.Rows.Count > 0)
            {
                gvStudents.UseAccessibleHeader = false;
                gvStudents.HeaderRow.TableSection = TableRowSection.TableHeader;

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
            if (Session["isClassTeacher"].ToString() == "1")
            {

                objstudent.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                DataTable dt = objstudent.Student_VerificatioSelect(objstudent);
                if (dt.Rows.Count > 0)
                {
                    ViewState["Data"] = dt;
                    gvStudents.DataSource = dt;
                    gvStudents.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnaddStudent_Click(object sender, EventArgs e)
    {
        try
        {

            if (ViewState["Data"] != null && gvStudents.Rows.Count > 0)
            {
                GridViewRow existing = gvStudents.Rows[0];
                DataTable dt = (DataTable)ViewState["Data"];
                DataRow r = dt.NewRow();
                r["Student_Id"] = "0";
                r["name"] = "0";
                r["Session_Id"] = existing.Cells[0].Text;
                r["Region_Id"] = existing.Cells[1].Text;
                r["Center_Id"] = existing.Cells[2].Text;
                r["Class_Id"] = existing.Cells[3].Text;
                r["Section_Id"] = existing.Cells[4].Text;
                r["Region_Name"] = existing.Cells[10].Text;
                r["Center_Name"] = existing.Cells[11].Text;
                r["Class_Name"] = existing.Cells[12].Text;
                r["Section_Name"] = existing.Cells[13].Text;
                r["isVerified"] = 0;

                dt.Rows.Add(r);
                gvStudents.DataSource = dt;
                gvStudents.DataBind();
                btnaddStudent.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void txtStdName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            TextBox txtname = (TextBox)currentRow.FindControl("txtStdName");
            TextBox txtId = (TextBox)currentRow.FindControl("txtStdId");
            txtname.Focus();
            txtname.AutoPostBack = true;
            if (txtId.Text.All(char.IsDigit) == false)
            {
                ImpromptuHelper.ShowPrompt("Student Number is numeric");
                return;
            }
            if (txtId.Text == "0" || String.IsNullOrEmpty(txtId.Text))
            {
                ImpromptuHelper.ShowPrompt("Please add Student Number");
                return;
            }
            if (txtname.Text == "0" || String.IsNullOrEmpty(txtname.Text))
            {
                ImpromptuHelper.ShowPrompt("Please add Student Name");
                return;
            }
            objstudent.Student_Id = Convert.ToInt32(txtId.Text);
            objstudent.fullname = txtname.Text;
            objstudent.Region_Id = Convert.ToInt32(currentRow.Cells[1].Text);
            objstudent.Center_Id = Convert.ToInt32(currentRow.Cells[2].Text);
            objstudent.Grade_Id = Convert.ToInt32(currentRow.Cells[3].Text);
            objstudent.Section_Id = Convert.ToInt32(currentRow.Cells[4].Text);
            objstudent.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            int k = objstudent.StudentVerificationInsert(objstudent);
            btnaddStudent.Enabled = true;
            if (k == 1)
                ImpromptuHelper.ShowPrompt("Student Added in the list!");
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;
            objstudent.Student_Id = Convert.ToInt32(currentRow.Cells[8].Text);
            objstudent.fullname = currentRow.Cells[9].Text;
            objstudent.Region_Id = Convert.ToInt32(currentRow.Cells[1].Text);
            objstudent.Center_Id = Convert.ToInt32(currentRow.Cells[2].Text);
            objstudent.Grade_Id = Convert.ToInt32(currentRow.Cells[3].Text);
            objstudent.Section_Id = Convert.ToInt32(currentRow.Cells[4].Text);
            objstudent.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            int k = objstudent.StudentVerificationInsert(objstudent);
            if (k == 1)
            {
                //ImpromptuHelper.ShowPrompt("Student Added in the list!");
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            //ImpromptuHelper.ShowPrompt("Student Added in the list!");
            BindGrid();
            btnaddStudent.Enabled = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}