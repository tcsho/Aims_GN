using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_ClassSectionSubjectComments2 : System.Web.UI.Page
{

    DALBase objBase = new DALBase();
    private DataSet ds = null;
    private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
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
                    Response.Redirect("~/login.aspx", false);
                }

                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["moID"].ToString());



                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "check";
                LoadClassSection();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        BLLStudent_Evaluation_SubjectRemarks objESR = new BLLStudent_Evaluation_SubjectRemarks();


        DropDownList listG1, listG2, listImp1, listImp2, listEffort;
        Label lblerror, lblAbsent;
        CheckBox chkAbsent;

        int AlreadyIn;
        bool chk, MasterCheck;
        chk = false;
        MasterCheck = false;
        try
        {

            foreach (GridViewRow gvr in gvRegStudents.Rows)
            {


                listG1 = (DropDownList)(gvr.FindControl("listG1"));
                listG2 = (DropDownList)(gvr.FindControl("listG2"));
                listImp1 = (DropDownList)(gvr.FindControl("listImp1"));
                listImp2 = (DropDownList)(gvr.FindControl("listImp2"));

                lblerror = (Label)(gvr.FindControl("lblerror"));

                listEffort = (DropDownList)(gvr.FindControl("listEffort"));


                chkAbsent = (CheckBox)(gvr.FindControl("chkAbsent"));
                lblAbsent = (Label)(gvr.FindControl("lblAbsent"));



                string gender = "";

                if (gvr.Cells[8].Text == "F")
                {
                    gender = "her";
                }
                else
                {
                    gender = "his";
                }


                objESR.Std_Com_Id = Convert.ToInt32(gvr.Cells[1].Text);
                objESR.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
                objESR.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
                objESR.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue);
                objESR.Student_Id = Convert.ToInt32(gvr.Cells[0].Text.ToString());
                objESR.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue);

                objESR.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                objESR.CreatedOn = DateTime.Now;
                objESR.CreatedBy = Int32.Parse(Session["ContactId"].ToString());

                objESR.ModifiedOn = DateTime.Now;
                objESR.ModifiedBy = Int32.Parse(Session["ContactId"].ToString());


                /*=====================*/
                if (chkAbsent.Checked)
                {
                    objESR.Remarks = lblAbsent.Text;
                    objESR.GoodOne = 0;
                    objESR.GoodTwo = 0;
                    objESR.ImprovOne = 0;
                    objESR.ImprovTwo = 0;
                    objESR.Effort = 0;
                    objESR.isAbsent = true;

                    AlreadyIn = objESR.Student_Evaluation_SubjectRemarksUpsert(objESR);
                    if (AlreadyIn == 1)
                    {
                        chk = true;
                        listG1.BackColor = Color.White;
                        listG2.BackColor = Color.White;
                        listImp1.BackColor = Color.White;
                        listImp2.BackColor = Color.White;
                        listEffort.BackColor = Color.White;
                        lblerror.Text = "";
                        lblerror.Visible = false;

                    }

                }
                else
                {

                    var sb = "I am really pleased with " + gvr.Cells[7].Text + "'s " + listG1.SelectedItem.Text + " and " + listG2.SelectedItem.Text + ". I would like to see an improvement in " + gender + " " + listImp1.SelectedItem.Text + " and also in " + gender + " " + listImp2.SelectedItem.Text + ".";

                    objESR.Remarks = sb.ToString();
                    objESR.GoodOne = Convert.ToInt32(listG1.SelectedValue);
                    objESR.GoodTwo = Convert.ToInt32(listG2.SelectedValue);
                    objESR.ImprovOne = Convert.ToInt32(listImp1.SelectedValue);
                    objESR.ImprovTwo = Convert.ToInt32(listImp2.SelectedValue);
                    objESR.Effort = Convert.ToInt32(listEffort.SelectedValue);
                    objESR.isAbsent = false;


                    if (Convert.ToInt32(listG1.SelectedValue) > 0 && Convert.ToInt32(listG2.SelectedValue) > 0 && Convert.ToInt32(listImp1.SelectedValue) > 0 && Convert.ToInt32(listImp2.SelectedValue) > 0 && Convert.ToInt32(listEffort.SelectedValue) > 0)
                    {
                        string[] myStrings = new string[4];

                        myStrings[0] = listG1.SelectedValue;
                        myStrings[1] = listG2.SelectedValue;
                        myStrings[2] = listImp1.SelectedValue;
                        myStrings[3] = listImp2.SelectedValue;

                        if (myStrings.Distinct().Count() == myStrings.Count())
                        {
                            AlreadyIn = objESR.Student_Evaluation_SubjectRemarksUpsert(objESR);
                            if (AlreadyIn == 1)
                            {
                                chk = true;
                                listG1.BackColor = Color.White;
                                listG2.BackColor = Color.White;
                                listImp1.BackColor = Color.White;
                                listImp2.BackColor = Color.White;
                                listEffort.BackColor = Color.White;
                                lblerror.Text = "";
                                lblerror.Visible = false;

                            }
                        }
                        else
                        {
                            lblerror.Text = "Comment selection can not be repeated, please select unique options";
                            lblerror.Visible = true;
                            MasterCheck = true;

                        }

                    }
                    else if (Convert.ToInt32(listG1.SelectedValue) == 0 && Convert.ToInt32(listG2.SelectedValue) == 0 && Convert.ToInt32(listImp1.SelectedValue) == 0 && Convert.ToInt32(listImp2.SelectedValue) == 0 && Convert.ToInt32(listEffort.SelectedValue) == 0)
                    {

                    }
                    else
                    {
                        lblerror.Text = "Please select all the options";
                        lblerror.Visible = true;
                        MasterCheck = true;

                    }



                }
                /*=====================*/











            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (MasterCheck == false)
        {
            if (chk == true)
            {
                ImpromptuHelper.ShowPrompt("Student Subject comments saved sucessfully.");
                ViewState["Grid"] = null;
                BindGrid();
            }
        }

        else
        {
            ImpromptuHelper.ShowPromptGeneric("There are few issues with the data, please review.", 0);

        }




    }
    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (List_ClassSection.SelectedValue != "")
            {
                LoadSubject();
                LoadTerm();
                ViewState["Grid"] = null;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Subject.SelectedValue != "")
            {
                LoadStudent();
                LoadTerm();

                ViewState["Grid"] = null;
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Term.SelectedValue != "")
            {
                ViewState["Grid"] = null;
                BindGrid();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void BindGrid()
    {
        try
        {
            BLLStudent objStudent = new BLLStudent();
            DataTable dt = new DataTable();

            if (Convert.ToInt32(List_ClassSection.SelectedValue) > 0 && Convert.ToInt32(list_Term.SelectedValue) > 0 && Convert.ToInt32(list_Subject.SelectedValue) > 0)
            {
                objStudent.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                objStudent.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

                objStudent.Term_Id = Convert.ToInt32(list_Term.SelectedValue);
                objStudent.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue);
                objStudent.Student_Id = Convert.ToInt32(list_student.SelectedValue);


                if (ViewState["Grid"] != null)
                {
                    dt = (DataTable)ViewState["Grid"];
                }
                else
                {
                    dt = objStudent.StudentSelectBySection_IdForSubjectComments(objStudent);
                }
                gvRegStudents.DataSource = dt;
                gvRegStudents.DataBind();
                ViewState["Grid"] = dt;

            }
            else
            {
                gvRegStudents.DataSource = null;
                gvRegStudents.DataBind();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Term.SelectedIndex > 0)
            {
                ViewState["Grid"] = null;
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void LoadSubject()
    {
        try
        {
            BLLSection_Subject obj = new BLLSection_Subject();

            obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
            obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());

            DataTable dt = (DataTable)obj.Section_SubjectSelectBySectionTeacherEvaluation(obj);
            objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void LoadStudent()
    {
        try
        {

            BLLSection_Subject obj = new BLLSection_Subject();
            int SectionSubjectId = Convert.ToInt32(list_Subject.SelectedValue.ToString());

            DataTable dt = (DataTable)obj.StudentBySectionSubjectId(SectionSubjectId);
            objBase.FillDropDown(dt, list_student, "Student_Id", "FullStudentName");
            ViewState["StudentList"] = dt;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void LoadTerm()
    {
        try
        {
            if (List_ClassSection.SelectedIndex > 0)
            {
                BLLSection_Subject obj = new BLLSection_Subject();

                obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
                obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

                DataTable dt = obj.Evaluation_Criteria_TypeBySectionId(obj);

                objBase.FillDropDown(dt, list_Term, "Id", "Type");


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gvRegStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvRegStudents.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvRegStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (List_ClassSection.SelectedIndex > 0 && list_Subject.SelectedIndex > 0 && list_Term.SelectedIndex > 0)
            {

                BLLEvaluation_Criteria_StudentCommentsBank objECSC = new BLLEvaluation_Criteria_StudentCommentsBank();


                objECSC.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
                /*Class_Id from Section_id*/

                BLLSection objsec = new BLLSection();
                DataTable dtcls = new DataTable();
                dtcls = objsec.SectionFetch(Convert.ToInt32(List_ClassSection.SelectedValue));

                objECSC.Class_Id = Convert.ToInt32(dtcls.Rows[0]["Class_Id"].ToString());


                /*Subject_Id from Section_subject_Id*/
                BLLSection_Subject objsecsub = new BLLSection_Subject();
                DataTable dtsecsub = new DataTable();
                dtsecsub = objsecsub.Section_SubjectFetch(Convert.ToInt32(list_Subject.SelectedValue));

                objECSC.Subject_Id = Convert.ToInt32(dtsecsub.Rows[0]["Subject_Id"].ToString());

                /*TermGroup_Id from Term_ID*/

                BLLEvaluation_Criteria_Type objECT = new BLLEvaluation_Criteria_Type();
                DataTable dtterm = new DataTable();
                dtterm = objECT.Evaluation_Criteria_TypeFetch(Convert.ToInt32(list_Term.SelectedValue));

                objECSC.TermGroup_Id = Convert.ToInt32(dtterm.Rows[0]["TermGroup_Id"].ToString());
                objECSC.CommCat_Id = 1;

                DataTable dtGood = objECSC.Evaluation_Criteria_StudentCommentsBankFetch(objECSC);

                objECSC.CommCat_Id = 2;
                DataTable dtImp = objECSC.Evaluation_Criteria_StudentCommentsBankFetch(objECSC);

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    CheckBox chkAbsent = (CheckBox)(e.Row.FindControl("chkAbsent"));
                    Label lblAbsent = (Label)(e.Row.FindControl("lblAbsent"));

                    HtmlTableRow trSubComments = (HtmlTableRow)e.Row.Cells[10].FindControl("trsubcomments");
                    HtmlTableRow treffort = (HtmlTableRow)e.Row.Cells[10].FindControl("treffort");

                    DropDownList listG1 = (e.Row.FindControl("listG1") as DropDownList);
                    DropDownList listG2 = (e.Row.FindControl("listG2") as DropDownList);
                    DropDownList listImp1 = (e.Row.FindControl("listImp1") as DropDownList);
                    DropDownList listImp2 = (e.Row.FindControl("listImp2") as DropDownList);
                    DropDownList listEffort = (e.Row.FindControl("listEffort") as DropDownList);

                    if (dtGood.Rows.Count > 0)
                    {

                        objBase.FillDropDown(dtGood, listG1, "ComBank_Id", "Comments");
                        objBase.FillDropDown(dtGood, listG2, "ComBank_Id", "Comments");

                    }

                    if (dtImp.Rows.Count > 0)
                    {

                        objBase.FillDropDown(dtImp, listImp1, "ComBank_Id", "Comments");
                        objBase.FillDropDown(dtImp, listImp2, "ComBank_Id", "Comments");

                    }




                    if (e.Row.Cells[9].Text == "True")
                    {

                        chkAbsent.Checked = true;
                        lblAbsent.Text = e.Row.Cells[7].Text + " has been absent for this subject this term.We look forward to better attendance next term.";

                        trSubComments.Visible = false;
                        treffort.Visible = false;


                    }
                    else
                    {


                        trSubComments.Visible = true;
                        treffort.Visible = true;


                        string G1Id = (e.Row.Cells[2].Text);
                        string G2Id = (e.Row.Cells[3].Text);
                        string Imp1Id = (e.Row.Cells[4].Text);
                        string Imp2Id = (e.Row.Cells[5].Text);
                        string Effort = (e.Row.Cells[6].Text);



                        if (G1Id != "&nbsp;" || G1Id != String.Empty)
                        {
                            listG1.SelectedValue = G1Id;

                            if (Convert.ToInt32(G1Id) > 0)
                            {
                                listG1.BackColor = Color.White;
                            }
                            else
                            {
                                listG1.BackColor = Color.Yellow;
                            }
                        }

                        if (G2Id != "&nbsp;" || G2Id != String.Empty)
                        {
                            listG2.SelectedValue = G2Id;
                            if (Convert.ToInt32(G2Id) > 0)
                            {
                                listG2.BackColor = Color.White;
                            }
                            else
                            {
                                listG2.BackColor = Color.Yellow;
                            }

                        }

                        if (Imp1Id != "&nbsp;" || Imp1Id != String.Empty)
                        {
                            listImp1.SelectedValue = Imp1Id;

                            if (Convert.ToInt32(Imp1Id) > 0)
                            {
                                listImp1.BackColor = Color.White;
                            }
                            else
                            {
                                listImp1.BackColor = Color.Yellow;
                            }
                        }

                        if (Imp2Id != "&nbsp;" || Imp2Id != String.Empty)
                        {
                            listImp2.SelectedValue = Imp2Id;

                            if (Convert.ToInt32(Imp2Id) > 0)
                            {
                                listImp2.BackColor = Color.White;
                            }
                            else
                            {
                                listImp2.BackColor = Color.Yellow;
                            }
                        }

                        if (Effort != "&nbsp;" || Effort != String.Empty)
                        {
                            listEffort.SelectedValue = Effort;

                            if (Convert.ToInt32(Effort) > 0)
                            {
                                listEffort.BackColor = Color.White;
                            }
                            else
                            {
                                listEffort.BackColor = Color.Yellow;
                            }
                        }
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

    protected void gvRegStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //if (e.CommandName == "toggleCheck")
            //{
            //    CheckBox cb = null;
            //    string mood = ViewState["tMood"].ToString();

            //    foreach (GridViewRow gvr in gvRegStudents.Rows)
            //    {
            //        cb = (CheckBox)gvr.FindControl("CheckBox1");

            //        if (mood == "" || mood == "check")
            //        {
            //            cb.Checked = true;
            //            ViewState["tMood"] = "uncheck";
            //        }
            //        else
            //        {
            //            cb.Checked = false;
            //            ViewState["tMood"] = "check";
            //        }

            //    }

            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void LoadClassSection()
    {
        try
        {

            BLLClass_Section obj = new BLLClass_Section();

            int EmployeeId = Convert.ToInt32(Session["EmployeeCode"].ToString());

            DataTable dt = (DataTable)obj.Class_SectionByEmployeeId(EmployeeId);
            objBase.FillDropDown(dt, List_ClassSection, "Section_id", "FullClassSection");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void chkAbsent_OnCheckedChanged(Object sender, EventArgs e)
    {

        CheckBox btnEdit = (CheckBox)(sender);

        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        gvRegStudents.SelectedIndex = gvr.RowIndex;

        HtmlTableRow trSubComments = (HtmlTableRow)gvr.FindControl("trSubComments");
        HtmlTableRow treffort = (HtmlTableRow)gvr.FindControl("treffort");

        Label lblAbsent = (Label)gvr.FindControl("lblAbsent");

        DropDownList listG1 = (gvr.FindControl("listG1") as DropDownList);
        DropDownList listG2 = (gvr.FindControl("listG2") as DropDownList);
        DropDownList listImp1 = (gvr.FindControl("listImp1") as DropDownList);
        DropDownList listImp2 = (gvr.FindControl("listImp2") as DropDownList);
        DropDownList listEffort = (gvr.FindControl("listEffort") as DropDownList);



        if (btnEdit.Checked)
        {
            ViewState["Std_Com_Id"] = gvr.Cells[1].Text;

            trSubComments.Visible = false;
            treffort.Visible = false;
            lblAbsent.Text = gvr.Cells[7].Text + " has been absent for this subject this term.We look forward to better attendance next term.";

        }
        else
        {
            trSubComments.Visible = true;
            treffort.Visible = true;
            lblAbsent.Text = "";

        }

        string G1Id = (gvr.Cells[2].Text);
        string G2Id = (gvr.Cells[3].Text);
        string Imp1Id = (gvr.Cells[4].Text);
        string Imp2Id = (gvr.Cells[5].Text);
        string Effort = (gvr.Cells[6].Text);



        if (G1Id != "&nbsp;" || G1Id != String.Empty)
        {
            listG1.SelectedValue = G1Id;

            if (Convert.ToInt32(G1Id) > 0)
            {
                listG1.BackColor = Color.White;
            }
            else
            {
                listG1.BackColor = Color.Yellow;
            }
        }

        if (G2Id != "&nbsp;" || G2Id != String.Empty)
        {
            listG2.SelectedValue = G2Id;
            if (Convert.ToInt32(G2Id) > 0)
            {
                listG2.BackColor = Color.White;
            }
            else
            {
                listG2.BackColor = Color.Yellow;
            }

        }

        if (Imp1Id != "&nbsp;" || Imp1Id != String.Empty)
        {
            listImp1.SelectedValue = Imp1Id;

            if (Convert.ToInt32(Imp1Id) > 0)
            {
                listImp1.BackColor = Color.White;
            }
            else
            {
                listImp1.BackColor = Color.Yellow;
            }
        }

        if (Imp2Id != "&nbsp;" || Imp2Id != String.Empty)
        {
            listImp2.SelectedValue = Imp2Id;

            if (Convert.ToInt32(Imp2Id) > 0)
            {
                listImp2.BackColor = Color.White;
            }
            else
            {
                listImp2.BackColor = Color.Yellow;
            }
        }

        if (Effort != "&nbsp;" || Effort != String.Empty)
        {
            listEffort.SelectedValue = Effort;

            if (Convert.ToInt32(Effort) > 0)
            {
                listEffort.BackColor = Color.White;
            }
            else
            {
                listEffort.BackColor = Color.Yellow;
            }
        }



    }

}