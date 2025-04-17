using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Web.Services;
using System.Runtime.InteropServices;
using System;
using System.Web.Services;

public partial class PresentationLayer_TCS_MarksUnlock : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLClass_Center objCC = new BLLClass_Center();
    BLLResult_Grade objClsSec = new BLLResult_Grade();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ViewState["tMood"] = "check";
                bindTermGroupList();
                FillActiveSessions();
                BindGrid();
                ViewState["MainOrgId"] = 1;
                loadRegions();
                loadClass();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");

            if (Session["RegionID"]!=null)
            {
                ViewState["RegionId"] = Session["RegionID"];
                if (!String.IsNullOrEmpty(ViewState["RegionId"].ToString()) && Convert.ToInt32(ViewState["RegionId"].ToString()) != 0)
                {
                    ddlRegion.SelectedValue = ViewState["RegionId"].ToString();
                    ddlRegion.Enabled = false;
                    ResetFilter();
                    ApplyFilter(1, ddlRegion.SelectedValue);
                    loadCenter();
                }
            }
           
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
            if (ddlRegion.SelectedIndex > 0)
                objCen.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select a Region");
                return;
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");

            //if (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0)
            //{
            //    ddlCenter.SelectedValue = ViewState["CenterId"].ToString();
            //    ddlCenter.Enabled = false;
            //}

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void loadClass()
    {
        try
        {
            BLLClass obj = new BLLClass();
            BLLClass objCS = new BLLClass();
            DataRow row = (DataRow)Session["rightsRow"];
            //if (ddlCenter.SelectedIndex > 0)
            //    obj.Center_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            //else
            //{
            //    ImpromptuHelper.ShowPrompt("Please Select a Center First!");
            //    return;
            //}

            //DataTable dt = obj.ClassFetchByCenterID(obj);
            //objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");

            objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            DataTable dt = objCS.ClassFetch(objCS);
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    private void loadSection()
    {
        try
        {
            BLLSection obj = new BLLSection();
            if (ddlCenter.SelectedIndex > 0)
                obj.Center_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select a Center First!");
                return;
            }
            if (ddlClass.SelectedIndex > 0)
                obj.Class_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select a Class First!");
                return;
            }
            
            DataTable dt = objCC.Class_CenterFetch(objCC); ;
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
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
            ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void bindTermGroupList()
    {
        try
        {
            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
            if (dt.Rows.Count > 0)
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    ddlTerm.SelectedValue = "2";
                else
                    ddlTerm.SelectedValue = "1";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGrid()
    {
        DataTable dt = new DataTable();
        if (ddlTerm.SelectedIndex > 0)
            objClsSec.TermGroup_Id = Convert.ToInt16(ddlTerm.SelectedValue);
        if (ddlSession.SelectedIndex > 0)
            objClsSec.Session_Id = Convert.ToInt16(ddlSession.SelectedValue);
        else
        {
            ImpromptuHelper.ShowPrompt("Please Select a Term and Session!");
            return;
        }
        if (ViewState["Details"] == null)
        {
            dt = objClsSec._AimsMarkslockUnlock(objClsSec);
            ViewState["Details"] = dt;
        }
        else
        {
            dt = (DataTable)ViewState["Details"];
        }
        if (dt.Rows.Count > 0)
        {
            gv_CenterGrid.DataSource = dt;
            GridTestTitle.Visible = true;
        }
        else
        {
            gv_CenterGrid.DataSource = null;
            //SetEmptyGrid(gv_CenterGrid);
        }
        gv_CenterGrid.DataBind();

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Details"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["Details"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegion.SelectedIndex <= 0)
            {
                ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                return;
            }
            ResetFilter();
            ApplyFilter(1, ddlRegion.SelectedValue);
            loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCenter.SelectedIndex <= 0)
            {
                ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                return;
            }
            ResetFilter();
            ApplyFilter(2, ddlCenter.SelectedValue);
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedIndex <= 0)
            {
                ddlCenter_SelectedIndexChanged(this, EventArgs.Empty);
                return;
            }
            ResetFilter();
            ApplyFilter(3, ddlClass.SelectedValue);
            //loadSection();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(4, ddlSection.SelectedValue);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gv_CenterGrid_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_CenterGrid.Rows.Count > 0)
            {
                gv_CenterGrid.UseAccessibleHeader = false;
                gv_CenterGrid.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    //protected void btnCompile_Click_(object sender, EventArgs e)
    //{
    //    CheckBox chkAllowAccess;
    //    foreach (GridViewRow gvr in gv_CenterGrid.Rows)
    //    {
    //        chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");
    //        if (chkAllowAccess.Checked)
    //        {
    //            try
    //            {
    //                int AlreadyIn = 0;

    //                if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
    //                {
    //                    objClsSec.Section_Id = Convert.ToInt32(gvr.Cells[2].Text);
    //                    objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
    //                    objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
    //                    objClsSec.User_Id = Convert.ToInt32(Session["ContactID"].ToString());

    //                    AlreadyIn = objClsSec.TCS_Result_GenerateResultAllBySection_Id(objClsSec);
    //                    ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");

    //                    objClsSec.MarksLockUnlockCompileLog_Insert(objClsSec);
    //                }
    //                else
    //                {
    //                    ImpromptuHelper.ShowPrompt("Please select Section, Session and Term!");
    //                }
    //            }

    //            catch (Exception ex)
    //            {
    //                Session["error"] = ex.Message;
    //                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


    //            }
    //        }
    //    }
    //    ViewState["Details"] = null;
    //    BindGrid();
    //}
    protected void btnCompile_Click(object sender, EventArgs e)
    {
        CheckBox chkAllowAccess;
        int selectedRowCount = 0;

        foreach (GridViewRow gvr in gv_CenterGrid.Rows)
        {
            chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");

            if (chkAllowAccess.Checked)
            {
                selectedRowCount++;
            }
        }

        if (selectedRowCount == 0)
        {
            ImpromptuHelper.ShowPrompt("Please select at least 1 row.");
            return;
        }
        else if (selectedRowCount > 1)
        {
            string script = @"<script type='text/javascript'>
                        showCompileConfirmation();
                      </script>";

            // Register the script for execution
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowCompileConfirmationScript", script, false);

            //foreach (GridViewRow gvr in gv_CenterGrid.Rows)
            //        {
            //            chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");

            //            if (chkAllowAccess.Checked)
            //            {
            //                try
            //                {
            //                    int AlreadyIn = 0;

            //                    if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
            //                    {
            //                        objClsSec.Section_Id = Convert.ToInt32(gvr.Cells[2].Text);
            //                        objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            //                        objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
            //                        objClsSec.User_Id = Convert.ToInt32(Session["ContactID"].ToString());

                                   // AlreadyIn = objClsSec.TCS_Result_GenerateResultAllBySection_Id(objClsSec);
            //                        ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");

            //                        objClsSec.MarksLockUnlockCompileLog_Insert(objClsSec);
            //                    }
            //                    else
            //                    {
            //                        ImpromptuHelper.ShowPrompt("Please select Section, Session, and Term!");
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    Session["error"] = ex.Message;
            //                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            //                }
            //            }
            //        }

            //        ViewState["Details"] = null;
            //        BindGrid();

            // If userConfirmation is false, the user clicked 'No', do nothing or handle accordingly


            // Execution continues here while waiting for the user's confirmation
        }
    }

    // [WebMethod]
    protected void btnYes_Click(object sender, EventArgs e)
    {
        CheckBox chkAllowAccess;
        foreach (GridViewRow gvr in gv_CenterGrid.Rows)
        {
            chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");
            if (chkAllowAccess.Checked)
            {
                try
                {
                    int AlreadyIn = 0;

                    if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0)
                    {
                        objClsSec.Section_Id = Convert.ToInt32(gvr.Cells[2].Text);
                        objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
                        objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
                        objClsSec.User_Id = Convert.ToInt32(Session["ContactID"].ToString());

                        AlreadyIn = objClsSec.TCS_Result_GenerateResultAllBySection_Id(objClsSec);
                        ImpromptuHelper.ShowPrompt("Result Calculation Generated Successfully!");

                        objClsSec.MarksLockUnlockCompileLog_Insert(objClsSec);
                    }
                    else
                    {
                        ImpromptuHelper.ShowPrompt("Please select Section, Session, and Term!");
                    }
                }

                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
                }
            }
        }
        ViewState["Details"] = null;
        BindGrid();
    }


    protected void btnLocking_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = true;
            if(LockUnlock(flag)>0)
                ImpromptuHelper.ShowPrompt("Marks Locked!");
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }
    public int  LockUnlock(bool flag)
    {
        int AlreadyIn = 0;
        try 
        {
            if (ddlSession.SelectedIndex <= 0 || ddlTerm.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please select Session, Term and Evaluation Type");
                return AlreadyIn;
            }
           
            CheckBox chkAllowAccess;
            
            foreach (GridViewRow gvr in gv_CenterGrid.Rows)
            {
                chkAllowAccess = (CheckBox)gvr.FindControl("CheckBox1");
                if (chkAllowAccess.Checked)
                {
                    if (objClsSec.lstSection_Id == null)
                        objClsSec.lstSection_Id = gvr.Cells[2].Text;
                    else
                        objClsSec.lstSection_Id = objClsSec.lstSection_Id + "," + gvr.Cells[2].Text;
                }
            }
            if (!String.IsNullOrEmpty(objClsSec.lstSection_Id))
                objClsSec.lstSection_Id = objClsSec.lstSection_Id.TrimEnd(',');
            else
                return 0;

            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue.ToString());
            objClsSec.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
            // objClsSec.Evaluation_Type_Id = Convert.ToInt32(ddlEvaluationType.SelectedValue);
            objClsSec.Evaluation_Type_Id = 0;
            AlreadyIn = objClsSec.Result_GradeUnlockedSectionsBySection_Id(objClsSec, flag);
            ViewState["Details"] = null;
            BindGrid();
            ApplyFilterafterLockunlock();
            return AlreadyIn;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);

        }
        return AlreadyIn;
    }
    protected void btnUnlocking_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            if (LockUnlock(flag) > 0)
                ImpromptuHelper.ShowPrompt("Marks Unlocked!");
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }
    protected void gv_CenterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gv_CenterGrid.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (mood == "" || mood == "check")
                    {
                        cb.Checked = true;
                        ViewState["tMood"] = "uncheck";
                    }
                    else
                    {
                        cb.Checked = false;
                        ViewState["tMood"] = "check";
                    }

                }

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ApplyFilterafterLockunlock()
    {
        try
        {
            DataView dv;
            string strFilter = "";
            if (ViewState["Details"] != null)
            {
                DataTable dt = (DataTable)ViewState["Details"];
                dv = dt.DefaultView;

                if (ddlRegion.SelectedIndex > 0)
                    strFilter = " Convert([Region_Id], 'System.String')='" + ddlRegion.SelectedValue + "'";

                if (ddlCenter.SelectedIndex > 0)
                    strFilter = strFilter + "and  Convert([Center_Id], 'System.String')='" + ddlCenter.SelectedValue + "'";
                if ((ddlClass.SelectedIndex > 0))
                    strFilter = strFilter + "and Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                dv.RowFilter = strFilter;
                gv_CenterGrid.DataSource = dv;
                gv_CenterGrid.DataBind();
                gv_CenterGrid.SelectedIndex = -1;

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ApplyFilter(int _FilterCondition, string value)
    {
        try
        {

            if (ViewState["Details"] != null)
            {
                DataTable dt = (DataTable)ViewState["Details"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    //case 1: // Region_Id
                    //    {
                    //
                    //        strFilter = " Convert([Region_Id], 'System.String')='" + value + "'";
                    //        break;
                    //    }
                    case 1: // Region_Id
                        {
                            strFilter = " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "' and " +
                                        " Convert([Region_Id], 'System.String')='" + value + "'";
                            break;
                        }


                    case 2: // Center_Id
                        {
                            //strFilter = " Convert([Center_Id], 'System.String')='" + value + "'";
                            //break;
                            strFilter = " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "' and " +
                                " Convert([Center_Id], 'System.String')='" + value + "'";
                            break;
                        }

                    case 3: // Class_Id
                        {
                          ///  strFilter = " Convert([Center_Id], 'System.String')='" + ddlCenter.SelectedValue + "' and ";
                            strFilter = strFilter + " Convert([Class_Id], 'System.String')='" + value + "'";
                            break;
                        }
                    case 4: // Section_Id
                        {
                            strFilter = " Convert([LockMark], 'System.String')='" + value + "'";
                            break;
                        }

                }
                dv.RowFilter = strFilter;
                gv_CenterGrid.DataSource = dv;
                gv_CenterGrid.DataBind();
                gv_CenterGrid.SelectedIndex = -1;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilter()
    {
        try
        {
            //       ViewState["dtDetails"] = null;
            BindGrid();
            gv_CenterGrid.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnUnlockMarks(object sender, EventArgs e)
    {
        try
        {
            Button btnEdit = (Button)(sender);
            objClsSec.Section_Id = Convert.ToInt32(btnEdit.CommandArgument);
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            bool flag = false;
            objClsSec.Result_GradeUnlockedSectionsBySection_Id(objClsSec, flag);
            ImpromptuHelper.ShowPrompt("Marks Unlocked for Specified Section!");
            ViewState["Details"] = null;
            BindGrid();
            ApplyFilterafterLockunlock();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnLockMarks(object sender, EventArgs e)
    {
        try
        {
            Button btnEdit = (Button)(sender);
            objClsSec.Section_Id = Convert.ToInt32(btnEdit.CommandArgument);
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            bool flag = true;
            objClsSec.Result_GradeUnlockedSectionsBySection_Id(objClsSec, flag);
            ImpromptuHelper.ShowPrompt("Marks Locked for Specified Section!");
            ViewState["Details"] = null;
            BindGrid();
            ApplyFilterafterLockunlock();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnLockedSection_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = true;
            if (LockUnlock(flag) > 0)
                ImpromptuHelper.ShowPrompt("Section Locked successfully!");
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }

    
    protected void btnUnLockedSection_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            if (LockUnlock(flag) > 0)
                ImpromptuHelper.ShowPrompt("Section Unlocked successfully!");
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


        }
    }
}