using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALLmsAppPagesFAQ
/// </summary>
public class _DALLmsAppPagesFAQ
{
    DALBase dalobj = new DALBase();

    public _DALLmsAppPagesFAQ()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable LmsAppPagesFAQSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesFAQSelectAll");
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

    public int LmsAppPagesFAQInsert(BLLLmsAppPagesFAQ objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        /*param[0] = new SqlParameter("@FAQ_ID", SqlDbType.Int); param[0].Value = objbll.FAQ_ID;
        param[1] = new SqlParameter("@Page_ID", SqlDbType.Int); param[1].Value = objbll.Page_ID;
        param[2] = new SqlParameter("@OrderNo", SqlDbType.Int); param[2].Value = objbll.OrderNo;
        param[3] = new SqlParameter("@Question", SqlDbType.NVarChar); param[3].Value = objbll.Question;
        param[4] = new SqlParameter("@Answer", SqlDbType.NVarChar); param[4].Value = objbll.Answer;
        param[5] = new SqlParameter("@Status_ID", SqlDbType.Int); param[5].Value = objbll.Status_ID;
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[6].Value = objbll.CreatedOn;
        param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[7].Value = objbll.CreatedBy;
        param[8] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[8].Value = objbll.ModifiedOn;
        param[9] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[9].Value = objbll.ModifiedBy;*/

        
        param[0] = new SqlParameter("@Page_ID", SqlDbType.Int); param[0].Value = objbll.Page_ID;        
        param[1] = new SqlParameter("@Question", SqlDbType.NVarChar); param[1].Value = objbll.Question;
        param[2] = new SqlParameter("@Answer", SqlDbType.NVarChar); param[2].Value = objbll.Answer;        
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[4].Value = objbll.CreatedBy;        
        param[5] = new SqlParameter("@alreadyExists", SqlDbType.Int); param[5].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("LmsAppPagesFAQInsert", param);
        k = Convert.ToInt32(param[5].Value);
        return k;

    }

    public int LmsAppPagesFAQUpdate(BLLLmsAppPagesFAQ objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@FAQ_ID", SqlDbType.Int); param[0].Value = objbll.FAQ_ID;
        param[1] = new SqlParameter("@Page_ID", SqlDbType.Int); param[1].Value = objbll.Page_ID;
        param[2] = new SqlParameter("@Question", SqlDbType.NVarChar); param[2].Value = objbll.Question;
        param[3] = new SqlParameter("@Answer", SqlDbType.NVarChar); param[3].Value = objbll.Answer;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[5].Value = objbll.ModifiedBy;

        int k = dalobj.sqlcmdExecute("LmsAppPagesFAQUpdate", param);

        return k;

    }

    public DataTable LmsAppPagesFAQSelectById(BLLLmsAppPagesFAQ objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@FAQ_ID", SqlDbType.Int); param[0].Value = objbll.FAQ_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesFAQSelectById", param);
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

    public int LmsAppPagesFAQDelete(BLLLmsAppPagesFAQ objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@FAQ_ID", SqlDbType.Int); param[0].Value = objbll.FAQ_ID;

        int k = dalobj.sqlcmdExecute("LmsAppPagesFAQDelete", param);

        return k;

    }

    public DataTable LmsAppPagesFAQSelectByPageID(BLLLmsAppPagesFAQ objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Page_ID", SqlDbType.Int); param[0].Value = objbll.Page_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesFAQSelectByPageID", param);
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
