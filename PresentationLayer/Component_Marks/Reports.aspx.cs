using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_Component_Marks_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        var Center_id = "";
        var Code = "";
        if (Session["cId"] == null || Session["EmployeeCode"] == null)
        {
            
            Response.Redirect("~/login.aspx", false);
        }
        else
        {
            Center_id = Session["cId"].ToString();
            Code = Session["EmployeeCode"].ToString();
            Response.Redirect("~/PresentationLayer/Component_Marks/Reports.html?Center_ID=" + Center_id, false);
        }
    }
}