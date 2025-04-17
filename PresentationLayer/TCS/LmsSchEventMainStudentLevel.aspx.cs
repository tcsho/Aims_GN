using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;





public partial class PresentationLayer_TCS_LmsSchEventMainStudentLevel : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            
        }
    }


    


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        


    }


    protected void DayPilotCalendar1_EventMove(object sender, DayPilot.Web.Ui.Events.EventMoveEventArgs e)
    {

    }
    protected void btnSchForm_Click(object sender, EventArgs e)
    {
        try
        {
        Response.Redirect("~/PresentationLayer/TCS/LmsSchEventView.aspx");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        try
        {
        Response.Redirect("~/PresentationLayer/TCS/LMSStudentWorkspaceDetail.aspx");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
        DayPilotCalendar1.StartDate = DayPilotCalendar1.StartDate.AddDays(-10);
        DayPilotCalendar1.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
        DayPilotCalendar1.StartDate = DayPilotCalendar1.StartDate.AddDays(10);
        DayPilotCalendar1.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


}