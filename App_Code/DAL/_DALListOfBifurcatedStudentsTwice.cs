using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALListOfBifurcatedStudentsTwice
/// </summary>
public class _DALListOfBifurcatedStudentsTwice
{
    DALBase dalobj = new DALBase();


    public _DALListOfBifurcatedStudentsTwice()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable ListSelect(int Region_Id, int Center_Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Bifurcation_Promotion_Twice", param);
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

}