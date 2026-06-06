using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
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
                lblExportCompilation.Text = string.Empty;
                if (Session["ContactID"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }
                Title = "Result Compilation Status";
                TrDhCampus.Visible = false;
                TrDhRegion.Visible = false;
                if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 5)//Head Office
                {
                }
                else
                    BindCompletionDataForCurrentUser();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }

    /// <summary>Same rule as former term dropdown: Mar–Jul → Second Term (2), else First Term (1).</summary>
    private static int GetEffectiveTermGroupId()
    {
        DateTime date = DateTime.Now;
        if (date.Month >= 3 && date.Month <= 7)
            return 2;
        return 1;
    }

    private void BindCompletionDataForCurrentUser()
    {
        try
        {
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
            objClsSec.TermGroup_Id = GetEffectiveTermGroupId();
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
            objClsSec.TermGroup_Id = GetEffectiveTermGroupId();
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
            objClsSec.TermGroup_Id = GetEffectiveTermGroupId();
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

    private const string SpSuccessfulCompilation = "Successful_Compilation_Aims";
    private const string SpUnsuccessfulCompilation = "Un_Successful_Compilation_Aims";

    protected void btnExportSuccessfulCompilation_Click(object sender, EventArgs e)
    {
        ExportCompilationProcedureToExcel(SpSuccessfulCompilation, "Successful_Compilation_Aims");
    }

    protected void btnExportUnsuccessfulCompilation_Click(object sender, EventArgs e)
    {
        ExportCompilationProcedureToExcel(SpUnsuccessfulCompilation, "Un_Successful_Compilation_Aims");
    }

    private void ExportCompilationProcedureToExcel(string procedureName, string fileNameBase)
    {
        lblExportCompilation.Text = string.Empty;
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        }

        if (!string.Equals(procedureName, SpSuccessfulCompilation, StringComparison.Ordinal)
            && !string.Equals(procedureName, SpUnsuccessfulCompilation, StringComparison.Ordinal))
        {
            lblExportCompilation.Text = "Invalid export.";
            return;
        }

        try
        {
            var dal = new DALBase();
            DataTable dt = dal.sqlcmdFetch(procedureName);
            if (dt == null || dt.Rows.Count == 0)
            {
                lblExportCompilation.Text = "No rows returned from " + procedureName + ".";
                return;
            }

            string safe = SanitizeExcelFileName(fileNameBase);
            WriteHtmlExcelDownload(dt, safe + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".xls");
        }
        catch (Exception ex)
        {
            lblExportCompilation.Text = HttpUtility.HtmlEncode(ex.Message);
        }
    }

    private static string SanitizeExcelFileName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return "export";
        var sb = new StringBuilder(name.Length);
        foreach (char c in name)
        {
            if (char.IsLetterOrDigit(c) || c == '_' || c == '-')
                sb.Append(c);
            else
                sb.Append('_');
        }
        return sb.Length > 0 ? sb.ToString() : "export";
    }

    private void WriteHtmlExcelDownload(DataTable dt, string fileName)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = Encoding.UTF8;
        Response.Charset = "utf-8";
        Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");

        var sb = new StringBuilder(16384);
        sb.Append("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /></head><body><table border='1' cellspacing='0' cellpadding='4'>");

        sb.Append("<tr style='font-weight:bold;background-color:#f0f0f0;'>");
        foreach (DataColumn col in dt.Columns)
        {
            sb.Append("<th>").Append(HttpUtility.HtmlEncode(col.ColumnName)).Append("</th>");
        }
        sb.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            sb.Append("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                object v = row[col];
                string text = v == null || v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture);
                sb.Append("<td>").Append(HttpUtility.HtmlEncode(text)).Append("</td>");
            }
            sb.Append("</tr>");
        }

        sb.Append("</table></body></html>");
        Response.Write(sb.ToString());
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

}