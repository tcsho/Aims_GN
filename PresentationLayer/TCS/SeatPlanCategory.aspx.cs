using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
//using ClosedXML.Excel;
using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;


public partial class PresentationLayer_TCS_SeatPlanCategory : System.Web.UI.Page
{

    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {

        ViewState["ALreadyHide"] = "0";
        ViewState["ALreadyHideStudentAllo"] = "0";

        GeneratedMaskNoBtn_.Click += GeneratedMaskNoBtn__Click;
        GeneratedMaskNoBtn_.OnClientClick = @"return getConfirmationValue();";

//        AssignRoomtoTeacher.Click += AssignRoomtoTeacher_Click;
        AssignRoomtoTeacher.OnClientClick = @"return getAssignRoomtoTeacher();";

  //      AllocateRoomsToStudent.Click += AllocateRoomsToStudent_Click;
        AllocateRoomsToStudent.OnClientClick = @"return AllocateRoomsTostudentFunLbl();";

        //SessionIdLbl.Text = Session["RegionID"].ToString();
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnExport);
        scriptManager.RegisterPostBackControl(this.DownloadUnassignedBtn);
        scriptManager.RegisterPostBackControl(this.DownloadUnlockedClasses);
        DownloadUnassignedBtn.Visible = false;
        DownloadUnlockedClasses.Visible = false;
        
        scriptManager.RegisterPostBackControl(this.ExportMaskNumberListBtn);
        ExportMaskNumberListBtn.Visible = false;

        scriptManager.RegisterPostBackControl(this.AllocatedRoomsStudent);
        AllocatedRoomsStudent.Visible = false;

        scriptManager.RegisterPostBackControl(this.AssignedTeacherRooms);
        AssignedTeacherRooms.Visible = false;

