using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_Class_Change_Request_Approval : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLClass_Change_Request objreq = new BLLClass_Change_Request();
    BLLClass_Change_Reasons objreason = new BLLClass_Change_Reasons();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // ======== Page Access Settings ========================//
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

                //  ====== End Page Access settings ======================//
                loadRegions();
                if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level   Aims.ho
                {
                    ddlCenter.Enabled = true;
                    ddlRegion.Enabled = true;
                    btnChanged.Visible = true;


                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO / RD Level
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = true;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);


                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 4)//CO Level Or Campus Head
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = false;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlCenter.SelectedValue = Session["cId"].ToString();
                    ddlCenter_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 10)// NO level 
                {
                    ddlRegion.Enabled = false;
                    ddlCenter.Enabled = true;
                    ddlRegion.SelectedValue = Session["RegionID"].ToString();
                    ddlRegion_SelectedIndexChanged(this, EventArgs.Empty);
                }

                BindStudentGrid();
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
            if (Session["UserLevel_Id"].ToString() == "10") // for Network Heads only 
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");
            }
            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) >= 2 && Convert.ToInt32(Session["UserLevel_Id"].ToString()) <= 5)
            //for HO,RO ,CO 
            {
                BLLCenter objCen = new BLLCenter();

                objCen.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue.ToString());

                DataTable dt = new DataTable();
                dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, ddlCenter, "Center_Id", "Center_Name");
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
            ViewState["MainOrgId"] = 1;
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddlRegion, "Region_Id", "Region_Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void FillClass()
    {
        try
        {
            BLLClass_Center obj = new BLLClass_Center();
            DataTable dt = null;
            int center = Convert.ToInt32(ddlCenter.SelectedValue);
            //if (ViewState["ClassData"] == null)
                dt = obj.Class_CenterFetch(center);
            //else
            //    dt = (DataTable)ViewState["ClassData"];
            ViewState["ClassData"] = dt;
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Class_Name");
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
            loadCenter();
            ResetFilter();
            ApplyFilter(1, ddlRegion.SelectedValue);
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
            FillClass();
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
            ResetFilter();
            ApplyFilter(3, ddlClass.SelectedValue);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvStudent_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStudent.Rows.Count > 0)
            {
                gvStudent.UseAccessibleHeader = false;
                gvStudent.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindStudentGrid()
    {
        try
        {
            if (ddlRegion.SelectedIndex > 0)
                objreq.Region_Id = Convert.ToInt32(ddlRegion.SelectedValue);
            else
                objreq.Region_Id = 0;
            //mz
            if (ddlCenter.SelectedIndex > 0)
                objreq.Center_Id = Convert.ToInt32(ddlCenter.SelectedValue);
            else
                objreq.Center_Id = 0;
            if (ddlClass.SelectedIndex > 0)
                objreq.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            else
                objreq.Class_Id = 0;
            //----
            objreq.Approved_By = Convert.ToInt32(Session["ContactID"].ToString());
            DataTable dt = new DataTable();
            if (ViewState["Students"] != null)
                dt = (DataTable)ViewState["Students"];
            else
                dt = objreq.Class_Change_RequestFetchforApproval(objreq);
            ViewState["Students"] = dt;
            if (dt.Rows.Count > 0)
                divStudentTitle.Visible = true;
            else
                divStudentTitle.Visible = false;

            gvStudent.DataSource = dt;
            gvStudent.DataBind();

            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level
            {
                gvStudent.Columns[8].Visible = false;
                gvStudent.Columns[10].Visible = true;
                gvStudent.Columns[11].Visible = true;
            }
            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 3)//RO /RD Level
            {
                gvStudent.Columns[8].Visible = true;
                gvStudent.Columns[10].Visible = false;
                gvStudent.Columns[11].Visible = false; //delete button
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnDecisionApprove_Click(object sender, EventArgs e)
    {
        try
        {
            //Work here
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = gvr.RowIndex;
            objreq.CCReq_Id = Convert.ToInt32(btn.CommandArgument);

            objreq.isApproved = true;

            objreq.Approved_By = Convert.ToInt32(Session["ContactID"].ToString());
            int k = objreq.Class_Change_RequestUpdate(objreq);
            if (k == 1)
            {
                /*As per Email of Mr. Aqeel After Approval of RD Class will be changed Automatically*/
                objreq.Class_Change_RequestAction(objreq);

                ViewState["Students"] = null;
                BindStudentGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDecisionDisapprove_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = gvr.RowIndex;
            objreq.CCReq_Id = Convert.ToInt32(btn.CommandArgument);

            objreq.isApproved = false;

            objreq.Approved_By = Convert.ToInt32(Session["ContactID"].ToString());
            int k = objreq.Class_Change_RequestUpdate(objreq);
            if (k == 1)
            {
                ViewState["Students"] = null;
                BindStudentGrid();
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
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = gvr.RowIndex;
            objreq.CCReq_Id = Convert.ToInt32(btn.CommandArgument);
            objreq.Class_Change_RequestDelete(objreq);
            ViewState["Students"] = null;
            BindStudentGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAction_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = gvr.RowIndex;
            objreq.CCReq_Id = Convert.ToInt32(btn.CommandArgument);
            objreq.Class_Change_RequestAction(objreq);
            ViewState["Students"] = null;
            BindStudentGrid();
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
            if (ViewState["Students"] != null)
            {
                DataTable dt = (DataTable)ViewState["Students"];
                DataView dv = dt.DefaultView;
                string strFilter = "";

                switch (_FilterCondition)
                {
                    case 1: // Filter by Region_Id 
                        if (!string.IsNullOrEmpty(value) && value != "0")
                        {
                            strFilter = "Convert([Region_Id], 'System.String')='" + value + "'";
                        }
                        break;

                    case 2: // Filter by Center_Id 
                        if (!string.IsNullOrEmpty(value) && value != "0")
                        {
                            strFilter = "Convert([Center_Id], 'System.String')='" + value + "'";
                        }
                        break;

                    case 3: // Filter by Center_Id and Class_Id 
                        if (!string.IsNullOrEmpty(value) && value != "0")
                        {
                            strFilter = "Convert([Center_Id], 'System.String')='" + ddlCenter.SelectedValue + "'";
                            strFilter += " and Convert([FromClass_Id], 'System.String')='" + value + "'";
                        }
                        break;

                    case 4: // Filter pending, approved, unapproved
                        
                        {
                            strFilter += "Convert([isApproved], 'System.String')='" + value + "'";
                        }
                        break;

                    case 5: // Filter by Student_Id
                     
                        {
                            strFilter += "Convert([Student_Id], 'System.String')='" + value + "'";
                        }
                        break;

                    case 6: // Filter by isApproved and isProcessed
                       
                        {
                            strFilter += "Convert([isApproved], 'System.String')='1' and Convert([isProccessed], 'System.String')='" + value + "'";
                        }
                        break;

                    case 0: // Show all data
                        strFilter = string.Empty; // Clear the filter
                        break;

                    default:
                        // Handle other cases or set a default filter if needed
                        break;
                }
                dv.RowFilter = strFilter;
                gvStudent.DataSource = dv;
                gvStudent.DataBind();
                gvStudent.SelectedIndex = -1;

                ViewState["Students"] = null;
             
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    //protected void ApplyFilter(int _FilterCondition, string value)
    //{
    //    try
    //    {

    //        if (ViewState["Students"] != null)
    //        {
    //            DataTable dt = (DataTable)ViewState["Students"];
    //            DataView dv;
    //            dv = dt.DefaultView;
    //            string strFilter = "";
    //            switch (_FilterCondition)
    //            {
    //                case 1: //Filter by Region_Id 
    //                    {

    //                        strFilter = " Convert([Region_Id], 'System.String')='" + value + "'";
    //                        break;
    //                    }
    //                case 2: //Filter by Center_Id 
    //                    {

    //                        strFilter = " Convert([Center_Id], 'System.String')='" + value + "'";
    //                        break;
    //                    }

    //                case 3: // Filter Class_Id 
    //                    {
    //                        strFilter = " Convert([Center_Id], 'System.String')='" + ddlCenter.SelectedValue + "'";
    //                        strFilter += " and  Convert([FromClass_Id], 'System.String')='" + value + "'";
    //                        break;
    //                    }
    //                case 4: // Filter pending ,approved, unapproved
    //                    {

    //                        strFilter += "  Convert([isApproved], 'System.String')='" + value + "'";
    //                        break;
    //                    }
    //                case 5: // Filter pending ,approved, unapproved
    //                    {

    //                        strFilter += "  Convert([Student_Id], 'System.String')='" + value + "'";
    //                        break;
    //                    }
    //                case 6: // Filter pending ,approved, unapproved
    //                    {

    //                        strFilter += " Convert([isApproved], 'System.String')='1' and  Convert([isProccessed], 'System.String')='" + value + "'";
    //                        break;
    //                    }
    //            }
    //            dv.RowFilter = strFilter;
    //            gvStudent.DataSource = dv;
    //            gvStudent.DataBind();
    //            gvStudent.SelectedIndex = -1;

    //            ViewState["Students"] = null;

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    private void ResetFilter()
    {
        try
        {
            
            BindStudentGrid();
            gvStudent.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnPending_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            ApplyFilter(4, "2"); //case 4 and 2 pending requests
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
            ApplyFilter(4, "1"); //case 4 and 1 approved requests
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
            ApplyFilter(4, "0"); //case 4 and 0 unapproved requests
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnProcessed_Click(object sender, EventArgs e)
    {

        try
        {
            ResetFilter();
            ApplyFilter(6, "1"); //case 4 and 0 unapproved requests
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlRegion.Items.Clear();
            //ddlRegion.Items.Insert(0, new ListItem("Select", ""));   //2023-0ct-19
            loadRegions();    //2023-19-oct
            ResetFilter();
           

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindReportCardGrid(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = true;
            LinkButton btn = (LinkButton)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            gvStudent.SelectedIndex = r.RowIndex;
            BLLSearchStudent objSer = new BLLSearchStudent();
            objSer.Student_Id = Convert.ToInt32(btn.CommandArgument);
            DataTable dt = objSer.SearchStudentResultCard(objSer);

            ResetFilter();
            ApplyFilter(5, objSer.Student_Id.ToString());
            gvReportCard.DataSource = dt;
            gvReportCard.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void gvReportCard_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvReportCard.Rows.Count > 0)
            {
                gvReportCard.UseAccessibleHeader = false;
                gvReportCard.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "../TCS";
            Button btn = (Button)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            gvReportCard.SelectedIndex = r.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Section_Id = Convert.ToInt32(r.Cells[4].Text); // remove dependency over section id for result
            obj.Student_Id = Convert.ToInt32(r.Cells[0].Text);
            obj.Session_Id = Convert.ToInt32(r.Cells[1].Text);
            obj.Class_Id = Convert.ToInt32(r.Cells[3].Text);
            obj.TermGroup_Id = Convert.ToInt32(r.Cells[2].Text);
            url = url + obj.OpenReport(obj);
            if (!String.IsNullOrEmpty(url))
            {
                //url = "../PresentationLayer/TCS/" + url;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilter();
            btnCancel.Visible = false;
            gvReportCard.DataSource = null;
            gvReportCard.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    //2023-oct-17
    protected void gvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnApproveDeci = (LinkButton)e.Row.FindControl("btnApproveDecision");
            LinkButton btnDisappr = (LinkButton)e.Row.FindControl("btnDisapprove");
            LinkButton btnAct = (LinkButton)e.Row.FindControl("btnAction");
            LinkButton btnDele = (LinkButton)e.Row.FindControl("btnDelete");

            if (Convert.ToInt32(Session["UserLevel_Id"].ToString()) == 2)//HO Level   Aims.ho
            {
                btnApproveDeci.Visible = false;
                btnDisappr.Visible = false;
                btnAct.Visible = false;
                btnDele.Visible = false;

            }
        }
    }
}