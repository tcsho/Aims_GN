using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_TCSStdAttnCalenderHolidays : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
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
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================



            bindddlYears();
            ddlYears.SelectedIndex = 0;
            bindGV(ddlYears.SelectedItem.Text);
        }
    }
    protected void bindddlDayType()
    {
        ddlDayType.Items.Clear();
        BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();
        DataTable dt = new DataTable();
        dt = bll.TCS_StdAttnCalenderDayTypeSelectAll();
        objbase.FillDropDown(dt, ddlDayType, "CalDayType_Id", "CalTypeDesc");

    }
    protected void bindddlYears()
    {
        ddlYears.Items.Clear();
        BLLTCS_StdYears bll = new BLLTCS_StdYears();
        DataTable dt = new DataTable();

        dt = bll.TCS_StdYearsSelectAll();
        objbase.FillDropDown(dt, ddlYears, "id", "Year");

    }
    protected void bindGV(string year)
    {
        gvAttnType.DataSource = null;
        gvAttnType.DataBind();
        BLLTCS_StdAttnCalenderHolidays bll = new BLLTCS_StdAttnCalenderHolidays();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dt = new DataTable();
        bll.Year = year;
        bll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        dt = bll.TCS_StdAttnCalenderHolidaysSelectAll(bll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            gvAttnType.DataSource = dt;
            gvAttnType.DataBind();
            lblNoData.Visible = false;
            lblNoData.Text = "";
        }
        else
        {
            lblNoData.Visible = true;
            lblNoData.Text = "No Data Found";
        }
    }

    private int CalculateDays(string _fromDate, string _toDate)
    {
        int _ret = 0;
        if (txtDate.Text.Length > 0 && txtDate2.Text.Length > 2)
        {

            DateTime dF = DateTime.ParseExact(_fromDate, "MM/dd/yyyy", null);

            DateTime dT = DateTime.ParseExact(_toDate, "MM/dd/yyyy", null);

            TimeSpan span = dT.Subtract(dF);
            if (span.Days >= 0)
            {
                _ret = span.Days + 1;
            }
            else
            {
                _ret = span.Days;
            }
        }
        return _ret;

    }
    protected void lnkAddCal_Click(object sender, EventArgs e)
    {
        BLLTCS_StdAttnCalenderHolidays objbll = new BLLTCS_StdAttnCalenderHolidays();
        DataRow userrow = (DataRow)Session["rightsRow"];
        if (ViewState["Mode"].ToString() == "add")
        {
            if (rblType.SelectedValue == "0") //Single Entry
            {
                objbll.CallDate = txtDate.Text.Trim().Replace("'", "");
                objbll.Remarks = txtDescription.Text.Trim().Replace("'", "");
                objbll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
                objbll.CalDayType_Id = Int32.Parse(ddlDayType.SelectedValue);
                objbll.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
                objbll.Main_Organisation_Id = Convert.ToInt32(userrow["Main_Organisation_Id"].ToString());
                objbll.CreatedBy = Convert.ToInt32(userrow["User_Id"].ToString());
                objbll.CreatedOn = DateTime.Now;
                int already = objbll.TCS_StdAttnCalenderHolidaysInsert(objbll);
                if (already != 0)
                {
                    ImpromptuHelper.ShowPrompt("Record already exists");
                }
                else
                {
                    txtDescription.Text = "";
                    txtDate.Text = "";
                    ddlDayType.SelectedValue = "0";
                    GenerateCalander();
                    ImpromptuHelper.ShowPrompt("Record is Saved Successfully");
                }
            }
            else //Multiple Entry
            {
                int days = CalculateDays(txtDate.Text, txtDate2.Text);
                if (days <= 0)
                {
                    ImpromptuHelper.ShowPrompt("Invalid Date Range! 'From date' can not be greater than 'To date'.");
                    days = 0;
                }
                else
                {
                    for (int i = 0; i < days; i++)
                    {


                        DateTime age = Convert.ToDateTime(txtDate.Text);
                        DateTime answer = age.AddDays(i);


                        string Days = answer.Day.ToString();
                        string Month = answer.Month.ToString();
                        string Year = answer.Year.ToString();


                        objbll.CallDate = Month + "/" + Days + "/" + Year;

                        objbll.Remarks = txtDescription.Text.Trim().Replace("'", "");
                        objbll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
                        objbll.CalDayType_Id = Int32.Parse(ddlDayType.SelectedValue);
                        objbll.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
                        objbll.Main_Organisation_Id = Convert.ToInt32(userrow["Main_Organisation_Id"].ToString());
                        objbll.CreatedBy = Convert.ToInt32(userrow["User_Id"].ToString());
                        objbll.CreatedOn = DateTime.Now;
                        int already = objbll.TCS_StdAttnCalenderHolidaysInsert(objbll);
                    }

                    GenerateCalander();
                }
            }

        }
        else if (ViewState["Mode"].ToString() == "Edit")
        {
            objbll.Call_ID = Int32.Parse(ViewState["Call_ID"].ToString());
            objbll.Remarks = txtDescription.Text.Trim().Replace("'", "");
            objbll.CalDayType_Id = Int32.Parse(ddlDayType.SelectedValue);
            objbll.ModifiedOn = DateTime.Now;
            objbll.ModifiedBy = Convert.ToInt32(userrow["User_Id"].ToString());

            objbll.TCS_StdAttnCalenderHolidaysUpdate(objbll);

            txtDescription.Text = "";
            txtDate.Text = "";
            ddlDayType.SelectedValue = "0";

            ImpromptuHelper.ShowPrompt("Record is Updated Successfully");
        }
        bindGV(ddlYears.SelectedItem.Text);
        ResetControls();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        

        ////////BLLTCS_StdAttnCalender obj = new BLLTCS_StdAttnCalender();
        ////////DataRow userrow = (DataRow)Session["rightsRow"];

        ////////obj.Main_Organisation_Id = Convert.ToInt32(userrow["Main_Organisation_Id"].ToString());
        ////////obj.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
        ////////obj.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        ////////obj.Year = ddlYears.SelectedItem.Text;

        ////////obj.TCS_StdAttnCalenderInsert(obj);

        ////////ImpromptuHelper.ShowPrompt("Calender is Updated Successfully");
    }

    protected void GenerateCalander()
    {
        BLLTCS_StdAttnCalender obj = new BLLTCS_StdAttnCalender();
        DataRow userrow = (DataRow)Session["rightsRow"];

        obj.Main_Organisation_Id = Convert.ToInt32(userrow["Main_Organisation_Id"].ToString());
        obj.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
        obj.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        obj.Year = ddlYears.SelectedItem.Text;

        obj.TCS_StdAttnCalenderInsert(obj);
    }

    protected void ResetControls()
    {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
        txtDescription.Text = "";
        btns.Visible = false;
        btnGen.Visible = false;
        trDate.Visible = false;
        trOpt.Visible = false;
        txtDate.Text = "";
        trDayType.Visible = false;
        TrDate2.Visible = false;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        ResetControls();
    }

    protected void btnCompose_Click(object sender, EventArgs e)
    {
        if (ddlYears.SelectedIndex > 0)
        {
            trCDT.Visible = true;
            trCDTEnt.Visible = true;
            trDayType.Visible = true;
            btns.Visible = true;
            btnGen.Visible = true;
            trDate.Visible = true;
            trOpt.Visible = true;
            txtDate.Text = "";
            txtDescription.Text = "";
            btnSave.Text = "Save";
            ViewState["Mode"] = "add";
            bindddlDayType();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select an year.");
        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        int Call_ID = Int32.Parse(imgbtn.CommandArgument);
        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        trDayType.Visible = true;
        btns.Visible = true;
        trDate.Visible = true;
        trOpt.Visible = true;
        ViewState["Mode"] = "Edit";
        ViewState["Call_ID"] = Call_ID;
        btnSave.Text = "Update Year Calender";
        txtDate.Enabled = false;
        GridViewRow gvr;
        gvr = (GridViewRow)imgbtn.NamingContainer;
        gvAttnType.SelectedIndex = gvr.RowIndex;
        loadFrm(Call_ID);
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        int Call_ID = Int32.Parse(imgbtn.CommandArgument);

        BLLTCS_StdAttnCalenderHolidays obj = new BLLTCS_StdAttnCalenderHolidays();
        obj.Call_ID = Call_ID;
        obj.ModifiedOn = System.DateTime.Now;
        obj.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());

        obj.TCS_StdAttnCalenderHolidaysDelete(obj);
        bindGV(ddlYears.SelectedItem.Text);
    }
    protected void loadFrm(int Call_ID)
    {
        BLLTCS_StdAttnCalenderHolidays bll = new BLLTCS_StdAttnCalenderHolidays();
        DataTable dt = new DataTable();

        bll.Call_ID = Call_ID;
        dt = bll.TCS_StdAttnCalenderHolidaysSelectByCall_ID(bll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            txtDate.Text = dt.Rows[0]["CallDate"].ToString();
            txtDescription.Text = dt.Rows[0]["Remarks"].ToString();
            bindddlDayType();
            ddlDayType.SelectedValue = dt.Rows[0]["CalDayType_Id"].ToString();
        }
    }

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnType.PageIndex = e.NewPageIndex;
        gvAttnType.DataSource = ViewState["LoadData"];
        gvAttnType.DataBind();
    }

    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYears.SelectedValue != "0")
        {
            bindGV(ddlYears.SelectedItem.Text);
        }
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblType.SelectedValue == "0")
        {
            TrDate2.Visible = false;
        }
        else if (rblType.SelectedValue == "1")
        {
            TrDate2.Visible = true;
        }
    }
}
