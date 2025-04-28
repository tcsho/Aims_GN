using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
public partial class PresentationLayer_TCS_MonthlyStdVerification : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
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
                loadMonths();
             }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void loadMonths()
    {
        lblError.Text = "";
        try
        {
            //only for Class teachers
            if (Session["EmployeeCode"] != null && Session["isClassTeacher"].ToString() == "1" && Session["UserType_Id"].ToString() == "1")
            {

                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
                LoadMonthDb();

            }
            else if ((Session["UserType_Id"].ToString() == "3" || Session["UserType_Id"].ToString() == "5" || Session["UserType_Id"].ToString() == "4"))
            {
                objstudent.Employee_Id = 0;
                LoadMonthDb();
            }
            else
            {
                lblError.Text = "Only the class teachers are authorized to verify the students.";
                ImpromptuHelper.ShowPrompt("Only the class teachers are authorized to verify the students.");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
     
    private void LoadMonthDb()
    {
        DataTable dt = objstudent.StudentVerificationMonth(objstudent);
        if (dt.Rows.Count > 0)
        {
            btnaddStudent.Visible = true;
            objbase.FillDropDown(dt, ddlmonth, "MonthId", "MonthDesc");
           Session["ActiveDaysTable"] = dt;
        }
    }

    protected void gvStudents_PreRender(object sender, EventArgs e)
    {
        try
        {
            //if (gvStudents.Rows.Count > 0)
            //{
            //    gvStudents.UseAccessibleHeader = false;
            //    gvStudents.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvSections_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudents.Rows.Count > 0)
            {
                gvSections.UseAccessibleHeader = false;
                gvSections.HeaderRow.TableSection = TableRowSection.TableHeader;

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
            if (Session["isClassTeacher"].ToString() == "1")
            {

                objstudent.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                objstudent.Center_Id = 0;
                objstudent.Region_Id = 0;
                objstudent.Section_Id = Convert.ToInt32(Session["Section_Id"].ToString());

                gvStudents.Columns[11].Visible = true;
                gvStudents.Columns[12].Visible = true;
                gvStudents.Columns[14].Visible = false;
                gvStudents.Columns[17].Visible = false;
                btnaddStudent.Visible = true;
                btnLock.Visible = false;
            }
            else if ((Session["UserType_Id"].ToString() == "3"))
            {
                objstudent.Employee_Id = 0;
                objstudent.Center_Id = Convert.ToInt32(Session["cId"].ToString());
                objstudent.Region_Id = 0;
                objstudent.Section_Id = 0;

                gvStudents.Columns[11].Visible = false;
                gvStudents.Columns[12].Visible = false;
                gvStudents.Columns[14].Visible = true;
                gvStudents.Columns[17].Visible = false;
                btnaddStudent.Visible = false;
                btnLock.Visible = false;
            }
            else if ((Session["UserType_Id"].ToString() == "4"))
            {
                objstudent.Employee_Id = 0;
                objstudent.Center_Id = 0;
                objstudent.Region_Id = Convert.ToInt32(Session["RegionId"].ToString());
                objstudent.Section_Id = 0;

                gvStudents.Columns[11].Visible = false;
                gvStudents.Columns[12].Visible = false;
                gvStudents.Columns[14].Visible = true;
                gvStudents.Columns[17].Visible = true;
                btnaddStudent.Visible = false;
                btnLock.Visible = false;
            }
            else if ((Session["UserType_Id"].ToString() == "5"))
            {
                objstudent.Employee_Id = 0;
                objstudent.Center_Id = 0;
                objstudent.Region_Id = 0;
                objstudent.Section_Id = 0;

                gvStudents.Columns[11].Visible = false;
                gvStudents.Columns[12].Visible = false;
                gvStudents.Columns[14].Visible = true;

                gvStudents.Columns[17].Visible = false;
                btnaddStudent.Visible = false;
                btnLock.Visible = false;
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Student Verification is only available for Class teachers");
                return;
            }

            DataTable dt = new DataTable();
            if (ViewState["Data"] == null)
            {
                objstudent.MonthId = Convert.ToInt32(ddlmonth.SelectedValue.ToString());
                objstudent.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
                dt = objstudent.Student_VerificatioSelect(objstudent);
            }
            else
            {
                dt = (DataTable)ViewState["Data"];
            }

            if (dt.Rows.Count > 0)
            {
                ViewState["Data"] = dt;
                gvStudents.DataSource = dt;
                gvStudents.DataBind();
                divTeacher.Visible = true;
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
            string islock = "0"; 

            if (ViewState["Data"] != null && gvStudents.Rows.Count > 0)
            {
                GridViewRow existing = gvStudents.Rows[0];
                DataTable dt = (DataTable)ViewState["Data"];
                if (dt.Rows.Count > 0)
                {
                    islock = dt.Rows[0]["isLock"].ToString();
                }
                if (islock == "0")
                {
                    AddStudent.Visible = true;

                    DALBase objBase = new DALBase();
                    DataTable dtreson = objstudent.StudentVerificationReasonSelect(objstudent);
                    if (dtreson.Rows.Count > 0)
                    {
                        objBase.FillDropDown(dtreson, ddlReasonList, "AddReasonId", "ReasonDesc");
                    }
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Veification has been locked for this month");
                    return;
                }
            } 
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnLockStudent_Click(object sender, EventArgs e)
    {
        try
        {
            objstudent.MonthId = Convert.ToInt32(ddlmonth.SelectedValue.ToString());
            objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
            objstudent.Section_Id = Convert.ToInt32(Session["Section_Id"].ToString());
            objstudent.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            bool isLock = true;

            int k = objstudent.StudentVerificationMstInsert(objstudent, isLock);
            btnaddStudent.Enabled = false;
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnUnlockMgmt_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;

            gvSections.SelectedIndex = currentRow.RowIndex; 

            objstudent.MonthId = Convert.ToInt32(ddlmonth.SelectedValue.ToString());
            //objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
            objstudent.Section_Id = Convert.ToInt32(Session["Section_Id"].ToString());
            objstudent.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            if (Session["UserType_Id"].ToString() == "3")
            {
                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
            }
            if (Session["UserType_Id"].ToString() == "5")
            {
                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString()); //ro user_name is string so user_id is stored
            }

            bool isLock = false;
            int k = objstudent.StudentVerificationMstInsert(objstudent, isLock);
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnLockMgmt_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvSections.SelectedIndex = currentRow.RowIndex;
            objstudent.Student_VerificationMst_Id = Convert.ToInt32(btn.CommandArgument);
            objstudent.MonthId = Convert.ToInt32(ddlmonth.SelectedValue.ToString());
            if (Session["UserType_Id"].ToString() == "3")
            {
                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
            }
            if (Session["UserType_Id"].ToString() == "5")
            {
                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());//ro user_name is string so user_id is stored
            }

            bool isLock = true;
            int k = objstudent.StudentVerificationMstInsert(objstudent, isLock);
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteStudent_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;

            if (btn.CommandArgument != "0")
            {
                int Student_Verification_Id = Convert.ToInt32(btn.CommandArgument);
                StudentVerificationUpdate(Student_Verification_Id, false);

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void StudentVerificationUpdate(int Student_Verification_Id, bool isVerify)
    {

        objstudent.IsVerify = isVerify;
        objstudent.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());

        if (Student_Verification_Id != 0)
            objstudent.Student_Verification_Id = Student_Verification_Id;
        int k = objstudent.StudentVerificationUpdate(objstudent);
        if (k == 1)
        {
            ViewState["Data"] = null;
            BindGrid();
        }
    }

    protected void txtStdName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;

            //TextBox txtname = (TextBox)currentRow.FindControl("txtStdName");
            //TextBox txtId = (TextBox)currentRow.FindControl("txtStdId");
            //DropDownList ddlreason = (DropDownList)currentRow.FindControl("ddlReasonList");
            //TextBox txtTchRemarks = (TextBox)currentRow.FindControl("txtTeacherRemarks");  

            if (txtStdId.Text.All(char.IsDigit) == false)
            {
                ImpromptuHelper.ShowPrompt("Student Number is numeric");
                return;
            }

            if (txtStdName.Text == "0" || String.IsNullOrEmpty(txtStdName.Text))
            {
                ImpromptuHelper.ShowPrompt("Student Name is a must required field");
                return;
            }

            if (txtTeacherRemarks.Text == "0" || String.IsNullOrEmpty(txtTeacherRemarks.Text))
            {
                ImpromptuHelper.ShowPrompt("Teacher Remarks is a must required field");
                return;
            } 

            if (ddlReasonList.SelectedIndex < 0)
            {
                ImpromptuHelper.ShowPrompt("Please Select a reason to Add this student.");
                return;
            }

            if (txtStdId.Text == "0" || String.IsNullOrEmpty(txtStdId.Text))
                objstudent.Student_Id = null;
            else
                objstudent.Student_Id = Convert.ToInt32(txtStdId.Text);

            objstudent.fullname = txtStdName.Text;
            objstudent.IsAdded = true;
            objstudent.Student_VerificationMst_Id = Convert.ToInt32(ViewState["mst_Id"].ToString());
            objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
            objstudent.TeacherRemarks = txtTeacherRemarks.Text;
            objstudent.AddReasonId = Convert.ToInt32(ddlReasonList.SelectedValue);

            int k = objstudent.StudentVerificationInsert(objstudent);
            btnaddStudent.Enabled = true;
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Student Added in the list!");
                ResetControls();
                AddStudent.Visible = false;
            }
            else
                ImpromptuHelper.ShowPrompt("Student Already Exists in the list!");

            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void ResetControls()
    {
        txtStdId.Text = "";
        txtStdName.Text = "";
        txtTeacherRemarks.Text = "";
        ddlReasonList.SelectedIndex = 0;
    }

    protected void BtnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;

            if (btn.CommandArgument != "0")
            {
                int Student_Verification_Id = Convert.ToInt32(btn.CommandArgument);
                StudentVerificationUpdate(Student_Verification_Id, true);

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void BtnSchoolVerify_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;

            TextBox txtSchoolRemarks = (TextBox)currentRow.FindControl("txtSchoolRemarks");
            TextBox txtStudent_Id = (TextBox)currentRow.FindControl("txtStdRowId");


            if (txtStudent_Id.Text.Length < 1 && currentRow.Cells[2].Text == "0")
            {
                ImpromptuHelper.ShowPrompt("Please enter student ERP Number!");
            }
            else
            {
                if (txtStudent_Id.Text.All(char.IsDigit) == false)
                {
                    ImpromptuHelper.ShowPrompt("Student Number is numeric");
                    return;
                }

                if (txtSchoolRemarks.Text.Length > 0)
                {
                    int Student_Verification_Id = Convert.ToInt32(currentRow.Cells[5].Text);
                    objstudent.SchoolVerificationRemarks = txtSchoolRemarks.Text;
                    objstudent.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    if (Student_Verification_Id != 0)
                        objstudent.Student_Verification_Id = Student_Verification_Id;

                    if (currentRow.Cells[2].Text != "0")
                    {
                        objstudent.Student_Id = Convert.ToInt32(currentRow.Cells[2].Text);
                    }
                    else
                    {
                        objstudent.Student_Id = Convert.ToInt32(txtStudent_Id.Text);
                    }


                    int k = objstudent.StudentVerificationUpdateSchool(objstudent);
                    if (k == 1)
                    {
                        ViewState["Data"] = null;
                        BindGrid();
                        ImpromptuHelper.ShowPrompt("School Remarks Saved and Locked!");
                    } 
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please enter school remarks!");
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteReq_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;
            TextBox txtSchoolRemarks = (TextBox)currentRow.FindControl("txtSchoolRemarks");

            if (txtSchoolRemarks.Text.Length<1)
            {
                ImpromptuHelper.ShowPrompt("Please enter remarks to delete!");
                return;
            }


            int Student_Verification_Id = Convert.ToInt32(currentRow.Cells[5].Text);
            if (Student_Verification_Id != 0)
            {
                objstudent.Student_Verification_Id = Student_Verification_Id;
            }

            objstudent.isDeleteRequest = true;
            objstudent.DeleteRequestBy = Convert.ToInt32(Session["ContactID"].ToString());
            objstudent.SchoolVerificationRemarks = txtSchoolRemarks.Text;


            int k = objstudent.StudentVerificationDeleteRequest(objstudent);
            if (k == 1)
            {
                ViewState["Data"] = null;
                BindGrid();
                ImpromptuHelper.ShowPrompt("Student Delete Request Generated!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
     
    protected void btnDeleteApproval_Click(object sender, EventArgs e)
    {
        try
        {
            StudentDelete(sender,true, "Student Deleted!");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
     
    protected void btnDeleteReject_Click(object sender, EventArgs e)
    {
        try
        {
            StudentDelete(sender, false, "Student delete request Cancelled!");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void StudentDelete(object sender,bool _iddel,string _msg)
    {
        Button btn = (Button)(sender);
        GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
        gvStudents.SelectedIndex = currentRow.RowIndex;

        int Student_Verification_Id = Convert.ToInt32(currentRow.Cells[5].Text);
        if (Student_Verification_Id != 0)
        {
            objstudent.Student_Verification_Id = Student_Verification_Id;
        }
        objstudent.isDeleted = _iddel;
        objstudent.DeletedBy = Convert.ToInt32(Session["ContactID"].ToString());

        int k = objstudent.StudentVerificationDeleteRequestApproval(objstudent);
        if (k == 1)
        {
            ViewState["Data"] = null;
            BindGrid();
            ImpromptuHelper.ShowPrompt(_msg);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Data"] = null;
            BindGrid();
            btnaddStudent.Enabled = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public bool AddMasterEntry()
    {
        bool flag = false;
        try
        {
            if (ddlmonth.SelectedIndex > 0)
            {
                objstudent.MonthId = Convert.ToInt32(ddlmonth.SelectedValue.ToString());
                objstudent.Employee_Id = Convert.ToInt32(Session["ContactID"].ToString());
                objstudent.Section_Id = Convert.ToInt32(Session["Section_Id"].ToString());
                objstudent.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

                bool islock = false;
                int k = objstudent.StudentVerificationMstInsert(objstudent, islock);
                ViewState["mst_Id"] = k;
                flag = true;
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select a Month");
            } 
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        return flag;
    }

    protected void ShowStudents()
    {
        try
        {
            BLLClass_Section obj = new BLLClass_Section();
            obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            DataTable dtClassTeacher = (DataTable)obj.Class_SectionByClassTeacherId(obj);

            if (dtClassTeacher.Rows.Count == 1)
            {
                Session["Section_Id"] = dtClassTeacher.Rows[0]["Section_Id"].ToString();
                bool flag = AddMasterEntry();
                if (flag == true)
                {
                    ViewState["Data"] = null;
                    BindGrid();
                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Teacher has more than one classes allocated as Class teachers!");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtSchoolsRemarks;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtSchoolsRemarks = (TextBox)e.Row.FindControl("txtSchoolRemarks");
            txtSchoolsRemarks.Text = e.Row.Cells[15].Text.Replace("&nbsp;", ""); ;
            // do your stuffs here, for example if column risk is your third column:




            if (e.Row.Cells[4].Text == "1")
            {
                e.Row.ForeColor = Color.Red;
            }
        }
    }
    public void gvSections_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {






                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.ForeColor = Color.Red;
                }

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmonth.SelectedIndex > 0)
        { 
            DataTable dt = (DataTable)Session["ActiveDaysTable"];
            string exp = "MonthDesc = '" + ddlmonth.SelectedItem.Text + "'";

            DataRow[] row = dt.Select(exp);

            //if (DateTime.Now.Day <= Convert.ToInt16(row[0][4].ToString()))
           // {
                if ((Session["UserType_Id"].ToString() == "3" || Session["UserType_Id"].ToString() == "5" || Session["UserType_Id"].ToString() == "4"))
                {
                    ShowExceptionalCases();
                }
                else if (Session["UserType_Id"].ToString() == "1")
                {
                    ShowStudents();
                    btnaddStudent.Enabled = true;
                }

            //}
            //else
            //{
            //    gvStudents.DataSource = null;
            //    gvStudents.DataBind();
            //    ImpromptuHelper.ShowPrompt("Student verification is available from the 1st to the 5th of every month.");
            //} 
        }
        else
        {
            gvStudents.DataSource = null;
            gvStudents.DataBind();
            divTeacher.Visible = false;
            btnaddStudent.Visible = false;
            btnLock.Visible = false;

        } 
    }

    private void ShowExceptionalCases()
    {
        ViewState["Data"] = null;
        BindGrid();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetControls();
        AddStudent.Visible = false;
    }
}