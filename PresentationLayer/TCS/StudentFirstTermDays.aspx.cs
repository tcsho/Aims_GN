using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_StudentFirstTermDays : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"];
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
            Session["AddCriteria"] = null;

            //====== End Page Access settings ======================


            //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];            
            BindTerm();
            BindGrid();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnAddPanel.Visible = true;
            btnCancelPanel.Visible = false;
            SearchPanel.Visible = false;
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
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, list_Term, "TermGroup_Id", "Type");
            if (dt.Rows.Count > 0)
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    list_Term.SelectedValue = "2";
                else
                    list_Term.SelectedValue = "1";
            }

            //BLLSection_Subject obj = new BLLSection_Subject();

            //obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
            //obj.Section_Id = Convert.ToInt32(lblsectionid.Text);

            //DataTable dt = obj.Evaluation_Criteria_TypeBySectionId(obj);

            //objBase.FillDropDown(dt, list_Term, "Id", "Type");

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
            ViewState["dtDetails"] = null;
            BindGrid();

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


            BLLStudent_Evaluation_Criteria_Detail objClsSec = new BLLStudent_Evaluation_Criteria_Detail();

            DataTable dtsub = new DataTable();
            DataTable dtwrk = new DataTable();

            DataRow row = (DataRow)Session["rightsRow"];



            ////////////////objClsSec.Student_Id = Convert.ToInt32(txtStudentNo.Text);
            objClsSec.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
            objClsSec.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue);
            //////////////////////objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());


            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Student_TermDaysSelectAllByCenterSessionId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                lblMessage.Visible = false;
                gvShowAck.DataSource = dtsub;
                gvShowAck.DataBind();
                ViewState["tMood"] = "check";
            }
            else
            {
                lblMessage.Visible = true;
                gvShowAck.DataSource = null;
                gvShowAck.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void gvShowAck_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "toggleCheck")
            {


                foreach (GridViewRow row in gvShowAck.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chkRating");
                    if (cb != null && cb.Checked == false)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvShowAck_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {



            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BLLDiag_Prog obj = new BLLDiag_Prog();
            LinkButton btnDelete = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btnDelete.NamingContainer;
            gvShowAck.SelectedIndex = gvr.RowIndex;

            obj.Student_Id = Convert.ToInt32(btnDelete.CommandArgument);
            obj.Session_Id = Convert.ToInt32(gvr.Cells[0].Text);
            obj.Evaluation_Criteria_Type_Id = Convert.ToInt32(gvr.Cells[8].Text);
            obj.Section_Id = Convert.ToInt32(gvr.Cells[9].Text);
            obj.Student_TermDaysDelete(obj);
            ViewState["dtDetails"] = null;
            BindGrid();
            dg_student.DataSource = null;
            dg_student.DataBind();
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
            int AlreadyIn = 0;
            DataTable dt = new DataTable();
            BLLDiag_Prog objactivity = new BLLDiag_Prog();
            DataTable dtsub = new DataTable();
            foreach (GridViewRow r in dg_student.Rows)
            {
                TextBox txtDaysWork = r.FindControl("txtDaysWork") as TextBox;
                TextBox txtAttendDay = r.FindControl("txtAttendDay") as TextBox;
                if (txtDaysWork.Text != "" && txtAttendDay.Text != "")
                {
                    int Dayswork = Convert.ToInt32(txtDaysWork.Text);
                    int AttendDay = Convert.ToInt32(txtAttendDay.Text);
                    if (AttendDay <= Dayswork)
                    {

                        objactivity.Session_Id = Convert.ToInt32(r.Cells[11].Text);
                        objactivity.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue);
                        objactivity.Student_Id = Convert.ToInt32(r.Cells[2].Text);
                        objactivity.FirstTermDays = Convert.ToInt32(txtDaysWork.Text);
                        objactivity.DaysAttend = Convert.ToInt32(txtAttendDay.Text);
                        objactivity.FirstTermDaysCH = txtDaysWork.Text;
                        objactivity.Section_Id = Convert.ToInt32(r.Cells[10].Text);
                        string mode = Convert.ToString(ViewState["mode"]);

                        if (mode != "Edit")
                        {

                            AlreadyIn = objactivity.Student_TermDaysAdd(objactivity);


                            ViewState["dtDetails"] = null;
                            if (AlreadyIn == 0)
                            {
                                ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                BindGrid();
                            }

                            else
                            {
                                ImpromptuHelper.ShowPrompt("Record already exist!");
                            }
                        }
                    }
                    ImpromptuHelper.ShowPrompt("Can't Save Attend days greater then Total working days !");
                }

                dg_student.DataSource = null;
                dg_student.DataBind();
                //BindGridSearch();
                btnCancel_Click(this, EventArgs.Empty);
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
    protected void gvShowAck_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvShowAck.Rows.Count > 0)
            {
                gvShowAck.UseAccessibleHeader = false;
                gvShowAck.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvShowAck.FooterRow.TableSection = TableRowSection.TableFooter;
            }
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
            string student = "";
            for (int i = 0; i < gvShowAck.Rows.Count; i++)
            {
                if (i == gvShowAck.Rows.Count - 1)
                    student += gvShowAck.Rows[i].Cells[2].Text;
                else
                    student += gvShowAck.Rows[i].Cells[2].Text + " , ";
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
                    btnSave.Visible = true;
                    SearchTitle.Visible = true;
                    if (!String.IsNullOrEmpty(student))
                    {
                        DataRow[] tblROWS = dt.Select("Student_No not in(" + student + ")");
                        if (tblROWS.Length > 0)
                        {
                            dt = dt.Select("Student_No not in(" + student + ")").CopyToDataTable();
                           
                        }
                        else
                        {
                            btnSave.Visible = false;
                            SearchTitle.Visible = false;
                            dt = null;
                        }
                     
                    }
                }
                dg_student.DataSource = dt;
                ViewState["studentDT"] = dt;
                dg_student.DataBind();               
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAddPanel_Click(object sender, EventArgs e)
    {
        try
        {
            btnAddPanel.Visible = false;
            btnCancelPanel.Visible = true;
            SearchPanel.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}
