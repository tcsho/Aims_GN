using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStdAttnType.cs
/// </summary>
public class _DALTCS_StdAttnType 
{
    DALBase dalobj = new DALBase();

    public _DALTCS_StdAttnType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int TCS_StdAttnTypeInsert(BLLTCS_StdAttnType objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@AttnDesc", SqlDbType.NVarChar);
        param[0].Value = objbll.AttnDesc;

        param[1] = new SqlParameter("@AttCode", SqlDbType.NVarChar);
        param[1].Value = objbll.AttCode;

        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[4].Value = objbll.CreatedOn;
   
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        int val = dalobj.sqlcmdExecute("TCS_StdAttnTypeInsert", param);

        val = Convert.ToInt32(param[5].Value);
        return val;
    }

    internal DataTable GetSectionClassByTeacher(int teacherId)
    {
        DataTable dataTable = new DataTable();
        string connString = dalobj._cn.ConnectionString;
        string query = @"SELECT        Class.Class_Id AS Class_Id, Class.Class_Name + ' - '+ Section.Section_Name as [Name], Section.Section_Id as Class_Section_Id, Section.Section_Name,Section.ClassTeacher_Id
                        FROM            Section INNER JOIN
                         Class ON Section.Class_Id = Class.Class_Id
                        where ClassTeacher_Id=" + teacherId;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();

        // create data adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // this will query your database and return the result to your datatable
        da.Fill(dataTable);
        conn.Close();
        da.Dispose();

        return dataTable;
    }

    public int TCS_StdAttnTypeUpdate(BLLTCS_StdAttnType objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@AttnType_ID", SqlDbType.NVarChar); 
        param[0].Value = objbll.AttnType_ID;
        param[1] = new SqlParameter("@AttnDesc", SqlDbType.NVarChar);
        param[1].Value = objbll.AttnDesc;
        param[2] = new SqlParameter("@AttCode", SqlDbType.NVarChar);
        param[2].Value = objbll.AttCode;

        param[3] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[3].Value = objbll.ModifiedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[4].Value = objbll.ModifiedOn;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("TCS_StdAttnTypeUpdate", param);
        int k = (int)param[5].Value;
        return k;


        //int k = dalobj.sqlcmdExecute("TCS_StdAttnTypeUpdate", param);
        
        //return k;
    }
    public DataTable TCS_StdAttnTypeSelectAll()
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnTypeSelectAll");
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
    } // OK-SFA
    public DataTable TCS_StdAttnTypeSelectByAttnType_ID(BLLTCS_StdAttnType objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AttnType_ID", SqlDbType.Int);
        param[0].Value = objbll.AttnType_ID;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnTypeSelectByAttnType_ID", param);
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
    } // OK-SFA
    public int TCS_StdAttnTypeDelete(BLLTCS_StdAttnType objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@AttnType_ID", SqlDbType.Int);
        param[0].Value = objbll.AttnType_ID;
        param[1] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[1].Value = objbll.ModifiedBy;
        param[2] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[2].Value = objbll.ModifiedOn;


        int k = dalobj.sqlcmdExecute("TCS_StdAttnTypeDelete", param);

        return k;
    }
}
