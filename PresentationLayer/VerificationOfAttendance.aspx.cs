using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.IO;
using System.Web.UI;
using System.IO;
using System.Text;
using Org.BouncyCastle.Ocsp;
public partial class PresentationLayer_VerificationOfAttendance : System.Web.UI.Page
{
    private int windowWidth = 5;
    DALBase objBase = new DALBase();
    int UL_ID;
    BLLSearchStudent objSer = new BLLSearchStudent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataRow row = (DataRow)Session["rightsRow"];
                lblSave.Text = "";
                //////////pan_new2.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Campus Officer
                {
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = 0;
                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Regional Officer
                {

                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = row["Center_Id"].ToString();
                }

                loadRegions();
               // loadCenter();
                
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }
    private void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            int c_id;
            if (ddl_center.SelectedIndex < 0)
            {
                DataRow row = (DataRow)Session["rightsRow"];
                c_id = Convert.ToInt32(row["Center_Id"].ToString());
            }
            else
            {
                c_id = Convert.ToInt32(ddl_center.SelectedValue);
            }
            objBLLClass.Center_Id = c_id;
            dt = objBLLClass.ClassFetchByCenterID(objBLLClass);
            objBase.FillDropDown(dt, list_Class, "Class_Id", "Class_Name");
            
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
            if (ddl_Region.SelectedValue == "")
            {
                ddl_Region.Items.Clear();
                ddl_Region.Items.Insert(0, new ListItem("Select", ""));
            }
           

                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Int32.Parse(ddl_Region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, ddl_center, "center_Id", "center_name");
            


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
           // int term = Convert.ToInt32(list_Term.SelectedValue); 
           // int c_id = Convert.ToInt32(ddl_center.SelectedValue);
           // int Reg=Int32.Parse(ddl_Region.SelectedValue);
           //int Class_Id = Convert.ToInt32(list_Class.SelectedValue.ToString());
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_AdmTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            list_Term.SelectedValue = "0";
            // BindTerm();
            //BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    //private void loadRegions()
    //{
    //    try
    //    {
    //        BLLRegion oDALRegion = new BLLRegion();
    //        DataTable dt = new DataTable();

    //        oDALRegion.Main_Organisation_Country_Id = 1;
    //        dt = oDALRegion.RegionFetch(oDALRegion);

    //        objBase.FillDropDown(dt, ddl_Region, "Region_Id", "Region_Name");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_Region, "Region_Id", "Region_Name");


            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                ddl_Region.SelectedValue = ViewState["RegionId"].ToString();
                ddl_Region.Enabled = false;
                loadCenter();
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        } 
    }

    private void BindGrid()
    {
        try
        {
            BLLVerificationOfAttendence objClsSec = new BLLVerificationOfAttendence();
            DataTable dtsub = new DataTable();
            
            if (!string.IsNullOrEmpty(ddl_center.SelectedValue))
            {
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            }
            else
            {
                objClsSec.Center_Id = 0;
            }
            if (!string.IsNullOrEmpty(list_Class.SelectedValue))
            {
                objClsSec.Class_Id = Convert.ToInt32(list_Class.SelectedValue);
            }
            else
            {
                objClsSec.Class_Id = 0;
            }
            if (!string.IsNullOrEmpty(ddl_Region.SelectedValue))
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_Region.SelectedValue);
            }
            else
            {
                objClsSec.Region_Id = 0;
            }
            if (!string.IsNullOrEmpty(list_Term.SelectedValue))
            {
                objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue);
            }
            else
            {
                objClsSec.Evaluation_Criteria_Type_Id = 0;
            }
            
            
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.VerificationOfAttendence_Get(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }
            if (dtsub.Rows.Count > 0)
            {
                gvVerification.DataSource = dtsub;
            } 

            gvVerification.DataBind();
            ViewState["tMood"] = "check";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
 
   
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
  
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           // BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //private void loadCenter()
    //{
    //    try
    //    {
    //        BLLCenter objCen = new BLLCenter();
    //        DataTable dt = new DataTable();
    //        dt = objCen.CenterFetchByRegionID(objCen);
    //        objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}

    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            if (Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
            {
                objCen.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_Region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            {
                ddl_center.SelectedValue = ViewState["CenterId"].ToString();
                ddl_center.Enabled = false;
                FillClass();
            } 
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
            FillClass();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    
    protected void dg_student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvVerification.Rows.Count > 0)
            {
                gvVerification.UseAccessibleHeader = false;
                gvVerification.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvVerification_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    gvVerification.PageIndex = e.NewPageIndex;
        // Call the method to bind data to your GridView here
        BindGrid(); // Replace this with your data-binding logic
    }

}