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
public partial class PresentationLayer_TCS_TCSHOCenterResources : System.Web.UI.Page
{
    
    DALBase objBase = new DALBase();
    BLLTssCMNResources objBllRes = new BLLTssCMNResources();
    protected void Page_Load(object sender, EventArgs e)
    {  
        // New Form


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

            ////string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            ////System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            ////string sRet = oInfo.Name;
            //DALBase objbase = new DALBase();
            //string _tempCntct = Session["ContactID"].ToString();
            //HtmlForm frm = new HtmlForm();
            //frm = Form;
            //objbase.ApplicationSettings(sRet, "ContentPlaceHolder1", _tempCntct, frm);

            #endregion


          
            if (row["User_Type"].ToString() != "SAdmin")
            {
                //   ddl_MOrg.SelectedValue = row.Main_Organisation_Id.ToString();
                //  ddl_MOrg_SelectedIndexChanged(sender, e);
            }

            loadOrg(sender, e);

            //////////FillRegion();

            ResetControls();
            campusSection.Visible = true;

            if (row["User_Type"].ToString() != "SAdmin")
            {
                ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                ddl_MOrg_SelectedIndexChanged(sender, e);
            }



            int regID = 0;
            if (Session["EditregID"] != null)
            {

                regID = Convert.ToInt32(Session["EditregID"]);
                btnSave.Visible = false;
            }
            else
            {
                //btnSave.Visible = true;
            }

            //btnTitle_Click(sender,e);

            //////////////FillResourceCatagories();
        }


    }


    ////////protected void lnkBtnAdd_Click(object sender, EventArgs e)
    ////////{
    ////////    ViewState["mode"] = "add";
    ////////    Session["EditregID"] = null;
    ////////    btnSave.Visible = true;
    ////////    ResetControls();


    ////////}


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        campusSection.Visible = false;
        //detail1.Visible = false;
        //detail2.Visible = false;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        ResetControls();
        loadCountries();
        FillRegion();

        gvResDetail.DataSource = null;
        gvResDetail.DataBind();
        campusSection.Visible = true;

        //

        //


    }

    protected void Save()
    {

        BLLTCS_DropBox objBll = new BLLTCS_DropBox();

        string RegionName;
        string strMode = "";
        if (ViewState["mode"] != null)
        {
            strMode = ViewState["mode"].ToString();

            
            foreach (GridViewRow gvr in gvResDetail.Rows)
            {
                
                if (Convert.ToInt32(ddlRegion.SelectedValue) == 2000000)
                {
                    RegionName = "SR";
                }
                else if (Convert.ToInt32(ddlRegion.SelectedValue) == 3000000)
                {
                    RegionName = "NR";
                }
                else 
                {
                    RegionName = "CR";
                }


                string CenterFullName = gvr.Cells[3].Text;
                string strFolderPath = "D:\\TCS\\DropBox\\" + RegionName + "\\" + CenterFullName; 

                objBll.Main_Organisation_ID = Convert.ToInt32(Session["MoId"]); ;
                objBll.Region_ID = Convert.ToInt32(ddlRegion.SelectedValue);
                objBll.Center_ID = Convert.ToInt32(gvr.Cells[2].Text);
                objBll.DropBoxResourcePath = strFolderPath;
                objBll.Status_ID = 1;
                objBll.CreatedOn = DateTime.Now;
                objBll.CreatedBy = Convert.ToInt32(Session["ContactID"]);


                objBll.TCS_DropBoxAdd(objBll);

                if (!Directory.Exists(strFolderPath))
                {
                    Directory.CreateDirectory(strFolderPath);
                }
                

            }
            
        }
        ImpromptuHelper.ShowPrompt("Access updated successfully.");
        

        ViewState["mode"] = "none";
        ViewState["Grid"] = null;

    }

    ////////////protected void lnkBtnBack_Click(object sender, EventArgs e)
    ////////////{
        
    ////////////}


    protected void ResetControls()
    {
        gvResDetail.DataSource = null;
        ViewState["mode"] = "add";
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
               
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }




    ////////////protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    ////////////{


    ////////////}





    protected void gvResources_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResDetail.PageIndex = e.NewPageIndex;
        BindGridResourceDetail();
    }

    protected void BindGridResourceDetail()
    {
        //////int resID = 0;
        //////if (ViewState["CMNResourceID"] != null)
        //////{
            DataTable dtcenter = new DataTable();
            BLLTCS_DropBox objBll = new BLLTCS_DropBox();
            //resID = Convert.ToInt32(ViewState["CMNResourceID"]);

            ////////////resID = 8;
            ////////objBll.CMNResource_ID = resID;
            ////////objBll.Region_ID = Convert.ToInt32(ddlRegion.SelectedValue);

            objBll.Region_ID = 1;


            dtcenter = objBll.TCS_DrobBoxSelectAllCenterByRegionId(objBll);
            ////////////////gvResDetail.DataSource = dtcenter;
            ////////////////gvResDetail.DataBind();
            ViewState["ResDeatilGrid"] = dtcenter;
        //////////////}
    }



    protected void BindRegionDropBoxGrid()
    {
       


        //////int resID = 0;
        //////if (ViewState["CMNResourceID"] != null)
        //////{
        DataTable dt = new DataTable();
        BLLRegion oDALRegion = new BLLRegion();
        ////BLLTCS_DropBox objBll = new BLLTCS_DropBox();
        //resID = Convert.ToInt32(ViewState["CMNResourceID"]);

        ////////////resID = 8;
        ////////objBll.CMNResource_ID = resID;
        oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(Session["moID"].ToString());
        dt = oDALRegion.RegionFetch(oDALRegion);
        gvRegionDpb.DataSource = dt;
        gvRegionDpb.DataBind();
        ViewState["ResDeatilGrid"] = dt;
        //////////////}
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
        gvResDetail.PageIndex = e.NewPageIndex;
        BindGridResourceDetail();
    }
   
    


    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
      BindGridResourceDetail();
    }


    protected void FillRegion()
    {
        


        BLLRegion oDALRegion = new BLLRegion();
        DataTable dt = new DataTable();

        oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(Session["moID"].ToString());
        dt = oDALRegion.RegionFetch(oDALRegion);

        objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");

    }


    protected void btnRegion_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
         string RegionName = gvr.Cells[2].Text;

         //string strFolderPath = "";

         Session["ResCat"] = btn.CommandArgument;
         Session["CatName"] = btn.CommandName;
         Session["View"] = "ho";
         Session["Module"] = "DropBox";
         ////////Session["FolderPath"] = strFolderPath;
        ////////


         DataTable dtcenter = new DataTable();
         BLLTCS_DropBox objBll = new BLLTCS_DropBox();
         
         objBll.Region_ID = 1;


         dtcenter = objBll.TCS_DrobBoxSelectAllCenterByRegionId(objBll);

         if (dtcenter.Rows.Count != 0)
         {


             for (int i = 0; i < dtcenter.Rows.Count; i++)
             {

                 string CenterFullName = dtcenter.Rows[i]["CenterFullName"].ToString().Trim();
                 string strFolderPath = "D:\\TCS\\DropBox\\" + RegionName + "\\" + CenterFullName;

                 if (!Directory.Exists(strFolderPath))
                 {
                     Directory.CreateDirectory(strFolderPath);
                 }
             }
         }


        ///////////


         Session["FolderPath"] = "D:\\TCS\\DropBox\\" + RegionName;




         Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");
    }



    protected void btnCenter_Click(object sender, EventArgs e)
    {

        string RegionName;


        if (Convert.ToInt32(ddlRegion.SelectedValue) == 2000000)
        {
            RegionName = "SR";
        }
        else if (Convert.ToInt32(ddlRegion.SelectedValue) == 3000000)
        {
            RegionName = "NR";
        }
        else
        {
            RegionName = "CR";
        }




        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        ////////string strFolderPath = gvr.Cells[3].Text;
        string strFolderPath = "";

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.CommandName;
        Session["View"] = "ho";
        Session["Module"] = "DropBox";
        ////////Session["FolderPath"] = strFolderPath;


        Session["FolderPath"] = "D:\\TCS\\DropBox\\" + RegionName;




        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");


    }


    protected void ddl_MOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCountries();

    }

    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRegion();

        BindRegionDropBoxGrid();

        BindGridResourceDetail();


    }




    protected void loadOrg(object sender, EventArgs e)
    {
        BLLMain_Organisation oDALMainOrgnization = new BLLMain_Organisation();
        DataTable dt = new DataTable();
        dt = oDALMainOrgnization.Main_OrganisationFetch(oDALMainOrgnization);

        DataRow row = (DataRow)Session["rightsRow"];


        if (row["User_Type"].ToString() == "Admin")
        {
            ddl_MOrg.Items.Add(new ListItem(row["Main_Organisation_Name"].ToString(), row["Main_Organisation_Id"].ToString()));

            ddl_MOrg.SelectedIndex = 1;

            ddl_MOrg_SelectedIndexChanged(sender, e);

        }
        else
        {
            objBase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
        }
        ddl_country.Items.Clear();
        ddl_country.Items.Add(new ListItem("Select", "0"));

        ddlRegion.Items.Clear();
        ddlRegion.Items.Add(new ListItem("Select", "0"));

        //////////ddl_center.Items.Clear();
        //////////ddl_center.Items.Add(new ListItem("Select", "0"));
    }

    protected void loadCountries()
    {
        BLLMain_Organisation_Country oDALMainOrgCountry = new BLLMain_Organisation_Country();
        oDALMainOrgCountry.Main_Organisation_Id = Convert.ToInt32(ddl_MOrg.SelectedValue.ToString());

        DataTable dt = new DataTable();
        dt = oDALMainOrgCountry.Main_Organisation_CountryFetch(oDALMainOrgCountry);

        objBase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");

        ddlRegion.Items.Clear();
        ddlRegion.Items.Add(new ListItem("Select", "0"));

        //////////ddl_center.Items.Clear();
        //////////ddl_center.Items.Add(new ListItem("Select", "0"));


    }


}
