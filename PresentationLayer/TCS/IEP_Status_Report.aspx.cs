using City.Library.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_IEP_Status_Report : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadRegions();
            FillActiveSessions();
        }
    }

    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedIndex == 0 || ddl_center.SelectedIndex == 0)
            {
                ViewState["Grid"] = null;
                //BindGrid();
            }
            loadCenter_Class();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dt_class = exec_SP(ddl_center.SelectedItem.Value, ddlClass.SelectedItem.Value, "");
        //Grid_IEPStudents.DataSource = dt_class;
        //Grid_IEPStudents.DataBind();

    }
    private void loadRegions()
    {
        try
        {

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            DataRow row = (DataRow)Session["rightsRow"];
            if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3) || (Convert.ToInt32(row["User_Type_Id"].ToString()) == 4) || (Convert.ToInt32(row["User_Type_Id"].ToString()) == 25))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                ddl_region.Enabled = false;
                loadCenter_Class();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void loadCenter_Class()
    {
        try
        {
            ddlClass.Items.Clear();

            String s = Request.QueryString["id"];

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());

            objCen.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());

            DataTable dt = new DataTable();
            dt = objCen.CenterSelectByRegionSessionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
            DataRow row = (DataRow)Session["rightsRow"];

            if ((Convert.ToInt32(row["User_Type_Id"].ToString()) == 3))
            {
                ddl_region.SelectedValue = row["Region_id"].ToString();
                ddl_center.SelectedValue = row["Center_Id"].ToString();
                ddl_region.Enabled = false;
                ddl_center.Enabled = false;
            }
            DataTable dt_class = exec_SP("","","LOV_Class");
            objBase.FillDropDown(dt_class, ddlClass, "Class_id", "Class_Name");
            //////////UserInformationGrid3.SetData(dt);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    public DataTable exec_SP(string Center, string Class, string Action)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@Center_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);
        param[2] = new SqlParameter("@Term", ddlterm.SelectedIndex);
        param[3] = new SqlParameter("@SessionID", ddl_session.SelectedValue);
        param[4] = new SqlParameter("@regionID", ddl_region.SelectedValue);
        param[5] = new SqlParameter("@Action", Action);
        DataTable dt = objBase.sqlcmdFetch("sp_IEP_Status_Summary_Report_Final", param);
        dt.Dispose();
        return dt;
    }

    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddl_session, "Session_ID", "Description");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid_IEPStudents.Rows.Count > 0)
            {
                Grid_IEPStudents.UseAccessibleHeader = false;
                Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlieptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlterm.SelectedIndex = 0;
        ddlClass.SelectedIndex = 0;
    }

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dt_class = exec_SP(ddl_center.SelectedItem.Value, ddlClass.SelectedItem.Value, "");
        //Grid_IEPStudents.DataSource = dt_class;
        //Grid_IEPStudents.DataBind();
    }

    protected void Grid_IEPStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reminder")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = Grid_IEPStudents.Rows[rowIndex];
            string Student_id = Grid_IEPStudents.Rows[rowIndex].Cells[0].Text;
            string studentname = Grid_IEPStudents.Rows[rowIndex].Cells[1].Text;
            string st_class = Grid_IEPStudents.Rows[rowIndex].Cells[2].Text;
         
            DataTable dt1 = ExecuteProcedure_StudentDetail(Student_id, "");


            if (dt1.Rows.Count > 0)
            {
                // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
                /*****************EMAIL***************/

                string getclass = ddlClass.SelectedIndex.ToString(); //ViewState["classids"].ToString();
                string getterm = ddlterm.SelectedIndex.ToString(); //ViewState["TermGroupID"].ToString();

                MailMessage mail = new MailMessage();
                var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                var Body = "";
                var To = dt1.Rows[0][2].ToString();
                var cc = "";
                var Password = ConfigurationManager.AppSettings["AppNotificationPwd"].ToString();
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
                Body += "<img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png'>";
                Body += "</td>";
                Body += "</tr>";
                Body += "<tr>";
                Body += "<td style='padding:36px 30px 42px 30px;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
                Body += "<tr>";
                Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
                Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";
                Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>The acknowledgement of your child’s IEP is still pending. Please use the link below to review it and acknowledge it.</p><br/>";
                Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p>";
                Body += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I, as a parent / guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in Class " + dt1.Rows[0]["Class_Name"].ToString() + "</strong>  " +
                    "confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:</p> ";


                /**on basis change**/
                /**CLASS UNDERTAKING**/
                if (getclass == "12" && getterm == "1")
                {

                    onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
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



                Body += onclassbase;
                Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>You can also review the Individual Education Plan we have created to support your child’s progress. Once you have reviewed it, please acknowledge it.</p> ";

                //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request</p>";



                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Student_id);
                string encrypted_student_Id = Convert.ToBase64String(b);

                byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(getclass);
                string encrypted_class_Id = Convert.ToBase64String(c);

                byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["Session_Id"].ToString());
                string encrypted_session_Id = Convert.ToBase64String(sess);


                byte[] stname = System.Text.ASCIIEncoding.ASCII.GetBytes(studentname);
                string encrypted_student_Name = Convert.ToBase64String(stname);

                byte[] classsec = System.Text.ASCIIEncoding.ASCII.GetBytes(st_class);
                string encrypted_student_ClassSec = Convert.ToBase64String(classsec);



                // var url = "http://localhost:50091/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id+"&Cl_Id="+ encrypted_class_Id+"&Sess_Id="+ encrypted_session_Id+"&St_Nm=" + encrypted_student_Name + "&St_ClS=" + encrypted_student_ClassSec;//ddlStudent.SelectedValue
                var urlconfirmation = "http://tcsaims.com/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id + "&St_Nm=" + encrypted_student_Name + "&St_ClS=" + encrypted_student_ClassSec;//ddlStudent.SelectedValue
                var urliep = "http://www.tcsaims.com/PresentationLayer/tcs/Parent_IEP_Form.aspx?s=" + Student_id + "&ses=" + Session["Session_Id"].ToString();
                Body += "<p style='text-align:center'><b><a style='color: #fff text-decoration:none border:none padding:10px 100px !important background:#0C4DA2 border-radius:10px 'href='" + urliep + "' >Click to view IEP form</a></b></p> ";
                Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + urlconfirmation + "'>Confirm</a></b></p>";

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

                cc = dt1.Rows[0]["centerEmail"].ToString();
                //cc2 = "Insa.Sohail@csn.edu.pk";
                try
                {
                    using (MailMessage mm = new MailMessage(Email.Address, To))
                    {
                        mm.Subject = "Acknowledgement Reminder to Parents for IEP + Undertaking";
                        mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                        mm.CC.Add(new MailAddress(cc));
                       // mm.CC.Add(new MailAddress(cc2));
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
                                //DataTable dt = SP_REMINDER_EMAIL_IEP_BIFURCATION(Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString(), ddlterm.SelectedIndex);
                                //dt.Dispose();
                                smtp.Send(mm);



                            }
                            catch (SmtpFailedRecipientException ex)
                            {

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    //DataTable dt = ExecuteProcedure("IN", "", Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString(), 0);
                    // dt.Dispose();
                }
            }
        }
    }
    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_IEP_bifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
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
    public DataTable exec_SP_table(string Center, string Class, string Action)
    {

        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@Center_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);
        param[2] = new SqlParameter("@Term", ddlterm.SelectedItem.Text);
        param[3] = new SqlParameter("@SessionID", ddl_session.SelectedItem.Text);
        param[4] = new SqlParameter("@regionID", ddl_region.SelectedValue);
        param[5] = new SqlParameter("@Action", Action);

        DataTable dt = objBase.sqlcmdFetch("sp_IEP_Status_Summary_Report_Final", param);
        dt.Dispose();
        return dt;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string ClassNameValue, CenterNameValue;
        if (ddl_region.SelectedIndex > 0)
        {
            if (ddlClass.SelectedItem.Value == "0")
            {
                ClassNameValue = "0";
            }
            else
            {
                ClassNameValue = ddlClass.SelectedItem.Text;
            }
            if (ddl_center.SelectedItem.Value == "0")
            {
                CenterNameValue = "0";
            }
            else
            {
                string splitcenterName = ddl_center.SelectedItem.Text;

                CenterNameValue = splitcenterName.Split('-')[1].ToString().Trim();
            }
            DataTable dt_class = exec_SP_table(CenterNameValue, ClassNameValue, "");

            //DataTable dt_class = exec_SP(ddl_center.SelectedItem.Value, ddlClass.SelectedItem.Value, "");
            Grid_IEPStudents.DataSource = dt_class;
            Grid_IEPStudents.DataBind();
        }
    }
}


