using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_EvaluationCriteriaPercentage : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string Result_GradeIdGe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillClassSection();
                pan_New.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                btn_apply.Visible = false;
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

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        FillSubjects();
        bindTermList();
        BindEvaluationType();

        //gvSubjects.DataSource = null;
        //gvSubjects.DataBind();
        SetEmptyGrid(gvSubjects);
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
            BLLEvaluation_Type obj = new BLLEvaluation_Type();

            obj.Main_Organisation_Id = Convert.ToInt32(Session["moID"].ToString());

            DataTable dt = obj.Evaluation_TypeSelectByOrgId(obj);

            objBase.FillDropDown(dt, list_EvlType, "Evaluation_Type_Id", "Name");


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
        BLLEvaluation_Criteria_Percentage objClsSec = new BLLEvaluation_Criteria_Percentage();

        DataTable dtsub = new DataTable();

       
        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
        objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Evaluation_Criteria_PercentageSelectAllByClassIdSubjectId(objClsSec);
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
        BLLEvaluation_Criteria_Percentage objClsSec = new BLLEvaluation_Criteria_Percentage();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;

        Result_GradeIdGe = ResultGradeValue;

        ViewState["ResultGrade"] = ResultGradeValue;


        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
        objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
        objClsSec.Evaluation_Criteria_Percentage_Id = Convert.ToInt32(Result_GradeIdGe);


        dtsub = (DataTable)objClsSec.Evaluation_Criteria_PercentageSelectAllByClassIdSubjectIdEvlPerctId(objClsSec);

        txtGrade.Text = dtsub.Rows[0]["Percentage"].ToString().Trim();

        ViewState["currentWeightage"] = txtGrade.Text;

        list_EvlType.SelectedValue = dtsub.Rows[0]["Evaluation_Type_Id"].ToString().Trim();
        list_subject.SelectedValue = dtsub.Rows[0]["Subject_Id"].ToString().Trim();
        lblSave.Text = "";

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
        BLLEvaluation_Criteria_Percentage objClsSec = new BLLEvaluation_Criteria_Percentage();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;


        ViewState["ResultGrade"] = ResultGradeValue;

        objClsSec.Evaluation_Criteria_Percentage_Id = Convert.ToInt32(ViewState["ResultGrade"]);

        AlreadyIn = objClsSec.Evaluation_Criteria_PercentageDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        lblSave.Visible = true;
        lblSave.Text = "Delete Record successfully";
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
        if (List_ClassSection.SelectedIndex > 0 && list_term.SelectedIndex > 0)
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        ViewState["currentWeightage"] = "0";
        list_EvlType.SelectedIndex = 0;
        list_subject.SelectedIndex = 0;
        lblSave.Text = "";

        }

        else
        {
            ImpromptuHelper.ShowPrompt("Please select Class, Subject and Term!");
            lblSave.Visible = true;
            lblSave.Text = "Please select Class and Term!";
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        


    }


    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {

            ImageButton btnCopy = (ImageButton)sender;
            GridViewRow grv = (GridViewRow)btnCopy.NamingContainer;            
            string Weitage = grv.Cells[4].Text;
            
            CheckBox cb = null;
            

            foreach (GridViewRow gvRow in gvSubjects.Rows)
            {
               
                cb = (CheckBox)gvRow.FindControl("CheckBox1");
                if (cb.Checked)
                {
                    gvRow.Cells[4].Text = Weitage;
                    cb.Checked = false;
                }
            }
            ViewState["tMood"] = "check";
            btn_apply.Visible = true;
            pan_New.Attributes.CssStyle.Add("display", "none");

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

                if (list_EvlType.SelectedIndex > 0 && list_subject.SelectedIndex > 0)
                {

                BLLEvaluation_Criteria_Percentage objClsSec = new BLLEvaluation_Criteria_Percentage();

                DataTable dtsub = new DataTable();



                objClsSec.Evaluation_Criteria_Percentage_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
                objClsSec.Evaluation_Type_Id = Convert.ToInt32(list_EvlType.SelectedValue.ToString());
                objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());

                objClsSec.Percentage = Convert.ToInt32(txtGrade.Text);


                dtsub = (DataTable)objClsSec.GetCurrentWeightagePercentage(objClsSec);

                    decimal weightage = decimal.Parse(txtGrade.Text);
                    decimal currWeightage = decimal.Parse(ViewState["currentWeightage"].ToString());
                    decimal currentWeightage = decimal.Parse(dtsub.Rows[0]["currentWeightage"].ToString().Trim());
                    if ((weightage + (currentWeightage - currWeightage)) > 100)
                    {
                        
                        ImpromptuHelper.ShowPrompt("Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + ". Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString());
                        lblSave.Visible = true;
                        lblSave.Text = "Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + ". Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString();
                    }
                    else
                    {
                        string mode = Convert.ToString(ViewState["mode"]);

                        if (mode != "Edit")
                        {
                            dt = (DataTable)objClsSec.Evaluation_Criteria_PercentageSelectAllByEvlTypeId(objClsSec);
                            if (dt.Rows.Count == 0)
                            {


                                AlreadyIn = objClsSec.Evaluation_Criteria_PercentageAdd(objClsSec);


                                ViewState["dtDetails"] = null;
                                if (AlreadyIn == 0)
                                {
                                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                    ////pan_New.Attributes.CssStyle.Add("display", "none");
                                    ViewState["mode"] = "Add";
                                    BindGrid();

                                    txtGrade.Text = "";
                                    list_EvlType.SelectedIndex = 0;


                                    lblSave.Visible = true;
                                    lblSave.Text = "Record Saved Successfully";

                                }


                            }
                            else
                            {

                                ImpromptuHelper.ShowPrompt("Evaluation Type with this name already exists.");
                                lblSave.Text = "Evaluation Type with this name already exists.";
                            }
                        }

                        else
                        {



                            AlreadyIn = objClsSec.Evaluation_Criteria_PercentageUpdate(objClsSec);


                            ViewState["dtDetails"] = null;
                            if (AlreadyIn == 0)
                            {
                                ImpromptuHelper.ShowPrompt("Record successfully updated.");
                                pan_New.Attributes.CssStyle.Add("display", "none");
                                BindGrid();

                                lblSave.Visible = true;
                                lblSave.Text = "Record Updated Successfully";

                            }


                        }



                    }

            }

                else
                {
                    ImpromptuHelper.ShowPrompt("Please Evaluation Type and Subject!");
                    lblSave.Visible = true;
                    lblSave.Text = "Please Evaluation Type and Subject!";
                }
            //}
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
            dt.Columns.Add("Evaluation_Criteria_Percentage_Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Subject_Name");
            dt.Columns.Add("Percentage");
            dt.Columns.Add("Evaluation_Criteria_Type_Id");
            dt.Columns.Add("EvaluationType");
            dt.Columns.Add("Subject_Id");
	    dt.Columns.Add("Class_Name");
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
    protected void gvSubjects_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {

            txtGrade.Text = gvSubjects.Rows[e.NewSelectedIndex].Cells[4].Text;
            ViewState["currentWeightage"] = txtGrade.Text;
            list_EvlType.SelectedValue = gvSubjects.Rows[e.NewSelectedIndex].Cells[6].Text;


            ViewState["mode"] = "Edit";
            ViewState["EditID"] = gvSubjects.Rows[e.NewSelectedIndex].Cells[0].Text;
            //error.Visible = false;
            pan_New.Attributes.CssStyle.Add("display", "inline");
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
            //gvSubjects.DataBind(); .
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
        //////pan_New.Attributes.CssStyle.Add("display", "none");
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        ViewState["currentWeightage"] = "0";
        list_EvlType.SelectedIndex = 0;
        lblSave.Text = "";
        txtGrade.Focus();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    
    protected void btn_apply_Click(object sender, EventArgs e)
    {
         try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLEvaluation_Criteria_Percentage objClsSec = new BLLEvaluation_Criteria_Percentage();
            DataTable dtsub = new DataTable();

            for (int i = 0; i < gvSubjects.Rows.Count; i++)
            {
                 objClsSec.Evaluation_Criteria_Percentage_Id = Convert.ToInt32(gvSubjects.Rows[i].Cells[0].Text);
                 objClsSec.Percentage = Convert.ToInt32(gvSubjects.Rows[i].Cells[4].Text);

                 AlreadyIn = objClsSec.Evaluation_Criteria_PercentageApplyAllChangesUpdate(objClsSec);

                
            }

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Apply All Changes successfully.");
                pan_New.Attributes.CssStyle.Add("display", "none");
                BindGrid();

                lblSave.Visible = true;
                lblSave.Text = "Apply All Changes successfully.";

            }

        }
         catch (Exception ex)
         {
             Session["error"] = ex.Message;
             Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
         }
    }
}