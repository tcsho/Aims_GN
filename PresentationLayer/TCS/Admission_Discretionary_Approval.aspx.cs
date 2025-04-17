using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
public partial class PresentationLayer_TCS_Admission_Discretionary_Approval : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLAdmStudentDiscretionalRequest objreq = new BLLAdmStudentDiscretionalRequest();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                loadRegions();
                if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level
                {
                    ddl_center.Enabled = true;
                    ddl_region.Enabled = true;
                     
                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO Level
                {
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    ddl_region_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 4)//CO Level
                {
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = false;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    ddl_region_SelectedIndexChanged(this, EventArgs.Empty);
                    ddl_center.SelectedValue = Session["cId"].ToString();
                    ddl_center_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 10)// NO level 
                {
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    ddl_region_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 5)//Teacher Level only for school heads
                {
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = false;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    ddl_region_SelectedIndexChanged(this, EventArgs.Empty);
                    ddl_center.SelectedValue = Session["cId"].ToString();
                    ddl_center_SelectedIndexChanged(this, EventArgs.Empty);

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
            ViewState["MainOrgId"] = 1;
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            resetddl_center();
            resetddlClass();
            ResetFilter();
            if (ddl_region.SelectedIndex > 0)
            {
                loadCenter();
                ApplyFilter(3, ddl_region.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGrid()
    {
        try
        {
            objreq.NH_Approval_By = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = new DataTable();
            if (ViewState["Approval"] == null)
            {
                dt = objreq.AdmStudentDiscretionalRequestFetch(objreq);
                ViewState["Approval"] = dt;
            }
            else
                dt = (DataTable)ViewState["Approval"];

            gvApproval.DataSource = dt;
            gvApproval.DataBind();

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
            if (Session["UserLevel_Id"].ToString() == "10") // for Network Heads only 
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            }
            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) >= 2 && Convert.ToInt32(Session["UserLevel_Id"].ToString()) <= 5)
                //for HO,RO ,CO and standalone school Heads
            {
                BLLCenter objCen = new BLLCenter();

                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

                DataTable dt = new DataTable();
                dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
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
            resetddlClass();
            ResetFilter();
            if (ddl_center.SelectedIndex > 0)
            {
                FillClass();
                ApplyFilter(1, ddl_center.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void resetddlClass()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Class_Id");
        dt.Columns.Add("Class_Name");
        objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
    }
    private void resetddl_center()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Center_Id");
        dt.Columns.Add("Center_Name");
        objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
    }
    protected void ddl_Class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            if (ddlClass.SelectedIndex > 0)
                ApplyFilter(2, ddlClass.SelectedValue);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillClass()
    {
        try
        {
            BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            int center = Convert.ToInt32(ddl_center.SelectedValue);
            dt = obj.Class_CenterFetch(center);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 20).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ApplyFilter(int _FilterCondition, string value)
    {
        try
        {

            if (ViewState["Approval"] != null)
            {
                DataTable dt = (DataTable)ViewState["Approval"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: //Filter by Center_Id 
                        {

                            strFilter = " Convert([Center_Id], 'System.String')='" + value + "'";
                            break;
                        }

                    case 2: // Filter Class_Id 
                        {
                            strFilter = " Convert([Center_Id], 'System.String')='" + ddl_center.SelectedValue + "'";
                            strFilter += " and  Convert([Class_Id], 'System.String')='" + value + "'";
                            break;
                        }
                    case 3: //Filter by Region_Id 
                        {

                            strFilter = " Convert([Region_Id], 'System.String')='" + value + "'";
                            break;
                        }
                }
                dv.RowFilter = strFilter;
                gvApproval.DataSource = dv;
                gvApproval.DataBind();
                gvApproval.SelectedIndex = -1;
                if (gvApproval.Rows.Count > 0)
                    tdSearch.Visible = true;
                else
                    tdSearch.Visible = false;

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
            BindGrid();
            gvApproval.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvApproval_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvApproval.Rows.Count > 0)
            {
                gvApproval.UseAccessibleHeader = false;
                gvApproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvApproval.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            txtNHRemarks.Text = "";
            rblApproval.SelectedIndex = -1;
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvApproval.SelectedIndex = gvr.RowIndex;
            lblReg.Text = gvr.Cells[0].Text;
            lblStdName.Text = gvr.Cells[0].Text + " - " + gvr.Cells[1].Text;
            lblResultDetail.Text = gvr.Cells[5].Text;
            lblHRemarks.Text = gvr.Cells[6].Text;
       
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            objreq.Regisration_Id = Convert.ToInt32(lblReg.Text);
            objreq.Heads_Remarks = lblHRemarks.Text;
            objreq.NH_Approval_By = Convert.ToInt32(Session["ContactID"].ToString());
            objreq.NH_Approval = Convert.ToBoolean(rblApproval.SelectedValue);
            objreq.NH_Remarks = txtNHRemarks.Text;
            int k = objreq.AdmStudentDiscretionalRequestUpdate(objreq);
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Request Submitted");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
                ViewState["Approval"] = null;
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}