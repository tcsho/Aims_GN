using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_TcsHlpDskSubCatg : System.Web.UI.Page
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
            txtName.Focus();

            FillMainCatagories();


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
    protected void gvDCT_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvDCT.Rows.Count > 0)
            {
                gvDCT.UseAccessibleHeader = false;
                gvDCT.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvDCT.FooterRow.TableSection = TableRowSection.TableFooter;
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
        ViewState["mode"] = "add";
        ContentDetailSection.Style.Add("display", "block");
        Session["EditregID"] = null;
        btnSave.Visible = true;
        ResetControls();

    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["mode"] = "edit";
        ContentDetailSection.Style.Add("display", "block");

        ImageButton btnEdit = (ImageButton)sender;
        regID = Convert.ToInt32(btnEdit.CommandArgument);

        ViewState["EditID"] = regID;

        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        gvDCT.SelectedIndex = gvr.RowIndex;
        LoadDataByID(regID);

    }

    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgBtnDelete = (ImageButton)sender;
        regID = Convert.ToInt32(imgBtnDelete.CommandArgument);
        BLLTCS_HlpDskSubCatg objBll = new BLLTCS_HlpDskSubCatg();
        objBll.HDSubCat_ID = regID;

        objBll.TCS_HlpDskSubCatgDelete(objBll);
        ViewState["Grid"] = null;
        BindGrid();
    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {

        if (Session["EditregID"] != null)
        {
            Response.Redirect("~/PresentationLayer/TSS/TssFirstRegApproval.aspx");
        }
        else
        {
            ContentDetailSection.Style.Add("display", "none");
            ResetControls();

        }
    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/PresentationLayer/LMS/LmsWrkSite.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PresentationLayer/LMS/LmsWrkSpace.aspx");
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        ResetControls();
    }

    protected void Save()
    {

        BLLTCS_HlpDskSubCatg objBll = new BLLTCS_HlpDskSubCatg();
        objBll.HDSubDesc = txtName.Text;
        objBll.MCatg_ID = Convert.ToInt32(ddlMainCatg.SelectedValue);

        string strMode = "";
        int lastInsertID = 0;



        if (ViewState["mode"] != null)
        {
            strMode = ViewState["mode"].ToString();
            if (strMode == "add")
            {


                lastInsertID = objBll.TCS_HlpDskSubCatgInsert(objBll);
                if (lastInsertID == 0)
                {
                    ImpromptuHelper.ShowPrompt("Catagory Created successfully.");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("A Catagory with this name already exists!");
                }
            }
            //Update mode
            else
            {
                if (ViewState["EditID"] != null)
                {
                    regID = Convert.ToInt32(ViewState["EditID"]);
                    objBll.HDSubCat_ID = regID;


                    objBll.TCS_HlpDskSubCatgUpdate(objBll);
                    ImpromptuHelper.ShowPrompt("Catagory updated successfully.");
                }
            }
        }

        //ViewState["mode"] = "none";        
        ViewState["mode"] = "add";
        ViewState["Grid"] = null;
        BindGrid();

    }

    protected void BindGrid()
    {
        if (ddlMainCatg.SelectedValue != "0")
        {
            DataTable dt = new DataTable();
            BLLTCS_HlpDskSubCatg objBll = new BLLTCS_HlpDskSubCatg();
            objBll.MCatg_ID = Convert.ToInt32(ddlMainCatg.SelectedValue);

            if (ViewState["Grid"] != null)
            {
                dt = (DataTable)ViewState["Grid"];
            }
            else
            {
                dt = objBll.TCS_HlpDskSubCatgSelectByMCatgId(objBll);
            }

            gvDCT.DataSource = dt;
            gvDCT.DataBind();

            ViewState["Grid"] = dt;
        }
    }

    protected void LoadDataByID(int selectID)
    {

        BLLTCS_HlpDskSubCatg objBll = new BLLTCS_HlpDskSubCatg();
        objBll.HDSubCat_ID = selectID;


        DataTable dt = new DataTable();
        dt = objBll.TCS_HlpDskSubCatgSelectById(objBll);
        DataRow dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];
            txtName.Text = dr["HDSubDesc"].ToString();

        }
    }

    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/PresentationLayer/LMS/LmsNewsSummaryView.aspx");
    }



    protected void ResetControls()
    {
        txtName.Text = "";
        txtName.Focus();
    }

    protected void btnTitle_Click(object sender, EventArgs e)
    {
        ViewState["mode"] = "edit";
        ContentDetailSection.Style.Add("display", "block");
        LinkButton btnTitle = (LinkButton)sender;
        regID = Convert.ToInt32(btnTitle.CommandArgument);
        ViewState["EditID"] = regID;

        GridViewRow gvr = (GridViewRow)btnTitle.NamingContainer;
        gvDCT.SelectedIndex = gvr.DataItemIndex;
        LoadDataByID(regID);
    }

    protected void gvDCT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDCT.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void FillMainCatagories()
    {
        BLLTCS_HlpDskMainCatg objBll = new BLLTCS_HlpDskMainCatg();
        DataRow row = (DataRow)Session["rightsRow"];
        objBll.Main_Organisation_Id = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
        DataTable dt = new DataTable();
        dt = objBll.TCS_HlpDskMainCatgSelectByMainOrgID(objBll);
        objBase.FillDropDown(dt, ddlMainCatg, "MCatg_ID", "MCatDesc");
    }
    protected void ddlMainCatg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMainCatg.SelectedValue != "0")
        {
            //ContentDetailSection.Attributes.CssStyle.Add("display", "inline");
            ResetControls();
            ViewState["Grid"] = null;
            BindGrid();
        }
        else
        {
            //ContentDetailSection.Attributes.CssStyle.Add("display", "none");
        }
    }
}
