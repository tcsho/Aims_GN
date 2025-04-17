using System;
using System.Data;

public class BLLCEPD_TrainerProfile
{
    public int Id { get; set; }
    public string ERPNumber { get; set; }
    public string TrainerName { get; set; }
    public string Designation { get; set; }
    public string Branch { get; set; }
    public string Expertise { get; set; }
    public string ExperienceTCS { get; set; }
    public string ExperienceOutsideTCS { get; set; }
    public string AcademicQualification { get; set; }
    public string ProfessionalQualificationTCS { get; set; }
    public string Trainings { get; set; }
    public string Training_Name { get; set; }
    public string ProfessionalQualificationOutsideTCS { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }

    public string action { get; set; }

    // Constructor
    public BLLCEPD_TrainerProfile()
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
