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
//using GleamTech.Web.Controls;
public partial class PresentationLayer_TCS_TCSCommonResources : System.Web.UI.Page
{
    //int worksiteID = 0;
    //int regID = 0;
    //int regPreEduID = 0;
    DALBase objBase = new DALBase();
    BLLTssCMNResources objBllRes = new BLLTssCMNResources();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        //////}
        //////catch (Exception ex)
        //////{
        //////    Session["error"] = ex.Message;
        //////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //////}

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
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================

            ViewState["mode"] = "add";
            ViewState["tMood"] = "check";


            #region 'Roles&Priviliges'

            ////string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            ////System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            ////string sRet = oInfo.Name;
            //DALBase objbase = new DALBase();
            //string _tempCntct = Session["ContactID"].ToString();
            //HtmlForm frm = new HtmlForm();
            //frm = Form;
            //objbase.ApplicationSettings(sRet, "ContentPlaceHolder1", _tempCntct, frm);

            #endregion


            //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];

            if (row["User_Type"].ToString() != "SAdmin")
            {
                //   ddl_MOrg.SelectedValue = row.Main_Organisation_Id.ToString();
                //  ddl_MOrg_SelectedIndexChanged(sender, e);
            }

            FillRegion();
            ResetControls();



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

            //btnTitle_Click(sender,e);

            FillResourceCatagories();
        }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



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
        detail1.Visible = false;
        detail2.Visible = false;
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
        ResetControls();
        campusSection.Visible = false;

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

        BLLTssCMNResourcesDetail objBll = new BLLTssCMNResourcesDetail();


        string strMode = "";
        if (ViewState["mode"] != null)
        {
            strMode = ViewState["mode"].ToString();

            LinkButton btnCenter;
            CheckBox chkAllowAccess;
            int resDetailID = 0;
            foreach (GridViewRow gvr in gvResDetail.Rows)
            {
                btnCenter = (LinkButton)gvr.FindControl("btnCenter");
                resDetailID = Convert.ToInt32(btnCenter.CommandArgument);
                chkAllowAccess = (CheckBox)gvr.FindControl("chkAllowAccess");
                objBll.IsAllow = chkAllowAccess.Checked;
                objBll.CMNResDetail_ID = resDetailID;
                objBll.TssCMNResourcesDetailUpdateAccess(objBll);


            }

        }
        ImpromptuHelper.ShowPrompt("Access updated successfully.");
        

        ViewState["mode"] = "none";
        ViewState["Grid"] = null;


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {


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
        if (ViewState["CMNResourceID"] != null)
        {
            DataTable dt = new DataTable();
            BLLTssCMNResourcesDetail objBll = new BLLTssCMNResourcesDetail();
            resID = Convert.ToInt32(ViewState["CMNResourceID"]);
            objBll.CMNResource_ID = resID;
            objBll.Region_ID = Convert.ToInt32(ddlRegion.SelectedValue);
            dt = objBll.TssCMNResourcesDetailSelectByGResourceId(objBll);
            gvResDetail.DataSource = dt;
            gvResDetail.DataBind();
            ViewState["ResDeatilGrid"] = dt;
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void FillResourceCatagories()
    {
        try
        {
        gvResCat.DataSource = null;
        gvResCat.DataBind();

        BLLTssCMNResourceDCTCatag objBll = new BLLTssCMNResourceDCTCatag();
        DataTable _dt = new DataTable();

        objBllRes.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);

        _dt = objBllRes.TssCMNResourcesSelectByMoId(objBllRes);
        if (_dt.Rows.Count > 0)
        {
            gvResCat.DataSource = _dt;
            gvResCat.DataBind();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnResCat_Click(object sender, EventArgs e)
    {
        try
        {
//        FileVistaControl.Visible = true;
        LinkButton btn = (LinkButton)sender;

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvResCat.SelectedIndex = gvr.DataItemIndex;
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
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {

            if (ViewState["ResDeatilGrid"] != null)
            {
                DataTable dt = (DataTable)ViewState["ResDeatilGrid"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (ddlFilter.SelectedValue)
                {
                    case "1":
                        {
                            strFilter = "Center_Name like '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case "2":
                        {
                            strFilter = "Convert([Center_ID], 'System.String') LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }



                }
                dv.RowFilter = strFilter;
                gvResDetail.DataSource = dv;
                ViewState["ResDeatilGrid"] = dv.ToTable();
                gvResDetail.DataBind();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
        txtFilter.Text = "";
        ddlFilter.SelectedIndex = 0;

        ResetFilter();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
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

    private void ResetFilter()
    {
        try
        {
        ViewState["ResDeatilGrid"] = null;
        BindGridResourceDetail();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void txtFilter_TextChanged(object sender, EventArgs e)
    {

        try
        {
        ResetFilter();
        btnFilter_Click(null, null);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    //=======================================================================================================

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btn = (ImageButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        string strFolderPath = gvr.Cells[3].Text;

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.CommandName;
        Session["View"] = "ho";
        Session["Module"] = "CMN";
        Session["FolderPath"] = strFolderPath;

        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnMngAccess_Click(object sender, EventArgs e)
    {

        try
        {
        campusSection.Visible = true;
        ImageButton btn = (ImageButton)sender;

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        //gvResources.SelectedIndex = gvr.DataItemIndex;
        gvResCat.SelectedIndex = gvr.RowIndex;
        int resourceID = 0;
        if (btn.CommandArgument != null)
        {
            resourceID = Convert.ToInt32(btn.CommandArgument);
            ViewState["CMNResourceID"] = resourceID;
            //////////BindGridResourceDetail();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    //==================================== merge =========================================


    protected void btnTitle_Click(object sender, EventArgs e)
    {
        try
        {
        FillResourceCatagories();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LinkButton1_Click2(object sender, EventArgs e)
    {
        try
        {
        ViewState["EditID"] = null;
        ViewState["mode"] = "add";
        detail1.Visible = true;
        detail2.Visible = true;
        //       ResetControls();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void SaveCMNResources()
    {
        try
        {

        campusSection.Visible = false;
        string resCatagory = "";


        resCatagory = txtResName.Text;
        string strFolderPath = "D:\\TCS\\CMNRESOURCES\\" + Session["moID"].ToString() + "\\" + resCatagory;

        objBllRes.ResourceTitle = txtResName.Text;
        objBllRes.Main_Organisation_ID = Convert.ToInt32(Session["MoId"]); ;
        objBllRes.FolderPath = strFolderPath;
        objBllRes.CreatedBy = Convert.ToInt32(Session["ContactID"]);
        objBllRes.CreatedOn = DateTime.Now;

        int counter = objBllRes.TssCMNResourcesInsert(objBllRes);
        if (counter > 0)
        {
            //================ Physical Folders ================================
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }
            //BindGridResourceDetail();
            FillResourceCatagories();
            ImpromptuHelper.ShowPrompt("Resource Created Successfully.");
            //==============================================================
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void btnAddRes_Click(object sender, EventArgs e)
    {
        try
        {
        SaveCMNResources();
        detail1.Visible = false;
        detail2.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
      BindGridResourceDetail();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void FillRegion()
    {

        try
        {
        //DALBase objBase = new DALBase();
        //BLLTssDCTProgram objBll = new BLLTssDCTProgram();
        //DataTable dt = new DataTable();
        //dt = objBll.TssDCTProgramSelectAll();
        //objBase.FillDropDown(dt, ddlProgram, "Program_ID", "Program");


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


}
