using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class PresentationLayer_CEPD_TrainingVideoUploader : System.Web.UI.Page
{
    BLLCEPD_Category objec = new BLLCEPD_Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView(); 

        }
    }
    protected void Btn_VidoeUpload(object sender, EventArgs e)
    {
        if (fileVideo.HasFile)
        {
            try
            {
                string folderpath = "~/PresentationLayer/TCS/CEPD_Videos/";
                string LinkPage = "~/CEPD_Video.aspx";
                // Specify the path where you want to save the uploaded video
                string uploadFolderPath = Server.MapPath(folderpath);
                string LinkedPage = Server.MapPath(folderpath);

                // Check if the upload folder exists, if not, create it
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                // Get the filename and extension of the uploaded file
                string fileName = Path.GetFileName(fileVideo.FileName);
                string filePath = Path.Combine(uploadFolderPath, fileName);
                string _path = Path.Combine(folderpath, fileName);
                string time= StopTime.Text;
                string Link_path = Path.Combine(LinkPage, fileName, time);
                // Save the uploaded file to the specified folder
                fileVideo.SaveAs(filePath);
                objec.path = _path;
                objec.StopTime = StopTime.Text;
                objec.TrainingName = txtTraining.Text;
                objec.Description = txtDescription.Text;
                objec.Link = Link_path;
              

                objec.TrainingVideoUploade_Save(objec);

                BindGridView();

                // Clear the TextBoxes after successful upload
                txtTraining.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during file upload
                // You can display an error message or log the exception
                // For simplicity, let's display an alert with the error message
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Error uploading file: " + ex.Message + "');", true);
            }
        }
        else
        {
            // If no file is selected, display an alert
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please select a file to upload.');", true);
        }
    }

   

    private void BindGridView()
    {
        DataTable dt = new DataTable();
            dt = objec.TrainingVideoUploade_Get();
        GridView.DataSource = dt;
        GridView.DataBind();
    }
    protected void Edit(object sender, EventArgs e)
    {
        // Cast the sender back to an ImageButton to access its properties
        ImageButton btnEdit = (ImageButton)sender;

        // Get the category ID from the CommandArgument
        string Id = btnEdit.CommandArgument;

        // Find the row index of the GridView based on the clicked button
        GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
        int rowIndex = row.RowIndex;

        // Now, you can retrieve data from the GridView using the row index
        // For example, to retrieve data from the first column:
        string training = GridView.Rows[rowIndex].Cells[1].Text;
        string description = GridView.Rows[rowIndex].Cells[2].Text;
        string path = GridView.Rows[rowIndex].Cells[3].Text;
        //string Link = GridView.Rows[rowIndex].Cells[4].Text;

        // Then, you can assign this data to your TextBoxes or other controls
        txtTraining.Text = training;
        txtDescription.Text = description;
        txtLink.Text = path;
        txtLink.Enabled = true;
        // You can do the same for other controls as needed
    }
    //protected void CopyToClipboard(object sender, EventArgs e)
    //{
    //    // Set the text in the TextBox to be copied
    //    string textToCopy = txtLink.Text;

    //    // Register a client-side script to copy text to clipboard using JavaScript
    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "copyScript", "copyToClipboard('" + textToCopy + "');", true);
    //}


}
