using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.IO;




public partial class PresentationLayer_LmsResource : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
                //BindGrid();
                BindFileFolder();


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
                


                dtsub = objClsSec.Section_SubjectSelectAllWorkSiteByTeacherIdForResources(objClsSec);

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
   
    


    private void BindStudent()
    {

       
    }

    private void BindFileFolder()
    {
        try
        {
            //// To automatically bind file folder location
            BLLLmsRes objBll = new BLLLmsRes();

            DataTable dtchk = new DataTable();


            string Title = Session["WorkSiteName"].ToString();

            string strFolderPath = "D:\\TCS\\LMS\\" + Title + "\\Resources";

            ////lblWorksitename.Text = Session["WorkSiteName"].ToString();

            objBll.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());
            objBll.WrkTool_ID = Convert.ToInt32(Session["WorkToolId"].ToString());

            objBll.ResourceTitle = Title;
            objBll.FolderPath = strFolderPath;
            objBll.Status_Id = 1;
            objBll.CreatedOn = DateTime.Now;
            objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);

            dtchk = (DataTable)objBll.LmsResSelectAllBySectionSubjectIdWrkToolId(objBll);
            if (dtchk.Rows.Count == 0)
            {
                objBll.LmsResAdd(objBll);
            }
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }



            Session["ResCat"] = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString()); ;
            Session["CatName"] = "";
            Session["View"] = "ho";
            Session["Module"] = "LMSResource";



            Session["FolderPath"] = "D:\\TCS\\LMS\\" + Title + "\\Resources";




            Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx",false);


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
        BLLSection_Subject objClsSec = new BLLSection_Subject();
        BLLLmsRes objBll = new BLLLmsRes();

        DataTable dtsub = new DataTable();
        DataTable dtchk = new DataTable();

        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;
        ViewState["ResultGrade"] = ResultGradeValue;


        objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
        objClsSec.Section_Subject_Id = Convert.ToInt32(ResultGradeValue);


        dtsub = (DataTable)objClsSec.Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForResources(objClsSec);

        string Title = dtsub.Rows[0]["Title"].ToString().Trim();

        string WrkToolId = dtsub.Rows[0]["WrkTool_ID"].ToString().Trim();

        
        string strFolderPath = "D:\\TCS\\LMS\\" + Title + "\\Resources";

        objBll.Section_Subject_Id = Convert.ToInt32(ResultGradeValue); ;
        objBll.WrkTool_ID = Convert.ToInt32(WrkToolId);
        objBll.ResourceTitle = Title;
        objBll.FolderPath = strFolderPath;
        objBll.Status_Id = 1;
        objBll.CreatedOn = DateTime.Now;
        objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);

        dtchk = (DataTable)objBll.LmsResSelectAllBySectionSubjectIdWrkToolId(objBll);
        if (dtchk.Rows.Count == 0)
        {
            objBll.LmsResAdd(objBll);
        }
        if (!Directory.Exists(strFolderPath))
        {
            Directory.CreateDirectory(strFolderPath);
        }

        

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.CommandName;
        Session["View"] = "ho";
        Session["Module"] = "LMSResource";
       


        Session["FolderPath"] = "D:\\TCS\\LMS\\" + Title + "\\Resources";




        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");


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
}