using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_CEPD_TrainerProfile : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_TrainerProfile objec = new BLLCEPD_TrainerProfile();
    BLLCEPD_Category obj = new BLLCEPD_Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadQualifictions(null);
                BindGrid();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }

        }


    }




    protected void Btn_Save(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtERPNumber.Text))
        {
            ImpromptuHelper.ShowPrompt("Please input ERP# for details");
            return;
        }

        // Call JavaScript function to save selected trainings
        ScriptManager.RegisterStartupScript(this, this.GetType(), "saveSelectedTrainings", "saveSelectedTrainings();", true);

        // Retrieve selected training IDs from hidden field
        string selectedTrainings = hidSelectedTrainings.Value;
        string selectedTrainings_names = hidSelectedTrainingText.Value;

        // Get selected items from ddlProfessionalQualificationTCS
        List<string> selectedQualificationsTCS = new List<string>();
        foreach (ListItem item in ddlProfessionalQualificationTCS.Items)
        {

            selectedQualificationsTCS.Add(item.Text);

        }

        // Get selected items from ddlProfessionalQualificationOutsideTCS
        //List<string> selectedQualificationsOutsideTCS = new List<string>();
        //foreach (ListItem item in ddlProfessionalQualificationOutsideTCS.Items)
        //{

            //selectedQualificationsOutsideTCS.Add(item.Text);

        //}

        // Combine selected items into comma-separated strings
        string combinedQualificationsTCS = string.Join(",", selectedQualificationsTCS);
        //string combinedQualificationsOutsideTCS = string.Join(",", selectedQualificationsOutsideTCS);

        // Assuming you have a method in BLLCEPD_TrainerProfile to save or update trainer profile
        BLLCEPD_TrainerProfile trainerProfile = new BLLCEPD_TrainerProfile
        {
            Id = int.Parse(txtTrainerId.Value),
            ERPNumber = txtERPNumber.Text,
            TrainerName = txtTrainerName.Text,
            Designation = txtDesignation.Text,
            Branch = txtBranch.Text,
            Expertise = txtExpertise.Text,
            ExperienceTCS = txtExperienceTCS.Text,
            ExperienceOutsideTCS = txtExperienceOutsideTCS.Text,
            AcademicQualification = txtAcademicQualification.Text,
            ProfessionalQualificationTCS = combinedQualificationsTCS,
            //ProfessionalQualificationOutsideTCS = combinedQualificationsOutsideTCS,   //*
            ProfessionalQualificationOutsideTCS = txtProfessionalQualificationOutsideTCS.Text.ToString().Trim(),
            Trainings = selectedTrainings,
            Training_Name = selectedTrainings_names,
            CreatedBy = Convert.ToInt32(Session["ContactID"]),
            CreatedOn = DateTime.Now
        };

        // Call the method to save or update trainer profile
        string message = objec.SaveOrUpdateTrainerProfile(trainerProfile);
        ImpromptuHelper.ShowPrompt(message);
        //BindGrid();
        Response.Redirect("~/PresentationLayer/TCS/CEPD_TrainerProfile.aspx", false);

    }


    protected void Edit(object sender, EventArgs e)
    {
        ImageButton btnEdit = (ImageButton)sender;

        // Get the category ID and category name from the CommandArgument and CommandName
        string Id = btnEdit.CommandArgument;
        DataTable dt = objec.GetTrainerProfile_BYID(Id);
        if (dt.Rows.Count > 0)
        {
            txtERPNumber.Text = dt.Rows[0]["ERPNumber"].ToString();
            txtAcademicQualification.Text = dt.Rows[0]["AcademicQualification"].ToString();
            txtBranch.Text = dt.Rows[0]["Branch"].ToString();
            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            txtExperienceOutsideTCS.Text = dt.Rows[0]["ExperienceOutsideTCS"].ToString();
            txtExperienceTCS.Text = dt.Rows[0]["ExperienceTCS"].ToString();
            txtExpertise.Text = dt.Rows[0]["Expertise"].ToString();
            txtTrainerId.Value = dt.Rows[0]["Id"].ToString();
            txtTrainerName.Text = dt.Rows[0]["TrainerName"].ToString();
            //string combinedProfessionalQualificationOutsideTCS = dt.Rows[0]["ProfessionalQualificationOutsideTCS"].ToString();
            string combinedProfessionalQualificationTCS = dt.Rows[0]["ProfessionalQualificationTCS"].ToString();
            //string[] qualificationsArray = combinedProfessionalQualificationOutsideTCS.Split(',');
            string[] qualificationsArrayTCS = combinedProfessionalQualificationTCS.Split(',');
           // ddlProfessionalQualificationOutsideTCS.Items.Clear();
            ddlProfessionalQualificationTCS.Items.Clear();
            txtProfessionalQualificationOutsideTCS.Text=dt.Rows[0]["ProfessionalQualificationOutsideTCS"].ToString();
            //foreach (string qualification in qualificationsArray)
            //{

            //    ddlProfessionalQualificationOutsideTCS.Items.Add(new ListItem(qualification.Trim(), qualification.Trim()));
            //}
            foreach (string qualificationtcs in qualificationsArrayTCS)
            {

                ddlProfessionalQualificationTCS.Items.Add(new ListItem(qualificationtcs.Trim(), qualificationtcs.Trim()));

            }

            string combinedTrainingIds = dt.Rows[0]["Trainings"].ToString();
            string[] trainingIdsArray = combinedTrainingIds.Split(',');
            //string selectedTrainings = hidSelectedTrainings.Value;
            //string selectedTrainings_names = hidSelectedTrainingText.Value;
            hidSelectedTrainings.Value = combinedTrainingIds;
            hidSelectedTrainingText.Value = dt.Rows[0]["Training_Name"].ToString();
            LoadQualifictions(trainingIdsArray);

        }


    }



    private void BindGrid()
    {
        // Call the method from BLL to get the data
        //objec.action = "GET";
        GridtrainerProfile.DataSource = null;
        GridtrainerProfile.DataBind();

        DataTable dt = objec.GetTrainerProfile();
        GridtrainerProfile.DataSource = dt;
        GridtrainerProfile.DataBind();
        //Response.Redirect("CEPD_TrainerProfile.aspx");
        
    }

    protected void Btn_GetProfile(object sender, EventArgs e)
    {
        int trainerId = 0;
        if (txtERPNumber.Text != "")
            trainerId = int.Parse(txtERPNumber.Text);
        DataTable profileData = objec.GetERPProfile(trainerId);
        if (profileData != null && profileData.Rows.Count > 0)
        {
            ddlProfessionalQualificationTCS.Items.Clear(); // Clear existing items
                                                           // ddlProfessionalQualificationOutsideTCS.Items.Clear(); // Clear existing items

            System.Text.StringBuilder trainingNamesoutside = new System.Text.StringBuilder();
            foreach (DataRow row in profileData.Rows)
            {
                // Check if Training_By is "TCS Conducted"
                if (row["Training_By"].ToString() == "TCS Conducted")    //TCS Conducted
                {
                    string trainingName = row["Training_Name"].ToString();
                    ddlProfessionalQualificationTCS.Items.Add(new ListItem(trainingName, trainingName));
                }
                // Check if Training_By is "Foreign"
                else if (row["Training_By"].ToString() == "Foreign")   //Foreign
                {
                   
                    if (trainingNamesoutside.Length > 0)
                    {
                        trainingNamesoutside.Append(", ");
                    }

                    trainingNamesoutside.Append(row["Training_Name"].ToString());
                    //ddlProfessionalQualificationOutsideTCS.Items.Add(new ListItem(trainingName, trainingName));
                    txtProfessionalQualificationOutsideTCS.Text = trainingNamesoutside.ToString();
                }
            }

            // Set other controls accordingly
            txtERPNumber.Text = profileData.Rows[0]["Employee_Number"].ToString();
            txtTrainerName.Text = profileData.Rows[0]["Employee_Name"].ToString();
            txtDesignation.Text = profileData.Rows[0]["Designation"].ToString();
            txtBranch.Text = profileData.Rows[0]["Organization"].ToString();
            txtAcademicQualification.Text = profileData.Rows[0]["Qualification"].ToString();
            txtExperienceTCS.Text = profileData.Rows[0]["Length_of_Service"].ToString();

        }
        else
        {
            ImpromptuHelper.ShowPrompt("Trainer profile not found.");
            txtERPNumber.Text = "";
            txtTrainerName.Text = "";
            txtDesignation.Text = "";
            txtBranch.Text = "";
            txtAcademicQualification.Text = "";
            txtExperienceTCS.Text = "";
        }
        LoadQualifictions(null);
    }



    private void LoadQualifictions(string[] trainingIdsArray)
    {
        try
        {
            DataTable Qul = obj.GetQualification(obj);
            string dropdownHtml = "";
            foreach (DataRow row in Qul.Rows)
            {
                string Name = row["Qualification"].ToString();
                string Id = row["id"].ToString();

                // Check if the current training ID is in the array of selected training IDs
                bool isChecked = (trainingIdsArray != null && trainingIdsArray.Contains(Id));

                // Generate HTML for checkbox and label with unique IDs
                dropdownHtml += "<label style='display: flex; align-items: center;'>";
                dropdownHtml += "<input type='checkbox' id='chk_" + Id + "' value='" + Id + "'";
                if (isChecked)
                {
                    dropdownHtml += " checked";
                }
                dropdownHtml += " style='margin-right: 5px;'>";
                dropdownHtml += Name + "</label>";
            }

            // Serialize the dropdown HTML to JSON
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonData = jsSerializer.Serialize(dropdownHtml);

            // Register the script to append dropdown options
            ScriptManager.RegisterStartupScript(this, this.GetType(), "appendOptions", "appendOptions(" + jsonData + ");", true);

            // Register the script to handle checkbox change event
            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindCheckboxChange", "$(document).ready(function () { $('input[type=\"checkbox\"]').change(function () { var selectedTrainings = []; var selectedTrainingTexts = []; $('input[type=\"checkbox\"]:checked').each(function () { selectedTrainings.push($(this).val()); selectedTrainingTexts.push($(this).parent().text().trim()); }); $('#" + hidSelectedTrainings.ClientID + "').val(selectedTrainings.join(',')); $('#" + hidSelectedTrainingText.ClientID + "').val(selectedTrainingTexts.join(',')); }); });", true);

        }
        catch (Exception ex)
        {
            // Handle exceptions
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }





}
