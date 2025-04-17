using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using City.Library.SQL;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_PerformanceEvaluationRegionLabels : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();

    string Result_GradeIdGe;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["moID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }
                else
                {
                    lblSave.Text = "";
                    FillClassSection();
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
                        Response.Redirect("~/login.aspx", false);
                    }
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
    private void FillSubjects()
    {
        try
        {

            lblSave.Text = "";
            BLLEvaluation_Criteria_Percentage obj = new BLLEvaluation_Criteria_Percentage();

            int moID = Int32.Parse(Session["moID"].ToString());
            obj.Main_Organisation_Id = moID;
            obj.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

            DataTable dt = (DataTable)obj.Class_SubjectSelectAllByClassId(obj);

            objBase.FillDropDown(dt, list_subject, "subject_id", "Subject_Name");

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
                BLLStudent_Performance_SubItemHeads obj = new BLLStudent_Performance_SubItemHeads();
                obj.Main_Organistion_Id = Int32.Parse(Session["moID"].ToString());

                DataTable dt = obj.Student_Performance_SubItemHeads_SelectAllByOrgID(obj);

                objBase.FillDropDown(dt, list_EvlType, "KndItmHd_Id", "Description");


            }

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
            objBase.FillDropDown(dt, list_term, "Evaluation_Criteria_Type_Id", "Type");
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
            dt.Columns.Add("SubKndItmLbl_Id");
            dt.Columns.Add("Class_Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Subject_Name");
            dt.Columns.Add("Item_Head");
            dt.Columns.Add("Description");
            dt.Columns.Add("OrderOfPer");
            dt.Columns.Add("Region");
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
    private void BindGrid()
    {
        try
        {
            DataTable DT = ExecuteProcedure("GETD", List_ClassSection.SelectedValue.ToString(), Session["moID"].ToString(), list_term.SelectedValue.ToString(), "", false);
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {
                gvSubjects.DataSource = DT;
                gvSubjects.DataBind();
            }
            else
            {
                SetEmptyGrid(gvSubjects);
            }


            ViewState["tMood"] = "check";
            trSave.Visible = true;

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
            BindGrid();
            pan_New.Attributes.CssStyle.Add("display", "inline");
            ViewState["mode"] = "Add";
            txtCritName.Text = "";
            txtSortOrder.Text = "";
            lblSave.Text = "";
            ViewState["currentWeightage"] = "0";
            txtCritName.Focus();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    DataTable ExecuteProcedure(string sAction, string sOptional1, string sOptional2, string sOptional3, string sOptional4, bool sCheck)
    {
        string sXML = "", sXMLD = "";
        if (sCheck)
        {
            sXML = "<PerformanceActivityCriteria>";
            sXML += "<MainOrganistionID>" + Session["moID"].ToString() + "</MainOrganistionID>";
            sXML += "<ClassID>" + List_ClassSection.SelectedValue.ToString() + "</ClassID>";
            sXML += "<SubjectID>" + list_subject.SelectedValue.ToString() + "</SubjectID>";
            sXML += "<EvaluationCriteriaTypeID>" + list_term.SelectedValue.ToString() + "</EvaluationCriteriaTypeID>";
            sXML += "<KndItmHdID>" + list_EvlType.SelectedValue.ToString() + "</KndItmHdID>";
            sXML += "<SubKndItmLblID>" + (ViewState["ResultGrade"] == null ? "0" : ViewState["ResultGrade"].ToString()) + "</SubKndItmLblID>";
            //sXML += "<CritName>" + txtCritName.Text + "</CritName>";
            sXML += "<SortOrder>" + txtSortOrder.Text + "</SortOrder>";
            sXML += "</PerformanceActivityCriteria>";

            sXMLD = "<PerformanceCriteriaDetail>";

            sXMLD += "<Row>";
            sXMLD += "<Region>" + "SR" + "</Region>";
            sXMLD += "<RegionStatus>" + (chkSoth.Checked == true ? "1" : "0") + "</RegionStatus>";
            sXMLD += "</Row>";

            sXMLD += "<Row>";
            sXMLD += "<Region>" + "NR" + "</Region>";
            sXMLD += "<RegionStatus>" + (chkNorth.Checked == true ? "1" : "0") + "</RegionStatus>";
            sXMLD += "</Row>";

            sXMLD += "<Row>";
            sXMLD += "<Region>" + "CR" + "</Region>";
            sXMLD += "<RegionStatus>" + (chkCentral.Checked == true ? "1" : "0") + "</RegionStatus>";
            sXMLD += "</Row>";

            sXMLD += "</PerformanceCriteriaDetail>";
        }
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_dmlPerformanceRegionActivity");
        obj_Access.AddParameter("P_UserID", Session["ContactID"] == null ? "-" : Session["ContactID"].ToString(), DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_XMLData", sXML.Replace("&nbsp;", "").Replace("&", "&amp;"), DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_XMLDataD", sXMLD.Replace("&nbsp;", "").Replace("&", "&amp;"), DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Optional1", sOptional1, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Optional2", sOptional2, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Optional3", sOptional3, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Optional4", sOptional4, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Optional5", txtCritName.Text, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            ImpromptuHelper.ShowPrompt(ex.Message);

        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillSubjects();
            bindTermList();
            BindEvaluationType();
            SetEmptyGrid(gvSubjects);
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
    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {
            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {
                DataTable DT = ExecuteProcedure("IN", "", "", "", "", true);
                DT.Dispose();
                if (DT.Rows.Count > 0)
                {
                    ImpromptuHelper.ShowPrompt(DT.Rows[0][0].ToString());
                }
                if (DT.Rows[0][0].ToString().StartsWith("Record Saved Successfully"))
                {
                    BindGrid();
                    txtCritName.Text = "";
                    txtSortOrder.Text = "";
                    ///   list_subject.SelectedIndex = 0;
                    ViewState["mode"] = "Add";
                    chkCentral.Checked = true;
                    chkNorth.Checked = true;
                    chkSoth.Checked = true;
                }
            }
            else
            {
                DataTable DT = ExecuteProcedure("UP", ViewState["ResultGrade"].ToString(), "", "", "", true);
                DT.Dispose();
                if (DT.Rows.Count > 0)
                {
                    ImpromptuHelper.ShowPrompt(DT.Rows[0][0].ToString());
                }
                if (DT.Rows[0][0].ToString().StartsWith("Record Updated Successfully"))
                {
                    BindGrid();
                    txtCritName.Text = "";
                    txtSortOrder.Text = "";
                    chkCentral.Checked = true;
                    chkNorth.Checked = true;
                    chkSoth.Checked = true;
                    /// list_subject.SelectedIndex = 0;
                }

            }
            ViewState["mode"] = null;
        }
        catch (Exception ex)
        {
            ImpromptuHelper.ShowPrompt(ex.Message);
        }
    }
    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "none");
            gvSubjects.SelectedRowStyle.Reset();
            lblSave.Text = "";
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
            if (List_ClassSection.SelectedIndex > 0 && list_term.SelectedIndex > 0)
            {
                pan_New.Attributes.CssStyle.Add("display", "inline");
                ViewState["mode"] = "Add";
                txtCritName.Text = "";
                txtSortOrder.Text = "";
                lblSave.Text = "";
                list_subject.SelectedIndex = 0;
                list_EvlType.SelectedIndex = 0;
                ViewState["currentWeightage"] = "0";
                txtCritName.Focus();

            }

            else
            {
                ImpromptuHelper.ShowPrompt("Please select Class, Subject and Term!");
            }
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
            pan_New.Attributes.CssStyle.Add("display", "inline");
            ViewState["mode"] = "Edit";
            ImageButton btn = (ImageButton)(sender);
            string ResultGradeValue = btn.CommandArgument;
            Result_GradeIdGe = ResultGradeValue;
            ViewState["ResultGrade"] = ResultGradeValue;

            DataTable DT = ExecuteProcedure("GDetail", Session["moID"].ToString(), List_ClassSection.SelectedValue.ToString(), list_term.SelectedValue.ToString(), Result_GradeIdGe, true);
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {

                txtCritName.Text = DT.Rows[0]["Description"].ToString().Trim();
                txtSortOrder.Text = DT.Rows[0]["OrderOfPer"].ToString().Trim();
                list_subject.SelectedValue = DT.Rows[0]["Subject_Id"].ToString().Trim();

                chkSoth.Checked = (DT.Rows[0]["SouthStatus"].ToString() == "1" ? true : false);
                chkNorth.Checked = (DT.Rows[0]["NorthStatus"].ToString() == "1" ? true : false);
                chkCentral.Checked = (DT.Rows[0]["CentralStatus"].ToString() == "1" ? true : false);

                if (DT.Rows[0]["KndItmHd_Id"].ToString().Trim() != "")
                {

                    list_EvlType.SelectedValue = DT.Rows[0]["KndItmHd_Id"].ToString().Trim();

                }
                else
                {
                    list_EvlType.SelectedIndex = 0;
                }
                txtCritName.Focus();

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
            ImageButton btn = (ImageButton)(sender);
            string ResultGradeValue = btn.CommandArgument;
            ViewState["ResultGrade"] = ResultGradeValue;
            DataTable DT = ExecuteProcedure("DTL", ViewState["ResultGrade"].ToString(), "", "", "", true);
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {
                ImpromptuHelper.ShowPrompt(DT.Rows[0][0].ToString());
                pan_New.Attributes.CssStyle.Add("display", "none");
                BindGrid();
            }
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}