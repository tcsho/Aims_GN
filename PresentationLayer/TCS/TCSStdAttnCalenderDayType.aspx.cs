using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TSSStdAttnCalenderDayType : System.Web.UI.Page
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
        gvCalDayType.DataSource = null;
        gvCalDayType.DataBind();
        BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();
        DataTable dt = new DataTable();

        dt = bll.TCS_StdAttnCalenderDayTypeSelectAll();
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            gvCalDayType.DataSource = dt;
            gvCalDayType.DataBind();
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

            int AlreadyIn = 0;


        BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();

        if (ViewState["Mode"].ToString() == "add")
        {
            bll.CalTypeDesc = txtDescription.Text.Trim().Replace("'", "");
            bll.Status_Id = 1;
            bll.CreatedBy = Int32.Parse(Session["ContactID"].ToString());
            bll.CreatedOn = System.DateTime.Now;

            int isSave = bll.TCS_StdAttnCalenderDayTypeInsert(bll);
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
            bll.CalDayType_Id = Int32.Parse(ViewState["CalDayType_Id"].ToString());
            bll.CalTypeDesc = txtDescription.Text.Trim().Replace("'", "");
            bll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
            bll.ModifiedOn = System.DateTime.Now;

            AlreadyIn =  bll.TCS_StdAttnCalenderDayTypeUpdate(bll);
            txtDescription.Text = "";
            ImpromptuHelper.ShowPrompt("Record Updated Successfully");
        }
        bindGV();
        ResetControls();
              }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void ResetControls()
    {
        trCDT.Visible = false;
        trCDTEnt.Visible = false;
        txtDescription.Text = "";
        btns.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetControls();
    }

    protected void btnCompose_Click(object sender, EventArgs e)
    {
        trCDT.Visible = true;
        trCDTEnt.Visible = true;
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
        int CalDayType_Id = Int32.Parse(imgbtn.CommandArgument);
        ViewState["Mode"] = "Edit";
        ViewState["CalDayType_Id"] = CalDayType_Id;
        trCDT.Visible = true;
        trCDTEnt.Visible = true;
        btnSave.Text = "Update";
        GridViewRow gvr;
        gvr = (GridViewRow)imgbtn.NamingContainer;
        gvCalDayType.SelectedIndex = gvr.RowIndex;
        loadFrm(CalDayType_Id);
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
        int cal_ID = Int32.Parse(imgbtn.CommandArgument);

        BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();
        bll.CalDayType_Id = cal_ID;
        bll.ModifiedBy = Int32.Parse(Session["ContactID"].ToString());
        bll.ModifiedOn = System.DateTime.Now;
        bll.TCS_StdAttnCalenderDayTypeDelete(bll);
        bindGV();

              }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void loadFrm(int CalDayType_Id)
    {
         try
        {
        BLLTCS_StdAttnCalenderDayType bll = new BLLTCS_StdAttnCalenderDayType();
        DataTable dt = new DataTable();

        dt = bll.TCS_StdAttnCalenderDayTypeSelectAll();
        if (dt.Rows.Count > 0)
        {
            bll.CalDayType_Id = CalDayType_Id;
            dt = bll.TCS_StdAttnCalenderDayTypeSelectByCalDayType_Id(bll);
            if (dt.Rows.Count > 0)
            {
                ViewState["LoadData"] = dt;
                txtDescription.Text = dt.Rows[0]["CalTypeDesc"].ToString();
            }
        }
        }
         catch (Exception ex)
         {
             Session["error"] = ex.Message;
             Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
         }
    }
    protected void gvCalDayType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCalDayType.PageIndex = e.NewPageIndex;
        gvCalDayType.DataSource = ViewState["LoadData"];
        gvCalDayType.DataBind();
    }
}
