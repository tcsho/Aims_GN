using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;
using System.Text.RegularExpressions;


public partial class PresentationLayer_TCS_Admission_Registeration_Evaluation_Criteria : System.Web.UI.Page
{
    BLLAdmission_Registeration_Evaluation_Criteria objAdm = new BLLAdmission_Registeration_Evaluation_Criteria();
    BLLStudent_AdmRegistration student = new BLLStudent_AdmRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["Regisration_Id"] = "";
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (!IsPostBack)
        {
            if (Session["Regisration_Id"] != null)
            {

                txtRegisterationID.Text = Session["Regisration_Id"].ToString();
                txtRegisterationID_TextChanged(this, EventArgs.Empty);
                objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);

                if (Session["Group_Type"] != null && Session["Group_Type"].ToString() != "Not Applicable" && Session["Class_Id"].ToString() == "13")
                {
                    ddlGroup.SelectedValue = Session["Group_Type"].ToString();
                    ddlGroup.Enabled = false;
                }

                DataRow row = (DataRow)Session["rightsRow"];

                if (row["User_Type_Id"].ToString() == "27")
                {
                    BindGrid();
                    int k = objAdm.Admission_RegisterationTestMarksUpdate(objAdm);
                    ViewState["dtDetails"] = null;
                    BindGrid();
                    btnSave.Visible = false;
                }

            }

        }
    }
    protected void txtRegisterationID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblUrdu.Visible = true;
            rblSkipUrdu.Visible = true;
            ViewState["Status"] = "";
            gv_subject.DataSource = null;
            gv_subject.DataBind();
            gvAlevelMarks.DataSource = null;
            gvAlevelMarks.DataBind();
            gvCriteria.DataSource = null;
            gvCriteria.DataBind();
            trUpdateMarks.Visible = false;
            ResetPolicy();

            DataTable dt = new DataTable();
            string s = Session["cId"].ToString();

            if (Session["cId"].ToString().Length > 0 && Session["cId"] != null)
                student.Center_Id = Convert.ToInt32(Session["cId"].ToString());
            else if (Session["Center_Id"] != null && Session["Center_Id"].ToString().Length > 0)
                student.Center_Id = Convert.ToInt32(Session["Center_Id"].ToString());
            else
                student.Center_Id = 0;
            student.Regisration_Id = Convert.ToInt32(txtRegisterationID.Text);
            dt = student.Student_AdmRegistrationFetch(student);
            if (dt.Rows.Count > 0)
            {
                // trStudentDetails.Visible = true;
                lblRegisteration.Text = dt.Rows[0]["Regisration_Id"].ToString();
                lblStudent.Text = dt.Rows[0]["StudentName"].ToString();
                student.StudentName = dt.Rows[0]["StudentName"].ToString();
                lblFather.Text = dt.Rows[0]["FatherName"].ToString();
                lblCenter.Text = dt.Rows[0]["Center_Name"].ToString();
                lblRegion.Text = dt.Rows[0]["Region_Name"].ToString();
                lblClass.Text = dt.Rows[0]["Class_Name"].ToString();
                DateTime d = Convert.ToDateTime(dt.Rows[0]["Admission_Date"].ToString());
                lblDate.Text = d.Date.ToString("d");
                if (dt.Rows[0]["Gender_Id"].ToString() == "M")
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Female";
                }
                ViewState["Center_Id"] = dt.Rows[0]["Center_Id"].ToString();
                ViewState["Class_Id"] = dt.Rows[0]["Grade_Id"].ToString();
                tblStudentDetails.Visible = true;
                ViewState["dtDetails"] = null;

                int i = Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString());
                if (Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString()) >= (int)AdmissionClasses.A1)//Bind OLevel Grid for class A1
                {
                    if (Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString()) == (int)AdmissionClasses.A1 ||
                        Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString()) == (int)AdmissionClasses.A2)
                    {
                        lblUrdu.Visible = false;
                        rblSkipUrdu.Visible = false;
                    }
                    ddlGroup.Visible = false;
                    lblOlevels.Text = "";
                    BindGridforOlevels(this);
                }
                else if (Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString()) >= (int)AdmissionClasses.Olevel1 &&
                    Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString()) < (int)AdmissionClasses.A1)
                //|| dt.Rows[0]["Grade_Id"].ToString() == "20")// take no action for A2, 10 and11
                {

                    ddlGroup.Visible = false;
                    lblOlevels.Text = "";
                    ImpromptuHelper.ShowPrompt("As per Admission Policy, Admission Test is not applicable for this Class Level.");
                    btnSave.Visible = false;
                }
                else if (dt.Rows[0]["Grade_Id"].ToString() == ((int)AdmissionClasses.Class9).ToString()) //Group Selection Class 9 Olevel
                {
                    ddlGroup.Visible = true;
                    lblOlevels.Text = "Subject Group Candidate wish to join: ";
                    BLLAdmission_Center_Evaluation_Criteria obj = new BLLAdmission_Center_Evaluation_Criteria();
                    obj.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
                    obj.Center_Id = Convert.ToInt32(Session["cId"].ToString());
                    obj.Class_Id = Convert.ToInt32(dt.Rows[0]["Grade_Id"].ToString());
                    DataTable dts = obj.Admission_Center_Evaluation_CriteriaSelectByCenterId(obj);
                    if (dts.Rows.Count == 0)
                    {
                        ddlGroup.Enabled = true;
                        ddlGroup.SelectedValue = "Select";
                        btnSave.Visible = false;
                    }
                    else
                    {
                        foreach (DataRow r in dts.Rows)
                        {
                            if (r["Subject_Id"].ToString() == ((int)SubjectList.Science).ToString()) //Science
                            {
                                ddlGroup.SelectedValue = SubjectList.Science.ToString();
                                break;
                            }
                            else
                            {
                                ddlGroup.SelectedValue = SubjectList.Business.ToString();
                            }
                        }
                        ddlGroup.Enabled = false;
                        BindGrid();
                        // ddlGroup_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                }
                else
                {
                    ddlGroup.Visible = false;
                    lblOlevels.Text = "";
                    BindGrid();
                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Sorry the Registration Number doesn't exists!");
                btnSave.Visible = false;
                divMarks.Visible = false;
                tdSearch.Visible = false;
                tblStudentDetails.Visible = false;
                lblRegisteration.Text = "";
                lblStudent.Text = "";
                lblFather.Text = "";
                lblCenter.Text = "";
                lblRegion.Text = "";
                lblClass.Text = "";
                lblDate.Text = "";
                lblGender.Text = "";
                tblStudentDetails.Visible = false;
                trOverallPolicy.Visible = false;
                trPolicy.Visible = false;
                trHeadingPolicy.Visible = false;
                trUpdateMarks.Visible = false;
                trAdditionalPolicy.Visible = false;
                ddlGroup.Visible = false;
                trNotApplicable.Visible = false;
                gv_subject.DataSource = null;
                gv_subject.DataBind();
                gvAlevelMarks.DataSource = null;
                gvAlevelMarks.DataBind();
                gvCriteria.DataSource = null;
                gvCriteria.DataBind();
                ResetPolicy();
                lblOlevels.Text = "";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGridforOlevels(object sender)
    {
        try
        {
            trUpdateMarks.Visible = true;
            btnSave.Visible = true;
            BLLAdmission_Registeration_Alevel objreg = new BLLAdmission_Registeration_Alevel();
            objreg.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
            DataTable dtbl = objreg.Admission_Registeration_AlevelFetch(objreg);
            if (dtbl.Rows.Count == 0)
            {
                ViewState["Mode"] = "FirstStepOlevels";
                BLLClass_Subject obj = new BLLClass_Subject();
                obj.Class_ID = (int)AdmissionClasses.Olevel2;// class id of olevels 
                DataTable dt = obj.Class_SubjectFetchOlevelsSubjects(obj);
                int StudentClass = Convert.ToInt32(ViewState["Class_Id"].ToString());
                gv_subject.DataSource = dt;
                gv_subject.DataBind();
                gv_subject.Visible = true;
                gvAlevelMarks.DataSource = null;
                gvAlevelMarks.DataBind();
                gvAlevelMarks.Visible = false;
                if (StudentClass == (int)AdmissionClasses.Olevel1 || StudentClass == (int)AdmissionClasses.Olevel2)
                {
                    foreach (GridViewRow row in gv_subject.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[2].Text) >= (int)SubjectList.MaxCompSuject
                            && Convert.ToInt32(row.Cells[2].Text) < (int)SubjectList.MinCompSuject)//default subjects marked
                        {
                            CheckBox chkSubject = (CheckBox)row.FindControl("cbSubject");
                            chkSubject.Checked = true;
                        }
                    }
                }
            }
            else if (dtbl.Rows.Count > 0)
            {
                ViewState["Mode"] = "SecondStepOlevels";
                gv_subject.DataSource = null;
                gv_subject.DataBind();
                gv_subject.Visible = false;
                gvAlevelMarks.DataSource = dtbl;
                gvAlevelMarks.DataBind();
                gvAlevelMarks.Visible = true;
                if (dtbl.Rows[0]["Lock_Marks"].ToString() == "True")
                {
                    BindPolicyGrid();
                    btnSave.Visible = false;
                }
                foreach (DataRow row in dtbl.Rows)
                {
                    if (row["Lock_Marks"].ToString() == "True")
                    {
                        foreach (GridViewRow r in gvAlevelMarks.Rows)
                        {
                            DropDownList ddlCriteria = (DropDownList)r.FindControl("ddlCriteria");
                            if (Convert.ToInt32(r.Cells[2].Text) == Convert.ToInt32(row["Subject_Id"].ToString()))
                            {
                                ddlCriteria.SelectedValue = row["Marks_Obtained"].ToString();
                                ddlCriteria.Enabled = false;
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

    protected void BindGrid()
    {
        try
        {

            gv_subject.DataSource = null;
            gv_subject.DataBind();
            gv_subject.Visible = false;
            gvAlevelMarks.DataSource = null;
            gvAlevelMarks.DataBind();
            gvAlevelMarks.Visible = false;
            ViewState["Mode"] = "Others";
            DataTable dt = new DataTable();
            BLLAdmission_Center_Evaluation_Criteria obj = new BLLAdmission_Center_Evaluation_Criteria();
            obj.Center_Id = Convert.ToInt32(ViewState["Center_Id"].ToString());
            obj.Class_Id = Convert.ToInt32(ViewState["Class_Id"].ToString());
            DataTable dtInsert = obj.Admission_Center_Evaluation_CriteriaSelectACEC(obj);
            if (dtInsert.Rows.Count == 0)
            {
                ImpromptuHelper.ShowPrompt("No Criteria Defined for this Class!");
                btnSave.Visible = false;
                trOverallPolicy.Visible = false;
                trHeadingPolicy.Visible = false;
                trPolicy.Visible = false;
                trUpdateMarks.Visible = false;
                return;
            }
            else
            {

                if (obj.Class_Id == (int)AdmissionClasses.Class9 && ddlGroup.SelectedValue == SubjectList.Business.ToString())
                {
                    DataTable dtInsertOlevel = dtInsert.Clone();
                    foreach (DataRow r in dtInsert.Rows)
                    {
                        if (r["Subject_Id"].ToString() != ((int)SubjectList.Science).ToString())//add all others except science
                        {
                            dtInsertOlevel.ImportRow(r);
                        }

                    }
                    if (dtInsertOlevel.Rows.Count == 0)
                    {
                        ImpromptuHelper.ShowPrompt("No Criteria defined for Business Group");
                        return;
                    }
                    else
                    {
                        InsertDefault(dtInsertOlevel);
                    }
                }
                else
                    InsertDefault(dtInsert);
                obj.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
                if (ViewState["dtDetails"] == null)
                {
                    dt = obj.Admission_Center_Evaluation_CriteriaSelectByCenterId(obj);
                    ViewState["dtDetails"] = dt;
                    if (dt.Rows.Count > 0)
                    {
                        tdSearch.Visible = true;
                        trUpdateMarks.Visible = true;
                        foreach (DataRow dr in dt.Rows)
                        {

                            if (dr["Lock_Marks"].ToString() == "False")
                            {
                                rblSkipUrdu.Enabled = true;
                                rblSkipUrdu.Visible = true;
                                ddlGroup.Enabled = true;
                                btnSave.Visible = true;
                                trOverallPolicy.Visible = false;
                                trHeadingPolicy.Visible = false;
                                trPolicy.Visible = false;

                                break;
                            }
                            else
                            {
                                if (dr["Subject_Id"].ToString() == ((int)SubjectList.UrduJr).ToString())
                                {
                                    lblUrdu.Text = "Skip Urdu for Foreign Student: No";///hasn't skipped urdu

                                    rblSkipUrdu.Visible = false;
                                    rblSkipUrdu.Enabled = false;
                                    ddlGroup.Enabled = false;
                                    btnSave.Visible = false;
                                    BindPolicyGrid();
                                    break;
                                }
                                else
                                {
                                    lblUrdu.Text = "Skip Urdu for Foreign Student: Yes"; //skipped Urdu

                                    rblSkipUrdu.Visible = false;
                                    rblSkipUrdu.Enabled = false;
                                    ddlGroup.Enabled = false;
                                    btnSave.Visible = false;
                                    BindPolicyGrid();
                                }


                            }
                        }
                    }
                }
                else
                {
                    dt = (DataTable)ViewState["dtDetails"];
                }
                if (dt.Rows.Count == 0)
                {
                    SetEmptyGrid(gvCriteria);
                }
                gvCriteria.DataSource = dt;
                gvCriteria.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void SetEmptyGrid(GridView gv)
    {

        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("ACEC_Id");
            dt.Columns.Add("Subject_Id");
            dt.Columns.Add("Session_Id");
            dt.Columns.Add("Class_Id");
            dt.Columns.Add("Criteria");
            dt.Columns.Add("Center_Id");
            dt.Columns.Add("Weightage");
            dt.Columns.Add("Lock_Marks");
            dt.Columns.Add("Total_Marks");
            dt.Columns.Add("Marks_Obtained");
            dt.Rows.Add(dt.NewRow());
            gv.DataSource = dt;
            gv.DataBind();
            ImpromptuHelper.ShowPrompt("No Criteria Defined!");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvCriteria_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvCriteria.Rows.Count > 0)
            {
                gvCriteria.UseAccessibleHeader = false;
                gvCriteria.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gv_subject_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_subject.Rows.Count > 0)
            {
                gv_subject.UseAccessibleHeader = false;
                gv_subject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvAlevelMarks_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvAlevelMarks.Rows.Count > 0)
            {
                gvAlevelMarks.UseAccessibleHeader = false;
                gvAlevelMarks.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        try
        {
            if (ViewState["Mode"].ToString() == "Others")
            {
                foreach (GridViewRow row in gvCriteria.Rows)
                {
                    objAdm.ACEC_Id = Convert.ToInt32(row.Cells[1].Text);
                    TextBox txtMark = row.Cells[8].FindControl("txtMarks") as TextBox;
                    txtMark.BackColor = Color.Gray;
                    txtMark.ReadOnly = true;
                    objAdm.Marks_Obtained = Convert.ToDecimal(txtMark.Text);
                    objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
                    int k = objAdm.Admission_Registeration_Evaluation_CriteriaUpdate(objAdm);
                }
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else if (ViewState["Mode"].ToString() == "FirstStepOlevels")
            {
                // insert and bind grid 
                CheckBox chkSubject; CheckBox chkIntend;
                int countIntend = 0;
                int countsubject = 0;

                int classId = Convert.ToInt32(ViewState["Class_Id"].ToString());

                if (classId == (int)AdmissionClasses.Olevel1 || classId == (int)AdmissionClasses.Olevel2)
                {
                    foreach (GridViewRow gvr in gv_subject.Rows)
                    {
                        chkIntend = (CheckBox)gvr.FindControl("cbIntend");
                        if (chkIntend.Checked == true)
                        {
                            countIntend++;
                        }
                        chkSubject = (CheckBox)gvr.FindControl("cbSubject");
                        if (chkSubject.Checked == true)
                        {
                            countsubject++;
                        }
                    }
                    if ((countIntend == (int)SubjectRestrictions.OlevelSubjectIntended ||
                        countIntend > (int)SubjectRestrictions.OlevelSubjectIntended)
                        && (countsubject == (int)SubjectRestrictions.OlevelSubjectTaken
                        || countsubject > (int)SubjectRestrictions.OlevelSubjectTaken))
                    {
                        OAlevelSecondStep();
                    }

                }
                if (classId == (int)AdmissionClasses.A1 || classId == (int)AdmissionClasses.A2)
                {
                    OAlevelSecondStep();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please select minimun"+ ((int)SubjectRestrictions.OlevelSubjectIntended).ToString() + 
                        "Intended and"+ ((int)SubjectRestrictions.OlevelSubjectTaken).ToString()+ " Studied Subjects");
                }
            }
            else if (ViewState["Mode"].ToString() == "SecondStepOlevels")
            {
                SecondStep();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void OAlevelSecondStep()
    {
        BLLAdmission_Registeration_Alevel obj = new BLLAdmission_Registeration_Alevel();
        obj.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
        foreach (GridViewRow gvr in gv_subject.Rows)
        {
            var chkSubject = (CheckBox)gvr.FindControl("cbSubject");
            var chkIntend = (CheckBox)gvr.FindControl("cbIntend");
            obj.Subject_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Marks_Obtained = "0";
            if (chkIntend.Checked && chkSubject.Checked)
            {
                obj.IsStudy = true;
                obj.IntendtoStudy = true;
                obj.Admission_Registeration_AlevelAdd(obj);
            }
            if (chkSubject.Checked == true && chkIntend.Checked == false)
            {
                obj.IsStudy = true;
                obj.IntendtoStudy = false;
                obj.Admission_Registeration_AlevelAdd(obj);
            }
            if (chkIntend.Checked == true && chkSubject.Checked == false)
            {
                obj.IsStudy = false;
                obj.IntendtoStudy = true;
                obj.Admission_Registeration_AlevelAdd(obj);
            }
            if (chkIntend.Checked == false && chkSubject.Checked == false)
            {

            }
        }
        BindGridforOlevels(this);
    }
    protected void SecondStep()
    {
        BLLAdmission_Registeration_Alevel obj = new BLLAdmission_Registeration_Alevel();
        foreach (GridViewRow r in gvAlevelMarks.Rows)
        {
            DropDownList ddlCriteria = (DropDownList)r.FindControl("ddlCriteria");
            if (ddlCriteria.SelectedValue == "0")
            {
                ImpromptuHelper.ShowPrompt("Please input marks for all subjects");
                return;
            }
            obj.Marks_Obtained = ddlCriteria.SelectedValue;
            obj.Subject_Id = Convert.ToInt32(r.Cells[2].Text);
            obj.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
            obj.Admission_Registeration_AlevelUpdate(obj);
        }
        BindGridforOlevels(this);
    }
    protected void ResetPolicy()
    {
        try
        {
            trHeadingPolicy.Visible = false;
            trPolicy.Visible = false;
            trOverallPolicy.Visible = false;
            trAdditionalPolicy.Visible = false;
            trNotApplicable.Visible = false;
            lblEnglishPolicy.Text = "";
            lblEnglish.Text = "";
            lblPercentage.Text = "";
            lblOverallPolicy.Text = "";
            lblOverall.Text = "";
            lblOverallPercentage.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindPolicyGrid()
    {
        try
        {
            int count = 0; string detail = "";
            objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
            DataTable dtEnglish = objAdm.Admission_Registeration_Evaluation_CriteriaEnglishPolicy(objAdm.Registeration_Id);
            DataTable dtOverall = objAdm.Admission_Registeration_Evaluation_CriteriaOverallPolicy(objAdm.Registeration_Id);
            foreach (DataRow r in dtEnglish.Rows)
            {
                lblEnglishPolicy.Text = "<b>" + r["PolicyDetail"].ToString() + r["Policy"].ToString() + " </b>";
                lblEnglish.Text = "<b>" + r["Obtained"].ToString() + " : </b>";
                lblPercentage.Text = r["Percentage"].ToString() + "    ";

                detail = "English " + r["Policy"].ToString() + "(" + r["Percentage"].ToString() + "),";
                if (r["Student_Status"].ToString() == "0")
                {
                    spFailEnglish.Visible = true;
                    spPassEnglish.Visible = false;
                }
                else if (r["Student_Status"].ToString() == "1")
                {
                    spFailEnglish.Visible = false;
                    spPassEnglish.Visible = true;
                    count++;
                }
            }
            foreach (DataRow r in dtOverall.Rows)
            {
                lblOverallPolicy.Text = "<b>" + r["PolicyDetail"].ToString() + r["Policy"].ToString() + " </b>";
                lblOverall.Text = "<b>" + r["Obtained"].ToString() + " : </b>";
                lblOverallPercentage.Text = r["Percentage"].ToString() + "";
                detail = detail + "Overall " + r["Policy"].ToString() + "(" + r["Percentage"].ToString() + ")";
                if (r["Student_Status"].ToString() == "0")
                {
                    spOverallFail.Visible = true;
                    spOverallPass.Visible = false;
                }
                else if (r["Student_Status"].ToString() == "1")
                {
                    spOverallFail.Visible = false;
                    spOverallPass.Visible = true;
                    count++;
                }
            }
            if (ViewState["Class_Id"].ToString() == "13" && ddlGroup.SelectedValue == "Science")// 9 Olevels Science group students 
            {
                trAdditionalPolicy.Visible = true;
                objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
                DataTable dtScience = new DataTable();
                dtScience = objAdm.Admission_Registeration_Evaluation_CriteriaSciencePolicy(objAdm.Registeration_Id);
                foreach (DataRow r in dtScience.Rows)
                {
                    lblAdditionalPolicy.Text = "<b>" + r["PolicyDetail"].ToString() + r["Policy"].ToString() + " </b></br>";
                    lblAdditional.Text = "<b>" + r["Obtained"].ToString() + "  </b> ";
                    lblAdditionalPercentage.Text = r["Percentage"].ToString() + "  ";
                    lblNotApplicable.Text = "";
                    detail = detail + ", Science " + r["Policy"].ToString() + "(" + r["Percentage"].ToString() + ")";
                    if (r["Student_Status"].ToString() == "0")
                    {
                        spAdditionalFail.Visible = true;
                        spAdditionalPass.Visible = false;
                    }
                    else if (r["Student_Status"].ToString() == "1")
                    {
                        spAdditionalFail.Visible = false;
                        spAdditionalPass.Visible = true;
                        count++;
                    }
                }
            }
            if (ViewState["Class_Id"].ToString() == "19") //Alevels Rule 3 
            {
                trAdditionalPolicy.Visible = true;
                trNotApplicable.Visible = true;
                DataTable dtAdditional = objAdm.Admission_Registeration_AlevelRule3(Convert.ToInt32(txtRegisterationID.Text));
                foreach (DataRow r in dtAdditional.Rows)
                {
                    lblAdditionalPolicy.Text = "<b>" + r["PolicyDetail"].ToString() + r["Policy"].ToString() + " </b></br>";
                    lblAdditional.Text = "<b>" + r["Obtained"].ToString() + "  </b></br>";
                    lblAdditionalPercentage.Text = r["Percentage"].ToString() + "  ";
                    lblNotApplicable.Text = "<b>" + r["AdditionalPolicy"] + "</b>  ";

                    if (!String.IsNullOrEmpty(r["Policy"].ToString()) && !String.IsNullOrEmpty(r["Percentage"].ToString()))
                        detail = detail + ", Overall(Alevels) " + r["Policy"].ToString() + "(" + r["Percentage"].ToString() + ")";

                    if (r["Student_Status"].ToString() == "0")
                    {
                        spAdditionalFail.Visible = true;
                        spAdditionalPass.Visible = false;
                    }
                    else if (r["Student_Status"].ToString() == "1")
                    {
                        spAdditionalFail.Visible = false;
                        spAdditionalPass.Visible = true;
                        count++;
                    }
                    else
                    {
                        spAdditionalFail.Visible = false;
                        spAdditionalPass.Visible = false;
                        count++;
                    }
                }

            }
            else if (ViewState["Class_Id"].ToString() != "19" && (ViewState["Class_Id"].ToString() != "13" && ddlGroup.SelectedValue != "Science"))
            {
                trAdditionalPolicy.Visible = false;
                lblAdditional.Text = "";
                lblAdditionalPercentage.Text = "";
                lblAdditionalPercentage.Text = "";
            }
            InsertERP(count, detail);
            trHeadingPolicy.Visible = true;
            trPolicy.Visible = true;
            trOverallPolicy.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void InsertERP(int count, string detail)
    {
        try
        {
            objAdm.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            bool status = false; int k = -1;
            objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
            if (ViewState["Class_Id"].ToString() == "19" || (ViewState["Class_Id"].ToString() == "13" && ddlGroup.SelectedValue == "Science"))
            {
                if (count == 3)
                    status = true;
            }
            else
            {
                if (count == 2)
                    status = true;
            }
            if (status == true)//pass
            {
                k = objAdm.Admission_Registeration_ERPInsert(objAdm.Registeration_Id, "Pass", detail, objAdm.User_Id);
            }
            else
            {
                k = objAdm.Admission_Registeration_ERPInsert(objAdm.Registeration_Id, "Fail", detail, objAdm.User_Id);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void InsertDefault(DataTable dt)
    {
        try
        {
            string s = ViewState["Status"].ToString();
            foreach (DataRow row in dt.Rows)
            {
                objAdm.ACEC_Id = Convert.ToInt32(row.Field<int>("ACEC_Id"));
                objAdm.Marks_Obtained = 0;
                objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
                int k = objAdm.Admission_Registeration_Evaluation_CriteriaAdd(objAdm, s);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void txtMarks_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow myRow = ((Control)sender).Parent.Parent as GridViewRow;
            myRow.FindControl("txtMarks").Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["dtDetails"] = null;
            ViewState["Status"] = "Group Change";
            gvCriteria.DataSource = null;
            gvCriteria.DataBind();
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvCriteria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int NumCells = e.Row.Cells.Count;
                for (int i = 0; i < NumCells - 1; i++)
                {
                    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void rblSkipUrdu_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Status"] = "";
            if (ViewState["Class_Id"].ToString() == ((int)SubjectList.UrduJr).ToString() && ddlGroup.SelectedIndex <= 0)
            {
                return;
            }
            objAdm.Registeration_Id = Convert.ToInt32(txtRegisterationID.Text);
            objAdm.Center_Id = Convert.ToInt32(ViewState["Center_Id"].ToString());
            objAdm.Class_Id = Convert.ToInt32(ViewState["Class_Id"].ToString());
            if (Convert.ToBoolean(rblSkipUrdu.SelectedValue) == true)
                objAdm.Status_Id = 2;
            else if (Convert.ToBoolean(rblSkipUrdu.SelectedValue) == false)
                objAdm.Status_Id = 1;
            objAdm.Admission_RegisterationTestSkipUrdu(objAdm);
            ViewState["dtDetails"] = null;
            gvCriteria.DataSource = null;
            gvCriteria.DataBind();
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

}