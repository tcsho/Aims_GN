using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_LMSTeacherWorkspaceDetail : System.Web.UI.Page
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

            BLLSection_Subject_Tool objClsSec = new BLLSection_Subject_Tool();

            DataTable dtsub = new DataTable();



            objClsSec.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());



            dtsub = objClsSec.Section_Subject_ToolSelectWorkSiteBySectionSubjectIdForStudent(objClsSec);

                dv_details.DataSource = dtsub;
                ViewState["Table"] = dtsub;
                dv_details.DataBind();
                //////////////////////foreach (DataRow row in dtsub.Rows) // Loop over the rows.
                //////////////////////{

                //////////////////////    MenuItem title = new MenuItem(row["ProjectTool"].ToString().Trim());
                //////////////////////    navMenu.Items.Add(title);
                //////////////////////    title.NavigateUrl = row["PagePath"].ToString().Trim();
                //////////////////////    Session["WorkToolId"] = row["WrkTool_ID"].ToString().Trim();

                   
                //////////////////////}



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
        try
        {
        Session["WorkToolId"] = null;

        ImageButton btn = (ImageButton)(sender);
        string WorkToolId = btn.CommandArgument;


        Session["WorkToolId"] = WorkToolId;




        ImageButton imgbtn = (ImageButton)sender;

        GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;

        string PagePath = gvr.Cells[6].Text.ToString();

        Response.Redirect(PagePath);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        

       
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
    protected void navMenu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    protected void lnkBtnWrk_Click(object sender, EventArgs e)
    {
        try
        {

        Session["WorkToolId"] = null;

        LinkButton btn = (LinkButton)(sender);
        string WorkToolId = btn.CommandArgument;


        Session["WorkToolId"] = WorkToolId;




        LinkButton imgbtn = (LinkButton)sender;

        GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;

        string PagePath = gvr.Cells[6].Text.ToString();

        Response.Redirect(PagePath);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void dv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        if (e.CommandName == "projecttool")
        {

            int ind = Int32.Parse((string)e.CommandArgument);

            int userId = Int32.Parse(dv_details.DataKeys[1].Value.ToString());



            
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}