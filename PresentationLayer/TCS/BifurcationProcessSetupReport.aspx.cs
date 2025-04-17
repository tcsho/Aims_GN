using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI;
using System.IO;
using System.Configuration;
public partial class PresentationLayer_BifurcationProcessSetupReport : System.Web.UI.Page
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

                if (row["User_Type"].ToString() != "SAdmin")
                {

                }
                //trbtnsyn.Visible = false;
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.but_Export);
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



                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    loadClass();
                    //trButtons.Visible = false;
                    bindTermGroupList();
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    loadClass();
                    //trButtons.Visible = false;
                    bindTermGroupList();
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

            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());


            if (ddlterm.SelectedIndex > 0)
                objClsSec.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            else
                objClsSec.TermGroupID = 0;


            dtsub = (DataTable)objClsSec.Student_Bifurcation_UndertakingNotRecieve(objClsSec);




            if (dtsub.Rows.Count > 0)
            {


                //tdSearch.Visible = true;

                //btns.Visible = true;
                //lblGridStatus.Text = "";



            }
            else
            {
                //tdSearch.Visible = false;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
               // lblGridStatus.Text = "No Record Found!";
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
               //** loadCenter();
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

            objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objCen.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());





            DataTable dt = new DataTable();
            dt = objCen.GetBifurcationProcesReport(objCen);

            if (dt.Rows.Count > 0)
            {
                gv_details.DataSource = dt;
                gv_details.DataBind();

                ViewState["dtDetails"] = dt;
            }
            else
            {
                gv_details.DataSource = null;
                gv_details.DataBind();
                ImpromptuHelper.ShowPromptGeneric("No Data Found", 0);
                return;
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
                //btns.Visible = false;
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


            foreach (DataRow row in filteredDt.Rows)
            {
                string classId = row["Class_Id"].ToString();
                string className = row["Class_Name"].ToString();
                //ddlClass.Items.Add(new ListItem(className, classId));
            }

            BLLSection_Subject objs = new BLLSection_Subject();
            objs.Org_Id = Convert.ToInt32(Session["moID"].ToString());
            //objs.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
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
            // loadCenter();

            if (ddl_region.SelectedItem.Text == "Select")
            {

                //ddl_center.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;

            }
            // BindGrid();
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

                }
                else
                {

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
            ViewState["dtDetails"] = null;
            ResetFilter();
            ApplyFilter(4);
            BindGrid();
        }
        else
        {
            ResetFilter();
        }

    }
    protected void btnbifuration_Click(object sender, EventArgs e)
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
            loadCenter();
        }
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


            //int status = int.Parse(e.Row.Cells[6].Text);
            //if(status==1)
            //{
            //    e.Row.BackColor = System.Drawing.Color.PaleGreen;
            //}

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
            if (dt.Rows.Count > 0)
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    ddlterm.SelectedValue = "2";
                else
                    ddlterm.SelectedValue = "1";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_Export_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Conditionally_Promoted_Request objCen = new BLLStudent_Conditionally_Promoted_Request();
            objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objCen.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.GetBifurcationProcesReport(objCen);

            if (dt.Rows.Count > 0)
            {
                if (dt != null)
                {
                    ExportToSpreadsheet(dt, "Bifurcated");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("There Are No Search Results To Export!");
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void ExportToSpreadsheet(DataTable table, string name)
    {
        System.Web.HttpContext context = HttpContext.Current;
        context.Response.Clear();

        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + "\t");

        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(",", string.Empty) + "\t");
            }

            context.Response.Write(Environment.NewLine);
        }

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename = " + name + ".xls");
        context.Response.Flush();
        context.Response.SuppressContent = true;
        context.ApplicationInstance.CompleteRequest();
    }

}
