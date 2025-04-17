using System;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_ChangePassword : System.Web.UI.Page
{
    BLLUser objuser = new BLLUser();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
                    Response.Redirect("~/PresentationLayer/Default.aspx");
     }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        objuser.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
        objuser.OldPassword = CurrentPassword.Text;
        objuser.NewPassword = ConfirmNewPassword.Text;

        int AlreadyIn = 0;

        AlreadyIn = objuser.ChangePassword(objuser);
        if (AlreadyIn==0)
        {
                ImpromptuHelper.ShowPrompt("Password changed successfully.");
    
        }
        else if (AlreadyIn==-1)
        {
                ImpromptuHelper.ShowPrompt("Pelease enter correct old password");
            
        }



    }
}