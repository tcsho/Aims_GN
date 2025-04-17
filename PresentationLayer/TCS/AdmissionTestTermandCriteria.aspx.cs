using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_AdmissionTestTermandCriteria : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                

                trSave.Visible = true;


                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


            RedirectAcceptCriteria();

        }
    }
    private void RedirectAcceptCriteria()
    {
        try
        {
        BLLAdmTestSubmissions obj = new BLLAdmTestSubmissions();

        obj.User_ID = Int32.Parse(Session["ContactID"].ToString());



        obj.AdmTestSubmissionsSelectAdminTestByUserId(obj);

        //if (dtcheck.Rows.Count != 0)
        //{
            Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx");
        //}

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
            ////////////////////Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx");

            BLLAdmTestSubmissions obj = new BLLAdmTestSubmissions();

            BLLAdmTestSubmissionDetail objdetail = new BLLAdmTestSubmissionDetail();

        

            int AlreadyIn = 0;

            obj.User_ID = Int32.Parse(Session["ContactID"].ToString());
            obj.SubmDateTime = DateTime.Now;
            obj.Comments = "None";
            obj.TotalScores = 0;
            obj.AdmTest_Id = 0;
           //// Add Master Data Entery for Submission
            /////

            DataTable dtcheck = null;
            //(DataTable)obj.AdmTestSubmissionsSelectAdminTestByUserId(obj);

            if (dtcheck.Rows.Count == 0)
            {

                      AlreadyIn = obj.AdmTestSubmissionsAdd(obj);

                ////// Load All Questions

                objdetail.User_ID = Int32.Parse(Session["ContactID"].ToString());
                DataTable dt = (DataTable)objdetail.AdmTestSubmissionDetailSelectAllQuestionsByUserId(objdetail);

                /////
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objdetail.isCorrect = false;
                        objdetail.Quest_ID = Convert.ToInt32(dt.Rows[i]["Quest_ID"].ToString().Trim());
                        objdetail.TeacherComments = "None";
                        objdetail.AdmTestSubm_ID = Convert.ToInt32(dt.Rows[i]["AdmTestSubm_ID"].ToString().Trim());
                        objdetail.QuestDetail_ID = 0;
                        objdetail.AnswerInSeconds = 0;

                       AlreadyIn = objdetail.AdmTestSubmissionAdd(objdetail);



                    }


                }

                Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx");

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx");


       
    }

    
    
    
    
}