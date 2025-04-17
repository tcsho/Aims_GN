using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Web;
using ListItem = System.Web.UI.WebControls.ListItem;


public partial class PresentationLayer_TCS_Result_Term : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            //string hostURL = HttpContext.Current.Request.Url.Host;
            //if (hostURL.ToLower() == "www.tcsaims.com")
            //{
            //    btnSave.Visible = false;

            //}
            //else
            //{
            //    btnSave.Visible = true;
            //}


            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];

            if (!IsPostBack)
            {
                //======== Page Access Settings ========================

                //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                //string sRet = oInfo.Name;
                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();

                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx",false);
                //}
                //Session["AddCriteria"] = null;

                //====== End Page Access settings ======================
                //Session.Remove("LastPage");
                //Session.Remove("AddCriteria");
                //Session.Remove("RptTitle");
                //Session.Remove("reppath");
                //Session.Remove("rep");
                //Session.Remove("CriteriaRpt");
                //Session.Remove("rptCmnt");
                
                loadOrg(sender, e);
                FillActiveSessions();
                trShowAck.Visible = false;
                trShowAckState.Visible = false;
                trShowUnderTakAck.Visible = false;
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }
                 
                if (Convert.ToInt32(row["User_Type_Id"].ToString()) == 5)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
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
                    fillNetworkCenters();
                }
                // PageInformation(); 
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //protected void PageInformation()
    //{
    //    try
    //    {
    //        BLLLmsAppPages objPage = new BLLLmsAppPages();
    //        string queryStr = Request.QueryString["id"];



    //        DataTable dt = new DataTable();
    //        objPage.Page_ID = Convert.ToInt32(queryStr);
    //        dt = objPage.LmsAppPagesFetch(objPage);
    //        if (dt.Rows.Count > 0)
    //        {

    //            Session["LastPage"] = dt.Rows[0]["PagePath"].ToString();

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    } 
    //}

    private void fillNetworkCenters()
    {
        try
        {
            BLLNetworkCenter obj = new BLLNetworkCenter();
            obj.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = new DataTable();
            dt = obj.NetworkCenterSelectByUserID(obj);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            //ActualReportCalling();
            HTMLReportCalling();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void HTMLReportCalling()
    {
        string url = "";
        try
        {
            if (list_section.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            {
                #region NewCode
                string Qs = "";
                bool _isok = false;

                int AlreadyIn;
                int termId = Int32.Parse(ddlTerm.SelectedValue);
                int class_Id = Int32.Parse(ddlClass.SelectedValue);
                int section_id = Int32.Parse(list_section.SelectedValue);

                //if (class_Id < 7 || class_Id > 12)
                // {
                //    ActualReportCalling();
                //    return;
                //    //Session["error"] = "This performance test activity is only available for class-3 to Class-8";
                //    //Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                //}
                //else
                {
                    BLLStudent_Performance_Grading_Mst ObjMst = new BLLStudent_Performance_Grading_Mst();

                    BLLMarks_Entry_Acknowledgement ObjMea = new BLLMarks_Entry_Acknowledgement();
                    BLLEvaluation_Criteria_Type ObjEval = new BLLEvaluation_Criteria_Type();

                    int session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                    int termGroup_Id;

                    ObjMea.Evaluation_Criteria_Type_Id = termId;
                    ObjMea.Session_Id = session_Id;
                    ObjMea.Section_Id = section_id;

                    ObjMst.Evaluation_Criteria_Type_Id = termId;
                    ObjMst.Session_Id = session_Id;
                    ObjMst.Section_Id = section_id;
                    DataTable dtECT = ObjEval.Evaluation_Criteria_TypeFetch(termId); //Term

                    if (dtECT.Rows.Count > 0)
                    {
                        termGroup_Id = Convert.ToInt32(dtECT.Rows[0]["TermGroup_Id"].ToString());
                    }
                    else
                    {
                        termGroup_Id = 1;
                    }

                    ViewReport obj = new ViewReport();
                    obj.Session_Id = session_Id;
                    obj.Section_Id = section_id;
                    obj.TermGroup_Id = termGroup_Id;
                    obj.Class_Id = class_Id;

                    if (list_student.SelectedIndex > 0)
                    {
                        /*Query string settings*/
                        // Qs = "?sc=000" + section_id.ToString() + "000" + session_Id.ToString() + termGroup_Id.ToString() + "&st=" + list_student.SelectedValue;
                        obj.Student_Id = Convert.ToInt32(list_student.SelectedValue);
                    }
                    else
                    {
                        /*Query string settings*/
                        //Qs = "?sc=000" + section_id.ToString() + "000" + session_Id.ToString() + termGroup_Id.ToString() + "&st=0";
                        obj.Student_Id = 0;
                    }
                    obj.isBorder = ChkSys.Checked;
                    AlreadyIn = ObjMea.Marks_Entry_AcknowledgementSelectBySectionSessionVerify(ObjMea); //Marks Entry Acknowledgement
                    if (AlreadyIn == 1 && session_Id > 6)
                    {
                        trShowAck.Visible = true;
                        trShowAckState.Visible = true;
                        DataTable dt = ObjMea.Marks_Entry_AcknowledgementSelectBySectionSessionId(ObjMea);//Marks Entry Acknowledgement Display Grid
                        if (dt.Rows.Count > 0)
                        {
                            gvShowAck.DataSource = dt;
                            gvShowAck.DataBind();
                        }
                    }
                    else
                    {
                        trShowAck.Visible = false;
                        trShowAckState.Visible = false;
                        trShowUnderTakAck.Visible = false;
                        ObjMst.Section_Id = section_id;
                        ObjMst.Evaluation_Criteria_Type_Id = termId;

                        DataTable dtUndTkCheck = ObjMst.Student_Performance_Grading_MstLetterOfUndTkCheck(ObjMst); //Letter of undertaking Acknowledgement Check

                        if (dtUndTkCheck.Rows.Count <= 0)
                        {
                            //if (session_Id>=12 )
                            //{
                            //    url = obj.OpenReport(obj);

                            //}
                            //else
                            //{
                            //    url = url + obj.OpenReport(obj);

                            //}
                            //url = obj.OpenReport(obj);

                            if (obj.Class_Id < 7)
                            {
                                //if (obj.Session_Id == 12)
                                //{
                                //    url = url;

                                //}
                                //else
                                //{
                                //    url = "../PresentationLayer/TCS";
                                //}
                                url = "../PresentationLayer/TCS/";
                                url = url + obj.OpenReport(obj);

                                if (!String.IsNullOrEmpty(url))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                                }
                            }
                            else
                            {
                                if (obj.Session_Id >= 12)
                                {
                                    url = url;

                                }
                                else
                                {
                                    url = "../PresentationLayer/TCS";
                                }
                                //--------------------------------------------------------------------------------------------------------//
                                //-------------------------------Modified By Huzaifa & Parvaiz 08-03-2022---------------------------------//
                                //--------------------------------------------------------------------------------------------------------//

                                if (obj.Class_Id > 13 && obj.Class_Id <= 20)
                                {
                                    if ((obj.TermGroup_Id == 1 || obj.TermGroup_Id == 2) && (obj.Class_Id == 14 || obj.Class_Id == 15 || obj.Class_Id == 19 || obj.Class_Id == 20)) //goto New Report
                                    {
                                        url = "";
                                    }
                                    else if (obj.TermGroup_Id == 2 || (obj.Class_Id == 19 || obj.Class_Id == 20)) //goto Old Report
                                    {
                                        url = "TCS/";
                                    }
                                }
                                //--------------------------------------------------------------------------------------------------------//
                                url = url + obj.OpenReport(obj);

                                if (!String.IsNullOrEmpty(url))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                                }
                            }
                        }

                        //if (!String.IsNullOrEmpty(url))
                        //{
                        //url = "../PresentationLayer/TCS/" + url;

                        //if (session_Id == 11 && ChkSys.Checked == true)
                        //{

                        //    ExportBulkPdf(section_id.ToString(),session_Id.ToString(),termGroup_Id.ToString(),list_student.SelectedValue);
                        //}
                        //else
                        //{
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                        //}

                        //} 
                    }

                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    private void ActualReportCalling()
    {
        try
        {
            if (list_section.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            {
                #region NewCode
                int[] array = new int[4];
                string[] reps = new string[2];

                bool _isok = false;

                int AlreadyIn;
                int termId = Int32.Parse(ddlTerm.SelectedValue);
                int class_Id = Int32.Parse(ddlClass.SelectedValue);
                int section_id = Int32.Parse(list_section.SelectedValue);



                BLLStudent_Performance_Grading_Mst ObjMst = new BLLStudent_Performance_Grading_Mst();

                BLLMarks_Entry_Acknowledgement ObjMea = new BLLMarks_Entry_Acknowledgement();
                BLLEvaluation_Criteria_Type ObjEval = new BLLEvaluation_Criteria_Type();

                int session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                int termGroup_Id;

                ObjMea.Evaluation_Criteria_Type_Id = termId;
                ObjMea.Session_Id = session_Id;
                ObjMea.Section_Id = section_id;



                ObjMst.Evaluation_Criteria_Type_Id = termId;
                ObjMst.Session_Id = session_Id;
                ObjMst.Section_Id = section_id;



                DataTable dtECT = ObjEval.Evaluation_Criteria_TypeFetch(termId); //Term

                if (dtECT.Rows.Count > 0)
                {
                    termGroup_Id = Convert.ToInt32(dtECT.Rows[0]["TermGroup_Id"].ToString());
                }
                else
                {
                    termGroup_Id = 1;
                }

                array[0] = section_id;
                array[1] = session_Id;
                array[2] = termGroup_Id;
                array[3] = class_Id;
                Session["param"] = array;
                Session["StartTime"] = DateTime.Now;
                txtMsg.Text = "Start: Term_Id=" + termId.ToString() + " : Section_Id=" + section_id.ToString() + " 1-EntryAcknow Start:" + DateTime.Now.ToString();
                AlreadyIn = ObjMea.Marks_Entry_AcknowledgementSelectBySectionSessionVerify(ObjMea); //Marks Entry Acknowledgement
                txtMsg.Text = txtMsg.Text + " 1-EntryAcknow End:" + DateTime.Now.ToString();
                if (AlreadyIn == 1 && session_Id > 6)
                {
                    trShowAck.Visible = true;
                    trShowAckState.Visible = true;
                    DataTable dt = ObjMea.Marks_Entry_AcknowledgementSelectBySectionSessionId(ObjMea);//Marks Entry Acknowledgement Display Grid
                    if (dt.Rows.Count > 0)
                    {
                        gvShowAck.DataSource = dt;
                        gvShowAck.DataBind();
                    }


                }
                else
                {

                    trShowAck.Visible = false;
                    trShowAckState.Visible = false;
                    trShowUnderTakAck.Visible = false;
                    ObjMst.Section_Id = section_id;
                    ObjMst.Evaluation_Criteria_Type_Id = termId;
                    txtMsg.Text = txtMsg.Text + " 2-Promotion Start:" + DateTime.Now.ToString();
                    if (list_student.SelectedValue != "0")
                    {
                        ObjMst.Student_Id = Int32.Parse(list_student.SelectedValue);
                        CheckPromotionMethod(class_Id, ObjMst); //Letter of undertaking Check
                    }
                    else
                    {
                        if (ViewState["Students"] != null)
                        {
                            DataTable dtStd = (DataTable)ViewState["Students"];
                            foreach (DataRow dtr in dtStd.Rows)
                            {
                                ObjMst.Student_Id = Convert.ToInt32(dtr["Student_Id"].ToString());
                                CheckPromotionMethod(class_Id, ObjMst); //Letter of undertaking Check
                            }

                        }

                    }
                    txtMsg.Text = txtMsg.Text + " 2-Promotion End:" + DateTime.Now.ToString();

                    txtMsg.Text = txtMsg.Text + " 3-Undertaking Start:" + DateTime.Now.ToString();
                    DataTable dtUndTkCheck = ObjMst.Student_Performance_Grading_MstLetterOfUndTkCheck(ObjMst); //Letter of undertaking Acknowledgement Check
                    txtMsg.Text = txtMsg.Text + " 3-Undertaking End:" + DateTime.Now.ToString();
                    if (dtUndTkCheck.Rows.Count <= 0)
                    {
                        txtMsg.Text = txtMsg.Text + " 4-MarksUpdation Start:" + DateTime.Now.ToString();
                        ObjMst.DatSet = txtMsg.Text;
                        ObjMst.Student_Performance_Grading_MstUpdateMarks(ObjMst); //Marks updation
                        txtMsg.Text = txtMsg.Text + " 4-MarksUpdation End:" + DateTime.Now.ToString();

                        if (class_Id < 7) //For EYE reports
                        {

                            if (termGroup_Id == 1)
                            {
                                if (ChkSys.Checked == true)
                                {

                                    reps[0] = Server.MapPath("Reports\\StudentWisePerformaceReportSecondTermB.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\StudentWisePerformaceReportSecondTerm.rpt");
                                }

                            }
                            else
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\StudentWisePerformaceReportSecondTermB.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\StudentWisePerformaceReportSecondTerm.rpt");
                                }

                            }
                            _isok = true;

                        }
                        else if (class_Id >= 7 && class_Id <= 12) // Class 3-8
                        {
                            if (termGroup_Id == 1)
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm.rpt");
                                }
                            }
                            else
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm.rpt");
                                }

                            }
                            _isok = true;

                        }

                        else if (class_Id >= 13 && class_Id <= 15) // O Level
                        {

                            if (termGroup_Id == 1)
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB_OA.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm_OA.rpt");
                                }
                            }
                            else
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB_OA.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm_OA.rpt");
                                }

                            }
                            _isok = true;
                        }

                        else if (class_Id >= 19 && class_Id <= 20) // A Level
                        {
                            if (termGroup_Id == 1)
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB_OA.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm_OA.rpt");
                                }
                            }
                            else
                            {
                                if (ChkSys.Checked == true)
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTermB_OA.rpt");
                                }
                                else
                                {
                                    reps[0] = Server.MapPath("Reports\\ResultCard_ClassFirstTerm_OA.rpt");
                                }

                            }
                            _isok = true;

                        }
                    }
                    else
                    {
                        trShowUnderTakAck.Visible = true;
                    }


                }

                //if (class_Id > 12)
                //{

                //    reps[1] = SelectCriteria(reps[1], "Arch_MidTerm_OA");
                //}
                //else if (class_Id > 6 && class_Id < 13)
                //{
                //    reps[1] = SelectCriteria(reps[1], "Arch_MidTerm");

                //}
                //else
                //{
                if (list_student.SelectedValue != "0")
                {
                    //Session["CriteriaRpt"] = "{TCS_Result_StudentInformation;1.Student_Id}=" + list_student.SelectedValue;
                    reps[1] = "{TCS_Result_StudentInformation;1.Student_Id}=" + list_student.SelectedValue;
                }
                else
                {
                    reps[1] = "";
                }
                //  }



                if (_isok == true)
                {
                    Session["LastPage"] = "~/PresentationLayer/TCS/Result_Term.aspx";
                    Session["reps"] = reps;

                    //string url = "../TCS/TCS_resultCard.aspx";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

                    Response.Redirect("~/PresentationLayer/TCS/TCS_resultCard.aspx", false);

                }
                #endregion
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    private static void CheckPromotionMethod(int class_Id, BLLStudent_Performance_Grading_Mst ObjMst)
    {

        if (class_Id < 11) // Class 6
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_3_6(ObjMst);
        }
        else if (class_Id == 11) //class 7
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_7(ObjMst);
        }
        else if (class_Id == 12) // Class 8
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_8(ObjMst);
        }
        else if (class_Id == 13) // Class 9
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_9(ObjMst);
        }
        else if (class_Id == 14) // Class 10
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_10(ObjMst);
        }
        else if (class_Id == 15) // Class 11
        {
            ObjMst.Student_Performance_Grading_MstUpdatePromotion_11(ObjMst);
        }


    }

    protected string SelectCriteria(string _cri, string _view)
    {
        string str = "";

        if (ddlSession.SelectedIndex > 0)
        {
            _cri = "{" + _view + ".Session_Id}=" + Convert.ToInt32(ddlSession.SelectedValue);//Convert.ToInt32(Session["Session_Id"]);
        }
        if (ddl_MOrg.SelectedIndex > 0)
        {
            if (_cri.Length > 0)
            {
                _cri = _cri + " and {" + _view + ".Main_Organisation_Id}=" + ddl_MOrg.SelectedValue;
            }
            else
            {
                _cri = " {" + _view + ".Main_Organisation_Id}=" + ddl_MOrg.SelectedValue;
            }
            str = str + "Main Organisation=" + ddl_MOrg.SelectedItem;
        }
        if (ddl_region.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Region_Id}=" + ddl_region.SelectedValue;
            str = str + "  Region=" + ddl_region.SelectedItem;
        }

        if (ddl_center.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Center_Id}=" + ddl_center.SelectedValue;
            str = str + "  Center=" + ddl_center.Text;
        }

        if (ddlClass.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Class_Id}=" + ddlClass.SelectedValue;
            str = str + "  Class=" + ddlClass.Text;
        }

        if (list_section.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Section_Id}=" + list_section.SelectedValue;
            str = str + "  Class=" + list_section.Text;
        }

        if (list_student.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Student_Id}=" + list_student.SelectedValue;
            str = str + "  Class=" + list_student.Text;
        }
        if (ddlTerm.SelectedIndex > 0)
        {
            _cri = _cri + " and {" + _view + ".Evaluation_Criteria_Type_Id}=" + ddlTerm.SelectedValue;
            str = str + "  Class=" + ddlTerm.Text;
        }

        DataRow row = (DataRow)Session["rightsRow"];
        if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)
        {

            _cri = _cri + " and {" + _view + ".Teacher_Id}=" + row["EmployeeCode"].ToString();

        }

        if (Session["AddCriteria"] != null)
        {
            _cri = _cri + Session["AddCriteria"].ToString();
        }
        //Session["rptCmnt"] = str;
        return _cri;
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

    protected void FillClass()
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
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void ResetDropDownList()
    {
        try
        {
            ddlReset(ddl_region);
            ddlReset(ddl_center);

            ddlReset(ddlSession);
            ddlReset(ddlClass);
            ddlReset(list_section);
            ddlReset(list_student);
            ddlReset(ddlTerm);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void ddlReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void bindTermList()
    {
        try
        {
            if (list_section.SelectedIndex > 0)
            {
                DataTable dt = null;
                BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
                ObjECT.Section_Id = Convert.ToInt32(list_section.SelectedValue);
                dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
                objBase.FillDropDown(dt, ddlTerm, "Evaluation_Criteria_Type_Id", "Type");
            }
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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }



    private void LoadClassSection()
    {
        try
        {
            list_section.Items.Clear();
            BLLSection objSec = new BLLSection();

            if (ddlClass.SelectedValue != "")
            {
                objSec.Center_Id = Int32.Parse(ddl_center.SelectedValue);
                objSec.Class_Id = Int32.Parse(ddlClass.SelectedValue);

                DataTable dt = objSec.SectionFetchByClassCenter(objSec);

                objBase.FillDropDown(dt, list_section, "Section_Id", "Section_Name");


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
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadClassSection();
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
            if (list_section.SelectedValue.ToString() != "")
            {
                BindStudentsList();
                bindTermList();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void BindStudentsList()
    {
        //DataTable dt = new DataTable();


        //DataRow rrow = (DataRow)Session["rightsRow"];

        //int c_id = 0;
        //if (ddl_center.SelectedIndex < 0)
        //{
        //    c_id = Convert.ToInt32(rrow["Center_Id"].ToString());

        //}
        //else
        //{
        //    c_id = Convert.ToInt32(ddl_center.SelectedValue);
        //}
        //objBllStd.Center_Id = c_id;

        //objBllStd.Class_ID = Convert.ToInt32(ddlClass.SelectedValue);


        //dt = objBllStd.StudentSelectByClassID(objBllStd);
        //objBase.FillDropDown(dt, list_student, "Student_ID", "StudentNameId");

        try
        {
            BLLStudent_Section_Subject objStd = new BLLStudent_Section_Subject();

            objStd.Section_Id = Convert.ToInt32(list_section.SelectedValue.ToString());
            objStd.Student_Status_Id = 5;
            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            DataTable dt = null;
            list_student.Enabled = true;
            dt = objStd.Student_Section_SubjectSelectBySessionSectionID(objStd);
            ViewState["Students"] = dt;
            objBase.FillDropDown(dt, list_student, "Student_Id", "id_name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.Items.Count > 0)
            {
                ddlClass.SelectedValue = "0";
            }
            if (list_section.Items.Count > 0)
            {
                list_section.SelectedValue = "0";
            }

            if (Convert.ToInt32(ddlSession.SelectedValue) > 14)
            {
                btnViewReport.Visible = false;
            }
            else
            {
                btnViewReport.Visible = true;
            }

            //btnViewReport.Visible = true; 
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
            gvShowAck.DataSource = null;
            gvShowAck.DataBind();
            trShowAck.Visible = false;
            trShowAckState.Visible = false;
            trShowUnderTakAck.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/PresentationLayer/Default.aspx");
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
            int AlreadyIn = 0;
            BLLResult_Grade objClsSec = new BLLResult_Grade();

            BLLEvaluation_Criteria_Type ObjEval = new BLLEvaluation_Criteria_Type();


            int termId = Int32.Parse(ddlTerm.SelectedValue);

            int termGroup_Id;

            if (list_section.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            {
                //objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
                objClsSec.Section_Id = Convert.ToInt32(list_section.SelectedValue.ToString());
                objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

                DataTable dtECT = ObjEval.Evaluation_Criteria_TypeFetch(termId); //Term

                if (dtECT.Rows.Count > 0)
                {
                    termGroup_Id = Convert.ToInt32(dtECT.Rows[0]["TermGroup_Id"].ToString());
                }
                else
                {
                    termGroup_Id = 1;
                }

                objClsSec.TermGroup_Id = termGroup_Id;

                /////////////////

                AlreadyIn = objClsSec.TCS_Result_GenerateResultAllBySection_Id(objClsSec);
                ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select Section, Session and Term!");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
}