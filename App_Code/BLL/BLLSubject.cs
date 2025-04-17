using System;
using System.Data;


/// <summary>
/// Summary description for BLLSubject
/// </summary>



public class BLLSubject
    {
    public BLLSubject()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSubject objdal = new DALSubject();



    #region 'Start Properties Declaration'

    public int Subject_Id { get; set; }
    public string Subject_Name { get; set; }
    public string Subject_Code { get; set; }
    public string Status_Id { get; set; }
    public string Comments { get; set; }
    public int Main_Organisation_Id { get; set; }
    public string isKPI { get; set; }
    public string SortOrder { get; set; }
    public int Class_ID { get; set; }
    public int Region_id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int SubjectAdd(BLLSubject _obj)
        {
        return objdal.SubjectAdd(_obj);
        }
    public int SubjectUpdate(BLLSubject _obj)
        {
        return objdal.SubjectUpdate(_obj);
        }
    public int SubjectDelete(BLLSubject _obj)
        {
        return objdal.SubjectDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SubjectFetch(BLLSubject _obj)
        {
        return objdal.SubjectSelect(_obj);
        }

    public DataTable SubjectSelectAllWithSubNameGroup(BLLSubject _obj)
    {
        return objdal.SubjectSelectAllWithSubNameGroup(_obj);
    }


    public DataTable SubjectFetchByStatusID(BLLSubject _obj)
    {
        return objdal.SubjectSelectByStatusID(_obj);
    }

    public DataTable SubjectFetchByClassID(BLLSubject _obj)
    {
        return objdal.SubjectFetchByClassID(_obj);
    }
    public DataTable SubjectFetchByClassIDSeatPlan(BLLSubject _obj)
    {
        return objdal.SubjectFetchByClassIDSeatPlan(_obj);
    }
    

    public DataTable SubjectFetch(int _id)
      {
        return objdal.SubjectSelect(_id);
      }


    #endregion

    public DataTable SubjectFetchByClassIDSeatPlan_(BLLSubject _obj)
    {
        return objdal.SubjectFetchByClassIDSeatPlan_(_obj);
    }
    public int AssignSubject(BLLSubject _obj)
    {
        return objdal.AssignSubject(_obj);
    }
    public DataTable SubjectFetchByMoId(int _id)
    {
        return objdal.SubjectFetchByMoId(_id);
    }
    public int SubjectNameAvailability(BLLSubject _obj)
    {
        return objdal.SubjectNameAvailability(_obj);
    }
    public int SubjectCodeAvailability(BLLSubject _obj)
    {
        return objdal.SubjectCodeAvailability(_obj);
    }
}
