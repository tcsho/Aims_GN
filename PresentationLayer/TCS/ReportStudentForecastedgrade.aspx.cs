using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;

public partial class PresentationLayer_TCS_ReportStudentForecastedgrade : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt.Dispose();
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
    private void loadResultMonth()
    {
        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            dt.Dispose();
            objBase.FillDropDown(dt, ddlResultMonth, "ResultSeries_Id", "ResultSeries");

            if (DateTime.Now.Month > 9)
            {
                ddlResultMonth.SelectedIndex = 2;
            }
            else
            {
                ddlResultMonth.SelectedIndex = 1;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillActiveSessions();
            loadResultMonth();
        }
    }

    private void BindGrid()
    {
        string rd_value = "";

        rd_value = rdbtn.SelectedValue;
        DataSet ds = exec_SP("F", rd_value);
        ds.Dispose();
        if (rd_value.ToString() == "1")
        {
            if (ds.Tables.Count > 0)
            {
                    gv_details.DataSource = ds.Tables[0];
                    gv_details.DataBind();
            }
        }
        else
        {
            if (ds.Tables.Count > 0)
            {


                if (ds.Tables[0].Rows.Count > 0)
                {

                    gv_details.DataSource = ds.Tables[0];
                    gv_details.DataBind();
                }
            }
        }
        // var rd =  rd1.Checked;
        
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public DataSet exec_SP(string action, string Rpts_ID)
    {       
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@ForcastedType", null);
        param[1] = new SqlParameter("@user_id", Session["UserId"].ToString());
        param[2] = new SqlParameter("@Session_Id", ddlSession.SelectedValue);
        param[3] = new SqlParameter("@ResultSeries_Id", ddlResultMonth.SelectedValue);
        param[4] = new SqlParameter("@Glevel", ddlGlevel.SelectedValue);
        param[5] = new SqlParameter("@Action", action);
        param[6] = new SqlParameter("@RPT_ID", Rpts_ID);

        DataSet ds = objBase.sqlcmdFetch_DS("SP_ForCasted_Grades", param);
        ds.Dispose();
        return ds;
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
