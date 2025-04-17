using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_MarksEntryAcknowledgement : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLMarks_Entry_Acknowledgement objStdWel = new BLLMarks_Entry_Acknowledgement();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception)
        {
        }

        try
        {
            if (!Page.IsPostBack)
            {

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

                int moID = Int32.Parse(Session["moID"].ToString());

                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "check";
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvFirstTerm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFirstTerm.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvFirstTerm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvFirstTerm.Rows)
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
    protected void gvFirstTerm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox btnMarksAck;

        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                btnMarksAck = (CheckBox)e.Row.FindControl("CheckBox1");
                DataRow row = ((DataRowView)e.Row.DataItem).Row;

                if (Convert.ToInt32(row["IsAckg"]) == 1)//Generated
                {
                    btnMarksAck.Enabled = false;

                }
                else if (Convert.ToInt32(row["IsAckg"]) == 0)//Not Generated
                {
                    btnMarksAck.Enabled = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex > 0)
                {
                    int i = e.Row.RowIndex - 1;
                    GridViewRow row = gvFirstTerm.Rows[i];
                    if (row.Cells[4].Text != e.Row.Cells[4].Text)
                    {
                        e.Row.BorderWidth = 5;
                        e.Row.BorderColor = System.Drawing.Color.Indigo;
                        // e.Row.Style.Add("border-bottom-width", "5"); //= "BottomRow";
                        //e.Row.CssClass = "BottomRow";
                        e.Row.ForeColor = System.Drawing.Color.Brown;
                        e.Row.Font.Bold = true;
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

    protected void BindGrid()
    {
        try
        {
            objStdWel.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
            objStdWel.Session_Id = Convert.ToInt32(Session["Session_Id"]);
            //        obj.Section_Id=Convert.ToInt32(ddlClass.SelectedValue.ToString());
            objStdWel.TermGroup_Id = 1;
            DataTable dt = new DataTable();
            DateTime date = DateTime.Now;
            if (date.Month >= 3 && date.Month <= 7)
            {
                objStdWel.TermGroup_Id = 2;
                if (ViewState["GridSecond"] != null)
                {
                    dt = (DataTable)ViewState["GridSecond"];
                }
                else
                {
                    dt = (DataTable)objStdWel.Marks_Entry_AcknowledgementSelectByEmployeeSession(objStdWel);
                }
                gvSecondTerm.DataSource = dt;
                gvSecondTerm.DataBind();
                ViewState["GridSecond"] = dt;

            }
            else
            {
                if (ViewState["GridFirst"] != null)
                {
                    dt = (DataTable)ViewState["GridFirst"];
                }
                else
                {
                    dt = (DataTable)objStdWel.Marks_Entry_AcknowledgementSelectByEmployeeSession(objStdWel);
                }
                gvFirstTerm.DataSource = dt;
                gvFirstTerm.DataBind();
                ViewState["GridFirst"] = dt;

            }
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
            bool chk = false;
            bool chkper = false;
            CheckBox cb = null;

            DataRow row = (DataRow)Session["rightsRow"];
            int month = DateTime.Now.Month;
            if(month>=3 && month<=9) //March - September 
            {
                foreach (GridViewRow gvr in gvSecondTerm.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (cb.Checked)
                    {
                        objStdWel.Section_Subject_Id = Convert.ToInt32(gvr.Cells[1].Text);
                        objStdWel.Evaluation_Criteria_Type_Id = Convert.ToInt32(gvr.Cells[2].Text);
                        objStdWel.Session_Id = Convert.ToInt32(Session["Session_Id"]);

                        objStdWel.CreatedOn = DateTime.Now;
                        objStdWel.CreatedBy = Convert.ToInt32(Session["ContactID"]);
                        decimal Percentage = Convert.ToDecimal(gvr.Cells[12].Text);


                        int Subject_Id = Convert.ToInt32(gvr.Cells[16].Text);
                        int Class_Id = Convert.ToInt32(gvr.Cells[17].Text);

                        if (Percentage < 90)
                        {

                            if ((Class_Id >= 14) && Percentage >= 60)
                            {
                                int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                                if (AlreadyIn == 0)
                                {
                                    chk = true;
                                }
                            }

                            else
                            {
                                chkper = true;
                            }


                            if (Subject_Id == 4 && Percentage >= 70)
                            {
                                int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                                if (AlreadyIn == 0)
                                {
                                    chk = true;
                                }

                            }
                            else
                            {
                                chkper = true;
                            }




                        }
                        else
                        {
                            int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                            if (AlreadyIn == 0)
                            {
                                chk = true;
                            }
                        }


                    }
                }
            }
            else
            {
                foreach (GridViewRow gvr in gvFirstTerm.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (cb.Checked)
                    {
                        objStdWel.Section_Subject_Id = Convert.ToInt32(gvr.Cells[1].Text);
                        objStdWel.Evaluation_Criteria_Type_Id = Convert.ToInt32(gvr.Cells[2].Text);
                        objStdWel.Session_Id = Convert.ToInt32(Session["Session_Id"]);

                        objStdWel.CreatedOn = DateTime.Now;
                        objStdWel.CreatedBy = Convert.ToInt32(Session["ContactID"]);
                        decimal Percentage = Convert.ToDecimal(gvr.Cells[12].Text);
                        int Subject_Id = Convert.ToInt32(gvr.Cells[16].Text);
                        int Class_Id = Convert.ToInt32(gvr.Cells[17].Text);

                        if (Percentage < 90)
                        {

                            if ((Class_Id >= 19) && Percentage >= 80)
                            {
                                int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                                if (AlreadyIn == 0)
                                {
                                    chk = true;
                                }
                            }


                            if (Subject_Id == 4 && Percentage >= 70)
                            {
                                int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                                if (AlreadyIn == 0)
                                {
                                    chk = true;
                                }

                            }
                            else
                            {
                                chkper = true;
                            }




                        }
                        else
                        {
                            int AlreadyIn = objStdWel.Marks_Entry_AcknowledgementAdd(objStdWel);
                            if (AlreadyIn == 0)
                            {
                                chk = true;
                            }
                        }

                    }
                }
            }
            if (chk == true && chkper == false)
            {
                ViewState["tMood"] = "check";
                ImpromptuHelper.ShowPrompt("Marks completion acknowledgement has been saved for selected Class-Section-Subject(s)");
                ViewState["GridFirst"] = null;
                ViewState["GridSecond"] = null;
                BindGrid();
            }



            else
            {
                ViewState["tMood"] = "check";
                ImpromptuHelper.ShowPrompt("Marks entry acknowledgement less than 90% would not be saved!");
                ViewState["GridFirst"] = null;
                ViewState["GridSecond"] = null;
                BindGrid();
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
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void gvSecondTerm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSecondTerm.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvSecondTerm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvSecondTerm.Rows)
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
    protected void gvSecondTerm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox btnMarksAck;

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                btnMarksAck = (CheckBox)e.Row.FindControl("CheckBox1");
                DataRow row = ((DataRowView)e.Row.DataItem).Row;

                if (Convert.ToInt32(row["IsAckg"]) == 1)//Generated
                {
                    btnMarksAck.Enabled = false;

                }
                else if (Convert.ToInt32(row["IsAckg"]) == 0)//Not Generated
                {
                    btnMarksAck.Enabled = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex > 0)
                {
                    int i = e.Row.RowIndex - 1;
                    GridViewRow row = gvSecondTerm.Rows[i];
                    if (row.Cells[4].Text != e.Row.Cells[4].Text)
                    {
                        e.Row.BorderWidth = 5;
                        e.Row.BorderColor = System.Drawing.Color.Indigo;
                        e.Row.ForeColor = System.Drawing.Color.Brown;
                        e.Row.Font.Bold = true;
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

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["GridFirst"] = null;
            ViewState["GridSecond"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}