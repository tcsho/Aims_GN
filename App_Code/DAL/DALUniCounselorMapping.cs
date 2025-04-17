using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALIssuanceDate
/// </summary>
public class DALUniCounselorMapping
{
    private readonly DALBase dalobj = new DALBase();
    //public DataTable GetListofCampusClass(BLLUniCounselorMapping obj)
    //{
    //    SqlParameter[] param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@TermGroupId", SqlDbType.Int) { Value = obj.TermGroup_Id };
    //    param[1] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = obj.Session_Id };
    //    param[2] = new SqlParameter("@ResultCardIssuanceId", SqlDbType.Int) { Value = obj.ResultIssueDateId };

    //    var dt = dalobj.sqlcmdFetch("GetAllCampusesTermWise", param);
    //    return dt;
    //}

    public int AddUniCounMapping(BLLUniCounselorMapping bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@Cc_Center_Fk", SqlDbType.Int) { Value = bllIssuanceDate.Uc_Uni_Fk };
        param[1] = new SqlParameter("@Cc_Coun_Fk", SqlDbType.Int) { Value = bllIssuanceDate.Uc_Coun_Fk };
        param[2] = new SqlParameter("@IsActive", SqlDbType.Bit) { Value = bllIssuanceDate.IsActive };
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int) { Value = bllIssuanceDate.Status_Id };
        
        param[4] = new SqlParameter("@AddTag", SqlDbType.NVarChar) { Value = bllIssuanceDate.AddTag };
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };

        dalobj.sqlcmdExecute("[Counselor_Center_Mapping_Insert]", param);
        int k = (int)param[5].Value;
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
    

    internal int ResultCardIssuanceDateDetailClassCenterDelete(BLLUniCounselorMapping obj)
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

    internal int ResultCardIssuanceDateDetailClassCenterInsert(BLLUniCounselorMapping bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ResultIssueDateId", SqlDbType.Int) { Value = bllIssuanceDate.ResultIssueDateId };
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailClassCenterInsert", param);
        int k = (int)param[1].Value;
        return k;
    }

    public DataTable SelectAllCentersNames()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[SelectAllCenterName]");
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

    public DataTable SelectAllCounselorsNames()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SelectAllCounselors");
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

    internal int checkIdExistinAppliedCenters(BLLUniCounselorMapping obj)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ResultIssuanceId", SqlDbType.Int) { Value = obj.deleterR };
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("CheckResultDateIdExistinAppliedCenters", param);
        int k = (int)param[1].Value;
        return k;
    }

    //internal DataTable getAllDatAppliedCneterClasses(BLLUniCounselorMapping obj)
    //{
    //    try
    //    {
    //        DataTable _dt = new DataTable();
    //        SqlParameter[] param = new SqlParameter[3];
    //        param[0] = new SqlParameter("@TermGroupId", SqlDbType.Int) { Value = obj.TermGroup_Id };
    //        param[1] = new SqlParameter("@SessionId", SqlDbType.Int) { Value = obj.Session_Id };
    //        param[2] = new SqlParameter("@ResultIssuanceDateId", SqlDbType.Int) { Value = obj.ResultIssueDateId };
    //        dalobj.OpenConnection();
    //        _dt = dalobj.sqlcmdFetch("GetAllCentersResultDateApplied", param);
    //        return _dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }

    //}

    internal int AddCenterIssuanceDate(BLLUniCounselorMapping bllIssuanceDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ResultIssueDateId", SqlDbType.Int) { Value = bllIssuanceDate.ResultIssueDateId };
        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar) { Value = bllIssuanceDate.Center_Id };
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };

        dalobj.sqlcmdExecute("ResultCardIssuanceDateDetailInsert", param);
        int k = (int)param[2].Value;
        return k;
    }

    public DataTable GetList(int SessionID)
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
         SELECT Cc_Id,u.First_Name,u.Region_Id,u.Center_Id,r.Region_Name,c.Center_Name FROM Counselor_Centers_Mapping AS a  
                          INNER JOIN [User] AS u ON u.[User_Id]= a.Cc_Coun_Fk
                          INNER JOIN Region AS r ON R.Region_Id=U.Region_Id
                          INNER JOIN Center AS c ON c.Center_Id=a.Cc_Center_Fk
                          WHERE a.Session_Id =" + SessionID + " AND ISNULL(a.IsActive,0)=1 and ISNULL(a.Status_Id,0)=1 "
            };

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
        return table;
    }

    internal int UpdateIssuanceDateMaster(BLLUniCounselorMapping bllIssuanceDate)
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

    public void InActivatemapping(int deleteR)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE Counselor_Centers_Mapping SET Status_Id=2 , IsActive=0 WHERE Cc_Id=" + deleteR
            };
            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
    }
}