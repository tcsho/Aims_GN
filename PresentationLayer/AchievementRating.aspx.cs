using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_AchievementRating : System.Web.UI.Page
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
                BindGrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
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

    



   
    private void BindGrid()
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
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        BLLStudent_Performance_AchvmntRating objClsSec = new BLLStudent_Performance_AchvmntRating();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;

        Result_GradeIdGe = ResultGradeValue;

        ViewState["ResultGrade"] = ResultGradeValue;


        objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
        objClsSec.AchvRating_Id = Convert.ToInt32(Result_GradeIdGe);


        dtsub = (DataTable)objClsSec.Student_Performance_AchvmntRating_SelectAllByAchvRatingId(objClsSec);

        txtCritName.Text = dtsub.Rows[0]["Description"].ToString().Trim();
        txtComments.Text = dtsub.Rows[0]["RateCode"].ToString().Trim();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    
        

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
        BLLStudent_Performance_AchvmntRating objClsSec = new BLLStudent_Performance_AchvmntRating();
        int AlreadyIn = 0;

        ImageButton btn = (ImageButton)(sender);
        string ResultGradeValue = btn.CommandArgument;


        ViewState["ResultGrade"] = ResultGradeValue;

        objClsSec.AchvRating_Id = Convert.ToInt32(ViewState["ResultGrade"]);

        AlreadyIn = objClsSec.Student_Performance_AchvmntRatingDelete(objClsSec);


        ViewState["dtDetails"] = null;

        ImpromptuHelper.ShowPrompt("Delete Record successfully");
        pan_New.Attributes.CssStyle.Add("display", "none");
        BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        ViewState["mode"] = "Add";
        txtCritName.Text = "";
        txtComments.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    
    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {

           
               
                int AlreadyIn = 0;
                DataTable dt = new DataTable();

                BLLStudent_Performance_AchvmntRating objClsSec = new BLLStudent_Performance_AchvmntRating();
                DataTable dtsub = new DataTable();
                objClsSec.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());
                objClsSec.Description = txtCritName.Text.ToString();
                objClsSec.RateCode = txtComments.Text.ToString();
               

                    
                    
                        string mode = Convert.ToString(ViewState["mode"]);

                        if (mode != "Edit")
                        {
                            

                                objClsSec.Status_Id = 1;
                                objClsSec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                                objClsSec.CreatedOn = DateTime.Now;


                                AlreadyIn = objClsSec.Student_Performance_AchvmntRatingAdd(objClsSec);


                                ViewState["dtDetails"] = null;
                                if (AlreadyIn == 0)
                                {
                                    ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                    pan_New.Attributes.CssStyle.Add("display", "none");
                                    BindGrid();

                                }
                            
                           
                        }

                        else
                        {


                           
                                objClsSec.AchvRating_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                                objClsSec.Status_Id = 1;
                                objClsSec.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                                objClsSec.ModifiedOn = DateTime.Now;

                                AlreadyIn = objClsSec.Student_Performance_AchvmntRatingUpdate(objClsSec);


                                ViewState["dtDetails"] = null;
                                if (AlreadyIn == 0)
                                {
                                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                                    pan_New.Attributes.CssStyle.Add("display", "none");
                                    BindGrid();

                                }
                            



                           


                        }



                        


                    
               

            //}
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
        pan_New.Attributes.CssStyle.Add("display", "none");
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
        try
        {


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
    }

    
    
    
}