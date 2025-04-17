using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using City.Library.SQL;

public partial class PresentationLayer_StudentConditionallyPromotedRequestReport : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    private DataSet ds = null;
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];

        if (!IsPostBack)
        {
            try
            {
                //ViewState["MainOrgId"] = 0;
                //ViewState["RegionId"] = 0;
                //ViewState["CenterId"] = 0;
                /////////Setting ///////////////
                if (row["User_Type"].ToString() != "SAdmin")
                {

                }


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = 0;
                    Center_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    trButtons.Visible = false;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = row["Center_Id"].ToString();
                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                    //  ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    trButtons.Visible = false;


                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                }

            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }
    protected void btnProcessed_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedIndex > 0)
            {
                //ViewState["dtDetails"] = null;
                //ViewState["RD_Approval"] = true;
                //ViewState["Submit_RD"] = null;
                //BindGrid();
                ResetFilter();
                ApplyFilter(3);
            }
            else
                ImpromptuHelper.ShowPrompt("Please select Session");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnShowSubmitted_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedIndex > 0)
            {
                //ViewState["dtDetails"] = null;
                //ViewState["Submit_RD"] = true;
                //ViewState["RD_Approval"] = null;
                //BindGrid();
                ResetFilter();
                ApplyFilter(2);
            }
            else
                ImpromptuHelper.ShowPrompt("Please select Session");
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
            if (ddlClass.SelectedIndex > 0)
            {
                ResetFilter();
                ApplyFilter(4);

            }
            else
            {
                ResetFilter();
            }


            //ViewState["dtDetails"] = null;
            //           ViewState["Submit_RD"] = false;
            //            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void loadClass()
    {
        try
        {
            BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            int center = Convert.ToInt32(ddl_center.SelectedValue);
            dt = obj.Class_CenterFetch(center);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 14).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") != 12).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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
            BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

            DataTable dtsub = new DataTable();

            //if (ddlClass.SelectedIndex > 0)
            //    objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            if (ddlClass.SelectedIndex > 0)

            {

                objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());

            }

            else

            {

                objClsSec.Class_Id = Class_Id;

            }
            objClsSec.Main_Organisation_Id = MOId;

            if (Region_Id == 0)
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Region_Id = Region_Id;
            }
            if (ddl_center.SelectedIndex > 0)
            {
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Center_Id = Center_Id;
            }
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

            //if (ViewState["dtDetails"] == null)
            //{
            dtsub = (DataTable)objClsSec.Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(objClsSec);
            //}
            //else
            //{
            // dtsub = (DataTable)ViewState["dtDetails"];
            //}



            if (dtsub.Rows.Count > 0)
            {

                tdSearch.Visible = true;
                gv_details.DataSource = dtsub;
                gv_details.DataBind();
                ViewState["dtDetails"] = dtsub;
                btns.Visible = true;
                lblGridStatus.Text = "";
                if (Region_Id == 0 && Center_Id == 0)
                {
                    //foreach (GridViewRow r in gv_details.Rows)
                    //{
                    //    r.FindControl("btnDelete").Visible = true;
                    //    r.FindControl("btnRevert").Visible = true;
                    //    r.FindControl("btnSubmit").Visible = false;
                    //}
                }
                else
                {
                    //foreach (GridViewRow r in gv_details.Rows)
                    //{
                    //    r.FindControl("btnDelete").Visible = false;
                    //    r.FindControl("btnRevert").Visible = false;

                    //}
                }

            }
            else
            {
                tdSearch.Visible = false;
                gv_details.DataSource = dtsub;
                gv_details.DataBind();
                ViewState["dtDetails"] = dtsub;
                btns.Visible = false;
                lblGridStatus.Text = "No Record Found!";
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

            oDALRegion.Main_Organisation_Country_Id = MOId;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


            if (Region_Id != 0)
            {
                ddl_region.SelectedValue = Region_Id.ToString();
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
            if (Region_Id != 0)
            {
                objCen.Region_Id = Region_Id;
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (Center_Id != 0)
            {
                ddl_center.SelectedValue = Center_Id.ToString();
                ddl_center.Enabled = false;
                ddl_center_SelectedIndexChanged(this, EventArgs.Empty);
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
            if (ddlSession.SelectedItem.Text == "Select")
            {
                ViewState["dtDetails"] = null;
                gv_details.DataSource = null;
                gv_details.DataBind();
                btns.Visible = false;
            }
            if (ddlSession.SelectedIndex > 0 && ddl_region.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            {
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Region,Center and Session!");
            }

            if (ddlClass.SelectedIndex > 0)
            {
                ddlClass.SelectedIndex = -1;
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
                gv_details.DataSource = null;
                gv_details.DataBind();
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
        try
        {
            if (ddl_center.SelectedItem.Text == "Select")
            {
                ddlSession.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();
                btns.Visible = false;
            }
            else
                loadClass();
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
            BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
            Button btn = (Button)(sender);
            obj.Student_Id = Convert.ToInt32(btn.CommandArgument);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Student_Conditionally_Promoted_RequestDelete(obj);
            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["mode"] = "Add";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Button btn = (Button)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gv_details.SelectedIndex = gvr.RowIndex;
            txtStdId.Text = btn.CommandArgument;
            txtStdName.Text = gvr.Cells[3].Text.Replace("&#39;", "'");
            txtClassSec.Text = gvr.Cells[4].Text + " - " + gvr.Cells[5].Text;
            ViewState["Class_Id"] = gvr.Cells[1].Text;
            ViewState["Class_Name"] = gvr.Cells[4].Text;
            ViewState["Section_Name"] = gvr.Cells[5].Text;
            ViewState["TermGroupID"] = gv_details.DataKeys[gvr.RowIndex].Values["TermGroupID"].ToString();

            BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
            obj.Student_Id = Convert.ToInt32(txtStdId.Text);
            DataTable dt = obj.Student_Conditionally_Promoted_RequestCheckStatus(obj);
            if (dt.Rows.Count > 0)
            {
                txtRemarks.Text = dt.Rows[0]["Reason"].ToString();
                txtRemarks.Enabled = false;
                btnSubmitReq.Visible = false;
            }
            else
            {
                btnSubmitReq.Visible = true;
                txtRemarks.Enabled = true;
                txtRemarks.Text = "";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        txtRemarks.Text = "";
        txtStdId.Text = "";
        txtStdName.Text = "";
        txtClassSec.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);

    }
    protected void btnSubmitReq_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

            DataTable dtsub = new DataTable();

            string StudentNO = txtStdId.Text;
            objClsSec.Remarks = txtRemarks.Text;
            int AlreadyIn = 0;
            DataTable dt = new DataTable();


            objClsSec.Student_Id = Int32.Parse(StudentNO);
            objClsSec.Student_No = Int32.Parse(StudentNO);
            objClsSec.StudentName = txtStdName.Text;
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            objClsSec.Class_Id = Int32.Parse(ViewState["Class_Id"].ToString());
            objClsSec.Class_Name = ViewState["Class_Name"].ToString();
            objClsSec.Section_Name = ViewState["Section_Name"].ToString();
            objClsSec.Remarks = txtRemarks.Text;
            objClsSec.ClassRequest = Int32.Parse(ViewState["Class_Id"].ToString()) + 1;
            objClsSec.TermGroupID = Convert.ToInt32(ViewState["TermGroupID"].ToString());
            objClsSec.Submit_RD = true;
            objClsSec.Submit_RD_By = Convert.ToInt32(Session["ContactID"].ToString());
            objClsSec.Submit_RD_On = DateTime.Now;


            string mode = Convert.ToString(ViewState["mode"]);

            if (mode == "Add")
            {
                AlreadyIn = objClsSec.Student_Conditionally_Promoted_RequestAdd(objClsSec);
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    ViewState["dtDetails"] = null;
                    BindGrid();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Student can request for discretionary promotion only once");

                }
            }
            btnClose_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{

        //    TextBox txttotaldays;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {



        //        txttotaldays = (TextBox)e.Row.FindControl("txttermdays");
        //        DataRow row = ((DataRowView)e.Row.DataItem).Row;

        //        if (Convert.ToInt32(row["Submit_RD"]) == 1)//Generated
        //        {

        //            txttotaldays.Enabled = false;
        //        }
        //        else if (Convert.ToInt32(row["Submit_RD"]) == 0)//Not Generated
        //        {


        //            txttotaldays.Enabled = true;
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }



    protected void ApplyFilter(int _FilterCondition)
    {
        try
        {

            if (ViewState["dtDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtDetails"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // Pending
                        {
                            if (ddlClass.SelectedIndex > 0)
                                strFilter = " Convert([RD_Approval], 'System.String')='3' and " + " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                            else
                                strFilter = " Convert([RD_Approval], 'System.String')='3'";
                            break;
                        }

                    case 2: //Submitted
                        {
                            if (ddlClass.SelectedIndex > 0)
                                strFilter = " Convert([RD_Approval], 'System.String')='2' and " + " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                            else
                                strFilter = " Convert([RD_Approval], 'System.String')='2'";
                            break;
                        }

                    case 3: // Processed by RD
                        {
                            if (ddlClass.SelectedIndex > 0)
                                strFilter = " Convert([RD_Approval], 'System.String') in ('1','0') and " + " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                            else
                                strFilter = " Convert([RD_Approval], 'System.String') in ('1','0') ";
                            break;
                        }
                    case 4: // Apply class Filter
                        {
                            strFilter = " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gv_details.DataSource = dv;
                gv_details.DataBind();

                gv_details.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ResetFilter();
        ApplyFilter(1);
    }

    private void ResetFilter()
    {
        try
        {
            //       ViewState["dtDetails"] = null;
            BindGrid();
            gv_details.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            // ddlClass.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            string url = "";
            Button btnEdit = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gv_details.SelectedIndex = gvr.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Class_Id = Convert.ToInt32(gvr.Cells[1].Text);
            obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Section_Id = Convert.ToInt32(gvr.Cells[6].Text);
            obj.TermGroup_Id = 1;//Students are detained after final term 
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;


            if (obj.Session_Id == 12)
            {
                url = "";
            }
            else if (!String.IsNullOrEmpty(url))
            {
                url = "../TCS";
            }

            url = url + obj.OpenReport(obj);


            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    //protected void btnViewReport_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        Button btnEdit = (Button)sender;
    //        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
    //        gv_details.SelectedIndex = gvr.RowIndex;
    //        BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
    //        obj.Class_Id = Convert.ToInt32(gvr.Cells[1].Text);
    //        obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
    //        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //        int section_id = Convert.ToInt32(gvr.Cells[6].Text);
    //        int termGroup_Id = 2; //Students are detained after final term 
    //        bool _isok = false;
    //        string url = "";
    //        CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
    //        /*Query string settings*/


    //        string Qs = "?sc=000" + section_id.ToString() + "000" + ddlSession.SelectedValue +
    //            termGroup_Id.ToString() + "&st=" + obj.Student_Id;

    //        if (obj.Class_Id >= 7 && obj.Class_Id <= 12) // Class 3-8
    //        {
    //            if (termGroup_Id == 1)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_3_8_B.aspx" + Qs;
    //                    }
    //                    else
    //                    {
    //                        url = "TCS_HTML_F_3_8_B_201617.aspx" + Qs;
    //                    }

    //                }
    //                else
    //                {
    //                    /*Without Border*/

    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_3_8.aspx" + Qs;

    //                    }
    //                    else
    //                    {

    //                        url = "TCS_HTML_F_3_8_201617.aspx" + Qs;
    //                    }
    //                }
    //            }
    //            else if (termGroup_Id == 2)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    url = "TCS_HTML_S_3_8_B.aspx" + Qs;
    //                }
    //                else
    //                {
    //                    /*Without Border*/
    //                    url = "TCS_HTML_S_3_8.aspx" + Qs;
    //                }
    //            }


    //            _isok = true;

    //        }

    //        else if (obj.Class_Id >= 13 && obj.Class_Id <= 15) // O Level
    //        {

    //            if (termGroup_Id == 1)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_O_A_B.aspx" + Qs;

    //                    }
    //                    else
    //                    {
    //                        url = "TCS_HTML_F_O_A_B_201617.aspx" + Qs;

    //                    }

    //                }
    //                else
    //                {
    //                    /*Without Border*/
    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_O_A.aspx" + Qs;

    //                    }
    //                    else
    //                    {

    //                        url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //                    }
    //                }
    //            }
    //            else if (termGroup_Id == 2)
    //            {
    //                if (obj.Class_Id == 13) //Second Term Class 9
    //                {
    //                    if (ChkSys.Checked == true)
    //                    {
    //                        /*WithBorder*/
    //                        url = "TCS_HTML_S_9_B.aspx" + Qs;
    //                    }
    //                    else
    //                    {
    //                        /*Without Border*/
    //                        url = "TCS_HTML_S_9.aspx" + Qs;
    //                    }
    //                }

    //                else
    //                {

    //                    if (ChkSys.Checked == true)
    //                    {
    //                        /*WithBorder*/
    //                        url = "TCS_HTML_S_O_A_B.aspx" + Qs;

    //                    }
    //                    else
    //                    {
    //                        /*Without Border*/
    //                        url = "TCS_HTML_S_O_A.aspx" + Qs;
    //                    }
    //                }
    //            }
    //            _isok = true;

    //        }

    //        else if (obj.Class_Id >= 17 && obj.Class_Id <= 18) // Class Matric 
    //        {
    //            if (termGroup_Id == 1)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    ////////////////////url = "TCS_HTML_F_3_8_B.aspx" + Qs;
    //                }
    //                else
    //                {
    //                    /*Without Border*/
    //                    url = "TCS_HTML_F_M10.aspx" + Qs;
    //                }
    //            }
    //            else if (termGroup_Id == 2)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    ////////////url = "TCS_HTML_S_3_8_B.aspx" + Qs;
    //                }
    //                else
    //                {
    //                    /*Without Border*/
    //                    //////////url = "TCS_HTML_S_M9_10.aspx" + Qs;
    //                }
    //            }


    //            _isok = true;

    //        }

    //        else if (obj.Class_Id >= 19 && obj.Class_Id <= 20) // A Level
    //        {
    //            if (termGroup_Id == 1)
    //            {
    //                if (ChkSys.Checked == true)
    //                {
    //                    /*WithBorder*/
    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_O_A_B.aspx" + Qs;

    //                    }
    //                    else
    //                    {
    //                        url = "TCS_HTML_F_O_A_B_201617.aspx" + Qs;

    //                    }
    //                }
    //                else
    //                {
    //                    /*Without Border*/
    //                    if (obj.Session_Id <= 7)
    //                    {
    //                        url = "TCS_HTML_F_O_A.aspx" + Qs;

    //                    }
    //                    else
    //                    {

    //                        url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //                    }
    //                }
    //            }
    //        }
    //        else if (termGroup_Id == 2)
    //        {
    //            if (ChkSys.Checked == true)
    //            {
    //                /*WithBorder*/
    //                //Response.Redirect("~/PresentationLayer/TCS/TCS_HTML_S_O_A_B.aspx" + Qs, false);
    //                url = "TCS_HTML_S_A_B.aspx" + Qs;
    //            }
    //            else
    //            {
    //                /*Without Border*/
    //                //Response.Redirect("~/PresentationLayer/TCS/TCS_HTML_S_O_A.aspx" + Qs, false);
    //                url = "TCS_HTML_S_A.aspx" + Qs;
    //            }

    //        }
    //        _isok = true;



    //        if (_isok)
    //        {
    //            //url = "../PresentationLayer/TCS/" + url;
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    protected void btnRevert_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
            Button btn = (Button)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            obj.Student_Id = Convert.ToInt32(btn.CommandArgument);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroupID = Convert.ToInt32(gv_details.DataKeys[gvr.RowIndex].Values["TermGroupID"].ToString());
            obj.Student_Conditionally_Promoted_RequestRevert(obj);

            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btn_bif_email_Click(object sender, EventArgs e)
    {


        if (Request.QueryString.Count > 0)
        {
            string _studntid = Request.QueryString["S"].ToString();
            string _secid = Request.QueryString["C"].ToString();
            string _Trmid = Request.QueryString["T"].ToString();

            DataTable dt1 = ExecuteProcedure_StudentDetail(_studntid, _secid);
            dt1.Dispose();
            DataTable dt = ExecuteProcedure("IN", "", Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString());
            dt.Dispose();
            if (dt.Rows.Count > 0)
            {
                // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
                /*****************EMAIL***************/

                var getclass = ""; //ViewState["classids"].ToString();
                var getterm = "";//ViewState["TermGroupID"].ToString();

                MailMessage mail = new MailMessage();
                var Body = "";
                var To = "";
                var CC = "";

                var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

                To = dt1.Rows[0][2].ToString();//ConfigurationManager.AppSettings["Bifurcation_email"].ToString(); //dt1.Rows[0][2].ToString();
                CC = "ManageAcknowledgement@csn.edu.pk";
                string Subject;
                if (getclass == "13" && getterm == "1")
                    Subject = "Undertaking – Class 9 (1st term)";
                else
                    Subject = "Application – Moving from Class 9 Matric to the O-Level route";



                var onclassbase = "";

                /***********HTML TEMPLET***/
                Body += "<body style='margin:0;padding:0;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
                Body += "<tr>";
                Body += "<td align='center' style='padding:0;'>";
                Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
                Body += "<tr>";
                Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2



                //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
                Body += "<img src = 'https://rebill.csn.edu.pk:8096/inassets/city/tcslogowhite.png'>";
                Body += "</td>";
                Body += "</tr>";
                Body += "<tr>";
                Body += "<td style='padding:36px 30px 42px 30px;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
                Body += "<tr>";
                Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
                Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";



                Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish to submit your application for your child to take O level route, then read & submit the following application:</p><br/><br/>";




                Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>I, as a parent / guardian of <strong>" + dt1.Rows[0]["First_Name"].ToString() + "</strong>ERP # " + dt1.Rows[0]["Student_no"].ToString() + "</strong> studying in Class " + dt1.Rows[0]["Class_Name"].ToString() + " </strong> confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:</p>";



                /**on basis change**/
                /**CLASS UNDERTAKING**/
                if (getclass == "13" && getterm == "1")
                {

                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that class 9 (1st term) result of my child is not up to the mark.</p>";
                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the required attainment levels set out by the school. Progress will be monitored regularly.</p>";
                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams will result in my child’s private registration for his/her CAIE Exams.</p>";

                }





                if (getclass == "12" && getterm == "1")
                {

                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) However, I am insisting that my child should continue the O-Level route.</p>";
                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) I take the responsibility that my child will meet the required attainment levels set out by the school. Progress will be monitored regularly.</p>";
                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 4) Failure to meet the minimum requirements in the internal exams will result in my child’s private registration for his/her CAIE Exams.</p>";
                }
                /**CLASS UNDERTAKING**/



                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>1) That the school, after careful deliberation and consideration of the " + spn_class.InnerText + " Results, has advised me to transfer my child to the Matric system.</p>";
                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>2) However, at my insistence, the school has provisionally allowed my child to sit in " + spn_class.InnerText + " and take final examinations for the O level stream.</p>";
                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>3) Accept the responsibility that my child must pass the " + spn_class.InnerText + " Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";
                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</p>";
                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</p>";

                Body += onclassbase;

                Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request</p>";



                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes("");
                string encrypted_student_Id = Convert.ToBase64String(b);

                byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes("");
                string encrypted_class_Id = Convert.ToBase64String(c);

                byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["session_id"].ToString().Trim());
                string encrypted_session_Id = Convert.ToBase64String(sess);



                //var url = "http://localhost:50091/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id+"&Cl_Id="+ encrypted_class_Id+"&Sess_Id="+ encrypted_session_Id;//ddlStudent.SelectedValue
                var url = "http://tcsaims.com/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id;//ddlStudent.SelectedValue
                Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + url + "'>Confirm</a></b></p>";

                Body += "</td>";
                Body += "</tr>";

                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "<tr>";
                Body += "<td style='padding:30px;background:#FBEE26;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
                Body += "<tr>";
                Body += "<td style='padding:0;width:100%;' align='Center'>";
                Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

                Body += "</td>";

                Body += "</tr>";
                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "</table>";
                Body += "</body>";
                /*****HTML TEMPLET*********/


                //var Password = "Pakistan!@#$";//gmail//"@U13K$@CgMlG";
                var Password = "Jup31963";

                using (MailMessage mm = new MailMessage(Email.Address, To))
                {
                    mm.Subject = Subject;
                    mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                    mm.CC.Add(new MailAddress(CC));
                    //mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

                    mm.Body = Body;


                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        // smtp.Host = "smtp.gmail.com"; //"mail.bizar.pk";
                        smtp.Host = "smtp.office365.com"; //"mail.bizar.pk";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Timeout = 1000000000;



                        try
                        {
                            smtp.Send(mm);



                        }
                        catch (SmtpFailedRecipientException ex)
                        {

                        }

                    }
                }

                /********EMAIL******************/
            }
            else
            { //ImpromptuHelper.ShowPrompt("No Data Found"); }
            }
        }
    }

    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "")
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter_withfatheremail");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);//
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_UserID", Session["UserId"].ToString(), DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_IEP_bifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("Term_id", Term_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

}