using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_SearchUser : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"];
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
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
                    Response.Redirect("~/login.aspx", false);
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
                if (Session["UserType_Id"].ToString() == "5")//HO Login
                {
                    btnAddNew.Visible = true;
                }

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
    protected void ddlRegion_SelectedIndexChange(object sender, EventArgs e)
    {
        try
        {
            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddlregion.SelectedValue);
            DataTable dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddlCenter, "center_Id", "center_name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnEditUser_click(object sender, EventArgs e)
    {
        try
        {

            BLLUser objuser = new BLLUser();
            DataTable dtUser = objuser.UserTypeFetchAll();
            objBase.FillDropDown(dtUser, ddlUser_Type, "User_Type_Id", "Type_Description");

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();
            oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlregion, "Region_Id", "Region_Name");
            DALBase oDALBase = new DALBase();
            DataSet dtgender = new DataSet();

            dtgender = oDALBase.get_Gender();
            DataTable dtG = dtgender.Tables[0];
            objBase.FillDropDown(dtG, ddlGender, "Gender_Id", "Gender");
            txtPass.Enabled = false;
            divUserLogin.Visible = true;

            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            ViewState["User_Id"] = gvr.Cells[0].Text;

            if (!String.IsNullOrEmpty(gvr.Cells[6].Text))
                txtFirstName.Text = gvr.Cells[6].Text;
            else
                txtFirstName.Text = "";
            if (!String.IsNullOrEmpty(gvr.Cells[15].Text))
                txtUserName.Text = gvr.Cells[15].Text;
            else
                txtUserName.Text = "";
            if (!String.IsNullOrEmpty(gvr.Cells[7].Text))
                txtLast.Text = gvr.Cells[7].Text;
            else
                txtLast.Text = "";
            if (!String.IsNullOrEmpty(gvr.Cells[12].Text))
                txtEmail.Text = gvr.Cells[12].Text;
            else
                txtEmail.Text = "";
            if (gvr.Cells[3].Text != "0")
                ddlCenter.SelectedValue = gvr.Cells[3].Text;
            if (gvr.Cells[2].Text != "0")
                ddlregion.SelectedValue = gvr.Cells[2].Text;
            ddlGender.SelectedValue = gvr.Cells[4].Text;
            ddlUser_Type.SelectedValue = gvr.Cells[1].Text;
            if (!String.IsNullOrEmpty(gvr.Cells[5].Text))
                txtMobile.Text = gvr.Cells[5].Text;
            else
                txtMobile.Text = "";
            divUserLogin.Visible = true;
            divSearch.Visible = false;
            ddlRegion_SelectedIndexChange(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnSaveUser_click(object sender, EventArgs e)
    {
        try
        {
            BLLUser objuser = new BLLUser();
            objuser.fName = txtFirstName.Text;
            objuser.usrName = txtUserName.Text;
            objuser.lName = txtLast.Text;
            objuser.eMail = txtEmail.Text;
            objuser.address = txtAddress.Text;
            objuser.mPhone = txtMobile.Text;
            objuser.User_Id = Convert.ToInt32(ViewState["User_Id"].ToString());
            if (ddlUser_Type.SelectedIndex > 0)
                objuser.userTypeID = Convert.ToInt32(ddlUser_Type.SelectedValue);
            else
            {
                ImpromptuHelper.ShowPrompt("Please select a Group");
                return;
            }
            if (ddlGender.SelectedIndex > 0)
                objuser.genderID = Convert.ToInt32(ddlGender.SelectedValue);
            else
            {
                ImpromptuHelper.ShowPrompt("Please select a Gender");
                return;
            }
            if (ddlregion.SelectedIndex > 0)
                objuser.regionID = Convert.ToInt32(ddlregion.SelectedValue);
            else
                objuser.regionID = 0;

            if (ddlCenter.SelectedIndex > 0)
                objuser.centerID = Convert.ToInt32(ddlCenter.SelectedValue);
            else
                objuser.centerID = 0;
            int k = objuser.User_Add(objuser);
            btnCancel_click(this, EventArgs.Empty);
            dg_user.DataSource = null;
            dg_user.DataBind();
            //but_search_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCancel_click(object sender, EventArgs e)
    {
        try
        {
            divSearch.Visible = true;
            divUserLogin.Visible = false;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAddNew_click(object sender, EventArgs e)
    {
        try
        {

            txtFirstName.Text = "";
            txtUserName.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            divSearch.Visible = false;
            ViewState["User_Id"] = 0;
            BLLUser objuser = new BLLUser();
            DataTable dtUser = objuser.UserTypeFetchAll();
            objBase.FillDropDown(dtUser, ddlUser_Type, "User_Type_Id", "Type_Description");

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();
            oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlregion, "Region_Id", "Region_Name");
            DALBase oDALBase = new DALBase();
            DataSet dtgender = new DataSet();

            dtgender = oDALBase.get_Gender();
            DataTable dtG = dtgender.Tables[0];
            objBase.FillDropDown(dtG, ddlGender, "Gender_Id", "Gender");
            divUserLogin.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_student_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            DataTable dtuser = new DataTable();
            DataTable dtcenter = new DataTable();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlcenter = e.Row.FindControl("ddlCenterteach") as DropDownList;
                int center_id = int.Parse(e.Row.Cells[3].Text);
                if (ddlcenter != null)
                {
                    //if (ViewState["Center"] != null)
                    //    dtcenter = (DataTable)ViewState["Center"];
                    //else
                    //{
                        BLLCenter objCen = new BLLCenter();
                        objCen.Region_Id = Convert.ToInt32(e.Row.Cells[2].Text);
                        dtcenter = objCen.CenterFetchByRegionID(objCen);
                        //ViewState["Center"] = dtcenter;
                    //}

                    dtcenter.AcceptChanges();
                    foreach (DataRow row in dtcenter.Rows)
                    {
                        if (int.Parse(row.ItemArray[0].ToString()) == center_id)
                        {
                            row.Delete();
                        } 
                    }
                    dtcenter.AcceptChanges(); 

                    objBase.FillDropDown(dtcenter, ddlcenter, "center_Id", "center_name"); 
                }
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
            divSearch.Visible = true;
            BLLSearchUser objUs = new BLLSearchUser();
            objUs.FirstName = text_firstName.Text;
            objUs.EmployeeCode = text_EmployeeCode.Text;
            objUs.User_Name = text_username.Text;
            objUs.Gender_Id = list_gender.SelectedValue;
            objUs.User_Type_Id = list_groupName.SelectedValue;
            objUs.Region_Id = list_region.SelectedValue;
            objUs.Cetnter_Id = list_center.SelectedValue;
            objUs.Mo_Id = Session["moID"].ToString();

            DataTable dt = objUs.SearchUserFetch(objUs);

            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                dg_user.DataSource = dt;
                lab_dataStatus.Visible = false;
            }
            if (Session["UserType_Id"].ToString() == "5")
            {
                dg_user.Columns[17].Visible = true;
                dg_user.Columns[18].Visible = true;

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
    protected void btnSharedLogin_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            BLLUser user = new BLLUser();
            user.ID = Convert.ToInt32(btn.CommandArgument);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            DropDownList ddl = gvr.FindControl("ddlCenterteach") as DropDownList;
            if (ddl.SelectedIndex > 0)
                user.centerID = Convert.ToInt32(ddl.SelectedValue);
            else
            {
                return;
            }
            int k = user.BLUser_SharedLoginAdd(user);
            but_search_Click(this, EventArgs.Empty);
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
