using System;
using System.Data;


/// <summary>
/// Summary description for BLLUser
/// </summary>



public class BLLUser
{
    public BLLUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALUsers objdal = new DALUsers();



    #region 'Start Properties Declaration'

    public bool isSuperUser { get; set; }
    public string moID { get; set; }
    public int userTypeID { get; set; }
    public string usrName { get; set; }
    public string password { get; set; }
    public string fName { get; set; }
    public string mName { get; set; }
    public string lName { get; set; }
    public int genderID { get; set; }
    public string birthDay { get; set; }
    public string eMail { get; set; }
    public string hPhone { get; set; }
    public string mPhone { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
    public int groupID { get; set; }
    public int MOrgID { get; set; }
    public string countryID { get; set; }
    public int regionID { get; set; }
    public int centerID { get; set; }
    public int gradeID { get; set; }
    //public int nAlreadyIn{ get; set; }
    public int lib_ID { get; set; }
    public int cluster_Id { get; set; }
    public int cluster_id { get; set; }
    public int ID { get; set; }
    public int warehouse_ID { get; set; }
    public int nAlreadyIn { get; set; }
    public int Employee_Id { get; set; }
    public int User_Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
   
    #endregion

    #region 'Start Executaion Methods'

    public int Add(BLLUser _obj)
    {
        return objdal.Add(_obj);
    }
    public int User_Add(BLLUser _obj)
    {
        return objdal.BLLUser_Add(_obj);
    }
    public void Update(BLLUser _obj)
    {
        objdal.Update(_obj);
    }

    public int ChangePassword(BLLUser _obj)
    {
        return objdal.ChangePassword(_obj);
    }
    public void Delete(int _obj)
    {
        objdal.Delete(_obj);

    }

    public int BLUser_SharedLoginAdd(BLLUser _obj)
    {
        return objdal.BLUser_SharedLoginAdd(_obj);
    }
    #endregion
    #region 'Start Fetch Methods'


    public DataSet get_Users(BLLUser _obj)
    {
        return objdal.get_Users(_obj);
    }

    public DataSet GetUsersByUserTypeID(BLLUser _obj)
    {
        return objdal.GetUsersByUserTypeID(_obj);
    }

    public DataTable UserSelectByUserName(BLLUser obj)
    {

        return UserSelectByUserName(obj);
    }
    public DataTable StatSelectByUserId(BLLUser obj)
    {

        return objdal.StatSelectByUserId(obj);
    }

    public DataTable UserFetchAll()
    {

        return objdal.UserSelectAll();
    }
    public DataTable UserTypeFetchAll()
    {

        return objdal.UserTypeSelectAll();
    }

    #endregion

}
