using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_AdmRegistration
/// </summary>



public class BLLStudent_AdmRegistration
    {
    public BLLStudent_AdmRegistration()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_AdmRegistration objdal = new DALStudent_AdmRegistration();



    #region 'Start Properties Declaration'
    public int Regisration_Id { get; set; }
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public int? Region_Id { get; set; }
    public int? Center_Id { get; set; }
    public int? Grade_Id { get; set; }
    public DateTime? Admission_Date { get; set; }
    public int? User_Id { get; set; }
    public string Gender_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_AdmRegistrationAdd(BLLStudent_AdmRegistration _obj)
        {
        return objdal.Student_AdmRegistrationAdd(_obj);
        }
    public int Student_AdmRegistrationUpdate(BLLStudent_AdmRegistration _obj)
        {
        return objdal.Student_AdmRegistrationUpdate(_obj);
        }
    public int Student_AdmRegistrationDelete(BLLStudent_AdmRegistration _obj)
        {
        return objdal.Student_AdmRegistrationDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_AdmRegistrationFetch(BLLStudent_AdmRegistration _obj)
        {
        return objdal.Student_AdmRegistrationSelect(_obj);
        }

    public DataTable Student_AdmRegistrationFetchByStatusID(BLLStudent_AdmRegistration _obj)
    {
        return objdal.Student_AdmRegistrationSelectByStatusID(_obj);
    }



    public DataTable Student_AdmRegistrationFetch(int _id)
      {
        return objdal.Student_AdmRegistrationSelect(_id);
      }


    #endregion

    }
