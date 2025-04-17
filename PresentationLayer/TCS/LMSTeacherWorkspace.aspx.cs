using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_LMSTeacherWorkspace : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillClassSection();
                trButtons.Visible = false;
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
       
            
    }

    private void FillClassSection()
    {

       

        try
        {

            BLLClass_Section objCS = new BLLClass_Section();

            objCS.Center_Id = Convert.ToInt32(Session["CId"]);
            objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            DataTable _dt = objCS.Class_SectionByTeacherId(objCS);


            objBase.FillDropDown(_dt, List_ClassSection, "Section_Id", "Name");

            if (List_ClassSection.Items.Count == 0)
            {
                ImpromptuHelper.ShowPrompt("This Teacher has no section assigned to it. Please assign section(s) to this teacher first.");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        


        try
        {

            
            dv_details.DataSource = null;
            dv_details.DataBind();


            
            BindSubject();
            

            if (List_ClassSection.SelectedItem.Text == "Select")
            {

                list_Subject.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();

            }
            else
            {
               
                
            }
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

            dv_details.DataSource = null;
            dv_details.DataBind();

            trButtons.Visible = true;

            BLLSection_Subject objClsSec = new BLLSection_Subject();

            DataTable dtsub = new DataTable();

            if ( list_Subject.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && List_ClassSection.SelectedIndex > 0)
           
           
            {

                objClsSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objClsSec.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());
                objClsSec.Section_Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
                objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());


                dtsub = objClsSec.Section_SubjectSelectTeacherWorkSpace(objClsSec);

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
   
    private void BindSubject()
    {
        try
        {
        BLLSection_Subject obj = new BLLSection_Subject();
        
        obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());

        DataTable dt = (DataTable)obj.Section_SubjectByEmployeeIdSectionId(obj);
        objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");

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

    private void AddMissingStudent()
    {
        try
        {
        BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
        int AlreadyIn = 0;
        DataTable DTs = (DataTable)ViewState["StudentList"];

        for (int i = 0; i < DTs.Rows.Count; i++)
        {
             obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
             obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

             AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
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
        try
        {
        FillActiveSessions();

        if (list_Subject.SelectedItem.Text == "Select")
        {

           
            ddlSession.SelectedIndex = 0;
            dv_details.DataSource = null;
            dv_details.DataBind();

        }
        else
        {
           

        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedValue != "")
            {
                BindGrid();
            }

            if (ddlSession.SelectedItem.Text == "Select")
            {

                
                dv_details.DataSource = null;
                dv_details.DataBind();

            }
            else
            {
                

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