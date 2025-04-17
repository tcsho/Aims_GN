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

public partial class PresentationLayer_TCS_ClassSectionDaysAttCom : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLStudent_Performance_Grading_Mst ObjMst = new BLLStudent_Performance_Grading_Mst();

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
                bindClassSection();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    
    protected void bindClassSection()
    {
        try
        {

            BLLClass_Section obj = new BLLClass_Section();

            obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"]);

            DataTable dt = (DataTable)obj.Class_SectionByClassTeacherId(obj);
            objBase.FillDropDown(dt, ddlClass, "Section_id", "FullClassSection");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void bindTermList()
    {
        try
        {
        DataTable dt = null;
        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        ObjECT.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
        dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
        objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
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
        TextBox txt_TeacherComments;
        //TextBox txt_DaysAttended;
        int Student_Id;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            txt_TeacherComments = (TextBox)e.Row.FindControl("txt_TeacherComments");
            //txt_DaysAttended = (TextBox)e.Row.FindControl("txt_DaysAttended");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;

            Student_Id = Convert.ToInt32(row[0].ToString());
            ObjMst.Student_Id = Student_Id;
            ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue);
            ObjMst.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
            ObjMst.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            DataTable _dt = ObjMst.Student_Performance_Grading_MstFetch(ObjMst);
            if (_dt.Rows.Count > 0)
            {
                //txt_DaysAttended.Text = _dt.Rows[0]["DaysAttend"].ToString();
                txt_TeacherComments.Text = _dt.Rows[0]["ClassTeacherComments"].ToString();
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
        BLLStudent objStudent = new BLLStudent();
        DataTable dt = new DataTable();

        if (Convert.ToInt32(ddlClass.SelectedValue) > 0)
        {
            objStudent.Session_Id = Convert.ToInt32(Session["Session_Id"]);

            objStudent.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);

            if (ViewState["Grid"] != null)
            {
                dt = (DataTable)ViewState["Grid"];
            }
            else
            {
                dt = objStudent.StudentSelectBySectionID(objStudent);
            }
            gvRegStudents.DataSource = dt;
            gvRegStudents.DataBind();
            ViewState["Grid"] = dt;

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
        if (ddlClass.SelectedValue != "")
        {
            WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
            objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
            objWLA._ddl = ddlClass;
            objWLA.ISWelcomeAcknowledge(objWLA);

            bindTermList();
            gvRegStudents.DataSource = null;
            gvRegStudents.DataBind();

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

        TextBox txt_TeacherComments;
        //TextBox txt_DaysAttended;
        int Student_Id, AlreadyIn;
        bool chk;
        chk = false;



        try
        {

            foreach (GridViewRow gvr in gvRegStudents.Rows)
            {
                txt_TeacherComments = (TextBox)gvr.FindControl("txt_TeacherComments");
                //txt_DaysAttended = (TextBox)gvr.FindControl("txt_DaysAttended");

                Student_Id = Convert.ToInt32(gvr.Cells[0].Text.ToString());
                ObjMst.Student_Id = Student_Id;
                ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue);
                ObjMst.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
                ObjMst.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

                ObjMst.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                ObjMst.Status_Id = 1;
                ObjMst.ClassTeacherComments = txt_TeacherComments.Text;
                ObjMst.DaysAttend = "0";

                ObjMst.CreatedOn = DateTime.Now;
                ObjMst.CreatedBy = Int32.Parse(Session["ContactId"].ToString());
                AlreadyIn = ObjMst.Student_Performance_Grading_MstAddAttenDaysCommentsNew(ObjMst);
                if (AlreadyIn == 1)
                {
                    chk = true;
                }

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        if (chk == true)
        {
            ViewState["tMood"] = "check";
            ImpromptuHelper.ShowPrompt("Student attendance and teacher comments saved sucessfully.");
            ViewState["Grid"] = null;
            BindGrid();
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
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            BLLClass_Section OBJCS = new BLLClass_Section();
            OBJCS.Center_Id = Convert.ToInt32(Session["cId"]);
            OBJCS.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
            DataTable dt = OBJCS.Class_SectionByCenterSectionId(OBJCS);

            int Class_Id = Convert.ToInt32(dt.Rows[0]["Class_Id"].ToString());
            if (Class_Id > 12)
            {


                if (Class_Id == 17 || Class_Id == 18 ) 
                {
                    ViewState["Grid"] = null;
                    BindGrid();
                }
                else
                {
                    gvRegStudents.DataSource = null;
                    gvRegStudents.DataBind();
                    ImpromptuHelper.ShowPrompt("Class Teacher Comments are not required for this Class Level.");

                }



            }
            else
            {
                ViewState["Grid"] = null;
                BindGrid();
            }




            //if (list_term.SelectedItem.Text != "Mock Examination")
            //{


            //    if (Class_Id==13 && list_term.SelectedItem.Text=="Second Term")
            //    {
            //        gvRegStudents.DataSource = null;
            //        gvRegStudents.DataBind();
            //        ImpromptuHelper.ShowPrompt("Class Teacher Comments are not required for this Term.");
                    
            //    }
            //    else
            //    {
            //        ViewState["Grid"] = null;
            //        BindGrid();
            //    }
                
            //}
            //else
            //{


            //    gvRegStudents.DataSource = null;
            //    gvRegStudents.DataBind();
            //    ImpromptuHelper.ShowPrompt("Class Teacher Comments are not required for this Term.");
            //}


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}