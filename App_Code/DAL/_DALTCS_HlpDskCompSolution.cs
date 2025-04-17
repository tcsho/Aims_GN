using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTCS_HlpDskCompSolution
/// </summary>
public class _DALTCS_HlpDskCompSolution
{
    DALBase dalobj = new DALBase();

    public _DALTCS_HlpDskCompSolution()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_HlpDskCompSolutionSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskCompSolutionSelectAll");
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

    public int TCS_HlpDskCompSolutionInsert(BLLTCS_HlpDskCompSolution objbll)
    {
        SqlParameter[] param = new SqlParameter[5];        
        
        
        param[0] = new SqlParameter("@HDComplaint_ID",SqlDbType.Int);	param[0].Value = objbll.HDComplaint_ID;
        param[1] = new SqlParameter("@SolutionRemarks",SqlDbType.NVarChar);	param[1].Value = objbll.SolutionRemarks;
        //param[2] = new SqlParameter("@Feedback",SqlDbType.NVarChar);	param[2].Value = objbll.Feedback;
        //param[3] = new SqlParameter("@FeedBackOn",SqlDbType.DateTime);	param[3].Value = objbll.FeedBackOn;
        //param[4] = new SqlParameter("@FeedBackBy",SqlDbType.Int);	param[4].Value = objbll.FeedBackBy;
        param[2] = new SqlParameter("@SolutionOn",SqlDbType.DateTime);	param[2].Value = objbll.SolutionOn;
        param[3] = new SqlParameter("@SolutionBy",SqlDbType.Int);	param[3].Value = objbll.SolutionBy;
        //param[7] = new SqlParameter("@isClear",SqlDbType.Bit);	param[7].Value = objbll.IsClear;
        param[4] = new SqlParameter("@HD_Resource_ID", SqlDbType.Int); param[4].Value = objbll.HD_Resource_ID;



        int k = dalobj.sqlcmdExecute("TCS_HlpDskCompSolutionInsert", param);
        //k = Convert.ToInt32(param[2].Value);
        return k;

    }

    public int TCS_HlpDskCompSolutionUpdate(BLLTCS_HlpDskCompSolution objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

       param[0] = new SqlParameter("@HDCompSol_ID",SqlDbType.Int);	param[0].Value = objbll.HDCompSol_ID;
        //param[1] = new SqlParameter("@HDComplaint_ID",SqlDbType.Int);	param[1].Value = objbll.HDComplaint_ID;
        //param[1] = new SqlParameter("@SolutionRemarks",SqlDbType.NVarChar);	param[1].Value = objbll.SolutionRemarks;
        param[1] = new SqlParameter("@Feedback",SqlDbType.NVarChar);	param[1].Value = objbll.Feedback;
        param[2] = new SqlParameter("@FeedBackOn",SqlDbType.DateTime);	param[2].Value = objbll.FeedBackOn;
        param[3] = new SqlParameter("@FeedBackBy",SqlDbType.Int);	param[3].Value = objbll.FeedBackBy;
        //param[5] = new SqlParameter("@SolutionOn",SqlDbType.DateTime);	param[5].Value = objbll.SolutionOn;
        //param[6] = new SqlParameter("@SolutionBy",SqlDbType.Int);	param[6].Value = objbll.SolutionBy;
        param[4] = new SqlParameter("@isClear",SqlDbType.Bit);	param[4].Value = objbll.IsClear;





        int k = dalobj.sqlcmdExecute("TCS_HlpDskCompSolutionUpdate", param);

        return k;

    }

    public DataTable TCS_HlpDskCompSolutionSelectById(BLLTCS_HlpDskCompSolution objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDCompSol_ID", SqlDbType.Int); param[0].Value = objbll.HDCompSol_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskCompSolutionSelectById", param);
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

    public int TCS_HlpDskCompSolutionDelete(BLLTCS_HlpDskCompSolution objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDCompSol_ID", SqlDbType.Int); param[0].Value = objbll.HDCompSol_ID;
        int k = dalobj.sqlcmdExecute("TCS_HlpDskCompSolutionDelete", param);

        return k;

    }

    public DataTable TCS_HlpDskCompSolutionSelectByComplaintId(BLLTCS_HlpDskCompSolution objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDComplaint_ID", SqlDbType.Int);
        param[0].Value = objbll.HDComplaint_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskCompSolutionSelectByComplaintId", param);
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

    /*public DataTable TCS_HlpDskCompSolutionSelectByCenterId(BLLTCS_HlpDskCompSolution objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); param[0].Value = objbll.Center_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskCompSolutionSelectByCenterId", param);
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
    }*/
}
