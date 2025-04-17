using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_ActivitySkillManagement : System.Web.UI.Page
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
                pan_new2.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                trsekill.Visible = false;
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
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


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
        //BindGrid();
        //pan_New.Attributes.CssStyle.Add("display", "none");
        gvSubjects.DataSource = null;
        gvSubjects.DataBind();
        pan_New.Attributes.CssStyle.Add("display", "none");
        gvSkillList.DataSource = null;
        gvSkillList.DataBind();
        pan_new2.Attributes.CssStyle.Add("display", "none");
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
        BLLActivity objClsSec = new BLLActivity();

        DataTable dtsub = new DataTable();

        objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        //////////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
        objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Activity_SelectAllByClassSubjectEvlCriteriaTypeId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvSubjects.DataSource = dtsub;
        }
        gvSubjects.DataBind();
        ViewState["tMood"] = "check";
        trSave.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindSkillGrid()
    {
        try
        {
        BLLActivity_Skill objClsSec = new BLLActivity_Skill();

        DataTable dtsub = new DataTable();

        objClsSec.Activity_Id = Convert.ToInt32(ViewState["ActivityValue"]);
        

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Activity_Skill_SelectAllByActivityId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvSkillList.DataSource = dtsub;
        }
        gvSkillList.DataBind();
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
        BLLActivity objClsSec = new BLLActivity();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;

        Result_GradeIdGe = ResultGradeValue;

        ViewState["ResultGrade"] = ResultGradeValue;


        objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        //////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
        objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
        objClsSec.Activity_Id = Convert.ToInt32(Result_GradeIdGe);


        dtsub = (DataTable)objClsSec.Activity_SelectAllByClassIdSubjectIdActivityId(objClsSec);

        //txtCritName.Text = dtsub.Rows[0]["Criteria"].ToString().Trim();
        txtMarks.Text = dtsub.Rows[0]["Activity"].ToString().Trim();
        txtGrade.Text = dtsub.Rows[0]["Weightage"].ToString().Trim();

        ViewState["currentWeightage"] = txtGrade.Text;

        list_EvlType.SelectedValue = dtsub.Rows[0]["Evaluation_Type_Id"].ToString().Trim();

        gvSkillList.DataSource = null;
        gvSkillList.DataBind();
        pan_new2.Attributes.CssStyle.Add("display", "none");

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
        BLLActivity objClsSec = new BLLActivity();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;


        ViewState["ResultGrade"] = ResultGradeValue;

        objClsSec.Activity_Id = Convert.ToInt32(ViewState["ResultGrade"]);

        AlreadyIn = objClsSec.ActivityDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        pan_New.Attributes.CssStyle.Add("display", "none");
        pan_new2.Attributes.CssStyle.Add("display", "none");
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnSkillEdit_Click(object sender, EventArgs e)
    {

        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "inline");
        BLLActivity_Skill objClsSec = new BLLActivity_Skill();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";

        ImageButton btn = (ImageButton)(sender);
        string ActivitySkillId = btn.CommandArgument;

        ViewState["ActivitySkillId"] = ActivitySkillId;


        objClsSec.Activity_Id = Convert.ToInt32(ViewState["ActivityValue"]);
        objClsSec.Activity_Skill_Id = Convert.ToInt32(ViewState["ActivitySkillId"]); ;






        dtsub = (DataTable)objClsSec.Activity_Skill_SelectAllValuesByActivityIdSkillId(objClsSec);


        txtSkillName.Text = dtsub.Rows[0]["Skill"].ToString().Trim();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void btnSkillDelete_Click(object sender, EventArgs e)
    {

        try
        {
        BLLActivity_Skill objClsSec = new BLLActivity_Skill();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ActivitySkillId = btn.CommandArgument;





        ViewState["ActivitySkillId"] = ActivitySkillId;

        objClsSec.Activity_Skill_Id = Convert.ToInt32(ViewState["ActivitySkillId"]);

        AlreadyIn = objClsSec.Activity_SkillDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        pan_New.Attributes.CssStyle.Add("display", "none");
        pan_new2.Attributes.CssStyle.Add("display", "none");
        BindSkillGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }




    protected void btnShowSkill_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btn = (ImageButton)(sender);
        string ActivityValue = btn.CommandArgument;
        ViewState["ActivityValue"] = ActivityValue;
        trsekill.Visible = true;
        BindSkillGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnSkillAdd_Click(object sender, EventArgs e)
    {
        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtSkillName.Text = "";

        ImageButton btn = (ImageButton)(sender);
        string ActivityValue = btn.CommandArgument;
        ViewState["ActivityValue"] = ActivityValue;
        trsekill.Visible = true;
        pan_New.Attributes.CssStyle.Add("display", "none");
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
        if (List_ClassSection.SelectedIndex > 0  && list_term.SelectedIndex > 0)
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        //txtCritName.Text = "";
        txtMarks.Text = "";
        list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        //txtUpperlimt.Text = "";
        //txtLowerlimt.Text = "";

        gvSkillList.DataSource = null;
        gvSkillList.DataBind();
        pan_new2.Attributes.CssStyle.Add("display", "none");

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

           
               
                int ActivityAlreadyIn = 0;
                DataTable dt = new DataTable();

                if (list_EvlType.SelectedIndex > 0 && txtMarks.Text != "" && txtGrade.Text != "")
            {

                BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();

                BLLActivity objactivity = new BLLActivity();



                DataTable dtsub = new DataTable();

                objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                //////////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
                objClsSec.Subject_Id = 4;
                objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
                objClsSec.Evaluation_Type_Id = Convert.ToInt32(list_EvlType.SelectedValue.ToString());


            ////// For activity paramaters

                objactivity.Activity_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                objactivity.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objactivity.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                ////////objactivity.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
                objactivity.Subject_Id = 4;
                objactivity.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());
                objactivity.Evaluation_Type_Id = Convert.ToInt32(list_EvlType.SelectedValue.ToString());
                objactivity.Activity = txtMarks.Text;
                objactivity.Weightage = Convert.ToDecimal(txtGrade.Text);

            ///////////////


                dtsub = (DataTable)objClsSec.GetCurrentWeightagePercentage(objClsSec);

                    decimal weightage = decimal.Parse(txtGrade.Text);
                    decimal currWeightage = decimal.Parse(ViewState["currentWeightage"].ToString());
                    decimal currentWeightage = decimal.Parse(dtsub.Rows[0]["currentWeightage"].ToString().Trim());
                    //if ((weightage + (currentWeightage - currWeightage)) > 100)
                    //{
                       

                    //    ImpromptuHelper.ShowPrompt("Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + " For " + list_term.SelectedItem.Text + " . Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString());
                    //    lblSave.Visible = true;
                    //    lblSave.Text = "Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + " For " + list_term.SelectedItem.Text + " . Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString();
                    //}
                    //else
                    {
                        string mode = Convert.ToString(ViewState["mode"]);

                        dt = (DataTable)objactivity.Activity_SelectAllByClassIdSubjectIdActivityId(objactivity);

                        if (mode != "Edit")
                        {
                            if (dt.Rows.Count == 0)
                            {
                                ActivityAlreadyIn = objactivity.ActivityAdd(objactivity);


                                ViewState["dtDetails"] = null;
                                if (ActivityAlreadyIn == 0)
                                {
                                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                    ////////pan_New.Attributes.CssStyle.Add("display", "none");

                                    ViewState["mode"] = "Add";
                                    BindGrid();
                                    txtMarks.Focus();

                                    txtGrade.Text = "";
                                    //txtCritName.Text = "";
                                    txtMarks.Text = "";
                                    list_EvlType.SelectedIndex = 0;
                                    trsekill.Visible = false;

                                    lblSave.Visible = true;
                                    lblSave.Text = "Record Saved Successfully";



                                }

                            }
                            else
                            {
                                ImpromptuHelper.ShowPrompt("Activity Name Already Exists.");
                                lblSave.Visible = true;
                                lblSave.Text = "Activity Name Already Exists.";

                            }
                           
                        }

                        else
                        {




                            ActivityAlreadyIn = objactivity.ActivityUpdate(objactivity);


                            ViewState["dtDetails"] = null;
                            if (ActivityAlreadyIn == 0)
                            {
                                ImpromptuHelper.ShowPrompt("Record successfully updated.");
                                pan_New.Attributes.CssStyle.Add("display", "none");
                                BindGrid();


                                lblSave.Visible = true;
                                lblSave.Text = "Record successfully updated.";


                            }


                        }


                    }
               

            //}
            }

                else
                {
                    ImpromptuHelper.ShowPrompt("Please Select Evaluation Type");
                    lblSave.Visible = true;
                    lblSave.Text = "Please Select Evaluation Type and Can't save blank value";
                }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void btnSkillSave_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();



            BLLActivity_Skill objClsSec = new BLLActivity_Skill();   



            DataTable dtsub = new DataTable();

            if ( txtSkillName.Text != "" )
            {

            objClsSec.Activity_Skill_Id = Convert.ToInt32(ViewState["ActivitySkillId"]);
            objClsSec.Activity_Id = Convert.ToInt32(ViewState["ActivityValue"]);
            objClsSec.Skill = txtSkillName.Text;
            string mode = Convert.ToString(ViewState["mode"]);

            dt = (DataTable)objClsSec.Activity_Skill_SelectToCheckExistingActivitySkillDescription(objClsSec);


            if (mode != "Edit")
            {
                if (dt.Rows.Count == 0)
                {
                    AlreadyIn = objClsSec.Activity_SkillAdd(objClsSec);


                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Skill was successfully added to this activity.");
                        ////////////pan_new2.Attributes.CssStyle.Add("display", "none");
                        ViewState["mode"] = "Add";
                        BindSkillGrid();
                        txtSkillName.Text = "";
                        txtSkillName.Focus();

                        lblSave.Visible = true;
                        lblSave.Text = "Skill was successfully added to this activity.";


                    }

                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Skill with this name already exists.");
                    lblSave.Visible = true;
                    lblSave.Text = "Skill with this name already exists.";

                }

            }
            else
            {


                AlreadyIn = objClsSec.Activity_SkillUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Skill was successfully updated to this activity.");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    BindSkillGrid();

                    lblSave.Visible = true;
                    lblSave.Text = "Skill was successfully updated to this activity.";

                }

            }

            }

                else
                {
                    ImpromptuHelper.ShowPrompt("Can't save balnk value");
                    lblSave.Visible = true;
                    lblSave.Text = "Can't save balnk value";
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

        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        //txtCritName.Text = "";
        txtMarks.Text = "";
        list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        //txtUpperlimt.Text = "";
        //txtLowerlimt.Text = "";

        gvSubjects.DataSource = null;
        gvSubjects.DataBind();
        gvSkillList.DataSource = null;
        gvSkillList.DataBind();
        pan_new2.Attributes.CssStyle.Add("display", "none");
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
        ////////pan_New.Attributes.CssStyle.Add("display", "none");
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        //txtCritName.Text = "";

        txtMarks.Text = "";
        list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        txtMarks.Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
   
    protected void btnCalnalSkill_Click(object sender, EventArgs e)
    {
        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "none");
        gvSkillList.SelectedRowStyle.Reset();

        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtGrade.Text = "";
        //txtCritName.Text = "";
        txtMarks.Text = "";
        list_EvlType.SelectedIndex = 0;
        ViewState["currentWeightage"] = "0";
        //txtUpperlimt.Text = "";
        //txtLowerlimt.Text = "";

        gvSkillList.DataSource = null;
        gvSkillList.DataBind();
        pan_new2.Attributes.CssStyle.Add("display", "none");
        lblSave.Text = "";

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    
}