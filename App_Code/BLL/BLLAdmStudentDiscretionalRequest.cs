using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmStudentDiscretionalRequest
/// </summary>



public class BLLAdmStudentDiscretionalRequest
    {
    public BLLAdmStudentDiscretionalRequest()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALAdmStudentDiscretionalRequest objdal = new DALAdmStudentDiscretionalRequest();



    #region 'Start Properties Declaration'

    public int SDAReq_Id { get; set; }
    public int Regisration_Id { get; set; }
    public int Session_Id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int Class_Id { get; set; }
    public string Heads_Remarks { get; set; }
    public int Submited_By { get; set; }
    public DateTime  Submited_On { get; set; }
    public bool   NH_Approval { get; set; }
    public int  NH_Approval_By { get; set; }
    public DateTime  NH_Approval_On { get; set; }
    public string  NH_Remarks { get; set; }
    public bool isEmail { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmStudentDiscretionalRequestAdd(BLLAdmStudentDiscretionalRequest _obj, string mode)
        {
        return objdal.AdmStudentDiscretionalRequestAdd(_obj,mode);
        }
    public int AdmStudentDiscretionalRequestUpdate(BLLAdmStudentDiscretionalRequest _obj)
        {
        return objdal.AdmStudentDiscretionalRequestUpdate(_obj);
        }
    public int AdmStudentDiscretionalRequestDelete(BLLAdmStudentDiscretionalRequest _obj)
        {
        return objdal.AdmStudentDiscretionalRequestDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmStudentDiscretionalRequestFetch(BLLAdmStudentDiscretionalRequest _obj)
        {
        return objdal.AdmStudentDiscretionalRequestSelect(_obj);
        }

    public DataTable AdmStudentDiscretionalRequestFetchByStatusID(BLLAdmStudentDiscretionalRequest _obj)
    {
        return objdal.AdmStudentDiscretionalRequestSelectByStatusID(_obj);
    }



    public DataTable AdmStudentDiscretionalRequestFetch(int _id)
      {
        return objdal.AdmStudentDiscretionalRequestSelect(_id);
      }


    #endregion

    }
