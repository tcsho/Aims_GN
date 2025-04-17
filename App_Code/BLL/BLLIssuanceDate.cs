using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLIssuanceDate
/// </summary>
public class BLLIssuanceDate
{
    DALIssuanceDate objDll = new DALIssuanceDate();
    public int ResultIssueDateId { get; set; }
    public string ResultDesc { get; set; }
    public DateTime ResultDate { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int Createdby { get; set; }
    public DateTime ModifedOn { get; set; }
    public int ModifedBy { get; set; }
    public int Center_Id { get; set; }
    public int deleterR { get; set; }
    public int ClassGroupId { get; set; }
    public string CenterList { get; set; }
	public DateTime DateFrom { get; set; }
    
	public DateTime DateTo { get; set; }
    
	public int SCPR_ID { get; set; }

    public DataTable GetListofCampusClass(BLLIssuanceDate obj)
    {
        return objDll.GetListofCampusClass(obj);
    }

    public DataTable GetListofIssuanceDates(int termId, int session_ID)
    {
        return objDll.GetListofIssuanceDates(termId, session_ID);
    }

    public int AddIssuanceDate(BLLIssuanceDate bllIssuanceDate)
    {
        return objDll.AddIssuanceDate(bllIssuanceDate);
    }

    public void DeleteIssuanceDate(int deleteR)
    {
        objDll.DeleteIssuanceDate(deleteR);
    }

    public int UpdateIssuanceDateMaster(BLLIssuanceDate bllIssuanceDate)
    {
        return objDll.UpdateIssuanceDateMaster(bllIssuanceDate);
    }

    public int AddCenterIssuanceDate(BLLIssuanceDate bllIssuanceDate)
    {
        return objDll.AddCenterIssuanceDate(bllIssuanceDate);

    }

    public DataTable getAllDatAppliedCneterClasses(BLLIssuanceDate obj)
    {
        return objDll.getAllDatAppliedCneterClasses(obj);
    }

    public int DeleteAppliedCenter(int deleteR)
    {
         return objDll.DeleteAppliedCenter(deleteR);
    }

    public int checkIdExistinAppliedCenters(BLLIssuanceDate obj)
    {
       return objDll.checkIdExistinAppliedCenters(obj);
    }

    public DataTable SelectAllClassGroups()
    {
        return objDll.SelectAllClassGroups();
    }

    public  int ResultCardIssuanceDateDetailClassCenterInsert(BLLIssuanceDate bllIssuanceDate)
    {
        return objDll.ResultCardIssuanceDateDetailClassCenterInsert(bllIssuanceDate);
    }
 public DataTable GetListofPromotedRequestDate(int session_ID)

    {

        return objDll.StudentConditionallypromotedRequestDate_All(session_ID);

    }

 

    public int AddPromotionalReqDate(BLLIssuanceDate bllIssuanceDate)

    {

        return objDll.AddPromotionReqDate(bllIssuanceDate);

    }

    public int UpdatePromotionalReqDate(BLLIssuanceDate bllIssuanceDate)

    {

        return objDll.UpdatePromotionReqDate(bllIssuanceDate);

    }
    public int ResultCardIssuanceDateDetailClassCenterDelete(BLLIssuanceDate obj)
    {
        return objDll.ResultCardIssuanceDateDetailClassCenterDelete(obj);
    }
}