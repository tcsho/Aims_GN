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
using System.Globalization;
using System.IO;


public partial class PresentationLayer_TCS_ReportUserControl : System.Web.UI.UserControl
{

    int regID = 0;
    int regPreEduID = 0;
    DALBase objBase = new DALBase();
    BLLTssGResources objBllRes = new BLLTssGResources();

    protected void Page_Load(object sender, EventArgs e)
    {
        
            
    }

    public void SetData(DataTable dt)
    {
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                grdControl.DataSource = dt;
                grdControl.DataBind();
            }
        }
        else
        {
            grdControl.DataSource = null;
            grdControl.DataBind();
        }
        //if (grdControl.Rows.Count > 0)
        //    grdControl.Columns[1].Visible = false;
        
    }

    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {

       

        //try
        //{
        //    ImageButton btn = (ImageButton)sender;
        //    if (btn.CommandArgument != "")
        //    {
        //        ViewState["StkTake"] = null;
        //        stkTakeID = Convert.ToInt32(btn.CommandArgument);
        //        objBll.StkTake_ID = stkTakeID;
        //        stkTakeID = objBll.LibStkTakeDelete(objBll);
        //        if (stkTakeID == 0)
        //        {
        //            ImpromptuHelper.ShowPrompt("Can not delete. One or more sections exist for this Stocktake!");
        //        }
        //        else
        //        {
        //            ImpromptuHelper.ShowPrompt("Record has been deleted successfully.");
        //            ViewState["StkTake"] = null;
        //            BindGrid();
        //        }
        //    }
        //    gvStkTake.SelectedRowStyle.Reset();

        //    //stkDetailPanel.Attributes.CssStyle.Add("display", "none");

        //}

        //catch (Exception ex)
        //{
        //    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        //    Response.Redirect("~/ErrorPages/Default.aspx", false);
        //}
    }


    protected void grdControl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //////if (e.Row.RowType == DataControlRowType.DataRow)
        //////{
        //////    ////////// CREATE A LinkButton AND IT TO EACH ROW.
        //////    LinkButton lb = new LinkButton();
        //////    lb.ID = "lnkDelete";
        //////    lb.Text = "Delete";
        //////    lb.Command += new CommandEventHandler(this.btn_Click);
        //////    //////lb.CommandName = "Click";
        //////    //////lb.Command += new CommandEventHandler(OnClick);
        //////    //lb.Click += new EventHandler(this.btn_Click);



        //////    e.Row.Cells[2].Controls.Add(lb);


        //////}
    }
    protected void grdControl_RowCreated(object sender, GridViewRowEventArgs e)
    {
       e.Row.Cells[0].Visible = false;

        e.Row.Cells[1].Visible = false;

        //////////////if (e.Row.RowType == DataControlRowType.DataRow)
        //////////////{
        //////////////    ////////// CREATE A LinkButton AND IT TO EACH ROW.
        //////////////    LinkButton lb = new LinkButton();
        //////////////    lb.ID = "lnkDelete";
        //////////////    lb.Text = "Delete";
        //////////////    lb.Command += new CommandEventHandler(this.OnClick);
        //////////////    //////lb.CommandName = "Click";
        //////////////    //////lb.Command += new CommandEventHandler(OnClick);
        //////////////    //lb.Click += new EventHandler(this.btn_Click);



        //////////////    e.Row.Cells[2].Controls.Add(lb);


        //////////////}
    }

    //protected void lnkDeleteCenter_Click(object sender, ImageClickEventArgs e)
    //{
    //}

    protected void btn_Click(object sender, EventArgs e)
    {
        //here type cast the sender as LinkButton type and know which is the button that clicked.
        LinkButton bttn = sender as LinkButton;
        string buttonClicked = bttn.CommandName;
        Response.Write(buttonClicked + " is Clicked");
    }

    protected void OnClick(object sender, CommandEventArgs e)
    {
    }


}