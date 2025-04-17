using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_LMSWorkSiteToolAssignment : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
   

    string Result_GradeIdGe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillClassSection();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx",false);
                }

                //====== End Page Access settings ======================
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }

    private void FillClassSection()
    {

        lblSave.Text = "";
        
        try
        {

            BLLTCS_StdAttn obj = new BLLTCS_StdAttn();

            obj.Center_Id = Convert.ToInt32(Session["cId"]);
            DataTable dt = (DataTable)obj.TssSelectClassSectionByCenter(obj);
            objBase.FillDropDown(dt, List_ClassSection, "Section_id", "Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }







    }

    private void FillWorkSite()
    {

        lblSave.Text = "";
        
        try
        {

            BLLSection_Subject obj = new BLLSection_Subject();

            obj.Section_Id = Int32.Parse(List_ClassSection.SelectedValue);
            DataTable dt = (DataTable)obj.Section_SubjectSelectWorkSiteALLBySection_Id(obj);
            objBase.FillDropDown(dt, list_WorkSite, "Section_Subject_Id", "Title");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        FillWorkSite();

        if (List_ClassSection.SelectedItem.Text == "Select")
        {

            list_WorkSite.SelectedIndex = 0;

            gvDetail.DataSource = null;
            gvDetail.DataBind();

            



        }
        else
        {
            

        }


        


        gvAssign.DataSource = null;
        gvAssign.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    private void BindGridMain()
    {
        try
        {
        BLLLmsProjectTool objClsSec = new BLLLmsProjectTool();

        DataTable dtsub = new DataTable();

        

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.LmsProjectToolFetch(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvDetail.DataSource = dtsub;
        }
        gvDetail.DataBind();
        ViewState["tMood"] = "check";
        trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void BindGrid()
    {
        try
        {
        BLLSection_Subject_Tool objClsSec = new BLLSection_Subject_Tool();

        DataTable dtsub = new DataTable();

        
        objClsSec.Section_Subject_Id = Convert.ToInt32(list_WorkSite.SelectedValue.ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Section_Subject_ToolSelectWorkSiteBySectionSubjectId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvAssign.DataSource = dtsub;
        }
        gvAssign.DataBind();
        ViewState["tMood"] = "check";
        trSave.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

    }

    
   

    protected void gvSubjects_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    
    




    protected void btnEdit_Click(object sender, EventArgs e)
    {

        

    }


   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       
    }


    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            int chktvalue = 0;
            BLLSection_Subject_Tool objClsSec = new BLLSection_Subject_Tool();

            if (List_ClassSection.SelectedIndex > 0 && list_WorkSite.SelectedIndex > 0)
            {

                CheckBox cb = null;
                foreach (GridViewRow gvr in gvDetail.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("chkRating");

                    if (cb.Checked)
                    {
                        

                        chktvalue = 88;

                        objClsSec.Section_Subject_Id = Convert.ToInt32(list_WorkSite.SelectedValue.ToString());
                        objClsSec.ProjectTool_ID = Convert.ToInt32(gvr.Cells[0].Text.ToString());
                        objClsSec.Status_Id = 1;
                        objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                        objClsSec.CreatedOn = DateTime.Now;



                       


                        AlreadyIn = objClsSec.Section_Subject_ToolAdd(objClsSec);

                    }
                    else
                    {
                        

                        if (chktvalue != 88)
                        {

                            chktvalue = 77;
                            
                        }


                    }
                }

                
                int ActChkTvalue = chktvalue;
                if (ActChkTvalue != 77)
                {


                    
                    if (AlreadyIn == 0)
                    {
                        ViewState["dtDetails"] = null;
                        ImpromptuHelper.ShowPrompt("Record Successfully Add.");

                        BindGridMain();
                        BindGrid();

                    }
                    else
                    {
                        ImpromptuHelper.ShowPrompt("Record Alraedy Exist.");
                    }
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please Select Desired Project Tool!");
                } 
            }

            else
            {
                ImpromptuHelper.ShowPrompt("Please select desired Class Section and WorkSite!");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


   

    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
        
        gvDetail.SelectedRowStyle.Reset();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "toggleCheck")
            {
              

                foreach (GridViewRow row in gvDetail.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chkRating");
                    if (cb != null && cb.Checked == false)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void gvDetail_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gvDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (List_ClassSection.SelectedValue != "0")
        {
            BindGrid();
           
        }
        else
        {
            gvDetail.DataSource = null;
            gvDetail.DataBind();
            
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        
    }


    protected void list_WorkSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BindGridMain();
        BindGrid();


        if (list_WorkSite.SelectedItem.Text == "Select")
        {

            list_WorkSite.SelectedIndex = 0;

            gvDetail.DataSource = null;
            gvDetail.DataBind();

            gvAssign.DataSource = null;
            gvAssign.DataBind();



        }
        else
        {
            

        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void gvDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGridMain();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}