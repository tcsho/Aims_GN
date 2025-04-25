using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_NEW_IEP : System.Web.UI.Page
{
    //BLLSubject obj = new BLLSubject();
    //DataTable dtCs = new DataTable();
    //DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            else
            {
                DataRow row = (DataRow)Session["rightsRow"];
                string User_Name = row["User_Name"].ToString();
                string Password = row["Password"].ToString();
                if (!string.IsNullOrEmpty(User_Name) || !string.IsNullOrEmpty(Password))
                {
                    // Response.Redirect("124.29.197.77:8098?username="+User_Name+"&password="+Password+"");
                    //string url = "http://124.29.197.77:8098?username=" + User_Name + "&password=" + Password;
                    //string script = "window.open('" + url + "', '_blank');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenPage", script, true);
                    string url ="http://sdp.csn.edu.pk?username="+Server.UrlEncode(User_Name) + "&password="+ Server.UrlEncode(Password);
                    // Set the src attribute of the iframe
                    myIframe.Attributes["src"] = url;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //private void search()
    //{
    //    try
    //    {
    //        ///searching
    //        ///
    //        BLLSubject obj = new BLLSubject();
    //        DataTable dt;

    //        int moId = Int32.Parse(Session["moID"].ToString());

    //        dt = obj.SubjectFetchByMoId(moId);
    //        if (dt.Rows.Count == 0)
    //        {
    //            lab_dataStatus.Visible = true;
    //        }
    //        else
    //        {
    //            ViewState["subjectDT"] = dt;

    //            dg_subject.DataSource = dt;
    //            dg_subject.DataBind();
    //            lab_dataStatus.Visible = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    ////protected void bindGrid()
    ////{
    ////    int moID = Convert.ToInt32(Session["moID"]);
    ////    DataTable dt = null;

    ////    dt = obj.SubjectFetchByMoId(moID);

    ////    if (dt.Rows.Count == 0)
    ////    {
    ////        lab_dataStatus.Visible = true;
    ////        //pan_New.Attributes.CssStyle.Add("display", "none");
    ////    }
    ////    else
    ////    {
    ////        gv_criteriaList.DataSource = dt;
    ////        lab_dataStatus.Visible = false;
    ////        lab_dataStatus.Visible = false;
    ////    }
    ////    gv_criteriaList.DataBind();
    ////    //pan_New.Attributes.CssStyle.Add("display", "none");


    ////    ViewState["CriteriaList"] = dt;

    ////}
    //protected void dg_subject_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        int ind = Int32.Parse((string)e.CommandArgument);

    //        if (e.CommandName == "name")
    //        {
    //            Session["SubjectID"] = dg_subject.DataKeys[ind].Value;
    //            Response.Redirect("SubjectDetail.aspx", false);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    //private bool validateGrid()
    //{
    //    bool result = false;
    //    foreach (GridViewRow gRow in dg_subject.Rows)
    //    {
    //        CheckBox chkBox = (CheckBox)gRow.Cells[3].FindControl("CheckBox1");
    //        if (chkBox.Checked)
    //        {
    //            result = true;
    //        }
    //    }
    //    return result;
    //}

    //protected void but_assignStudents_Click(object sender, EventArgs e)
    //{
    //    //if (!validateGrid())
    //    //{
    //    //    drawMsgBox("No Subject is selected for deletion!");
    //    //    return;
    //    //}


    //    try
    //    {
    //        CheckBox cb;
    //        int subjectId;
    //        int? nAlreadyIn = null;
    //        BLLSubject obj = new BLLSubject();
    //        foreach (GridViewRow gvr in dg_subject.Rows)
    //        {
    //            cb = (CheckBox)gvr.FindControl("CheckBox1");

    //            if (cb.Checked)
    //            {
    //                subjectId = Convert.ToInt32(dg_subject.DataKeys[gvr.RowIndex].Value.ToString());
    //                //csTa.DeleteSubject(subjectId);
    //                obj.Subject_Id = subjectId;
    //                nAlreadyIn = obj.SubjectDelete(obj);
    //                if (nAlreadyIn != 0)
    //                {
    //                    if (nAlreadyIn == 1)
    //                        drawMsgBox("Subject Not Deleted, Section(s) Already Exists For Subject.");
    //                    else if (nAlreadyIn == 2)
    //                        drawMsgBox("Subject Not Deleted, Student(s) Already Exists For Subject.");
    //                    else if (nAlreadyIn == 3)
    //                        drawMsgBox("Subject Not Deleted, Teacher(s) Already Exists For Subject.");
    //                    else if (nAlreadyIn == 4)
    //                        drawMsgBox("Subject Not Deleted, WorkPlan(s) Already Exists For Subject.");
    //                }
    //                else
    //                {
    //                    drawMsgBox("Subject Successfully Deleted.");
    //                }
    //            }
    //        }


    //        //search();
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
        //try
        //{
        //    TreeView tempView = (TreeView)Master.FindControl("MenuLeft");
        //    TreeNode tn = tempView.FindNode("Functions");
        //    if (tn != null)
        //    {
        //        tn.Expand();
        //        tn.ChildNodes[11].Expand();
        //        tn.ChildNodes[11].Select();
        //    }

        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }
    //protected void drawMsgBox(string msg)
    //{
    //    try
    //    {

    //        MPopEx.Enabled = true;
    //        MPopEx.DropShadow = true;
    //        MPopEx.OkControlID = "msgOK";
    //        MPopEx.CancelControlID = "msgCross";
    //        MPopEx.PopupControlID = "msgBox";
    //        MPopEx.PopupDragHandleControlID = "msgDrag";

    //        msgBox.Visible = true;
    //        msgNote.Text = msg;
    //        MPopEx.Show();


    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}
    //protected void lnkAdd_Click(object sender, EventArgs e)
    //{
    //    SubjectDetailsArea(true);
    //    clearingAppearance();
    //}


    //protected void but_saveClass_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLSubject obj = new BLLSubject();
    //        DataTable dt;
    //        int active = 2;
    //        if (ch_active.Checked)
    //            active = 1;

    //        int moID = Int32.Parse(Session["moID"].ToString());
    //        obj.Main_Organisation_Id = moID;
    //        obj.Subject_Name = text_Subject.Text.ToString();
    //        int n = obj.SubjectNameAvailability(obj);
    //        if (n == 0)
    //        {
    //            obj.Subject_Code =text_subjectCode.Text.Trim();
    //            obj.Main_Organisation_Id = moID;
    //            int c = obj.SubjectCodeAvailability(obj);
    //            if (c == 0)
    //            {
    //                obj.Main_Organisation_Id = moID;
    //                obj.Comments = ta_comments.Text.Trim();
    //                obj.Subject_Name = text_Subject.Text.Trim();
    //                obj.Subject_Code =text_subjectCode.Text.Trim();
    //                obj.Status_Id =active.ToString();
    //                obj.isKPI = "1";
    //                int k = obj.SubjectAdd(obj);
    //                if (k == 1)
    //                {
    //                    ImpromptuHelper.ShowPrompt("Record Already Exist");
    //                }
    //                else if (k == 3)
    //                {
    //                    ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
    //                }
    //                clearingAppearance();
    //                search();
    //                SubjectDetailsArea(false);
    //            }
    //            else
    //            {
    //                drawMsgBox("Subject with this code already exists.");
    //            }
    //        }
    //        else
    //        {
    //            drawMsgBox("Subject with this name already exists.");
    //        }



    //        //else
    //        //{
    //        //    int subID = Int32.Parse(ViewState["SubjectID"].ToString());

    //        //    ManageSubjectTableAdapters.SubjectTableAdapter ta = new ManageSubjectTableAdapters.SubjectTableAdapter();
    //        //    ManageSubject.SubjectDataTable subDt = ta.CheckNameForUpdate(text_Subject.Text.Trim(), moID, subID);
    //        //    if (subDt.Rows.Count == 0)
    //        //    {
    //        //        subDt = ta.CheckCodeForUpdate(text_subjectCode.Text.Trim(), subID);
    //        //        if (subDt.Rows.Count == 0)
    //        //        {
    //        //            obj.Update(text_Subject.Text.Trim(), text_subjectCode.Text.Trim(), active, ta_comments.Text.Trim(), subID);
    //        //            drawMsgBox("Subject successfully updated.");
    //        //            //search();
    //        //            SubjectDetailsArea(false);

    //        //        }
    //        //        else
    //        //        {
    //        //            drawMsgBox("Subject with this code already exists.");
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        drawMsgBox("Subject with this name already exists.");
    //        //    }

    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    //private void SubjectDetailsArea(bool _chk)
    //{
    //    SubDet1.Visible = _chk;
    //    SubDet2.Visible = _chk;
    //}

    //protected void lb_checkName_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLSubject obj = new BLLSubject();
    //        int moID = Int32.Parse(Session["moID"].ToString());

    //        if (!string.IsNullOrEmpty(text_Subject.Text))
    //        {
    //            obj.Subject_Name = text_Subject.Text.Trim();
    //            obj.Main_Organisation_Id = moID;
    //            int k = obj.SubjectNameAvailability(obj);
    //            if (k == 0)
    //            {
    //                lab_availability.Text = "Available";
    //                lab_availability.ForeColor = System.Drawing.Color.Green;
    //            }
    //            else
    //            {
    //                lab_availability.Text = "Already Exist";
    //                lab_availability.ForeColor = System.Drawing.Color.Red;
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}
    //protected void lb_checkCode_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLSubject obj = new BLLSubject();
    //        int moID = Int32.Parse(Session["moID"].ToString());

    //        if (!string.IsNullOrEmpty(text_subjectCode.Text))
    //        {
    //            obj.Subject_Code = text_subjectCode.Text.Trim();
    //            obj.Main_Organisation_Id = moID;
    //            int k = obj.SubjectCodeAvailability(obj);
    //            if (k == 0)
    //            {
    //                lab_codeAvailability.Text = "Available";
    //                lab_codeAvailability.ForeColor = System.Drawing.Color.Green;
    //            }
    //            else
    //            {
    //                lab_codeAvailability.Text = "Already Exist";
    //                lab_codeAvailability.ForeColor = System.Drawing.Color.Red;
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}
    //private void clearingAppearance()
    //{
    //    text_Subject.Text = "";
    //    lab_availability.Text = "";

    //    text_subjectCode.Text = "";
    //    lab_codeAvailability.Text = "";

    //    ch_active.Checked = false;

    //    ta_comments.Text = "";
    //}
    //protected void but_cancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        clearingAppearance();
    //        SubjectDetailsArea(false);
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    //protected void lbtndelete_Click(object sender, EventArgs e)
    //{
    //    LinkButton btn = (LinkButton)sender;
    //     int   SubjectID = Convert.ToInt32(btn.CommandArgument);
    //    obj.Subject_Id = SubjectID;
    //   int k= obj.SubjectDelete(obj);
    //    if (k == 0) { ImpromptuHelper.ShowPrompt("Record Delete UnSuccessfull"); }
    //    if (k == 1) { ImpromptuHelper.ShowPrompt("Record Deleted Successfuly"); }
    //    search();
    //}
}