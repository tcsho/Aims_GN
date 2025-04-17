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
//using GleamTech.Web.Controls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_ProgressCheckerMangeCenterAccess : System.Web.UI.Page
{
    //int worksiteID = 0;
    int regID = 0;
    int regPreEduID = 0;
    DALBase objBase = new DALBase();
    BLLTssGResources objBllRes = new BLLTssGResources();
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
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

        if (!IsPostBack)
        {
            //======== Page Access Settings ========================
            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;


            DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            //            tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx", false);
            }

            //====== End Page Access settings ======================

            ViewState["mode"] = "add";
            ViewState["tMood"] = "check";

            #region 'Roles&Priviliges'

            //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //string sRet = oInfo.Name;
            DALBase objbase = new DALBase();
            string _tempCntct = Session["ContactID"].ToString();
            HtmlForm frm = new HtmlForm();
            frm = Form;
            //objbase.ApplicationSettings(sRet, "ContentPlaceHolder1", _tempCntct, frm);

            #endregion


            //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];

            //if (row["User_Type"].ToString() != "SAdmin")
            //{
            //    //   ddl_MOrg.SelectedValue = row.Main_Organisation_Id.ToString();
            //    //  ddl_MOrg_SelectedIndexChanged(sender, e);
            //}
            FillDropDowns();
            FillClassSection();
            ResetControls();
            ////////////ddlSession.SelectedValue = "1";
            ////////////ddlSession.Visible = false;



            int regID = 0;
            if (Session["EditregID"] != null)
            {

                regID = Convert.ToInt32(Session["EditregID"]);
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
            ////////////ReloadSelectionCriteria();

             campusSection.Visible = true;
        }


    }
    protected void gvResDetail_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvResDetail.Rows.Count > 0)
            {
                gvResDetail.UseAccessibleHeader = false;
                gvResDetail.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void FillDropDowns()
    {
        try
        {
            ////////////FillSession();
            ////////////FillClass();
            FillRegion();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void FillClassSection()
    {
        FillSubject();
        //try
        //{
        //    BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
        //    objDPUnit.Subject_Id = Convert.ToInt16(ViewState["SubjectInfo"]);
        //    DataTable dtClass = objDPUnit.Diag_Prog_UnitSelectClassBySubject_Id(objDPUnit);
        //    objBase.FillDropDown(dtClass, ddlClass, "Class_Id", "Class_Name");
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }
    protected void lnkBtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["mode"] = "add";
            Session["EditregID"] = null;
            btnSave.Visible = true;
            ResetControls();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            campusSection.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void Save()
    {
        try
        {
            
            BLLDiag_Prog dp = new BLLDiag_Prog();
            //dp.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            dp.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"]);
            int k= dp.Diag_Prog_DetailUpdateLockMarks(dp);
            if (k == 0)
            {
                ImpromptuHelper.ShowPrompt("Your TOS is locked now");
            }
            else
            {
                ImpromptuHelper.ShowPrompt("You do not have a TOS for the specified subject");
            }
            
            int AlreadyIn = 0;
            int AlreadyInAccess = 0;
            BLLSection_Subject_Diag_Prog objClsSec = new BLLSection_Subject_Diag_Prog();

            string strMode = "";
            if (ViewState["mode"] != null)
            {
                strMode = ViewState["mode"].ToString();

                LinkButton btnCenter;
                CheckBox chkAllowAccess;
                int resDetailID = 0;
                foreach (GridViewRow gvr in gvResDetail.Rows)
                {
                    chkAllowAccess = (CheckBox)gvr.FindControl("chkAllowAccess");

                    if (chkAllowAccess.Checked)
                    {

                        objClsSec.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());
                        objClsSec.Region_Name = gvr.Cells[1].Text.ToString();
                        objClsSec.Center_Id = Convert.ToInt32(gvr.Cells[2].Text.ToString());
                        objClsSec.Center_Name = gvr.Cells[3].Text.ToString();
                        objClsSec.isAllow = true;
                        objClsSec.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"]); 
                        AlreadyIn = objClsSec.Diag_Prog_Manage_Center_AccessAdd(objClsSec);

                        ///////// Comment for testing 4 Jan 2016 
                        AlreadyInAccess = objClsSec.Section_Subject_Diag_Prog_GenerateMasterDetailValues(objClsSec);




                    }

                }

            }
            ImpromptuHelper.ShowPrompt("Record was successfully added.");


            BindGridResourceDetail();


        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }

    }

    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/PresentationLayer/LMS/LmsNewsSummaryView.aspx");
    }






    protected void ResetControls()
    {
        try
        {

            ddlRegion.SelectedValue = "0";
            gvResDetail.DataSource = null;


            ViewState["mode"] = "add";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }





    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
        try
        {
            TreeView tempView = (TreeView)Master.FindControl("MenuLeft");

            TreeNode tn = tempView.FindNode("Resources");
            if (tn != null)
            {
                tn.Expand();
                //tn.ChildNodes[0].Select();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }




    protected void gvResources_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvResDetail.PageIndex = e.NewPageIndex;
            BindGridResourceDetail();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BindGridResourceDetail()
    {
        try
        {
            int resID = 0;
            ////////if (ViewState["GResourceID"] != null)
            ////////{
            DataTable dt = new DataTable();
            BLLDiag_Prog objBll = new BLLDiag_Prog();
            //if (ddlClass.SelectedIndex > 0)
            if (ddlRegion.SelectedIndex > 0)
            {
                objBll.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
                objBll.Subject_Id = Convert.ToInt32(ViewState["SubjectInfo"]);
                dt = objBll.Diag_ProgManageCenterWiseAccess(objBll);

                if (dt.Rows.Count > 0)
                {
                    campusSectionTitle.Visible = true;
                    gvResDetail.DataSource = dt;
                    gvResDetail.DataBind();
                    ViewState["ResDeatilGrid"] = dt;
                }
                else
                {
                    campusSectionTitle.Visible = false;
                    gvResDetail.DataSource = null;
                    gvResDetail.DataBind();
                    ViewState["ResDeatilGrid"] = null;
                }
            }
            else
            {
                gvResDetail.DataSource = null;
                gvResDetail.DataBind();
                ViewState["ResDeatilGrid"] = dt;
            }
            //////////}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void gvResDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvResDetail.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("chkAllowAccess");

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
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void gvResDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvResDetail.PageIndex = e.NewPageIndex;
            BindGridResourceDetail();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    // =================================== Filter Section ===================================================

    protected void btnReset_Click(object sender, EventArgs e)
    {
    }


    protected void FillRegion()
    {
        try
        {


            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(Session["moID"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindGridResourceDetail();
            campusSection.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void FillSubject()
    {
        BLLDiag_Prog_Unit objDPUnit = new BLLDiag_Prog_Unit();
        try
        {
            int user_id = Convert.ToInt32(Session["ContactID"]);
            DataTable dt = objDPUnit.Diag_Prog_UnitSelectSubjectByUser_Id(user_id);
            if (dt.Rows.Count > 0)
            {

                lblSubject.Text = dt.Rows[0]["Subject_Name"].ToString();
                ViewState["SubjectInfo"] = dt.Rows[0]["Subject_Id"].ToString();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
