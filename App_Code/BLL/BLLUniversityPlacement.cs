using System;
using System.Data;


/// <summary>
/// Summary description for BLLSubject
/// </summary>



public class BLLUniversityPlacement
{
    public BLLUniversityPlacement()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALUniversityPlacement objdal = new DALUniversityPlacement();



    #region 'Start Properties Declaration'

    //public int Subject_Id { get; set; }
    //public string Subject_Name { get; set; }
    //public string Subject_Code { get; set; }
    //public string Status_Id_ { get; set; }
    //public string Comments_ { get; set; }
    //public int Main_Organisation_Id { get; set; }
    //public string isKPI { get; set; }
    //public string SortOrder { get; set; }
    //public int Class_ID { get; set; }
    //public int Region_id { get; set; }


    //**************************
    public int U_Id { get; set; }
    public string Uni_Name { get; set; }
    public int Status_Id { get; set; }
    public string Comments { get; set; }
    public bool IsActive { get; set; }
    public string AddTag { get; set; }

    public string University_Ranking { get; set; }
    public string University_Location { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int UniversitytAdd(BLLUniversityPlacement _obj)
        {
        return objdal.UniversitytAdd(_obj);
        }
    //public int SubjectUpdate(BLLUniversityPlacement _obj)
    //    {
    //    return objdal.SubjectUpdate(_obj);
    //    }
    public int UniDelete(BLLUniversityPlacement _obj)
        {
        return objdal.UniDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    //public DataTable SubjectFetch(BLLUniversityPlacement _obj)
    //    {
    //    return objdal.SubjectSelect(_obj);
    //    }

    public DataTable SubjectSelectAllWithSubNameGroup(BLLUniversityPlacement _obj)
    {
        return objdal.SubjectSelectAllWithSubNameGroup(_obj);
    }


    public DataTable SubjectFetchByStatusID(BLLUniversityPlacement _obj)
    {
        return objdal.SubjectSelectByStatusID(_obj);
    }

    //public DataTable SubjectFetchByClassID(BLLUniversityPlacement _obj)
    //{
    //    return objdal.SubjectFetchByClassID(_obj);
    //}
    //public DataTable SubjectFetchByClassIDSeatPlan(BLLUniversityPlacement _obj)
    //{
    //    return objdal.SubjectFetchByClassIDSeatPlan(_obj);
    //}
    

    //public DataTable SubjectFetch(int _id)
    //  {
    //    return objdal.SubjectSelect(_id);
    //  }


    #endregion

    //public DataTable SubjectFetchByClassIDSeatPlan_(BLLUniversityPlacement _obj)
    //{
    //    return objdal.SubjectFetchByClassIDSeatPlan_(_obj);
    //}
    //public int AssignSubject(BLLUniversityPlacement _obj)
    //{
    //    return objdal.AssignSubject(_obj);
    //}
    public DataTable Get_All_Universities()
    {
        return objdal.Get_All_Universities();
    }
    public int UniNameAvailability(BLLUniversityPlacement _obj)
    {
        return objdal.UniNameAvailability(_obj);
    }
    //public int SubjectCodeAvailability(BLLUniversityPlacement _obj)
    //{
    //    return objdal.SubjectCodeAvailability(_obj);
    //}
}
