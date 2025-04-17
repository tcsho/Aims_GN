using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_StudentMissingExam : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
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
        if (!IsPostBack)
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
            ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
            (uc.FindControl("list_studentStatus") as DropDownList).Visible = false;
            (uc.FindControl("list_class") as DropDownList).Visible = false;
            (uc.FindControl("list_section") as DropDownList).Visible = false;
            (uc.FindControl("lbl_teacher") as Label).Visible = false;
            (uc.FindControl("lbl_StdStatus") as Label).Visible = false;
            (uc.FindControl("lblClass") as Label).Visible = false;
            (uc.FindControl("list_teacher") as DropDownList).Visible = false;
            (uc.FindControl("lab_section") as Label).Visible = false;

        }
    }
    protected void gvAttnType_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvAttnType.Rows.Count > 0)
            {
                gvAttnType.UseAccessibleHeader = false;
                gvAttnType.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAttnType.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvOlevels_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvOlevels.Rows.Count > 0)
            {
                gvOlevels.UseAccessibleHeader = false;
                gvOlevels.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvOlevels.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindGridSearch()
    {
        try
        {

            BLLSearchStudent objSer = new BLLSearchStudent();
            ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
            DataTable dt = new DataTable();

            objSer.First_Name = (uc.FindControl("text_firstName") as TextBox).Text;
            objSer.Last_Name = (uc.FindControl("text_lastName") as TextBox).Text;
            objSer.Middle_Name = (uc.FindControl("text_middleName") as TextBox).Text;
            objSer.Date_Of_Birth = (uc.FindControl("text_dateOfBirth") as TextBox).Text;
            objSer.Gender_Id = (uc.FindControl("list_gender") as DropDownList).SelectedValue;
            objSer.Student_No = (uc.FindControl("text_studentNo") as TextBox).Text;
            objSer.Region_Id = (uc.FindControl("list_region") as DropDownList).SelectedValue;
            objSer.Student_Status_Id = (uc.FindControl("list_studentStatus") as DropDownList).SelectedValue;
            objSer.Center_Id = (uc.FindControl("list_center") as DropDownList).SelectedValue;

            objSer.Grade_Id = (uc.FindControl("list_class") as DropDownList).SelectedValue;
            objSer.Section_Id = (uc.FindControl("list_section") as DropDownList).SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = (uc.FindControl("list_teacher") as DropDownList).SelectedValue;

            objSer.EndIndex = "";
            objSer.StartIndex = "";
            dt = objSer.SearchStudentFetch(objSer);
            if (dt.Rows.Count > 0)
            {
                txtRollNo.Text = dt.Rows[0]["Student_No"].ToString();
                btnLoad_Click(this, EventArgs.Empty);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void bindGV()
    {
        try
        {
            gvAttnType.DataSource = null;
            gvAttnType.DataBind();
            gvOlevels.DataSource = null;
            gvOlevels.DataBind();
            BLLStudent_Missing_Exam bll = new BLLStudent_Missing_Exam();
            DataRow userrow = (DataRow)Session["rightsRow"];
            DataTable dt = new DataTable();

            bll.Student_Id = Int32.Parse(txtRollNo.Text);
            bll.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            bll.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());

            if (ViewState["Mode"].ToString() == "Other")
            {
                bll.Evaluation_Type_Id = 0;
                dt = bll.Student_SelectAllByStudentNoForStudentMissingExam(bll);
                if (dt.Rows.Count > 0)
                {
                    ViewState["LoadData"] = dt;

                    gvAttnType.DataSource = dt;
                    gvAttnType.DataBind();
                    lblNoData.Visible = false;
                    lblNoData.Text = "";

                    tdSearch.Visible = true;
                    gvAttnType.DataBind();

                }

            }
            if (ViewState["Mode"].ToString() == "O/A Level")
            {

                dt = bll.Student_MissingExamOASelectAll(bll);
                if (dt.Rows.Count > 0)
                {
                    gvOlevels.DataSource = dt;
                    gvOlevels.DataBind();
                    tdSearch.Visible = true;
                    //if (bll.Evaluation_Type_Id == 1) //coursework
                    //{
                    //    gvOlevels.Columns[18].Visible = true;
                    //    gvOlevels.Columns[19].Visible = false;
                    //}
                    //else //exam
                    //{
                    //    gvOlevels.Columns[18].Visible = false;
                    //    gvOlevels.Columns[19].Visible = true;
                    //}
                    gvOlevels.DataBind();
                }
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            //bindGV();
            BindTerm();
            gvAttnType.DataSource = null;
            gvAttnType.DataBind();
            gvOlevels.DataSource = null;
            gvOlevels.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAttnType.PageIndex = e.NewPageIndex;
            gvAttnType.DataSource = ViewState["LoadData"];
            gvAttnType.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bindGV();
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
            bindGV();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindTerm()
    {
        try
        {
            BLLSearchStudent objSer = new BLLSearchStudent();
            DataTable dt = null;
            BLLStudent_Missing_Exam ObjECT = new BLLStudent_Missing_Exam();
            ObjECT.Student_Id = Convert.ToInt32(txtRollNo.Text);
            dt = ObjECT.Evaluation_Criteria_TypeSelectByStudentId(ObjECT);
            if (dt.Rows.Count > 0)
            {
                objBase.FillDropDown(dt, list_Term, "TermGroup_Id", "Type");
                DataRow r = dt.Rows[0];
                if (Convert.ToInt32(r["Class_Id"].ToString()) > 12)
                {

                    ViewState["Mode"] = "O/A Level";
                }
                else
                {

                    ViewState["Mode"] = "Other";
                    list_Term_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void btnExamAbsent_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;


            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Add";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;

            ViewState["ReferenceId"] = ReferenceIdValue;


            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;

            int index = gvRow.RowIndex;



            objClsSec.Student_Id = Convert.ToInt32(txtRollNo.Text);
            objClsSec.Region_Id = Int32.Parse(gvRow.Cells[4].Text);

            objClsSec.Center_Id = Int32.Parse(gvRow.Cells[6].Text);
            objClsSec.Student_Name = gvRow.Cells[3].Text;

            objClsSec.Class_Id = Int32.Parse(gvRow.Cells[8].Text);
            objClsSec.Class_Name = gvRow.Cells[9].Text;

            objClsSec.Section_Id = Int32.Parse(gvRow.Cells[10].Text);
            objClsSec.Section_Name = gvRow.Cells[11].Text;

            objClsSec.Session_Id = Int32.Parse(gvRow.Cells[12].Text);

            objClsSec.Subject_Id = Int32.Parse(gvRow.Cells[13].Text);
            objClsSec.Subject_Name = gvRow.Cells[14].Text;

            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());

            objClsSec.IsMissingExam = true;//Exams 
            objClsSec.IsMissingCoursework = null;
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());

            AlreadyIn = objClsSec.Student_Missing_ExamAdd(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                bindGV();
            }
            else
            {
                //ImpromptuHelper.ShowPrompt("Record Alraedy Exist!");
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnExamPresent_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;


            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;
            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());

            objClsSec.IsMissingExam = false;
            objClsSec.IsMissingCoursework = Convert.ToBoolean(gvRow.Cells[17].Text);
            AlreadyIn = objClsSec.Student_Missing_ExamDelete(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                // ImpromptuHelper.ShowPrompt("Record Successfully Updated.");
                bindGV();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAbsentCoursework_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Add";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;
            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            objClsSec.Student_Id = Convert.ToInt32(txtRollNo.Text);
            objClsSec.Region_Id = Int32.Parse(gvRow.Cells[4].Text);

            objClsSec.Center_Id = Int32.Parse(gvRow.Cells[6].Text);
            objClsSec.Student_Name = gvRow.Cells[3].Text;

            objClsSec.Class_Id = Int32.Parse(gvRow.Cells[8].Text);
            objClsSec.Class_Name = gvRow.Cells[9].Text;

            objClsSec.Section_Id = Int32.Parse(gvRow.Cells[10].Text);
            objClsSec.Section_Name = gvRow.Cells[11].Text;

            objClsSec.Session_Id = Int32.Parse(gvRow.Cells[12].Text);

            objClsSec.IsMissingCoursework = true;//Coursework
            objClsSec.IsMissingExam = null;
            objClsSec.Subject_Id = Int32.Parse(gvRow.Cells[13].Text);
            objClsSec.Subject_Name = gvRow.Cells[14].Text;
            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            AlreadyIn = objClsSec.Student_Missing_ExamAdd(objClsSec);
            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                bindGV();
            }
            else
            {
                //  ImpromptuHelper.ShowPrompt("Record Alraedy Exist!");
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnPresentCoursework_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;
            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());
            objClsSec.IsMissingCoursework = false;
            objClsSec.IsMissingExam = Convert.ToBoolean(gvRow.Cells[16].Text);
            AlreadyIn = objClsSec.Student_Missing_ExamDelete(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                // ImpromptuHelper.ShowPrompt("Record Successfully Updated.");
                bindGV();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnOExamAbsent_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;


            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Add";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;

            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            gvOlevels.SelectedIndex = gvRow.RowIndex;
            objClsSec.Student_Id = Convert.ToInt32(txtRollNo.Text);
            objClsSec.Region_Id = Int32.Parse(gvRow.Cells[4].Text);

            objClsSec.Center_Id = Int32.Parse(gvRow.Cells[6].Text);
            objClsSec.Student_Name = gvRow.Cells[3].Text;

            objClsSec.Class_Id = Int32.Parse(gvRow.Cells[8].Text);
            objClsSec.Class_Name = gvRow.Cells[9].Text;

            objClsSec.Section_Id = Int32.Parse(gvRow.Cells[10].Text);
            objClsSec.Section_Name = gvRow.Cells[11].Text;

            objClsSec.Session_Id = Int32.Parse(gvRow.Cells[12].Text);

            objClsSec.Subject_Id = Int32.Parse(gvRow.Cells[13].Text);
            objClsSec.Subject_Name = gvRow.Cells[14].Text;

            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());

            objClsSec.Evaluation_Type_Id = 2;//Exams 
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(gvRow.Cells[17].Text);
            AlreadyIn = objClsSec.Student_MissingExamOAAdd(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                bindGV();
            }
            else
            {
                // ImpromptuHelper.ShowPrompt("Record Alraedy Exist!");
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnOExamPresent_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;
            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvOlevels.SelectedIndex = gvr.RowIndex;
            objClsSec.SDash_Id = Convert.ToInt32(ReferenceIdValue.ToString());
            AlreadyIn = objClsSec.Student_MissingExamOADelete(objClsSec);
            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                // ImpromptuHelper.ShowPrompt("Record Successfully Updated.");
                bindGV();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnOAbsentCoursework_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Add";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;
            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            gvOlevels.SelectedIndex = gvRow.RowIndex;

            objClsSec.Student_Id = Convert.ToInt32(txtRollNo.Text);
            objClsSec.Region_Id = Int32.Parse(gvRow.Cells[4].Text);

            objClsSec.Center_Id = Int32.Parse(gvRow.Cells[6].Text);
            objClsSec.Student_Name = gvRow.Cells[3].Text;

            objClsSec.Class_Id = Int32.Parse(gvRow.Cells[8].Text);
            objClsSec.Class_Name = gvRow.Cells[9].Text;

            objClsSec.Section_Id = Int32.Parse(gvRow.Cells[10].Text);
            objClsSec.Section_Name = gvRow.Cells[11].Text;

            objClsSec.Session_Id = Int32.Parse(gvRow.Cells[12].Text);

            objClsSec.Subject_Id = Int32.Parse(gvRow.Cells[13].Text);
            objClsSec.Subject_Name = gvRow.Cells[14].Text;

            objClsSec.SAbsent_Id = Convert.ToInt32(ReferenceIdValue.ToString());

            objClsSec.Evaluation_Type_Id = 1;//Course work 
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(gvRow.Cells[17].Text);
            AlreadyIn = objClsSec.Student_MissingExamOAAdd(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                bindGV();
            }
            else
            {
                //  ImpromptuHelper.ShowPrompt("Record Alraedy Exist!");
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnOPresentCoursework_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            BLLStudent_Missing_Exam objClsSec = new BLLStudent_Missing_Exam();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string ReferenceIdValue = btn.CommandArgument;

            ViewState["ReferenceId"] = ReferenceIdValue;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvOlevels.SelectedIndex = gvr.RowIndex;
            objClsSec.SDash_Id = Convert.ToInt32(ReferenceIdValue.ToString());


            AlreadyIn = objClsSec.Student_MissingExamOADelete(objClsSec);

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                //   ImpromptuHelper.ShowPrompt("Record Successfully Updated.");
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void gvAttnType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool lockstatus = Convert.ToBoolean(e.Row.Cells[20].Text);
            LinkButton btnCoursework = (LinkButton)e.Row.FindControl("btnCoursework");
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton btnExam = (LinkButton)e.Row.FindControl("btnExam");
            LinkButton btnExamPresent = (LinkButton)e.Row.FindControl("btnExamPresent");




            if (lockstatus)
            {

                btnCoursework.Visible = false;
                LinkButton1.Visible = false;
                btnExam.Visible = false;
                btnExamPresent.Visible = false;
            }
            else
            {
                ////Missing Exam
                //if (Convert.ToBoolean(e.Row.Cells[21].Text.ToString()) == true)
                //{
                //    btnExamPresent.Visible = true;

                //}
                //else
                //{
                //    btnExam.Visible = false;
                //}

                ////Missing Coursework
                //if (Convert.ToBoolean(e.Row.Cells[22].Text.ToString()) == true)
                //{
                //    LinkButton1.Visible = true;

                //}
                //else
                //{
                //    btnCoursework.Visible = false;
                //}
            }

        }
    }

    protected void gvOlevels_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool lockstatus = Convert.ToBoolean(e.Row.Cells[20].Text);
            LinkButton btnCoursework = (LinkButton)e.Row.FindControl("btnCoursework");
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton btnExam = (LinkButton)e.Row.FindControl("btnExam");
            LinkButton btnExamPresent = (LinkButton)e.Row.FindControl("btnExamPresent");

            if (lockstatus)
            {

                btnCoursework.Visible = false;
                LinkButton1.Visible = false;
                btnExam.Visible = false;
                btnExamPresent.Visible = false;
            }

        }

    }
}
