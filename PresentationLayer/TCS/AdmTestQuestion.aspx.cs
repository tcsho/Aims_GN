using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_AdmTestQuestion : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string QuestionId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillAdmTest();
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "none");
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

    private void FillAdmTest()
    {
        try
        {
        lblSave.Text = "";
        BLLAdmTest obj = new BLLAdmTest();

        DataTable dt = (DataTable)obj.AdmTestFetch(obj);

        objBase.FillDropDown(dt, list_AdmTest, "AdmTest_Id", "Title");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    private void FillAdmTestDetailClassWise()
    {
        try
        {
        lblSave.Text = "";
        BLLAdmTestDetail obj = new BLLAdmTestDetail();

        obj.AdmTest_Id = Convert.ToInt32(list_AdmTest.SelectedValue);

        DataTable dt = (DataTable)obj.AdmTestDetailSelectAllByAdmTest_Id(obj);

        objBase.FillDropDown(dt, list_AdmTestDetail, "AdmTestDetail_Id", "AdmTestDesc");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BindAnswerOption()
    {
        try
        {
        DataTable dt = null;
        BLLAdmTestAnswerOptions ObjECT = new BLLAdmTestAnswerOptions();
        dt = ObjECT.AdmTestAnswerOptionsFetch(ObjECT);
        objBase.FillDropDown(dt, listAnswOption, "AnswerOption_ID", "AnswerOptionDesc");

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
        FillAdmTestDetailClassWise();
        BindAnswerOption();

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
        BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();

        DataTable dtsub = new DataTable();

        
        //objClsSec.AdmTestDetail_Id = Convert.ToInt32(list_AdmTestDetail.SelectedValue.ToString());
        
        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.AdmTestQuestionsSelectAllByAdmTestDetailId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvQuestions.DataSource = dtsub;
        }
        gvQuestions.DataBind();
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
        BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();

        DataTable dtsub = new DataTable();

        objClsSec.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);
        

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.AdmTestQuestionsDetailSelectAllByQuestId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvAnswerList.DataSource = dtsub;
        }
        gvAnswerList.DataBind();
        ViewState["tMood"] = "check";
        trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

    }

    
   

    protected void gvSubjects_Sorting(object sender, GridViewSortEventArgs e)
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
    
    




    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string QuestionIdValue = btn.CommandArgument;

        QuestionId = QuestionIdValue;

        ViewState["QuestionId"] = QuestionIdValue;


        
        //objClsSec.AdmTestDetail_Id = Convert.ToInt32(list_AdmTestDetail.SelectedValue.ToString());
        objClsSec.Quest_ID = Convert.ToInt32(QuestionId);


        dtsub = (DataTable)objClsSec.AdmTestQuestionsSelectAllByAdmTestDetailIdQuestId(objClsSec);

        txtQuestion.Text = dtsub.Rows[0]["QuestText"].ToString().Trim();
        txtComments.Text = dtsub.Rows[0]["Comments"].ToString().Trim();
        txtPValue.Text = dtsub.Rows[0]["AnsPointValue"].ToString().Trim();
        txtNValue.Text = dtsub.Rows[0]["NegtvPointValue"].ToString().Trim();
        txtAnsInSec.Text = dtsub.Rows[0]["TimeInSeconds"].ToString().Trim();



        ViewState["currentWeightage"] = txtPValue.Text;

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
        BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string QuestionIdValue = btn.CommandArgument;


        ViewState["QuestionId"] = QuestionIdValue;

        objClsSec.Quest_ID = Convert.ToInt32(QuestionIdValue);

        AlreadyIn = objClsSec.AdmTestQuestionsDelete(objClsSec);


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

    protected void btnAnswerEdit_Click(object sender, EventArgs e)
    {
        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "inline");
        BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";

        ImageButton btn = (ImageButton)(sender);
        string QuestionDetailId = btn.CommandArgument;

        ViewState["QuestionDetailId"] = QuestionDetailId;


        objClsSec.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);
        objClsSec.QuestDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]); ;

        dtsub = (DataTable)objClsSec.AdmTestQuestionsDetailSelectAllByQuestIdDetailId(objClsSec);


        txtAnswer.Text = dtsub.Rows[0]["Options"].ToString().Trim();
        listAnswOption.SelectedValue = dtsub.Rows[0]["AnswerOption_ID"].ToString().Trim();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }





    }

    protected void btnAnswerDelete_Click(object sender, EventArgs e)
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




    protected void btnShowAnswer_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btn = (ImageButton)(sender);
        string QuestionId = btn.CommandArgument;
        ViewState["QuestionId"] = QuestionId;
        BindSkillGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnAnswerAdd_Click(object sender, EventArgs e)
    {
        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtAnswer.Text = "";

        ImageButton btn = (ImageButton)(sender);
        string QuestionId = btn.CommandArgument;
        ViewState["QuestionId"] = QuestionId;

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
        if (list_AdmTest.SelectedIndex > 0 && list_AdmTestDetail.SelectedIndex > 0 )
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtPValue.Text = "";
        txtComments.Text = "";
        txtPValue.Text = "";
        txtNValue.Text = "";
        txtAnsInSec.Text = "";
        txtQuestion.Text = "";
        ViewState["currentWeightage"] = "0";
        

        }

        else
        {
            ImpromptuHelper.ShowPrompt("Please select Test Name and Detail!");
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
                BLLAdmTestQuestions objactivity = new BLLAdmTestQuestions();
                DataTable dtsub = new DataTable();


            ////// For activity paramaters

                objactivity.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);
                //objactivity.AdmTestDetail_Id = Convert.ToInt32(list_AdmTestDetail.SelectedValue.ToString());
                objactivity.QuesText = txtQuestion.Text;
                objactivity.Comments = txtComments.Text;
                objactivity.AnsPointValue = Convert.ToDecimal(txtPValue.Text);
                objactivity.NegtvPointValue = Convert.ToDecimal(txtNValue.Text);
                objactivity.TimeInSeconds = Convert.ToInt32(txtAnsInSec.Text);
                objactivity.Status_ID = 1;
                objactivity.QuestType_ID = 1;
                string mode = Convert.ToString(ViewState["mode"]);

                        

                        if (mode != "Edit")
                        {
                            
                                ActivityAlreadyIn = objactivity.AdmTestQuestionsAdd(objactivity);


                                ViewState["dtDetails"] = null;
                                if (ActivityAlreadyIn == 0)
                                {
                                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                    pan_New.Attributes.CssStyle.Add("display", "none");
                                    BindGrid();

                                }

                            
                           
                        }

                        else
                        {

                            ActivityAlreadyIn = objactivity.AdmTestQuestionsUpdate(objactivity);
                            ViewState["dtDetails"] = null;
                            if (ActivityAlreadyIn == 0)
                            {
                                ImpromptuHelper.ShowPrompt("Record successfully updated.");
                                pan_New.Attributes.CssStyle.Add("display", "none");
                                BindGrid();

                            }


                        }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void btnAnswerSave_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();



            BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();   



            DataTable dtsub = new DataTable();


            objClsSec.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);
            objClsSec.QuestDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]); ;
            objClsSec.Options = txtAnswer.Text;
            //objClsSec.AnswerOption_ID = Convert.ToInt32(listAnswOption.SelectedValue.ToString());

            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {
                    AlreadyIn = objClsSec.AdmTestQuestionsDetailAdd(objClsSec);


                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Answer was successfully added to this Question.");
                        pan_new2.Attributes.CssStyle.Add("display", "none");
                        BindSkillGrid();

                    }

               
            }
            else
            {


                AlreadyIn = objClsSec.AdmTestQuestionsDetailUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Answer was successfully updated to this Question.");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    BindSkillGrid();

                }

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
        gvQuestions.SelectedRowStyle.Reset();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        
    }
    
    protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
    protected void gvSubjects_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {

            txtPValue.Text = gvQuestions.Rows[e.NewSelectedIndex].Cells[4].Text;
            ViewState["currentWeightage"] = txtPValue.Text;
            ViewState["mode"] = "Edit";
            ViewState["EditID"] = gvQuestions.Rows[e.NewSelectedIndex].Cells[0].Text;
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
        if (list_AdmTestDetail.SelectedValue != "0")
        {
            BindGrid();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        else
        {
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        
    }

    
    protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();
        pan_New.Attributes.CssStyle.Add("display", "none");

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
    protected void btnCalnalSkill_Click(object sender, EventArgs e)
    {
        try
        {
        pan_new2.Attributes.CssStyle.Add("display", "none");
        gvAnswerList.SelectedRowStyle.Reset();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_AdmTestDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGrid();
        pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvQuestions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (list_AdmTestDetail.SelectedValue != "0")
        {
            BindGrid();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        else
        {
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        
    }
    protected void gvQuestions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {


    }
    protected void gvQuestions_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void listAnswOption_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}