using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Performance_ClassAchvRating
/// </summary>



public class BLLStudent_Performance_ClassAchvRating
    {
    public BLLStudent_Performance_ClassAchvRating()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_ClassAchvRating objdal = new DALStudent_Performance_ClassAchvRating();



    #region 'Start Properties Declaration'

    public int KindClassAchvRating_Id { get; set; }
    public int Main_Organistion_Id { get; set; }
    public int AchvRating_Id { get; set; }
    public int Class_Id { get; set; }
    public int Section_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_ClassAchvRatingAdd(BLLStudent_Performance_ClassAchvRating _obj)
        {
        return objdal.Student_Performance_ClassAchvRatingAdd(_obj);
        }
    public int Student_Performance_ClassAchvRatingUpdate(BLLStudent_Performance_ClassAchvRating _obj)
        {
        return objdal.Student_Performance_ClassAchvRatingUpdate(_obj);
        }
    public int Student_Performance_ClassAchvRatingDelete(BLLStudent_Performance_ClassAchvRating _obj)
        {
        return objdal.Student_Performance_ClassAchvRatingDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_ClassAchvRatingFetch(BLLStudent_Performance_ClassAchvRating _obj)
        {
        return objdal.Student_Performance_ClassAchvRatingSelect(_obj);
        }

    public DataTable Student_Performance_ClassAchvRatingFetchByStatusID(BLLStudent_Performance_ClassAchvRating _obj)
    {
        return objdal.Student_Performance_ClassAchvRatingSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_ClassAchvRatingFetch(int _id)
      {
        return objdal.Student_Performance_ClassAchvRatingSelect(_id);
      }

    public DataTable Student_Performance_ClassAchvRatingSelectAllByOrgId(BLLStudent_Performance_ClassAchvRating _obj)
    {
        return objdal.Student_Performance_ClassAchvRatingSelectAllByOrgId(_obj);
    }

    #endregion

    }
