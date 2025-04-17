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
public partial class PresentationLayer_TCS_Archieve : System.Web.UI.Page
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
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


        DALBase objBase = new DALBase();
        DataRow row = (DataRow)Session["rightsRow"];

        if (!IsPostBack)
        {
            try
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


            loadOrg(sender, e);
            LoadActiveSessions();
            LoadTerm();
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


            }

            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
            {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;


            }

            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
            {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;


            }
            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
            {
                ddl_country.SelectedIndex = 1;
                ddl_country_SelectedIndexChanged(sender, e);

                ddl_country.Enabled = false;
                ddl_region.Enabled = false;

              }
            // PageInformation();

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }

    }
    protected void LoadTerm()
    {
        try
        {
        DataTable dt = null;
        BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
        dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
        objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LoadActiveSessions()
    {
        try
        {
        BLLSession objBll = new BLLSession();
        DataTable dt = new DataTable();
        dt = objBll.SessionSelectAllActive();
        objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
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

    protected void but_archive_Click(object sender, EventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"]; 
        
        try
        {
            BLLArchieve ObjArch = new BLLArchieve();
            int ind;


            GridViewRowCollection gvrc = gvCenter.Rows;
            foreach (GridViewRow gvr in gvrc)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");
                    ind = gvr.RowIndex;
                    if (cb.Checked)
                    {
                        ObjArch.Center_Id = Int32.Parse(gvCenter.DataKeys[ind].Value.ToString());
                        ObjArch.Session_Id=Int32.Parse(ddlSession.SelectedValue);
                        ObjArch.Term_Id=Convert.ToInt32(ddlTerm.SelectedValue);
                        ObjArch.Mo_Id=Convert.ToInt32(row["Main_Organisation_Id"].ToString());

                        ObjArch.Call_ArchiveProcedureNew(ObjArch);
                    }

                }
            }
            
            ImpromptuHelper.ShowPrompt("Campus Successfully Archived.");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //DALArchive oDALArchive = new DALArchive();
        //DataTable dt = oDALArchive.Get_Center_Based_On_Archive(Int32.Parse(ddlSession.SelectedValue));


        //GridViewRow gvr = e.Row;
        //CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        if (dt.Rows[i][0].ToString() == gvr.Cells[3].Text)
        //        {
        //            cb.Enabled = false;
        //        }
        //        else
        //        {
        //            cb.Enabled = true;
        //        }
        //    }
        //}
    }
    protected void btn_sendEmail_Click(object sender, EventArgs e)
    {

        //BLLSendEmail bllemail = new BLLSendEmail();
        //BLLStudent objStd = new BLLStudent();

        //isl_amso.dt_AuthenticateUserRow userrow = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];
        //try
        //{
        //    DALArchive oDALArchive = new DALArchive();
        //    int ind;
        //    DataTable _dtemp = new DataTable();

        //    string maildts = "";
        //    string _last = "";
        //    string _ToStart = "";
        //    GridViewRowCollection gvrc = gvCenter.Rows;
        //    foreach (GridViewRow gvr in gvrc)
        //    {
        //        if (gvr.RowType == DataControlRowType.DataRow)
        //        {
        //            //CheckBox cb = (CheckBox)gvr.Cells[4].Controls[1];
        //            CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");
        //            ind = gvr.RowIndex;
        //            if (cb.Checked)
        //            {
        //                int center_id = Int32.Parse(gvCenter.DataKeys[ind].Value.ToString());
        //                objStd.Center_id = center_id;
        //                objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        //                objStd.Term_Id = Convert.ToInt32(ddlTerm.SelectedValue);

        //                _dtemp = objStd.SelectStudentsByPerformanceDeclineEmail(objStd);

        //                /*if students arcieved are >0 then Select all Students first from Auto Alert email table and then Send Email once*/


        //                if (_dtemp.Rows.Count > 0)
        //                {
        //                    foreach (DataRow var in _dtemp.Rows)
        //                    {
        //                        maildts = maildts + "" + var["ClassSub"].ToString() + "    -    " + var["StudentName"].ToString() + "                                       -                                     " + var["Detail"].ToString() + "<br>";
        //                        _ToStart = var["Session"].ToString();
        //                    }
        //                }

        //                string mailMsg = "To Principal, <br><br> List of sutdents performance declines .<br> " + _ToStart + " <br>      [Class]---[Section]---[Rol#]---[Student Name]---[Previous Term Marks]---[Current Term Marks] <br><br>";

        //                _last = "<br><br> * This is auto alert generted by Academic Management System(aims), The City School";

        //                mailMsg = mailMsg + maildts + _last;

        //                bllemail.SendEmail(gvr.Cells[3].Text.ToString(), "Student Performance Summary", mailMsg);
        //            }

        //        }
        //    }
        //    ImpromptuHelper.ShowPrompt("Email Sent Successfully to Branch.");

        //}

        //catch (Exception ex)
        //{
        //    Session["error"] = ex.InnerException.ToString();
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}


    }
    protected void btn_Parents_Click(object sender, EventArgs e)
    {

        //BLLSendEmail bllemail = new BLLSendEmail();
        //BLLStudent objStd = new BLLStudent();

        //isl_amso.dt_AuthenticateUserRow userrow = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];
        //try
        //{
        //    DALArchive oDALArchive = new DALArchive();
        //    int ind;
        //    DataTable _dtemp = new DataTable();

        //    string maildts = "";
        //    string _last = "";
        //    string _ToStart = "";
        //    GridViewRowCollection gvrc = gvCenter.Rows;
        //    foreach (GridViewRow gvr in gvrc)
        //    {
        //        if (gvr.RowType == DataControlRowType.DataRow)
        //        {
        //            //CheckBox cb = (CheckBox)gvr.Cells[4].Controls[1];
        //            CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");
        //            ind = gvr.RowIndex;
        //            if (cb.Checked)
        //            {
        //                int center_id = Int32.Parse(gvCenter.DataKeys[ind].Value.ToString());
        //                objStd.Center_id = center_id;
        //                objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        //                objStd.Term_Id = Convert.ToInt32(ddlTerm.SelectedValue);

        //                _dtemp = objStd.SelectStudentsByParentsEmail(objStd);

        //                /*if students arcieved are >0 then Select all Students first from Auto Alert email table and then Send Email once*/


        //                if (_dtemp.Rows.Count > 0)
        //                {
        //                    foreach (DataRow var in _dtemp.Rows)
        //                    {
        //                        maildts = "";
        //                        string mailMsg = "To Parent, <br><br> Please find Your Child's result card Progress .<br> RollNumber:" + var["Student_no"].ToString() + "<br> Student Name: " + var["First_Name"].ToString() + "" + var["Last_Name"].ToString() + "<br><br>";

        //                        DataTable _dtRes = GetStudentResultReport(Convert.ToInt32(var["Student_Id"].ToString()), Convert.ToInt32(ddlTerm.SelectedValue));
        //                        if (_dtRes.Rows.Count > 0)
        //                        {
        //                            foreach (DataRow dr in _dtRes.Rows)
        //                            {
        //                                maildts = maildts + dr["Class_Name"].ToString() + " = " + dr["Subject_name"].ToString() + " = " + dr["Course_Work"].ToString() + " = " + dr["Theory_Exam"].ToString() + " = " + dr["Mid_Year"].ToString() + " = " + dr["Marks"].ToString() + " = " + dr["grade"].ToString() + "<br>";
        //                            }
        //                        }
        //                        _last = "<br><br> * This is auto alert generted by Academic Management System(aims), The City School";

        //                        mailMsg = mailMsg + maildts + _last;

        //                        bllemail.SendEmail(var["FatherEmail"].ToString(), "Student Result Card", mailMsg);

        //                    }
        //                }


        //            }

        //        }
        //    }
        //    ImpromptuHelper.ShowPrompt("Email Sent Successfully to Branch.");

        //}

        //catch (Exception ex)
        //{
        //    Session["error"] = ex.InnerException.ToString();
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }

    protected DataTable GetStudentResultReport(int Student_Id, int Term_Id)
    {
        DataTable studentDt=null;

        //DAStudentResultCard oDAStudentResultCard = new DAStudentResultCard();

        //if (Term_Id == 2) //Mid Term
        //{
        //    studentDt = oDAStudentResultCard.GetStudentResultCardMid(Student_Id, Term_Id);
        //}
        //else
        //{
        //    studentDt = oDAStudentResultCard.GetStudentResultCardFinal(Student_Id, Term_Id);
        //}

        return studentDt;

    }
    protected void but_Promote_Click(object sender, EventArgs e)
    {

        //if (ddlTerm.SelectedValue == "1")
        //{
        //    isl_amso.dt_AuthenticateUserRow userrow = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];
        //    try
        //    {
        //        DALArchive oDALArchive = new DALArchive();
        //        int ind;


        //        GridViewRowCollection gvrc = gvCenter.Rows;
        //        foreach (GridViewRow gvr in gvrc)
        //        {
        //            if (gvr.RowType == DataControlRowType.DataRow)
        //            {
        //                CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");
        //                ind = gvr.RowIndex;
        //                if (cb.Checked)
        //                {
        //                    int center_id = Int32.Parse(gvCenter.DataKeys[ind].Value.ToString());
        //                    oDALArchive.Call_PromotionProcedure((Int32.Parse(ddlSession.SelectedValue)), center_id, userrow.Main_Organisation_Id);
        //                }

        //            }
        //        }
        //        ImpromptuHelper.ShowPrompt("Promotion Process Successfully Executed.");

        //    }

        //    catch (Exception ex)
        //    {
        //        Session["error"] = ex.InnerException.ToString();
        //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //    }

        //}
        //else
        //{
        //    ImpromptuHelper.ShowPrompt("Select Final Term.");
        //}

    }

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        //if (ddl_region.SelectedIndex > 0 && ddl_region.SelectedIndex > 0)
        //{
            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            //objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            gvCenter.DataSource = dt;
            gvCenter.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


       //}
    }
}
