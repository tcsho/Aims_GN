using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_TCS_ClassSectionSubjectCommentsReview : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                ////======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
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

                ////====== End Page Access settings ======================

                FillActiveSessions();
                ddlSession_SelectedIndexChanged(sender, e);
                trButtons.Visible = false;
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }

    private void FillClassSection()
    {



        try
        {

            BLLClass_Section objCS = new BLLClass_Section();

            int Center_Id = Convert.ToInt32(Session["CId"]);

            DataTable _dt = objCS.Class_SectionByCenterId(Center_Id);
            _dt.DefaultView.RowFilter = "Class_Id in (7,8,9,10,11,12,13,14,15)";
            DataTable _dtfilter = _dt.DefaultView.ToTable();
            objBase.FillDropDown(_dt, List_ClassSection, "Section_Id", "fullclasssection");

            if (List_ClassSection.Items.Count == 0)
            {
                ImpromptuHelper.ShowPrompt("Please assign section(s) first.");
            }

        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {



        try
        {

            if (List_ClassSection.SelectedValue != "")
            {
                BindTerm();
                BindSubject();
                //ViewState["Grid"] = null;
                //BindGrid();
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
            BLLStudent objStudent = new BLLStudent();
            DataTable dt = new DataTable();

            if (Convert.ToInt32(List_ClassSection.SelectedValue) > 0 && Convert.ToInt32(list_Term.SelectedValue) > 0 && Convert.ToInt32(list_Subject.SelectedValue) > 0)
            {
                objStudent.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objStudent.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
                objStudent.Term_Id = Convert.ToInt32(list_Term.SelectedValue);
                objStudent.Subject_Id = list_Subject.SelectedValue==null?0:Convert.ToInt32(list_Subject.SelectedValue);


                if (ViewState["Grid"] != null)
                {
                    dt = (DataTable)ViewState["Grid"];
                }
                else
                {
                    dt = objStudent.StudentSelectBySection_IdForSubjectCommentsReview(objStudent);
                }
                dv_details.DataSource = dt;
                dv_details.DataBind();
                ViewState["Grid"] = dt;

            }
            else
            {
                dv_details.DataSource = null;
                dv_details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void dv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dv_details.Rows.Count > 0)
            {
                dv_details.UseAccessibleHeader = false;
                dv_details.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    //private void BindSubject()
    //{
    //    try
    //    {
    //        BLLSection_Subject obj = new BLLSection_Subject();

    //        obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
    //        obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());

    //        DataTable dt = (DataTable)obj.Section_SubjectByEmployeeIdSessionSectionId(obj);
    //        objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}
    private void BindSubject()
    {
        try
        {
            BLLSection_Subject obj = new BLLSection_Subject();



            obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());



            DataTable dt = (DataTable)obj.Section_SubjectSelectSubjectBySectionId(obj);
            objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }


    private void BindStudent()
    {


    }

    private void AddMissingStudent()
    {
        try
        {
            BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
            int AlreadyIn = 0;
            DataTable DTs = (DataTable)ViewState["StudentList"];

            for (int i = 0; i < DTs.Rows.Count; i++)
            {
                obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
                obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

                AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
            }
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
            ObjECT.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
            dt = ObjECT.Evaluation_Criteria_TypeFetchBySectionID(ObjECT);
            objBase.FillDropDown(dt, list_Term, "Evaluation_Criteria_Type_Id", "Type");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    int chkloop;
    protected void btnSave_Click(object sender, EventArgs e)

    {
        BLLStudent_Evaluation_SubjectRemarks objESR = new BLLStudent_Evaluation_SubjectRemarks();


        //DropDownList listG1, listG2, listImp1, listImp2, listEffort;
        //Label lblerror;

        int AlreadyIn;
        bool chk, MasterCheck;
        chk = false;
        MasterCheck = false;
        try
        {
            string gender = "";

            if (ViewState["Gender"].ToString() == "F")
            {
                gender = "her";
            }
            else
            {
                gender = "his";
            }


            objESR.Std_Com_Id = Convert.ToInt32(ViewState["Std_Com_Id"].ToString());
            objESR.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            objESR.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
            objESR.Subject_Id = Convert.ToInt32(ViewState["SecSub"].ToString());
            objESR.Student_Id = Convert.ToInt32(ViewState["Student_Id"].ToString());
            objESR.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue);




            objESR.CreatedOn = DateTime.Now;
            objESR.CreatedBy = Int32.Parse(Session["ContactId"].ToString());

            objESR.ModifiedOn = DateTime.Now;
            objESR.ModifiedBy = Int32.Parse(Session["ContactId"].ToString());


            /*Class_Id from Section_id*/

            BLLSection objsec = new BLLSection();
            DataTable dtcls = new DataTable();
            dtcls = objsec.SectionFetch(Convert.ToInt32(List_ClassSection.SelectedValue));

            /*Subject_Id from Section_subject_Id*/
            BLLSection_Subject objsecsub = new BLLSection_Subject();
            DataTable dtsecsub = new DataTable();
            dtsecsub = objsecsub.Section_SubjectFetch(Convert.ToInt32(list_Subject.SelectedValue));


            /*TermGroup_Id from Term_ID*/

            BLLEvaluation_Criteria_Type objECT = new BLLEvaluation_Criteria_Type();
            DataTable dtterm = new DataTable();
            dtterm = objECT.Evaluation_Criteria_TypeFetch(Convert.ToInt32(list_Term.SelectedValue));



            int class_Id = Convert.ToInt32(dtcls.Rows[0]["Class_Id"].ToString());
            int subject_Id = Convert.ToInt32(dtsecsub.Rows[0]["Subject_Id"].ToString());
            int termgroup_Id = Convert.ToInt32(dtterm.Rows[0]["TermGroup_Id"].ToString());


            if (chkAbsent.Checked)
            {

                objESR.Remarks = lblAbsent.Text;
                objESR.GoodOne = 0;
                objESR.GoodTwo = 0;
                objESR.ImprovOne = 0;
                objESR.ImprovTwo = 0;
                objESR.Effort = 0;
                objESR.isAbsent = true;

                AlreadyIn = objESR.Student_Evaluation_SubjectRemarksUpsert(objESR);
                if (AlreadyIn == 1)
                {
                    chk = true;
                    listG1.BackColor = Color.White;
                    listG2.BackColor = Color.White;
                    listImp1.BackColor = Color.White;
                    listImp2.BackColor = Color.White;
                    listEffort.BackColor = Color.White;
                    lblerror.Text = "";
                    lblerror.Visible = false;

                }

            }
            else
            {
                //var sb = "I am really pleased with " + ViewState["fullname"].ToString() + "'s " + listG1.SelectedItem.Text + " and " + listG2.SelectedItem.Text + ". I would like to see an improvement in " + gender + " " + listImp1.SelectedItem.Text + " and also in " + gender + " " + listImp2.SelectedItem.Text + ".";

                /****COMMENT SAVE**/
                var sb = "";

                if (objESR.Session_Id == 12 && termgroup_Id == 1)
                {
                    sb = "I am really pleased with " + ViewState["fullname"].ToString() + "'s " + listG1.SelectedItem.Text + " and " + listG2.SelectedItem.Text + ". I would like to see an improvement in " + gender + " " + listImp1.SelectedItem.Text + " and also in " + gender + " " + listImp2.SelectedItem.Text + ".";
                }
                else
                {

                    if (class_Id >= 7 && class_Id <= 12) /*For Class 3 to Class 8*/
                    {
                        if (subject_Id == 17 || subject_Id == 12 || subject_Id == 18)
                        {
                            /*Urdu Comments Settings*/
                            //sb = listG1.SelectedItem.Text + " اور اس " + listG2.SelectedItem.Text + " سے خوش ہوں۔ مزیدبرآں اس" + listImp1.SelectedItem.Text + " اور اس " + listImp2.SelectedItem.Text + ".میں بہتری  کے لیے پرامید ہوں " + gvr.Cells[7].Text + " میں";
                            //sb = " میں" + gvr.Cells[7].Text + " " + listG1.SelectedItem.Text + " اور اس " + listG2.SelectedItem.Text + " سے خوش ہوں۔ مزیدبرآں اس" + listImp1.SelectedItem.Text + " اور اس " + listImp2.SelectedItem.Text + ".میں بہتری  کے لیے پرامید ہوں ";
                            sb = listG1.SelectedItem.Text + " اور اس " + listG2.SelectedItem.Text  + "   سے خوش ہوں. مزیدبرآں اس" +"  "+ listImp1.SelectedItem.Text + " اور اس " + listImp2.SelectedItem.Text+ "  " + "میں  بہتری کے لئے پر امید ہوں۔ ";
                        }
                        else
                        {

                            /*English Setting*/
                            sb = "I am  pleased with " + ViewState["fullname"].ToString() + "'s " + listG1.SelectedItem.Text + " and " + listG2.SelectedItem.Text + ". I would like to see an improvement in " + gender + " " + listImp1.SelectedItem.Text + " and also in " + gender + " " + listImp2.SelectedItem.Text + ".";
                        }

                    }
                    else if ((class_Id == 13 || class_Id == 14) && subject_Id == 133)
                    {
                        /*Urdu Comments Settings*/
                        sb =  listG1.SelectedItem.Text + " اور اس " + listG2.SelectedItem.Text +"   "+ "  سے خوش ہوں. مزیدبرآں اس" + "  "+ listImp1.SelectedItem.Text + " اور اس " + listImp2.SelectedItem.Text + "  " + "میں  بہتری کے لئے پر امید ہوں۔ ";
                    }
                    else
                    {
                        /*English Setting*/
                        sb = "I am pleased with " + ViewState["fullname"].ToString() + "'s " + listG1.SelectedItem.Text + " and " + listG2.SelectedItem.Text + ". I would like to see an improvement in " + gender + " " + listImp1.SelectedItem.Text + " and also in " + gender + " " + listImp2.SelectedItem.Text + ".";
                    }
                }
                /**COMMENT SAVE***/


                objESR.Remarks = sb.ToString();

                objESR.Effort = Convert.ToInt32(listEffort.SelectedValue);

                objESR.GoodOne = Convert.ToInt32(listG1.SelectedValue);
                objESR.GoodTwo = Convert.ToInt32(listG2.SelectedValue);
                objESR.ImprovOne = Convert.ToInt32(listImp1.SelectedValue);
                objESR.ImprovTwo = Convert.ToInt32(listImp2.SelectedValue);



                if (Convert.ToInt32(listG1.SelectedValue) > 0 && Convert.ToInt32(listG2.SelectedValue) > 0 && Convert.ToInt32(listImp1.SelectedValue) > 0 && Convert.ToInt32(listImp2.SelectedValue) > 0 && Convert.ToInt32(listEffort.SelectedValue) > 0)
                {
                    string[] myStrings = new string[4];

                    myStrings[0] = listG1.SelectedValue;
                    myStrings[1] = listG2.SelectedValue;
                    myStrings[2] = listImp1.SelectedValue;
                    myStrings[3] = listImp2.SelectedValue;

                    if (myStrings.Distinct().Count() == myStrings.Count())
                    {
                        AlreadyIn = objESR.Student_Evaluation_SubjectRemarksUpsert(objESR);
                        if (AlreadyIn == 1)
                        {
                            chk = true;
                            listG1.BackColor = Color.White;
                            listG2.BackColor = Color.White;
                            listImp1.BackColor = Color.White;
                            listImp2.BackColor = Color.White;
                            listEffort.BackColor = Color.White;
                            lblerror.Text = "";
                            lblerror.Visible = false;

                        }
                    }
                    else
                    {
                        lblerror.Text = "Comment selection can not be repeated, please select unique options";
                        lblerror.Visible = true;
                        MasterCheck = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);


                    }

                }
                else if (Convert.ToInt32(listG1.SelectedValue) == 0 && Convert.ToInt32(listG2.SelectedValue) == 0 && Convert.ToInt32(listImp1.SelectedValue) == 0 && Convert.ToInt32(listImp2.SelectedValue) == 0 && Convert.ToInt32(listEffort.SelectedValue) == 0)
                {

                }
                else
                {
                    lblerror.Text = "Please select all the options";
                    lblerror.Visible = true;
                    MasterCheck = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);

                }
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

        if (MasterCheck == false)
        {
            if (chk == true)
            {
                ImpromptuHelper.ShowPrompt("Student Subject comments saved sucessfully.");
                ViewState["Grid"] = null;
                BindGrid();
                btnCancel_Click(this, EventArgs.Empty);
            }
        }

        else
        {
            ImpromptuHelper.ShowPromptGeneric("There are few issues with the data, please review.", 0);

        }


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Term.SelectedValue != "")
            {
                ViewState["Grid"] = null;
                BindGrid();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {

    }




    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Subject.SelectedIndex >= 0)
            {
                BindTerm();

                ViewState["Grid"] = null;
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedValue != "")
            {
                FillClassSection();
                DDLReset(list_Subject);
                DDLReset(list_Term);
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void DDLReset(DropDownList _ddl)
    {
        try
        {
            if (_ddl.Items.Count > 0)
            {
                _ddl.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");

            ddlSession.SelectedValue =  (Session["Session_Id"].ToString());
            ddlSession.Enabled = false;


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
 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            ViewState["Mode"] = "Edit";
            LinkButton btnEdit = (LinkButton)(sender);

            ViewState["Std_Com_Id"] = btnEdit.CommandArgument;

            BLLEvaluation_Criteria_StudentCommentsBank objECSC = new BLLEvaluation_Criteria_StudentCommentsBank();
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            dv_details.SelectedIndex = gvr.RowIndex;

            objECSC.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objECSC.Class_Id = Convert.ToInt32(gvr.Cells[7].Text);
            objECSC.Subject_Id = Convert.ToInt32(gvr.Cells[6].Text);

            ViewState["Gender"]=(gvr.Cells[8].Text);
            ViewState["fullname"]= (gvr.Cells[9].Text);
            ViewState["SecSub"] = (gvr.Cells[10].Text);
            ViewState["Student_Id"] = (gvr.Cells[11].Text);
            BLLEvaluation_Criteria_Type objECT = new BLLEvaluation_Criteria_Type();
            DataTable dtterm = new DataTable();
            dtterm = objECT.Evaluation_Criteria_TypeFetch(Convert.ToInt32(list_Term.SelectedValue));

            objECSC.TermGroup_Id = Convert.ToInt32(dtterm.Rows[0]["TermGroup_Id"].ToString());
            objECSC.CommCat_Id = 1;

            DataTable dtGood = objECSC.Evaluation_Criteria_StudentCommentsBankFetch(objECSC);

            objECSC.CommCat_Id = 2;
            DataTable dtImp = objECSC.Evaluation_Criteria_StudentCommentsBankFetch(objECSC);

            Panel trdes = (gvr.FindControl("trdes") as Panel);

            if (dtGood.Rows.Count > 0)
                {

                    objBase.FillDropDown(dtGood, listG1, "ComBank_Id", "Comments");
                    objBase.FillDropDown(dtGood, listG2, "ComBank_Id", "Comments");

                }

                if (dtImp.Rows.Count > 0)
                {

                    objBase.FillDropDown(dtImp, listImp1, "ComBank_Id", "Comments");
                    objBase.FillDropDown(dtImp, listImp2, "ComBank_Id", "Comments");

                }

          

            /**COMMENT ALIGNEMENT**/


            string genders = "";

            if (ViewState["Gender"].ToString() == "F")
            {
                genders = "her";
            }
            else
            {
                genders = "his";
            }
            if (objECSC.Class_Id >= 7 && objECSC.Class_Id <= 12) /*From Class 3 to Class 8*/
            {
                if (objECSC.Subject_Id == 17 || objECSC.Subject_Id == 12 || objECSC.Subject_Id == 18)
                {
                    if (objECSC.TermGroup_Id == 1)
                    {
                        if (objECSC.Session_Id<13)
                        {
                            listG1.CssClass = "left-align form-control";
                            listG2.CssClass = "left-align form-control";
                            listImp1.CssClass = "left-align form-control";
                            listImp2.CssClass = "left-align form-control";
                            pleasetxtengtest.CssClass = "urdutxtleft";
                            if (objECSC.Session_Id == 12 && objECSC.TermGroup_Id == 1)
                            {
                                pleasetxtengtest.Text = "I am really pleased with " + ViewState["fullname"].ToString() + "'s ";
                            }
                            else
                            {
                                pleasetxtengtest.Text = "I am pleased with " + ViewState["fullname"].ToString() + "'s ";
                            }

                            andtxt.Text = "and";
                            improtxt1.CssClass = "urdutxtleft";
                            improtxt2.CssClass = "hidetxt";
                            improtxt1.Text = "I would like to see an improvement in " + genders;
                            improtxtand.Text = "and also in " + genders;
                            listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                            andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                            listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                            andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                        }
                        else
                        {
                            listG1.CssClass = "right-align form-control";
                            listG2.CssClass = "right-align form-control";
                            listImp1.CssClass = "right-align form-control";
                            listImp2.CssClass = "right-align form-control";
                            pleasetxtengtest.CssClass = "urdutxtright";

                            pleasetxtengtest.Text = ViewState["fullname"].ToString() + " میں";

                            andtxt.Text = "اور اس";
                            improtxt1.CssClass = "urdutxtright";
                            improtxt1.Text = "سے خوش ہوں۔ مزیدبرآں اس";
                            improtxtand.Text = "اور اس";
                            improtxt2.CssClass = "showtxt text-right";

                            listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                            andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                            listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                            andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                        }
                    }
                    else
                    {
                        listG1.CssClass = "right-align form-control";
                        listG2.CssClass = "right-align form-control";
                        listImp1.CssClass = "right-align form-control";
                        listImp2.CssClass = "right-align form-control";
                        pleasetxtengtest.CssClass = "urdutxtright";

                        //pleasetxtengtest.Text = ViewState["fullname"].ToString() + " میں";
                        pleasetxtengtest.Text = "مہارات";

                        //andtxt.Text = "اور اس";
                        andtxt.Text = "اور";
                        improtxt1.CssClass = "urdutxtright";
                        //improtxt1.Text = "سے خوش ہوں۔ مزیدبرآں اس";
                        improtxt1.Text = "قابلِ توجہ موضوعات";
                        //improtxtand.Text = "اور اس";
                        improtxtand.Text = "اور";
                        improtxt2.CssClass = "showtxt text-right";

                        listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                        andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                        listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                        andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                    }
                }
                else
                {
                    listG1.CssClass = "left-align form-control";
                    listG2.CssClass = "left-align form-control";
                    listImp1.CssClass = "left-align form-control";
                    listImp2.CssClass = "left-align form-control";
                    pleasetxtengtest.CssClass = "urdutxtleft";
                    if (objECSC.Session_Id == 12 && objECSC.TermGroup_Id == 1)
                    {
                        pleasetxtengtest.Text = "I am really pleased with " + ViewState["fullname"].ToString() + "'s ";
                    }
                    else
                    {
                        //pleasetxtengtest.Text = "I am pleased with " + ViewState["fullname"].ToString() + "'s ";
                        pleasetxtengtest.Text = "Strengths";
                    }
                    andtxt.Text = "and";
                    improtxt1.CssClass = "urdutxtleft";
                    improtxt2.CssClass = "hidetxt";
                    //improtxt1.Text = "I would like to see an improvement in " + genders;
                    improtxt1.Text = "Areas for improvement";
                    //improtxtand.Text = "and also in " + genders;
                    improtxtand.Text = "and";
                    listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                    andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                    listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                    andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                }

            }
            else if ((objECSC.Class_Id == 13 || objECSC.Class_Id == 14) && objECSC.Subject_Id == 133) /* For Class 9 and urdu*/
            {
                    if (objECSC.TermGroup_Id == 1)
                {

                    if (objECSC.Session_Id < 13)
                    {
                        listG1.CssClass = "left-align form-control";
                        listG2.CssClass = "left-align form-control";
                        listImp1.CssClass = "left-align form-control";
                        listImp2.CssClass = "left-align form-control";
                        pleasetxtengtest.CssClass = "urdutxtleft";
                        if (objECSC.Session_Id == 12 && objECSC.TermGroup_Id == 1)
                        {
                            pleasetxtengtest.Text = "I am really pleased with " + ViewState["fullname"].ToString() + "'s ";
                        }
                        else
                        {
                            pleasetxtengtest.Text = "I am pleased with " + ViewState["fullname"].ToString() + "'s ";
                        }
                        andtxt.Text = "and";
                        improtxt1.CssClass = "urdutxtleft";
                        improtxt2.CssClass = "hidetxt";
                        improtxt1.Text = "I would like to see an improvement in " + genders;
                        improtxtand.Text = "and also in " + genders;
                        listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                        andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                        listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                        andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";

                    }
                    else
                    {
                        listG1.CssClass = "right-align form-control";
                        listG2.CssClass = "right-align form-control";
                        listImp1.CssClass = "right-align form-control";
                        listImp2.CssClass = "right-align form-control";
                        pleasetxtengtest.CssClass = "urdutxtright";

                        pleasetxtengtest.Text = ViewState["fullname"].ToString() + " میں";

                        andtxt.Text = "اور اس";
                        improtxt1.CssClass = "urdutxtright";
                        improtxt1.Text = "سے خوش ہوں۔ مزیدبرآں اس";
                        improtxtand.Text = "اور اس";
                        improtxt2.CssClass = "showtxt text-right";

                        listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                        andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                        listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                        andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                    }

                   
                }
                else
                {
                    listG1.CssClass = "right-align form-control";
                    listG2.CssClass = "right-align form-control";
                    listImp1.CssClass = "right-align form-control";
                    listImp2.CssClass = "right-align form-control";
                    pleasetxtengtest.CssClass = "urdutxtright";

                    pleasetxtengtest.Text = ViewState["fullname"].ToString() + " میں";

                    andtxt.Text = "اور اس";
                    improtxt1.CssClass = "urdutxtright";
                    improtxt1.Text = "سے خوش ہوں۔ مزیدبرآں اس";
                    improtxtand.Text = "اور اس";
                    improtxt2.CssClass = "showtxt text-right";

                    listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                    andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                    listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding ufloat_right";
                    andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp ufloat_right";
                }
            }
            else
            {

                listG1.CssClass = "left-align form-control";
                listG2.CssClass = "left-align form-control";
                listImp1.CssClass = "left-align form-control";
                listImp2.CssClass = "left-align form-control";
                pleasetxtengtest.CssClass = "urdutxtleft";
                if (objECSC.Session_Id == 12 && objECSC.TermGroup_Id == 1)
                {
                    pleasetxtengtest.Text = "I am really pleased with " + ViewState["fullname"].ToString() + "'s ";
                }
                else
                {
                    pleasetxtengtest.Text = "I am pleased with " + ViewState["fullname"].ToString() + "'s ";
                }
                andtxt.Text = "and";
                improtxt1.CssClass = "urdutxtleft";
                improtxt2.CssClass = "hidetxt";
                improtxt1.Text = "I would like to see an improvement in " + genders;
                improtxtand.Text = "and also in " + genders;
                listG1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                andp.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";
                listImp1div.CssClass = "col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding";
                andp2.CssClass = "col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp";

            }

            /**COMMENT ALIGNMENT***/


            string G1Id = (gvr.Cells[1].Text);
                string G2Id = (gvr.Cells[2].Text);
                string Imp1Id = (gvr.Cells[3].Text);
                string Imp2Id = (gvr.Cells[4].Text);
                string Effort = (gvr.Cells[5].Text);

            bool isAbsent = Convert.ToBoolean(gvr.Cells[12].Text);

            if (isAbsent==true)
            {
                chkAbsent.Checked = true;
                trComments.Visible = false;
                trAttendance.Visible = true;
                //lblAbsent.Text = gvr.Cells[16].Text;


                /******ON CHECk ABSENT CONDTION OF URDU AND ISLAMIAT**/

                if (objECSC.Class_Id >= 7 && objECSC.Class_Id <= 12) /*For Class 3 to Class 8*/
                {
                    if (objECSC.Subject_Id == 17 || objECSC.Subject_Id == 12 || objECSC.Subject_Id==18)
                    {
                        string namewithmain = ViewState["fullname"].ToString() + " میں";
                        // string namewithmain = ViewState["fullname"].ToString();
                        string absenttxt = "کی اس میعاد میں اس مضمون میں غیر حاضری رہی- میں اگلی میعاد میں باقاعدہ حاضری کے لیے پرامید ہوں";

                        //lblAbsent.Text = "<span ><span>" + namewithmain + "</span></span> " + absenttxt;
                        //lblAbsent.CssClass = "maiproblemabsent text-right";
                        lblabsenttxt.Text = namewithmain;
                        lblAbsent.Text = absenttxt;
                    }
                    else
                    {
                        lblabsenttxt.Text = "";
                        lblAbsent.Text = ViewState["fullname"].ToString() + " has been absent for this subject this term.We look forward to better attendance next term.";

                    }
                }
                else if ((objECSC.Class_Id == 13 || objECSC.Class_Id == 14) && objECSC.Subject_Id == 133) /* For Class 9 and urdu*/
                {
                    string namewithmain = ViewState["fullname"].ToString() + " میں";
                    // string namewithmain = ViewState["fullname"].ToString();
                    string absenttxt = "کی اس میعاد میں اس مضمون میں غیر حاضری رہی- میں اگلی میعاد میں باقاعدہ حاضری کے لیے پرامید ہوں";

                    //lblAbsent.Text = "<span ><span>" + namewithmain + "</span></span> " + absenttxt;
                    //lblAbsent.CssClass = "maiproblemabsent text-right";
                    lblabsenttxt.Text = namewithmain;
                    lblAbsent.Text = absenttxt;
                }
                else
                {
                    lblabsenttxt.Text = "";
                    lblAbsent.Text = ViewState["fullname"].ToString() + " has been absent for this subject this term.We look forward to better attendance next term.";

                }
                /******ON CHECk ABSENT CONDTION OF URDU AND ISLAMIAT**/




            }
            else
            {
                chkAbsent.Checked = false;
                trComments.Visible = true;
                trAttendance.Visible = false;
                lblAbsent.Text = "";
            }


            ViewState["G1Id"] = G1Id;
            ViewState["G2Id"] = G2Id;
            ViewState["Imp1Id"] = Imp1Id;
            ViewState["Imp2Id"] = Imp2Id;
            ViewState["Effort"] = Effort;


            if (G1Id != "&nbsp;" || G1Id != String.Empty)
                {
                    listG1.SelectedValue = G1Id;

                    if (Convert.ToInt32(G1Id) > 0)
                    {
                        listG1.BackColor = Color.White;
                    }
                    else
                    {
                        listG1.BackColor = Color.Yellow;
                    }
                }

                if (G2Id != "&nbsp;" || G2Id != String.Empty)
                {
                    listG2.SelectedValue = G2Id;
                    if (Convert.ToInt32(G2Id) > 0)
                    {
                        listG2.BackColor = Color.White;
                    }
                    else
                    {
                        listG2.BackColor = Color.Yellow;
                    }

                }

                if (Imp1Id != "&nbsp;" || Imp1Id != String.Empty)
                {
                    listImp1.SelectedValue = Imp1Id;

                    if (Convert.ToInt32(Imp1Id) > 0)
                    {
                        listImp1.BackColor = Color.White;
                    }
                    else
                    {
                        listImp1.BackColor = Color.Yellow;
                    }
                }

                if (Imp2Id != "&nbsp;" || Imp2Id != String.Empty)
                {
                    listImp2.SelectedValue = Imp2Id;

                    if (Convert.ToInt32(Imp2Id) > 0)
                    {
                        listImp2.BackColor = Color.White;
                    }
                    else
                    {
                        listImp2.BackColor = Color.Yellow;
                    }
                }

                if (Effort != "&nbsp;" || Effort != String.Empty)
                {
                    listEffort.SelectedValue = Effort;

                    if (Convert.ToInt32(Effort) > 0)
                    {
                        listEffort.BackColor = Color.White;
                    }
                    else
                    {
                        listEffort.BackColor = Color.Yellow;
                    }
                }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    


    protected void chkAbsent_OnCheckedChanged(Object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
        if (chkAbsent.Checked)
        {
            //ViewState["Std_Com_Id"] = gvr.Cells[1].Text;
            trComments.Visible = false;
            trAttendance.Visible = true;


            //lblAbsent.Text = ViewState["fullname"].ToString() + " has been absent for this subject this term.We look forward to better attendance next term.";

            /******ON CHECk ABSENT CONDTION OF URDU AND ISLAMIAT**/

            /*Class_Id from Section_id*/

            BLLSection objsec = new BLLSection();
            DataTable dtcls = new DataTable();
            dtcls = objsec.SectionFetch(Convert.ToInt32(List_ClassSection.SelectedValue));

            /*Subject_Id from Section_subject_Id*/
            BLLSection_Subject objsecsub = new BLLSection_Subject();
            DataTable dtsecsub = new DataTable();
            dtsecsub = objsecsub.Section_SubjectFetch(Convert.ToInt32(list_Subject.SelectedValue));


            /*TermGroup_Id from Term_ID*/

            BLLEvaluation_Criteria_Type objECT = new BLLEvaluation_Criteria_Type();
            DataTable dtterm = new DataTable();
            dtterm = objECT.Evaluation_Criteria_TypeFetch(Convert.ToInt32(list_Term.SelectedValue));



            int class_Id = Convert.ToInt32(dtcls.Rows[0]["Class_Id"].ToString());
            int subject_Id = Convert.ToInt32(dtsecsub.Rows[0]["Subject_Id"].ToString());
            int termgroup_Id = Convert.ToInt32(dtterm.Rows[0]["TermGroup_Id"].ToString());



            if (class_Id >= 7 && class_Id <= 12) /*For Class 3 to Class 8*/
            {
                if (subject_Id == 17 || subject_Id == 12 || subject_Id==18)
                {
                    string namewithmain = ViewState["fullname"].ToString() + " میں";
                    // string namewithmain = ViewState["fullname"].ToString();
                    string absenttxt = "کی اس میعاد میں اس مضمون میں غیر حاضری رہی- میں اگلی میعاد میں باقاعدہ حاضری کے لیے پرامید ہوں";

                    //lblAbsent.Text = "<span ><span>" + namewithmain + "</span></span> " + absenttxt;
                    //lblAbsent.CssClass = "maiproblemabsent text-right";
                    lblabsenttxt.Text = namewithmain;
                    lblAbsent.Text = absenttxt;
                   
                }
                else
                {
                    lblabsenttxt.Text = "";
                    lblAbsent.Text = ViewState["fullname"].ToString() + " has been absent for this subject this term.We look forward to better attendance next term.";

                }
            }
            else if ((class_Id == 13 || class_Id == 14) && subject_Id == 133) /* For Class 9 and urdu*/
            {
                string namewithmain = ViewState["fullname"].ToString() + " میں";
                // string namewithmain = ViewState["fullname"].ToString();
                string absenttxt = "کی اس میعاد میں اس مضمون میں غیر حاضری رہی- میں اگلی میعاد میں باقاعدہ حاضری کے لیے پرامید ہوں";

                //lblAbsent.Text = "<span ><span>" + namewithmain + "</span></span> " + absenttxt;
                //lblAbsent.CssClass = "maiproblemabsent text-right";
                lblabsenttxt.Text = namewithmain;
                lblAbsent.Text = absenttxt;
            }
            else
            {
                lblabsenttxt.Text = "";
                lblAbsent.Text = ViewState["fullname"].ToString() + " has been absent for this subject this term.We look forward to better attendance next term.";

            }
            /******ON CHECk ABSENT CONDTION OF URDU AND ISLAMIAT**/



        }
        else
        {
            trComments.Visible = true;
            trAttendance.Visible = false;
            lblAbsent.Text = "";
            lblabsenttxt.Text = "";
        }
 
        string G1Id = (ViewState["G1Id"].ToString());
        string G2Id = (ViewState["G2Id"].ToString());
        string Imp1Id = (ViewState["Imp1Id"].ToString());
        string Imp2Id = (ViewState["Imp2Id"].ToString());
        string Effort = (ViewState["Effort"].ToString());
 
        if (G1Id != "&nbsp;" || G1Id != String.Empty)
        {
            listG1.SelectedValue = G1Id;

            if (Convert.ToInt32(G1Id) > 0)
            {
                listG1.BackColor = Color.White;
            }
            else
            {
                listG1.BackColor = Color.Yellow;
            }
        }

        if (G2Id != "&nbsp;" || G2Id != String.Empty)
        {
            listG2.SelectedValue = G2Id;
            if (Convert.ToInt32(G2Id) > 0)
            {
                listG2.BackColor = Color.White;
            }
            else
            {
                listG2.BackColor = Color.Yellow;
            }

        }

        if (Imp1Id != "&nbsp;" || Imp1Id != String.Empty)
        {
            listImp1.SelectedValue = Imp1Id;

            if (Convert.ToInt32(Imp1Id) > 0)
            {
                listImp1.BackColor = Color.White;
            }
            else
            {
                listImp1.BackColor = Color.Yellow;
            }
        }

        if (Imp2Id != "&nbsp;" || Imp2Id != String.Empty)
        {
            listImp2.SelectedValue = Imp2Id;

            if (Convert.ToInt32(Imp2Id) > 0)
            {
                listImp2.BackColor = Color.White;
            }
            else
            {
                listImp2.BackColor = Color.Yellow;
            }
        }

        if (Effort != "&nbsp;" || Effort != String.Empty)
        {
            listEffort.SelectedValue = Effort;

            if (Convert.ToInt32(Effort) > 0)
            {
                listEffort.BackColor = Color.White;
            }
            else
            {
                listEffort.BackColor = Color.Yellow;
            }
        }



    }

    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            BLLEvaluation_Criteria_StudentCommentsBank objECSC = new BLLEvaluation_Criteria_StudentCommentsBank();
            //Label conname = (e.Row.FindControl("conname") as Label);
            BLLEvaluation_Criteria_Type objECT = new BLLEvaluation_Criteria_Type();
            DataTable dtterm = new DataTable();
            dtterm = objECT.Evaluation_Criteria_TypeFetch(Convert.ToInt32(list_Term.SelectedValue));

            objECSC.TermGroup_Id = Convert.ToInt32(dtterm.Rows[0]["TermGroup_Id"].ToString());

            objECSC.Class_Id = Convert.ToInt32(e.Row.Cells[7].Text);
            objECSC.Subject_Id = Convert.ToInt32(e.Row.Cells[6].Text);

            //if (objECSC.TermGroup_Id == 1)
            //{

            //    e.Row.Cells[16].Text = e.Row.Cells[16].Text.ToString();//Convert.ToString()
            //}
            //else
            //{
            //    e.Row.Cells[16].Text = "<span ><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
            //}
            if (objECSC.TermGroup_Id == 1)
            {
                //btn_save.Attributes.CssStyle["display"] = "none";
                listG1.Enabled = true;
                listG2.Enabled = true;
                listImp1.Enabled = true;
                listImp2.Enabled = true;
                listEffort.Enabled = true;
                chkAbsent.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                //btn_save.Attributes.CssStyle["display"] = "block";
                listG1.Enabled = false;
                listG2.Enabled = false;
                listImp1.Enabled = false;
                listImp2.Enabled = false;
                listEffort.Enabled = false;
                chkAbsent.Enabled = false;
                btnSave.Enabled = false;
            }

            /**If First Term then hide save button**/


            /**COMMENT ALIGNEMENT**/
            if (e.Row.Cells[16].Text ==" " || e.Row.Cells[16].Text == "" || e.Row.Cells[16].Text =="&nbsp;" || e.Row.Cells[16].Text==null)
            {
            
                e.Row.Cells[16].Text = "";
            }

        else
            {
                if (objECSC.Class_Id >= 7 && objECSC.Class_Id <= 12) /*From Class 3 to Class 8*/
                {
                    if (objECSC.Subject_Id == 17 || objECSC.Subject_Id == 12 || objECSC.Subject_Id == 18)
                    {
                        if (objECSC.TermGroup_Id == 1)
                        {
                            //english
                            //e.Row.Cells[16].Text = e.Row.Cells[16].Text;

                            if (Convert.ToInt32(Session["Session_Id"].ToString()) < 13)
                            {
                                e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                            }
                            else
                            {
                                /***For absent**/
                                e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                                e.Row.Cells[16].CssClass = "maiproblem text-right";
                                /***For absent**/
                            }


                        }
                        else
                        {
                            //urdu
                            if (e.Row.Cells[12].Text == "True")
                            {
                                //english
                                //e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                                /***For absent**/
                                e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                                e.Row.Cells[16].CssClass = "maiproblem text-right";
                                /***For absent**/
                            }
                            else 
                            {
                                e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                                e.Row.Cells[16].CssClass = "maiproblem text-right";
                            }
                        }
                    }
                    else
                    {
                        //english
                        e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                    }

                }
                else if ((objECSC.Class_Id == 13 || objECSC.Class_Id == 14) && objECSC.Subject_Id == 133) /* For Class 9 and urdu*/
                {

                    if (objECSC.TermGroup_Id == 1)
                    {
                        //English
                        // e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                        if (Convert.ToInt32(Session["Session_Id"].ToString()) < 13)
                        {
                            e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                        }
                        else
                        {
                            /***For absent**/
                            e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                            e.Row.Cells[16].CssClass = "maiproblem text-right";
                            /***For absent**/
                        }
                    }
                    else
                    {
                        //urdu
                        if (e.Row.Cells[12].Text == "True")
                        {
                            //english
                            //e.Row.Cells[16].Text = e.Row.Cells[16].Text;
                            /***For absent**/
                            e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                            e.Row.Cells[16].CssClass = "maiproblem text-right";
                            /***For absent**/
                        }
                        else
                        {
                            e.Row.Cells[16].Text = "<span class='urdutxt'><span>" + e.Row.Cells[9].Text + "</span></span> " + e.Row.Cells[16].Text;
                            e.Row.Cells[16].CssClass = "maiproblem text-right";
                        }
                    }
                }
                else
                {

                    //English
                    e.Row.Cells[16].Text = e.Row.Cells[16].Text;

                }
            }

            /**COMMENT ALIGNMENT***/
        }

    }
}