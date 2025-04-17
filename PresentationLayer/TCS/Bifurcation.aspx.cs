using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_Bifurcation : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
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
                loadRegions();
                FillActiveSessions();
                ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                ViewState["Mode"] = "Expel";
                ViewState["Class"] = null;
                ddlSession_SelectedIndexChanged(this, EventArgs.Empty);

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);

            }
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
    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
            ViewState["Bifurcation"] = null;
            BindBfurcationGrid();
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
            ViewState["Bifurcation"] = null;
            BindBfurcationGrid();

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
            ViewState["Bifurcation"] = null;
            BindBfurcationGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvBifurcation_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvbifurcation.Rows.Count > 0)
            {
                gvbifurcation.UseAccessibleHeader = false;
                gvbifurcation.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvbifurcation.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnOstream_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterBifurcation();
            ApplyFilterBifurcation(1);
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnMStream_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterBifurcation();
            ApplyFilterBifurcation(2);
             
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnBifurcation_Click(object sender, EventArgs e)
    {
        try
        {

            ViewState["Mode"] = "Bifurcation";
            BindBfurcationGrid();
            if (gvbifurcation.Rows.Count == 0)
            {
                tdSearch.Visible = false;
                lblGridStatus.Text = "No data to Display!";
            }
            else
            {
                lblGridStatus.Text = "";
                tdSearch.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindBfurcationGrid()
    {
        try
        {
            DataTable dt = new DataTable();
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            if (ddl_center.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            else
                obj.Center_Id = 0;
            if (ddl_region.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            else
                obj.Region_Id = 0;
            if (ViewState["Bifurcation"] == null)
            {
                dt = obj.Student_Bifurcation(obj);
                ViewState["Bifurcation"] = dt;
            }
            else
                dt = (DataTable)ViewState["Bifurcation"];
            if (dt.Rows.Count == 0)
            {
                lblGridStatus.Text = "No Data to Display!";
                tdSearch.Visible = false;
                gvbifurcation.DataSource = null;
                gvbifurcation.DataBind();
                divBifurcation.Visible = false;
            }
            else
            {
                divBifurcation.Visible = true;
                lblGridStatus.Text = "";
                tdSearch.Visible = true;
                gvbifurcation.DataSource = dt;
                gvbifurcation.DataBind();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnBifurcationStudent_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnEdit = (Button)sender;
            ViewState["Unit_Id"] = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["tMood"] = "edit";
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvbifurcation.SelectedIndex = gvr.RowIndex;

            DropDownList ddlBif = (DropDownList)gvr.FindControl("ddlBifurcation");
            obj.Class_Id = Convert.ToInt32(ddlBif.SelectedValue);
            if (obj.Class_Id == 0)
            {
                ImpromptuHelper.ShowPrompt("Please Select a value");
                return;
            }

            obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
            obj.StudentName = gvr.Cells[1].Text;
            obj.Center_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Region_Id = Convert.ToInt32(gvr.Cells[3].Text);
            obj.Section_Id = Convert.ToInt32(gvr.Cells[4].Text);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            obj.Class_Id = Convert.ToInt32(ddlBif.SelectedValue);
            obj.PromotionStatus = "Bifurcation";

            int k = obj.Student_BifurcationMatricStream(obj);
            if (k == 0)
            {
                ImpromptuHelper.ShowPrompt("Student Promoted to " + ddlBif.SelectedItem.Text);
                EmailAlert(ddlBif);

            }
            else
            {
                ImpromptuHelper.ShowPrompt("Cannot Promote Student " + ddlBif.SelectedItem.Text);
            }







            ViewState["Bifurcation"] = null;
            BindBfurcationGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void EmailAlert(DropDownList ddlBif)
    {




        if (ViewState["Bifurcation"] != null)
        {
            DataTable _dt = (DataTable)ViewState["Bifurcation"];
            DataRow[] foundRows;
            foundRows = _dt.Select("Student_Id = '" + obj.Student_Id.ToString() + "'");

            string reason = foundRows[0]["ResultStatus"].ToString();
            reason = reason.Replace("&amp;#8195;", "&#8195;");
            reason = reason.Replace("&amp;#8201;", "&#8201;");
            reason = reason.Replace("&amp;#8194;", "&#8194;");
            reason = reason.Replace("&lt;br /&gt;", "<br/>");
            reason = reason.Replace("&amp;#10006;", "&#10006;");
            reason = reason.Replace("&amp;#10004;", "&#10004;");

                  string strEmailMsg = "Dear Sir,<br><br>";
                  strEmailMsg += "<b>Date : </b>" + String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now) + "<br/><br/>";
                  strEmailMsg += "<b>Campus : </b>" + foundRows[0]["Center_Name"] + "<br/><br/><br/>";

                strEmailMsg += "<b>" + obj.Student_Id.ToString() + "-"+ obj.StudentName + "</b>";
                strEmailMsg += " of <b>"+foundRows[0]["Class_Name"].ToString() + "-" + foundRows[0]["Section_Name"].ToString() + "</b> has been Bifurcated to " + ddlBif.SelectedItem.Text + ".";

            strEmailMsg += "<br/><br/>He/She fails to meet the promotion criteria in Mid year exams due to following reason(s) <br/><br/> <div>" + reason + "</div>";

            strEmailMsg += "<br><br><b>Note:</b><i>This is a system generated message. Please do not reply to this message.</i>";
            BLLSendEmail objEmail = new BLLSendEmail();

            objEmail.SendEmail(2, "Student Bifurcation Alert", strEmailMsg, "Bifurcation from Class 8");
        }


    }
    protected void btnAllbifurcation_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterBifurcation();
            ApplyFilterBifurcation(3);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilterBifurcation(int _FilterCondition)
    {
        try
        {

            if (ViewState["Bifurcation"] != null)
            {
                DataTable dt = (DataTable)ViewState["Bifurcation"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // 9 Olevels Stream
                        {

                            strFilter = " Convert([ToClass_Id], 'System.String')='13'";
                            break;
                        }

                    case 2: // 9 Matric Stream
                        {
                            strFilter = " Convert([ToClass_Id], 'System.String')='17'";
                            break;
                        }

                    case 3: // All
                        {
                            //strFilter = " Convert([ToClass_Id], 'System.String')='1'";
                            break;
                        }
                    case 4: // Pending
                        {
                            strFilter = " Convert([ToClass_Id], 'System.String') in (0,12) ";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvbifurcation.DataSource = dv;
                gvbifurcation.DataBind();
                gvbifurcation.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilterBifurcation()
    {
        try
        {
            //       ViewState["dtDetails"] = null;
            BindBfurcationGrid();
            gvbifurcation.SelectedIndex = -1;
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
            string url = "../TCS";
            Button btnEdit = (Button)sender;
           
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvbifurcation.SelectedIndex = gvr.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Class_Id = 12;
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Section_Id= Convert.ToInt32(gvr.Cells[4].Text);
            obj.TermGroup_Id = 1; //Students are bifurcated after Midterm 
            obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;
            url =url+ obj.OpenReport(obj);
            if (!String.IsNullOrEmpty(url))
            {
                //url = "../PresentationLayer/TCS/" + url;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnPending_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterBifurcation();
            ApplyFilterBifurcation(4);
          
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}