using System;
using System.Data;

public class BLLCEPD_TNA
{
   
    public int TNA_ID { get; set; }
    public string Center_Code { get; set; }
    public string Center_Name { get; set; }
    public string City { get; set; }
    public string Region_Name { get; set; }
    public int Region_ID { get; set; }
    public int Center_ID { get; set; }
    public int TotalTeachers { get; set; }
    public string KeyStages { get; set; } 
    public string KeyStagesName { get; set; }
    public int KSTotalTeacher { get; set; }
    public string TrainingType { get; set; }
    public int TrainingValue { get; set; }
    public int Category_ID { get; set; }
    public string Category_Name { get; set; } 
    public int SubCategory_ID { get; set; }
    public string SubCategory_Name { get; set; }
    
    public string Level { get; set; } 
    public string PreferredModeOfTraining { get; set; }
    public string SIQAReportName { get; set; }
    public string SIQAReportPath { get; set; } 
    public int ExpectedTrainees { get; set; } 
    public int AssignedTrainer { get; set; }
    public string AssignedTrainerName { get; set; }
    public int ConfirmedTraineesCount { get; set; }
    public DateTime PreferredDateTime { get; set; }
    public int UserID { get; set; }   
    public string TeacherERPNumber { get; set; }
    public string TeacherName{ get; set; }
    public string Status { get; set; }
    public string Reason { get; set; }

    // Constructor
    public BLLCEPD_TNA()
    {
        // Initialization or default values can be added here if needed
    }

    _DALCEPD_TrainerProfile objdal = new _DALCEPD_TrainerProfile();

    // Method to save or update TrainerProfile
    public string SaveOrUpdateTrainerProfile(BLLCEPD_TrainerProfile _obj)
    {
        return objdal.SaveOrUpdateTrainerProfile(_obj);
    }

    // Method to delete TrainerProfile
    public string DeleteTrainerProfile(int id)
    {
        return objdal.DeleteTrainerProfile(id);
    }

    // Method to get TrainerProfile
    public DataTable GetTrainerProfile()
    {
        return objdal.GetTrainerProfile();
    }
    public DataTable GetTrainerProfile_BYID(string id)
    {
        return objdal.GetTrainerProfile_ByID(id);
    }
    public DataTable GetERPProfile(int id)
    {
        return objdal.GetERPProfile(id);
    }
    public DataTable SelectTrainings()
    {
        return objdal.SelectTrainings();
    }

    public DataTable GetTNA_Detils(string code)
    {
        return objdal.GetTNA_Detils(code);
    } 
    public DataTable GetTNA_KeyStages()
    {
        return objdal.GetTNA_KeyStages();
    }
    public DataTable GetTNA_KeyStages_emplyoeecount(string centerid, string groupid)
    {
        return objdal.GetTNA_KeyStages_emplyoeecount(centerid, groupid);
    }
}
