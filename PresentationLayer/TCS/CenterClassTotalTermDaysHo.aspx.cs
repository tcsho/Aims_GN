using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_CenterClassTotalTermDaysHo : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)

    {
        copyFirTerm.Visible = false;
        copySecondTerm.Visible = false;
        UpdateRegionTermDays.Visible = false;

        trCenter.Visible = false;
        trGroup.Visible = false;
        trSession.Visible = false;
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
                if (row["User_Type"].ToString() != "SAdmin")
                {


                }

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = 0;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = row["Center_Id"].ToString();
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {


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
                dtsub = dt;
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
                BindGrid();
            }

            if (ddlSession.SelectedItem.Text == "Select")
            {
                list_Term.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;
                dv_details.DataSource = null;
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
            copyFirTerm.Visible = true;
            copySecondTerm.Visible = true;
            UpdateRegionTermDays.Visible = true;
            if (ddl_region.SelectedItem.Text == "Select")
            {
                ddl_center.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                list_Term.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;
            }
            else
            {
                ddlSession.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();
                BindGrid();
                dvRegion.DataSource = null;
                dvRegion.DataBind();
                BindRegionGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void BindRegionGrid()
    {
        try
        {
            BLLCenter_Class_TermDays objClsSec = new BLLCenter_Class_TermDays();
            if (Convert.ToInt32(ViewState["RegionId"].ToString()) == 0)
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            BLLCenter objCen = new BLLCenter();
            DataTable dt = new DataTable();
            dt = objCen.GetRegionByRegionId(objClsSec);
            if (dt.Rows.Count > 0)
            {
                dvRegion.DataSource = dt;
                dvRegion.DataBind();
                btns.Visible = true;
            }
            else
            {
                dvRegion.DataSource = null;
                dvRegion.DataBind();
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
        copyFirTerm.Visible = true;
        copySecondTerm.Visible = true;
        UpdateRegionTermDays.Visible = true;
        BLLCenter_Class_TermDays objBll = new BLLCenter_Class_TermDays();

        int AlreadyIn = 0;
        try
        {
            var isSelected = false;
            foreach (GridViewRow gvr in dv_details.Rows)
            {
                var txtfirtermdays = (TextBox)dv_details.Rows[gvr.RowIndex].FindControl("txtfirstermdays");
                var txtsecondtermdays = (TextBox)dv_details.Rows[gvr.RowIndex].FindControl("txtsecondtermdays");
                objBll.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
                objBll.Center_Id = Convert.ToInt32(gvr.Cells[1].Text);

                int convertedInput;
                if (!int.TryParse(txtfirtermdays.Text, out convertedInput))
                    ImpromptuHelper.ShowPrompt("Please Enter Integer value only!");
                else
                    objBll.FirstTermDays = Convert.ToInt32(txtfirtermdays.Text);

                if (!int.TryParse(txtsecondtermdays.Text, out convertedInput))
                    ImpromptuHelper.ShowPrompt("Please Enter Integer value only!");
                else
                    objBll.SecondTermDays = Convert.ToInt32(txtsecondtermdays.Text);

                AlreadyIn = objBll.Center_TermDaysAdd(objBll);
                isSelected = true;
            }
            if (!isSelected) return;
            BindGrid();
            ImpromptuHelper.ShowPrompt("Record has been successfully added!");
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

    protected void UpdateRegionTermDays_Click(object sender, EventArgs e)
    {
        copyFirTerm.Visible = true;
        copySecondTerm.Visible = true;
        UpdateRegionTermDays.Visible = true;
        BLLCenter_Class_TermDays objBll = new BLLCenter_Class_TermDays();
        int AlreadyIn = 0;
        try
        {
            var isSelected = false;
            foreach (GridViewRow gvr in dvRegion.Rows)
            {
                objBll.Region_Id = Convert.ToInt32(gvr.Cells[1].Text);
                var txtfirtermdays = (TextBox)dvRegion.Rows[gvr.RowIndex].FindControl("txtfirstermdays");
                var txtsecondtermdays = (TextBox)dvRegion.Rows[gvr.RowIndex].FindControl("txtsecondtermdays");
                int convertedInput;
                if (!int.TryParse(txtfirtermdays.Text, out convertedInput))
                    ImpromptuHelper.ShowPrompt("Please Enter Integer value only!");
                else
                    objBll.FirstTermDays = Convert.ToInt32(txtfirtermdays.Text);

                if (!int.TryParse(txtsecondtermdays.Text, out convertedInput))
                    ImpromptuHelper.ShowPrompt("Please Enter Integer value only!");
                else
                    objBll.SecondTermDays = Convert.ToInt32(txtsecondtermdays.Text);

                AlreadyIn = objBll.UpdateRegionTermDays(objBll);
                if (AlreadyIn == 1)
                {
                    isSelected = true;
                }
            }
            if (!isSelected) return;
            BindRegionGrid();
            ImpromptuHelper.ShowPrompt("Record has been updated successfully!");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void copyFirTerm_ServerClick(object sender, EventArgs e)
    {
        copyFirTerm.Visible = true;
        copySecondTerm.Visible = true;
        UpdateRegionTermDays.Visible = true;    
        BLLCenter_Class_TermDays objBll = new BLLCenter_Class_TermDays();
        foreach (GridViewRow gvr in dvRegion.Rows)
        {
            var txtfirtermdays = (TextBox)dvRegion.Rows[gvr.RowIndex].FindControl("txtfirstermdays");
            objBll.Region_Id = Convert.ToInt32(gvr.Cells[1].Text);
            objBll.FirstTermDays = Convert.ToInt32( txtfirtermdays.Text);
        }
        int AlreadyIn= objBll.RegionTermDaysCopyToCenter(objBll);
        if (AlreadyIn == 1)
        {
            BindGrid();
            ImpromptuHelper.ShowPrompt("Term Days have been copied successfully!");
        }
    }

    protected void copySecondTerm_ServerClick(object sender, EventArgs e)
    {
        copyFirTerm.Visible = true;
        copySecondTerm.Visible = true;
        UpdateRegionTermDays.Visible = true;
        BLLCenter_Class_TermDays objBll = new BLLCenter_Class_TermDays();
        foreach (GridViewRow gvr in dvRegion.Rows)
        {
            var txtsecondtermdays = (TextBox)dvRegion.Rows[gvr.RowIndex].FindControl("txtsecondtermdays");
            objBll.Region_Id = Convert.ToInt32(gvr.Cells[1].Text);
            objBll.SecondTermDays = Convert.ToInt32(txtsecondtermdays.Text);
        }
        int AlreadyIn = objBll.RegionSecondTermDaysCopyToCenter(objBll);
        if (AlreadyIn == 1)
        {
            BindGrid();
            ImpromptuHelper.ShowPrompt("Term Days have been copied successfully!");
        }
    }
}