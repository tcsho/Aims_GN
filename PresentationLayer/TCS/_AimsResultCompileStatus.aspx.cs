using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class _AimsResultCompileStatus : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLResult_Grade objClsSec = new BLLResult_Grade();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillActiveSessions();
            bindTermGroupList();
            BindGrid();
            ViewState["SortDirection"] = "ASC";
            ViewState["tMood"] = "check";
        }
    }
    private void SetEmptyGrid(GridView gv)
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("Region_Id");
            dt.Columns.Add("Center_Id");
            dt.Columns.Add("Section_Id");
            dt.Columns.Add("Region_Name");
            dt.Columns.Add("Center_Name");
            dt.Columns.Add("Class_Name");
            dt.Columns.Add("Section_Name");
            dt.Columns.Add("CurrentStudents");
            dt.Columns.Add("ResultCompiled");
            dt.Columns.Add("NotCompiled");

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
    protected void gv_CenterGrid_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_CenterGrid.Rows.Count > 0)
            {
                gv_CenterGrid.UseAccessibleHeader = false;
                gv_CenterGrid.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        DataTable dt = new DataTable();
        objClsSec.TermGroup_Id = Convert.ToInt16(ddlTerm.SelectedValue);
        objClsSec.Session_Id = Convert.ToInt16(ddlSession.SelectedValue);
        if (ViewState["Details"] == null)
        {
            dt = objClsSec.Result_Grade_AimsResultCompileStatus(objClsSec);
            ViewState["Details"] = dt;
        }
        else
        {
            dt = (DataTable)ViewState["Details"];
        }
        if (dt.Rows.Count > 0)
        {
            gv_CenterGrid.DataSource = dt;
            gv_CenterGrid.DataBind();
        }
        else
        {
            SetEmptyGrid(gv_CenterGrid); 
        }
       
    }
    protected void btnCompile_Click(object sender, EventArgs e)
    {
        CheckBox chkAllowAccess;
        foreach (GridViewRow gvr in gv_CenterGrid.Rows)
        {
            chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");
            if (chkAllowAccess.Checked)
            {
                try
                {
                    int AlreadyIn = 0;

                    if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
                    {
                        objClsSec.Section_Id = Convert.ToInt32(gvr.Cells[2].Text);
                        objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                        objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
                        AlreadyIn = objClsSec.TCS_Result_GenerateResultAllBySection_Id(objClsSec);
                        ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");
                    }
                    else
                    {
                        ImpromptuHelper.ShowPrompt("Please select Section, Session and Term!");
                    }
                }

                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


                }
            }
        }
        ViewState["Details"] = null;
        BindGrid();
    }

    protected void bindTermGroupList()
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
    protected void CenterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_CenterGrid.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    public void CenterGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["Details"];
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
        gv_CenterGrid.DataSource = dt;
        gv_CenterGrid.DataBind();
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
    protected void ddlReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetDropDownList()
    {
        try
        {
            ddlReset(ddlSession);
            ddlReset(ddlTerm);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void gv_CenterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gv_CenterGrid.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

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
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedValue = Session["Session_Id"].ToString();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
}