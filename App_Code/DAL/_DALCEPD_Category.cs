using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;



/// <summary>
/// Summary description for _DALStudent_Conditionally_Promoted_Request
/// </summary>
public class _DALCEPD_Category
{
    DALBase dalobj = new DALBase();


    public _DALCEPD_Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string SaveOrUpdateCategory(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@category_id", SqlDbType.Int);
        param[0].Value = objbll.CategoryId;

        param[1] = new SqlParameter("@category_name", SqlDbType.VarChar, 255);
        param[1].Value = objbll.CategoryName;

        param[2] = new SqlParameter("@created_on", SqlDbType.DateTime);
        param[2].Value = objbll.CreatedOn;

        param[3] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
        param[3].Value = objbll.CreatedBy;

        param[4] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[4].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("SP_CEPD_Category", param);
            string message = param[4].Value.ToString();
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

    public string SaveOrUpdateSubcategory(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@subcategory_id", SqlDbType.Int);
        param[0].Value = objbll.SubcategoryId;

        param[1] = new SqlParameter("@subcategory_name", SqlDbType.VarChar, 255);
        param[1].Value = objbll.SubcategoryName;

        param[2] = new SqlParameter("@category_id", SqlDbType.Int);
        param[2].Value = objbll.CategoryId;

        param[3] = new SqlParameter("@created_on", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;

        param[4] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
        param[4].Value = objbll.CreatedBy;

        param[5] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[5].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("SP_CEPD_SubCategory", param);
            string message = param[5].Value.ToString();
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

    public DataTable GetCategory(BLLCEPD_Category objbll)
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
    public DataTable GetSubCategory_Get()
    {
        SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@category_id", SqlDbType.Int);
        //param[0].Value = categoryId;

        param[0] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[0].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_SubCategory_Get", param);
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
    public DataTable GetSubCategory_GetByCategoryID(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@category_id", SqlDbType.Int);
        param[0].Value = objbll.CategoryId;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_SubCategory_byCetagory", param);
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

    public String DeleteCategory(string CategoryId)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@category_id", SqlDbType.Int);
        param[0].Value = CategoryId;

        param[1] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[1].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_Category_Delete", param);
            string message = param[0].Value.ToString();
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
    public String DeleteSubCategory(string SubCategoryId)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Subcategory_id", SqlDbType.Int);
        param[0].Value = SubCategoryId;

        param[1] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[1].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_SubCategory_Delete", param);
            string message = param[0].Value.ToString();
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
    public string SaveUpdateQualification(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = objbll.Qualif_id;

        param[1] = new SqlParameter("@Qualification", SqlDbType.VarChar, 255);
        param[1].Value = objbll.Qualification;

        param[2] = new SqlParameter("@created_on", SqlDbType.DateTime);
        param[2].Value = objbll.CreatedOn;

        param[3] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
        param[3].Value = objbll.CreatedBy;

        param[4] = new SqlParameter("@category", SqlDbType.VarChar, 255);
        param[4].Value = objbll.Category;

        param[5] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[5].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("Sp_CEPD_Prof_Qualification", param);
            string message = param[5].Value.ToString();
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
    public DataTable GetQualification(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@category_type", SqlDbType.VarChar,255);
        param[0].Value = objbll.Category;

        //param[1] = new SqlParameter("@message", SqlDbType.VarChar, 255);
       // param[1].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_Prof_Qualification_Get", param);
           // string message = param[1].Value.ToString();
           // Console.WriteLine("Stored procedure message: " + message);
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
    public String DeleteQualification(string Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = Id;

        param[1] = new SqlParameter("@message", SqlDbType.VarChar, 255);
        param[1].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("SP_CEPD_Prof_Qualification_Delete", param);
            string message = param[0].Value.ToString();
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



    // For CEPD_TrainingVideoUploader.aspx
    public string TrainingVideoUploade_Save(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[6];



        param[0] = new SqlParameter("@Training", SqlDbType.VarChar, 225);
        param[0].Value = objbll.TrainingName;

        param[1] = new SqlParameter("@Description", SqlDbType.VarChar, 225);
        param[1].Value = objbll.Description;

        param[2] = new SqlParameter("@Path", SqlDbType.VarChar, 500);
        param[2].Value = objbll.path;  
        param[3] = new SqlParameter("@StopTime", SqlDbType.VarChar, 500);
        param[3].Value = objbll.StopTime;

        param[4] = new SqlParameter("@Link", SqlDbType.VarChar, 500);
        param[4].Value = objbll.Link;

        param[5] = new SqlParameter("@ID", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("CEPD_TrainingVideo_Insert", param);
            string message = param[5].Value.ToString();
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


    public DataTable TrainingQuestions_Get()
    {
        SqlParameter[] param = new SqlParameter[0];

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainingQuestions_Get");

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
    public DataTable TrainingVideoUploade_Get()
    {
        SqlParameter[] param = new SqlParameter[0];

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainingVideo_Get");

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
    public DataTable TrainingQues_Get()
    {
        SqlParameter[] param = new SqlParameter[0];

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainingQuestions_Get");

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
    public string TrainingVideoQuestions_Save(BLLCEPD_Category objbll)
    {
        SqlParameter[] param = new SqlParameter[8];



        param[0] = new SqlParameter("@Question", SqlDbType.VarChar, 225);
        param[0].Value = objbll.Question;

        param[1] = new SqlParameter("@OptionD", SqlDbType.VarChar, 225);
        param[1].Value = objbll.OptionD;

        param[2] = new SqlParameter("@OptionC", SqlDbType.VarChar, 500);
        param[2].Value = objbll.OptionC;

        param[3] = new SqlParameter("@OptionB", SqlDbType.VarChar, 500);
        param[3].Value = objbll.OptionB;
        param[4] = new SqlParameter("@OptionA", SqlDbType.VarChar, 500);
        param[4].Value = objbll.OptionA;
        param[5] = new SqlParameter("@CorrectAnswer", SqlDbType.VarChar, 500);
        param[5].Value = objbll.CorrectAnswer;

        param[6] = new SqlParameter("@TrainingID", SqlDbType.Int);
        param[6].Value = objbll.TrainingID;
        param[7] = new SqlParameter("@ID", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("TrainingQuestions_Insert", param);
            string message = param[7].Value.ToString();
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

    public DataTable TrainingQuestions_GetByID(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = id;

        

        try
        {
            dalobj.OpenConnection();
            DataTable dt = dalobj.sqlcmdFetch("CEPD_TrainingQuestions_GetBYID", param);
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
