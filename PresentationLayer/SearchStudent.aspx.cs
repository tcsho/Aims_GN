using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI;
using System.IO;
using System.Configuration;
using System.Net.Http;
using AngleSharp.Io;
using System.Web.Http.Results;
using AjaxControlToolkit;
public partial class PresentationLayer_SearchStudent : System.Web.UI.Page
{
    private int windowWidth = 5;
    DALBase objBase = new DALBase();
    int UL_ID;
    BLLSearchStudent objSer = new BLLSearchStudent();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());

            if (!Page.IsPostBack)
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.but_Export);
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

                //but_page_last.Visible = false;
                //but_page_First.Visible = false;
                ViewState["tMood"] = "check";

                #region Filling lists
                DALBase oDALBase = new DALBase();
                DataSet ods = new DataSet();
                ods = null;

                ods = oDALBase.get_Gender();

                DataTable dt = ods.Tables[0];

                objBase.FillDropDown(dt, list_gender, "Gender_Id", "Gender");

                BLLRegion oDALRegion = new BLLRegion();

                oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
                dt = oDALRegion.RegionFetch(oDALRegion);

                objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");


                BLLStudent_Status objSS = new BLLStudent_Status();
                dt = objSS.Student_StatusFetch(objSS);
                objBase.FillDropDown(dt, list_studentStatus, "student_status_Id", "student_status");


                if (Convert.ToBoolean(row["Center"].ToString()) != true)
                {
                    BLLClass objCS = new BLLClass();
                    objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                    dt = objCS.ClassFetch(objCS);
                }
                else
                {
                    BLLClass_Center objCC = new BLLClass_Center();

                    DataRow rrow = (DataRow)Session["rightsRow"];
                    objCC.Center_ID = Convert.ToInt32(rrow["Center_Id"].ToString());
                    dt = objCC.Class_CenterFetch(objCC);
                }
                objBase.FillDropDown(dt, list_class, "Class_Id", "Class_Name");

                #endregion

                int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
                if (UserLevel_ID == 1 || UserLevel_ID == 2) //Head Office
                { }
                else if (UserLevel_ID == 3) //Regional Officer
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);
                }
                else if (UserLevel_ID == 4) //Campus Officer
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    list_center.SelectedValue = row["Center_Id"].ToString();
                    list_center.Enabled = false;
                    list_center_SelectedIndexChanged(sender, e);

                    lab_section.Visible = true;
                    list_section.Visible = true;
                    list_section.Items.Insert(0, new ListItem("Select", ""));

                }
                else if (UserLevel_ID == 10) //Network
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    lab_section.Visible = true;
                    list_section.Visible = true;
                    list_section.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (UserLevel_ID == 5) //Teacher
                {
                    list_region.SelectedValue = row["Region_Id"].ToString();
                    list_region.Enabled = false;
                    list_region_SelectedIndexChanged(sender, e);

                    list_center.SelectedValue = row["Center_Id"].ToString();
                    list_center.Enabled = false;
                    list_center_SelectedIndexChanged(sender, e);

                    list_teacher.SelectedValue = row["User_Id"].ToString();
                    list_teacher.Enabled = false;

                    lab_section.Visible = true;
                    list_section.Visible = true;
                    list_section.Items.Insert(0, new ListItem("Select", ""));

                    tblSearch.Visible = false;
                    trSearchCriteria.Visible = false;
                    but_search_Click(this, EventArgs.Empty);

                }

                if (list_center.Enabled == false)
                {
                    lab_center.Text = list_center.SelectedItem.Text;
                    list_center.Visible = false;
                }
                if (list_region.Enabled == false)
                {
                    lab_region.Text = list_region.SelectedItem.Text;
                    list_region.Visible = false;
                }
                if (list_teacher.Enabled == false)
                {
                    lab_teacher.Text = list_teacher.SelectedItem.Text;
                    list_teacher.Visible = false;
                }


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            dv_details.DataSource = null;
            dv_details.DataBind();
            ViewState["window_end"] = 5;
            ViewState["page_number"] = 1;
            BindGrid();
            dv_details.DataSource = null;
            dv_details.DataBind();
            trresultSummary.Visible = false;
            btnCancel.Visible = false;
            trReportCard.Visible = false;
            trSubjectList.Visible = false;
            gvReportCard.DataSource = null;
            gvReportCard.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void dg_student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_student.Rows.Count > 0)
            {
                dg_student.UseAccessibleHeader = false;
                dg_student.HeaderRow.TableSection = TableRowSection.TableHeader;

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
    private void BindGrid()
    {
        try
        {



            objSer.First_Name = text_firstName.Text;
            objSer.Last_Name = text_lastName.Text;
            objSer.Middle_Name = text_middleName.Text;
            objSer.Date_Of_Birth = text_dateOfBirth.Text;
            objSer.Gender_Id = list_gender.SelectedValue;
            objSer.Student_No = text_studentNo.Text;
            objSer.Region_Id = list_region.SelectedValue;
            objSer.Student_Status_Id = list_studentStatus.SelectedValue;
            objSer.Center_Id = list_center.SelectedValue;
            objSer.Grade_Id = list_class.SelectedValue;
            objSer.Section_Id = list_section.SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = list_teacher.SelectedValue;
            DataTable dt = new DataTable();
            //DataTable dt = objSer.SearchStudentFetchCount(objSer);
            //if (dt.Rows.Count > 0)
            //{
            //    int total = Convert.ToInt32(dt.Rows[0]["StudenCount"].ToString());
            //    trSearch.Visible = true;
            //    ViewState["total"] = total;

            //    int pageNumber = Int32.Parse(ViewState["page_number"].ToString());
            //    pageNumber = pageNumber - 1;
            //    pageNumber = pageNumber * dg_student.PageSize;

            //    pageNumber = pageNumber + 1;

            //    int startIndex = pageNumber;
            //    //int endIndex = startIndex + dg_student.PageSize - 1;
            //    int endIndex = total;

            objSer.First_Name = text_firstName.Text;
            objSer.Last_Name = text_lastName.Text;
            objSer.Middle_Name = text_middleName.Text;
            objSer.Date_Of_Birth = text_dateOfBirth.Text;
            objSer.Gender_Id = list_gender.SelectedValue;
            objSer.Student_No = text_studentNo.Text;
            objSer.Region_Id = list_region.SelectedValue;
            objSer.Student_Status_Id = list_studentStatus.SelectedValue;
            objSer.Center_Id = list_center.SelectedValue;
            objSer.Grade_Id = list_class.SelectedValue;
            objSer.Section_Id = list_section.SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = list_teacher.SelectedValue;
            objSer.EndIndex = Session["isClassTeacher"].ToString();
            objSer.StartIndex = "";


            dt = objSer.SearchStudentFetch(objSer);

            if (dt.Rows.Count == 0)
            {
                trSearch.Visible = false;
            }
            else
            {
                dg_student.DataSource = dt;
                ViewState["studentDT"] = dt;

                DataRow row = (DataRow)Session["rightsRow"];
                if (list_studentStatus.SelectedValue == "5" || list_studentStatus.SelectedIndex == 0)
                    dg_student.Columns[15].Visible = true;
                else
                    dg_student.Columns[15].Visible = false;

                if (Session["isClassTeacher"].ToString() == "0" && UL_ID == 5)
                    dg_student.Columns[15].Visible = false;
                else
                    dg_student.Columns[15].Visible = true;
            }

            dg_student.DataBind();
        }

        //}
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnCancelHistory_Click(object sender, EventArgs e)
    {
        try
        {
            ResetFilterBifurcation();
            trReportCard.Visible = false;
            trSubjectList.Visible = false;
            gvReportCard.DataSource = null;
            gvReportCard.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindReportCardGrid(object sender, EventArgs e)
    {

        trSubjectList.Visible = false;
        try
        {
            ViewState["ResultHistory"] = null;
            LinkButton btn = (LinkButton)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            dg_student.SelectedIndex = r.RowIndex;
            BLLSearchStudent objSer = new BLLSearchStudent();
            objSer.Student_Id = Convert.ToInt32(btn.CommandArgument);
            DataTable dt = objSer.SearchStudentResultCard(objSer);
            ViewState["ResultHistory"] = dt;
            ApplyFilterBifurcation(1, objSer.Student_Id);
            if (dt.Rows.Count > 0)
            {
                gvReportCard.DataSource = dt;
                gvReportCard.DataBind();
                if (Session["isClassTeacher"].ToString() == "1" || Session["UserType_Id"].ToString() == "1")
                {
                    gvReportCard.Columns[10].Visible = false;
                }
            }
            gvReportCard.DataBind();
            trReportCard.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void BindSubjectGrid(object sender, EventArgs e)
    {
        trReportCard.Visible = false;

        try
        {
            ViewState["SubjectList"] = null;
            LinkButton btn = (LinkButton)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            dg_student.SelectedIndex = r.RowIndex;
            BLLSearchStudent objSer = new BLLSearchStudent();
            objSer.Student_Id = Convert.ToInt32(btn.CommandArgument);
            objSer.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
            DataTable dt = objSer.SearchStudentSubjectData(objSer);

            ViewState["SubjectList"] = dt;

            ApplyFilterBifurcation(1, objSer.Student_Id);

            if (dt.Rows.Count > 0)
            {
                gvSubjectList.DataSource = dt;
                gvSubjectList.DataBind();
                //if (Session["isClassTeacher"].ToString() == "1" || Session["UserType_Id"].ToString() == "1")
                //{
                //    gvReportCard.Columns[10].Visible = false;
                //}
            }

            trSubjectList.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void dg_student_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "name")
            {
                int ind = Int32.Parse((string)e.CommandArgument);

                Session["studentId"] = dg_student.DataKeys[ind].Value;
                //                Response.Redirect("StudentInfo.aspx", false);
            }
            else if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in dg_student.Rows)
                {
                    cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if (cb.Enabled == true)
                    {
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
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_student_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dg_student.PageIndex = e.NewPageIndex;
            dg_student.DataSource = (DataTable)ViewState["studentDT"];
            dg_student.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void dg_student_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRow userrow = (DataRow)Session["rightsRow"];

            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox ch = (CheckBox)row.Cells[13].Controls[1];
                if (row.Cells[9].Text != "Applicant")
                {
                    ch.Enabled = false;
                    ch.Checked = true;
                }
                if (!Convert.ToBoolean(userrow["Center"].ToString()))
                {
                    ch.Enabled = false;
                }
                
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_region.SelectedValue == "")
            {
                list_center.Items.Clear();
                list_center.Items.Insert(0, new ListItem("Select", ""));
            }
            if (UL_ID == 10)//Load Network specifc centers
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, list_center, "Center_Id", "Center_Name");
            }
            else
            {

                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Int32.Parse(list_region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void list_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_center.SelectedValue == "")
            {
                list_teacher.Items.Clear();
                list_teacher.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                BLLSection_Subject objSecSub = new BLLSection_Subject();

                objSecSub.Center_Id = Int32.Parse(list_center.SelectedValue.ToString());
                DataTable dt = objSecSub.Section_SubjectSelectTeacherByCenter_Id(objSecSub);
                objBase.FillDropDown(dt, list_teacher, "user_Id", "name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_pager_Click1(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;


            GotoPage(lb);


            BindGrid();



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_pager_1_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;


            GotoWindowFirstPage(lb);

            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_pager_5_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;


            GotoWindowLastPage(lb);


            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void doPaging()
    {
        try
        {
            int total = Int32.Parse(ViewState["total"].ToString());

            ContentPlaceHolder cph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            LinkButton lb;

            if (total == 0 || total < dg_student.PageSize)
            {
                //but_page_First.Visible = false;
                //but_page_last.Visible = false;
                for (int x = 1; x <= windowWidth; x++)
                {
                    lb = (LinkButton)cph.FindControl("but_pager_" + x.ToString());
                    lb.Visible = false;

                }

            }
            else
            {
                for (int x = 1; x <= windowWidth; x++)
                {
                    lb = (LinkButton)cph.FindControl("but_pager_" + x.ToString());
                    lb.Visible = true;
                    lb.Font.Bold = false;
                    lb.Font.Underline = false;

                }



                int windowEnd = Int32.Parse(ViewState["window_end"].ToString());
                int windowStart = windowEnd - windowWidth + 1;

                int y = 1;
                for (int x = windowStart; x <= windowEnd; x++, y++)
                {
                    lb = (LinkButton)cph.FindControl("but_pager_" + y.ToString());
                    lb.CommandArgument = x.ToString();
                    lb.Text = x.ToString();

                }
                int endPage = (int)Math.Ceiling((float)total / (float)dg_student.PageSize);
                if (endPage < windowEnd)
                {
                    int endbuttonIndex = endPage - windowStart + 1;
                    for (int x = endbuttonIndex + 1; x <= windowWidth; x++)
                    {
                        lb = (LinkButton)cph.FindControl("but_pager_" + x.ToString());
                        lb.Visible = false;

                    }
                }

                int pageNumber = Int32.Parse(ViewState["page_number"].ToString());

                int currentButtonIndex = pageNumber - windowStart + 1;
                lb = (LinkButton)cph.FindControl("but_pager_" + currentButtonIndex.ToString());
                lb.Font.Bold = true;
                lb.Font.Underline = true;

            }

            //if (total <= 200)
            //but_page_last.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void GotoPage(LinkButton lb)
    {

        try
        {

            ViewState["page_number"] = lb.CommandArgument;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void GotoWindowFirstPage(LinkButton lb)
    {
        try
        {
            if (lb.CommandArgument != "1")
            {
                MoveWindowBack();

                ViewState["page_number"] = lb.CommandArgument;
            }
            else
                ViewState["page_number"] = 1;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void GotoWindowLastPage(LinkButton lb)
    {
        try
        {
            int totalRecords = Int32.Parse(ViewState["total"].ToString());

            ViewState["page_number"] = lb.CommandArgument;

            int pageNumber = Int32.Parse(ViewState["page_number"].ToString());
            if (pageNumber != (int)Math.Ceiling((float)totalRecords / (float)dg_student.PageSize))
            {
                MoveWindowForward();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    public void MoveWindowForward()
    {
        try
        {
            int windowEnd = Int32.Parse(ViewState["window_end"].ToString());

            windowEnd = windowWidth + windowEnd - 1;
            ViewState["window_end"] = windowEnd;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public void MoveWindowBack()
    {
        try
        {
            int windowEnd = Int32.Parse(ViewState["window_end"].ToString());

            windowEnd = windowEnd - windowWidth + 1;

            if (windowEnd < windowWidth)
                windowEnd = windowWidth;

            ViewState["window_end"] = windowEnd;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_Export_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            BLLSearchStudent objSer = new BLLSearchStudent();

            objSer.First_Name = text_firstName.Text;
            objSer.Last_Name = text_lastName.Text;
            objSer.Middle_Name = text_middleName.Text;
            objSer.Date_Of_Birth = text_dateOfBirth.Text;
            objSer.Gender_Id = list_gender.SelectedValue;
            objSer.Student_No = text_studentNo.Text;
            objSer.Region_Id = list_region.SelectedValue;
            objSer.Student_Status_Id = list_studentStatus.SelectedValue;
            objSer.Center_Id = list_center.SelectedValue;
            objSer.Grade_Id = list_class.SelectedValue;
            objSer.Section_Id = list_section.SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = list_teacher.SelectedValue;
            dt = objSer.SearchStudentFetchExport(objSer);
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Students");


            }
            else
            {
                ImpromptuHelper.ShowPrompt("There Are No Search Results To Export!");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public void ExportToSpreadsheet(DataTable table, string name)
    {


        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + "\t");

        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(",", string.Empty) + "\t");
            }

            context.Response.Write(Environment.NewLine);
        }

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename = " + name + ".xls");



        context.Response.Flush();
        context.Response.SuppressContent = true;
        context.ApplicationInstance.CompleteRequest();


        ////////////context.Response.End();



    }

    protected void but_page_First_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["window_end"] = 5;
            ViewState["page_number"] = 1;
            BindGrid();



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void but_page_last_Click(object sender, EventArgs e)
    {
        try
        {
            int totalRecords = Convert.ToInt32(ViewState["total"].ToString());

            ViewState["page_number"] = Convert.ToInt32(Math.Ceiling(((float)totalRecords / (float)dg_student.PageSize)));
            ViewState["window_end"] = Convert.ToInt32(ViewState["page_number"]);

            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void list_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            if (Convert.ToBoolean(row["Center"].ToString()) == true || Convert.ToBoolean(row["Teacher"].ToString()) == true)
            {

                if (list_class.SelectedValue == "")
                {
                    list_section.Items.Clear();
                    list_section.Items.Insert(0, new ListItem("Select", ""));
                }
                else
                {
                    BLLSection objSec = new BLLSection();

                    objSec.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    objSec.Class_Id = Int32.Parse(list_class.SelectedValue);
                    DataTable dt = objSec.SectionFetchByClassCenter(objSec);
                    objBase.FillDropDown(dt, list_section, "section_Id", "section_name");

                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void btnSummary_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = true;
            btnCancelHistory.Visible = false;
            int term = 0;
            Button btn = (Button)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            dg_student.SelectedIndex = r.RowIndex;
            BLLSearchStudent objSer = new BLLSearchStudent();
            //if(Convert.ToInt32(r.Cells[3].Text)==1)
            //{
            //    ImpromptuHelper.ShowPrompt("The Student is not assigned!");
            //    return;
            //}
            objSer.Section_ID = 0;
            objSer.Student_Id = Convert.ToInt32(r.Cells[0].Text);
            objSer.Session_Id = Convert.ToInt32(r.Cells[1].Text);
            term = Convert.ToInt32(r.Cells[2].Text);

            BindGridSummary(objSer.Section_ID, objSer.Student_Id, objSer.Session_Id, term);
            ResetFilterResultCard();
            ApplyFilterResultCard(1, objSer.Session_Id, term);
            //trReportCard.Visible = false;
            //gvReportCard.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindGridSummary(int section, int studentid, int session, int term)
    {

        try
        {
            BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

            DataTable dtsub = new DataTable();
            objClsSec.Section_Id = Convert.ToInt32(section);
            objClsSec.Evaluation_Criteria_Type_Id = term;
            objClsSec.Session_Id = session;
            objClsSec.Student_Id = Convert.ToInt32(studentid);
            dtsub = objClsSec.Result_ByEmployeeCenterWise(objClsSec);
            ViewState["Table"] = dtsub;
            if (dtsub.Rows.Count > 0)
            {
                trresultSummary.Visible = true;
                dv_details.DataSource = dtsub;
                dv_details.DataBind();
            }



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancelHistory.Visible = true;
            btnCancel.Visible = false;
            ResetFilterResultCard();
            dv_details.DataSource = null;
            dv_details.DataBind();
            trresultSummary.Visible = false;
            trReportCard.Visible = true;
            gvReportCard.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyFilterBifurcation(int _FilterCondition, int value)
    {
        try
        {

            if (ViewState["studentDT"] != null)
            {
                DataTable dt = (DataTable)ViewState["studentDT"];
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: //filter selected Student
                        {

                            strFilter = " Convert([Student_No], 'System.String')='" + value + "'";
                            break;
                        }
                }
                dv.RowFilter = strFilter;
                dg_student.DataSource = dv;
                dg_student.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilterBifurcation()
    {
        try
        {
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ApplyFilterResultCard(int _FilterCondition, int Session_Id, int TermGroup_Id)
    {
        try
        {

            if (ViewState["ResultHistory"] != null)
            {
                DataTable dtactual = (DataTable)ViewState["ResultHistory"];
                DataTable dt = dtactual;
                DataView dv;
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: //filter selected Student
                        {

                            strFilter = " Convert([Session_Id], 'System.String')='" + Session_Id + "' ";
                            strFilter = strFilter + "and  Convert([TermGroup_Id], 'System.String')='" + TermGroup_Id + "' ";
                            break;
                        }
                }
                dv.RowFilter = strFilter;
                gvReportCard.DataSource = dv;
                gvReportCard.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilterResultCard()
    {
        try
        {
            if (ViewState["ResultHistory"] != null)
                gvReportCard.DataSource = (DataTable)ViewState["ResultHistory"];
            gvReportCard.DataBind();
            /// BindReportCardGrid(this, EventArgs.Empty);
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
            Button btn = (Button)(sender);
            GridViewRow r = (GridViewRow)btn.NamingContainer;
            dg_student.SelectedIndex = r.RowIndex;
            ViewReport obj = new ViewReport();
            obj.Section_Id = Convert.ToInt32(r.Cells[4].Text); // remove dependency over section id for result
            obj.Student_Id = Convert.ToInt32(r.Cells[0].Text);
            obj.Session_Id = Convert.ToInt32(r.Cells[1].Text);
            obj.Class_Id = Convert.ToInt32(r.Cells[3].Text);
            obj.TermGroup_Id = Convert.ToInt32(r.Cells[2].Text);

            string url = "";

            if (obj.Class_Id < 7)
            {
                //if (obj.Session_Id == 12)
                //{
                //    url = url;

                //}
                //else
                //{
                //    url = "../PresentationLayer/TCS";
                //}
                url = "../PresentationLayer/TCS/";
                url = url + obj.OpenReport(obj);

                if (!String.IsNullOrEmpty(url))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                }
            }
            else
            {
                if (obj.Session_Id >= 12)
                {
                    url = url;

                }
                else
                {
                    url = "../PresentationLayer";
                }
                //--------------------------------------------------------------------------------------------------------//
                //-------------------------------Modified By Huzaifa & Parvaiz 08-03-2022---------------------------------//
                //--------------------------------------------------------------------------------------------------------//

                if (obj.Class_Id > 13 && obj.Class_Id <= 20)
                {
                    if ((obj.TermGroup_Id == 1 || obj.TermGroup_Id == 2) && (obj.Class_Id == 14 || obj.Class_Id == 15 || obj.Class_Id == 19 || obj.Class_Id == 20)) //goto New Report
                    {
                        url = "";
                    }
                    else if (obj.TermGroup_Id == 2 || (obj.Class_Id == 19 || obj.Class_Id == 20)) //goto Old Report
                    {
                        //url = "TCS/";     //2025-02-18
                        url = "";
                    }
                }
                //--------------------------------------------------------------------------------------------------------//
                url = url + obj.OpenReport(obj);

                if (!String.IsNullOrEmpty(url))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    //protected void ViewReport(int termGroup_Id, int section, int student, int session, int class_id)
    //{

    //    try
    //    {

    //        bool _isok = false;
    //        string url = "";
    //        string Qs = "?sc=000" + section.ToString() + "000" + session +
    //            termGroup_Id.ToString() + "&st=" + student;


    //        if (class_id < 7) //For EYE reports
    //        {

    //            if (termGroup_Id == 1)
    //            {
    //                if (session <= 7)
    //                {
    //                    url = "TCS_HTML_F_EYE.aspx" + Qs;
    //                }
    //                else
    //                {
    //                    url = "TCS_HTML_F_EYE_201617.aspx" + Qs;
    //                }
    //            }
    //            else if (termGroup_Id == 2)
    //            {

    //                url = "TCS_HTML_S_EYE_201617.aspx" + Qs;
    //            }
    //            _isok = true;

    //        }
    //        if (class_id >= 7 && class_id <= 12) // Class 3-8
    //        {
    //            if (termGroup_Id == 1)
    //            {
    //                if (session <= 7)
    //                {
    //                    url = "TCS_HTML_F_3_8.aspx" + Qs;

    //                }
    //                else
    //                    url = "TCS_HTML_F_3_8_201617.aspx" + Qs;

    //            }

    //            else if (termGroup_Id == 2)
    //            {

    //                url = "TCS_HTML_S_3_8_201617.aspx" + Qs;
    //            }

    //            _isok = true;

    //        }

    //        else if (class_id >= 13 && class_id <= 15) // O Level
    //        {

    //            if (termGroup_Id == 1)
    //            {
    //                if (session <= 7)
    //                {
    //                    url = "TCS_HTML_F_O_A.aspx" + Qs;
    //                }
    //                else
    //                {
    //                    url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //                }
    //            }
    //            else
    //            {
    //                /*Without Border*/
    //                if (session <= 7)
    //                {
    //                    url = "TCS_HTML_F_O_A.aspx" + Qs;

    //                }
    //                else
    //                {

    //                    url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //                }
    //            }


    //            if (termGroup_Id == 2)
    //            {
    //                if (class_id == 13) //Second Term Class 9
    //                {

    //                    /*Without Border*/
    //                    url = "TCS_HTML_S_9_201617.aspx" + Qs;
    //                }

    //                else
    //                {
    //                    /*Without Border*/
    //                    url = "TCS_HTML_S_O_A.aspx" + Qs;
    //                }
    //            }
    //            _isok = true;
    //        }
    //        else if (class_id >= 19 && class_id <= 20) // A Level
    //        {
    //            if (termGroup_Id == 1)
    //            {
    //                url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //            }
    //            else
    //            {
    //                url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
    //            }
    //            if (termGroup_Id == 2)
    //            {
    //                url = "TCS_HTML_S_O_A.aspx" + Qs;
    //            }
    //            _isok = true;
    //        }
    //        if (_isok)
    //        {
    //            url = "../PresentationLayer/TCS/" + url;
    //            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>window.open('" + url + "');</script>", false);

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
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



    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            LinkButton btnEdit = (LinkButton)(sender);
            var StudentId = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["Student_Id"] = StudentId;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvReportCard.SelectedIndex = gvr.RowIndex;

            txtFirstName.Text = gvr.Cells[18].Text == "&nbsp;" ? "" : gvr.Cells[18].Text;
            txtLastName.Text = gvr.Cells[19].Text == "&nbsp;" ? "" : gvr.Cells[19].Text;
            //txtNameUrdu.Text = gvr.Cells[20].Text=="&nbsp;"?"":gvr.Cells[20].Text;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            BLLStudentNameFixedUpsert obj = new BLLStudentNameFixedUpsert();
            int k = 0;
            int StudentId = Convert.ToInt32(ViewState["Student_Id"]);
            obj.Student_Id = Convert.ToInt32(StudentId);
            obj.First_Name = txtFirstName.Text.ToString();
            obj.Last_Name = txtLastName.Text.ToString();
            //obj.NameUrdu = txtNameUrdu.Text.ToString();
            k = obj.StudentNameFixedUpsertUpdate(obj);
            BindGrid();
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Updated Successfuly");
            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPrompt("Inserted Successfuly");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalTest();", true);
        //btnCancel_Click(this, EventArgs.Empty);
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openImageUploadmodal();", true);
            LinkButton btnview = (LinkButton)(sender);
            var StudentId = Convert.ToInt32(btnview.CommandArgument);
            ViewState["StudentId"] = StudentId;
            GridViewRow gvr = (GridViewRow)btnview.NamingContainer;
            gvReportCard.SelectedIndex = gvr.RowIndex;
            txtStdName.Text = gvr.Cells[3].Text == "&nbsp;" ? "" : gvr.Cells[3].Text + " / " + StudentId;
            ViewState["Regionid"] = gvr.Cells[21].Text == "&nbsp;" ? "" : gvr.Cells[21].Text;
            ViewState["Centerid"] = gvr.Cells[22].Text == "&nbsp;" ? "" : gvr.Cells[22].Text;
            ViewState["Classid"] = gvr.Cells[8].Text == "&nbsp;" ? "" : gvr.Cells[8].Text;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    protected void btndocsupload_Click(object sender, EventArgs e)
    {

        DocumentUpload(Convert.ToInt32(ViewState["StudentId"]), ViewState["Regionid"].ToString(), ViewState["Centerid"].ToString(), ViewState["Classid"].ToString());
    }

    private void DocumentUpload(int studentid, string Regionid, string Centerid, string classid)
    {
        HttpPostedFile postedFile;
        if (FileUpload1.HasFile)
        {
            HttpFileCollection uploadedFiles = Request.Files;
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                postedFile = uploadedFiles[i];
                if (postedFile.ContentLength > 1048576)
                {
                    lblerror.ForeColor = System.Drawing.Color.Red;
                    lblerror.Text = "Please check File size is above 1MB....";
                    lblerror.Visible = true;
                    return;
                }
                postedFile = null;
            }

            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                postedFile = uploadedFiles[i];
                string FileName = postedFile.FileName;
                string additionals = "";


                if (1 == 1)
                {


                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName);

                    if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".png")
                    {
                        string regionFolder = Server.MapPath("~\\PresentationLayer\\TCS\\Files\\" + Regionid + "\\");
                        string centerFolder = Path.Combine(regionFolder, Centerid);
                        string classFolder = Path.Combine(centerFolder, classid);

                        if (!Directory.Exists(regionFolder))
                        {
                            Directory.CreateDirectory(regionFolder);
                        }

                        if (!Directory.Exists(centerFolder))
                        {
                            Directory.CreateDirectory(centerFolder);
                        }
                        if (!Directory.Exists(classFolder))
                        {
                            Directory.CreateDirectory(classFolder);
                        }



                        int contentLength = postedFile.ContentLength;
                        byte[] buffer = new byte[contentLength];
                        postedFile.InputStream.Read(buffer, 0, contentLength);
                        string fileName = FileUpload1.PostedFile.FileName.ToString();
                        additionals = DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + Extension.ToLower();
                        // FileStream stream = new FileStream(base.Server.MapPath("~\\PresentationLayer\\TCS\\Files\\" + additionals + "_" + Convert.ToString(studentid) + "_" + FileName), FileMode.Create);
                        FileStream stream = new FileStream(base.Server.MapPath("~\\PresentationLayer\\TCS\\Files\\" + Regionid + "\\" + Centerid + "\\" + classid + "\\" + Convert.ToString(studentid) + "_" + additionals), FileMode.Create);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Close();

                        BLLSearchStudent objblli = new BLLSearchStudent();

                        objblli.Student_Id = studentid;
                        objblli.Image_Path = "~\\PresentationLayer\\TCS\\Files\\" + Regionid + "\\" + Centerid + "\\" + classid + "\\" + Convert.ToString(studentid) + "_" + additionals;
                        objblli.Update_student_Profile_Image_Path(objblli);
                        objblli = null;

                        BindGrid();

                    }
                    else if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".docx" || Extension.ToLower() == ".xlsx" || Extension.ToLower() == ".xls" || Extension.ToLower() == ".pdf")
                    {
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        lblerror.Text = "Only JPEG,JPG,PNG file is allowed to upload....";
                        lblerror.Visible = true;
                        return;

                    }
                    else
                    {
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        lblerror.Text = "File size is above 1MB....";
                        lblerror.Visible = true;
                        return;
                    }
                }


            }
            int a = Convert.ToInt32(ViewState["Us_ID"]);// Updatestatus


        }
        else
        {
            lblerror.ForeColor = System.Drawing.Color.Red;
            lblerror.Text = "There's issue with files please select again....";
            lblerror.Visible = true;
            return;
        }
        lblerror.Visible = false;
    }

    protected void btnAPICall_Click(object sender, EventArgs e)
  {
      // Cast the sender to Button to get the CommandArgument
      Button btn = (Button)sender;
      GridViewRow row = (GridViewRow)btn.NamingContainer;

      // Student_No from CommandArgument
      string studentId = btn.CommandArgument;

      // Class_Id directly from GridView
      string classId = row.Cells[8].Text;


      // Get the Session_Id from the DataTable
      string sessionID = string.Empty;

      DataTable dt = new BLLSession().SessionSelectAll();
      if (dt != null && dt.Rows.Count > 0)
      {
          sessionID = dt.Rows[0]["Session_Id"].ToString();
      }
      
      // API URL construction
      string termID = "2"; // Default value
      if (classId == "12" || classId == "14" || classId == "15" || classId == "92" || classId == "93")
      {
          termID = "1";
      }
      string apiUrl = "http://sdp.csn.edu.pk/student/sdp?studentid=" + studentId + "&termid=" + termID + "&sessionid=" + sessionID;

      ScriptManager.RegisterStartupScript(this, GetType(), "OpenNewTab", "window.open('" + apiUrl + "', '_blank');", true);
  }
    protected void dg_student_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Extract Class_Id from the DataItem
            int classId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Class_Id"));

            // Find the Button control in the current row
            Button btnAPICall = (Button)e.Row.FindControl("btnAPICall");

            // Check and set visibility based on Class_Id
            if (btnAPICall != null)
            {
                btnAPICall.Visible = classId == 12 || classId == 13 || classId == 14 ||
                                     classId == 15 || classId == 91 || classId == 92 || classId == 93;
            }
        }
    }
}
