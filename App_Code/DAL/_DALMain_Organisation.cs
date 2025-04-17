using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALMain_Organisation
/// </summary>
public class DALMain_Organisation
{
    DALBase dalobj = new DALBase();


    public DALMain_Organisation()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Main_OrganisationAdd(BLLMain_Organisation objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        //param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Id;
        param[0] = new SqlParameter("@Main_Organisation_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Main_Organisation_Name;
        param[1] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[1].Value = objbll.Address;
        param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
        param[2].Value = objbll.Phone;
        param[3] = new SqlParameter("@Organisation_ID", SqlDbType.NVarChar);
        param[3].Value = objbll.Organisation_ID;
        param[4] = new SqlParameter("@Website", SqlDbType.NVarChar);
        param[4].Value = objbll.Website;
        param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[5].Value = objbll.Email;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[6].Value = objbll.Status_Id;
        param[7] = new SqlParameter("@Bank_Id", SqlDbType.Int);
        param[7].Value = objbll.Bank_Id;


        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Main_OrganisationInsert", param);
        int k = (int)param[8].Value;
        return k;

    }
    public int Main_OrganisationUpdate(BLLMain_Organisation objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        //param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Id;
        param[0] = new SqlParameter("@Main_Organisation_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Main_Organisation_Name;
        param[1] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[1].Value = objbll.Address;
        param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
        param[2].Value = objbll.Phone;
        param[3] = new SqlParameter("@Organisation_ID", SqlDbType.NVarChar);
        param[3].Value = objbll.Organisation_ID;
        param[4] = new SqlParameter("@Website", SqlDbType.NVarChar);
        param[4].Value = objbll.Website;
        param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[5].Value = objbll.Email;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[6].Value = objbll.Status_Id;
        param[7] = new SqlParameter("@Bank_Id", SqlDbType.Int);
        param[7].Value = objbll.Bank_Id;


        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Main_OrganisationUpdate", param);
        int k = (int)param[8].Value;
        return k;
    }
    public int Main_OrganisationDelete(BLLMain_Organisation objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Main_Organisation_Id;


        int k = dalobj.sqlcmdExecute("Main_OrganisationDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Main_OrganisationSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Main_OrganisationSelectById", param);
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

    public DataTable Main_OrganisationSelect(BLLMain_Organisation objbll)
    {
        //  SqlParameter[] param = new SqlParameter[3];

        //  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        ////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Main_OrganisationSelectAll");
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

    public DataTable Main_OrganisationSelectByStatusID(BLLMain_Organisation objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Main_OrganisationSelectByStatusID");
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
