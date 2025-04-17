using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;

public partial class PresentationLayer_CEPD_Category: System.Web.UI.Page
{
    DALBase objBase = new DALBase();
   

    BLLCEPD_Category objec = new BLLCEPD_Category();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateGridView();
        }
    }

    protected void PopulateGridView()
    {
        DataTable categoryData = GetSampleCategoryData();
        GridView.DataSource = categoryData;
       GridView.DataBind();


        DataTable subcategoryData = GetSampleSubcategoryData();
        yourSubcategoryGridView.DataSource = subcategoryData;
        yourSubcategoryGridView.DataBind();
    }

    private DataTable GetSampleCategoryData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Category_Id", typeof(int));
        dt.Columns.Add("Category_Name", typeof(string));
        dt.Rows.Add(1, "Category 1");
        dt.Rows.Add(2, "Category 2");
        // Add more rows as needed
        return dt;
    }

    private DataTable GetSampleSubcategoryData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Subcategory_ID", typeof(int));
        dt.Columns.Add("Subcategory_Name", typeof(string));
        dt.Rows.Add(1, "Subcategory 1");
        dt.Rows.Add(2, "Subcategory 2");
        // Add more rows as needed
        return dt;
    }






    //protected void Btn_Category(object sender, EventArgs e)
    //{
    //    if (string.IsNullOrWhiteSpace(txtcategory.Text))
    //    {
    //     ImpromptuHelper.ShowError("Category cannot be empty!");
    //        return; 
    //    }
    //    string category = txtcategory.Text;
    //    objec.PerformCEPD_CategorySave(objec);
    //    // Proceed with saving the category to the database or performing other necessary operations
    //}


    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        LinkButton btn = (LinkButton)(sender);
    //        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    //        gvStudent.SelectedIndex = gvr.RowIndex;
    //        objreq.Student_Id = Convert.ToInt32(btn.CommandArgument);
    //        DropDownList ddl = (DropDownList)gvr.FindControl("ddlToClass");
    //        DropDownList ddlreason = (DropDownList)gvr.FindControl("ddlReason");
    //        TextBox txtOther = (gvr.FindControl("txtOthers") as TextBox);
    //        if (ddl.SelectedIndex <= 0)
    //        {
    //            ImpromptuHelper.ShowPrompt("Please Select the required Class!");
    //            return;
    //        }

    //        if (ddlreason.SelectedIndex <= 0)
    //        {
    //            ImpromptuHelper.ShowPrompt("Please Select a reason for class Change!");
    //            return;
    //        }
    //        objreq.ToClass_Id = Convert.ToInt32(ddl.SelectedValue);
    //        objreq.CCReason_Id = Convert.ToInt32(ddlreason.SelectedValue);
    //        if (txtOther.Visible == true)
    //            objreq.Comments = txtOther.Text;
    //        else
    //            objreq.Comments = null;
    //        objreq.CCReq_Id = Convert.ToInt32(gvr.Cells[0].Text);
    //        objreq.Submit_By = Convert.ToInt32(Session["ContactID"].ToString());
    //        int k = objreq.Class_Change_RequestAdd(objreq);
    //        if (k == 1)
    //        {
    //            ImpromptuHelper.ShowPrompt("Request Submitted!");
    //            gvStudent.DataSource = null;
    //            gvStudent.DataBind();
    //        }
    //        ViewState["Students"] = null;
    //        BindGridSearch();

    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }
    //}
}