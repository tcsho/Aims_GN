using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALLogin
/// </summary>
public class _DALLogin
{
    DALBase dalobj = new DALBase();


    public _DALLogin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LoginAddUser(BLLLogin objbll)
    {
        SqlParameter[] param = new SqlParameter[21];


        param[0] = new SqlParameter("@groupID", SqlDbType.Int); param[0].Value = objbll.User_Type_Id;
        param[1] = new SqlParameter("@fName", SqlDbType.NVarChar); param[1].Value = objbll.First_Name;
        param[2] = new SqlParameter("@mName", SqlDbType.NVarChar); param[2].Value = objbll.Middle_Name;
        param[3] = new SqlParameter("@lName", SqlDbType.NVarChar); param[3].Value = objbll.Last_Name;
        param[4] = new SqlParameter("@birthDay", SqlDbType.DateTime); param[4].Value = objbll.Date_Of_Birth;
        param[5] = new SqlParameter("@address", SqlDbType.NVarChar); param[5].Value = objbll.Address;
        param[6] = new SqlParameter("@hPhone", SqlDbType.NVarChar); param[6].Value = objbll.Home_Phone;
        param[7] = new SqlParameter("@mPhone", SqlDbType.NVarChar); param[7].Value = objbll.Mobile_Phone;
        param[8] = new SqlParameter("@eMail", SqlDbType.NVarChar); param[8].Value = objbll.Email;
        param[9] = new SqlParameter("@state", SqlDbType.NVarChar); param[9].Value = objbll.State;
        param[10] = new SqlParameter("@postalCode", SqlDbType.NVarChar); param[10].Value = objbll.Postal_Code;
        param[11] = new SqlParameter("@city", SqlDbType.NVarChar); param[11].Value = objbll.City;
        param[12] = new SqlParameter("@countryID", SqlDbType.NVarChar); param[12].Value = objbll.Country;
        param[13] = new SqlParameter("@usrName", SqlDbType.NVarChar); param[13].Value = objbll.User_Name;
        param[14] = new SqlParameter("@password", SqlDbType.NVarChar); param[14].Value = objbll.Password;
        param[15] = new SqlParameter("@MOrgID", SqlDbType.Int); param[15].Value = objbll.Main_Organisation_Id;
        param[16] = new SqlParameter("@genderID", SqlDbType.Int); param[16].Value = objbll.Gender_Id;
        param[17] = new SqlParameter("@centerID", SqlDbType.Int); param[17].Value = objbll.Center_Id;
        param[18] = new SqlParameter("@regionID", SqlDbType.Int); param[18].Value = objbll.Region_Id;
        param[19] = new SqlParameter("@gradeID", SqlDbType.Int); param[19].Value = objbll.Status_Id;
//        param[21] = new SqlParameter("@NewPassword", SqlDbType.NVarChar); param[21].Value = objbll.NewPassword;


        param[20] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[20].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AddUser", param);
        int k = (int)param[20].Value;
        return k;

    }
    public int LoginUpdateUser(BLLLogin objbll)
    {
        SqlParameter[] param = new SqlParameter[21];

        param[0] = new SqlParameter("@groupID", SqlDbType.Int); param[0].Value = objbll.User_Type_Id;
        param[1] = new SqlParameter("@fName", SqlDbType.NVarChar); param[1].Value = objbll.First_Name;
        param[2] = new SqlParameter("@mName", SqlDbType.NVarChar); param[2].Value = objbll.Middle_Name;
        param[3] = new SqlParameter("@lName", SqlDbType.NVarChar); param[3].Value = objbll.Last_Name;
        param[4] = new SqlParameter("@birthDay", SqlDbType.DateTime); param[4].Value = objbll.Date_Of_Birth;
        param[5] = new SqlParameter("@address", SqlDbType.NVarChar); param[5].Value = objbll.Address;
        param[6] = new SqlParameter("@hPhone", SqlDbType.NVarChar); param[6].Value = objbll.Home_Phone;
        param[7] = new SqlParameter("@mPhone", SqlDbType.NVarChar); param[7].Value = objbll.Mobile_Phone;
        param[8] = new SqlParameter("@eMail", SqlDbType.NVarChar); param[8].Value = objbll.Email;
        param[9] = new SqlParameter("@state", SqlDbType.NVarChar); param[9].Value = objbll.State;
        param[10] = new SqlParameter("@postalCode", SqlDbType.NVarChar); param[10].Value = objbll.Postal_Code;
        param[11] = new SqlParameter("@city", SqlDbType.NVarChar); param[11].Value = objbll.City;
        param[12] = new SqlParameter("@countryID", SqlDbType.NVarChar); param[12].Value = objbll.Country;
        param[13] = new SqlParameter("@usrName", SqlDbType.NVarChar); param[13].Value = objbll.User_Name;
        param[14] = new SqlParameter("@password", SqlDbType.NVarChar); param[14].Value = objbll.Password;
        param[15] = new SqlParameter("@MOrgID", SqlDbType.Int); param[15].Value = objbll.Main_Organisation_Id;
        param[16] = new SqlParameter("@genderID", SqlDbType.Int); param[16].Value = objbll.Gender_Id;
        param[17] = new SqlParameter("@centerID", SqlDbType.Int); param[17].Value = objbll.Center_Id;
        param[18] = new SqlParameter("@regionID", SqlDbType.Int); param[18].Value = objbll.Region_Id;
        param[19] = new SqlParameter("@gradeID", SqlDbType.Int); param[19].Value = objbll.Status_Id;
        param[20] = new SqlParameter("@ID", SqlDbType.Int); param[20].Value = objbll.User_Id;

        //param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //param[9].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("UpdateUser", param);
        //int k = (int)param[20].Value;
        return k;
    }
    public int LoginUpdateParent(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[21];

        param[0] = new SqlParameter("@groupID", SqlDbType.Int); param[0].Value = objbll.User_Type_Id;
        param[1] = new SqlParameter("@fName", SqlDbType.NVarChar); param[1].Value = objbll.First_Name;
        param[2] = new SqlParameter("@mName", SqlDbType.NVarChar); param[2].Value = objbll.Middle_Name;
        param[3] = new SqlParameter("@lName", SqlDbType.NVarChar); param[3].Value = objbll.Last_Name;
        param[4] = new SqlParameter("@birthDay", SqlDbType.DateTime); param[4].Value = objbll.Date_Of_Birth;
        param[5] = new SqlParameter("@address", SqlDbType.NVarChar); param[5].Value = objbll.Address;
        param[6] = new SqlParameter("@hPhone", SqlDbType.NVarChar); param[6].Value = objbll.Home_Phone;
        param[7] = new SqlParameter("@mPhone", SqlDbType.NVarChar); param[7].Value = objbll.Mobile_Phone;
        param[8] = new SqlParameter("@eMail", SqlDbType.NVarChar); param[8].Value = objbll.Email;
        param[9] = new SqlParameter("@state", SqlDbType.NVarChar); param[9].Value = objbll.State;
        param[10] = new SqlParameter("@postalCode", SqlDbType.NVarChar); param[10].Value = objbll.Postal_Code;
        param[11] = new SqlParameter("@city", SqlDbType.NVarChar); param[11].Value = objbll.City;
        param[12] = new SqlParameter("@countryID", SqlDbType.NVarChar); param[12].Value = objbll.Country;
        param[13] = new SqlParameter("@usrName", SqlDbType.NVarChar); param[13].Value = objbll.User_Name;
        param[14] = new SqlParameter("@password", SqlDbType.NVarChar); param[14].Value = objbll.Password;
        param[15] = new SqlParameter("@MOrgID", SqlDbType.Int); param[15].Value = objbll.Main_Organisation_Id;
        param[16] = new SqlParameter("@genderID", SqlDbType.Int); param[16].Value = objbll.Gender_Id;
        param[17] = new SqlParameter("@centerID", SqlDbType.Int); param[17].Value = objbll.Center_Id;
        param[18] = new SqlParameter("@regionID", SqlDbType.Int); param[18].Value = objbll.Region_Id;
        param[19] = new SqlParameter("@gradeID", SqlDbType.Int); param[19].Value = objbll.Status_Id;
        param[20] = new SqlParameter("@ID", SqlDbType.Int); param[20].Value = objbll.User_Id;

        //param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //param[9].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("updateParent", param);
        //int k = (int)param[20].Value;
        return k;
        }
    public int LoginDelete(BLLLogin objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = objbll.User_Id;


        int k = dalobj.sqlcmdExecute("DeleteUser", param);

        return k;
    }
    public int LoginDeleteUserInfo(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Original_User_Id", SqlDbType.Int);
        param[0].Value = objbll.User_Id;


        int k = dalobj.sqlcmdExecute("DeleteUserInfo", param);

        return k;
        }
    #endregion

