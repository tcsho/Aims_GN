using System;
using System.Data;

/// <summary>
/// Summary description for BLLLmsAppObjectServices
/// </summary>



public class BLLLmsAppObjectServices
    {
    public BLLLmsAppObjectServices()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALLmsAppObjectServices objdal = new _DALLmsAppObjectServices();

    private int objectServices_ID;
    private int pageObject_ID;
    private string user_Type_ID;
    private bool isallow;
    private int partType_ID;
    //private string pagename;


    #region 'Start Properties Declaration'

    public int ObjectServices_ID { get { return objectServices_ID; } set { objectServices_ID = value; } }
    public int PageObject_ID { get { return pageObject_ID; } set { pageObject_ID = value; } }
    public string User_Type_ID { get { return user_Type_ID; } set { user_Type_ID = value; } }
    public bool isAllow { get { return isallow; } set { isallow = value; } }
    public int PartType_ID { get { return partType_ID; } set { partType_ID = value; } }
    //public string PageName { get { return pagename; } set { pagename = value; } }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsAppObjectServicesAdd(BLLLmsAppObjectServices _obj)
        {
        return objdal.LmsAppObjectServicesAdd(_obj);
        }
    public int LmsAppObjectServicesUpdate(BLLLmsAppObjectServices _obj)
        {
        return objdal.LmsAppObjectServicesUpdate(_obj);
        }
    public int LmsAppObjectServicesDelete(BLLLmsAppObjectServices _obj)
        {
        return objdal.LmsAppObjectServicesDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsAppObjectServicesFetch(BLLLmsAppObjectServices _obj)
        {
        return objdal.LmsAppObjectServicesSelect(_obj);
        }

    public DataTable LmsAppObjectServicesFetch(string _PageName, int _PartType)
      {
        return objdal.LmsAppObjectServicesSelect(_PageName,_PartType);
      }
    public int LmsAppObjectServicesFetchField(int _Id)
        {
        return objdal.LmsAppObjectServicesSelectField(_Id);
        }


    #endregion

    }
