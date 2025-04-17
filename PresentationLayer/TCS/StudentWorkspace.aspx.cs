using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_StudentWorkspace : System.Web.UI.Page
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
                ////////FillClassSection();
                FillActiveSessions();
                trButtons.Visible = false;
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
       
            
    }

    //private void FillClassSection()
    //{

       

    //    try
    //    {

    //        BLLClass_Section objCS = new BLLClass_Section();

    //        objCS.Center_Id = Convert.ToInt32(Session["CId"]);
    //        objCS.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
    //        DataTable _dt = objCS.Class_SectionByTeacherId(objCS);


    //        objBase.FillDropDown(_dt, List_ClassSection, "Section_Id", "Name");

    //        if (List_ClassSection.Items.Count == 0)
    //        {
    //            ImpromptuHelper.ShowPrompt("This Teacher has no section assigned to it. Please assign section(s) to this teacher first.");
    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    ////////protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    ////////{
        


    ////////    try
    ////////    {
            
    ////////        //BindSubject();
    ////////        //////////////BindTerm();
    ////////        //BindStudent();
    ////////        FillActiveSessions();
    ////////        BindGrid(); 

    ////////        //////////////if (List_ClassSection.SelectedItem.Text == "Select")
    ////////        //////////////{
                
    ////////        //////////////    //list_Term.SelectedIndex = 0;

    ////////        //////////////}
    ////////        //////////////else
    ////////        //////////////{
    ////////        //////////////    //list_Term.SelectedIndex = 0;
                
    ////////        //////////////}
    ////////    }
    ////////    catch (Exception ex)
    ////////    {
    ////////        Session["error"] = ex.Message;
    ////////        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    ////////    }
    ////////}

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


//               dtsub = objClsSec.Student_Section_SubjectSelectStudentWorkSpace(objClsSec);

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
   
    //////////private void BindSubject()
    //////////{
    //////////    BLLSection_Subject obj = new BLLSection_Subject();
        
    //////////    obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
    //////////    obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());

    //////////    DataTable dt = (DataTable)obj.Section_SubjectByEmployeeIdSectionId(obj);
    //////////    objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
    //////////}


    //////////private void BindStudent()
    //////////{

       
    //////////}

    //////////private void AddMissingStudent()
    //////////{
    //////////    BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
    //////////    int AlreadyIn = 0;
    //////////    DataTable DTs = (DataTable)ViewState["StudentList"];

    //////////    for (int i = 0; i < DTs.Rows.Count; i++)
    //////////    {
    //////////         obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
    //////////         obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

    //////////         AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
    //////////    }
    //////////}

    //////////private void BindTerm()
    //////////{

        

    //////////    //////////DataTable dt = null;
    //////////    //////////BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
    //////////    //////////ObjECT.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
    //////////    //////////dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
    //////////    //////////objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");

    //////////}

    int chkloop;
    protected void btnSave_Click(object sender, EventArgs e)
       
    {
        
    }

    
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        
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
        BLLSession objBll = new BLLSession();
        DataTable dt = new DataTable();
        dt = objBll.SessionSelectAllActive();
        objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");

    }
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void dv_details_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}