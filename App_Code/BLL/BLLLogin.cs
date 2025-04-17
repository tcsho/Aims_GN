using System;
using System.Data;


/// <summary>
/// Summary description for BLLLogin
/// </summary>



public class BLLLogin
    {
    public BLLLogin()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALLogin objdal = new _DALLogin();







    #region 'Start Properties Declaration'



    private int user_Id;
    private int user_Type_Id;
    private string first_Name;
    private string middle_Name;
    private string last_Name;
    private DateTime date_Of_Birth;
    private string address;
    private string home_Phone;
    private string mobile_Phone;
    private string email;
    private string state;
    private string postal_Code;
    private string city;
    private string country;
    private string user_Name;
    private string password;
    private int main_Organisation_Id;
    private int gender_Id;
    private int center_Id;
    private int region_Id;
    private int status_Id;
    private int grade_id;
    private string newPassword;
    private DateTime lastPasswordChangedOn;
    


    public int User_Id { get { return user_Id; } set { user_Id = value; } }
    public int User_Type_Id { get { return user_Type_Id; } set { user_Type_Id = value; } }
    public string First_Name { get { return first_Name; } set { first_Name = value; } }
    public string Middle_Name { get { return middle_Name; } set { middle_Name = value; } }
    public string Last_Name { get { return last_Name; } set { last_Name = value; } }
    public DateTime Date_Of_Birth { get { return date_Of_Birth; } set { date_Of_Birth = value; } }
    public string Address { get { return address; } set { address = value; } }
    public string Home_Phone { get { return home_Phone; } set { home_Phone = value; } }
    public string Mobile_Phone { get { return mobile_Phone; } set { mobile_Phone = value; } }
    public string Email { get { return email; } set { email = value; } }
    public string State { get { return state; } set { state = value; } }
    public string Postal_Code { get { return postal_Code; } set { postal_Code = value; } }
    public string City { get { return city; } set { city = value; } }
    public string Country { get { return country; } set { country = value; } }
    public string User_Name { get { return user_Name; } set { user_Name = value; } }
    public string Password { get { return password; } set { password = value; } }
    public int Main_Organisation_Id { get { return main_Organisation_Id; } set { main_Organisation_Id = value; } }
    public int Gender_Id { get { return gender_Id; } set { gender_Id = value; } }
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }
    public int Region_Id { get { return region_Id; } set { region_Id = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public int Grade_id { get { return grade_id; } set { grade_id = value; } }
    public string NewPassword { get { return newPassword; } set { newPassword = value; } }
    public DateTime LastPasswordChangedOn { get { return lastPasswordChangedOn; } set { lastPasswordChangedOn = value; } }



    #endregion

    #region 'Start Executaion Methods'

    public int LoginAddUser(BLLLogin _obj)
        {
        return objdal.LoginAddUser(_obj);
        }
    public int LoginUpdateUser(BLLLogin _obj)
        {
        return objdal.LoginUpdateUser(_obj);
        }
    public int LoginUpdateParent(BLLLogin _obj)
        {
        return objdal.LoginUpdateParent(_obj);
        }
    public int LoginDelete(BLLLogin _obj)
        {
        return objdal.LoginDelete(_obj);

        }

    public int LoginDeleteUserInfo(BLLLogin _obj)
        {
        return objdal.LoginDeleteUserInfo(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LoginFetchAuthenticateUser(BLLLogin _obj)
        {
        return objdal.LoginSelectAuthenticateUser(_obj);
        }

    public DataTable LoginFetchAuthenticateSuperAdmin(BLLLogin _obj)
        {
        return objdal.LoginSelectAuthenticateSuperAdmin(_obj);
        }

    public DataTable LoginFetchAuthenticateUserWithOrganisation(BLLLogin _obj)
        {
        return objdal.LoginSelectAuthenticateUserWithOrganisation(_obj);
        }

    public DataTable LoginFetchGet_HPI_SuperAdmin(int _Id)
        {
        return objdal.LoginSelectGet_HPI_SuperAdmin(_Id);
        }

    public DataTable LoginFetchGetOnlyUsers()
        {
        return objdal.LoginSelectGetOnlyUsers();
        }

    public DataTable LoginFetchGetUsersForAdmin(int _Id)
        {
        return objdal.LoginSelectGetUsersForAdmin(_Id);
        }

    public DataTable LoginFetchGetUsersForSuperAdmin()
        {
        return objdal.LoginSelectGetUsersForSuperAdmin();
        }



    public DataTable LoginFetchHomePageStatics_Admin(int _Id)
        {
        return objdal.LoginSelectHomePageStatics_Admin(_Id);
        }
    public DataTable LoginFetchHomePageStatics_CO(int _Id)
        {
        return objdal.LoginSelectHomePageStatics_CO(_Id);
        }
    public DataTable LoginFetchHomePageStatics_RO(int _Id)
        {
        return objdal.LoginSelectHomePageStatics_RO(_Id);
        }

        public int UpdatePasswordPolicy(BLLLogin objbll)
        {
        return objdal.UpdatePasswordPolicy(objbll);
        }
    public int LoginReset(BLLLogin objbll)
        {
        return objdal.LoginReset(objbll);
        }
    public DataTable LoginFetchUserByID(BLLLogin _obj)
        {
        return objdal.LoginSelectUserByID(_obj);
        }

    public DataTable LoginFetchUserByCenterUserTypeID(BLLLogin _obj)
        {
        return objdal.LoginSelectUserByCenterUserTypeID(_obj);
        }

    #endregion

    }
