using System;
using System.Data;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for BLLSendEmail
/// </summary>
public class BLLSendEmail
{
    private string fromEmail, password, host, target;
    private int port;
    private int emailCategory_Id;
    _DALSendEmail objDal = new _DALSendEmail();
  
    
    public BLLSendEmail()
    {
        fromEmail = "AppNotifications@csn.edu.pk";
        password = "city_0369#";
        host = "smtp.office365.com";
        target = "STARTTLS/smtp.office365.com";
        port = 587;

    }
    public int EmailCategory_Id
    {
        get { return emailCategory_Id; }
        set { emailCategory_Id = value; }
    }

    public bool IsValidEmailFormat(string emailToValidate)
    {
        if (string.IsNullOrWhiteSpace(emailToValidate))
        {
            return false;
        }

        return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate,
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    public bool SendEmail(int emailCatID, string subject, string msgbody, string displayName)
    {
        bool isSent = false;
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromEmail);
        BLLSendEmail objBll = new BLLSendEmail();
        objBll.EmailCategory_Id = emailCatID;
        string msg = string.Empty;

        DataTable dt = new DataTable();
        dt = objDal.TssHoEmailConfigurationSelectByCategoryId(objBll);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var isValidEmail = IsValidEmailFormat(dr["EmailAddress"].ToString());
                if (!isValidEmail)
                {
                    throw new Exception("Email Address is invalid {toEmail}");
                }
                switch (Convert.ToInt32(dr["EmailAdressType_ID"]))
                {
                    case 1:
                        {
                            message.To.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                    case 2:
                        {
                            message.CC.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                    case 3:
                        {
                            message.Bcc.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                }
            }
        }
        message.Subject = subject;
        message.IsBodyHtml = true;
        message.Body = (msgbody);
        message.BodyEncoding = (System.Text.Encoding.UTF8);
        message.SubjectEncoding = System.Text.Encoding.UTF8;

        var fromAddress = new MailAddress(fromEmail, "Aims");
        var smtp = new SmtpClient
        {
            Host = host,
            Port = port,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            TargetName = target,
            Credentials = new NetworkCredential(fromAddress.Address, password, "csn.edu.pk")
        };
        try
        {
            smtp.Send(message);
            isSent = true;
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                isSent = false;
            }
        }
        return isSent;
    }

    public void SendEmailDiscretionaryAdmission(int emailCatID, string subject, string msgbody, string displayName, int center, int region)
    {

        MailMessage message = new MailMessage();
        BLLSendEmail objBll = new BLLSendEmail();
        objBll.EmailCategory_Id = emailCatID;
        string msg = string.Empty;

        var fromAddress = new MailAddress(fromEmail, "Aims");
        message.From = fromAddress;

        DataTable dt = new DataTable();
        dt = objDal.Discretionary_Admission_Email(region, center);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                switch (Convert.ToInt32(dr["EmailAdressType_ID"]))
                {
                    case 1:
                        {
                            if (!string.IsNullOrEmpty(dr["EmailAddress"].ToString()))
                                message.To.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                    case 2:
                        {
                            if (!string.IsNullOrEmpty(dr["EmailAddress"].ToString()))
                                message.CC.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                    case 3:
                        {
                            if (!string.IsNullOrEmpty(dr["EmailAddress"].ToString()))
                                message.Bcc.Add(new MailAddress(dr["EmailAddress"].ToString()));
                            break;
                        }
                }
            }
        }


        message.Subject = subject;
        message.IsBodyHtml = true;
        message.Body = (msgbody);
        message.BodyEncoding = (System.Text.Encoding.UTF8);
        message.SubjectEncoding = System.Text.Encoding.UTF8;

        var smtp = new SmtpClient
        {
            Host = host,
            Port = port,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            TargetName = target,
            Credentials = new NetworkCredential(fromAddress.Address, password, "csn.edu.pk")
        };
        try
        {
            smtp.Send(message);

        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {

            }
        }
    }
}
