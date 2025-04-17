using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
public partial class PresentationLayer_TCS_AdmissionDates : System.Web.UI.Page
{
    BLLEvaluation_Criteria_Type_CUTTOFF obj = new BLLEvaluation_Criteria_Type_CUTTOFF();
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // ======== Page Access Settings ========================//
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

            //====== End Page Access settings ======================//
            if (!IsPostBack)
            {
                FillActiveSessions();
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please select a Session");
                return;
            }
            ddlTerm.Enabled = true;
            ddlTerm.SelectedValue = "0";
            txtFromDate.Text = "";
            pan_Add.Visible = true;
            divList.Visible = true;
            ViewState["AdmSession_Id"] = 0;
            btnAddTest.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvDates.SelectedIndex = gvr.RowIndex;
            ddlTerm.Enabled = false;
            obj.ECT_CUTTOFF_Id = Convert.ToInt32(gvr.Cells[0].Text);
            ddlSession.SelectedValue = gvr.Cells[1].Text;
            ddlTerm.SelectedValue = gvr.Cells[2].Text;
            txtFromDate.Text = gvr.Cells[6].Text;

            obj.Status = 1;
            ViewState["ECT_CUTTOFF_Id"] = obj.ECT_CUTTOFF_Id;
            pan_Add.Visible = true;
            divList.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            pan_Add.Visible = false;
            divList.Visible = true;
            btnAddTest.Visible = true;
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

            if (ddlTerm.SelectedIndex<=0 )
            {
                ImpromptuHelper.ShowPrompt("Please select Term");
                return;
            }
            if (ddlSession.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please select Session");
                return;
            }


            obj.ECT_CUTTOFF_Id = Convert.ToInt32(ViewState["ECT_CUTTOFF_Id"]);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.FromDate = Convert.ToDateTime(txtFromDate.Text);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Status = 1;
            int k = obj.Evaluation_Criteria_Type_CUTTOFFCRUD(obj);
            if (k > 0)
            {
                BindGrid();
                pan_Add.Visible = false;
                divList.Visible = true;
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Record Already Exists for this Session and Term!");
                return;
            }
            btnAddTest.Visible = true;
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
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvDates.SelectedIndex = gvr.RowIndex;

            obj.ECT_CUTTOFF_Id = Convert.ToInt32(gvr.Cells[0].Text);
            obj.Session_Id = Convert.ToInt32(gvr.Cells[1].Text);
            obj.TermGroup_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.FromDate = Convert.ToDateTime(gvr.Cells[6].Text);
            obj.Status = 2;
            int k = obj.Evaluation_Criteria_Type_CUTTOFFCRUD(obj);
            BindGrid();
            pan_Add.Visible = false;
            divList.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSyncStudents_Click(object sender, EventArgs e)
    {
        try
        {

            obj.Evaluation_Criteria_Type_CUTTOFFSyncStudents(obj);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void BindGrid()
    {
        try
        {
            gvDates.DataSource = null;
            gvDates.DataBind();


            if (ddlSession.SelectedIndex > 0)
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            else
                obj.Session_Id = 0;

            DataTable dt = obj.Evaluation_Criteria_Type_CUTTOFFSelectAll(obj);
            if (dt.Rows.Count > 0)
            {
                GridTitle.Visible = true;
                gvDates.DataSource = dt;
                gvDates.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvDates_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvDates.Rows.Count > 0)
            {
                gvDates.UseAccessibleHeader = false;
                gvDates.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
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
            foreach (DataRow r in dt.Rows)
            {
                if (r["Status_Id"].ToString() == "1")
                {
                    ddlSession.SelectedValue = r["Session_Id"].ToString();
                    ddlSession.Enabled = false;

                    break;
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