    #region 'Start of Fetch Methods'


    public DataTable LoginSelectAuthenticateUser(BLLLogin objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar);
    param[0].Value = objbll.User_Name;

    param[1] = new SqlParameter("@password", SqlDbType.NVarChar);
    param[1].Value = objbll.Password;

    param[2] = new SqlParameter("@organisation_Id", SqlDbType.NVarChar);
    param[2].Value = Convert.ToString(objbll.Main_Organisation_Id);

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        //_dt = dalobj.sqlcmdFetch("AuthenticateUser", param); 
        //Updated 23-Jan-2013
        _dt = dalobj.sqlcmdFetch("AuthenticateUserWithOrganisation",param);

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


    public DataTable LoginSelectAuthenticateSuperAdmin(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar);
        param[0].Value = objbll.User_Name;

        param[1] = new SqlParameter("@password", SqlDbType.NVarChar);
        param[1].Value = objbll.Password;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AuthenticateSuperAdmin", param);
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

    
    public DataTable LoginSelectAuthenticateUserWithOrganisation(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar);
        param[0].Value = objbll.User_Name;

        param[1] = new SqlParameter("@password", SqlDbType.NVarChar);
        param[1].Value = objbll.Password;

        param[2] = new SqlParameter("@organisation_Id", SqlDbType.NVarChar);
        param[2].Value = Convert.ToString(objbll.Main_Organisation_Id);

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AuthenticateUserWithOrganisation", param);
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


