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

public partial class PresentationLayer_TCS_TCSGResourceDCTCatag : System.Web.UI.Page
{
    //int worksiteID = 0;
    int regID = 0;
    int regPreEduID = 0;
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        ////////////}
        ////////////catch (Exception ex)
        ////////////{
        ////////////    Session["error"] = ex.Message;
        ////////////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        ////////////}

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
            txtName.Focus();
            #region 'Roles&Priviliges'

            //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //string sRet = oInfo.Name;
            DALBase objbase = new DALBase();
            string _tempCntct = Session["ContactID"].ToString();
            HtmlForm frm = new HtmlForm();
            frm = Form;
           // objbase.ApplicationSettings(sRet, "ContentPlaceHolder1", _tempCntct, frm);

            //objbase.ApplicationSettings(sRet, "ContentPlaceHolder1", _tempCntct, frm, gvRegStudents, "gvRegStudents");

            #endregion

            if (Session["WrkSiteName"] != null)
            {
                ////////wrkTitle.InnerText = "News [ " + Session["WrkSiteName"].ToString() + " ]";
            }

            //worksiteID = Convert.ToInt32(Session["wrkSiteID"]);
            BindGrid();
            ViewState["mode"] = "add";
            int regID = 0;
            if (Session["EditregID"] != null)
            {
                regID = Convert.ToInt32(Session["EditregID"]);
                LoadDataByID(regID);
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
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

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        ViewState["mode"] = "edit";
        detail1.Visible = true;
        detail2.Visible = true;
        ImageButton btnEdit = (ImageButton)sender;
        regID = Convert.ToInt32(btnEdit.CommandArgument);

        ViewState["EditID"] = regID;

        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        gvDCT.SelectedIndex = gvr.RowIndex;
        LoadDataByID(regID);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {
       try
       {
        ImageButton imgBtnDelete = (ImageButton)sender;
        regID = Convert.ToInt32(imgBtnDelete.CommandArgument);
        BLLTssGResourceDCTCatag objBll = new BLLTssGResourceDCTCatag();
        objBll.GResourceCat_ID = regID;
        objBll.ModifiedOn = DateTime.Now;
        objBll.ModifiedBy = Convert.ToInt32(Session["ContactID"]);
        objBll.TssGResourceDCTCatagDelete(objBll);
        ViewState["Grid"] = null;
        BindGrid();

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
        if (Session["EditregID"] != null)
        {
            Response.Redirect("~/PresentationLayer/TSS/TssFirstRegApproval.aspx");
        }
        else
        {
            ResetControls();
            detail1.Visible = false;
            detail2.Visible = false;
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        try
        {
        Response.Redirect("~/PresentationLayer/LMS/LmsWrkSite.aspx");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
        Response.Redirect("~/PresentationLayer/LMS/LmsWrkSpace.aspx");
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
        detail1.Visible = false;
        detail2.Visible = false;
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
        BLLTssGResourceDCTCatag objBll = new BLLTssGResourceDCTCatag();
        objBll.GResourceCatDesc = txtName.Text;

        string strMode = "";
        int lastInsertID = 0;
        if (ViewState["mode"] != null)
        {
            strMode = ViewState["mode"].ToString();
            if (strMode == "add")
            {
                //objBll.Region_Id = 0;
                //objBll.Center_Id = Convert.ToInt32(Session["cId"]);
                objBll.Main_Organisation_ID = Convert.ToInt32(Session["MoId"]);
                objBll.CreatedOn = DateTime.Now;
                objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);

                lastInsertID = objBll.TssGResourceDCTCatagInsert(objBll);
                if (lastInsertID == 0)
                {
                    //lblMsg.Text = "";
                    ImpromptuHelper.ShowPrompt("Catagory Created successfully.");
                }
                else
                {
                    //lblMsg.Text = "A Catagory with this name already exists!";
                    ImpromptuHelper.ShowPrompt("A Catagory with this name already exists!");
                }
            }
            //Update mode
            else
            {
                if (ViewState["EditID"] != null)
                {
                    regID = Convert.ToInt32(ViewState["EditID"]);
                    objBll.GResourceCat_ID = regID;
                    objBll.ModifiedOn = DateTime.Now;
                    objBll.ModifiedBy = Convert.ToInt32(Session["ContactID"]);

                    objBll.TssGResourceDCTCatagUpdate(objBll);
                    ImpromptuHelper.ShowPrompt("Catagory updated successfully.");
                }
            }
        }

        //ViewState["mode"] = "none";        
        ViewState["mode"] = "add";
        ViewState["Grid"] = null;
        BindGrid();
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
        BLLTssGResourceDCTCatag objBll = new BLLTssGResourceDCTCatag();
        //if (Session["cId"] != null)
        //{
        //    //objBll.Center_Id = Convert.ToInt32(Session["cId"]);    
        //}

        if (ViewState["Grid"] != null)
        {
            dt = (DataTable)ViewState["Grid"];
        }
        else
        {
            dt = objBll.TssGResourceDCTCatagSelectAll();
        }

        gvDCT.DataSource = dt;
        gvDCT.DataBind();

        ViewState["Grid"] = dt;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LoadDataByID(int selectID)
    {
        try
        {

        BLLTssGResourceDCTCatag objBll = new BLLTssGResourceDCTCatag();
        objBll.GResourceCat_ID = selectID;


        DataTable dt = new DataTable();
        dt = objBll.TssGResourceDCTCatagSelectById(objBll);
        DataRow dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            txtName.Text = dr["GResourceCatDesc"].ToString();

        }

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
        txtName.Text = "";
        txtName.Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnTitle_Click(object sender, EventArgs e)
    {
        try
        {
        ViewState["mode"] = "edit";
        //        ContentDetailSection.Style.Add("display", "block");
        LinkButton btnTitle = (LinkButton)sender;
        regID = Convert.ToInt32(btnTitle.CommandArgument);
        ViewState["EditID"] = regID;

        GridViewRow gvr = (GridViewRow)btnTitle.NamingContainer;
        gvDCT.SelectedIndex = gvr.DataItemIndex;
        LoadDataByID(regID);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }




    protected void gvDCT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvDCT.PageIndex = e.NewPageIndex;
        BindGrid();
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
        ResetControls();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
}
