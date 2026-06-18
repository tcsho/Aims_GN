using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI;
using System.IO;
using System.Configuration;
using City.Library.SQL;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Linq;


public partial class PresentationLayer_SefEvaluation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    private int windowWidth = 5;
    DALBase objBase = new DALBase();
    int UL_ID;
    BLLUploadEducationalArchive objSer = new BLLUploadEducationalArchive();
    BLLSiqa objSiqa = new BLLSiqa();
    DataSet _dtGrade;
    DataTable _dt_PS_KS4_5;
    DataTable _dtKS2;
    BLLKpiSef _kpiBll = new BLLKpiSef();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());

            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(this.but_Export);
            if (!Page.IsPostBack)
            {
                lblerror.Text = "";
                lblerror.Visible = false;
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.but_Export);

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

                //but_page_last.Visible = false;
                //but_page_First.Visible = false;
                ViewState["tMood"] = "check";

                #region Filling lists
                DALBase oDALBase = new DALBase();
                DataSet ods = new DataSet();
                ods = null;

                ods = oDALBase.get_Gender();

                DataTable dt = ods.Tables[0];


                //****************************************

                loadRegions();
                FillActiveSessions();
                dt = objSiqa.Get_Active_GroupHeads();
                objBase.FillDropDown(dt, ddl_grouphead, "Group_ID", "Group_Name");


                #endregion


                //2025-01-09
                int userid = Convert.ToInt32(row["User_Type_Id"].ToString());
                if (userid == 45 || userid == 43 || userid == 44)
                {
                    btnsave.Enabled = false;
                    btnprint.Enabled = false;
                    btn_ConSiqaEndrosed.Enabled = false;
                }

                if (userid == 43)      //QuratUlAin.Fatima     Region readonly
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                }


                int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
                if (UserLevel_ID == 1 || UserLevel_ID == 2) //Head Office
                {

                    btn_ConSiqaEndrosed.Visible = true;

                    btn_ConSave.Enabled = false;
                    btn_ConSave.Visible = false;
                    ddl_Session.SelectedIndex = ddl_Session.Items.Count - 1;

                }
                else if (UserLevel_ID == 3) //Regional Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_region.Enabled = false;
                    btn_ConSave.Visible = false;
                    btn_ConSiqaEndrosed.Visible = true;

                }
                else if (UserLevel_ID == 4 && Session["UserType_Id"].ToString() == "34")//Counselors   //Addded by Hasan
                {

                }
                else if (UserLevel_ID == 10) //Network
                {

                }
                else if (UserLevel_ID == 5) //Teacher
                {

                    but_search_Click(this, EventArgs.Empty);

                }


                else if (UserLevel_ID == 4) //Campus Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);
                    ddl_Session.SelectedIndex = ddl_Session.Items.Count - 1;
                    ddl_Session.Enabled = false;
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = false;
                    btn_ConSave.Visible = true;
                    btn_ConSiqaEndrosed.Visible = false;

                }

                ddl_1_3_overall_grade.Enabled = false;
                ddl_2_1_1_and_2_1_2_grade.Enabled = false;
                ddl_2_1_5_grade.Enabled = false;
                ddl_3_1_overall_grade.Enabled = false;
                ddl_3_2_1_grade.Enabled = false;
                ddl_3_2_3_grade.Enabled = false;
                ddl_4_2_1_grade.Enabled = false;
                ddl_5_2_3_grade.Enabled = false;


                DataTable dtlovs = new DataTable();



                Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = false;
                Conditional_row1_ps_4_for_ks4_ks5_matric.Visible = false;
                Conditional_row2_ps_4_for_ks4_ks5_matric.Visible = false;
                Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = false;



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
            string selected_text = ddl_grouphead.SelectedItem.Text;
            if (ddl_region.SelectedItem.Text.ToString() == "Select")
            {
                lblerror.Text = "Please select Region";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }
            if (ddl_center.SelectedItem.Text.ToString() == "" || ddl_center.SelectedItem.Text.ToString() == "Select")
            {
                lblerror.Text = "Please select Center";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }
            if (ddl_grouphead.SelectedItem.Text.ToString() == "Select")
            {
                lblerror.Text = "Please select Key Stage";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }

            show_Ph.Visible = true;
            Call_All_Performance_Standard();
            if (selected_text == "KS5")
            {
                ddl_1_3_overall_grade.Enabled = true;
                ddl_2_1_1_and_2_1_2_grade.Enabled = true;
                ddl_2_1_5_grade.Enabled = true;
                ddl_3_1_overall_grade.Enabled = true;
                ddl_3_2_1_grade.Enabled = true;
                ddl_3_2_3_grade.Enabled = true;
                ddl_4_2_1_grade.Enabled = true;
                ddl_5_2_3_grade.Enabled = true;
            }
            else
            {
                ddl_1_3_overall_grade.Enabled = false;
                ddl_2_1_1_and_2_1_2_grade.Enabled = false;
                ddl_2_1_5_grade.Enabled = false;
                ddl_3_1_overall_grade.Enabled = false;
                ddl_3_2_1_grade.Enabled = false;
                ddl_3_2_3_grade.Enabled = false;
                ddl_4_2_1_grade.Enabled = false;
                ddl_5_2_3_grade.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void Call_All_Performance_Standard()
    {

        Load_PS1_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(),ddl_Session.SelectedValue.ToString());
        Bind_Learning_skill_Grid();  //Child Fetching Area of PS1
        Load_PS2_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        Load_PS3_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        Load_PS4_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        Load_PS5_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        Load_PS6_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        Load_Consolodation_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        calculate_PS5_Data(ddl_center.SelectedValue.ToString(), ddl_grouphead.SelectedItem.Text.ToString(), ddl_Session.SelectedValue.ToString());
        ConsolidationBody();
        ConsolidationBodyHistory();
        Compare_Dropdown_Values();
        if (ddl_grouphead.SelectedItem.Text.ToString() == "EYFS" || ddl_grouphead.SelectedItem.Text.ToString() == "KS1")
        {
            ddl_2_1_5_grade.Visible = true;
            lbl2_1_5.Visible = true;
            lbl2_1_5Desc.Visible = true;
        }
        else
        {
            ddl_2_1_5_grade.Visible = false;
            lbl2_1_5.Visible = false;
            lbl2_1_5Desc.Visible = false;

        }
    }



    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddl_Session, "Session_ID", "Description");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void dg_student_PreRender(object sender, EventArgs e)
    {

    }
    protected void dv_details_PreRender(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gv_learningskills_PreRender(object sender, EventArgs e)
    {
        try
        {
            //if (gv_learningskills.Rows.Count > 0)
            //{
            //    gv_learningskills.UseAccessibleHeader = false;
            //    gv_learningskills.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void Bind_Learning_skill_Grid()
    {
        try
        {
            DataTable dt_All_PS = new DataTable();
            dt_All_PS = objSiqa.Get_PS_Indicators(int.Parse(ddl_grouphead.SelectedValue.ToString()));
            if (dt_All_PS != null)
            {
                if (dt_All_PS.Rows.Count > 0)
                {

                    #region PS1
                    DataRow[] _PS1 = dt_All_PS.Select("PS_ID = 1");
                    if (dt_All_PS.Rows.Count == 0)
                    {
                        //trSearch.Visible = false;
                        //PS1Container.Visible = false;
                    }
                    else
                    {
                        //PS1Container.Visible = true;
                        int LSI = 0;    //LSI=Learning skill Indicator
                                        //int AI = 0;     //AI= Attainment Indicator
                        DataTable dtsubjects = new DataTable();
                        DataTable dtsubjects_indicator2 = new DataTable();
                        for (int i = 0; i < _PS1.Length; i++)
                        {

                            if (_PS1[i]["INDICATOR_NAME"].ToString().Trim() == "LEARNING SKILLS" && LSI == 0)
                            {
                                DataTable dtlovs = new DataTable();
                                dtlovs = objSiqa.Get_Lovs_Against_Indicator_ID(int.Parse(_PS1[i]["PSI_ID"].ToString().Trim()), Convert.ToInt32(ddl_grouphead.SelectedValue));

                                dtlovs = null;
                                LSI = 1;

                            }

                            if (_PS1[i]["INDICATOR_NAME"].ToString().Trim() == "ATTAINMENT")
                            {

                                dtsubjects = EvaluationGETSubject(ddl_grouphead.SelectedValue, ddl_center.SelectedValue, ddl_Session.SelectedValue);
                                DataColumn dcolColumn = new DataColumn("PSI_ID", typeof(int));
                                DataColumn dcolColumn2 = new DataColumn("INDICATOR_NAME", typeof(string));
                                dtsubjects.Columns.Add(dcolColumn);
                                dtsubjects.Columns.Add(dcolColumn2);

                                foreach (DataRow row in dtsubjects.Rows)
                                {

                                    row["PSI_ID"] = _PS1[i]["PSI_ID"].ToString().Trim();
                                    row["INDICATOR_NAME"] = _PS1[i]["INDICATOR_NAME"].ToString().Trim();
                                }

                            }

                            if (_PS1[i]["INDICATOR_NAME"].ToString().Trim() == "PROGRESS")
                            {

                                dtsubjects_indicator2 = EvaluationGETSubject(ddl_grouphead.SelectedValue, ddl_center.SelectedValue, ddl_Session.SelectedValue);
                                DataColumn dcolColumn = new DataColumn("PSI_ID", typeof(int));
                                DataColumn dcolColumn2 = new DataColumn("INDICATOR_NAME", typeof(string));
                                dtsubjects_indicator2.Columns.Add(dcolColumn);
                                dtsubjects_indicator2.Columns.Add(dcolColumn2);
                                foreach (DataRow row in dtsubjects_indicator2.Rows)
                                {
                                    row["PSI_ID"] = _PS1[i]["PSI_ID"].ToString().Trim();
                                    row["INDICATOR_NAME"] = _PS1[i]["INDICATOR_NAME"].ToString().Trim();
                                }
                            }

                        }
                        //dtsubjects.Merge(dtsubjects_indicator2);
                        //dtsubjects.AcceptChanges();

                        gvps1child.DataSource = dtsubjects;
                        gvps1child.DataBind();
                        dtsubjects.Dispose();
                    }
                    #endregion PS1

                    var _PS2 = dt_All_PS.Select("PS_ID = 2").CopyToDataTable();
                    //if (_PS2.Rows.Count > 0)
                    //{
                    //    ps2GridView.DataSource = _PS2;
                    //    ps2GridView.DataBind();
                    //}
                    //else
                    //{
                    //    ps2GridView.DataSource = null;
                    //    ps2GridView.DataBind();
                    //}

                    var _PS3 = dt_All_PS.Select("PS_ID = 3").CopyToDataTable();
                    //if (_PS3.Rows.Count > 0)
                    //{
                    //    ps3GridView.DataSource = _PS3;
                    //    ps3GridView.DataBind();
                    //}
                    //else
                    //{
                    //    ps3GridView.DataSource = null;
                    //    ps3GridView.DataBind();
                    //}

                    var _PS4 = dt_All_PS.Select("PS_ID = 4").CopyToDataTable();
                    //if (_PS4.Rows.Count > 0)
                    //{
                    //    ps4GridView.DataSource = _PS4;
                    //    ps4GridView.DataBind();
                    //}
                    //else
                    //{
                    //    ps4GridView.DataSource = null;
                    //    ps4GridView.DataBind();
                    //}

                    var _PS5 = dt_All_PS.Select("PS_ID = 5").CopyToDataTable();
                    //if (_PS5.Rows.Count > 0)
                    //{
                    //    ps5GridView.DataSource = _PS5;
                    //    ps5GridView.DataBind();
                    //}
                    //else
                    //{
                    //    ps5GridView.DataSource = null;
                    //    ps5GridView.DataBind();
                    //}

                    var _PS6 = dt_All_PS.Select("PS_ID = 6").CopyToDataTable();
                    //if (_PS6.Rows.Count > 0)
                    //{
                    //    ps6GridView.DataSource = _PS6;
                    //    ps6GridView.DataBind();
                    //}
                    //else
                    //{
                    //    ps6GridView.DataSource = null;
                    //    ps6GridView.DataBind();
                    //}

                }
                else
                {
                    ImpromptuHelper.ShowPrompt("No Data Found");
                }

            }
            else
            {
                ImpromptuHelper.ShowPrompt("No Data Found");
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCancelHistory_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["studentDT"] = null;
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
            DataRow userrow = (DataRow)Session["rightsRow"];

            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox ch = (CheckBox)row.Cells[13].Controls[1];
                if (row.Cells[9].Text != "Applicant")
                {
                    ch.Enabled = false;
                    ch.Checked = true;
                }
                if (!Convert.ToBoolean(userrow["Center"].ToString()))
                {
                    ch.Enabled = false;
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
            //if (list_region.SelectedValue == "")
            //{
            //    list_center.Items.Clear();
            //    list_center.Items.Insert(0, new ListItem("Select", ""));
            //}
            //if (UL_ID == 10)//Load Network specifc centers
            //{
            //    BLLNetworkCenter objnet = new BLLNetworkCenter();
            //    objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            //    DataTable dt = new DataTable();
            //    dt = objnet.NetworkCenterSelectByUserID(objnet);
            //    objBase.FillDropDown(dt, list_center, "Center_Id", "Center_Name");
            //}
            //else
            //{
            if (UL_ID == 4)  //counselors
            {
                BLLUploadEducationalArchive objCen = new BLLUploadEducationalArchive();
                //int Region_Id = Int32.Parse(list_region.SelectedValue);   //2023-10-17
                int User_ID = Convert.ToInt32(Session["ContactID"].ToString());
                //DataTable dt = objCen.CenterSelectByCounselor(User_ID, Region_Id);
                //objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
            }
            else
            {
                BLLUploadEducationalArchive objCen = new BLLUploadEducationalArchive();
                // int Region_Id = Int32.Parse(list_region.SelectedValue);
                // DataTable dt = objCen.CenterSelectByRegionIDfor_Alumni(Region_Id);//2023-10-17
                // objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
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



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void GotoPage(LinkButton lb)
    {

        try
        {

            ViewState["page_number"] = lb.CommandArgument;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void GotoWindowFirstPage(LinkButton lb)
    {
        try
        {
            if (lb.CommandArgument != "1")
            {
                MoveWindowBack();

                ViewState["page_number"] = lb.CommandArgument;
            }
            else
                ViewState["page_number"] = 1;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void MoveWindowForward()
    {
        try
        {
            int windowEnd = Int32.Parse(ViewState["window_end"].ToString());

            windowEnd = windowWidth + windowEnd - 1;
            ViewState["window_end"] = windowEnd;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void MoveWindowBack()
    {
        try
        {
            int windowEnd = Int32.Parse(ViewState["window_end"].ToString());

            windowEnd = windowEnd - windowWidth + 1;

            if (windowEnd < windowWidth)
                windowEnd = windowWidth;

            ViewState["window_end"] = windowEnd;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void ExportToSpreadsheet(DataTable table, string name)
    {


        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + "\t");

        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(",", string.Empty) + "\t");
            }

            context.Response.Write(Environment.NewLine);
        }

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename = " + name + ".xls");



        context.Response.Flush();
        context.Response.SuppressContent = true;
        context.ApplicationInstance.CompleteRequest();


        ////////////context.Response.End();



    }
    private void BindGridSummary(int section, int studentid, int session, int term)
    {

        try
        {
            BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

            DataTable dtsub = new DataTable();
            objClsSec.Section_Id = Convert.ToInt32(section);
            objClsSec.Evaluation_Criteria_Type_Id = term;
            objClsSec.Session_Id = session;
            objClsSec.Student_Id = Convert.ToInt32(studentid);
            dtsub = objClsSec.Result_ByEmployeeCenterWise(objClsSec);
            ViewState["Table"] = dtsub;
            if (dtsub.Rows.Count > 0)
            {
                //trresultSummary.Visible = true;
                // dv_details.DataSource = dtsub;
                // dv_details.DataBind();
            }



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void ResetFilterBifurcation()
    {
        try
        {
            Bind_Learning_skill_Grid();
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

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //***************************************************************************************************************
    DataTable ExecuteProcedure(string sAction, string Class_ID, string Region_ID)
    {

        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_CampusSubjectCommentsCorrection");
        obj_Access.AddParameter("P_optional1", Class_ID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_optional2", Region_ID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    //load Grades 

    DataSet ExecuteProcedureGrade(int centerID, string ksVal)
    {

        DataSet DT_Data = null;
        //obj_Access.CreateProcedureCommand("SP_SIQA_SEF_evalution");
        //obj_Access.AddParameter("centerID", centerID, DataAccess.SQLParameterType.Number, true);
        //obj_Access.AddParameter("KS_Value", ksVal, DataAccess.SQLParameterType.VarChar, true);
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@centerID", centerID);
        param[1] = new SqlParameter("@Session_ID", Session["Session_Id"].ToString());
        param[2] = new SqlParameter("@KS_Value", ksVal);//Session["Session_Id"].ToString()

        try
        {
            // DT_Data = objBase.sqlcmdFetch_DS("SP_SIQA_SEF_evalution", param);
            DT_Data = objBase.sqlcmdFetch_DS("SP_SIQA_SEF_evalution_From_Night_Job_Data", param);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    DataTable ExecuteProcedureSEF_PS1_KS_4_5(int centerID)
    {

        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("Sp_SIQA_SEF_PS1_KS4_KS5");
        obj_Access.AddParameter("centerID", centerID, DataAccess.SQLParameterType.Number, true);
        // obj_Access.AddParameter("subjectID", subjectID, DataAccess.SQLParameterType.VarChar, true);
        // obj_Access.AddParameter("ClassId", ClassId, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    private void loadRegions()
    {
        try
        {
            //string q = Request.QueryString["id"];
            //string s = Request.QueryString["id"];

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            // BindCheckBoxListControl(dt, lstRegion, "Region_Id", "Region_Name");
            ////////////UserInformationGrid2.SetData(dt);

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
            //Call_All_Performance_Standard();
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
            objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            DataRow row = (DataRow)Session["rightsRow"];

            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
            {
                ddl_center.SelectedValue = row["Center_Id"].ToString();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvps1child_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label subject = e.Row.FindControl("lblsubject") as Label;
            Label subjectid = e.Row.FindControl("lblsubjectid") as Label;
            DataTable dt = new DataTable();
            if (_dtGrade == null)
            {
                _dtGrade = ExecuteProcedureGrade(int.Parse(ddl_center.SelectedItem.Value), ddl_grouphead.SelectedItem.Text);
            }
            DataTable dtformulalo = new DataTable();
            DataTable dtformulaNb = new DataTable();
            DataTable dtPS5_2_3 = new DataTable();
            BLLSiqa obj = new BLLSiqa();
            dt = obj.SEF_PS1_CHILD_GET_DATA(ddl_region.SelectedValue, ddl_center.SelectedValue, ddl_grouphead.SelectedValue, subject.Text.ToString().Trim(), ddl_Session.SelectedValue.ToString());
            //DropDownList Attainment_grade2 = e.Row.FindControl("ddl_1_1_2_grade") as DropDownList;
            DropDownList ddl_1_1_1_grade = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
            DropDownList Attainment_grade2 = e.Row.FindControl("ddl_1_1_2_grade") as DropDownList;
            DropDownList Progress_grade2 = e.Row.FindControl("ddl_1_2_2_grade") as DropDownList;
            DropDownList ddl_1_1_2 = e.Row.FindControl("ddl_1_1_2_grade") as DropDownList;
            DropDownList ddl_1_1_3 = e.Row.FindControl("ddl_1_1_3_grade") as DropDownList;
            DropDownList ddl_1_2_1_grade = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;
            if (dt.Rows.Count > 0)
            {
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (subject.Text.ToString().Trim() == dt.Rows[i]["Subject_Name"].ToString().Trim())
                        {
                            DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
                            DropDownList Attainment_overall_grade = e.Row.FindControl("ddl_1_1_overall_grade") as DropDownList;
                            DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;
                            DropDownList Progress_overall_grade = e.Row.FindControl("ddl_1_2_overall_grade") as DropDownList;
                            DropDownList Attainment_grade3 = e.Row.FindControl("ddl_1_1_3_grade") as DropDownList;


                            Attainment_grade1.SelectedValue = dt.Rows[i]["Attainment_grade1"].ToString().Trim();
                            Attainment_overall_grade.SelectedValue = dt.Rows[i]["Attainment_overall_grade"].ToString().Trim();
                            Progress_grade1.SelectedValue = dt.Rows[i]["Progress_grade1"].ToString().Trim();
                            Progress_overall_grade.SelectedValue = dt.Rows[i]["Progress_overall_grade"].ToString().Trim();
                            Attainment_grade2.SelectedValue = dt.Rows[i]["Attainment_grade2"].ToString().Trim();
                            Progress_grade2.SelectedValue = dt.Rows[i]["Progress_grade2"].ToString().Trim();
                            Attainment_grade3.SelectedValue = dt.Rows[i]["Attainment_grade3"].ToString().Trim();
                        }
                    }
                }
            }
            //  SR Work Start
            if (ddl_grouphead.SelectedIndex == 1 || ddl_grouphead.SelectedIndex == 2)
            {

                if (_dtGrade != null)
                {
                    if (_dtGrade.Tables.Count >= 1)
                    {
                        for (int i = 0; i < _dtGrade.Tables[0].Rows.Count; i++)
                        {
                            DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
                            // DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                            float expected = float.Parse(_dtGrade.Tables[0].Rows[i]["Exp"].ToString());
                            float exceeded = float.Parse(_dtGrade.Tables[0].Rows[i]["Exc"].ToString());

                            if (subject.Text.ToString().Trim() == _dtGrade.Tables[0].Rows[i]["Subject_Name"].ToString().Trim())
                            {
                                if (expected + exceeded >= 90)
                                {
                                    Attainment_grade1.SelectedValue = "OS";
                                    Attainment_grade1.Enabled = false;
                                }
                                else if (expected + exceeded >= 75)
                                {
                                    Attainment_grade1.SelectedValue = "Good";
                                    Attainment_grade1.Enabled = false;
                                }
                                else if (expected + exceeded >= 61)
                                {
                                    Attainment_grade1.SelectedValue = "Acc";
                                    Attainment_grade1.Enabled = false;
                                }

                                else if (expected > 39 && expected < 60)
                                {
                                    Attainment_grade1.SelectedValue = "UA";
                                    Attainment_grade1.Enabled = false;
                                }
                                else
                                {
                                    Attainment_grade1.SelectedValue = "Acc";
                                    Attainment_grade1.Enabled = false;
                                }
                            }
                        }

                    }
                    if (_dtGrade.Tables.Count >= 2)
                    {
                        for (int i = 0; i < _dtGrade.Tables[1].Rows.Count; i++)
                        {

                            DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                            float Aboveexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_AboveExpected"].ToString());
                            float expected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_Expected"].ToString());
                            float Belowexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_BelowExpected"].ToString());

                            if (subject.Text.ToString().ToLower().Trim().Contains(_dtGrade.Tables[1].Rows[i]["Subject_Name"].ToString().ToLower()))
                            {
                                // if (Belowexpected > 25)
                                //{
                                //    Progress_grade1.SelectedValue = "UA";
                                //    Progress_grade1.Enabled = false;
                                //}
                                //else if ((expected + Aboveexpected) >= 75)
                                //{
                                //    Progress_grade1.SelectedValue = "Acc";
                                //    Progress_grade1.Enabled = false;
                                //}
                                //else if ((expected + Aboveexpected) >= 61 && (expected + Aboveexpected) < 75)
                                //{
                                //    Progress_grade1.SelectedValue = "Good";
                                //    Progress_grade1.Enabled = false;
                                //}
                                //else if (Aboveexpected >= 75)
                                //{
                                //    Progress_grade1.SelectedValue = "OS";
                                //    Progress_grade1.Enabled = false;
                                //}


                                if (Aboveexpected >= 75)
                                {
                                    Progress_grade1.SelectedValue = "OS";
                                    Progress_grade1.Enabled = false;
                                }
                                else if (Belowexpected > 25)
                                {
                                    Progress_grade1.SelectedValue = "UA";
                                    Progress_grade1.Enabled = false;
                                }
                                else if (Aboveexpected >= 61 && Aboveexpected < 75)
                                {
                                    Progress_grade1.SelectedValue = "Good";
                                    Progress_grade1.Enabled = false;
                                }
                                else if ((expected + Aboveexpected) >= 75)
                                {
                                    Progress_grade1.SelectedValue = "Acc";
                                    Progress_grade1.Enabled = false;
                                }
                                else
                                {
                                    Progress_grade1.SelectedValue = "Acc";
                                    Progress_grade1.Enabled = false;
                                }

                            }

                        }
                    }
                    if (_dtGrade.Tables.Count >= 3)
                    {
                        for (int i = 0; i < _dtGrade.Tables[2].Rows.Count; i++)
                        {

                            DropDownList Progress_grade113 = e.Row.FindControl("ddl_1_1_3_grade") as DropDownList;

                            //float Session_Id = float.Parse(_dtGrade.Tables[2].Rows[i]["Session_Id"].ToString());
                            string Curr_Grade = _dtGrade.Tables[2].Rows[i]["CurrentGrade"].ToString();
                            string Last_Grade1 = _dtGrade.Tables[2].Rows[i]["LastGrade1"].ToString();
                            string Last_Grade2 = _dtGrade.Tables[2].Rows[i]["LastGrade2"].ToString();
                            string Last_Grade3 = _dtGrade.Tables[2].Rows[i]["LastGrade3"].ToString();
                            int Subject_Id = int.Parse(_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString());

                            if (subject.Text.ToString().ToLower().Trim().Contains(_dtGrade.Tables[2].Rows[i]["Subject_Name"].ToString().ToLower()))
                            {
                                if (Curr_Grade == "Good")
                                {
                                    if (Curr_Grade == "Good" && Last_Grade1 != "UA" && Last_Grade2 != "UA" && Last_Grade3 != "UA")
                                    {
                                        Progress_grade113.SelectedValue = "Good";
                                        Progress_grade113.Enabled = false;
                                    }
                                    else
                                    {
                                        Progress_grade113.SelectedValue = "Acc";
                                        Progress_grade113.Enabled = false;
                                    }
                                }

                                else if (Curr_Grade == "OS")
                                {
                                    if (Curr_Grade == "OS" && (Last_Grade1 == "Good" || Last_Grade1 == "OS" || Last_Grade1 == "") && (Last_Grade2 == "Good" || Last_Grade2 == "OS" || Last_Grade2 == "") && (Last_Grade3 == "Good" || Last_Grade3 == "OS" || Last_Grade3 == ""))
                                    {
                                        Progress_grade113.SelectedValue = "OS";
                                        Progress_grade113.Enabled = false;
                                    }
                                    else
                                    {
                                        Progress_grade113.SelectedValue = "Acc";
                                        Progress_grade113.Enabled = false;
                                    }
                                }
                                else if (Curr_Grade == "UA")
                                {
                                    Progress_grade113.SelectedValue = "UA";
                                    Progress_grade113.Enabled = false;
                                }
                                else if (Curr_Grade == "Acc")
                                {
                                    Progress_grade113.SelectedValue = "Acc";
                                    Progress_grade113.Enabled = false;
                                }


                                //if (Curr_Grade == "Good" && Last_Grade1 != "UA" && Last_Grade2 != "UA" && Last_Grade3 != "UA")
                                //{
                                //    Progress_grade113.SelectedValue = "Good";
                                //    Progress_grade113.Enabled = false;
                                //}
                                //else if (Curr_Grade == "OS" && (Last_Grade1 == "Good" || Last_Grade1 == "OS" || Last_Grade1 == "") && (Last_Grade2 == "Good" || Last_Grade2 == "OS" || Last_Grade2 == "") && (Last_Grade3 == "Good" || Last_Grade3 == "OS" || Last_Grade3 == ""))
                                //{
                                //    Progress_grade113.SelectedValue = "OS";
                                //    Progress_grade113.Enabled = false;
                                //}
                                //else if (Curr_Grade == "UA")
                                //{
                                //    Progress_grade113.SelectedValue = "UA";
                                //    Progress_grade113.Enabled = false;
                                //}
                                //else if (Curr_Grade == "Acc")
                                //{
                                //    Progress_grade113.SelectedValue = "Acc";
                                //    Progress_grade113.Enabled = false;
                                //}
                            }
                        }
                    }
                }
            }

            if (ddl_grouphead.SelectedIndex == 3 || ddl_grouphead.SelectedIndex == 4)
            {
                if (_dtGrade != null)
                {

                    for (int i = 0; i < _dtGrade.Tables[0].Rows.Count; i++)
                    {
                        DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
                        DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                        float A_B_Urdu = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_A1_A_B"].ToString());
                        float C_Urdu = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_C"].ToString());
                        float D_E_U_Urdu = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_D_E_U"].ToString());


                        if (subject.Text.ToString().Trim() == _dtGrade.Tables[0].Rows[i]["Subject_Name"].ToString().Trim()) // add science later
                        {

                            if (A_B_Urdu >= 75 && D_E_U_Urdu <= 10)
                            {
                                Attainment_grade1.SelectedValue = "OS";
                                Attainment_grade1.Enabled = false;
                            }
                            else if (A_B_Urdu >= 61 && D_E_U_Urdu <= 10)
                            {
                                Attainment_grade1.SelectedValue = "Good";
                                Attainment_grade1.Enabled = false;
                            }
                            else if (C_Urdu + A_B_Urdu >= 75)
                            {
                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                            else if (D_E_U_Urdu > 25)
                            {
                                Attainment_grade1.SelectedValue = "UA";
                                Attainment_grade1.Enabled = false;
                            }
                            else
                            {
                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                        }
                    }

                    for (int i = 0; i < _dtGrade.Tables[1].Rows.Count; i++)
                    {

                        DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                        float Aboveexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_AboveExpected"].ToString());
                        float expected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_Expected"].ToString());
                        float Belowexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_BelowExpected"].ToString());

                        if (subject.Text.ToString().ToLower().Trim().Contains(_dtGrade.Tables[1].Rows[i]["Subject_Name"].ToString().ToLower()))
                        {
                            if (Aboveexpected >= 75)
                            {
                                Progress_grade1.SelectedValue = "OS";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Belowexpected > 25)
                            {
                                Progress_grade1.SelectedValue = "UA";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Aboveexpected >= 61 && Aboveexpected < 75)
                            {
                                Progress_grade1.SelectedValue = "Good";
                                Progress_grade1.Enabled = false;
                            }
                            else if ((expected + Aboveexpected) >= 75)
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }

                            else
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }
                        }

                    }
                    for (int i = 0; i < _dtGrade.Tables[2].Rows.Count; i++)
                    {

                        DropDownList Progress_grade113 = e.Row.FindControl("ddl_1_1_3_grade") as DropDownList;

                        //float Session_Id = float.Parse(_dtGrade.Tables[2].Rows[i]["Session_Id"].ToString());
                        string Curr_Grade = _dtGrade.Tables[2].Rows[i]["CurrentGrade"].ToString();
                        string Last_Grade1 = _dtGrade.Tables[2].Rows[i]["LastGrade1"].ToString();
                        string Last_Grade2 = _dtGrade.Tables[2].Rows[i]["LastGrade2"].ToString();
                        string Last_Grade3 = _dtGrade.Tables[2].Rows[i]["LastGrade3"].ToString();
                        int Subject_Id = int.Parse(_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString());



                        if (_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString() == subjectid.Text.ToString())     //2024-09-26 changed variable Subject_id
                        //if (_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString() == Convert.ToString(Subject_Id))
                        {
                            ////****
                            //if ((subjectid.Text.ToString().Trim() == "14"))
                            //{
                            //    string a = "";
                            //}
                            ////****

                            if (Curr_Grade == "Good" && Last_Grade1 != "UA" && Last_Grade2 != "UA" && Last_Grade3 != "UA")
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "Good" && (Last_Grade1 == "UA" || Last_Grade2 == "UA" || Last_Grade3 == "UA"))
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "Good" || Last_Grade1 == "OS" || Last_Grade1 == "") && (Last_Grade2 == "Good" || Last_Grade2 == "OS" || Last_Grade2 == "") && (Last_Grade3 == "Good" || Last_Grade3 == "OS" || Last_Grade3 == ""))
                            {
                                Progress_grade113.SelectedValue = "OS";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "Acc" || Last_Grade2 == "Acc" || Last_Grade3 == "Acc"))
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "UA" || Last_Grade2 == "UA" || Last_Grade3 == "UA"))
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "UA")
                            {
                                Progress_grade113.SelectedValue = "UA";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "Acc")
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                        }

                        else if (_dtGrade.Tables[2].Rows[i]["Subject_Name"].ToString().ToLower().Contains(subject.Text.ToString().ToLower().Trim()))
                        {


                            if (Curr_Grade == "Good" && Last_Grade1 != "UA" && Last_Grade2 != "UA" && Last_Grade3 != "UA")
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "Good" && (Last_Grade1 == "UA" || Last_Grade2 == "UA" || Last_Grade3 == "UA"))
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "Good" || Last_Grade1 == "OS" || Last_Grade1 == "") && (Last_Grade2 == "Good" || Last_Grade2 == "OS" || Last_Grade2 == "") && (Last_Grade3 == "Good" || Last_Grade3 == "OS" || Last_Grade3 == ""))
                            {
                                Progress_grade113.SelectedValue = "OS";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "Acc" || Last_Grade2 == "Acc" || Last_Grade3 == "Acc"))
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "OS" && (Last_Grade1 == "UA" || Last_Grade2 == "UA" || Last_Grade3 == "UA"))
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "UA")
                            {
                                Progress_grade113.SelectedValue = "UA";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Curr_Grade == "Acc")
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                        }
                    }
                }
            }

            if (ddl_grouphead.SelectedIndex == 5 || ddl_grouphead.SelectedIndex == 6)
            {
                string Curr_Grade = "";
                if (_dtGrade != null)
                {
                    for (int i = 0; i < _dtGrade.Tables[0].Rows.Count; i++)
                    {
                        string subjectName = _dtGrade.Tables[0].Rows[i]["Subject"].ToString();
                        float A_1_A_B = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_A1_A_B"].ToString());
                        float C = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_C"].ToString());
                        float DEU = float.Parse(_dtGrade.Tables[0].Rows[i]["grade_D_E_U"].ToString());


                        if (_dtGrade.Tables[0].Rows[i]["Subject_Id"].ToString() == subjectid.Text.ToString()) // (subject.Text.ToString().ToLower().Trim() == subjectName.ToLower().Trim()) // add science later || subject.Text.ToString().Trim() == "Mathematics" || subject.Text.ToString().Trim() == "English"
                        {
                            DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
                            DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;


                            if ((A_1_A_B) >= 75 && (DEU) <= 10)
                            {

                                Attainment_grade1.SelectedValue = "OS";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((A_1_A_B) >= 61 && (DEU) <= 15)
                            {

                                Attainment_grade1.SelectedValue = "Good";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((C + A_1_A_B) >= 75)
                            {

                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((DEU) > 25)
                            {

                                Attainment_grade1.SelectedValue = "UA";
                                Attainment_grade1.Enabled = false;
                            }

                            else
                            {

                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                            break;
                        }
                        else if (subjectName.ToLower() == subject.Text.ToString().ToLower()) // add science later || subject.Text.ToString().Trim() == "Mathematics" || subject.Text.ToString().Trim() == "English"
                        {
                            DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;
                            DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                            if ((A_1_A_B) >= 75 && (DEU) <= 10)
                            {

                                Attainment_grade1.SelectedValue = "OS";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((A_1_A_B) >= 61 && (DEU) <= 15)
                            {

                                Attainment_grade1.SelectedValue = "Good";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((C + A_1_A_B) >= 75)
                            {

                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                            else if ((DEU) > 25)
                            {

                                Attainment_grade1.SelectedValue = "UA";
                                Attainment_grade1.Enabled = false;
                            }

                            else
                            {

                                Attainment_grade1.SelectedValue = "Acc";
                                Attainment_grade1.Enabled = false;
                            }
                            break;
                        }

                    }

                    for (int i = 0; i < _dtGrade.Tables[1].Rows.Count; i++)
                    {

                        DropDownList Progress_grade1 = e.Row.FindControl("ddl_1_2_1_grade") as DropDownList;

                        float Aboveexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_AboveExpected"].ToString());
                        float expected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_Expected"].ToString());
                        float Belowexpected = float.Parse(_dtGrade.Tables[1].Rows[i]["progress_BelowExpected"].ToString());
                        string subjectname = _dtGrade.Tables[1].Rows[i]["Subject_Id"].ToString();

                        if (_dtGrade.Tables[1].Rows[i]["Subject_Id"].ToString() == subjectid.Text.ToString())
                        {

                            // if (Belowexpected > 25)
                            // {
                            //     Progress_grade1.SelectedValue = "UA";
                            //     Progress_grade1.Enabled = false;
                            // }
                            //else if ((expected + Aboveexpected) >= 75)
                            // {
                            //     Progress_grade1.SelectedValue = "Acc";
                            //     Progress_grade1.Enabled = false;
                            // }
                            //else if (Aboveexpected >= 61 && Aboveexpected < 75)
                            // {
                            //     Progress_grade1.SelectedValue = "Good";
                            //     Progress_grade1.Enabled = false;
                            // }
                            //else if (Aboveexpected >= 75)
                            // {
                            //     Progress_grade1.SelectedValue = "OS";
                            //     Progress_grade1.Enabled = false;
                            // }



                            if (Aboveexpected >= 75)
                            {
                                Progress_grade1.SelectedValue = "OS";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Belowexpected > 25)
                            {
                                Progress_grade1.SelectedValue = "UA";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Aboveexpected >= 61 && Aboveexpected < 75)
                            {
                                Progress_grade1.SelectedValue = "Good";
                                Progress_grade1.Enabled = false;
                            }
                            else if ((expected + Aboveexpected) >= 75)
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }
                            else
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }


                        }

                        else if (_dtGrade.Tables[1].Rows[i]["Subject"].ToString().ToLower() == subject.Text.ToString().ToLower().ToLower())
                        {


                            //if (Belowexpected > 25)
                            //{
                            //    Progress_grade1.SelectedValue = "UA";
                            //    Progress_grade1.Enabled = false;
                            //}
                            //else if ((expected + Aboveexpected) >= 75)
                            //{
                            //    Progress_grade1.SelectedValue = "Acc";
                            //    Progress_grade1.Enabled = false;
                            //}
                            //else if (Aboveexpected >= 61 && Aboveexpected < 75)
                            //{
                            //    Progress_grade1.SelectedValue = "Good";
                            //    Progress_grade1.Enabled = false;
                            //}
                            //else if (Aboveexpected >= 75)
                            //{
                            //    Progress_grade1.SelectedValue = "OS";
                            //    Progress_grade1.Enabled = false;
                            //}


                            if (Aboveexpected >= 75)
                            {
                                Progress_grade1.SelectedValue = "OS";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Belowexpected > 25)
                            {
                                Progress_grade1.SelectedValue = "UA";
                                Progress_grade1.Enabled = false;
                            }
                            else if (Aboveexpected >= 61 && Aboveexpected < 75)
                            {
                                Progress_grade1.SelectedValue = "Good";
                                Progress_grade1.Enabled = false;
                            }
                            else if ((expected + Aboveexpected) >= 75)
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }
                            else
                            {
                                Progress_grade1.SelectedValue = "Acc";
                                Progress_grade1.Enabled = false;
                            }

                        }
                    }

                    for (int i = 0; i < _dtGrade.Tables[2].Rows.Count; i++)
                    {

                        DropDownList Progress_grade113 = e.Row.FindControl("ddl_1_1_3_grade") as DropDownList;

                        //float Session_Id = float.Parse(_dtGrade.Tables[2].Rows[i]["Session_Id"].ToString());

                        float grade_A1_A_B = float.Parse(_dtGrade.Tables[2].Rows[i]["grade_A1_A_B"].ToString());
                        float grade_C = float.Parse(_dtGrade.Tables[2].Rows[i]["grade_C"].ToString());
                        float grade_D_E_U = float.Parse(_dtGrade.Tables[2].Rows[i]["grade_D_E_U"].ToString());
                        int Subject_Id = int.Parse(_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString());
                        DropDownList Attainment_grade1 = e.Row.FindControl("ddl_1_1_1_grade") as DropDownList;

                        string Prev_grade = "Acc";
                        if (_dtGrade.Tables[2].Rows[i]["Subject_Id"].ToString() == subjectid.Text.ToString())
                        {
                            if ((grade_A1_A_B) >= 75 && (grade_D_E_U) <= 10)
                            {
                                Prev_grade = "OS";

                            }
                            else if ((grade_A1_A_B) >= 61 && (grade_D_E_U) <= 15)
                            {
                                Prev_grade = "Good";

                            }
                            else if ((grade_C + grade_A1_A_B) >= 75)
                            {
                                Prev_grade = "Acc";

                            }
                            else if ((grade_D_E_U) > 25)
                            {
                                Prev_grade = "UA";

                            }

                            else
                            {
                                Prev_grade = "Acc";

                            }



                            if (Attainment_grade1.SelectedItem.Text == "Good" && Prev_grade != "UA")
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "OS" && (Prev_grade == "Good" || Prev_grade == "OS"))
                            {
                                Progress_grade113.SelectedValue = "OS";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "UA")
                            {
                                Progress_grade113.SelectedValue = "UA";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "Acc")
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }


                        }
                        else if (_dtGrade.Tables[2].Rows[i]["Subject"].ToString().ToLower() == subject.Text.ToString().ToLower().ToLower())
                        {

                            if ((grade_A1_A_B) >= 75 && (grade_D_E_U) <= 10)
                            {
                                Prev_grade = "OS";

                            }
                            else if ((grade_A1_A_B) >= 61 && (grade_D_E_U) <= 15)
                            {
                                Prev_grade = "Good";

                            }
                            else if ((grade_C + grade_A1_A_B) >= 75)
                            {
                                Prev_grade = "Acc";

                            }
                            else if ((grade_D_E_U) > 25)
                            {
                                Prev_grade = "UA";

                            }

                            else
                            {
                                Prev_grade = "Acc";

                            }



                            if (Attainment_grade1.SelectedItem.Text == "Good" && Prev_grade != "UA")
                            {
                                Progress_grade113.SelectedValue = "Good";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "OS" && (Prev_grade == "Good" || Prev_grade == "OS"))
                            {
                                Progress_grade113.SelectedValue = "OS";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "UA")
                            {
                                Progress_grade113.SelectedValue = "UA";
                                Progress_grade113.Enabled = false;
                            }
                            else if (Attainment_grade1.SelectedItem.Text == "Acc")
                            {
                                Progress_grade113.SelectedValue = "Acc";
                                Progress_grade113.Enabled = false;
                            }
                        }
                    }
                }
            }

            //  SR Work End

            //***************************************Code Here***************************

            //For Formula based values rebinding LO New
            dtformulalo = obj.SEF_PS1_CHILD_GET_DATA_FROM_FORMULA(ddl_region.SelectedValue, ddl_center.SelectedValue, ddl_grouphead.SelectedItem.Text.ToString(), subject.Text.ToString().Trim());
            if (dtformulalo.Rows.Count > 0)
            {
                if (dtformulalo != null)
                {
                    for (int i = 0; i < dtformulalo.Rows.Count; i++)
                    {
                        if (subject.Text.ToString().Trim() == dtformulalo.Rows[i]["Subject_Name"].ToString().Trim())
                        {
                            if (dtformulalo.Rows[i]["Student_Progress_Grade_Final"].ToString().Trim() != "NA")
                            {
                                Progress_grade2.SelectedValue = dtformulalo.Rows[i]["Student_Progress_Grade_Final"].ToString().Trim();
                                Progress_grade2.Enabled = false;
                            }
                            else
                            {
                                Progress_grade2.Enabled = true;
                            }
                        }
                    }
                }

            }


            //*****************For Formula based values rebinding NB***************************
            dtformulaNb = obj.SEF_PS1_CHILD_GET_DATA_FROM_FORMULA_NB(ddl_region.SelectedValue, ddl_center.SelectedValue, ddl_grouphead.SelectedItem.Text.ToString(), subject.Text.ToString().Trim());
            if (dtformulaNb.Rows.Count > 0)
            {
                if (dtformulaNb != null)
                {
                    for (int i = 0; i < dtformulaNb.Rows.Count; i++)
                    {
                        if (subject.Text.ToString().Trim() == dtformulaNb.Rows[i]["Subject_Name"].ToString().Trim())
                        {
                            if (dtformulaNb.Rows[i]["Knowledge_Skills_1_1_2_Grade_final"].ToString().Trim() != "NA")
                            {
                                Attainment_grade2.SelectedValue = dtformulaNb.Rows[i]["Knowledge_Skills_1_1_2_Grade_final"].ToString().Trim();
                                Attainment_grade2.Enabled = false;
                            }
                            else
                            {
                                Attainment_grade2.Enabled = true;
                            }
                        }
                    }
                }

            }


            ddl_1_1_2.Enabled = false;
            ddl_1_1_1_grade.Enabled = false;
            ddl_1_1_3.Enabled = false;
            ddl_1_2_1_grade.Enabled = false;
            Attainment_grade2.Enabled = false;
            Progress_grade2.Enabled = false;


            if (ddl_grouphead.SelectedValue == "7")
            {
                ddl_1_1_1_grade.Enabled = true;
                ddl_1_1_3.Enabled = true;
                ddl_1_2_1_grade.Enabled = true;
                ddl_5_2_3_grade.Enabled = true;

            }

            dt = null;
            dtformulalo = null;
            dtformulaNb = null;
            dtPS5_2_3 = null;

            if (ddl_grouphead.SelectedItem.Text == "KS5")
            {
                Attainment_grade2.Enabled = true;
                ddl_1_1_2.Enabled = true;
                Progress_grade2.Enabled = true;
            }
            else
            {
                Attainment_grade2.Enabled = false;
                ddl_1_1_2.Enabled = false;
                Progress_grade2.Enabled = false;
            }

        }
    }
    DataTable EvaluationGETSubject(string GroupID, string center_id, string Session_ID)
    {

        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_SEF_Evaluation_GET_Subject");
        obj_Access.AddParameter("GroupID", GroupID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Center_ID", center_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Session_ID", Session_ID, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    protected void ddl_grouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = false;
        Conditional_row1_ps_4_for_ks4_ks5_matric.Visible = false;
        Conditional_row2_ps_4_for_ks4_ks5_matric.Visible = false;
        Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = false;
        string selected_text = ddl_grouphead.SelectedItem.Text;
        if (selected_text == "EYFS")
        {
            Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;
        }
        if (selected_text == "KS1")
        {
            Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;

        }
        if (selected_text == "KS2")
        {
            Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;
        }
        if (selected_text == "KS3")
        {
            Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = true;
            Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;

        }
        if (selected_text == "KS4")
        {
            Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = true;
            Conditional_row1_ps_4_for_ks4_ks5_matric.Visible = true;
            Conditional_row2_ps_4_for_ks4_ks5_matric.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;
        }
        if (selected_text == "KS5")
        {
            Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = true;
            Conditional_row1_ps_4_for_ks4_ks5_matric.Visible = true;
            Conditional_row2_ps_4_for_ks4_ks5_matric.Visible = true;

            ddl_1_3_overall_grade.Enabled = true;
            ddl_2_1_1_and_2_1_2_grade.Enabled = true;
            ddl_2_1_5_grade.Enabled = true;
            ddl_3_1_overall_grade.Enabled = true;
            ddl_3_2_1_grade.Enabled = true;
            ddl_3_2_3_grade.Enabled = true;
            ddl_4_2_1_grade.Enabled = true;
            ddl_5_2_3_grade.Enabled = true;
        }
        if (selected_text == "MATRIC")
        {
            Condional_row_ps_5_for_ks3_ks4_ks5_matric.Visible = true;
            Conditional_row1_ps_4_for_ks4_ks5_matric.Visible = true;
            Conditional_row2_ps_4_for_ks4_ks5_matric.Visible = true;

            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;

        }
        show_Ph.Visible = true;
        Call_All_Performance_Standard();

        if (selected_text == "KS5")
        {
            ddl_1_3_overall_grade.Enabled = true;
            ddl_2_1_1_and_2_1_2_grade.Enabled = true;
            ddl_2_1_5_grade.Enabled = true;
            ddl_3_1_overall_grade.Enabled = true;
            ddl_3_2_1_grade.Enabled = true;
            ddl_3_2_3_grade.Enabled = true;
            ddl_4_2_1_grade.Enabled = true;
            ddl_5_2_3_grade.Enabled = true;
        }
        else
        {
            ddl_1_3_overall_grade.Enabled = false;
            ddl_2_1_1_and_2_1_2_grade.Enabled = false;
            ddl_2_1_5_grade.Enabled = false;
            ddl_3_1_overall_grade.Enabled = false;
            ddl_3_2_1_grade.Enabled = false;
            ddl_3_2_3_grade.Enabled = false;
            ddl_4_2_1_grade.Enabled = false;
            ddl_5_2_3_grade.Enabled = false;
        }

        //FillSLTEmployeesDynamic();
        BindSLTAssignmentGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_region.SelectedItem.Text.ToString() == "Select")
            {

                lblerror.Text = "Please select Region";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }
            if (ddl_center.SelectedItem.Text.ToString() == "" || ddl_center.SelectedItem.Text.ToString() == "Select")
            {
                lblerror.Text = "Please select Center";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }
            if (ddl_grouphead.SelectedItem.Text.ToString() == "Select")
            {
                lblerror.Text = "Please select Key Stage";
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Visible = true;
                return;
            }
            else
            {
                lblerror.Text = "";
                lblerror.Visible = false;
            }

            //***********************Insertion Area**********************************
            //2024-11-01
            //if (ddl_1_3_overall_grade.SelectedValue.ToString() != "")
            //{
            PS1_Fields_Insert();
            //}
            //********************************************************//2024-09-18
            // if (ddl_2_1_1_and_2_1_2_grade.SelectedValue.ToString() != "")   //ddl_2_1_1_and_2_1_2_grade
            //{
            PS2_Fields_Insert();
            //}

            //2024-11-01
            //if (ddl_3_1_overall_grade.SelectedValue.ToString() != "")
            //{
            PS3_Fields_Insert();
            //}

            PS4_Fields_Insert();


            //2024-09-18
            // if (ddl_5_1_1_grade.SelectedValue.ToString() != "")
            //{
            PS5_Fields_Insert();
            //}
            // if (ddl_6_1_1_grade.SelectedValue.ToString() != "")
            // {
            PS6_Fields_Insert();
            // }


            Compare_Dropdown_Values();
            ConsolidationBody();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    //public void Consolidation_OverallPerf_Fields_Insert()
    //{
    //    DataTable dt = new DataTable();
    //    BLLSiqa obj = new BLLSiqa();
    //    obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
    //    obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
    //    obj.overall_EYFS = ddl_Overall_Perf_EYFS.SelectedValue.ToString();
    //    //obj.overall_KS1 = ddl_Overall_Perf_KS1.SelectedValue.ToString();
    //    //obj.overall_KS2 = ddl_Overall_Perf_KS2.SelectedValue.ToString();
    //    //obj.overall_KS3 = ddl_Overall_Perf_KS3.SelectedValue.ToString();
    //    //obj.overall_KS4 = ddl_Overall_Perf_KS4.SelectedValue.ToString();
    //    //obj.overall_KS5 = ddl_Overall_Perf_KS5.SelectedValue.ToString();
    //    //obj.overall_Matric = ddl_Overall_Perf_Matric.SelectedValue.ToString();
    //    obj.CreateBy = Session["ContactID"].ToString();

    //    dt = obj.SEF_Consolidation_Overall_Insert(obj);
    //    if (dt.Rows.Count >= 1)
    //    {

    //        // Load_PS6_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString());

    //        ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
    //    }
    //    obj = null;
    //    dt = null;
    //}
    public void PS1_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        BLLSiqa obj1 = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());
        obj.Ps_Name = "PS1";
        obj.Learning_Skill_grade1 = ddl_1_3_overall_grade.SelectedValue.ToString();
        obj.Learning_Skill_Judg_txt = txt_1_3_explain_judgements.Text.ToString();
        obj.CreateBy = Session["ContactID"].ToString();
        int id = obj.SEF_PS1_Insert(obj);
        dt = obj1.Find_PS1_Child(id);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                obj1.PS1_Child_Delete(id);
            }
        }

        //if(id)
        PS1_Child_Fields_Insert(id);
        Load_PS1_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());


        obj = null;
        obj1 = null;
        dt = null;
    }
    public void PS1_Child_Fields_Insert(int id)
    {
        DataTable dt = new DataTable();
        //BLLSiqa obj = new BLLSiqa();
        int index = 0;
        foreach (GridViewRow row in gvps1child.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                BLLSiqa obj = new BLLSiqa();
                Label subject = gvps1child.Rows[index].FindControl("lblsubject") as Label;
                DropDownList Attainment_grade1 = gvps1child.Rows[index].FindControl("ddl_1_1_1_grade") as DropDownList;
                DropDownList Attainment_overall_grade = gvps1child.Rows[index].FindControl("ddl_1_1_overall_grade") as DropDownList;
                DropDownList Progress_grade1 = gvps1child.Rows[index].FindControl("ddl_1_2_1_grade") as DropDownList;
                DropDownList Progress_overall_grade = gvps1child.Rows[index].FindControl("ddl_1_2_overall_grade") as DropDownList;
                DropDownList Attainment_grade2 = gvps1child.Rows[index].FindControl("ddl_1_1_2_grade") as DropDownList;
                DropDownList Progress_grade2 = gvps1child.Rows[index].FindControl("ddl_1_2_2_grade") as DropDownList;
                DropDownList Attainment_grade3 = gvps1child.Rows[index].FindControl("ddl_1_1_3_grade") as DropDownList;
                obj.Ps1_Id_Fk = id;
                obj.Subject_Name = subject.Text.ToString();
                obj.Attainment_grade1 = Attainment_grade1.Text.ToString();
                obj.Attainment_overall_grade = Attainment_overall_grade.Text.ToString();
                obj.Progress_grade1 = Progress_grade1.Text.ToString();
                obj.Progress_overall_grade = Progress_overall_grade.Text.ToString();
                obj.Attainment_grade2 = Attainment_grade2.Text.ToString();
                obj.Progress_grade2 = Progress_grade2.Text.ToString();
                obj.Attainment_grade3 = Attainment_grade3.Text.ToString();
                obj.PS1_Child_Fields_Insert(obj);
                obj = null;
            }
            index++;
        }
    }
    public void PS2_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());



        obj.Ps_Name = "PS2";
        obj.Personal_dev_grade1 = ddl_2_1_1_and_2_1_2_grade.SelectedValue.ToString().Trim();
        obj.Personal_dev_overall_grade = ddl_2_1_overall_grade.SelectedValue.ToString().Trim();
        obj.Personal_dev_Lo_Form_chkbx1 = chkbx_2_1_1_and_2_1_2_lo_form.Checked;
        obj.Personal_dev_Dlws_chkbx1 = chkbx_2_1_1_and_2_1_2_dlws.Checked;
        obj.Personal_dev_Incidentlog_chkbx1 = chkbx_2_1_1_and_2_1_2_incident_log.Checked;
        obj.Personal_dev_Surveyres_chkbx1 = chkbx_2_1_1_and_2_1_2_survey_responses.Checked;
        obj.Personal_dev_Uniformdeflog_chkbx1 = chkbx_2_1_1_and_2_1_2_uniform_defaulter_log.Checked;
        obj.Personal_dev_Explain_Judg_txt = txt_2_1_explain_judgements.Text.ToString().Trim();
        obj.Personal_dev_grade2 = ddl_2_1_3_grade.SelectedValue.ToString();
        obj.Personal_dev_Dlws_chkbx2 = chkbx_2_1_3_dlws.Checked;
        obj.Personal_dev_grade3 = ddl_2_1_4_grade.SelectedValue.ToString();
        obj.Personal_dev_AttendanceReg_chkbx3 = chkbx_2_1_4_attendance_registers.Checked;
        obj.Personal_dev_TardyLateArrival_chkbx3 = chkbx_2_1_4_tardy_late_arrival_log.Checked;
        obj.Personal_dev_grade4 = ddl_2_1_5_grade.SelectedValue.ToString();
        obj.Personal_dev_LoConsolidation_chkbx4 = chkbx_2_1_5_lo_consolidation.Checked;
        obj.Social_Values_grade1 = ddl_2_2_overall_grade.SelectedValue.ToString();
        obj.Social_Values_Dlws_chkbx1 = chkbx_2_2_evidence_source_dlws.Checked;
        obj.Social_Values_Incidentlog_chkbx1 = chkbx_2_2_evidence_source_incident_log.Checked;
        obj.Social_Values_SurveyResponses_chkbx1 = chkbx_2_2_evidence_source_survey_responses.Checked;
        obj.Social_Values_ImpressionLo_chkbx1 = chkbx_2_2_evidence_source_impressions_from_lo.Checked;
        obj.Social_Values_Explain_Judg_txt = txt_2_2_explain_judgements.Text.ToString().Trim();
        obj.Social_Responsibility_grade1 = ddl_2_3_overall_grade.SelectedValue.ToString();
        obj.Social_Responsibility_Dlws_chkbx1 = chkbx_2_3_evidence_source_dlws.Checked;
        obj.Social_Responsibility_CoCurrricular_Act_chkbx1 = chkbx_2_3_evidence_source_cocurricular_activities.Checked;
        obj.Social_Responsibility_Explain_Judg_txt = txt_2_3_explain_judgements.Text.ToString().Trim();
        obj.CreateBy = Session["ContactID"].ToString();
        dt = obj.SEF_PS2_Insert(obj);
        if (dt.Rows.Count >= 1)
        {
            Load_PS2_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }
    public void PS3_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());
        obj.Ps_Name = "PS3";
        obj.Teaching_Eff_Learning_grade1 = ddl_3_1_overall_grade.SelectedValue.ToString().Trim();
        obj.Teaching_Eff_Learning_Judg_txt = txt_3_1_explain_judgements.Text.ToString().Trim();
        obj.Assessment_grade1 = ddl_3_2_1_grade.SelectedValue.ToString().Trim();
        obj.Assessment_overall_grade = ddl_3_2_overall_grade.SelectedValue.ToString().Trim();
        obj.Assessment_Progress_trckr_chkbx1 = chkbx_3_2_evidence_source_progress_trackers.Checked;
        obj.Assessment_Ieps_chkbx1 = chkbx_3_2_evidence_source_ieps.Checked;
        obj.Assessment_Assessment_Formt_chkbx1 = chkbx_3_2_evidence_source_assessment_formats.Checked;
        obj.Assessment_Aimsreport_chkbx1 = chkbx_3_2_evidence_source_aims_reports.Checked;
        obj.Assessment_Judg_tx = txt_3_2_explain_judgements.Text.ToString().Trim();
        obj.Assessment_grade2 = ddl_3_2_2_grade.SelectedValue.ToString();
        obj.Assessment_grade3 = ddl_3_2_3_grade.SelectedValue.ToString();
        obj.Assessment_Nb_consolidation_chkbx3 = chkbx_3_2_evidence_source_nb_consolidation.Checked;
        obj.CreateBy = Session["ContactID"].ToString();
        dt = obj.SEF_PS3_Insert(obj);



        if (dt.Rows.Count >= 1)
        {
            Load_PS3_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }
    public void PS4_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());
        obj.Ps_Name = "PS4";
        obj.Curriculum_Imp_Cross_Curricular_grade_E123 = ddl_4_1_overall_grade_eyfs_ks1_ks2_ks3.SelectedValue.ToString().Trim();
        obj.Curriculum_Imp_Judg_txt_E123 = txt_4_1_explain_judgements_eyfs_ks1_ks2_ks3.Text.ToString().Trim();
        obj.Curriculum_Imp_Curricular_Choices_grade = ddl_4_1_1_grade.SelectedValue.ToString().Trim();
        obj.Curriculum_Imp_Overall_grade = ddl_4_1_overall_grade_ks4_ks5_matric.SelectedValue.ToString().Trim();
        obj.Curriculum_Imp_Judg_txt_K45 = txt_4_1_explain_judgements_ks4_ks5_matric.Text.ToString().Trim();
        obj.Curriculum_Imp_Cross_Curricular_grade_K45 = ddl_4_1_2_grade.SelectedValue.ToString().Trim();
        obj.Curriculum_Adaptation_grade = ddl_4_2_1_grade.SelectedValue.ToString().Trim();
        obj.Curriculum_Adaptation_Overall_grade = ddl_4_2_overall_grade.SelectedValue.ToString().Trim();
        obj.Curriculum_Adaptation_Lo_Consolidation_chkbx = Chkbx_4_2_evidence_source_lo_consolidation.Checked;
        obj.Curriculum_Adaptation_Nb_Consolidation_chkbx = Chkbx_4_2_evidence_source_nb_consolidation.Checked;
        obj.Curriculum_Adaptation_Co_And_Extra_Curricular_chkbx = Chkbx_4_2_evidence_source_co_extra_curricular_activities.Checked;
        obj.Curriculum_Adaptation_Club_And_Societies_chkbx = Chkbx_4_2_evidence_source_clubs_societies.Checked;
        obj.Curriculum_Adaptation_Event_Log_chkbx = Chkbx_4_2_evidence_source_event_log.Checked;
        obj.Curriculum_Adaptation_Morning_Assemblies_chkbx = Chkbx_4_2_evidence_source_morning_assemblies.Checked;
        obj.Curriculum_Adaptation_Activity_Calendar_chkbx = Chkbx_4_2_evidence_source_activity_calendar.Checked;
        obj.Curriculum_Adaptation_Judg_txt = txt_4_2_explain_judgements.Text.ToString().Trim();
        obj.Curriculum_Adaptation_Enhancement_Enterprise_grade = ddl_4_2_2_grade.SelectedValue.ToString();
        obj.Curriculum_Adaptation_Link_Pakistani_grade = ddl_4_2_3_grade.SelectedValue.ToString();
        obj.CreateBy = Session["ContactID"].ToString();
        dt = obj.SEF_PS4_Insert(obj);
        if (dt.Rows.Count >= 1)
        {
            Load_PS4_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }
    public void PS5_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());
        obj.Ps_Name = "PS5";
        obj.Health_And_Safety_grade1 = ddl_5_1_1_grade.SelectedValue.ToString().Trim();
        obj.Health_And_Safety_overall_grade = ddl_5_1_overall_grade.SelectedValue.ToString().Trim();
        obj.Health_And_Safety_Evidence_Source_txt = txt_5_1_evidence_source.Text.ToString().Trim();
        obj.Health_And_Safety_Judg_txt = txt_5_1_explain_judgements.Text.ToString().Trim();
        obj.Health_And_Safety_grade2 = ddl_5_1_2_grade.SelectedValue.ToString().Trim();
        obj.Health_And_Safety_grade3 = ddl_5_1_3_grade.SelectedValue.ToString().Trim();
        obj.Health_And_Safety_grade4 = ddl_5_1_4_grade.SelectedValue.ToString().Trim();
        obj.Care_And_Support_grade1 = ddl_5_2_1_grade.SelectedValue.ToString().Trim();
        obj.Care_And_Support_overall_grade = ddl_5_2_overall_grade.SelectedValue.ToString().Trim();
        obj.Care_And_Support_Evidence_Source_txt = txt_5_2_eveidence_source.Text.ToString().Trim();
        obj.Care_And_Support_Judg_txt = txt_5_2_explain_judgements.Text.ToString().Trim();

        obj.Care_And_Support_grade2 = ddl_5_2_2_grade.SelectedValue.ToString().Trim();
        obj.Care_And_Support_grade3 = ddl_5_2_3_grade.SelectedValue.ToString().Trim();
        obj.Care_And_Support_grade4 = ddl_5_2_4_grade.SelectedValue.ToString().Trim();
        obj.CreateBy = Session["ContactID"].ToString();
        dt = obj.SEF_PS5_Insert(obj);
        //int result = obj.SEF_PS5_Insert(obj);
        if (dt.Rows.Count >= 1)
        {
            Load_PS5_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }
    public void PS6_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());

        obj.Ps_Name = "PS6";
        obj.Eff_of_Leadership_grade1 = ddl_6_1_1_grade.SelectedValue.ToString().Trim();
        obj.Eff_of_Leadership_overall_grade = ddl_6_1_overall_grade.SelectedValue.ToString().Trim();
        obj.Eff_of_Leadership_Evidence_Source_txt = txt_6_1_evidence_source.Text.ToString().Trim();
        obj.Eff_of_Leadership_Judg_txt = txt_6_1_explain_judgements.Text.ToString().Trim();
        obj.Eff_of_Leadership_grade2 = ddl_6_1_2_grade.SelectedValue.ToString().Trim();
        obj.Eff_of_Leadership_grade3 = ddl_6_1_3_grade.SelectedValue.ToString().Trim();
        obj.Eff_of_Leadership_grade4 = ddl_6_1_4_grade.SelectedValue.ToString().Trim();
        obj.Sef_Imp_Planning_grade1 = ddl_6_2_1_grade.SelectedValue.ToString().Trim();
        obj.Sef_Imp_Planning_overall_grade1 = ddl_6_2_overall_grade.SelectedValue.ToString().Trim();
        obj.Sef_Imp_Planning_Evidence_Source_txt = txt_6_2_evidence_source.Text.ToString().Trim();
        obj.Sef_Imp_Planning_Judg_txt = txt_6_2_explain_judgements.Text.ToString().Trim();
        obj.Sef_Imp_Planning_overall_grade2 = ddl_6_2_2_grade.SelectedValue.ToString().Trim();
        obj.Sef_Imp_Planning_overall_grade3 = ddl_6_2_3_grade.SelectedValue.ToString().Trim();
        obj.Sef_Imp_Planning_overall_grade4 = ddl_6_2_4_grade.SelectedValue.ToString().Trim();
        obj.Partnership_With_Parents_Comm_grade1 = ddl_6_3_1_grade.SelectedValue.ToString().Trim();
        obj.Partnership_With_Parents_Comm_overall_grade = ddl_6_3_overall_grade.SelectedValue.ToString().Trim();
        obj.Partnership_With_Parents_Comm_Evidence_Source_txt = txt_6_3_evidence_source.Text.ToString().Trim();
        obj.Partnership_With_Parents_Comm_Judg_txt = txt_6_3_explain_judgements.Text.ToString().Trim();
        obj.Partnership_With_Parents_Comm_grade2 = ddl_6_3_2_grade.SelectedValue.ToString().Trim();
        obj.Partnership_With_Parents_Comm_grade3 = ddl_6_3_3_grade.SelectedValue.ToString().Trim();
        obj.Partnership_With_Parents_Comm_grade4 = "";
        obj.Mgmt_Staff_Facilities_grade1 = ddl_6_4_1_grade.SelectedValue.ToString().Trim();
        obj.Mgmt_Staff_Facilities_overall_grade = ddl_6_4_overall_grade.SelectedValue.ToString().Trim();
        obj.Mgmt_Staff_Facilities_Evidence_Source_txt = txt_6_4_evidence_source.Text.ToString().Trim();
        obj.Mgmt_Staff_Facilities_Judg_txt = txt_6_4_explain_judgements.Text.ToString().Trim();
        obj.Mgmt_Staff_Facilities_grade2 = ddl_6_4_2_grade.SelectedValue.ToString().Trim();
        obj.Mgmt_Staff_Facilities_grade3 = ddl_6_4_3_grade.SelectedValue.ToString().Trim();
        obj.Mgmt_Staff_Facilities_grade4 = ddl_6_4_4_grade.SelectedValue.ToString().Trim();

        obj.CreateBy = Session["ContactID"].ToString();

        dt = obj.SEF_PS6_Insert(obj);
        if (dt.Rows.Count >= 1)
        {
            // ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            // ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            // ddl_6_1_1_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_grade1"].ToString();
            // txt_6_1_evidence_source.Text = dt.Rows[0]["Eff_of_Leadership_Evidence_Source_txt"].ToString();
            Load_PS6_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString(), obj.Group_ID.ToString(), ddl_Session.SelectedValue.ToString());
            //Clear_Data();
            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }
    protected void PS1_fields_Clear()
    {
        ddl_1_3_overall_grade.SelectedIndex = 0;
        txt_1_3_explain_judgements.Text = "";
    }
    protected void PS2_Fields_Clear()
    {
        ddl_2_1_1_and_2_1_2_grade.SelectedIndex = 0;
        ddl_2_1_overall_grade.SelectedIndex = 0;
        chkbx_2_1_1_and_2_1_2_lo_form.Checked = false;
        chkbx_2_1_1_and_2_1_2_dlws.Checked = false;
        chkbx_2_1_1_and_2_1_2_incident_log.Checked = false;
        chkbx_2_1_1_and_2_1_2_survey_responses.Checked = false;
        chkbx_2_1_1_and_2_1_2_uniform_defaulter_log.Checked = false;
        txt_2_1_explain_judgements.Text = "";
        ddl_2_1_3_grade.SelectedIndex = 0;
        chkbx_2_1_3_dlws.Checked = false;
        ddl_2_1_4_grade.SelectedIndex = 0;
        chkbx_2_1_4_attendance_registers.Checked = false;
        chkbx_2_1_4_tardy_late_arrival_log.Checked = false;
        ddl_2_1_5_grade.SelectedIndex = 0; ;
        chkbx_2_1_5_lo_consolidation.Checked = false;
        ddl_2_2_overall_grade.SelectedIndex = 0;
        chkbx_2_2_evidence_source_dlws.Checked = false;
        chkbx_2_2_evidence_source_incident_log.Checked = false;
        chkbx_2_2_evidence_source_survey_responses.Checked = false;
        chkbx_2_2_evidence_source_impressions_from_lo.Checked = false;
        txt_2_2_explain_judgements.Text = "";
        ddl_2_3_overall_grade.SelectedIndex = 0;
        chkbx_2_3_evidence_source_dlws.Checked = false;
        chkbx_2_3_evidence_source_cocurricular_activities.Checked = false;
        txt_2_3_explain_judgements.Text = "";
    }
    protected void PS3_Fields_Clear()
    {
        ddl_3_1_overall_grade.SelectedIndex = 0;
        ddl_3_1_overall_grade.SelectedIndex = 0;
        txt_3_1_explain_judgements.Text = "";
        ddl_3_2_1_grade.SelectedIndex = 0;
        ddl_3_2_overall_grade.SelectedIndex = 0;
        chkbx_3_2_evidence_source_progress_trackers.Checked = false;
        chkbx_3_2_evidence_source_ieps.Checked = false;
        chkbx_3_2_evidence_source_assessment_formats.Checked = false;
        chkbx_3_2_evidence_source_aims_reports.Checked = false;
        txt_3_2_explain_judgements.Text = "";
        ddl_3_2_2_grade.SelectedIndex = 0;
        ddl_3_2_3_grade.SelectedIndex = 0;
        chkbx_3_2_evidence_source_nb_consolidation.Checked = false;
    }
    protected void PS4_Fields_Clear()
    {
        ddl_4_1_overall_grade_eyfs_ks1_ks2_ks3.SelectedIndex = 0;
        txt_4_1_explain_judgements_eyfs_ks1_ks2_ks3.Text = "";
        ddl_4_1_1_grade.SelectedIndex = 0;
        ddl_4_1_overall_grade_ks4_ks5_matric.SelectedIndex = 0;
        txt_4_1_explain_judgements_ks4_ks5_matric.Text = "";
        ddl_4_1_2_grade.SelectedIndex = 0;
        ddl_4_2_1_grade.SelectedIndex = 0;
        ddl_4_2_overall_grade.SelectedIndex = 0;
        Chkbx_4_2_evidence_source_lo_consolidation.Checked = false;
        Chkbx_4_2_evidence_source_nb_consolidation.Checked = false;
        Chkbx_4_2_evidence_source_co_extra_curricular_activities.Checked = false;
        Chkbx_4_2_evidence_source_clubs_societies.Checked = false;
        Chkbx_4_2_evidence_source_event_log.Checked = false;
        Chkbx_4_2_evidence_source_morning_assemblies.Checked = false;
        Chkbx_4_2_evidence_source_activity_calendar.Checked = false;
        txt_4_2_explain_judgements.Text = "";
        ddl_4_2_2_grade.SelectedIndex = 0;
        ddl_4_2_3_grade.SelectedIndex = 0;
    }
    protected void PS5_Fields_Clear()
    {
        ddl_5_1_1_grade.SelectedIndex = 0;
        ddl_5_1_overall_grade.SelectedIndex = 0;
        txt_5_1_evidence_source.Text = "";
        txt_5_1_explain_judgements.Text = "";
        ddl_5_1_2_grade.SelectedIndex = 0;
        ddl_5_1_3_grade.SelectedIndex = 0;
        ddl_5_1_4_grade.SelectedIndex = 0;
        ddl_5_2_1_grade.SelectedIndex = 0;
        ddl_5_2_overall_grade.SelectedIndex = 0;
        txt_5_2_eveidence_source.Text = "";
        txt_5_2_explain_judgements.Text = "";
        ddl_5_2_2_grade.SelectedIndex = 0;
        ddl_5_2_3_grade.SelectedIndex = 0;
        ddl_5_2_4_grade.SelectedIndex = 0;
    }
    protected void PS6_Fields_Clear()
    {
        ddl_6_1_1_grade.SelectedIndex = 0;
        ddl_6_1_overall_grade.SelectedIndex = 0;
        txt_6_1_evidence_source.Text = "";
        txt_6_1_explain_judgements.Text = "";
        ddl_6_1_2_grade.SelectedIndex = 0;
        ddl_6_1_3_grade.SelectedIndex = 0;
        ddl_6_1_4_grade.SelectedIndex = 0;
        ddl_6_2_1_grade.SelectedIndex = 0;
        ddl_6_2_overall_grade.SelectedIndex = 0;
        txt_6_2_evidence_source.Text = "";
        txt_6_2_explain_judgements.Text = "";
        ddl_6_2_2_grade.SelectedIndex = 0;
        ddl_6_2_3_grade.SelectedIndex = 0;
        ddl_6_2_4_grade.SelectedIndex = 0;
        ddl_6_3_1_grade.SelectedIndex = 0;
        ddl_6_3_overall_grade.SelectedIndex = 0;
        txt_6_3_evidence_source.Text = "";
        txt_6_3_explain_judgements.Text = "";
        ddl_6_3_2_grade.SelectedIndex = 0;
        ddl_6_3_3_grade.SelectedIndex = 0;
        ddl_6_4_1_grade.SelectedIndex = 0;
        ddl_6_4_overall_grade.SelectedIndex = 0;
        txt_6_4_evidence_source.Text = "";
        txt_6_4_explain_judgements.Text = "";
        ddl_6_4_2_grade.SelectedIndex = 0;
        ddl_6_4_3_grade.SelectedIndex = 0;
        ddl_6_4_4_grade.SelectedIndex = 0;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        PS2_Fields_Clear();
        PS3_Fields_Clear();
        PS4_Fields_Clear();
        PS5_Fields_Clear();
    }

    //***************************************Data Fetching Area************************************************
    protected void Load_PS1_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        DataTable dtformula = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        dt = obj.SEF_PS1_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {
            ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            ddl_grouphead.SelectedValue = dt.Rows[0]["Group_ID"].ToString();
            ddl_1_3_overall_grade.SelectedValue = dt.Rows[0]["Learning_Skill_grade1"].ToString();
            txt_1_3_explain_judgements.Text = dt.Rows[0]["Learning_Skill_Judg_txt"].ToString();
        }
        else
        {
            PS1_fields_Clear();
        }

        dtformula = obj.SEF_PS1_GET_FORMULA_DROPDOWN(Region_Id, Center_Id, ddl_grouphead.SelectedItem.Text.ToString().Trim(), ddl_Session.SelectedValue.ToString());
        if (dtformula.Rows.Count > 0)
        {
            if (dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString() != "NA")
            {
                ddl_1_3_overall_grade.SelectedValue = dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString();
                //if (dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString() == "UA")
                //{
                ddl_1_3_overall_grade.Enabled = false;
                //}
                //else
                //{
                //    ddl_1_3_overall_grade.Enabled = true;
                //}
            }
        }
        else
        {
            // ddl_1_3_overall_grade.Enabled = true;
        }
        dt = null;
        obj = null;
        dtformula = null;
    }
    protected void Load_PS2_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        DataTable dtformula = new DataTable();
        dt = obj.SEF_PS2_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {

            ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            ddl_grouphead.SelectedValue = dt.Rows[0]["Group_ID"].ToString();
            // Ps_Name = "PS2";        
            ddl_2_1_1_and_2_1_2_grade.SelectedValue = dt.Rows[0]["Personal_dev_grade1"].ToString();
            ddl_2_1_overall_grade.SelectedValue = dt.Rows[0]["Personal_dev_overall_grade"].ToString();
            chkbx_2_1_1_and_2_1_2_lo_form.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Lo_Form_chkbx1"].ToString());
            chkbx_2_1_1_and_2_1_2_dlws.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Dlws_chkbx1"].ToString());
            chkbx_2_1_1_and_2_1_2_incident_log.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Incidentlog_chkbx1"].ToString());
            chkbx_2_1_1_and_2_1_2_survey_responses.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Surveyres_chkbx1"].ToString());
            chkbx_2_1_1_and_2_1_2_uniform_defaulter_log.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Uniformdeflog_chkbx1"].ToString());
            txt_2_1_explain_judgements.Text = dt.Rows[0]["Personal_dev_Explain_Judg_txt"].ToString();
            ddl_2_1_3_grade.SelectedValue = dt.Rows[0]["Personal_dev_grade2"].ToString();
            chkbx_2_1_3_dlws.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_Dlws_chkbx2"].ToString());
            ddl_2_1_4_grade.SelectedValue = dt.Rows[0]["Personal_dev_grade3"].ToString();
            chkbx_2_1_4_attendance_registers.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_AttendanceReg_chkbx3"].ToString());
            chkbx_2_1_4_tardy_late_arrival_log.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_TardyLateArrival_chkbx3"].ToString());
            ddl_2_1_5_grade.SelectedValue = dt.Rows[0]["Personal_dev_grade4"].ToString();
            chkbx_2_1_5_lo_consolidation.Checked = Convert.ToBoolean(dt.Rows[0]["Personal_dev_LoConsolidation_chkbx4"].ToString());
            ddl_2_2_overall_grade.SelectedValue = dt.Rows[0]["Social_Values_grade1"].ToString();
            chkbx_2_2_evidence_source_dlws.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Values_Dlws_chkbx1"].ToString());
            chkbx_2_2_evidence_source_incident_log.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Values_Incidentlog_chkbx1"].ToString());
            chkbx_2_2_evidence_source_survey_responses.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Values_SurveyResponses_chkbx1"].ToString());
            chkbx_2_2_evidence_source_impressions_from_lo.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Values_ImpressionLo_chkbx1"].ToString());
            txt_2_2_explain_judgements.Text = dt.Rows[0]["Social_Values_Explain_Judg_txt"].ToString();
            ddl_2_3_overall_grade.SelectedValue = dt.Rows[0]["Social_Responsibility_grade1"].ToString();
            chkbx_2_3_evidence_source_dlws.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Responsibility_Dlws_chkbx1"].ToString());
            chkbx_2_3_evidence_source_cocurricular_activities.Checked = Convert.ToBoolean(dt.Rows[0]["Social_Responsibility_CoCurrricular_Act_chkbx1"].ToString());
            txt_2_3_explain_judgements.Text = dt.Rows[0]["Social_Responsibility_Explain_Judg_txt"].ToString();
        }
        else
        {
            PS2_Fields_Clear();
        }
        dtformula = obj.SEF_PS1_GET_FORMULA_DROPDOWN(Region_Id, Center_Id, ddl_grouphead.SelectedItem.Text.ToString().Trim(), ddl_Session.SelectedValue.ToString());
        if (dtformula.Rows.Count > 0)
        {
            if (dtformula.Rows[0]["Attitudes_Relationships_Grade_Final"].ToString() != "NA")
            {
                ddl_2_1_1_and_2_1_2_grade.SelectedValue = dtformula.Rows[0]["Attitudes_Relationships_Grade_Final"].ToString();
                //if (dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString() == "UA")
                // {
                ddl_2_1_1_and_2_1_2_grade.Enabled = false;
                //}
                //else
                //{
                // ddl_2_1_1_and_2_1_2_grade.Enabled = true;
                //}
            }
            if (dtformula.Rows[0]["Care_And_Classroom_Routines_Grade_Final"].ToString() != "NA")
            {
                ddl_2_1_5_grade.SelectedValue = dtformula.Rows[0]["Care_And_Classroom_Routines_Grade_Final"].ToString();
                ddl_2_1_5_grade.Enabled = false;
            }
            else
            {
                if (ddl_grouphead.SelectedItem.Text.ToString() == "EYFS" || ddl_grouphead.SelectedItem.Text.ToString() == "KS1")
                {
                    ddl_2_1_5_grade.Visible = true;
                    lbl2_1_5.Visible = true;
                    lbl2_1_5Desc.Visible = true;
                }
                else
                {
                    ddl_2_1_5_grade.Visible = false;
                    lbl2_1_5.Visible = false;
                    lbl2_1_5Desc.Visible = false;

                }
            }
        }
        else
        {
            if (ddl_grouphead.SelectedItem.Text.ToString() == "EYFS" || ddl_grouphead.SelectedItem.Text.ToString() == "KS1")
            {
                ddl_2_1_5_grade.Visible = true;
                lbl2_1_5.Visible = true;
                lbl2_1_5Desc.Visible = true;
            }
            else
            {
                ddl_2_1_5_grade.Visible = false;
                lbl2_1_5.Visible = false;
                lbl2_1_5Desc.Visible = false;

            }
            //  ddl_2_1_1_and_2_1_2_grade.Enabled = true;
            //  ddl_2_1_5_grade.Enabled = true;
        }
        dt = null;
        dtformula = null;
        obj = null;
    }
    protected void Load_PS3_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        DataTable dtformula = new DataTable();
        DataTable dtformulaNB = new DataTable();
        dt = obj.SEF_PS3_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {

            ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            ddl_grouphead.SelectedValue = dt.Rows[0]["Group_ID"].ToString();
            // Ps_Name = "PS3";        
            ddl_3_1_overall_grade.SelectedValue = dt.Rows[0]["Teaching_Eff_Learning_grade1"].ToString();
            txt_3_1_explain_judgements.Text = dt.Rows[0]["Teaching_Eff_Learning_Judg_txt"].ToString();
            ddl_3_2_1_grade.SelectedValue = dt.Rows[0]["Assessment_grade1"].ToString();
            ddl_3_2_overall_grade.SelectedValue = dt.Rows[0]["Assessment_overall_grade"].ToString();
            chkbx_3_2_evidence_source_progress_trackers.Checked = Convert.ToBoolean(dt.Rows[0]["Assessment_Progress_trckr_chkbx1"].ToString());
            chkbx_3_2_evidence_source_ieps.Checked = Convert.ToBoolean(dt.Rows[0]["Assessment_Ieps_chkbx1"].ToString());
            chkbx_3_2_evidence_source_assessment_formats.Checked = Convert.ToBoolean(dt.Rows[0]["Assessment_Assessment_Formt_chkbx1"].ToString());
            chkbx_3_2_evidence_source_aims_reports.Checked = Convert.ToBoolean(dt.Rows[0]["Assessment_Aimsreport_chkbx1"].ToString());
            txt_3_2_explain_judgements.Text = dt.Rows[0]["Assessment_Judg_tx"].ToString();
            ddl_3_2_2_grade.SelectedValue = dt.Rows[0]["Assessment_grade2"].ToString();
            ddl_3_2_3_grade.SelectedValue = dt.Rows[0]["Assessment_grade3"].ToString();
            chkbx_3_2_evidence_source_nb_consolidation.Checked = Convert.ToBoolean(dt.Rows[0]["Assessment_Nb_consolidation_chkbx3"].ToString());
        }
        else
        {
            PS3_Fields_Clear();
        }
        dtformula = obj.SEF_PS1_GET_FORMULA_DROPDOWN(Region_Id, Center_Id, ddl_grouphead.SelectedItem.Text.ToString().Trim(), ddl_Session.SelectedValue.ToString());
        if (dtformula.Rows.Count > 0)
        {
            if (dtformula.Rows[0]["Lesson_Planning_Grade_Final"].ToString() != "NA")
            {
                ddl_3_1_overall_grade.SelectedValue = dtformula.Rows[0]["Lesson_Planning_Grade_Final"].ToString();
                //if (dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString() == "UA")
                // {
                ddl_3_1_overall_grade.Enabled = false;
                //}
                //else
                //{
                // ddl_2_1_1_and_2_1_2_grade.Enabled = true;
                //}
            }
        }
        else
        {
            //  ddl_3_1_overall_grade.Enabled = true;
        }

        dtformulaNB = obj.SEF_GET_FORMULA_DROPDOWN_FROM_NB(Region_Id, Center_Id, ddl_grouphead.SelectedItem.Text.ToString().Trim());
        if (dtformulaNB.Rows.Count > 0)
        {
            if (dtformulaNB.Rows[0]["Quality_of_Tasks_Grade_Final"].ToString() != "NA")
            {
                ddl_3_2_1_grade.SelectedValue = dtformulaNB.Rows[0]["Quality_of_Tasks_Grade_Final"].ToString();

                ddl_3_2_1_grade.Enabled = false;

            }
            if (dtformulaNB.Rows[0]["Assessment_Grade_Final"].ToString() != "NA")
            {
                ddl_3_2_3_grade.SelectedValue = dtformulaNB.Rows[0]["Assessment_Grade_Final"].ToString();

                ddl_3_2_3_grade.Enabled = false;

            }
        }
        else
        {
            //  ddl_3_2_1_grade.Enabled = true;
            //  ddl_3_2_3_grade.Enabled = true;
        }



        dtformula = null;
        dt = null;
        obj = null;
    }
    protected void Load_PS4_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        DataTable dtformula = new DataTable();
        dt = obj.SEF_PS4_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {
            ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            ddl_grouphead.SelectedValue = dt.Rows[0]["Group_ID"].ToString();
            //Ps_Name = "PS4"; 
            ddl_4_1_overall_grade_eyfs_ks1_ks2_ks3.SelectedValue = dt.Rows[0]["Curriculum_Imp_Cross_Curricular_grade_E123"].ToString();
            txt_4_1_explain_judgements_eyfs_ks1_ks2_ks3.Text = dt.Rows[0]["Curriculum_Imp_Judg_txt_E123"].ToString();
            ddl_4_1_1_grade.SelectedValue = dt.Rows[0]["Curriculum_Imp_Curricular_Choices_grade"].ToString();
            ddl_4_1_overall_grade_ks4_ks5_matric.SelectedValue = dt.Rows[0]["Curriculum_Imp_Overall_grade"].ToString();
            txt_4_1_explain_judgements_ks4_ks5_matric.Text = dt.Rows[0]["Curriculum_Imp_Judg_txt_K45"].ToString();
            ddl_4_1_2_grade.SelectedValue = dt.Rows[0]["Curriculum_Imp_Cross_Curricular_grade_K45"].ToString();
            ddl_4_2_1_grade.SelectedValue = dt.Rows[0]["Curriculum_Adaptation_grade"].ToString(); //Convert.ToBoolean( dt.Rows[0]["Curriculum_Adaptation_Link_Pakistani_grade"].ToString());
            ddl_4_2_overall_grade.SelectedValue = dt.Rows[0]["Curriculum_Adaptation_Overall_grade"].ToString();
            Chkbx_4_2_evidence_source_lo_consolidation.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Lo_Consolidation_chkbx"].ToString());
            Chkbx_4_2_evidence_source_nb_consolidation.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Nb_Consolidation_chkbx"].ToString());
            Chkbx_4_2_evidence_source_co_extra_curricular_activities.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Co_And_Extra_Curricular_chkbx"].ToString());
            Chkbx_4_2_evidence_source_clubs_societies.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Club_And_Societies_chkbx"].ToString());
            Chkbx_4_2_evidence_source_event_log.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Event_Log_chkbx"].ToString());
            Chkbx_4_2_evidence_source_morning_assemblies.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Morning_Assemblies_chkbx"].ToString());
            Chkbx_4_2_evidence_source_activity_calendar.Checked = Convert.ToBoolean(dt.Rows[0]["Curriculum_Adaptation_Activity_Calendar_chkbx"].ToString());
            txt_4_2_explain_judgements.Text = dt.Rows[0]["Curriculum_Adaptation_Judg_txt"].ToString();
            ddl_4_2_2_grade.SelectedValue = dt.Rows[0]["Curriculum_Adaptation_Enhancement_Enterprise_grade"].ToString();
            ddl_4_2_3_grade.SelectedValue = dt.Rows[0]["Curriculum_Adaptation_Link_Pakistani_grade"].ToString();
        }
        else
        {
            PS4_Fields_Clear();
        }
        dtformula = obj.SEF_PS1_GET_FORMULA_DROPDOWN(Region_Id, Center_Id, ddl_grouphead.SelectedItem.Text.ToString().Trim(), ddl_Session.SelectedValue.ToString());
        if (dtformula.Rows.Count > 0)
        {
            if (dtformula.Rows[0]["Need_Ability_Group_Grade_Final"].ToString() != "NA")
            {
                ddl_4_2_1_grade.SelectedValue = dtformula.Rows[0]["Need_Ability_Group_Grade_Final"].ToString();
                //if (dtformula.Rows[0]["Student_Learning_Skills_Grade_final"].ToString() == "UA")
                //{
                ddl_4_2_1_grade.Enabled = false;
                //}
                //else
                //{
                //    ddl_1_3_overall_grade.Enabled = true;
                //}
            }
            else
            {
                //  ddl_4_2_1_grade.Enabled = true;
            }
        }
        else
        {
            //   ddl_4_2_1_grade.Enabled = true;
        }
        dt = null;
        dtformula = null;
    }
    protected void Load_PS5_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        dt = obj.SEF_PS5_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {
            ddl_region.SelectedValue = dt.Rows[0]["Region_Id"].ToString();
            ddl_center.SelectedValue = dt.Rows[0]["Center_Id"].ToString();
            ddl_grouphead.SelectedValue = dt.Rows[0]["Group_ID"].ToString();
            // Ps_Name = "PS5";
            ddl_5_1_1_grade.SelectedValue = dt.Rows[0]["Health_And_Safety_grade1"].ToString();
            ddl_5_1_overall_grade.SelectedValue = dt.Rows[0]["Health_And_Safety_overall_grade"].ToString();
            txt_5_1_evidence_source.Text = dt.Rows[0]["Health_And_Safety_Evidence_Source_txt"].ToString();
            txt_5_1_explain_judgements.Text = dt.Rows[0]["Health_And_Safety_Judg_txt"].ToString();
            ddl_5_1_2_grade.SelectedValue = dt.Rows[0]["Health_And_Safety_grade2"].ToString();
            ddl_5_1_3_grade.SelectedValue = dt.Rows[0]["Health_And_Safety_grade3"].ToString();
            ddl_5_1_4_grade.SelectedValue = dt.Rows[0]["Health_And_Safety_grade4"].ToString();
            ddl_5_2_1_grade.SelectedValue = dt.Rows[0]["Care_And_Support_grade1"].ToString();
            ddl_5_2_overall_grade.SelectedValue = dt.Rows[0]["Care_And_Support_overall_grade"].ToString();
            txt_5_2_eveidence_source.Text = dt.Rows[0]["Care_And_Support_Evidence_Source_txt"].ToString();
            txt_5_2_explain_judgements.Text = dt.Rows[0]["Care_And_Support_Judg_txt"].ToString();
            ddl_5_2_2_grade.SelectedValue = dt.Rows[0]["Care_And_Support_grade2"].ToString();
            ddl_5_2_3_grade.SelectedValue = dt.Rows[0]["Care_And_Support_grade3"].ToString();
            ddl_5_2_4_grade.SelectedValue = dt.Rows[0]["Care_And_Support_grade4"].ToString();
        }
        else
        {
            PS5_Fields_Clear();
        }
        dt = null;
    }
    protected void Load_PS6_Data(string Region_Id, string Center_Id, string Group_ID, string Session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        dt = obj.SEF_PS6_GET_DATA(Region_Id, Center_Id, Group_ID, Session_ID);
        if (dt.Rows.Count > 0)
        {
            obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            obj.Group_ID = Convert.ToInt32(ddl_grouphead.SelectedValue.ToString());

            //obj.Ps_Name = "PS6";
            ddl_6_1_1_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_grade1"].ToString();
            ddl_6_1_overall_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_overall_grade"].ToString();
            txt_6_1_evidence_source.Text = dt.Rows[0]["Eff_of_Leadership_Evidence_Source_txt"].ToString();
            txt_6_1_explain_judgements.Text = dt.Rows[0]["Eff_of_Leadership_Judg_txt"].ToString();
            ddl_6_1_2_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_grade2"].ToString();
            ddl_6_1_3_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_grade3"].ToString();
            ddl_6_1_4_grade.SelectedValue = dt.Rows[0]["Eff_of_Leadership_grade4"].ToString();
            ddl_6_2_1_grade.SelectedValue = dt.Rows[0]["Sef_Imp_Planning_grade1"].ToString();
            ddl_6_2_overall_grade.SelectedValue = dt.Rows[0]["Sef_Imp_Planning_overall_grade1"].ToString();
            txt_6_2_evidence_source.Text = dt.Rows[0]["Sef_Imp_Planning_Evidence_Source_txt"].ToString();
            txt_6_2_explain_judgements.Text = dt.Rows[0]["Sef_Imp_Planning_Judg_txt"].ToString();
            ddl_6_2_2_grade.SelectedValue = dt.Rows[0]["Sef_Imp_Planning_overall_grade2"].ToString();
            ddl_6_2_3_grade.SelectedValue = dt.Rows[0]["Sef_Imp_Planning_overall_grade3"].ToString();
            ddl_6_2_4_grade.SelectedValue = dt.Rows[0]["Sef_Imp_Planning_overall_grade4"].ToString();
            ddl_6_3_1_grade.SelectedValue = dt.Rows[0]["Partnership_With_Parents_Comm_grade1"].ToString();
            ddl_6_3_overall_grade.SelectedValue = dt.Rows[0]["Partnership_With_Parents_Comm_overall_grade"].ToString();
            txt_6_3_evidence_source.Text = dt.Rows[0]["Partnership_With_Parents_Comm_Evidence_Source_txt"].ToString();
            txt_6_3_explain_judgements.Text = dt.Rows[0]["Partnership_With_Parents_Comm_Judg_txt"].ToString();
            ddl_6_3_2_grade.SelectedValue = dt.Rows[0]["Partnership_With_Parents_Comm_grade2"].ToString();
            ddl_6_3_3_grade.SelectedValue = dt.Rows[0]["Partnership_With_Parents_Comm_grade3"].ToString();
            //Partnership_With_Parents_Comm_grade4 = "";   
            ddl_6_4_1_grade.SelectedValue = dt.Rows[0]["Mgmt_Staff_Facilities_grade1"].ToString();
            ddl_6_4_overall_grade.SelectedValue = dt.Rows[0]["Mgmt_Staff_Facilities_overall_grade"].ToString();
            txt_6_4_evidence_source.Text = dt.Rows[0]["Mgmt_Staff_Facilities_Evidence_Source_txt"].ToString();
            txt_6_4_explain_judgements.Text = dt.Rows[0]["Mgmt_Staff_Facilities_Judg_txt"].ToString();
            ddl_6_4_2_grade.SelectedValue = dt.Rows[0]["Mgmt_Staff_Facilities_grade2"].ToString();
            ddl_6_4_3_grade.SelectedValue = dt.Rows[0]["Mgmt_Staff_Facilities_grade3"].ToString();
            ddl_6_4_4_grade.SelectedValue = dt.Rows[0]["Mgmt_Staff_Facilities_grade4"].ToString();
        }
        else
        {
            PS6_Fields_Clear();
        }
        dt = null;
    }

    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Call_All_Performance_Standard();
    }


    protected void Compare_Dropdown_Values()
    {
        if (ddl_2_1_4_grade.SelectedItem.Text.ToString().Trim() != ddl_5_2_2_grade.SelectedItem.Text.ToString().Trim())
        {

            //ddl_5_2_2_grade.BackColor = System.Drawing.Color.Orange;
        }
        else
        {
            ddl_5_2_2_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }


        //2
        if (ddl_3_1_overall_grade.SelectedItem.Text.ToString().Trim() != ddl_4_1_overall_grade_eyfs_ks1_ks2_ks3.SelectedItem.Text.ToString().Trim())
        {

            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        else
        {
            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }




        //3
        if (ddl_3_1_overall_grade.SelectedItem.Text.ToString().Trim() != ddl_6_1_2_grade.SelectedItem.Text.ToString().Trim())
        {

            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        else
        {
            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        ////4
        //if (ddl_6_2_3_grade.SelectedItem.Text.ToString().Trim() != ddl_3_1_overall_grade.SelectedItem.Text.ToString().Trim())
        if (ddl_3_1_overall_grade.SelectedItem.Text.ToString().Trim() != ddl_6_2_3_grade.SelectedItem.Text.ToString().Trim())
        {

            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        else
        {
            ddl_3_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }




        if (ddl_2_1_overall_grade.SelectedItem.Text.ToString().Trim() != ddl_5_2_1_grade.SelectedItem.Text.ToString().Trim())
        {
            //ddl_5_2_1_grade.BackColor = System.Drawing.Color.Orange;
            ddl_2_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        else
        {
            //ddl_5_2_1_grade.BackColor = System.Drawing.Color.WhiteSmoke;
            ddl_2_1_overall_grade.BackColor = System.Drawing.Color.WhiteSmoke;
        }
    }


    //-----SR Work Start
    DataSet ExecuteProcedureGradeConsolidation(string centerID, string sessionId)
    {
        DALBase objBase = new DALBase();
        DataSet DT_Data = null;
        //obj_Access.CreateProcedureCommand("SP_SIQA_SEF_evalution");
        //obj_Access.AddParameter("centerID", centerID, DataAccess.SQLParameterType.Number, true);
        //obj_Access.AddParameter("KS_Value", ksVal, DataAccess.SQLParameterType.VarChar, true);
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@centerID", centerID);
        param[1] = new SqlParameter("@session_ID", sessionId);


        try
        {
            DT_Data = objBase.sqlcmdFetch_DS("sef_SIQA_Con_AimsCalulations_new", param);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    DataSet ExecuteProcedureGradeConsolidationHistory(string centerID, string sessionId)
    {
        DALBase objBase = new DALBase();
        DataSet DT_Data = null;
        //obj_Access.CreateProcedureCommand("SP_SIQA_SEF_evalution");
        //obj_Access.AddParameter("centerID", centerID, DataAccess.SQLParameterType.Number, true);
        //obj_Access.AddParameter("KS_Value", ksVal, DataAccess.SQLParameterType.VarChar, true);
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@centerID", centerID);
        param[1] = new SqlParameter("@session_ID", sessionId);


        try
        {
            DT_Data = objBase.sqlcmdFetch_DS("sef_SIQA_Con_AimsCalulations_History", param);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    DataSet ExecuteProcedureGradeConsolidation_GetData(string regionID, string centerID, string sessionId)
    {
        DALBase objBase = new DALBase();
        DataSet DT_Data = null;
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_Id", regionID);
        param[1] = new SqlParameter("@Center_Id", centerID);
        param[2] = new SqlParameter("@Session_ID", sessionId);

        try
        {
            DT_Data = objBase.sqlcmdFetch_DS("SEF_Consolidaion_GETDATA", param);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    protected void ddl_Session_SelectedIndexChanged(object sender, EventArgs e)
    {
        Call_All_Performance_Standard();
    }

    protected void btn_ConSave_Click(object sender, EventArgs e)
    {
        if (ddl_KS_wise_EYFS.SelectedValue.ToString() != "" && ddl_Overall_Perf_All.SelectedValue.ToString() != "")
        {
            Consolidation_KeystageWise_Fields_Insert();
            // Consolidation_OverallPerf_Fields_Insert();
            ConsolidationBody();
            Load_Consolodation_Data(ddl_region.SelectedValue.ToString(), ddl_center.SelectedValue.ToString(), ddl_Session.SelectedValue.ToString());
        }

    }

    protected void btn_ConSiqaEndrosed_Click(object sender, EventArgs e)
    {
        Consolidation_KeystageWise_Fields_SIqaEnd_Updated();
        ConsolidationBody();
        ConsolidationBodyHistory();
    }

    public void ConsolidationBody()
    {
        string makehtml = "";
        string makehtmlPS2 = "";

        try
        {


            DataSet dt = new DataSet();

            string cenID = ddl_center.SelectedItem.Value;
            string sessID = ddl_Session.SelectedValue.ToString();//Session["Session_Id"].ToString();
            dt = ExecuteProcedureGradeConsolidation(cenID, sessID);


            if (dt != null)
            {
                for (int i = 0; i < dt.Tables[1].Rows.Count; i++)
                {
                    //    makehtml += "<tr>\r\n <td rowspan=\"4\">"+ dt.Tables[1].Rows[i]["Subject_Name"] + "</td>\r\n            <td rowspan=\"2\">1.1 Attainment</td>\r\n            <td>2021-22</td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n        </tr>\r\n        <tr class=\"SecondRow\">\r\n            \r\n            <td >2022-23</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n            <td >0</td>\r\n        </tr>\r\n        <tr >\r\n            <td rowspan=\"2\">1.2 Progress</td>\r\n            <td>2021-22</td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n        </tr>\r\n        <tr class=\"SecondRow\">\r\n            <td>2022-23</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n            <td>0</td>\r\n        </tr>";
                    //    makehtml += "  <tr>\n" +
                    //"     <td rowspan=\"2\">" + dt.Tables[1].Rows[i]["Subject_Name"] + "</td>\n" +
                    //"     <td rowspan=\"1\">1.1 Attainment</td>\n";

                    //    for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                    //    {
                    //        DataRow[] dtvaluesEYFS = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'EYFS'");
                    //        DataRow[] dtvaluesKS1 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS1'");
                    //        DataRow[] dtvaluesKS2 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS2'");
                    //        DataRow[] dtvaluesKS3 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS3'");
                    //        DataRow[] dtvaluesKS4 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS4'");
                    //        DataRow[] dtvaluesKS5 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS5'");
                    //        DataRow[] dtvaluesMatric = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'Matric'");


                    //        //if (k > 0)
                    //        //{
                    //        //    makehtml += "<tr class=\"SecondRow\">\n";
                    //        //    makehtml += "     <td>" + dt.Tables[2].Rows[k]["Description"].ToString() + "</td>\n";

                    //        //    string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //        //    EYFS = dtvaluesEYFS.Length > 0 ? EYFS = dtvaluesEYFS[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    KS1 = dtvaluesKS1.Length > 0 ? dtvaluesKS1[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    KS2 = dtvaluesKS2.Length > 0 ? dtvaluesKS2[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    KS3 = dtvaluesKS3.Length > 0 ? dtvaluesKS3[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    KS4 = dtvaluesKS4.Length > 0 ? dtvaluesKS4[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    KS5 = dtvaluesKS5.Length > 0 ? dtvaluesKS5[0]["Attainment_overall_grade"].ToString() : "";
                    //        //    Matric = dtvaluesMatric.Length > 0 ? dtvaluesMatric[0]["Attainment_overall_grade"].ToString() : "";

                    //        //    makehtml +=
                    //        //           "     <td>" + EYFS + "</td>\n" +
                    //        //           "     <td>" + KS1 + "</td>\n" +
                    //        //           "     <td>" + KS2 + "</td>\n" +
                    //        //           "     <td>" + KS3 + "</td>\n" +
                    //        //           "     <td>" + KS4 + "</td>\n" +
                    //        //           "     <td>" + KS5 + "</td>\n" +
                    //        //           "     <td>" + Matric + "</td>\n" +
                    //        //           " </tr>\n";
                    //        //}
                    //        //  else
                    //        // {
                    //        makehtml += "     <td>" + dt.Tables[2].Rows[k]["Description"].ToString() + "</td>\n";
                    //        string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //        EYFS = dtvaluesEYFS.Length > 0 ? EYFS = dtvaluesEYFS[0]["Attainment_overall_grade"].ToString() : "";
                    //        KS1 = dtvaluesKS1.Length > 0 ? dtvaluesKS1[0]["Attainment_overall_grade"].ToString() : "";
                    //        KS2 = dtvaluesKS2.Length > 0 ? dtvaluesKS2[0]["Attainment_overall_grade"].ToString() : "";
                    //        KS3 = dtvaluesKS3.Length > 0 ? dtvaluesKS3[0]["Attainment_overall_grade"].ToString() : "";
                    //        KS4 = dtvaluesKS4.Length > 0 ? dtvaluesKS4[0]["Attainment_overall_grade"].ToString() : "";
                    //        KS5 = dtvaluesKS5.Length > 0 ? dtvaluesKS5[0]["Attainment_overall_grade"].ToString() : "";
                    //        Matric = dtvaluesMatric.Length > 0 ? dtvaluesMatric[0]["Attainment_overall_grade"].ToString() : "";

                    //        makehtml +=
                    //               "     <td>" + EYFS + "</td>\n" +
                    //               "     <td>" + KS1 + "</td>\n" +
                    //               "     <td>" + KS2 + "</td>\n" +
                    //               "     <td>" + KS3 + "</td>\n" +
                    //               "     <td>" + KS4 + "</td>\n" +
                    //               "     <td>" + KS5 + "</td>\n" +
                    //               "     <td>" + Matric + "</td>\n" +
                    //               " </tr>\n";
                    //        //    }


                    //    }

                    //    makehtml += " <tr >\n" +
                    //  "<td rowspan=\"1\">1.2 Progress</td>\n";
                    //    for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                    //    {
                    //        DataRow[] dtvaluesEYFS = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'EYFS'");
                    //        DataRow[] dtvaluesKS1 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS1'");
                    //        DataRow[] dtvaluesKS2 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS2'");
                    //        DataRow[] dtvaluesKS3 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS3'");
                    //        DataRow[] dtvaluesKS4 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS4'");
                    //        DataRow[] dtvaluesKS5 = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'KS5'");
                    //        DataRow[] dtvaluesMatric = dt.Tables[4].Select("Subject_Name = '" + dt.Tables[1].Rows[i]["Subject_Name"] + "' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + " and Group_Name = 'Matric'");


                    //        //if (k > 0)
                    //        //{
                    //        //    makehtml += "<tr class=\"SecondRow\">\n";
                    //        //    makehtml += "     <td>" + dt.Tables[2].Rows[k]["Description"].ToString() + "</td>\n";
                    //        //    string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //        //    EYFS = dtvaluesEYFS.Length > 0 ? EYFS = dtvaluesEYFS[0]["Progress_overall_grade"].ToString() : "";
                    //        //    KS1 = dtvaluesKS1.Length > 0 ? dtvaluesKS1[0]["Progress_overall_grade"].ToString() : "";
                    //        //    KS2 = dtvaluesKS2.Length > 0 ? dtvaluesKS2[0]["Progress_overall_grade"].ToString() : "";
                    //        //    KS3 = dtvaluesKS3.Length > 0 ? dtvaluesKS3[0]["Progress_overall_grade"].ToString() : "";
                    //        //    KS4 = dtvaluesKS4.Length > 0 ? dtvaluesKS4[0]["Progress_overall_grade"].ToString() : "";
                    //        //    KS5 = dtvaluesKS5.Length > 0 ? dtvaluesKS5[0]["Progress_overall_grade"].ToString() : "";
                    //        //    Matric = dtvaluesMatric.Length > 0 ? dtvaluesMatric[0]["Progress_overall_grade"].ToString() : "";

                    //        //    makehtml +=
                    //        //           "     <td>" + EYFS + "</td>\n" +
                    //        //           "     <td>" + KS1 + "</td>\n" +
                    //        //           "     <td>" + KS2 + "</td>\n" +
                    //        //           "     <td>" + KS3 + "</td>\n" +
                    //        //           "     <td>" + KS4 + "</td>\n" +
                    //        //           "     <td>" + KS5 + "</td>\n" +
                    //        //           "     <td>" + Matric + "</td>\n" +
                    //        //           " </tr>\n";
                    //        //}
                    //        //else
                    //        //{
                    //        makehtml += "     <td>" + dt.Tables[2].Rows[k]["Description"].ToString() + "</td>\n";
                    //        string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //        EYFS = dtvaluesEYFS.Length > 0 ? EYFS = dtvaluesEYFS[0]["Progress_overall_grade"].ToString() : "";
                    //        KS1 = dtvaluesKS1.Length > 0 ? dtvaluesKS1[0]["Progress_overall_grade"].ToString() : "";
                    //        KS2 = dtvaluesKS2.Length > 0 ? dtvaluesKS2[0]["Progress_overall_grade"].ToString() : "";
                    //        KS3 = dtvaluesKS3.Length > 0 ? dtvaluesKS3[0]["Progress_overall_grade"].ToString() : "";
                    //        KS4 = dtvaluesKS4.Length > 0 ? dtvaluesKS4[0]["Progress_overall_grade"].ToString() : "";
                    //        KS5 = dtvaluesKS5.Length > 0 ? dtvaluesKS5[0]["Progress_overall_grade"].ToString() : "";
                    //        Matric = dtvaluesMatric.Length > 0 ? dtvaluesMatric[0]["Progress_overall_grade"].ToString() : "";

                    //        makehtml +=
                    //               "     <td>" + EYFS + "</td>\n" +
                    //               "     <td>" + KS1 + "</td>\n" +
                    //               "     <td>" + KS2 + "</td>\n" +
                    //               "     <td>" + KS3 + "</td>\n" +
                    //               "     <td>" + KS4 + "</td>\n" +
                    //               "     <td>" + KS5 + "</td>\n" +
                    //               "     <td>" + Matric + "</td>\n" +
                    //               " </tr>\n";
                    //        //  }
                    //    }


                }


                //DataRow[] dtvaluesOSEYFS = dt.Tables[5].Select("Group_Name = 'EYFS'");
                //DataRow[] dtvaluesOSKS1 = dt.Tables[5].Select("Group_Name = 'KS1'");
                //DataRow[] dtvaluesOSKS2 = dt.Tables[5].Select("Group_Name = 'KS2'");
                //DataRow[] dtvaluesOSKS3 = dt.Tables[5].Select("Group_Name = 'KS3'");
                //DataRow[] dtvaluesOSKS4 = dt.Tables[5].Select("Group_Name = 'KS4'");
                //DataRow[] dtvaluesOSKS5 = dt.Tables[5].Select("Group_Name = 'KS5'");
                //DataRow[] dtvaluesOSMatric = dt.Tables[5].Select("Group_Name = 'Matric'");

                //string osEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["OSPer"].ToString() : "0";
                //string OSKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["OSPer"].ToString() : "0";
                //string OSKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["OSPer"].ToString() : "0";
                //string OSKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["OSPer"].ToString() : "0";
                //string OSKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["OSPer"].ToString() : "0";
                //string OSKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["OSPer"].ToString() : "0";
                //string OSMatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["OSPer"].ToString() : "0";


                //         makehtml += "  <tr>" +
                //     "<td colspan='2'> %age of subjects with OS attainment</td>" +
                //          " <td >%</td>" +
                //          " <td>" + osEYFS + "</td> " +
                //          " <td>" + OSKS1 + "</td> " +
                //          " <td>" + OSKS2 + "</td> " +
                //          " <td>" + OSKS3 + "</td> " +
                //          " <td>" + OSKS4 + "</td> " +
                //          " <td>" + OSKS5 + "</td> " +
                //          " <td>" + OSMatric + "</td> " +
                //     "</tr>";



                //         string GoodEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["GoodPer"].ToString() : "0";
                //         string GoodKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["GoodPer"].ToString() : "0";
                //         string GoodKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["GoodPer"].ToString() : "0";
                //         string GoodKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["GoodPer"].ToString() : "0";
                //         string GoodKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["GoodPer"].ToString() : "0";
                //         string GoodKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["GoodPer"].ToString() : "0";
                //         string GoodMatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["GoodPer"].ToString() : "0";
                //         makehtml += "  <tr>" +
                // "<td colspan='2'>%age of subjects with Good attainment</td>" +
                //      " <td >%</td>" +
                //      " <td>" + GoodEYFS + "</td> " +
                //      " <td>" + GoodKS1 + "</td> " +
                //      " <td>" + GoodKS2 + "</td> " +
                //      " <td>" + GoodKS3 + "</td> " +
                //      " <td>" + GoodKS4 + "</td> " +
                //      " <td>" + GoodKS5 + "</td> " +
                //      " <td>" + GoodMatric + "</td> " +
                // "</tr>";



                //         string AccEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["AccPer"].ToString() : "0";
                //         string AccKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["AccPer"].ToString() : "0";
                //         string AccKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["AccPer"].ToString() : "0";
                //         string AccKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["AccPer"].ToString() : "0";
                //         string AccKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["AccPer"].ToString() : "0";
                //         string AccKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["AccPer"].ToString() : "0";
                //         string AccMatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["AccPer"].ToString() : "0";
                //         makehtml += "  <tr>" +
                //    "<td colspan='2'>%age of subjects with Acc attainment</td>" +
                //         " <td >%</td>" +
                //         " <td>" + AccEYFS + "</td> " +
                //         " <td>" + AccKS1 + "</td> " +
                //         " <td>" + AccKS2 + "</td> " +
                //         " <td>" + AccKS3 + "</td> " +
                //         " <td>" + AccKS4 + "</td> " +
                //         " <td>" + AccKS5 + "</td> " +
                //         " <td>" + AccMatric + "</td> " +
                //    "</tr>";


                //         string UAEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["UAPer"].ToString() : "0";
                //         string UAKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["UAPer"].ToString() : "0";
                //         string UAKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["UAPer"].ToString() : "0";
                //         string UAKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["UAPer"].ToString() : "0";
                //         string UAKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["UAPer"].ToString() : "0";
                //         string UAKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["UAPer"].ToString() : "0";
                //         string UAMatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["UAPer"].ToString() : "0";

                //         makehtml += "  <tr>" +
                //"<td colspan='2'>%age of subjects with UA attainment</td>" +
                //     " <td >%</td>" +
                //     " <td>" + UAEYFS + "</td> " +
                //     " <td>" + UAKS1 + "</td> " +
                //     " <td>" + UAKS2 + "</td> " +
                //     " <td>" + UAKS3 + "</td> " +
                //     " <td>" + UAKS4 + "</td> " +
                //     " <td>" + UAKS5 + "</td> " +
                //     " <td>" + AccMatric + "</td> " +
                //"</tr>";

                // 1.1 Attaiment

                makehtml += "  <tr>\n" +
            " <td  colspan=\"2\">1.1 Attainment</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {
                    DataRow[] dtvaluesOSEYFS = dt.Tables[5].Select("Group_Name = 'EYFS'");
                    DataRow[] dtvaluesOSKS1 = dt.Tables[5].Select("Group_Name = 'KS1'");
                    DataRow[] dtvaluesOSKS2 = dt.Tables[5].Select("Group_Name = 'KS2'");
                    DataRow[] dtvaluesOSKS3 = dt.Tables[5].Select("Group_Name = 'KS3'");
                    DataRow[] dtvaluesOSKS4 = dt.Tables[5].Select("Group_Name = 'KS4'");
                    DataRow[] dtvaluesOSKS5 = dt.Tables[5].Select("Group_Name = 'KS5'");
                    DataRow[] dtvaluesOSMatric = dt.Tables[5].Select("Group_Name = 'Matric'");

                    string osEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["OSPer"].ToString() : "0";
                    string AccEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["AccPer"].ToString() : "0";
                    string GOODEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["GoodPer"].ToString() : "0";
                    string UAsEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["UAPer"].ToString() : "0";
                    string emEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["emPer"].ToString() : "0";


                    string finalEYFS = "";

                    if (float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "OS";
                    }
                    else if (float.Parse(GOODEYFS) + float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "Good";
                    }
                    else if (float.Parse(AccEYFS) + float.Parse(GOODEYFS) + float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "Acc";
                    }

                    if (float.Parse(UAsEYFS) > 25)
                    {
                        finalEYFS = "UA";
                    }



                    string osKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["OSPer"].ToString() : "0";
                    string AccKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["AccPer"].ToString() : "0";
                    string GOODKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["GoodPer"].ToString() : "0";
                    string UAKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["UAPer"].ToString() : "0";
                    string emKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["emPer"].ToString() : "0";


                    string finalKS1 = "";

                    if (float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "OS";
                    }
                    else if (float.Parse(GOODKS1) + float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "Good";
                    }
                    else if (float.Parse(AccKS1) + float.Parse(GOODKS1) + float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "Acc";
                    }

                    if (float.Parse(UAKS1) > 25)
                    {
                        finalKS1 = "UA";
                    }

                    //KS2

                    string osKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["OSPer"].ToString() : "0";
                    string AccKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["AccPer"].ToString() : "0";
                    string GOODKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["GoodPer"].ToString() : "0";
                    string UAKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["UAPer"].ToString() : "0";
                    string emKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["emPer"].ToString() : "0";


                    string finalKS2 = "";

                    if (float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "OS";
                    }
                    else if (float.Parse(GOODKS2) + float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "Good";
                    }
                    else if (float.Parse(AccKS2) + float.Parse(GOODKS2) + float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "Acc";
                    }

                    if (float.Parse(UAKS2) > 25)
                    {
                        finalKS2 = "UA";
                    }

                    //KS3

                    string osKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["OSPer"].ToString() : "0";
                    string AccKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["AccPer"].ToString() : "0";
                    string GOODKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["GoodPer"].ToString() : "0";
                    string UAKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["UAPer"].ToString() : "0";
                    string emKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["emPer"].ToString() : "0";


                    string finalKS3 = "";

                    if (float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "OS";
                    }
                    else if (float.Parse(GOODKS3) + float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "Good";
                    }
                    else if (float.Parse(AccKS3) + float.Parse(GOODKS3) + float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "Acc";
                    }

                    if (float.Parse(UAKS3) > 25)
                    {
                        finalKS3 = "UA";
                    }


                    //ks4

                    string osKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["OSPer"].ToString() : "0";
                    string AccKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["AccPer"].ToString() : "0";
                    string GOODKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["GoodPer"].ToString() : "0";
                    string UAKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["UAPer"].ToString() : "0";
                    string emKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["emPer"].ToString() : "0";


                    string finalKS4 = "";

                    if (float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "OS";
                    }
                    else if (float.Parse(GOODKS4) + float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "Good";
                    }
                    else if (float.Parse(AccKS4) + float.Parse(GOODKS4) + float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "Acc";
                    }

                    if (float.Parse(UAKS4) > 25)
                    {
                        finalKS4 = "UA";
                    }

                    //ks5
                    string osKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["OSPer"].ToString() : "0";
                    string AccKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["AccPer"].ToString() : "0";
                    string GOODKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["GoodPer"].ToString() : "0";
                    string UAKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["UAPer"].ToString() : "0";
                    string emKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["emPer"].ToString() : "0";


                    string finalKS5 = "";

                    if (float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "OS";
                    }
                    else if (float.Parse(GOODKS5) + float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "Good";
                    }
                    else if (float.Parse(AccKS5) + float.Parse(GOODKS5) + float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "Acc";
                    }

                    if (float.Parse(UAKS5) > 25)
                    {
                        finalKS5 = "UA";
                    }

                    //matric
                    string osmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["OSPer"].ToString() : "0";
                    string Accmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["AccPer"].ToString() : "0";
                    string GOODmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["GoodPer"].ToString() : "0";
                    string UAmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["UAPer"].ToString() : "0";
                    string emmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["emPer"].ToString() : "0";


                    string finalmatric = "";

                    if (float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "OS";
                    }
                    else if (float.Parse(GOODmatric) + float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "Good";
                    }
                    else if (float.Parse(Accmatric) + float.Parse(GOODmatric) + float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "Acc";
                    }

                    if (float.Parse(UAmatric) > 25)
                    {
                        finalmatric = "UA";
                    }

                    makehtml +=
                        "     <td>" + finalEYFS + "</td>\n" +
                        "     <td>" + finalKS1 + "</td>\n" +
                        "     <td>" + finalKS2 + "</td>\n" +
                        "     <td>" + finalKS3 + "</td>\n" +
                        "     <td>" + finalKS4 + "</td>\n" +
                        "     <td>" + finalKS5 + "</td>\n" +
                        "     <td>" + finalmatric + "</td>\n" +
                        " </tr>\n";

                    //string OSKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["OSPer"].ToString() : "0";
                    //string OSKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["OSPer"].ToString() : "0";
                    //string OSKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["OSPer"].ToString() : "0";
                    //string OSKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["OSPer"].ToString() : "0";
                    //string OSKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["OSPer"].ToString() : "0";
                    //string OSMatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["OSPer"].ToString() : "0";

                    //DataRow[] dtLearningSkillEYFS = dt.Tables[0].Select("Group_Name = 'EYFS' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS1 = dt.Tables[0].Select("Group_Name = 'KS1' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS2 = dt.Tables[0].Select("Group_Name = 'KS2' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS3 = dt.Tables[0].Select("Group_Name = 'KS3' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS4 = dt.Tables[0].Select("Group_Name = 'KS4' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS5 = dt.Tables[0].Select("Group_Name = 'KS5' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillMatric = dt.Tables[0].Select("Group_Name = 'Matric' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");



                    //string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //EYFS = dtLearningSkillEYFS.Length > 0 ? dtLearningSkillEYFS[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS1 = dtLearningSkillKS1.Length > 0 ? dtLearningSkillKS1[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS2 = dtLearningSkillKS2.Length > 0 ? dtLearningSkillKS2[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS3 = dtLearningSkillKS3.Length > 0 ? dtLearningSkillKS3[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS4 = dtLearningSkillKS4.Length > 0 ? dtLearningSkillKS4[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS5 = dtLearningSkillKS5.Length > 0 ? dtLearningSkillKS5[0]["Learning_Skill_grade1"].ToString() : "";
                    //Matric = dtLearningSkillMatric.Length > 0 ? dtLearningSkillMatric[0]["Learning_Skill_grade1"].ToString() : "";




                }




                // 1.2 Progress
                makehtml += "  <tr>\n" +
             " <td  colspan=\"2\">1.2 Progress</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {

                    string[] groups = { "EYFS", "KS1", "KS2", "KS3", "KS4", "KS5", "Matric" };
                    string[] finalResults = new string[groups.Length];

                    for (int i = 0; i < groups.Length; i++)
                    {
                        DataRow[] dtValues = dt.Tables[11].Select("Group_Name = '" + groups[i] + "'");

                        string os = dtValues.Length > 0 ? dtValues[0]["OSPer"].ToString() : "0";
                        string acc = dtValues.Length > 0 ? dtValues[0]["AccPer"].ToString() : "0";
                        string good = dtValues.Length > 0 ? dtValues[0]["GoodPer"].ToString() : "0";
                        string ua = dtValues.Length > 0 ? dtValues[0]["UAPer"].ToString() : "0";
                        string em = dtValues.Length > 0 ? dtValues[0]["emPer"].ToString() : "0";

                        string final = "";
                        //2024-11-05
                        // if (float.Parse(os) >= 75)
                        // {
                        //     final = "OS";
                        //  }
                        //  if (float.Parse(good) + float.Parse(os) >= 75)
                        // {
                        //     final = "Good";
                        //  }
                        //if (float.Parse(acc) + float.Parse(good) + float.Parse(os) >= 75)
                        //  {
                        //    final = "Acc";
                        // }
                        // if (float.Parse(ua) > 25)
                        // {
                        //     final = "UA";
                        // }


                        if (float.Parse(os) >= 75)
                        {
                            final = "OS";
                        }
                        else if (float.Parse(ua) > 25)
                        {
                            final = "UA";
                        }
                        else if (float.Parse(good) + float.Parse(os) >= 75)
                        {
                            final = "Good";
                        }
                        else if (float.Parse(acc) + float.Parse(good) + float.Parse(os) >= 75)
                        {
                            final = "Acc";
                        }

                        finalResults[i] = final;
                    }



                    //DataRow[] dtLearningSkillEYFS = dt.Tables[0].Select("Group_Name = 'EYFS' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS1 = dt.Tables[0].Select("Group_Name = 'KS1' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS2 = dt.Tables[0].Select("Group_Name = 'KS2' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS3 = dt.Tables[0].Select("Group_Name = 'KS3' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS4 = dt.Tables[0].Select("Group_Name = 'KS4' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillKS5 = dt.Tables[0].Select("Group_Name = 'KS5' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    //DataRow[] dtLearningSkillMatric = dt.Tables[0].Select("Group_Name = 'Matric' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");



                    //string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    //EYFS = dtLearningSkillEYFS.Length > 0 ? dtLearningSkillEYFS[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS1 = dtLearningSkillKS1.Length > 0 ? dtLearningSkillKS1[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS2 = dtLearningSkillKS2.Length > 0 ? dtLearningSkillKS2[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS3 = dtLearningSkillKS3.Length > 0 ? dtLearningSkillKS3[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS4 = dtLearningSkillKS4.Length > 0 ? dtLearningSkillKS4[0]["Learning_Skill_grade1"].ToString() : "";
                    //KS5 = dtLearningSkillKS5.Length > 0 ? dtLearningSkillKS5[0]["Learning_Skill_grade1"].ToString() : "";
                    //Matric = dtLearningSkillMatric.Length > 0 ? dtLearningSkillMatric[0]["Learning_Skill_grade1"].ToString() : "";

                    makehtml +=
                           "     <td>" + finalResults[0] + "</td>\n" +
                           "     <td>" + finalResults[1] + "</td>\n" +
                           "     <td>" + finalResults[2] + "</td>\n" +
                           "     <td>" + finalResults[3] + "</td>\n" +
                           "     <td>" + finalResults[4] + "</td>\n" +
                           "     <td>" + finalResults[5] + "</td>\n" +
                           "     <td>" + finalResults[6] + "</td>\n" +
                           " </tr>\n";


                }

                // Learnig Skill Section

                makehtml += "  <tr>\n" +
              "     <td  colspan=\"2\">1.3 Learning Skills</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {
                    DataRow[] dtLearningSkillEYFS = dt.Tables[0].Select("Group_Name = 'EYFS' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS1 = dt.Tables[0].Select("Group_Name = 'KS1' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS2 = dt.Tables[0].Select("Group_Name = 'KS2' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS3 = dt.Tables[0].Select("Group_Name = 'KS3' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS4 = dt.Tables[0].Select("Group_Name = 'KS4' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS5 = dt.Tables[0].Select("Group_Name = 'KS5' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillMatric = dt.Tables[0].Select("Group_Name = 'Matric' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");



                    string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    EYFS = dtLearningSkillEYFS.Length > 0 ? dtLearningSkillEYFS[0]["Learning_Skill_grade1"].ToString() : "";
                    KS1 = dtLearningSkillKS1.Length > 0 ? dtLearningSkillKS1[0]["Learning_Skill_grade1"].ToString() : "";
                    KS2 = dtLearningSkillKS2.Length > 0 ? dtLearningSkillKS2[0]["Learning_Skill_grade1"].ToString() : "";
                    KS3 = dtLearningSkillKS3.Length > 0 ? dtLearningSkillKS3[0]["Learning_Skill_grade1"].ToString() : "";
                    KS4 = dtLearningSkillKS4.Length > 0 ? dtLearningSkillKS4[0]["Learning_Skill_grade1"].ToString() : "";
                    KS5 = dtLearningSkillKS5.Length > 0 ? dtLearningSkillKS5[0]["Learning_Skill_grade1"].ToString() : "";
                    Matric = dtLearningSkillMatric.Length > 0 ? dtLearningSkillMatric[0]["Learning_Skill_grade1"].ToString() : "";

                    makehtml +=
                           "     <td>" + EYFS + "</td>\n" +
                           "     <td>" + KS1 + "</td>\n" +
                           "     <td>" + KS2 + "</td>\n" +
                           "     <td>" + KS3 + "</td>\n" +
                           "     <td>" + KS4 + "</td>\n" +
                           "     <td>" + KS5 + "</td>\n" +
                           "     <td>" + Matric + "</td>\n" +
                           " </tr>\n";
                    // }


                }



                Htmlbody.Text = makehtml;


                // PS 2 


                StringBuilder makehtmlPS21 = new StringBuilder();
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.1 Personal Development", "Personal_dev_overall_grade"));
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.2 Social Values", "Social_Values_grade1"));
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.3 Social Responsibility", "Social_Responsibility_grade1"));

                HtmlPS2.Text = makehtmlPS21.ToString();


                StringBuilder makehtmlPS3 = new StringBuilder();
                makehtmlPS3.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[7], "3.1 Teaching for Effective Learning", "Teaching_Eff_Learning_grade1"));
                makehtmlPS3.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[7], "3.2 Assessment", "Assessment_overall_grade"));

                HtmlPS3.Text = makehtmlPS3.ToString();

                StringBuilder makehtmlPS4 = new StringBuilder();
                makehtmlPS4.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[8], "4.1 Curriculum Implementation", "Curriculum_Imp_Cross_Curricular_grade_E123"));
                makehtmlPS4.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[8], "4.2 Curriculum Adaptation", "Curriculum_Adaptation_Overall_grade"));




                HtmlPS4.Text = makehtmlPS4.ToString();


                StringBuilder makehtmlPS5 = new StringBuilder();
                makehtmlPS5.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[9], "5.1 Health, Safety and Safeguarding", "Health_And_Safety_overall_grade"));
                makehtmlPS5.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[9], "5.2 Care & Support", "Care_And_Support_overall_grade"));




                HtmlPS5.Text = makehtmlPS5.ToString();

                StringBuilder makehtmlPS6 = new StringBuilder();
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.1 Effectiveness of Leadership", "Eff_of_Leadership_overall_grade"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.2 Self-evaluation and Improvement Planning", "Sef_Imp_Planning_overall_grade1"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.3 Partnership with Parents and Community", "Partnership_With_Parents_Comm_overall_grade"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.4 Management, Staffing, Facilities & Resources", "Mgmt_Staff_Facilities_overall_grade"));




                HtmlPS6.Text = makehtmlPS6.ToString();



            }
            else
            {
                ImpromptuHelper.ShowPrompt("No Data Found");
            }

            //   gvps1child.DataSource = dt;
            //   gvps1child.DataBind();
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void ConsolidationBodyHistory()
    {
        string makehtml = "";
        string makehtmlPS2 = "";
        try
        {
            DataSet dt = new DataSet();

            string cenID = ddl_center.SelectedItem.Value;
            string sessID = ddl_Session.SelectedValue.ToString();//Session["Session_Id"].ToString();
            dt = ExecuteProcedureGradeConsolidationHistory(cenID, sessID);
            if (dt != null)
            {

                // 1.1 Attaiment

                makehtml += "  <tr>\n" +
            " <td  colspan=\"2\">1.1 Attainment</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {
                    DataRow[] dtvaluesOSEYFS = dt.Tables[5].Select("Group_Name = 'EYFS'");
                    DataRow[] dtvaluesOSKS1 = dt.Tables[5].Select("Group_Name = 'KS1'");
                    DataRow[] dtvaluesOSKS2 = dt.Tables[5].Select("Group_Name = 'KS2'");
                    DataRow[] dtvaluesOSKS3 = dt.Tables[5].Select("Group_Name = 'KS3'");
                    DataRow[] dtvaluesOSKS4 = dt.Tables[5].Select("Group_Name = 'KS4'");
                    DataRow[] dtvaluesOSKS5 = dt.Tables[5].Select("Group_Name = 'KS5'");
                    DataRow[] dtvaluesOSMatric = dt.Tables[5].Select("Group_Name = 'Matric'");

                    string osEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["OSPer"].ToString() : "0";
                    string AccEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["AccPer"].ToString() : "0";
                    string GOODEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["GoodPer"].ToString() : "0";
                    string UAsEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["UAPer"].ToString() : "0";
                    string emEYFS = dtvaluesOSEYFS.Length > 0 ? dtvaluesOSEYFS[0]["emPer"].ToString() : "0";


                    string finalEYFS = "";

                    if (float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "OS";
                    }
                    else if (float.Parse(GOODEYFS) + float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "Good";
                    }
                    else if (float.Parse(AccEYFS) + float.Parse(GOODEYFS) + float.Parse(osEYFS) >= 75)
                    {
                        finalEYFS = "Acc";
                    }

                    if (float.Parse(UAsEYFS) > 25)
                    {
                        finalEYFS = "UA";
                    }
                    string osKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["OSPer"].ToString() : "0";
                    string AccKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["AccPer"].ToString() : "0";
                    string GOODKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["GoodPer"].ToString() : "0";
                    string UAKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["UAPer"].ToString() : "0";
                    string emKS1 = dtvaluesOSKS1.Length > 0 ? dtvaluesOSKS1[0]["emPer"].ToString() : "0";

                    string finalKS1 = "";

                    if (float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "OS";
                    }
                    else if (float.Parse(GOODKS1) + float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "Good";
                    }
                    else if (float.Parse(AccKS1) + float.Parse(GOODKS1) + float.Parse(osKS1) >= 75)
                    {
                        finalKS1 = "Acc";
                    }

                    if (float.Parse(UAKS1) > 25)
                    {
                        finalKS1 = "UA";
                    }
                    //KS2
                    string osKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["OSPer"].ToString() : "0";
                    string AccKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["AccPer"].ToString() : "0";
                    string GOODKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["GoodPer"].ToString() : "0";
                    string UAKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["UAPer"].ToString() : "0";
                    string emKS2 = dtvaluesOSKS2.Length > 0 ? dtvaluesOSKS2[0]["emPer"].ToString() : "0";

                    string finalKS2 = "";

                    if (float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "OS";
                    }
                    else if (float.Parse(GOODKS2) + float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "Good";
                    }
                    else if (float.Parse(AccKS2) + float.Parse(GOODKS2) + float.Parse(osKS2) >= 75)
                    {
                        finalKS2 = "Acc";
                    }

                    if (float.Parse(UAKS2) > 25)
                    {
                        finalKS2 = "UA";
                    }

                    //KS3
                    string osKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["OSPer"].ToString() : "0";
                    string AccKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["AccPer"].ToString() : "0";
                    string GOODKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["GoodPer"].ToString() : "0";
                    string UAKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["UAPer"].ToString() : "0";
                    string emKS3 = dtvaluesOSKS3.Length > 0 ? dtvaluesOSKS3[0]["emPer"].ToString() : "0";

                    string finalKS3 = "";

                    if (float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "OS";
                    }
                    else if (float.Parse(GOODKS3) + float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "Good";
                    }
                    else if (float.Parse(AccKS3) + float.Parse(GOODKS3) + float.Parse(osKS3) >= 75)
                    {
                        finalKS3 = "Acc";
                    }

                    if (float.Parse(UAKS3) > 25)
                    {
                        finalKS3 = "UA";
                    }

                    //ks4

                    string osKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["OSPer"].ToString() : "0";
                    string AccKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["AccPer"].ToString() : "0";
                    string GOODKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["GoodPer"].ToString() : "0";
                    string UAKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["UAPer"].ToString() : "0";
                    string emKS4 = dtvaluesOSKS4.Length > 0 ? dtvaluesOSKS4[0]["emPer"].ToString() : "0";

                    string finalKS4 = "";

                    if (float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "OS";
                    }
                    else if (float.Parse(GOODKS4) + float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "Good";
                    }
                    else if (float.Parse(AccKS4) + float.Parse(GOODKS4) + float.Parse(osKS4) >= 75)
                    {
                        finalKS4 = "Acc";
                    }

                    if (float.Parse(UAKS4) > 25)
                    {
                        finalKS4 = "UA";
                    }

                    //ks5
                    string osKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["OSPer"].ToString() : "0";
                    string AccKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["AccPer"].ToString() : "0";
                    string GOODKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["GoodPer"].ToString() : "0";
                    string UAKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["UAPer"].ToString() : "0";
                    string emKS5 = dtvaluesOSKS5.Length > 0 ? dtvaluesOSKS5[0]["emPer"].ToString() : "0";


                    string finalKS5 = "";

                    if (float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "OS";
                    }
                    else if (float.Parse(GOODKS5) + float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "Good";
                    }
                    else if (float.Parse(AccKS5) + float.Parse(GOODKS5) + float.Parse(osKS5) >= 75)
                    {
                        finalKS5 = "Acc";
                    }

                    if (float.Parse(UAKS5) > 25)
                    {
                        finalKS5 = "UA";
                    }

                    //matric
                    string osmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["OSPer"].ToString() : "0";
                    string Accmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["AccPer"].ToString() : "0";
                    string GOODmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["GoodPer"].ToString() : "0";
                    string UAmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["UAPer"].ToString() : "0";
                    string emmatric = dtvaluesOSMatric.Length > 0 ? dtvaluesOSMatric[0]["emPer"].ToString() : "0";

                    string finalmatric = "";

                    if (float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "OS";
                    }
                    else if (float.Parse(GOODmatric) + float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "Good";
                    }
                    else if (float.Parse(Accmatric) + float.Parse(GOODmatric) + float.Parse(osmatric) >= 75)
                    {
                        finalmatric = "Acc";
                    }

                    if (float.Parse(UAmatric) > 25)
                    {
                        finalmatric = "UA";
                    }

                    makehtml +=
                        "     <td>" + finalEYFS + "</td>\n" +
                        "     <td>" + finalKS1 + "</td>\n" +
                        "     <td>" + finalKS2 + "</td>\n" +
                        "     <td>" + finalKS3 + "</td>\n" +
                        "     <td>" + finalKS4 + "</td>\n" +
                        "     <td>" + finalKS5 + "</td>\n" +
                        "     <td>" + finalmatric + "</td>\n" +
                        " </tr>\n";

                }
                // 1.2 Progress
                makehtml += "  <tr>\n" +
             " <td  colspan=\"2\">1.2 Progress</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {

                    string[] groups = { "EYFS", "KS1", "KS2", "KS3", "KS4", "KS5", "Matric" };
                    string[] finalResults = new string[groups.Length];

                    for (int i = 0; i < groups.Length; i++)
                    {
                        DataRow[] dtValues = dt.Tables[11].Select("Group_Name = '" + groups[i] + "'");

                        string os = dtValues.Length > 0 ? dtValues[0]["OSPer"].ToString() : "0";
                        string acc = dtValues.Length > 0 ? dtValues[0]["AccPer"].ToString() : "0";
                        string good = dtValues.Length > 0 ? dtValues[0]["GoodPer"].ToString() : "0";
                        string ua = dtValues.Length > 0 ? dtValues[0]["UAPer"].ToString() : "0";
                        string em = dtValues.Length > 0 ? dtValues[0]["emPer"].ToString() : "0";

                        string final = "";
                        //2024-11-06
                        /*  if (float.Parse(os) >= 75)
                          {
                              final = "OS";
                          }
                          if (float.Parse(good) + float.Parse(os) >= 75)
                          {
                              final = "Good";
                          }
                          if (float.Parse(acc) + float.Parse(good) + float.Parse(os) >= 75)
                          {
                              final = "Acc";
                          }
                          if (float.Parse(ua) > 25)
                          {
                              final = "UA";
                          }*/


                        if (float.Parse(os) >= 75)
                        {
                            final = "OS";
                        }
                        else if (float.Parse(ua) > 25)
                        {
                            final = "UA";
                        }
                        else if (float.Parse(good) + float.Parse(os) >= 75)
                        {
                            final = "Good";
                        }
                        else if (float.Parse(acc) + float.Parse(good) + float.Parse(os) >= 75)
                        {
                            final = "Acc";
                        }

                        finalResults[i] = final;
                    }
                    makehtml +=
                           "     <td>" + finalResults[0] + "</td>\n" +
                           "     <td>" + finalResults[1] + "</td>\n" +
                           "     <td>" + finalResults[2] + "</td>\n" +
                           "     <td>" + finalResults[3] + "</td>\n" +
                           "     <td>" + finalResults[4] + "</td>\n" +
                           "     <td>" + finalResults[5] + "</td>\n" +
                           "     <td>" + finalResults[6] + "</td>\n" +
                           " </tr>\n";


                }

                // Learnig Skill Section

                makehtml += "  <tr>\n" +
              "     <td  colspan=\"2\">1.3 Learning Skills</td>\n";
                for (int k = 0; k < dt.Tables[2].Rows.Count; k++)
                {
                    DataRow[] dtLearningSkillEYFS = dt.Tables[0].Select("Group_Name = 'EYFS' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS1 = dt.Tables[0].Select("Group_Name = 'KS1' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS2 = dt.Tables[0].Select("Group_Name = 'KS2' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS3 = dt.Tables[0].Select("Group_Name = 'KS3' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS4 = dt.Tables[0].Select("Group_Name = 'KS4' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillKS5 = dt.Tables[0].Select("Group_Name = 'KS5' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");
                    DataRow[] dtLearningSkillMatric = dt.Tables[0].Select("Group_Name = 'Matric' and Session_Id = " + dt.Tables[2].Rows[k]["Session_Id"] + "");



                    string EYFS, KS1, KS2, KS3, KS4, KS5, Matric;

                    EYFS = dtLearningSkillEYFS.Length > 0 ? dtLearningSkillEYFS[0]["Learning_Skill_grade1"].ToString() : "";
                    KS1 = dtLearningSkillKS1.Length > 0 ? dtLearningSkillKS1[0]["Learning_Skill_grade1"].ToString() : "";
                    KS2 = dtLearningSkillKS2.Length > 0 ? dtLearningSkillKS2[0]["Learning_Skill_grade1"].ToString() : "";
                    KS3 = dtLearningSkillKS3.Length > 0 ? dtLearningSkillKS3[0]["Learning_Skill_grade1"].ToString() : "";
                    KS4 = dtLearningSkillKS4.Length > 0 ? dtLearningSkillKS4[0]["Learning_Skill_grade1"].ToString() : "";
                    KS5 = dtLearningSkillKS5.Length > 0 ? dtLearningSkillKS5[0]["Learning_Skill_grade1"].ToString() : "";
                    Matric = dtLearningSkillMatric.Length > 0 ? dtLearningSkillMatric[0]["Learning_Skill_grade1"].ToString() : "";

                    makehtml +=
                           "     <td>" + EYFS + "</td>\n" +
                           "     <td>" + KS1 + "</td>\n" +
                           "     <td>" + KS2 + "</td>\n" +
                           "     <td>" + KS3 + "</td>\n" +
                           "     <td>" + KS4 + "</td>\n" +
                           "     <td>" + KS5 + "</td>\n" +
                           "     <td>" + Matric + "</td>\n" +
                           " </tr>\n";
                    // }


                }
                HtmlbodyHistory.Text = makehtml;

                // PS 2 

                StringBuilder makehtmlPS21 = new StringBuilder();
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.1 Personal Development", "Personal_dev_overall_grade"));
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.2 Social Values", "Social_Values_grade1"));
                makehtmlPS21.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[6], "2.3 Social Responsibility", "Social_Responsibility_grade1"));

                HtmlPS2History.Text = makehtmlPS21.ToString();


                StringBuilder makehtmlPS3 = new StringBuilder();
                makehtmlPS3.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[7], "3.1 Teaching for Effective Learning", "Teaching_Eff_Learning_grade1"));
                makehtmlPS3.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[7], "3.2 Assessment", "Assessment_overall_grade"));

                HtmlPS3History.Text = makehtmlPS3.ToString();

                StringBuilder makehtmlPS4 = new StringBuilder();
                makehtmlPS4.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[8], "4.1 Curriculum Implementation", "Curriculum_Imp_Cross_Curricular_grade_E123"));
                makehtmlPS4.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[8], "4.2 Curriculum Adaptation", "Curriculum_Adaptation_Overall_grade"));

                HtmlPS4History.Text = makehtmlPS4.ToString();

                StringBuilder makehtmlPS5 = new StringBuilder();
                makehtmlPS5.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[9], "5.1 Health, Safety and Safeguarding", "Health_And_Safety_overall_grade"));
                makehtmlPS5.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[9], "5.2 Care & Support", "Care_And_Support_overall_grade"));

                HtmlPS5History.Text = makehtmlPS5.ToString();

                StringBuilder makehtmlPS6 = new StringBuilder();
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.1 Effectiveness of Leadership", "Eff_of_Leadership_overall_grade"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.2 Self-evaluation and Improvement Planning", "Sef_Imp_Planning_overall_grade1"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.3 Partnership with Parents and Community", "Partnership_With_Parents_Comm_overall_grade"));
                makehtmlPS6.Append(GenerateHtmlSection(dt.Tables[2], dt.Tables[10], "6.4 Management, Staffing, Facilities & Resources", "Mgmt_Staff_Facilities_overall_grade"));

                HtmlPS6History.Text = makehtmlPS6.ToString();

            }
            else
            {
                ImpromptuHelper.ShowPrompt("No Data Found");
            }
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void Load_Consolodation_Data(string Region_Id, string Center_Id, string SessionID)
    {
        DataSet dt = ExecuteProcedureGradeConsolidation_GetData(Region_Id, Center_Id, SessionID);
        if (dt != null)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {



                ddl_KS_wise_EYFS.SelectedValue = dt.Tables[0].Rows[0]["EYFS"].ToString() != "" ? dt.Tables[0].Rows[0]["EYFS"].ToString() : "";
                ddl_KS_wise_KS1.SelectedValue = dt.Tables[0].Rows[0]["KS1"].ToString() != "" ? dt.Tables[0].Rows[0]["KS1"].ToString() : "";
                ddl_KS_wise_KS2.SelectedValue = dt.Tables[0].Rows[0]["KS2"].ToString() != "" ? dt.Tables[0].Rows[0]["KS2"].ToString() : "";
                ddl_KS_wise_KS3.SelectedValue = dt.Tables[0].Rows[0]["KS3"].ToString() != "" ? dt.Tables[0].Rows[0]["KS3"].ToString() : "";
                ddl_KS_wise_KS4.SelectedValue = dt.Tables[0].Rows[0]["KS4"].ToString() != "" ? dt.Tables[0].Rows[0]["KS4"].ToString() : "";
                ddl_KS_wise_KS5.SelectedValue = dt.Tables[0].Rows[0]["KS5"].ToString() != "" ? dt.Tables[0].Rows[0]["KS5"].ToString() : "";
                ddl_KS_wise_Matric.SelectedValue = dt.Tables[0].Rows[0]["Matric"].ToString() != "" ? dt.Tables[0].Rows[0]["Matric"].ToString() : "";
                ddl_Overall_Perf_All.SelectedValue = dt.Tables[0].Rows[0]["OverallPerformance_Grade"].ToString() != "" ? dt.Tables[0].Rows[0]["OverallPerformance_Grade"].ToString() : "";


                // For History
                if (dt.Tables[1].Rows.Count > 0)
                {
                    ddl_KS_wise_EYFSHistory.SelectedValue = dt.Tables[1].Rows[0]["EYFS"].ToString() != "" ? dt.Tables[0].Rows[0]["EYFS"].ToString() : "";
                    ddl_KS_wise_KS1History.SelectedValue = dt.Tables[1].Rows[0]["KS1"].ToString() != "" ? dt.Tables[0].Rows[0]["KS1"].ToString() : "";
                    ddl_KS_wise_KS2History.SelectedValue = dt.Tables[1].Rows[0]["KS2"].ToString() != "" ? dt.Tables[0].Rows[0]["KS2"].ToString() : "";
                    ddl_KS_wise_KS3History.SelectedValue = dt.Tables[1].Rows[0]["KS3"].ToString() != "" ? dt.Tables[0].Rows[0]["KS3"].ToString() : "";
                    ddl_KS_wise_KS4History.SelectedValue = dt.Tables[1].Rows[0]["KS4"].ToString() != "" ? dt.Tables[0].Rows[0]["KS4"].ToString() : "";
                    ddl_KS_wise_KS5History.SelectedValue = dt.Tables[1].Rows[0]["KS5"].ToString() != "" ? dt.Tables[0].Rows[0]["KS5"].ToString() : "";
                    ddl_KS_wise_MatricHistory.SelectedValue = dt.Tables[1].Rows[0]["Matric"].ToString() != "" ? dt.Tables[0].Rows[0]["Matric"].ToString() : "";
                    ddl_Overall_Perf_AllHistory.SelectedValue = dt.Tables[1].Rows[0]["OverallPerformance_Grade"].ToString() != "" ? dt.Tables[0].Rows[0]["OverallPerformance_Grade"].ToString() : "";
                }
                DataRow row = (DataRow)Session["rightsRow"];
                int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
                if (UserLevel_ID == 1 || UserLevel_ID == 2) //Head Office
                {

                    btn_ConSiqaEndrosed.Visible = true;

                    btn_ConSave.Enabled = false;
                    btn_ConSave.Visible = false;
                }


            }
            else
            {
                ddl_KS_wise_EYFS.Enabled = true;
                ddl_KS_wise_KS1.Enabled = true;
                ddl_KS_wise_KS2.Enabled = true;
                ddl_KS_wise_KS3.Enabled = true;
                ddl_KS_wise_KS4.Enabled = true;
                ddl_KS_wise_KS5.Enabled = true;
                ddl_KS_wise_Matric.Enabled = true;
                ddl_Overall_Perf_All.Enabled = true;
                btn_ConSave.Enabled = true;

                ddl_KS_wise_EYFS.SelectedValue = "";
                ddl_KS_wise_KS1.SelectedValue = "";
                ddl_KS_wise_KS2.SelectedValue = "";
                ddl_KS_wise_KS3.SelectedValue = "";
                ddl_KS_wise_KS4.SelectedValue = "";
                ddl_KS_wise_KS5.SelectedValue = "";
                ddl_KS_wise_Matric.SelectedValue = "";
                ddl_Overall_Perf_All.SelectedValue = "";


                // for History

                ddl_KS_wise_EYFSHistory.Enabled = false;
                ddl_KS_wise_KS1History.Enabled = false;
                ddl_KS_wise_KS2History.Enabled = false;
                ddl_KS_wise_KS3History.Enabled = false;
                ddl_KS_wise_KS4History.Enabled = false;
                ddl_KS_wise_KS5History.Enabled = false;
                ddl_KS_wise_MatricHistory.Enabled = false;
                ddl_Overall_Perf_AllHistory.Enabled = false;

                ddl_KS_wise_EYFSHistory.SelectedValue = "";
                ddl_KS_wise_KS1History.SelectedValue = "";
                ddl_KS_wise_KS2History.SelectedValue = "";
                ddl_KS_wise_KS3History.SelectedValue = "";
                ddl_KS_wise_KS4History.SelectedValue = "";
                ddl_KS_wise_KS5History.SelectedValue = "";
                ddl_KS_wise_MatricHistory.SelectedValue = "";
                ddl_Overall_Perf_AllHistory.SelectedValue = "";

            }

        }
    }

    protected void calculate_PS5_Data(string Center_Id, string Group_ID, string session_ID)
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        dt = obj.SIQA_Grade_SEF_PS5_GET_DATA(Center_Id, Group_ID, session_ID);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Total"].ToString() != "0")
            {
                float below_Exp = float.Parse(dt.Rows[0]["Below_Expected"].ToString());
                float Above_Exp = float.Parse(dt.Rows[0]["Above_Expected"].ToString());
                float Expected = float.Parse(dt.Rows[0]["Expected"].ToString());

                if (below_Exp > 39)
                {
                    ddl_5_2_3_grade.SelectedValue = "UA";
                }
                if (Expected + Above_Exp >= 61)
                {
                    ddl_5_2_3_grade.SelectedValue = "Acc";
                }
                if (Above_Exp >= 75)
                {
                    ddl_5_2_3_grade.SelectedValue = "Good";
                }
                if (Above_Exp >= 90)
                {
                    ddl_5_2_3_grade.SelectedValue = "OS";
                }
                ddl_5_2_3_grade.Enabled = false;
            }
        }

        dt = null;
    }

    public void Consolidation_KeystageWise_Fields_Insert()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.EYFS = ddl_KS_wise_EYFS.SelectedValue.ToString();
        obj.KS1 = ddl_KS_wise_KS1.SelectedValue.ToString();
        obj.KS2 = ddl_KS_wise_KS2.SelectedValue.ToString();
        obj.KS3 = ddl_KS_wise_KS3.SelectedValue.ToString();
        obj.KS4 = ddl_KS_wise_KS4.SelectedValue.ToString();
        obj.KS5 = ddl_KS_wise_KS5.SelectedValue.ToString();
        obj.Matric = ddl_KS_wise_Matric.SelectedValue.ToString();
        obj.OverallPerformance_Grade = ddl_Overall_Perf_All.SelectedValue.ToString();
        obj.IsSIQAEndrosed = false;
        obj.CreateBy = Session["ContactID"].ToString();

        dt = obj.SEF_Consolidation_KeyStageWise_Insert(obj);
        if (dt.Rows.Count >= 1)
        {

            // Load_PS6_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString());

            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }

    public void Consolidation_KeystageWise_Fields_SIqaEnd_Updated()
    {
        DataTable dt = new DataTable();
        BLLSiqa obj = new BLLSiqa();
        obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        obj.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        obj.EYFS = ddl_KS_wise_EYFS.SelectedValue.ToString();
        obj.KS1 = ddl_KS_wise_KS1.SelectedValue.ToString();
        obj.KS2 = ddl_KS_wise_KS2.SelectedValue.ToString();
        obj.KS3 = ddl_KS_wise_KS3.SelectedValue.ToString();
        obj.KS4 = ddl_KS_wise_KS4.SelectedValue.ToString();
        obj.KS5 = ddl_KS_wise_KS5.SelectedValue.ToString();
        obj.Matric = ddl_KS_wise_Matric.SelectedValue.ToString();
        obj.OverallPerformance_Grade = ddl_Overall_Perf_All.SelectedValue.ToString();
        obj.IsSIQAEndrosed = true;

        obj.CreateBy = Session["ContactID"].ToString();

        dt = obj.SEF_Consolidation_KeyStageWise_SiqaEndrosed(obj);
        if (dt.Rows.Count >= 1)
        {

            // Load_PS6_Data(obj.Region_Id.ToString(), obj.Center_Id.ToString());

            ImpromptuHelper.ShowPrompt("Record Inserted Successfuly");
        }
        obj = null;
        dt = null;
    }

    string GenerateHtmlSection(DataTable dtSessions, DataTable dtGrades, string sectionTitle, string gradeColumn)
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("  <tr>");
        html.AppendLine("<td rowspan='1' colspan='2' >" + sectionTitle + "</td>");

        for (int k = 0; k < dtSessions.Rows.Count; k++)
        {
            string description = dtSessions.Rows[k]["Description"].ToString();
            int sessionId = (int)dtSessions.Rows[k]["Session_Id"];

            // Fetch grades for each group
            string[] groupNames = { "EYFS", "KS1", "KS2", "KS3", "KS4", "KS5", "Matric" };
            string[] grades = new string[groupNames.Length];

            for (int i = 0; i < groupNames.Length; i++)
            {
                DataRow[] rows = dtGrades.Select("Group_Name = '" + groupNames[i] + "' and Session_Id = " + sessionId + "");
                grades[i] = rows.Length > 0 ? rows[0][gradeColumn].ToString() : "";
            }

            // Add a new row for each session
            //if (k > 0)
            //{
            //    html.AppendLine("<tr class=\"SecondRow\">");
            //}
            //  html.AppendLine("<td>" + description + "</td>");
            foreach (string grade in grades)
            {
                if (grade == "G" || grade == "Good")
                {
                    html.AppendLine("<td>Good</td>");
                }
                else if (grade == "A" || grade == "Acc")
                {
                    html.AppendLine("<td>Acc</td>");
                }
                else
                {
                    html.AppendLine("<td>" + grade + "</td>");
                }
            }
            html.AppendLine(" </tr>");
        }

        return html.ToString();
    }
    //-----SR Work END

    protected void BindSLTAssignmentGrid()
    {
        try
        {
            string category = "SLT";
            int region = Convert.ToInt32(ddl_region.SelectedValue);
            int center = Convert.ToInt32(ddl_center.SelectedValue);
            int session = Convert.ToInt32(ddl_Session.SelectedValue);

            DataTable dtemp = _kpiBll.GetEmployees(category, region, center);
            //DataTable dtStages = _kpiBll.GetKeyStagesForCenter(region, center, session);
            DataTable dtExistingAssignments = _kpiBll.GetSLTAssignments(session, region, center);

            if (dtemp != null && dtemp.Rows.Count > 0)
            {
                //if (!dtemp.Columns.Contains("KeyStages")) dtemp.Columns.Add("KeyStages", typeof(string));
                if (!dtemp.Columns.Contains("SIQA_Grade")) dtemp.Columns.Add("SIQA_Grade", typeof(string));
                if (!dtemp.Columns.Contains("KPI_Grade_Points")) dtemp.Columns.Add("KPI_Grade_Points", typeof(string));
                if (!dtemp.Columns.Contains("KPI_Points")) dtemp.Columns.Add("KPI_Points", typeof(string));
                if (!dtemp.Columns.Contains("KPI_Grade")) dtemp.Columns.Add("KPI_Grade", typeof(string));
                if (!dtemp.Columns.Contains("KPI_Year")) dtemp.Columns.Add("KPI_Year", typeof(int));
                if (!dtemp.Columns.Contains("HasExistingAssignment")) dtemp.Columns.Add("HasExistingAssignment", typeof(bool));

                foreach (DataRow row in dtemp.Rows)
                {
                    string employeeCode = row["EmployeeCode"].ToString();
                    DataRow[] existingAssignments = dtExistingAssignments != null
                        ? dtExistingAssignments.Select("Employee_Id = '" + employeeCode + "'")
                        : new DataRow[0];

                    if (existingAssignments.Length > 0)
                    {
                        DataRow assignment = existingAssignments[0];
                        //row["KeyStages"] = assignment["Assigned_Key_Stage"];
                        row["SIQA_Grade"] = assignment["SIQA_Grade"];
                        row["KPI_Grade_Points"] = assignment["KPI_Grade_Points"];
                        row["KPI_Points"] = assignment["KPI_Points"];
                        row["KPI_Grade"] = assignment["KPI_Grade"];
                        row["KPI_Year"] = assignment["KPI_Year"];
                        row["HasExistingAssignment"] = true;
                    }
                    else
                    {
                        //row["KeyStages"] = "";
                        row["SIQA_Grade"] = "";
                        row["KPI_Grade_Points"] = "";
                        row["KPI_Points"] = "";
                        row["KPI_Grade"] = "";
                        row["KPI_Year"] = DBNull.Value;
                        row["HasExistingAssignment"] = false;
                    }
                }

                gvSLTAssignment.DataSource = dtemp;
                gvSLTAssignment.DataBind();

                //ViewState["KeyStagesData"] = dtStages;
                ViewState["RegionId"] = region;
                ViewState["CenterId"] = center;
                ViewState["SessionId"] = session;
            }
            else
            {
                DataTable emptyTable = new DataTable();
                emptyTable.Columns.Add("EmployeeCode");
                emptyTable.Columns.Add("FullName");
                //emptyTable.Columns.Add("KeyStages");
                emptyTable.Columns.Add("SIQA_Grade");
                emptyTable.Columns.Add("KPI_Grade_Points");
                emptyTable.Columns.Add("KPI_Points");
                emptyTable.Columns.Add("KPI_Grade");
                emptyTable.Columns.Add("KPI_Year", typeof(int));
                emptyTable.Columns.Add("HasExistingAssignment", typeof(bool));
                DataRow newRow = emptyTable.NewRow();
                newRow["EmployeeCode"] = string.Empty;
                newRow["FullName"] = string.Empty;
                //newRow["KeyStages"] = string.Empty;
                newRow["SIQA_Grade"] = string.Empty;
                newRow["KPI_Grade_Points"] = string.Empty; 
                newRow["KPI_Grade"] = string.Empty;
                newRow["KPI_Points"] = string.Empty; 
                newRow["KPI_Year"] = DBNull.Value;
                newRow["HasExistingAssignment"] = false;
                emptyTable.Rows.Add(newRow);
                gvSLTAssignment.DataSource = emptyTable;
                gvSLTAssignment.DataBind();
            }
        }
        catch
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("EmployeeCode");
            emptyTable.Columns.Add("FullName");
            //emptyTable.Columns.Add("KeyStages");
            emptyTable.Columns.Add("SIQA_Grade");
            emptyTable.Columns.Add("KPI_Grade_Points");
            emptyTable.Columns.Add("KPI_Points");
            emptyTable.Columns.Add("KPI_Grade");
            emptyTable.Columns.Add("KPI_Year", typeof(int));
            emptyTable.Columns.Add("HasExistingAssignment", typeof(bool));
            DataRow newRow = emptyTable.NewRow();
            newRow["EmployeeCode"] = string.Empty;
            newRow["FullName"] = string.Empty;
            //newRow["KeyStages"] = string.Empty;
            newRow["SIQA_Grade"] = string.Empty;
            newRow["KPI_Grade_Points"] = string.Empty;
            newRow["KPI_Grade"] = string.Empty;
            newRow["KPI_Points"] = string.Empty;
            newRow["KPI_Year"] = DBNull.Value;
            newRow["HasExistingAssignment"] = false;
            emptyTable.Rows.Add(newRow);
            gvSLTAssignment.DataSource = emptyTable;
            gvSLTAssignment.DataBind();
        }
    }
     
    protected void gvSLTAssignment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            TextBox txtSIQAGrades = (TextBox)e.Row.FindControl("txtSIQAGrades");
            TextBox txtKPIGradePoints = (TextBox)e.Row.FindControl("txtKPIGradePoints");
            TextBox txtKPIGrades = (TextBox)e.Row.FindControl("txtKPIGrades");
            TextBox txtKPIGrade = (TextBox)e.Row.FindControl("txtKPIGrade");

            if (txtSIQAGrades != null && drv.Row.Table.Columns.Contains("SIQA_Grade"))
            {
                if (drv["SIQA_Grade"] != DBNull.Value)
                    txtSIQAGrades.Text = drv["SIQA_Grade"].ToString();
                else
                    txtSIQAGrades.Text = string.Empty;
            }

            if (txtKPIGradePoints != null && drv.Row.Table.Columns.Contains("KPI_Grade_Points"))
            {
                if (drv["KPI_Grade_Points"] != DBNull.Value)
                    txtKPIGradePoints.Text = drv["KPI_Grade_Points"].ToString();
                else
                    txtKPIGradePoints.Text = string.Empty;
            }

            // Correct column for KPI Grades
            if (txtKPIGrades != null && drv.Row.Table.Columns.Contains("KPI_Grade"))
            {
                if (drv["KPI_Grade"] != DBNull.Value)
                    txtKPIGrades.Text = drv["KPI_Grade"].ToString();
                else
                    txtKPIGrades.Text = string.Empty;
                
            }

            // Correct column for Average
            if (txtKPIGrade != null && drv.Row.Table.Columns.Contains("KPI_Points"))
            {
                if (drv["KPI_Points"] != DBNull.Value)
                    txtKPIGrade.Text = drv["KPI_Points"].ToString();
                else
                    txtKPIGrade.Text = string.Empty;
            }
        }
    }
      
    protected void gvSLTAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument == null) return;
        int rowIndex;
        if (!int.TryParse(e.CommandArgument.ToString(), out rowIndex)) return;
        if (rowIndex < 0 || rowIndex >= gvSLTAssignment.Rows.Count) return;
        GridViewRow row = gvSLTAssignment.Rows[rowIndex];
        if (row == null) return;

        int regionId = SafeToInt(ddl_region.SelectedValue);
        int centerId = SafeToInt(ddl_center.SelectedValue);
        int sessionId = SafeToInt(ddl_Session.SelectedValue);

        Dictionary<string, object> model = BuildSltModelFromRow(row, sessionId, regionId, centerId);
        if (model == null) return;

        if (string.Equals(e.CommandName, "SaveRow", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(e.CommandName, "EditRow", StringComparison.OrdinalIgnoreCase))
        {
            _kpiBll.UpsertSLTAssignment(model);
            ShowAlert("Saved successfully.", "success");
        }
        else if (string.Equals(e.CommandName, "DeleteRow", StringComparison.OrdinalIgnoreCase))
        {
            Dictionary<string, object> key = new Dictionary<string, object>();
            key["Session_Id"] = model["Session_Id"];
            key["Region_Id"] = model["Region_Id"];
            key["Center_Id"] = model["Center_Id"];
            key["Employee_Id"] = model["Employee_Id"];
            _kpiBll.DeleteSLTAssignment(key);
            ShowAlert("Deleted successfully.", "success");
        }

        BindSLTAssignmentGrid();
    }

    //protected void gvSLTAssignment_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        try
    //        {
    //            var checkboxOptions = e.Row.FindControl("checkboxOptions") as HtmlGenericControl;
    //            var hdnSelectedKeyStages = e.Row.FindControl("hdnSelectedKeyStages") as HiddenField;
    //            var txtSIQAGrades = e.Row.FindControl("txtSIQAGrades") as TextBox;
    //            var txtKPIGradePoints = e.Row.FindControl("txtKPIGradePoints") as TextBox;
    //            var txtKPIGrades = e.Row.FindControl("txtKPIGrades") as TextBox;
    //            var txtKPIGrade = e.Row.FindControl("txtKPIGrade") as TextBox;
    //            var hdnKPIGrade = e.Row.FindControl("hdnKPIGrade") as HiddenField;
    //            var hdnKPIAvg = e.Row.FindControl("hdnKPIAvg") as HiddenField;
    //            var ddlKPIYear = e.Row.FindControl("ddlKPIYear") as DropDownList;

    //            if (checkboxOptions == null || hdnSelectedKeyStages == null) return;

    //            int regionId = Convert.ToInt32(ddl_region.SelectedValue);
    //            int centerId = Convert.ToInt32(ddl_center.SelectedValue);
    //            int sessionId = Convert.ToInt32(ddl_Session.SelectedValue);

    //            DataTable keyStagesData = _kpiBll.GetKeyStagesForCenter(regionId, centerId, sessionId);
    //            if (keyStagesData == null || keyStagesData.Rows.Count == 0)
    //            {
    //                checkboxOptions.InnerHtml = "<div>No key stages available</div>";
    //                return;
    //            }

    //            string selectedKeyStages = hdnSelectedKeyStages.Value ?? "";
    //            var selectedList = !string.IsNullOrEmpty(selectedKeyStages) ? selectedKeyStages.Split(',').ToList() : new System.Collections.Generic.List<string>();

    //            var keyStageGrades = new System.Collections.Generic.Dictionary<string, string>();
    //            var keyStageGradePoints = new System.Collections.Generic.Dictionary<string, string>();
    //            var keyStageKPIGrades = new System.Collections.Generic.Dictionary<string, string>();
    //            var sb = new System.Text.StringBuilder();

    //            foreach (DataRow r in keyStagesData.Rows)
    //            {
    //                string ks = r["KeyStage"] != null ? r["KeyStage"].ToString() : "";
    //                if (string.IsNullOrEmpty(ks)) continue;
    //                string siqa = r["Grade"] != null ? r["Grade"].ToString() : "";
    //                string pts = (r["GradePoints"] != DBNull.Value && r["GradePoints"] != null) ? r["GradePoints"].ToString() : "0";
    //                string kpi = r.Table.Columns.Contains("KPIGrade_string") && r["KPIGrade_string"] != null ? r["KPIGrade_string"].ToString() : "";

    //                keyStageGrades[ks] = siqa;
    //                keyStageGradePoints[ks] = pts;
    //                keyStageKPIGrades[ks] = kpi;

    //                bool isSel = selectedList.Contains(ks);
    //                sb.AppendFormat("<div class='checkbox-item'><input type='checkbox' value='{0}' {1} onchange='updateSelectedKeyStages(this)' /><label>{0}</label></div>", ks, isSel ? "checked='checked'" : "");
    //            }
    //            checkboxOptions.InnerHtml = sb.ToString();

    //            var hdnKeyStageGrades = e.Row.FindControl("hdnKeyStageGrades") as HiddenField;
    //            var hdnKeyStageGradePoints = e.Row.FindControl("hdnKeyStageGradePoints") as HiddenField;
    //            var hdnKeyStageKPIGrades = e.Row.FindControl("hdnKeyStageKPIGrades") as HiddenField;

    //            if (hdnKeyStageGrades != null) hdnKeyStageGrades.Value = Newtonsoft.Json.JsonConvert.SerializeObject(keyStageGrades);
    //            if (hdnKeyStageGradePoints != null) hdnKeyStageGradePoints.Value = Newtonsoft.Json.JsonConvert.SerializeObject(keyStageGradePoints);
    //            if (hdnKeyStageKPIGrades != null) hdnKeyStageKPIGrades.Value = Newtonsoft.Json.JsonConvert.SerializeObject(keyStageKPIGrades);

    //            if (!string.IsNullOrEmpty(selectedKeyStages))
    //            {
    //                var sel = selectedKeyStages.Split(',');
    //                var siqaList = new System.Collections.Generic.List<string>();
    //                var ptsList = new System.Collections.Generic.List<string>();
    //                var kpiNames = new System.Collections.Generic.List<string>();
    //                double total = 0; int cnt = 0;

    //                foreach (var ks in sel)
    //                {
    //                    if (keyStageGrades.ContainsKey(ks)) siqaList.Add(keyStageGrades[ks]);
    //                    if (keyStageGradePoints.ContainsKey(ks))
    //                    {
    //                        ptsList.Add(keyStageGradePoints[ks]);
    //                        double p; if (double.TryParse(keyStageGradePoints[ks], out p)) { total += p; cnt++; }
    //                    }
    //                    if (keyStageKPIGrades.ContainsKey(ks)) kpiNames.Add(keyStageKPIGrades[ks]);
    //                }

    //                if (txtSIQAGrades != null) txtSIQAGrades.Text = string.Join(", ", siqaList);
    //                if (txtKPIGradePoints != null) txtKPIGradePoints.Text = string.Join(", ", ptsList);
    //                if (txtKPIGrades != null) txtKPIGrades.Text = string.Join(", ", kpiNames);

    //                string avg = (cnt > 0 ? (total / cnt).ToString("F2") : "0");
    //                if (txtKPIGrade != null) txtKPIGrade.Text = avg;
    //                if (hdnKPIGrade != null) hdnKPIGrade.Value = avg;
    //                if (hdnKPIAvg != null) hdnKPIAvg.Value = avg;
    //            }
    //            else
    //            {
    //                if (txtSIQAGrades != null) txtSIQAGrades.Text = string.Empty;
    //                if (txtKPIGradePoints != null) txtKPIGradePoints.Text = "0";
    //                if (txtKPIGrades != null) txtKPIGrades.Text = string.Empty;
    //                if (txtKPIGrade != null) txtKPIGrade.Text = "0";
    //                if (hdnKPIGrade != null) hdnKPIGrade.Value = "0";
    //                if (hdnKPIAvg != null) hdnKPIAvg.Value = "0";
    //            }

    //            var data = (DataRowView)e.Row.DataItem;
    //            if (ddlKPIYear != null && data != null && data.Row.Table.Columns.Contains("KPI_Year"))
    //            {
    //                var yrObj = data["KPI_Year"];
    //                if (yrObj != DBNull.Value && yrObj != null)
    //                {
    //                    string yr = Convert.ToString(yrObj);
    //                    if (ddlKPIYear.Items.FindByValue(yr) != null) ddlKPIYear.SelectedValue = yr;
    //                }
    //            }

    //            bool hasExistingAssignment = false;
    //            if (data != null && data.Row.Table.Columns.Contains("HasExistingAssignment"))
    //            {
    //                var v = data["HasExistingAssignment"];
    //                if (v != DBNull.Value && v != null) hasExistingAssignment = Convert.ToBoolean(v);
    //            }
    //            foreach (Control cell in e.Row.Controls)
    //            {
    //                var dc = cell as DataControlFieldCell;
    //                if (dc == null) continue;
    //                foreach (Control c in dc.Controls)
    //                {
    //                    var lb = c as LinkButton;
    //                    if (lb == null) continue;
    //                    if (lb.CommandName == "SaveRow") lb.Visible = !hasExistingAssignment;
    //                    else if (lb.CommandName == "EditRow" || lb.CommandName == "DeleteRow") lb.Visible = hasExistingAssignment;
    //                }
    //            }
    //        }
    //        catch { }
    //    }
    //}

    private Dictionary<string, object> BuildSltModelFromRow(GridViewRow row, int sessionId, int regionId, int centerId)
    {
        if (row == null) return null;

        Label lblEmployeeID = row.FindControl("lblEmployeeID") as Label;
        Label lblSchoolLeader = row.FindControl("lblSchoolLeader") as Label;
        HiddenField hdnSelectedKeyStages = row.FindControl("hdnSelectedKeyStages") as HiddenField;
        DropDownList ddlKPIYear = row.FindControl("ddlKPIYear") as DropDownList;
        TextBox txtSIQAGrades = row.FindControl("txtSIQAGrades") as TextBox;
        TextBox txtKPIGradePoints = row.FindControl("txtKPIGradePoints") as TextBox;
        TextBox txtKPIGrades = row.FindControl("txtKPIGrades") as TextBox;
        TextBox txtKPIGrade = row.FindControl("txtKPIGrade") as TextBox;
        HiddenField hdnKPIGrade = row.FindControl("hdnKPIGrade") as HiddenField;
        HiddenField hdnKPIAvg = row.FindControl("hdnKPIAvg") as HiddenField;

        string employeeCode = (lblEmployeeID != null && lblEmployeeID.Text != null) ? lblEmployeeID.Text.Trim() : "";
        string schoolLeader = (lblSchoolLeader != null && lblSchoolLeader.Text != null) ? lblSchoolLeader.Text.Trim() : "";

        string ksCsv = (hdnSelectedKeyStages != null && hdnSelectedKeyStages.Value != null) ? hdnSelectedKeyStages.Value.Trim() : "";
        string gradesCsv = (txtSIQAGrades != null && txtSIQAGrades.Text != null) ? txtSIQAGrades.Text.Trim() : "";
        string pointsCsv = (txtKPIGradePoints != null && txtKPIGradePoints.Text != null) ? txtKPIGradePoints.Text.Trim() : "";
        string avgStrForGrade = (txtKPIGrades != null && txtKPIGrades.Text != null) ? txtKPIGrades.Text.Trim() : "";
        string avgStrForPoints = (txtKPIGrade != null && txtKPIGrade.Text != null) ? txtKPIGrade.Text.Trim() : "0";

        if (string.IsNullOrWhiteSpace(employeeCode)) { ShowAlert("Employee code is required.", "error"); return null; }

        int kpiYear = 0;
        if (ddlKPIYear != null && ddlKPIYear.SelectedValue != null) int.TryParse(ddlKPIYear.SelectedValue, out kpiYear);
        if (kpiYear == 0) { ShowAlert("KPI Year is required.", "error"); return null; }

        //if (string.IsNullOrWhiteSpace(ksCsv)) { ShowAlert("Please select at least one Key Stage.", "error"); return null; }

        decimal avgVal;
        if (!decimal.TryParse(avgStrForPoints, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out avgVal))
            avgVal = 0m;
        int User_ID = Convert.ToInt32(Session["ContactID"].ToString());
        Dictionary<string, object> model = new Dictionary<string, object>();
        model["Session_Id"] = sessionId;
        model["Region_Id"] = regionId;
        model["Center_Id"] = centerId;
        model["Employee_Id"] = employeeCode;
        model["EmployeeCode"] = employeeCode;
        model["School_Leader"] = schoolLeader;
        model["Assigned_Key_Stage"] = ksCsv;
        model["KPI_Year"] = kpiYear;
        model["SIQA_Grade"] = gradesCsv;
        model["KPI_Grade_Points"] = pointsCsv;
        model["KPI_Points"] = avgStrForPoints;        // numeric average
        model["KPI_Grade"] = avgStrForGrade; // same average as string
        model["UserName"] = User_ID;
       
        return model;
    }

    private int SafeToInt(string s)
    {
        int v; return int.TryParse(s, out v) ? v : 0;
    }

    private void ShowAlert(string message, string type = "info")
    {
        var safe = (message ?? string.Empty)
            .Replace("\\", "\\\\")
            .Replace("'", "\\'")
            .Replace("\r", string.Empty)
            .Replace("\n", "<br/>");

        var js = "window.showToast && window.showToast('" + safe + "', '" + type + "');";
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "toast_" + Guid.NewGuid().ToString("N"),
            js,
            true
        );
    } 
}