    public DataTable LoginSelectGet_HPI_SuperAdmin(int _id)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@userId", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_HPI_SuperAdmin", param);
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


    public DataTable LoginSelectGetOnlyUsers()
        {

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetOnlyUsers");
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


    public DataTable LoginSelectGetUsersForAdmin(int _id)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@sp_mo_id", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetUsersForAdmin", param);
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


    public DataTable LoginSelectGetUsersForSuperAdmin()
        {

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetUsersForSuperAdmin");
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





    public DataTable LoginSelectHomePageStatics_Admin(int _id)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@userId", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HomePageStatics_Admin", param);
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


    public DataTable LoginSelectHomePageStatics_CO(int _id)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@UserId", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HomePageStatics_CO", param);
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


    public DataTable LoginSelectHomePageStatics_RO(int _id)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@UserId", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HomePageStatics_RO", param);
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

    public int UpdatePasswordPolicy(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int); param[0].Value = objbll.User_Id;
        param[1] = new SqlParameter("@Password", SqlDbType.NVarChar); param[1].Value = objbll.Password;
        param[2] = new SqlParameter("@LastPasswordChangedOn", SqlDbType.DateTime); param[2].Value = objbll.LastPasswordChangedOn;



        int k = dalobj.sqlcmdExecute("UpdatePasswordPolicy", param);

        return k;

        
        }

    public int LoginReset(BLLLogin objbll)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Id", SqlDbType.Int); param[0].Value = objbll.User_Id;
            int k = dalobj.sqlcmdExecute("UserPasswordResetByUser_Id", param);
            return k;
        }

   public DataTable LoginSelectUserByID(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int); param[0].Value = objbll.User_Id;

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetUserById", param);
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


   public DataTable LoginSelectUserByCenterUserTypeID(BLLLogin objbll)
        {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); 
        param[0].Value = objbll.Main_Organisation_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@User_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.User_Type_Id;
        
       DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchUserByCenterUserType_Id", param);
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
