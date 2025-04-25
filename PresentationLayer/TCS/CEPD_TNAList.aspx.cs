using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Configuration;

public partial class PresentationLayer_CEPD_TNAList : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_Category obje = new BLLCEPD_Category();
    BLLCEPD_TrainerProfile objec = new BLLCEPD_TrainerProfile();
    _DAL_CEPD_TNA objTNA = new _DAL_CEPD_TNA();
    int UL_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }

        UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());
       
        if (!IsPostBack)
        {
            Loadregion();
            DataRow row = (DataRow)Session["rightsRow"];
            int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
            if (UserLevel_ID == 1 || UserLevel_ID == 2) //Head Office
            { list_region_SelectedIndexChanged(sender, e); }
            else if (UserLevel_ID == 3) //Regional Officer
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);
            }
            else if (UserLevel_ID == 4) //Campus Officer
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);

                list_center.SelectedValue = row["Center_Id"].ToString();
                list_center.Enabled = false;
            }
            else if (UserLevel_ID == 10) //Network
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);
            }
            else if (UserLevel_ID == 5) //Teacher
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);

                list_center.SelectedValue = row["Center_Id"].ToString();
                list_center.Enabled = false;

            }

            if (list_center.Enabled == false)
            {
                lab_center.Text = list_center.SelectedItem.Text;
                list_center.Visible = false;
            }
            if (list_region.Enabled == false)
            {
                lab_region.Text = list_region.SelectedItem.Text;
                list_region.Visible = false;
            }
            BindGrid();
        }

    }
   
    protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_region.SelectedValue == "")
            {
                list_center.Items.Clear();
                list_center.Items.Insert(0, new ListItem("Select", ""));
            }
            if (UL_ID == 10)
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, list_center, "Center_Id", "Center_Name");
            }
            else
            {

                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Int32.Parse(list_region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindGrid()
    {
        BLLCEPD_TNA obj_TNA = new BLLCEPD_TNA();
        obj_TNA.Region_ID = Int32.Parse(list_region.SelectedValue.ToString());
        obj_TNA.Center_ID = Int32.Parse(list_center.SelectedValue.ToString());
        obj_TNA.Status = ddlStatus.SelectedValue.ToString();

        gvTNAList.DataSource = null;
        gvTNAList.DataBind();

        DataTable dt = objTNA.GetTNAList(obj_TNA);
        gvTNAList.DataSource = dt;
        gvTNAList.DataBind();

    }
    public void Loadregion()
    {
        BLLRegion oDALRegion = new BLLRegion();

        oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
        DataTable dt = oDALRegion.RegionFetch(oDALRegion);

        objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");
    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEdit = (ImageButton)sender;

        string Id = btnEdit.CommandArgument;
        Response.Redirect("~/PresentationLayer/TCS/CEPD_TNA.aspx?TNAID=" + Id, false);
    }
    protected void btnSaveReason_Click(object sender, EventArgs e)
    {
       
        Button btnSave = (Button)sender;

       
        GridViewRow row = (GridViewRow)btnSave.NamingContainer;

       
        TextBox txtReason = (TextBox)row.FindControl("txtReason");

        
        string reasonText = txtReason.Text;

       
        string id = btnSave.CommandArgument;
        int ids = Convert.ToInt32(id);
        
        SaveReason(ids, reasonText);
    }

    private void SaveReason(int id, string reasonText)
    {
        BLLCEPD_TNA obj_TNA = new BLLCEPD_TNA();

        obj_TNA.Reason = reasonText;
        obj_TNA.TNA_ID = id;

      string msg = objTNA.UpdateTNAReason(obj_TNA);
    }

    //protected void btnReject_Click(object sender, ImageClickEventArgs e)
    //{
    //    GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
    //    TextBox txtReason = (TextBox)row.FindControl("txtReason");
    //    txtReason.Visible = true;
    //}


    protected void btnReject_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
        
        divMessage.Visible = false;
        ImageButton btnAppromed = (ImageButton)sender;
        string message = "";
        string[] args = btnAppromed.CommandArgument.Split(',');

        string Id = args[0]; ;
        string CENTERId = args[1];
        BLLCEPD_TNA obj_TNA = new BLLCEPD_TNA();

        obj_TNA.TNA_ID = Convert.ToInt32(Id);
        obj_TNA.UserID = Convert.ToInt32(Session["ContactID"]);
        obj_TNA.Status = "Rejected";


        message = objTNA.UpdateTNAStatus(obj_TNA);
        SendEmailForRejetion(CENTERId);
        divMessage.Visible = true;
        spanMessage.InnerText = message;
        BindGrid();

    }
    protected void btnApproved_Click(object sender, ImageClickEventArgs e)
    {
        divMessage.Visible = false;
        ImageButton btnAppromed = (ImageButton)sender;
        string message = "";
        string[] args = btnAppromed.CommandArgument.Split(',');

        string Id = args[0]; ;
        string CENTERId = args[1];
        BLLCEPD_TNA obj_TNA = new BLLCEPD_TNA();

        obj_TNA.TNA_ID = Convert.ToInt32(Id);
        obj_TNA.UserID = Convert.ToInt32(Session["ContactID"]);
        obj_TNA.Status = "Approved";
        

       message = objTNA.UpdateTNAStatus(obj_TNA);
        SendEmailForApproved(CENTERId);
        divMessage.Visible = true;
        spanMessage.InnerText = message;
        BindGrid();
       
    }




    public void SendEmailForApproved(string CENTERId)
    {
        MailMessage mail = new MailMessage();
        var Body = "";
        var To = "";
        var CC1 = "omer.mubbasher@csn.edu.pk";
        var CC2 = "jawed.mughal@csn.edu.pk";
        var Email = new MailAddress("maria.zahid@csn.edu.pk", "The City School");

        To = "maria.zahid@csn.edu.pk";
        var Subject = "Approval of Training Session Request";

        var Password = "Master@123";

        Body += "<div style='font-family: Arial, sans-serif; font-size: 14px; line-height: 24px;'>";
        Body += "<p style='margin: 0 0 12px 0;'>Dear Head of the School/Recipient,</p>";
        Body += "<p style='margin: 0 0 12px 0;'>We are pleased to inform you that your request for the training session has been approved. The Regional Training Lead/CEPD-HO will be in touch with you shortly to discuss the next steps.</p>";
        Body += "<p style='margin: 0 0 12px 0;'>Thank you for your attention to this matter.</p>";
        Body += "<p style='margin: 0 0 12px 0;'>Best regards,</p>";
        Body += "<p style='margin: 0 0 12px 0;'>Training Department</p>";
        Body += "</div>";

        using (MailMessage mm = new MailMessage(Email.Address, To))
        {
            mm.Subject = Subject;
            mm.From = new MailAddress("noreply@csn.edu.pk", "The City School");
            mm.Body = Body;
            mm.IsBodyHtml = true;
            mm.CC.Add(CC1);
            mm.CC.Add(CC2);

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "10.1.1.120";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Timeout = 1000000000;

                try
                {
                    smtp.Send(mm);
                }
                catch (SmtpFailedRecipientException ex)
                {
                    // Handle the exception
                }
            }
        }
    }


    public void SendEmailForRejetion(string CENTERId)
    {
        MailMessage mail = new MailMessage();
        var Body = "";
        var To = "";
        var CC1 = "omer.mubbasher@csn.edu.pk";
        var CC2 = "jawed.mughal@csn.edu.pk";
        var Email = new MailAddress("maria.zahid@csn.edu.pk", "The City School");

        To = "maria.zahid@csn.edu.pk";
        var Subject = "Rejection of Training Session Request";

        var Password = "Master@123";

        Body += "<div style='font-family: Arial, sans-serif; font-size: 14px; line-height: 24px;'>";
        Body += "<p style='margin: 0 0 12px 0;'>Dear Head of the School/Recipient,</p>";
        Body += "<p style='margin: 0 0 12px 0;'>We regret to inform you that your request for the training session has been rejected. The Regional Training Lead/CEPD-HO will coordinate with you in due course of time.We value your interest in Professional Development and encourage you to initiate training request at a later time.</ p>";
        Body += "<p style='margin: 0 0 12px 0;'>Thank you for your attention to this matter.</p>";
        Body += "<p style='margin: 0 0 12px 0;'>Best regards,</p>";
        Body += "<p style='margin: 0 0 12px 0;'>Training Department</p>";
        Body += "</div>";

        using (MailMessage mm = new MailMessage(Email.Address, To))
        {
            mm.Subject = Subject;
            mm.From = new MailAddress("noreply@csn.edu.pk", "The City School");
            mm.Body = Body;
            mm.IsBodyHtml = true;
            mm.CC.Add(CC1);
            mm.CC.Add(CC2);
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "10.1.1.120";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Timeout = 1000000000;

                try
                {
                    smtp.Send(mm);
                }
                catch (SmtpFailedRecipientException ex)
                {
                    // Handle the exception
                }
            }
        }
    }

    protected void gvTNAList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRow row = (DataRow)Session["rightsRow"];
        int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
        if (UserLevel_ID == 4) 
        {
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            if(ddlStatus.SelectedValue == "Approved")
            {
                e.Row.Cells[12].Visible = false;
            }
        }
        else
        {
            e.Row.Cells[14].Visible = true;
            e.Row.Cells[15].Visible = true;
            e.Row.Cells[16].Visible = true;
        }
    }
    //protected void OnCertificate_Click(object sender, ImageClickEventArgs e)
    //{
    //    // Get the TNA_ID and Center_ID from the CommandArgument
    //    ImageButton btn = (ImageButton)sender;
    //    string[] args = btn.CommandArgument.Split(',');



    //    //string url = string.Format("CertificatePage.aspx?TNA_ID={0}&Center_ID={1}", tnaId, centerId);
    //    string url = string.Format("CEPD_Certificate.aspx");

    //    Response.Redirect(url);
    //}
    protected void OnCertificate_Click(object sender, ImageClickEventArgs e)
    {
        // Get the TeacherName from the CommandArgument
        ImageButton btn = (ImageButton)sender;
        string teacherNames = btn.CommandArgument;

        // Extract only the names, removing the numbers
        string[] teacherEntries = teacherNames.Split(',');
        List<string> namesList = new List<string>();
        foreach (string entry in teacherEntries)
        {
            // Find the index of the first non-numeric character after the space following the number
            int index = entry.IndexOf('-');
            if (index >= 0 && index + 2 < entry.Length)
            {
                namesList.Add(entry.Substring(index + 2).Trim());
            }
        }

        // Join the names into a single string separated by commas
        string namesOnly = string.Join(", ", namesList);

        // URL encode the names to ensure they are safe for use in a URL
        string encodedNames = Server.UrlEncode(namesOnly);

        // Construct the URL with the encoded names
        string url = string.Format("CEPD_Certificate.aspx?TeacherNames={0}", encodedNames);

        // Use JavaScript to open the URL in a new window
        string script = "window.open('" + url + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OpenWindow", script, true);
    }



}