using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLIssuanceDate
/// </summary>
public class BLLUniCounselorMapping
{
    DALUniCounselorMapping objDll = new DALUniCounselorMapping();
    public int ResultIssueDateId { get; set; }
    public string ResultDesc { get; set; }
    public DateTime ResultDate { get; set; }
    public int Session_Id_ { get; set; }
    public int TermGroup_Id { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public int Createdby { get; set; }
    public DateTime ModifedOn { get; set; }
    public int ModifedBy { get; set; }
    public int Center_Id { get; set; }
    public int deleterR { get; set; }
    public int ClassGroupId { get; set; }
    public string CenterList { get; set; }


    //********************************************
    public int Uc_Id { get; set; }
    public int Uc_Uni_Fk { get; set; }
    public int Uc_Coun_Fk { get; set; }
    public int Session_Id { get; set; }
    public bool IsActive { get; set; }
    public int Status_Id { get; set; }
    public string AddTag { get; set; }
    


    //public DataTable GetListofCampusClass(BLLUniCounselorMapping obj)
    //{
    //    return objDll.GetListofCampusClass(obj);
    //}

    public DataTable GetList(int session_ID)
    {
        return objDll.GetList(session_ID);
    }

    public int AddUniCounMapping(BLLUniCounselorMapping bllIssuanceDate)
    {
        return objDll.AddUniCounMapping(bllIssuanceDate);
    }

    public void InActivatemapping(int deleteR)
    {
        objDll.InActivatemapping(deleteR);
    }

    public int UpdateIssuanceDateMaster(BLLUniCounselorMapping bllIssuanceDate)
    {
        return objDll.UpdateIssuanceDateMaster(bllIssuanceDate);
    }

    public int AddCenterIssuanceDate(BLLUniCounselorMapping bllIssuanceDate)
    {
        return objDll.AddCenterIssuanceDate(bllIssuanceDate);

    }

    //public DataTable getAllDatAppliedCneterClasses(BLLUniCounselorMapping obj)
    //{
    //    return objDll.getAllDatAppliedCneterClasses(obj);
    //}

    public int DeleteAppliedCenter(int deleteR)
    {
         return objDll.DeleteAppliedCenter(deleteR);
    }

    public int checkIdExistinAppliedCenters(BLLUniCounselorMapping obj)
    {
       return objDll.checkIdExistinAppliedCenters(obj);
    }

    public DataTable SelectAllCentersNames()
    {
        return objDll.SelectAllCentersNames();
    }

    public DataTable SelectAllCounselorsNames()
    {
        return objDll.SelectAllCounselorsNames();
    }

    public  int ResultCardIssuanceDateDetailClassCenterInsert(BLLUniCounselorMapping bllIssuanceDate)
    {
        return objDll.ResultCardIssuanceDateDetailClassCenterInsert(bllIssuanceDate);
    }

    public int ResultCardIssuanceDateDetailClassCenterDelete(BLLUniCounselorMapping obj)
    {
        return objDll.ResultCardIssuanceDateDetailClassCenterDelete(obj);
    }
}