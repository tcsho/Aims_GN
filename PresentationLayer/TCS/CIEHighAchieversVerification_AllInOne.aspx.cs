using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_CIEHighAchieversVerification_AllInOne : System.Web.UI.Page
{
    DALBase objbase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            DataRow row = (DataRow)Session["rightsRow"];

            if (!IsPostBack)
            {
                loadOrg(sender, e);
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }
                if (row["User_type_id"].ToString() == "5")
                {
                    btnAcknowledge.Visible = false;
                }
                FillActiveSessions();

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = true;
                    ddl_region.Enabled = true;
                    ddl_center.Enabled = true;
                   // ddlResultMonth.SelectedValue = "2";

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 10) //Network
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;


                }

                loadResultMonth();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
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
        try
        {
            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            if (ddlSession.SelectedIndex > 0)
            {
                objCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            }
            else
            {
                objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            }

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objbase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            DataRow row = (DataRow)Session["rightsRow"];

            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
            {
                ddl_center.SelectedValue = row["Center_Id"].ToString();
            }

            //////////UserInformationGrid3.SetData(dt);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadRegions();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void loadRegions()
    {
        try
        {
            string q = Request.QueryString["id"];
            string s = Request.QueryString["id"];
            if (Convert.ToInt32(s) == 92 || Convert.ToInt32(s) > 92 || Convert.ToInt32(s) == 97 || Convert.ToInt32(s) < 97)
            {
                //lab_center.Text = "School*: ";
            }

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ddl_country.SelectedValue.ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objbase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddl_MOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCountries();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void loadOrg(object sender, EventArgs e)
    {

        try
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
                objbase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
            }
            ddl_country.Items.Clear();
            ddl_country.Items.Add(new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void loadCountries()
    {
        try
        {

            BLLMain_Organisation_Country oDALMainOrgCountry = new BLLMain_Organisation_Country();
            oDALMainOrgCountry.Main_Organisation_Id = Convert.ToInt32(ddl_MOrg.SelectedValue.ToString());

            DataTable dt = new DataTable();
            dt = oDALMainOrgCountry.Main_Organisation_CountryFetch(oDALMainOrgCountry);

            objbase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");
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
            objbase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            // ddlSession.SelectedValue = Session["Session_Id"].ToString();


            ddlSession.Items.Remove(ddlSession.Items.FindByText("AY 2014 - 2015"));
            ddlSession.Items.Remove(ddlSession.Items.FindByText("AY 2015 - 2016"));

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }



    public void BindGrid()
    {
        try
        {
            if (ViewState["dtDetails"] == null)
            {

                if (ddlSession.SelectedIndex > 0)
                {
                    DataTable dt = new DataTable();
                    BLLCIE_Student_Mapping objstudent = new BLLCIE_Student_Mapping();

                    objstudent.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

                    if (ddl_region.SelectedIndex > 0)
                    {
                        objstudent.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
                    }
                    else
                    {
                        objstudent.Region_Id = 0;
                    }


                    if (ddl_center.SelectedIndex > 0)
                    {
                        objstudent.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
                    }
                    else
                    {
                        objstudent.Center_Id = 0;
                    }
                    //if (ddlclass.SelectedIndex > 0)
                    //{
                    //    //objstudent.Glevel = ddlclass.SelectedItem.Text.ToString();
                    //    //*****2023-Aug-7
                    //    
                    //}
                    if (ddlResultMonth.SelectedIndex > 0)
                    {

                        //*****2023-Aug-7
                        objstudent.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue.ToString());
                    }
                    else
                    {
                        objstudent.Glevel = "";
                    }
                    dt = objstudent.CIE_HighAchieversSelectByCenter(objstudent);


                    if (dt.Rows.Count > 0)
                    {
                        ViewState["dtDetails"] = dt;
                        gvStudents.DataSource = dt;
                        gvStudents.DataBind();
                    }
                    else
                    {
                        gvStudents.DataSource = null;
                        gvStudents.DataBind();
                    }

                }
            }
            else
            {
                DataTable dt = (DataTable)ViewState["dtDetails"];
                gvStudents.DataSource = dt;
                gvStudents.DataBind();
            }

            if (ViewState["IsFilter"] != null)
            {
                int fliter = Convert.ToInt32(ViewState["IsFilter"].ToString());
                ApplyFilter(fliter);

            }

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["dtDetails"] = null;
        //BindGrid();
    }
    protected void dg_student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudents.Rows.Count > 0)
            {
                gvStudents.UseAccessibleHeader = false;
                gvStudents.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BtnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            BLLCIE_HighAchieverVerification objStd = new BLLCIE_HighAchieverVerification();

            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;


            TextBox txtAStar = (TextBox)currentRow.FindControl("txtAStar");
            TextBox txtAGrade = (TextBox)currentRow.FindControl("txtAGrade");

            if (btn.CommandArgument != "0")
            {

                if (txtAStar.Text.Length < 1 && txtAGrade.Text.Length < 1)
                {
                    ImpromptuHelper.ShowPrompt("Please enter Grade Values!");
                }
                else
                {

                    objStd.HA_Id = Convert.ToInt32(btn.CommandArgument);
                    objStd.AStar = Convert.ToInt32(txtAStar.Text);
                    objStd.AGrade = Convert.ToInt32(txtAGrade.Text);
                    objStd.VerifiedBy = Int32.Parse(Session["ContactId"].ToString());

                    int AlreadyIn = objStd.CIE_HighAchieverVerificationVerify(objStd);

                    if (AlreadyIn == 1)
                    {
                        ViewState["dtDetails"] = null;
                        BindGrid();

                    }


                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            //}
        }
    }




    protected void btnUnverify_Click(object sender, EventArgs e)
    {
        try
        {
            BLLCIE_HighAchieverVerification objStd = new BLLCIE_HighAchieverVerification();

            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;

            if (btn.CommandArgument != "0")
            {
                objStd.HA_Id = Convert.ToInt32(btn.CommandArgument);
                int AlreadyIn = objStd.CIE_HighAchieverVerificationUnVerify(objStd);

                if (AlreadyIn == 1)
                {
                    ViewState["dtDetails"] = null;
                    BindGrid();

                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            //}
        }
    }


    protected void BtnUnlock_Click(object sender, EventArgs e)
    {
        try
        {
            BLLCIE_HighAchieverVerification objStd = new BLLCIE_HighAchieverVerification();

            LinkButton btn = (LinkButton)(sender);
            GridViewRow currentRow = (GridViewRow)btn.NamingContainer;
            gvStudents.SelectedIndex = currentRow.RowIndex;

            objStd.HA_Id = Convert.ToInt32(btn.CommandArgument);
            int AlreadyIn = objStd.CIE_HighAchieverVerificationUnLock(objStd);

            if (AlreadyIn == 1)
            {
                ViewState["dtDetails"] = null;
                BindGrid();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnUnVerified_Click(object sender, EventArgs e)
    {
        ResetFilter();
        ApplyFilter(1);
    }

    protected void btnVerified_Click(object sender, EventArgs e)
    {
        ResetFilter();
        ApplyFilter(2);
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        ViewState["IsFilter"] = null;
        ResetFilter();

    }



    protected void ApplyFilter(int _FilterCondition)
    {
        try
        {
            ViewState["IsFilter"] = _FilterCondition;
            if (ViewState["dtDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtDetails"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // Pending
                        {
                            strFilter = " Convert([IsLock], 'System.String')='false'";

                            break;
                        }

                    case 2: //Submitted
                        {
                            strFilter = " Convert([IsLock], 'System.String')='true'";
                            ViewState["IsFilter"] = 2;
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gvStudents.DataSource = dv;
                gvStudents.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void ResetFilter()
    {
        try
        {
            BindGrid();
            gvStudents.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        if (ddlSession.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
        {
            BLLCIE_HighAchieverVerification objStd = new BLLCIE_HighAchieverVerification();

            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objStd.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

            int AlreadyIn = objStd.CIE_HighAchieverVerificationLock(objStd);
            if (AlreadyIn == 1)
            {
                ViewState["dtDetails"] = null;
                BindGrid();
                ImpromptuHelper.ShowPrompt("All verified records are locked successfully");

            }



        }

    }

    //protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindGrid();
    //    ViewState["dtDetails"] = null;
    //}


    private void loadResultMonth()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            objbase.FillDropDown(dt, ddlResultMonth, "ResultSeries_Id", "ResultSeries");

            //if (DateTime.Now.Month > 9)
            //{
            //    ddlResultMonth.SelectedIndex = 2;
            //}
            //else
            //{
            //    ddlResultMonth.SelectedIndex = 1;
            //}
            // UploadSettings();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlResultMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["dtDetails"] = null;
        BindGrid();
        
        //UploadSettings();

    }
}
