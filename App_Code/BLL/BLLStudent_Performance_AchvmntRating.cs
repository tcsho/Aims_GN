using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Performance_AchvmntRating
/// </summary>



public class BLLStudent_Performance_AchvmntRating
    {
    public BLLStudent_Performance_AchvmntRating()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_AchvmntRating objdal = new DALStudent_Performance_AchvmntRating();



    #region 'Start Properties Declaration'

    public int AchvRating_Id { get; set; }
    public string RateCode { get; set; }
    public int Main_Organistion_Id { get; set; }
    public string Description { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_AchvmntRatingAdd(BLLStudent_Performance_AchvmntRating _obj)
        {
        return objdal.Student_Performance_AchvmntRatingAdd(_obj);
        }
    public int Student_Performance_AchvmntRatingUpdate(BLLStudent_Performance_AchvmntRating _obj)
        {
        return objdal.Student_Performance_AchvmntRatingUpdate(_obj);
        }
    public int Student_Performance_AchvmntRatingDelete(BLLStudent_Performance_AchvmntRating _obj)
        {
        return objdal.Student_Performance_AchvmntRatingDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_AchvmntRatingFetch(BLLStudent_Performance_AchvmntRating _obj)
        {
        return objdal.Student_Performance_AchvmntRatingSelect(_obj);
        }

    public DataTable Student_Performance_AchvmntRatingFetchByStatusID(BLLStudent_Performance_AchvmntRating _obj)
    {
        return objdal.Student_Performance_AchvmntRatingSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_AchvmntRatingFetch(int _id)
      {
        return objdal.Student_Performance_AchvmntRatingSelect(_id);
      }

    public DataTable Student_Performance_AchvmntRating_SelectAllByOrgId(BLLStudent_Performance_AchvmntRating _obj)
    {
        return objdal.Student_Performance_AchvmntRating_SelectAllByOrgId(_obj);
    }

    public DataTable Student_Performance_AchvmntRating_SelectAllByAchvRatingId(BLLStudent_Performance_AchvmntRating _obj)
    {
        return objdal.Student_Performance_AchvmntRating_SelectAllByAchvRatingId(_obj);
    }

    #endregion

    }
