using System;
using System.Data;
using System.Web.UI.WebControls;
//using GleamTech.Web.Controls;

public partial class PresentationLayer_TCS_TCSGResourcesDownload : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"];
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        ////////}
        ////////catch (Exception ex)
        ////////{
        ////////    Session["error"] = ex.Message;
        ////////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        ////////}

        if (!IsPostBack)
        {
            //======== Page Access Settings ========================

            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();

            if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            {
                Session.Abandon();
                Response.Redirect("~/login.aspx",false);
            }
            Session["AddCriteria"] = null;

            //====== End Page Access settings ======================


            //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];            
            FillDropDowns();
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
        //        FillResourceCatagories();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {


    }

    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/PresentationLayer/LMS/LmsNewsSummaryView.aspx");
    }



    protected void FillSession()
    {
        //BLLSession objBll = new BLLSession();
        //DataTable dt = new DataTable();
        //dt = objBll.SessionSelectAll();        
        //objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");

        //foreach (DataRow dr in dt.Rows)
        //{
        //    if (Convert.ToInt32(dr["Status_ID"]) == 1)
        //    { 
        //        ddlSession.SelectedValue = dr["Session_ID"].ToString();
        //    }
        //}

    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void loadCenter()
    {
        /*DALCenter oDALCenter = new DALCenter();
        DataSet ods = new DataSet();
        ods = null;
        int id = 0;
        //if (ddlRegion.SelectedValue != "0")
        //{
        id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());
        //}

        ods = oDALCenter.get_CenterFromRegion(id);


        ddlCenter.Items.Clear();
        ddlCenter.Items.Add(new ListItem("Select", "0"));

        //CheckList Center
        //cblCenters.Items.Clear();

        //

        for (int i = 0; i <= ods.Tables[0].Rows.Count - 1; i++)
        {
            ddlCenter.Items.Add(new ListItem(ods.Tables[0].Rows[i][1].ToString(), ods.Tables[0].Rows[i][0].ToString()));
            //CheckList Center
            //cblCenters.Items.Add(new ListItem(ods.Tables[0].Rows[i][1].ToString(), ods.Tables[0].Rows[i][0].ToString()));

            //

        }*/
    }

    protected void FillClass()
    {
        try
        {

        BLLClass objBLLClass = new BLLClass();

        DataTable dt = null;
        int c_id;
            DataRow row = (DataRow)Session["rightsRow"];
            c_id = Convert.ToInt32(row["Center_Id"].ToString());
        objBLLClass.Center_Id = c_id;
        dt = objBLLClass.ClassFetchByCenterID(objBLLClass);
        objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ResetControls()
    {
        //loadRegions();
        //loadCenter();
        //ddlCenter.SelectedValue = "0";
        //if(ddlProgram.Items.Count>0)
        //ddlProgram.SelectedValue = "0";
        //ddlSession.SelectedValue = "0";
        //ddlClass.SelectedValue = "0";        

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


    protected void FillResourceCatagories()
    {
        try
        {
        BLLTssGResources objBllRes = new BLLTssGResources();
        DataTable dt = new DataTable();
        //dt = objBll.TssGResourceDCTCatagSelectAll();
        //updated 24-Jan-2013

        objBllRes.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);
        //objBllRes.Session_ID = Convert.ToInt32(ddlSession.SelectedValue);
        objBllRes.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);
        objBllRes.Subject_ID = Convert.ToInt32(ddlSubject.SelectedValue);

        //dt = objBllRes.TssGResourceDCTCatagSelectBySubject(objBllRes);
        dt = objBllRes.TssGResourceDCTCatagSelectBySubjectWOSession(objBllRes);

        gvResCat.DataSource = dt;
        gvResCat.DataBind();
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

        Session["ResCat"] = btn.CommandArgument;
        Session["CatName"] = btn.Text;
        Session["SessionID"] = 6;
        Session["ClassID"] = ddlClass.SelectedValue;
        Session["SubjectID"] = ddlSubject.SelectedValue;
        Session["View"] = "campus";
        Session["Module"] = "GNR";
        Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownloadControl.aspx");

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

    protected void ReloadSelectionCriteria()
    {
        try
        {
        //if(Session["SessionID"] != null)
        //    ddlSession.SelectedValue = Session["SessionID"].ToString();
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

}
