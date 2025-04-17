using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_StudentResultCenterWise : System.Web.UI.Page
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
                if (Session["Section_Id"] != null && Session["Student_Id"] != null)
                {
                    List_ClassSection.SelectedValue = Session["Section_Id"].ToString();
                    BindStudent();
                    list_student.SelectedValue = Session["Student_Id"].ToString();
                    List_ClassSection.Enabled = false;
                    list_student.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
        
            
    }

    private void FillClassSection()
    {

       

        try
        {

           

            BLLClass_Section obj = new BLLClass_Section();

            int CenterId = Convert.ToInt32(Session["cId"].ToString());
            DataTable dt = (DataTable)obj.Class_SectionByCenterId(CenterId);

            objBase.FillDropDown(dt, List_ClassSection, "Section_Id", "FullClassSection");

           
            

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
            
            BindTerm();
            
            FillActiveSessions();


            BindStudent();
         
           

            BindGrid(false);

            if (List_ClassSection.SelectedItem.Text == "Select")
            {



                list_Term.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                list_student.SelectedIndex = 0;

                dv_details.DataSource = null;
                dv_details.DataBind();
                

            }
         

            ////if (List_ClassSection.SelectedItem.Text == "Select")
            ////{
               
            ////    list_Term.SelectedIndex = 0;

            ////}
            ////else
            ////{
            ////    list_Term.SelectedIndex = 0;
                
            ////}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindGrid(bool doOverride)
    {

        try
        {

            int termId = Convert.ToInt32(list_Term.SelectedValue.ToString());
            int termGroup_Id = 0;
            BLLEvaluation_Criteria_Type ObjEval = new BLLEvaluation_Criteria_Type();
            DataTable dtECT = ObjEval.Evaluation_Criteria_TypeFetch(termId); //Term

            if (dtECT.Rows.Count > 0)
            {
                termGroup_Id = Convert.ToInt32(dtECT.Rows[0]["TermGroup_Id"].ToString());
            }
            else
            {
                termGroup_Id = 1;
            }

            if (termGroup_Id == 1)
            {
                dv_details.Columns[4].Visible = false;
            }
            else
            {
                dv_details.Columns[4].Visible = true;
            }


            if (list_Term.SelectedItem.Text == "Mock Examination")
            {
                dv_details.Columns[3].Visible = false;
                dv_details.Columns[4].Visible = false;

            }
            else
            {
                dv_details.Columns[3].Visible = true;
                dv_details.Columns[4].Visible = true;

            }




            dv_details.DataSource = null;
            dv_details.DataBind();

            trButtons.Visible = true;

            trButtons.Visible = true;

           

            BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

            DataTable dtsub = new DataTable();

            if (list_Term.SelectedIndex > 0 && list_student.SelectedIndex > 0 && ddlSession.SelectedIndex > 0)
           
           
            {
                

                    objClsSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                    objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());

                objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

                objClsSec.Student_Id = Convert.ToInt32(list_student.SelectedValue.ToString());

                dtsub = objClsSec.Result_ByEmployeeCenterWise(objClsSec);


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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

       
    }


    private void BindStudent()
    {

       
        try
        {
            list_student.Items.Clear();

            if (List_ClassSection.SelectedValue != "")
            {
                BLLStudent_Section_Subject objStd = new BLLStudent_Section_Subject();

                objStd.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objStd.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
                objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                
                DataTable dt = objStd.StudentByCenterEvaluationId(objStd);
                objBase.FillDropDown(dt, list_student, "Student_Id", "FullStudentName");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    ////////////private void AddMissingStudent()
    ////////////{
    ////////////    try
    ////////////    {
    ////////////    BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
    ////////////    int AlreadyIn = 0;
    ////////////    DataTable DTs = (DataTable)ViewState["StudentList"];

    ////////////    for (int i = 0; i < DTs.Rows.Count; i++)
    ////////////    {
    ////////////         obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
    ////////////         obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

    ////////////         AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
    ////////////    }
    ////////////    }
    ////////////    catch (Exception ex)
    ////////////    {
    ////////////        Session["error"] = ex.Message;
    ////////////        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    ////////////    }

    ////////////}

    private void BindTerm()
    {
        try
        {
        

        DataTable dt = null;
        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        ObjECT.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
        dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
        objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");
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
        if (list_Term.SelectedItem.Text == "Select")
        {



            //////////////////list_Term.SelectedIndex = 0;
            ddlSession.SelectedIndex = 0;
            list_student.SelectedIndex = 0;

            dv_details.DataSource = null;
            dv_details.DataBind();


        }

        BindGrid(false);
    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_student.SelectedValue != "")
            {
                BindGrid(true);
            }
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
                BindStudent();
            }
            if (Session["Student_Id"] != null)
            {
                BindStudent();
                list_student.SelectedValue = Session["Student_Id"].ToString();
                list_student_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlSession.SelectedItem.Text == "Select")
            { 
                //////////////////list_Term.SelectedIndex = 0;
                //////////ddlSession.SelectedIndex = 0;
                list_student.SelectedIndex = 0;

                dv_details.DataSource = null;
                dv_details.DataBind();


            }

            BindGrid(false);
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

    }
}