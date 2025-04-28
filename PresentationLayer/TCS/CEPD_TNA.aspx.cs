using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

public partial class PresentationLayer_CEPD_TNA : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    BLLCEPD_Category obje = new BLLCEPD_Category();
    BLLCEPD_TrainerProfile objec = new BLLCEPD_TrainerProfile();
    _DAL_CEPD_TNA objTNA = new _DAL_CEPD_TNA();
    int UL_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }
       
        if (!IsPostBack)
        {
            loadCategory();
            LoadTrainer();
            if (Request.QueryString["TNAID"] != null)
            {
                btnSave.Text = "Update";

                LoadTNARecord();
            }
            loadKeyStages();
            LoadTeachers();
            DataRow row = (DataRow)Session["rightsRow"]; 
            int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
           
            if (UserLevel_ID  == 4) //Capmus Office
            {
                ddlTrainer.Enabled = false;
            }
            else
            {
                ddlTrainer.Enabled = true;
            }
        }
    }
    public void LoadTrainer()
    {
        DataTable dt = objec.GetTrainerProfile();

        objBase.FillDropDown(dt, ddlTrainer, "ID", "TrainerName");
    }
    public void LoadTNARecord()
    {
        try
        {
            int TNAID = int.Parse(Request.QueryString["TNAID"].ToString());
            DataTable dt = objTNA.GetTNAList_ByID(TNAID);
            if (dt.Rows.Count > 0)
            {
                hdTNAID.Value = dt.Rows[0]["TNA_Id"].ToString();
                txtRegion.Text = dt.Rows[0]["Region_Name"].ToString();
                hdRegionID.Value = dt.Rows[0]["Region_ID"].ToString();
                txtSchoolHead.Text = dt.Rows[0]["Center_Code"].ToString();
                txtcenter.Value = dt.Rows[0]["Center_ID"].ToString();
                txtCampusName.Text = dt.Rows[0]["Center_Name"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                txtCurrentStaff.Text = dt.Rows[0]["TotalTeacher"].ToString();
                hidSelectedKeyStage.Value = dt.Rows[0]["KeyStages"].ToString();
                hidSelectedKeyStageText.Value = dt.Rows[0]["KeyStagesName"].ToString();
                hidSelectedTeacher.Value = dt.Rows[0]["TeacherERPNumber"].ToString();
                hidSelectedTeacherText.Value = dt.Rows[0]["TeacherName"].ToString();
                txtTotalTeachers.Text = dt.Rows[0]["KSTotalTeacher"].ToString();
                ddlTrainingRequired.SelectedValue = dt.Rows[0]["TrainingValue"].ToString();
                //ddlTrainingRequired.Text = dt.Rows[0]["TrainingType"].ToString();
                
                ddlCategory.SelectedValue = dt.Rows[0]["Category_ID"].ToString();
                ddlCategory_SelectedIndexChanged(null, null);
                ddlSubCategory.SelectedValue = dt.Rows[0]["SubCategory_ID"].ToString();
                txtLevels.Text = dt.Rows[0]["LEVEL"].ToString();
                ddlPreferredMode.SelectedValue = dt.Rows[0]["PreferredModeOfTraining"].ToString();
                txtPreferredDateTime.Text = Convert.ToDateTime(dt.Rows[0]["PreferredDateTime"]).ToString("yyyy-MM-dd");
                txtExpectedTrainees.Text = dt.Rows[0]["ExpectedTrainees"].ToString();
                txtConfirmedTrainees.Text = dt.Rows[0]["ConfirmedTraineesCount"].ToString();
                hdConfirmedTrainees.Value = dt.Rows[0]["ConfirmedTraineesCount"].ToString();
                ddlTrainer.SelectedValue = dt.Rows[0]["AssignedTrainer"].ToString();
                if (dt.Rows[0]["SIQAReportName"].ToString() != "")
                {
                    lbtnSiqareport.Visible = true;
                    lbtnSiqareport.Text = dt.Rows[0]["SIQAReportName"].ToString();
                    hdSIQFilePath.Value = dt.Rows[0]["SIQAReportPath"].ToString();

                }
                else
                {
                    lbtnSiqareport.Visible = false;
                    lbtnSiqareport.Text = "";
                    hdSIQFilePath.Value = "";
                }
                //fuSIQAReport.FileName = dt.Rows[0][""].ToString();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void Btn_GetDetails(object sender, EventArgs e)
    {
        string code = txtSchoolHead.Text;
        if (string.IsNullOrWhiteSpace(code))
        {
            ImpromptuHelper.ShowPrompt("Campus Code cannot be empty!");
            return;

        }
        DataTable profileData = objec.GetTNA_Detils(code);
        if (profileData != null && profileData.Rows.Count > 0)
        {
            txtCampusName.Text = profileData.Rows[0]["Center_Name"].ToString();
            txtCity.Text = profileData.Rows[0]["City_Name"].ToString();
            txtRegion.Text = profileData.Rows[0]["Region_Name"].ToString();
            hdRegionID.Value = profileData.Rows[0]["Region_ID"].ToString();
            txtCurrentStaff.Text = profileData.Rows[0]["UserCount"].ToString();
            txtcenter.Value = profileData.Rows[0]["Center_id"].ToString();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Trainer profile not found.");
        }
        loadKeyStages();
        LoadTeachers();
    }
    protected void Btn_GetTotalTeachers(object sender, EventArgs e)
    {
        string groupid = hidSelectedKeyStage.Value;
        string groupName = hidSelectedKeyStageText.Value;
        DataTable dt = new DataTable();
        string centerid = txtcenter.Value;

        dt = objec.GetTNA_KeyStages_emplyoeecount(centerid, groupid);
        if (dt.Rows.Count > 0)
        {
            txtTotalTeachers.Text = dt.Rows[0]["total"].ToString();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Trainer profile not found.");
        }

        loadKeyStages();
        LoadTeachers();
        hidSelectedKeyStage.Value = groupid;
        hidSelectedKeyStageText.Value = groupName;
    }


    private void loadCategory()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();
            dt = obje.GetCategory(obje);
            objBase.FillDropDown(dt, ddlCategory, "category_id", "category_name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void loadsubCategory()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();
            BLLCEPD_Category objsubCat = new BLLCEPD_Category();
            int CategoryID = 0;
            if (ddlCategory.SelectedValue != "")
                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

            objsubCat.CategoryId = CategoryID;
            dt = obje.GetSubCategory_ByCategoryID(objsubCat);

            objBase.FillDropDown(dt, ddlSubCategory, "subcategory_id", "subcategory_name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadsubCategory();
        loadKeyStages();
        LoadTeachers();
    }
    public void LoadTeachers()
    {
        try
        {
            string _Teacherid = hidSelectedTeacher.Value;
            //string TeacherName = hidSelectedTeacherText.Value;
            string[] trainingIdsArray = _Teacherid.Split(',');

            BLLSection_Subject objSecSub = new BLLSection_Subject();
            objSecSub.Center_Id = Convert.ToInt32(txtcenter.Value);
            DataTable dtTeacher = objSecSub.Section_SubjectSelectTeacherByCenter_Id(objSecSub);
            //DataTable trainings = objec.SelectTrainings();
            string dropdownHtml = "";

            foreach (DataRow row in dtTeacher.Rows)
            {
                string TeacherName = row["Name"].ToString();
                string TeacherId = row["user_Id"].ToString();

                // Check if the current training ID is in the array of selected training IDs
                bool isChecked = (trainingIdsArray != null && trainingIdsArray.Contains(TeacherId));

                // Generate HTML for checkbox and label with unique IDs
                dropdownHtml += "<label style='display: flex; align-items: center;'>";
                dropdownHtml += "<input type='checkbox' class='checkbox-Teachers' id='chk_" + TeacherId + "' value='" + TeacherId + "'";
                if (isChecked)
                {
                    dropdownHtml += " checked";
                }
                dropdownHtml += " style='margin-right: 5px;'>";
                dropdownHtml += TeacherName + "</label>";
            }

            // Serialize the dropdown HTML to JSON
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonData = jsSerializer.Serialize(dropdownHtml);

            // Register the script to append dropdown options
            ScriptManager.RegisterStartupScript(this, this.GetType(), "appendTeachers", "appendTeachers(" + jsonData + ");", true);


            // Register the script to handle checkbox change event
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "bindCheckboxChange", "$(document).ready(function () { $('input[type=\"checkbox\"]').change(function () { var selectedTeachers = []; var selectedTeacherTexts = []; $('input[type=\"checkbox\"]:checked').each(function () { selectedTeachers.push($(this).val()); selectedTeacherTexts.push($(this).parent().text().trim()); }); $('#" + hidSelectedTeacher.ClientID + "').val(selectedTeachers.join(',')); $('#" + hidSelectedTeacherText.ClientID + "').val(selectedTeacherTexts.join(',')); }); });", true);

        }
        catch (Exception ex)
        {
            // Handle exceptions
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void loadKeyStages()
    {
        try
        {
            string groupid = hidSelectedKeyStage.Value;
            string groupName = hidSelectedKeyStageText.Value;
            string[] trainingIdsArray = groupid.Split(',');

            BLLSection_Subject objSecSub = new BLLSection_Subject();
            objSecSub.Center_Id = Convert.ToInt32(txtcenter.Value);
            DataTable dtTeacher = objec.GetTNA_KeyStages();
            //DataTable trainings = objec.SelectTrainings();
            string dropdownHtml = "";

            foreach (DataRow row in dtTeacher.Rows)
            {
                string Name = row["Group_Name"].ToString();
                string Id = row["Group_ID"].ToString();

                // Check if the current training ID is in the array of selected training IDs
                bool isChecked = (trainingIdsArray != null && trainingIdsArray.Contains(Id));

                // Generate HTML for checkbox and label with unique IDs
                dropdownHtml += "<label style='display: flex; align-items: center;'>";
                dropdownHtml += "<input type='checkbox' class='checkbox-Trainings' id='chk_" + Id + "' value='" + Id + "'";
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "appendKeyStage", "appendKeyStage(" + jsonData + ");", true);

            // Register the script to handle checkbox change event
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "bindCheckboxChange", "$(document).ready(function () { var selectedKeyStage = []; var selectedKeyStageText = []; $('.options-container_KefStage input[type=\"checkbox\"]').change(function () {  $('.options-container_KefStage input[type=\"checkbox\"]:checked').each(function () { selectedKeyStage.push($(this).val()); selectedKeyStageText.push($(this).parent().text().trim()); }); $('#" + hidSelectedKeyStage.ClientID + "').val(selectedKeyStage.join(',')); $('#" + hidSelectedKeyStageText.ClientID + "').val(selectedKeyStageText.join(',')); }); });", true);



            //LoadTeachers();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    string folderPath = "";
    protected void btnSave_Click(object sender, EventArgs e)
    {
        divMessage.Visible = false;
        if (txtSchoolHead.Text == "" || hdRegionID.Value == "")
        {
            loadKeyStages();
            LoadTeachers();
           
            spanSchoolHead.Visible = true;            
            //ImpromptuHelper.ShowError("Please enter code and serch button press.");            
            return;
        }
        else
        {
            spanSchoolHead.Visible = false;
        }
        if (hidSelectedKeyStage.Value == "")
        {
            loadKeyStages();
            LoadTeachers();
            spanKeyStage.Visible = true;
            return;
        }
        else
        {
            spanKeyStage.Visible = false;
        }
        if (ddlCategory.SelectedValue == "0")
        {
            loadKeyStages();
            LoadTeachers();
            //ddlCategory.BackColor = System.Drawing.Color.OrangeRed;
            spanCategory.Visible = true;
            return;
        }
        else
        {
            ddlCategory.BackColor = System.Drawing.Color.White;
        }
        if (ddlSubCategory.SelectedValue == "0")
        {
            loadKeyStages();
            LoadTeachers();
            spanSubCategory.Visible = true;
            return;
        }
        else
        {
            spanSubCategory.Visible = false;
        }
        if (txtPreferredDateTime.Text == "")
        {
            loadKeyStages();
            LoadTeachers();
            txtPreferredDateTime.BackColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            txtPreferredDateTime.BackColor = System.Drawing.Color.White;
            spanSubCategory.Visible = false;
        }
        string dbPath = "";
        if (fuSIQAReport.HasFile)
        {
            folderPath = Server.MapPath("~/PresentationLayer/TCS/Files/CEPD/");
            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }
            //Save the File to the Directory (Folder).
            dbPath = folderPath + Path.GetFileName(fuSIQAReport.FileName);
            fuSIQAReport.SaveAs(dbPath);
        }
        BLLCEPD_TNA obj_TNA = new BLLCEPD_TNA();
        obj_TNA.Region_Name = txtRegion.Text;
        obj_TNA.Region_ID = Convert.ToInt32(hdRegionID.Value);
        obj_TNA.Center_Code = txtSchoolHead.Text;
        obj_TNA.Center_ID = Convert.ToInt32(txtcenter.Value);
        obj_TNA.Center_Name = txtCampusName.Text;
        obj_TNA.City = txtCity.Text;
        obj_TNA.TotalTeachers = Convert.ToInt32(txtCurrentStaff.Text);
        obj_TNA.KeyStages = hidSelectedKeyStage.Value;
        obj_TNA.KeyStagesName = hidSelectedKeyStageText.Value;
        obj_TNA.KSTotalTeacher = Convert.ToInt32(txtTotalTeachers.Text);
        obj_TNA.TrainingValue = Convert.ToInt32(ddlTrainingRequired.SelectedValue);
        obj_TNA.TrainingType = ddlTrainingRequired.SelectedItem.Text;
        obj_TNA.Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
        obj_TNA.Category_Name = ddlCategory.SelectedItem.Text;
        obj_TNA.SubCategory_ID = Convert.ToInt32(ddlSubCategory.SelectedValue);
        obj_TNA.SubCategory_Name = ddlSubCategory.SelectedItem.Text;
        obj_TNA.Level = txtLevels.Text;
        obj_TNA.PreferredModeOfTraining = ddlPreferredMode.Text;
        obj_TNA.PreferredDateTime = txtPreferredDateTime.Text == "" ? DateTime.Now : Convert.ToDateTime(txtPreferredDateTime.Text);
        obj_TNA.ExpectedTrainees = txtExpectedTrainees.Text == ""? 0 : Convert.ToInt32(txtExpectedTrainees.Text);
        obj_TNA.SIQAReportPath = dbPath;
        obj_TNA.SIQAReportName = fuSIQAReport.FileName;
        obj_TNA.UserID = Convert.ToInt32(Session["ContactID"]);
        obj_TNA.TeacherERPNumber = hidSelectedTeacher.Value;
        obj_TNA.TeacherName = hidSelectedTeacherText.Value;
        //obj_TNA.ConfirmedTraineesCount = Convert.ToInt32(txtConfirmedTrainees.Text);
        obj_TNA.ConfirmedTraineesCount = Convert.ToInt32(hdConfirmedTrainees.Value);
        if (ddlTrainer.SelectedValue != "0")
        {
            obj_TNA.AssignedTrainer = Convert.ToInt32(ddlTrainer.SelectedValue);
            obj_TNA.AssignedTrainerName = ddlTrainer.SelectedItem.Text;
        }
        else
        {
            obj_TNA.AssignedTrainer = 0;
            obj_TNA.AssignedTrainerName = "";
        }
        string message = "";
        // Call the method to save or update trainer profile
        if (btnSave.Text == "Save")
        {
            message = objTNA.SaveTNA(obj_TNA);
            ClearControl();
        }
        else
        {
            obj_TNA.TNA_ID = Convert.ToInt32(hdTNAID.Value);
            message = objTNA.UpdateTNA(obj_TNA);
            LoadTNARecord();
        }
        divMessage.Visible = true;
        spanMessage.InnerText = message;
        //ImpromptuHelper.ShowPrompt(message);

        // Response.Redirect("~/PresentationLayer/TCS/CEPD_TrainerProfile.aspx", false);
    }
    public void ClearControl()
    {
        txtRegion.Text = "";
        hdRegionID.Value = "0";
        txtSchoolHead.Text = "";
        txtcenter.Value = "0";
        txtCampusName.Text = "";
        txtCity.Text = "";
        txtCurrentStaff.Text = "";
        hidSelectedKeyStage.Value = "0";
        hidSelectedKeyStageText.Value = "0";
        txtTotalTeachers.Text = "";
        ddlTrainingRequired.SelectedValue = "";
        ddlTrainingRequired.Text = "";
        ddlCategory.SelectedValue = "0";
        ddlTrainingRequired.Text = "";
        ddlSubCategory.SelectedValue = "0";
        // ddlSubCategory.Text = "";
        txtLevels.Text = "";
        //ddlSubCategory.Text = "";
        txtPreferredDateTime.Text = "";
        txtExpectedTrainees.Text = "";
        txtConfirmedTrainees.Text = "";
        hidSelectedTeacher.Value = "0";
        hidSelectedTeacherText.Value = "0";
    }



    protected void lbtnSiqareport_Click(object sender, EventArgs e)
    {
        WebClient User = new WebClient();
        Byte[] FileBuffer = User.DownloadData(hdSIQFilePath.Value);
        if (FileBuffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", FileBuffer.Length.ToString());
            Response.BinaryWrite(FileBuffer);
        }
    }
}