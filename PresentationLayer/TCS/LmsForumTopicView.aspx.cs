using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_TCS_LmsForumTopicView : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected int _ttlpoints;
    protected int _postTypeID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                _ttlpoints = 0;
                _postTypeID = 0;

                FillForumTopicDropDown();
                ResetControls();
                

              


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

    private void FillForumTopicDropDown()
    {
        try
        {

        lblSave.Text = "";
        BLLLmsFormTopic obj = new BLLLmsFormTopic();
        obj.Section_Subject_Id = Convert.ToInt32(Session["WorkSiteSectionSubjectId"].ToString());

        //////////int CenterId = Convert.ToInt32(Session["cId"].ToString());
        DataTable dt = (DataTable)obj.LmsFormTopicFetch(obj);

        objBase.FillDropDown(dt, List_ForumTopic, "Topic_ID", "TopicTitle");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void List_ForumTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        trCDT.Visible = true;
        trLabl1.Visible = true;
        trLabl2.Visible = true;
        trLabl3.Visible = true;
        trLabl4.Visible = true;
        trLabl5.Visible = true;
        trLabl6.Visible = true;
        trLabl7.Visible = true;
        trLabl8.Visible = true;
        trLabl9.Visible = true;


        LoadTopicInformation();

        DisplayTopicResponse();


        ViewState["mode"] = "Add";
        pan_New.Attributes.CssStyle.Add("display", "none");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void ResetControls()
    {
        try
        {
        trCDT.Visible = false;
        pan_New.Attributes.CssStyle.Add("display", "none");
        trLabl1.Visible = false;
        trLabl2.Visible = false;
        trLabl3.Visible = false;
        trLabl4.Visible = false;
        trLabl5.Visible = false;
        trLabl6.Visible = false;
        trLabl7.Visible = false;
        trLabl8.Visible = false;
        trLabl9.Visible = false;
       

        ////////lblCreatedBy.Visible = false;
        ////////lblCreatedOn.Visible = false;
        ////////lblShortDesc.Visible = false;
        ////////lblLongDesc.Visible = false;
        ////////lblisLock.Visible = false;
        ////////lblisGradeBook.Visible = false;
        ////////lblPostType.Visible = false;
        ////////lblThreadType.Visible = false;
        ////////lblTtlGrade.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

  




    protected void LoadTopicInformation()
    {
        try
        {
        BLLLmsFormTopic bllObj = new BLLLmsFormTopic();

        if (List_ForumTopic.SelectedIndex > 0)
        {
            ////////////int _id = Int32.Parse(Session["Topic_ID"].ToString());
            ////////////DataTable dt = new DataTable();

            bllObj.Topic_ID = Convert.ToInt32(List_ForumTopic.SelectedValue);

            DataTable dt = (DataTable)bllObj.LmsFormTopicSlectAllByTopicId(bllObj);


            //dt = bllObj.LmsFormTopicFetchById(_id);
            if (dt.Rows.Count > 0)
            {
                //////////title.InnerText = dt.Rows[0]["Title"].ToString();
                //////////ForumPath.InnerText = dt.Rows[0]["ForumPath"].ToString();
                lblCreatedBy.Text = dt.Rows[0]["CreatedBy"].ToString();
                lblCreatedOn.Text = dt.Rows[0]["CreatedOn"].ToString();
                lblShortDesc.Text = dt.Rows[0]["ShortDescription"].ToString();
                lblLongDesc.Text = dt.Rows[0]["LongDescription"].ToString();
                lblisLock.Text = dt.Rows[0]["isLock"].ToString();
                lblisGradeBook.Text = dt.Rows[0]["isGradeBook"].ToString();
                lblPostType.Text = dt.Rows[0]["PostType"].ToString();
                lblThreadType.Text = dt.Rows[0]["ThreadType"].ToString();
                lblTtlGrade.Text = dt.Rows[0]["TotalPoints"].ToString();
                //_ttlpoints = Int32.Parse(dt.Rows[0]["TotalPoints"].ToString());
                //_postTypeID = Int32.Parse(dt.Rows[0]["PostingType_ID"].ToString());


            }

        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }



    protected void DisplayTopicResponse()
    {
        try
        {
        BLLLmsFormResponse bllobj = new BLLLmsFormResponse();

        ////////////DataTable dt = new DataTable();
        ////////////int _topic_ID = 0;

        ////////////if (Session["Topic_ID"] != null)
        ////////////{
        ////////////    _topic_ID = Convert.ToInt32(Session["Topic_ID"].ToString());
        ////////////}

        //////////////dt = bllobj.LmsFormResponseFetchByTopic(_topic_ID);

        bllobj.Topic_ID = Convert.ToInt32(List_ForumTopic.SelectedValue);

        DataTable dt = (DataTable)bllobj.LmsFormResponseFetch(bllobj);

        if (dt.Rows.Count > 0)
        {

            DataView dv = new DataView(dt);
            gvTopic.DataSource = dv;
            gvTopic.DataBind();
        }

        /////// comment for all records 
        ////////////////////if (dt.Rows.Count > 0)
        ////////////////////{

        ////////////////////    DataView dv = new DataView(dt);
        ////////////////////    gvTopic.DataSource = dv;
        ////////////////////    gvTopic.DataBind();

        ////////////////////    if (dt.Rows[0]["isLock"].ToString() == "True")
        ////////////////////    {
        ////////////////////        hidereplyLink();
        ////////////////////        but_Reply.Visible = false;
        ////////////////////    }

        ////////////////////    if (dt.Rows[0]["PostingType_ID"].ToString() == "1")
        ////////////////////    {
        ////////////////////        bool _chk = false;
        ////////////////////        for (int i = 0; i < dt.Rows.Count; i++)
        ////////////////////        {
        ////////////////////            if (dt.Rows[i]["Participant_ID"].ToString() == Session["Participant_ID"].ToString())
        ////////////////////            {
        ////////////////////                _chk = true;
        ////////////////////                break;
        ////////////////////            }
        ////////////////////        }
        ////////////////////        if (_chk == true)
        ////////////////////        {
        ////////////////////            but_Reply.Visible = false;
        ////////////////////        }
        ////////////////////        else
        ////////////////////        {
        ////////////////////            but_Reply.Visible = true;

        ////////////////////        }

        ////////////////////    }
        ////////////////////    else
        ////////////////////    {
        ////////////////////        but_Reply.Visible = true;
        ////////////////////    }



        ////////////////////    if (dt.Rows[0]["ThreadType_ID"].ToString() == "1")
        ////////////////////    {
        ////////////////////        hidereplyLink();
        ////////////////////    }

        ////////////////////    if (dt.Rows[0]["ThreadType_ID"].ToString() == "1")
        ////////////////////    {
        ////////////////////        hidereplyLink();
        ////////////////////    }

        ////////////////////    int Parti_id = Int32.Parse(Session["Participant_ID"].ToString());
        ////////////////////    //int _partType = objbase.GetPartType(Parti_id);

        ////////////////////    int _partType = 1;


        ////////////////////    GradeSettings(_partType);
        ////////////////////    if (_partType == 1)
        ////////////////////    {
        ////////////////////        hideDeleteLink();

        ////////////////////    }
        ////////////////////    if (dt.Rows[0]["isGradeBook"].ToString() == "False")
        ////////////////////    {
        ////////////////////        disableMarking();
        ////////////////////    }
        ////////////////////}
        ////////////////////-----

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    protected void hidereplyLink()
    {

        foreach (GridViewRow gr in gvTopic.Rows)
        {
            Control ctrl = gr.FindControl("LnkBtnReply");
            LinkButton lnk = (LinkButton)ctrl;
            lnk.Visible = false;
        }


    }
    protected void hideDeleteLink()
    {

        foreach (GridViewRow gr in gvTopic.Rows)
        {


        }


    }
    protected void GradeSettings(int _id)
    {

        foreach (GridViewRow gr in gvTopic.Rows)
        {

            Control ctrl = gr.FindControl("LnkBtnRate");
            LinkButton lnk = (LinkButton)ctrl;
            if (_id == 1)
            {
                lnk.Visible = false;
            }
            else
            {
                lnk.Visible = true;
            }

            //ctrl = gr.FindControl("lblPoints");
            //lbl = (Label)ctrl;
            //if (_id == 1)
            //    {
            //    lbl.Visible = true;
            //    }
            //else
            //    {
            //    lbl.Visible = true;
            //    }

            ctrl = gr.FindControl("lblGrade");
            Label lbl = (Label)ctrl;
            if (_id == 1)
            {
                lbl.Visible = true;
            }
            else
            {
                lbl.Visible = true;
            }

            ctrl = gr.FindControl("txtObtMarks");
            TextBox txt = (TextBox)ctrl;
            txt.Visible = false;
            if (_id == 1)
            {
                txt.Visible = false;
            }
            else
            {
                txt.Visible = true;
            }


            ctrl = gr.FindControl("LnkBtnDelete");
            lnk = (LinkButton)ctrl;
            if (_id == 1)
            {
                lnk.Visible = false;
            }
            else
            {
                lnk.Visible = true;
            }
        }
    }



    protected void disableMarking()
    {
        foreach (GridViewRow gr in gvTopic.Rows)
        {
            Control ctrl = gr.FindControl("txtObtMarks");
            TextBox txt = (TextBox)ctrl;
            txt.Visible = false;


            ctrl = gr.FindControl("lblGrade");
            Label lbl = (Label)ctrl;
            lbl.Visible = false;

            ctrl = gr.FindControl("lblPoints");
            lbl = (Label)ctrl;
            lbl.Visible = false;


        }
    }



   



    protected void gvTopic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvTopic.PageIndex = e.NewPageIndex;
        DisplayTopicResponse();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


  
    protected void but_Reply_Click(object sender, EventArgs e)
    {
        try
        {
        ViewState["Response_Id"] = null;
        pan_New.Attributes.CssStyle.Add("display", "inline");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
        BLLLmsFormResponse bllobj = new BLLLmsFormResponse();

        DataTable dt = new DataTable();
        int _topic_ID = 0;

        if (Session["Topic_ID"] != null)
        {
            _topic_ID = Convert.ToInt32(Session["Topic_ID"].ToString());
        }

        //dt = bllobj.LmsFormResponseFetchByTopic(_topic_ID);


        //       PlaceHolder1.Controls.Add(new LiteralControl("<table width='100%'>"));
        for (int r = 0; r < dt.Rows.Count; r++)
        {
            int x;
            string p1, p2, p3, p4;
            p1 = dt.Rows[r].ItemArray.GetValue(12).ToString();
            p2 = dt.Rows[r].ItemArray.GetValue(9).ToString();
            p3 = dt.Rows[r].ItemArray.GetValue(2).ToString();
            p4 = dt.Rows[r].ItemArray.GetValue(10).ToString();

            Math.DivRem(r, 2, out x);
            if (x == 0)
                MainDiv(p1, p2, p3, p4, r);
            else
                ChildDiv(p1, p2, p3, p4, r);
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

        BLLLmsFormResponse bllObj = new BLLLmsFormResponse();

        try
        {

            //////////bllObj.Topic_ID = Int32.Parse(Session["Topic_ID"].ToString());
            bllObj.Topic_ID = Convert.ToInt32(List_ForumTopic.SelectedValue);

            bllObj.Message = Editor1.Content;
            if (ViewState["Response_Id"] != null)
            {
                bllObj.ParentResponse_ID = Int32.Parse(ViewState["Response_Id"].ToString());
            }
            else
            {
                bllObj.ParentResponse_ID = 0;
            }
            bllObj.Participant_ID = Int32.Parse(Session["ContactID"].ToString());
            bllObj.ObtainePoints = 0;
            bllObj.Status_Id = 1;

            string mode = Convert.ToString(ViewState["mode"]);
            int nAlreadyIn = 0;
            if (mode != "Edit")
            {

                bllObj.CreatedOn = DateTime.Now;
                bllObj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());

                nAlreadyIn = bllObj.LmsFormResponseAdd(bllObj);

                if (nAlreadyIn == 0)
                {
                    pan_New.Attributes.CssStyle.Add("display", "none");
                    ImpromptuHelper.ShowPrompt("Message Posted Successfully.");
                    ResetControls();
                    DisplayTopicResponse();
                }

            }
            else
            {
                //             id = Convert.ToInt32(ViewState["Response_ID"]);

                //               bllObj.ModifiedOn = DateTime.Now;
                //               bllObj.ModifiedBy = Convert.ToInt16(Session["ContactID"].ToString());


                nAlreadyIn = bllObj.LmsFormResponseUpdate(bllObj);
                if (nAlreadyIn == 0)
                {
                    pan_New.Attributes.CssStyle.Add("display", "none");
                    ImpromptuHelper.ShowPrompt("Message Post Updated Successfully.");
                    ResetControls();
                    DisplayTopicResponse();

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
        ResetControls();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void MainDiv(string param1, string param2, string _obpoints, string param3, int r)
    {
        try
        {
        int x;
        TextBox tb;
        Label lab_error;
        PlaceHolder1.Controls.Add(new LiteralControl("<table width='100%'>"));
        //Header Row
        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tableheaderD'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>" + param1 + "</tr>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
        //Detail Row

        PlaceHolder1.Controls.Add(new LiteralControl("<tr class='tr1' Style=height:100px>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td text-align=top>" + param2 + "</td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr class='tr1' Style=height:auto>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td> Marks: "));

        tb = new TextBox();
        tb.ID = "hello" + r.ToString();

        //            if (doOverride)
        tb.Text = _obpoints;
        if (tb.Text == "")
            tb.Text = "-1";
        tb.Width = 30;
        tb.EnableViewState = true;
        tb.ValidationGroup = "valSave";
        // tb.ReadOnly = (bool)dt.Rows[r].ItemArray.GetValue(3);

        PlaceHolder1.Controls.Add(tb);

        lab_error = new Label();
        lab_error.ForeColor = System.Drawing.Color.Red;
        lab_error.ID = "error" + r.ToString();
        lab_error.Text = "Reply On " + param3;

        PlaceHolder1.Controls.Add(lab_error);

        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));



        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tableheaderD'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>  </td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tr2'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'> </tr>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void ChildDiv(string param1, string param2, string _obpoints, string param3, int r)
    {
        try
        {
        int x;
        TextBox tb;
        Label lab_error;

        PlaceHolder1.Controls.Add(new LiteralControl("<table width='100%'>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr class='tableheaderD'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>" + param1 + "</td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));


        PlaceHolder1.Controls.Add(new LiteralControl("<tr class='tr1' Style=height:100px>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td class='tr2' Style=width:10%></td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td>" + param2 + "</td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr class='tr1' Style=height:auto>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td class='tr2' Style=width:10%></td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td> Marks: "));

        tb = new TextBox();
        tb.ID = "hello" + r.ToString();

        //            if (doOverride)
        tb.Text = _obpoints;
        if (tb.Text == "")
            tb.Text = "-1";
        tb.Width = 30;
        tb.EnableViewState = true;
        tb.ValidationGroup = "valSave";
        // tb.ReadOnly = (bool)dt.Rows[r].ItemArray.GetValue(3);

        PlaceHolder1.Controls.Add(tb);

        lab_error = new Label();
        lab_error.ForeColor = System.Drawing.Color.Red;
        lab_error.ID = "error" + r.ToString();
        lab_error.Text = "Reply On " + param3;

        PlaceHolder1.Controls.Add(lab_error);

        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));



        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tableheaderD'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>  </td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tableheaderD'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'>  </td>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("<tr  class='tr2'>"));
        PlaceHolder1.Controls.Add(new LiteralControl("<td colspan='2'> </tr>"));
        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

        PlaceHolder1.Controls.Add(new LiteralControl("</table>"));

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void LnkBtnRate_Click(object sender, EventArgs e)
    {
        try
        {
        BLLLmsFormResponse bllObj = new BLLLmsFormResponse();

        LinkButton lnkBtn = (LinkButton)sender;
        int _id = Convert.ToInt32(lnkBtn.CommandArgument);
        ViewState["Response_Id"] = _id;
        bllObj.Response_ID = _id;
        GridViewRow grv = (GridViewRow)lnkBtn.NamingContainer;

        Control ctl = (Control)grv.FindControl("txtObtMarks");
        TextBox txt = (TextBox)ctl;

        if (txt.Text != string.Empty)
        {
            int temp = Int32.Parse(txt.Text);
            int tempT = Int32.Parse(lblTtlGrade.Text);
            if (tempT < temp)
            {
                ImpromptuHelper.ShowPrompt("Please Enter valid Grading Points");
            }
            else
            {
                bllObj.ObtainePoints = Int32.Parse(txt.Text);
                int AlreadyIn = 0;



                AlreadyIn = bllObj.LmsFormResponseUpdateObtainPoint(bllObj);
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Grade Saved Successfully!");
                    DisplayTopicResponse();
                }
            }
        }
        else
       {
           ImpromptuHelper.ShowPrompt("Please Enter valid Grading Points");
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void LnkBtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
        BLLLmsFormResponse bllObj = new BLLLmsFormResponse();

        LinkButton lnkBtn = (LinkButton)sender;
        int _id = Convert.ToInt32(lnkBtn.CommandArgument);
        ViewState["Response_Id"] = _id;

        bllObj.Response_ID = Int32.Parse(ViewState["Response_Id"].ToString());


        //        pan_New.Attributes.CssStyle.Add("display", "inline");

        lnkBtn.Attributes.Add("onclick", "javascript:return " +
        "confirm('Are you sure to delete the This Post?') ");

        int AlreadyIn = 0;



                AlreadyIn = bllObj.LmsFormResponseDelete(bllObj);
                if (AlreadyIn == 0)
                {
                    ////////////////////drawMsgBox("Post Deleted Successfully!");
                    DisplayTopicResponse();
                }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    protected void LnkBtnReply_Click(object sender, EventArgs e)
    {
        try
        {
        LinkButton lnkBtn = (LinkButton)sender;
        int Res_Id = Convert.ToInt32(lnkBtn.CommandArgument);
        ViewState["Response_Id"] = Res_Id;
        pan_New.Attributes.CssStyle.Add("display", "inline");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


}