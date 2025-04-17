using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;


public partial class PresentationLayer_StudentActivityActivityWise : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected string totalMarks = "";
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

        try
        {
            if (!Page.IsPostBack)
            {
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx",false);
                }

                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["moID"].ToString());
                pan_New.Attributes.CssStyle.Add("display", "none");

                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";

                BindClassSection();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    
    protected void BindClassSection()
    {
        try
        {

            BLLClass_Section objCS = new BLLClass_Section();

            objCS.Center_Id = Convert.ToInt32(Session["CId"]);
            objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.Class_SectionByTeacherId(objCS);


            objBase.FillDropDown(_dt, list_ClassSection, "Section_Id", "Name");

            if (list_ClassSection.Items.Count == 0)
            {
                ImpromptuHelper.ShowPrompt("This Teacher has no section assigned to it. Please assign section(s) to this teacher first.");
            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }


    protected void BindTermList()
    {
        try
        {

        if (list_ClassSection.SelectedIndex > 0)
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type objEct = new BLLEvaluation_Criteria_Type();
            objEct.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
            dt = objEct.Evaluation_Criteria_TypeFetchBySectionID(objEct);
            objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BindSubject()
    {

        BLLSection_Subject objSS = new BLLSection_Subject();
        try
        {
            list_subject.Items.Clear();
            list_activity.Enabled = true;
            list_skill.Enabled = true;
            if (list_ClassSection.SelectedValue != "0")
            {
                DataTable dt = null;
                objSS.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
                objSS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);

                dt = objSS.Section_SubjectSelectBySectionTeacherActivity(objSS);
                if (dt.Rows.Count>0)
                {
                    objBase.FillDropDown(dt, list_subject, "Section_Subject_Id", "Subject_name");
                    list_subject.SelectedValue = dt.Rows[0]["Section_Subject_Id"].ToString();
                    
                }

                gvClasses.DataBind();

            }
            else
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                gvClasses.DataBind();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void BindActivity()
    {
        try
        {
            if (list_subject.SelectedValue != "0" && list_term.SelectedValue != "0")
            {
                DataRow row = (DataRow)Session["rightsRow"];

                BLLActivity objAct = new BLLActivity();


                objAct.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objAct.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
                objAct.Section_Subject_Id = Int32.Parse(list_subject.SelectedValue);
                DataTable dt = objAct.ActivityFetchBySectionSubjectTerm(objAct);

                objBase.FillDropDown(dt, list_activity, "SSA_Id", "Activity");

                list_skill.Items.Clear();
                list_skill.Items.Insert(0, new ListItem("Select", "0"));

                gvClasses.DataBind();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "none");
        lab_dataStatus.Visible = false;
        gvClasses.DataSource = null;
        gvClasses.DataBind();

        list_skill.SelectedIndex = 0;

        msg.Visible = false;
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
            TextBox marks = null;
            //Check added on 2 Jun to stop saving -1 marks for students that have atleast one 1 or 0
            int minusNum = 0;
            string studentNames = "";
            foreach (GridViewRow row in gvClasses.Rows)
            {
                marks = (TextBox)row.FindControl("txt_Marks");
                if (marks.Text == "-1")
                {
                    minusNum++;
                    LinkButton lb = (LinkButton)row.FindControl("LinkButton1");
                    if (studentNames != "")
                        studentNames = studentNames + ", " + lb.Text;
                    else
                        studentNames = lb.Text;
                }
            }
            if (studentNames != "")
            {
                ImpromptuHelper.ShowPrompt("Cannot Save.Following students have atleast one negative marking: " + studentNames);
                return;
            }

            //Check added on 2 Jun to stop saving -1 marks for students that have atleast one 1 or 0


            int skillId = 0;
            int sectionSubjectId = 0;
            int termId = 0;
            int studentSectionSubjectId = 0;

            BLLStudent_Activity_Skill objSas = new BLLStudent_Activity_Skill();

            sectionSubjectId = Int32.Parse(list_subject.SelectedValue);
            skillId = Int32.Parse(list_skill.SelectedValue);
            termId = Int32.Parse(list_term.SelectedValue);

            objSas.Section_Subject_Id = sectionSubjectId;
            objSas.Evaluation_Criteria_Type_Id = termId;
            objSas.Activity_Skill_Id = skillId;
            foreach (GridViewRow row in gvClasses.Rows)
            {
                studentSectionSubjectId = Int32.Parse(gvClasses.DataKeys[row.RowIndex].Value.ToString());
                
                marks = (TextBox)row.FindControl("txt_Marks");
                if (!marks.Text.Equals(""))
                {
                    objSas.Student_Section_Subject_Id = studentSectionSubjectId;
                    objSas.SSAS_Id = skillId;
                    objSas.Marks = Int32.Parse(marks.Text);
                    objSas.Lock_Mark = false;

                    objSas.Student_Activity_SkillAdd(objSas);

                }
            }


            ImpromptuHelper.ShowPrompt("Student marks successfully updated.");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void gvClasses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Total_Marks"] != null)
            {
                RangeValidator rv = (RangeValidator)e.Row.FindControl("RanVd");
                rv.ErrorMessage = "<b>Invalid Field</b><br />Enter value >= 0 and <= " + ViewState["Total_Marks"].ToString() + "<br />";

            }

            TextBox tb = (TextBox)e.Row.FindControl("txt_Marks");
            tb.Font.Size = 10;
            if (bool.Parse(e.Row.Cells[0].Text) == true)
            {
                tb.ForeColor = Color.Indigo;
                tb.Font.Bold = true;
                tb.Font.Size = 13;
                tb.Enabled = false;
                tb.ToolTip = "Marks editing is locked.";
            }
            else
            {
                tb.Enabled = true;

            }


        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvClasses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        if (e.CommandName.Equals("cnStudent"))
        {
            Session["studentID"] = Convert.ToInt32(e.CommandArgument);
            //Response.Redirect("StudentInfo.aspx");

        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }



    private void bindGridView(int sectionSubjectId, int criteriaId)
    {
        try
        {
        DataTable dt = null;
        BLLStudent_Activity_Skill objSAS = new BLLStudent_Activity_Skill();
        objSAS.Section_Subject_Id = sectionSubjectId;
        objSAS.SSAS_Id = criteriaId;
        dt = objSAS.Student_Activity_SkillFetchBySectionSkill(objSAS);

        if (dt.Rows.Count == 0)
        {
            lab_dataStatus.Text = "No data exists.";
        }
        else
        {
            lab_dataStatus.Text = "";
            gvClasses.DataSource = dt;
            gvClasses.DataBind();
            ViewState["Total_Marks"] = 1;
        }


        pan_New.Attributes.CssStyle.Add("display", "inline");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void lb_getAvailableSubs_Click(object sender, EventArgs e)
    {
        try
        {
        int sectionSubjectId = Convert.ToInt32(list_subject.SelectedValue);
        int criteriaId = Int32.Parse(list_skill.SelectedValue);
        if (criteriaId != 0)
        {
            bindGridView(sectionSubjectId, criteriaId);
        }
        else
        {
            gvClasses.DataSource = null;
            gvClasses.DataBind();
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int moID = Int32.Parse(Session["moID"].ToString());
            if (list_ClassSection.SelectedValue.ToString() != "0")
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void list_activity_SelectedIndexChanged(object sender, EventArgs e)
    {

        BLLSection_Subject_Activity_Skill objAS = new BLLSection_Subject_Activity_Skill();


        try
        {
            msg.Visible = false;
            list_skill.Items.Clear();
            if (list_activity.SelectedValue == "")
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                gvClasses.DataBind();

            }
            else
            {
                if (list_activity.SelectedItem.Text == "Select")
                {
                    list_skill.Enabled = false;
                }
                list_skill.Enabled = true;

                objAS.SSA_Id = Int32.Parse(list_activity.SelectedValue);
                DataTable dt = objAS.Activity_SkillFetchByActivityId(objAS);
                objBase.FillDropDown(dt, list_skill, "SSAS_Id", "skill");
            }
            gvClasses.DataSource = null;
            gvClasses.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_ClassSection_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            msg.Visible = false;
            if (list_ClassSection.SelectedItem.Text == "Select")
            {

                list_activity.Items.Clear();

                list_activity.Items.Insert(0, new ListItem("Select", "0"));

                list_skill.Items.Clear();
                list_skill.Items.Insert(0, new ListItem("Select", "0"));


            }
            else
            {
                WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
                objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
                objWLA._ddl = list_ClassSection;
                objWLA.ISWelcomeAcknowledge(objWLA);

                BindSubject();
                BindTermList();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msg.Visible = false;
            if (list_subject.SelectedValue != "0")
            {

                BindActivity();

            }
            else
            {
                if (list_subject.SelectedItem.Text == "Select")
                {

                    list_activity.Items.Clear();
                    list_activity.Items.Insert(0, new ListItem("Select", "0"));

                    list_skill.Items.Clear();
                    list_skill.Items.Insert(0, new ListItem("Select", "0"));
                }
                pan_New.Attributes.CssStyle.Add("display", "none");
                gvClasses.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msg.Visible = false;
            if (list_term.SelectedValue != "0")
            {

                BindActivity();

            }
            else
            {
                if (list_term.SelectedItem.Text == "Select")
                {

                    list_activity.Items.Clear();
                    list_activity.Items.Insert(0, new ListItem("Select", "0"));

                    list_skill.Items.Clear();
                    list_skill.Items.Insert(0, new ListItem("Select", "0"));
                }
                pan_New.Attributes.CssStyle.Add("display", "none");
                gvClasses.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_skill_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "none");
        gvClasses.DataBind();

        skillWiseRetrieving();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void skillWiseRetrieving()
    {
        try
        {
        int sectionSubjectId = Convert.ToInt32(list_subject.SelectedValue);
        if (list_skill.SelectedItem.Text == "Select")
        {
            msg.Visible = false;
            return;
        }
        int criteriaId = Int32.Parse(list_skill.SelectedValue);
        if (criteriaId != 0)
        {
            msg.Visible = true;
            bindGridView(sectionSubjectId, criteriaId);
        }
        else
        {
            gvClasses.DataSource = null;
            gvClasses.DataBind();
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_Apply1_Click(object sender, EventArgs e)
    {
        try
        {
        ApplyMarksGrid("1");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void but_Apply0_Click(object sender, EventArgs e)
    {
        try
        {
        ApplyMarksGrid("0");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ApplyMarksGrid(string mrk)
    {
        try{
        TextBox marks = null;
        foreach (GridViewRow row in gvClasses.Rows)
        {

            marks = (TextBox)row.FindControl("txt_Marks");
            if (marks.Enabled==true)
            {
                marks.Text = mrk;
                
            }
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
