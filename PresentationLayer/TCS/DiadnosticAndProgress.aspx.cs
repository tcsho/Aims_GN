using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class PresentationLayer_TCS_DiadnosticAndProgress : System.Web.UI.Page
{

    DALBase objBase = new DALBase();
    string QuestionId;
    BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
    BLLDiag_Prog objDP = new BLLDiag_Prog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                 
                lblSave.Text = "";
                FillClassSection();
                BindQuestionType();
                pan_New.Visible = false;
                pan_new2.Visible = false;
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
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
    protected void gvQuestions_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvQuestions.Rows.Count > 0)
            {
                gvQuestions.UseAccessibleHeader = false;
                gvQuestions.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvAnswerList_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvAnswerList.Rows.Count > 0)
            {
                gvAnswerList.UseAccessibleHeader = false;
                gvAnswerList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void FillClassSection()
    {
        FillSubject();
        try
        {

            objDPUnit.Subject_Id = Convert.ToInt16(ViewState["SubjectInfo"]);
            DataTable dtClass = objDPUnit.Diag_Prog_UnitSelectClassBySubject_Id(objDPUnit);
            objBase.FillDropDown(dtClass, ddlClass, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    //private void FillUnit()
    //{
    //    try
    //    {
    //        objDPUnit.Subject_Id = Convert.ToInt16(ViewState["SubjectInfo"]);
    //        objDPUnit.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
    //        objDPUnit.Evaluation_Criteria_Id = Convert.ToInt32(list_Term.SelectedValue);
    //        DataTable dt = objDPUnit.Diag_Prog_UnitFetch(objDPUnit);
    //        objBase.FillDropDown(dt, ddlUnit, "Unit_Id", "Unit_Description");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    private void FillSubject()
    {

        try
        {
            int user_id = Convert.ToInt32(Session["ContactID"]);
            DataTable dt = objDPUnit.Diag_Prog_UnitSelectSubjectByUser_Id(user_id);
            if (dt.Rows.Count > 0)
            {

                lblSubject.Text = dt.Rows[0]["Subject_Name"].ToString();
                ViewState["SubjectInfo"] = dt.Rows[0]["Subject_Id"].ToString();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            pan_New.Attributes.CssStyle.Add("display", "none");
            pan_new2.Attributes.CssStyle.Add("display", "none");

            BindTerm();
            //gvTopicList.DataSource = null;
            //gvTopicList.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();

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
            DataTable dtsub = new DataTable();
            objDP.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString().Trim());
            objDP.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"].ToString().Trim());
            objDP.Evaluation_Criteria_Type_Id = Convert.ToInt32(ViewState["EvalId"].ToString());

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objDP.Diag_ProgSelectAllByClassSubjectTermId(objDP);
                if (dtsub.Rows.Count > 0 && dtsub.Rows[0]["StatusCheck"].ToString() == "True")
                {
                    but_new.Visible = false;
                }
                else
                {
                    but_new.Visible = true;
                }

            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                lblSave.Text = "";
                divSection.Visible = true;
                gvQuestions.DataSource = dtsub;
            }
            else
            {
                gvQuestions.DataSource = null;
                lblSave.Text = "No Data to Display!";
                divSection.Visible = false;
            }
            gvQuestions.DataBind();
            ViewState["tMood"] = "check";
            ViewState["dtDetails"] = dtsub;
            //trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindQuestionGrid()
    {
        try
        {
            BLLDiag_Prog_Detail objClsSec = new BLLDiag_Prog_Detail();

            DataTable dtsub = new DataTable();
            objClsSec.DP_Id = Convert.ToInt32(ViewState["QuestionId"]);


            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Diag_Prog_DetailSelectAllByDPId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                divQuestion.Visible = true;
                lblSave.Text = "";
                gvAnswerList.DataSource = dtsub;
            }
            else
            {
                divQuestion.Visible = false;
                lblSave.Text = "No Questions found";
            }
            gvAnswerList.DataBind();
            ViewState["tMood"] = "check";
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
            BLLDiag_Prog_Detail obj = new BLLDiag_Prog_Detail();
            divQuestion.Visible = false;
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();

            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            ImageButton btn = (ImageButton)(sender);
            string QuestionIdValue = btn.CommandArgument;

            QuestionId = QuestionIdValue;

            ViewState["QuestionId"] = QuestionIdValue;
            objDP.DP_Id = Convert.ToInt32(QuestionId);
            obj.DP_Id = objDP.DP_Id;
            DataTable dt = obj.Diag_Prog_DetailSelectLockMarks(obj);

            dtsub = objDP.Diag_ProgSelectAllByDPId(objDP);
            if (dtsub.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0 && dt.Rows[0]["Is_Lock"].ToString() == "False")
                {
                    pan_New.Visible = true;
                    pan_New.Attributes.CssStyle.Add("display", "inline");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    //Topic.Visible = false;
                    BindTopic();
                    // ddlTopic.SelectedValue = dtsub.Rows[0]["Topic_Id"].ToString();   
                    txtSectionName.Text = dtsub.Rows[0]["Section_Name"].ToString();
                    // list_QuestionType.SelectedValue = dtsub.Rows[0]["Diag_Prog_Question_Type_Id"].ToString();
                }
                else if (dt.Rows.Count == 0)
                {
                    pan_New.Visible = true;
                    pan_New.Attributes.CssStyle.Add("display", "inline");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    //Topic.Visible = false;
                    BindTopic();
                    // ddlTopic.SelectedValue = dtsub.Rows[0]["Topic_Id"].ToString();   
                    txtSectionName.Text = dtsub.Rows[0]["Section_Name"].ToString();
                    // list_QuestionType.SelectedValue = dtsub.Rows[0]["Diag_Prog_Question_Type_Id"].ToString();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Sorry Marks are Locked");
                }
            }

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
            BLLDiag_Prog objClsSec = new BLLDiag_Prog();
            BLLDiag_Prog_Detail obj = new BLLDiag_Prog_Detail();
            int AlreadyIn = 0;

            ImageButton btn = (ImageButton)(sender);
            string QuestionIdValue = btn.CommandArgument;


            ViewState["QuestionId"] = QuestionIdValue;
            obj.DP_Id = Convert.ToInt32(QuestionIdValue);
            DataTable dt = obj.Diag_Prog_DetailSelectLockMarks(obj);
            if (dt.Rows.Count > 0 && dt.Rows[0]["Is_Lock"].ToString() == "False")
            {
                objClsSec.DP_Id = Convert.ToInt32(QuestionIdValue);

                AlreadyIn = objClsSec.Diag_ProgDelete(objClsSec);


                ViewState["dtDetails"] = null;

                ImpromptuHelper.ShowPrompt("Delete Record successfully");
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "none");
                BindGrid();
            }
            else if (dt.Rows.Count == 0)
            {
                objClsSec.DP_Id = Convert.ToInt32(QuestionIdValue);

                AlreadyIn = objClsSec.Diag_ProgDelete(objClsSec);


                ViewState["dtDetails"] = null;

                ImpromptuHelper.ShowPrompt("Delete Record successfully");
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "none");
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Sorry Marks are Locked");
            }
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
            BindTopic();


            BLLDiag_Prog_Detail objClsSec = new BLLDiag_Prog_Detail();

            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";

            ImageButton btn = (ImageButton)(sender);
            string QuestionDetailId = btn.CommandArgument;

            ViewState["QuestionDetailId"] = QuestionDetailId;
            objClsSec.DP_Id = Convert.ToInt32(ViewState["QuestionId"]);
            objClsSec.DPD_Id = Convert.ToInt32(ViewState["QuestionDetailId"]);

            dtsub = (DataTable)objClsSec.Diag_Prog_DetailSelectAllByDPDId(objClsSec);

            if (dtsub.Rows.Count > 0)
            {
                if (dtsub.Rows[0]["Is_Lock"].ToString().Trim() == "False")
                {
                    pan_new2.Visible = true;
                    pan_new2.Attributes.CssStyle.Add("display", "inline");
                    txtQuestion.Text = dtsub.Rows[0]["Question_Name"].ToString().Trim();
                    txtMarks.Text = dtsub.Rows[0]["Total_Marks"].ToString().Trim();
                    txtMarkPercentage.Text = dtsub.Rows[0]["Marks_Percentage"].ToString().Trim();
                    list_QuestionType.SelectedValue = dtsub.Rows[0]["Diag_Prog_Question_Type_Id"].ToString().Trim();
                    ddlTopic.SelectedValue = dtsub.Rows[0]["Topic_Id"].ToString();
                    txtMarks.Visible = true;
                    txtQuestion.Visible = true;
                    txtMarkPercentage.Visible = true;
                    list_QuestionType.Visible = true;
                    ddlTopic.Visible = true;
                     
                }
                else if (dtsub.Rows[0]["Is_Lock"].ToString().Trim() == "True")
                {
                    ImpromptuHelper.ShowPrompt("Sorry Your Marks are Locked ");
                    return;
                }
            }
            txtQuestion.Focus();

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
            BLLDiag_Prog_Detail objClsSec = new BLLDiag_Prog_Detail();
            int AlreadyIn = 0;

            ImageButton btn = (ImageButton)(sender);
            string DPDId = btn.CommandArgument;

            ViewState["DPDId"] = DPDId;

            objClsSec.DP_Id = Convert.ToInt32(ViewState["QuestionId"]);
            objClsSec.DPD_Id = Convert.ToInt32(ViewState["DPDId"]);
            DataTable dtsub = (DataTable)objClsSec.Diag_Prog_DetailSelectAllByDPDId(objClsSec);

            if (dtsub.Rows.Count > 0)
            {
                if (dtsub.Rows[0]["Is_Lock"].ToString().Trim() == "False")
                {

                    AlreadyIn = objClsSec.Diag_Prog_DetailDelete(objClsSec);
                    ViewState["dtDetails"] = null;

                    ImpromptuHelper.ShowPrompt("Delete Record successfully");
                    pan_New.Attributes.CssStyle.Add("display", "none");
                    pan_new2.Attributes.CssStyle.Add("display", "none");
                    BindQuestionGrid();
                    BindGrid();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Sorry Marks are Locked");
                }

            }
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
            //Topic.Visible = false;

            pan_New.Attributes.CssStyle.Add("display", "none");
            pan_new2.Attributes.CssStyle.Add("display", "none");
            ImageButton btn = (ImageButton)(sender);
            string QuestionId = btn.CommandArgument;
            ViewState["QuestionId"] = QuestionId;
            ViewState["dtDetails"] = null;
            BindQuestionGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void BindEvaluationCriteria()
    {
        //try
        //{
        //if (ddlClass.SelectedIndex > 0 && list_Subject.SelectedIndex > 0 && list_Term.SelectedIndex > 0)
        //{
        //    BLLEvaluation_Criteria obj = new BLLEvaluation_Criteria();

        //    obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());
        //    obj.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
        //    obj.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
        //    DataTable dt = obj.Evaluation_CriteriaSelectBYClassSubjectEvlID(obj);

        //    if (dt.Rows.Count > 0)
        //    {


        //        objBase.FillDropDown(dt, list_EvlCriteria, "Evaluation_Criteria_Id", "Criteria");

        //    }
        //}
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }
    protected void btnAnswerAdd_Click(object sender, EventArgs e)
    {
        try
        {
            divQuestion.Visible = false;
            BLLDiag_Prog_Detail objClsSec = new BLLDiag_Prog_Detail();

            ViewState["mode"] = "Add";
            ImageButton btn = (ImageButton)(sender);
            ViewState["QuestionId"] = btn.CommandArgument;
            list_QuestionType.SelectedIndex = 0;

            objClsSec.DP_Id = Convert.ToInt32(ViewState["QuestionId"].ToString());
            DataTable dtsub = objClsSec.Diag_Prog_DetailSelectAllByDPId(objClsSec);
            int sum = 0;
            foreach (GridViewRow r in gvQuestions.Rows)
            {
                sum= sum+Convert.ToInt32(r.Cells[3].Text);
            }
            sum = sum + 1;
            if (dtsub == null || dtsub.Rows.Count == 0) //for the very first entry
            {
                //Topic.Visible = false;
                BindTopic();
                if (ddlTopic.SelectedIndex > 0)
                {
                    ddlTopic.SelectedIndex = 0;
                }
                pan_new2.Visible = true;
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "inline");

                txtQuestion.Text = "Q."+sum.ToString();
                txtMarks.Text = "10";
                txtMarkPercentage.Text = "10";
                list_QuestionType.SelectedIndex = 1;
               // ddlTopic.SelectedIndex = 1;

            }
            else if (dtsub.Rows.Count > 0 && dtsub.Rows[0]["Is_Lock"].ToString().Trim() == "False")
            {
                //Topic.Visible = false;
                BindTopic();
                if (ddlTopic.SelectedIndex > 0)
                {
                    ddlTopic.SelectedIndex = 0;
                }
                pan_new2.Visible = true;
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "inline");
                txtQuestion.Text = "Q." + sum.ToString();
                txtMarks.Text = "10";
                txtMarkPercentage.Text = "10";
                list_QuestionType.SelectedIndex = 1;
                ddlTopic.SelectedIndex = 1;
            }
            else if (dtsub.Rows[0]["Is_Lock"].ToString().Trim() == "True")
            {
                //Topic.Visible = false;
                pan_new2.Visible = false;
                pan_New.Attributes.CssStyle.Add("display", "none");
                pan_new2.Attributes.CssStyle.Add("display", "none");
                ImpromptuHelper.ShowPrompt("Sorry Your Marks have been locked!");
            }
            txtQuestion.Focus();
            // trsection.Visible = false;
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
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

            if (ddlClass.SelectedIndex > 0 && list_Term.SelectedIndex > 0)
            {
                pan_New.Visible = true;
                pan_New.Attributes.CssStyle.Add("display", "inline");
                ViewState["mode"] = "Add";
                txtSectionName.Text = "";
                BindTopic();
                //FillUnit();
                BindQuestionType();
                ViewState["currentWeightage"] = "0";

                gvAnswerList.DataSource = null;
                gvAnswerList.DataBind();

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
    protected void BindTopic()
    {

        try
        {
            DataTable dt = new DataTable();
            objDP.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            objDP.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"]);
            objDP.Evaluation_Criteria_Type_Id = Convert.ToInt32(ViewState["EvalId"].ToString());
            dt = objDP.Diag_ProgSelectTopic(objDP);

            if (dt.Rows.Count > 0)
            {

                objBase.FillDropDown(dt, ddlTopic, "Topic_Id", "Topic_Description");
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

            ViewState["dtDetails"] = null;
            int QuestionAlreadyIn = 0;
            DataTable dt = new DataTable();
            DataTable dtsub = new DataTable();

            if (txtSectionName.Text != "")
            {

                objDP.DP_Id = Convert.ToInt32(ViewState["QuestionId"]);
                objDP.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objDP.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"]);
                objDP.Evaluation_Criteria_Type_Id = Convert.ToInt32(ViewState["EvalId"].ToString());
                objDP.Section_Name = txtSectionName.Text;
                objDP.Evaluation_Criteria_Id = Convert.ToInt32(ViewState["EvalCriteria"]);
                //objDP.Diag_Prog_Question_Type_Id = Convert.ToInt32(list_QuestionType.SelectedValue.ToString());
                objDP.Unit_Id = 0;
                ViewState["dtDetails"] = null;
                string mode = Convert.ToString(ViewState["mode"]);

                if (mode != "Edit")
                {

                    objDP.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    QuestionAlreadyIn = objDP.Diag_ProgAdd(objDP);

                    if (QuestionAlreadyIn == 0)
                    {
                        ViewState["dtDetails"] = null;
                        //ImpromptuHelper.ShowPrompt("Record was successfully added.");
                        pan_New.Attributes.CssStyle.Add("display", "inline");
                        BindGrid();
                    }


                }

                else
                {

                    objDP.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    QuestionAlreadyIn = objDP.Diag_ProgUpdate(objDP);

                    if (QuestionAlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Record successfully updated.");
                        pan_New.Attributes.CssStyle.Add("display", "none");
                        BindGrid();

                    }


                }
            }

            else
            {
                ImpromptuHelper.ShowPrompt("Can't Save balnk Values!");
            }
            but_cancel_Click(this, EventArgs.Empty);
        }




        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }


    }
    protected void btnAnswerSave_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();
            BLLDiag_Prog_Detail objClsSec = new BLLDiag_Prog_Detail();
            DataTable dtsub = new DataTable();


            if (txtQuestion.Text != "" && txtMarks.Text != "" && ddlTopic.SelectedIndex > 0 && list_QuestionType.SelectedIndex > 0)
            {

                objClsSec.DP_Id = Convert.ToInt32(ViewState["QuestionId"]);
                objClsSec.DPD_Id = Convert.ToInt32(ViewState["QuestionDetailId"]); ;
                objClsSec.Question_Name = txtQuestion.Text;
                objClsSec.Total_Marks = Convert.ToInt32(txtMarks.Text.ToString());
                //objClsSec.Marks_Percentage = Convert.ToDecimal(txtMarkPercentage.Text.ToString());
                objClsSec.Marks_Percentage = 10;
                objClsSec.Status_Id = 1;
                objClsSec.Diag_Prog_Question_Type_Id = Convert.ToInt32(list_QuestionType.SelectedValue);
                objClsSec.Topic_Id = Convert.ToInt16(ddlTopic.SelectedValue);
                objClsSec.Seq_Id=Convert.ToInt32(txtQuestion.Text.Replace("Q.",""));
                string mode = Convert.ToString(ViewState["mode"]);

                if (mode != "Edit")
                {

                    objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    objClsSec.CreatedOn = DateTime.Now;


                    AlreadyIn = objClsSec.Diag_Prog_DetailAdd(objClsSec);


                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Question was successfully added to this Section.");
                        pan_new2.Attributes.CssStyle.Add("display", "none");
                        BindQuestionGrid();

                        BindGrid();


                    }

                }
                else
                {

                    objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    objClsSec.ModifiedOn = DateTime.Now;



                    AlreadyIn = objClsSec.Diag_Prog_DetailUpdate(objClsSec);


                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Question was successfully updated to this Section.");
                        pan_new2.Attributes.CssStyle.Add("display", "none");
                        BindQuestionGrid();
                        BindGrid();

                    }

                }


            }
            else
            {
                ImpromptuHelper.ShowPrompt("Can't Save balnk Values!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
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
            BindTerm();

            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            pan_New.Attributes.CssStyle.Add("display", "none");

            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            pan_new2.Attributes.CssStyle.Add("display", "none");
            //trsection.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    protected void gvQuestions_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //if (ddlClass.SelectedValue != "0")
        //{
        //    BindGrid();
        //    pan_New.Attributes.CssStyle.Add("display", "none");
        //}
        //else
        //{
        //    gvQuestions.DataSource = null;
        //    gvQuestions.DataBind();
        //    pan_New.Attributes.CssStyle.Add("display", "none");
        //}
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}


    }
    protected void listAnswOption_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public DataTable SearchRecordsDT(string Col1, DataTable RecordDT_, String KeyWORD)
    {
        DataTable TempTable = RecordDT_;
        DataView DV = new DataView(TempTable);
        DV.RowFilter = string.Format(string.Format("Convert({0},'System.String')", Col1) + " LIKE '{0}'", KeyWORD);
        return DV.ToTable();
    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            String s = list_Term.SelectedItem.Text.Trim();
            objDP.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString().Trim());
            objDP.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"].ToString());
            objDP.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());

            DataTable dt = objDP.Diag_ProgSelectEvalCriteriaId(objDP);
            if (dt.Rows.Count > 0)
            {
              
                lblEvalCriteria.Text = dt.Rows[0]["Criteria"].ToString().Trim();
                ViewState["EvalCriteria"] = dt.Rows[0]["Evaluation_Criteria_Id"].ToString().Trim();

            }
                        
            ViewState["EvalId"] = list_Term.SelectedValue.ToString();
            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    private void BindTerm()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            ObjECT.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);
            if (dt.Rows.Count > 0)
            {

                objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindQuestionType()
    {
        try
        {
            DataTable dt = null;
            BLLDiag_Prog ObjECT = new BLLDiag_Prog();
            //ObjECT.Class_Id = Convert.ToInt32(list_Class.SelectedValue);
            dt = ObjECT.Diag_Prog_Question_TypeSelectAll(ObjECT);
            if (dt.Rows.Count > 0)
            {

                objBase.FillDropDown(dt, list_QuestionType, "Diag_Prog_Question_Type_Id", "Question_Type");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAddTopic_Click(object sender, EventArgs e)
    {
        ViewState["mode"] = "Add";
        ImageButton btn = (ImageButton)(sender);
        BLLDiag_Prog_Detail obj = new BLLDiag_Prog_Detail();
        obj.DP_Id = Convert.ToInt32(btn.CommandArgument);
        ViewState["DP_Id"] = obj.DP_Id;
        DataTable dt = obj.Diag_Prog_DetailSelectLockMarks(obj);
        if (dt.Rows.Count == 0)
        {
            //Topic.Visible = true;
            pan_New.Visible = false;
            pan_new2.Visible = false;
            //trTopic.Visible = true;
            ViewState["TopicDetails"] = null;
            BindTopic();
            BindTopicGrid();
        }
        if (dt.Rows.Count > 0 && dt.Rows[0]["Is_Lock"].ToString() == "False")
        {
            //Topic.Visible = true;
            pan_New.Visible = false;
            pan_new2.Visible = false;
            //trTopic.Visible = true;


            ViewState["TopicDetails"] = null;
            BindTopic();
            BindTopicGrid();
        }

        else if (dt.Rows.Count > 0 && dt.Rows[0]["Is_Lock"].ToString() == "True")
        {
            ImpromptuHelper.ShowPrompt("Sorry Marks are Locked");
        }

    }
    protected void TopicSave_Click(object sender, EventArgs e)
    {
        BLLDiag_Prog_Topic obj = new BLLDiag_Prog_Topic();
        obj.Topic_Id = Convert.ToInt32(ddlTopic.SelectedValue.ToString());
        String s = ViewState["mode"].ToString();
        if (s == "Add")
        {
            obj.DP_ID = Convert.ToInt32(ViewState["DP_Id"].ToString());
            int k = obj.Diag_Prog_TopicAdd(obj);
            if (k == 0)
            {
                ImpromptuHelper.ShowPrompt("Record Saved!");
            }
        }
        else
        {
            obj.DP_Topic_ID = Convert.ToInt32(ViewState["DP_Topic_Id"].ToString());
            obj.Diag_Prog_TopicUpdate(obj);
        }
        ViewState["TopicDetails"] = null;
        //Topic.Visible = false;
        BindTopicGrid();

    }
    protected void BindTopicGrid()
    {
        BLLDiag_Prog_Topic obj = new BLLDiag_Prog_Topic();
        obj.DP_ID = Convert.ToInt32(ViewState["DP_Id"].ToString());
        DataTable dtsub = new DataTable();
        //        ViewState["TopicDetails"] = dtsub;

        if (ViewState["TopicDetails"] == null)
        {
            dtsub = obj.Diag_Prog_TopicSelectTopicDetails(obj);

        }
        else
        {
            dtsub = (DataTable)ViewState["TopicDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            //gvTopicList.DataSource = dtsub;
        }
        //gvTopicList.DataBind();
        ViewState["tMood"] = "check";
        ViewState["TopicDetails"] = dtsub;
        //trSave.Visible = true;

    }
    protected void btnTopicCancel_Click(object sender, EventArgs e)
    {
        try
        {
            //Topic.Attributes.CssStyle.Add("display", "none");
            gvQuestions.SelectedRowStyle.Reset();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnShowTopic_Click(object sender, EventArgs e)
    {
        //trTopic.Visible = true;
        pan_new2.Visible = false;
        pan_New.Visible = false;
        //Topic.Visible = false;
        ViewState["TopicDetails"] = null;
        ImageButton btn = (ImageButton)(sender);
        ViewState["DP_Id"] = btn.CommandArgument;
        BindTopicGrid();
    }
    protected void btnTopicEdit_Click(object sender, EventArgs e)
    {
        try
        {
            BLLDiag_Prog_Topic obj = new BLLDiag_Prog_Topic();

            ImageButton btn = (ImageButton)(sender);
            ViewState["DP_Topic_Id"] = btn.CommandArgument;

            pan_New.Visible = false;
            pan_new2.Attributes.CssStyle.Add("display", "none");
            //Topic.Visible = true;    
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            obj.DP_Topic_ID = Convert.ToInt16(ViewState["DP_Topic_Id"]);
            dtsub = obj.Diag_Prog_TopicSelectTopic(obj);
            if (dtsub.Rows.Count > 0)
            {
                DataTable dt = obj.Diag_Prog_TopicCheckLockMarks(obj);
                if (dt.Rows[0]["Is_Lock"].ToString().Trim() == "False")
                {
                    BindTopic();
                    ddlTopic.SelectedValue = dtsub.Rows[0]["Topic_Id"].ToString();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Marks are locked!");
                }

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnTopicDelete_Click(object sender, EventArgs e)
    {
        BLLDiag_Prog_Topic obj = new BLLDiag_Prog_Topic();

        ImageButton btn = (ImageButton)(sender);
        ViewState["DP_Topic_Id"] = btn.CommandArgument;
        obj.DP_Topic_ID = Convert.ToInt16(ViewState["DP_Topic_Id"]);
        DataTable dt = obj.Diag_Prog_TopicCheckLockMarks(obj);
        if (dt.Rows[0]["Is_Lock"].ToString().Trim() == "False")
        {
            obj.Diag_Prog_TopicDelete(obj);
            ViewState["TopicDetails"] = null;
            BindTopicGrid();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Marks are locked!");
        }
    }
    protected void btnLockMarks_Click(object sender, EventArgs e)
    {
        ImageButton btn = (ImageButton)(sender);
        but_new.Visible = false;
        ViewState["DP_Id"] = btn.CommandArgument;
        BLLDiag_Prog_Detail obj = new BLLDiag_Prog_Detail();
        obj.DP_Id = Convert.ToInt32(ViewState["DP_Id"].ToString());
        int k = obj.Diag_Prog_DetailLockMarks(obj);
        if (k == 0)
        {
            ImpromptuHelper.ShowPrompt("You have successfully locked the marks ");


        }
        else
        {
            ImpromptuHelper.ShowPrompt("Transaction Unsuccessful ");
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["Subject"] = ViewState["SubjectInfo"].ToString();
        Session["Class"] = ddlClass.SelectedValue;
        Session["Term"] = list_Term.SelectedValue;
        if (ViewState["EvalId"] != null)
        {
            Session["Eval"] = Convert.ToInt32(ViewState["EvalId"].ToString()); Response.Redirect("Report.aspx");
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select the options!");
        }

    }
}