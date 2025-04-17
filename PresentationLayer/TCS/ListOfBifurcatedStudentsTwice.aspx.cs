using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_ListOfBifurcatedStudentsTwice : System.Web.UI.Page
{
    _DALListOfBifurcatedStudentsTwice obj = new _DALListOfBifurcatedStudentsTwice();
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 0;
  
   private void BindGrid(int _Region_Id,int _Center_Id)
    {
        try
        {
            DataTable dtsub = new DataTable();

            if (ViewState["dtDetails"] == null)
            {

                //Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
                //Center_Id = Convert.ToInt32(ddl_center.SelectedValue);

                dtsub = obj.ListSelect(_Region_Id, _Center_Id);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                tdSearch.Visible = true;
                gv_details.DataSource = dtsub;
                gv_details.DataBind();
                ViewState["dtDetails"] = dtsub;
                btns.Visible = true;
                lblGridStatus.Text = "";
            }
            else
            {
                tdSearch.Visible = false;
                gv_details.DataSource = null;
                gv_details.DataBind();
                btns.Visible = false;
                lblGridStatus.Text = "No Record Found!";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];

        if (!IsPostBack)
        {
            try
            {
                //ViewState["MainOrgId"] = 0;
                //ViewState["RegionId"] = 0;
                //ViewState["CenterId"] = 0;
                /////////Setting ///////////////
                if (row["User_Type"].ToString() != "SAdmin")
                {

                }


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = 0;
                    Center_Id = 0;
                    
                    

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = 0;
                   
                    trButtons.Visible = false;
                    
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = row["Center_Id"].ToString();
                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                  
                    trButtons.Visible = false;


                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                }
                BindGrid(Region_Id, Center_Id);

            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{

        //    TextBox txttotaldays;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {



        //        txttotaldays = (TextBox)e.Row.FindControl("txttermdays");
        //        DataRow row = ((DataRowView)e.Row.DataItem).Row;

        //        if (Convert.ToInt32(row["Submit_RD"]) == 1)//Generated
        //        {

        //            txttotaldays.Enabled = false;
        //        }
        //        else if (Convert.ToInt32(row["Submit_RD"]) == 0)//Not Generated
        //        {


        //            txttotaldays.Enabled = true;
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            
            string url = "";
            Button btnEdit = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gv_details.SelectedIndex = gvr.RowIndex;
            ViewReport obj = new ViewReport();

            obj.TermGroup_Id = 1;//Students are detained after final term 
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;


            if (obj.Session_Id == 12)
            {
                url = "";
            }
            else if (!String.IsNullOrEmpty(url))
            {
                url = "../TCS";
            }

            url = url + obj.OpenReport(obj);


            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btndetail_Click(object sender, EventArgs e)
    {
        try
        {
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gv_details.SelectedIndex = gvr.RowIndex;
            

            lblStudentID.Text = btn.CommandArgument;
            lblStudentName.Text = gvr.Cells[1].Text;
            
            lblPreSession.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Session_pre"].ToString();
            lblCurSession.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Session_cur"].ToString();

            lblPreRegion.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Region_Name_pre"].ToString();
            lblCurRegion.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Region_Name_cur"].ToString();

            lblPreCenter.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Center_Name_pre"].ToString();
            lblCurCenter.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Center_Name_cur"].ToString();

            lblPreClass.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Class_Name_pre"].ToString();
            lblCurClass.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Class_Name_cur"].ToString();
            
            lblPreSection.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Section_Name_pre"].ToString();
            lblCurSection.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Section_Name_cur"].ToString();

            lblPreSubmitedBy.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Submit_RD_By_Name_pre"].ToString();
            lblCurSubmitedBy.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Submit_RD_By_Name_cur"].ToString();

            lblPreSubmitedOn.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Submit_RD_On_pre"].ToString();
            lblCurSubmitedOn.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Submit_RD_On_cur"].ToString();

            lblPreRemarks.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Remarks_pre"].ToString();
            lblCurRemarks.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["Remarks_cur"].ToString();

            lblPreApprovedBy.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Approval_By_Name_pre"].ToString();
            lblCurApprovedBy.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Approval_By_Name_cur"].ToString();

            lblPreApprovedOn.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Approval_On_pre"].ToString();
            lblCurApprovedOn.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Approval_On_cur"].ToString();

            lblPreRDRemarks.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Remarks_pre"].ToString();
            lblCurRDRemarks.InnerHtml = gv_details.DataKeys[gvr.RowIndex].Values["RD_Remarks_cur"].ToString();
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}