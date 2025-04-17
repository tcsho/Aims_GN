using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
public partial class PresentationLayer_TCS_Admission_Evaluation_Criteria : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
  
    BLLAdmission_Evaluation_Criteria objAdm = new BLLAdmission_Evaluation_Criteria();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        if (!IsPostBack)
        {
            try
            {
                //======== Page Access Settings ========================
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

                //====== End Page Access settings =====================
                FillActiveSessions();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 14).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillClass();
            ddlClass.SelectedValue = "0";
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
            trHeading.Visible = true;
            objAdm.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objAdm.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            DataTable dt = new DataTable();
            if (ViewState["dtDetails"] == null)
            {
                dt = objAdm.Admission_Evaluation_CriteriaFetch(objAdm);
                ViewState["dtDetails"] = dt;
                foreach (DataRow r in dt.Rows)
                {
                    if (r["Total_Marks"].ToString() == "0.00")
                    {
                        lblNote.Text = "Please Update Marks and Weightage";
                        break;
                    }
                    else
                    {
                        lblNote.Text = "";
                    }
                }
            }
            else
            {
                dt = (DataTable)ViewState["dtDetails"];
            }
            if (dt.Rows.Count == 0)
            {
                InsertDefault();
                dt = objAdm.Admission_Evaluation_CriteriaFetch(objAdm);
            }
            gvCriteria.DataSource = dt;
            gvCriteria.DataBind();  
            
            
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
            ViewState["dtDetails"] = null;
            BindGrid();
            but_cancel_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedIndex > 0)
            {
                trNewHeading.Visible = true;
                trNewInformation.Visible = true;
                ViewState["Mode"] = "Add";
                BindAssignedSubjects();
                txtCriteria.Text = "";
                txtMarks.Text = "";
                txtWeightage.Text = "";
                ddlSubject.SelectedValue = "0";
                ddlSubject.Enabled = true;
                ddlSubject.Visible = true;
                lblSubName.Visible = false;
                txtMarks.Focus();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select a Class");
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
            trNewHeading.Visible = false;
            trNewInformation.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void InsertDefault()
    {
        try
        {
            ViewState["Mode"] = "AddDefault";
            txtCriteria.Text = "Admission Test";
            txtMarks.Text = "0";
            txtWeightage.Text = "0";
            if (Convert.ToInt32(ddlClass.SelectedValue) > 6 && Convert.ToInt32(ddlClass.SelectedValue) < 10)// grade 3 to 5
            {
                for (int i = 11; i <= 13; i++)
                {
                    ViewState["Subject_Id"] = Convert.ToString(i); 
                    but_save_Click(this, EventArgs.Empty);
                }
            }
            else if (Convert.ToInt32(ddlClass.SelectedValue) > 9 && Convert.ToInt32(ddlClass.SelectedValue) < 14)//grade 6 to Olevels
            {
                for (int i = 11; i <= 14; i++)
                {
                    ViewState["Subject_Id"] = Convert.ToString(i); 
                    but_save_Click(this, EventArgs.Empty);
                }
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
        try
        {
            int k = -1;
            objAdm.Criteria = txtCriteria.Text;
            objAdm.Total_Marks = Convert.ToDecimal(txtMarks.Text);
            objAdm.Weightage = Convert.ToDecimal(txtWeightage.Text);
            if (ViewState["Mode"].ToString() == "AddDefault")
            {
                objAdm.Subject_Id = Convert.ToInt32(ViewState["Subject_Id"].ToString());
                objAdm.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objAdm.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                k = objAdm.Admission_Evaluation_CriteriaAdd(objAdm);
            }
            if (ViewState["Mode"].ToString() == "Add")
            {
                objAdm.Subject_Id = Convert.ToInt32(ddlSubject.SelectedValue);
                objAdm.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objAdm.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                k = objAdm.Admission_Evaluation_CriteriaAdd(objAdm);
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else if (ViewState["Mode"].ToString() == "Edit")
            {
                if (ViewState["Subject_Id"].ToString() != "0")
                {
                    objAdm.Subject_Id = Convert.ToInt32(ViewState["Subject_Id"].ToString());
                }
                else
                {
                    objAdm.Subject_Id = Convert.ToInt32(ddlSubject.SelectedValue);
                }
                objAdm.AEC_Id = Convert.ToInt32(ViewState["AEC_Id"].ToString());
                k = objAdm.Admission_Evaluation_CriteriaUpdate(objAdm); 
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            if (k == 0)
            {
              //  ImpromptuHelper.ShowPrompt("Record Updated");
            }
            
            else if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Cannot Update Record");
            }
            but_cancel_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindAssignedSubjects()
    {
        try
        {
            BLLClass_Subject objBllcs = new BLLClass_Subject();
            objBllcs.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);
            objBllcs.Main_Organisation_Id = 1;
            if (objBllcs.Class_ID == 13)
            {
                objBllcs.Class_ID = 12;
            }
            DataTable dt = (DataTable)objBllcs.Class_SubjectSelectAllByClassId(objBllcs);
            if (dt.Rows.Count > 0)
            {
                if (objBllcs.Class_ID >= 10 && objBllcs.Class_ID <= 13)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["Subject_Id"].ToString() == "14" || r["Subject_Id"].ToString() == "13" || r["Subject_Id"].ToString() == "12" || r["Subject_Id"].ToString() == "11"|| r["Subject_Id"].ToString() == "55")
                        {
                            r.Delete();
                        }
                    }
                }
                if (objBllcs.Class_ID >= 7 && objBllcs.Class_ID <= 9)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["Subject_Id"].ToString() == "13" || r["Subject_Id"].ToString() == "12" || r["Subject_Id"].ToString() == "11" || r["Subject_Id"].ToString() == "55")
                        {
                            r.Delete();
                        }
                    }
                }

                objBase.FillDropDown(dt, ddlSubject, "Subject_id", "Subject_Name");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            trNewHeading.Visible = true;
            trNewInformation.Visible = true;
            ViewState["Mode"] = "Edit";
            BindAssignedSubjects();
            ImageButton btnEdit = (ImageButton)(sender);
            objAdm.AEC_Id = Convert.ToInt16(btnEdit.CommandArgument);
            ViewState["AEC_Id"] = btnEdit.CommandArgument;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvCriteria.SelectedIndex = gvr.RowIndex;
            txtCriteria.Text = gvr.Cells[5].Text;
            txtMarks.Text = gvr.Cells[6].Text;
            txtWeightage.Text = gvr.Cells[7].Text;
           
            if (Convert.ToInt32(gvr.Cells[3].Text) >= 11 && Convert.ToInt32(gvr.Cells[3].Text) <= 14
                && Convert.ToInt32(ddlClass.SelectedValue) > 9 && Convert.ToInt32(ddlClass.SelectedValue)<14)
            {
                lblSubName.Text = gvr.Cells[4].Text;
                lblSubName.Visible = true;
                ddlSubject.Visible = false;
                ViewState["Subject_Id"] = gvr.Cells[3].Text;
            }
            else if (Convert.ToInt32(gvr.Cells[3].Text) >= 11 && Convert.ToInt32(gvr.Cells[3].Text) <= 13
                && Convert.ToInt32(ddlClass.SelectedValue) > 6 && Convert.ToInt32(ddlClass.SelectedValue) <10)
            {
                lblSubName.Text = gvr.Cells[4].Text;
                lblSubName.Visible = true;
                ddlSubject.Visible = false;
                ViewState["Subject_Id"] = gvr.Cells[3].Text;
                
            }
            else
            {
                ddlSubject.SelectedValue = gvr.Cells[3].Text;
                ViewState["Subject_Id"] = "0";
                ddlSubject.Visible = true;
                lblSubName.Visible = false;
            }
            
            if (gvr.Cells[10].Text == "False")
            {
                ddlSubject.Enabled = false;
            }
            else
            {
                ddlSubject.Enabled = true;
            }
            ddlSubject.Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnEdit = (ImageButton)(sender);
            objAdm.AEC_Id = Convert.ToInt16(btnEdit.CommandArgument);
            objAdm.Admission_Evaluation_CriteriaDelete(objAdm);
            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void SetEmptyGrid(GridView gv)
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("AEC_Id");
            dt.Columns.Add("Main_Organisation_Id");
            dt.Columns.Add("Session_Id");
            dt.Columns.Add("Subject_Id");
            dt.Columns.Add("Subject_Name");
            dt.Columns.Add("Class_Id");
            dt.Columns.Add("Class_Name");
            dt.Columns.Add("Status_Id");
            dt.Columns.Add("Criteria");
            dt.Columns.Add("Total_Marks");
            dt.Columns.Add("Weightage");
            dt.Rows.Add(dt.NewRow());
            gv.DataSource = dt;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvCriteria_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvCriteria.Rows.Count > 0)
            {
                gvCriteria.UseAccessibleHeader = false;
                gvCriteria.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    BLLAdmission_Center_Evaluation_Criteria obj = new BLLAdmission_Center_Evaluation_Criteria();
        //    foreach (GridViewRow row in gvCriteria.Rows)
        //    {
        //        obj.AEC_Id = Convert.ToInt32(row.Cells[0].Text);
        //        obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
        //        obj.Subject_Id = Convert.ToInt32(row.Cells[3].Text);
        //        obj.Session_Id = Convert.ToInt32(row.Cells[2].Text);
        //        obj.Criteria = row.Cells[5].Text;
        //        obj.Total_Marks = Convert.ToDecimal(row.Cells[6].Text);
        //        obj.Weightage = Convert.ToDecimal(row.Cells[7].Text);
        //        int k= obj.Admission_Center_Evaluation_CriteriaAdd(obj);
        //        if (k == 0)
        //        {
        //            ImpromptuHelper.ShowPrompt("Record Updated");
        //        }
        //        else if (k == 2)
        //        {
        //            ImpromptuHelper.ShowPrompt("Changes were copied to all Centers!");
        //        }
        //        else
        //        {
        //            ImpromptuHelper.ShowPrompt("Record wasn't Updated");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }
}