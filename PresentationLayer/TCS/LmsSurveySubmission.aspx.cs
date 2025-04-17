using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_LmsSurveySubmission : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillSurveyDropDown();

              


                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }

    private void FillSurveyDropDown()
    {
        try
        {
        lblSave.Text = "";
        BLLLmsSurvey obj = new BLLLmsSurvey();

        obj.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());

        //int CenterId = Convert.ToInt32(Session["cId"].ToString());
        DataTable dt = (DataTable)obj.LmsSurveySelectAllForSubmission(obj);

        objBase.FillDropDown(dt, List_Survey, "Survey_ID", "QstText");

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
        SaveUserId();
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        

    }

    private void SaveUserId()
    {
        try
        {
            BLLLmsSurveySubmissionsUser obj = new BLLLmsSurveySubmissionsUser();

            int AlreadyIn = 0;

            obj.User_ID = Int32.Parse(Session["ContactID"].ToString());
            obj.Survey_ID = Convert.ToInt32(List_Survey.SelectedValue.ToString());

            DataTable dtcheck = (DataTable)obj.LmsSurveySubmissionsUserSelectSurveyIdUserId(obj);

             if (dtcheck.Rows.Count == 0)
             {

                 AlreadyIn = obj.LmsSurveySubmissionsUserAdd(obj);
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
        BLLLmsSurveySubmissions objClsSec = new BLLLmsSurveySubmissions();

        DataTable dtsub = new DataTable();

        objClsSec.Survey_ID = Convert.ToInt32(List_Survey.SelectedValue.ToString());

        objClsSec.User_Id = Int32.Parse(Session["ContactID"].ToString());


        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsSurveySubmissionselectAllbySurveyId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvSurveyQuestion.DataSource = dtsub;
        }
        gvSurveyQuestion.DataBind();
        ViewState["tMood"] = "check";
        trSave.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSurveyQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string AnsId = (e.Row.Cells[2].Text);

            DropDownList listAnswerOption = (e.Row.FindControl("listAnswerOption") as DropDownList);

            BLLLmsSurveyQuestionDetailOption obj = new BLLLmsSurveyQuestionDetailOption();

            //obj.Center_Id = Convert.ToInt32(Session["cId"].ToString());

            DataTable dt = (DataTable)obj.LmsSurveyQuestionDetailOptionFetch(obj);
            objBase.FillDropDown(dt, listAnswerOption, "QuestionDetailOption_Id", "QuestionDetailOption");


            if (AnsId != "&nbsp;" || AnsId != String.Empty)
            {
                listAnswerOption.SelectedValue = AnsId;   
            }

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
            BLLLmsSurveySubmissions obj = new BLLLmsSurveySubmissions();
            int AlreadyIn = 0;


            obj.Survey_ID = Convert.ToInt32(gvSurveyQuestion.Rows[0].Cells[0].Text);
            obj.Participant_ID = Int32.Parse(Session["ContactID"].ToString());

            AlreadyIn = obj.LmsSurveySubmissionsDelete(obj);

            AlreadyIn = 0;

            for (int i = 0; i < gvSurveyQuestion.Rows.Count; i++)
            {
                DropDownList list = (DropDownList)gvSurveyQuestion.Rows[i].FindControl("listAnswerOption");

                
                
                   obj.Survey_ID = Convert.ToInt32(gvSurveyQuestion.Rows[i].Cells[0].Text);
                   obj.SurveyDetail_ID = Convert.ToInt32(gvSurveyQuestion.Rows[i].Cells[1].Text);
                   obj.Participant_ID = Int32.Parse(Session["ContactID"].ToString());
                   obj.QuestionDetailOption_Id = Convert.ToInt32(list.SelectedItem.Value);
                   obj.QuestionDetailOption = list.SelectedItem.ToString();
                   obj.LmsSurveySubmissionsUser_ID = Convert.ToInt32(gvSurveyQuestion.Rows[i].Cells[7].Text);


                   AlreadyIn = obj.LmsSurveySubmissionsAdd(obj);
                

            }

            ViewState["dtDetails"] = null;
            if (AlreadyIn==0)
            {
                ImpromptuHelper.ShowPrompt("Record Saved Successfully");
                BindGrid();
                
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSurveyQuestion_Sorting(object sender, GridViewSortEventArgs e)
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
    
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btnCopy = (ImageButton)sender;
        GridViewRow grv = (GridViewRow)btnCopy.NamingContainer;

        Control ctl = (Control)grv.FindControl("listAnswerOption");
        DropDownList ddlTeacher = (DropDownList)ctl;

        CheckBox cb = null;
        DropDownList ddlTeacherInner = null;
     
        foreach (GridViewRow gvRow in gvSurveyQuestion.Rows)
        {
            ddlTeacherInner = (DropDownList)gvRow.FindControl("listAnswerOption");
            cb = (CheckBox)gvRow.FindControl("CheckBox1");
            if (cb.Checked)
            {
                ddlTeacherInner.SelectedValue = ddlTeacher.SelectedValue;
                cb.Checked = false;
            }
        }
        ViewState["tMood"] = "check";

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gvSurveyQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        if (e.CommandName == "toggleCheck")
        {
            CheckBox cb = null;
            string mood = ViewState["tMood"].ToString();

            foreach (GridViewRow gvr in gvSurveyQuestion.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (mood == "" || mood == "check")
                {
                    cb.Checked = true;
                    ViewState["tMood"] = "uncheck";
                }
                else
                {
                    cb.Checked = false;
                    ViewState["tMood"] = "check";
                }

            }

        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
}