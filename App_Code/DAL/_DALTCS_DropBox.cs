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
/// Summary description for _DALTCS_DropBox
/// </summary>
public class DALTCS_DropBox
{
    DALBase dalobj = new DALBase();


    public DALTCS_DropBox()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int TCS_DropBoxAdd(BLLTCS_DropBox objbll)
    {
        SqlParameter[] param = new SqlParameter[7];



        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = objbll.Region_ID;
        param[2] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[2].Value = objbll.Center_ID;
        param[3] = new SqlParameter("@DropBoxResourcePath", SqlDbType.NVarChar);
        param[3].Value = objbll.DropBoxResourcePath;
        param[4] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[4].Value = objbll.Status_ID;
        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        //////////////////param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        //////////////////param[6].Value = objbll.ModifiedOn;
        //////////////////param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        //////////////////param[7].Value = objbll.ModifiedBy;




        ////////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        ////////param[14].Direction = ParameterDirection.Output;


        int k = dalobj.sqlcmdExecute("TCS_DropBoxInsert", param);
        return k;

     

    }
    public int TCS_DropBoxUpdate(BLLTCS_DropBox objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@TCS_DropBox_ID", SqlDbType.Int); param[0].Value = objbll.TCS_DropBox_ID;
        param[0] = new SqlParameter("@Region_ID", SqlDbType.Int); param[0].Value = objbll.Region_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int); param[1].Value = objbll.Center_ID;
        param[2] = new SqlParameter("@DropBoxResourcePath", SqlDbType.NVarChar); param[2].Value = objbll.DropBoxResourcePath;
        param[3] = new SqlParameter("@Status_ID", SqlDbType.Int); param[3].Value = objbll.Status_ID;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[7].Value = objbll.ModifiedBy;






        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TCS_DropBoxUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int TCS_DropBoxDelete(BLLTCS_DropBox objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@TCS_DropBox_Id", SqlDbType.Int);
     //   param[0].Value = objbll.TCS_DropBox_Id;


        int k = dalobj.sqlcmdExecute("TCS_DropBoxDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable TCS_DropBoxSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("TCS_DropBoxSelectById", param);
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
    
    public DataTable TCS_DropBoxSelect(BLLTCS_DropBox objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("TCS_DropBoxSelectAll", param);
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

    public DataTable TCS_DropBoxSelectByStatusID(BLLTCS_DropBox objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_DropBoxSelectByStatusID");
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




    public DataTable TCS_DrobBoxSelectAllCenterByRegionId(BLLTCS_DropBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

       
        param[0] = new SqlParameter("@Region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_DrobBoxSelectAllCenterByRegionId", param);
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



    public DataTable TCS_DrobBoxSelectCenterByCenterId(BLLTCS_DropBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_DrobBoxSelectCenterByCenterId", param);
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






    #endregion


}
