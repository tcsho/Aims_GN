using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_WorkSiteUpdate : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
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
            try
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


            bindClassSection();
            

            }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        }
    }

    protected void bindClassSection()
    {
        try
        {

            BLLTCS_StdAttn obj = new BLLTCS_StdAttn();

            obj.Center_Id = Convert.ToInt32(Session["cId"]); 
            DataTable dt = (DataTable)obj.TssSelectClassSectionByCenter(obj);
            objbase.FillDropDown(dt, ddl_ClassSection, "Section_id", "Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    
    protected void bindGV()
    {
        try
        {
        gvAttnType.DataSource = null;
        gvAttnType.DataBind();
        BLLSection_Subject bll = new BLLSection_Subject();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dt = new DataTable();

        bll.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);
        dt = bll.Section_SubjectSelectWorkSiteBySection_Id(bll);
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
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    
    protected void lnkAddCal_Click(object sender, EventArgs e)
    {
        
        try
        {

            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLSection_Subject objClsSec = new BLLSection_Subject();
            DataTable dtsub = new DataTable();
            objClsSec.Description = txtDesc.Text.ToString();
            objClsSec.SpecialInstructions = txtSpcIns.Text.ToString();




            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {


            }

            else
            {



                objClsSec.Section_Subject_Id = Convert.ToInt32(ViewState["SectionSubjectID"]);
                AlreadyIn = objClsSec.Section_SubjectWorkSiteUpdate(objClsSec);


                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    ResetControls();
                    bindGV();

                }
                
            }

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
        trCDT.Visible = false;
        btns.Visible = false;
        btnGen.Visible = false;
        trDate.Visible = false;
        trOpt.Visible = false;
        txtDesc.Text = "";
        TrDate2.Visible = false;

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
        BLLSection_Subject objClsSec = new BLLSection_Subject();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string SectionSubjectID = btn.CommandArgument;

        trCDT.Visible = true;
        btns.Visible = true;
        trDate.Visible = true;
        txtDesc.Visible = true;
        TrDate2.Visible = true;
        txtSpcIns.Visible = true;
        trOpt.Visible = true;
        btnSave.Text = "Save";
        


        ViewState["SectionSubjectID"] = SectionSubjectID;


        objClsSec.Section_Id = Int32.Parse(ddl_ClassSection.SelectedValue);
        objClsSec.Section_Subject_Id = Convert.ToInt32(SectionSubjectID);


        dtsub = (DataTable)objClsSec.Section_SubjectSelectWorkSiteBySection_Subject_Id(objClsSec);

        txtDesc.Text = dtsub.Rows[0]["Description"].ToString().Trim();
        txtSpcIns.Text = dtsub.Rows[0]["SpecialInstructions"].ToString().Trim();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvAttnType.PageIndex = e.NewPageIndex;
        gvAttnType.DataSource = ViewState["LoadData"];
        gvAttnType.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
       
        bindGV();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
