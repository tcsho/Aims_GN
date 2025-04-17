using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI.HtmlControls;


public partial class PresentationLayer_TCS_EvaluationCriteriaCenter : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string QuestionId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                DataRow row = (DataRow)Session["rightsRow"];
                lblSave.Text = "";
                loadRegions();
                
                

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_region.Enabled = true;
                    ddl_center.Enabled = true;
                    btnLockcenter.Visible = true;
                    btnUnlock.Visible = true;
                    //btnRevert.Enabled = false;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                pan_New.Attributes.CssStyle.Add("display", "none");
                //////////pan_new2.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
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

    private void FillClass()
    {

        try
        {
            BLLClass objBLLClass = new BLLClass();
            
            DataTable dt = null;
            int c_id;
            if (ddl_center.SelectedIndex < 0)
            {

                DataRow row = (DataRow)Session["rightsRow"];
                c_id = Convert.ToInt32(row["Center_Id"].ToString());
            }
            else
            {
                c_id = Convert.ToInt32(ddl_center.SelectedValue);
            }
            objBLLClass.Center_Id = c_id;
            dt = objBLLClass.ClassFetchByCenterID(objBLLClass);
            DataTable dtALevel = new DataTable();
            dtALevel.Columns.Add("Class_Id", typeof(int));
            dtALevel.Columns.Add("Name", typeof(string));
            dtALevel.Columns.Add("OrderOfClass", typeof(int));
            DataRow[] result = dt.Select("class_Id in (19,20,17,18,89,90)");

            // Display.
            foreach (DataRow row in result)
            {
                dtALevel.Rows.Add(row["Class_Id"], row["Name"], row["OrderOfClass"]);
            }
            objBase.FillDropDown(dtALevel, list_Class, "Class_Id", "Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = 1;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    private void FillSubject()
    {
        try
        {

            lblSave.Text = "";


            BLLClass_Subject objBllcs = new BLLClass_Subject();
            DataTable dtCs = new DataTable();
            objBllcs.Class_ID = Convert.ToInt32(list_Class.SelectedValue);
            objBllcs.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);

            int moID = Int32.Parse(Session["moID"].ToString());
            objBllcs.Main_Organisation_Id = moID;

            DataTable dt = (DataTable)objBllcs.Class_SubjectSelectAllByClassId(objBllcs);

            objBase.FillDropDown(dt, list_Subject, "subject_id", "Subject_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }





    protected void list_AdmTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "none");
            //////pan_new2.Attributes.CssStyle.Add("display", "none");
            trSave.Visible = false;


            BindTerm();

            FillSubject();

            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }


    public void btnLockcenter_click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_center.SelectedIndex >= 0)
            {
                BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                objClsSec.Lock = true;
                objClsSec.Evaluation_Criteria_CenterLockUnlock(objClsSec);
                ImpromptuHelper.ShowPrompt(ddl_center.SelectedItem.Text+ "is now Locked!");
                if (list_Class.SelectedIndex > 0 && list_Subject.SelectedIndex > 0 && list_Term.SelectedIndex > 0)
                {
                    ViewState["dtDetails"] = null;
                    BindGrid();
                }
                else
                {
                    gvQuestions.DataSource = null;
                    gvQuestions.DataBind();
                }
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Center");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void btnUnLockcenter_click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_center.SelectedIndex >= 0)
            {
                BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                objClsSec.Lock = false;
                objClsSec.Evaluation_Criteria_CenterLockUnlock(objClsSec);
                ImpromptuHelper.ShowPrompt(ddl_center.SelectedItem.Text + "is now Unlocked!");
                if (list_Class.SelectedIndex > 0 && list_Subject.SelectedIndex > 0 && list_Term.SelectedIndex>0)
                {
                    ViewState["dtDetails"] = null;
                    BindGrid();
                }
                else
                {
                    gvQuestions.DataSource = null;
                    gvQuestions.DataBind();
                }
            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Center");
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
            BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();

            DataTable dtsub = new DataTable();

            objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            objClsSec.Class_Id = Convert.ToInt32(list_Class.SelectedValue.ToString());
            objClsSec.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
            objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());


            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Evaluation_Criteria_CenterSelectByClassSubjectCenterId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                gvQuestions.DataSource = dtsub;
            }
            gvQuestions.DataBind();
            ViewState["tMood"] = "check";
            trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }  
    private void BindGridDelete()
    {
        try
        {
            BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();

            DataTable dtsub = new DataTable();

            objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            objClsSec.Class_Id = Convert.ToInt32(list_Class.SelectedValue.ToString());
            objClsSec.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
            objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
             dtsub = (DataTable)objClsSec.Evaluation_Criteria_CenterSelectByClassSubjectCenterId_Delete(objClsSec);
            if (dtsub.Rows.Count > 0)
            {
                gvNewGrid.DataSource = dtsub;
                gvNewGrid.DataBind();

            }
            gvQuestions.DataSource = null;
            gvNewGrid.DataBind();
    
            trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    //protected void gvNewGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        DataRow rows = (DataRow)Session["rightsRow"];
    //        LinkButton btnRevert = e.Row.FindControl("btnrevert") as LinkButton;
    //        HtmlGenericControl spanIcon = e.Row.FindControl("spanIcon") as HtmlGenericControl;

    //        if (btnRevert != null)
    //        {
    //            DataRowView rowView = e.Row.DataItem as DataRowView;
    //            DataRow row = rowView.Row;

    //            //if (Convert.ToInt32(rows["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(rows["UserLevel_ID"].ToString()) == 2)
    //            //{
    //                btnRevert.Enabled = false;
    //                //spanIcon.Attributes.Add("class", "disabled-glyphicon glyphicon glyphicon-repeat");
    //            //}
    //        }
    //    }
    //}

    protected void gvNewGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow rows = (DataRow)Session["rightsRow"];
            LinkButton btnRevert = e.Row.FindControl("btnrevert") as LinkButton;

            if (btnRevert != null)
            {
                DataRowView rowView = e.Row.DataItem as DataRowView;
                DataRow row = rowView.Row;

                // Check your condition (e.g., user level) to determine if the button should be disabled
                if (Convert.ToInt32(rows["User_Type_Id"].ToString()) == 5 || Convert.ToInt32(rows["User_Type_Id"].ToString()) == 16)
                {
                    btnRevert.Enabled = true;
                    btnRevert.CssClass += "Enable";
                    btnRevert.OnClientClick = "";
                }
                else
                {

                    btnRevert.Enabled = false;
                    btnRevert.CssClass += " disabled";
                    btnRevert.OnClientClick = "return false;";
                }
                
            }

            
        }
    }




    protected void btnEdit_Click(object sender, EventArgs e)
    {

        try
        {
            pan_New.Attributes.CssStyle.Add("display", "inline");

            BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();

            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string QuestionIdValue = btn.CommandArgument;

            QuestionId = QuestionIdValue;

            ViewState["QuestionId"] = QuestionIdValue;


            objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            objClsSec.Class_Id = Convert.ToInt32(list_Class.SelectedValue.ToString());
            objClsSec.Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
            objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            objClsSec.ECC_Id = Convert.ToInt32(QuestionId);


            dtsub = (DataTable)objClsSec.Evaluation_Criteria_CenterSelectByClassSubjectCenterIdECC_Id(objClsSec);

            txtCriteria.Text = dtsub.Rows[0]["Criteria"].ToString().Trim();
            txtTotalMarks.Text = dtsub.Rows[0]["Total_Marks"].ToString().Trim();
            txtWeitage.Text = dtsub.Rows[0]["Weightage"].ToString().Trim();

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
            BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();
            int AlreadyIn = 0;

            LinkButton btn = (LinkButton)(sender);
            string QuestionIdValue = btn.CommandArgument;


            ViewState["QuestionId"] = QuestionIdValue;

            objClsSec.ECC_Id = Convert.ToInt32(QuestionIdValue);

            AlreadyIn = objClsSec.Evaluation_Criteria_CenterDelete(objClsSec);


            ViewState["dtDetails"] = null;

            ImpromptuHelper.ShowPrompt("Delete Record successfully");
            pan_New.Attributes.CssStyle.Add("display", "none");
            //////pan_new2.Attributes.CssStyle.Add("display", "none");
            BindGrid();
            BindGridDelete();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void btnRevert_Click(object sender, EventArgs e)
    {

        try
        {
            BLLEvaluation_Criteria_Center objClsSec = new BLLEvaluation_Criteria_Center();
            int AlreadyIn = 0;

            LinkButton btn = (LinkButton)(sender);
            string QuestionIdValue = btn.CommandArgument;


            ViewState["QuestionId"] = QuestionIdValue;

            objClsSec.ECC_Id = Convert.ToInt32(QuestionIdValue);

            AlreadyIn = objClsSec.Evaluation_Criteria_CenterRevert(objClsSec);

            ImpromptuHelper.ShowPrompt("Revert Record successfully");
            pan_New.Attributes.CssStyle.Add("display", "none");
            BindGrid();
            BindGridDelete();

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


            int QuestionAlreadyIn = 0;
            DataTable dt = new DataTable();
            BLLEvaluation_Criteria_Center objactivity = new BLLEvaluation_Criteria_Center();
            DataTable dtsub = new DataTable();

            if (txtTotalMarks.Text != "")
            {

                objactivity.ECC_Id = Convert.ToInt32(ViewState["QuestionId"]);

                objactivity.Total_Marks = Convert.ToDecimal(txtTotalMarks.Text);
                objactivity.Weightage = Convert.ToDecimal(txtWeitage.Text);
                objactivity.Criteria = txtCriteria.Text;
              objactivity.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue);
                ////////////////objactivity.Status_Id = 1;
                if (!String.IsNullOrEmpty(Session["cId"].ToString()))
                    objactivity.Center_Id = Convert.ToInt32(Session["cId"].ToString());
                else
                    objactivity.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                string mode = Convert.ToString(ViewState["mode"]);


                if (mode == "Edit")
                {




                    QuestionAlreadyIn = objactivity.Evaluation_Criteria_CenterUpdate(objactivity);
                    if (QuestionAlreadyIn == 1)
                    {
                        ImpromptuHelper.ShowPrompt("Total weightage can not exceed from 100%.");
                    }
                    else
                    {

                        ViewState["dtDetails"] = null;
                        if (QuestionAlreadyIn == 0)
                        {
                            ImpromptuHelper.ShowPrompt("Record updated successfully.");
                            pan_New.Attributes.CssStyle.Add("display", "none");
                            BindGrid();
                            BindGridDelete();
                        }
                    }


                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Can't Save balnk Values!");
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
            pan_New.Attributes.CssStyle.Add("display", "none");
            gvQuestions.SelectedRowStyle.Reset();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }




    protected void list_subject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            BindGridDelete();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void list_EvlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void list_AdmTestDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            BindGrid();
            BindGridDelete();
            pan_New.Attributes.CssStyle.Add("display", "none");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void gvQuestions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Subject.SelectedValue != "0")
            {
                BindGrid();
                BindGridDelete();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                gvQuestions.DataSource = null;
                gvQuestions.DataBind();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvNewGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Subject.SelectedValue != "0")
            {
                BindGridDelete();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                gvNewGrid.DataSource = null;
                gvNewGrid.DataBind();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void listAnswOption_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindTerm()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            ObjECT.Class_Id = Convert.ToInt32(list_Class.SelectedValue);
            dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);



            //DataTable dtALevelTerm = new DataTable();
            //dtALevelTerm.Columns.Add("Evaluation_Criteria_Type_Id", typeof(int));
            //dtALevelTerm.Columns.Add("Type", typeof(string));

            //DataRow[] result = dt.Select("Type='First Term'");

            //// Display.
            //foreach (DataRow row in result)
            //{
            //    dtALevelTerm.Rows.Add(row["Evaluation_Criteria_Type_Id"], row["Type"]);
            //}


            //            objBase.FillDropDown(dtALevelTerm, list_Term, "Evaluation_Criteria_Type_Id", "Type");

            objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");
            


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillClass();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

}