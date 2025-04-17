using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_PerformanceEvaluationLabelsGeneralPerformance : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string Result_GradeIdGe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ImpromptuHelper.ShowPrompt("Hello World!");
            try
            {
                lblSave.Text = "";
                bindTermGroupList();
                FillClassSection();
                pan_New.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;

                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx",false);
                }

                //====== End Page Access settings ======================









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
        lblSave.Text = "";
        BLLResult_Grade obj = new BLLResult_Grade();

        
        int moID = Int32.Parse(Session["moID"].ToString());
        obj.Main_Organisation_Id = moID;

        DataTable dt = (DataTable)obj.Class_SelectByOrgId(obj);

        objBase.FillDropDown(dt, List_ClassSection, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void FillSubjects()
    {

        try
        {

        lblSave.Text = "";
        BLLEvaluation_Criteria_Percentage obj = new BLLEvaluation_Criteria_Percentage();

        
        int moID = Int32.Parse(Session["moID"].ToString());
        obj.Main_Organisation_Id = moID;
        obj.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

        DataTable dt = (DataTable)obj.Class_SubjectSelectAllByClassId(obj);

        objBase.FillDropDown(dt, list_subject, "subject_id", "Subject_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void bindTermList()
    {
        try
        {
        DataTable dt = null;
        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        ObjECT.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
        dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);
        objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void bindTermGroupList()
    {
        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, list_term, "TermGroup_Id", "Type");
           

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
        //////////////////////FillSubjects();
        ////////////////////////////////////////////////bindTermList();
        //////////////////////BindEvaluationType();
        //////////////////////gvSubjects.DataSource = null;
        //////////////////////gvSubjects.DataBind();
        //////////////////////pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    private void BindEvaluationType()
    {
        try
        {

        if (List_ClassSection.SelectedIndex > 0)
        {
            BLLStudent_Performance_SubItemHeads obj = new BLLStudent_Performance_SubItemHeads();
            obj.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());

            DataTable dt = obj.Student_Performance_SubItemHeads_SelectAllByOrgID(obj);

            objBase.FillDropDown(dt, list_EvlType, "KndItmHd_Id", "Description");


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
        BLLStudent_Performance_SubClassActLbl objClsSec = new BLLStudent_Performance_SubClassActLbl();

        DataTable dtsub = new DataTable();

        ////////////////objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
        ////////////////objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        objClsSec.TermGroup_Id = Convert.ToInt32(list_term.SelectedValue.ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Student_Performance_SubClassActLbl_SelectAllByTermGroupId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvSubjects.DataSource = dtsub;
            gvSubjects.DataBind();
        }
        else
            SetEmptyGrid(gvSubjects);

        
        ViewState["tMood"] = "check";
        trSave.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

  
    
   

     




    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        BLLStudent_Performance_SubClassActLbl objClsSec = new BLLStudent_Performance_SubClassActLbl();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;

        Result_GradeIdGe = ResultGradeValue;

        ViewState["ResultGrade"] = ResultGradeValue;


        ////////////objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
        ////////////objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        ////////////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
        objClsSec.TermGroup_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
        objClsSec.SubKndItmLbl_Id = Convert.ToInt32(Result_GradeIdGe);


        dtsub = (DataTable)objClsSec.Student_Performance_SubClassActLbl_SelectAllByTermGroupIdSubKndItmLblId(objClsSec);

        txtCritName.Text = dtsub.Rows[0]["Description"].ToString().Trim();
        //////////////list_subject.SelectedValue = dtsub.Rows[0]["Subject_Id"].ToString().Trim();
        List_ClassSection.SelectedValue = dtsub.Rows[0]["Class_Id"].ToString().Trim();
        
        //////////////////////if (dtsub.Rows[0]["KndItmHd_Id"].ToString().Trim() !="")
        //////////////////////{

        //////////////////////list_EvlType.SelectedValue = dtsub.Rows[0]["KndItmHd_Id"].ToString().Trim();
       
        //////////////////////}
        //////////////////////else
        //////////////////////{
        //////////////////////    list_EvlType.SelectedIndex = 0;
        //////////////////////}
        txtCritName.Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
        BLLStudent_Performance_SubClassActLbl objClsSec = new BLLStudent_Performance_SubClassActLbl();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;


        ViewState["ResultGrade"] = ResultGradeValue;

        objClsSec.SubKndItmLbl_Id = Convert.ToInt32(ViewState["ResultGrade"]);

        AlreadyIn = objClsSec.Student_Performance_SubClassActLblDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        pan_New.Attributes.CssStyle.Add("display", "none");
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
        if (  list_term.SelectedIndex > 0)
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";        
        txtCritName.Text = "";
        list_subject.SelectedIndex = 0;
        list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        txtCritName.Focus();

        }

        else
        {
            ImpromptuHelper.ShowPrompt("Please select Class, Subject and Term!");
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        

    }


    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {



            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLStudent_Performance_SubClassActLbl objClsSec = new BLLStudent_Performance_SubClassActLbl();
            DataTable dtsub = new DataTable();
            objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
            objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
            ////////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
            objClsSec.Subject_Id = 55;
            ////////objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
            ////////////objClsSec.KndItmHd_Id = Convert.ToInt32(list_EvlType.SelectedValue.ToString());
            objClsSec.SubKndItmLbl_Id = Convert.ToInt32(ViewState["ResultGrade"]);
            objClsSec.Description = txtCritName.Text.ToString();

            if (list_term.SelectedIndex > 0)
            {



            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {


                objClsSec.Status_Id = 1;
                objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.CreatedOn = DateTime.Now;


                AlreadyIn = objClsSec.Student_Performance_SubClassActLblGeneralPerformanceInsert(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                    //////////pan_New.Attributes.CssStyle.Add("display", "none");

                    BindGrid();

                    txtCritName.Text = "";
                    //////////list_subject.SelectedIndex = 0;
                    ViewState["mode"] = "Add";

                    lblSave.Visible = true;
                    lblSave.Text = "Record Saved Successfully";




                }


            }

            else
            {


               
               
                objClsSec.Status_Id = 1;
                objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objClsSec.ModifiedOn = DateTime.Now;

                AlreadyIn = objClsSec.Student_Performance_SubClassActLblGeneralPerformanceUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    pan_New.Attributes.CssStyle.Add("display", "none");
                    BindGrid();


                    txtCritName.Text = "";
                    ////list_subject.SelectedIndex = 0;

                    lblSave.Visible = true;
                    lblSave.Text = "Record Updated Successfully";

                }


            }

            }

            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Subject & Item Head!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "none");
        gvSubjects.SelectedRowStyle.Reset();

        lblSave.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }



    private void SetEmptyGrid(GridView gv)
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("SubKndItmLbl_Id");
            dt.Columns.Add("Class_Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Subject_Name");
            dt.Columns.Add("Item_Head");
            dt.Columns.Add("Description");


            dt.Rows.Add(dt.NewRow());
            gv.DataSource = dt;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvSubjects.Rows.Count > 0)
            {
                gvSubjects.UseAccessibleHeader = false;
                gvSubjects.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_term.SelectedValue != "0")
            {
                BindGrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                //gvSubjects.DataSource = null;
                //gvSubjects.DataBind();
                SetEmptyGrid(gvSubjects);
                pan_New.Attributes.CssStyle.Add("display", "none");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();
        //////////pan_New.Attributes.CssStyle.Add("display", "none");

        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtCritName.Text = "";
        lblSave.Text = "";
        ////////////list_subject.SelectedIndex = 0;
        ////////////list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        txtCritName.Focus();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void list_EvlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void list_subject_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            //////////////////bindTermList();
            //////////////////gvSubjects.DataSource = null;
            //////////////////gvSubjects.DataBind();
            //////////////////pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}