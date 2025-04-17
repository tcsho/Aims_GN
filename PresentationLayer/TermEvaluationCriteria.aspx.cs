using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TermEvaluationCriteria : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string Result_GradeIdGe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //lblSave.Text = "";
                loadRegions();
              
                pan_New.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                btn_apply.Visible = false;

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

    private void FillClassSection()
    {

        try
        {
            //lblSave.Text = "";
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


    private void FillSubjects()
    {

        try
        {

            //lblSave.Text = "";
            BLLEvaluation_Criteria_Percentage obj = new BLLEvaluation_Criteria_Percentage();


            int moID = Int32.Parse(Session["moID"].ToString());
            obj.Main_Organisation_Id = moID;
            obj.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
            obj.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
            DataTable dt = (DataTable)obj.Class_SubjectSelectAllByClassId(obj);
            ViewState["SubjectList"] = dt;

            cblSubjects.DataSource = dt;
            cblSubjects.DataValueField = "subject_id";
            cblSubjects.DataTextField = "Subject_Name";
            cblSubjects.DataBind();
            
            objBase.FillDropDown(dt, list_subject, "subject_id", "Subject_Name");

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
    protected void bindTermList()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            ObjECT.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
            dt = ObjECT.Evaluation_Criteria_TypeSelectByNewClassID(ObjECT);


            cblTerm.DataSource = dt;
            cblTerm.DataValueField = "Evaluation_Criteria_Type_Id";
            cblTerm.DataTextField = "Type";
            cblTerm.DataBind();

            objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
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




            FillSubjects();
            bindTermList();
            BindEvaluationType();
            SetEmptyGrid(gvSubjects);

            BindGrid();
          

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    private void BindEvaluationType()
    {
        try
        {
            if (List_ClassSection.SelectedIndex > 0)
            {
                BLLEvaluation_Type obj = new BLLEvaluation_Type();

                obj.Main_Organisation_Id = Convert.ToInt32(Session["moID"].ToString());

                DataTable dt = obj.Evaluation_TypeSelectByOrgId(obj);

                objBase.FillDropDown(dt, list_EvlType, "Evaluation_Type_Id", "Name");


            }
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
            BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();

            DataTable dtsub = new DataTable();

            objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
            //////////////////////objClsSec.Subject_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
            //objClsSec.Evaluation_Criteria_Type_Id = Convert.ToInt32(list_term.SelectedValue.ToString());

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Evaluation_Criteria_SelectAllByClassSubject(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                gvSubjects.DataSource = dtsub;
                gvSubjects.DataBind();
            }
            else
                SetEmptyGrid(gvSubjects);

            ViewState["tMood"] = "check";
            trSave.Visible = true;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    private void SetEmptyGrid(GridView gv)
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("Evaluation_Criteria_Id");
            dt.Columns.Add("Subject_Name");
            dt.Columns.Add("EvaluationType");
            dt.Columns.Add("Criteria");
            dt.Columns.Add("Total_Marks");
            dt.Columns.Add("Weightage");
            dt.Columns.Add("Type");
            dt.Columns.Add("Subject_Id");
            dt.Columns.Add("Evaluation_Criteria_Type_Id");
            dt.Columns.Add("Evaluation_Type_Id");
            
            dt.Rows.Add(dt.NewRow());
            gv.DataSource = dt;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvSubjects.Rows.Count > 0)
            {
                gvSubjects.UseAccessibleHeader = false;
                gvSubjects.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
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
            if (List_ClassSection.SelectedIndex > 0)
            {


                pan_New.Attributes.CssStyle.Add("display", "inline");
                BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();

                DataTable dtsub = new DataTable();
                ViewState["mode"] = "Edit";
                ImageButton btn = (ImageButton)(sender);
                string ResultGradeValue = btn.CommandArgument;

                Result_GradeIdGe = ResultGradeValue;

                ViewState["ResultGrade"] = ResultGradeValue;

                GridViewRow gvr = (GridViewRow)btn.NamingContainer;



                objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(Result_GradeIdGe);



                //dtsub = (DataTable)objClsSec.Evaluation_Criteria_SelectAllByEvlCriteriaId(objClsSec);

                //txtCritName.Text = dtsub.Rows[0]["Criteria"].ToString().Trim();
                txtCritName.Text = gvr.Cells[5].Text.Trim();
                //txtMarks.Text = dtsub.Rows[0]["Total_Marks"].ToString().Trim();
                txtMarks.Text = gvr.Cells[6].Text.Trim();
                //txtGrade.Text = dtsub.Rows[0]["Weightage"].ToString().Trim();
                txtGrade.Text = gvr.Cells[7].Text.Trim();

                ViewState["currentWeightage"] = txtGrade.Text;

                //list_EvlType.SelectedValue = dtsub.Rows[0]["Evaluation_Type_Id"].ToString().Trim(); 13
                list_subject.SelectedValue = gvr.Cells[9].Text.Trim();
                list_term.SelectedValue = gvr.Cells[10].Text.Trim();
                list_EvlType.SelectedValue = gvr.Cells[11].Text.Trim();

                cblSubjects.Visible = false;
                cblTerm.Visible = false;
                list_term.Visible = true;
                list_subject.Visible = true;

                //list_subject.SelectedValue = dtsub.Rows[0]["Subject_Id"].ToString().Trim(); 8
            }
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
            if (List_ClassSection.SelectedIndex > 0)
            {
                BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();
                int AlreadyIn = 0;

                ImageButton btn = (ImageButton)(sender);
                string ResultGradeValue = btn.CommandArgument;


                ViewState["ResultGrade"] = ResultGradeValue;

                objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(ViewState["ResultGrade"]);

                AlreadyIn = objClsSec.Evaluation_CriteriaDelete(objClsSec);


                ViewState["dtDetails"] = null;

                ImpromptuHelper.ShowPrompt("Delete Record successfully");
                pan_New.Attributes.CssStyle.Add("display", "none");
                BindGrid();

                //lblSave.Visible = true;
                //lblSave.Text = "Delete Record successfully";
            }
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
            if (List_ClassSection.SelectedIndex > 0 )
            {
                pan_New.Attributes.CssStyle.Add("display", "inline");
                ViewState["mode"] = "Add";
                txtGrade.Text = "";
                ViewState["currentWeightage"] = "0";
                list_EvlType.SelectedIndex = 0;
                //lblSave.Text = "";
                txtCritName.Focus();

                list_subject.Visible = false;
                cblSubjects.Visible = true;

                list_term.Visible = false;
                cblTerm.Visible = true;

            }

            else
            {
                ImpromptuHelper.ShowPrompt("Please select a Class !");
                //lblSave.Visible = true;
                //lblSave.Text = "Please select Class!";

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void but_save_Click(object sender, EventArgs e)
    {
        int subj_Id,Term_Id=0;
        string mode = Convert.ToString(ViewState["mode"]);
        if (mode != "Edit")
        {


            DataTable dt = (DataTable)ViewState["SubjectList"];

            foreach (ListItem item in cblSubjects.Items)
            {
                if (item.Selected)
                {
                    subj_Id = Convert.ToInt32(item.Value.ToString());
                    foreach (ListItem item2 in cblTerm.Items)
                    {
                      
                            if (item2.Selected)
                            {
                                Term_Id = Convert.ToInt32(item2.Value.ToString());
                                save(subj_Id, Term_Id);
                            }
                            
                      

                    }
                   
                }
            }
        }
        else
        {
            subj_Id = Convert.ToInt32(list_subject.SelectedValue.ToString());
            Term_Id = Convert.ToInt32(list_term.SelectedValue.ToString());

            save(subj_Id,Term_Id);

        }



    }

    private void save(int subj_Id,int term_Id)
    {
        try
        {



            int AlreadyIn = 0;
            DataTable dt = new DataTable();
            if (list_EvlType.SelectedIndex > 0)
            {


                BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();



                DataTable dtsub = new DataTable();



                objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objClsSec.Subject_Id = subj_Id;
                objClsSec.Evaluation_Criteria_Type_Id = term_Id;
                objClsSec.Evaluation_Type_Id = Convert.ToInt32(list_EvlType.SelectedValue.ToString());


                objClsSec.Criteria = txtCritName.Text;
                objClsSec.Total_Marks = Convert.ToDecimal(txtMarks.Text);
                objClsSec.Weightage = Convert.ToDecimal(txtGrade.Text);



                dtsub = (DataTable)objClsSec.GetCurrentWeightage(objClsSec);

                if (dtsub.Rows.Count > 0)
                {

                    decimal weightage = decimal.Parse(txtGrade.Text);
                    decimal currWeightage = decimal.Parse(ViewState["currentWeightage"].ToString());
                    decimal currentWeightage = decimal.Parse(dtsub.Rows[0]["currentWeightage"].ToString().Trim());
                    if ((weightage + (currentWeightage - currWeightage)) > 100)
                    {



                        //ImpromptuHelper.ShowPrompt("Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + " For " + list_term.SelectedItem.Text + " . Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString());
                        //lblSave.Visible = true;
                        //lblSave.Text = "Total Weightage Can Not Exceed From 100 For " + list_EvlType.SelectedItem.Text + " For " + list_term.SelectedItem.Text + " . Current Weightage Is " + ((float)(weightage + (currentWeightage - currWeightage))).ToString();
                        return;
                    }
                    else
                    {
                        string mode = Convert.ToString(ViewState["mode"]);

                        if (mode != "Edit")
                        {

                            AlreadyIn = objClsSec.Evaluation_CriteriaAdd(objClsSec);


                            ViewState["dtDetails"] = null;
                            if (AlreadyIn == 0)
                            {
                               // ImpromptuHelper.ShowPrompt("Record was successfully added.");
                                ////pan_New.Attributes.CssStyle.Add("display", "none");
                                ViewState["mode"] = "Add";
                                BindGrid();

                                //txtGrade.Text = "";
                                //list_EvlType.SelectedIndex = 0;

                                //txtGrade.Text = "";
                                //txtCritName.Text = "";
                                //txtMarks.Text = "";
                                //list_EvlType.SelectedIndex = 0;
                                //list_subject.SelectedIndex = 0;




                                //lblSave.Visible = true;
                                //lblSave.Text = "Record Saved Successfully";

                            }



                        }

                        else
                        {



                            AlreadyIn = objClsSec.Evaluation_CriteriaUpdate(objClsSec);


                            ViewState["dtDetails"] = null;
                            if (AlreadyIn == 0)
                            {
                                ImpromptuHelper.ShowPrompt("Record successfully updated.");
                                pan_New.Attributes.CssStyle.Add("display", "none");
                                BindGrid();

                                //lblSave.Visible = true;
                                //lblSave.Text = "Record Updated Successfully";

                            }


                        }






                    }
                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Evaluation Type and Subject!");

                //lblSave.Visible = true;
                //lblSave.Text = "Please Evaluation Type and Subject!";

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




    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
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


    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {

            ImageButton btnCopy = (ImageButton)sender;
            GridViewRow grv = (GridViewRow)btnCopy.NamingContainer;
            string tomarks = grv.Cells[5].Text;
            string Weitage = grv.Cells[6].Text;

            CheckBox cb = null;


            foreach (GridViewRow gvRow in gvSubjects.Rows)
            {

                cb = (CheckBox)gvRow.FindControl("CheckBox1");
                if (cb.Checked)
                {

                    gvRow.Cells[6].Text = Weitage;
                    gvRow.Cells[5].Text = tomarks;
                    cb.Checked = false;
                }
            }
            ViewState["tMood"] = "check";
            btn_apply.Visible = true;
            pan_New.Attributes.CssStyle.Add("display", "none");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();

            BLLEvaluation_Criteria objClsSec = new BLLEvaluation_Criteria();
            DataTable dtsub = new DataTable();

            for (int i = 0; i < gvSubjects.Rows.Count; i++)
            {
                objClsSec.Evaluation_Criteria_Id = Convert.ToInt32(gvSubjects.Rows[i].Cells[0].Text);
                objClsSec.Total_Marks = Convert.ToDecimal(gvSubjects.Rows[i].Cells[5].Text);
                objClsSec.Weightage = Convert.ToDecimal(gvSubjects.Rows[i].Cells[6].Text);


                AlreadyIn = objClsSec.Evaluation_CriteriaApplyAllChangesUpdate(objClsSec);


            }

            ViewState["dtDetails"] = null;
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Apply All Changes successfully.");
                pan_New.Attributes.CssStyle.Add("display", "none");
                BindGrid();

                //lblSave.Visible = true;
                //lblSave.Text = "Apply All Changes successfully.";

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillClassSection();
    }
}