using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALClass_Change_Request
/// </summary>
public class DALClass_Change_Request
{
    DALBase dalobj = new DALBase();


    public DALClass_Change_Request()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_Change_RequestAdd(BLLClass_Change_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int); 
        param[0].Value = objbll.Student_Id;
       
        param[1] = new SqlParameter("@ToClass_Id", SqlDbType.Int); 
        param[1].Value = objbll.ToClass_Id;
      
        param[2] = new SqlParameter("@CCReason_Id", SqlDbType.Int); 
        param[2].Value = objbll.CCReason_Id;
        param[3] = new SqlParameter("@Submit_By", SqlDbType.Int); 
        param[3].Value = objbll.Submit_By;
       
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;

        param[5] = new SqlParameter("@CCReq_Id", SqlDbType.NVarChar);
        param[5].Value = objbll.CCReq_Id;
        
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Change_RequestInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int Class_Change_RequestUpdate(BLLClass_Change_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@CCReq_Id", SqlDbType.Int); 
        param[0].Value = objbll.CCReq_Id;
        param[1] = new SqlParameter("@isApproved", SqlDbType.Bit); 
        param[1].Value = objbll.isApproved;
        param[2] = new SqlParameter("@Approved_By", SqlDbType.Int); 
        param[2].Value = objbll.Approved_By;
   
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Change_RequestUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Class_Change_RequestAction(BLLClass_Change_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CCReq_Id", SqlDbType.Int);
        param[0].Value = objbll.CCReq_Id;
        int k = dalobj.sqlcmdExecute("Class_Change_RequestAction", param);
        return k;
    }
    public int Class_Change_RequestDelete(BLLClass_Change_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CCReq_Id", SqlDbType.Int);
        param[0].Value = objbll.CCReq_Id;


        int k = dalobj.sqlcmdExecute("Class_Change_RequestDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_Change_RequestSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_RequestSelectById", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;
    }

    public DataTable Class_Change_RequestSelect(BLLClass_Change_Request objbll)
    {
        //SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        //param[0].Value = objbll.Region_Id;
        //param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        //param[1].Value = objbll.Center_Id;

        //param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //param[2].Value = objbll.FromClass_Id;
        SqlParameter[] param = new SqlParameter[15];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id.ToString();

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id.ToString();

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        param[10].Value = objbll.Section_Id;

        param[11] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[11].Value = objbll.Main_Organisation_Id;

        param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        param[12].Value = objbll.Teacher_Id;

        param[13] = new SqlParameter("@sp_end_index", SqlDbType.NChar);
        param[13].Value = objbll.EndIndex;

        param[14] = new SqlParameter("@sp_start_index", SqlDbType.NChar);
        param[14].Value = objbll.StartIndex;
            
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_RequestSelectAll", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }

    public DataTable Class_Change_RequestFetchforApproval(BLLClass_Change_Request objbll)
    
	{
       
	 DataTable dt = new DataTable();
 
        SqlParameter[] param = new SqlParameter[4];
 
 
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
 
       param[0].Value = objbll.Region_Id;
    
    param[1] = new SqlParameter("@User_Id", SqlDbType.Int);
  
      param[1].Value = objbll.Approved_By;
     
   param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
 
       param[2].Value = objbll.Class_Id;
    
    param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
  
      param[3].Value = objbll.Center_Id;
  
      try
   
     {
  
          dalobj.OpenConnection();
   
         dt = dalobj.sqlcmdFetch("Class_Change_RequestforApproval", param);
     
       return dt;
  
      }
     
   catch (Exception _exception)
  
      {
        
    throw _exception;
  
      }
       
 finally
        
{
            
dalobj.CloseConnection();
     
   }
 
     
   return dt;
 
 
   }
    
    public DataTable Class_Change_RequestNotification(BLLClass_Change_Request objbll)
    {
        DataTable dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = objbll.Approved_By;
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_RequestNotification", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }




    #endregion


}
