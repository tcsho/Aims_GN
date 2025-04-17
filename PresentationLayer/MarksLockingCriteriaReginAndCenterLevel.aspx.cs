using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class PresentationLayer_MarksLockingCriteriaReginAndCenterLevel : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    static DataTable dd = new DataTable();


    BLLMarksLockingCriteria obj = new BLLMarksLockingCriteria();

    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        if (!IsPostBack)
        {
            try
            {
                FillActiveSessions();
                FillTermList();
                FillMLCTypes();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void BindReGrid()
    {
        try
        {
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void FillMLCTypes()
    {

        try
        {

            DataTable dt = new DataTable();
            dt = (DataTable)obj.MarksLockingCriteriaTypesFetch(obj);
            objBase.FillDropDown(dt, ddlType, "MLC_Type_Id", "MLC_Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void FillTermList()
    {

        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
            ddlTerm.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["chkSelect"] = "check";
        BindReGrid();
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindReGrid();
    }

    void chkTestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Data"] = null;
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
    protected void btnAssignCenters_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Session_Id"] = ddlSession.SelectedValue;
            Session["Session_Name"] = ddlSession.SelectedItem.Text;
            Session["Type_Id"] = ddlType.SelectedValue;
            Response.Redirect("~/PresentationLayer/TCS/AdmTestAssignCenters.aspx", false);
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
            int k = 0;
            obj.MLCri_Id = Convert.ToInt32(ViewState["MLCri_Id"]);
            obj.LockingDate = Convert.ToDateTime(txtTestName.Text);
            k = obj.MarksLockingCriteriaUpdate(obj);
            ViewState["Data"] = null;
            BindGrid();
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Update Successfull");
            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPrompt("Update UnSuccessfull");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        btnCancel_Click(this, EventArgs.Empty);
    }
    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";

            if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlType.SelectedIndex > 0)
            {
                ViewState["Mode"] = "Add";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Class");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteTest_Click(object sender, EventArgs e)
    {

    }
    protected void BindGrid()
    {
        try
        {
            gvLocking.DataSource = null;
            gvLocking.DataBind();
            DataTable dt = new DataTable();
            if (ddlType.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlSession.SelectedIndex > 0)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.MCL_Type_Id = Convert.ToInt32(ddlType.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                btnAddTest.Visible = false;
                if (ViewState["Data"] == null)
                {
                    dt = obj.MarksLockingCriteriaFetch(obj);
                    ViewState["Data"] = dt;
                }
                else
                {
                    dt = (DataTable)ViewState["Data"];
                }
            }

            if (dt.Rows.Count > 0)
            {
                gvLocking.DataSource = dt;
                dd = dt;
                gvLocking.DataBind();
            }
            else
            {
                gvLocking.DataSource = null;
                gvLocking.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvLocking.Rows.Count > 0)
            {
                gvLocking.UseAccessibleHeader = false;
                gvLocking.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
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
            txtTestName.TextMode = TextBoxMode.DateTimeLocal;
            txtTestName.Attributes["min"]=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            ViewState["Mode"] = "Edit";
            LinkButton btnEdit = (LinkButton)(sender);
            obj.MLCri_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["MLCri_Id"] = obj.MLCri_Id;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvLocking.SelectedIndex = gvr.RowIndex;
            txtTestName.Text = gvr.Cells[1].Text;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        ImageButton btn = (ImageButton)sender;
        DateTime date = Convert.ToDateTime(btn.CommandArgument);

        GridViewRow grv = (GridViewRow)btn.NamingContainer;
        CheckBox cb = null;
        date = Convert.ToDateTime(grv.Cells[4].Text);
        foreach (GridViewRow gvRow in gvLocking.Rows)
        {
            int _index = gvRow.RowIndex;
            cb = (CheckBox)gvRow.FindControl("chkSelect");
            if (cb.Checked)
            {
                try
                {
                    int k = 0;
                    int id = Convert.ToInt32(gvRow.Cells[0].Text.ToString());
                    obj.MLCri_Id = id;
                    obj.LockingDate = date;
                    k = obj.MarksLockingCriteriaUpdate(obj);
                    if (k == 1)
                    {
                        ImpromptuHelper.ShowPrompt("Update Successfull");
                    }
                    else if (k == 2)
                    {
                        ImpromptuHelper.ShowPrompt("Update UnSuccessfull");
                    }
                }
                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                }
                cb.Checked = false;
            }
        }
        ViewState["Data"] = null;
        BindGrid();
    }
}
