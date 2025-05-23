﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_StudentsResultsMsgs_EOY : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillActiveSessions();
            bindTermGroupList();
            exec_SP();

        }
    }

    public void exec_SP()
    {
        SqlParameter[] param = new SqlParameter[2];
        DataTable dt = new DataTable();
        param[0] = new SqlParameter("@Session_Id", ddlSession.SelectedValue.ToString().Trim());
        param[1] = new SqlParameter("@TermGroup_Id", ddlTerm.SelectedValue.ToString().Trim());
        if (ddlrptname.SelectedValue.ToString().Trim() == "1")
        {
            dt = objBase.sqlcmdFetch("sp_ResultStudentAll_EOY_WinterCapmus", param);
            Label1.Text = "Student Result Sent Messages for Winter Campus-(EOY)";
        }
        else
        {
            dt = objBase.sqlcmdFetch("sp_ResultStudentAll_EOY", param);
            Label1.Text = "Student Result Sent Messages-(EOY)";
        }
        if (dt.Rows.Count > 0)
        {
            Grid_IEPStudents.DataSource = dt;
            Grid_IEPStudents.DataBind();
        }
        else
        {
            Grid_IEPStudents.DataSource = null;
            Grid_IEPStudents.DataBind();
        }
        dt.Dispose();

    }
    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid_IEPStudents.Rows.Count > 0)
            {
                Grid_IEPStudents.UseAccessibleHeader = false;
                Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //protected void txt_view_Click(object sender, EventArgs e)
    //{
    //    Button btn = sender as Button;
    //    GridViewRow row = btn.NamingContainer as GridViewRow;
    //  //  string pk = e.DataKeys[row.RowIndex].Values[0].ToString();
    //  //  Response.Redirect("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + spnErpNo.InnerText + "&C=" + hd_section_id.Value + "&T=" + 1);
    //}

    protected void Grid_IEPStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string URL = e.CommandArgument.ToString();
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        if (URL != "")
        {
            Response.Redirect(URL);
        }
        else
        {
            lblGridStatus.Text = "Result Not Exists..";
        }
        

    }

    //*****************************************************************

    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void bindTermGroupList()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
            if (dt.Rows.Count > 0)
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    ddlTerm.SelectedValue = "2";
                else
                    ddlTerm.SelectedValue = "1";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        exec_SP();
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            exec_SP();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void ddlrptname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            exec_SP();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }





}