using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Newtonsoft.Json;

public partial class PresentationLayer_TCS_IEP_Reports : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddl_reports_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_class = exec_SP(ddl_reports.SelectedItem.Value);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt_class);
            Grid_IEPStudents.DataSource = dt_class;
            Grid_IEPStudents.DataBind();
         
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public DataTable exec_SP(string Action)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_id", Convert.ToInt32(Session["Session_Id"]));
        param[1] = new SqlParameter("@Action", Action);
        DataTable dt = objBase.sqlcmdFetch("sp_iep_kpis", param);
        dt.Dispose();
        return dt;
    }

    //protected void Grid_IEPStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    int cnt = 0;
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //If Salary is less than 10000 than set the row Background Color to Cyan  
    //        if (e.Row.Cells[2].Text == "Yes" && e.Row.Cells[3].Text == "Yes" && e.Row.Cells[4].Text == "Yes" && e.Row.Cells[5].Text == "Yes")
    //        {
    //            e.Row.BackColor = Color.Red;
    //        }
    //        if (e.Row.Cells[2].Text == "Yes")
    //        {
    //            cnt++;
    //        }
    //        if (e.Row.Cells[3].Text == "Yes")
    //        {
    //            cnt++;
    //        }
    //        if (e.Row.Cells[4].Text == "Yes")
    //        {
    //            cnt++;
    //        }
    //        if (e.Row.Cells[5].Text == "Yes")
    //        {
    //            cnt++;
    //        }
    //        e.Row.Cells[0].Text = cnt.ToString();
    //    }
    //}

}