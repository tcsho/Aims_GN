using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;

public partial class PresentationLayer_CEPD_professional_Qualification : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_Category objec = new BLLCEPD_Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        // Call the method from BLL to get the data
        //objec.action = "GET";
        objec.Category = ddlcategory.SelectedValue.ToString();
        DataTable dt = objec.GetQualification(objec);
        GridView.DataSource = dt;
        BtnSave.Text = "Save";
        //txtProQualification.Text = "";
        qualID.Value = "";
        //ddlcategory.SelectedValue = "";
        GridView.DataBind();

    }


    protected void Btn_QulificationSave(object sender, EventArgs e)
    {
        if (BtnSave.Text == "Save")
        {
            if (string.IsNullOrWhiteSpace(txtProQualification.Text))
            {
                //*ImpromptuHelper.ShowError("Qualification cannot be empty!");
                return;
            }
            if (ddlcategory.SelectedValue.ToString() == "")
            {
                ImpromptuHelper.ShowPromptGeneric("Please Select Category", 0);
                return;
            }

            string Qualification = txtProQualification.Text;
            objec.Qualification = Qualification;

            string Category = ddlcategory.SelectedValue;
            objec.Category = Category;
            //objec.action = "SAVE";
            objec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            objec.CreatedOn = DateTime.Now;
            objec.SaveUpdateQualification(objec);
            //*ImpromptuHelper.ShowSuccess("New Category Saved Successfully!");
            BindGrid();

        }

        // Rebind the GridView after saving the category
        if (BtnSave.Text == "Edit")
        {

            Edit(qualID.Value);
            BindGrid();
        }


    }
    private void Edit(string Id)
    {
        objec.Qualif_id = Convert.ToInt32(Id);
        objec.Qualification = txtProQualification.Text;
        objec.Category = ddlcategory.SelectedValue;
        //objec.action = "SAVE";
        objec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
        objec.CreatedOn = DateTime.Now;
        objec.SaveUpdateQualification(objec);
        //*ImpromptuHelper.ShowSuccess("Qualification Edit Successfully!");
    }


    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnEdit = (ImageButton)sender;

        // Get the category ID and category name from the CommandArgument and CommandName
        string categoryId = btnEdit.CommandArgument;
        string categoryName = btnEdit.CommandName;
        string categorytype = btnEdit.ValidationGroup;
        if(categorytype== "Academic Qualification")
        {
            ddlcategory.SelectedValue = "A";
        }
        if(categorytype== "Professional Qualification")
        {
            ddlcategory.SelectedValue = "P";
        }
        txtProQualification.Text = categoryName;

        qualID.Value = categoryId;
        BtnSave.Text = "Edit";
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnDelete = (ImageButton)sender;

        // Get the CommandArgument, which holds the category_id
        string Id = btnDelete.CommandArgument;

        // Call the delete method/function passing the category_id
        DeleteCategory(Id);

        // Rebind the GridView to refresh the data
        BindGrid();
    }
    private void DeleteCategory(string categoryId)
    {

        objec.DeleteQualification(categoryId);
        //*ImpromptuHelper.ShowSuccess("Qualification Deleted Successfully!");
    }

    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}
