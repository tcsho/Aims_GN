using System;
using System.Collections.Generic;
using System.Linq;
using City.Library.SQL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public partial class PresentationLayer_Bifurcation_Confirmation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {

        string Student_Id = Request["St_Id"];
        string Class_Id = Request["Cl_Id"];
        string Session_Id = Request["Sess_Id"];

        string Student_Name = Request["St_Nm"];
        string Student_ClassSec = Request["St_ClS"];


        byte[] bd = Convert.FromBase64String(Student_Id);
        string decrypted_Student_Id = System.Text.ASCIIEncoding.ASCII.GetString(bd);

        byte[] cd = Convert.FromBase64String(Class_Id);
        string decrypted_Class_Id = System.Text.ASCIIEncoding.ASCII.GetString(cd);

        byte[] sessd = Convert.FromBase64String(Session_Id);
        string decrypted_Session_Id = System.Text.ASCIIEncoding.ASCII.GetString(sessd);


        //byte[] stname = Convert.FromBase64String(Student_Name);
        //string decrypted_Student_Name = System.Text.ASCIIEncoding.ASCII.GetString(stname);

       // byte[] stclssec = Convert.FromBase64String(Student_ClassSec);
        //string decrypted_StudentClassSec = System.Text.ASCIIEncoding.ASCII.GetString(stclssec);
        DataTable dt1 = ExecuteProcedure_StudentDetail(decrypted_Student_Id, "");
        string studentname = dt1.Rows[0][1].ToString();
        string centerid = dt1.Rows[0][13].ToString();
        string Term = dt1.Rows[0]["Term"].ToString();
        string region_id = dt1.Rows[0][13].ToString();
        dt1.Dispose();
        /****EMAIL***/
        MailMessage mail = new MailMessage();
        var Body = "";
        

        var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

        // To = ConfigurationManager.AppSettings["Bifurcation_email"].ToString();//dt1.Rows[0][2].ToString();// //
        var To = dt1.Rows[0][2].ToString();
        //var To = "muhammad.maroof1@csn.edu.pk";
        var CC = dt1.Rows[0]["CenterEmail"].ToString();
        var CC2 = "ManageAcknowledgement@csn.edu.pk";//dt1.Rows[0]["centerEmail"].ToString();                                                              // CC = "ManageAcknowledgement@csn.edu.pk";
        
            



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
        //Body += "<img src = 'https://rebill.csn.edu.pk:8096/inassets/city/tcslogowhite.png'>";
        Body += "<img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png'>";
        Body += "</td>";
        Body += "</tr>";
        Body += "<tr>";
        Body += "<td style='padding:36px 30px 42px 30px;'>";
        Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
        Body += "<tr>";
        Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
        Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";




        /**on basis change**/
        /**CLASS UNDERTAKING**/
        if (decrypted_Class_Id == "12" && Term == "1" && (region_id == "40000000" || region_id == "30000000"))
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>We have received your undertaking to promote your child to the O-Level route. Upon your request, we are promoting the student on the desired path.</p>";
        }
        if (decrypted_Class_Id == "12" && Term == "2" && (region_id == "40000000" ||  region_id == "30000000"))
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Thank you sincerely for submitting the undertaking.</p>";
        }
        if (decrypted_Class_Id == "12" && Term == "2" && region_id == "20000000")
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>We have received your undertaking to promote your child to the O-Level route. Upon your request, we are promoting the student on the desired path.</p>";
        }
        if (decrypted_Class_Id == "12" && Term == "2" && region_id == "20000000" && (centerid == "20201002" || centerid == "20201005"))
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Thank you sincerely for submitting the undertaking.</p>";
        }
        if (decrypted_Class_Id == "13")
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Dear Parent, We have received your undertaking that your child will improve his/her academic results in the next term’s exams.</p>";

        }
        if (decrypted_Class_Id == "14")
        {
            onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Dear Parent, We have received your undertaking that your child will improve his/her academic results in the next term’s exams.</p>";

        }

        /**CLASS UNDERTAKING**/



        //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>1) That the school, after careful deliberation and consideration of the " + spn_class.InnerText + " Results, has advised me to transfer my child to the Matric system.</p>";
        //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>2) However, at my insistence, the school has provisionally allowed my child to sit in " + spn_class.InnerText + " and take final examinations for the O level stream.</p>";
        //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>3) Accept the responsibility that my child must pass the " + spn_class.InnerText + " Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";
        //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</p>";
        //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</p>";

        Body += onclassbase;







        //var url = "http://localhost:50091/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id+"&Cl_Id="+ encrypted_class_Id+"&Sess_Id="+ encrypted_session_Id;//ddlStudent.SelectedValue
        //var url = "http://trainingaims.thecityschool.edu.pk/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id;//ddlStudent.SelectedValue
        // Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + url + "'>Confirm</a></b></p>";

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
        var Password = ConfigurationManager.AppSettings["AppNotificationPwd"].ToString();
        //var Password2 = ConfigurationManager.AppSettings["AppNotificationGmail"].ToString();

       // using (MailMessage mm = new MailMessage(Email.Address, To))
        using (MailMessage mm = new MailMessage(Email.Address, To))
        {
            //if (decrypted_Class_Id == "12" && Term == "2" && (region_id == "40000000" || region_id == "30000000"))
            //{
                //var Subject = "Parent's Undertaking for " + studentname + " (" + decrypted_Student_Id + ") | " + dt1.Rows[0][4].ToString() + " | Term: " + Term + " | Center Name: " + dt1.Rows[0]["Center_Name"].ToString(); ;
            //}
            //else if (decrypted_Class_Id == "12" && Term == "2" && region_id == "20000000" && (centerid == "20201002" || centerid == "20201005"))
            //{
                var Subject = "Parent's Bifurcation Undertaking for " + studentname + " (" + decrypted_Student_Id + ") | " + dt1.Rows[0][4].ToString() + " | Term: " + Term + " | Center Name: " + dt1.Rows[0]["Center_Name"].ToString(); 
            mm.Subject = Subject;
            mm.From = new MailAddress("noreply@csn.edu.pk", "The City School");
            if (CC != "")
            {
                mm.CC.Add(new MailAddress(CC));
            }
            mm.CC.Add(new MailAddress(CC2));
            //mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

            mm.Body = Body;


            mm.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.office365.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials =
                new NetworkCredential("noreply@csn.edu.pk", "Master@123");
                smtp.Timeout = 1000000000;
                // Enable verbose logging
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.TargetName = "STARTTLS/smtp.office365.com";
                // Capture additional log information
                smtp.ServicePoint.MaxIdleTime = 1; smtp.ServicePoint.ConnectionLimit = 1; ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                try
                {
                    smtp.Send(mm);
                }
                catch
                (SmtpException smtpEx)
                {
                    Console.WriteLine(
                "SMTP Exception: "
                + smtpEx.Message);
                    if
                    (smtpEx.InnerException != null)
                    {
                        Console.WriteLine(
                    "Inner Exception: "
                    + smtpEx.InnerException.Message);
                    }
                }

                catch
                (Exception ex)
                {
                    Console.WriteLine(
                "General Exception: "
                + ex.Message);
                }
            }
        }

        /********EMAIL******************/






        //DataTable dt = ExecuteProcedure("GETDTL", "","", "", Student_Id);
        //dt.Dispose();
        //if (dt.Rows.Count > 0)
        //{

        //    txt_Student_Name1.Text = dt.Rows[0]["studentname"].ToString();
        //    txt_Student_Section.Text = dt.Rows[0]["section_name"].ToString();
        //    //bi_label_father.Text = "Ghamoon Mal Chohan";
        //}


        //else { txt_Student_Name1.Text = ""; txt_Student_Section.Text = ""; }


        DataTable dtupdate = ExecuteProcedure("UP", "", decrypted_Session_Id, "", decrypted_Student_Id, "", decrypted_Class_Id, Term);
        dtupdate.Dispose();
        //if (dtupdate.Rows.Count > 0)
        //{


        //}


        //else { txt_Student_Name1.Text = ""; txt_Student_Section.Text = ""; }

    }

    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "",string p_term = "")
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter_withfatheremail");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_UserID", 0, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Is_success", 0, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("term", p_term, DataAccess.SQLParameterType.VarChar, true);

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
    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_IEP_bifurcation_studentdetail_ForEmail");
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


}