        //LblInProgressRollNoGen.Visible = false;
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }



            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];

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
                    //..Session.Abandon();
                    //..Response.Redirect("~/login.aspx", false);
                }


                //====== End Page Access settings ======================


                loadOrg(sender, e);

               
                FillActiveSessions();
                //..    AdEditCate.Visible = false;
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }

              
                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = true;
                    ddl_region.Enabled = true;
                    ddl_center.Enabled = true;

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
                 //PageInformation();
                loadCenter();
            }
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


    protected void loadCountries()
    {
        try
        {

            BLLMain_Organisation_Country oDALMainOrgCountry = new BLLMain_Organisation_Country();
            oDALMainOrgCountry.Main_Organisation_Id = Convert.ToInt32(ddl_MOrg.SelectedValue.ToString());

            DataTable dt = new DataTable();
            dt = oDALMainOrgCountry.Main_Organisation_CountryFetch(oDALMainOrgCountry);

            objBase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");

            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            ddl_center.Items.Clear();
            ddl_center.Items.Add(new ListItem("Select", "0"));
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
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ddl_country.SelectedValue.ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
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
            //loadCenter();
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
            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            //objCen.Region_Id = Convert.ToInt32(Session["RegionId"]);//ddl_region.SelectedValue.ToString()

            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionIDSeatPlan(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            objBase.FillDropDown(dt, Dll_DeleteBlockCOnfig_Center, "Center_Id", "Center_Name");
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            loadClass();
            loadSeatPlanBlock();
            loadSeatPlanGender();
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTerm.SelectedIndex > 0)
            {
                ViewState["Data"] = null;
                BindGrid();
            }
            else
            {
                //ViewState["Data"] = null;
                gvTest.DataSource = null;
                gvTest.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Convert.ToInt32(ddlClass.SelectedValue)>12)
        //    {
        //        ShowSubject.Visible = true;
        //        ddlSubject.Enabled = true;
        //        loadSubject();
        //    }
        //    else
        //    {
        //        ddlSubject.Enabled = false;
        //        ShowSubject.Visible = false;
        //    }

        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }


    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvTest.Rows.Count > 0)
            {
                gvTest.UseAccessibleHeader = false;
                gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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
                objBase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
            }
            ddl_country.Items.Clear();
            ddl_country.Items.Add(new ListItem("Select", "0"));

            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            ddl_center.Items.Clear();
            ddl_center.Items.Add(new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        switch (btnSave.CommandName)
        {
            case "AddRecord":
                ViewState["Mode"] = "Add";
                break;
            case "EditRecord":
                ViewState["Mode"] = "Edit";
                break;
        }

        btnSave.CommandName = "AddRecord";
        try
        {
            BLLSeatPlanCategory objCat = new BLLSeatPlanCategory();

            int k = 0;

            //if ((ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlClass.SelectedIndex > 0 && ddl_center.SelectedIndex > 0 && Convert.ToInt32(ddlClass.SelectedValue) <= 12)  ||
            //    (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlClass.SelectedIndex > 0 && ddl_center.SelectedIndex > 0 && Convert.ToInt32(ddlClass.SelectedValue) > 12 && ddlSubject.SelectedIndex > 0)
            //    )
            if (
                (
                    ddlSession.SelectedIndex > 0 &&
                    ddlTerm.SelectedIndex > 0 &&
                    ddlClass.SelectedIndex > 0 &&
                    ddl_center.SelectedIndex > 0 &&
                    Convert.ToInt32(ddlClass.SelectedValue) <= 12
                 ) ||
                 (
                    ddlSession.SelectedIndex > 0 &&
                    ddlTerm.SelectedIndex > 0 &&
                    ddlClass.SelectedIndex > 0 &&
                    ddl_center.SelectedIndex > 0 &&
                    Convert.ToInt32(ddlClass.SelectedValue) > 12
                  //..&& ddlSubject.SelectedIndex > 0
                  )
                 )
            {



                objCat.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                objCat.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
                objCat.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
                objCat.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objCat.Block_Id = Convert.ToInt32(ddlBlock.SelectedValue.ToString());
                objCat.Gender_Id = Convert.ToInt32(ddlGender.SelectedValue.ToString());


                if (objCat.Block_Id == 0) { objCat.Block_Id = 1; }
                if (objCat.Gender_Id == 0) { objCat.Gender_Id = 3; }

                //if (objCat.Class_Id > 12)
                //{
                //    objCat.Subject_Id = Convert.ToInt32(ddlSubject.SelectedValue);
                //    objCat.CategoryName = ddl_center.SelectedItem.Text + "-" + ddlSubject.SelectedItem.Text +"-" + (ddlBlock.SelectedItem.Text != "Select" ? ddlBlock.SelectedItem.Text : "Block A") + "-" + ddlClass.SelectedItem.Text + "-" + (ddlGender.SelectedItem.Text != "Select" ? ddlGender.SelectedItem.Text : "Combined");
                //}
                //else
                //{
                objCat.Subject_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objCat.CategoryName = ddl_center.SelectedItem.Text + "-" + (ddlBlock.SelectedItem.Text != "Select" ? ddlBlock.SelectedItem.Text : "Block A") + "-" + ddlClass.SelectedItem.Text + "-" + (ddlGender.SelectedItem.Text != "Select" ? ddlGender.SelectedItem.Text : "Combined");
                //}
                if (ViewState["Mode"].ToString() == "Add")
                {
                    objCat.Categ_Id = 0;
                    objCat.InsertOrUpdate = 1;
                    objCat.ModifiedOn = DateTime.Now;
                    objCat.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    objCat.CreatedOn = DateTime.Now;
                    objCat.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    k = objCat.SeatPlanCategoryAdd(objCat);
                }
                if (ViewState["Mode"].ToString() == "Edit")
                {
                    objCat.InsertOrUpdate = 2;
                    objCat.Categ_Id = Convert.ToInt32(ViewState["Categ_Id"].ToString());
                    objCat.ModifiedOn = DateTime.Now;
                    objCat.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());


                    objCat.CreatedOn = DateTime.Now;
                    objCat.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    k = objCat.SeatPlanCategoryAdd(objCat);

                }
                if (k == 1)
                {
                    ImpromptuHelper.ShowPromptGeneric(" Category Already Exists !", 0);
                }
                else if (k == 201)
                {
                    ImpromptuHelper.ShowPromptGeneric("Data has been locked, no further changes are allowed !", 0);
                }
                else if (k == 3)
                {
                    ImpromptuHelper.ShowPromptGeneric("Error: Category Not Allowed !", 0);
                }
                else if (k == 40)
                {
                    ImpromptuHelper.ShowPromptGeneric("Category Saved!", 01);
                    ViewState["Data"] = null;
                    BindGrid();
                }
                else
                {
                    ImpromptuHelper.ShowPromptGeneric("Error: Category Not Allowed !..." + k, 0);

                }
            }
            else
            {
                ImpromptuHelper.ShowPromptGeneric("Center, Term Name and Class are mendatory fileds!", 0);
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);

            ResetControllsAddMode();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void btnLock_Click(object sender, EventArgs e)
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        int k = 0;
        try
        {
            if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                obj.LockDate = DateTime.Now;
                k = obj.SeatPlanCategoryLock(obj);
            }
            if (k == 1)
            {
                ImpromptuHelper.ShowPromptGeneric("Records Locked Successfully", 1);
            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPromptGeneric("Records have been Already Locked", 1);
            }
            else
            {
                ImpromptuHelper.ShowPromptGeneric("Failed to Lock Records", 0);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        BLLCenter objCen = new BLLCenter();
        DataTable DataTable_Center = new DataTable();
        DataTable_Center = objCen.CentersList(objCen);

        BLLSeatPlanCategory obj_ = new BLLSeatPlanCategory();
        if (ddlSession.SelectedIndex > 0)
            obj_.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        if (ddlTerm.SelectedIndex > 0)
            obj_.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);

        if (ddl_center.SelectedIndex == 0)
        {
            if (DataTable_Center.Rows.Count > 0)
            {
                foreach (DataRow row in DataTable_Center.Rows)
                {
                    obj_.Center_Id = Convert.ToInt32(row["Center_Id"]);
                    obj_.SeatPlanCategorySelectBySessionTermCenter(obj_);
                }
            }
        }
        else
        {
            if (DataTable_Center.Rows.Count > 0)
            {
                foreach (DataRow row in DataTable_Center.Rows)
                {
                    obj_.Center_Id = Convert.ToInt32(row["Center_Id"]);
                    obj_.SeatPlanCategorySelectBySessionTermCenter(obj_);
                }
            }

            //obj_.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            //obj_.SeatPlanCategorySelectBySessionTermCenter(obj_);
        }



        ViewState["Data"] = null;
        BindGrid();
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        try
        {
            //..    AdEditCate.Visible = true;
            ResetControlls();
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);

            ViewState["Mode"] = "Add";
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
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedValue = Session["Session_Id"].ToString();
            ddlSession.Enabled = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void bindTermList()
    {
        //try
        //{
        //    if (list_section.SelectedIndex > 0)
        //    {
        //        DataTable dt = null;
        //        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        //        ObjECT.Section_Id = Convert.ToInt32(list_section.SelectedValue);
        //        dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
        //        objBase.FillDropDown(dt, ddlTerm, "Evaluation_Criteria_Type_Id", "Type");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        try
        {
            ResetControlls();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            //..    AdEditCate.Visible = false;
            ViewState["Mode"] = "Edit";
            btnSave.CommandName = "EditRecord";
            LinkButton btnEdit = (LinkButton)(sender);


            obj.Categ_Id = Convert.ToInt32(btnEdit.CommandArgument);

            ViewState["Categ_Id"] = obj.Categ_Id;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;

            ddl_center.SelectedValue = gvr.Cells[1].Text;
            ddl_center_SelectedIndexChanged(sender, e);

            ddlBlock.SelectedValue = gvr.Cells[3].Text;
            ddlGender.SelectedValue = gvr.Cells[4].Text;
            //ddlClass.SelectedValue = gvr.Cells[4].Text;
            ddlClass.SelectedValue = gvr.Cells[5].Text;
            if (Convert.ToInt32(ddlClass.SelectedValue) > 12)
            {
                loadSubject();
                ddlSubject.SelectedValue = gvr.Cells[5].Text;
                ddlSubject.Enabled = false;
                ShowSubject.Visible = true;
            }
            else
            {
                ddlSubject.Enabled = false;
                ShowSubject.Visible = false;

            }


            ddl_center.Enabled = false;
           // ddlClass.Enabled = false;
            //. AdEditCate.Visible = false;



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        int k = 0;
        try
        {
            LinkButton btnEdit = (LinkButton)(sender);
            obj.Categ_Id = Convert.ToInt32(btnEdit.CommandArgument);

            ViewState["Categ_Id"] = obj.Categ_Id;
            k = obj.SeatPlanCategoryDelete(obj);

            if (k == 1)
            {
                ImpromptuHelper.ShowPromptGeneric("Record Deleted Successfully", 1);
                ViewState["Data"] = null;
                BindGrid();

            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPromptGeneric("Record Can not be Deleted, Data has already been locked", 0);
            }
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
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
            //..    AdEditCate.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void loadSeatPlanBlock()
    {

        try
        {
            BLLSeatPlanBlock objCen = new BLLSeatPlanBlock();

            DataTable dt = new DataTable();
            dt = objCen.SeatPlanBlockFetchAll();
            objBase.FillDropDown(dt, ddlBlock, "Block_Id", "BlockName");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void loadSeatPlanGender()
    {

        try
        {
            BLLSeatPlanGender objCen = new BLLSeatPlanGender();
            DataTable dt = new DataTable();
            dt = objCen.SeatPlanGenderFetchAll();
            objBase.FillDropDown(dt, ddlGender, "Gender_Id", "GenderName");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void loadClass()
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
            dt = objBLLClass.ClassFetchByCenterID(objBLLClass);//ClassSelectByCenterIDSeatPlan
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }



    protected void loadSubject()
    {
        try
        {
            BLLSubject objbllsubject = new BLLSubject();

            DataTable dt = null;
            int c_id;
            if (ddlClass.SelectedIndex > 0)
            {
                objbllsubject.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);
                dt = objbllsubject.SubjectFetchByClassIDSeatPlan_(objbllsubject);
                objBase.FillDropDown(dt, ddlSubject, "SubjectID", "Subject_Name");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void BindGrid()
    {
        ViewState["Data"] = null;
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();

        try
        {
            if (ddlSession.SelectedIndex > 0)
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            if (ddlTerm.SelectedIndex > 0)
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);

            if (ddl_center.SelectedIndex > 0) { ViewState["Data"] = null; obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue); }
            else { obj.Center_Id = 101; }

            obj.RegionID = Session["RegionID"].ToString();
            DataTable dt = new DataTable();
            if (ViewState["Data"] == null)
            {
                dt = obj.SeatPlanCategoryFetchSessionTerm(obj);
                ViewState["Data"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["Data"];
            }

            if (dt.Rows.Count > 0)
            {
                gvTest.DataSource = dt;
                gvTest.DataBind();
            }
            else
            {

                gvTest.DataSource = null;
                gvTest.DataBind();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    public void ResetControlls()
    {
        if (ddl_center.Items.Count > 0)
        {
            ddl_center.SelectedIndex = 0;
            ddl_center.Enabled = true;
        }
        if (ddlBlock.Items.Count > 0)
            ddlBlock.SelectedIndex = 0;

        if (ddlGender.Items.Count > 0)
            ddlGender.SelectedIndex = 0;

        if (ddlClass.Items.Count > 0)
        {
            ddlClass.SelectedIndex = 0;
            ddlClass.Enabled = true;
        }
        if (ddlSubject.Items.Count > 0)
        {
            ddlSubject.SelectedIndex = 0;
            ddlSubject.Enabled = true;
        }
    }

    public void ResetControllsAddMode()
    {//..   
        ddl_center.Enabled = true;

        if (ddlBlock.Items.Count > 0)
            ddlBlock.SelectedIndex = 0;

        if (ddlGender.Items.Count > 0)
            ddlGender.SelectedIndex = 0;

        if (ddlClass.Items.Count > 0)
        {
            //..    ddlClass.SelectedIndex = 0;
            ddlClass.Enabled = true;
        }
        if (ddlSubject.Items.Count > 0)
        {
            ddlSubject.SelectedIndex = 0;
            ddlSubject.Enabled = true;
        }
    }


    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable("GridView_Data");
    //    foreach (TableCell cell in gvTest.HeaderRow.Cells)
    //    {
    //        dt.Columns.Add(cell.Text);
    //    }
    //    foreach (GridViewRow row in gvTest.Rows)
    //    {
    //        dt.Rows.Add();
    //        for (int i = 0; i < row.Cells.Count; i++)
    //        {
    //            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
    //        }
    //    }
    //    using (XLWorkbook wb = new XLWorkbook())
    //    {
    //        wb.Worksheets.Add(dt);

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //        Response.AddHeader("content-disposition", "attachment;filename=GridView.xlsx");
    //        using (MemoryStream MyMemoryStream = new MemoryStream())
    //        {
    //            wb.SaveAs(MyMemoryStream);
    //            MyMemoryStream.WriteTo(Response.OutputStream);
    //            Response.Flush();
    //            Response.End();
    //        }
    //    }
    //    //Response.Clear();
    //    //Response.Buffer = true;
    //    //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
    //    //Response.Charset = "";
    //    //Response.ContentType = "application/vnd.ms-excel";
    //    //using (StringWriter sw = new StringWriter())
    //    //{
    //    //    HtmlTextWriter hw = new HtmlTextWriter(sw);

    //    //    //To Export all pages
    //    //    gvTest.AllowPaging = false;
    //    //    this.BindGrid();

    //    //    gvTest.HeaderRow.BackColor = Color.White;
    //    //    foreach (TableCell cell in gvTest.HeaderRow.Cells)
    //    //    {
    //    //        cell.BackColor = gvTest.HeaderStyle.BackColor;
    //    //    }
    //    //    foreach (GridViewRow row in gvTest.Rows)
    //    //    {
    //    //        row.BackColor = Color.White;
    //    //        foreach (TableCell cell in row.Cells)
    //    //        {
    //    //            if (row.RowIndex % 2 == 0)
    //    //            {
    //    //                cell.BackColor = gvTest.AlternatingRowStyle.BackColor;
    //    //            }
    //    //            else
    //    //            {
    //    //                cell.BackColor = gvTest.RowStyle.BackColor;
    //    //            }
    //    //            cell.CssClass = "textmode";
    //    //        }
    //    //    }

    //    //    gvTest.RenderControl(hw);

    //    //    //style to format numbers to string
    //    //    string style = @"<style> .textmode { } </style>";
    //    //    Response.Write(style);
    //    //    Response.Output.Write(sw.ToString());
    //    //    Response.Flush();
    //    //    Response.End();
    //    //}
    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}


    protected bool DecideDeleteShow(int isLock)
    {
        if (Convert.ToInt32(isLock) > 0)
            return false;
        else
            return true;
    }
    protected bool DecideLockShow(int isLock)
    {
        if (Convert.ToInt32(isLock) == 1)
            return true;
        else
            return false;
    }



    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvTest.AllowPaging = false;
        //Change the Header Row back to white color
        gvTest.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        //gvTest.HeaderRow.Cells[0].Style.Add("background-color", "green");
        //gvTest.HeaderRow.Cells[1].Style.Add("background-color", "green");
        //gvTest.HeaderRow.Cells[2].Style.Add("background-color", "green");
        gvTest.HeaderRow.Cells[0].Visible = false;
        gvTest.HeaderRow.Cells[1].Visible = false;
        gvTest.HeaderRow.Cells[2].Visible = false;
        gvTest.HeaderRow.Cells[3].Visible = false;
        gvTest.HeaderRow.Cells[4].Visible = false;
        gvTest.HeaderRow.Cells[5].Visible = false;
        gvTest.HeaderRow.Cells[6].Visible = false;
        gvTest.HeaderRow.Cells[13].Visible = false;
        gvTest.HeaderRow.Cells[14].Visible = false;
        for (int i = 0; i < gvTest.Rows.Count; i++)
        {
            GridViewRow row = gvTest.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
            row.Cells[0].Visible = false;
            row.Cells[1].Visible = false;
            row.Cells[2].Visible = false;
            row.Cells[3].Visible = false;
            row.Cells[4].Visible = false;
            row.Cells[5].Visible = false;
            row.Cells[6].Visible = false;
            row.Cells[13].Visible = false;
            row.Cells[14].Visible = false;
            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                //row.Cells[0].Style.Add("background-color", "#C2D69B");
                //row.Cells[1].Style.Add("background-color", "#C2D69B");
                //row.Cells[2].Style.Add("background-color", "#C2D69B");
            }
        }
        gvTest.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    //protected void AllocateRoomsToStudent_Click(object sender, EventArgs e)
    //{
    //    BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
    //    try
    //    {
    //        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //        obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
    //        obj.Center_Id = 2010201;


    //        obj.LockRoomAllocation(obj);

    //        BLLCenter objCen = new BLLCenter();
    //        DataTable DataTable_Center = new DataTable();
    //        DataTable_Center = objCen.CentersList(objCen);

    //        if (DataTable_Center.Rows.Count > 0)
    //        {
    //            foreach (DataRow row__ in DataTable_Center.Rows)
    //            {
    //                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
    //                //..    obj.Center_Id = 2010201;
    //                obj.Center_Id = Convert.ToInt32(row__["Center_Id"]);

    //                DataTable DataTable_ = new DataTable();
    //                //..    DataTable_ = obj.SeatPlanCategorySelectBlockBySchool(obj);
    //                DataTable_ = obj.SeatPlanCategorySelectAssignRooms(obj);
    //                ViewState["Data"] = DataTable_;

    //                int LastCenter = 0;
    //                int LastGender = 0;
    //                int LastClass = 0;

    //                if (DataTable_.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in DataTable_.Rows)
    //                    {
    //                        int Center_Id = Convert.ToInt32(row["Center_Id"]);
    //                        int Session_Id = Convert.ToInt32(row["Session_Id"]);
    //                        int TermGroup_Id = Convert.ToInt32(row["TermGroup_Id"]);
    //                        int Class_Id = Convert.ToInt32(row["Class_Id"]);
    //                        int Room_Id = Convert.ToInt32(row["Room_Id"]);
    //                        int Students = Convert.ToInt32(row["Students"]);
    //                        int Gender_Id = Convert.ToInt32(row["Gender_Id"]);
    //                        int Block_Id = Convert.ToInt32(row["Block_Id"]);



    //                        /********************************/
    //                        BLLSeatPlanRoomAllocateToStudent ObjSelect = new BLLSeatPlanRoomAllocateToStudent();
    //                        try
    //                        {
    //                            ObjSelect.Center_Id = Center_Id;
    //                            ObjSelect.Session_Id = Session_Id;
    //                            ObjSelect.TermGroup_Id = TermGroup_Id;
    //                            ObjSelect.Class_Id = Class_Id;
    //                            ObjSelect.Room_Id = Room_Id;
    //                            ObjSelect.Students = Students;
    //                            ObjSelect.Gender_Id = Gender_Id;
    //                            ObjSelect.Block_Id = Block_Id;
    //                            int ReturnResult = 0;
    //                            ReturnResult = ObjSelect.SeatPlanAssignRoomsToStudents(ObjSelect);
    //                            //if (ObjSelect.SeatPlanAssignRoomsToStudents(ObjSelect))
    //                            //{

    //                            //}
    //                            //else 
    //                            //{
    //                            //}
    //                            //ImpromptuHelper.ShowPrompt("Rooms Allocated To The Students Of Class ::>> " + Class_Id);

    //                        }
    //                        catch (Exception ex)
    //                        {
    //                            Session["error"] = ex.Message;
    //                            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //                        }
    //                        /********************************/
    //                    }
    //                }
    //                else
    //                {
    //                    ImpromptuHelper.ShowPromptGeneric("Error: Rooms Not Assigned To All Students!", 0);
    //                    ////gvTest.DataSource = null;
    //                    ////gvTest.DataBind();
    //                }
    //                ImpromptuHelper.ShowPrompt("Rooms Allocated Students .. ");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }


    //    BLLSeatPlanCategory FindCenterobjCen = new BLLSeatPlanCategory();
    //    FindCenterobjCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //    FindCenterobjCen.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
    //    DataTable DataTable_FindCenter = new DataTable();
    //    DataTable_FindCenter = FindCenterobjCen.ExamUnAssignedRoomCentersList(FindCenterobjCen);
    //    if (DataTable_FindCenter.Rows.Count > 0)
    //    {
    //        ImpromptuHelper.ShowPromptGeneric("Error: Rooms Not Assigned To All Students!", 0);
    //    }


    //}

    protected void AllocateRoomsToStudent_Click(object sender, EventArgs e)
    {
        int ShowPopup = 0;
        int ShowError = 0;
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {

            BLLSeatPlanCategory objj = new BLLSeatPlanCategory();
            objj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            /************Check Block DIstribution ********************/
            DataTable DataTable_BlockDIstribution = new DataTable();
            DataTable_BlockDIstribution = objj.CheckBlockDistribution(objj);
            if (DataTable_BlockDIstribution.Rows.Count < 1)
            {
                ImpromptuHelper.ShowPromptGeneric("Block Distribution Not Locked!", 0);
            }
            else
            {


                /***********Allocate Rooms To student ALready Status Check Start*****************/

                DataTable DataTable_CheckBlocAllocateRoomsToStudent = new DataTable();
                DataTable_CheckBlocAllocateRoomsToStudent = objj.CheckBlocAllocateRoomsToStudent(objj);
                if (DataTable_CheckBlocAllocateRoomsToStudent.Rows.Count > 0)
                {
                    //if (ViewState["ALreadyHideStudentAllo"] == "1")
                    //{
                    //    ViewState["ALreadyHideStudentAllo"] = "0";
                    //}
                    //else
                    //{
                        ImpromptuHelper.ShowPromptGeneric("Rooms Allocation Already Processed..!", 0);
                    //}
                    
                }
                else
                {
                    ViewState["ALreadyHideStudentAllo"] = "1";
                    BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
                    try
                    {
                        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                        obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                        //obj.Center_Id = 2010201;

                        DataTable DataTable_AssignRoomToTeacherCheckRoomsStatus_ = new DataTable();
                        DataTable_AssignRoomToTeacherCheckRoomsStatus_ = obj.AssignRoomToTeacherCheckRoomsStatus(obj);
                        if (DataTable_AssignRoomToTeacherCheckRoomsStatus_.Rows.Count > 0)
                        {
                            ImpromptuHelper.ShowPromptGeneric("Rooms Allocation Not Completed Yet..!", 0);
                        }
                        else
                        {
                            BLLCenter objCen = new BLLCenter();
                            DataTable DataTable_Center = new DataTable();
                            DataTable_Center = objCen.CentersList(objCen);

                            if (DataTable_Center.Rows.Count > 0)
                            {
                                foreach (DataRow row__ in DataTable_Center.Rows)
                                {
                                    obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                                    obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                                    //obj.Center_Id = 2010201;
                                    obj.Center_Id = Convert.ToInt32(row__["Center_Id"]);

                                    DataTable DataTable_ = new DataTable();
                                    //..    DataTable_ = obj.SeatPlanCategorySelectBlockBySchool(obj);
                                    DataTable_ = obj.SeatPlanCategorySelectAssignRooms(obj);
                                    ViewState["Data"] = DataTable_;

                                    int LastCenter = 0;
                                    int LastGender = 0;
                                    int LastClass = 0;

                                    if (DataTable_.Rows.Count > 0)
                                    {
                                        obj.LockRoomAllocation(obj);

                                        foreach (DataRow row in DataTable_.Rows)
                                        {
                                            ShowPopup++;
                                            int Center_Id = Convert.ToInt32(row["Center_Id"]);
                                            int Session_Id = Convert.ToInt32(row["Session_Id"]);
                                            int TermGroup_Id = Convert.ToInt32(row["TermGroup_Id"]);
                                            int Class_Id = Convert.ToInt32(row["Class_Id"]);
                                            int Room_Id = Convert.ToInt32(row["Room_Id"]);
                                            int Students = Convert.ToInt32(row["Students"]);
                                            int Gender_Id = Convert.ToInt32(row["Gender_Id"]);
                                            int Block_Id = Convert.ToInt32(row["Block_Id"]);



                                            /********************************/
                                            BLLSeatPlanRoomAllocateToStudent ObjSelect = new BLLSeatPlanRoomAllocateToStudent();
                                            try
                                            {
                                                ObjSelect.Center_Id = Center_Id;
                                                ObjSelect.Session_Id = Session_Id;
                                                ObjSelect.TermGroup_Id = TermGroup_Id;
                                                ObjSelect.Class_Id = Class_Id;
                                                ObjSelect.Room_Id = Room_Id;
                                                ObjSelect.Students = Students;
                                                ObjSelect.Gender_Id = Gender_Id;
                                                ObjSelect.Block_Id = Block_Id;
                                                int ReturnResult = 0;
                                                ReturnResult = ObjSelect.SeatPlanAssignRoomsToStudents(ObjSelect);
                                            }
                                            catch (Exception ex)
                                            {
                                                Session["error"] = ex.Message;
                                                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                            }
                                            /********************************/
                                        }
                                    }
                                    //else
                                    //{
                                    //    ShowError++;
                                    //    ImpromptuHelper.ShowPromptGeneric("Error: No Rooms Found For Process", 0);
                                    //}
                                }

                                //GeneratedMaskNoBtn_.Enabled = false;
                                if (ShowPopup > 0)
                                {
                                    lblModalTitle.Text = "Allocate Rooms To student";
                                    lblModalBody.Text = "Process Completed";
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                    upModal.Update();
                                }

                            }
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        Session["error"] = ex.Message;
                        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                    }
                }
                /***********Allocate Rooms To student ALready Status Check End  *****************/



                //BLLSeatPlanCategory FindCenterobjCen = new BLLSeatPlanCategory();
                //FindCenterobjCen.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                //FindCenterobjCen.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                //DataTable DataTable_FindCenter = new DataTable();
                //DataTable_FindCenter = FindCenterobjCen.ExamUnAssignedRoomCentersList(FindCenterobjCen);
                //if (DataTable_FindCenter.Rows.Count > 0)
                //{
                //    ImpromptuHelper.ShowPromptGeneric("Error: Rooms Not Assigned To All Students!", 0);
                //}
            }

        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }



        }

    protected void DisableButtons() 
    {
        GeneratedMaskNoBtn_.Enabled = false;
        AllocateRoomsToStudent.Enabled = false;
        AssignRoomtoTeacher.Enabled = false;
    }

    protected void EnablesButtons()
    {
        GeneratedMaskNoBtn_.Enabled = true;
        AllocateRoomsToStudent.Enabled = true;
        AssignRoomtoTeacher.Enabled = true;
    }
    protected void GeneratedMaskNoBtn__Click(object sender, EventArgs e)
    {
        DisableButtons();
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#myModal').modal('hide');", true);

            BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            /************Check Block DIstribution ********************/
            DataTable DataTable_BlockDIstribution = new DataTable();
            DataTable_BlockDIstribution = obj.CheckBlockDistribution(obj);
            if (DataTable_BlockDIstribution.Rows.Count < 1)
            {
                ImpromptuHelper.ShowPromptGeneric("Block Distribution Not Locked!", 0);
            }
            else
            {
                /************Check Already Run oR NOt ********************/
                DataTable DataTable_CheckProcess = new DataTable();
                DataTable_CheckProcess = obj.CheckRollNumberGeneratedOrNot(obj);
                if (DataTable_CheckProcess.Rows.Count > 0)
                {
                    ImpromptuHelper.ShowPromptGeneric("Students Masks Already Generated!", 0);
                }
                else
                {
                    //LblInProgressRollNoGen.Visible = true;
                    GeneratedMaskNoBtn_.Enabled = false;
                    lblModalTitle.Text = "Roll Numbers-Maks Generation";
                    lblModalBody.Text = "Process Completed";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                    //..    obj.Center_Id = 2010201;
                    BLLCenter objCen = new BLLCenter();
                    DataTable DataTable_Center = new DataTable();
                    DataTable_Center = objCen.CentersList(objCen);

                    foreach (DataRow row_ in DataTable_Center.Rows)
                    {
                        obj.Center_Id = Convert.ToInt32(row_["Center_Id"]);

                        try
                        {
                            DataTable DataTable_ = new DataTable();
                            DataTable_ = obj.SeatPlanCategorySelectBlockBySchool(obj);
                            ViewState["Data"] = DataTable_;

                            int LastCenter = 0;
                            int LastGender = 0;
                            int LastClass = 0;

                            if (DataTable_.Rows.Count > 0)
                            {
                                foreach (DataRow row in DataTable_.Rows)
                                {
                                    int Center_Id = Convert.ToInt32(row["Center_Id"]);
                                    int Class_Id = Convert.ToInt32(row["Class_Id"]);
                                    int Gender_Id = Convert.ToInt32(row["Gender_Id"]);

                                    /********************************/
                                    BLLSeatPlanCategory SelectStudentObj = new BLLSeatPlanCategory();

                                    try
                                    {
                                        SelectStudentObj.Center_Id = Center_Id;
                                        SelectStudentObj.Class_Id = Class_Id;
                                        SelectStudentObj.Gender_Id = Gender_Id;
                                        SelectStudentObj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                                        SelectStudentObj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);



                                        DataTable DataTable__Student = new DataTable();
                                        DataTable__Student = SelectStudentObj.SeatPlanCategorySelectStudents(SelectStudentObj);
                                        ViewState["Data"] = DataTable__Student;

                                        string FOrmatedClassID = "";
                                        if (Class_Id == 7) { FOrmatedClassID = "3"; }
                                        if (Class_Id == 8) { FOrmatedClassID = "4"; }
                                        if (Class_Id == 9) { FOrmatedClassID = "5"; }
                                        if (Class_Id == 10) { FOrmatedClassID = "6"; }
                                        if (Class_Id == 11) { FOrmatedClassID = "7"; }
                                        if (Class_Id == 12) { FOrmatedClassID = "8"; }
                                        if (Class_Id == 13) { FOrmatedClassID = "01"; }
                                        if (Class_Id == 14) { FOrmatedClassID = "02"; }
                                        if (Class_Id == 15) { FOrmatedClassID = "03"; }
                                        if (Class_Id == 16) { FOrmatedClassID = "12"; }
                                        if (Class_Id == 19) { FOrmatedClassID = "A1"; }
                                        if (Class_Id == 20) { FOrmatedClassID = "A2"; }
                                        //..    string StartMaskSign = "";


                                        if (DataTable__Student.Rows.Count > 0)
                                        {
                                            foreach (DataRow RowStudent in DataTable__Student.Rows)
                                            {
                                                int _index = DataTable__Student.Rows.IndexOf(RowStudent);
                                                _index++;
                                                try
                                                {

                                                    BLLSeatPlanStudentRollNo ROllNoObj = new BLLSeatPlanStudentRollNo();
                                                    BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();
                                                    int ReturnResult = 0;
                                                    int k = 0;


                                                    ROllNoObj.Center_Id = Center_Id;
                                                    ROllNoObj.Class_Id = Class_Id;
                                                    ROllNoObj.SessionId = Convert.ToInt32(ddlSession.SelectedValue);
                                                    ROllNoObj.TermId = Convert.ToInt32(ddlTerm.SelectedValue);
                                                    ROllNoObj.StudentERPNo = Convert.ToInt32(RowStudent["Student_No"]);
                                                    ROllNoObj.StudentMaskNo = _index.ToString("" + FOrmatedClassID + "000");
                                                    ReturnResult = ROllNoObj.SeatPlanStudentRollNo_Insert(ROllNoObj);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Session["error"] = ex.Message;
                                                    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                                }
                                            }
                                        }
                                        else
                                        {

                                            ////gvTest.DataSource = null;
                                            ////gvTest.DataBind();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Session["error"] = ex.Message;
                                        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                    }
                                    /********************************/



                                    LastCenter = Center_Id;
                                    LastGender = Gender_Id;
                                    LastClass = Class_Id;
                                }
                            }
                            else
                            {

                                ////gvTest.DataSource = null;
                                ////gvTest.DataBind();
                            }
                            ImpromptuHelper.ShowPrompt("Roll Number Asigned To Students .. ");
                            //ShowGeneratedRollNumbersWithMask();
                        }
                        catch (Exception ex)
                        {
                            Session["error"] = ex.Message;
                            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                        }
                    }
                }
                /************Check Already Run oR NOt ********************/
                /********************************/
            }

        }
        else 
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
        //LblInProgressRollNoGen.Visible = false;
        //GeneratedMaskNoBtn_.Enabled = false;
        EnablesButtons();
    }

    protected void AssignRoomtoTeacher_Click(object sender, EventArgs e)
    {

        int ShowAssignRoomToTeacherPopup = 0;
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            /************Check Block DIstribution ********************/
            DataTable DataTable_BlockDIstribution = new DataTable();
            DataTable_BlockDIstribution = obj.CheckBlockDistribution(obj);
            if (DataTable_BlockDIstribution.Rows.Count < 1)
            {
                ImpromptuHelper.ShowPromptGeneric("Block Distribution Not Locked!", 0);
            }
            else
            {
                int Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                int TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                DataTable DataTable_CheckTeacherAlocation = new DataTable();
                DataTable_CheckTeacherAlocation = obj.CheckTeacherAlocationAlredyProcessOrNot(obj);
                if (DataTable_CheckTeacherAlocation.Rows.Count > 0)
                {
                    //if (ViewState["ALreadyHide"] == "1")
                    //{
                    //    ViewState["ALreadyHide"] = "0";
                    //}
                    //else 
                    //{
                        ImpromptuHelper.ShowPromptGeneric("Rooms Already Assigned To Teachers!", 0);
                    //}
                }
                else
                {
                    ViewState["ALreadyHide"] = "1";
                    DataTable DataTable_AssignRoomToTeacherCheckRoomsStatus = new DataTable();
                    DataTable_AssignRoomToTeacherCheckRoomsStatus = obj.AssignRoomToTeacherCheckRoomsStatus(obj);
                    if (DataTable_AssignRoomToTeacherCheckRoomsStatus.Rows.Count > 0 )
                    {
                        ImpromptuHelper.ShowPromptGeneric("Rooms Allocation Not Completed Yet..!", 0);
                    }
                    else
                    {
                        BLLSeatPlanTeacherExamAllocation ActiveSchoolsObjective = new BLLSeatPlanTeacherExamAllocation();
                        try
                        {
                            DataTable DataTable_ActiveSchools = new DataTable();
                            DataTable_ActiveSchools = ActiveSchoolsObjective.TeacherExamAllocationActiveSchools(ActiveSchoolsObjective);
                            ViewState["DataActiveSchools"] = DataTable_ActiveSchools;
                            if (DataTable_ActiveSchools.Rows.Count > 0)
                            {
                                foreach (DataRow row in DataTable_ActiveSchools.Rows)
                                {
                                    int Center_Id = Convert.ToInt32(row["Center_Id"]);

                                    /************* StudentsCountBaseOnSubject *******************/
                                    BLLSeatPlanTeacherExamAllocation StudentsCountBaseOnSubjectObject = new BLLSeatPlanTeacherExamAllocation();
                                    try
                                    {
                                        StudentsCountBaseOnSubjectObject.Session_Id = Session_Id;
                                        StudentsCountBaseOnSubjectObject.Center_Id = Center_Id;
                                        //StudentsCountBaseOnSubjectObject.TeacherId = EmployeeCode;

                                        DataTable DataTable_StudentsCountBaseOnSubject = new DataTable();
                                        DataTable_StudentsCountBaseOnSubject = StudentsCountBaseOnSubjectObject.StudentsCountBaseOnSubject(StudentsCountBaseOnSubjectObject);
                                        ViewState["DataStudentsCountBaseOnSubject"] = DataTable_StudentsCountBaseOnSubject;
                                        /************* StudentInRooms *******************/
                                        if (DataTable_StudentsCountBaseOnSubject.Rows.Count > 0)
                                        {
                                            foreach (DataRow RowStudentInRooms in DataTable_StudentsCountBaseOnSubject.Rows)
                                            {
                                                int TeacherStudentsStrength = Convert.ToInt32(RowStudentInRooms["Students"]);
                                                int Employee_Id = Convert.ToInt32(RowStudentInRooms["Employee_Id"]);
                                                int Class_Id = Convert.ToInt32(RowStudentInRooms["Class_Id"]);
                                                int Subject_Id = Convert.ToInt32(RowStudentInRooms["Subject_Id"]);
                                                int Gender_Id = Convert.ToInt32(RowStudentInRooms["Gender_Id"]);
                                                int Block_Id = Convert.ToInt32(RowStudentInRooms["CategoryGender"]);
                                                /************* StudentsCountBaseOnSubject *******************/
                                                if (TeacherStudentsStrength >= 5)
                                                {
                                                    BLLSeatPlanTeacherExamAllocation GetRoomsObject = new BLLSeatPlanTeacherExamAllocation();
                                                    try
                                                    {
                                                        GetRoomsObject.Session_Id = Session_Id;
                                                        GetRoomsObject.Center_Id = Center_Id;
                                                        GetRoomsObject.TermId = TermGroup_Id;
                                                        GetRoomsObject.Class_Id = Class_Id;
                                                        GetRoomsObject.SubjectId = Subject_Id;
                                                        GetRoomsObject.Gender_Id = Gender_Id;
                                                        GetRoomsObject.Block_Id = Block_Id;

                                                        DataTable DataTable_GetRooms = new DataTable();
                                                        DataTable_GetRooms = GetRoomsObject.GetRooms(GetRoomsObject);
                                                        ViewState["DataTable_GetRooms"] = DataTable_GetRooms;

                                                        if (DataTable_GetRooms.Rows.Count > 0)
                                                        {
                                                            int[] numberList = { };
                                                            List<int> lst = new List<int>();

                                                            foreach (DataRow RowGetRooms in DataTable_GetRooms.Rows)
                                                            {
                                                                //numberList[DataTable_GetRooms.Rows.IndexOf(RowGetRooms)] = (int)RowGetRooms.ItemArray[0];
                                                                lst.Add((int)RowGetRooms.ItemArray[10]);
                                                            }
                                                            numberList = lst.ToArray();

                                                            //..if (Block_Id != 3) { Array.Sort(numberList); }
                                                            //Dictionary<int, int> roomasign = printClosest(numberList, numberList.Length, TeacherStudentsStrength);

                                                            Dictionary<int, int> dict = new Dictionary<int, int>();
                                                            dict = FindAvailableRooms(numberList, TeacherStudentsStrength);
                                                            ShowAssignRoomToTeacherPopup++;
                                                            BLLSeatPlanTeacherExamAllocation AssignRoomInsertObject = new BLLSeatPlanTeacherExamAllocation();

                                                            AssignRoomInsertObject.Center_Id = Center_Id;
                                                            AssignRoomInsertObject.Session_Id = Session_Id;
                                                            AssignRoomInsertObject.TermId = TermGroup_Id;
                                                            AssignRoomInsertObject.Class_Id = Class_Id;
                                                            AssignRoomInsertObject.TeacherId = Employee_Id;
                                                            AssignRoomInsertObject.SubjectId = Subject_Id;

                                                            foreach (var item in dict)
                                                            {
                                                                DataRow RowGetRooms_ = DataTable_GetRooms.Rows[item.Key];
                                                                try
                                                                {
                                                                    AssignRoomInsertObject.RoomAllot_Id = Convert.ToUInt16(RowGetRooms_[5]);
                                                                    int ReturnResult = 0;
                                                                    ReturnResult = AssignRoomInsertObject.TeacherExamAllocationAssignedRoomToTeacherDetail(AssignRoomInsertObject);
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    Session["error"] = ex.Message;
                                                                    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                                                }
                                                            }
                                                            int ReturnResultMaster = 0;
                                                            ReturnResultMaster = AssignRoomInsertObject.TeacherExamAllocationAssignedRoomToTeacherDetailMaster(AssignRoomInsertObject);
                                                            AssignRoomInsertObject.AllocationMasterId = ReturnResultMaster;
                                                            int UpdateResult = 0;
                                                            UpdateResult = AssignRoomInsertObject.TeacherExamAllocationAssignedRoomToTeacherDetailUpdate(AssignRoomInsertObject);
                                                            ImpromptuHelper.ShowPrompt("Rooms Assigned To Teachers");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Session["error"] = ex.Message;
                                                        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                                    }
                                                }
                                                /********************************/
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Session["error"] = ex.Message;
                                        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                    }

                                    /************* Setp 2. ActiveTeachers *******************/
                                    //BLLSeatPlanTeacherExamAllocation ActiveTeachersObjective = new BLLSeatPlanTeacherExamAllocation();
                                    //try
                                    //{
                                    //    ActiveTeachersObjective.Center_Id = Center_Id;
                                    //    DataTable DataTable_ActiveTeachers = new DataTable();
                                    //    DataTable_ActiveTeachers = ActiveTeachersObjective.TeacherExamAllocationActiveTeachers(ActiveTeachersObjective);
                                    //    ViewState["DataActiveTeachers"] = DataTable_ActiveTeachers;
                                    //    if (DataTable_ActiveTeachers.Rows.Count > 0)
                                    //    {
                                    //        foreach (DataRow RowActiveSchools in DataTable_ActiveTeachers.Rows)
                                    //        {
                                    //            //Teacher list add hogi us mai teacher jaega
                                    //            int EmployeeCode = Convert.ToInt32(RowActiveSchools["EmployeeCode"]);


                                    //            /********************************/
                                    //        }
                                    //    }
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Session["error"] = ex.Message;
                                    //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                                    //}
                                    /********************************/
                                }
                            }
                            //..    ImpromptuHelper.ShowPrompt("Rooms Allocated Students .. ");
                        }
                        catch (Exception ex)
                        {
                            Session["error"] = ex.Message;
                            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                        }
                    }
                    

                    
                }

                    /************* Setp 1. ActiveSchools *******************/
                
            }
        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
        //..    ShowAndHideGridView(ShowAssignedTeacherRooms1);

        if (ShowAssignRoomToTeacherPopup > 0)
        {
            lblModalTitle.Text = "Allocate Rooms To Teachers";
            lblModalBody.Text = "Process Completed";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

    }

    private static Dictionary<int, int> FindAvailableRooms(int[] arr, int sum)
    {
        int[] sub = new int[arr.Length];
        int temp = 0;
        int greatersum = sum + 5;
        int lesssum = sum - 5;

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i, col = 0; j < arr.Length; j++, col++)
            {
                temp += arr[j];
                sub[j] = arr[j];

                if (temp == sum)
                {
                    for (int k = 0; k < sub.Length; k++)
                    {
                        if (sub[k] > 0)
                        {
                            dict.Add(k, sub[k]);
                        }
                    }
                    return dict;
                }
                else if ((temp >= lesssum && temp <= greatersum) || j + 1 == arr.Length)
                {
                    for (int k = 0; k < sub.Length; k++)
                    {
                        if (sub[k] > 0)
                        {
                            dict.Add(k, sub[k]);
                        }
                    }
                    return dict;
                }

                if (temp > sum)
                {
                    Array.Clear(sub, 0, sub.Length);
                    temp = 0;
                    break;
                }

            }
        }

        return dict;
    }

    protected void ShowUnassignedBtn_Click(object sender, EventArgs e)
    {

        HideGrids();
        GridViewShowShowUnassignedStudents.Visible = true;

        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();

        try
        {
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            DataTable UnAssigned_DataTable = new DataTable();
            UnAssigned_DataTable = obj.UnAssignedStudentList(obj);
            if (UnAssigned_DataTable.Rows.Count > 0)
            {
                GridViewShowShowUnassignedStudents.DataSource = UnAssigned_DataTable;
                GridViewShowShowUnassignedStudents.DataBind();
                GridViewShowShowUnassignedStudents.Visible = true;
                DownloadUnassignedBtn.Visible = true;

            }
            else
            {
                GridViewShowShowUnassignedStudents.DataSource = null;
                GridViewShowShowUnassignedStudents.DataBind();
                ImpromptuHelper.ShowPromptGeneric(" No Un Assigned Students..!", 1);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void GridViewShowShowUnassignedStudents_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridViewShowShowUnassignedStudents.Rows.Count > 0)
            {
                GridViewShowShowUnassignedStudents.UseAccessibleHeader = false;
                GridViewShowShowUnassignedStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void DownloadUnassignedBtn_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=SchoolBlockDistribution.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewShowShowUnassignedStudents.AllowPaging = false;
        //Change the Header Row back to white color
        GridViewShowShowUnassignedStudents.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        for (int i = 0; i < GridViewShowShowUnassignedStudents.Rows.Count; i++)
        {
            GridViewRow row = GridViewShowShowUnassignedStudents.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
        }
        GridViewShowShowUnassignedStudents.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void ShowUnlockedClasses_Click(object sender, EventArgs e)
    {
        HideGrids();
        GridViewShowUnlockedClasses.Visible = true;
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
            try
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                DataTable UnAssigned_DataTable = new DataTable();
                UnAssigned_DataTable = obj.ShowUnlockedClasses(obj);
                if (UnAssigned_DataTable.Rows.Count > 0)
                {
                    GridViewShowUnlockedClasses.DataSource = UnAssigned_DataTable;
                    GridViewShowUnlockedClasses.DataBind();
                    GridViewShowUnlockedClasses.Visible = true;
                    DownloadUnlockedClasses.Visible = true;

                }
                else
                {
                    GridViewShowUnlockedClasses.DataSource = null;
                    GridViewShowUnlockedClasses.DataBind();
                    ImpromptuHelper.ShowPromptGeneric(" No Un Locked Rooms ...!", 1);
                }

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
        else 
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
        
    }

    protected void DownloadUnlockedClasses_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=SchoolBlockDistribution.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewShowUnlockedClasses.AllowPaging = false;
        //Change the Header Row back to white color
        GridViewShowUnlockedClasses.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        for (int i = 0; i < GridViewShowUnlockedClasses.Rows.Count; i++)
        {
            GridViewRow row = GridViewShowUnlockedClasses.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
        }
        GridViewShowUnlockedClasses.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void GridViewShowUnlockedClasses_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridViewShowUnlockedClasses.Rows.Count > 0)
            {
                GridViewShowUnlockedClasses.UseAccessibleHeader = false;
                GridViewShowUnlockedClasses.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void BtnDll_DeleteBlockCOnfig_Click(object sender, EventArgs e)
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        obj.TermGroup_Id = Convert.ToInt32(Dll_DeleteBlockCOnfig_Term.SelectedValue);
        obj.Center_Id = Convert.ToInt32(Dll_DeleteBlockCOnfig_Center.SelectedValue);

        int k = obj.DeleteBlockConfiguration(obj);

        if (k == 1)
        {
            ImpromptuHelper.ShowPromptGeneric("Record Deleted Successfully", 1);
            ViewState["Data"] = null;
            BindGrid();

        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Record Not Deleted", 0);
        }
    }

    protected void HideGrids()
    {
        this.GridViewShowShowUnassignedStudents.DataSource = null;
        this.GridViewShowShowUnassignedStudents.Visible = false;

        this.GridViewShowUnlockedClasses.DataSource = null;
        this.GridViewShowUnlockedClasses.Visible = false;

        this.GridViewStudentMaskList.DataSource = null;
        this.GridViewStudentMaskList.Visible = false;

        this.GridViewShowAllocatedStudentsRooms.DataSource = null;
        this.GridViewShowAllocatedStudentsRooms.Visible = false;

        this.ShowAssignedTeacherRooms1.DataSource = null;
        this.ShowAssignedTeacherRooms1.Visible = false;



        
    }

    protected void ShowMaskNumberListBtn_Click(object sender, EventArgs e)
    {
        HideGrids();
        GridViewStudentMaskList.Visible = true;
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            /************Check Block DIstribution ********************/
            DataTable DataTable_ShowMaskNumberList = new DataTable();
            DataTable_ShowMaskNumberList = obj.SeatPlanCategorySelectBySessionTermCenterStudent(obj);
            if (DataTable_ShowMaskNumberList.Rows.Count > 0)
            {
                GridViewStudentMaskList.DataSource = DataTable_ShowMaskNumberList;
                GridViewStudentMaskList.DataBind();
                ExportMaskNumberListBtn.Visible = true;
            }
            else
            {
                ImpromptuHelper.ShowPromptGeneric("No data found", 0);
            }
        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
    }


    protected void HideButton() 
    {
        ExportMaskNumberListBtn.Visible = false;
        AllocatedRoomsStudent.Visible = false;
    }

    protected void ExportMaskNumberListBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=GeneratedMaskNumbersExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewStudentMaskList.AllowPaging = false;
            //Change the Header Row back to white color
            GridViewStudentMaskList.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Apply style to Individual Cells
            //GridViewStudentMaskList.HeaderRow.Cells[0].Visible = false;
            //GridViewStudentMaskList.HeaderRow.Cells[1].Visible = false;
            //GridViewStudentMaskList.HeaderRow.Cells[2].Visible = false;
            //GridViewStudentMaskList.HeaderRow.Cells[3].Visible = false;
            //GridViewStudentMaskList.HeaderRow.Cells[4].Visible = false;
            //GridViewStudentMaskList.HeaderRow.Cells[5].Visible = false;
            //gvTest.HeaderRow.Cells[6].Visible = false;
            for (int i = 0; i < GridViewStudentMaskList.Rows.Count; i++)
            {
                GridViewRow row = GridViewStudentMaskList.Rows[i];
                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;
                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                //row.Cells[0].Visible = false;
                //row.Cells[1].Visible = false;
                //row.Cells[2].Visible = false;
                //row.Cells[3].Visible = false;
                //row.Cells[4].Visible = false;
                //row.Cells[5].Visible = false;
                //row.Cells[6].Visible = false; 
            }
            GridViewStudentMaskList.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            //style to format numbers to string
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridViewStudentMaskList_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridViewStudentMaskList.Rows.Count > 0)
            {
                GridViewStudentMaskList.UseAccessibleHeader = false;
                GridViewStudentMaskList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ShowAllocatedStudentsRooms_Click(object sender, EventArgs e)
    {
        HideGrids();
        GridViewShowAllocatedStudentsRooms.Visible = true;

        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        try
        {
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Center_Id = Convert.ToInt32(Session["CId"]);
            //obj.Center_Id = 2010201;
            DataTable _DataTable = new DataTable();
            _DataTable = obj.SeatPlanAllocatedStudentsRoomsShow(obj);
            ViewState["_DataTable"] = _DataTable;
            if (_DataTable.Rows.Count > 0)
            {
                GridViewShowAllocatedStudentsRooms.DataSource = _DataTable;
                GridViewShowAllocatedStudentsRooms.DataBind();
                AllocatedRoomsStudent.Visible = true;
            }
            else
            {

                GridViewShowAllocatedStudentsRooms.DataBind();
                ImpromptuHelper.ShowPromptGeneric(" Room not Alocated Yet!", 1);


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void AllocatedRoomsStudent_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=AllocatedRoomsStudent.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewShowAllocatedStudentsRooms.AllowPaging = false;
        //Change the Header Row back to white color
        GridViewShowAllocatedStudentsRooms.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[0].Visible = false;
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[1].Visible = false;
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[2].Visible = false;
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[3].Visible = false;
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[4].Visible = false;
        //GridViewShowAllocatedStudentsRooms.HeaderRow.Cells[5].Visible = false;
        //gvTest.HeaderRow.Cells[6].Visible = false;
        for (int i = 0; i < GridViewShowAllocatedStudentsRooms.Rows.Count; i++)
        {
            GridViewRow row = GridViewShowAllocatedStudentsRooms.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
            //row.Cells[0].Visible = false;
            //row.Cells[1].Visible = false;
            //row.Cells[2].Visible = false;
            //row.Cells[3].Visible = false;
            //row.Cells[4].Visible = false;
            //row.Cells[5].Visible = false;
            //row.Cells[6].Visible = false; 
        }
        GridViewShowAllocatedStudentsRooms.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void GridViewShowAllocatedStudentsRooms_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridViewShowAllocatedStudentsRooms.Rows.Count > 0)
            {
                GridViewShowAllocatedStudentsRooms.UseAccessibleHeader = false;
                GridViewShowAllocatedStudentsRooms.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ShowAssignedTeacherRooms1_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (ShowAssignedTeacherRooms1.Rows.Count > 0)
            {
                ShowAssignedTeacherRooms1.UseAccessibleHeader = false;
                ShowAssignedTeacherRooms1.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void AssignedTeacherRooms_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=AssignedTeacherRooms.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        ShowAssignedTeacherRooms1.AllowPaging = false;
        //Change the Header Row back to white color
        ShowAssignedTeacherRooms1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[0].Visible = false;
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[1].Visible = false;
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[2].Visible = false;
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[3].Visible = false;
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[4].Visible = false;
        //ShowAssignedTeacherRooms1.HeaderRow.Cells[5].Visible = false;
        //gvTest.HeaderRow.Cells[6].Visible = false;
        for (int i = 0; i < ShowAssignedTeacherRooms1.Rows.Count; i++)
        {
            GridViewRow row = ShowAssignedTeacherRooms1.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
            //row.Cells[0].Visible = false;
            //row.Cells[1].Visible = false;
            //row.Cells[2].Visible = false;
            //row.Cells[3].Visible = false;
            //row.Cells[4].Visible = false;
            //row.Cells[5].Visible = false;
            //row.Cells[6].Visible = false; 
        }
        ShowAssignedTeacherRooms1.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void ShowAssignedTeacherRooms_Click(object sender, EventArgs e)
    {
        HideGrids();

        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            ShowAssignedTeacherRooms1.Visible = true;
            BLLSeatPlanTeacherExamAllocation obj = new BLLSeatPlanTeacherExamAllocation();
            try
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.TermId = Convert.ToInt32(ddlTerm.SelectedValue);
                obj.Center_Id = Convert.ToInt32(Session["CId"]);
                ViewState["_DataTable"] = null;
                DataTable DataTable_ = new DataTable();
                //if (ViewState["_DataTable"] == null)
                //{
                DataTable_ = obj.SeatPlanShowAssignedTeacherRooms(obj);
                ViewState["_DataTable"] = DataTable_;
                //}
                //else
                //{
                //    _DataTable = (DataTable)ViewState["_DataTable"];
                //}

                if (DataTable_.Rows.Count > 0)
                {
                    ShowAssignedTeacherRooms1.DataSource = DataTable_;
                    ShowAssignedTeacherRooms1.DataBind();
                    AssignedTeacherRooms.Visible = true;

                }
                else
                {

                    ShowAssignedTeacherRooms1.DataSource = null;
                    ShowAssignedTeacherRooms1.DataBind();
                    ImpromptuHelper.ShowPromptGeneric(" Room Allocation Process Pending..!", 1);


                }

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
        else 
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
            

    }
}