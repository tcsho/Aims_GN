using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALSendEmail
/// </summary>
public class _DALSendEmail
{
    DALBase dalobj = new DALBase();
	public _DALSendEmail()
	{
		
	}

    public DataTable TssHoEmailConfigurationSelectByCategoryId(BLLSendEmail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@EmailCategory_Id", SqlDbType.Int); 
        param[0].Value = objbll.EmailCategory_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("EmailConfigurationSelectByCategoryId", param);
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
    public DataTable Discretionary_Admission_Email(int region, int center)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int); 
        param[0].Value = region;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = center;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Discretionary_Admission_Email", param);
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

    
}
