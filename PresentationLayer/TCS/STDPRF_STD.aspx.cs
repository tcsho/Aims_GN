using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Drawing;

public partial class PresentationLayer_TCS_STDPRF_STD : System.Web.UI.Page
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
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
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
            if (_dt.Rows.Count > 0)
            {
                ViewState["Class_Id"] = _dt.Rows[0]["Class_Id"].ToString();
            }

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
            if (dt.Rows.Count > 0)
            {

            }
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
            if (list_ClassSection.SelectedIndex > 0)
            {
                objWLA._ddl = list_ClassSection;
                objWLA.ISWelcomeAcknowledge(objWLA);

                bindTermList();
                BindStudents();
                bindRating();
                ViewState["Table"] = null;
                bindGridView();

            }
            if (list_ClassSection.SelectedItem.Text == "Select")
            {
                list_student.Items.Clear();
                list_student.Items.Insert(0, new ListItem("Select", ""));
                list_term.SelectedIndex = 0;

            }
            else
            {
                list_term.SelectedIndex = 0;
                //list_student.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
                ViewState["Rating"] = dt;
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

    //protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int moID = Int32.Parse(Session["moID"].ToString());
    //    if (list_subject.SelectedValue.ToString() != "")
    //    {
    //        BindStudents();
    //        ViewState["Table"] = null;
    //        bindGridView();
    //    }
    //}



    protected void BindStudents()
    {
        try
        {
            list_student.Items.Clear();

            if (list_ClassSection.SelectedValue != "")
            {
                BLLStudent_Section_Subject objStd = new BLLStudent_Section_Subject();

                objStd.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue.ToString());
                objStd.Student_Status_Id = 5;
                DataTable dt = null;
                list_student.Enabled = true;
                dt = objStd.Student_Section_SubjectFetchBySectionID(objStd);
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
        if (list_student.SelectedValue != "" && list_term.SelectedValue != "" && list_ClassSection.SelectedValue != "")
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

            if (list_student.SelectedValue == "0" || list_student.SelectedValue == "" || list_term.SelectedValue == "0" || list_ClassSection.SelectedValue == "0")
            {
                pan_New.Attributes.CssStyle.Add("display", "none");
                Prom1.Visible = false;
                lab_status.Visible = true;
                lab_status.Text = "No data exists";
                dv_details.DataSource = null;
                dv_details.DataBind();
            }
            else
            {


                DataRow row = (DataRow)Session["rightsRow"];
                ViewState["tMood"] = "uncheck";
                DataTable dt = null;
                BLLStudent_Performance_Grading_Mst bllObj = new BLLStudent_Performance_Grading_Mst();

                if (ViewState["Table"] == null)
                {

                    bllObj.Student_Id = Int32.Parse(list_student.SelectedValue);
                    bllObj.Evaluation_Criteria_Type_Id = Int32.Parse(list_term.SelectedValue);
                    bllObj.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                    bllObj.Section_Id = Int32.Parse(list_ClassSection.SelectedValue);
                    bllObj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                    dt = bllObj.Student_Performance_Grading_MstFetchByStudentSectionNew(bllObj);
                    ViewState["Table"] = dt;
                }
                else
                {
                    dt = (DataTable)ViewState["Table"];
                }
                if (dt.Rows.Count == 0)
                {
                    pan_New.Attributes.CssStyle.Add("display", "none");
                    Prom1.Visible = false;
                    lab_status.Visible = true;
                    lab_status.Text = "No data exists";
                    dv_details.DataSource = null;
                    ViewState["Table"] = null;
                    dv_details.DataBind();
                }
                else
                {
                    dv_details.DataSource = dt;
                    ViewState["Table"] = dt;
                    dv_details.DataBind();
                    lab_dataStatus.Visible = false;
                    lab_status.Visible = false;
                    pan_New.Attributes.CssStyle.Add("display", "inline");

                    ////////}

                    if (list_term.SelectedValue != "")
                    {

                        if (Convert.ToInt32(list_term.SelectedValue) % 2 == 0)
                        {

                            if (Convert.ToInt32(dv_details.Rows[0].Cells[11].Text) < 7)
                            {
                                Prom1.Visible = true;
                            }

                        }
                        else
                        {
                            Prom1.Visible = false;
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

    protected bool CheckClassTeacher()
    {
        bool chk = false; ;

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
            //bllobjMst.Section_subject_Id = Int32.Parse(list_subject.SelectedValue);
            bllobjMst.Session_Id = Convert.ToInt32(Session["Session_Id"]);

            DataTable _dt = new DataTable();

            _dt = bllobjMst.Student_Performance_Grading_MstFetch(bllobjMst);
            if (_dt.Rows.Count > 0)
            {
                chk_promoted.SelectedValue = Convert.ToBoolean(_dt.Rows[0]["isPromoted"]).ToString();
                //txt_SchoolHeadRmk.Text = _dt.Rows[0]["SchoolHeadComments"].ToString();
                txt_TeacherComments.Text = _dt.Rows[0]["ClassTeacherComments"].ToString();
                //          txt_ICT.Text = _dt.Rows[0]["ICTRemarks"].ToString();
                //            txt_DaysAttend.Text = _dt.Rows[0]["DaysAttend"].ToString();
                //            txt_Islamiat.Text = _dt.Rows[0]["IslamyatComments"].ToString();
                ViewState["mode"] = "Edit";
            }
            else
            {

                //chk_promoted.Checked = false;
                //txt_SchoolHeadRmk.Text = "";
                txt_TeacherComments.Text = "";
                ViewState["mode"] = "Add";
            }

            //isClassTeacher = CheckClassTeacher();

            //if (isClassTeacher == true)
            //    {
            //    txt_SchoolHeadRmk.Enabled = true;
            //    txt_TeacherComments.Enabled = true;
            //    }
            //else
            //    {
            //    txt_SchoolHeadRmk.Enabled = false;
            //    txt_TeacherComments.Enabled = false;
            //    }
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
                    bllObj.Section_Subject_Id = Int32.Parse(gvr.Cells[4].Text);

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
                                //objbll.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                                //objbll.Section_Id = Convert.ToInt32(list_ClassSection.SelectedValue);
                                //dt = objbll.Student_Performance_ClassAchvRatingFetch(objbll);
                                dt = (DataTable)ViewState["Rating"];
                                objBase.FillDropDown(dt, ddlAchRate, "KindClassAchvRating_Id", "RateCode");
                                lab_status.Visible = false;
                            }

                            if (bool.Parse(e.Row.Cells[10].Text) == true)
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
                    //  txtb.Visible = true;
                }
                else
                {
                    ddlAchRate.Visible = true;
                    //txtb.Visible = false;
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex > 0)
                {
                    int i = e.Row.RowIndex - 1;
                    GridViewRow row = dv_details.Rows[i];
                    if (row.Cells[6].Text != e.Row.Cells[6].Text)
                    {
                        // e.Row.BorderWidth = 5;
                        // e.Row.Style.Add("border-bottom-width", "5"); //= "BottomRow";
                        //e.Row.CssClass = "BottomRow";
                        e.Row.ForeColor = System.Drawing.Color.Brown;
                        e.Row.Font.Bold = true;
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

    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "none");
            //ViewState["getData"] = 0;
            list_student.SelectedIndex = 0;
            list_term.SelectedIndex = 0;
            list_ClassSection.SelectedIndex = 0;
            bindGridView();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void  but_save_Click(object sender, EventArgs e)
    {
        try
        {
            int idMst = 0;
            BLLStudent_Performance_Grading_Mst bllobjMst = new BLLStudent_Performance_Grading_Mst();

            if (IsEmpty() == false)
            {
                int _class_Id,_term_Id;
                _class_Id = Convert.ToInt32(ViewState["Class_Id"].ToString());
                _term_Id=Convert.ToInt32(list_term.SelectedValue.ToString());
                if (_class_Id<7 && _term_Id%2==0)
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
                bllobjMst.Status_Id = 1;
                
                bllobjMst.ClassTeacherComments = txt_TeacherComments.Text;
                bllobjMst.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                bllobjMst.Main_Organistion_Id = Convert.ToInt32(Session["moID"]);

                bllobjMst.IslamyatComments = "";//txt_Islamiat.Text;
                bllobjMst.ICTRemarks = "";//txt_ICT.Text;
                bllobjMst.DaysAttend = "0";//txt_DaysAttend.Text;
                bllobjMst.Section_subject_Id = 0;


                DataTable _dt = new DataTable();
                _dt = bllobjMst.Student_Performance_Grading_MstFetch(bllobjMst);


                if (_dt.Rows.Count <= 0)
                {
                    bllobjMst.CreatedOn = DateTime.Now;
                    bllobjMst.CreatedBy = Int32.Parse(Session["ContactId"].ToString());
                    idMst = bllobjMst.Student_Performance_Grading_MstAdd(bllobjMst);
                    DetailAddUpdate(idMst);
                    ImpromptuHelper.ShowPrompt("Record Added Successfully.");
                }
                else
                {
                    bllobjMst.KindSubStdMst_Id = Convert.ToInt32(_dt.Rows[0]["KindSubStdMst_Id"].ToString());
                    bllobjMst.ModifiedOn = DateTime.Now;
                    bllobjMst.ModifiedBy = Int32.Parse(Session["ContactId"].ToString());
                    bllobjMst.Student_Performance_Grading_MstUpdate(bllobjMst);
                    DetailAddUpdate(bllobjMst.KindSubStdMst_Id);
                }
                ImpromptuHelper.ShowPrompt("Record Updated Successfully.");
                ViewState["Table"] = null;
                bindGridView();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please check some data is missing for Performance grading.");
            }
        } //try end
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public bool IsEmpty()
    {
        bool isemp = false;

        if (Convert.ToInt32(dv_details.Rows[0].Cells[11].Text) >= 7)
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

    }

    private void ResetControls()
    {

        try
        {
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
    //protected void dv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    //    {
    //    if (e.CommandName == "toggleCheck")
    //        {
    //        CheckBox cb = null;
    //        string mood = ViewState["tMood"].ToString();

    //        foreach (GridViewRow gvr in dv_details.Rows)
    //            {
    //            cb = (CheckBox)gvr.FindControl("CheckBox1");

    //            if (mood == "" || mood == "check")
    //                {
    //                cb.Checked = true;
    //                ViewState["tMood"] = "uncheck";
    //                }
    //            else
    //                {
    //                cb.Checked = false;
    //                ViewState["tMood"] = "check";
    //                }

    //            }

    //        }
    //    }
    protected void txtcount_TextChanged(object sender, EventArgs e)
    {
        //CheckBox cb = null;
        //foreach (GridViewRow gvr in dv_details.Rows)
        //    {
        //    cb = (CheckBox)gvr.FindControl("CheckBox1");

        //    if (gvr.RowIndex < Convert.ToInt32(txtcount.Text))
        //        {
        //        cb.Checked = false;
        //        }
        //    else
        //        {
        //        cb.Checked = true;
        //        }

        //    }
        //DeleteDetail();
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
