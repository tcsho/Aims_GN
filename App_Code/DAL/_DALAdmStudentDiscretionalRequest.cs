using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmStudentDiscretionalRequest
/// </summary>
public class DALAdmStudentDiscretionalRequest
{
    DALBase dalobj = new DALBase();


    public DALAdmStudentDiscretionalRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmStudentDiscretionalRequestAdd(BLLAdmStudentDiscretionalRequest objbll,string mode)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@Regisration_Id", SqlDbType.Int);
        param[0].Value = objbll.Regisration_Id;

        param[1] = new SqlParameter("@Heads_Remarks", SqlDbType.NVarChar);
        param[1].Value = (objbll.Heads_Remarks != null) ? objbll.Heads_Remarks : "";

        param[2] = new SqlParameter("@Submited_By", SqlDbType.Int);
        param[2].Value = objbll.Submited_By;


        param[3] = new SqlParameter("@Mode", SqlDbType.NVarChar);
        param[3].Value = mode;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmStudentDiscretionalRequestInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int AdmStudentDiscretionalRequestUpdate(BLLAdmStudentDiscretionalRequest objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

       
        param[0] = new SqlParameter("@Regisration_Id", SqlDbType.Int); 
        param[0].Value = objbll.Regisration_Id;
        
        param[1] = new SqlParameter("@NH_Approval", SqlDbType.Bit); 
        param[1].Value = objbll.NH_Approval;
        param[2] = new SqlParameter("@NH_Approval_By", SqlDbType.Int); 
        param[2].Value = objbll.NH_Approval_By;
        param[3] = new SqlParameter("@NH_Remarks", SqlDbType.NVarChar);
        param[3].Value = objbll.NH_Remarks;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmStudentDiscretionalRequestUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int AdmStudentDiscretionalRequestDelete(BLLAdmStudentDiscretionalRequest objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmStudentDiscretionalRequest_Id", SqlDbType.Int);
        //   param[0].Value = objbll.AdmStudentDiscretionalRequest_Id;


        int k = dalobj.sqlcmdExecute("AdmStudentDiscretionalRequestDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmStudentDiscretionalRequestSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("AdmStudentDiscretionalRequestSelectById", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;
    }

    public DataTable AdmStudentDiscretionalRequestSelect(BLLAdmStudentDiscretionalRequest objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = objbll.NH_Approval_By;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("AdmStudentDiscretionalRequestSelectAll", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }

    public DataTable AdmStudentDiscretionalRequestSelectByStatusID(BLLAdmStudentDiscretionalRequest objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("AdmStudentDiscretionalRequestSelectByStatusID");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }




    #endregion


}
