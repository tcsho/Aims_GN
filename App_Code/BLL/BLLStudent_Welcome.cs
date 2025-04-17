using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Welcome
/// </summary>



public class BLLStudent_Welcome
    {
    public BLLStudent_Welcome()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Welcome objdal = new DALStudent_Welcome();



    #region 'Start Properties Declaration'

    public int welcome_Id { get; set; }
    public int Student_Id { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Student_WelcomeAdd(BLLStudent_Welcome _obj)
        {
        return objdal.Student_WelcomeAdd(_obj);
        }
    public int Student_WelcomeUpdate(BLLStudent_Welcome _obj)
        {
        return objdal.Student_WelcomeUpdate(_obj);
        }
    public int Student_WelcomeDelete(BLLStudent_Welcome _obj)
        {
        return objdal.Student_WelcomeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_WelcomeFetch(BLLStudent_Welcome _obj)
        {
        return objdal.Student_WelcomeSelect(_obj);
        }

    public DataTable Student_WelcomeFetchByStatusID(BLLStudent_Welcome _obj)
    {
        return objdal.Student_WelcomeSelectByStatusID(_obj);
    }



    public DataTable Student_WelcomeFetch(int _id)
      {
        return objdal.Student_WelcomeSelect(_id);
      }


    #endregion

    }
