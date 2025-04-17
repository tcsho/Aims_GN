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

public partial class PresentationLayer_ClassSectionWelcomeLetter : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLClass_Section_Welcome objStdWel = new BLLClass_Section_Welcome();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
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
                    Response.Redirect("~/login.aspx",false);
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


    protected void gvRegStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvRegStudents.PageIndex = e.NewPageIndex;
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvRegStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        CheckBox btnGenerateLetter;
        ImageButton btnPrintChallan;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            btnGenerateLetter = (CheckBox)e.Row.FindControl("CheckBox1");
            btnPrintChallan = (ImageButton)e.Row.FindControl("btnPrintChallan");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;

            if (Convert.ToInt32(row["IsWelcomeLetter"]) == 1)//Generated
            {
                //btnPrintChallan.Visible = true;
                btnGenerateLetter.Enabled = false;
            }
            else if (Convert.ToInt32(row["IsWelcomeLetter"]) == 0)//Not Generated
            {
               // btnPrintChallan.Visible = false;
                btnGenerateLetter.Enabled = true;
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
        BLLClass_Section obj = new BLLClass_Section();

        obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);
        obj.Session_Id = Convert.ToInt32(Session["Session_Id"]);

        DataTable dt = new DataTable();

            if (ViewState["Grid"] != null)
            {
                dt = (DataTable)ViewState["Grid"];
            }
            else
            {
                dt = (DataTable)obj.Class_SectionWelcomeByClassTeacherId(obj);
            }
            gvRegStudents.DataSource = dt;
            gvRegStudents.DataBind();
            ViewState["Grid"] = dt;
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
        ViewState["Grid"] = null;
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    //public void btnGenerateLetter_Click(object sender, EventArgs e)
    //{
    //    ImageButton btn = (ImageButton)sender;
    //    GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    //    objStdWel.Student_Id = Convert.ToInt32(btn.CommandArgument);
    //    objStdWel.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
    //    int AlreadyIn = objStdWel.Student_WelcomeAdd(objStdWel);
    //    if (AlreadyIn == 1)
    //    {
    //        ImpromptuHelper.ShowPrompt("Welcome Letter has been genetaed for this student!");
    //        ViewState["Grid"] = null;
    //        BindGrid();
    //    }


    //}

    public void btnPrintLetter_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btn = (ImageButton)sender;
        int class_Id = Convert.ToInt32(btn.CommandArgument);

        switch (class_Id)
        {
            case 2: // Play Group
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Toddler_KG.rpt");
                Session["rep"] = "WelcomeLetter_Toddler_KG.rpt";

                break;
            case 3: // Nursery
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Toddler_KG.rpt");
                Session["rep"] = "WelcomeLetter_Toddler_KG.rpt";

                break;
            case 4: // KG
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Toddler_KG.rpt");
                Session["rep"] = "WelcomeLetter_Toddler_KG.rpt";

                break;



            case 5: //Class 1
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_1_2.rpt");
                Session["rep"] = "WelcomeLetter_Class_1_2.rpt";

                break;
            case 6: //Class 2
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_1_2.rpt");
                Session["rep"] = "WelcomeLetter_Class_1_2.rpt";

                break;


            case 7: //Class 3
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_3_5.rpt");
                Session["rep"] = "WelcomeLetter_Class_3_5.rpt";

                break;
            case 8: //Class 4
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_3_5.rpt");
                Session["rep"] = "WelcomeLetter_Class_3_5.rpt";

                break;
            case 9: //Class 5
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_3_5.rpt");
                Session["rep"] = "WelcomeLetter_Class_3_5.rpt";

                break;




            case 10: //Class 6
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_6.rpt");
                Session["rep"] = "WelcomeLetter_Class_6.rpt";

                break;
            case 11: //Class 7
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_7.rpt");
                Session["rep"] = "WelcomeLetter_Class_7.rpt";

                break;
            case 12: //Class 8
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_8.rpt");
                Session["rep"] = "WelcomeLetter_Class_8.rpt";

                break;




            case 13: //Class 9(Olevel)
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_9.rpt");
                Session["rep"] = "WelcomeLetter_Class_9.rpt";

                break;
            case 14: //Class 10(Olevel)
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_10.rpt");
                Session["rep"] = "WelcomeLetter_Class_10.rpt";

                break;

            case 15: //Class 11(Olevel)
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_11.rpt");
                Session["rep"] = "WelcomeLetter_Class_11.rpt";

                break;


            case 19: //Class A1(Alevel)
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_A1.rpt");
                Session["rep"] = "WelcomeLetter_Class_A1.rpt";

                break;

            case 20://Class A2(Alevel)
                Session["reppath"] = Server.MapPath("~/PresentationLayer/TCS/Reports/WelcomeLetter_Class_A2.rpt");
                Session["rep"] = "WelcomeLetter_Class_A2.rpt";

                break;

            default:
                break;
        }

        Session["RptTitle"] = "";
        Session["CriteriaRpt"] = " {Student.Main_Organisation_Id}=1 and {Student.Region_Id}=3000000 and {Student.Center_Id}=3010301 and {Student.Student_Id}=105451";
        Session["LastPage"] = "~/PresentationLayer/ClassSectionWelcomeLetter.aspx";
        Response.Redirect("~/PresentationLayer/TCS/TssCrystalReports.aspx",false);
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
        CheckBox cb = null;
        foreach (GridViewRow gvr in gvRegStudents.Rows)
        {
            cb = (CheckBox)gvr.FindControl("CheckBox1");

            if (cb.Checked)
            {
                objStdWel.Section_Id = Convert.ToInt32(gvr.Cells[1].Text);
                objStdWel.Session_Id = Convert.ToInt32(Session["Session_Id"]);
                objStdWel.CreatedOn = DateTime.Now;
                objStdWel.CreatedBy = Convert.ToInt32(Session["ContactID"]);
                int AlreadyIn = objStdWel.Class_Section_WelcomeAdd(objStdWel);
                if (AlreadyIn == 0)
                {
                    chk = true;
                }


            }
        }

        if (chk == true)
        {
            ViewState["tMood"] = "check";
            ImpromptuHelper.ShowPrompt("Welcome Letters issued for selected class section.");
            ViewState["Grid"] = null;
            BindGrid();
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvRegStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
        if (e.CommandName == "toggleCheck")
        {
            CheckBox cb = null;
            string mood = ViewState["tMood"].ToString();

            foreach (GridViewRow gvr in gvRegStudents.Rows)
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