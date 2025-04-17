using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmission_Registeration_Alevel
/// </summary>



public class BLLAdmission_Registeration_Alevel
{
    public BLLAdmission_Registeration_Alevel()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmission_Registeration_Alevel objdal = new DALAdmission_Registeration_Alevel();



    #region 'Start Properties Declaration'

    public int ARO { get; set; }
    public int Subject_Id { get; set; }
    public int Registeration_Id { get; set; }
    public string Marks_Obtained { get; set; }
    public bool Lock_Marks { get; set; }
    public bool IsStudy { get; set; }
    public bool IntendtoStudy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Admission_Registeration_AlevelAdd(BLLAdmission_Registeration_Alevel _obj)
    {
        return objdal.Admission_Registeration_AlevelAdd(_obj);
    }
    public int Admission_Registeration_AlevelUpdate(BLLAdmission_Registeration_Alevel _obj)
    {
        return objdal.Admission_Registeration_AlevelUpdate(_obj);
    }
    public int Admission_Registeration_AlevelDelete(BLLAdmission_Registeration_Alevel _obj)
    {
        return objdal.Admission_Registeration_AlevelDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Admission_Registeration_AlevelFetch(BLLAdmission_Registeration_Alevel _obj)
    {
        return objdal.Admission_Registeration_AlevelSelect(_obj);
    }

    public DataTable Admission_Registeration_AlevelFetchByStatusID(BLLAdmission_Registeration_Alevel _obj)
    {
        return objdal.Admission_Registeration_AlevelSelectByStatusID(_obj);
    }



    public DataTable Admission_Registeration_AlevelFetch(int _id)
    {
        return objdal.Admission_Registeration_AlevelSelect(_id);
    }


    #endregion

}
