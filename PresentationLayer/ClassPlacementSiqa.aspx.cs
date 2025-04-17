using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class PresentationLayer_ClassPlacementSiqa : System.Web.UI.Page
{
    BLLSiqa obj = new BLLSiqa();
    DataTable dtCs = new DataTable();
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            else
            {
                search();
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void search()
    {
        try
        {
            ///searching
            ///
            BLLSiqa obj = new BLLSiqa();
            DataTable dt;

            //int moId = Int32.Parse(Session["moID"].ToString());

            dt = obj.Get_All_GroupHeads();
            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                ViewState["GroupHeadDT"] = dt;

                dg_Group.DataSource = dt;
                dg_Group.DataBind();
                lab_dataStatus.Visible = false;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    //protected void bindGrid()
    //{
    //    int moID = Convert.ToInt32(Session["moID"]);
    //    DataTable dt = null;

    //    dt = obj.SubjectFetchByMoId(moID);

    //    if (dt.Rows.Count == 0)
    //    {
    //        lab_dataStatus.Visible = true;
    //        //pan_New.Attributes.CssStyle.Add("display", "none");
    //    }
    //    else
    //    {
    //        gv_criteriaList.DataSource = dt;
    //        lab_dataStatus.Visible = false;
    //        lab_dataStatus.Visible = false;
    //    }
    //    gv_criteriaList.DataBind();
    //    //pan_New.Attributes.CssStyle.Add("display", "none");


    //    ViewState["CriteriaList"] = dt;

    //}
    protected void dg_Group_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int ind = Int32.Parse((string)e.CommandArgument);

            if (e.CommandName == "name")
            {
                Session["SubjectID"] = dg_Group.DataKeys[ind].Value;
                Response.Redirect("SubjectDetail.aspx", false);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private bool validateGrid()
    {
        bool result = false;
        foreach (GridViewRow gRow in dg_Group.Rows)
        {
            CheckBox chkBox = (CheckBox)gRow.Cells[3].FindControl("CheckBox1");
            if (chkBox.Checked)
            {
                result = true;
            }
        }
        return result;
    }

    protected void but_assignStudents_Click(object sender, EventArgs e)
    {
        //if (!validateGrid())
        //{
        //    drawMsgBox("No Subject is selected for deletion!");
        //    return;
        //}


        try
        {
            CheckBox cb;
            int subjectId;
            int? nAlreadyIn = null;
            BLLSubject obj = new BLLSubject();
            foreach (GridViewRow gvr in dg_Group.Rows)
            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");

                if (cb.Checked)
                {
                    subjectId = Convert.ToInt32(dg_Group.DataKeys[gvr.RowIndex].Value.ToString());
                    //csTa.DeleteSubject(subjectId);
                    obj.Subject_Id = subjectId;
                    nAlreadyIn = obj.SubjectDelete(obj);
                    if (nAlreadyIn != 0)
                    {
                        if (nAlreadyIn == 1)
                            drawMsgBox("Subject Not Deleted, Section(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 2)
                            drawMsgBox("Subject Not Deleted, Student(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 3)
                            drawMsgBox("Subject Not Deleted, Teacher(s) Already Exists For Subject.");
                        else if (nAlreadyIn == 4)
                            drawMsgBox("Subject Not Deleted, WorkPlan(s) Already Exists For Subject.");
                    }
                    else
                    {
                        drawMsgBox("Subject Successfully Deleted.");
                    }
                }
            }


            //search();
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
        //        tn.ChildNodes[11].Expand();
        //        tn.ChildNodes[11].Select();
        //    }

        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }
    protected void drawMsgBox(string msg)
    {
        try
        {

            MPopEx.Enabled = true;
            MPopEx.DropShadow = true;
            MPopEx.OkControlID = "msgOK";
            MPopEx.CancelControlID = "msgCross";
            MPopEx.PopupControlID = "msgBox";
            MPopEx.PopupDragHandleControlID = "msgDrag";

            msgBox.Visible = true;
            msgNote.Text = msg;
            MPopEx.Show();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        UniDetailsArea(true);
        clearingAppearance();
    }


    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            BLLSiqa obj = new BLLSiqa();

            bool isAssigned = false;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < gvclass.Rows.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)gvclass.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    if (isAssigned == false)
                    {
                        isAssigned = true;
                    }
                    count = count + 1;
                    //Session["Class_Id"] = chkSelect.ToolTip.ToString();
                    //Session["Class_Id"] += String.Join(",", chkSelect.ToolTip.ToString());
                    result.Append(chkSelect.ToolTip.ToString() + ",");

                }

                chkSelect = null;
            }
            Session["Class_Id"] = result.ToString().TrimEnd(',');

            if (count > 0)
            {

                obj.Group_Name = text_groupname.Text.ToString().ToUpper().Trim();
                int n = obj.GroupNameAvailability(obj);
                if (n != -1)
                {
                    obj.Remarks = ta_comments.Text.ToString().ToUpper().Trim();
                    obj.Group_Name = text_groupname.Text.ToString().ToUpper().Trim();
                    obj.IsActive = Convert.ToBoolean(ch_active.Checked);
                    obj.CreateBy = Session["ContactID"].ToString();
                    int k = obj.Group_Add(obj);
                    Session["Group_ID"] = k;
                    if (k > 0)
                    {
                        //Child Insertion
                        var query = from val in Session["Class_Id"].ToString().Split(',')
                                    select int.Parse(val);
                        foreach (int CID in query)
                        {
                            obj.Class_Id = CID;
                            obj.Group_ID = int.Parse(Session["Group_ID"].ToString());
                            obj.Add_classes(obj);
                        }

                    }
                    clearingAppearance();
                    search();
                    UniDetailsArea(false);

                }
                else
                {
                    drawMsgBox("Group Head with same name already exists.");
                }

            }
            else
            {
                lab_availability.Text = "Class selection is mandatory....";
                lab_availability.ForeColor = System.Drawing.Color.Red;
                lab_availability.Visible = true;
                ImpromptuHelper.ShowPrompt("Class selection is mandatory....");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private void UniDetailsArea(bool _chk)
    {
        SubDet1.Visible = _chk;
        SubDet2.Visible = _chk;
    }

    protected void lb_checkName_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSiqa obj = new BLLSiqa();
            // int moID = Int32.Parse(Session["moID"].ToString());

            if (!string.IsNullOrEmpty(text_groupname.Text))
            {
                obj.Group_Name = text_groupname.Text.ToString().Trim();
                //obj.Main_Organisation_Id = moID;
                int k = obj.GroupNameAvailability(obj);
                if (k == 0)
                {
                    lab_availability.Text = "Available";
                    lab_availability.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lab_availability.Text = "Group Already Exist";
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
    //protected void lb_checkCode_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLSubject obj = new BLLSubject();
    //        int moID = Int32.Parse(Session["moID"].ToString());

    //        if (!string.IsNullOrEmpty(text_groupnameCode.Text))
    //        {
    //            obj.Subject_Code = text_groupnameCode.Text.Trim();
    //            obj.Main_Organisation_Id = moID;
    //            int k = obj.SubjectCodeAvailability(obj);
    //            if (k == 0)
    //            {
    //                //lab_codeAvailability.Text = "Available";
    //               // lab_codeAvailability.ForeColor = System.Drawing.Color.Green;
    //            }
    //            else
    //            {
    //               // lab_codeAvailability.Text = "Already Exist";
    //                //lab_codeAvailability.ForeColor = System.Drawing.Color.Red;
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}
    private void clearingAppearance()
    {
        text_groupname.Text = "";
        lab_availability.Text = "";

        //text_groupnameCode.Text = "";
        //lab_codeAvailability.Text = "";

        ch_active.Checked = false;

        ta_comments.Text = "";
    }
    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearingAppearance();
            UniDetailsArea(false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void lbtndelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int U_Id = Convert.ToInt32(btn.CommandArgument);
        obj.U_Id = U_Id;
        int k = obj.Group_Inactive(obj);
        if (k == 0) { ImpromptuHelper.ShowPrompt("Record Delete UnSuccessfull"); }
        if (k == 1) { ImpromptuHelper.ShowPrompt("Record Deleted Successfuly"); }
        search();
        dg_Group.DataBind();
    }

    protected void btnaddclasses_Click(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openClassModel();", true);
            //Button btnEdit = (Button)(sender);
            //var StudentId = Convert.ToInt32(btnEdit.CommandArgument);
            //ViewState["Student_Id_doc_upload"] = StudentId;


            // GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;



            //// txtStdName.Text = gvr.Cells[1].Text == "&nbsp;" ? "" : gvr.Cells[1].Text;
            // ViewState["Us_ID"] = gvr.Cells[2].Text == "&nbsp;" ? "" : gvr.Cells[2].Text;   //Getting table id for unique record
            // ViewState["Us_Uni_Fk"] = gvr.Cells[3].Text == "&nbsp;" ? "" : gvr.Cells[3].Text;  //Uni id




        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    //protected void btnbindclassses_Click(object sender, EventArgs e)
    //{
    //    bool isAssigned = false;

    //    for (int i = 0; i < gvclass.Rows.Count; i++)
    //    {
    //        CheckBox chkSelect = (CheckBox)gvclass.Rows[i].FindControl("chkSelect");
    //        if (chkSelect.Checked)
    //        {
    //            if (isAssigned == false)
    //            {
    //                isAssigned = true;
    //            }
    //            Session["id"] = chkSelect.ToolTip.ToString();
    //            //ctBL = (BLL.ComplaintTechniciansBL)ctBL.Add(Session["ComplaintID"].ToString(), chkSelect.ToolTip.ToString());
    //            //Session["id"] = chkSelect.ToolTip.ToString();
    //            //ctBL = null;
    //        }
    //        chkSelect = null;
    //    }

    //}


    protected void BindGrid()
    {
        try
        {
            gvclass.DataSource = null;
            gvclass.DataBind();
            DataTable dt = new DataTable();


            if (ViewState["Data"] == null)
            {
                dt = obj.GetClasses();
                ViewState["Data"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["Data"];
            }


            if (dt.Rows.Count > 0)
            {
                gvclass.DataSource = dt;
                gvclass.DataBind();
            }
            else
            {
                gvclass.DataSource = null;
                gvclass.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void gvclass_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvclass.Rows.Count > 0)
            {
                gvclass.UseAccessibleHeader = false;
                gvclass.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    protected void gvclassview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //foreach (TableCell tc in e.Row.Cells)
        //{
        //    tc.Attributes["style"] = "border-color: #c3cecc";
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //CheckBox chkRedo = (CheckBox)e.Row.FindControl("chkRedo");
            //TextBox txtAT = (TextBox)e.Row.FindControl("txtAT");
            //TextBox txtDO = (TextBox)e.Row.FindControl("txtDO");
            //BLL.ExternalJobCardTechBL ctBL = new BLL.ExternalJobCardTechBL();
            DataTable dt = new DataTable();
            //dt = (DataTable)obj.Get_Classes_By_Group_ID(Request.QueryString["ID"].ToString());
            dt = (DataTable)obj.Get_Classes_By_Group_ID(1);
            if (dt != null)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (chkSelect.ToolTip.ToString() == dt.Rows[j]["Class_Id"].ToString())
                    {
                        //chkRedo.Checked = Convert.ToBoolean(dt.Rows[j]["EJT_IS_REDO"].ToString());
                        // txtAT.Text = dt.Rows[j]["EJT_TCN_ARRIVAL_TIME"].ToString();
                        //txtDO.Text = dt.Rows[j]["EJT_TCN_DEPARTURE_TIME"].ToString();
                        chkSelect.Checked = true;
                        break;
                    }
                    else
                    {
                        // chkRedo.Checked = false;
                        chkSelect.Checked = false;
                        //txtAT.Text = "00:00:00";
                        //txtDO.Text = "00:00:00";
                    }
                }
            }
            dt = null;
            //ctBL = null;
            chkSelect = null;

            //e.Row.Enabled = Convert.ToBoolean(txtAT.ToolTip);
        }

    }


    protected void btnview_Click(object sender, EventArgs e)
    {
        LinkButton btnv = (LinkButton)(sender);
        BindGrid_View_Classes(int.Parse(btnv.CommandArgument.ToString()));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewClassModel();", true);




        //trSubjectList.Visible = false;
        //try
        //{
        //    ViewState["ResultHistory"] = null;
        //    LinkButton btn = (LinkButton)(sender);
        //    GridViewRow r = (GridViewRow)btn.NamingContainer;
        //    dg_student.SelectedIndex = r.RowIndex;
        //    BLLUploadEducationalArchive objSer = new BLLUploadEducationalArchive();
        //    objSer.Student_Id = Convert.ToInt32(btn.CommandArgument);
        //    //DataTable dt = objSer.SearchStudentResultCard(objSer);
        //    DataTable dt = objSer.Get_University_student_Placement_List(objSer.Student_Id);
        //    ViewState["ResultHistory"] = dt;
        //    ApplyFilterBifurcation(1, objSer.Student_Id);
        //    if (dt.Rows.Count > 0)
        //    {
        //        gvuniplacement.DataSource = dt;
        //        gvuniplacement.DataBind();
        //        if (Session["isClassTeacher"].ToString() == "1" || Session["UserType_Id"].ToString() == "1")
        //        {
        //            // gvuniplacement.Columns[10].Visible = false;
        //        }
        //    }
        //    //gvuniplacement.DataBind();
        //    trReportCard.Visible = true;
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        //}

    }


    protected void BindGrid_View_Classes(int Group_ID)
    {
        try
        {

            DataTable dt = new DataTable();
            if (ViewState["Data_View"] == null)
            {
                dt = obj.Get_Classes_By_Group_ID(Group_ID);
                ViewState["Data_View"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["Data_View"];
            }


            if (dt.Rows.Count > 0)
            {
                gvclassview.DataSource = dt;
                gvclassview.DataBind();
            }
            else
            {
                gvclassview.DataSource = null;
                gvclassview.DataBind();
            }
            ViewState["Data_View"] = null;



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }




    //protected void btnviewclasses_Click(object sender, EventArgs e)
    //{
    //    Button btnv = (Button)(sender);
    //    BindGrid_View_Classes(int.Parse(btnv.CommandArgument.ToString()));
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewClassModel();", true);
    //}



    protected void btnviewclasses_Click(object sender, EventArgs e)
    {
        Button btnv = (Button)(sender);
        //BindGrid_View_Classes(int.Parse(btnv.CommandArgument.ToString()));
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewClassModel();", true);
    }
}