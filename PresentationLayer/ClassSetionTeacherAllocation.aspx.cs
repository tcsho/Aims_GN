using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_ClassSetionTeacherAllocation : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillClassSection();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;
                trClassTeacher.Visible = false;
                trNotice.Visible = false;
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
            lblSave.Text = "";
            BLLClass_Section obj = new BLLClass_Section();

            int CenterId = Convert.ToInt32(Session["cId"].ToString());
            DataTable dt = (DataTable)obj.Class_SectionByCenterId(CenterId);

            objBase.FillDropDown(dt, List_ClassSection, "Section_Id", "FullClassSection");
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
            BindGrid();
            DataTable dt = (DataTable)ViewState["Teachers"];
            objBase.FillDropDown(dt, List_ClassTeacher, "Employee_Id", "TeacherFullName");


            if (List_ClassSection.SelectedValue != "0")
            {
                BLLSection ObjSec = new BLLSection();
                ObjSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);
                dt = ObjSec.SectionSelectClassTeacherBySection_Id(ObjSec);
                if (dt.Rows.Count > 0)
                {
                    List_ClassTeacher.SelectedValue = dt.Rows[0]["ClassTeacher_Id"].ToString();

                }
                else
                {
                    List_ClassTeacher.SelectedValue = "0";
                }
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
            BLLClass_Section objClsSec = new BLLClass_Section();

            DataTable dtsub = new DataTable();
            LoadTeachers();

            objClsSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Class_SectionSubjectsValues(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                gvSubjects.DataSource = dtsub;
            }
            gvSubjects.DataBind();
            ViewState["tMood"] = "check";
            trSave.Visible = true;
            trClassTeacher.Visible = true;
            trNotice.Visible = true;
            lblSave.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string EmpId = (e.Row.Cells[1].Text);

                DropDownList listTeacher = (e.Row.FindControl("listTeacher") as DropDownList);

                if (ViewState["Teachers"] != null)
                {
                    DataTable dt = (DataTable)ViewState["Teachers"];
                    objBase.FillDropDown(dt, listTeacher, "Employee_Id", "TeacherFullName");
                }

                if (EmpId != "&nbsp;" || EmpId != String.Empty)
                {
                    listTeacher.SelectedValue = EmpId;
                }

                var dr = e.Row.DataItem as DataRowView;

                if (dr["Subject_Id"].ToString() == "55")
                {
                    e.Row.Enabled = false;  //OR dr.Enabled = false;
                    ((DropDownList)e.Row.FindControl("listTeacher")).Enabled = false;
                }


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void LoadTeachers()
    {
        try
        {
            BLLClass_Section obj = new BLLClass_Section();

            obj.Center_Id = Convert.ToInt32(Session["cId"].ToString());

            DataTable dt = (DataTable)obj.Employee_ProfileByCenterId(obj);
            ViewState["Teachers"] = dt;
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
            BLLSection_Subject obj = new BLLSection_Subject();
            int AlreadyIn = 0;

            if (List_ClassTeacher.SelectedValue == "0")
            {
                ImpromptuHelper.ShowPrompt("Class Teacher is a required field");
            }
            else
            {


                for (int i = 0; i < gvSubjects.Rows.Count; i++)
                {
                    DropDownList list = (DropDownList)gvSubjects.Rows[i].FindControl("listTeacher");

                    //if (Convert.ToInt32(list.SelectedValue) > 0)
                    //{
                    obj.Section_Subject_Id = Convert.ToInt32(gvSubjects.Rows[i].Cells[0].Text);
                    obj.Employee_Id = Convert.ToInt32(list.SelectedItem.Value);
                    AlreadyIn = obj.Section_SubjectUpdate(obj);
                    //}

                }

                BLLSection ObjSec = new BLLSection();
                ObjSec.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                ObjSec.Teacher_Id = Convert.ToInt32(List_ClassTeacher.SelectedValue.ToString());
                ObjSec.SectionUpdateClassTeacher(ObjSec);

                ViewState["dtDetails"] = null;
                if (AlreadyIn == 1)
                {
                    ImpromptuHelper.ShowPrompt("Record Saved Successfully");
                    BindGrid();
                    lblSave.Visible = true;
                    lblSave.Text = "Record Saved Successfully";


                }
                else
                {
                    ImpromptuHelper.ShowPrompt("No teacher has been assigned to any subject");
                    lblSave.Visible = true;
                    lblSave.Text = "No teacher has been assigned to any subject";

                }
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {

            ImageButton btnCopy = (ImageButton)sender;
            GridViewRow grv = (GridViewRow)btnCopy.NamingContainer;

            Control ctl = (Control)grv.FindControl("listTeacher");
            DropDownList ddlTeacher = (DropDownList)ctl;

            CheckBox cb = null;
            DropDownList ddlTeacherInner = null;

            foreach (GridViewRow gvRow in gvSubjects.Rows)
            {
                ddlTeacherInner = (DropDownList)gvRow.FindControl("listTeacher");
                cb = (CheckBox)gvRow.FindControl("CheckBox1");
                if (cb.Checked)
                {
                    ddlTeacherInner.SelectedValue = ddlTeacher.SelectedValue;
                    cb.Checked = false;
                }
            }
            ViewState["tMood"] = "check";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "toggleCheck")
            {
                CheckBox cb = null;
                string mood = ViewState["tMood"].ToString();

                foreach (GridViewRow gvr in gvSubjects.Rows)
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
    public void List_ClassTeacher_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvSubjects.Rows)
            {
                if (row.Cells[7].Text == "55")
                {
                    DropDownList ddlGP = (DropDownList)row.FindControl("listTeacher");
                    ddlGP.SelectedValue = List_ClassTeacher.SelectedValue;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

}