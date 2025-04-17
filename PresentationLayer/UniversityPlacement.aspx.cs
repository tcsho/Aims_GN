using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_UniversityPlacement : System.Web.UI.Page
{
    BLLUniversityPlacement obj = new BLLUniversityPlacement();
    DataTable dtCs = new DataTable();
    DALBase objBase = new DALBase();
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
                search();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void search()
    {
        try
        {
            ///searching
            ///
            BLLUniversityPlacement obj = new BLLUniversityPlacement();
            DataTable dt;

            //int moId = Int32.Parse(Session["moID"].ToString());

            dt = obj.Get_All_Universities();
            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                ViewState["subjectDT"] = dt;

                dg_Uni.DataSource = dt;
                dg_Uni.DataBind();
                lab_dataStatus.Visible = false;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    //protected void bindGrid()
    //{
    //    int moID = Convert.ToInt32(Session["moID"]);
    //    DataTable dt = null;

    //    dt = obj.SubjectFetchByMoId(moID);

    //    if (dt.Rows.Count == 0)
    //    {
    //        lab_dataStatus.Visible = true;
    //        //pan_New.Attributes.CssStyle.Add("display", "none");
    //    }
    //    else
    //    {
    //        gv_criteriaList.DataSource = dt;
    //        lab_dataStatus.Visible = false;
    //        lab_dataStatus.Visible = false;
    //    }
    //    gv_criteriaList.DataBind();
    //    //pan_New.Attributes.CssStyle.Add("display", "none");


    //    ViewState["CriteriaList"] = dt;

    //}
    protected void dg_Uni_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int ind = Int32.Parse((string)e.CommandArgument);

            if (e.CommandName == "name")
            {
                Session["SubjectID"] = dg_Uni.DataKeys[ind].Value;
                Response.Redirect("SubjectDetail.aspx", false);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private bool validateGrid()
    {
        bool result = false;
        foreach (GridViewRow gRow in dg_Uni.Rows)
        {
            CheckBox chkBox = (CheckBox)gRow.Cells[3].FindControl("CheckBox1");
            if (chkBox.Checked)
            {
                result = true;
            }
        }
        return result;
    }

    protected void but_assignStudents_Click(object sender, EventArgs e)
    {
        //if (!validateGrid())
        //{
        //    drawMsgBox("No Subject is selected for deletion!");
        //    return;
        //}


        try
        {
            CheckBox cb;
            int subjectId;
            int? nAlreadyIn = null;
            BLLSubject obj = new BLLSubject();
            foreach (GridViewRow gvr in dg_Uni.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (cb.Checked)
                {
                    subjectId = Convert.ToInt32(dg_Uni.DataKeys[gvr.RowIndex].Value.ToString());
                    //csTa.DeleteSubject(subjectId);
                    obj.Subject_Id = subjectId;
                    nAlreadyIn = obj.SubjectDelete(obj);
                    if (nAlreadyIn != 0)
                    {
                        if (nAlreadyIn == 1)
                            drawMsgBox("Subject Not Deleted, Section(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 2)
                            drawMsgBox("Subject Not Deleted, Student(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 3)
                            drawMsgBox("Subject Not Deleted, Teacher(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 4)
                            drawMsgBox("Subject Not Deleted, WorkPlan(s) Already Exists For Subject.");
                    }
                    else
                    {
                        drawMsgBox("Subject Successfully Deleted.");
                    }
                }
            }


            //search();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

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
    protected void drawMsgBox(string msg)
    {
        try
        {

            MPopEx.Enabled = true;
            MPopEx.DropShadow = true;
            MPopEx.OkControlID = "msgOK";
            MPopEx.CancelControlID = "msgCross";
            MPopEx.PopupControlID = "msgBox";
            MPopEx.PopupDragHandleControlID = "msgDrag";

            msgBox.Visible = true;
            msgNote.Text = msg;
            MPopEx.Show();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        UniDetailsArea(true);
        clearingAppearance();
    }


    protected void but_saveClass_Click(object sender, EventArgs e)
    {
        try
        {
            BLLUniversityPlacement obj = new BLLUniversityPlacement();
            DataTable dt;
            int statusid = 2;
            if (ch_active.Checked)
                statusid = 1;

            // int moID = Int32.Parse(Session["moID"].ToString());
            // obj.Main_Organisation_Id = moID;
            obj.Uni_Name = text_University.Text.ToString().ToUpper().Trim();
            int n = obj.UniNameAvailability(obj);
            if (n == 0)
            {
                //obj.Subject_Code =text_UniversityCode.Text.Trim();
                // obj.Main_Organisation_Id = moID;
                // int c = obj.SubjectCodeAvailability(obj);

                //obj.Main_Organisation_Id = moID;
                obj.Comments = ta_comments.Text.ToString().ToUpper().Trim();
                obj.Uni_Name = text_University.Text.ToString().ToUpper().Trim();
                //obj.Subject_Code =text_UniversityCode.Text.Trim();
                obj.IsActive = Convert.ToBoolean(ch_active.Checked);
                obj.Status_Id = statusid;
                obj.AddTag = Session["ContactID"].ToString();
                obj.University_Ranking= txtuniranking.Text.ToString().ToUpper().Trim();
                obj.University_Location = txtunilocation.Text.ToString().ToUpper().Trim();
                int k = obj.UniversitytAdd(obj);
                if (k == 1)
                {
                    ImpromptuHelper.ShowPrompt("Record Already Exist");
                }
                else if (k == 3)
                {
                    ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
                }
                clearingAppearance();
                search();
                UniDetailsArea(false);

            }
            else
            {
                drawMsgBox("Subject with this name already exists.");
            }



            //else
            //{
            //    int subID = Int32.Parse(ViewState["SubjectID"].ToString());

            //    ManageSubjectTableAdapters.SubjectTableAdapter ta = new ManageSubjectTableAdapters.SubjectTableAdapter();
            //    ManageSubject.SubjectDataTable subDt = ta.CheckNameForUpdate(text_University.Text.Trim(), moID, subID);
            //    if (subDt.Rows.Count == 0)
            //    {
            //        subDt = ta.CheckCodeForUpdate(text_UniversityCode.Text.Trim(), subID);
            //        if (subDt.Rows.Count == 0)
            //        {
            //            obj.Update(text_University.Text.Trim(), text_UniversityCode.Text.Trim(), active, ta_comments.Text.Trim(), subID);
            //            drawMsgBox("Subject successfully updated.");
            //            //search();
            //            UniDetailsArea(false);

            //        }
            //        else
            //        {
            //            drawMsgBox("Subject with this code already exists.");
            //        }
            //    }
            //    else
            //    {
            //        drawMsgBox("Subject with this name already exists.");
            //    }

            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private void UniDetailsArea(bool _chk)
    {
        SubDet1.Visible = _chk;
        SubDet2.Visible = _chk;
    }

    protected void lb_checkName_Click(object sender, EventArgs e)
    {
        try
        {
            BLLUniversityPlacement obj = new BLLUniversityPlacement();
            // int moID = Int32.Parse(Session["moID"].ToString());

            if (!string.IsNullOrEmpty(text_University.Text))
            {
                obj.Uni_Name = text_University.Text.ToString().Trim();
                //obj.Main_Organisation_Id = moID;
                int k = obj.UniNameAvailability(obj);
                if (k == 0)
                {
                    lab_availability.Text = "Available";
                    lab_availability.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lab_availability.Text = "Already Exist";
                    lab_availability.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    //protected void lb_checkCode_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLSubject obj = new BLLSubject();
    //        int moID = Int32.Parse(Session["moID"].ToString());

    //        if (!string.IsNullOrEmpty(text_UniversityCode.Text))
    //        {
    //            obj.Subject_Code = text_UniversityCode.Text.Trim();
    //            obj.Main_Organisation_Id = moID;
    //            int k = obj.SubjectCodeAvailability(obj);
    //            if (k == 0)
    //            {
    //                //lab_codeAvailability.Text = "Available";
    //               // lab_codeAvailability.ForeColor = System.Drawing.Color.Green;
    //            }
    //            else
    //            {
    //               // lab_codeAvailability.Text = "Already Exist";
    //                //lab_codeAvailability.ForeColor = System.Drawing.Color.Red;
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}
    private void clearingAppearance()
    {
        text_University.Text = "";
        lab_availability.Text = "";

        //text_UniversityCode.Text = "";
        //lab_codeAvailability.Text = "";

        ch_active.Checked = false;

        ta_comments.Text = "";
    }
    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearingAppearance();
            UniDetailsArea(false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void lbtndelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int U_Id = Convert.ToInt32(btn.CommandArgument);
        obj.U_Id = U_Id;
        int k = obj.UniDelete(obj);
        if (k == 0) { ImpromptuHelper.ShowPrompt("Record Delete UnSuccessfull"); }
        if (k == 1) { ImpromptuHelper.ShowPrompt("Record Deleted Successfuly"); }
        search();
        dg_Uni.DataBind();
    }
}