using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_CenterClassTotalTermDays : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    BLLStudent_Performance_Grading_Mst ObjMst = new BLLStudent_Performance_Grading_Mst();

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];

        if (!IsPostBack)
        {
            try
            {
                ViewState["MainOrgId"] = 0;
                ViewState["RegionId"] = 0;
                ViewState["CenterId"] = 0;
                /////////Setting ///////////////


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Campus Officer
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = 0;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Regional Officer
                {

                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = row["Center_Id"].ToString();
                }

                ////////////////////////////
                loadRegions();
                FillActiveSessions();
                BindTerm();
                trButtons.Visible = false;
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }
    private void BindGrid()
    {
        try
        {
            BLLCenter_Class_TermDays objClsSec = new BLLCenter_Class_TermDays();

            DataTable dtsub = new DataTable();

            objClsSec.Main_Organisation_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            if (Convert.ToInt32(ViewState["RegionId"].ToString()) == 0)
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            if (Convert.ToInt32(ViewState["CenterId"].ToString()) == 0)
            {
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Center_Id = Convert.ToInt32(ViewState["CenterId"].ToString());
            }
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Center_Class_TermDaysSelectAllByregionIdCenterId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                dv_details.DataSource = dtsub;
                dv_details.DataBind();
                btns.Visible = true;
            }
            else
            {
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            TextBox txt_DaysAttended;
            Label lblStdId;
            //Label lblDaysAttend;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txt_DaysAttended = (TextBox)e.Row.FindControl("txttermdays");
                lblStdId = (Label)e.Row.FindControl("stdIds");
                //lblDaysAttend = (Label)e.Row.FindControl("lblDaysAttend");

                ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(e.Row.Cells[2].Text);
                ObjMst.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                ObjMst.Grade_Id = Convert.ToInt32(e.Row.Cells[4].Text);
                ObjMst.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                ObjMst.DaysAttend = txt_DaysAttended.Text;

                DataTable _dt = ObjMst.Student_Performance_Grading_MstSelectAllClass(ObjMst);

                if (_dt.Rows.Count > 0)
                {
                    if (_dt.Rows[0]["Student_Id"].ToString() == "")
                    {
                        lblStdId.Text = "-";
                        lblStdId.ForeColor = Color.Black;
                        //lblDaysAttend.Text = "-";
                        //lblDaysAttend.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblStdId.Text = _dt.Rows[0]["Student_Id"].ToString();
                        //lblDaysAttend.Text = _dt.Rows[0]["DaysAttend"].ToString();
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
    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                ddl_region.SelectedValue = ViewState["RegionId"].ToString();
                ddl_region.Enabled = false;
                loadCenter();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                objCen.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            {
                ddl_center.SelectedValue = ViewState["CenterId"].ToString();
                ddl_center.Enabled = false;

            }

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


            if (list_Term.SelectedItem.Text == "Select")
            {

                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;

            }


            if (list_Term.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && ddl_region.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            {

                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Region,Center, Session and Term Group!");


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedValue != "")
            {

                DDLReset(list_Term);
            }

            if (ddlSession.SelectedItem.Text == "Select")
            {



                list_Term.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;

            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void DDLReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();

            if (ddl_region.SelectedItem.Text == "Select")
            {

                ddl_center.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                list_Term.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_center.SelectedItem.Text == "Select")
        {


            ddlSession.SelectedIndex = 0;
            list_Term.SelectedIndex = 0;
            dv_details.DataSource = null;
            dv_details.DataBind();
            btns.Visible = false;
        }
    }
    protected void but_save_Click(object sender, EventArgs e)
    {
        BLLCenter_Class_TermDays objBll = new BLLCenter_Class_TermDays();

        int AlreadyIn = 0;
        try
        {
            bool isSelected = false;

            CheckBox cb = null;
            CheckBox cb2 = null;

            foreach (GridViewRow gvr in dv_details.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");
                cb2 = (CheckBox)gvr.FindControl("CheckBox2");
                TextBox txttotaldays = (TextBox)dv_details.Rows[gvr.RowIndex].FindControl("txttermdays");
                Label lblStdId = (Label)dv_details.Rows[gvr.RowIndex].FindControl("stdIds");
                int DaysAttend = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[9].Text);

                objBll.CenterClassTermDayId = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[1].Text);
                objBll.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                objBll.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
                objBll.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
                objBll.Class_Id = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[4].Text);
                objBll.Evaluation_Criteria_Type_Id = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[2].Text);
                ////////objBll.TotalTermDays = Convert.ToInt32(txttotaldays.Text);

                int convertedInput;
                if (Int32.TryParse(txttotaldays.Text, out convertedInput))
                {
                    //the userInput was a valid integer. convertedInput is now set to the integer value
                    objBll.TotalTermDays = Convert.ToInt32(txttotaldays.Text);
                }
                else
                {
                    //the userInput was ***not*** a valid integer. 
                    ImpromptuHelper.ShowPrompt("Please Enter Integer value only!");
                }

                if (Convert.ToInt32(txttotaldays.Text) >= DaysAttend)
                {
                    AlreadyIn = objBll.Center_Class_TermDaysAdd(objBll);
                }
                isSelected = true;
            }

            if (isSelected)
            {
                BindGrid();
                ImpromptuHelper.ShowPrompt("Record(s) updated successfully for student(s) attended days not exceeding from Total Term Days!");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddl_center.SelectedIndex = 0;
        ddlSession.SelectedIndex = 0;
        list_Term.SelectedIndex = 0;
        dv_details.DataSource = null;
        dv_details.DataBind();
        btns.Visible = false;

        if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
        {
            ddl_region.SelectedValue = ViewState["RegionId"].ToString();
            loadCenter();
        }

    }

    protected void txttermdays_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            //TextBox txt = (TextBox)currentRow.FindControl("TxtId");

            TextBox txt_DaysAttended;
            Label lblStdId;
            //Label lblDaysAttend;

            txt_DaysAttended = (TextBox)currentRow.FindControl("txttermdays");
            lblStdId = (Label)currentRow.FindControl("stdIds");
            //lblDaysAttend = (Label)e.Row.FindControl("lblDaysAttend");

            ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(currentRow.Cells[2].Text);
            ObjMst.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            ObjMst.Grade_Id = Convert.ToInt32(currentRow.Cells[4].Text);
            ObjMst.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            ObjMst.DaysAttend = txt_DaysAttended.Text;

            DataTable _dt = ObjMst.Student_Performance_Grading_MstSelectAllClass(ObjMst);

            if (_dt.Rows.Count > 0)
            {
                if (_dt.Rows[0]["Student_Id"].ToString() == "")
                {
                    lblStdId.Text = "-";
                    lblStdId.ForeColor = Color.Black;

                }
                else
                {
                    lblStdId.Text = _dt.Rows[0]["Student_Id"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}