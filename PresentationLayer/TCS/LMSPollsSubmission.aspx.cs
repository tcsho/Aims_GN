using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_LMSPollsSubmission : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillPollDropDown();

              


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

    private void FillPollDropDown()
    {
        try
        {
        lblSave.Text = "";
        BLLLmsPolls obj = new BLLLmsPolls();

        obj.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());

        //int CenterId = Convert.ToInt32(Session["cId"].ToString());
        DataTable dt = (DataTable)obj.LmsPollsSelectAllForSubmission(obj);
        
        objBase.FillDropDown(dt, List_Poll, "Poll_ID", "QstText");
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
            BLLLmsPollsSubmissionsUser obj = new BLLLmsPollsSubmissionsUser();

            int AlreadyIn = 0;

            obj.User_ID = Int32.Parse(Session["ContactID"].ToString());
            obj.Poll_ID = Convert.ToInt32(List_Poll.SelectedValue.ToString());

            DataTable dtcheck = (DataTable)obj.LmsPollsSubmissionsUserSelectPollIdUserId(obj);

             if (dtcheck.Rows.Count == 0)
             {

                 AlreadyIn = obj.LmsPollsSubmissionsUserAdd(obj);
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
        BLLLmsPollsSubmissions objClsSec = new BLLLmsPollsSubmissions();

        DataTable dtsub = new DataTable();

        objClsSec.Poll_ID = Convert.ToInt32(List_Poll.SelectedValue.ToString());

        objClsSec.User_Id = Int32.Parse(Session["ContactID"].ToString());


        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsPollsSubmissionSelectAllbyPollId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvPollQuestion.DataSource = dtsub;
        }
        gvPollQuestion.DataBind();
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
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string AnsId = (e.Row.Cells[2].Text);

            DropDownList listAnswerOption = (e.Row.FindControl("listAnswerOption") as DropDownList);

            BLLLmsPollsQuestionDetailOption obj = new BLLLmsPollsQuestionDetailOption();

            //obj.Center_Id = Convert.ToInt32(Session["cId"].ToString());

            DataTable dt = (DataTable)obj.LmsPollsQuestionDetailOptionFetch(obj);
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
            BLLLmsPollsSubmissions obj = new BLLLmsPollsSubmissions();
            int AlreadyIn = 0;


            obj.Poll_ID = Convert.ToInt32(gvPollQuestion.Rows[0].Cells[0].Text);
            obj.Participant_ID = Int32.Parse(Session["ContactID"].ToString());

            AlreadyIn = obj.LmsPollsSubmissionsDelete(obj);

            AlreadyIn = 0;

            for (int i = 0; i < gvPollQuestion.Rows.Count; i++)
            {
                DropDownList list = (DropDownList)gvPollQuestion.Rows[i].FindControl("listAnswerOption");

                
                
                   obj.Poll_ID = Convert.ToInt32(gvPollQuestion.Rows[i].Cells[0].Text);
                   obj.PollDetail_ID = Convert.ToInt32(gvPollQuestion.Rows[i].Cells[1].Text);
                   obj.Participant_ID = Int32.Parse(Session["ContactID"].ToString());
                   obj.QuestionDetailOption_Id = Convert.ToInt32(list.SelectedItem.Value);
                   obj.QuestionDetailOption = list.SelectedItem.ToString();
                   obj.LmsPollsSubmissionsUser_ID = Convert.ToInt32(gvPollQuestion.Rows[i].Cells[7].Text);


                   AlreadyIn = obj.LmsPollsSubmissionsAdd(obj);
                

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
     
        foreach (GridViewRow gvRow in gvPollQuestion.Rows)
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
    
    protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

        if (e.CommandName == "toggleCheck")
        {
            CheckBox cb = null;
            string mood = ViewState["tMood"].ToString();

            foreach (GridViewRow gvr in gvPollQuestion.Rows)
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