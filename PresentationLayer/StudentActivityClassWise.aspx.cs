using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;

public partial class PresentationLayer_StudentActivityClassWise : System.Web.UI.Page
{
    private DataSet ds = null;
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
                trButtons.Visible=false;
                bindClassSection();

            }
            if (ViewState["actId"] != null && PlaceHolder1.Controls.Count == 0)
            {
                int ssId = Int32.Parse(ViewState["ssId"].ToString());
                int actId = Int32.Parse(ViewState["actId"].ToString());
                bindGridView(ssId, actId, false);
            }


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
        BLLEvaluation_Criteria_Type objEct = new BLLEvaluation_Criteria_Type();
        objEct.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
        dt = objEct.Evaluation_Criteria_TypeFetchBySectionID(objEct);
        objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void bindActivity()
    {
        try
        {
            lab_msg.Visible = false;
            msg.Visible = false;
            if (list_subject.SelectedValue != "" && list_term.SelectedValue != "")
            {
                DataRow row = (DataRow)Session["rightsRow"];

                BLLSection_Subject_Activity objAct = new BLLSection_Subject_Activity();

                objAct.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objAct.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
                objAct.Section_Subject_Id = Int32.Parse(list_subject.SelectedValue);
                
                DataTable dt = objAct.Section_Subject_ActivityFetch(objAct);

                objBase.FillDropDown(dt, list_activity, "Activity_Id", "Activity");
                PlaceHolder1.Controls.Clear();

            }
            else
            {
                trButtons.Visible=false;
                PlaceHolder1.Controls.Clear();
                ViewState["ssId"] = null;
                ViewState["actId"] = null;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    private void bindGridView(int sectionSubjectID, int activityID, bool doOverride)
    {
        try
        {
            PlaceHolder1.Controls.Clear();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@Section_Subject_Id", sectionSubjectID);
            param[1] = new SqlParameter("@activity_id", activityID);

            ds = DALBase.getDataSetBySp("StudentActivityMarks", param);
            if (ds.Tables.Count == 0)
            {
               
                //ImpromptuHelper.ShowPrompt("Not Applicable!");
                return;
            }
            ViewState["StudentTable"] = ds.Tables[0];
            DataSet lockMarkDs = DALBase.getDataSetBySp("StudentActivityMarksEnable", param);
            DataRow[] lockMarkRow = null;





            if (ds.Tables.Count == 0)
            {
                trButtons.Visible=false;
                lab_msg.Visible = true;
                lab_msg.Text = "No data exists";
                msg.Visible = false;
                but_save.Visible = false;
                return;
            }
            else
            {
                msg.Visible = true;
                lab_msg.Text = "";
                but_save.Visible = true;
            }

            TextBox tb;
            RegularExpressionValidator regVal;
            RangeValidator ranVal;
            Label lab_error;
            String myClass;
            int x;

            PlaceHolder1.Controls.Add(new LiteralControl("<table>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<table border='1'>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<tr style='color:#FFF; background-color: #868B74;  '>"));
            
            
            int[] skillId = new int[ds.Tables[0].Rows.Count];
            int[] studentId = new int[ds.Tables[0].Columns.Count];

            string tempStudentId, header, headerNew;
            string[] t;
            char[] del = new char[2];
            del[0] = '#';
            del[1] = '&';

            for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
            {
                if (c == 0)
                    PlaceHolder1.Controls.Add(new LiteralControl("<td style='font-size:14px'>No.</td>"));
                else if (c == 1)
                {
                    header = ds.Tables[0].Columns[c].ToString();
                    headerNew = header + "";
                    PlaceHolder1.Controls.Add(new LiteralControl("<td style='font-size:14px;'>" + headerNew + "</td>"));

                }
                else if (c >= 2)
                {
                    header = ds.Tables[0].Columns[c].ToString();

                    tempStudentId = ds.Tables[0].Columns[c].ToString();
                    t = tempStudentId.Split(del);
                    studentId[c] = Int32.Parse(t[2]); //Student Section Subject Id
                    header = t[0];
                    PlaceHolder1.Controls.Add(new LiteralControl("<td class='verticaltext'>" + header + "</td>"));
                }
            }
            PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                Math.DivRem(r, 2, out x);
                if (x == 0)
                    myClass = "trgv1";
                else
                    myClass = "trgv2";

                PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));
                for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                {
                    if (c >= 2)
                    {
                        lockMarkRow = lockMarkDs.Tables[0].Select("student_section_subject_id = " + studentId[c].ToString() + " and activity_skill_id = " + ds.Tables[0].Rows[r][0].ToString());

                        PlaceHolder1.Controls.Add(new LiteralControl("<td class='" + myClass + "'>"));
                        tb = new TextBox();
                        tb.ID = "hello" + r.ToString() + "_" + c.ToString();
                        if (doOverride)
                            tb.Text = ds.Tables[0].Rows[r][c].ToString();
                        if (tb.Text == "")
                            tb.Text = "-1";
                        tb.TabIndex = short.Parse(c.ToString());
                        tb.Width = 70;
                        tb.EnableViewState = true;
                        tb.ValidationGroup = "valSave";

                        if (lockMarkRow != null && lockMarkRow.GetLength(0) != 0)
                        {
                            tb.Enabled = !(bool.Parse(lockMarkRow[0]["lock_mark"].ToString()));
                        }


                        tb.Font.Size = 10;
                        if (lockMarkRow.Length>1)
                        {


                            if ((bool.Parse(lockMarkRow[0]["lock_mark"].ToString())) == true)
                            {
                                tb.ForeColor = Color.Indigo;
                                tb.Font.Bold = true;
                                tb.Font.Size = 13;
                                tb.ToolTip = "Marks editing is locked.";
                            }
                        }
                        PlaceHolder1.Controls.Add(tb);

                        lab_error = new Label();
                        lab_error.ForeColor = System.Drawing.Color.Red;
                        lab_error.ID = "error" + r.ToString() + "_" + c.ToString();
                        
                        PlaceHolder1.Controls.Add(lab_error);

                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));
                    }
                    else if (c == 0)
                    {
                        PlaceHolder1.Controls.Add(new LiteralControl("<td class='" + myClass + "'>" + ((int)(r + 1)).ToString() + "</td>"));
                        skillId[r] = Int32.Parse(ds.Tables[0].Rows[r][c].ToString());

                    }
                    else if (c == 1)
                    {
                        PlaceHolder1.Controls.Add(new LiteralControl("<td class='" + myClass + "'>" + ds.Tables[0].Rows[r][c].ToString() + "</td>"));
                    }

                }

                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
            }

            PlaceHolder1.Controls.Add(new LiteralControl("<table>"));

            ViewState["skill_ids"] = skillId;
            ViewState["student_ids"] = studentId;


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
    protected void but_save_Click(object sender, EventArgs e)
    {

        try
        {

            BLLStudent_Activity_Skill objSAS = new BLLStudent_Activity_Skill();

            //ManageSkillTableAdapters.Student_Activity_SkillTableAdapter da = new ManageSkillTableAdapters.Student_Activity_SkillTableAdapter();

            //Check added on 2 Jun 09 to stop from saving records that have mix of positive and negative numbers

            int[] sssId = (int[])(ViewState["student_ids"]);
            int[] skillId = (int[])(ViewState["skill_ids"]);
            TextBox tb;
            Label lab_error;
            int result;
            int MinusNum = 0;
            DataTable studentTable = (DataTable)ViewState["StudentTable"];
            string StudentNames = "";
            for (int c = 2; c < sssId.GetLength(0); c++)
            {
                for (int r = 0; r < skillId.GetLength(0); r++)
                {
                     tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                    if (Int32.TryParse(tb.Text, out result))
                    {
                        if (result == -1)
                            MinusNum++;
                    }
                }
                if (MinusNum != skillId.GetLength(0) && MinusNum != 0)
                {
                    string[] Names = studentTable.Columns[c].ColumnName.Split('#');
                    if (StudentNames != "")
                        StudentNames = StudentNames + ", " + Names[0];
                    else
                        StudentNames = Names[0];

                }
                MinusNum = 0;
            }
            if (StudentNames != "")
            {
                ImpromptuHelper.ShowPrompt("Cannot Save.Following students have atleast one negative marking: " + StudentNames);
                return;
            }
            //ManageSkillTableAdapters.Student_Activity_Skill_By_TermTableAdapter daterm = new ManageSkillTableAdapters.Student_Activity_Skill_By_TermTableAdapter();
            //daterm.DeleteMarksForClassSectionByTerm(Int32.Parse(list_subject.SelectedValue.ToString()), Int32.Parse(list_activity.SelectedValue.ToString()), Int32.Parse(list_term.SelectedValue.ToString()));
            objSAS.Section_Subject_Id = Int32.Parse(list_subject.SelectedValue.ToString());
            objSAS.Activity_Id = Int32.Parse(list_activity.SelectedValue.ToString());
            objSAS.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue.ToString());

            // Student_Activity_SkillDelete did not exist 
            // So comment by ilyas ahmed at 31 Oct 2014
            ////////objSAS.Student_Activity_SkillDelete(objSAS);

            //

            for (int r = 0; r < skillId.GetLength(0); r++)
            {
                for (int c = 2; c < sssId.GetLength(0); c++)
                {
                    tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                    lab_error = (Label)(PlaceHolder1.FindControl("error" + r.ToString() + "_" + c.ToString()));

                    if (Int32.TryParse(tb.Text, out result))
                    {
                        if (result <= 1 && result >= -1)
                        {
                            objSAS.Student_Section_Subject_Id = sssId[c];
                            //objSAS.Activity_Skill_Id = skillId[r];
                            objSAS.SSAS_Id = skillId[r];
                            objSAS.Marks = result;
                            objSAS.Lock_Mark = false;

                            objSAS.Student_Activity_SkillAdd(objSAS);
                            //da.Insert(sssId[c], skillId[r], result, false);
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
            }
            ImpromptuHelper.ShowPrompt("Correct marks entries were successfully updated.");
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
        trButtons.Visible=false;
        lab_msg.Text = "";

        list_activity.SelectedIndex = 0;

        msg.Visible = false;

        PlaceHolder1.Controls.Clear();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
        try
        {
            TreeView tempView = (TreeView)Master.FindControl("MenuLeft");
            TreeNode tn = tempView.FindNode("Marks Entry");

            if (tn != null)
            {
                tn.Expand();
                tn.ChildNodes[1].Expand();
                tn.ChildNodes[1].ChildNodes[0].Select();
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
            if (list_ClassSection.SelectedValue != "" || list_ClassSection.SelectedValue != "Select")

            {
                WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
                objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
                objWLA._ddl = list_ClassSection;
                objWLA.ISWelcomeAcknowledge(objWLA);

                bindTermList();
                bindSubject();
            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            bindActivity();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            bindActivity();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
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

                lab_status.Visible = false;

                if (dt.Rows.Count>0)
                {
                    objBase.FillDropDown(dt, list_subject, "Section_Subject_Id", "Subject_name");
                    lab_status.Visible = false;
                    list_subject.SelectedValue = dt.Rows[0]["Section_Subject_Id"].ToString();
                    
                }
            }
            else
            {
                trButtons.Visible=false;
                PlaceHolder1.Controls.Clear();
                ViewState["getData"] = 0;
            }

            ////////////////list_student.Items.Clear();
            ////////////////list_student.Items.Insert(0, new ListItem("Select", "0"));

            PlaceHolder1.Controls.Clear();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void list_activity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        trButtons.Visible=false;
        ViewState["actId"] = null;
        PlaceHolder1.Controls.Clear();

        //Class Wise Retrieval
        classWiseRetrieving();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void classWiseRetrieving()
    {
        try
        {
            int activityID;
            trButtons.Visible=true;
            int sectionSubjectID = Int32.Parse(list_subject.SelectedValue.ToString());
            if (list_activity.SelectedItem.Text == "Select")
            {
                lab_msg.Visible = false;
                msg.Visible = false;
                return;
            }
            else
            {
                activityID = Int32.Parse(list_activity.SelectedValue.ToString());
            }
            ViewState["actId"] = activityID;
            ViewState["ssId"] = sectionSubjectID;
            bindGridView(sectionSubjectID, activityID, true);

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
        int[] sssId = (int[])(ViewState["student_ids"]);
        int[] skillId = (int[])(ViewState["skill_ids"]);
        TextBox tb;
        for (int r = 0; r < skillId.GetLength(0); r++)
        {
            for (int c = 2; c < sssId.GetLength(0); c++)
            {

                tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                if (tb.Enabled==true)
                {
                    tb.Text = "1";
                    
                }
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
        int[] sssId = (int[])(ViewState["student_ids"]);
        int[] skillId = (int[])(ViewState["skill_ids"]);
        TextBox tb;
        for (int r = 0; r < skillId.GetLength(0); r++)
        {
            for (int c = 2; c < sssId.GetLength(0); c++)
            {

                tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                if (tb.Enabled == true)
                {
                    tb.Text = "0";
                }
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

