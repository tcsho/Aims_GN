using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_LmsStudentDropbox : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //======== Page Access Settings ========================
            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;


            DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            //            tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================

            try
            {
                
                FillActiveSessions();
                trButtons.Visible = false;
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

            trButtons.Visible = true;

            BLLStudent_Section_Subject objClsSec = new BLLStudent_Section_Subject();

            DataTable dtsub = new DataTable();

            if (  ddlSession.SelectedIndex > 0 )
           
           
            {

                objClsSec.Student_Id = Int32.Parse(Session["ContactID"].ToString());
                objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());


                dtsub = objClsSec.Student_Section_SubjectSelectStudentWorkSpace(objClsSec);

                dv_details.DataSource = dtsub;
                ViewState["Table"] = dtsub;
                dv_details.DataBind();

                


            }

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
    private void BindFileFolder()
    {
        try
        {
            




            Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
        BLLSection_Subject objClsSec = new BLLSection_Subject();
        BLLLmsDpb objBll = new BLLLmsDpb();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ReferenceIdValue = btn.CommandArgument;
        ViewState["ReferenceId"] = ReferenceIdValue;


        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        dv_details.SelectedIndex = gvr.RowIndex;



        string Title = gvr.Cells[8].Text;

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.CommandName;
        Session["View"] = "std";
        Session["Module"] = "LMSDropbox";



        Session["FolderPath"] = "D:\\TCS\\LMS\\" + Title + "\\Dropbox\\" + ReferenceIdValue;




        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }


    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedValue != "")
            {
                BindGrid();
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