using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Diagnostics;
using System.Threading;




public partial class PresentationLayer_TCS_AdmissionTest : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    static double TimeAllSecondes;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {

                BindGrid();
                if (gvComplaints.Rows.Count > 0)
                {
                    int Question_Id = Convert.ToInt32(gvComplaints.Rows[0].Cells[1].Text);
                    BindQuestionDetail(Question_Id, rblOptions);
                    UpdateTimer.Enabled = true;
                    UpdateTimer.Interval = 1000;

                }
                LoadStudentData();
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
    }

    protected void LoadStudentData()
    {
        try
        {
            BLLAdmTestSubmissions ObjADS = new BLLAdmTestSubmissions();
            ObjADS.User_ID = Int32.Parse(Session["ContactID"].ToString());
            DataTable dt = (DataTable)Session["StudentTestInfo"];
            //if (Session["StudentTestInfo"] == null)
            //{
            //    //Response.Redirect("~/login.aspx", false);
            //}
            if (dt.Rows.Count > 0)
            {
                tdReg.InnerText = dt.Rows[0]["Regisration_Id"].ToString();
                tdSName.InnerText = dt.Rows[0]["StudentName"].ToString();
                Session["Class_Id"] = dt.Rows[0]["Grade_Id"].ToString();
                if (Session["QuestionNo"] != null)
                    tdClass.InnerText = Session["QuestionNo"].ToString() + " Of " + dt.Rows[0]["NumberOfQuestions"].ToString();
                else
                {
                    Session["Mode"] = "NoTest";
                   // Response.Redirect("Admission_Registeration_Evaluation_Criteria.aspx", false);
                }
                if (Session["Group_Type"] != null)
                {
                    Session["Group_Type"] = Session["Group_Type"].ToString();
                }
                
                tdCName.InnerText = lblQuestionTime.Text + " Seconds";
                //tdTestDetails.InnerText = dt.Rows[0]["AdmTestName"].ToString() + " Total Marks: " +
                //    dt.Rows[0]["TotalMarks"].ToString() + " Weightage: " + dt.Rows[0]["Weightage"].ToString();
                Session["Regisration_Id"] = dt.Rows[0]["Regisration_Id"].ToString();
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
            BLLAdmTestSubmissionDetail objClsSec = new BLLAdmTestSubmissionDetail();


            DataTable dtsub = new DataTable();

            objClsSec.User_ID = Int32.Parse(Session["ContactID"].ToString());

            dtsub = (DataTable)objClsSec.AdmTestSubmissionDetailSelectAllQuestionsByUserIdOneByOne(objClsSec);


            if (dtsub.Rows.Count > 0)
            {
                tdTestName.InnerText = dtsub.Rows[0]["AdmTestName"].ToString().Trim();
                tdTitle.InnerText = dtsub.Rows[0]["Title"].ToString().Trim();
                lblQuestionTime.Text = dtsub.Rows[0]["TimeInSeconds"].ToString().Trim();
                Session["QuestionNo"] = dtsub.Rows[0]["QuestionNo"].ToString().Trim();
                int TotalTimeInSeconds = Convert.ToInt32(dtsub.Rows[0]["TimeInSeconds"].ToString().Trim());
                int AnswerInSeconds = Convert.ToInt32(dtsub.Rows[0]["AnswerInSeconds"].ToString().Trim());

                if (AnswerInSeconds > 0)
                {
                    TimeAllSecondes = TotalTimeInSeconds - AnswerInSeconds;
                }
                else
                {
                    TimeAllSecondes = TotalTimeInSeconds;
                }
                lblTimer.Text = String.Format("Time remaining: {0}", TimeAllSecondes.ToString("00"));
                gvComplaints.DataSource = dtsub;
                gvComplaints.DataBind();

                lblTimer.Visible = true;

            }
            else
            {
               
                ResetAllFields();
               Response.Redirect("~/PresentationLayer/TCS/Admission_Registeration_Evaluation_Criteria.aspx", false);

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    private void ResetAllFields()
    {
        try
        {
            gvComplaints.DataSource = null;
            gvComplaints.DataBind();

            lblqtime.Visible = false;
            lblQuestionTime.Visible = false;
            lblTimer.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    public void BindQuestionDetail(int _question, RadioButtonList _rbl)
    {
        try
        {
            BLLAdmTestQuestionsDetail objQDet = new BLLAdmTestQuestionsDetail();
            objQDet.Quest_ID = _question;
            DataTable dt = objQDet.AdmTestQuestionsDetailSelectAllByQuestionId(objQDet);
            if (dt.Rows.Count > 0)
            {
                objBase.FillRadioButtonList(dt, _rbl, "QuestDetail_Id", "Options");
            }

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
            if (rblOptions.SelectedIndex > -1)
            {
                SubmitAnswer();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Answer before Saving!");
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }


    private void SubmitAnswer()
    {

        try
        {
            BLLAdmTestSubmissionDetail obj = new BLLAdmTestSubmissionDetail();
            int AlreadyIn = 0;
            obj.Quest_ID = Convert.ToInt32(gvComplaints.Rows[0].Cells[1].Text);
            obj.AdmTestSubmDetail_ID = Convert.ToInt32(gvComplaints.Rows[0].Cells[2].Text);


            if (rblOptions.SelectedIndex > -1)
            {
                obj.QuestDetail_ID = Convert.ToInt32(rblOptions.SelectedValue);
                obj.IsNotAnswered = false;
            }
            else
            {
                obj.QuestDetail_ID = null;
                obj.IsNotAnswered = true;
            }
            int Qseconds = 0;

            if (lblTimer.Text != "TimeOut!")
            {
                Qseconds = Convert.ToInt32(TimeAllSecondes);
            }

            obj.AnswerInSeconds = (Convert.ToInt32(lblQuestionTime.Text) - Qseconds);

            AlreadyIn = obj.AdmTestSubmissionDetailUpdate(obj);

            UpdateTimer.Enabled = false;


            if (AlreadyIn == 0)
            {
                Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx", false);
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void SubmitAnswerTimeOnly()
    {

        try
        {
            BLLAdmTestSubmissionDetail obj = new BLLAdmTestSubmissionDetail();
            int AlreadyIn = 0;
            obj.AdmTestSubmDetail_ID = Convert.ToInt32(gvComplaints.Rows[0].Cells[2].Text);

            int Qseconds = 0;

            if (lblTimer.Text != "TimeOut!")
            {
                Qseconds = Convert.ToInt32(TimeAllSecondes);
            }

            obj.AnswerInSeconds = (Convert.ToInt32(lblQuestionTime.Text) - Qseconds);

            AlreadyIn = obj.AdmTestSubmissionDetailUpdateTimeOnly(obj);

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            SubmitAnswer();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        try
        {

            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;

                lblTimer.Text = String.Format("Time remaining: {0}", TimeAllSecondes.ToString("00"));
                SubmitAnswerTimeOnly();
            }
            else
            {
                lblTimer.Text = "TimeOut!";
                SubmitAnswer();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


}