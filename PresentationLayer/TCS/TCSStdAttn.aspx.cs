using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TSSStdAttn : System.Web.UI.Page
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
            gvAttnMonthly.RowCreated += new GridViewRowEventHandler(gvAttnMonthly_RowCreated);
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

            //====== End Page Access settings ======================




            if (ddl_ClassSection.SelectedValue.ToString() != "0")
            {
                gvOptions.DataSource = null;
                gvOptions.DataBind();
                gvAttnMonthly.DataSource = null;
                gvAttnMonthly.DataBind();
            }


            trClsSec.Visible = true;
            trStd.Visible = true;
            trLeaveType.Visible = true;
            trDate.Visible = true;
            trLnkBtn.Visible = true;
            trgvOptions.Visible = true;
            trMonth.Visible = true;
            bindClassSection();
            ViewState["Mode"] = "add";
            lnkAddOptions.Text = "Mark -ve Attendance";
            int Curmonth = System.DateTime.Now.Month;
            ddlMonth.SelectedValue = Curmonth.ToString();
            txtDate.Text = System.DateTime.Now.ToShortDateString();

            bindLeaveType();
        }
    }
    protected void bindClassSection()
    {
        try
        {
            BLLTCS_StdAttn obj = new BLLTCS_StdAttn();
            obj.Center_Id = Convert.ToInt32(Session["cId"]);
            DataTable dt = (DataTable)obj.TssSelectClassSectionByCenter(obj);
            objbase.FillDropDown(dt, ddl_ClassSection, "Section_id", "Name");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void bindGV()
    {
        gvAttnMonthly.DataSource = null;
        gvAttnMonthly.DataBind();

        BLLTCS_StdAttn objbll = new BLLTCS_StdAttn();
        DataTable dt = new DataTable();
        DataRow userrow = (DataRow)Session["rightsRow"];
        objbll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        objbll.Month = Int32.Parse(ddlMonth.SelectedValue);
        objbll.Year = Convert.ToInt32(txtDate.Text.Substring(txtDate.Text.LastIndexOf("/") + 1, 4));
        objbll.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);

        dt = objbll.TSSMonthlyAttnSummery(objbll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadGrid"] = dt;
            gvAttnMonthly.DataSource = dt;
            gvAttnMonthly.DataBind();

            lblNoData.Visible = false;
            lblNoData.Text = "";
        }
        else
        {
            lblNoData.Visible = true;
            lblNoData.Text = "No Data Found";
        }
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
        bll.CalDate = txtDate.Text.Trim().Replace("'", "");
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
        if (CalDayType_Id == "")
        {
            if (ViewState["Mode"].ToString() == "add")
            {
                if (ViewState["StdLst"] != null)
                {
                    DataTable dt = (DataTable)ViewState["StdLst"];
                    if (dt.Rows.Count > 0)
                    {
                        dtfill = FillDTOption(5);
                        if (dtfill.Rows.Count == 0)
                        {
                            BLLSession objSes = new BLLSession();
                            objSes.Center_Id = Convert.ToInt32(Session["cId"].ToString());
                            DataTable dtSes = objSes.SessionSelectActiveByCenter(objSes);
                            if (dtSes.Rows.Count > 0)
                            {
                                objbll.Session_Id = Convert.ToInt32(dtSes.Rows[0]["Session_Id"].ToString());
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                objbll.Cal_ID = Cal_ID;
                                objbll.AttnDate = txtDate.Text.Trim().Replace("'", "");
                                if (Convert.ToDateTime(txtDate.Text.Trim().Replace("'", "")) < Convert.ToDateTime(dt.Rows[i]["AdmReqDate"]))
                                {
                                    objbll.AttnType_Id = 2;//absent
                                }
                                else
                                {
                                    objbll.AttnType_Id = 1;   //1 is for Present by Default    
                                }

                                objbll.Student_Id = Int32.Parse(dt.Rows[i]["Student_Id"].ToString());
                                objbll.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);
                                objbll.CreatedBy = Int32.Parse(Session["ContactID"].ToString());
                                objbll.CreatedOn = System.DateTime.Now;

                                objbll.TCS_StdAttnInsert(objbll);
                            }
                        }
                        else if (ViewState["addOptions"] == null)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                objbll.AttnDate = txtDate.Text.Trim().Replace("'", "");

                                if (Convert.ToDateTime(txtDate.Text.Trim().Replace("'", "")) < Convert.ToDateTime(dt.Rows[i]["AdmReqDate"]))
                                {
                                    objbll.AttnType_Id = 2;//absent
                                }
                                else
                                {
                                    objbll.AttnType_Id = 1;   //1 is for Present by Default    
                                }

                                //objbll.AttnType_Id = 1;   //1 is for Present by Default
                                objbll.Student_Id = Int32.Parse(dt.Rows[i]["Student_Id"].ToString());
                                objbll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
                                objbll.ModifiedOn = System.DateTime.Now;

                                objbll.TCS_StdAttnUpdate(objbll);
                            }
                        }
                    }
                    BLLTCS_StdAttn objBllDetail = new BLLTCS_StdAttn();
                    DataTable dtSOptions = new DataTable();
                    if (ViewState["addOptions"] != null)
                    {



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objbll.AttnDate = txtDate.Text.Trim().Replace("'", "");
                            objbll.AttnType_Id = 1;   //1 is for Present by Default    
                            objbll.Student_Id = Int32.Parse(dt.Rows[i]["Student_Id"].ToString());
                            objbll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
                            objbll.ModifiedOn = System.DateTime.Now;

                            objbll.TCS_StdAttnUpdate(objbll);
                        }
                        dtSOptions = (DataTable)ViewState["addOptions"];
                        if (dtSOptions.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtSOptions.Rows.Count; i++)
                            {
                                objbll.AttnDate = dtSOptions.Rows[i]["AttnDate"].ToString();
                                objbll.AttnType_Id = Int32.Parse(dtSOptions.Rows[i]["AttnType_Id"].ToString());
                                objbll.Student_Id = Int32.Parse(dtSOptions.Rows[i]["Student_Id"].ToString());
                                objbll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
                                objbll.ModifiedOn = System.DateTime.Now;

                                objbll.TCS_StdAttnUpdate(objbll);
                            }
                        }
                    }

                    gvOptions.DataSource = (DataTable)ViewState["addOptions"];
                    gvOptions.DataBind();
                }
            }
            else if (ViewState["Mode"].ToString() == "Edit")
            {

            }
            ImpromptuHelper.ShowPrompt("Attendance marked successfully");
            bindGV();

        }
        else
        {

            DataTable dt = (DataTable)ViewState["StdLst"];
            if (dt.Rows.Count > 0)
            {
                dtfill = FillDTOption(5);
                if (dtfill.Rows.Count == 0)
                {
                    BLLSession objSes = new BLLSession();
                    objSes.Center_Id = Convert.ToInt32(Session["cId"].ToString());
                    DataTable dtSes = objSes.SessionSelectActiveByCenter(objSes);
                    if (dtSes.Rows.Count > 0)
                    {
                        objbll.Session_Id = Convert.ToInt32(dtSes.Rows[0]["Session_Id"].ToString());
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objbll.Cal_ID = Cal_ID;
                        objbll.AttnDate = txtDate.Text.Trim().Replace("'", "");

                        objbll.AttnType_Id = 24;   // "-" for other holidays    
                        objbll.Student_Id = Int32.Parse(dt.Rows[i]["Student_Id"].ToString());
                        objbll.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);
                        objbll.CreatedBy = Int32.Parse(Session["ContactID"].ToString());
                        objbll.CreatedOn = System.DateTime.Now;

                        objbll.TCS_StdAttnInsert(objbll);
                    }
                }
            }
        }


        ImpromptuHelper.ShowPrompt("In Calendar " + txtDate.Text.Trim() + " is " + calDayDesc + " so attendance can not be marked");

        bindGV();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        int AttnType_ID = Int32.Parse(imgbtn.CommandArgument);
        ViewState["Mode"] = "Edit";
        ViewState["AttnType_ID"] = AttnType_ID;

        btnSave.Text = "Update";
        GridViewRow gvr;
        gvr = (GridViewRow)imgbtn.NamingContainer;

        loadFrm(AttnType_ID);
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        int AttnType_ID = Int32.Parse(imgbtn.CommandArgument);

        BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();
        obj.AttnType_ID = AttnType_ID;
        obj.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
        obj.ModifiedOn = System.DateTime.Now;

        obj.TCS_StdAttnTypeDelete(obj);
    }
    protected void loadFrm(int AttnType_ID)
    {
        BLLTCS_StdAttnType bll = new BLLTCS_StdAttnType();
        DataTable dt = new DataTable();

        bll.AttnType_ID = AttnType_ID;
        dt = bll.TCS_StdAttnTypeSelectByAttnType_ID(bll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;

        }
    }

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }


    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_ClassSection.SelectedValue.ToString() != "0")
            {
                loadStudents();
                gvOptions.DataSource = null;
                gvOptions.DataBind();
                ViewState["addOptions"] = null;
                DataTable dt = new DataTable();
                dt = FillDTOption(4);
                                gvOptions.DataSource = dt;
                ViewState["addOptions"] = dt;
                gvOptions.DataBind();
                bindGV();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void loadStudents()
    {


        BLLTCS_StdAttn obj = new BLLTCS_StdAttn();

        obj.Class_Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);


        DataTable dt = (DataTable)obj.TssStudentSelectByClassSectionIdForAttendance(obj);
        ViewState["StdLst"] = dt;
        objbase.FillDropDown(dt, list_student, "Student_Id", "Name");


    }
    protected void bindLeaveType()
    {

        BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();

        DataTable dt = obj.TCS_StdAttnTypeSelectAll();

        objbase.FillDropDown(dt, ddlLeaveType, "AttnType_ID", "AttnDesc");





    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindLeaveType();
    }
    protected void btnDeleteOpt_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton bt = (ImageButton)sender;
        string id = bt.CommandArgument;


        if (ViewState["addOptions"] != null)
        {
            DataTable dtbl = (DataTable)ViewState["addOptions"];


            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (id == dtbl.Rows[i]["Attn_ID"].ToString())
                {
                    dtbl.Rows[i].Delete();
                }
            }

            dtbl.AcceptChanges();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                dtbl.Rows[i]["Attn_ID"] = i + 1;
            }
            this.gvOptions.DataSource = dtbl;
            this.gvOptions.DataBind();

            ViewState["addOptions"] = dtbl;

            if (dtbl.Rows.Count == 0)
            {
                ViewState["addOptions"] = null;
            }
        }
        else
        {
            this.gvOptions.DataSource = null;
            this.gvOptions.DataBind();

        }
    }
    protected void btnEditOpt_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton bt = (ImageButton)sender;
        string id = bt.CommandArgument;


        lnkAddOptions.Text = "Update -ve Attendance";

        DataTable dtbl = new DataTable();
        if (ViewState["addOptions"] != null)
        {
            dtbl = (DataTable)ViewState["addOptions"];

            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (id == dtbl.Rows[i]["Attn_ID"].ToString())
                {
                    this.list_student.SelectedValue = dtbl.Rows[i]["Student_Id"].ToString();
                    this.txtDate.Text = dtbl.Rows[i]["AttnDate"].ToString();
                    this.ddlLeaveType.SelectedValue = dtbl.Rows[i]["AttnType_Id"].ToString();
                }
            }
            ViewState["OptID"] = id;
        }
    }
    protected void lnkAddOptions_Click(object sender, EventArgs e)
    {
        if (lnkAddOptions.Text == "Update -ve Attendance")
        {
            string id = ViewState["OptID"].ToString();
            DataTable dtbl = new DataTable();
            if (ViewState["addOptions"] != null)
            {
                dtbl = (DataTable)ViewState["addOptions"];

                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    if (id == dtbl.Rows[i]["Attn_ID"].ToString())
                    {
                        dtbl.Rows[i]["name"] = list_student.SelectedItem.Text;
                        dtbl.Rows[i]["AttnDate"] = this.txtDate.Text.Trim().Replace("'", "");
                        dtbl.Rows[i]["AttnDesc"] = this.ddlLeaveType.SelectedItem.Text;
                        dtbl.Rows[i]["AttnType_Id"] = this.ddlLeaveType.SelectedValue;
                        dtbl.Rows[i]["Student_Id"] = this.list_student.SelectedValue;
                    }
                }
                ViewState["addOptions"] = dtbl;
                gvOptions.DataSource = dtbl;
                gvOptions.DataBind();
                list_student.SelectedIndex = 0;
                ddlLeaveType.SelectedIndex = 0;
                lnkAddOptions.Text = "Mark -ve Attendance";
            }
        }
        else if (lnkAddOptions.Text == "Mark -ve Attendance")
        {
            DataTable dtOptions = null;
            DataRow drOptions;
            if (ViewState["addOptions"] != null)
            {
                dtOptions = (DataTable)ViewState["addOptions"];
            }
            else
            {
                dtOptions = new DataTable();
                dtOptions.Columns.Add("Attn_ID");
                dtOptions.Columns.Add("Student_ID");
                dtOptions.Columns.Add("AttnType_ID");
                dtOptions.Columns.Add("name");
                dtOptions.Columns.Add("AttnDate");
                dtOptions.Columns.Add("AttnDesc");
            }
            drOptions = dtOptions.NewRow();

            drOptions["Attn_ID"] = dtOptions.Rows.Count + 1;
            drOptions["Student_Id"] = this.list_student.SelectedValue;
            drOptions["AttnType_Id"] = this.ddlLeaveType.SelectedValue;
            drOptions["name"] = Convert.ToString(list_student.SelectedItem.Text);
            drOptions["AttnDate"] = txtDate.Text.Trim().Replace("'", "");
            drOptions["AttnDesc"] = ddlLeaveType.SelectedItem.Text;

            string id = this.list_student.SelectedValue;
            bool isexist = false;

            foreach (DataRow dr in dtOptions.Rows)
            {
                if (dr["Student_Id"].ToString() == id)
                {
                    isexist = true;
                }
            }

            if (isexist == false)
            {
                dtOptions.Rows.Add(drOptions);
                // dtOptions.Rows.Remove(drOptions);
            }

            ViewState["addOptions"] = dtOptions;
            gvOptions.DataSource = dtOptions;
            gvOptions.DataBind();

            list_student.SelectedIndex = 0;
            ddlLeaveType.SelectedIndex = 0;
        }
    }
    protected void gvAttnMonthly_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnMonthly.PageIndex = e.NewPageIndex;
        gvAttnMonthly.DataSource = ViewState["LoadGrid"];
        gvAttnMonthly.DataBind();
    }
    protected void gvAttnMonthly_RowDataBound(object sender, GridViewRowEventArgs e)
    {


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
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        gvOptions.DataSource = null;
        gvOptions.DataBind();
        ViewState["addOptions"] = null;

        dt = FillDTOption(4);

        gvOptions.DataSource = dt;
        ViewState["addOptions"] = dt;
        gvOptions.DataBind();

        bindGV();
    }
    protected DataTable FillDTOption(int param)
    {



        BLLTCS_StdAttn obj = new BLLTCS_StdAttn();

        obj.Center_Id = Convert.ToInt32(Session["cId"]);
        obj.date = Convert.ToDateTime(txtDate.Text.Trim().Replace("'", ""));
        obj.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);
        obj.parm = param;


        DataTable dt = (DataTable)obj.TCS_StdAttnDailyRptAttnTypeWise(obj);






        return dt;
    }


    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
