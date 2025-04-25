using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class PresentationLayer_AMS_Ams : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
           // gvAttnWeekly.RowCreated += new GridViewRowEventHandler(gvAttnMonthly_RowCreated);
            //gvAttnMonthly.RowCreated += new GridViewRowEventHandler(gvAttnMonthly_RowCreated);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (!IsPostBack)
        {
            try
            {
                // ======== Page Access Settings ========================//
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                var User_TypId = row["User_Type_Id"].ToString();
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;

                // start here
                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //  ====== End Page Access settings ======================//

                //ControlSettings();
                //select_class.Visible = true;
                //datepicker.Visible = true;
                datepicker.Text = DateTime.Now.ToShortDateString();

                if (Convert.ToInt32(User_TypId) == 1)
                {
                    FillClassSectionTeacher();
                }
                else if (Convert.ToInt32(User_TypId) == 3)
                {
                    FillClassSectionCampus();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }

    protected void FillClassSectionCampus()
    {
        try
        {
            var test = Convert.ToString(Session["ContactID"]);
            BLLTCS_StdAttn obj = new BLLTCS_StdAttn { Center_Id = Convert.ToInt32(Session["cId"]) };
            DataTable dt = (DataTable)obj.TssSelectClassSectionByCenter(obj);
            objbase.FillDropDown(dt, select_class, "Section_id", "Name");

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void FillClassSectionTeacher()
    {
        try
        {
            BLLClass_Section obj = new BLLClass_Section();

            int EmployeeId = Convert.ToInt32(Session["EmployeeCode"].ToString());
            DataTable dt = (DataTable)obj.Class_SectionByEmployeeId(EmployeeId);

            objbase.FillDropDown(dt, select_class, "Section_id", "fullClassSection");
            select_class.SelectedIndex = 1;
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
            ViewSettings();
            ViewState["addOptions"] = null;
            DataTable dt = FillDTOption(4);
            ViewState["addOptions"] = dt;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }



    protected void gvAttnDaily_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "P")
        {
            LinkButton oneDayAtt = (LinkButton)e.CommandSource;

            if (oneDayAtt != null)
                if (oneDayAtt.Text == "P")
                {
                    oneDayAtt.Text = "A";
                    oneDayAtt.ForeColor = System.Drawing.Color.Red;
                }
                else if (oneDayAtt.Text == "A")
                {
                    oneDayAtt.Text = "L";
                    oneDayAtt.ForeColor = System.Drawing.Color.Navy;
                }
                else if (oneDayAtt.Text == "L")
                {
                    oneDayAtt.Text = "P";
                    oneDayAtt.ForeColor = System.Drawing.Color.Green;
                }



        }
    }


    protected void gvAttnDaily_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton oneDayAtt = (LinkButton)e.Row.FindControl("oneDayAtt");

        if (e.Row.Cells[2].Text == "1")
        {
            oneDayAtt.Text = "P";
            oneDayAtt.ForeColor = System.Drawing.Color.Green;
        }
        else if (e.Row.Cells[2].Text == "2")
        {
            oneDayAtt.Text = "A";
            oneDayAtt.ForeColor = System.Drawing.Color.Red;
        }
        else if (e.Row.Cells[2].Text == "3")
        {
            oneDayAtt.Text = "L";
            oneDayAtt.ForeColor = System.Drawing.Color.Navy;
        }
        else if (e.Row.Cells[2].Text == "24")
        {
            oneDayAtt.Text = "-";
            oneDayAtt.ForeColor = System.Drawing.Color.Gray;
        }

    }


    protected void gvAttnWeekly_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Font.Size = FontUnit.Large;

            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Font.Size = FontUnit.Medium;
                if (i > 1)
                {
                    e.Row.Cells[i].Font.Size = FontUnit.Large;
                    e.Row.Cells[i].Font.Bold = true;

                    string t = e.Row.Cells[i].Text;
                    if (t == "A")
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                    }
                    else if (t == "P")
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Green;
                    }
                    else if (t == "L")
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Navy;
                    }
                    else
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Gray;
                    }


                }

            }

        }
    }




    protected void gvAttnWeekly_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i > 1)
                {
                    string t = e.Row.Cells[i].Text;
                    Button lnkbtn = new Button();
                    lnkbtn.Text = e.Row.Cells[i].Text;
                    lnkbtn.ID = "lkb" + e.Row.RowIndex + "" + i;
                    lnkbtn.Click += new System.EventHandler(this.lnkbtn_Click);
                    lnkbtn.CssClass="btn btn - success active";

                    e.Row.Cells[i].Controls.Add(lnkbtn);

                }
            }

        }
        else
        {

        }







    }
    protected void lnkbtn_Click(object sender, EventArgs e)
    {
        //sender.ToString();
        Button lb= (Button)sender;
        datepicker.Text=lb.Text;
        view_as.SelectedIndex = 1;
        ViewSettings();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dtfill = new DataTable();
        int Cal_ID = 0;
        string CalDayType_Id = "";
        string calDayDesc = "";
        DataRow userrow = (DataRow)Session["rightsRow"];
        BLLTCS_StdAttn objbll = new BLLTCS_StdAttn();
        BLLTCS_StdAttnCalender bll = new BLLTCS_StdAttnCalender();
        DataTable dtbll = new DataTable();
        bll.CalDate = datepicker.Text.Trim().Replace("'", "");
        bll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        dtbll = bll.TCS_StdAttnCalenderSelectCal_IDByDateCenter(bll);
        if (dtbll.Rows.Count > 0)
        {
            Cal_ID = Int32.Parse(dtbll.Rows[0]["Cal_ID"].ToString());
            CalDayType_Id = dtbll.Rows[0]["CalDayType_Id"].ToString();
            calDayDesc = dtbll.Rows[0]["CalTypeDesc"].ToString();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please add Academic Calendar First for this Center");
            return;
        }

        System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)sender;

        foreach (GridViewRow row in gvAttnDaily.Rows)
        {

            objbll.Session_Id = Convert.ToInt32(Session["Session_Id"]);
            objbll.Cal_ID = Cal_ID;
            objbll.AttnDate = datepicker.Text.Trim().Replace("'", "");



            var att = row.FindControl("oneDayAtt") as LinkButton;
            var type = (DropDownList)row.FindControl("leaveType");
            if (CalDayType_Id == "")
            {
                if (att.Text == "P")
                {
                    objbll.AttnType_Id = 1;
                }
                else if (att.Text == "A")
                {
                    objbll.AttnType_Id = 2;
                }
                else if (att.Text == "L")
                {
                    objbll.AttnType_Id = 3;
                }
            }
            else
            {
                objbll.AttnType_Id = 24;
            }
            objbll.Student_Id = int.Parse(row.Cells[4].Text);
            objbll.Section_Id = int.Parse(select_class.SelectedValue);
            if (Convert.ToInt32(row.Cells[0].Text) <= 0)
            {
                objbll.CreatedBy = int.Parse(Session["ContactID"].ToString());
                objbll.CreatedOn = DateTime.Now;
                objbll.TCS_StdAttnInsert(objbll);
            }
            else
            {
                objbll.Attn_ID = Convert.ToInt32(row.Cells[0].Text);
                objbll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
                objbll.ModifiedOn = System.DateTime.Now;
                objbll.TCS_StdAttnUpdate(objbll);
            }
        }
        ViewSettings();
        //ImpromptuHelper.ShowPrompt("In Calendar " + datepicker.Text.Trim() + " is " + calDayDesc + " so attendance can not be marked");
        ImpromptuHelper.ShowPrompt("Data Saved");
    }

    protected DataTable FillDTOption(int param)
    {
        BLLTCS_StdAttn obj = new BLLTCS_StdAttn();
        obj.Center_Id = Convert.ToInt32(Session["cId"]);
        obj.date = Convert.ToDateTime(datepicker.Text.Trim().Replace("'", ""));
        obj.Section_Id = Int32.Parse(select_class.SelectedValue);
        obj.parm = param;
        DataTable dt = (DataTable)obj.TCS_StdAttnDailyRptAttnTypeWise(obj);
        return dt;
    }
    protected void gvAttnMonthly_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnWeekly.PageIndex = e.NewPageIndex;
        gvAttnWeekly.DataSource = (DataTable)ViewState["Monthly"];
        gvAttnWeekly.DataBind();
    }


    protected void gvAttnMonthly_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Style.Add("width", "250px");
                cell.Style.Add("text-align", "center");
            }
        }
    }





    


    protected void view_as_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewSettings();
    }

    private void ViewSettings()
    {
        if (view_as.SelectedIndex > 0 && Convert.ToInt32(select_class.SelectedValue) > 0 && datepicker.Text != String.Empty)
        {
            ControlSettings();
            if (view_as.SelectedValue == "1")
            {
                DailyView();
                btnSave.Visible = true;
            }
            else if (view_as.SelectedValue == "2" || view_as.SelectedValue == "3")
            {
                WeeklyView();
            }
            
        }
        else
        {
            ControlSettings();
        }
    }

    private void DailyView()
    {

        gvAttnDaily.DataSource = null;
        gvAttnDaily.DataBind();

        BLLTCS_StdAttn obj = new BLLTCS_StdAttn();
        obj.Class_Section_Id = Int32.Parse(select_class.SelectedValue);
        obj.AttnDate = datepicker.Text;

        DataTable dt = obj.TssStudentSelectByClassSectionIdForAttendanceExisting(obj);

        if (dt.Rows.Count > 0)
        {
            gvAttnDaily.DataSource = dt;
            gvAttnDaily.DataBind();
            foreach (GridViewRow row in gvAttnDaily.Rows)
            {
                string order = gvAttnDaily.Rows[row.RowIndex].Cells[6].Text;

                if (order == "1")
                {
                    LinkButton oneDayAtt = (LinkButton)row.FindControl("oneDayAtt");
                    oneDayAtt.Visible = true;
                    oneDayAtt.Text = "P";
                    oneDayAtt.ForeColor = System.Drawing.Color.Green;
                }
                else if (order == "2")
                {
                    LinkButton oneDayAtt = (LinkButton)row.FindControl("oneDayAtt");
                    oneDayAtt.Visible = true;
                    oneDayAtt.Text = "A";
                    oneDayAtt.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    
                    LinkButton oneDayAtt = (LinkButton)row.FindControl("oneDayAtt");
                    oneDayAtt.Visible = true;

                }

            }

        }








        gvAttnDaily.Visible = true;
        gvAttnWeekly.Visible = false;
        lblClass.Visible = true;
        select_class.Visible = true;
        //  select_class.SelectedValue = "0";
    }

    private void WeeklyView()
    {

        //if (ViewState["Weekly"] == null)
        //{

        gvAttnWeekly.DataSource = null;
        gvAttnWeekly.DataBind();

        BLLTCS_StdAttn objbll = new BLLTCS_StdAttn();
        DataTable dt = new DataTable();
        DataRow userrow = (DataRow)Session["rightsRow"];
        objbll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        objbll.Year = DateTime.Now.Year;
        objbll.Section_Id = Int32.Parse(select_class.SelectedValue);

        //objbll.Week = objbll.GetIso8601WeekOfYear(Convert.ToDateTime(datepicker.Text));
        //objbll.Year = Convert.ToInt32(datepicker.Text.Substring(datepicker.Text.LastIndexOf("/") + 1, 4));


        if (view_as.SelectedValue=="2")
        {
            int day = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now,CalendarWeekRule.FirstDay,DayOfWeek.Monday);
            objbll.Week = Convert.ToInt32(day);

            dt = objbll.TSSWeeklyAttnSummery(objbll);

        }
        else if (view_as.SelectedValue=="3")
        {
            objbll.Month = DateTime.Now.Month;
            dt = objbll.TSSMonthlyAttnSummery(objbll);
        }

        

        if (dt.Rows.Count > 0)
        {
            gvAttnWeekly.DataSource = dt;
            gvAttnWeekly.DataBind();


            lblNoData.Visible = false;
            lblNoData.Text = "";
        }
        else
        {
            lblNoData.Visible = true;
            lblNoData.Text = "No Data Found";
        }

        gvAttnWeekly.Visible = true;
        lblClass.Visible = true;

    }

    protected void ControlSettings()
    {

        gvAttnDaily.DataSource = null;
        gvAttnDaily.DataBind();

        gvAttnWeekly.DataSource = null;
        gvAttnWeekly.DataBind();


        gvAttnDaily.Visible = false;
        gvAttnWeekly.Visible = false;

        //select_class.SelectedValue = "0";
        btnSave.Visible = false;
        lblClass.Visible = false;
    }


    protected void datepicker_TextChanged(object sender, EventArgs e)
    {
        ViewSettings();
    }
}