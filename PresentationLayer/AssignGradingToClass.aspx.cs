using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_AssignGradingToClass : System.Web.UI.Page
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
        try
        {
        lblSave.Text = "";
        BLLResult_Grade obj = new BLLResult_Grade();

        
        int moID = Int32.Parse(Session["moID"].ToString());
        obj.Main_Organisation_Id = moID;

        DataTable dt = (DataTable)obj.Class_SelectByOrgId(obj);

        objBase.FillDropDown(dt, List_ClassSection, "Class_Id", "Class_Name");
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
        BindGridMain();
        BindGrid();
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
        BLLStudent_Performance_AchvmntRating objClsSec = new BLLStudent_Performance_AchvmntRating();

        DataTable dtsub = new DataTable();

        objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Student_Performance_AchvmntRating_SelectAllByOrgId(objClsSec);
        }
        else
        {
            dtsub = (DataTable)ViewState["dtDetails"];
        }

        if (dtsub.Rows.Count > 0)
        {
            gvSubjects.DataSource = dtsub;
        }
        gvSubjects.DataBind();
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
        BLLStudent_Performance_ClassAchvRating objClsSec = new BLLStudent_Performance_ClassAchvRating();

        DataTable dtsub = new DataTable();

        objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());

        if (ViewState["dtDetails"] == null)
        {
            dtsub = (DataTable)objClsSec.Student_Performance_ClassAchvRatingSelectAllByOrgId(objClsSec);
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
            BLLStudent_Performance_ClassAchvRating objClsSec = new BLLStudent_Performance_ClassAchvRating();

             CheckBox cb = null;
             foreach (GridViewRow gvr in gvSubjects.Rows)
             {
                 cb = (CheckBox)gvr.FindControl("chkRating");

                  if (cb.Checked)
                  {
                      objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                      objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                     
                      objClsSec.AchvRating_Id = Convert.ToInt32(gvr.Cells[0].Text.ToString());


                      AlreadyIn = objClsSec.Student_Performance_ClassAchvRatingAdd(objClsSec);

                  }
             }


             ViewState["dtDetails"] = null;
             if (AlreadyIn == 0)
             {
                 ImpromptuHelper.ShowPrompt("Record Successfully Add.");
                 
                 BindGridMain();
                 BindGrid();

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
        gvSubjects.SelectedRowStyle.Reset();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    
    protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
    protected void gvSubjects_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gvSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (List_ClassSection.SelectedValue != "0")
        {
            BindGrid();
           
        }
        else
        {
            gvSubjects.DataSource = null;
            gvSubjects.DataBind();
            
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void DeleteClassRating(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Performance_ClassAchvRating objClsSec = new BLLStudent_Performance_ClassAchvRating();

            objClsSec.KindClassAchvRating_Id = Convert.ToInt32(((Button)sender).CommandArgument);
            int AlreadyIn = objClsSec.Student_Performance_ClassAchvRatingDelete(objClsSec);

            if (AlreadyIn==0)
            {
                ImpromptuHelper.ShowPrompt("Key Deleted!");
            }
                    BindGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}