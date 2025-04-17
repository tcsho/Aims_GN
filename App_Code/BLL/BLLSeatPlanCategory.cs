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
/// Summary description for BLLSeatPlanCategory
/// </summary>



public class BLLSeatPlanCategory
{
    public BLLSeatPlanCategory()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALSeatPlanCategory objdal = new _DALSeatPlanCategory();



    #region 'Start Properties Declaration'

    public int Categ_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Center_Id { get; set; }
    public int Class_Id { get; set; }
    public int Block_Id { get; set; }
    public int Gender_Id { get; set; }
    public string CategoryName { get; set; }
    public int Status_Id { get; set; }
    public string RegionID { get; set; }
    public int InsertOrUpdate { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }

    public DateTime LockDate { get; set; }

    public int Subject_Id { get; set; }
    public int isLock { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int SeatPlanCategoryAdd(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategoryAdd(_obj);
    }
    public int SeatPlanCategoryUpdate(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategoryUpdate(_obj);
    }
    public int SeatPlanCategoryDelete(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategoryDelete(_obj);
    }

    public int DeleteBlockConfiguration(BLLSeatPlanCategory _obj)
    {
        return objdal.DeleteBlockConfiguration(_obj);
    }

    public int SeatPlanCategoryLock(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategoryLock(_obj);

    }



    #endregion
    #region 'Start Fetch Methods'


    public DataTable SeatPlanCategoryFetch(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelect(_obj);
    }


    public DataTable SeatPlanCategoryFetchSessionTerm(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectBySessionTerm(_obj);
    }
    public DataTable SeatPlanCategorySelectLock(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectLock(_obj);
    }

    public DataTable SeatPlanCategorySelectBySessionTermCenter(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectBySessionTermCenter(_obj);
    }

    public DataTable ShowRoomsAllocationBYCenter(BLLSeatPlanCategory _obj)
    {
        return objdal.ShowRoomsAllocationBYCenter(_obj);
    }

    public DataTable SeatPlanCategorySelectBySessionTermCenterStudent(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectBySessionTermCenterStudent(_obj);
    }

    public DataTable UnAssignedStudentList(BLLSeatPlanCategory _obj)
    {
        return objdal.UnAssignedStudentList(_obj);
    }

    public DataTable ShowUnlockedClasses(BLLSeatPlanCategory _obj)
    {
        return objdal.ShowUnlockedClasses(_obj);
    }   

    public DataTable SeatPlanAllocatedStudentsRoomsShow(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanAllocatedStudentsRoomsShow(_obj);
    }

    public DataTable SeatPlanCategorySelectBlockBySchool(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectBlockBySchool(_obj);
    }

    public DataTable CheckRollNumberGeneratedOrNot(BLLSeatPlanCategory _obj)
    {
        return objdal.CheckRollNumberGeneratedOrNot(_obj);
    }

    public DataTable CheckBlockDistribution(BLLSeatPlanCategory _obj)
    {
        return objdal.CheckBlockDistribution(_obj);
    }

    public DataTable AssignRoomToTeacherCheckRoomsStatus(BLLSeatPlanCategory _obj)
    {
        return objdal.AssignRoomToTeacherCheckRoomsStatus(_obj);
    }

    public DataTable CheckTeacherAlocationAlredyProcessOrNot(BLLSeatPlanCategory _obj)
    {
        return objdal.CheckTeacherAlocationAlredyProcessOrNot(_obj);
    }

    public DataTable CheckBlocAllocateRoomsToStudent(BLLSeatPlanCategory _obj)
    {
        return objdal.CheckBlocAllocateRoomsToStudent(_obj);
    }

    public DataTable SeatPlanCategorySelectAssignRooms(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectAssignRooms(_obj);
    }

    public DataTable SeatPlanCategorySelectStudents(BLLSeatPlanCategory _obj)
    {
        return objdal.SeatPlanCategorySelectStudents(_obj);
    }


    public DataTable SeatPlanCategoryFetch(int _id)
    {
        return objdal.SeatPlanCategorySelect(_id);
    }
    public int SeatPlanCategoryFetchField(int _Id)
    {
        return objdal.SeatPlanCategorySelectField(_Id);
    }

    public DataTable ExamUnAssignedRoomCentersList(BLLSeatPlanCategory _obj)
    {
        return objdal.ExamUnAssignedRoomCentersList(_obj);
    }

    public int LockRoomAllocation(BLLSeatPlanCategory _obj)
    {
        return objdal.LockRoomAllocation(_obj);
    }



    #endregion

}
