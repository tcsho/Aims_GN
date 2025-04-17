using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;
using System.Globalization;

public partial class PresentationLayer_BifurcationProcessSetup : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 12;  //--Bifurcation Class 8--\\

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];

        if (!IsPostBack)
        {
            try
            {

                if (row["User_Type"].ToString() != "SAdmin")
                {

                }
                //trbtnsyn.Visible = false;

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
                    loadClass();
                    bindTermGroupList();
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
                    loadClass();
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
                    loadClass();
                    trButtons.Visible = false;



                    //DataTable dt1 = objs.Evaluation_Criteria_TypeBySectionId(objs);
                    //objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");
                    //****************************************

                    //************************************************


                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                }
                CalendarExtender1.StartDate = DateTime.Now.AddDays(1);
            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

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
            //Student_Bifurcation_RequestSynWithErp
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
            //if (ddl_center.SelectedIndex > 0)
            //{
            //    objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            //}
            //else
            //{
            //    objClsSec.Center_Id = 0;
            //}
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

            //if (ddlClass.SelectedIndex > 0)
            //    objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());  
            //else
            //    objClsSec.Class_Id = Class_Id;
            if (ddlterm.SelectedIndex > 0)
                objClsSec.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            else
                objClsSec.TermGroupID = 0;

            //if (ViewState["dtDetails"] == null)
            //{
            dtsub = (DataTable)objClsSec.Student_Bifurcation_UndertakingNotRecieve(objClsSec);
            //}
            //else
            //{
            //    dtsub = (DataTable)ViewState["dtDetails"];
            //}



            if (dtsub.Rows.Count > 0)
            {

                //var filteredRows = dtsub.AsEnumerable()
                //                       .Where(row => row.Field<string>("Acknowledgement") == "No" && row.Field<string>("EmailSent") == "Yes");

                //if (filteredRows.Any())
                //{
                //dtsub = filteredRows.CopyToDataTable();
                tdSearch.Visible = true;
                //trbtnsyn.Visible = true;
                //gv_details.DataSource = dtsub;
                //gv_details.DataBind();

                //ViewState["dtDetails"] = dtsub;
                btns.Visible = true;
                lblGridStatus.Text = "";
                //}
                //else
                //{
                //    tdSearch.Visible = false;
                //    gv_details.DataSource = null;
                //    gv_details.DataBind();
                //    btns.Visible = false;
                //    lblGridStatus.Text = "No Record Found!";
                //}


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

            BLLStudent_Conditionally_Promoted_Request objCen = new BLLStudent_Conditionally_Promoted_Request();
            if (ddlterm.SelectedValue == "0")
            {
                objCen.TermGroupID = 0;
            }
            else
            {
                objCen.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            }


            if (Region_Id != 0)
            {
                objCen.Region_Id = Region_Id;
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }


            DataTable dt = new DataTable();
            dt = objCen.GetCenterFromRegionBifurcationProces(objCen);
            //objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");


            if (dt.Rows.Count > 0)
            {
                gv_details.DataSource = dt;
                gv_details.DataBind();
            }
            else
            {
                dt = objCen.GetCenterFromRegionBifurcationProces_NotFound(objCen);
                gv_details.DataSource = dt;
                gv_details.DataBind();
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
                //ViewState["dtDetails"] = null;
                gv_details.DataSource = null;
                gv_details.DataBind();
                btns.Visible = false;
            }
            //if (ddlSession.SelectedIndex > 0 && ddl_region.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            //{
            //    ViewState["dtDetails"] = null;
            //    BindGrid();
            //}
            //else
            //{
            //    ImpromptuHelper.ShowPrompt("Please Select Region,Center and Session!");
            //}

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

    protected void loadClass()
    {
        try
        {
            // BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            // int center = Convert.ToInt32(ddl_center.SelectedValue);
            BLLClass objCS = new BLLClass();
            objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            dt = objCS.ClassFetch(objCS);
            DataTable filteredDt = dt.Clone();

            // Apply the filter condition and copy the rows to the new DataTable for class ID 12
            foreach (DataRow row in dt.Rows)
            {
                int classId = row.Field<int>("Class_Id");
                if (classId == 12)
                {
                    filteredDt.ImportRow(row);
                }
            }

            // Clear existing items in ddlClass
            //ddlClass.Items.Clear();

            // Add class ID 12 to ddlClass without a default "Select All" option
            foreach (DataRow row in filteredDt.Rows)
            {
                string classId = row["Class_Id"].ToString();
                string className = row["Class_Name"].ToString();
                //ddlClass.Items.Add(new ListItem(className, classId));
            }

            BLLSection_Subject objs = new BLLSection_Subject();
            objs.Org_Id = Convert.ToInt32(Session["moID"].ToString());
            //objs.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);

            //DataTable dt1 = objs.Evaluation_Criteria_TypeBySectionId(objs);
            //objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");
            //ViewState["dtDetails"] = null;
            //gv_details.DataSource = null;
            //gv_details.DataBind();



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
            
            if (ddlterm.SelectedValue.ToString() == "0")
            {
                //ImpromptuHelper.ShowPromptGeneric("Please select Term", 0);
                gv_details.DataSource = null;
                gv_details.DataBind();
                return;
            }
            else
            {
                loadCenter();
            }


            if (ddl_region.SelectedItem.Text == "Select")
            {

                //ddl_center.SelectedIndex = 0;
                //ddlSession.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();
                btns.Visible = false;

            }
            // BindGrid();
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "validate();", true);
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
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    ResetFilter();
    //    ApplyFilter(1);
    //}

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

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlterm.SelectedIndex > 0)
        {
            //ViewState["dtDetails"] = null;
            //ResetFilter();
            //ApplyFilter(4);
            //BindGrid();
        }
        else
        {
            ResetFilter();
        }

    }



    protected void btnbifuration_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gv_details.Rows)
        {
            Boolean status = Convert.ToBoolean(row.Cells[4].Text);
            if (status == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewBifurcationcenterModal();", true);
                return;
            }
            else
            {
                Save();
            }
        }
    }
    public void Save()
    {
        try
        {

            if (ddlterm.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Term", 0);
                return;
            }
            if (ddl_region.SelectedValue.ToString() == "0")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Region", 0);
                return;
            }
            if (text_date.Text.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Date", 0);
                return;
            }

            bool isAnyRowChecked = false;

            foreach (GridViewRow row in gv_details.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkSelect");

                if (chkRow.Checked)
                {
                    isAnyRowChecked = true;
                }
            }
            if (!isAnyRowChecked)
            {
                // At least one row should be checked, show error message
                // You can use a label or display a message in another way
                //lblError.Text = "Please check at least one row.";
                //return;
                ImpromptuHelper.ShowPromptGeneric("Please check at least one center", 0);
                return;
            }



            List<BLLStudent_Conditionally_Promoted_Request> centerDataList = new List<BLLStudent_Conditionally_Promoted_Request>();
            BLLStudent_Conditionally_Promoted_Request objb = new BLLStudent_Conditionally_Promoted_Request();
            //DataTable dtsub = new DataTable();
            DataTable dtr = new DataTable();
            int sessionid = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            int Termid = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            int Regionid = Convert.ToInt32(ddl_region.SelectedValue.ToString());


            string dateFormat = "M/d/yyyy";
            DateTime BifurcationProcessDat = DateTime.ParseExact(text_date.Text, dateFormat, CultureInfo.InvariantCulture);
            //DateTime BifurcationProcessDat = Convert.ToDateTime(text_date.Text);




            int createdby = Convert.ToInt32(Session["ContactID"].ToString());
            //**********************************************************
            List<GridViewRow> allRows = gv_details.Rows.OfType<GridViewRow>().ToList();
            foreach (GridViewRow row in allRows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                //if (chkSelect != null)
                //{
                //    bool isChecked = chkSelect.Checked;
                //    // Perform operations based on the checked state
                //    // isChecked will be true if the checkbox is checked, false otherwise
                //}

                bool isChecked = chkSelect.Checked;


                int Center_ID = int.Parse(row.Cells[1].Text);
                string CenterName = row.Cells[2].Text;
                Boolean isprocessedstatus = Convert.ToBoolean(row.Cells[5].Text);

                BLLStudent_Conditionally_Promoted_Request objcenter = new BLLStudent_Conditionally_Promoted_Request
                {
                    Session_Id = sessionid,
                    TermGroupID = Termid,
                    Region_Id = Regionid,
                    //BifurcationProcessDate =Convert.ToDateTime(formattedDate),
                    BifurcationProcessDate = BifurcationProcessDat,
                    isActive = isChecked,
                    Center_Id = Center_ID,
                    Center_Name = CenterName,
                    CreatedBy = createdby,
                };

                //This check defines if inserted record is processed by nighly job than this flag is true and all the records with true flag will not
                //become a part of any update or insert
                if (isprocessedstatus != true)
                {
                    centerDataList.Add(objcenter);

                    if (centerDataList.Count > 0)
                    {
                        dtr = objcenter.Bifuration_Process_Setup_Add(objcenter);
                    }
                }


            }
            //BindGrid();
            //ImpromptuHelper.ShowPrompt(dtsub);
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
            //return;
        }
        //BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            CheckBox chkAllselect = (CheckBox)e.Row.FindControl("chkSelect");
            bool chkstatus = Convert.ToBoolean(chkAllselect.ValidationGroup);
            Boolean isprocessedstatus = Convert.ToBoolean(e.Row.Cells[5].Text);
            if (isprocessedstatus == true)
            {
                chkAllselect.Enabled = false;
            }
            else
            {
                chkAllselect.Enabled = true;
            }
            if (chkstatus == true)
            {
                chkAllselect.Checked = true;
            }
            else
            {
                chkAllselect.Checked = false;

            }

        }
    }


    protected void bindTermGroupList()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlterm, "TermGroup_Id", "Type");
            //if (dt.Rows.Count > 0)
            //{
            //    DateTime date = DateTime.Now;
            //    if (date.Month >= 3 && date.Month <= 7)
            //        ddlterm.SelectedValue = "2";
            //    else
            //        ddlterm.SelectedValue = "1";
            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void ddlterm_SelectedIndexChanged1(object sender, EventArgs e)
    {


        if (ddlterm.SelectedValue.ToString() == "0")
        {
            //ImpromptuHelper.ShowPromptGeneric("Please select Term", 0);
            gv_details.DataSource = null;
            gv_details.DataBind();
            return;
        }
        else
        {
            loadCenter();
        }


        //loadCenter();



        //System.Text.StringBuilder selectedCenters = new System.Text.StringBuilder();
        //int count = 0;

        //// Begin the unordered list
        //selectedCenters.Append("<ul style='list-style-type:disc; padding-left:20px;'>");

        //foreach (GridViewRow row in gv_details.Rows)
        //{
        //    CheckBox chkRow = (CheckBox)row.FindControl("chkSelect");
        //    if (chkRow != null && chkRow.Checked)
        //    {
        //        string centerName = row.Cells[2].Text;
        //        if (centerName == "&nbsp;")
        //        {
        //            centerName = string.Empty;
        //        }

        //        if (!string.IsNullOrEmpty(centerName))
        //        {
        //            selectedCenters.Append("<li>").Append(centerName).Append("</li>");
        //            count++;
        //        }
        //    }
        //}


        //selectedCenters.Append("</ul>");

        //if (count > 0)
        //{
        //    lblbifcentre.Text = selectedCenters.ToString();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ViewRejectionModal();", true);

        //}
        //else
        //{
        //    lblbifcentre.Text = "No centers selected.";
        //}
    }



    protected void btnproceed_Click(object sender, EventArgs e)
    {
        Save();
    }
}