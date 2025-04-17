using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI;
using System.Drawing;
public partial class PresentationLayer_TCS_AssignStudents_OALevel : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private void bindListStatus()
    {
        ddlStatus.Items.Insert(0, new ListItem("Select", "0"));
        ddlStatus.Items.Insert(1, new ListItem("Approved/Unassigned", "1"));
        ddlStatus.Items.Insert(2, new ListItem("Assigned", "5"));

    }

    protected void Page_Load(object sender, EventArgs e)
    {
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
                    Response.Redirect("~/login.aspx", false);
                }

                //====== End Page Access settings ======================

                bindListStatus();

                pan_availableClass.Visible = false;

                ViewState["tMood"] = "check";

                //                FillClass();


                loadOrg(sender, e);

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

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void FillClass()
    {
        try
        {
            int moID = Int32.Parse(Session["moID"].ToString());

            DataRow rrow = (DataRow)Session["rightsRow"];
            BLLClass_Center objCC = new BLLClass_Center();
            objCC.Center_ID = Int32.Parse(ddl_center.SelectedValue);

            DataTable _dt = objCC.Class_CenterSelect_OA_Level(objCC);
            objBase.FillDropDown(_dt, list_classFilter, "class_Id", "class_name");
            objBase.FillDropDown(_dt, list_class, "class_Id", "class_name");

            list_section.Items.Clear();
            list_section.Items.Insert(0, new ListItem("Select", ""));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void search()
    {
        try
        {

            BLLStudent objStd = new BLLStudent();

            DataTable dt = new DataTable();

            DataRow row = (DataRow)Session["rightsRow"];

            //            objStd.Main_Organisation_Id = int.Parse(Session["moId"].ToString());
            objStd.Main_Organisation_Id = int.Parse(ddl_MOrg.SelectedValue);
            objStd.Class_ID = int.Parse(list_classFilter.SelectedValue);
            //          objStd.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
            objStd.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            //         objStd.Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
            objStd.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);

            if (ddlStatus.SelectedValue == "1")// UnAssigned Students
            {
                dt = objStd.GetStudents_Unassigned(objStd);

                ViewState["studentDT"] = dt;
            }
            else if (ddlStatus.SelectedValue == "5") //Assigend Students
            {

                objStd.Section_Id = int.Parse(list_sectionFilter.SelectedValue);

                dt = objStd.GetStudents_Assigned(objStd);
                ViewState["studentDT"] = dt;
            }

            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
                but_assignStudents.Visible = false;
            }
            else
            {
                dg_student.DataSource = dt;
                dg_student.DataBind();
                lab_dataStatus.Visible = false;
                but_assignStudents.Visible = true;
            }

            pan_availableClass.Visible = false;
            dg_student.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_student_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            int ind;

            if (e.CommandName == "name")
            {
                ind = Int32.Parse((string)e.CommandArgument);
                GridViewRow gvrow = dg_student.Rows[ind];
                DataRow dr = ((DataTable)ViewState["studentDT"]).Rows[gvrow.RowIndex];

                Session["studentId"] = dr["Student_ID"];
                //                Response.Redirect("StudentInfo.aspx", false);
            }
            else if (e.CommandName == "modify")
            {
                ind = Int32.Parse((string)e.CommandArgument);
                ViewState["student_id"] = dg_student.DataKeys[ind].Value;
                ViewState["check"] = "0";

                list_class.SelectedIndex = 0;
                list_section.SelectedIndex = 0;
                pan_availableClass.Visible = true;

                dg_subject.DataSource = new DataView();
                dg_subject.DataBind();

            }
            else if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in dg_student.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (mood == "" || mood == "check")
                    {
                        cb.Checked = true;
                        ViewState["tMood"] = "uncheck";
                    }
                    else
                    {
                        cb.Checked = false;
                        ViewState["tMood"] = "check";
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
    protected void dg_student_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dg_student.PageIndex = e.NewPageIndex;
            dg_student.DataSource = (DataTable)ViewState["studentDT"];
            dg_student.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (list_class.SelectedValue != "")
            {
                BLLClass_Section objCS = new BLLClass_Section();

                objCS.Class_Id = Int32.Parse(list_class.SelectedValue);

                //objCS.Center_Id = Int32.Parse(Session["cId"].ToString());

                objCS.Center_Id = Int32.Parse(ddl_center.SelectedValue);


                DataTable _dt = objCS.Class_SectionFetch(objCS);


                objBase.FillDropDown(_dt, list_section, "section_Id", "section_name");

                if (list_section.Items.Count == 0)
                {
                    ImpromptuHelper.ShowPrompt("This class has no section assigned to it. Please assign section(s) to this class first.");
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void RetrieveSubjects()
    {
        try
        {

            DataTable dt = null;
            DataRow dr = null;

            dt = (DataTable)ViewState["studentDT"];
            dr = dt.Rows[0];

            BLLStudent_Section_Subject ObjSSS = new BLLStudent_Section_Subject();

            if (list_section.SelectedValue != "")
            {
                ObjSSS.Section_Id = Int32.Parse(list_section.SelectedValue);

            }
            else if (list_sectionFilter.SelectedValue != "")
            {
                ObjSSS.Section_Id = Int32.Parse(list_sectionFilter.SelectedValue);

            }
            else
            {
                ObjSSS.Section_Id = Int32.Parse(list_section.SelectedValue);

            }



            if (ViewState["check"].ToString() == "0")
            {
                ObjSSS.Student_Id = 0;
                dg_subject.DataSource = ObjSSS.student_section_subjectSelectBySectionStudent_Id(ObjSSS);
            }
            else
            {
                ObjSSS.Student_Id = Convert.ToInt32(dr["Student_Id"].ToString());
                dg_subject.DataSource = ObjSSS.student_section_subjectSelectBySectionStudent_Id(ObjSSS);
            }

            dg_subject.DataBind();
            if (dg_subject.Rows.Count == 0)
            {
                if (ddlStatus.SelectedItem.Text == "Assigned")
                {
                    ImpromptuHelper.ShowPrompt("No subject(s) assigned to this section.");
                }

            }
            ViewState["subjectDt"] = dg_subject.DataSource;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_subject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox ch = (CheckBox)row.Cells[2].Controls[1];
                if (dg_subject.DataKeys[row.RowIndex].Value.ToString() != "")
                    ch.Checked = true;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void lb_assign_Click(object sender, EventArgs e)
    {

        BLLStudent_Section_Subject objBll = new BLLStudent_Section_Subject();

        if (Session["Session_Id"] != null)
        {
            objBll.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
        }
        try
        {
            bool isSelected = false;

            CheckBox cb = null;

            foreach (GridViewRow gvr in dg_student.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (cb.Checked)
                {
                    objBll.Student_Id = Convert.ToInt32(dg_student.DataKeys[gvr.RowIndex].Value.ToString());
                    GridViewRowCollection rC = dg_subject.Rows;
                    foreach (GridViewRow r in rC)
                    {
                        if (r.RowType == DataControlRowType.DataRow)
                        {
                            objBll.Section_Subject_Id = Convert.ToInt32(r.Cells[4].Text);
                            CheckBox ch = (CheckBox)r.Cells[2].Controls[1];
                            //if (ddlStatus.SelectedItem.Text == "Approved/Unassigned")
                            //{
                            if (ch.Checked == true)
                            {
                                /*Insert/Update Subject*/
                                objBll.Student_Secttion_Subject_AssignUpdate(objBll);
                                isSelected = true;
                            }
                            else
                            {
                                /*Delete From Student_section_subject and Detail Marks*/
                                objBll.Student_Secttion_Subject_UnAssign(objBll);
                                isSelected = true;
                            }

                            //}
                        }
                    }


                }

            }

            if (isSelected)
            {
                lb_assign.Visible = false;
                dg_subject.DataSource = null;
                dg_subject.DataBind();
                pan_availableClass.Visible = false;
                search();
                ImpromptuHelper.ShowPrompt("Student(s) successfully assigned to the selected subject(s).");


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_assignStudents_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedValue == "1")
            {

                lb_assign.Visible = true;

                if (list_classFilter.SelectedValue != "0")
                {
                    list_class.SelectedValue = list_classFilter.SelectedValue;
                    list_class_SelectedIndexChanged(sender, e);
                    list_class.Enabled = false;
                }
                else
                {
                    list_class.SelectedValue = "0";
                    list_class.SelectedIndex = 0;
                }

                list_section.SelectedIndex = 0;

                list_section.Enabled = true;

                ViewState["check"] = "1";
            }
            else if (ddlStatus.SelectedValue == "5")
            {

                list_class.SelectedValue = list_classFilter.SelectedValue;
                list_class.Enabled = false;

                list_class_SelectedIndexChanged(sender, e);

                list_section.SelectedValue = list_sectionFilter.SelectedValue;
                list_section.Enabled = false;

                GridViewRow gvr = dg_student.Rows[0];
                DataRow dr = ((DataTable)ViewState["studentDT"]).Rows[gvr.RowIndex];

                ViewState["check"] = "0";

                //Updated 22-Jan-2013

                lb_assign.Visible = true;

                //

                dg_subject.DataBind();
            }
            pan_availableClass.Visible = true;


            dg_subject.DataSource = new DataView();
            dg_subject.DataBind();
            RetrieveSubjects();

            ViewState.Remove("student_id");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void lbut_retrieveStudents_Click(object sender, EventArgs e)
    {
    }
    protected void list_classFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedValue == "" && list_classFilter.SelectedItem.Text != "Select")
            {
                lbl_sectionFilter.Visible = false;
                list_sectionFilter.Visible = false;
            }
            else if (ddlStatus.SelectedValue == "1" && list_classFilter.SelectedItem.Text != "Select")
            {
                lbl_sectionFilter.Visible = false;
                list_sectionFilter.Visible = false;
                search();
            }
            else if (ddlStatus.SelectedValue == "5" && list_classFilter.SelectedItem.Text != "Select")
            {
                lbl_sectionFilter.Visible = true;
                list_sectionFilter.Visible = true; ;
                getSectionsAgainstClass();

                but_assignStudents.Visible = false;

                pan_availableClass.Visible = false;
                dg_student.DataBind();

                lab_dataStatus.Visible = false;
            }
            else if (list_classFilter.SelectedItem.Text == "Select")
            {
                lbl_sectionFilter.Visible = false;
                list_sectionFilter.Visible = false;


                but_assignStudents.Visible = false;

                pan_availableClass.Visible = false;
                dg_student.DataBind();

                lab_dataStatus.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            list_classFilter.SelectedIndex = 0;

            list_sectionFilter.Items.Clear();

            lbl_sectionFilter.Visible = false;
            list_sectionFilter.Visible = false;

            but_assignStudents.Visible = false;

            dg_student.DataBind();

            lab_dataStatus.Visible = false;

            pan_availableClass.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void decideSection()
    {
        try
        {
            if (ddlStatus.SelectedValue == "")
            {
                list_classFilter.SelectedIndex = 0;

                list_sectionFilter.Items.Clear();

                but_assignStudents.Visible = false;

                dg_student.DataBind();
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                list_sectionFilter.Items.Clear();

            }
            else if (ddlStatus.SelectedValue == "5")
            {
                list_classFilter.SelectedIndex = 0;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void getSectionsAgainstClass()
    {
        try
        {

            if (list_classFilter.SelectedValue != "")
            {

                BLLClass_Section objCS = new BLLClass_Section();

                objCS.Class_Id = Int32.Parse(list_classFilter.SelectedValue);
                //objCS.Center_Id = Int32.Parse(Session["cId"].ToString());
                objCS.Center_Id = Int32.Parse(ddl_center.SelectedValue);

                DataTable _dt = objCS.Class_SectionFetch(objCS);


                objBase.FillDropDown(_dt, list_sectionFilter, "section_Id", "section_name");

                if (list_sectionFilter.Items.Count == 0)
                {
                    ImpromptuHelper.ShowPrompt("This class has no section assigned to it. Please assign section(s) to this class first.");
                }
            }

            dg_subject.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_sectionFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedItem.Text != "Select" && list_classFilter.SelectedValue != "" && list_sectionFilter.SelectedValue != "")
            {
                search();
            }
            else
            {
                lab_dataStatus.Visible = true;
                but_assignStudents.Visible = false;

                pan_availableClass.Visible = false;
                dg_student.DataBind();

                lab_dataStatus.Visible = false;
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
        loadCountries();

    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadRegions();
    }
    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCenter();
    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillClass();
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

    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void list_section_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RetrieveSubjects();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void cleartoggle()
    {

        foreach (GridViewRow gvr in dg_student.Rows)
        {
            CheckBox cb=(CheckBox)gvr.FindControl("CheckBox1");
            cb.Checked = false;
            gvr.BackColor = Color.White;
        }
    
    
    }
    protected void btnPassChange_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {

            
            ImageButton imgbtn = (ImageButton)sender;
            int student_Id = Convert.ToInt32(imgbtn.CommandArgument);
            BLLStudent_Section_Subject ObjSSS = new BLLStudent_Section_Subject();

            cleartoggle();


            GridViewRow gvr = (GridViewRow)imgbtn.NamingContainer;
            
            
            gvr.BackColor = ColorTranslator.FromHtml("#A1DCF2");
            //int =gvr.BackColor.GetHashCode();



            CheckBox cb = null;
            cb = (CheckBox)gvr.FindControl("CheckBox1");
            cb.Checked = true;

            list_class.SelectedValue = list_classFilter.SelectedValue;
            list_class.Enabled = false;

            list_class_SelectedIndexChanged(sender, e);

            list_section.SelectedValue = list_sectionFilter.SelectedValue;
            list_section.Enabled = false;

            //GridViewRow gvr = dg_student.Rows[0];
            //DataRow dr = ((DataTable)ViewState["studentDT"]).Rows[gvr.RowIndex];

            lb_assign.Visible = true;
            dg_subject.DataBind();


            pan_availableClass.Visible = true;


            dg_subject.DataSource = new DataView();
            dg_subject.DataBind();



            if (list_section.SelectedValue != "")
            {
                ObjSSS.Section_Id = Int32.Parse(list_section.SelectedValue);

            }
            else if (list_sectionFilter.SelectedValue != "")
            {
                ObjSSS.Section_Id = Int32.Parse(list_sectionFilter.SelectedValue);

            }
            else
            {
                ObjSSS.Section_Id = Int32.Parse(list_section.SelectedValue);

            }
            ObjSSS.Student_Id = student_Id;
            dg_subject.DataSource = ObjSSS.student_section_subjectSelectBySectionStudent_Id(ObjSSS);

            dg_subject.DataBind();
            if (dg_subject.Rows.Count == 0)
            {
                if (ddlStatus.SelectedItem.Text == "Assigned")
                {
                    ImpromptuHelper.ShowPrompt("No subject(s) assigned to this student.");
                }

            }
            ViewState["subjectDt"] = dg_subject.DataSource;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void dg_student_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Control ctrl = e.Row.FindControl("CheckBox1");
            ImageButton imgbtn = (ImageButton)e.Row.FindControl("btnstdSub");
            if (ddlStatus.SelectedValue == "5")
            {
                ctrl.Visible = false;
                imgbtn.Visible = true;
            }
            else
            {
                ctrl.Visible = true;
                imgbtn.Visible = false;
            }
        }
    }
    protected void OnSelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = dg_student.Rows[e.NewSelectedIndex];
        //foreach (GridViewRow row in dg_student.Rows)
        //{
        //    if (row.RowIndex == dg_student.SelectedIndex)
        //    {
        //        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        //    }
        //    else
        //    {
        //        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        //    }
        //}
    }
}
