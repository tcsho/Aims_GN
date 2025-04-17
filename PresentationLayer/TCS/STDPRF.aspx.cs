using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;

public partial class PresentationLayer_LMS_STDPRF : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
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
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
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
                pan_New.Attributes.CssStyle.Add("display", "none");

                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "uncheck";
                bindClassSection();
                Bifurcation.Visible = false;


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

            if (_dt.Rows.Count > 0)
            {
                ViewState["Class_Id"] = _dt.Rows[0]["Class_Id"].ToString();
            }

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

            int classid = Convert.ToInt32(dt.Rows[0]["Class_Id"].ToString().Trim());

            ViewState["classid"] = classid;

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
            WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
            objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
            objWLA._ddl = list_ClassSection;
            objWLA.ISWelcomeAcknowledge(objWLA);

            bindTermList();
            bindSubject();
            bindRating();
            ViewState["Table"] = null;
            bindGridView();

            if (list_ClassSection.SelectedItem.Text == "Select")
            {
                list_student.Items.Clear();
                list_student.Items.Insert(0, new ListItem("Select", ""));
                list_term.SelectedIndex = 0;
                list_subject.SelectedIndex = 0;

            }
            else
            {
                list_term.SelectedIndex = 0;
                list_subject.SelectedIndex = -1;
                //list_student.SelectedIndex = 0;
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

            if (list_ClassSection.SelectedValue != "")
            {
                int sectionID = Convert.ToInt32(list_ClassSection.SelectedValue);
                int teacherId = Convert.ToInt32(Session["EmployeeCode"]);

                DataTable dt = null;
                ObjSS.Section_Id = sectionID;
                ObjSS.Employee_Id = teacherId;

                dt = ObjSS.Section_SubjectSelectBySectionTeacherPerformance(ObjSS);

                lab_status.Visible = false;

                objBase.FillDropDown(dt, list_subject, "Section_Subject_Id", "Subject_name");

            }
            list_student.Items.Clear();
            list_student.Items.Insert(0, new ListItem("Select", ""));


        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void bindRating()
    {
        try
        {

            BLLStudent_Performance_ClassAchvRating objbll = new BLLStudent_Performance_ClassAchvRating();



            ddlARate.Items.Clear();

            if (list_ClassSection.SelectedValue != "")
            {
                DataTable dt = new DataTable();
                objbll.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                objbll.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);

                dt = objbll.Student_Performance_ClassAchvRatingFetch(objbll);
                objBase.FillDropDown(dt, ddlARate, "KindClassAchvRating_Id", "RateCode");
                lab_status.Visible = false;
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
            BindStudents();
            PopulateData();
            PageLayoutSettings();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void BindStudents()
    {
        try
        {
            list_student.Items.Clear();

            if (list_subject.SelectedValue != "")
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
            PopulateData();
            PageLayoutSettings();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void PopulateData()
    {
        if (list_student.SelectedValue != "" && list_term.SelectedValue != "" && list_subject.SelectedValue != "")
        {
            RetrieveMaster();
            ViewState["Table"] = null;
            bindGridView();
            
        }
    }
    private void bindGridView()
    {
        try
        {

            int studentId, sectionSubjectId, termId;

            if (list_student.SelectedValue == "0" || list_student.SelectedValue == "" || list_subject.SelectedValue == "0" || list_term.SelectedValue == "0" || list_ClassSection.SelectedValue == "0")
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                Prom1.Visible = false;
                DaysAtt.Visible = false;
                Bifurcation.Visible = false;
                lab_status.Visible = true;
                lab_status.Text = "No data exists";
                dv_details.DataSource = null;
                dv_details.DataBind();
            }
            else
            {

                if (list_term.SelectedValue.ToString() != "23")
                {
                    studentId = Int32.Parse(list_student.SelectedValue);
                    sectionSubjectId = Int32.Parse(list_subject.SelectedValue);
                    termId = Int32.Parse(list_term.SelectedValue);
                    DataRow row = (DataRow)Session["rightsRow"];
                    ViewState["tMood"] = "uncheck";
                    DataTable dt = null;
                    BLLStudent_Performance_Grading_Mst bllObj = new BLLStudent_Performance_Grading_Mst();

                    if (ViewState["Table"] == null)
                    {

                        bllObj.Student_Id = studentId;
                        bllObj.Section_subject_Id = sectionSubjectId;
                        bllObj.Evaluation_Criteria_Type_Id = termId;
                        bllObj.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                        dt = bllObj.Student_Performance_Grading_MstFetchByStudent(bllObj);
                        ViewState["Table"] = dt;
                    }
                    else
                    {
                        dt = (DataTable)ViewState["Table"];
                    }
                    if (dt.Rows.Count == 0)
                    {
                        pan_New.Attributes.CssStyle.Add("display", "none");
                        //Prom1.Visible = false;
                        lab_status.Visible = true;
                        lab_status.Text = "No data exists";
                    }
                    else
                    {
                        dv_details.DataSource = dt;
                        ViewState["Table"] = dt;
                        dv_details.DataBind();
                        lab_dataStatus.Visible = false;
                        lab_status.Visible = false;
                        pan_New.Attributes.CssStyle.Add("display", "inline");
                    }

                    if (list_term.SelectedValue != "")
                    {

                        if (Convert.ToInt32(list_term.SelectedValue) % 2 == 0)
                        {
                            if (Convert.ToInt32(ViewState["Class_Id"].ToString()) < 7)
                            {
                                Prom1.Visible = true;
                            }
                            else
                            {
                                Prom1.Visible = false;
                            }
                            Bifurcation.Visible = false;
                            DaysAtt.Visible = false;
                        }
                        else if (Convert.ToInt32(list_term.SelectedValue) == 23)
                        {
                            Prom1.Visible = false;
                            Bifurcation.Visible = false;
                            DaysAtt.Visible = false;
                        }
                        else
                        {
                            Prom1.Visible = false;
                            Bifurcation.Visible = false;
                            DaysAtt.Visible = false;
                        }

                    }

                }
                else
                {
                    pan_New.Attributes.CssStyle.Add("display", "inline");
                    Prom1.Visible = false;
                    DaysAtt.Visible = false;
                    Bifurcation.Visible = true;
                    lab_status.Visible = true;
                    lab_status.Text = "No data exists";
                    dv_details.DataSource = null;
                    dv_details.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected bool CheckClassTeacher()
    {
        bool chk = false; ;
        try
        {

        if (list_ClassSection.SelectedIndex > 0)
        {
            BLLSection objsec = new BLLSection();

            objsec.Section_Id = Int32.Parse(list_ClassSection.SelectedValue);
            DataTable dt = objsec.SectionFetch(objsec);
            if (dt.Rows.Count > 0)
            {
                int userID = Int32.Parse(Session["ContactId"].ToString());
                int _t;

                if (dt.Rows[0]["Teacher_Id"].ToString() == "")
                {
                    _t = 0;

                }
                else
                {
                    _t = Convert.ToInt32(dt.Rows[0]["Teacher_Id"].ToString());

                }

                if (userID == _t)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                }
            }
        }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        return chk;

    }

    protected void RetrieveMaster()
    {
        try
        {
            ResetControls();
            BLLStudent_Performance_Grading_Mst bllobjMst = new BLLStudent_Performance_Grading_Mst();
            BLLStudent_Performance_Grading_Det bllObj = new BLLStudent_Performance_Grading_Det();
            bllobjMst.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
            bllobjMst.Student_Id = Int32.Parse(list_student.SelectedValue);
            bllobjMst.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);

            int SectionId = Int32.Parse(list_ClassSection.SelectedValue);
            BLLStudent_Performance_Grading_Mst bllOb = new BLLStudent_Performance_Grading_Mst();

            bllobjMst.Section_Id = SectionId;
            bllobjMst.Section_subject_Id = Int32.Parse(list_subject.SelectedValue);
            bllobjMst.Session_Id = Convert.ToInt32(Session["Session_Id"]);

            DataTable _dt = new DataTable();

            _dt = bllobjMst.Student_Performance_Grading_MstFetch(bllobjMst);
            if (_dt.Rows.Count > 0)
            {

                chk_promoted.SelectedValue = Convert.ToBoolean(_dt.Rows[0]["isPromoted"]).ToString();
                txt_TeacherComments.Text = _dt.Rows[0]["ClassTeacherComments"].ToString();
                txt_DaysAttend.Text = _dt.Rows[0]["DaysAttend"].ToString();

                if (_dt.Rows[0]["IslamyatComments"].ToString() != string.Empty)
                {
                    rblBifurcation.SelectedValue = _dt.Rows[0]["IslamyatComments"].ToString();
                }

                ViewState["mode"] = "Edit";
            }
            else
            {
                txt_TeacherComments.Text = "";
                ViewState["mode"] = "Add";
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void DetailAddUpdate(int idMst)
    {
        try
        {
            if (idMst > 0)
            {
                BLLStudent_Performance_Grading_Det bllObj = new BLLStudent_Performance_Grading_Det();

                foreach (GridViewRow gvr in dv_details.Rows)
                {

                    DropDownList ddl = (DropDownList)gvr.FindControl("ddlAchRate");



                    string hdfldRate = gvr.Cells[0].Text;//("Student_Performance_ClassAchvRating_Id");
                    string hdfldid = gvr.Cells[2].Text;//("KndSubStd_Id");
                    string lblId = gvr.Cells[1].Text;//("SubKndItmLbl_Id");


                    TextBox txtbx = (TextBox)gvr.FindControl("txtTest");
                    bllObj.Main_Organisation_id = Int32.Parse(Session["moID"].ToString());
                    bllObj.Section_Subject_Id = Int32.Parse(list_subject.SelectedValue);

                    bllObj.SSSKIL_Id = Int32.Parse(lblId);

                    if (ddl.SelectedIndex > 0)
                    {
                        bllObj.KindClassAchvRating_Id = Int32.Parse(ddl.SelectedValue);
                    }
                    else
                    {
                        bllObj.KindClassAchvRating_Id = 0;
                    }

                    bllObj.KindSubStdMst_Id = idMst;

                    if (hdfldid == "0" || hdfldid == "" || hdfldid == "&nbsp;")//KndSubStd_Id
                    {
                        bllObj.Student_Performance_Grading_DetAdd(bllObj);
                    }
                    else
                    {
                        bllObj.KndSubStd_Id = Int32.Parse(hdfldid);//KndSubStd_Id
                        bllObj.Student_Performance_Grading_DetUpdate(bllObj);
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
    public bool IsEmpty()
    {
        //try
        //{
        bool isemp = false;

        if (Convert.ToInt32(ViewState["Class_Id"].ToString()) >= 7)
        {

            foreach (GridViewRow gvr in dv_details.Rows)
            {

                DropDownList ddl = (DropDownList)gvr.FindControl("ddlAchRate");


                if (Int32.Parse(ddl.SelectedValue) == 0)
                {
                    isemp = true;
                }

            }
        }
        return isemp;
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }

    protected void lbAssingAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvr in dv_details.Rows)
            {
                DropDownList ddl = (DropDownList)gvr.FindControl("ddlAchRate");
                if (ddl.Visible == true)
                {
                    ddl.SelectedValue = ddlARate.SelectedValue;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void dv_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            dv_details.PageIndex = e.NewPageIndex;
            bindGridView();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }


    protected void dv_details_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["Table"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            //bindGridView();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            int _classId = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("ddlAchRate");
                DropDownList ddlAchRate = (DropDownList)e.Row.FindControl("ddlAchRate");
                //TextBox txtb = (TextBox)e.Row.FindControl("txtTest");
                if (ctrl != null)
                {

                    try
                    {
                        BLLStudent_Performance_ClassAchvRating objbll = new BLLStudent_Performance_ClassAchvRating();

                        if (e.Row.RowIndex != -1)
                        {

                            ddlAchRate.Items.Clear();

                            if (list_ClassSection.SelectedValue != "")
                            {
                                DataTable dt = new DataTable();
                                objbll.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                                objbll.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);

                                dt = objbll.Student_Performance_ClassAchvRatingFetch(objbll);
                                objBase.FillDropDown(dt, ddlAchRate, "KindClassAchvRating_Id", "RateCode");
                                lab_status.Visible = false;
                            }

                            if (bool.Parse(e.Row.Cells[8].Text) == true)
                            {
                                ddlAchRate.ForeColor = Color.Indigo;
                                ddlAchRate.Enabled = false;
                                ddlAchRate.ToolTip = "Marks editing is locked.";
                            }
                            else
                            {
                                ddlAchRate.Enabled = true;

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Session["error"] = ex.Message;
                        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
                    }

                }
                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    ddlAchRate.SelectedValue = e.Row.Cells[0].Text;
                }
                else
                {
                    ddlAchRate.SelectedValue = "0";
                }


                if (e.Row.Cells[3].Text == "True")
                {
                    ddlAchRate.Visible = false;
                    //   txtb.Visible = true;
                }
                else
                {
                    ddlAchRate.Visible = true;
                    // txtb.Visible = false;
                }
            }
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
            //ViewState["getData"] = 0;
            list_student.SelectedIndex = 0;
            list_term.SelectedIndex = 0;
            list_ClassSection.SelectedIndex = 0;
            list_subject.SelectedIndex = 0;
            bindGridView();
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
            int idMst = 0;
            BLLStudent_Performance_Grading_Mst bllobjMst = new BLLStudent_Performance_Grading_Mst();
            //2025-01-01
            if (txt_TeacherComments.Text.ToString().Trim().Length >= 500)
            {

                ImpromptuHelper.ShowPromptGeneric("Teacher Comments Exceeding From 500 characters :", 0);
                return;
            }





            if (IsEmpty() == false)
            {



                int _class_Id, _term_Id;
                _class_Id = Convert.ToInt32(ViewState["Class_Id"].ToString());
                _term_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
                if (_class_Id < 7 && _term_Id % 2 == 0)
                {
                    if (chk_promoted.SelectedItem == null)
                    {
                        ImpromptuHelper.ShowPrompt("Please select Student Promotion Status!");
                        return;
                    }
                    else
                    {
                        bllobjMst.isPromoted = Convert.ToBoolean(chk_promoted.SelectedValue);
                    }

                }






                bllobjMst.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                bllobjMst.Student_Id = Int32.Parse(list_student.SelectedValue);
                bllobjMst.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
                bllobjMst.Section_Id = Int32.Parse(list_ClassSection.SelectedValue);
                bllobjMst.Section_subject_Id = Int32.Parse(list_subject.SelectedValue);
                bllobjMst.Status_Id = 1;

                bllobjMst.ClassTeacherComments = txt_TeacherComments.Text;
                bllobjMst.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                bllobjMst.Main_Organistion_Id = Convert.ToInt32(Session["moID"]);

                bllobjMst.IslamyatComments = rblBifurcation.SelectedValue;
                bllobjMst.ICTRemarks = "";// txt_ICT.Text;
                bllobjMst.DaysAttend = txt_DaysAttend.Text;


                DataTable _dt = new DataTable();
                _dt = bllobjMst.Student_Performance_Grading_MstFetch(bllobjMst);


                if (_dt.Rows.Count <= 0)
                {
                    bllobjMst.CreatedOn = DateTime.Now;
                    bllobjMst.CreatedBy = Int32.Parse(Session["ContactId"].ToString());
                    idMst = bllobjMst.Student_Performance_Grading_MstAdd(bllobjMst);
                    if (list_term.SelectedValue.ToString() != "23")
                        DetailAddUpdate(idMst);
                    ImpromptuHelper.ShowPrompt("Record Added Successfully.");
                }
                else
                {
                    bllobjMst.KindSubStdMst_Id = Convert.ToInt32(_dt.Rows[0]["KindSubStdMst_Id"].ToString());
                    bllobjMst.ModifiedOn = DateTime.Now;
                    bllobjMst.ModifiedBy = Int32.Parse(Session["ContactId"].ToString());
                    bllobjMst.Student_Performance_Grading_MstUpdate(bllobjMst);
                    if (list_term.SelectedValue.ToString() != "23")
                    {
                        DetailAddUpdate(bllobjMst.KindSubStdMst_Id);

                    }
                }
                ImpromptuHelper.ShowPrompt("Record Updated Successfully.");
                ViewState["Table"] = null;
                bindGridView();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please check some data is missing for Performance grading.");
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }







    private void ResetControls()
    {
        try
        {
            txt_DaysAttend.Text = "";
            txt_TeacherComments.Text = "";
            //txt_Islamiat.Text = "";
            //txt_ICT.Text = "";
            //chk_promoted.Checked = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void DeleteDetail()
    {
        try
        {

            BLLStudent_Performance_Grading_Det bllObjDet = new BLLStudent_Performance_Grading_Det();


            CheckBox cb = null;

            foreach (GridViewRow gvr in dv_details.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (cb.Checked)
                {
                    bllObjDet.KndSubStd_Id = Convert.ToInt32(gvr.Cells[2].Text.ToString());
                    bllObjDet.Student_Performance_Grading_DetDelete(bllObjDet);
                }
            }
            ViewState["Table"] = null;
            bindGridView();
            txtcount.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void txtcount_TextChanged(object sender, EventArgs e)
    {

    }

    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PopulateData();
            PageLayoutSettings();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void PageLayoutSettings()
    {
        int termId = Int32.Parse(list_term.SelectedValue);


        if (Convert.ToInt32(ViewState["classid"]) > 12)
        {

            if (Convert.ToInt32(ViewState["classid"]) == 17 || Convert.ToInt32(ViewState["classid"]) == 18)
            {
                trComment.Visible = true;
                Prom1.Visible = false;
                chk_promoted.Visible = false;

            }
            else
            {
                trComment.Visible = false;
                Prom1.Visible = false;
                chk_promoted.Visible = false;

            }

        }
        else
        {
            trComment.Visible = true;
            if (Convert.ToInt32(ViewState["classid"]) < 7 && termId % 2 == 0)
            {
                chk_promoted.Visible = true;  
                Prom1.Visible = true;  
            }
            else
            {
                chk_promoted.Visible = false;    
                Prom1.Visible = false;

            }
            
        }

        if (Convert.ToInt32(ViewState["classid"]) <= 6)
        {

            lblteacher.Text = "Class Teacher Comments (maximum <strong>500</strong> characters with spaces):";
        }
        else
        {

            lblteacher.Text = " Club / Societies / Co-Curricular Activities(maximum <strong>500</strong> characters with spaces):";
        }
    }
}
