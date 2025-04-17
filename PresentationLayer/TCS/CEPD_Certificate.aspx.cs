using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class CEPD_Certificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the query string parameter
        string teacherNames = Request.QueryString["TeacherNames"];

        if (!string.IsNullOrEmpty(teacherNames))
        {
            // Split the names by comma
            string[] names = teacherNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Loop through each name and create a certificate
            foreach (string name in names)
            {
                // Trim any extra spaces
                string trimmedName = name.Trim();

                // Create a new div element for the certificate
                HtmlGenericControl certificateDiv = new HtmlGenericControl("div");
                certificateDiv.Attributes["class"] = "certificate";

                // Create the certificate content using StringBuilder
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class='certificate-images'>");
                sb.Append("<img alt='Certificate Left Image' src='/images/CertificatePic_1.png' />");
                sb.Append("<img alt='Certificate Right Image' src='/images/CertificatePic_2.png' />");
                sb.Append("</div>");
                sb.Append("<div class='certificate-content'>");
                sb.Append("<h1>CERTIFICATE OF ATTENDANCE</h1>");
                sb.Append("<p>In recognition of</p>");
                sb.AppendFormat("<p class='name'>{0}</p>", trimmedName);
                sb.Append("<p>for successfully completing the</p>");
                sb.Append("<p>Self-paced Online Training Session on</p>");
                sb.Append("<h4>QUESTIONING TECHNIQUES</h4>");
                sb.Append("<div class='footer'>");
                sb.Append("<div><div>Head of CEPD</div><br /><div class='line'></div></div>");
                sb.Append("<div><div>Date</div><br /><div class='line'></div></div>");
                sb.Append("</div>");
                sb.Append("</div>");

                // Set the certificate content
                certificateDiv.InnerHtml = sb.ToString();

                // Add the new certificate div to the certificate container
                certificateContainer.Controls.Add(certificateDiv);
            }
        }
    }
}
