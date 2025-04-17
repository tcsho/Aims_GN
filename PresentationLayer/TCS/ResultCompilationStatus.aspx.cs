using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_ResultCompilationStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    ddlTermGroup.SelectedValue = "2";
                else
                    ddlTermGroup.SelectedValue = "1";
                if (Session["ContactID"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }
                DataTable dt = new DataTable();
                TrDhCampus.Visible = false;
                TrDhRegion.Visible = false;
                if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 5)//Head Office
                {
                }
                else
                    ddlTermGroup_SelectedIndexChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTermGroup.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please Select a Term");
                return;
            }
            if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 1) // Teacher
            {

                TrDhCampus.Visible = false;
                TrDhRegion.Visible = false;
                BindResultCompletionGrid();
            }

            if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 3)//Campus Officer
            {
                TrDhCampus.Visible = true;
                TrDhRegion.Visible = false;
                BindResultCompletionCenterGrid();
            }
            if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 4)//Regional Officer
            {
                TrDhCampus.Visible = false;
                TrDhRegion.Visible = true;
                SetEmptyGrid(gvRegionResult);
                BindResultCompletionRegionGrid();
            }

            if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 5)//Head Office
            {
                Response.Redirect("~/PresentationLayer/ResultCompilationStatus.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlTermGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTermGroup.SelectedIndex > 0)
            {
                ViewState["dtDetails"] = null;
                Button1_Click(this, EventArgs.Empty);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvRegionResult_PreRender(object sender, EventArgs e)
    {
        try
        {
            GridHeaderSetting(gvRegionResult);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvResultCompletion_PreRender(object sender, EventArgs e)
    {
        try
        {
            GridHeaderSetting(gvResultCompletion);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvResultCompletion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            HtmlTableRow rwGP = (HtmlTableRow)e.Row.FindControl("trGP");
            HtmlTableRow rwECM = (HtmlTableRow)e.Row.FindControl("trECM");
            HtmlTableRow rwACS = (HtmlTableRow)e.Row.FindControl("trACS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (e.Row.Cells[1].Text == "0")
                    {
                        rwGP.Visible = false;

                    }
                    else
                    {
                        rwGP.Visible = true;
                    }


                    if (e.Row.Cells[2].Text == "0")
                    {
                        rwECM.Visible = false;
                    }
                    else
                    {
                        rwECM.Visible = true;
                    }


                    if (e.Row.Cells[3].Text == "0")
                    {
                        rwACS.Visible = false;
                    }
                    else
                    {
                        rwACS.Visible = true;
                    }

                }
                catch (Exception ex)
                {

                    Session["error"] = ex.Message;
                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
                }

            }

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void GridHeaderSetting(GridView _gd)
    {

        if (_gd.Rows.Count > 0)
        {
            _gd.UseAccessibleHeader = false;
            _gd.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
    }
    protected void gvCenterResult_PreRender(object sender, EventArgs e)
    {
        try
        {
            GridHeaderSetting(gvCenterResult);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindResultCompletionGrid()
    {
        try
        {
            BLLSection objClsSec = new BLLSection();


            DataTable dtsub = new DataTable();

            objClsSec.ClassTeacher_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTermGroup.SelectedValue);
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Section_ClassTeacherResultCompletionStatus(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                Trteacher.Visible = true;
                gvResultCompletion.DataSource = dtsub;
                gvResultCompletion.DataBind();

            }
            else
            {
                lblerror.Text = "Result Compilation Status is only available for Class Teachers!";
                gvResultCompletion.DataSource = null;
                gvResultCompletion.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void BindResultCompletionCenterGrid()
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            BLLSection objClsSec = new BLLSection();


            DataTable dtsub = new DataTable();

            objClsSec.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTermGroup.SelectedValue);
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Section_ClassCenterWiseResultCompletionStatus(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                TrDhCampus.Visible = true;
                gvCenterResult.DataSource = dtsub;
                gvCenterResult.DataBind();

            }
            else
            {
                gvCenterResult.DataSource = null;
                gvCenterResult.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void BindResultCompletionRegionGrid()
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            BLLSection objClsSec = new BLLSection();


            DataTable dtsub = new DataTable();

            objClsSec.Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTermGroup.SelectedValue);
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Section_ClassRegionWiseResultCompletionStatus(objClsSec);

            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                TrDhRegion.Visible = true;
                gvRegionResult.DataSource = dtsub;
                gvRegionResult.DataBind();

            }
            else
            {
                gvRegionResult.DataSource = null;
                gvRegionResult.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    private void SetEmptyGrid(GridView gv)
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("Center_Name");
            dt.Columns.Add("Class_Name");
            dt.Columns.Add("Section_Name");
            dt.Columns.Add("StudentCount");
            dt.Columns.Add("NotStarted");
            dt.Columns.Add("InProcess");
            dt.Columns.Add("Completed");



            dt.Rows.Add(dt.NewRow());
            gv.DataSource = dt;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
 
}