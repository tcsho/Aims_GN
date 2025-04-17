using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_Admission_Registeration_Summary : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLAdmStudentDiscretionalRequest objReq = new BLLAdmStudentDiscretionalRequest();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ViewState["MainOrgId"] = 1;
            if (!IsPostBack)
            {
                //   FillClass();
                loadRegions();
                if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level
                {
                    btnSearch.Visible = true;
                    ddl_center.Visible = true;
                    ddl_region.Visible = true;
                    lblcenter.Visible = true;
                    lblregion.Visible = true;
                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO Level
                {
                    ddl_center.Visible = true;
                    lblcenter.Visible = true;
                    lblregion.Visible = false;
                    ddl_region.Visible = false;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    ddl_region_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 4)// Co level 
                {
                    ddl_center.Visible = false;
                    ddl_region.Visible = false;
                    lblcenter.Visible = false;
                    lblregion.Visible = false;
                    ddl_region.SelectedValue = Session["RegionID"].ToString();
                    loadCenter();
                    ddl_center.SelectedValue = Session["cId"].ToString();
                    ddl_center_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvStudentStatus_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudentStatus.Rows.Count > 0)
            {
                gvStudentStatus.UseAccessibleHeader = false;
                gvStudentStatus.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnRequest_Click(object sender, EventArgs e)
    {
        try
        {
            txtHRemarks.Text = "";
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int status = Convert.ToInt32(btn.CommandArgument);

            int level = Convert.ToInt32(Session["UserLevel_Id"].ToString());
            btnSaveReq.Visible = true;
            if (status == 0)//request not sent 
            {
                divDecision.Visible = false;
                divAction.Visible = false;
                txtHRemarks.Enabled = true;
                if (level == 2 || level == 3)
                {
                    txtHRemarks.Enabled = false;
                    btnSaveReq.Visible = false;
                }
            }
            if (status == 1) //request submitted but no action taken
            {
                txtHRemarks.Enabled = false;
                txtHRemarks.Text = gvr.Cells[12].Text;
                lblNHRemarks.Text = gvr.Cells[13].Text;
                lblNHDecision.Text = gvr.Cells[14].Text;
                divDecision.Visible = true;
                divAction.Visible = false;
                btnSaveReq.Visible = false;
            }
            if (status == 2 || status == 3)//request submitted and action taken
            {
                txtHRemarks.Enabled = false;
                txtHRemarks.Text = gvr.Cells[12].Text;
                lblNHRemarks.Text = gvr.Cells[13].Text;
                lblNHDecision.Text = gvr.Cells[14].Text;
                divAction.Visible = true;
                divDecision.Visible = true;
                btnSaveReq.Visible = false;

            }
            gvStudentStatus.SelectedIndex = gvr.RowIndex;
            lblReg.Text = gvr.Cells[1].Text;
            lblStdName.Text = gvr.Cells[1].Text + " - " + gvr.Cells[2].Text;
            lblResultDetail.Text = gvr.Cells[6].Text;
            if (gvr.Cells[15].Text == "1")
            {
                btnSaveReq.Text = "Save & Approve";
                ViewState["Mode"] = "Alone";
            }
            if (gvr.Cells[15].Text == "0")
            {
                btnSaveReq.Text = "Save";
                ViewState["Mode"] = "Network";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();

            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
            //BindGrid();
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

            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillClass();
            BindGrid();
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
            BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            int center = Convert.ToInt32(ddl_center.SelectedValue);
            dt = obj.Class_CenterFetch(center);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 20).CopyToDataTable();
            //dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") ==14).ToList().ForEach(row => row.Delete());
            //dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 15).ToList().ForEach(row => row.Delete());
            //dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 16).ToList().ForEach(row => row.Delete());
            //dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 17).ToList().ForEach(row => row.Delete());
            //dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 18).ToList().ForEach(row => row.Delete());

            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
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
            if (ddlClass.SelectedIndex > 0)
            {
                BindGrid();

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
            DataTable dt = new DataTable();
            BLLStudent_Registration_Result_ERP obj = new BLLStudent_Registration_Result_ERP();
            if (ddl_region.SelectedIndex > 0)
                obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            else
                obj.Region_Id = 0;

            if (ddl_center.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            else
                obj.Center_Id = 0;

            if (ddlClass.SelectedIndex > 0)
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            else
                obj.Class_Id = 0;


            dt = obj.Student_Registration_Result_ERPFetch(obj);
            if (dt.Rows.Count > 0)
                tdSearch.Visible = true;
            else
                tdSearch.Visible = false;

            gvStudentStatus.DataSource = dt;
            gvStudentStatus.DataBind();
            int level = Convert.ToInt32(Session["UserLevel_Id"].ToString());

            if (level == 2 || level == 3)
            {
                gvStudentStatus.Columns[11].Visible = true;
                gvStudentStatus.DataBind();
            }

            else if (ddlClass.SelectedValue == "13")
            {

                gvStudentStatus.Columns[5].Visible = true;
                gvStudentStatus.DataBind();
            }
            else
            {
                gvStudentStatus.Columns[5].Visible = false;
                gvStudentStatus.Columns[11].Visible = false;
                gvStudentStatus.Columns[9].Visible = true;
                gvStudentStatus.DataBind();
            }
            if (Session["UserType_Id"].ToString() == "3")
            {
                gvStudentStatus.Columns[10].Visible = false;
                gvStudentStatus.Columns[16].Visible = false;
            }
            if (Session["UserType_Id"].ToString() == "28")
            {
                gvStudentStatus.Columns[16].Visible = false;
            }
            gvStudentStatus.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Registration_Result_ERP obj = new BLLStudent_Registration_Result_ERP();
            LinkButton btndelete = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btndelete.NamingContainer;
            obj.Registration_Id = Convert.ToInt32(btndelete.CommandArgument);
            int k = obj.Student_Registration_Result_ERPDelete(obj);
            if (k == 0)
                ImpromptuHelper.ShowPrompt("Marks Unlocked");
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAddMarks_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Registration_Result_ERP obj = new BLLStudent_Registration_Result_ERP();
            LinkButton btndelete = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btndelete.NamingContainer;
            obj.Registration_Id = Convert.ToInt32(btndelete.CommandArgument);
            Session["Regisration_Id"] = obj.Registration_Id;
            if(ddl_center.SelectedIndex>0)
                Session["Center_Id"] = ddl_center.SelectedValue;
            if(ddl_region.SelectedIndex>0)
                Session["Region_Id"] = ddl_region.SelectedValue;
            string url = "Admission_Registeration_Evaluation_Criteria.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
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
            objReq.Regisration_Id = Convert.ToInt32(lblReg.Text);
            objReq.Heads_Remarks = txtHRemarks.Text;
            objReq.Submited_By = Convert.ToInt32(Session["ContactID"].ToString());
            int k = objReq.AdmStudentDiscretionalRequestAdd(objReq, ViewState["Mode"].ToString());
            if (k == 1)
            {
                //ImpromptuHelper.ShowPrompt("Request Submitted");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
                BindGrid();
            }

            if (ViewState["Mode"].ToString() == "Network")
            {
                //send email to network heads
                EmailAdmissionSummary(lblStdName.Text, lblResultDetail.Text);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void EmailAdmissionSummary(string student, string result)
    {
        try
        {
            int region;
            int center;

            if (!String.IsNullOrEmpty(Session["RegionID"].ToString()) && Session["RegionID"]!=null)
                region = Convert.ToInt32(Session["RegionID"].ToString());
            else
                region = 0;
            if (!String.IsNullOrEmpty(Session["cId"].ToString()) && Session["RegionID"] != null)
                center = Convert.ToInt32(Session["cId"].ToString());
            else
                center = 0;

            bool flag = false;
            BLLAdmStudentDiscretionalRequest objClsSec = new BLLAdmStudentDiscretionalRequest();
            BLLSendEmail objEmail = new BLLSendEmail();

            string strEmailMsg = "<br> Dear Sir, <br> ";
            strEmailMsg += " Following discretionary admission request has been raised by " + ddl_center.SelectedItem.Text + " for your approval. Please attend to this as a matter of priority.";
            strEmailMsg += " Login to approve: http://www.tcsaims.com/ .";
            strEmailMsg += "<br/><br/><b>Student Details are as follows:  </b><br><b>Student: </b> " + student + "<br>";
            strEmailMsg += "<b>Date: </b>" + String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now) + "<br/>";
            strEmailMsg += "<b>Campus : </b>" + ddl_center.SelectedItem.Text + "<br/>";

            result = result.Replace("&amp;#8195;", "&#8195;");
            result = result.Replace("&amp;#8201;", "&#8201;");
            result = result.Replace("&amp;#8194;", "&#8194;");
            result = result.Replace("&lt;br /&gt;", "<br/>");
            result = result.Replace("&amp;#10006;", "&#10006;");
            result = result.Replace("&amp;#10004;", "&#10004;");
            strEmailMsg += "<b>Admission Test Result: </b>" + result;

            flag = true;

            if (flag == true)
            {
                strEmailMsg += "<br><br><b>Note: </b><i>This is a system generated message. Please do not reply to this message.</i><br/><br/>";
                objEmail.SendEmailDiscretionaryAdmission(4, "Discretionary Admission Alert", strEmailMsg, "Discretionary  Admission",center,region);

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}