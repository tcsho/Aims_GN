using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_CaieStudentGradesRevision : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            NotApplied.Visible = false;
            btnSaveDateApplied.Visible = false;
            textArea.Visible = false;
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
                // ======== Page Access Settings ========================//
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //  ====== End Page Access settings ======================//
                FillSessions();
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


    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvTest.Rows.Count > 0)
            {
                gvTest.UseAccessibleHeader = false;
                gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void search_Click(object sender, EventArgs e)
    {
        try
        {
            CaieStudentGradeRevision grade = new CaieStudentGradeRevision();
            BindGrid();
            var gradelevel = ddlGradeLevel.Text;
            int seriesId = gradelevel == "GCE O Level" ? 1 : 2;
            DataTable comment = grade.BindComment(Convert.ToInt32(txtRollNumber.Text), seriesId, Convert.ToInt32(ddlSession.Text));
            
            if (comment.Rows.Count == 1)
            {
                DataRow row = comment.Rows[0];
                txtCommentId.Text = row["Id"].ToString();
                txtareaComments.InnerText = row["Comments"].ToString();
            }
            else{
                txtCommentId.Text = "";
                txtareaComments.InnerText = "";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public void BindGrid()
    {
        var grade = new CaieStudentGradeRevision
        {
            RollNumber = Convert.ToInt32(txtRollNumber.Text),
            SessionId = Convert.ToInt32(ddlSession.Text),
            GradeLevel = ddlGradeLevel.Text
        };
        gvTest.DataSource = null;
        gvTest.DataBind();
        var dt = grade.GetStudentGrade(grade);
        if (dt.Rows.Count > 0)
        {
            lblHeader.Text = "Result";
            btnSaveDateApplied.Visible = true;
            textArea.Visible = true;
        }
        else
        {
            lblHeader.Text = "No record found.";
        }
        gvTest.DataSource = dt;
        gvTest.DataBind();
        NotApplied.Visible = true;
    }
    protected void FillSessions()
    {
        try
        {
            var objBll = new BLLSession();
            var dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            foreach (DataRow r in dt.Rows)
            {
                if (r["Status_Id"].ToString() != "1") continue;
                ddlSession.SelectedValue = r["Session_Id"].ToString();
                break;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnSaveDateApplied_Click(object sender, EventArgs e)
    {
        var grade = new CaieStudentGradeRevision();
        var k = 0;
        foreach (GridViewRow row in gvTest.Rows)
        {
            var tb = (TextBox)row.FindControl("txtResult");
            grade.PuId = Convert.ToInt32(row.Cells[1].Text);
            grade.Result = tb.Text;
            Session["student_Id"] = row.Cells[9].Text;
            Session["Series_Id"] = row.Cells[10].Text;
            k = grade.UpdateCaieStudentResultGrade(grade);
        }
        grade.SessionId = Convert.ToInt32(ddlSession.Text);
        grade.Comments = txtareaComments.InnerText;
        grade.StudentId = Convert.ToInt32(Session["student_Id"]);
        grade.SeriesId = Convert.ToInt32(Session["Series_Id"]);
        if (txtCommentId.Text == "")
        {
            grade.SaveComments(grade);
            txtCommentId.Text = Convert.ToString( grade.GetLastAddedCommentId());
        }
        else
        {
            grade.Id = Convert.ToInt32(txtCommentId.Text);
            grade.UpdateComments(grade);
        }
        if (k != 1) return;
        BindGrid();
        ImpromptuHelper.ShowPrompt("Student Grades Updated sucessfuly!");

    }
}