using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_StudentWithoutFirstTerm : System.Web.UI.Page
{
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
            BindStudentsWithoutFT();
            btnSearch.Focus();
        }
    }
    private void BindGridSearch()
    {
        try
        {
            string student = "";
            for (int i = 0; i < gvStudents.Rows.Count; i++)
            {
                if (i == gvStudents.Rows.Count - 1)
                    student += gvStudents.Rows[i].Cells[1].Text;
                else
                    student += gvStudents.Rows[i].Cells[1].Text + " , ";
            }



            BLLSearchStudent objSer = new BLLSearchStudent();
            ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
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

            DataTable dt = objSer.SearchStudentFetchCount(objSer);
            if (dt.Rows.Count > 0)
            {
                int total = Convert.ToInt32(dt.Rows[0]["StudenCount"].ToString());

                ViewState["total"] = total;

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
                    SearchTitle.Visible = true;
                    if (!String.IsNullOrEmpty(student))
                    {
                        DataRow[] tblROWS = dt.Select("Student_No not in(" + student + ")");
                        if (tblROWS.Length > 0)
                            dt = dt.Select("Student_No not in(" + student + ")").CopyToDataTable();

                        else
                        {
                            SearchTitle.Visible = false;
                            dt = null;
                        }
                    }

                    dg_student.DataSource = dt;
                    ViewState["studentDT"] = dt;
                }
                dg_student.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    //public void btnAddPanel_Click(object sender, EventArgs e)
    //{

    //    ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
    //    cp.Page.FindControl("pan_search").Visible = true;
    //}
    //public void btnCancelPanel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Page.FindControl("pan_search").Visible = false;
    //        Page.FindControl("addPanel").Visible = true;

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}
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
    protected void dg_student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_student.Rows.Count > 0)
            {
                dg_student.UseAccessibleHeader = false;
                dg_student.HeaderRow.TableSection = TableRowSection.TableHeader;
                dg_student.FooterRow.TableSection = TableRowSection.TableFooter;
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
                gvStudents.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindStudentsWithoutFT()
    {

        BLLStudent_Without_First_Term bll = new BLLStudent_Without_First_Term();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dtn = new DataTable();
        if (Session["RegionID"] != null)
            bll.Region_Id = Convert.ToInt32(Session["RegionID"].ToString());
        else
            bll.Region_Id = 0;
        if (Session["cId"] != null && !String.IsNullOrEmpty(Session["cId"].ToString()))
        {
            bll.Center_Id = Convert.ToInt32(Session["cId"].ToString());
        }
        else
            bll.Center_Id = 0;

        dtn = bll.Student_Without_First_TermFetch(bll);
        if (dtn.Rows.Count > 0)
        {
            ViewState["LoadData"] = dtn;
            gvStudents.DataSource = dtn;
            gvStudents.DataBind();

        }
        else
        {
            lblNoDatadt.Visible = true;
            lblNoDatadt.Text = "No Data Found";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BLLStudent_Without_First_Term objClsSec = new BLLStudent_Without_First_Term();
        DataTable dtsub = new DataTable();
        LinkButton btn = (LinkButton)(sender);
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvStudents.SelectedIndex = gvr.RowIndex;
        int AlreadyIn = 0;
        DataTable dt = new DataTable();
        objClsSec.Student_Id = Int32.Parse(btn.CommandArgument);
        objClsSec.Region_Id = Int32.Parse(gvr.Cells[13].Text);
        objClsSec.Center_Id = Int32.Parse(gvr.Cells[14].Text);
        objClsSec.Student_Name = gvr.Cells[3].Text;
        objClsSec.Class_Id = Int32.Parse(gvr.Cells[8].Text);
        objClsSec.Class_Name = gvr.Cells[7].Text;
        objClsSec.Section_Id = Int32.Parse(gvr.Cells[10].Text);
        objClsSec.Section_Name = gvr.Cells[9].Text;
        objClsSec.Session_Id = Int32.Parse(gvr.Cells[11].Text);
        AlreadyIn = objClsSec.Student_Without_First_TermAdd(objClsSec);
        if (AlreadyIn == 0)
            ImpromptuHelper.ShowPrompt("Record successfully updated.");
        else
            ImpromptuHelper.ShowPrompt("Record Already exist.");
        BindStudentsWithoutFT();
        dg_student.DataSource = null;
        dg_student.DataBind();
        BindGridSearch();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Without_First_Term bll = new BLLStudent_Without_First_Term();
            LinkButton btn = (LinkButton)(sender);
            bll.Student_Id = Convert.ToInt32(btn.CommandArgument);
            bll.Student_Without_First_TermDelete(bll);
            ViewState["LoadData"] = null;
            BindStudentsWithoutFT();
            //BindGridSearch();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}