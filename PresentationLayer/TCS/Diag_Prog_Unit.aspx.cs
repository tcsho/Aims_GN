using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Diagnostics;
using System.Threading;


public partial class PresentationLayer_TCS_Diag_Prog_Unit : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                if (Session["Mode"] != null && Session["Mode"].ToString() == "Back")
                {
                    string c = Session["ClassID"].ToString();
                    string ev = Session["EvaluationID"].ToString();
                    // lblSubject.Text = Session["SubjectName"].ToString();
                    FillSubjectDetails();
                    FillClassSection();
                    ddlClass.SelectedValue = c;
                    BindEvaluation();
                    ddlterm.SelectedValue = ev;
                    list_term_SelectedIndexChanged(this, e);
                    Session["Mode"] = null;
                    pan_New.Visible = false;
                }
                else if (Session["Mode"] == null)
                {
                    pan_New.Visible = false;
                    FillSubjectDetails();
                    FillClassSection();
                    ViewState["tMood"] = "check";
                    ViewState["SortDirection"] = "ASC";
                    ViewState["Unit_Id"] = null;
                }
                //======== Page Access Settings ========================
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

                //====== End Page Access settings ======================
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }

            //if (Session["Mode"]!=null && Session["Mode"].ToString() == "Back")
            //{
            //    ddlClass.SelectedValue = Session["ClassID"].ToString();
            //    ddlterm.SelectedValue = Session["EvaluationID"].ToString();
            //    ViewState["SubjectInfo"] = Session["SubjectInfo"].ToString();
            //    BindGrid();
            //    Session.Abandon();
            //}
        }
    }
    private void FillSubjectDetails()
    {
        try
        {
            int user_id = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = objDPUnit.Diag_Prog_UnitSelectSubjectByUser_Id(user_id);
            if (dt.Rows.Count > 0)
            {

                lblSubject.Text = dt.Rows[0]["Subject_Name"].ToString();
                ViewState["SubjectInfo"] = dt.Rows[0]["Subject_Id"].ToString();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }
    private void FillClassSection()
    {

        try
        {

            objDPUnit.Subject_Id = Convert.ToInt16(ViewState["SubjectInfo"]);
            DataTable dtClass = objDPUnit.Diag_Prog_UnitSelectClassBySubject_Id(objDPUnit);

            objBase.FillDropDown(dtClass, ddlClass, "Class_Id", "Class_Name");
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
            DataTable dtsub = new DataTable();
            objDPUnit.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());
            objDPUnit.Evaluation_Criteria_Id = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            objDPUnit.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"].ToString());
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objDPUnit.Diag_Prog_UnitFetch(objDPUnit);
                ViewState["dtDetails"] = dtsub;
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                UnitView.DataSource = dtsub;
                UnitView.DataBind();
                tdSearch.Visible = true;
                lblSave.Text = "";
            }
            else
            {
                tdSearch.Visible = false;
                lblSave.Text = "No Data to Display";
                UnitView.DataSource = null;
                UnitView.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void UnitView_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (UnitView.Rows.Count > 0)
            {
                UnitView.UseAccessibleHeader = false;
                UnitView.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindEvaluation();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void BindEvaluation()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            ObjECT.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);
            objBase.FillDropDown(dt, ddlterm, "Evaluation_Criteria_Type_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    //Sorting 
    public void UnitView_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dtDetails"];
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }

            dt.DefaultView.Sort = e.SortExpression + " " + sortingDirection;
            UnitView.DataSource = dt;
            UnitView.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    public SortDirection direction
    {
        get
        {
            if (ViewState["directionState"] == null)
            {
                ViewState["directionState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["directionState"];
        }
        set
        {
            ViewState["directionState"] = value;
        }
    }
    protected void UnitView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            UnitView.PageIndex = e.NewPageIndex;
            BindGrid();
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

            ImageButton btndel = (ImageButton)sender;
            objDPUnit.Unit_Id = Convert.ToInt32(btndel.CommandArgument);

            int k = objDPUnit.Diag_Prog_UnitDelete(objDPUnit);
            ViewState["dtDetails"] = null;
            BindGrid();
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
            pan_New.Visible = true;
            ImageButton btnEdit = (ImageButton)sender;
            ViewState["Unit_Id"] = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["tMood"] = "edit";
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            UnitView.SelectedIndex = gvr.RowIndex;
            txtUnitDescription.Text = gvr.Cells[4].Text;
            ViewState["OldPercentage"] = gvr.Cells[5].Text;
            lblPercentage.Text = gvr.Cells[5].Text;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
            txtUnitDescription.Text = "";
            ViewState["tMood"] = "";
            int i = ddlterm.SelectedIndex;
            if (ddlClass.SelectedIndex < 0 || ddlterm.SelectedIndex < 0 || ddlterm.SelectedIndex == 0 || checkPercentage() == true)
            {
                if (ddlClass.SelectedIndex > 0 && (ddlterm.SelectedIndex < 0 || ddlterm.SelectedIndex == 0))
                {
                    ImpromptuHelper.ShowPrompt("Please Select a Term !");
                }
                else if (checkPercentage() == true)
                {
                    ImpromptuHelper.ShowPrompt("Percentage Exceeds the Limit!");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please Select a Class and Term !");
                }

            }
            else if (ddlClass.SelectedIndex > 0 && ddlterm.SelectedIndex > 0)
            {
                pan_New.Visible = true;
                ViewState["tMood"] = "insert";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected bool checkPercentage()
    {
        bool parameter = false;
        try
        {
            
            decimal sum = 0;
            DataTable dt = (DataTable)ViewState["dtDetails"];
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dtRow in dt.Rows)
                {
                    decimal d = Convert.ToDecimal(dtRow["Percentage"].ToString());
                    if (d != 0)
                    {

                        //decimal s = Convert.ToDecimal(dtRow["Percentage"].ToString());
                        sum = sum + d;
                        if (sum > 100 || sum == 100)
                        {
                            parameter = true;

                        }

                    }
                    else
                    {
                        parameter = false;
                        break;
                    }
                }
                ViewState["TotalPercentage"] = sum;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        return parameter;
    }
    protected void but_save_Click(object sender, EventArgs e)
    { 

        try
        {
            int k = -1;
            objDPUnit.Unit_Description = txtUnitDescription.Text;
            objDPUnit.Evaluation_Criteria_Id = Convert.ToInt32(ddlterm.SelectedValue.ToString());
            DataTable dt = new DataTable();
            if (ViewState["tMood"].ToString() == "insert")
            {
                objDPUnit.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"].ToString());
                objDPUnit.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objDPUnit.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());

                k = objDPUnit.Diag_Prog_UnitAdd(objDPUnit);

            }
            else if (ViewState["tMood"].ToString() == "edit")
            {
                objDPUnit.Percentage = Convert.ToDecimal(lblPercentage.Text);
                objDPUnit.Unit_Id = Convert.ToInt32(ViewState["Unit_Id"].ToString());
                objDPUnit.ModifiedBy = Convert.ToInt32(Session["ContactID"]);
                k = objDPUnit.Diag_Prog_UnitUpdate(objDPUnit);
            }


            if (k == 0)
            {
                ViewState["dtDetails"] = null;
                BindGrid();
                pan_New.Visible = false;
                ImpromptuHelper.ShowPrompt("Record Saved Successfully !");

            }

            else
            {
                pan_New.Visible = false;
                ImpromptuHelper.ShowPrompt("Record Already Exists!");
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "none");
            UnitView.SelectedRowStyle.Reset();
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
            ImageButton btnAdd = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btnAdd.NamingContainer;
            UnitView.SelectedIndex = gvr.RowIndex;
            Session["UnitDescription"] = gvr.Cells[4].Text;
            Session["Per"] = gvr.Cells[5].Text;
            Session["UnitId"] = gvr.Cells[0].Text;
            Session["SubjectName"] = lblSubject.Text;
            Session["ClassName"] = ddlClass.SelectedItem.ToString();
            Session["ClassID"] = ddlClass.SelectedValue;
            Session["EvaluationID"] = ddlterm.SelectedValue;
            Session["SubjectInfo"] = ViewState["SubjectInfo"];
            bool d = checkPercentage();
            string s = ViewState["TotalPercentage"].ToString();
            Session["UnitPercentage"] = s;
            Response.Redirect("~/presentationlayer/TCS/Diag_Prog_Unit_Topic.aspx", false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlterm.SelectedIndex > 0)
            {
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Pease Select a Class !");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}