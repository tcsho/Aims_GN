using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Performance_SubItemHeads
/// </summary>



public class BLLStudent_Performance_SubItemHeads
    {
    public BLLStudent_Performance_SubItemHeads()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_SubItemHeads objdal = new DALStudent_Performance_SubItemHeads();



    #region 'Start Properties Declaration'

    public int KndItmHd_Id { get; set; }
    public string Description { get; set; }
    public int Main_Organistion_Id { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string Comments { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_SubItemHeadsAdd(BLLStudent_Performance_SubItemHeads _obj)
        {
        return objdal.Student_Performance_SubItemHeadsAdd(_obj);
        }
    public int Student_Performance_SubItemHeadsUpdate(BLLStudent_Performance_SubItemHeads _obj)
        {
        return objdal.Student_Performance_SubItemHeadsUpdate(_obj);
        }
    public int Student_Performance_SubItemHeadsDelete(BLLStudent_Performance_SubItemHeads _obj)
        {
        return objdal.Student_Performance_SubItemHeadsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_SubItemHeadsFetch(BLLStudent_Performance_SubItemHeads _obj)
        {
        return objdal.Student_Performance_SubItemHeadsSelect(_obj);
        }

    public DataTable Student_Performance_SubItemHeadsFetchByStatusID(BLLStudent_Performance_SubItemHeads _obj)
    {
        return objdal.Student_Performance_SubItemHeadsSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_SubItemHeadsFetch(int _id)
      {
        return objdal.Student_Performance_SubItemHeadsSelect(_id);
      }


    public DataTable Student_Performance_SubItemHeads_SelectAllByOrgID(BLLStudent_Performance_SubItemHeads _obj)
    {
        return objdal.Student_Performance_SubItemHeads_SelectAllByOrgID(_obj);
    }

    public DataTable Student_Performance_SubItemHeads_SelectAllBYKindItemHdId(BLLStudent_Performance_SubItemHeads _obj)
    {
        return objdal.Student_Performance_SubItemHeads_SelectAllBYKindItemHdId(_obj);
    }

    public DataTable GetSubjectWiseItemHeadsAvailability(BLLStudent_Performance_SubItemHeads _obj)
    {
        return objdal.GetSubjectWiseItemHeadsAvailability(_obj);
    }

    #endregion

    }
