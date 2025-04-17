using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PresentationLayer_TCS_UnassignSubjectaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //======== Page Access Settings ========================
                //DALBase objBase = new DALBase();
                //DataRow row = (DataRow)Session["rightsRow"];
                //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                //string sRet = oInfo.Name;


                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}
            }
        }
        catch(Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindGridSearch()
    {
        try
        {

            BLLSearchStudent objSer = new BLLSearchStudent();
            ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
            DataTable dt = new DataTable();

            objSer.First_Name = (uc.FindControl("text_firstName") as TextBox).Text;
            objSer.Last_Name = (uc.FindControl("text_lastName") as TextBox).Text;
            objSer.Middle_Name = (uc.FindControl("text_middleName") as TextBox).Text;
            objSer.Date_Of_Birth = (uc.FindControl("text_dateOfBirth") as TextBox).Text;
            objSer.Gender_Id = (uc.FindControl("list_gender") as DropDownList).SelectedValue;
            objSer.Student_No = (uc.FindControl("text_studentNo") as TextBox).Text;
            objSer.Region_Id = (uc.FindControl("list_region") as DropDownList).SelectedValue;
            objSer.Student_Status_Id = (uc.FindControl("list_studentStatus") as DropDownList).SelectedValue;
            objSer.Center_Id = (uc.FindControl("list_center") as DropDownList).SelectedValue;

            objSer.Grade_Id = (uc.FindControl("list_class") as DropDownList).SelectedValue;
            objSer.Section_Id = (uc.FindControl("list_section") as DropDownList).SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = (uc.FindControl("list_teacher") as DropDownList).SelectedValue;

            objSer.EndIndex = "";
            objSer.StartIndex = "";
            dt = objSer.SearchStudent_UnassignSubject(objSer);
            if (dt.Rows.Count > 0)
            {
                tdSearch.Visible = true;
                gvStudentSubject.DataSource = dt;
            }
            else
                gvStudentSubject.DataSource = dt;
            gvStudentSubject.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvStudentSubject_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudentSubject.Rows.Count > 0)
            {
                gvStudentSubject.UseAccessibleHeader = false;
                gvStudentSubject.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnUnassign_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Section_Subject objBll = new BLLStudent_Section_Subject();
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudentSubject.SelectedIndex = gvr.RowIndex;
            objBll.Student_Id = Convert.ToInt32(gvr.Cells[4].Text);
            objBll.Session_Id = Convert.ToInt32(gvr.Cells[2].Text);
            objBll.Section_Subject_Id = Convert.ToInt32(gvr.Cells[1].Text);
            int k= objBll.Student_Secttion_Subject_UnAssign(objBll);
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Section_Subject objBll = new BLLStudent_Section_Subject();
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudentSubject.SelectedIndex = gvr.RowIndex;
            objBll.Student_Id = Convert.ToInt32(gvr.Cells[4].Text);
            objBll.Session_Id = Convert.ToInt32(gvr.Cells[2].Text);
            objBll.Section_Subject_Id = Convert.ToInt32(gvr.Cells[1].Text);
            objBll.Student_Secttion_Subject_AssignUpdate(objBll);
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}