using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALLmsSchEventFrequency
/// </summary>
public class DALLmsSchEventFrequency
{
    DALBase dalobj = new DALBase();


    public DALLmsSchEventFrequency()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSchEventFrequencyAdd(BLLLmsSchEventFrequency objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //////param[0] = new SqlParameter("@EFrequency_ID", SqlDbType.Int);
        //////param[0].Value = objbll.EFrequency_ID;
        param[0] = new SqlParameter("@Frequency_ID", SqlDbType.Int);
        param[0].Value = objbll.Frequency_ID;
        param[1] = new SqlParameter("@EFreqGap", SqlDbType.Int);
        param[1].Value = objbll.EFreqGap;
        param[2] = new SqlParameter("@EndsAfter", SqlDbType.Int); 
        param[2].Value = objbll.EndsAfter;
        param[3] = new SqlParameter("@EndDate", SqlDbType.DateTime); 
        param[3].Value = objbll.EndDate;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;
        ////////////////param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        ////////////////param[6].Value = objbll.ModifiedOn;
        ////////////////param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        ////////////////param[7].Value = objbll.ModifiedBy;



        param[6] = new SqlParameter("@lastEvtFreqID", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventFrequencyInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int LmsSchEventFrequencyUpdate(BLLLmsSchEventFrequency objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@EFrequency_ID", SqlDbType.Int); param[0].Value = objbll.EFrequency_ID;
        param[0] = new SqlParameter("@Frequency_ID", SqlDbType.Int); param[0].Value = objbll.Frequency_ID;
        param[1] = new SqlParameter("@EFreqGap", SqlDbType.Int); param[1].Value = objbll.EFreqGap;
        param[2] = new SqlParameter("@EndsAfter", SqlDbType.Int); param[2].Value = objbll.EndsAfter;
        param[3] = new SqlParameter("@EndDate", SqlDbType.DateTime); param[3].Value = objbll.EndDate;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[7].Value = objbll.ModifiedBy;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventFrequencyUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSchEventFrequencyDelete(BLLLmsSchEventFrequency objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsSchEventFrequency_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsSchEventFrequency_Id;


        int k = dalobj.sqlcmdExecute("LmsSchEventFrequencyDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSchEventFrequencySelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventFrequencySelectById", param);
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
    
    public DataTable LmsSchEventFrequencySelect(BLLLmsSchEventFrequency objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventFrequencySelectAll", param);
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

    public DataTable LmsSchEventFrequencySelectByStatusID(BLLLmsSchEventFrequency objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchEventFrequencySelectByStatusID");
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
