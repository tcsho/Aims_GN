using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Net;



public partial class PresentationLayer_StudentConditionallyPromotedApproval : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    public static int NMOId, NRegion_Id, NCenter_Id;

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];

        if (!IsPostBack)
        {
            try
            {
                NMOId = 0;
                NRegion_Id = 0;
                NCenter_Id = 0;

                if (row["User_Type"].ToString() != "SAdmin")
                {

                }


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {

                    NMOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    NRegion_Id = 0;
                    NCenter_Id = 0;
                    loadRegions();
                    FillActiveSessions();
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                    //btnSendEmail.Visible = true;
                    return;
                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {

                    NMOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    NRegion_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    NCenter_Id = 0;


                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    NMOId = Convert.ToInt32(row["Main_Organisation_Id"].ToString());
                    NRegion_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    NCenter_Id = Convert.ToInt32(row["Center_Id"].ToString());



                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {


                }
                loadRegions();
                ddl_region_SelectedIndexChanged(this, EventArgs.Empty);
                FillActiveSessions();
                ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                // trButtons.Visible = false;
                FillClass();
            }



            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }


    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;
                gv_details.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowApproved_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(2);
            //if (ddlSession.SelectedIndex > 0)
            //{
            //    ViewState["RD_Approval"] = true;
            //    ViewState["dtDetails"] = null;
            //    BindGrid();
            //}
            //else
            //    ImpromptuHelper.ShowPrompt("Please Select a session");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowDisApproved_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(3);
            //if (ddlSession.SelectedIndex > 0)
            //{
            //    ViewState["RD_Approval"] = false;
            //    ViewState["dtDetails"] = null;
            //    BindGrid();
            //}
            //else  
            //    ImpromptuHelper.ShowPrompt("Please Select a session");
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
            BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

            DataTable dtsub = new DataTable();


            objClsSec.Main_Organisation_Id = NMOId;
            if (NRegion_Id == 0)
            {
                objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());


            }
            else
            {
                objClsSec.Region_Id = NRegion_Id;


            }
            if (NCenter_Id == 0)
            {
                objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());

            }
            else
            {
                objClsSec.Center_Id = NCenter_Id;


            }
            if (ddlSession.SelectedIndex > 0)
                objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            //////objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            //if (ViewState["RD_Approval"].ToString() == "-1")
            //    objClsSec.RD_Approval = null;
            //else
            //    objClsSec.RD_Approval = Convert.ToBoolean(ViewState["RD_Approval"].ToString());
            if (ddlClass.SelectedIndex > 0)
                objClsSec.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            else
                objClsSec.Class_Id = null;
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Student_Conditionally_Promoted_RequestForApproval(objClsSec);
                ViewState["dtDetails"] = dtsub;
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

                //btns.Visible = true;
                lblGridStatus.Text = "";
            }
            else
            {
                tdSearch.Visible = false;
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;

                lblGridStatus.Text = "No Record Found!";
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

            oDALRegion.Main_Organisation_Country_Id = NMOId;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");


            if (NRegion_Id != 0)
            {
                ddl_region.SelectedValue = NRegion_Id.ToString();
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

    private void loadCenter()
    {
        try
        {

            BLLCenter objCen = new BLLCenter();
            if (NRegion_Id != 0)
            {
                objCen.Region_Id = NRegion_Id;
            }
            else
            {
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            }
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");

            if (NCenter_Id != 0)
            {
                ddl_center.SelectedValue = NCenter_Id.ToString();
                ddl_center.Enabled = false;

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

            if (ddlSession.SelectedItem.Text == "Select")
            {
                gv_details.DataSource = null;
                gv_details.DataBind();
                //btns.Visible = false;
            }
            if (ddlSession.SelectedIndex > 0 && ddl_region.SelectedIndex > 0)
            {

                ViewState["dtDetails"] = null;
                BindGrid();
            }
            else
            {
                //  ImpromptuHelper.ShowPrompt("Please Select Region,Center and Session!");
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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }




    protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            loadCenter();
            if (ddl_region.SelectedItem.Text == "Select")
            {

                ddl_center.SelectedIndex = 0;
                ddlSession.SelectedIndex = 0;
                gv_details.DataSource = null;
                gv_details.DataBind();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_center.SelectedItem.Text == "Select")
        {
            ddlSession.SelectedIndex = 0;
            gv_details.DataSource = null;
            gv_details.DataBind();
            //btns.Visible = false;
        }
        else
        {
            FillClass();
            ViewState["dtDetails"] = null;
            BindGrid();

        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedIndex > 0)
        {
            ViewState["dtDetails"] = null;
            BindGrid();

        }
    }
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            //dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            //dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 14).CopyToDataTable();
            int[] excludedClassIds = new int[] { 2, 3, 4, 5, 6, 12, 14, 15, 17, 18, 19, 20, 89, 90, 92, 93 };
            dt = dt.AsEnumerable().Where(r => !excludedClassIds.Contains(r.Field<int>("Class_Id"))).CopyToDataTable();
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        if (txtRemarks.Text == "   ")
            return;
        ViewState["mode"] = "Add";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        Button btn = (Button)(sender);
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gv_details.SelectedIndex = gvr.RowIndex;
        lblStdId.Text = btn.CommandArgument;
        lblStdName.Text = gvr.Cells[1].Text;
        lblRequestedClass.Text = gvr.Cells[10].Text;
        lblClassSec.Text = gvr.Cells[3].Text + " - " + gvr.Cells[4].Text;
        ViewState["Class_Id"] = gvr.Cells[2].Text;
        ViewState["Class_Name"] = gvr.Cells[3].Text;
        ViewState["Section_Name"] = gvr.Cells[4].Text;
        ViewState["ResultStatus"] = gvr.Cells[7].Text;
        ViewState["Days"] = gvr.Cells[9].Text;
        rdApproval.SelectedIndex = -1;
        txtRemarks.Text = "";
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        rdApproval.SelectedValue = "-1";
        txtRemarks.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Add";
        string StudentNO = lblStdId.Text;

        objClsSec.RD_Remarks = txtRemarks.Text;

        int AlreadyIn = 0;
        DataTable dt = new DataTable();


        objClsSec.Student_Id = Int32.Parse(StudentNO);
        objClsSec.Student_No = Int32.Parse(StudentNO);
        objClsSec.StudentName = lblStdName.Text;
        objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
        objClsSec.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
        objClsSec.Center_Id = Convert.ToInt32(ddl_center.SelectedValue.ToString());
        objClsSec.Class_Id = Int32.Parse(ViewState["Class_Id"].ToString());
        objClsSec.Class_Name = ViewState["Class_Name"].ToString();
        objClsSec.Section_Name = ViewState["Section_Name"].ToString();
        if (rdApproval.SelectedValue == "0")
            objClsSec.RD_Approval = false;
        else
            objClsSec.RD_Approval = true;
        objClsSec.RD_Approval_By = Convert.ToInt32(Session["ContactID"].ToString());
        objClsSec.RD_Approval_On = DateTime.Now;
        string mode = Convert.ToString(ViewState["mode"]);
        if (mode != "Edit")
        {

            AlreadyIn = objClsSec.Student_Conditionally_Promoted_RequestUpdate(objClsSec);
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Record successfully updated.");
                ViewState["dtDetails"] = null;
                BindGrid();
            }

            else
            {
                ImpromptuHelper.ShowPrompt("Record Already exist.");
            }
        }
        btnClose_Click(this, EventArgs.Empty);
        //if (objClsSec.RD_Approval == true)
        //{

        //    string reason = ViewState["ResultStatus"].ToString();
        //    reason = reason.Replace("&amp;#8195;", "&#8195;");
        //    reason = reason.Replace("&amp;#8201;", "&#8201;");
        //    reason = reason.Replace("&amp;#8194;", "&#8194;");
        //    reason = reason.Replace("&lt;br /&gt;", "<br/>");
        //    reason = reason.Replace("&amp;#10006;", "&#10006;");
        //    reason = reason.Replace("&amp;#10004;", "&#10004;");

        //    string strEmailMsg = "Dear Sir,<br><br>";

        //    if (ViewState["dtDetails"] != null)
        //    {
        //        DataTable _dt = (DataTable)ViewState["dtDetails"];
        //        DataRow[] foundRows;
        //        foundRows = _dt.Select("Student_Id = '" + objClsSec.Student_No.ToString() + "'");

        //        strEmailMsg += "<b>Date : </b>" + String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now) + "<br/><br/>";
        //        strEmailMsg += "<b>Campus : </b>" + foundRows[0]["Center_Name"] + "<br/><br/><br/>";

        //        strEmailMsg += "<b>" + objClsSec.Student_No + "-"
        //            + objClsSec.StudentName + "</b> of <b>" + ViewState["Class_Name"].ToString() + "-" +
        //            ViewState["Section_Name"].ToString() + "</b> has been discretionarily promoted by Regional Director of "
        //            + ddl_region.SelectedItem.Text + ".";

        //        strEmailMsg += "<br/><br/>He/She was detained due to following reason(s) <br/><br/> <div>" + reason + "</div>";
        //        strEmailMsg += "<br/><br/><b>Days Attended</b>: " + ViewState["Days"].ToString() + "";
        //        strEmailMsg += "<br/><br/><b> School Head Remarks: </b>" + foundRows[0]["Remarks"].ToString();
        //        strEmailMsg += "<br/><br/><b> Regional Director Approval Remarks: </b>" + objClsSec.RD_Remarks;
        //        strEmailMsg += "<br><br><b>Note:</b><i>This is a system generated message. Please do not reply to this message.</i>";
        //        BLLSendEmail objEmail = new BLLSendEmail();

        //        objEmail.SendEmail(1, "Disrcretionary Promotion Alert", strEmailMsg, "Discretionary Promotion");
        //    }

        //}
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
                            strFilter = " Convert([RD_Approval], 'System.String')='2'";
                            break;
                        }

                    case 2: //Submitted
                        {
                            strFilter = " Convert([RD_Approval], 'System.String')='1'";
                            break;
                        }

                    case 3: // Processed by RD
                        {
                            strFilter = " Convert([RD_Approval], 'System.String')='0'";
                            break;
                        }

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


    protected void btnPending_Click(object sender, EventArgs e)
    {
        ResetFilter();
        ApplyFilter(1);
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        try
        {
            Button btnEdit = (Button)sender;

            string url = "";
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gv_details.SelectedIndex = gvr.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Class_Id = Convert.ToInt32(gvr.Cells[2].Text);
            obj.Student_Id = Convert.ToInt32(btnEdit.CommandArgument);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.Section_Id = Convert.ToInt32(gvr.Cells[8].Text);
            obj.TermGroup_Id = 2; //Students are detained after final term 
            CheckBox ChkSys = (CheckBox)gvr.FindControl("ChkSys");
            obj.isBorder = ChkSys.Checked;
            


            if (obj.Session_Id==12)
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
}