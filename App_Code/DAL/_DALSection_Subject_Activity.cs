using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSection_Subject_Activity
/// </summary>
public class DALSection_Subject_Activity
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Activity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_ActivityAdd(BLLSection_Subject_Activity objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_ActivityInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Section_Subject_ActivityUpdate(BLLSection_Subject_Activity objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_ActivityUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_ActivityDelete(BLLSection_Subject_Activity objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Activity_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Activity_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_ActivityDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_ActivitySelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_ActivitySelectById", param);
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
    
    public DataTable Section_Subject_ActivitySelect(BLLSection_Subject_Activity objbll)
    {
    
        SqlParameter[] param = new SqlParameter[3];

    
        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); 
        param[0].Value = objbll.Main_Organisation_Id;
    
        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int); 
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;
    
        param[2] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); 
        param[2].Value = objbll.Section_Subject_Id;
    

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_ActivitySelectAll", param);
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

    public DataTable Section_Subject_ActivitySelectByStatusID(BLLSection_Subject_Activity objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_ActivitySelectByStatusID");
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
