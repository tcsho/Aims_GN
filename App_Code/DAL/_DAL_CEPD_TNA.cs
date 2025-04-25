using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class _DAL_CEPD_TNA
{
    DALBase dalobj = new DALBase();

    public _DAL_CEPD_TNA()
    {
        // Constructor logic
    }

    public string SaveTNA(BLLCEPD_TNA obj)
    {        
	   
        SqlParameter[] param = new SqlParameter[29];

        param[0] = new SqlParameter("@Center_Code", SqlDbType.VarChar, 50);
        param[0].Value = obj.Center_Code;

        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = obj.Center_ID;

        param[2] = new SqlParameter("@Center_Name", SqlDbType.VarChar, 200);
        param[2].Value = obj.Center_Name;

        param[3] = new SqlParameter("@Region_ID", SqlDbType.VarChar, 100);
        param[3].Value = obj.Region_ID;

        param[4] = new SqlParameter("@Region_Name", SqlDbType.VarChar, 200);
        param[4].Value = obj.Region_Name;

        param[5] = new SqlParameter("@City", SqlDbType.VarChar, 200);
        param[5].Value = obj.City;

        param[6] = new SqlParameter("@TotalTeacher", SqlDbType.Int);
        param[6].Value = obj.TotalTeachers;

        param[7] = new SqlParameter("@KeyStages", SqlDbType.VarChar, 250);
        param[7].Value = obj.KeyStages;
        
        
        
        param[8] = new SqlParameter("@KSTotalTeacher", SqlDbType.Int);
        param[8].Value = obj.KSTotalTeacher;

        param[9] = new SqlParameter("@TrainingType", SqlDbType.VarChar, 200);
        param[9].Value = obj.TrainingType;

        param[10] = new SqlParameter("@TrainingValue", SqlDbType.Int);
        param[10].Value = obj.TrainingValue;

        param[11] = new SqlParameter("@Category_ID", SqlDbType.Int);
        param[11].Value = obj.Category_ID;

        param[12] = new SqlParameter("@Category_Name", SqlDbType.VarChar, 200);
        param[12].Value = obj.Category_Name; 
        param[13] = new SqlParameter("@SubCategory_ID", SqlDbType.Int);
        param[13].Value = obj.SubCategory_ID; 
        param[14] = new SqlParameter("@SubCategory_Name", SqlDbType.VarChar, 200);
        param[14].Value = obj.SubCategory_Name;

        param[15] = new SqlParameter("@Level", SqlDbType.VarChar, 250);
        param[15].Value = obj.Level;

        param[16] = new SqlParameter("@PreferredModeOfTraining", SqlDbType.VarChar, 200);
        param[16].Value = obj.PreferredModeOfTraining; 

        param[17] = new SqlParameter("@SIQAReportPath", SqlDbType.VarChar, 1250);
        param[17].Value = obj.SIQAReportPath; 
        
        param[18] = new SqlParameter("@PreferredDateTime", SqlDbType.DateTime);
        param[18].Value = obj.PreferredDateTime;
        
        param[19] = new SqlParameter("@ExpectedTrainees", SqlDbType.Int);
        param[19].Value = obj.ExpectedTrainees;

        param[20] = new SqlParameter("@UserID", SqlDbType.Int);
        param[20].Value = obj.UserID;

        param[21] = new SqlParameter("@KeyStagesName", SqlDbType.VarChar,500);
        param[21].Value = obj.KeyStagesName;

        param[22] = new SqlParameter("@TeacherName", SqlDbType.VarChar, 4000);
        param[22].Value = obj.TeacherName;

        param[23] = new SqlParameter("@TeacherERPNumber", SqlDbType.VarChar, 4000);
        param[23].Value = obj.TeacherERPNumber;

        param[24] = new SqlParameter("@ConfirmedTraineesCount", SqlDbType.Int);
        param[24].Value = obj.ConfirmedTraineesCount;

        param[25] = new SqlParameter("@SIQAReportName", SqlDbType.VarChar, 500);
        param[25].Value = obj.SIQAReportName;
        param[26] = new SqlParameter("@AssignedTrainer", SqlDbType.Int);
        param[26].Value = obj.AssignedTrainer;
        param[27] = new SqlParameter("@AssignedTrainerName", SqlDbType.VarChar, 500);
        param[27].Value = obj.AssignedTrainerName;
        param[28] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[28].Direction = ParameterDirection.Output;
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TNA_Save", param);
            string message = param[28].Value.ToString(); // Adjust index based on message parameter position
            Console.WriteLine("Stored procedure message: " + message);
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
    public string UpdateTNA(BLLCEPD_TNA obj)
    {        
	   
        SqlParameter[] param = new SqlParameter[30];

        param[0] = new SqlParameter("@Center_Code", SqlDbType.VarChar, 50);
        param[0].Value = obj.Center_Code;

        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = obj.Center_ID;

        param[2] = new SqlParameter("@Center_Name", SqlDbType.VarChar, 200);
        param[2].Value = obj.Center_Name;

        param[3] = new SqlParameter("@Region_ID", SqlDbType.VarChar, 100);
        param[3].Value = obj.Region_ID;

        param[4] = new SqlParameter("@Region_Name", SqlDbType.VarChar, 200);
        param[4].Value = obj.Region_Name;

        param[5] = new SqlParameter("@City", SqlDbType.VarChar, 200);
        param[5].Value = obj.City;

        param[6] = new SqlParameter("@TotalTeacher", SqlDbType.Int);
        param[6].Value = obj.TotalTeachers;

        param[7] = new SqlParameter("@KeyStages", SqlDbType.VarChar, 250);
        param[7].Value = obj.KeyStages;
        
        
        
        param[8] = new SqlParameter("@KSTotalTeacher", SqlDbType.Int);
        param[8].Value = obj.KSTotalTeacher;

        param[9] = new SqlParameter("@TrainingType", SqlDbType.VarChar, 200);
        param[9].Value = obj.TrainingType;

        param[10] = new SqlParameter("@TrainingValue", SqlDbType.Int);
        param[10].Value = obj.TrainingValue;

        param[11] = new SqlParameter("@Category_ID", SqlDbType.Int);
        param[11].Value = obj.Category_ID;

        param[12] = new SqlParameter("@Category_Name", SqlDbType.VarChar, 200);
        param[12].Value = obj.Category_Name; 
        param[13] = new SqlParameter("@SubCategory_ID", SqlDbType.Int);
        param[13].Value = obj.SubCategory_ID; 
        param[14] = new SqlParameter("@SubCategory_Name", SqlDbType.VarChar, 200);
        param[14].Value = obj.SubCategory_Name;

        param[15] = new SqlParameter("@Level", SqlDbType.VarChar, 250);
        param[15].Value = obj.Level;

        param[16] = new SqlParameter("@PreferredModeOfTraining", SqlDbType.VarChar, 200);
        param[16].Value = obj.PreferredModeOfTraining; 

        param[17] = new SqlParameter("@SIQAReportPath", SqlDbType.VarChar, 250);
        param[17].Value = obj.SIQAReportPath; 
        
        param[18] = new SqlParameter("@PreferredDateTime", SqlDbType.DateTime);
        param[18].Value = obj.PreferredDateTime;
        
        param[19] = new SqlParameter("@ExpectedTrainees", SqlDbType.Int);
        param[19].Value = obj.ExpectedTrainees;

        param[20] = new SqlParameter("@UserID", SqlDbType.Int);
        param[20].Value = obj.UserID;

        param[21] = new SqlParameter("@TNAID", SqlDbType.Int);
        param[21].Value = obj.TNA_ID;
        
        param[22] = new SqlParameter("@TeacherName", SqlDbType.VarChar, 4000);
        param[22].Value = obj.TeacherName;

        param[23] = new SqlParameter("@TeacherERPNumber", SqlDbType.VarChar, 4000);
        param[23].Value = obj.TeacherERPNumber;

        param[24] = new SqlParameter("@ConfirmedTraineesCount", SqlDbType.Int);
        param[24].Value = obj.ConfirmedTraineesCount;

        param[25] = new SqlParameter("@SIQAReportName", SqlDbType.VarChar, 500);
        param[25].Value = obj.SIQAReportName;

        param[26] = new SqlParameter("@KeyStagesName", SqlDbType.VarChar, 500);
        param[26].Value = obj.KeyStagesName;

        param[27] = new SqlParameter("@AssignedTrainer", SqlDbType.Int);
        param[27].Value = obj.AssignedTrainer;
        param[28] = new SqlParameter("@AssignedTrainerName", SqlDbType.VarChar, 500);
        param[28].Value = obj.AssignedTrainerName;

        param[29] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[29].Direction = ParameterDirection.Output;
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TNA_Update", param);
            string message = param[29].Value.ToString(); // Adjust index based on message parameter position
            Console.WriteLine("Stored procedure message: " + message);
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
    public string UpdateTNAReason(BLLCEPD_TNA obj)
    {

        SqlParameter[] param = new SqlParameter[3];

       
        param[0] = new SqlParameter("@TNAID", SqlDbType.Int);
        param[0].Value = obj.TNA_ID;
        param[1] = new SqlParameter("@Reason", SqlDbType.VarChar);
        param[1].Value = obj.Reason;
        param[2] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[2].Direction = ParameterDirection.Output;
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TNA_UpdateReason", param);
            string message = param[2].Value.ToString(); // Adjust index based on message parameter position
            Console.WriteLine("Stored procedure message: " + message);
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
    public string UpdateTNAStatus(BLLCEPD_TNA obj)
    {

        SqlParameter[] param = new SqlParameter[4];       

        param[0] = new SqlParameter("@UserID", SqlDbType.Int);
        param[0].Value = obj.UserID;
        param[1] = new SqlParameter("@TNAID", SqlDbType.Int);
        param[1].Value = obj.TNA_ID;
        param[2] = new SqlParameter("@Status", SqlDbType.VarChar);
        param[2].Value = obj.Status;
        param[3] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[3].Direction = ParameterDirection.Output;
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TNA_UpdateStatus", param);
            string message = param[3].Value.ToString(); // Adjust index based on message parameter position
            Console.WriteLine("Stored procedure message: " + message);
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
    public string DeleteTrainerProfile(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Id", SqlDbType.Int);
        param[0].Value = id;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TrainerProfile_Delete", param);
            string message = param[1].Value.ToString(); // Adjust index based on message parameter position
            Console.WriteLine("Stored procedure message: " + message);
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public DataTable GetTNAList(BLLCEPD_TNA obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[0].Value = obj.Region_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = obj.Center_ID;
        param[2] = new SqlParameter("@Status", SqlDbType.VarChar);
        param[2].Value = obj.Status;
        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TNA_GET", param);          
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }  
    public DataTable GetTNAList_ByID(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@TNAID", SqlDbType.Int);
        param[0].Value = id;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TNA_GETBYID", param);
           
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
}
