using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TSSStdAttnType : System.Web.UI.Page
{
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
            //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }

            //====== End Page Access settings ======================


            bindGV();
        }
    }
    protected void bindGV()
    {
       
        gvAttnType.DataSource = null;
        gvAttnType.DataBind();
        BLLTCS_StdAttnType bll = new BLLTCS_StdAttnType();
        DataTable dt = new DataTable();

        dt = bll.TCS_StdAttnTypeSelectAll();
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            gvAttnType.DataSource = dt;
            gvAttnType.DataBind();
            lblNoData.Visible = false;
            lblNoData.Text = "";
        }
        else
        {
            lblNoData.Visible = true;
            lblNoData.Text = "No Data Found";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

        BLLTCS_StdAttnType bll = new BLLTCS_StdAttnType();
        if (ViewState["Mode"].ToString() == "add")
        {
            bll.AttnDesc = txtDescription.Text.Trim().Replace("'", "");
            bll.AttCode = txtCode.Text.Trim().Replace("'", "");
            bll.Status_Id = 1;
            bll.CreatedBy = Int32.Parse(Session["ContactID"].ToString());
            bll.CreatedOn = System.DateTime.Now;

            int isSave = bll.TCS_StdAttnTypeInsert(bll);
            if (isSave != 0)
            {
                ImpromptuHelper.ShowPrompt("Record already exists");
            }
            else
            {
                txtDescription.Text = "";
                ImpromptuHelper.ShowPrompt("Record is Saved Successfully");
            }
        }
        else if (ViewState["Mode"].ToString() == "Edit")
        {
            bll.AttnType_ID = Int32.Parse(ViewState["AttnType_ID"].ToString());
            bll.AttnDesc = txtDescription.Text.Trim().Replace("'", "");
            bll.AttCode = txtCode.Text.Trim().Replace("'", "");
            bll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
            bll.ModifiedOn = System.DateTime.Now;

            bll.TCS_StdAttnTypeUpdate(bll);
            ImpromptuHelper.ShowPrompt("Record Updated Successfully");
        }
        bindGV();
        ResetControl();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void ResetControl()
    {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
        trCDTEnt1.Visible = false;
        txtDescription.Text = "";
        btns.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetControl();
    }

    protected void btnCompose_Click(object sender, EventArgs e)
    {
        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        trCDTEnt1.Visible = true;
        txtDescription.Text = "";
        btnSave.Text = "Save";
        ViewState["Mode"] = "add";
        btns.Visible = true;
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
         try
        {

                ImageButton imgbtn = (ImageButton)sender;
                int AttnType_ID = Int32.Parse(imgbtn.CommandArgument);
                ViewState["Mode"] = "Edit";
                ViewState["AttnType_ID"] = AttnType_ID;
                trCDT.Visible = true;
                trCDTEnt.Visible = true;
                trCDTEnt1.Visible = true;
                btnSave.Text = "Update";
                GridViewRow gvr;
                gvr = (GridViewRow)imgbtn.NamingContainer;
                gvAttnType.SelectedIndex = gvr.RowIndex;
                loadFrm(AttnType_ID);
                btns.Visible = true;
        }
         catch (Exception ex)
         {
             Session["error"] = ex.Message;
             Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
         }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
                ImageButton imgbtn = (ImageButton)sender;
                int AttnType_ID = Int32.Parse(imgbtn.CommandArgument);

                BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();
                obj.AttnType_ID = AttnType_ID;
                obj.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
                obj.ModifiedOn = System.DateTime.Now;

                obj.TCS_StdAttnTypeDelete(obj);
                bindGV();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void loadFrm(int AttnType_ID)
    {
        try
        {

        BLLTCS_StdAttnType bll = new BLLTCS_StdAttnType();
        DataTable dt = new DataTable();

        bll.AttnType_ID = AttnType_ID;
        dt = bll.TCS_StdAttnTypeSelectByAttnType_ID(bll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            txtDescription.Text = dt.Rows[0]["AttnDesc"].ToString();
            txtCode.Text = dt.Rows[0]["AttCode"].ToString();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnType.PageIndex = e.NewPageIndex;
        gvAttnType.DataSource = ViewState["LoadData"];
        gvAttnType.DataBind();
    }
}
