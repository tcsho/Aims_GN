using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BLLStudentVerificationFocalPerson
/// </summary>
public class BLLStudentVerificationFocalPerson
{
	public BLLStudentVerificationFocalPerson()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    _DALStudentVerificationFocalPerson objdal = new _DALStudentVerificationFocalPerson();



    #region 'Start Properties Declaration'

    
        public int Focal_Person_Id { get; set; }
        public int Center_Id { get; set; }
        public int Region_Id { get; set; }
        public string Employee_Code { get; set; } 
        public string User_Name { get; set; }
        public string DesigName { get; set; } 
        public string Email { get; set; } 
        public DateTime Modify_On { get; set; } 
        public string Modify_By { get; set; } 
        public int Status_Id { get; set; } 
        public string Month_Name { get; set; } 
        
    



    public DataTable StudentVerificationFocalPerson_List(int center, string month_name)
    {
        return objdal.StudentVerificationFocalPerson_List(center, month_name);
    }
    public DataTable StudentVerificationFocalPerson_EmployeeDetails(BLLStudentVerificationFocalPerson objbll)
    {
        return objdal.StudentVerificationFocalPerson_EmployeeDetails(objbll);
    }
    public int Student_Verification_FocalPerson_Update(BLLStudentVerificationFocalPerson objbll)
    {
        return objdal.Student_Verification_FocalPerson_Update(objbll);
    }


  

    #endregion

}