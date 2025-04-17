using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class _DALCEPD_TrainerProfile
{
    DALBase dalobj = new DALBase();

    public _DALCEPD_TrainerProfile()
    {
        // Constructor logic
    }

    public string SaveOrUpdateTrainerProfile(BLLCEPD_TrainerProfile obj)
    {
        SqlParameter[] param = new SqlParameter[16];

        param[0] = new SqlParameter("@Id", SqlDbType.Int);
        param[0].Value = obj.Id;

        param[1] = new SqlParameter("@ERPNumber", SqlDbType.VarChar, 50);
        param[1].Value = obj.ERPNumber;

        param[2] = new SqlParameter("@TrainerName", SqlDbType.VarChar, 100);
        param[2].Value = obj.TrainerName;

        param[3] = new SqlParameter("@Designation", SqlDbType.VarChar, 100);
        param[3].Value = obj.Designation;

        param[4] = new SqlParameter("@Branch", SqlDbType.VarChar, 100);
        param[4].Value = obj.Branch;

        param[5] = new SqlParameter("@Expertise", SqlDbType.VarChar, 100);
        param[5].Value = obj.Expertise;

        param[6] = new SqlParameter("@ExperienceTCS", SqlDbType.VarChar, 50);
        param[6].Value = obj.ExperienceTCS;

        param[7] = new SqlParameter("@ExperienceOutsideTCS", SqlDbType.VarChar, 50);
        param[7].Value = obj.ExperienceOutsideTCS;

        param[8] = new SqlParameter("@AcademicQualification", SqlDbType.Text);
        param[8].Value = obj.AcademicQualification;

        param[9] = new SqlParameter("@ProfessionalQualificationTCS", SqlDbType.Text);
        param[9].Value = obj.ProfessionalQualificationTCS;

        param[10] = new SqlParameter("@ProfessionalQualificationOutsideTCS", SqlDbType.Text);
        param[10].Value = obj.ProfessionalQualificationOutsideTCS;

        param[11] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[11].Value = obj.CreatedOn;

        param[12] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[12].Value = obj.CreatedBy; 
        param[13] = new SqlParameter("@Trainings", SqlDbType.Text);
        param[13].Value = obj.Trainings; 
        param[14] = new SqlParameter("@Training_Name", SqlDbType.Text);
        param[14].Value = obj.Training_Name;
        param[15] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[15].Direction = ParameterDirection.Output;
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TrainerProfile_Save_Update", param);
            string message = param[15].Value.ToString(); // Adjust index based on message parameter position
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

    public DataTable GetTrainerProfile()
    {
        //SqlParameter[] param = new SqlParameter[0];

        //param[0] = new SqlParameter("@Id", SqlDbType.Int);
        //param[0].Value = id;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainerProfile_Get");
           // string message = param[1].Value.ToString(); // Adjust index based on message parameter position
            //Console.WriteLine("Stored procedure message: " + message);
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
    public DataTable GetTrainerProfile_ByID(string id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Id", SqlDbType.Int);
        param[0].Value = id;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainerProfile_GetbyID", param);
           //string message = param[1].Value.ToString(); // Adjust index based on message parameter position
            //Console.WriteLine("Stored procedure message: " + message);
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
  public DataTable SelectTrainings()
    {
        SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@category_id", SqlDbType.Int);
        //param[0].Value = categoryId;

        param[0] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[0].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_Category_Get", param);
            string message = param[0].Value.ToString();
            Console.WriteLine("Stored procedure message: " + message);
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
    public DataTable GetERPProfile(int Employee_Number)
    {
        DataTable dt = new DataTable();

        // Use the connection string from the configuration file
        string connectionString = ConfigurationManager.ConnectionStrings["ERPDB"].ConnectionString;

        // Use a using statement to ensure proper disposal of resources
        using (OracleConnection cnx = new OracleConnection(connectionString))
        {
            // Define your Oracle query with the parameter concatenated
            string query = "SELECT * FROM apps.vw_tcs_erp_staff_training WHERE \"Employee_Number\" = " + Employee_Number;

            // Create Oracle command with the query and connection
            OracleCommand command = new OracleCommand(query, cnx);

            try
            {
                cnx.Open();

                // Execute the query and fill the DataTable
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw ex;
            }
        }

        return dt;
    }

    public DataTable GetTNA_Detils(string code)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@code", SqlDbType.VarChar);
        param[0].Value = code;



        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TNA_User_Get", param);
            string message = param[0].Value.ToString();
            Console.WriteLine("Stored procedure message: " + message);
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
    public DataTable GetTNA_KeyStages()
    {
        
        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TNA_KeyStages");
            
            //Console.WriteLine("Stored procedure message: " + message);
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
    public DataTable GetTNA_KeyStages_emplyoeecount(string Centerid, string group)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.VarChar);
        param[0].Value = Centerid;

        param[1] = new SqlParameter("@Group_ID", SqlDbType.VarChar);
        param[1].Value = group;


        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TNA_Employee_GET", param);
            
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
