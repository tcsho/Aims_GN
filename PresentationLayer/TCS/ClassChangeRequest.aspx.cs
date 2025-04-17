using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_ClassChangeRequest : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLClass_Change_Request objreq = new BLLClass_Change_Request();
    BLLClass_Change_Reasons objreason = new BLLClass_Change_Reasons();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // ======== Page Access Settings ========================//
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }

                //  ====== End Page Access settings ======================//

                btnSearch.Focus();
            }
            btnSearch.Focus();

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlReason_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList dropdownlist = (DropDownList)gvr.FindControl("ddlReason");
            if (dropdownlist.SelectedItem.Text.Trim() == "Others")
            {
                (gvr.FindControl("txtOthers") as TextBox).Visible = true;
                (gvr.FindControl("lblOthers") as Control).Visible = true;
            }
            else
            {
                (gvr.FindControl("txtOthers") as TextBox).Visible = false;
                (gvr.FindControl("lblOthers") as Control).Visible = false;
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*  Fill Required Class */
                DropDownList dropdown = e.Row.FindControl("ddlToClass") as DropDownList;
                if (dropdown != null)
                {
                    DataTable dt = new DataTable();
                    BLLClass_Center obj = new BLLClass_Center();
                    if (ViewState["ClassData"] == null)
                    {
                        ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
                        UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
                        DropDownList ddl = (DropDownList)uc.FindControl("list_center") as DropDownList;
                        dt = obj.Class_CenterFetch(Convert.ToInt32(ddl.SelectedValue));
                        ViewState["ClassData"] = dt;
                    }
                    dt = (DataTable)ViewState["ClassData"];
                    objBase.FillDropDown(dt, dropdown, "Class_Id", "Class_Name");
                    if ((e.Row.FindControl("lblToClass") as Label).Text != "0")
                    {
                        dropdown.Items.FindByValue((e.Row.FindControl("lblToClass") as Label).Text).Selected = true;
                    }
                }
                /*  Fill Reason */
                DropDownList ddlreason = e.Row.FindControl("ddlReason") as DropDownList;
                if (dropdown != null)
                {
                    DataTable dt = new DataTable();
                    BLLClass_Center obj = new BLLClass_Center();
                    dt = (DataTable)ViewState["Reason"];
                    objBase.FillDropDown(dt, ddlreason, "CCReason_Id", "Reason_Description");
                    (e.Row.FindControl("divComments") as Control).Visible = false;
                    if ((e.Row.FindControl("lblreason") as Label).Text != "0")
                    {
                        ddlreason.Items.FindByValue((e.Row.FindControl("lblreason") as Label).Text).Selected = true;
                        if (ddlreason.SelectedItem.Text == "Others")
                        {
                            //(e.Row.FindControl("divschoolHead") as Control).Visible = true;
                            (e.Row.FindControl("divComments") as Control).Visible = true;
                            
                        }
                        
                    }
                }
                if ((e.Row.FindControl("lbllock") as Label).Text != "0")
                {
                    ddlreason.Enabled = false;
                    dropdown.Enabled = false;
                }

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvStudent_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudent.Rows.Count > 0)
            {
                gvStudent.UseAccessibleHeader = false;
                gvStudent.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = gvr.RowIndex;
            objreq.Student_Id = Convert.ToInt32(btn.CommandArgument);
            DropDownList ddl = (DropDownList)gvr.FindControl("ddlToClass");
            DropDownList ddlreason = (DropDownList)gvr.FindControl("ddlReason");
            TextBox txtOther = (gvr.FindControl("txtOthers") as TextBox);
            if (ddl.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please Select the required Class!");
                return;
            }

            if (ddlreason.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please Select a reason for class Change!");
                return;
            }
            objreq.ToClass_Id = Convert.ToInt32(ddl.SelectedValue);
            objreq.CCReason_Id = Convert.ToInt32(ddlreason.SelectedValue);
            if (txtOther.Visible == true)
                objreq.Comments = txtOther.Text;
            else
                objreq.Comments = null;
            objreq.CCReq_Id=Convert.ToInt32(gvr.Cells[0].Text);
            objreq.Submit_By = Convert.ToInt32(Session["ContactID"].ToString());
            int k = objreq.Class_Change_RequestAdd(objreq);
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Request Submitted!");
                gvStudent.DataSource = null;
                gvStudent.DataBind();
            }
            ViewState["Students"] = null;
            BindGridSearch();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnPending_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(2, "1"); //case 4 and 2 pending requests
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowApproved_Click(object sender, EventArgs e)
    {

        try
        {
            ResetFilter();
            ApplyFilter(1, "True"); //case 4 and 1 approved requests
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowDisApproved_Click(object sender, EventArgs e)
    {

        try
        {
            ResetFilter();
            ApplyFilter(1, "False"); //case 4 and 0 unapproved requests
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilter(int _FilterCondition, string value)
    {
        try
        {

            if (ViewState["Students"] != null)
            {
                DataTable dt = (DataTable)ViewState["Students"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {

                    case 1: // Filter approved, unapproved
                        {

                            strFilter += "  Convert([isApproved], 'System.String')='" + value + "'";
                            break;
                        }
                    case 2: // Filter pending 
                        {

                            strFilter += "  Convert([isSubmit], 'System.String')='" + value + "'";

                            break;
                        }
                    case 3: // Filter pending 
                        {

                            strFilter += "  Convert([Student_No], 'System.String')='" + value + "'";

                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvStudent.DataSource = dv;
                gvStudent.DataBind();
                gvStudent.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilter()
    {
        try
        {
            BindGridSearch();
            gvStudent.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Students"] = null;
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void BindGridSearch()
    {
        try
        {
            DataTable dtreason = new DataTable();
            if (ViewState["Reason"] != null)
                dtreason = (DataTable)ViewState["Reason"];
            else
                dtreason = objreason.Class_Change_ReasonsFetch();
            ViewState["Reason"] = dtreason;
            DataTable dt = new DataTable();
            if (ViewState["Students"] == null)
            {
                ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
                UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
                objreq.First_Name = (uc.FindControl("text_firstName") as TextBox).Text;
                objreq.Last_Name = (uc.FindControl("text_lastName") as TextBox).Text;
                objreq.Middle_Name = (uc.FindControl("text_middleName") as TextBox).Text;
                objreq.Date_Of_Birth = (uc.FindControl("text_dateOfBirth") as TextBox).Text;
                objreq.Gender_Id = (uc.FindControl("list_gender") as DropDownList).SelectedValue;
                objreq.Student_No = (uc.FindControl("text_studentNo") as TextBox).Text;
                objreq.Region_Id = Convert.ToInt32((uc.FindControl("list_region") as DropDownList).SelectedValue);
                objreq.Student_Status_Id = (uc.FindControl("list_studentStatus") as DropDownList).SelectedValue;
                objreq.Center_Id = Convert.ToInt32((uc.FindControl("list_center") as DropDownList).SelectedValue);

                objreq.Grade_Id = (uc.FindControl("list_class") as DropDownList).SelectedValue;
                objreq.Section_Id = (uc.FindControl("list_section") as DropDownList).SelectedValue;
                objreq.Main_Organisation_Id = Session["moId"].ToString();
                objreq.Teacher_Id = (uc.FindControl("list_teacher") as DropDownList).SelectedValue;

                objreq.EndIndex = "";
                objreq.StartIndex = "";

                dt = objreq.Class_Change_RequestFetch(objreq);
            }
            else
                dt = (DataTable)ViewState["Students"];

            ViewState["Students"] = dt;

            if (dt.Rows.Count > 0)
                divStudentTitle.Visible = true;
            else
                divStudentTitle.Visible = false;
            gvStudent.DataSource = dt;
            gvStudent.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void BindReportCardGrid(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = true;
            LinkButton btn = (LinkButton)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = r.RowIndex;
            BLLSearchStudent objSer = new BLLSearchStudent();
            objSer.Student_Id = Convert.ToInt32(btn.CommandArgument);
            DataTable dt = objSer.SearchStudentResultCard(objSer);

            ResetFilter();
            ApplyFilter(3, objSer.Student_Id.ToString());
            gvReportCard.DataSource = dt;
            gvReportCard.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvReportCard_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvReportCard.Rows.Count > 0)
            {
                gvReportCard.UseAccessibleHeader = false;
                gvReportCard.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "../TCS";
            Button btn = (Button)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            gvReportCard.SelectedIndex = r.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Section_Id = Convert.ToInt32(r.Cells[4].Text); // remove dependency over section id for result
            obj.Student_Id = Convert.ToInt32(r.Cells[0].Text);
            obj.Session_Id = Convert.ToInt32(r.Cells[1].Text);
            obj.Class_Id = Convert.ToInt32(r.Cells[3].Text);
            obj.TermGroup_Id = Convert.ToInt32(r.Cells[2].Text);
            url = url + obj.OpenReport(obj);
            if (!String.IsNullOrEmpty(url))
            {
                //url = "../PresentationLayer/TCS/" + url;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            btnCancel.Visible = false;
            gvReportCard.DataSource = null;
            gvReportCard.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}