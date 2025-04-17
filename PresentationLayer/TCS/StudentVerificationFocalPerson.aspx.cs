using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_TCS_StudentVerificationFocalPerson : System.Web.UI.Page
{
    BLLStudentVerificationFocalPerson ObjECT = new BLLStudentVerificationFocalPerson();
    DALBase objBase = new DALBase();
    BLLRegion oDALRegion = new BLLRegion();
    BLLStudent objstudent = new BLLStudent();
    int UL_ID;int center_id ;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Your existing code here...

            if (!IsPostBack)
            {
                if (Session["ContactID"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }

                UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());

                int moID = Int32.Parse(Session["moID"].ToString());
                BLLRegion oDALRegion = new BLLRegion();

                oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
                DataTable dt = oDALRegion.RegionFetch(oDALRegion);
                DataRow[] selectedRows = dt.Select("Region_Id IN (40000000)");
                DataTable filteredDt = selectedRows.CopyToDataTable();
                objBase.FillDropDown(filteredDt, ddl_region, "Region_Id", "Region_Name");

                if (UL_ID==4)
                {
                    ddl_region.Visible = false;
                    //ddlmonth.Visible = false;
                    ddl_Center.Visible = false;
                    //ddMonth.Visible = false;
                    TdCenter.Visible = false;
                    tdRegion.Visible = false;
                }

               
                LoadMonth();
                if (UL_ID == 4)
                {
                    center_id= Int32.Parse(Session["Center_Id"].ToString());

                    BindGrid(center_id, "");
                }
                else
                {
                    BindGrid(0, "");
                }
                  
                
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindGrid(int val, string month_name)
    {
        try
        {
            DataTable dt = ObjECT.StudentVerificationFocalPerson_List(val, month_name);
            if (dt != null)
            {
                gvFocaPerson.DataSource = dt;

                // Attach the RowDataBound event handler
                gvFocaPerson.RowDataBound += gvFocaPerson_RowDataBound;

                gvFocaPerson.DataBind();
            }
            else
            {
                gvFocaPerson.DataSource = null;
                gvFocaPerson.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


    //protected void gvFocaPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        DataRowView rowView = (DataRowView)e.Row.DataItem;

    //        // Assuming "Employee_code" is the correct column name, modify it if needed
    //        string employeeCode = rowView["Employee_code"].ToString();

    //        if (string.IsNullOrEmpty(employeeCode))
    //        {
    //            // Set the background color to red for rows with empty Employee_code
    //            e.Row.BackColor = System.Drawing.Color.PapayaWhip;
    //        }
    //        else
    //        {
    //            // Set the default background color for other rows
    //            e.Row.BackColor = System.Drawing.Color.Transparent; // You can set it to another color if needed
    //        }
    //    }
    //}

    protected void FetchDataButton_Click(object sender, EventArgs e)
    {
        // Access the GridView row that contains the button
        GridViewRow gridViewRow = (GridViewRow)((Control)sender).NamingContainer;

        // Access TextBox and other controls in the same row
        TextBox textBox = (TextBox)gridViewRow.FindControl("TextBox1");

        // Get values from the controls
        string employeeCode = textBox.Text;

        // Get Center_id from the row
        ObjECT.Center_Id = GetIntFromCell(gridViewRow, "Center ID");

        // Get Region_id from the row
        ObjECT.Region_Id = GetIntFromCell(gridViewRow, "Region ID");

        // Use the values as needed
        ObjECT.Employee_Code = employeeCode;

        // Now you can use these values in your stored procedure or perform any other logic
        DataTable dt = ObjECT.StudentVerificationFocalPerson_EmployeeDetails(ObjECT);

       
        // Check if the DataTable is not null and has rows
        if (dt != null && dt.Rows.Count > 0)
        {
            // Assuming your email column in DataTable is named "Email"
            string email = dt.Rows[0]["Email"].ToString();
            string FullName = dt.Rows[0]["FullName"].ToString();
            string DesigName = dt.Rows[0]["DesigName"].ToString();

            // Find the Label control in the row
            Label lblEmail = (Label)gridViewRow.FindControl("lblEmail");
            Label lblFullName = (Label)gridViewRow.FindControl("lblUserName");
            Label lblDesigName = (Label)gridViewRow.FindControl("lblUserType");
           lblEmail.Text = email;
            lblFullName.Text = FullName;
            lblDesigName.Text = DesigName;
            
        }
    }


    private int GetIntFromCell(GridViewRow row, string columnName)
    {
        int result;
        TableCell cell = row.Cells.Cast<TableCell>().FirstOrDefault(c => ((DataControlFieldCell)c).ContainingField.HeaderText == columnName);

        if (cell != null && int.TryParse(cell.Text, out result))
        {
            return result;
        }

        // Handle the case where the cell is not found or the conversion fails
        return 0; // or throw an exception, set a default value, etc.
    }


    protected void gvFocaPerson_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvFocaPerson.Rows[rowIndex];

            // Perform custom logic or call your update method
            UpdateFocalPerson(row);

            // Exit edit mode
            gvFocaPerson.EditIndex = -1;

            // Refresh the GridView
            BindGrid(0,"");
        }
    }
    private void UpdateFocalPerson(GridViewRow row)
    {
        try
        {
            // Access Focal_Person_Id from DataKeys
            int focalPersonId = Convert.ToInt32(gvFocaPerson.DataKeys[row.RowIndex].Value);

            // Initialize a dictionary to store column data
            Dictionary<string, string> columnData = new Dictionary<string, string>();

            // Access controls in the row and retrieve their values
            TextBox txtEmployeeCode = (TextBox)row.FindControl("TextBox1");
            Label lblUserName = (Label)row.FindControl("lblUserName");
            Label lblUserType = (Label)row.FindControl("lblUserType");
            Label lblEmail = (Label)row.FindControl("lblEmail");

            // Add column data to the dictionary
            columnData.Add("Employee_code", txtEmployeeCode.Text);
            columnData.Add("User_name", lblUserName.Text);
            columnData.Add("DesigName", lblUserType.Text);
            columnData.Add("Email", lblEmail.Text);

            // Use this data in your update logic or stored procedure
            ObjECT.Focal_Person_Id = focalPersonId;
            ObjECT.Employee_Code = columnData.ContainsKey("Employee_code") ? columnData["Employee_code"] : "";
            ObjECT.User_Name = columnData.ContainsKey("User_name") ? columnData["User_name"] : "";
            ObjECT.DesigName = columnData.ContainsKey("DesigName") ? columnData["DesigName"] : "";
            ObjECT.Email = columnData.ContainsKey("Email") ? columnData["Email"] : "";

            int dt = ObjECT.Student_Verification_FocalPerson_Update(ObjECT);
            gvFocaPerson.EditIndex = -1;

            // Refresh the GridView
            BindGrid(0, "");
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_region.SelectedValue == "")
            {
                ddl_Center.Items.Clear();
                ddl_Center.Items.Insert(0, new ListItem("Select", ""));
                
            }
            else
            {
                ///filling country
                ///
                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);

                // Assuming the column names are "center_Id" and "center_name"
 
           
		var filteredData = dt.AsEnumerable()
.Where(row => !new[] { 40102001, 40109001, 40109002 }.Contains(row.Field<int>("center_Id")))
.CopyToDataTable();
                objBase.FillDropDown(filteredData, ddl_Center, "center_Id", "center_name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddl_Center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string month = "";
            if (ddl_Center.SelectedValue != "0")
            {
               int vals= Int32.Parse(ddl_Center.SelectedValue.ToString());
                if (ddlmonth.SelectedIndex > 0)
                {
                    month = ddlmonth.SelectedItem.Text;
                    BindGrid(vals, month);
                }
                else
                {
                    BindGrid(vals, month);
                }
            }
            else
                BindGrid(0, month);


        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void LoadMonth()
    {
        DataTable dt = objstudent.StudentVerificationMonth(objstudent);
        if (dt.Rows.Count > 0)
        {
            objBase.FillDropDown(dt, ddlmonth, "MonthId", "MonthDesc");
            Session["ActiveDaysTable"] = dt;
        }
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        int vals = 0;
        UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());
        center_id = Int32.Parse(Session["Center_Id"].ToString());
        if (!string.IsNullOrEmpty(ddl_Center.SelectedValue))
        {
            vals = Int32.Parse(ddl_Center.SelectedValue);
            // Rest of your code...
        }

        ///int vals = Int32.Parse(ddl_Center.SelectedValue);
        string month ="";
        if (ddlmonth.SelectedIndex > 0)
        {
            DataTable dt = (DataTable)Session["ActiveDaysTable"];
            string exp = "MonthDesc = '" + ddlmonth.SelectedItem.Text + "'";

            DataRow[] row = dt.Select(exp);

            month = ddlmonth.SelectedItem.Text;
        }
        if (UL_ID == 4)
        {
            center_id = Int32.Parse(Session["Center_Id"].ToString());

            BindGrid(center_id, month);
        }
        else
        {
            BindGrid(vals, month);
        }

    }

    protected void gvFocaPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            // Assuming "Employee_code" is the correct column name, modify it if needed
            string employeeCode = rowView["Employee_code"].ToString();

            if (string.IsNullOrEmpty(employeeCode))
            {
                // Set the background color to red for rows with empty Employee_code
                e.Row.BackColor = System.Drawing.Color.PapayaWhip;
            }
            else
            {
                // Set the default background color for other rows
                e.Row.BackColor = System.Drawing.Color.Transparent; // You can set it to another color if needed
            }

            // Find the TextBox control in the row
            TextBox textBox = (TextBox)e.Row.FindControl("TextBox1");

            // Find the Label control in the row
            Label label = (Label)e.Row.FindControl("Label1");

            // Calculate the label text based on the row index
            int rowIndex = e.Row.RowIndex + 1; // Add 1 to make it 1-based
            string[] labelTexts = { "AIMS+Administrator", "School Accountant", "SLT" };

            // Calculate the index for the labelTexts array
            int labelIndex = (rowIndex - 1) % labelTexts.Length;

            // Set the label text
            label.Text = labelTexts[labelIndex];
            label.Font.Bold = true;
            label.Style["color"] = "#750000";
        }
    }


}
