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

public partial class ForceChangePassword : System.Web.UI.Page
{

protected void Page_Load(object sender, EventArgs e)
    {
    try
        {
        if (Session["ContactID"] == null)
            {
            Response.Redirect("~/login.aspx");
            }
        }
    catch (Exception ex)
        {
        Session["error"] = ex.Message;
        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }

protected void btnCancel_Click(object sender, EventArgs e)
    {
    Response.Redirect("~/PresentationLayer/LMS/LmsWrkSite.aspx");
    }


protected void btnSave_Click(object sender, EventArgs e)
    {

    BLLLogin objbll = new BLLLogin();
    objbll.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
    objbll.Password = txtNPassC.Text;
    objbll.LastPasswordChangedOn = DateTime.Now;

    int AlreadyIn = objbll.UpdatePasswordPolicy(objbll);

    if (AlreadyIn == 0)
        {
  //      Display Message to Enforce

        }
    else if (AlreadyIn > 0)
        {
        Response.Redirect("~/PresentationLayer/Default.aspx", false);
        }




    }


protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
    Response.Redirect("~/PresentationLayer/LMS/LmsWrkLstDPD.aspx");
    }
    }
