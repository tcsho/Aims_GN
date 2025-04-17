using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Section_Welcome
/// </summary>



public class BLLClass_Section_Welcome
    {
    public BLLClass_Section_Welcome()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALClass_Section_Welcome objdal = new DALClass_Section_Welcome();



    #region 'Start Properties Declaration'
    public int Section_Welcome_Id { get; set; }
    public int Section_Id { get; set; }
    public int Session_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    


    #endregion

    #region 'Start Executaion Methods'

    public int Class_Section_WelcomeAdd(BLLClass_Section_Welcome _obj)
        {
        return objdal.Class_Section_WelcomeAdd(_obj);
        }
    public int Class_Section_WelcomeUpdate(BLLClass_Section_Welcome _obj)
        {
        return objdal.Class_Section_WelcomeUpdate(_obj);
        }
    public int Class_Section_WelcomeDelete(BLLClass_Section_Welcome _obj)
        {
        return objdal.Class_Section_WelcomeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Class_Section_WelcomeFetch(BLLClass_Section_Welcome _obj)
        {
        return objdal.Class_Section_WelcomeSelect(_obj);
        }

    public DataTable Class_Section_WelcomeFetchByStatusID(BLLClass_Section_Welcome _obj)
    {
        return objdal.Class_Section_WelcomeSelectByStatusID(_obj);
    }

    public DataTable Class_Section_WelcomeFetchByBySectionSession(BLLClass_Section_Welcome _obj)
    {
        return objdal.Class_Section_WelcomeSelectBySectionSession(_obj);
    }


    public DataTable Class_Section_WelcomeFetch(int _id)
      {
        return objdal.Class_Section_WelcomeSelect(_id);
      }


    #endregion

    }
