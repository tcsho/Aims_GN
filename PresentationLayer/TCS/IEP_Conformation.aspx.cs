using System;
using System.Collections.Generic;
using System.Linq;
using City.Library.SQL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class PresentationLayer_TCS_IEP_Conformation : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string Batch_Id = Request.QueryString["d"].ToString();
                byte[] bd = Convert.FromBase64String(Batch_Id);
                string decrypted_Batch_Id = System.Text.ASCIIEncoding.ASCII.GetString(bd);

                string Student_Id = Request.QueryString["s"].ToString();
                byte[] bs = Convert.FromBase64String(Student_Id);
                Session["decrypted_Student_Id"]  = System.Text.ASCIIEncoding.ASCII.GetString(bs);
               
                DataTable dtupdate = exec_SP("SACK", decrypted_Batch_Id, Session["decrypted_Student_Id"].ToString()).Tables[0];
                dtupdate.Dispose();
                if (dtupdate.Rows.Count > 0)
                {
                    if (dtupdate.Rows[0][0].ToString() == "success")
                    {
                        Email();
                        dv1.Visible = true;
                    }
                    else
                    {
                        DV2.Visible = true;
                    }
                }
                else
                {
                    DV2.Visible = true;
                }
            }

            catch (Exception ex)
            {


                DV2.Visible = true;
            }
        }
    }
    public DataSet exec_SP(string action, string Optional1 = null, string Optional2 = null)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@user_id", "0");
        param[1] = new SqlParameter("@Optional1", Optional1);
        param[2] = new SqlParameter("@Optional2", Optional2);
        param[3] = new SqlParameter("@Action", action);


        DataSet ds = objBase.sqlcmdFetch_DS("SP_IEP_Forms", param);
        ds.Dispose();
        return ds;
    }

    public void Email()
    {

        DataSet dsE = exec_SP(action: "ACK", Optional1: Session["decrypted_Student_Id"].ToString(), Optional2: "1");
        dsE.Dispose();
        if (dsE.Tables.Count > 0 && dsE.Tables[0].Rows.Count > 0)
        {
            // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
            /*****************EMAIL***************/


            MailMessage mail = new MailMessage();
            var Body = "";
            var To = "";

            var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

            To = ConfigurationManager.AppSettings["IEP_Test_TO_Email"].ToString();//"huzaifa.ranta@csn.edu.pk";//lblfatheremail.Text.Trim();
            var Subject = "IEP Acknowledgement";



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

            Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>Acknowledgement success of your child   <strong>" + dsE.Tables[1].Rows[0]["First_Name"].ToString() + "</strong> studying in Class " + dsE.Tables[1].Rows[0]["Class_Name"].ToString() + " <br/><br/>";



         
         
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
            var Password = "C1ty.0148#";

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