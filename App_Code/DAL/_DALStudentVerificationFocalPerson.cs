using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Results;
using ADG.JQueryExtenders.Impromptu;
using System.Web.ClientServices.Providers;

/// <summary>
/// Summary description for _DALNetworkCenter
/// </summary>
public class _DALStudentVerificationFocalPerson
{
    DALBase dalobj = new DALBase();

	public _DALStudentVerificationFocalPerson()
	{
		//
		// TODO: Add constructor logic here
		//
	}

  

    #region 'Start of Fetch Methods'

    public DataTable StudentVerificationFocalPerson_List(int center,string month_name)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
            param[0].Value = center;

            param[1] = new SqlParameter("@month_name", SqlDbType.VarChar);
            param[1].Value = month_name;
            _dt = dalobj.sqlcmdFetch("Student_Verification_FocalPerson_List", param);
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
    public DataTable StudentVerificationFocalPerson_EmployeeDetails(BLLStudentVerificationFocalPerson objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            SqlParameter[] param = new SqlParameter[4]; // Adjust the number of parameters based on your stored procedure

            param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
            param[0].Value = objbll.Center_Id;
            param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
            param[1].Value = objbll.Region_Id;
            param[2] = new SqlParameter("@employeeCode", SqlDbType.Int);
            param[2].Value = objbll.Employee_Code;

            // OUTPUT parameter for messages
            param[3] = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, -1);
            param[3].Direction = ParameterDirection.Output;

            _dt = dalobj.sqlcmdFetch("Student_Verification_FocalPerson_EmployeeDetails", param);

            // Retrieve the output message
            string outputMessage = param[3].Value.ToString();

            // Display the message (you can use your specific method for displaying messages)
            ImpromptuHelper.ShowPrompt(outputMessage);


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

    public int Student_Verification_FocalPerson_Update(BLLStudentVerificationFocalPerson objbll)
    {
        try
        {
            dalobj.OpenConnection();
            SqlParameter[] param = new SqlParameter[6]; // Adjust the number of parameters based on your stored procedure

            param[0] = new SqlParameter("@Focal_Person_Id", SqlDbType.Int);
            param[0].Value = objbll.Focal_Person_Id;
            param[1] = new SqlParameter("@Employee_Code", SqlDbType.NVarChar, 255); 
            param[1].Value = objbll.Employee_Code;
            param[2] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 255); 
            param[2].Value = objbll.User_Name;
            param[3] = new SqlParameter("@DesigName", SqlDbType.NVarChar, 255);
            param[3].Value = objbll.DesigName;
            param[4] = new SqlParameter("@Email", SqlDbType.NVarChar, 255); 
            param[4].Value = objbll.Email;
            param[5] = new SqlParameter("@Result", SqlDbType.Int); // OUTPUT parameter for result
            param[5].Direction = ParameterDirection.Output;

            dalobj.sqlcmdFetch("Student_Verification_FocalPerson_Update", param);

            int result = Convert.ToInt32(param[5].Value);
            if (result ==1)
            {
                ImpromptuHelper.ShowPrompt("Focal Person Saved Successfully");
            }
            return result;
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