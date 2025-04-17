using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_IEPAllTables : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                   // Session.Abandon();
                  //  Response.Redirect("~/login.aspx", false);
                //}

                //====== End Page Access settings ======================
              //  FillActiveSessions();
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
    //        objCS.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
    //        DataTable _dt = objCS.Class_SectionBySessionTeacherId(objCS);


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

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {

        

        try
        {
            //BindTerm();
            //BindSubject();
           // BindGrid(); 

            //if (List_ClassSection.SelectedItem.Text == "Select")
            //{
                
            //    list_Term.SelectedIndex = 0;

            //}
            //else
            //{
            //    list_Term.SelectedIndex = 0;
                
            //}
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

            DataSet dtsub = new DataSet();
            if (txtStudentID.Text != "")
            {
                dtsub = Result_ByEmployeeSubjectWise(txtStudentID.Text);

                dv_details.DataSource = dtsub.Tables[0];
                //ViewState["Table"] = dtsub;
                dv_details.DataBind();

                dv_IepRaisec.DataSource = dtsub.Tables[1];
                dv_IepRaisec.DataBind();

                dv_IEPC_Recom.DataSource = dtsub.Tables[2];
                dv_IEPC_Recom.DataBind();

                dv_IEPExtra_C.DataSource= dtsub.Tables[3];
                dv_IEPExtra_C.DataBind();

                dv_IepHonorAwards.DataSource = dtsub.Tables[4];
                dv_IepHonorAwards.DataBind();

                dv_IEP_DU.DataSource = dtsub.Tables[5];
                dv_IEP_DU.DataBind();

            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public DataSet Result_ByEmployeeSubjectWise(string studentID)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@StudentID", SqlDbType.Int);
        param[0].Value = studentID;

        

        
        ds = DALBase.getDataSetBySp("Sp_IEP_GetDataWithoutAudit", param);
        if (ds.Tables.Count == 0)
        {
            return null;
        }
        
        return ds;
    }


    //private void BindSubject()
    //{
    //    try
    //    {
    //    BLLSection_Subject obj = new BLLSection_Subject();

    //    obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
    //    obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());

    //    obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

    //   DataTable dt = (DataTable)obj.Section_SubjectByEmployeeIdSessionSectionId(obj);
    //   objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}


    private void BindStudent()
    {

       
    }

    private void AddMissingStudent()
    {
        //try
        //{
        //BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
        //int AlreadyIn = 0;
        //DataTable DTs = (DataTable)ViewState["StudentList"];

        //for (int i = 0; i < DTs.Rows.Count; i++)
        //{
        //     obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
        //     obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

        //     AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
        //}
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }

    //private void BindTerm()
    //{

    //    try
    //    {

    //    DataTable dt = null;
    //    BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
    //    ObjECT.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
    //    dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
    //    objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }


    //}

    int chkloop;
    protected void btnSave_Click(object sender, EventArgs e)
       
    {
        
    }

    
    //protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //    BindGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }




    //protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //    DDLReset(list_Term);
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    //protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlSession.SelectedValue != "")
    //        {
    //            FillClassSection();
    //            DDLReset(list_Subject);
    //            DDLReset(list_Term);
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}
    protected void DDLReset(DropDownList _ddl)
    {
        try
        {
        if (_ddl.Items.Count > 0)
        {
            _ddl.SelectedValue = "0";
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    
    }

    //protected void FillActiveSessions()
    //{
    //    try
    //    {
    //    BLLSession objBll = new BLLSession();
    //    DataTable dt = new DataTable();
    //    dt = objBll.SessionSelectAllActive();
    //    objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

        
    //}
    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {







    }


    protected void btnShowRecord_click(object sender, EventArgs e)
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