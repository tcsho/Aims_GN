using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
public partial class PresentationLayer_TCS_SeatPlanRoomAllocation : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    Decimal dPageTotal;
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnExport);
        scriptManager.RegisterPostBackControl(this.GeneratedMaskNumbersExport);
        scriptManager.RegisterPostBackControl(this.AllocatedRoomsStudent);
        scriptManager.RegisterPostBackControl(this.AssignedTeacherRooms);
        scriptManager.RegisterPostBackControl(this.ExcelAllocationBYCenterBtn);

        GeneratedMaskNumbersExport.Visible = false;
        AllocatedRoomsStudent.Visible = false;
        AssignedTeacherRooms.Visible = false;
        ExcelAllocationBYCenterBtn.Visible = false;
        btnExport.Visible = false;
        

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
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }


                //====== End Page Access settings ======================


                loadOrg(sender, e);
                FillActiveSessions();
                AdEditCate.Visible = false;
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
                // PageInformation();
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
            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionIDSeatPlan(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
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
            if (ddlTerm.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            {
                if (isLocked())
                {
                    ViewState["Data"] = null;
                    BindGrid();
                }
                else
                {

                    gvTest.DataSource = null;
                    gvTest.DataBind();
                    ImpromptuHelper.ShowPromptGeneric("The Configuration is incomplete, please cooridnate with regional exam coordinator.", 0);

                }
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

    protected void gvRooms_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvRooms.Rows.Count > 0)
            {
                gvRooms.UseAccessibleHeader = false;
                gvRooms.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        try
        {
            BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();

            int k = 0;
            objCat.SeatPlanRoomAllocationLockUpdate(Convert.ToInt32(ViewState["Categ_Id"].ToString()), 0);


            if (ddlSession.SelectedIndex > 0 && Convert.ToInt32(txtStudents.Text) > 0 && ddlRoom.SelectedIndex > 0)
            {

                objCat.Categ_Id = Convert.ToInt32(ViewState["Categ_Id"].ToString());
                objCat.Room_Id = Convert.ToInt32(ddlRoom.SelectedValue.ToString());
                objCat.Students = Convert.ToInt32(txtStudents.Text);
                objCat.Class_Id = Convert.ToInt32(ClassID_.Text);

                if (ViewState["Mode"].ToString() == "Add")
                {
                    objCat.CreatedOn = DateTime.Now;
                    objCat.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());

                    k = objCat.SeatPlanRoomAllocationAdd(objCat);

                }
                if (ViewState["Mode"].ToString() == "Edit")
                {
                    objCat.RoomAllot_Id = Convert.ToInt32(ViewState["RoomAllot_Id"].ToString());
                    objCat.ModifiedOn = DateTime.Now;
                    objCat.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                    k = objCat.SeatPlanRoomAllocationUpdate(objCat);

                }
                if (k == 2)
                {
                    ImpromptuHelper.ShowPromptGeneric("Error: Room number already Exists!", 0);
                }
                else if (k == 1)

                {
                    ImpromptuHelper.ShowPrompt("Room Allocation Saved!");
                    ViewState["RoomsData"] = null;
                    BindGridRoom();
                }
                ViewState["Mode"] = "Add";
            }
            else
            {
                ImpromptuHelper.ShowPromptGeneric("Room # and Students are mendatory fileds!", 0);
            }
            ViewState["Data"] = null;
            gvTest.DataSource = null;
            gvTest.DataBind();
            BindGrid();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
            //..  AdEditCate.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void loadSeatPlanRoomsInfo()
    {

        try
        {
            BLLSeatPlanRoomInfo objCen = new BLLSeatPlanRoomInfo();

            DataTable dt = new DataTable();
            dt = objCen.SeatPlanRoomInfoSelectAll();
            objBase.FillDropDown(dt, ddlRoom, "Room_Id", "RoomName");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected Boolean isLocked()
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        int k = 0;
        bool ret = false;
        DataTable dt = new DataTable();
        try
        {
            if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                dt = obj.SeatPlanCategorySelectLock(obj);
            }
            if (dt.Rows.Count > 0)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        return ret;
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


    protected void btnAddRoom_Click(object sender, EventArgs e)
    {
        gvRooms.Visible = true;

        BLLSeatPlanRoomAllocation obaj = new BLLSeatPlanRoomAllocation();
        int k = 0;
        DataTable dt = new DataTable();
        try
        {
            LinkButton btnEdit = (LinkButton)(sender);
            obaj.Categ_Id = Convert.ToInt32(btnEdit.CommandArgument);

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;

            TotalStudents.Text = "Total Students : " + gvTest.SelectedRow.Cells[6].Text;
            AllocatedVsTotal.Text = "Allocated Students : 0";

            ViewState["Categ_Id"] = obaj.Categ_Id;
            ViewState["RoomsData"] = null;
            BindGridRoom();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        try
        {
            ResetControlls();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            AdEditCate.Visible = true;
            ViewState["Mode"] = "Add";
            LinkButton btnEdit = (LinkButton)(sender);
            loadSeatPlanRoomsInfo();

            obj.Categ_Id = Convert.ToInt32(btnEdit.CommandArgument);

            ViewState["Categ_Id"] = obj.Categ_Id;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;

            ddl_center.SelectedValue = gvr.Cells[1].Text;



            lblClass.Text = gvr.Cells[8].Text;
            lblBlock.Text = gvr.Cells[9].Text;
            lblGender.Text = gvr.Cells[10].Text;
            lblCategory.Text = gvr.Cells[11].Text;
            //..CenterID_.Text = gvr.Cells[].Text;
            SessionID_.Text = gvr.Cells[4].Text;
            TermID_.Text = gvr.Cells[4].Text;
            ClassID_.Text = gvr.Cells[4].Text;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnShowDetail_Click(object sender, EventArgs e)
    {
        AdEditCate.Visible = false;
        gvRooms.Visible = true;
        BLLSeatPlanRoomAllocation obj = new BLLSeatPlanRoomAllocation();
        int k = 0;
        DataTable dt = new DataTable();
        try
        {
            LinkButton btnEdit = (LinkButton)(sender);
            obj.Categ_Id = Convert.ToInt32(btnEdit.CommandArgument);

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;

            ViewState["Categ_Id"] = obj.Categ_Id;
            ViewState["RoomsData"] = null;
            BindGridRoom();
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
            AdEditCate.Visible = false;
            gvRooms.Visible = false;
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
            if (ddl_center.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

            DataTable dt = new DataTable();
            if (ViewState["Data"] == null)
            {
                dt = obj.SeatPlanCategorySelectBySessionTermCenter(obj);
                ViewState["Data"] = dt;

            }
            else
            {
                dt = (DataTable)ViewState["Data"];
                btnExport.Visible = true;
            }

            if (dt.Rows.Count > 0)
            {
                gvTest.DataSource = dt;
                gvTest.DataBind();
                btnExport.Visible = true;
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
    protected void BindGridRoom()
    {
        BLLSeatPlanRoomAllocation obj = new BLLSeatPlanRoomAllocation();

        DataTable dt = new DataTable();
        try
        {
            obj.Categ_Id = Convert.ToInt32(ViewState["Categ_Id"].ToString());
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);

            if (ViewState["RoomsData"] == null)
            {
                dt = obj.SeatPlanRoomAllocationSelectByCategoryId(obj);
                ViewState["RoomsData"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["RoomsData"];
            }

            if (dt.Rows.Count > 0)
            {
                gvRooms.DataSource = dt;
                double totalSalary = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalSalary += Convert.ToDouble(row["Students"]);
                }
                AllocatedVsTotal.Text = "Allocated Students :" + totalSalary.ToString();
                //--- Here 3 is the number of column where you want to show the total.  
               // gvRooms.Columns[3].FooterText = totalSalary.ToString();
                gvRooms.DataBind();


            }
            else
            {

                gvRooms.DataSource = null;
                gvRooms.DataBind();

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
            //ddl_center.SelectedIndex = 0;
            //..    ddl_center.Enabled = true;
        }


    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        BLLSeatPlanRoomAllocation obj = new BLLSeatPlanRoomAllocation();
        try
        {
            ResetControlls();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            AdEditCate.Visible = true;
            ViewState["Mode"] = "Edit";
            LinkButton btnEdit = (LinkButton)(sender);

            loadSeatPlanRoomsInfo();
            obj.RoomAllot_Id = Convert.ToInt32(btnEdit.CommandArgument);

            ViewState["RoomAllot_Id"] = obj.RoomAllot_Id;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvRooms.SelectedIndex = gvr.RowIndex;

            lblCategory.Text = gvr.Cells[5].Text;
            lblBlock.Text = gvr.Cells[3].Text;
            lblClass.Text = gvr.Cells[4].Text;
            lblGender.Text = gvr.Cells[2].Text;

            txtStudents.Text = gvr.Cells[8].Text;
            ddlRoom.SelectedValue = gvr.Cells[1].Text;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BLLSeatPlanRoomAllocation obj = new BLLSeatPlanRoomAllocation();
        int k = 0;
        try
        {
            LinkButton btnEdit = (LinkButton)(sender);
            obj.RoomAllot_Id = Convert.ToInt32(btnEdit.CommandArgument);

            ViewState["RoomAllot_Id"] = obj.RoomAllot_Id;
            k = obj.SeatPlanRoomAllocationDelete(obj);

            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Record Deleted Successfully");
                ViewState["RoomsData"] = null;
                BindGridRoom();

            }
            else
            {
                ImpromptuHelper.ShowPromptGeneric("Record Can not be Deleted", 0);
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void GenerateRollNOButton_Click(object sender, EventArgs e)
    {
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
        //..    obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
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
                                        ImpromptuHelper.ShowPrompt("Roll Number Asigned To Campus " + Center_Id + " Class:: " + FOrmatedClassID);

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
                ShowGeneratedRollNumbersWithMask();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }





    }

    protected void btnLockBlock_Click(object sender, EventArgs e)
    {
    }

    protected bool DecideHere(int CountAssignStudent, int CountTotalStudent, int IsLockedForRooms)
    {
        //if (
        //    Convert.ToInt32(CountAssignStudent) >= Convert.ToInt32(CountTotalStudent) 
        //    && Convert.ToInt32(CountAssignStudent) != 0 && IsLockedForRooms == 1)
        if (IsLockedForRooms == 1)
            return true;
        else
            return false;
    }

    protected bool ShowUnlockedBlocks(int CountAssignStudent, int CountTotalStudent, int IsLockedForRooms)
    {
        //if ((Convert.ToInt32(CountAssignStudent) < Convert.ToInt32(CountTotalStudent)) 
        //    || Convert.ToInt32(CountAssignStudent) == 0)
        if (IsLockedForRooms == 0)
            return true;
        else
            return false;
    }

    protected void AllocateRoomsToStudent_Click(object sender, EventArgs e)
    {

        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        try
        {
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);


            BLLCenter objCen = new BLLCenter();
            DataTable DataTable_Center = new DataTable();
            DataTable_Center = objCen.CentersList(objCen);

            if (DataTable_Center.Rows.Count > 0)
            {
                foreach (DataRow row__ in DataTable_Center.Rows)
                {
                    obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                    obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                    //..    obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
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
                        foreach (DataRow row in DataTable_.Rows)
                        {
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
                                //if (ObjSelect.SeatPlanAssignRoomsToStudents(ObjSelect))
                                //{

                                //}
                                //else 
                                //{
                                //}
                                ImpromptuHelper.ShowPrompt("Rooms Allocated To The Students Of Class ::>> " + Class_Id);

                            }
                            catch (Exception ex)
                            {
                                Session["error"] = ex.Message;
                                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                            }
                            /********************************/
                        }
                    }
                    else
                    {
                        ImpromptuHelper.ShowPromptGeneric("Error: Rooms Not Assigned To All Students!", 0);
                        ////gvTest.DataSource = null;
                        ////gvTest.DataBind();
                    }
                    ImpromptuHelper.ShowPrompt("Rooms Allocated Students .. ");
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void ShowGeneratedRollNumbersWithMask()
    {

        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();

        try
        {

            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Center_Id = Convert.ToInt32(Session["CId"]);
            ViewState["_DataTable"] = "";
            DataTable _DataTable = new DataTable();
            //if (ViewState["_DataTable"] == null)
            //{
            _DataTable = obj.SeatPlanCategorySelectBySessionTermCenterStudent(obj);
            ViewState["_DataTable"] = _DataTable;
            //}
            //else
            //{
            //    _DataTable = (DataTable)ViewState["_DataTable"];
            //}

            if (_DataTable.Rows.Count > 0)
            {
                GridViewStudentMaskList.DataSource = _DataTable;
                GridViewStudentMaskList.DataBind();
                GeneratedMaskNumbersExport.Visible = true;

            }
            else
            {

                GridViewStudentMaskList.DataSource = null;
                GridViewStudentMaskList.DataBind();
                ImpromptuHelper.ShowPromptGeneric(" Student Mask List Not Generated Yet!", 1);

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void ShowGeneratedMaskNoBtn_Click(object sender, EventArgs e)
    {
        HideGrids();
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            this.GridViewStudentMaskList.Visible = true;
            ShowGeneratedRollNumbersWithMask();
        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
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
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            AllocatedStudentsRoomsShow();
        }
        else
        {
            ImpromptuHelper.ShowPromptGeneric("Error: Please Select Term..!", 0);
        }
        

    }

    protected void AllocatedStudentsRoomsShow()
    {
        //this.GridViewStudentMaskList.DataSource = null;
        //this.GridViewStudentMaskList.Visible = false;
        //this.GridViewShowAllocatedStudentsRooms.Visible = true;

        ShowAndHideGridView(GridViewShowAllocatedStudentsRooms);
        BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
        ViewState["_DataTable"] = null;

        try
        {
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Center_Id = Convert.ToInt32(Session["CId"]);

            DataTable _DataTable = new DataTable();
            //if (ViewState["_DataTable"] == null)
            //{
            _DataTable = obj.SeatPlanAllocatedStudentsRoomsShow(obj);
            ViewState["_DataTable"] = _DataTable;
            //}
            //else
            //{
            //    _DataTable = (DataTable)ViewState["_DataTable"];
            //}

            if (_DataTable.Rows.Count > 0)
            {
                GridViewShowAllocatedStudentsRooms.DataSource = _DataTable;
                GridViewShowAllocatedStudentsRooms.DataBind();
                AllocatedRoomsStudent.Visible = true;
            }
            else
            {

                GridViewShowAllocatedStudentsRooms.DataSource = null;
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

    protected void AssignRoomtoTeacher_Click(object sender, EventArgs e)
    {

    }




    static Dictionary<int, int> printClosest(int[] arr, int n, int x)
    {
        int res_l = 0, res_r = 0;
        int l = 0, r = n - 1, diff = int.MaxValue;
        Dictionary<int, int> val = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            int xdiff = x - arr[i];
            if (arr[i] == x)
            {
                val.Add(res_l, arr[res_l]);
                return val;
            }
            else if ((xdiff < 0) && (xdiff) >= -5)
            {
                val.Add(res_l, arr[res_l]);
                return val;
            }
            else if ((xdiff > 0) && (xdiff) <= 5)
            {
                val.Add(res_l, arr[res_l]);
                return val;
            }
        }
        while (r > l)
        {
            if (Math.Abs(arr[l] + arr[r] - x) < diff)
            {
                res_l = l;
                res_r = r;
                diff = Math.Abs(arr[l] + arr[r] - x);
            }



            if (arr[l] + arr[r] > x)
                r--;
            else
                l++;
        }
        val.Add(res_l, arr[res_l]);
        val.Add(res_r, arr[res_r]);
        return val;
    }

    protected void ShowAssignedTeacherRoomsGridView_PreRender(object sender, EventArgs e)
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
                    AssignedTeacherRooms.Visible = true;
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

    protected void ShowAndHideGridView(GridView GridName)
    {
        //this.ShowAssignedTeacherRooms1.DataSource = null;
        //this.ShowAssignedTeacherRooms1.Visible = false;

        //this.GridViewShowAllocatedStudentsRooms.DataSource = null;
        //this.GridViewShowAllocatedStudentsRooms.Visible = false;

        //this.GridViewStudentMaskList.DataSource = null;
        //this.GridViewStudentMaskList.Visible = false;
        GridName.Visible = true;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=SchoolBlockDistribution.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTest.AllowPaging = false;
            //Change the Header Row back to white color
            gvTest.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gvTest.HeaderRow.Cells[0].Visible = false;
            gvTest.HeaderRow.Cells[6].Visible = false;
            gvTest.HeaderRow.Cells[7].Visible = false;
            gvTest.HeaderRow.Cells[8].Visible = false;
            gvTest.HeaderRow.Cells[9].Visible = false;
            for (int i = 0; i < gvTest.Rows.Count; i++)
            {
                GridViewRow row = gvTest.Rows[i];
                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;
                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                row.Cells[0].Visible = false;
                row.Cells[6].Visible = false;
                row.Cells[7].Visible = false;
                row.Cells[8].Visible = false;
                row.Cells[9].Visible = false;
            }
            gvTest.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            //style to format numbers to string
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }


    protected void GeneratedMaskNumbersExport_Click(object sender, EventArgs e)
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

    protected void AllocatedRoomsStudent_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=AllocatedRoomsToStudent.xls");
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

    protected void ibtnEdit_Click(object sender, EventArgs e)
    {

    }



    protected void ibtnEdit_Command1(object sender, CommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        int Categ_IdUpdate = Convert.ToInt32(commandArgs[0]);
        int CountAssignStudent = Convert.ToInt32(commandArgs[1]);
        int CountTotalStudents = Convert.ToInt32(commandArgs[2]);
        BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();
        if ((CountAssignStudent < CountTotalStudents) || CountAssignStudent == 0)
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 0);
            ImpromptuHelper.ShowPromptGeneric(" Data Can not be locked Bacause still all students not assigned !", 0);
        }
        else
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 1);
            ImpromptuHelper.ShowPromptGeneric(" Data Locked !", 1);
        }

    }

    //protected void ibtnEdit_Command1(object sender, CommandEventArgs e)
    //{
    //    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
    //    int Categ_IdUpdate = Convert.ToInt32(commandArgs[0]);
    //    int CountAssignStudent = Convert.ToInt32(commandArgs[1]);
    //    int CountTotalStudents = Convert.ToInt32(commandArgs[2]);
    //    BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();
    //    if ((CountAssignStudent < CountTotalStudents) || CountAssignStudent == 0)
    //    {
    //        objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 0);
    //        ImpromptuHelper.ShowPromptGeneric(" Data Can not be locked Bacause still all students not assigned !", 0);
    //    }
    //    else
    //    {
    //        objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 1);
    //        ImpromptuHelper.ShowPromptGeneric(" Data Locked !", 1);
    //    }

    //}


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




    protected void ibtnEdit_Command(object sender, CommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        int Categ_IdUpdate = Convert.ToInt32(commandArgs[0]);
        int CountAssignStudent = Convert.ToInt32(commandArgs[1]);
        int CountTotalStudents = Convert.ToInt32(commandArgs[2]);
        BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();
        if ((CountAssignStudent < CountTotalStudents) || CountAssignStudent == 0)
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 0);
            ImpromptuHelper.ShowPromptGeneric(" Data Can not be locked Bacause still all students not assigned !", 0);
            BindGrid();
        }
        else
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 1);
            ImpromptuHelper.ShowPromptGeneric(" Data Locked !", 1);
            BindGrid();
        }
    }

    protected void LOckDecision_Command(object sender, CommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        int Categ_IdUpdate = Convert.ToInt32(commandArgs[0]);
        int CountAssignStudent = Convert.ToInt32(commandArgs[1]);
        int CountTotalStudents = Convert.ToInt32(commandArgs[2]);
        BLLSeatPlanRoomAllocation objCat = new BLLSeatPlanRoomAllocation();
        if ((CountAssignStudent < CountTotalStudents) || CountAssignStudent == 0)
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 0);
            ImpromptuHelper.ShowPromptGeneric(" Data Can not be locked Bacause still all students not assigned !", 0);
            BindGrid();
        }
        else
        {
            objCat.SeatPlanRoomAllocationLockUpdate(Categ_IdUpdate, 1);
            ImpromptuHelper.ShowPromptGeneric(" Data Locked !", 1);
            BindGrid();
        }
    }

    protected void GridViewShowRoomsAllocationBYCenter_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridViewShowRoomsAllocationBYCenter.Rows.Count > 0)
            {
                GridViewShowRoomsAllocationBYCenter.UseAccessibleHeader = false;
                GridViewShowRoomsAllocationBYCenter.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ShowRoomsAllocationBYCenterBtn_Click(object sender, EventArgs e)
    {
        HideGrids();
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
        {
            GridViewShowRoomsAllocationBYCenter.Visible = true;
            BLLSeatPlanCategory obj = new BLLSeatPlanCategory();
            try
            {
                if (ddlSession.SelectedIndex > 0)
                    obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                if (ddlTerm.SelectedIndex > 0)
                    obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                if (ddl_center.SelectedIndex > 0)
                    obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

                DataTable dt_ = new DataTable();
                dt_ = obj.ShowRoomsAllocationBYCenter(obj);
                if (dt_.Rows.Count > 0)
                {
                    GridViewShowRoomsAllocationBYCenter.DataSource = dt_;
                    GridViewShowRoomsAllocationBYCenter.DataBind();
                    ExcelAllocationBYCenterBtn.Visible = true;
                }
                else
                {

                    GridViewShowRoomsAllocationBYCenter.DataSource = null;
                    GridViewShowRoomsAllocationBYCenter.DataBind();
                    ImpromptuHelper.ShowPromptGeneric("No Rooms Allocation Generated ..!", 1);
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

    protected void HideGrids()
    {
        this.GridViewStudentMaskList.DataSource = null;
        this.GridViewStudentMaskList.Visible = false;

        this.GridViewShowAllocatedStudentsRooms.DataSource = null;
        this.GridViewShowAllocatedStudentsRooms.Visible = false;

        this.ShowAssignedTeacherRooms1.DataSource = null;
        this.ShowAssignedTeacherRooms1.Visible = false;

        this.GridViewShowRoomsAllocationBYCenter.DataSource = null;
        this.GridViewShowRoomsAllocationBYCenter.Visible = false;
    }

    protected void ExcelAllocationBYCenterBtn_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=RoomsAllocation.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewShowRoomsAllocationBYCenter.AllowPaging = false;
        //Change the Header Row back to white color
        GridViewShowRoomsAllocationBYCenter.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Apply style to Individual Cells
        for (int i = 0; i < GridViewShowRoomsAllocationBYCenter.Rows.Count; i++)
        {
            GridViewRow row = GridViewShowRoomsAllocationBYCenter.Rows[i];
            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;
            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");
        }
        GridViewShowRoomsAllocationBYCenter.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        //style to format numbers to string
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void gvRooms_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPgTotal = (Label)e.Row.FindControl("lblTotalPrice");
            dPageTotal += Decimal.Parse(lblPgTotal.Text);
        }

        // FINALLY, SHOW THE RUNNING AND GRAND TOTAL ON EACH PAGE.
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (ViewState["TotalPrice"] != null && dPageTotal != 0)
            {
                // PAGE TOTAL.
                Label lblPageTotal = (Label)e.Row.FindControl("lblPageTotal");
                lblPageTotal.Text = dPageTotal.ToString("N2");

                //GRAND TOTAL.
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                lblGrandTotal.Text = ViewState["TotalPrice"].ToString();
            }
        }
    }

    protected void gvRooms_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRooms.PageIndex = e.NewPageIndex;
        BindGridRoom();
    }
}

