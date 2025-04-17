using System;
using System.Collections.Generic;
using System.Linq;
using City.Library.SQL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Net;

public partial class PresentationLayer_Bifurcation_Confirmation : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        string  Student_Id=Request["St_Id"];
        string Class_Id = Request["Cl_Id"];
        string Session_Id = Request["Sess_Id"];



        //DataTable dt = ExecuteProcedure("GETDTL", "","", "", Student_Id);
        //dt.Dispose();
        //if (dt.Rows.Count > 0)
        //{

        //    txt_Student_Name1.Text = dt.Rows[0]["studentname"].ToString();
        //    txt_Student_Section.Text = dt.Rows[0]["section_name"].ToString();
        //    //bi_label_father.Text = "Ghamoon Mal Chohan";
        //}


        //else { txt_Student_Name1.Text = ""; txt_Student_Section.Text = ""; }
        byte[] bd = Convert.FromBase64String(Student_Id);
        string decrypted_Student_Id = System.Text.ASCIIEncoding.ASCII.GetString(bd);

        byte[] cd = Convert.FromBase64String(Class_Id);
        string decrypted_Class_Id = System.Text.ASCIIEncoding.ASCII.GetString(cd);

        byte[] sessd = Convert.FromBase64String(Session_Id);
        string decrypted_Session_Id = System.Text.ASCIIEncoding.ASCII.GetString(sessd);

        DataTable dtupdate = ExecuteProcedure("UP", "", decrypted_Session_Id, "", decrypted_Student_Id,"", decrypted_Class_Id);
        dtupdate.Dispose();

        Email(decrypted_Student_Id);
        //if (dtupdate.Rows.Count > 0)
        //{


        //}


        //else { txt_Student_Name1.Text = ""; txt_Student_Section.Text = ""; }

    }

    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "")
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);


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

    public void Email(string student_id)
    {
        DataTable dt1 = ExecuteProcedure_StudentDetail(student_id, "");
        dt1.Dispose();
  
        if (dt1.Rows.Count>0)
        {
            // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
            /*****************EMAIL***************/


            MailMessage mail = new MailMessage();
            var Body = "";
            var To = "";
            var CC = "";
            var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

            To = dt1.Rows[0][2].ToString();//ConfigurationManager.AppSettings["Bifurcation_email"].ToString();//"huzaifa.ranta@csn.edu.pk";//lblfatheremail.Text.Trim();
            var Subject = "Bifurcation Acknowledgement";
            CC = "ManageAcknowledgement@csn.edu.pk";  


            /***********HTML TEMPLET***/
            Body += "<body style='margin:0;padding:0;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:0;'>";
            Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2

            //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
            Body += "<img src = 'https://thecityschool.edu.pk/wp-content/uploads/2019/01/tcs-logo-wh.png'>";
            Body += "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td style='padding:36px 30px 42px 30px;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
            Body += "<tr>";
            Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
            Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";

            Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>Acknowledgement success of your child   <strong>" + dt1.Rows[0]["First_Name"].ToString() + "</strong> studying in Class " + dt1.Rows[0]["Class_Name"].ToString() + " <br/><br/>";





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
                mm.CC.Add(new MailAddress(CC));
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

                        // lblerror.Text = "Email Sent Successfully";
                        // lblerror.CssClass = "label label-success text-center";
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        //lblerror.Text = "Error : " + ex;
                        //lblerror.CssClass = "label label-danger text-center";

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