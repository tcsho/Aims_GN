using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_AdmTestConfiguration : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    BLLAdmTest obj = new BLLAdmTest();
    BLLAdmTestDetail objDetail = new BLLAdmTestDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        if (!IsPostBack)
        {
            try
            {
                //======== Page Access Settings ========================
                //DALBase objBase = new DALBase();
                //DataRow row = (DataRow)Session["rightsRow"];
                //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                //string sRet = oInfo.Name;


                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //====== End Page Access settings ======================
                FillActiveSessions();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }
    protected void FillTestType()
    {
        try
        {
            DataTable dt = obj.AdmTestFetchTestType(obj);
            chkTestType.DataSource = dt;
            chkTestType.DataTextField = "Description";
            chkTestType.DataValueField = "TestType_Id";
            chkTestType.DataBind();
            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);

           dt = obj.AdmTestFetchTestType(obj);
            //objBase.FillDropDown(dt, ddlTestType, "TestType_Id", "Description");
            
            if (dt.Rows.Count == 1)
            {
                btnDeleteTest.Visible = true;
                btnAddTest.Visible = false; 
                chkTestType.SelectedValue = dt.Rows[0]["TestType_Id"].ToString();
                chkTestType_SelectedIndexChanged(this, EventArgs.Empty);
                chkTestType.Enabled = false;
                
            }
            else
            {
                if (chkTestType.Enabled == true)
                {
                    btnDeleteTest.Visible = false;
                    btnAddTest.Visible = true;
                }
                chkTestType.Enabled = true;
            }
            chkTestType.DataSource = dt;
            chkTestType.DataTextField = "Description";
            chkTestType.DataValueField = "TestType_Id";
            chkTestType.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillPool()
    {
        try
        {
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
            DataTable dt = new DataTable();
            obj.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
            dt = obj.AdmTestQuestionsPoolFetch(obj.AdmTestDetail_Id);
            //objBase.FillDropDown(dt, ddlPool, "Pool_Id", "Description");

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
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 14).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";
            clearControls();
            if (ddlClass.SelectedIndex > 0 && chkTestType.SelectedIndex>-1)
            {
                //tblAddTest.Visible = true;
                chkTestType.Enabled = false; 
                ViewState["Mode"] = "Add";
                btnSave_Click(this, EventArgs.Empty);
                tdGridHeader.Visible = true;
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Class");
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteTest_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            if (ddlClass.SelectedIndex > 0)
            {
                ViewState["Mode"] = "Delete";
                //tblAddTest.Visible = true;
                BLLAdmTest obj = new BLLAdmTest();
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                int k= obj.AdmTestDelete(obj);
                ViewState["Data"] = null;
                gvTest.DataSource = null;
                gvTest.DataBind();
                gvPool.DataSource = null;
                gvPool.DataBind();
                gvQuestions.DataSource=null;
                gvQuestions.DataBind();
                gvAnswerList.DataSource = null;
                gvAnswerList.DataBind();
                tdGridHeader.Visible = false;
                trViewAnswer.Visible=false;
                trViewQuestion.Visible = false;
                trViewPool.Visible = false;
                FillTestType();
                chkTestType.Enabled = true;
                chkTestType.SelectedIndex = -1;

                BindGrid();
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Class and a Test Type First");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvAnswerList_Prerender(object sender, EventArgs e)
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
    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvTest.Rows.Count > 0)
            {
                gvTest.UseAccessibleHeader = false;
                gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvPool_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvPool.Rows.Count > 0)
            {
                gvPool.UseAccessibleHeader = false;
                gvPool.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            panAddQuestion.Visible = false;
            BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();
        

            ImageButton btnEdit = (ImageButton)(sender);
            objClsSec.Pool_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["Pool_Id"] = objClsSec.Pool_Id;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            BindQuestion();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void BindQuestion()
    {
        try
        {
            BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();
            DataTable dtsub = new DataTable();
            objClsSec.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"].ToString());
            dtsub = (DataTable)objClsSec.AdmTestQuestionsSelectAllByAdmTestDetailId(objClsSec);

            if (dtsub.Rows.Count > 0)
            {
                gvQuestions.DataSource = dtsub;
                trViewQuestion.Visible = true;
            }
            else
            {
                trViewQuestion.Visible = false;
                //ImpromptuHelper.ShowPrompt("No Questions yet specified for this admission test");
            }
             
            gvQuestions.DataBind();
            ViewState["tMood"] = "check";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnEdit = (ImageButton)(sender);
            objDetail.Pool_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["Pool_Id"] = objDetail.Pool_Id;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            if (Convert.ToDecimal(gvr.Cells[4].Text) > 0)
            {
                imgAnswer.Visible = true;
                ViewState["Mode"] = "AddQuestion";
                panAddQuestion.Visible = true;
                trViewQuestion.Visible = false;
                gvQuestions.DataSource = null;
                gvQuestions.DataBind();
                lblName.Text = gvr.Cells[1].Text;
                lblPooldesc.Text = gvr.Cells[2].Text;
                txtPValue.Enabled = false;
                txtPValue.Text = gvr.Cells[4].Text;
                lblTName.Visible = true;
                lblName.Visible = true;
                btnCancelAnswer_Click(this, EventArgs.Empty);
                trViewQuestion.Visible = false;
                trViewAnswer.Visible = false;

                txtAddAnswer.Visible = true;
                lblAnnswer.Visible = true;
                txtAddAnswer.TextMode = TextBoxMode.MultiLine;
                txtAddAnswer.Rows = 5;
                txtAddAnswer.MaxLength = 500;
                txtAddAnswer.Text = "";
                divPool.Visible = false;
                txtQuestion.Text = "";
                txtComments.Text = "";
                txtNValue.Text = "";
            }
            else
                ImpromptuHelper.ShowPrompt("Please Update Pool Configuration");
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
            if (chkTestType.SelectedValue == "1" || chkTestType.SelectedValue == "2")//1->Adaptive and 2->Non-Adaptive
                txtMarks.Enabled = false;
            txtQuestion.Focus();
            tblAddTest.Visible = true;
            ViewState["Mode"] = "Edit";
            ImageButton btnEdit = (ImageButton)(sender);
            obj.AdmTest_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["AdmTest_Id"] = obj.AdmTest_Id;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            txtOpening.Text = gvr.Cells[6].Text;
            txtClosing.Text = gvr.Cells[7].Text;
            txtTestName.Text = gvr.Cells[5].Text;
            txtTestDesc.Text = gvr.Cells[9].Text;
            txtMarks.Text = gvr.Cells[11].Text;
           
            txtTotal.Text = gvr.Cells[13].Text;

            ViewState["AdmTestDetail_Id"] = gvr.Cells[3].Text;
            btnCancelAnswer_Click(this, EventArgs.Empty);
            btnCancelQuestion_Click(this, EventArgs.Empty);
            divPool.Visible = false;
            panAddQuestion.Visible = false;
            trViewAnswer.Visible = false;
            trViewQuestion.Visible = false;
            trViewPool.Visible = false;
            gvPool.DataSource = null;
            gvPool.DataBind();
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
    protected void btnEditQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            panAddQuestion.Visible = true;
            ViewState["Mode"] = "EditQuestion";
            ImageButton btnEdit = (ImageButton)(sender);
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions();
            obj.Quest_ID = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["Quest_ID"] = obj.Quest_ID;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            txtQuestion.Focus();
            imgAnswer.Visible = false;

            txtQuestion.Text = gvr.Cells[3].Text;
            txtPValue.Text = gvr.Cells[4].Text;
            txtNValue.Text = gvr.Cells[5].Text;
            txtComments.Text = gvr.Cells[6].Text;
            txtAnsInSec.Text = gvr.Cells[7].Text;
            ViewState["AdmTestDetail_Id"] = gvr.Cells[1].Text;
            lblTName.Visible = false;
            lblName.Visible = false;
            lblPooldesc.Text = gvr.Cells[12].Text;
            trViewAnswer.Visible = false;
            lblAnnswer.Visible = false;
            txtAddAnswer.Visible = false; 
            FillPool();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            panAddQuestion.Visible = false;
            ViewState["Mode"] = "DeleteQuestion";
            ImageButton btnEdit = (ImageButton)(sender);
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions();
            obj.Quest_ID = Convert.ToInt32(btnEdit.CommandArgument);
            int AlreadyIn = obj.AdmTestQuestionsDelete(obj);
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Deleted");

            }
          
            ViewState["Data"] = null;
            BindGrid();
            trViewAnswer.Visible = false;
            BindQuestion();

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
            BindAnswerGrid();
            trAddAnswer.Visible = false;
            panAddQuestion.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancelAnswer_Click(object sender, EventArgs e)
    {
        try
        {
            trViewAnswer.Visible = true;
            trAddAnswer.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindAnswerGrid()
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
                trViewAnswer.Visible = true;
                gvAnswerList.DataSource = dtsub;
            }
            else
            {
                //ImpromptuHelper.ShowPrompt("No Answer Option found!");
                trViewAnswer.Visible = false;
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
    protected void btnAnswerAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btn = (ImageButton)(sender);
            string QuestionId = btn.CommandArgument;
            lblQuesDesc.Visible = true;
            lblQuestion.Visible = true;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            lblQuesDesc.Text = gvr.Cells[3].Text;
            trAddAnswer.Visible = true;
            trViewAnswer.Visible = false;
            ViewState["QuestionId"] = QuestionId;
            txtAnswer.Text = "";
            ddlAnswOption.SelectedValue = "0";
            ViewState["mode"] = "Add";
            txtAnswer.TextMode = TextBoxMode.MultiLine;
            txtAnswer.Rows = 5;
            ddlAnswOption.Visible = false;
            lblAnswerOption.Visible = false;
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
            objBase.FillDropDown(dt, ddlAnswOption, "AnswerOption_ID", "AnswerOptionDesc");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnEditPool_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["mode"] = "EditPool";
            ImageButton btn = (ImageButton)(sender);
            ViewState["Pool_Id"] = btn.CommandArgument;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            divPool.Visible = true;
            gvTest.SelectedIndex = gvr.RowIndex;
            txtTotal.Focus();
            txtAnsInSec.Text = gvr.Cells[3].Text;
            txtMarksQuestion.Text = gvr.Cells[4].Text;
            txtTotal.Text = gvr.Cells[5].Text;
            trViewAnswer.Visible = false;
            trViewQuestion.Visible = false;
            trAddAnswer.Visible = false;
            panAddQuestion.Visible = false;
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            panAddQuestion.Visible = false; 

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSavePool_Click(object sender, EventArgs e)
    {
        try
        {
            int k=-1;
            if (ViewState["mode"].ToString() == "EditPool")
            {
                BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
                obj.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"]);
                obj.MarksPerQuestion = Convert.ToDecimal(txtMarksQuestion.Text);
                obj.TimeInSeconds = Convert.ToInt32(txtAnsInSec.Text);
                obj.MinQuest = Convert.ToInt32(txtTotal.Text);
                k = obj.AdmTestQuestionPoolUpdate(obj);
            }
            if (k == 1)
                ImpromptuHelper.ShowPrompt("Cannot Incorporate changes!");
            BindgvPool();
            ViewState["Data"] = null;
            BindGrid();
            divPool.Visible = false;
            trViewPool.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancelPool_Click(object sender, EventArgs e)
    {
        try
        {
            divPool.Visible = false;
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
            trAddAnswer.Visible = true;

            trViewAnswer.Visible = false;
            lblQuesDesc.Visible = false;
            lblQuestion.Visible = false;
            BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            ImageButton btn = (ImageButton)(sender);
            string QuestionDetailId = btn.CommandArgument;
            ViewState["QuestionDetailId"] = QuestionDetailId;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            txtAnswer.Focus();
            txtAnswer.Text = gvr.Cells[3].Text;

            if (gvr.Cells[4].Text == "True")
                ddlAnswOption.SelectedValue = "1";
            else
                ddlAnswOption.SelectedValue = "0";
            ViewState["QuestionId"] = gvr.Cells[2].Text;

            ddlAnswOption.Visible = true;
            txtAnswer.Rows = 1;
            txtAnswer.TextMode = TextBoxMode.SingleLine;
            lblAnswerOption.Visible = true;
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

            BLLAdmTestQuestionsDetail obj = new BLLAdmTestQuestionsDetail();
            ImageButton btn = (ImageButton)(sender);
            obj.QuestDetail_ID = Convert.ToInt32(btn.CommandArgument);
            int k = obj.AdmTestQuestionsDetailDelete(obj);
            BindAnswerGrid();
            if (k == 0)
                ImpromptuHelper.ShowPrompt("Record Deleted!");
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
            string mode = Convert.ToString(ViewState["mode"]);
            DataTable dtMCQsOptions = new DataTable();
            if (mode == "Add")
            {
                dtMCQsOptions.Columns.Add("QuestionId");
                dtMCQsOptions.Columns.Add("Description");
                dtMCQsOptions.Columns.Add("IsCorrect");
                DataRow drMCQsOptions = null;
                ViewState["addMCQsOptions"] = null;
                foreach (string line in this.txtAddAnswer.Text.Split('\n'))
                {
                    if (line.Length > 1 || line.Length == 1)
                    {
                        drMCQsOptions = dtMCQsOptions.NewRow();
                        drMCQsOptions["QuestionId"] = 0;

                        if (line.Substring(0, 1) == "*")
                        {
                            drMCQsOptions["Description"] = line.Substring(1, line.Length - 1).Trim();
                            drMCQsOptions["IsCorrect"] = true;

                        }
                        else
                        {
                            drMCQsOptions["Description"] = line.Trim();
                            drMCQsOptions["IsCorrect"] = false;

                        }
                        dtMCQsOptions.Rows.Add(drMCQsOptions);
                    }
                }
                foreach (DataRow r in dtMCQsOptions.Rows)
                {
                    objClsSec.Options = r["Description"].ToString();
                    objClsSec.IsCorrect = Convert.ToBoolean(r["IsCorrect"].ToString());
                    AlreadyIn = objClsSec.AdmTestQuestionsDetailAdd(objClsSec);
                }
                ViewState["dtDetails"] = null;
                if (AlreadyIn == 1)
                {
                    ImpromptuHelper.ShowPrompt("Cannot add Answer!");
                }
            }
            else
            {
                objClsSec.QuestDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]);
                if (ddlAnswOption.SelectedValue.ToString() == "0")
                    objClsSec.IsCorrect = false;
                else
                    objClsSec.IsCorrect = true;
                objClsSec.Options = txtAnswer.Text;
                AlreadyIn = objClsSec.AdmTestQuestionsDetailUpdate(objClsSec);
                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Answer was successfully updated to this Question.");
                }
                else 
                    ImpromptuHelper.ShowPrompt("Cannot Incorporate changes!");
            }
            BindAnswerGrid();
            trAddAnswer.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnSaveQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions(); int k = -1;
            if (txtQuestion.Text.Length >= 500 || txtAddAnswer.Text.Length >= 500)
            {
                ImpromptuHelper.ShowPrompt("Your text exceeds the available limit!");
                return;
            }
            obj.AnsPointValue = Convert.ToDecimal(txtPValue.Text);
            obj.NegtvPointValue = Convert.ToDecimal(txtNValue.Text);
            obj.QuesText = txtQuestion.Text;
            obj.Comments = txtComments.Text;
            obj.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"].ToString());
            if (ViewState["Mode"].ToString() == "AddQuestion")
            {
                k = obj.AdmTestQuestionsAdd(obj);
                ViewState["QuestionId"] = k;
                ViewState["mode"] = "Add";
                btnAnswerSave_Click(this, EventArgs.Empty);
                ViewState["dtDetails"] = null;
                BindAnswerGrid();
            }
            else if (ViewState["Mode"].ToString() == "EditQuestion")
            {
                obj.Quest_ID = Convert.ToInt32(ViewState["Quest_ID"].ToString());
                k = obj.AdmTestQuestionsUpdate(obj);
                trViewAnswer.Visible = false;
            }
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("You cannot change questions!");
            }
            
            btnCancelQuestion_Click(this, EventArgs.Empty);
            ViewState["Pool_Id"] = obj.Pool_Id;
            BindQuestion();
            ViewState["Data"] = null;
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnCancelQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            panAddQuestion.Visible = false;
            txtAnsInSec.Text = "";
            txtComments.Text = "";
            txtNValue.Text = "";
            txtPValue.Text = "";
            txtQuestion.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int k = 0;

            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.AdmTestType_Id = Convert.ToInt32(chkTestType.SelectedValue);
            if (ViewState["Mode"].ToString() == "Add")
            {
                obj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                k = obj.AdmTestAdd(obj);
            }
            if (ViewState["Mode"].ToString() == "Edit")
            {
                obj.Title = txtTestName.Text;
                objDetail.TestDesc = txtTestDesc.Text;
                obj.PublishStatus_ID = 1;
                objDetail.TotalMarks = Convert.ToDecimal(txtMarks.Text);
                obj.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objDetail.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
                obj.AdmTest_Id = Convert.ToInt32(ViewState["AdmTest_Id"].ToString());

                k = obj.AdmTestUpdate(obj, objDetail);
                ViewState["Data"] = null;
                BindGrid();
            }
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Cannot apply changes!");
            }
            btnCancel_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGrid()
    {
        try
        {

            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            DataTable dt = new DataTable();
            if (ViewState["Data"] == null)
            {
                dt = obj.AdmTestFetch(obj);
                ViewState["Data"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["Data"];
            }
            if (dt.Rows.Count > 0)
            {
                tdGridHeader.Visible = true;
                btnAddTest.Visible = false;
                btnDeleteTest.Visible = true;
            }
            else if (dt.Rows.Count == 0)
            {
                tdGridHeader.Visible = false;
                btnAddTest.Visible = true;
                btnDeleteTest.Visible = false;
            }

            gvTest.DataSource = dt;
            gvTest.DataBind();
            if (dt.Rows.Count > 0 && dt.Rows[0]["AdmTestType_Id"].ToString() == "3")//manual entry by campus officer
            {
                gvTest.Columns[16].Visible = false;
                gvTest.Columns[10].Visible = false;
                gvTest.Columns[15].Visible = true;
            }
            else
            {
                gvTest.Columns[15].Visible = false;
                gvTest.Columns[16].Visible = true;
                gvTest.Columns[10].Visible = true;

            }
            gvTest.DataSource = dt;
            gvTest.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void clearControls()
    {
        try
        {
            txtClosing.Text = "";
            txtOpening.Text = "";
            txtTestDesc.Text = "";
            txtTestName.Text = "";
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
            FillClass();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            tblAddTest.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindgvPool()
    {
        try
        {
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
            obj.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
            DataTable dt = obj.AdmTestQuestionPoolFetch(obj);
            if (dt.Rows.Count == 0)
                trViewPool.Visible = false;
            gvPool.DataSource = dt;
            gvPool.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowPool_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnEdit = (ImageButton)(sender);
            ViewState["AdmTestDetail_Id"] = Convert.ToInt32(btnEdit.CommandArgument);
            BindgvPool();
            divPool.Visible = false;
            trAddAnswer.Visible = false;
            panAddQuestion.Visible = false; 
            trViewPool.Visible = true;
            trViewQuestion.Visible = false;
            trViewAnswer.Visible = false;
            tblAddTest.Visible = false;
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
            chkTestType.Enabled = true;
            trViewQuestion.Visible = false;
            gvTest.DataSource = null;
            gvTest.DataBind();
            gvPool.DataSource = null;
            gvPool.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            btnCancel_Click(this, EventArgs.Empty);
            btnCancelQuestion_Click(this, EventArgs.Empty);
            trViewQuestion.Visible = false;
            btnCancelAnswer_Click(this, EventArgs.Empty);
            trViewAnswer.Visible = false;
            trViewPool.Visible = false;
            tdGridHeader.Visible = false;
            FillTestType();
             
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void chkTestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            chkTestType.Enabled = false;
            ViewState["Data"] = null;
            BindGrid();
            gvPool.DataSource = null;
            gvPool.DataBind();
            trViewQuestion.Visible = false;
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            btnCancel_Click(this, EventArgs.Empty);
            btnCancelQuestion_Click(this, EventArgs.Empty);
            trViewQuestion.Visible = false;
            btnCancelAnswer_Click(this, EventArgs.Empty);
            trViewAnswer.Visible = false;
            tdGridHeader.Visible = true;
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}