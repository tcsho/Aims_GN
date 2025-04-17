using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_IssuanceDate : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLIssuanceDate bllIssuanceDate = new BLLIssuanceDate();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            ResultIssue.Visible = false;
            

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (IsPostBack) return;
        {
            try
            {

                DALBase objBase = new DALBase();
                FillSessions();
                ddlSession.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }

    private void BindIssuanceDateGrid()
    {
        try
        {
            bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            gv_IssuanceDate.DataSource = null;
            gv_IssuanceDate.DataBind();
            var dt = bllIssuanceDate.GetListofPromotedRequestDate(bllIssuanceDate.Session_Id);
            gv_IssuanceDate.DataSource = dt;
            gv_IssuanceDate.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void FillSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            objBase.FillDropDown(dt, ddl_Session, "Session_ID", "Description");
            foreach (DataRow r in dt.Rows)
            {
              
                ddlSession.SelectedValue = r["Session_Id"].ToString();
                ddl_Session.SelectedValue = r["Session_Id"].ToString();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvIssuanceDate_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_IssuanceDate.Rows.Count > 0)
            {
                gv_IssuanceDate.UseAccessibleHeader = false;
                gv_IssuanceDate.HeaderRow.TableSection = TableRowSection.TableHeader;

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

   public void AddIssuanceDate(object sender, EventArgs e)
    {
        try
        {
            var button = (Button)(sender);
            if (button.Text == "Add")
            {
                bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.Text);
                bllIssuanceDate.DateFrom = Convert.ToDateTime(txtFrmDate.Text);
                bllIssuanceDate.DateTo = Convert.ToDateTime(txtToDate.Text);

 

                var k = bllIssuanceDate.AddPromotionalReqDate(bllIssuanceDate);

 

                if (k > 0)
                {

 

                    BindIssuanceDateGrid();
                    ResultIssue.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record added successfuly!");
                    return;
                }
                else
                     if (k == 0)
                {
                    BindIssuanceDateGrid();
                    ResultIssue.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record updated successfuly!");
                    return;
                }
            }
            else
            {
                bllIssuanceDate.SCPR_ID = Convert.ToInt32(Session["updateId"]);
                bllIssuanceDate.Session_Id = Convert.ToInt32(ddlSession.Text);
                bllIssuanceDate.DateFrom = Convert.ToDateTime(txtFrmDate.Text);
                bllIssuanceDate.DateTo = Convert.ToDateTime(txtToDate.Text);

 

                var k = bllIssuanceDate.UpdatePromotionalReqDate(bllIssuanceDate);
                if (k == 0)
                {
                    BindIssuanceDateGrid();
                    ResultIssue.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                    ImpromptuHelper.ShowPrompt("Record updated successfuly!");
                    return;
                }
            }

 

            //upModal.Update();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

 

    }

    // popup model for form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ResultIssue.Visible = true;
        var btn = (Button)sender;
        lblModalTitle.Text = "Add Issuance Date";
        if (btn.Text == "Update")
        {
            var argument = ((Button)sender).CommandArgument;
            string[] words = argument.Split(';');
            DateTime fdate = DateTime.Parse(words[1]);
            DateTime tdate = DateTime.Parse(words[2]);
            Session["updateId"] = words[0];
            if (ddl_Session.Items.Count > 1)
            {
                ddl_Session.SelectedValue = words[3];
            }
            else
            {
                ddl_Session.SelectedIndex = 0;
            }
            txtFrmDate.Text = fdate.ToString("yyyy-MM-dd");
            txtToDate.Text = tdate.ToString("yyyy-MM-dd");
            btnAddIssuanceDate.Text = "Update";
        }
        else
        {
            btnAddIssuanceDate.Text = "Add";
            txtFrmDate.Text = "";
            txtToDate.Text = "";
            ddl_Session.SelectedIndex = 0;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSession.Text == "0")
        {
            ResultIssue.Visible = false;
        }
        else
        {
            ResultIssue.Visible = true;
            BindIssuanceDateGrid();
        }
    }

}