using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_SearchUserWithPassword : System.Web.UI.Page
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
        }
        catch (Exception)
        {
        }
        try
        {
            if (!Page.IsPostBack)
            {
                //======== Page Access Settings ========================


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

                ///filling gender
                ///

                DALBase oDALBase = new DALBase();
                DataSet ods = new DataSet();
                ods = null;
                ods = oDALBase.get_Gender();
                DataTable dt = ods.Tables[0];
                objBase.FillDropDown(dt, list_gender, "Gender_Id", "Gender");

                ///filling region
                ///
                BLLRegion oDALRegion = new BLLRegion();

                oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
                dt = oDALRegion.RegionFetch(oDALRegion);

                objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");


                ///filling user type
                ///

                DALGroups oDALGroups = new DALGroups();
                ods = null;

                ods = oDALGroups.get_AllGroupsUserType();

                list_groupName.Items.Clear();
                objBase.FillDropDown(ods.Tables[0], list_groupName, "User_Type_ID", "Type_Description");
                list_center.Items.Insert(0, new ListItem("Select", ""));


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
                    //list_center_SelectedIndexChanged(sender, e);
                }
                else if (Convert.ToBoolean(row["Teacher"].ToString()) == true)
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    list_center.SelectedValue = row["Center_Id"].ToString();
                    list_center.Enabled = false;

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


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void dg_user_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_user.Rows.Count > 0)
            {
                dg_user.UseAccessibleHeader = false;
                dg_user.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            ///searching
            ///

            BLLSearchUser objUs = new BLLSearchUser();
            objUs.FirstName = text_firstName.Text;
            objUs.LastName = text_lastName.Text;
            objUs.MiddleName = text_middleName.Text;
            objUs.Gender_Id = list_gender.SelectedValue;
            objUs.User_Type_Id = list_groupName.SelectedValue;
            objUs.Region_Id = list_region.SelectedValue;
            objUs.Cetnter_Id = list_center.SelectedValue;
            objUs.Mo_Id = Session["moID"].ToString();
            //////////DataTable dt = objUs.SearchUserFetch(objUs);

            DataTable dt = objUs.SearchUserWithPassword(objUs);

            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                dg_user.DataSource = dt;
                lab_dataStatus.Visible = false;
            }
            dg_user.DataBind();
            ViewState["userDT"] = dt;


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_user_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "name")
            {
                int ind = Int32.Parse((string)e.CommandArgument);
                Session["userType"] = 4;
                Session["user_id"] = dg_user.DataKeys[ind].Value;

                // New Session Variable Used For Keeping Value of UserName to UserOptions.aspx in Password Update Process (12.12.08) ...
                Session["UserName"] = dg_user.DataKeys[ind].Values[1].ToString();

                //Response.Redirect("UserOptions.aspx", false);
            }

            if (e.CommandName == "notify")
            {
                int ind = Int32.Parse((string)e.CommandArgument);
                Session["user_name"] = dg_user.DataKeys[ind].Values[1].ToString();

                Response.Redirect("Messeges/Messeges.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_user_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dg_user.PageIndex = e.NewPageIndex;
            dg_user.DataSource = (DataTable)ViewState["userDT"];
            dg_user.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void btnPassChange_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

        try
        {

        ImageButton imgbtn = (ImageButton)sender;
        int User_Id = Convert.ToInt32(imgbtn.CommandArgument);
        BLLLogin ObjLog = new BLLLogin();

        ObjLog.User_Id = User_Id;
        int AlreadyIn = ObjLog.LoginReset(ObjLog);
        ImpromptuHelper.ShowPrompt("Password has changed to default");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

}
