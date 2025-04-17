using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Performance_SubItemHeads
/// </summary>
public class DALStudent_Performance_SubItemHeads
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_SubItemHeads()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_SubItemHeadsAdd(BLLStudent_Performance_SubItemHeads objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[0].Value = objbll.Description;
        param[1] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organistion_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[4].Value = objbll.CreatedBy;
        //param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[5].Value = objbll.ModifiedOn;
        //param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[6].Value = objbll.ModifiedBy;
        param[5] = new SqlParameter("@Comments", SqlDbType.NVarChar); 
        param[5].Value = objbll.Comments;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubItemHeadsInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int Student_Performance_SubItemHeadsUpdate(BLLStudent_Performance_SubItemHeads objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int);
        param[0].Value = objbll.KndItmHd_Id;
        param[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[1].Value = objbll.Description;
        param[2] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[2].Value = objbll.Main_Organistion_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[3].Value = objbll.Status_Id;
        //param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[4].Value = objbll.CreatedOn;
        //param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[5].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[5].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[6].Value = objbll.Comments;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubItemHeadsUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
    public int Student_Performance_SubItemHeadsDelete(BLLStudent_Performance_SubItemHeads objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int);
        param[0].Value = objbll.KndItmHd_Id;


        int k = dalobj.sqlcmdExecute("Student_Performance_SubItemHeadsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_SubItemHeadsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_SubItemHeadsSelectById", param);
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
    
    public DataTable Student_Performance_SubItemHeadsSelect(BLLStudent_Performance_SubItemHeads objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_SubItemHeadsSelectAll", param);
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

    public DataTable Student_Performance_SubItemHeadsSelectByStatusID(BLLStudent_Performance_SubItemHeads objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubItemHeadsSelectByStatusID");
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


    public DataTable Student_Performance_SubItemHeads_SelectAllByOrgID(BLLStudent_Performance_SubItemHeads _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubItemHeads_SelectAllByOrgID", param);
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

    public DataTable Student_Performance_SubItemHeads_SelectAllBYKindItemHdId(BLLStudent_Performance_SubItemHeads _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@Kinditem_Id", SqlDbType.Int);
        param[1].Value = _obj.KndItmHd_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubItemHeads_SelectAllBYKindItemHdId", param);
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

    public DataTable GetSubjectWiseItemHeadsAvailability(BLLStudent_Performance_SubItemHeads _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@Description", SqlDbType.Int);
        param[1].Value = _obj.Description;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetSubjectWiseItemHeadsAvailability", param);
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
