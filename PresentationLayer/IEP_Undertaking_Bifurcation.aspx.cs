using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using City.Library.SQL;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public partial class PresentationLayer_TCS_IEP_Undertaking_Bifurcation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();

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

                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}


                //FillClassSection();



                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["moID"].ToString());
                ViewState["SortDirection"] = "ASC";
                ViewState["mode"] = "Add";
                ViewState["tMood"] = "check";
                // LoadClassSection();

                //if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                //{

                //    DataTable dt = ExecuteProcedure("GetBDataC", "", Session["session_id"].ToString(), row["center_id"].ToString());
                //    dt.Dispose();
                //    if (dt.Rows.Count > 0)
                //    {
                //        ddlStudent.DataSource = dt;
                //        ddlStudent.DataValueField = "student_id";
                //        ddlStudent.DataTextField = "studentname";
                //        ddlStudent.DataBind();
                //        ddlStudent.Items.Insert(0, new ListItem("--Select--", ""));
                //    }
                //    else { ImpromptuHelper.ShowPrompt("No Data Found"); }
                //}
                //else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Teacher Officer
                //{
                //    DataTable dt = ExecuteProcedure("GetBDataT", row["User_Name"].ToString(), Session["session_id"].ToString(), row["center_id"].ToString());
                //    dt.Dispose();
                //    if (dt.Rows.Count > 0)
                //    {
                //        ddlStudent.DataSource = dt;
                //        ddlStudent.DataValueField = "student_id";
                //        ddlStudent.DataTextField = "studentname";
                //        ddlStudent.DataBind();
                //        ddlStudent.Items.Insert(0, new ListItem("--Select--", ""));
                //    }
                //    else { ImpromptuHelper.ShowPrompt("No Data Found"); }




                //}



                if (Request.QueryString.Count > 0)
                {
                    string _studntid = Request.QueryString["S"].ToString();
                    string _secid = Request.QueryString["C"].ToString();
                    string _Trmid = Request.QueryString["T"].ToString();

                    DataTable dt = ExecuteProcedure_StudentDetail(_studntid, _secid, Convert.ToInt32(_Trmid));
                    dt.Dispose();
                    string _classID = "";
                    if (dt.Rows.Count > 0)
                    {
                       
                        _classID = dt.Rows[0]["class_id"].ToString();
                        ViewState["classids"] = _classID;
                        ViewState["termids"] = _Trmid;
                        /**CLASS UNDERTAKING**/
                        if (_classID == "12" && _Trmid == "1"  )
                        {
                            bi_lettersubheading.Text = dt.Rows[0]["student_no"].ToString() + " - Application – Moving from Class 9 Matric to the O-Level route";
                            bi_classchange.Text = "Class 8 ";
                            ul_List.InnerHtml = "<li> 1) That the school, after careful deliberation and consideration of the Class 8 Results, had advised me to transfer my child to the Matric system.</li>" +
                                "<li> 2) However, I am insisting that my child should continue the O-Level route.</li>" +
                                "<li> 3)I take the responsibility that my child will meet the school’s required attainment levels.</li>" +
                                "<li> 4)Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</li>";
                            spn_class.InnerText = "Class 8 ";
                        }

                        if (_classID == "12" && _Trmid == "2" && dt.Rows[0]["region_id"].ToString() == "30000000" || dt.Rows[0]["region_id"].ToString() == "40000000")
                        {
                            bi_lettersubheading.Text = dt.Rows[0]["student_no"].ToString() + "- Application – Continue O-level route (Class 8 - 2nd term)";
                            bi_classchange.Text = "Class 8 ";
                            ul_List.InnerHtml = "<li> 1)  The school has clearly explained that my child’s class 8 (2nd term) result is not up to the mark.</li><li> 2)  I take the responsibility that my child will meet the school’s required attainment levels. </li><li> 3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</li>";
                            spn_class.InnerText = "Class 8 ";
                        }
                        if (_classID == "12" && _Trmid == "2" && dt.Rows[0]["region_id"].ToString() == "20000000" )
                        {
                            bi_lettersubheading.Text = dt.Rows[0]["student_no"].ToString() + "- Application – Moving from Class 9 Matric to the O-Level route";
                            bi_classchange.Text = "Class 8 ";
                            ul_List.InnerHtml = "<li> 1)  The school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</li><li> 2)  However, I am insisting that my child should continue the O-Level route. </li><li> 3)  I take the responsibility that my child will meet the school’s required attainment levels.</li><li> 4) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</li>";
                            spn_class.InnerText = "Class 8 ";
                        }

                        if (_classID == "13" && _Trmid == "1")
                        {

                            bi_lettersubheading.Text = "Undertaking – Class 9 (1st term)";
                            bi_classchange.Text = "Class 9 ";
                            ul_List.InnerHtml = "<li> 1) The school has clearly explained that my child’s class 9 (1st term) result is not up to the mark.</li>" +
                                "<li> 2) I take the responsibility that my child will meet the school’s required attainment levels.</li>" +
                                  "<li> 3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</li>";
                            spn_class.InnerText = "Class 9 ";
                        }

                        if (_classID == "13" && _Trmid == "2")
                        {

                            bi_lettersubheading.Text = "Undertaking – Class 9 (2nd term)";
                            bi_classchange.Text = "Class 9 ";
                            ul_List.InnerHtml = "<li> 1) The school has clearly explained that my child’s class 9 (2nd term) result is not up to the mark.</li>" +
                                "<li> 2) I take the responsibility that my child will meet the school’s required attainment levels. </li>" +
                                "<li> 3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams. </li>";
                            spn_class.InnerText = "Class 9 ";
                        }


                        if (_classID == "14" && _Trmid == "1")
                        {
                            bi_lettersubheading.Text = "Undertaking – Class 10 (1st term)";
                            bi_classchange.Text = "Class 10 ";
                            ul_List.InnerHtml = "<li> 1) 1)\tThe school has clearly explained that my child’s class 10 (1st term) result is not up to the mark.</li>" +
                                "<li> 2) I take the responsibility that my child will meet the school’s required attainment levels.</li>" +
                                "<li> 3) Failure to meet the minimum requirements in the upcoming CAIE and the internal exams may result in my child’s private registration for his/her CAIE Exams next year.</li>";
                            spn_class.InnerText = "Class 10 ";
                        }
                        if (_classID == "14" && _Trmid == "2")
                        {
                            bi_lettersubheading.Text = "Class 10 Mid-Year Undertaking";
                            bi_classchange.Text = "Class 10 ";
                            ul_List.InnerHtml = "<li> 1) That the school, after careful deliberation and consideration of the Class 9 EOY Results, had provisionally promoted my child to Year 10.</li><li> 2) My child has not passed the Class 10 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 10 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</li>";
                            spn_class.InnerText = "Class 10 ";
                        }

                        if (_classID == "15" && _Trmid == "2")
                        {
                            bi_lettersubheading.Text = "Class 11 Mock Undertaking";
                            bi_classchange.Text = "Class 11 ";
                            ul_List.InnerHtml = "<li> 1) That the school, after careful deliberation and consideration of the Class 11 Mid-year examination Results, had provisionally allowed my child to sit for Year 11 Mock examinations. </li><li> 2) My child has not passed the Class 11 Mock examinations with the minimum required attainment levels and is going to be privatized for Cambridge Exams.</li>";
                            spn_class.InnerText = "Class 11 ";
                        }

                        if (_classID == "15" && _Trmid == "1")
                        {
                            bi_lettersubheading.Text = "Class 11 Mid-Year Undertaking";
                            bi_classchange.Text = "Class 11 ";
                            ul_List.InnerHtml = "<li> 1) That the school, after careful deliberation and consideration of the Class 10 Mocks and Cambridge Results, had provisionally promoted my child to Year 11.</li><li> 2) My child has not passed the Class 11 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 11 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</li>";
                            spn_class.InnerText = "Class 11 ";
                        }
                        /**CLASS UNDERTAKING**/

                        /**SET label**/
                        lblCenter_Id.Text = dt.Rows[0]["center_id"].ToString();
                        lblStudent_Id.Text = dt.Rows[0]["Student_No"].ToString();
                        //lblSession_Id.Text = dt.Rows[0]["Session_Id"].ToString();
                        lblClass_Id.Text = dt.Rows[0]["class_id"].ToString();
                        lblfatheremail.Text = dt.Rows[0]["FatherEmail"].ToString();
                        txt_Student_Name1.Text = dt.Rows[0]["First_Name"].ToString();
                        txt_Student_Section.Text = dt.Rows[0]["Section_Name"].ToString();
                        if (dt.Rows[0]["ParentApproved"].ToString() == "1")
                        {//   txtfathersign.Text = dt.Rows[0]["First_Name"].ToString();
                            lblrcv.Visible = true;
                            lblrcv.InnerText = lblrcv.InnerText + dt.Rows[0]["Date"].ToString() + "."; 
                        }
                       // txtheadname.Text = dt.Rows[0]["headname"].ToString();
                       // txtdate.Text = dt.Rows[0]["Date"].ToString();
                        /**SET label**/
                    }


                    //List_ClassSection.SelectedValue = _secid;
                    //List_ClassSection_SelectedIndexChanged(null, null) ;

                    //BiTerm.SelectedValue = _Trmid;

                    //ddlStudent.SelectedValue = _studntid;
                    //ddlStudent_SelectedIndexChanged(null,null);


                }
                /***class dropdown**/
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    /**detail procedure**/
    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id,int term_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_iepandbifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("term_id", term_id, DataAccess.SQLParameterType.Number, true);
        //obj_Access.AddParameter("Term_id", Term_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


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
    /**detail procedure**/
    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "")
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter_withfatheremail");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);//
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_UserID", Session["UserId"].ToString(), DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


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
    //protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (ddlStudent.SelectedIndex > 0)
    //    {
    //        DataTable dt = ExecuteProcedure("GETDTL", "", Session["session_id"].ToString(), "", ddlStudent.SelectedValue);
    //        dt.Dispose();
    //        if (dt.Rows.Count > 0)
    //        {

    //            lblCenter_Id.Text = dt.Rows[0]["Center_Id"].ToString();
    //            lblStudent_Id.Text = dt.Rows[0]["Student_Id"].ToString();
    //            lblSession_Id.Text = dt.Rows[0]["Session_Id"].ToString();
    //            lblClass_Id.Text = dt.Rows[0]["Class_Id"].ToString();
    //            lblfatheremail.Text = dt.Rows[0]["FatherEmail"].ToString();
    //            txt_Student_Name1.Text = dt.Rows[0]["studentname"].ToString();
    //            txt_Student_Section.Text = dt.Rows[0]["section_name"].ToString();

    //        }

    //    }
    //    else { txt_Student_Name1.Text = ""; txt_Student_Section.Text = ""; }



    //}


    //private void FillClassSection()
    //{



    //    try
    //    {
    //        DALBase objBase = new DALBase();
    //        BLLClass_Section objCS = new BLLClass_Section();

    //        int Center_Id = Convert.ToInt32(Session["CId"]);

    //        DataTable _dt = objCS.Class_SectionByCenterId(Center_Id);
    //        _dt.DefaultView.RowFilter = "Class_Id in (7,8,9,10,11,12,13,14,15)";
    //        DataTable _dtfilter = _dt.DefaultView.ToTable();
    //        objBase.FillDropDown(_dt, List_ClassSection, "Section_Id", "fullclasssection");

    //        if (List_ClassSection.Items.Count == 0)
    //        {
    //            ImpromptuHelper.ShowPrompt("Please assign section(s) first.");
    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    protected void List_Term_SelectedIndexChanged(object sender, EventArgs e)
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

    //protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DALBase objBase = new DALBase();
    //        BLLClass_Section objCS = new BLLClass_Section();

    //        int Center_Id = Convert.ToInt32(Session["CId"]);

    //        DataTable _dt = objCS.Class_SectionByCenterId(Center_Id);
    //        _dt.DefaultView.RowFilter = "Section_Id = " + List_ClassSection.SelectedValue;
    //        DataTable _dtfilter = _dt.DefaultView.ToTable();

    //        string _classID = _dtfilter.Rows[0]["Class_id"].ToString();
    //        string _TermGroupID = Request.QueryString["T"].ToString();





    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}


    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dt = ExecuteProcedure("IN", "", Session["session_id"].ToString(), lblCenter_Id.Text, lblStudent_Id.Text, txt_Student_Name1.Text, lblClass_Id.Text);
        dt.Dispose();
        if (dt.Rows.Count > 0)
        {
            // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
            /*****************EMAIL***************/

            var getclass = ViewState["classids"].ToString();
            var getterm = ViewState["termids"].ToString();

            MailMessage mail = new MailMessage();
            var Body = "";
            var To = "";

            var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

            To = lblfatheremail.Text;
            var Subject = "Bifrucation Confirmation";



            var onclassbase = "";

            /***********HTML TEMPLET***/
            Body += "<body style='margin:0;padding:0;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:0;'>";
            Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2

            //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
            Body += "<img src = 'https://rebill.csn.edu.pk:8096/inassets/city/tcslogowhite.png'>";
            Body += "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td style='padding:36px 30px 42px 30px;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
            Body += "<tr>";
            Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
            Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";

            Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish to submit your application for your child to take O level route, then read & submit the following application:</p><br/><br/>";


            Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>I, as a parent / guardian of <strong>" + txt_Student_Name1.Text.Trim() + "</strong> studying in " + spn_class.InnerText + " Section <strong>" + txt_Student_Section.Text.Trim() + "</strong> confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:</p>";

            /**on basis change**/
            /**CLASS UNDERTAKING**/
            if (getclass == "12" && getterm == "1")
            {

                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) tThe school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) However, I am insisting that my child should continue the O-Level route.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 4) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</p>";
            }
            if (getclass == "12" && getterm == "2")
            {

                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 8 (2nd term) result is not up to the mark.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams</p>";

            }

            if (getclass == "13" && getterm == "2")
            {


                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>" +
                    " 1) The school has clearly explained that my child’s class 9 (2nd term) result is not up to the mark.</p>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "2) I take the responsibility that my child will meet the school’s required attainment levels.</p>" +
                     "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</p>";

            }

            if (getclass == "13" && getterm == "1")
            {


                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "1) The school has clearly explained that my child’s class 9 (1st term) result is not up to the mark." +
                      "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
               " 2) I take the responsibility that my child will meet the school’s required attainment levels.+ " +
                 "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                "3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams. </p>";

            }


            if (getclass == "14" && getterm == "2")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 10 (1st term) result is not up to the mark.</p>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "2) I take the responsibility that my child will meet the school’s required attainment levels.</li>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "<li> Failure to meet the minimum requirements in the upcoming CAIE and the internal exams may result in my child’s private registration for his/her CAIE Exams next year.</p>";

            }
            if (getclass == "14" && getterm == "1")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 9 EOY Results, had provisionally promoted my child to Year 10.</p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 10 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 10 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

            }

            if (getclass == "15" && getterm == "2")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 11 Mid-year examination Results, had provisionally allowed my child to sit for Year 11 Mock examinations. </p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mock examinations with the minimum required attainment levels and is going to be privatized for Cambridge Exams.</p>";

            }

            if (getclass == "15" && getterm == "1")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 10 Mocks and Cambridge Results, had provisionally promoted my child to Year 11.</p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 11 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

            }
            /**CLASS UNDERTAKING**/



            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>1) That the school, after careful deliberation and consideration of the " + spn_class.InnerText + " Results, has advised me to transfer my child to the Matric system.</p>";
            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>2) However, at my insistence, the school has provisionally allowed my child to sit in " + spn_class.InnerText + " and take final examinations for the O level stream.</p>";
            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>3) Accept the responsibility that my child must pass the " + spn_class.InnerText + " Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";
            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</p>";
            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</p>";

            Body += onclassbase;

            Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request</p>";



            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(lblStudent_Id.Text.Trim());
            string encrypted_student_Id = Convert.ToBase64String(b);

            byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(lblClass_Id.Text.Trim());
            string encrypted_class_Id = Convert.ToBase64String(c);

            byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["session_id"].ToString().Trim());
            string encrypted_session_Id = Convert.ToBase64String(sess);



            //var url = "http://localhost:50091/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id+"&Cl_Id="+ encrypted_class_Id+"&Sess_Id="+ encrypted_session_Id;//ddlStudent.SelectedValue
            var url = "http://tcsaims.com/PresentationLayer/BifurcationConfirmation_IEP.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id;//ddlStudent.SelectedValue
            Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + url + "'>Confirm</a></b></p>";

            Body += "</td>";
            Body += "</tr>";

            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td style='padding:30px;background:#FBEE26;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
            Body += "<tr>";
            Body += "<td style='padding:0;width:100%;' align='Center'>";
            Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

            Body += "</td>";

            Body += "</tr>";
            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "</table>";
            Body += "</body>";
            /*****HTML TEMPLET*********/


            //var Password = "Pakistan!@#$";//gmail//"@U13K$@CgMlG";
            var Password = "Jup31963";

            using (MailMessage mm = new MailMessage(Email.Address, To))
            {
                mm.Subject = Subject;
                mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                //mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

                mm.Body = Body;


                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    // smtp.Host = "smtp.gmail.com"; //"mail.bizar.pk";
                    smtp.Host = "smtp.office365.com"; //"mail.bizar.pk";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Timeout = 1000000000;



                    try
                    {
                        smtp.Send(mm);



                    }
                    catch (SmtpFailedRecipientException ex)
                    {

                    }

                }
            }

            /********EMAIL******************/
        }
        else
        { //ImpromptuHelper.ShowPrompt("No Data Found"); }
        }


    }
}