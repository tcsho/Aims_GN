using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class PresentationLayer_CEPD_QuestionsforSelfPacedCourses : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_Category objec = new BLLCEPD_Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
            loadTraings();
        }
    }
    protected void BindGridView()
    {
        DataTable dt = new DataTable();
        dt = objec.TrainingQuestions_Get();
        GridView.DataSource = dt;
        GridView.DataBind();
    }
    
    private void loadTraings()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();


            dt = objec.TrainingVideoUploade_Get();

            objBase.FillDropDown(dt, ddl_Trainings, "ID", "Training");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    
    protected void btnSave_traingquestions(object sender, EventArgs e)
    {
        if (ddl_Trainings.SelectedIndex == 0)
        {
            ImpromptuHelper.ShowPromptGeneric("Please Select Training!",0);
            return;
        }

        if (ddlCorrectAnswer.SelectedIndex == 0)
        {
            ImpromptuHelper.ShowPromptGeneric("Please Select Correct Answer!",0);
            return;
        }
        objec.Question = txtQuestion.Text;
        objec.OptionA = txtOptionA.Text;
        objec.OptionB = txtOptionB.Text;
        objec.OptionC = txtOptionC.Text;
        objec.OptionD = txtOptionD.Text;
        objec.CorrectAnswer = ddlCorrectAnswer.SelectedValue.ToString();
        objec.TrainingID = Convert.ToInt32(ddl_Trainings.SelectedValue);


        objec.TrainingVideoQuestions_Save(objec);
        ImpromptuHelper.ShowPrompt("Saved Successfully!");
        BindGridView();




    }
    protected void Edit(object sender, EventArgs e)
    {
        ImageButton btnEdit = (ImageButton)sender;

        int Id = int.Parse(btnEdit.CommandArgument);

        DataTable dt = objec.TrainingQuestions_GetBYid(Id);
        if (dt.Rows.Count > 0)
        {
          
            txtQuestion.Text= dt.Rows[0]["Question"].ToString();
            txtOptionA.Text= dt.Rows[0]["OptionA"].ToString();
            txtOptionB.Text= dt.Rows[0]["OptionB"].ToString();
            txtOptionC.Text= dt.Rows[0]["OptionC"].ToString();
            txtOptionD.Text= dt.Rows[0]["OptionD"].ToString();
            string ans = dt.Rows[0]["CorrectAnswer"].ToString();
            ddlCorrectAnswer.SelectedValue = ans;
            ddl_Trainings.SelectedValue= dt.Rows[0]["TrainingID"].ToString();




        }


    }
}