using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;

public partial class PresentationLayer_CEPD_Category : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_Category objec = new BLLCEPD_Category();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid(); // Call the method to bind data to the GridView
            loadCategory();
            BindGrid_SubCate();
        }
       
    }
    
    private void BindGrid()
    {
        // Call the method from BLL to get the data
        //objec.action = "GET";
        DataTable dt = objec.GetCategory(objec);
        GridView.DataSource = dt;
        BtnCategory.Text = "Save Category";
        txtcategory.Text = "";
        catID.Value = "";
        GridView.DataBind();
     
    }

    private void BindGrid_SubCate()
    {
        // Call the method from BLL to get the data
        DataTable dt = objec.GetSubCategory_Get(); // Assuming you have a method to get subcategory data from the database

        // Bind the grid with the retrieved data
        GridSubCategory.DataSource = dt;
        GridSubCategory.DataBind();

        // Reset controls for adding new subcategory
        Btn_SubCat.Text = "Save";
        txtSubcategory.Text = "";
        ddlCategory.ClearSelection();
        catID.Value = "";
    }

    // Event handler for the Save button click
    protected void Btn_Category(object sender, EventArgs e)
    {
        if (BtnCategory.Text == "Save Category")
        {
            if (string.IsNullOrWhiteSpace(txtcategory.Text))
            {
                ImpromptuHelper.ShowError("Category cannot be empty!");
                return;
            }

            string category = txtcategory.Text;
            objec.CategoryName = category;
            //objec.action = "SAVE";
            objec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
            objec.CreatedOn = DateTime.Now;
            objec.PerformCEPD_CategorySave(objec);
            ImpromptuHelper.ShowSuccess("New Category Saved Successfully!");
            BindGrid();

        }

        // Rebind the GridView after saving the category
        if (BtnCategory.Text =="Edit Category")
        {
           
            Edit(catID.Value);
            BindGrid();
        }

       
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnEdit = (ImageButton)sender;

        // Get the category ID and category name from the CommandArgument and CommandName
        string categoryId = btnEdit.CommandArgument;
        string categoryName = btnEdit.CommandName;
        txtcategory.Text = categoryName;
        catID.Value = categoryId;
        BtnCategory.Text = "Edit Category";
    }

    private void Edit(string categoryId)
    {
       objec.CategoryId =Convert.ToInt32(categoryId);
      objec.CategoryName = txtcategory.Text;
        //objec.action = "SAVE";
        objec.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
        objec.CreatedOn = DateTime.Now;
        objec.PerformCEPD_CategorySave(objec);
        ImpromptuHelper.ShowSuccess("Category Edit Successfully!");
    }

    private void Edit_sub(string subcategoryId)
    {
        // Assuming you have controls for subcategory name and category selection
        string subcategoryName = txtSubcategory.Text; // Update this according to your control
        int categoryId = Convert.ToInt32(ddlCategory.SelectedValue); // Assuming you have a DropDownList for category selection

        // Set the properties of the business object
        objec.SubcategoryId = Convert.ToInt32(subcategoryId);
        objec.SubcategoryName = subcategoryName;
        objec.CategoryId = categoryId;
        objec.CreatedBy = Convert.ToInt32(Session["ContactID"]);
        objec.CreatedOn = DateTime.Now;

        // Call the method to perform the save or update operation
        string message = objec.PerformCEPD_SubCategorySave(objec);

        // Check if the operation was successful and show appropriate message
        if (message.Contains("updated"))
        {
            ImpromptuHelper.ShowSuccess("Subcategory edited successfully!");
        }
        else
        {
            ImpromptuHelper.ShowError("Failed to edit subcategory!");
        }
    }


    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnDelete = (ImageButton)sender;

        // Get the CommandArgument, which holds the category_id
        string categoryId = btnDelete.CommandArgument;

        // Call the delete method/function passing the category_id
        DeleteCategory(categoryId);

        // Rebind the GridView to refresh the data
        BindGrid();
    }


    private void DeleteSubCategory(string categoryId)
    {

        objec.CEPD_SUBCategoryDelete(categoryId);
        ImpromptuHelper.ShowSuccess("SubCategory Delete Successfully!");
    }

    private void DeleteCategory(string categoryId)
    {
        
        objec.CEPD_CategoryDelete(categoryId);
        ImpromptuHelper.ShowSuccess("Category Delete Successfully!");
    }
    ///
    ///SubCatagory///
    ///

    //[SP_CEPD_SubCategory]

    protected void Btn_SubCategory(object sender, EventArgs e)
    {
        if (Btn_SubCat.Text == "Save")
        {
            if (string.IsNullOrWhiteSpace(txtSubcategory.Text))
            {
                ImpromptuHelper.ShowError("Subcategory name cannot be empty!");
                return;
            }

            objec.SubcategoryName = txtSubcategory.Text;
            objec.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue); // Assuming you have a DropDownList for category selection
            objec.CreatedBy = Convert.ToInt32(Session["ContactID"]);
            objec.CreatedOn = DateTime.Now;
            string message = "";
            objec.PerformCEPD_SubCategorySave(objec);
           
            
                ImpromptuHelper.ShowSuccess("Subcategory inserted successfully!");

            BindGrid_SubCate();
        }

        // Rebind the GridView after saving or editing the subcategory
        if (Btn_SubCat.Text == "Edit")
        {
            string subcategoryId = subCat_id.Value;
            Edit_sub(subcategoryId);
            BindGrid_SubCate();
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "SetTabActive", "$('.nav-tabs a[href=\"#Subcategory\"]').tab('show'); $('.nav-tabs a[href=\"#Category\"]').removeClass('active');", true);
    }

    protected void btnSubCatEdit_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnEdit = (ImageButton)sender;

        // Get the category ID and category name from the CommandArgument and CommandName
        string[] args = btnEdit.CommandArgument.Split(',');
        string categoryId = btnEdit.CommandName;
        string subcategoryId = args[1];
        string subCategoryName = args[2];
       
        txtSubcategory.Text = subCategoryName;
        ddlCategory.SelectedValue = categoryId;
        subCat_id.Value = subcategoryId;
        Btn_SubCat.Text = "Edit";
        ScriptManager.RegisterStartupScript(this, GetType(), "SetTabActive", "$('.nav-tabs a[href=\"#Subcategory\"]').tab('show'); $('.nav-tabs a[href=\"#Category\"]').removeClass('active');", true);
    }

    protected void btnSubCateDelete_Click(object sender, ImageClickEventArgs e)
    {
        // Get the reference to the ImageButton that triggered the event
        ImageButton btnDelete = (ImageButton)sender;

        // Get the CommandArgument, which holds the category_id
        string SubcategoryId = btnDelete.CommandArgument;

        // Call the delete method/function passing the category_id
        DeleteSubCategory(SubcategoryId);

        // Rebind the GridView to refresh the data
        BindGrid_SubCate();
        ScriptManager.RegisterStartupScript(this, GetType(), "SetTabActive", "$('.nav-tabs a[href=\"#Subcategory\"]').tab('show'); $('.nav-tabs a[href=\"#Category\"]').removeClass('active');", true);
    }


    private void loadCategory()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();


            dt = objec.GetCategory(objec);

            objBase.FillDropDown(dt, ddlCategory, "category_id", "category_name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
