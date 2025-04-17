using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLGrade
/// </summary>



public class BLLGrade
    {
    public BLLGrade()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALGrade objdal = new DALGrade();



    #region 'Start Properties Declaration'

    public int Grade_Id { get; set; }
    public string Grade { get; set; }
    public int Status_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Class_Id { get; set; }

    public double Lowerlimit { get;set; }
    public double Upperlimit { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int GradeAdd(BLLGrade _obj)
        {
        return objdal.GradeAdd(_obj);
        }
    public int GradeUpdate(BLLGrade _obj)
        {
        return objdal.GradeUpdate(_obj);
        }
    public int GradeDelete(BLLGrade _obj)
        {
        return objdal.GradeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable GradeSelectBymoID(BLLGrade _obj)
        {
        return objdal.GradeSelectBymoID(_obj);
        }

    public DataTable GradeFetchByStatusID(BLLGrade _obj)
    {
        return objdal.GradeSelectByStatusID(_obj);
    }



    

  

    public DataTable GradeFetch(int _id)
      {
        return objdal.GradeSelect(_id);
      }


    #endregion

    }
