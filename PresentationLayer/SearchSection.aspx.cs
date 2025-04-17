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
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_SearchSection : System.Web.UI.Page
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
        }
        catch (Exception)
        {
        }
        try
        {
            if (!Page.IsPostBack)
            {

                //======== Page Access Settings ========================
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
          //      tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx",false);
                }

                //====== End Page Access settings ======================

                ///filling region
                ///
                int moID = Int32.Parse(Session["moID"].ToString());
                BLLRegion oDALRegion = new BLLRegion();

                oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
                DataTable dt  = oDALRegion.RegionFetch(oDALRegion);

                objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");
                
                ///filling class
                ///

                BLLClass objCs = new BLLClass();


                objCs.Main_Organisation_Id = moID;
                dt = objCs.ClassFetch(objCs);
                objBase.FillDropDown(dt, list_class, "Class_Id", "Class_Name");

                //filling subject
                BLLSubject objSub = new BLLSubject();
                objSub.Main_Organisation_Id = moID;
                dt = objSub.SubjectFetch(objSub);
                objBase.FillDropDown(dt, list_subject, "Subject_Id", "Subject_Name");


                if (Convert.ToBoolean(row["Main_Organisation"].ToString()) == true)
                {

                }
                else if (Convert.ToBoolean(row["Region"].ToString()) == true)
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);
                }
                else if (Convert.ToBoolean(row["Center"].ToString()) == true)
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    list_center.SelectedValue = row["Center_Id"].ToString();
                    list_center.Enabled = false;
                    list_center_SelectedIndexChanged(sender, e);
                }
                else if (Convert.ToBoolean(row["Teacher"].ToString()) == true)
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    list_center.SelectedValue = row["Center_Id"].ToString();
                    list_center.Enabled = false;
                    list_center_SelectedIndexChanged(sender, e);

                    list_teacher.SelectedValue = row["User_Id"].ToString();
                    list_teacher.Enabled = false;
                }

                if (list_center.Enabled == false)
                {
                    lab_center.Text = list_center.SelectedItem.Text;
                    list_center.Visible = false;
                }
                if (list_region.Enabled == false)
                {
                    lab_region.Text = list_region.SelectedItem.Text;
                    list_region.Visible = false;
                }
                if (list_teacher.Enabled == false)
                {
                    lab_teacher.Text = list_teacher.SelectedItem.Text;
                    list_teacher.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void dg_section_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_section.Rows.Count > 0)
            {
                dg_section.UseAccessibleHeader = false;
                dg_section.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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

            BLLSearchSection objSec = new BLLSearchSection();
            objSec.Class_Name = text_className.Text;
            objSec.Class_Id = list_class.SelectedValue.ToString();
            objSec.Region_Id = list_region.SelectedValue.ToString();
            objSec.Center_Id = list_center.SelectedValue.ToString();
            objSec.Subject_Id = list_subject.SelectedValue.ToString();
            objSec.Mo_Id = Session["moID"].ToString();
            objSec.Teacer_Id = list_teacher.SelectedValue.ToString();

            DataTable dt = objSec.SearchSectionFetch(objSec);


            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                dg_section.DataSource = dt;
                lab_dataStatus.Visible = false;
            }
            dg_section.DataBind();

            ViewState["sectionDT"] = dg_section.DataSource;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_region.SelectedValue == "")
            {
                list_center.Items.Clear();
                list_center.Items.Insert(0, new ListItem("Select", ""));

                list_teacher.Items.Clear();
                list_teacher.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                ///filling country
                ///
                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Convert.ToInt32(list_region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_class_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dg_section.PageIndex = e.NewPageIndex;
            dg_section.DataSource = (DataTable)ViewState["sectionDT"];
            dg_section.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_section_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "detail")
            {
                int ind = Int32.Parse(e.CommandArgument.ToString());

                GridViewRow gvrow1 = dg_section.Rows[ind];
                Session["Center_Id"] = dg_section.Rows[ind].Cells[8].Text;
                Session["SectionID"] = dg_section.DataKeys[ind].Value;
                Response.Redirect("SectionDetail.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_center.SelectedValue == "")
            {
                list_teacher.Items.Clear();
                list_teacher.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                ///filling teacher
                ///
                BLLSection_Subject objTe = new BLLSection_Subject();

                objTe.Center_Id = Int32.Parse(list_center.SelectedValue.ToString());
                DataTable dt = objTe.Section_SubjectSelectTeacherByCenter_Id(objTe);
                objBase.FillDropDown(dt, list_teacher, "Employee_Id", "name");

            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
