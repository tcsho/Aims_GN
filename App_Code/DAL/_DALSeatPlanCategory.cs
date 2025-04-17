using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALSeatPlanCategory
/// </summary>
public class _DALSeatPlanCategory
{
    DALBase dalobj = new DALBase();


    public _DALSeatPlanCategory()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SeatPlanCategoryAdd(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int); param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); param[1].Value = objbll.TermGroup_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int); param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int); param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Block_Id", SqlDbType.Int); param[4].Value = objbll.Block_Id;
        param[5] = new SqlParameter("@Gender_Id", SqlDbType.Int); param[5].Value = objbll.Gender_Id;
        param[6] = new SqlParameter("@CategoryName", SqlDbType.NVarChar); param[6].Value = objbll.CategoryName;

        param[7] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[7].Value = objbll.Subject_Id;


        param[8] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[8].Value = objbll.CreatedOn;
        param[9] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[9].Value = objbll.CreatedBy;
        param[10] = new SqlParameter("@InsertOrUpdate", SqlDbType.Int); param[10].Value = objbll.InsertOrUpdate;
        param[11] = new SqlParameter("@Categ_Id", SqlDbType.Int); param[11].Value = objbll.Categ_Id;
        param[12] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[12].Value = objbll.ModifiedOn;
        param[13] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[13].Value = objbll.ModifiedBy;


        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanCategoryInsert", param);
        int k = (int)param[14].Value;   
        return k;

    }
    public int SeatPlanCategoryUpdate(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Categ_Id", SqlDbType.Int); param[0].Value = objbll.Categ_Id;

        param[1] = new SqlParameter("@Block_Id", SqlDbType.Int); param[1].Value = objbll.Block_Id;
        param[2] = new SqlParameter("@Gender_Id", SqlDbType.Int); param[2].Value = objbll.Gender_Id;
        param[3] = new SqlParameter("@CategoryName", SqlDbType.NVarChar); param[3].Value = objbll.CategoryName;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[5].Value = objbll.ModifiedBy;



        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanCategoryUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }
    public int SeatPlanCategoryDelete(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Categ_Id", SqlDbType.Int);
        param[0].Value = objbll.Categ_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanCategoryDelete", param);
        int k = (int)param[1].Value;
        return k;

    }

    public int DeleteBlockConfiguration(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        param[3] = new SqlParameter("@Result", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("DeleteBlockConfiguration", param);
        int k = (int)param[3].Value;
        return k;

    }


    public int SeatPlanCategoryLock(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@LockDate", SqlDbType.DateTime);
        param[2].Value = objbll.LockDate;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanCategoryLock", param);
        int k = (int)param[3].Value;
        return k;


    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SeatPlanCategorySelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelect", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }


    public DataTable SeatPlanCategorySelectBySessionTermCenter(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectBySessionTermCenter", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SeatPlanCategorySelectBySessionTermCenterStudent(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectBySessionTermCenterStudent", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable UnAssignedStudentList(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("UnAssignedStudentList", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable ShowUnlockedClasses(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ShowUnlockedClasses", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SeatPlanAllocatedStudentsRoomsShow(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanAllocatedStudentsRoomsShowNew", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable SeatPlanCategorySelectBlockBySchool(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectBlockBySchool", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable CheckRollNumberGeneratedOrNot(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CheckRollNumberGeneratedOrNot", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable CheckBlockDistribution(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CheckBlockDistribution", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable CheckTeacherAlocationAlredyProcessOrNot(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CheckTeacherAlocationAlredyProcessOrNot", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }
        return _dt;
    }

    public DataTable AssignRoomToTeacherCheckRoomsStatus(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AssignRoomToTeacherCheckRoomsStatus", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }
        return _dt;
    }


    public DataTable CheckBlocAllocateRoomsToStudent(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CheckBlocAllocateRoomsToStudent", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SeatPlanCategorySelectAssignRooms(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectAssignRooms", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable SeatPlanCategorySelectStudents(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;

        param[4] = new SqlParameter("@Gender_Id", SqlDbType.Int);
        param[4].Value = objbll.Gender_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectStudents", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SeatPlanCategorySelectBySessionTerm(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        param[3] = new SqlParameter("@RegionID", SqlDbType.Int);
        param[3].Value = objbll.RegionID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectBySessionTerm", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }



    public DataTable SeatPlanCategorySelectLock(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelectLock", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SeatPlanCategorySelect(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanCategorySelect", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public int SeatPlanCategorySelectField(int _Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[1].Value;
        return k;

    }

    public DataTable ExamUnAssignedRoomCentersList(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;
        
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ExamUnAssignedRoomCentersList", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public int LockRoomAllocation(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Result", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LockRoomAllocation", param);
        int k = (int)param[2].Value;
        return k;
    }


    public DataTable ShowRoomsAllocationBYCenter(BLLSeatPlanCategory objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroup_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ShowRoomsAllocationBYCenter", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    #endregion


}
