using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_ClassDetail : System.Web.UI.Page
{
    BLLClass obj = new BLLClass();
    DataTable dtCs = new DataTable();
    DALBase objBase = new DALBase();
    int classID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
        catch (Exception)
        {
        }
        try
        {
            ta_comments.Attributes.Add("OnChange", "javascript:if(this.value.length>=200){var textField=this.value;this.value=textField.substring(0,200);this.blur();alert('Comments Length Maximum Exceeded. Only First 200 Characters Will Be Saved')};");

            if (!Page.IsPostBack)
            {

                //======== Page Access Settings ========================
                //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                // System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                // string sRet = oInfo.Name;

                // if (objBase.ApplyPageAccessSettings(sRet, row.User_Type_Id) == false)
                // {
                //     Session.Abandon();
                //     Response.Redirect("~/login.aspx");
                // }

                //====== End Page Access settings ======================


                ///filling grade
                ///
                int moID = Int32.Parse(Session["MoID"].ToString());
                //list_grade.DataSource = obj.GetClassesByMOId(moID);
                //list_grade.DataTextField = "grade";
                //list_grade.DataValueField = "grade_Id";
                //list_grade.DataBind();
                //list_grade.Items.Insert(0, new ListItem("Select", ""));
                loadRegions();
                FillProgram();



                ViewState["mode"] = "Add";

                if (ViewState["classId"] == null)
                {
                    ViewState["classId"] = Session["classId"];
                    pan_New.Attributes.CssStyle.Add("display", "none");
                }

                //if (ViewState["classId"] != null)
                //{
                //    int classId = Int32.Parse(ViewState["classId"].ToString());
                //    obj.Class_Id = classId;
                //     obj.GetDataByMOId(classId);
                //    //obj.classRow = classDT[0];
                //    //list_grade.SelectedValue = classRow.Grade_Id.ToString();
                //    //list_grade.Enabled = false;
                //    //text_className.Text = classRow.Class_Name;
                //    //if (classRow.IsCommentsNull())
                //    //    ta_comments.Text = "";
                //    //else
                //    //    ta_comments.Text = classRow.Comments;

                //    //if (!classRow.IsProgram_IDNull())
                //    //    //ddlProgram.SelectedValue = classRow.Program_ID.ToString();

                //        pan_New.Attributes.CssStyle.Add("display", "inline");

                //}

                //Session.Remove("classId");


                //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];
                //if (row.Admin == false)
                //{
                //    DisableControls(UpdatePanel1);
                //}

                bindGrid();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void bindGrid()
    {
        int moID = Convert.ToInt32(Session["moID"]);
        DataTable dt = null;

        dt = obj.GetClassesByMOId(moID);

        if (dt.Rows.Count == 0)
        {
            lab_dataStatus.Visible = true;
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        else
        {
            gv_criteriaList.DataSource = dt;
            lab_dataStatus.Visible = false;
            lab_dataStatus.Visible = false;
        }
        gv_criteriaList.DataBind();
        pan_New.Attributes.CssStyle.Add("display", "none");


        ViewState["CriteriaList"] = dt;

    }

    protected void gv_criteriaList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_criteriaList.PageIndex = e.NewPageIndex;
        }
        catch (Exception oException)
        {
            throw oException;
        }
    }

    protected void gv_criteriaList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int classId = 0;
        //int isDeleted = 0;

        //isl_amso.dt_AuthenticateUserRow row = (isl_amso.dt_AuthenticateUserRow)Session["rightsRow"];
        //int moId = row.Main_Organisation_Id;

        try
        {
            classId = Convert.ToInt32(gv_criteriaList.DataKeys[e.RowIndex].Value);
            //ManageGradeTableAdapters.ClassTableAdapter cta = new ManageGradeTableAdapters.ClassTableAdapter();
            //ManageGrade.ClassDataTable dt = null;
            //dt = cta.CheckClassExist(criteriaId, moId);
            //string className = Convert.ToString(dt.Rows[0]["Class_Name"]);
            //if (dt.Rows.Count > 0)
            //{
            //    ImpromptuHelper.ShowPrompt(className + " Already Exists For This Grade, Remove " + className + ".");
            //    return;
            //}
            //else
            //{
            int? nAlreadyIn = null;
            obj.Class_Id = 1;
            obj.ClassDelete(obj);

            //if (nAlreadyIn == 0)
            //    bindGrid();
            if (nAlreadyIn == 1)
                ImpromptuHelper.ShowPrompt("Section(s) exist for class. Remove section(s) first!");
            else if (nAlreadyIn == 2)
                ImpromptuHelper.ShowPrompt("Evaluation criteria(s) exist for class. Remove evaluation criteria(s) first!");
            else if (nAlreadyIn == 3)
                ImpromptuHelper.ShowPrompt("Overall evaluation criteria(s) exist for class. Remove overall evaluation criteria(s) first!");
            else if (nAlreadyIn == 4)
                ImpromptuHelper.ShowPrompt("Percentage evaluation criteria(s) exist for class. Remove percentage evaluation criteria(s) first!");
            else if (nAlreadyIn == 5)
                ImpromptuHelper.ShowPrompt("Activity(s) exist for class. Remove activity(s) first!");
            else if (nAlreadyIn == 6)
                ImpromptuHelper.ShowPrompt("Result Grade(s) exist for class. Remove Result Grade(s) first!");
            else if (nAlreadyIn == 0)
            {
                bindGrid();
                ImpromptuHelper.ShowPrompt("Class deleted successfully.");
            }
            //}
        }
        //catch (System.Data.SqlClient.SqlException ex)
        //{
        //    ImpromptuHelper.ShowPrompt("Student already assigned to the section.");
        //}
        catch (Exception oException)
        {
            Session["error"] = oException.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            //throw oException;
        }
        // grdGroups.Rows[e.RowIndex].Cells[1].Text.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", Convert.ToString('"')), Session.SessionID);
    }

    protected void gv_criteriaList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ib = (ImageButton)e.Row.FindControl("btnDelete");
                ib.Attributes.Add("onclick", "javascript:return " +
                "confirm('Are you sure you want to delete this record?') ");
            }
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gv_criteriaList_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            //DataSet personnelList = personnelBO.GetPersonnelList();
            //personnelList.Tables[0].DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();
            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            //grdPersonnelInfo.DataSource = personnelList.Tables[0];
            //grdPersonnelInfo.DataBind();


        }
        catch (Exception oException)
        {
            throw oException;
        }
    }

    protected void gv_criteriaList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            if (gv_criteriaList.Rows[e.NewSelectedIndex].Cells[0].Text != "No data exists")
            {
                //text_grade.ReadOnly = true;
                //list_grade.SelectedValue = gv_criteriaList.DataKeys[e.NewSelectedIndex].Values[1].ToString();
                //list_grade.Enabled = false;

                text_className.Text = gv_criteriaList.Rows[e.NewSelectedIndex].Cells[3].Text;

                ta_comments.Text = gv_criteriaList.Rows[e.NewSelectedIndex].Cells[4].Text;

                if (ta_comments.Text == "&nbsp;")
                    ta_comments.Text = "";

                //if (ddlProgram.Items.FindByValue(gv_criteriaList.Rows[e.NewSelectedIndex].Cells[5].Text) != null)
                //ddlProgram.SelectedValue = gv_criteriaList.Rows[e.NewSelectedIndex].Cells[5].Text;

                //text_grade.Text = gv_criteriaList.Rows[e.NewSelectedIndex].Cells[1].Text;

                //list_status.SelectedValue = gv_criteriaList.DataKeys[e.NewSelectedIndex].Values[1].ToString();


                ViewState["mode"] = "Edit";
                ViewState["EditID"] = gv_criteriaList.DataKeys[e.NewSelectedIndex].Value;
                pan_New.Attributes.CssStyle.Add("display", "inline");
                pnlAssignedSubjects.Visible = false;
                pnlAllSubjects.Visible = false;
            }

        }
        catch (Exception oException)
        {
            throw oException;
        }
    }

    protected void gv_criteriaList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gv_criteriaList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].CssClass = "hide";
    }


    protected void but_saveClass_Click(object sender, EventArgs e)
    {
        try
        {
            //int gradeID = Int32.Parse(list_grade.SelectedValue);
            int moID = Int32.Parse(Session["MoID"].ToString());

            string mode = Convert.ToString(ViewState["mode"]);
            DataTable dt;
            if (mode != "Edit")
            {
                obj.Class_Name = text_className.Text;
                obj.Main_Organisation_Id = moID;
                obj.Comments = ta_comments.Text;
                obj.Status_Id = 1;
                obj.isKPI = true;
                obj.OrderOfClass = 1;
                //dt= obj.ClassFetchByName(obj);
                int k = obj.ClassNameAvailability(obj);
                if (k == 0)
                {

                    obj.ClassAdd(obj);
                    bindGrid();
                    ImpromptuHelper.ShowPrompt("Class successfully created.");
                    pan_New.Attributes.CssStyle.Add("display", "none");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Class name is not available. Class creation failed!");
                }


            }
            else //Edit
            {
                //int classId = Int32.Parse(ViewState["classId"].ToString());
                int classId = Convert.ToInt32(ViewState["EditID"]);

                try
                {
                    obj.Class_Name = text_className.Text;
                    int k = obj.ClassNameAvailability(obj);
                    if (k > 0)
                    {
                        ImpromptuHelper.ShowPrompt("Class name already exists. Supply another Class name!");
                    }
                    else
                    {
                        //classDA.Update(text_className.Text, moID, 1, gradeID, ta_comments.Text,Convert.ToInt32(ddlProgram.SelectedValue), classId);

                        obj.Main_Organisation_Id = moID;
                        // obj.Grade_Id = Int32.Parse(list_grade.SelectedValue.ToString());
                        obj.Comments = ta_comments.Text;
                        obj.Class_Name = text_className.Text;
                        obj.ClassUpdate(obj);
                        bindGrid();
                        ImpromptuHelper.ShowPrompt("Class successfully updated.");
                        pan_New.Attributes.CssStyle.Add("display", "none");
                    }
                }
                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
                }
            }
            //Session["classId"] = ViewState["classId"];

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }


    protected void lb_checkAvailability_Click(object sender, EventArgs e)
    {
        try
        {

            int moID = Int32.Parse(Session["MoID"].ToString());


            if (text_className.Text == "")
            {
                //drawMsgBox("Enter name of the class.");
            }
            else
            {
                obj.Class_Name = text_className.Text;
                int k = obj.ClassNameAvailability(obj);
                if (k == 0)
                {
                    lab_availability.Text = "Available";
                    lab_availability.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lab_availability.Text = "Not available";
                    lab_availability.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
        //try
        //{
        //    TreeView tempView = (TreeView)Master.FindControl("MenuLeft");
        //    TreeNode tn = tempView.FindNode("Functions");
        //    if (tn != null)
        //    {
        //        tn.Expand();
        //        tn.ChildNodes[2].Expand();
        //        tn.ChildNodes[2].Select();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }
    protected void list_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ViewState.Remove("classId");
            //text_className.Text = "";
            //ta_comments.Text = "";

            //isl_amsoTableAdapters.da_ClassTableAdapter da = new isl_amsoTableAdapters.da_ClassTableAdapter();
            //isl_amso.dt_ClassDataTable dt;
            //if (list_grade.SelectedValue != "")
            //{
            //    dt = da.GetDataByGradeId(Int32.Parse(list_grade.SelectedValue));
            //    if (dt.Rows.Count > 0)
            //    {
            //        text_className.Text = dt[0].Class_Name;
            //        ViewState["classId"] = dt[0].Class_Id;
            //        ta_comments.Text = dt[0].Comments;
            //    }
            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void but_back_Click(object sender, EventArgs e)
    {

    }

    protected void but_new_Click1(object sender, EventArgs e)
    {
        pan_New.Attributes.CssStyle.Add("display", "inline");
        //text_grade.ReadOnly = false;
        //text_grade.Text = "";
        text_className.Text = "";
        //list_status.SelectedValue = "";
        //list_grade.SelectedValue = "";
        //list_grade.Enabled = true;
        ta_comments.Text = "";

        ViewState["mode"] = "Add";
        //ch_is_activity.Checked = false;
        gv_criteriaList.SelectedRowStyle.Reset();

        //ddlProgram.SelectedValue = "0";
        pnlAssignedSubjects.Visible = false;
        pnlAllSubjects.Visible = false;


    }

    protected void but_cancel_Click(object sender, EventArgs e)
    {
        pan_New.Attributes.CssStyle.Add("display", "none");
        gv_criteriaList.SelectedRowStyle.Reset();
    }

    protected void FillProgram()
    {
        //DALBase objBase = new DALBase();
        //BLLTssDCTProgram objBll = new BLLTssDCTProgram();
        //DataTable dt = new DataTable();
        //dt = objBll.TssDCTProgramSelectAll();
        //objBase.FillDropDown(dt, ddlProgram, "Program_ID", "Program");

    }

    protected void btnViewSubjects_Click(object sender, EventArgs e)
    {
        if (list_region.SelectedValue != "0")
        {
            pnlAssignedSubjects.Visible = true;
            pan_New.Attributes.CssStyle.Add("display", "none");


            LinkButton btn = (LinkButton)sender;
            classID = Convert.ToInt32(btn.CommandArgument);
            titlesection.InnerHtml = "";
            string className = btn.CommandName;
            titlesection.InnerHtml = "Assigned Subjects"+ " "+ className;
            BindAssignedSubjects(classID);
            ViewState["EditID"] = classID;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gv_criteriaList.SelectedIndex = gvr.RowIndex;

        }
        else
        {
            ImpromptuHelper.ShowPrompt("Select Region For Subject View");
        }
    }

    private void BindAssignedSubjects(int classID)
    {
        obj.Class_Id = classID;
        obj.Region_id = Convert.ToInt32(list_region.SelectedValue);
        dtCs = obj.Class_SubjectSelectByClassID(obj);
        gvAssignedSubjects.DataSource = dtCs;
        gvAssignedSubjects.DataBind();
        ViewState["dtAssignedSubjects"] = dtCs;
    }

    protected void btnShowAllSubj_Click(object sender, EventArgs e)
    {
        RetrieveAllSubjects();
        pnlAllSubjects.Visible = true;
        DisableAlreadyAssignedSubjects();
    }

    private void RetrieveAllSubjects()
    {
        try
        {
            ///searching
            ///
            DataTable dt;

            int moId = Int32.Parse(Session["moID"].ToString());

            dt = obj.GetClassesByMOId(moId);
            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                ViewState["subjectDT"] = dt;

                dg_subject.DataSource = dt;
                dg_subject.DataBind();
                lab_dataStatus.Visible = false;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void dg_subject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int ind = Int32.Parse((string)e.CommandArgument);

            if (e.CommandName == "name")
            {
                Session["SubjectID"] = dg_subject.DataKeys[ind].Value;
                Response.Redirect("SubjectDetail.aspx", false);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {

        CheckBox CheckBox1;
        classID = Convert.ToInt32(ViewState["EditID"]);
        obj.Class_Id = classID;
        foreach (GridViewRow gvr in dg_subject.Rows)
        {
            CheckBox1 = (CheckBox)gvr.FindControl("CheckBox1");

            obj.Status_Id = CheckBox1.Checked ? 1 : 2;
            obj.Subject_Id = Convert.ToInt32(gvr.Cells[0].Text);
            if (CheckBox1.Checked)
            {
                obj.Class_SubjectAssign(obj);
            }

        }
        BindAssignedSubjects(classID);
        ImpromptuHelper.ShowPrompt("Selected subjects assigned successfully.");

        pnlAllSubjects.Visible = false;
    }

    protected void btnCancelAssign_Click(object sender, EventArgs e)
    {
        pnlAllSubjects.Visible = false;
    }

    protected void btnUnAssign_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        classID = Convert.ToInt32(ViewState["EditID"]);
        
        obj.Class_Id = classID;
        obj.Subject_Id = Convert.ToInt32(gvr.Cells[0].Text);
        obj.Region_id = Convert.ToInt32(list_region.SelectedValue);
        obj.Class_SubjectUnAssign(obj);
        BindAssignedSubjects(classID);
        ImpromptuHelper.ShowPrompt("Subject has been UnAssigned from the class.");
    }

    protected void DisableAlreadyAssignedSubjects()
    {
        //=====================
        if (gvAssignedSubjects.Rows.Count > 0)
        {
            foreach (GridViewRow gvrAllSubj in dg_subject.Rows)
            {
                foreach (GridViewRow gvrAssigned in gvAssignedSubjects.Rows)
                {
                    if (Convert.ToInt32(gvrAssigned.Cells[0].Text) == Convert.ToInt32(gvrAllSubj.Cells[0].Text))
                    {
                        gvrAllSubj.Enabled = false;
                    }
                    /*else
                    {
                        gvrAllSubj.Enabled = true;
                    }*/
                }
            }
        }
        //=====================


    }


    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        BLLClass obj = new BLLClass();
        ImageButton btn = (ImageButton)sender;
        string id = btn.CommandArgument;
        obj.Class_Id = Convert.ToInt32(id);
        obj.ClassDelete(obj);
        bindGrid();
    }

    protected void btnAssignSubjects_Click(object sender, EventArgs e)
    {
        if (list_region.SelectedValue != "0")
        {

            pnlAssignSubjects.Visible = true;
            pan_New.Attributes.CssStyle.Add("display", "none");
            LinkButton btn = (LinkButton)sender;

            classID = Convert.ToInt32(btn.CommandArgument);
            ViewState["EditID"] = classID;
            string className = btn.CommandName;
            lblClassName.Text = className;
            ViewState["Region"] =  list_region.SelectedValue;
            FillSection();
            //BindAssignedSubjects(classID);
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //gv_criteriaList.SelectedIndex = gvr.RowIndex;
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Select Region For Assign Subject");
        }
    }

    protected void list_Section_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnassignsub_Click(object sender, EventArgs e)
    {
        BLLSubject obj = new BLLSubject();
        obj.Class_ID = Convert.ToInt32(ViewState["EditID"].ToString());
        obj.Subject_Id = Convert.ToInt32(list_Section.SelectedValue);
        obj.Region_id = Convert.ToInt32(ViewState["Region"]);
        int k = obj.AssignSubject(obj);
        if (k == 1) ImpromptuHelper.ShowPrompt("Subject already exist for the class.");
        if (k == 2) ImpromptuHelper.ShowPrompt("Subject Assigned Successfully.");
        BindAssignedSubjects(obj.Class_ID);
    }
    public void FillSection()
    {
        int moID = Int32.Parse(Session["MoID"].ToString());
        BLLSubject objCv = new BLLSubject();
        DataTable _dt = objCv.SubjectFetchByMoId(moID);
        objBase.FillDropDown(_dt, list_Section, "Subject_Id", "Subject_name");
        BLLRegion oDALRegion = new BLLRegion();

       
    }

    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = 1;
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}