using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALIssuanceDate
/// </summary>
public class DALIssuanceDate
{
    private readonly DALBase dalobj = new DALBase();
    public DataTable GetListofCampusClass(BLLIssuanceDate obj)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@TermGroupId", SqlDbType.Int) { Value = obj.TermGroup_Id };
        param[1] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = obj.Session_Id };
        param[2] = new SqlParameter("@ResultCardIssuanceId", SqlDbType.Int) { Value = obj.ResultIssueDateId };

        var dt = dalobj.sqlcmdFetch("GetAllCampusesTermWise", param);
        return dt;
    }

    public int AddIssuanceDate(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@ResultDesc", SqlDbType.NVarChar) { Value = bllIssuanceDate.ResultDesc };
        param[1] = new SqlParameter("@ResultDate", SqlDbType.DateTime) { Value = bllIssuanceDate.ResultDate };
        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int) { Value = bllIssuanceDate.Session_Id };
        param[3] = new SqlParameter("@TermGroup_Id", SqlDbType.Int) { Value = bllIssuanceDate.TermGroup_Id };

        param[4] = new SqlParameter("@ClassGroupId", SqlDbType.Int) { Value = bllIssuanceDate.ClassGroupId };


        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int) { Value = bllIssuanceDate.Status_Id };
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime) { Value = bllIssuanceDate.CreatedOn };
        param[7] = new SqlParameter("@Createdby", SqlDbType.Int) { Value = bllIssuanceDate.Createdby };
        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };

        dalobj.sqlcmdExecute("ResultCardIssuanceDateInsert", param);
        int k = (int)param[8].Value;
        return k;
    }

    internal int DeleteAppliedCenter(int deleteR)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@RIDDetId", SqlDbType.Int) { Value = deleteR };
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailDelete", param);
        int k = (int)param[1].Value;
        return k;
    }
      public DataTable StudentConditionallypromotedRequestDate_All(int SessionID)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @"
                 Select *From Student_Conditionally_promoted_RequestDate
               WHERE    Session_Id =" + SessionID
            };

 

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
        return table;
    }
    
public int AddPromotionReqDate(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int) { Value = bllIssuanceDate.Session_Id };
        param[1] = new SqlParameter("@DateFrom", SqlDbType.DateTime) { Value = bllIssuanceDate.DateFrom };
        param[2] = new SqlParameter("@DateTo", SqlDbType.DateTime) { Value = bllIssuanceDate.DateTo };
        //param[3] = new SqlParameter("@SCPR_ID", SqlDbType.Int) { Direction = bllIssuanceDate.SCPR_ID };
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("StudentConditionallypromotedRequestDate_Insert", param);
        int k = (int)param[3].Value;
        return k;
    }    

public int UpdatePromotionReqDate(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@SCPR_ID", SqlDbType.Int) { Value = bllIssuanceDate.SCPR_ID };
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int) { Value = bllIssuanceDate.Session_Id };
        param[2] = new SqlParameter("@DateFrom", SqlDbType.DateTime) { Value = bllIssuanceDate.DateFrom };
        param[3] = new SqlParameter("@DateTo", SqlDbType.DateTime) { Value = bllIssuanceDate.DateTo };
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("StudentConditionallypromotedRequestDate_Update", param);
        int k = (int)param[4].Value;
        return k;
    }

    internal int ResultCardIssuanceDateDetailClassCenterDelete(BLLIssuanceDate obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@RIDDetId", SqlDbType.Int) { Value = obj.ResultIssueDateId };
            param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
            dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailClassCenterDelete", param);
            int k = (int)param[1].Value;
            return k;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    internal int ResultCardIssuanceDateDetailClassCenterInsert(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ResultIssueDateId", SqlDbType.Int) { Value = bllIssuanceDate.ResultIssueDateId };
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailClassCenterInsert", param);
        int k = (int)param[1].Value;
        return k;
    }

    public DataTable SelectAllClassGroups()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SelectAllClassGroups");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    internal int checkIdExistinAppliedCenters(BLLIssuanceDate obj)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ResultIssuanceId", SqlDbType.Int) { Value = obj.deleterR };
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("CheckResultDateIdExistinAppliedCenters", param);
        int k = (int)param[1].Value;
        return k;
    }

    internal DataTable getAllDatAppliedCneterClasses(BLLIssuanceDate obj)
    {
        try
        {
            DataTable _dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@TermGroupId", SqlDbType.Int) { Value = obj.TermGroup_Id };
            param[1] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = obj.Session_Id };
            param[2] = new SqlParameter("@ResultIssuanceDateId", SqlDbType.Int) { Value = obj.ResultIssueDateId };
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetAllCentersResultDateApplied", param);
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

    }

    internal int AddCenterIssuanceDate(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ResultIssueDateId", SqlDbType.Int) { Value = bllIssuanceDate.ResultIssueDateId };
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar) { Value = bllIssuanceDate.Center_Id };
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };

        dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailInsert", param);
        int k = (int)param[2].Value;
        return k;
    }

    public DataTable GetListofIssuanceDates(int termId, int SessionID)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @"
                   SELECT ResultCardIssuanceDate.ResultIssueDateId, ResultCardIssuanceDate.ResultDesc, ResultCardIssuanceDate.ResultDate, ResultCardIssuanceDate.Session_Id, ResultCardIssuanceDate.TermGroup_Id, 
                          ResultCardIssuanceDate.ClassGroupId, ResultCardIssuanceDate.Status_Id, ResultCardIssuanceDate.CreatedOn, ResultCardIssuanceDate.Createdby, ResultCardIssuanceDate.ModifedOn, ResultCardIssuanceDate.ModifedBy, 
                          ClassGroup.ClassGroupName
                          FROM            ResultCardIssuanceDate INNER JOIN
                                                     ClassGroup ON ResultCardIssuanceDate.ClassGroupId = ClassGroup.ClassGroupId
                          WHERE        ResultCardIssuanceDate.Status_Id = 1 AND ResultCardIssuanceDate.TermGroup_Id =" + termId + " AND ResultCardIssuanceDate.Session_Id =" + SessionID
            };

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
        return table;
    }

    internal int UpdateIssuanceDateMaster(BLLIssuanceDate bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@ResultIssueDateId", SqlDbType.Int) { Value = bllIssuanceDate.ResultIssueDateId };
        param[1] = new SqlParameter("@ResultDesc", SqlDbType.NVarChar) { Value = bllIssuanceDate.ResultDesc };
        param[2] = new SqlParameter("@ResultDate", SqlDbType.DateTime) { Value = bllIssuanceDate.ResultDate };
        param[3] = new SqlParameter("@ModifedOn", SqlDbType.DateTime) { Value = bllIssuanceDate.ModifedOn };
        param[4] = new SqlParameter("@ModifedBy", SqlDbType.Int) { Value = bllIssuanceDate.ModifedBy };
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("ResultCardIssuanceDateUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }

    public void DeleteIssuanceDate(int deleteR)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE ResultCardIssuanceDate SET Status_Id = 2 WHERE ResultIssueDateId=" + deleteR
            };
            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
    }
}