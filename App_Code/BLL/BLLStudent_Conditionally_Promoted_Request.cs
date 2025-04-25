using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLStudent_Conditionally_Promoted_Request
/// </summary>



public class BLLStudent_Conditionally_Promoted_Request
{
    public BLLStudent_Conditionally_Promoted_Request()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Conditionally_Promoted_Request objdal = new DALStudent_Conditionally_Promoted_Request();



    #region 'Start Properties Declaration'

    public int SCPReq_Id { get; set; }
    public int Student_Id { get; set; }
    public int Student_No { get; set; }
    public string studentist { get; set; }
    public string StudentName { get; set; }
    public int Session_Id { get; set; }
    public string Description { get; set; }
    public int Region_Id { get; set; }
    public string Region_Name { get; set; }
    public int Center_Id { get; set; }
    public string Grade_Id { get; set; }
    public string Center_Name { get; set; }
    public int ? Class_Id { get; set; }
    public string Class_Name { get; set; }
    public string Section_Name { get; set; }
    public string Remarks { get; set; }
    public int ClassRequest { get; set; }
    public int TermGroupID { get; set; }
    public bool ? Submit_RD { get; set; }
    public int Submit_RD_By { get; set; }
    public DateTime Submit_RD_On { get; set; }
    public bool ? RD_Approval { get; set; }
    public int RD_Approval_By { get; set; }
    public DateTime RD_Approval_On { get; set; }
    public string RD_Remarks { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime  CreatedOn{ get; set; }
    public string PromotionStatus { get; set; }
    public int Section_Id { get; set; }


    //2024-Apr-10
    public DateTime BifurcationProcessDate { get; set; }
    public bool isActive { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int Student_Conditionally_Promoted_RequestAdd(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestAdd(_obj);
    }
    public int Student_Conditionally_Promoted_RequestUpdate(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestUpdate(_obj);
    }

    public int Student_Conditionally_Promoted_RequestUpdateEmailSent(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestUpdateEmailSent(_obj);
    }

    public int Student_Conditionally_Promoted_RequestDelete(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestDelete(_obj);

    }
    public int Student_Conditionally_Promoted_RequestRevert(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestRevert(_obj);

    }
    public int Student_BifurcationMatricStream(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_BifurcationMatricStream(_obj);

    }
    public int Student_PrivatiseCenterWise(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_PrivatiseCenterWise(_obj);

    }


	public DataTable Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request _obj)
   	 {
   	     return objdal.Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId(_obj);
   	 }


    public DataTable New_Student_Bifurcation_RequestSelectAllByOrgRegionCenterId_SyncERP(BLLStudent_Conditionally_Promoted_Request _obj)
    {
   		 return objdal.Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId_SyncERP(_obj);
	}
#endregion
#region 'Start Fetch Methods'


public DataTable Student_Conditionally_Promoted_RequestCheckStatus(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestCheckStatus(_obj);
    }
    public DataTable Student_Conditionally_Promoted_RequestEmailSummary(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestEmailSummary(_obj);
    }
    public DataTable Student_Conditionally_Promoted_RequestFetch(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestSelect(_obj);
    }

    public DataTable Student_Conditionally_Promoted_RequestFetchByStatusID(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestSelectByStatusID(_obj);
    }


    public DataTable Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(_obj);
    }
    public DataTable Student_Report_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(_obj);
    }
    public DataTable Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(_obj);
    } 
    public DataTable Student_Bifurcation_UndertakingNotRecieve(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        
        return objdal.Student_Bifurcation_UndertakingNotRecieve(_obj);
    }

    public string Student_Bifurcation_RequestSynWithErp(BLLStudent_Conditionally_Promoted_Request _obj)
    {

        return objdal.Student_Bifurcation_RequestSynWithErp(_obj);
    }
    public string Student_Bifurcation_BIFURCATION_CLASS_CHANGE(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        //APPS.BIFURCATION_CLASS_CHANGE
        return objdal.Student_Bifurcation_BIFURCATION_CLASS_CHANGE(_obj);
    }
    public DataTable Student_Conditionally_Promoted_RequestForApproval(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Student_Conditionally_Promoted_RequestForApproval(_obj);
    }


    public DataTable Student_Conditionally_Promoted_RequestFetch(int _id)
    {
        return objdal.Student_Conditionally_Promoted_RequestSelect(_id);
    }

//Add this method in BLLStudent_Conditionally_Promoted_Request.cs Class    
//==========================================================================
public DataTable New_Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.New_Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(_obj);
    }
    public DataTable Student_Expelled(BLLStudent_Conditionally_Promoted_Request obj)
    {
        return objdal.Student_Expelled(obj);
    }
    public DataTable Student_Privatisation(BLLStudent_Conditionally_Promoted_Request obj)
    {
        return objdal.Student_Privatisation(obj);
    }
    public DataTable Student_Bifurcation(BLLStudent_Conditionally_Promoted_Request obj)
    {
        return objdal.Student_Bifurcation(obj);
    }


    public DataTable Bifuration_Process_Setup_Add(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.Bifuration_Process_Setup_Add(_obj);
    }

    public DataTable GetCenterFromRegionBifurcationProces(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.GetCenterFromRegionBifurcationProces(_obj);
    }
    public DataTable GetCenterFromRegionBifurcationProces_NotFound(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.GetCenterFromRegionBifurcationProces_NotFound(_obj);
    }

    public DataTable GetBifurcationProcesReport(BLLStudent_Conditionally_Promoted_Request _obj)
    {
        return objdal.GetBifurcationProcesReport(_obj);
    }
    #endregion

}
