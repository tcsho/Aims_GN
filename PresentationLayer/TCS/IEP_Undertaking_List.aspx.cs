using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_IEP_Undertaking_List : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string a = Session["UserType_Id"].ToString();
            DataRow row = (DataRow)Session["rightsRow"];
            if (Session["UserType_Id"].ToString() == "3" || Session["UserType_Id"].ToString() == "25" || Session["UserType_Id"].ToString() == "16" || Session["UserType_Id"].ToString() == "33" || Session["UserType_Id"].ToString() == "4" || Session["UserType_Id"].ToString() == "35" || Session["UserType_Id"].ToString() == "5")
            {
                DataTable dt = exec_SP(Session["UserId"].ToString());
                Grid_IEPStudents.DataSource = dt;
                Grid_IEPStudents.DataBind();
            }
            else
            {
                Response.Redirect("~/PresentationLayer/Default.aspx", false);
            }

            
        }
    }

    public DataTable exec_SP(string Student_id)
    {
        SqlParameter[] param = new SqlParameter[2];

        if(Session["UserType_Id"].ToString() == "3")
        {
            DataRow row = (DataRow)Session["rightsRow"]; //row["Center_Id"].ToString()
            param[0] = new SqlParameter("@Student_id", row["Center_Id"].ToString());
        }
        else if (Session["UserType_Id"].ToString() == "4" || Session["UserType_Id"].ToString() == "25" || Session["UserType_Id"].ToString() == "33")
        {
            DataRow row = (DataRow)Session["rightsRow"]; //row["Center_Id"].ToString()
            param[0] = new SqlParameter("@Student_id", row["Region_Id"].ToString());
        }
        
        else
        {
            param[0] = new SqlParameter("@Student_id", Student_id);
        }
        param[1] = new SqlParameter("@UserTypeID", Session["UserType_Id"].ToString());
        DataTable dt = objBase.sqlcmdFetch("sp_getundertaking", param);
        dt.Dispose();
        return dt;
    }
    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid_IEPStudents.Rows.Count > 0)
            {
                Grid_IEPStudents.UseAccessibleHeader = false;
                Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void txt_view_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;
      //  string pk = e.DataKeys[row.RowIndex].Values[0].ToString();
      //  Response.Redirect("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + spnErpNo.InnerText + "&C=" + hd_section_id.Value + "&T=" + 1);
    }

    protected void Grid_IEPStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       string student_id =  e.CommandArgument.ToString();
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
         Response.Redirect("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + student_id + "&C=" + row.Cells[0].Text + "&T=" + row.Cells[5].Text);

    }



}