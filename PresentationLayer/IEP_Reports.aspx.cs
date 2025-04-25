using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_IEP_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string cenid=Session["cId"].ToString();
        //var ssid = Session["Session_Id"];
        TextBox Sessionid = this.FindControl("Sessionid") as TextBox;
        TextBox Cenid = this.FindControl("CenID") as TextBox;
        //Cenid.Text = cenid;
        //Sessionid.Text = Session["Session_Id"].ToString();
      


    }
}