using System;
using System.Data;


/// <summary>
/// Summary description for BLLClass
/// </summary>



public class BLLClass
{
    public BLLClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALClass objdal = new DALClass();



    #region 'Start Properties Declaration'
    public int Class_Id { get; set; }
    public string Class_Name { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Status_Id { get; set; }
    public int Subject_Id { get; set; } //using for class subject assignment
    public int Grade_Id { get; set; }
    public string Comments { get; set; }
    public int OrderOfClass { get; set; }
    public bool isKPI { get; set; }
    public int Center_Id { get; set; }
    public string Grade_IdS { get; set; }
    public string Main_Organisation_IdS { get; set; }
    public int Teacher_Id { get; set; }
    public int Region_id { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int ClassAdd(BLLClass _obj)
    {
        return objdal.ClassAdd(_obj);
    }
    public int ClassUpdate(BLLClass _obj)
    {
        return objdal.ClassUpdate(_obj);
    }
    public int ClassDelete(BLLClass _obj)
    {
        return objdal.ClassDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable ClassSelectForAlumni(BLLClass _obj)
    {
        return objdal.ClassSelectForAlumni(_obj);
    }
    public DataTable ClassFetch(BLLClass _obj)
    {
        return objdal.ClassSelect(_obj);
    }

    public DataTable ClassFetchByStatusID(BLLClass _obj)
    {
        return objdal.ClassSelectByStatusID(_obj);
    }
    public DataTable ClassFetchByCenterID(BLLClass _obj)
    {
        return objdal.ClassSelectByCenterID(_obj);
    }

    public DataTable ClassSelectByCenterIDSeatPlan(BLLClass _obj)
    {
        return objdal.ClassSelectByCenterIDSeatPlan(_obj);
    }


    public DataTable ClassSelectByCenterTeacherID(BLLClass _obj)
    {
        return objdal.ClassSelectByCenterTeacherID(_obj);
    }


    public DataTable ClassFetchSearch(BLLClass _obj)
    {
        return objdal.ClassSelectSearch(_obj);
    }



    public DataTable ClassFetch(int _id)
    {
        return objdal.ClassSelect(_id);
    }

    public DataTable GetClassesByMOId(int _id)
    {
        return objdal.GetClassesByMOId(_id);
    }
    public int ClassNameAvailability(BLLClass _obj)
    {
        return objdal.ClassNameAvailability(_obj);
    }
    public DataTable Class_SubjectSelectByClassID(BLLClass obj)
    {
        return objdal.Class_SubjectSelectByClassID(obj);
    }
    public int Class_SubjectAssign(BLLClass _obj)
    {
        return objdal.Class_SubjectAssign(_obj);
    }
    public void Class_SubjectUnAssign(BLLClass _obj)
    {
        objdal.Class_SubjectUnAssign(_obj);
    }

    public DataTable Fetch_ClassesBasedonCenter_Dashboard(BLLClass obj)
    {
        return objdal.Fetch_ClassesBasedonCenter_Dashboard(obj);
    }
    #endregion

}
