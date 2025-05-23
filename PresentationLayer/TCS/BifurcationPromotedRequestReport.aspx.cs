﻿using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Configuration;

public partial class PresentationLayer_BifurcationPromotedRequestReport : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 12; //--Bifurcation Class 8--\\

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
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
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

                BLLSection_Subject obj = new BLLSection_Subject();
                obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
                obj.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);

                DataTable dt1 = obj.Evaluation_Criteria_TypeBySectionId(obj);
                objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");
                ViewState["dtDetails"] = null;
                gv_details.DataSource = null;
                gv_details.DataBind();
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
            int center = Convert.ToInt32(20103004);
            dt = obj.Class_CenterFetch(center);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 11).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 13).CopyToDataTable();

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

    private void bindrdbClass()
    {
        try
        {
            BLLClass obj = new BLLClass();
            DataTable dt = null;
            dt = obj.ClassFetch(obj);

            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 13 || r.Field<int>("Class_Id") == 17).CopyToDataTable();
            
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

            if (ddlClass.SelectedIndex > 0)
                objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());  //Added by huzaifa on 30-05-2022
            else
                objClsSec.Class_Id = Class_Id;
            if (ddlterm.SelectedIndex > 0)
                objClsSec.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());  //Added by huzaifa on 30-05-2022
            else
                objClsSec.TermGroupID = 0;

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }



            if (dtsub.Rows.Count > 0)
            {

                tdSearch.Visible = true;
                gv_details.DataSource = dtsub;
                gv_details.DataBind();

                ViewState["dtDetails"] = dtsub;
                btns.Visible = true;
                lblGridStatus.Text = "";

            }
            else
            {
                tdSearch.Visible = false;
                gv_details.DataSource = null;
                gv_details.DataBind();
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

            //if (ddlClass.SelectedIndex > 0)
            //{
            //    ddlClass.SelectedIndex = -1;
            //}

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

    void AddOrRemoveClass9M(string _Class_Id, string _PromotedTo)
    {

        ListItem Class9M = new ListItem("9 M (Matric)", "17");
        
    }


    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
            loadClass();
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
            bindrdbClass();
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
        
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        

    }
    protected void btnSubmitReq_Click(object sender, EventArgs e)
    {
        
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
                if (ViewState["RegionId"] != null && ViewState["RegionId"].ToString() == "0" && ViewState["CenterId"] != null && ViewState["CenterId"].ToString() == "0")
                {
                    //foreach (GridViewRow r in gv_details.Rows)
                    //{
                    //    r.FindControl("btnDelete").Visible = true;
                    //    r.FindControl("btnSubmit").Visible = false;
                    //}
                }
                else
                {
                    //foreach (GridViewRow r in gv_details.Rows)
                    //{
                    //    r.FindControl("btnDelete").Visible = false;

                    //}
                }
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
    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlterm.SelectedIndex > 0)
        {
            ViewState["dtDetails"] = null;
            ResetFilter();
            ApplyFilter(4);
        }
        else
        {
            ResetFilter();
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

    protected void gv_details_PreRender1(object sender, EventArgs e)
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
}