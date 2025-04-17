
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

public partial class PresentationLayer_TCS_ClassSectionDaysAtt : System.Web.UI.Page
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
                BindTermDays();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindTermDays()
    {
        try
        {
        //DataRow row = (DataRow)Session["rightsRow"];
        //BLLRegion objReg = new BLLRegion();
        //int region_Id = Convert.ToInt32(row["Region_Id"].ToString());
        //DataTable dt = objReg.RegionFetch(region_Id);
        //ViewState["RegionInfo"] = dt;

        DataRow row = (DataRow)Session["rightsRow"];
        BLLCenter objCen = new BLLCenter();
        objCen.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
        DataTable dt = objCen.CenterFetchByCenterID(objCen);
        ViewState["CenterInfo"] = dt;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    
    }
    protected void BindTermDaysCenter()
    {


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

            throw ex;
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
        int val=list_term.Items.Count;
        //for (int i = 0; i < list_term.Items.Count; i++)
        //{
        //    if (i>1)
        //    {
        //        list_term.Items.RemoveAt(i);
        //    }
        //}
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
        TextBox txt_DaysAttended;
        RangeValidator rv; 
        int Student_Id;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            txt_TeacherComments = (TextBox)e.Row.FindControl("txt_TeacherComments");
            txt_DaysAttended = (TextBox)e.Row.FindControl("txt_DaysAttended");
            rv = (RangeValidator)e.Row.FindControl("DARVal");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;

            Student_Id = Convert.ToInt32(row[0].ToString());
            ObjMst.Student_Id = Student_Id;
            ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue);
            ObjMst.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
            ObjMst.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            DataTable _dt = ObjMst.Student_Performance_Grading_MstFetch(ObjMst);
            
            //DataTable _dtSTermDays = ObjMst.Evaluation_Criteria_Type_Id;


            if (_dt.Rows.Count > 0)
            {
                txt_DaysAttended.Text = _dt.Rows[0]["DaysAttend"].ToString();
                txt_TeacherComments.Text = _dt.Rows[0]["ClassTeacherComments"].ToString();
            }
          //  DataTable _dtr=(DataTable)ViewState["CenterInfo"];
            //DataTable _dtr = (DataTable)ViewState["RegionInfo"];
                        
            rv.MinimumValue = "0";
//            rv.MaximumValue = _dtr.Rows[0]["FirstTermDays"].ToString();
            rv.MaximumValue = row[9].ToString();
            rv.ErrorMessage = "Value must be a number between 0 and "+rv.MaximumValue;
                       
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

        if (Convert.ToInt32(list_term.SelectedValue) > 0)
        {
            objStudent.Session_Id = Convert.ToInt32(Session["Session_Id"]);

            objStudent.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
            objStudent.Term_Id = Convert.ToInt32(list_term.SelectedValue);
            if (ViewState["Grid"] != null)
            {
                dt = (DataTable)ViewState["Grid"];
            }
            else
            {
                dt = objStudent.StudentSelectBySectionIDTerm(objStudent);
            }
            gvRegStudents.DataSource = dt;
            gvRegStudents.DataBind();
            ViewState["Grid"] = dt;

        }
        else
        {
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
        TextBox txt_DaysAttended;
        int Student_Id, AlreadyIn;
        bool chk;
        chk = false;



        try
        {

            foreach (GridViewRow gvr in gvRegStudents.Rows)
            {
                txt_TeacherComments = (TextBox)gvr.FindControl("txt_TeacherComments");
                txt_DaysAttended = (TextBox)gvr.FindControl("txt_DaysAttended");

                Student_Id = Convert.ToInt32(gvr.Cells[0].Text.ToString());
                ObjMst.Student_Id = Student_Id;
                ObjMst.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue);
                ObjMst.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);
                ObjMst.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

                ObjMst.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                ObjMst.Status_Id = 1;
                ObjMst.ClassTeacherComments = txt_TeacherComments.Text;
                ObjMst.DaysAttend = txt_DaysAttended.Text;

                ObjMst.CreatedOn = DateTime.Now;
                ObjMst.CreatedBy = Int32.Parse(Session["ContactId"].ToString());
                AlreadyIn = ObjMst.Student_Performance_Grading_MstAddAttenDaysComments(ObjMst);
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
            ImpromptuHelper.ShowPrompt("Student attendance saved sucessfully.");
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
        ViewState["Grid"] = null;
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}