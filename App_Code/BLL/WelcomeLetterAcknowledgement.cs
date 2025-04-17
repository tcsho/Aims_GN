using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for WelcomeLetterAcknowledgement
/// </summary>
public class WelcomeLetterAcknowledgement
{
    public int Session_id{get;set;}
    public DropDownList _ddl; 

	public WelcomeLetterAcknowledgement()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ISWelcomeAcknowledge(WelcomeLetterAcknowledgement objBll)
    {
        BLLClass_Section_Welcome ObjCSW = new BLLClass_Section_Welcome();
        ObjCSW.Section_Id = Convert.ToInt32(objBll._ddl.SelectedValue.ToString());
        ObjCSW.Session_Id = Convert.ToInt32(objBll.Session_id);
        DataTable dt = ObjCSW.Class_Section_WelcomeFetchByBySectionSession(ObjCSW);
        if (dt.Rows.Count < 1)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session["error"] = "Marks entry is not available untill Welcome Letters are issued to the whole class.";
                HttpContext.Current.Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }


    }
}