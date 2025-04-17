using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_TeacherWorkspaceDetail : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //FillClassSection();
                BindGrid();
                //trButtons.Visible = false;
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
       
            
    }

   

    private void BindGrid()
    {
        try
        {

            dv_details.DataSource = null;
            dv_details.DataBind();

            //trButtons.Visible = true;

            BLLSection_Subject objClsSec = new BLLSection_Subject();

            DataTable dtsub = new DataTable();

            ////if ( list_Subject.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && List_ClassSection.SelectedIndex > 0)
           
           
            ////{

                ////objClsSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                ////objClsSec.Section_Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
                ////objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());


                dtsub = objClsSec.Section_SubjectSelectAllWorkSiteByTeacherId(objClsSec);

                dv_details.DataSource = dtsub;
                ViewState["Table"] = dtsub;
                dv_details.DataBind();

                


            ////////}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
   
   


    private void BindStudent()
    {

       
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
    }

   

    int chkloop;
    protected void btnSave_Click(object sender, EventArgs e)
       
    {
        
    }

    
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }




    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void dv_details_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}