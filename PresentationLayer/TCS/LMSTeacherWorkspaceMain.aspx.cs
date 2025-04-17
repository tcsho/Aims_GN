using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_LMSTeacherWorkspaceMain : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
       
            
    }

    

    private void BindGrid()
    {
        try
        {

            dv_details.DataSource = null;
            dv_details.DataBind();

           

            BLLSection_Subject objClsSec = new BLLSection_Subject();

            DataTable dtsub = new DataTable();

            

               
                objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                


                dtsub = objClsSec.Section_SubjectSelectAllWorkSiteByTeacherId(objClsSec);

                dv_details.DataSource = dtsub;
                ViewState["Table"] = dtsub;
                dv_details.DataBind();






        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
   
    


    ////private void BindStudent()
    ////{

       
    ////}


    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
        Session["WorkSiteSectionSubjectId"] = null;

        Session["WorkSiteName"] = null;

        ImageButton btn = (ImageButton)(sender);
        string WorkSiteSectionSubjectId = btn.CommandArgument;
        

        Session["WorkSiteSectionSubjectId"] = WorkSiteSectionSubjectId;


        ImageButton imgbtn = (ImageButton)sender;

        GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;

        Session["WorkSiteName"] = gvr.Cells[1].Text.ToString();



        Response.Redirect("~/PresentationLayer/TCS/LMSTeacherWorkspaceDetail.aspx");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    

    //////int chkloop;
    //////protected void btnSave_Click(object sender, EventArgs e)
       
    //////{
        
    //////}

    
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


    protected void lnkBtnWrk_Click(object sender, EventArgs e)
    {
        try
        {

        Session["WorkSiteSectionSubjectId"] = null;

        Session["WorkSiteName"] = null;

        LinkButton btn = (LinkButton)(sender);
        string WorkSiteSectionSubjectId = btn.CommandArgument;


        Session["WorkSiteSectionSubjectId"] = WorkSiteSectionSubjectId;


        LinkButton imgbtn = (LinkButton)sender;

        GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;

        Session["WorkSiteName"] = gvr.Cells[1].Text.ToString();



        Response.Redirect("~/PresentationLayer/TCS/LMSTeacherWorkspaceDetail.aspx");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
   
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void dv_details_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}