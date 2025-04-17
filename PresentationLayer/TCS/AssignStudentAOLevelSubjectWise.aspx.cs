using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_AssignStudentAOLevelSubjectWise : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            try
            {
                FillClass();
                trButtons.Visible = false;
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
        
            
    }

    private void FillClass()
    {

       

        try
        {


            int moID = Int32.Parse(Session["moID"].ToString());

            DataRow rrow = (DataRow)Session["rightsRow"];
            BLLClass_Center objCC = new BLLClass_Center();
            objCC.Center_ID = Convert.ToInt32(Session["cId"].ToString());

            DataTable _dt = objCC.Class_CenterSelect_OA_Level(objCC);
           
            objBase.FillDropDown(_dt, List_Class, "class_Id", "class_name");

            list_Section.Items.Clear();
            list_Section.Items.Insert(0, new ListItem("Select", ""));



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void FillSectionAgainstClass()
    {
        try
        {

            if (List_Class.SelectedValue != "")
            {

                BLLClass_Section objCS = new BLLClass_Section();

                objCS.Class_Id = Int32.Parse(List_Class.SelectedValue);
            
                objCS.Center_Id = Convert.ToInt32(Session["cId"].ToString());

                DataTable _dt = objCS.Class_SectionFetch(objCS);


                objBase.FillDropDown(_dt, list_Section, "section_Id", "section_name");

                if (list_Section.Items.Count == 0)
                {
                    ImpromptuHelper.ShowPrompt("This class has no section assigned to it. Please assign section(s) to this class first.");
                }
            }

           
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
            FillSectionAgainstClass();
            
            if (List_Class.SelectedItem.Text == "Select")
            {
               
                list_Section.SelectedIndex = 0;
                list_Subject.SelectedIndex = 0;
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

    

    private void BindGrid()
    {
        try
        {
            BLLSection_Subject objClsSec = new BLLSection_Subject();

            DataTable dtsub = new DataTable();



            objClsSec.Center_Id = Convert.ToInt32(Session["cId"].ToString());
            objClsSec.Session_Id = Convert.ToInt32(ViewState["SessionId"].ToString());
            objClsSec.Section_Id = Convert.ToInt32(list_Section.SelectedValue.ToString());
            objClsSec.Section_Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
            

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.GetStudents_AssignedForSubjectWiseAllocation(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                dv_details.DataSource = dtsub;
                dv_details.DataBind();
                btns.Visible = true;
            }
            else
            {
                dv_details.DataSource = null;
                dv_details.DataBind();
                btns.Visible = false;

            }

            ViewState["tMood"] = "check";

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    protected void FillActiveSubjects()
    {
        ViewState["SessionId"] = 0;

        try
        {
            BLLSection_Subject objsubject = new BLLSection_Subject();
            DataTable dt = new DataTable();
            objsubject.Section_Id = Convert.ToInt32(list_Section.SelectedValue.ToString());
            objsubject.Center_Id = Convert.ToInt32(Session["cId"].ToString());


            dt = (DataTable)objsubject.Section_SubjectSelectSubjectBySectionId(objsubject);
            ViewState["SessionId"] = Convert.ToInt32(dt.Rows[0]["Session_Id"].ToString().Trim());
            objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void dv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
             
            foreach (GridViewRow gvr in dv_details.Rows)
            {
                GridViewRow row = e.Row;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox ch = (CheckBox)gvr.FindControl("CheckBox1");
                    CheckBox ch2 = (CheckBox)gvr.FindControl("CheckBox2");
                    if (dv_details.Rows[gvr.RowIndex].Cells[7].Text != "&nbsp;")
                    {
                        ch.Checked = true;
                    }
                    else
                    {
                        ch2.Checked = true;
                    }
                        ////////ch.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void dv_details_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void list_Section_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        if (list_Section.SelectedItem.Text == "Select")
        {

            list_Section.SelectedIndex = 0;
            list_Subject.SelectedIndex = 0;
            dv_details.DataSource = null;
            dv_details.DataBind();

        }
        else
        {
            FillActiveSubjects();
        }
    }
    protected void but_save_Click(object sender, EventArgs e)
    {

        BLLStudent_Section_Subject objBll = new BLLStudent_Section_Subject();


        try
        {
            bool isSelected = false;

            CheckBox cb = null;
            CheckBox cb2 = null;

            objBll.Session_Id = Convert.ToInt32(ViewState["SessionId"].ToString());
            objBll.Section_Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
            
            foreach (GridViewRow gvr in dv_details.Rows)

            {
                cb = (CheckBox)gvr.FindControl("CheckBox1");
                cb2 = (CheckBox)gvr.FindControl("CheckBox2");

                if (cb.Checked)
                {
                    objBll.Student_Id = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[2].Text);


                    if (cb.Checked == true)
                    {
                        /*Insert/Update Subject*/
                        objBll.Student_Secttion_Subject_AssignUpdate(objBll);
                        isSelected = true;
                    }
                   
                }
                else
                {
                    if (cb.Checked == false)
                    {
                        objBll.Student_Id = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[2].Text);
                        /*Delete From Student_section_subject and Detail Marks*/
                        objBll.Student_Secttion_Subject_UnAssign(objBll);
                        isSelected = true;
                    }
                }


                ////////  Comment for hide second un assign coloumn
                ////////////if (cb2.Checked)
                ////////////{
                ////////////    objBll.Student_Id = Convert.ToInt32(dv_details.Rows[gvr.RowIndex].Cells[2].Text);


                ////////////    if (cb2.Checked == true)
                ////////////    {
                ////////////        /*Delete From Student_section_subject and Detail Marks*/
                ////////////        objBll.Student_Secttion_Subject_UnAssign(objBll);
                ////////////        isSelected = true;
                ////////////    }


                ////////////}

                
            }

            if (isSelected)
            {


                BindGrid();

                ImpromptuHelper.ShowPrompt("Student(s) successfully assigned to the selected subject.");


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
        List_Class.SelectedIndex = 0;
        list_Section.SelectedIndex = 0;
        list_Subject.SelectedIndex = 0;
        dv_details.DataSource = null;
        dv_details.DataBind();
    }

    

    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_Section.SelectedItem.Text == "Select")
            {

                ////////////list_Section.SelectedIndex = 0;
                list_Subject.SelectedIndex = 0;
                dv_details.DataSource = null;
                dv_details.DataBind();

            }
            else
            {

                if (List_Class.SelectedIndex > 0 && list_Section.SelectedIndex > 0 && list_Subject.SelectedIndex > 0)
                {

                    BindGrid();
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please select Class, Section and Subject!");
                    list_Subject.SelectedIndex = 0;
                    dv_details.DataSource = null;
                    dv_details.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void dv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in dv_details.Rows)
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
                /////////////////// For un assign
                if (e.CommandName == "toggleCheck")
                {
                    CheckBox cb2 = null;
                    string mood2 = ViewState["tMood"].ToString();

                    foreach (GridViewRow gvr in dv_details.Rows)
                    {
                        cb2 = (CheckBox)gvr.FindControl("CheckBox2");

                        if (mood == "" || mood == "check")
                        {
                            cb2.Checked = true;
                            ViewState["tMood"] = "uncheck";
                        }
                        else
                        {
                            cb2.Checked = false;
                            ViewState["tMood"] = "check";
                        }

                    }
                }
                //////////////////////////////

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       

        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb2 = (CheckBox)dv_details.Rows[index].FindControl("CheckBox2");
        cb2.Checked = false;
        
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)dv_details.Rows[index].FindControl("CheckBox1");
        cb1.Checked = false;
    }
}