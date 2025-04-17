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

public partial class PresentationLayer_TCS_TCSGResources : System.Web.UI.Page
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
                Response.Redirect("~/login.aspx",false);
            }
        //////////}
        //////////catch (Exception ex)
        //////////{
        //////////    Session["error"] = ex.Message;
        //////////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //////////}

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

            if (row["User_Type"].ToString() != "SAdmin")
            {
                //   ddl_MOrg.SelectedValue = row.Main_Organisation_Id.ToString();
                //  ddl_MOrg_SelectedIndexChanged(sender, e);
            }
            FillDropDowns();
             ResetControls();
           ////////////ddlSession.SelectedValue = "1";
             ddlSession.Visible = false;



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
            ReloadSelectionCriteria();


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
        FillSession();
        FillClass();
        FillProgram();
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
        BLLTssGResourcesDetail objBll = new BLLTssGResourcesDetail();


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
                objBll.GResDetail_ID = resDetailID;
                objBll.TssGResourcesDetailUpdateAccess(objBll);


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




    protected void FillSession()
    {
        try
        {
        

        BLLSession objBll = new BLLSession();
        DataTable dt = new DataTable();
        dt = objBll.SessionSelectAllActive();
        objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
        ddlSession.SelectedIndex  = 1;

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
        BLLClass_Subject obj = new BLLClass_Subject();

        int moID = Int32.Parse(Session["moID"].ToString());
        obj.Main_Organisation_Id = moID;


        DataTable dt = (DataTable)obj.Class_SelectByOrgId(obj);

        objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");




        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ResetControls()
    {
        try
        {
        

        ddlProgram.SelectedValue = "0";
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


    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        FillClass();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindAssignedSubjects(int classID)
    {
        try
        {
        BLLClass_Subject objBllcs = new BLLClass_Subject();
        DataTable dtCs = new DataTable();
        objBllcs.Class_ID = classID;


        int moID = Int32.Parse(Session["moID"].ToString());
        objBllcs.Main_Organisation_Id = moID;
        ////////objBllcs.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

        DataTable dt = (DataTable)objBllcs.Class_SubjectSelectAllByClassId(objBllcs);

        objBase.FillDropDown(dt, ddlSubject, "subject_id", "Subject_Name");



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
            int id = Convert.ToInt32(ddlClass.SelectedValue);
            BindAssignedSubjects(id);


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
        try
        {
        campusSection.Visible = false;
        string resCatagory = "";

        ImageButton imgbtn = (ImageButton)sender;

        GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;
        LinkButton btn = (LinkButton)gvr.FindControl("btnResCat");

        TextBox _txt = (TextBox)gvr.FindControl("txtResTitle");
        resCatagory = btn.Text;

        string strFolderPath = "D:\\TCS\\" + Session["moID"].ToString() + "\\" + ddlSession.SelectedItem.Text + "\\" + ddlClass.SelectedItem.Text + "\\" + ddlSubject.SelectedItem.Text + "\\" + resCatagory;
       


        
        BLLTssGResources objBll = new BLLTssGResources();

        objBll.GResourceCat_ID = Convert.ToInt32(btn.CommandArgument);
        objBll.ResourceTitle = _txt.Text;
        objBll.Main_Organisation_ID = Convert.ToInt32(Session["moID"].ToString());
        objBll.Session_ID = Convert.ToInt32(ddlSession.SelectedValue);
        objBll.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);
        objBll.Subject_ID = Convert.ToInt32(ddlSubject.SelectedValue);
        objBll.FolderPath = strFolderPath;
        objBll.CreatedOn = DateTime.Now;
        objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);
        objBll.ModifiedOn = DateTime.Now;
        objBll.ModifiedBy = Convert.ToInt32(Session["ContactID"]);
        int k = objBll.TssGResourcesInsert(objBll);
        if (k > 0)
        {

            BindGridResourceDetail();
            FillResourceCatagories();
            ImpromptuHelper.ShowPrompt("Resource Created Successfully.");

        }
        /*else
        {
            ImpromptuHelper.ShowPrompt("Resource already exists!");
        }*/
        //================ Physical Folders ================================
        if (!Directory.Exists(strFolderPath))
        {
            Directory.CreateDirectory(strFolderPath);
        }

        //=================================================================

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
        if (ViewState["GResourceID"] != null)
        {
            DataTable dt = new DataTable();
            BLLTssGResourcesDetail objBll = new BLLTssGResourcesDetail();
            //if (ddlClass.SelectedIndex > 0)
            if (ddlProgram.SelectedIndex > 0)
            {
                resID = Convert.ToInt32(ViewState["GResourceID"]);
                objBll.Program_ID = Convert.ToInt32(ddlProgram.SelectedValue);
                //objBll.Program_ID = 1;
                objBll.GResource_ID = resID;
                dt = objBll.TssGResourcesDetailSelectByGResourceIdCampusType(objBll);

                gvResDetail.DataSource = dt;
                gvResDetail.DataBind();
                ViewState["ResDeatilGrid"] = dt;

            }
            else
            {
                gvResDetail.DataSource = null;
                gvResDetail.DataBind();
                ViewState["ResDeatilGrid"] = dt;
            }
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
        BLLTssGResourceDCTCatag objBll = new BLLTssGResourceDCTCatag();
        DataTable dt = new DataTable();
        //dt = objBll.TssGResourceDCTCatagSelectAll();
      

        objBllRes.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);
        objBllRes.Session_ID = Convert.ToInt32(ddlSession.SelectedValue);
        objBllRes.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);
        objBllRes.Subject_ID = Convert.ToInt32(ddlSubject.SelectedValue);

        dt = objBllRes.TssGResourceDCTCatagSelectByParam(objBllRes);

        gvResCat.DataSource = dt;
        gvResCat.DataBind();
        campusSection.Visible = false;
        GenerateResourceTitle();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void GenerateResourceTitle()
    {
        try
        {

        foreach (GridViewRow row in gvResCat.Rows)
        {
            string strTitle = "";
            LinkButton btn = (LinkButton)row.FindControl("btnResCat");
            if (ddlSession.SelectedValue != "0")
                //strTitle += ddlSession.SelectedItem.Text + "-";
                if (ddlClass.SelectedValue != "0")
                    strTitle += ddlClass.SelectedItem.Text + "-";
            if (ddlSubject.SelectedValue != "0")
                strTitle += ddlSubject.SelectedItem.Text + "-";

            strTitle += btn.Text;

            TextBox _txt = (TextBox)row.FindControl("txtResTitle");


            _txt.Text = strTitle;



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

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (ddlSubject.SelectedIndex > 0)
        {
            FillResourceCatagories();
            gvResCat.Visible = true;
        }
        else
        {
            gvResCat.DataSource = null;
            gvResCat.DataBind();
        }
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
    }


    protected void FillProgram()
    {
        try
        {


        BLLRegion oDALRegion = new BLLRegion();
        DataTable dt = new DataTable();

        oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(Session["moID"].ToString());
        dt = oDALRegion.RegionFetch(oDALRegion);

        objBase.FillDropDown(dt, ddlProgram, "Region_Id", "Region_Name");
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
        string strFolderPath = gvr.Cells[5].Text;

        /*//====================== Root Folder Creation ==============================
        //BLLTssGResources objBll = new BLLTssGResources();
        FileVistaControl.Visible = true;
        FileVistaRootFolder rootFolder = new FileVistaRootFolder("The Smart School", strFolderPath);

        rootFolder.Permissions = FileVistaPermissions.Full;

        rootFolder.Quota = "20MB";
        FileVistaControl.RootFolders.Add(rootFolder);*/

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.CommandName;
        Session["SessionID"] = ddlSession.SelectedValue;
        Session["ClassID"] = ddlClass.SelectedValue;
        Session["SubjectID"] = ddlSubject.SelectedValue;
        Session["View"] = "ho";
        Session["Module"] = "GNR";
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
            ViewState["GResourceID"] = resourceID;
            BindGridResourceDetail();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ReloadSelectionCriteria()
    {
        try
        {
        if (Session["SessionID"] != null)
            ddlSession.SelectedValue = Session["SessionID"].ToString();
        if (Session["ClassID"] != null)
        {
            ddlClass.SelectedValue = Session["ClassID"].ToString();
            ddlClass_SelectedIndexChanged(null, null);
        }
        if (Session["SubjectID"] != null)
        {
            ddlSubject.SelectedValue = Session["SubjectID"].ToString();
            ddlSubject_SelectedIndexChanged(null, null);
        }

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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


}
