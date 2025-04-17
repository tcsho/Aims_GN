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
/// Summary description for _DALStudent_Evaluation_SubjectRemarks
/// </summary>
public class _DALStudent_Evaluation_SubjectRemarks
{
    DALBase dalobj = new DALBase();


    public _DALStudent_Evaluation_SubjectRemarks()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Evaluation_SubjectRemarksUpsert(BLLStudent_Evaluation_SubjectRemarks objbll)
    {
        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@Std_Com_Id", SqlDbType.Int); param[0].Value = objbll.Std_Com_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int); param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int); param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); param[4].Value = objbll.TermGroup_Id;
        param[5] = new SqlParameter("@Student_Id", SqlDbType.Int); param[5].Value = objbll.Student_Id;
        param[6] = new SqlParameter("@Remarks", SqlDbType.NVarChar); param[6].Value = objbll.Remarks;
        param[7] = new SqlParameter("@Effort", SqlDbType.Int); param[7].Value = objbll.Effort;
        param[8] = new SqlParameter("@Employee_Id", SqlDbType.Int); param[8].Value = objbll.Employee_Id;
        param[9] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[9].Value = objbll.CreatedBy;
        param[10] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[10].Value = objbll.CreatedOn;
        param[11] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[11].Value = objbll.ModifiedBy;
        param[12] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[12].Value = objbll.ModifiedOn;
        param[13] = new SqlParameter("@GoodOne", SqlDbType.Int); param[13].Value = objbll.GoodOne;
        param[14] = new SqlParameter("@GoodTwo", SqlDbType.Int); param[14].Value = objbll.GoodTwo;
        param[15] = new SqlParameter("@ImprovOne", SqlDbType.Int); param[15].Value = objbll.ImprovOne;
        param[16] = new SqlParameter("@ImprovTwo", SqlDbType.Int); param[16].Value = objbll.ImprovTwo;
        param[17] = new SqlParameter("@isAbsent", SqlDbType.Bit); param[17].Value = objbll.isAbsent;

        param[18] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[18].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_SubjectRemarksUpsert", param);
        int k = (int)param[18].Value;
        return k;

    }
    public int Student_Evaluation_SubjectRemarksUpsert_correction(BLLStudent_Evaluation_SubjectRemarks objbll)
    {
        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@Std_Com_Id", SqlDbType.Int); param[0].Value = objbll.Std_Com_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int); param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int); param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int); param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); param[4].Value = objbll.TermGroup_Id;
        param[5] = new SqlParameter("@Student_Id", SqlDbType.Int); param[5].Value = objbll.Student_Id;
        param[6] = new SqlParameter("@Remarks", SqlDbType.NVarChar); param[6].Value = objbll.Remarks;
        param[7] = new SqlParameter("@Effort", SqlDbType.Int); param[7].Value = objbll.Effort;
        param[8] = new SqlParameter("@Employee_Id", SqlDbType.Int); param[8].Value = objbll.Employee_Id;
        param[9] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[9].Value = objbll.CreatedBy;
        param[10] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[10].Value = objbll.CreatedOn;
        param[11] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[11].Value = objbll.ModifiedBy;
        param[12] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[12].Value = objbll.ModifiedOn;
        param[13] = new SqlParameter("@GoodOne", SqlDbType.Int); param[13].Value = objbll.GoodOne;
        param[14] = new SqlParameter("@GoodTwo", SqlDbType.Int); param[14].Value = objbll.GoodTwo;
        param[15] = new SqlParameter("@ImprovOne", SqlDbType.Int); param[15].Value = objbll.ImprovOne;
        param[16] = new SqlParameter("@ImprovTwo", SqlDbType.Int); param[16].Value = objbll.ImprovTwo;
        param[17] = new SqlParameter("@isAbsent", SqlDbType.Bit); param[17].Value = objbll.isAbsent;

        param[18] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[18].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_SubjectRemarksUpsert_correction", param);
        int k = (int)param[18].Value;
        return k;

    }
    public int Student_Evaluation_SubjectRemarksUpdate(BLLStudent_Evaluation_SubjectRemarks objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_SubjectRemarksUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Evaluation_SubjectRemarksDelete(BLLStudent_Evaluation_SubjectRemarks objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Evaluation_SubjectRemarks_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Evaluation_SubjectRemarks_Id;


        int k = dalobj.sqlcmdExecute("Student_Evaluation_SubjectRemarksDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Evaluation_SubjectRemarksSelectById(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Evaluation_SubjectRemarksSelect", param);
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
    
    public DataTable Student_Evaluation_SubjectRemarksSelectAll(BLLStudent_Evaluation_SubjectRemarks objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_Evaluation_SubjectRemarksSelectAll", param);
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
