using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Data;
public partial class PresentationLayer_TCS_AdmTestAssignCenters : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                lblDesc.Text = Session["Session_Name"].ToString();
                lblClassDesc.Text = Session["ClassDesc"].ToString();
                ViewState["MainOrgId"] = 1;
                ViewState["tMood"] = "";
                FillTestType();
                BindCenterGrid();
                ddlTestType.SelectedValue = Session["TestType_Id"].ToString();
                loadRegions();

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
            objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");
            if (ViewState["RegionId"] != null && Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                ddlRegion.SelectedValue = ViewState["RegionId"].ToString();
                ddlRegion.Enabled = false;
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
            if (ViewState["RegionId"] != null && Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                objCen.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");

            if (ViewState["CenterId"] != null && Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            {
                ddlCenter.SelectedValue = ViewState["CenterId"].ToString();
                ddlCenter.Enabled = false;

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegion.SelectedValue == "0")
            {
                BindCenterGrid();
                return;
            }
            ResetFilter();
            ApplyFilter(1, Convert.ToInt32(ddlRegion.SelectedValue));
            loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCenter.SelectedValue == "0")
            {
                BindCenterGrid();
                if (ddlRegion.SelectedIndex > 0)
                {
                    ResetFilter();
                    ApplyFilter(1, Convert.ToInt32(ddlRegion.SelectedValue));
                }
                return;
            }
            ResetFilter();
            ApplyFilter(2, Convert.ToInt32(ddlCenter.SelectedValue));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillTestType()
    {
        try
        {
            BLLAdmTest obj = new BLLAdmTest();
            DataTable dt = obj.AdmTestFetchTestType(obj);

            obj.Class_Id = Convert.ToInt32(Session["Class_Id"].ToString());
            obj.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            dt = obj.AdmTestFetchTestType(obj);
            if (dt.Rows.Count > 0)
            {
                //filter records with flag==1
                DataView dv = dt.DefaultView;
                string strFilter = "";
                strFilter = " Convert([flag], 'System.String')= '1'";
                dv.RowFilter = strFilter;
                ddlTestType.DataSource = dv.ToTable();
                ddlTestType.DataValueField = "TestType_Id";
                ddlTestType.DataTextField = "Description";
                ddlTestType.DataBind();

                //dt = (DataTable)ViewState["Test"];
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilter(int _FilterCondition, int value)
    {
        try
        {

            if (ViewState["Centers"] != null)
            {
                DataTable dt = (DataTable)ViewState["Centers"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // Filter Center by Region Id
                        {

                            strFilter = " Convert([Region_Id], 'System.String')=" + value;
                            break;
                        }
                    case 2: // Filter Center by Center Id
                        {

                            strFilter = " Convert([Center_Id], 'System.String')=" + value;
                            break;
                        }
                    case 3: // Filter Center by Center Id
                        {

                            strFilter = " Convert([Assigned], 'System.String')=" + value;
                            break;
                        }
                    case 4: // Filter Center by Center Id
                        {

                            strFilter = " Convert([Assigned], 'System.String')=" + value;
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvCenters.DataSource = dv.ToTable();
                gvCenters.DataBind();

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
            BindCenterGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvCenters_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvCenters.Rows.Count > 0)
            {
                gvCenters.UseAccessibleHeader = false;
                gvCenters.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow r = ((CheckBox)sender).Parent.Parent as GridViewRow;
        CheckBox chkBox = r.FindControl("chkCenter") as CheckBox;
        if (chkBox.Checked)
            r.BackColor = System.Drawing.Color.PaleGoldenrod;
        else
            r.BackColor = System.Drawing.Color.White;
    }
    protected void gvCenters_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvCenters.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("chkCenter");

                    if (mood == "" || mood == "check")
                    {
                        cb.Checked = true;
                        ViewState["tMood"] = "uncheck";
                    }
                    else
                    {
                        cb.Checked = false;
                        ViewState["tMood"] = "check";
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
    protected void BindCenterGrid()
    {
        try
        {
            BLLAdmission_Center_Evaluation_Criteria obj = new BLLAdmission_Center_Evaluation_Criteria();
            obj.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            obj.Class_Id = Convert.ToInt32(Session["Class_Id"].ToString());
            DataTable dt = new DataTable();
            if (ViewState["Centers"] == null)
            {
                dt = obj.Admission_Center_Evaluation_CriteriaSelectAllCenters(obj);
                ViewState["Centers"] = dt;
            }
            else
                dt = (DataTable)ViewState["Centers"];
            if (dt.Rows.Count > 0)
            {
                divFilters.Visible = true;
                gvCenters.DataSource = dt;
                GridTitle.Visible = true;
            }
            else
            {
                divFilters.Visible = false;
                gvCenters.DataSource = null;
                GridTitle.Visible = false;
            }
            gvCenters.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Session"] = Session["Session_Id"];
            Session["Class"] = Session["Class_Id"];
            Session["TestType"] = ddlTestType.SelectedValue;
            Response.Redirect("~/presentationlayer/TCS/AdmTestConfig.aspx", false);
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
            BLLAdmission_Center_Evaluation_Criteria obj = new BLLAdmission_Center_Evaluation_Criteria();
            obj.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            obj.Class_Id = Convert.ToInt32(Session["Class_Id"].ToString());
            obj.TestType_Id = Convert.ToInt32(ddlTestType.SelectedValue);
            int k = -1;
            foreach (GridViewRow r in gvCenters.Rows)
            {
                CheckBox c = (CheckBox)r.FindControl("chkCenter");
                r.BackColor = System.Drawing.Color.PaleGoldenrod;
                if (c.Checked == true)
                {
                    c.Enabled = false;
                    obj.Center_Id = Convert.ToInt32(r.Cells[0].Text);
                    k = obj.Admission_Center_Evaluation_CriteriaAdd(obj);
                }
            }
            if (k == 1)
                ImpromptuHelper.ShowPrompt("Test Configuration applied!");
            ViewState["Centers"] = null;
            BindCenterGrid();
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAssignedCenters_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(3, 1); //All assigned centers have a flag value of 1
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnUnAssignedCenters_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(4, 0); //All assigned centers have a flag value of 1
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlCenter.SelectedIndex = 0;
            ddlRegion.SelectedIndex = 0;
            ResetFilter();
            BindCenterGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}