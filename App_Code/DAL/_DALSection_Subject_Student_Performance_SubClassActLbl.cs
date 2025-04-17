using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSection_Subject_Student_Performance_SubClassActLbl
/// </summary>
public class DALSection_Subject_Student_Performance_SubClassActLbl
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Student_Performance_SubClassActLbl()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_Student_Performance_SubClassActLblAdd(BLLSection_Subject_Student_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[15];
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int); param[1].Value = objbll.SubKndItmLbl_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int); param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Description", SqlDbType.NVarChar); param[4].Value = objbll.Description;
        param[5] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); param[5].Value = objbll.Main_Organistion_Id;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int); param[6].Value = objbll.Status_Id;
        param[7] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int); param[7].Value = objbll.KndItmHd_Id;
        param[8] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[8].Value = objbll.CreatedOn;
        param[9] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[9].Value = objbll.CreatedBy;
        param[10] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[10].Value = objbll.ModifiedOn;
        param[11] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[11].Value = objbll.ModifiedBy;
        param[12] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int); param[12].Value = objbll.Evaluation_Criteria_Type_Id;
        param[13] = new SqlParameter("@OrderOfPer", SqlDbType.Int); param[13].Value = objbll.OrderOfPer;

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Student_Performance_SubClassActLblInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Section_Subject_Student_Performance_SubClassActLblUpdate(BLLSection_Subject_Student_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@SSSKIL_Id", SqlDbType.Int); param[0].Value = objbll.SSSKIL_Id;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int); param[2].Value = objbll.SubKndItmLbl_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int); param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@Description", SqlDbType.NVarChar); param[5].Value = objbll.Description;
        param[6] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); param[6].Value = objbll.Main_Organistion_Id;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); param[7].Value = objbll.Status_Id;
        param[8] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int); param[8].Value = objbll.KndItmHd_Id;
        param[9] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[9].Value = objbll.CreatedOn;
        param[10] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[10].Value = objbll.CreatedBy;
        param[11] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[11].Value = objbll.ModifiedOn;
        param[12] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[12].Value = objbll.ModifiedBy;
        param[13] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int); param[13].Value = objbll.Evaluation_Criteria_Type_Id;
        param[14] = new SqlParameter("@OrderOfPer", SqlDbType.Int); param[14].Value = objbll.OrderOfPer;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Student_Performance_SubClassActLblUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_Student_Performance_SubClassActLblDelete(BLLSection_Subject_Student_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Student_Performance_SubClassActLbl_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Student_Performance_SubClassActLbl_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_Student_Performance_SubClassActLblDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_Student_Performance_SubClassActLblSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Student_Performance_SubClassActLblSelectById", param);
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
    
    public DataTable Section_Subject_Student_Performance_SubClassActLblSelect(BLLSection_Subject_Student_Performance_SubClassActLbl objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_Student_Performance_SubClassActLblSelectAll", param);
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

    public DataTable Section_Subject_Student_Performance_SubClassActLblSelectByStatusID(BLLSection_Subject_Student_Performance_SubClassActLbl objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_Student_Performance_SubClassActLblSelectByStatusID");
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
