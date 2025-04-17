using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;

public partial class PresentationLayer_StudentActivityStudentWise : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

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
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
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

                bindClassSection();


                ViewState["getData"] = 0;
            }
            if (ViewState["getData"].ToString() == "1")
                bindGridView(false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void bindClassSection()
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



    protected void bindTermList()
    {
        try
        {

        DataTable dt = null;
        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        ObjECT.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
        dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
        objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
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

        PlaceHolder1.Controls.Clear();
        ViewState["getData"] = 0;

        list_student.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void but_save_Click(object sender, EventArgs e)
    {

        BLLStudent_Activity_Skill objSAS = new BLLStudent_Activity_Skill();

        try
        {
            //Check added on 2 Jun to stop saving -1 marks for students that have atleast one 1 or 0
            int[] skillId = (int[])(ViewState["skill_ids"]);
            TextBox tb;
            Label lab_error;
            int result;

            int count = 0;

            int MinusNum = 0;
            string ActivityNames = "";
            int No_of_skills_in_Activity = 0;
            string lastValue = "";

            DataTable skillsDt = (DataTable)ViewState["Table"];
            string oldvalue = skillsDt.Rows[0][1].ToString();

            foreach (DataRow row in skillsDt.Rows)
            {
                if (oldvalue != row.ItemArray.GetValue(1).ToString())
                {
                    MinusNum = 0;
                    No_of_skills_in_Activity = 1;
                }
                else
                    No_of_skills_in_Activity++;

                tb = (TextBox)(PlaceHolder1.FindControl("hello" + Convert.ToString(count)));

                if (tb.Text == "-1")
                    MinusNum++;


                if (MinusNum != 0 && MinusNum != No_of_skills_in_Activity && oldvalue != lastValue)
                {
                    if (ActivityNames == "")
                        ActivityNames = row.ItemArray.GetValue(1).ToString();
                    else
                        ActivityNames = ActivityNames + ", " + row.ItemArray.GetValue(1).ToString();
                    lastValue = row.ItemArray.GetValue(1).ToString();
                }
                count++;
                oldvalue = row.ItemArray.GetValue(1).ToString();
            }
            //  if (ActivityNames != "")
            if (MinusNum > 0)
            {
                //ImpromptuHelper.ShowPrompt("Cannot Save.Following Activities have at least one negative marking: " + ActivityNames);
                ImpromptuHelper.ShowPrompt("Some Activities have negative marking, -ve Marking not allowed in ;" + ActivityNames);
                return;
            }

            int student_section_subject_Id;
            int section_subject_Id = Int32.Parse(list_subject.SelectedValue);
            int student_Id = (int)(ViewState["student_id"]);

            /*Get Student_section_subject_Id by StudentId*/

            //BLLStudent_Section_Subject objSSS = new BLLStudent_Section_Subject();
            //objSSS.Student_Id = student_Id;
            //objSSS.Section_Subject_Id = section_subject_Id;
            //DataTable dt = objSSS.student_section_subjectSelectBySectionSubjectStudent_Id(objSSS);



            //student_section_subject_Id = Convert.ToInt32(dt.Rows[0]["Student_Section_Subject_Id"].ToString());
            student_section_subject_Id = (int)(ViewState["student_section_subject_id"]);

            objSAS.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
            objSAS.Student_Section_Subject_Id = student_section_subject_Id;
            //objSAS.Student_Activity_SkillDeleteSectionSkill(objSAS);

            for (int r = 0; r < skillId.GetLength(0); r++)
            {

                tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString()));
                lab_error = (Label)(PlaceHolder1.FindControl("error" + r.ToString()));

                if (Int32.TryParse(tb.Text, out result))
                {
                    if (result <= 1 && result >= -1)
                    {
                        objSAS.Student_Section_Subject_Id = student_section_subject_Id;
                        objSAS.SSAS_Id = skillId[r];
                        objSAS.Marks = result;
                        objSAS.Lock_Mark = false;
                        objSAS.Student_Activity_SkillAdd(objSAS);
                        lab_error.Text = "";
                    }
                    else
                    {
                        lab_error.Text = "Range error.";
                        tb.Focus();
                    }

                }
                else
                {
                    lab_error.Text = "Invalid Entry.";
                    tb.Focus();
                }


            }
            ImpromptuHelper.ShowPrompt("Correct marks entries were successfully updated.");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    private void bindGridView(bool doOverride)
    {
        try
        {
        PlaceHolder1.Controls.Clear();
        if ((list_student.SelectedValue == "0" || list_subject.SelectedValue == "0") || list_term.SelectedValue == "0")
        {
            msg.Visible = false;
            ViewState["getData"] = 0;
            return;
        }


        DataRow row = (DataRow)Session["rightsRow"];

        DataTable dt = null;

        BLLStudent_Activity_Skill objSAS = new BLLStudent_Activity_Skill();
        objSAS.Student_Id = Int32.Parse(list_student.SelectedValue);
        objSAS.Section_Subject_Id = Int32.Parse(list_subject.SelectedValue);
        objSAS.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
        dt = objSAS.Student_Activity_SkillFetch(objSAS);

        ViewState["Table"] = dt;
        if (dt.Rows.Count == 0)
        {
            pan_New.Attributes.CssStyle.Add("display", "none");
            PlaceHolder1.Controls.Clear();
            lab_status.Visible = true;
            lab_status.Text = "No data exists";
        }
        else
        {
            msg.Visible = true;
            lab_status.Text = "";
            TextBox tb;
            Label lab_error;
            String myClass, oldValue = "";
            int x;
            int[] skillId = new int[dt.Rows.Count];

            PlaceHolder1.Controls.Add(new LiteralControl("<table width='100%' >"));

            PlaceHolder1.Controls.Add(new LiteralControl("<table width='100%' border='1'>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<tr style='color:#FFF; background-color: #868B74;width:100%; font-size:14px;'>"));
            
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                ViewState["student_id"] = dt.Rows[r].ItemArray.GetValue(4);
                skillId[r] = Int32.Parse(dt.Rows[r].ItemArray.GetValue(6).ToString());
                ViewState["student_section_subject_id"] = dt.Rows[r].ItemArray.GetValue(8);

                if (oldValue != dt.Rows[r].ItemArray.GetValue(1).ToString())
                {
                    //PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tableheaderD'>"));
                    PlaceHolder1.Controls.Add(new LiteralControl("<tr style='color:#FFF; background-color: #868B74;width:100%;font-size:14px;'>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>" + dt.Rows[r].ItemArray.GetValue(1) + "</tr>"));
                    PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
                    oldValue = dt.Rows[r].ItemArray.GetValue(1).ToString();
                }

                Math.DivRem(r, 2, out x);
                if (x == 0)
                    myClass = "trgv1";
                else
                    myClass = "trgv2";


                PlaceHolder1.Controls.Add(new LiteralControl("<tr class='" + myClass + "'>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td style='width:80%;font-size:14px;' >" + dt.Rows[r].ItemArray.GetValue(0) + "</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<td style='width:20%;font-size:14px;' >"));

                tb = new TextBox();
                tb.ID = "hello" + r.ToString();
                if (doOverride)
                    tb.Text = dt.Rows[r].ItemArray.GetValue(2).ToString();
                if (tb.Text == "")
                    tb.Text = "-1";
                tb.Width = 50;
                tb.EnableViewState = true;
                tb.ValidationGroup = "valSave";
                //tb.ReadOnly = (bool)dt.Rows[r].ItemArray.GetValue(3);

                //if (lockMarkRow != null && lockMarkRow.GetLength(0) != 0)
                //{

                //    tb.Enabled = !(bool.Parse(lockMarkRow[0]["lock_mark"].ToString()));
                //}

                bool val = bool.Parse(dt.Rows[r].ItemArray.GetValue(3).ToString());
                tb.Font.Size = 10;
                if (val == true)
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



                PlaceHolder1.Controls.Add(tb);

                lab_error = new Label();
                lab_error.ForeColor = System.Drawing.Color.Red;
                lab_error.ID = "error" + r.ToString();
                PlaceHolder1.Controls.Add(lab_error);

                PlaceHolder1.Controls.Add(new LiteralControl("</td>"));
                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));


            }
            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));


            ViewState["skill_ids"] = skillId;
            pan_New.Attributes.CssStyle.Add("display", "inline");
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    protected void lb_getAvailableSubs_Click(object sender, EventArgs e)
    {



    }

    protected void list_ClassSection_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            msg.Visible = false;
            if (list_ClassSection.SelectedItem.Text == "Select")
            {

                list_student.Items.Clear();
                list_student.Items.Insert(0, new ListItem("Select", "0"));

                list_term.SelectedIndex = 0;
            }
            else
            {
                WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
                objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
                objWLA._ddl = list_ClassSection;

                objWLA.ISWelcomeAcknowledge(objWLA);

                bindSubject();
                bindTermList();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void bindSubject()
    {
        BLLSection_Subject ObjSS = new BLLSection_Subject();


        try
        {
            list_subject.Items.Clear();

            if (list_ClassSection.SelectedValue != "0")
            {

                DataTable dt = null;
                ObjSS.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
                ObjSS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);

                dt = ObjSS.Section_SubjectSelectBySectionTeacherActivity(ObjSS);

                if (dt.Rows.Count>0)
                {
                    objBase.FillDropDown(dt, list_subject, "Section_Subject_Id", "Subject_name");
                   // list_subject.SelectedValue = dt.Rows[0]["Section_Subject_Id"].ToString();
                    lab_status.Visible = false;
                }
            }
            else
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                PlaceHolder1.Controls.Clear();
                ViewState["getData"] = 0;
            }

            list_student.Items.Clear();
            list_student.Items.Insert(0, new ListItem("Select", "0"));

            PlaceHolder1.Controls.Clear();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        msg.Visible = false;
        int moID = Int32.Parse(Session["moID"].ToString());
        if (list_subject.SelectedValue.ToString() != "0")
        {
            BindStudents();
        }
        else
        {
            if (list_subject.SelectedItem.Text == "Select")
            {
                list_student.Enabled = true;

                list_student.Items.Clear();
                list_student.Items.Insert(0, new ListItem("Select", "0"));
            }
            pan_New.Attributes.CssStyle.Add("display", "none");
            PlaceHolder1.Controls.Clear();
            ViewState["getData"] = 0;
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void BindStudents()
    {
        DALBase objbase = new DALBase();
        try
        {
            list_student.Items.Clear();

            if (list_subject.SelectedValue != "0")
            {
                BLLStudent_Section_Subject objStd = new BLLStudent_Section_Subject();

                objStd.Section_Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
                objStd.Student_Status_Id = 5;
                DataTable dt = null;
                list_student.Enabled = true;
                dt = objStd.Student_Section_SubjectFetchByStatusID(objStd);
                objBase.FillDropDown(dt, list_student, "Student_Id", "id_name");
            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_term.SelectedValue != "")
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                PlaceHolder1.Controls.Clear();
                ViewState["getData"] = 0;

                // Student Wise Retrieval
                studentWiseRetrieving();
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
            if (list_student.SelectedValue != "")
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                PlaceHolder1.Controls.Clear();
                ViewState["getData"] = 0;

                // Student Wise Retrieval
                studentWiseRetrieving();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void studentWiseRetrieving()
    {
        try
        {
        ViewState["getData"] = 1;
        bindGridView(true);
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

        int[] skillId = (int[])(ViewState["skill_ids"]);
        TextBox tb;
        for (int r = 0; r < skillId.GetLength(0); r++)
        {

            tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString()));
            if (tb.Enabled == true)
            {
                tb.Text = "1";
            }

        }

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
        int[] skillId = (int[])(ViewState["skill_ids"]);
        TextBox tb;
        for (int r = 0; r < skillId.GetLength(0); r++)
        {

            tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString()));
            if (tb.Enabled == true)
            {
                tb.Text = "0";
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
