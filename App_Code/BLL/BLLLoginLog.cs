using System;
using System.Data;


/// <summary>
/// Summary description for BLLLoginLog
/// </summary>



public class BLLLoginLog
    {
    public BLLLoginLog()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALLoginLog objdal = new _DALLoginLog();



    #region 'Start Properties Declaration'

    private int login_Id;
    private string user_Name;
    private string password;
    private DateTime createdOn;
    private bool isSuccess;
    private int mO_Id;
    private string ip_Add;



    public int Login_Id { get { return login_Id; } set { login_Id = value; } }
    public string User_Name { get { return user_Name; } set { user_Name = value; } }
    public string Password { get { return password; } set { password = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public bool IsSuccess { get { return isSuccess; } set { isSuccess = value; } }
    public int MO_Id { get { return mO_Id; } set { mO_Id = value; } }
    public string IP_Add { get { return ip_Add; } set { ip_Add = value; } }

    #endregion

    #region 'Start Executaion Methods'

    public int LoginLogAdd(BLLLoginLog _obj)
        {
        return objdal.LoginLogAdd(_obj);
        }
    public int LoginLogUpdate(BLLLoginLog _obj)
        {
        return objdal.LoginLogUpdate(_obj);
        }
    public int LoginLogDelete(BLLLoginLog _obj)
        {
        return objdal.LoginLogDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LoginLogFetch(BLLLoginLog _obj)
        {
        return objdal.LoginLogSelect(_obj);
        }

    public DataTable LoginLogFetch(int _id)
      {
        return objdal.LoginLogSelect(_id);
      }
    public int LoginLogFetchField(int _Id)
        {
        return objdal.LoginLogSelectField(_Id);
        }


    #endregion

    }
