using System;
using System.Data;

public class BLLCEPD_Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Qualification { get; set; }
    public int Qualif_id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
    public string action { get; set; }
    public int SubcategoryId { get; set; }
    public string SubcategoryName { get; set; }
    public int SubcategoryCategoryId { get; set; }
    public DateTime SubcategoryCreatedOn { get; set; }
    public string SubcategoryCreatedBy { get; set; }
    public DateTime SubcategoryModifiedOn { get; set; }
    public string SubcategoryModifiedBy { get; set; }
    public int TrainingID { get; set; }
    public string TrainingName { get; set; }
    public string Description { get; set; }
     public string path { get; set; }
    public string Link { get; set; }
    public string StopTime { get; set; }
    
     public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string Category { get; set; }



    public BLLCEPD_Category()
    {
        // Initialization or default values can be added here if needed
    }

    _DALCEPD_Category objdal = new _DALCEPD_Category();

    public string PerformCEPD_CategorySave(BLLCEPD_Category _obj)
    {
     
        return objdal.SaveOrUpdateCategory(_obj);
    }
    public string PerformCEPD_SubCategorySave(BLLCEPD_Category _obj)
    {

        return objdal.SaveOrUpdateSubcategory(_obj);
    }
    public string CEPD_CategoryDelete(string _obj)
    {

        return objdal.DeleteCategory(_obj);
    }
   
    public DataTable GetCategory(BLLCEPD_Category _obj)
    {

        return objdal.GetCategory(_obj);
    }
    public DataTable GetSubCategory_Get()
    {
        return objdal.GetSubCategory_Get();
    }
    public DataTable GetSubCategory_ByCategoryID(BLLCEPD_Category objbll)
    {
        return objdal.GetSubCategory_GetByCategoryID(objbll);
    }
    public string CEPD_SUBCategoryDelete(string _obj)
    {

        return objdal.DeleteSubCategory(_obj);
    }
    public string SaveUpdateQualification(BLLCEPD_Category _obj)
    {

        return objdal.SaveUpdateQualification(_obj);
    }
    public DataTable GetQualification(BLLCEPD_Category _obj)
    {

        return objdal.GetQualification(_obj);
    }
    public string DeleteQualification(string _obj)
    {

        return objdal.DeleteQualification(_obj);
    }


    // For CEPD_TrainingVideoUploader.aspx
    public string TrainingVideoUploade_Save(BLLCEPD_Category _obj)
    {

        return objdal.TrainingVideoUploade_Save(_obj);
    } 
    public DataTable TrainingVideoUploade_Get()
    {

        return objdal.TrainingVideoUploade_Get();
    }
    public DataTable TrainingQuestions_Get()
    {

        return objdal.TrainingQuestions_Get();
    }
    public string TrainingVideoQuestions_Save(BLLCEPD_Category _obj)
    {


        return objdal.TrainingVideoQuestions_Save(_obj);
        {

        }
    }
    public DataTable TrainingQuestions_GetBYid(int id)
    {

        return objdal.TrainingQuestions_GetByID(id);
    }
}


