using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Performance_SubClassActLbl
/// </summary>
public class DALStudent_Performance_SubClassActLbl
{
    DALBase dalobj = new DALBase();


    public DALStudent_Performance_SubClassActLbl()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Performance_SubClassActLblAdd(BLLStudent_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[11];
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Description", SqlDbType.NVarChar); 
        param[2].Value = objbll.Description;
        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); 
        param[3].Value = objbll.Main_Organistion_Id;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[4].Value = objbll.Status_Id;
        param[5] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int); 
        param[5].Value = objbll.KndItmHd_Id;
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[6].Value = objbll.CreatedOn;
        param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[7].Value = objbll.CreatedBy;
        //param[8] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        //param[8].Value = objbll.ModifiedOn;
        //param[9] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        //param[9].Value = objbll.ModifiedBy;
        param[8] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int); 
        param[8].Value = objbll.Evaluation_Criteria_Type_Id;
        param[9] = new SqlParameter("@OrderOfPer", SqlDbType.Int);
        param[9].Value = objbll.OrderOfPer;

        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubClassActLblInsert", param);
        int k = (int)param[10].Value;
        return k;

    }

    public int Student_Performance_SubClassActLblGeneralPerformanceInsert(BLLStudent_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[2].Value = objbll.Description;
        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organistion_Id;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[4].Value = objbll.Status_Id;
        ////////////param[5] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int);
        ////////////param[5].Value = objbll.KndItmHd_Id;
        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        //param[8] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        //param[8].Value = objbll.ModifiedOn;
        //param[9] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        //param[9].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[7].Value = objbll.TermGroup_Id;
        //param[9] = new SqlParameter("@OrderOfPer", SqlDbType.Int); 
        //param[9].Value = objbll.OrderOfPer;

        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubClassActLblGeneralPerformanceInsert", param);
        int k = (int)param[8].Value;
        return k;

    }

    public int Student_Performance_SubClassActLblUpdate(BLLStudent_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[12];
        param[0] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int);
        param[0].Value = objbll.SubKndItmLbl_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Description", SqlDbType.NVarChar); 
        param[3].Value = objbll.Description;
        param[4] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int); 
        param[4].Value = objbll.Main_Organistion_Id;
        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[5].Value = objbll.Status_Id;
        param[6] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int); 
        param[6].Value = objbll.KndItmHd_Id;
        ////param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        ////param[7].Value = objbll.CreatedOn;
        ////param[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        ////param[8].Value = objbll.CreatedBy;
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[8].Value = objbll.ModifiedBy;
        param[9] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[9].Value = objbll.Evaluation_Criteria_Type_Id;
        param[10] = new SqlParameter("@OrderOfPer", SqlDbType.Int);
        param[10].Value = objbll.OrderOfPer;

 
        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubClassActLblUpdate", param);
        int k = (int)param[11].Value;
        return k;
    }

    public int Student_Performance_SubClassActLblGeneralPerformanceUpdate(BLLStudent_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int);
        param[0].Value = objbll.SubKndItmLbl_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[3].Value = objbll.Description;
        param[4] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[4].Value = objbll.Main_Organistion_Id;
        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[5].Value = objbll.Status_Id;
        //////param[6] = new SqlParameter("@KndItmHd_Id", SqlDbType.Int);
        //////param[6].Value = objbll.KndItmHd_Id;
        ////param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        ////param[7].Value = objbll.CreatedOn;
        ////param[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        ////param[8].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[7].Value = objbll.ModifiedBy;
        param[8] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[8].Value = objbll.Evaluation_Criteria_Type_Id;
        //param[12] = new SqlParameter("@OrderOfPer", SqlDbType.Int);
        //param[12].Value = objbll.OrderOfPer;


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Performance_SubClassActLblGeneralPerformanceUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }

    public int Student_Performance_SubClassActLblDelete(BLLStudent_Performance_SubClassActLbl objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int);
       param[0].Value = objbll.SubKndItmLbl_Id;


        int k = dalobj.sqlcmdExecute("Student_Performance_SubClassActLblDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Performance_SubClassActLblSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLblSelectById", param);
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
    
    public DataTable Student_Performance_SubClassActLblSelect(BLLStudent_Performance_SubClassActLbl objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLblSelectAll", param);
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

    public DataTable Student_Performance_SubClassActLblSelectByStatusID(BLLStudent_Performance_SubClassActLbl objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLblSelectByStatusID");
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


    public DataTable Student_Performance_SubClassActLbl_SelectAllByOrgIdClassIdSubjectId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        ////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////param[2].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Evl_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLbl_SelectAllByOrgIdClassIdSubjectId", param);
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


    public DataTable Student_Performance_SubClassActLbl_SelectAllByTermGroupId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        ////////////////param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        ////////////////param[0].Value = _obj.Main_Organistion_Id;

        ////////////////param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        ////////////////param[1].Value = _obj.Class_Id;

        ////////////////////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////////////////////param[2].Value = _obj.Subject_Id;

        param[0] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[0].Value = _obj.TermGroup_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLbl_SelectAllByTermGroupId", param);
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

    public DataTable Student_Performance_SubClassActLbl_SelectAllBySubKndItmLblId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organistion_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        ////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////param[2].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Evl_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        param[3] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int);
        param[3].Value = _obj.SubKndItmLbl_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLbl_SelectAllBySubKndItmLblId", param);
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

    public DataTable Student_Performance_SubClassActLbl_SelectAllByTermGroupIdSubKndItmLblId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        //////////////////param[0] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        //////////////////param[0].Value = _obj.Main_Organistion_Id;

        //////////////////param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //////////////////param[1].Value = _obj.Class_Id;

        ////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////param[2].Value = _obj.Subject_Id;

        param[0] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[0].Value = _obj.TermGroup_Id;

        param[1] = new SqlParameter("@SubKndItmLbl_Id", SqlDbType.Int);
        param[1].Value = _obj.SubKndItmLbl_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Performance_SubClassActLbl_SelectAllByTermGroupIdSubKndItmLblId", param);
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
