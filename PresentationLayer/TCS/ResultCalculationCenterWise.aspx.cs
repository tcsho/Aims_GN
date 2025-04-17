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

public partial class PresentationLayer_TCS_ResultCalculationCenterWise : System.Web.UI.Page
{
    //int worksiteID = 0;
    
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


             FillDropDowns();
             ResetControls();

             mainlable.Visible = false;
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
             

             campusSection.Visible = true;
        }


    }

    private void FillDropDowns()
    {
        try
        {
        FillRegion();
        FillActiveSessions();
        bindTermGroupList();

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
         mainlable.Visible = false;
        campusSection.Visible = false;
        ddlRegion.SelectedIndex = 0;
        ddlSession.SelectedIndex = 0;
        ddlTermGroup.SelectedIndex = 0;
        
        gvResDetail.DataSource = null;
        gvResDetail.DataBind();
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
            if (ddlRegion.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && ddlTermGroup.SelectedIndex > 0)
            {
                Save();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select Region, Session and Term!");
            }
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
        

        int AlreadyIn = 0;
        BLLResult_Grade objClsSec = new BLLResult_Grade();

        string strMode = "";
        if (ViewState["mode"] != null)
        {
            strMode = ViewState["mode"].ToString();

           
            CheckBox chkAllowAccess;
            
            foreach (GridViewRow gvr in gvResDetail.Rows)
            {
                chkAllowAccess = (CheckBox)gvr.FindControl("chkAllowAccess");

                 if (chkAllowAccess.Checked)
                 {

                     
                     objClsSec.Center_Id = Convert.ToInt32(gvr.Cells[2].Text.ToString());
                     objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                     objClsSec.TermGroup_Id = Convert.ToInt32(ddlTermGroup.SelectedValue.ToString());

                     AlreadyIn = objClsSec.TCS_Result_GenerateResultAllByCenter_Id(objClsSec);

                 }

            }

        }
        ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");   
        BindGridResourceDetail();
       

         }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }

    }

       

    protected void ResetControls()
    {
        try
        {

        
        mainlable.Visible = false;
        ddlRegion.SelectedIndex = 0;
        ddlSession.SelectedIndex = 0;
        ddlTermGroup.SelectedIndex = 0;

        gvResDetail.DataSource = null;
        gvResDetail.DataBind();


        ViewState["mode"] = "add";
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

                dt = objBll.Diag_ProgManageCenterWiseAccess(objBll);

                gvResDetail.DataSource = dt;
                gvResDetail.DataBind();
                ViewState["ResDeatilGrid"] = dt;
                mainlable.Visible = true;

            }
            else
            {
                gvResDetail.DataSource = null;
                gvResDetail.DataBind();
                ViewState["ResDeatilGrid"] = dt;
                mainlable.Visible = false;
            }

            
        //////////}
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


    protected void bindTermGroupList()
    {
        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTermGroup, "TermGroup_Id", "Type");
           

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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


    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegion.SelectedIndex ==0)
        {
            ResetControls();
        }
    }
    protected void ddlTermGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            mainlable.Visible = false;
            BindGridResourceDetail();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSession.SelectedIndex == 0)
        {
            mainlable.Visible = false;
            //////////////campusSection.Visible = false;
            ddlSession.SelectedIndex = 0;
            ddlTermGroup.SelectedIndex = 0;

            gvResDetail.DataSource = null;
            gvResDetail.DataBind();
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
}
