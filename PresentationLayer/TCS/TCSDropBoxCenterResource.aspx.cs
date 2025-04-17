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

public partial class PresentationLayer_TCS_TCSDropBoxCenterResource : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            /// New Form
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
        }
        BindDropBoxPath();


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

    protected void BindDropBoxPath()
    {
       try
       {

        // For center drop box




        string strFolderPath = "";

        Session["ResCat"] = "";
        Session["CatName"] = "";
        Session["View"] = "campus";
        Session["Module"] = "DropBox";
        ////////Session["FolderPath"] = strFolderPath;


        Session["FolderPath"] = "D:\\TCS\\DropBox\\";




        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");

       }
       catch (Exception ex)
       {
           Session["error"] = ex.Message;
           Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
       }


    }


   

}
