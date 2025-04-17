using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Performance_Grading_Det
/// </summary>



public class BLLStudent_Performance_Grading_Det
    {
    public BLLStudent_Performance_Grading_Det()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_Grading_Det objdal = new DALStudent_Performance_Grading_Det();



    #region 'Start Properties Declaration'

    public int KndSubStd_Id { get; set; }
    public int SSSKIL_Id { get; set; }
    public int KindClassAchvRating_Id { get; set; }
    public int KindSubStdMst_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Main_Organisation_id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_Grading_DetAdd(BLLStudent_Performance_Grading_Det _obj)
        {
        return objdal.Student_Performance_Grading_DetAdd(_obj);
        }
    public int Student_Performance_Grading_DetUpdate(BLLStudent_Performance_Grading_Det _obj)
        {
        return objdal.Student_Performance_Grading_DetUpdate(_obj);
        }
    public int Student_Performance_Grading_DetDelete(BLLStudent_Performance_Grading_Det _obj)
        {
        return objdal.Student_Performance_Grading_DetDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_Grading_DetFetch(BLLStudent_Performance_Grading_Det _obj)
        {
        return objdal.Student_Performance_Grading_DetSelect(_obj);
        }

    public DataTable Student_Performance_Grading_DetFetchByStatusID(BLLStudent_Performance_Grading_Det _obj)
    {
        return objdal.Student_Performance_Grading_DetSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_Grading_DetFetch(int _id)
      {
        return objdal.Student_Performance_Grading_DetSelect(_id);
      }


    #endregion

    }
