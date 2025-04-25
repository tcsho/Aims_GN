using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using City.Library.SQL;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.HtmlControls;


public partial class PresentationLayer_BifurcationAutomatedStatus : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    private DataSet ds = null;
    public static int MOId = 0, Region_Id = 0, Center_Id = 0, Class_Id = 0; //--Bifurcation Class 8--\\
    

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
                    loadRegions();
                    loadTerms();
                    //loadCenter();
                    loadClass();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                    //if (Convert.ToInt32(row["User_Type_Id"].ToString()) != 5)
                    //{
                    //    ddl_session.Enabled = false;
                    //}
                    

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = 0;

                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = 0;
                    loadRegions();
                    //loadCenter();
                    loadTerms();
                    loadClass();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                    //ddl_session_SelectedIndexChanged(this, EventArgs.Empty);
                    //trButtons.Visible = false;
                    //ddl_session.Enabled = false;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {

                    //ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    //ViewState["RegionId"] = row["Region_Id"].ToString();
                    //ViewState["CenterId"] = row["Center_Id"].ToString();
                    MOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    loadRegions();
                    //loadCenter();
                    loadTerms();
                    loadClass();
                    FillActiveSessions();
                    ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                    //ddl_session_SelectedIndexChanged(this, EventArgs.Empty);
                    //trButtons.Visible = false;
                    //ddl_session.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {

                }

            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }
    protected void btnProcessed_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_session.SelectedIndex > 0)
            {
                //ViewState["dtDetails"] = null;
                //ViewState["RD_Approval"] = true;
                //ViewState["Submit_RD"] = null;
                //BindGrid();
                ResetFilter();
                ApplyFilter(3);
            }
            else
                ImpromptuHelper.ShowPrompt("Please select Session");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnShowSubmitted_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_session.SelectedIndex > 0)
            {
                //ViewState["dtDetails"] = null;
                //ViewState["Submit_RD"] = true;
                //ViewState["RD_Approval"] = null;
                //BindGrid();
                ResetFilter();
                ApplyFilter(2);
            }
            else
                ImpromptuHelper.ShowPrompt("Please select Session");
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
            if (ddlClass.SelectedIndex > 0)
            {
                BLLSection_Subject obj = new BLLSection_Subject();
                obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
                //if (ddlClass.Text == "")
                //{
                //    ddlClass.Text = "Class 8";
                //}
                obj.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);

                DataTable dt1 = obj.Evaluation_Criteria_TypeBySectionId(obj);
                objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");

                // Check and remove "Southern Region" from ddl_region
                foreach (ListItem item in ddl_region.Items)
                {
                    //if (item.Text.Contains("Southern"))
                    //{
                    //    ddl_region.Items.Remove(item);
                    //    break; // Exit the loop once the item is found and removed
                    //}
                }

                if (ddlClass.SelectedValue == "12" && ddl_region.SelectedValue == "20000000")
                {
                    //ddlterm.Items.RemoveAt(1);
                }

                ViewState["dtDetails"] = null;
                gv_details.DataSource = null;
                gv_details.DataBind();

            }
            else
            {
                ResetFilter();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void loadClass()
    {
        //try
        //{
        //    BLLClass_Center obj = new BLLClass_Center();
        //    DataTable dt = null;
        //    int center = Convert.ToInt32(ddl_center.SelectedValue);
        //    dt = obj.Class_CenterFetch(center);
        //    dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 11).CopyToDataTable();
        //    dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 13).CopyToDataTable();

        //    objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
        //    //  ddlClass.SelectedValue = "12";
        //    //ddlClass.Enabled = false;
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 11).CopyToDataTable();
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 13).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
            ddlClass.SelectedIndex = ddlClass.Items.Count - 1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        
    }

    private void bindrdbClass()
    {
        //try
        //{
        //    BLLClass obj = new BLLClass();
        //    DataTable dt = null;
        //    dt = obj.ClassFetch(obj);

        //    dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") == 13 || r.Field<int>("Class_Id") == 17).CopyToDataTable();
        //    objBase.FillRadioButtonList(dt, rdbPromotionClass, "Class_Id", "Class_Name");
        //    //rdbPromotionClass.SelectedValue = "13";
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}
    }
    private void BindGrid()
    {
        try
        {
            BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

            DataTable dtsub = new DataTable();

            //if (ddlClass.SelectedIndex > 0)
            //    objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);

            objClsSec.Main_Organisation_Id = MOId;

            if (Region_Id == 0)
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Region_Id = Region_Id;
            }
            if (ddl_center.SelectedIndex > 0)
            {
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
            }
            else
            {
                objClsSec.Center_Id = Center_Id;
            }
            objClsSec.Session_Id = Convert.ToInt32(ddl_session.SelectedValue.ToString());

            if (ddlClass.SelectedIndex > 0)
                objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue.ToString());  //Added by huzaifa on 30-05-2022
            else
                objClsSec.Class_Id = Class_Id;
            if (ddlterm.SelectedIndex > 0)
                objClsSec.TermGroupID = Convert.ToInt32(ddlterm.SelectedValue.ToString());  //Added by huzaifa on 30-05-2022
            else
                objClsSec.TermGroupID = 0;

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }



            if (dtsub.Rows.Count > 0)
            {


                //if (dtsub.Rows[0]["bifurcation"].ToString() != "1")
                //{
                //    btn_view_Undertaking.Visible = false;
                //    btn_bif_email.Visible = false;
                //}
                gv_details.DataSource = null;
                gv_details.DataBind();
                //tdSearch.Visible = true;
                gv_details.DataSource = dtsub;
                gv_details.DataBind();
                ViewState["dtDetails"] = dtsub;
                //btns.Visible = true;
                //lblGridStatus.Text = "";
            }
            else
            {
                //tdSearch.Visible = false;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
                //lblGridStatus.Text = "No Record Found!";
            }
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

            oDALRegion.Main_Organisation_Country_Id = MOId;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");

            // Check and remove "Southern Region" from ddl_region
            foreach (ListItem item in ddl_region.Items)
            {
                //if (item.Text.Contains("Southern Region"))
                //{
                //    ddl_region.Items.Remove(item);
                //    break; // Exit the loop once the item is found and removed
                //}
            }

            if (Region_Id != 0)
            {
                ddl_region.SelectedValue = Region_Id.ToString();
                ddl_region.Enabled = false;
                loadCenter();
            }



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    private void loadTerms()
    {
        BLLSection_Subject obj = new BLLSection_Subject();
        obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
        
        obj.Section_Id = Convert.ToInt32(12);

        DataTable dt1 = obj.Evaluation_Criteria_TypeBySectionId(obj);
        objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");

        // Check and remove "Southern Region" from ddl_region
        foreach (ListItem item in ddlterm.Items)
        {
            //if (item.Text.Contains("First"))
            //{
            //    ddlterm.Items.Remove(item);
            //    break; // Exit the loop once the item is found and removed
            //}
        }

        if (ddlClass.SelectedValue == "12" && ddl_region.SelectedValue == "20000000")
        {
            ddlterm.Items.RemoveAt(1);
        }
        ddlterm.SelectedIndex = ddlterm.Items.Count - 1;
    }
    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            if (Region_Id != 0)
            {
                objCen.Region_Id = Region_Id;
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (Center_Id != 0)
            {
                ddl_center.SelectedValue = Center_Id.ToString();
                ddl_center.Enabled = false;
                ddl_center_SelectedIndexChanged(this, EventArgs.Empty);
                loadClass();
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void SetSelectedValue(DropDownList ddl, string value)
    {
        foreach (ListItem item in ddl.Items)
        {
            if (item.Value == value)
            {
                ddl.SelectedValue = value;
                return;
            }
        }
        // If value is not found, log a message or handle the situation as needed
        System.Diagnostics.Debug.WriteLine("Value not found in DropDownList: " + value);
    }
    protected void ddl_session_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_session.SelectedItem.Text == "Select")
            {
                ViewState["dtDetails"] = null;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
            }
            if (ddl_session.SelectedIndex > 0 && ddl_region.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
            {
                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please Select Region,Center and Session!");
            }

            //if (ddlClass.SelectedIndex > 0)
            //{
            //    ddlClass.SelectedIndex = -1;
            //}

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
            objBase.FillDropDown(dt, ddl_session, "Session_ID", "Description");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    void AddOrRemoveClass9M(string _Class_Id, string _PromotedTo)
    {

        //ListItem Class9M = new ListItem("9 M (Matric)", "17");
        //rdbPromotionClass.Items.Remove(Class9M);
        //if (_Class_Id == "12" && _PromotedTo == "17")
        //{
        //    rdbPromotionClass.SelectedValue = "13";
        //}
        //else
        //{
        //    rdbPromotionClass.Items.Add(Class9M);
        //}
    }


    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BLLStudent_Conditionally_Promoted_Request obj = new BLLStudent_Conditionally_Promoted_Request();
            Button btn = (Button)(sender);
            obj.Student_Id = Convert.ToInt32(btn.CommandArgument);
            obj.Session_Id = Convert.ToInt32(ddl_session.SelectedValue);
            obj.Student_Conditionally_Promoted_RequestDelete(obj);
            ViewState["dtDetails"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //txtRemarks.Text = "";
        //txtStdId.Text = "";
        //txtStdName.Text = "";
        //txtClassSec.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);

    }


    protected void ApplyFilter(int _FilterCondition)
    {
        try
        {

            if (ViewState["dtDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtDetails"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // Pending
                        {
                            if (ddlClass.SelectedIndex > 0 && ddl_center.SelectedIndex > 0)
                                strFilter = " Convert([RegionId], 'System.String')='" + ddl_region.SelectedValue + "' and " + " Convert([ClassId], 'System.String')='" + ddlClass.SelectedValue + "' and " + " Convert([CenterID], 'System.String')='" + ddl_center.SelectedValue + "'";
                            else if (ddlClass.SelectedIndex > 0)
                                strFilter = " Convert([RegionId], 'System.String')='" + ddl_region.SelectedValue + "' and " + " Convert([ClassId], 'System.String')='" + ddlClass.SelectedValue + "'";
                            else if (ddl_center.SelectedIndex > 0)
                                strFilter = " Convert([RegionId], 'System.String')='" + ddl_region.SelectedValue + "' and " + " Convert([CenterID], 'System.String')='" + ddl_center.SelectedValue + "'";
                            else if (ddl_region.SelectedIndex > 0)
                                strFilter = " Convert([RegionId], 'System.String')='" + ddl_region.SelectedValue + "'";
                            break;
                        }

                    //case 2: //Submitted
                    //    {
                    //        if (ddlClass.SelectedIndex > 0)
                    //            strFilter = " Convert([RD_Approval], 'System.String')='2' and " + " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                    //        else
                    //            strFilter = " Convert([RD_Approval], 'System.String')='2'";
                    //        break;
                    //    }

                    //case 3: // Processed by RD
                    //    {
                    //        if (ddlClass.SelectedIndex > 0)
                    //            strFilter = " Convert([RD_Approval], 'System.String') in ('1','0') and " + " Convert([Class_Id], 'System.String')='" + ddlClass.SelectedValue + "'";
                    //        else
                    //            strFilter = " Convert([RD_Approval], 'System.String') in ('1','0') ";
                    //        break;
                    //    }
                    //case 4: // Apply class Filter
                    //    {
                    //        strFilter = " Convert([ClassID], 'System.String')='" + ddlClass.SelectedValue + "'";
                    //        break;
                    //    }
                }
                dv.RowFilter = strFilter;
                gv_details.DataSource = dv;
                gv_details.DataBind();
               
                gv_details.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ResetFilter();
        ApplyFilter(1);
    }

    private void ResetFilter()
    {
        try
        {
            //       ViewState["dtDetails"] = null;
            BindGrid();
            gv_details.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            // ddlClass.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }





    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "", int isSuccess = 0)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter_withfatheremail");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);//
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_UserID", Session["UserId"].ToString(), DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Is_success", isSuccess, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("term", ddlterm.SelectedValue.ToString(), DataAccess.SQLParameterType.VarChar, true);

        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    DataTable SP_REMINDER_EMAIL_IEP_BIFURCATION(string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "", string sRemarks = "", int sRegionId = 0, int term = 0)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_REMINDER_EMAIL_IEP_AUTOMATED_STATUS");
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);//
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Term", term, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SentRemarks", sRemarks, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_RegionId", sRegionId, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    DataTable ExecuteProcedure_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_IEP_bifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("term", Term_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    DataTable ExecuteProcedure_NEW_StudentDetail(string student_id, string section_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("sp_NEW_IEP_bifurcation_studentdetail");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("section_id", section_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("Term_id", Term_id, DataAccess.SQLParameterType.VarChar, true);
        //obj_Access.AddParameter("P_FatherEmail", lblfatheremail.Text.Trim(), DataAccess.SQLParameterType.VarChar, true); 


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    DataTable ExecuteFunctionIEPStatus(int student_id)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("checkcompletioniep");
        obj_Access.AddParameter("student_id", student_id, DataAccess.SQLParameterType.VarChar, true);

        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    protected void btn_bif_email_Click(object sender, EventArgs e)
    {

        //Button btn = (Button)(sender);
        //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        //gv_details.SelectedIndex = gvr.RowIndex;
        //gvr.Cells[9].Visible = false;
        ////txtStdId.Text = btn.CommandArgument;
        ////txtStdName.Text = gvr.Cells[4].Text.Replace("&#39;", "'");
        ////txtClassSec.Text = gvr.Cells[5].Text + " - " + gvr.Cells[5].Text;
        //ViewState["Class_Id"] = gvr.Cells[2].Text;
        //ViewState["Class_Name"] = gvr.Cells[5].Text;
        //ViewState["Section_Name"] = gvr.Cells[6].Text;
        //ViewState["TermGroupID"] = ddlterm.SelectedValue;//gv_details.DataKeys[gvr.RowIndex].Values["TermGroupID"].ToString();


        //DataTable dt2 = ExecuteFunctionIEPStatus(Convert.ToInt32(txtStdId.Text));
        //if (dt2.Rows.Count > 0)
        //{
        //    if (dt2.Rows[0]["Completion"].ToString() == dt2.Rows[0]["Total"].ToString() && dt2.Rows[0]["CounselorComplete"].ToString() == "1") // CounselorComplete 1 for 'Complete' or 0 for 'InComplete'
        //    {
        //        DataTable dt1 = ExecuteProcedure_StudentDetail(txtStdId.Text, "");
        //        dt1.Dispose();

        //        if (dt1.Rows.Count > 0)
        //        {
        //            // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
        //            /*****************EMAIL***************/

        //            var getclass = ViewState["Class_Id"].ToString(); //ViewState["classids"].ToString();
        //            var getterm = ViewState["TermGroupID"].ToString();//ViewState["TermGroupID"].ToString();

        //            MailMessage mail = new MailMessage();
        //            var Body = "";
        //            var To = "";
        //            var CC = "";
        //            var CC2 = "";
        //            var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

        //            To = dt1.Rows[0][2].ToString();
        //            CC = dt1.Rows[0]["CenterEmail"].ToString();
        //            CC2 = "ManageAcknowledgement@csn.edu.pk";
        //            // CC = "ManageAcknowledgement@csn.edu.pk";  //txtStdId.Text +
        //            string Subject = "";

        //            if (getclass == "12" && getterm == "1" && (ddl_region.SelectedValue == "30000000" || ddl_region.SelectedValue == "40000000"))
        //                Subject = "Bifurcation Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (First Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "] "; //Moving from Class 9 Matric to the O-Level route
        //            else if (getclass == "12" && getterm == "2" && ddl_region.SelectedValue == "20000000")
        //                Subject = "Bifurcation Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (Second Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";
        //            //Subject = txtStdId.Text + " - Application – Moving from Class 9 Matric to the O-Level route";

        //            else if (getclass == "12" && getterm == "2" && (ddl_region.SelectedValue == "30000000" || ddl_region.SelectedValue == "40000000"))
        //                //Subject = txtStdId.Text + " - Application – Continue O-level route (Class 8 - 2nd term)";
        //                Subject = "Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (Second Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";

        //            else if (getclass == "13" && getterm == "1")
        //                Subject = "Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (First Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";
        //            //Subject = "Undertaking – Class 9 (1st term)";
        //            else if (getclass == "13" && getterm == "2")
        //                Subject = "Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (Second Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";
        //            //Subject = "Undertaking – Class 9 (2nd term)";



        //            else if (getclass == "14" && getterm == "1")
        //                Subject = "Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (First Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";
        //            // Subject = "Undertaking – Class 10 (1st term)";

        //            else if (getclass == "15" && getterm == "1")
        //                Subject = "Undertaking – [" + dt1.Rows[0]["First_Name"].ToString() + "] (" + txtStdId.Text + ") | [" + dt1.Rows[0]["Class_Name"].ToString() + "-" + ViewState["Section_Name"].ToString() + "] (First Term)| [" + dt1.Rows[0]["Center_Name"].ToString() + "]";
        //            // Subject = "Undertaking – Class 10 (1st term)";

        //            var onclassbase = "";
        //            /***********HTML TEMPLET***/
        //            Body += "<body style='margin:0;padding:0;'>";
        //            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
        //            Body += "<tr>";
        //            Body += "<td align='center' style='padding:0;'>";
        //            Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
        //            Body += "<tr>";
        //            Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2

        //            //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
        //            Body += "<img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png'>";
        //            Body += "</td>";
        //            Body += "</tr>";
        //            Body += "<tr>";
        //            Body += "<td style='padding:36px 30px 42px 30px;'>";
        //            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
        //            Body += "<tr>";
        //            Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
        //            Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";



        //            /**on basis change**/
        //            /**CLASS UNDERTAKING**/
        //            //Mid Year Bifurcation: For CR and NR only. (Bifurcation Undertaking Email)
        //            if (getclass == "12" && getterm == "1")
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) However, I insist that my child should continue the O-Level route.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) I accept the responsibility to ensure my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 4) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams.</p>";
        //            }
        //            // End Of Year Bifurcation: For SR Only. (Bifurcation Undertaking Email)
        //            if (getclass == "12" && getterm == "2" && ddl_region.SelectedValue == "20000000")
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) However, I insist that my child should continue the O-Level route.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) I accept the responsibility to ensure my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 4) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams.</p>";
        //            }
        //            //End Of Year(CR and NR): Undertaking Email for promotion
        //            if (getclass == "12" && getterm == "2" && (ddl_region.SelectedValue == "30000000" || ddl_region.SelectedValue == "40000000"))
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";


        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 8 (2nd term) result is not up to the mark.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams</p>";

        //            }

        //            if (getclass == "13" && getterm == "1")
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 9 (1st term) result is not up to the mark.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams</p>";

        //            }

        //            if (getclass == "13" && getterm == "2")
        //            {

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 9 (2nd term) result is not up to the mark.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams</p>";

        //            }




        //            if (getclass == "14" && getterm == "1")
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in " + dt1.Rows[0]["Class_Name"].ToString() + " Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 10 (First Term) result is not up to the mark.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams</p>";

        //            }
        //            //if (getclass == "14" && getterm == "1")
        //            //{

        //            //    onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 9 EOY Results, had provisionally promoted my child to Year 10.</p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 10 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 10 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

        //            //}

        //            //if (getclass == "15" && getterm == "2")
        //            //{

        //            //    onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 11 Mid-year examination Results, had provisionally allowed my child to sit for Year 11 Mock examinations. </p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mock examinations with the minimum required attainment levels and is going to be privatized for Cambridge Exams.</p>";

        //            //}

        //            if (getclass == "15" && getterm == "1")
        //            {
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to take the Cambridge exams as The City School student, please read and submit the application for undertaking.</p><br/>";
        //                onclassbase += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I,as a parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong>, ERP # " + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in Class 11 Section " + ViewState["Section_Name"].ToString() + "</strong>  " +
        //                    ", confirm that I have fully read and understood the the circumstances outlined below and have signed the agreement as per my consent:</p> ";

        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 10 Mid-year, Mocks and Cambridge Results, had provisionally promoted my child to Year 11.</p>";
        //                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 11 Mock examinations with the condition of attaining an overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

        //            }
        //            /**CLASS UNDERTAKING**/



        //            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>1) That the school, after careful deliberation and consideration of the " + spn_class.InnerText + " Results, has advised me to transfer my child to the Matric system.</p>";
        //            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>2) However, at my insistence, the school has provisionally allowed my child to sit in " + spn_class.InnerText + " and take final examinations for the O level stream.</p>";
        //            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>3) Accept the responsibility that my child must pass the " + spn_class.InnerText + " Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";
        //            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</p>";
        //            //Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</p>";

        //            Body += onclassbase;
        //            //  Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>You can also review the Individual Education Plan we have created to support your child’s progress. Once you have reviewed it, please acknowledge it.</p> ";

        //            Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request.</p>";



        //            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(txtStdId.Text);
        //            string encrypted_student_Id = Convert.ToBase64String(b);

        //            byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(ViewState["Class_Id"].ToString());
        //            string encrypted_class_Id = Convert.ToBase64String(c);

        //            byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["Session_Id"].ToString());
        //            string encrypted_session_Id = Convert.ToBase64String(sess);


        //            byte[] stname = System.Text.ASCIIEncoding.ASCII.GetBytes(txtStdId.Text);
        //            string encrypted_student_Name = Convert.ToBase64String(stname);

        //            byte[] classsec = System.Text.ASCIIEncoding.ASCII.GetBytes(txtClassSec.Text);
        //            string encrypted_student_ClassSec = Convert.ToBase64String(classsec);


        //            //var baseurl = "http://trainingaims.thecityschool.edu.pk/";
        //            // var baseurl = "http://tcsaims.com/";
        //            var baseurl = "http://124.29.197.77:5173/";
        //            var urlconfirmation = baseurl + "confirmation?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id + "&St_Nm=" + encrypted_student_Name + "&St_ClS=" + encrypted_student_ClassSec;//ddlStudent.SelectedValue

        //            // var urliep = baseurl+"PresentationLayer/tcs/Parent_IEP_Form.aspx?s=" + txtStdId.Text + "&ses=" + Session["Session_Id"].ToString();
        //            // Body += "<p style='text-align:center'><b><a style='color: #fff text-decoration:none border:none padding:10px 100px !important background:#0C4DA2 border-radius:10px 'href='" + urliep + "' >Click to view IEP form</a></b></p> ";
        //            Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + urlconfirmation + "'>Confirm</a></b></p>";

        //            Body += "</td>";
        //            Body += "</tr>";

        //            Body += "</table>";
        //            Body += "</td>";
        //            Body += "</tr>";
        //            Body += "<tr>";
        //            Body += "<td style='padding:30px;background:#FBEE26;'>";
        //            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
        //            Body += "<tr>";
        //            Body += "<td style='padding:0;width:100%;' align='Center'>";
        //            Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

        //            Body += "</td>";

        //            Body += "</tr>";
        //            Body += "</table>";
        //            Body += "</td>";
        //            Body += "</tr>";
        //            Body += "</table>";
        //            Body += "</td>";
        //            Body += "</tr>";
        //            Body += "</table>";
        //            Body += "</body>";
        //            /*****HTML TEMPLET*********/


        //            //var Password = "Pakistan!@#$";//gmail//"@U13K$@CgMlG";
        //            var Password = ConfigurationManager.AppSettings["AppNotificationPwd"].ToString(); ;

        //            try
        //            {
        //                using (MailMessage mm = new MailMessage(Email.Address, To))
        //                {
        //                    mm.Subject = Subject;
        //                    mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
        //                    if (CC != "")
        //                    {
        //                        mm.CC.Add(new MailAddress(CC));
        //                    }

        //                    mm.CC.Add(new MailAddress(CC2));
        //                    //mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");

        //                    mm.Body = Body;


        //                    mm.IsBodyHtml = true;
        //                    using (SmtpClient smtp = new SmtpClient())
        //                    {
        //                        // smtp.Host = "smtp.gmail.com"; //"mail.bizar.pk";
        //                        smtp.Host = "10.1.1.120";//"smtp.office365.com"; //"mail.bizar.pk";
        //                        smtp.EnableSsl = false;
        //                        NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);

        //                        smtp.UseDefaultCredentials = false;
        //                        smtp.Credentials = NetworkCred;
        //                        smtp.Port = 25;
        //                        smtp.Timeout = 1000000000;



        //                        try
        //                        {
        //                            DataTable dt = ExecuteProcedure("IN", "", ddl_session.SelectedValue.ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), ddlClass.SelectedValue.ToString(), 1);
        //                            dt.Dispose();
        //                            smtp.Send(mm);



        //                        }
        //                        catch (SmtpFailedRecipientException ex)
        //                        {

        //                        }

        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                DataTable dt = ExecuteProcedure("IN", "", Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString(), 0);
        //                dt.Dispose();
        //            }

        //            /********EMAIL******************/
        //            ViewState["dtDetails"] = null;
        //            BindGrid();
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
        //else
        //{

        //    //lblerror.Text = "Incompleted IEP Can't send Bifurcation Email";
        //    //lblerror.CssClass = "label label-danger text-center";
        //}
    }


    protected void btnreminder_Click(object sender, EventArgs e)
    {


    }

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }




    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                // Create a new HtmlForm and add the GridView to it
                HtmlForm form = new HtmlForm();
                gv_details.Parent.Controls.Add(form);
                form.Controls.Add(gv_details);

                // Render the form
                form.RenderControl(hw);

                // Write the rendered content to the response
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // This is required to avoid the runtime error "Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }

    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();

            if (ddl_region.SelectedItem.Text == "Select")
            {

                ddl_center.SelectedIndex = 0;
                ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
            }
            else
            {
                ResetFilter();
                ApplyFilter(1);
                ViewState["dtDetails"] = null;
                // ddlClass.SelectedIndex = 0;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddl_center_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddl_center.SelectedItem.Text == "Select")
            {
                ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
            }
            else
            {
                loadClass();
                ResetFilter();
                ApplyFilter(1);
                ViewState["dtDetails"] = null;
            }
                
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_region.SelectedIndex <= 0)
            {
                ImpromptuHelper.ShowPrompt("Please select Region");
            }
            else
            {
                ResetFilter();
                ApplyFilter(1);
                ViewState["dtDetails"] = null;
                // ddlClass.SelectedIndex = 0;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void ddlterm_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (ddlterm.SelectedIndex > 0)
        //{
        //    ViewState["dtDetails"] = null;
        //    ResetFilter();
        //    ApplyFilter(4);
        //    //DropDownList btn = (DropDownList)(sender);
        //    //GridViewRow gvr = (GridViewRow)btn.NamingContainer;

        //    //gvr.Cells[9].Visible = true;
        //}
        //else
        //{
        //    ResetFilter();
        //}

    }

    protected void gv_details_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reminder")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gv_details.Rows[rowIndex];
            string Student_id = gv_details.Rows[rowIndex].Cells[3].Text;
            string studentname = gv_details.Rows[rowIndex].Cells[4].Text;
            string st_class = gv_details.Rows[rowIndex].Cells[1].Text;

            DataTable dt1 = ExecuteProcedure_NEW_StudentDetail(Student_id, "");


            if (dt1.Rows.Count > 0)
            {
                // ImpromptuHelper.ShowPrompt(dt.Rows[0][0].ToString());
                /*****************EMAIL***************/

                string getclass = ddlClass.SelectedValue; //ViewState["classids"].ToString();
                string getterm = ddlterm.SelectedValue; //ViewState["TermGroupID"].ToString();

                MailMessage mail = new MailMessage();
                var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                var Body = "";
                var To = dt1.Rows[0][2].ToString();
                //var To = "muhammad.maroof1@csn.edu.pk";
                var cc = "";
                var cc2 = "";
                // var Password = ConfigurationManager.AppSettings["AppNotificationPwd"].ToString();
                var Password = "Jup31963";
                var onclassbase = "";
                /***********HTML TEMPLET***/
                Body += "<body style='margin:0;padding:0;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
                Body += "<tr>";
                Body += "<td align='center' style='padding:0;'>";
                Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
                Body += "<tr>";
                Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2

                //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
                Body += "<img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png'>";
                Body += "</td>";
                Body += "</tr>";
                Body += "<tr>";
                Body += "<td style='padding:36px 30px 42px 30px;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
                Body += "<tr>";
                Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
                Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian,</h1>";
                Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, please read and submit the application for undertaking.</p><hr>";
                Body += "<p style='margin: 0 0 12px 0font - size:14pxline - height:24pxfont - family:Arial,sans - serif'>I, the parent/guardian of <strong> " + dt1.Rows[0]["First_Name"].ToString() + "</strong> ERP # <strong>" + dt1.Rows[0]["Student_No"].ToString() + " </strong> studying in <strong>" + dt1.Rows[0]["Class_Name"].ToString() + "</strong> Section <strong>" + dt1.Rows[0]["Section_Name"].ToString() + "</strong>,   " +
                    "confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to implement the appropriate consequences stated:</p> ";

                /**on basis change**/
                /**CLASS UNDERTAKING**/
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1. The school has clearly explained that my child’s class 8 (2nd term) result is not up to the mark.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2. I take the responsibility that my child will meet the school’s required attainment levels.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3. Failure to meet the minimum requirements in the internal exams may result in my child being privately registered for the CAIE Exams.</p>";

                Body += onclassbase;
                Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request.</p>";

                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Student_id);
                string encrypted_student_Id = Convert.ToBase64String(b);

                byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(getclass);
                string encrypted_class_Id = Convert.ToBase64String(c);

                //byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(Session["Session_Id"].ToString());
                byte[] sess = System.Text.ASCIIEncoding.ASCII.GetBytes(ddl_session.SelectedValue.ToString());
                string encrypted_session_Id = Convert.ToBase64String(sess);


                byte[] stname = System.Text.ASCIIEncoding.ASCII.GetBytes(studentname);
                string encrypted_student_Name = Convert.ToBase64String(stname);

                byte[] classsec = System.Text.ASCIIEncoding.ASCII.GetBytes(st_class);
                string encrypted_student_ClassSec = Convert.ToBase64String(classsec);

                var urlconfirmation = "http://www.tcsaims.com/PresentationLayer/New_Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id + "&St_Nm=" + encrypted_student_Name + "&St_ClS=" + encrypted_student_ClassSec;
                //var urlconfirmation = "http://192.168.1.9:8095/PresentationLayer/New_Bifurcation_Confirmation.aspx?St_Id=" + encrypted_student_Id + "&Cl_Id=" + encrypted_class_Id + "&Sess_Id=" + encrypted_session_Id + "&St_Nm=" + encrypted_student_Name + "&St_ClS=" + encrypted_student_ClassSec;

                Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + urlconfirmation + "'>Confirm</a></b></p><hr>";

                Body += "</td>";
                Body += "</tr>";

                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "<tr>";
                Body += "<td style='padding:30px;background:#FBEE26;'>";
                Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
                Body += "<tr>";
                Body += "<td style='padding:0;width:100%;' align='Center'>";
                Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

                Body += "</td>";

                Body += "</tr>";
                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "</table>";
                Body += "</td>";
                Body += "</tr>";
                Body += "</table>";
                Body += "</body>";

                cc = dt1.Rows[0]["centerEmail"].ToString();
                cc2 = "manageacknowledgement@csn.edu.pk";

                try
                {
                    using (MailMessage mm = new MailMessage(Email.Address, To))
                    {
                        mm.Subject = "Undertaking – " + dt1.Rows[0]["First_Name"].ToString() + " (" + dt1.Rows[0]["Student_No"].ToString() + ") | " + dt1.Rows[0]["class_name"].ToString() + " (Second Term) | " + dt1.Rows[0]["Center_Name"].ToString() + "";
                        mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                        mm.CC.Add(new MailAddress(cc));
                        mm.CC.Add(new MailAddress(cc2));


                        mm.Body = Body;


                        mm.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.office365.com";
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials =
                            new NetworkCredential("AppNotifications@csn.edu.pk", "Jup31963");
                            smtp.Timeout = 1000000000;
                            // Enable verbose logging
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.EnableSsl = true;
                            smtp.TargetName = "STARTTLS/smtp.office365.com";
                            // Capture additional log information
                            smtp.ServicePoint.MaxIdleTime = 1; smtp.ServicePoint.ConnectionLimit = 1; ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            try
                            {
                                smtp.Send(mm);
                                DataTable dt = SP_REMINDER_EMAIL_IEP_BIFURCATION(Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString(), "Successfully Sent", int.Parse(dt1.Rows[0]["Region_Id"].ToString()),int.Parse(ddlterm.SelectedValue));
                                dt.Dispose();
                            }
                            catch
                            (SmtpException smtpEx)
                            {
                                Console.WriteLine(
                            "SMTP Exception: "
                            + smtpEx.Message);
                                if
                                (smtpEx.InnerException != null)
                                {
                                    Console.WriteLine(
                                "Inner Exception: "
                                + smtpEx.InnerException.Message);
                                }
                            }

                            catch
                            (Exception ex)
                            {
                                Console.WriteLine(
                            "General Exception: "
                            + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //DataTable dt = ExecuteProcedure("IN", "", Session["session_id"].ToString(), dt1.Rows[0]["center_id"].ToString(), dt1.Rows[0]["Student_No"].ToString(), dt1.Rows[0]["First_Name"].ToString(), dt1.Rows[0]["class_id"].ToString(), 0);
                    // dt.Dispose();
                }
            }
        }
    }

    protected void gv_details_PreRender1(object sender, EventArgs e)
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

    protected void ddl_center_SelectedIndexChanged2(object sender, EventArgs e)
    {
        try
        {
            if (ddl_center.SelectedItem.Text == "Select")
            {
                ddl_session.SelectedIndex = ddl_session.Items.Count - 1;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
            }
            else
            {
                loadClass();
                ResetFilter();
                ApplyFilter(1);
                ViewState["dtDetails"] = null;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btn_view_Undertaking_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)(sender);
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gv_details.SelectedIndex = gvr.RowIndex;
        txtStdId.Text = btn.CommandArgument;
        txtStdName.Text = gvr.Cells[3].Text.Replace("&#39;", "'");
        txtClassSec.Text = gvr.Cells[4].Text + " - " + gvr.Cells[5].Text;
        //ViewState["Class_Id"] = gvr.Cells[1].Text;
        //ViewState["Class_Name"] = gvr.Cells[4].Text;
        //ViewState["Section_Name"] = gvr.Cells[5].Text;
        //ViewState["TermGroupID"] = gv_details.DataKeys[gvr.RowIndex].Values["TermGroupID"].ToString();
        Response.Redirect("~/PresentationLayer/IEP_Simple_Undertaking.aspx?S=" + txtStdId.Text + "&C=" + "" + "&T=" + ddlterm.SelectedValue);
    }
}