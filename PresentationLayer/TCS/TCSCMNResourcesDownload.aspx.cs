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

public partial class PresentationLayer_TCS_TCSCMNResourcesDownload : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        //////////////}
        //////////////catch (Exception ex)
        //////////////{
        //////////////    Session["error"] = ex.Message;
        //////////////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //////////////}

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
        FillResourceCatagories();


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

    protected void FillResourceCatagories()
    {
        try
        {
        gvResCat.DataSource = null;
        gvResCat.DataBind();

        BLLTssCMNResources objBllRes = new BLLTssCMNResources();
        DataTable _dt = new DataTable();
        objBllRes.Center_ID = Convert.ToInt32(Session["cId"].ToString());
        objBllRes.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);

        _dt = objBllRes.TssCMNResourcesSelectByMoIdCId(objBllRes);
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
        LinkButton btn = (LinkButton)sender;

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvResCat.SelectedIndex = gvr.RowIndex;

        if (gvr.Cells[0].Text == "False")
        {
            ImpromptuHelper.ShowPrompt("You are not authorized to download data!");
        }
        else
        {
            Session["ResCat"] = btn.CommandArgument;
            Session["CatName"] = btn.Text;
            Session["View"] = "campus";
            Session["Module"] = "CMN";
            Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

}
