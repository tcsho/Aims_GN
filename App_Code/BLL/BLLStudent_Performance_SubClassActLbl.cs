using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Performance_SubClassActLbl
/// </summary>



public class BLLStudent_Performance_SubClassActLbl
    {
    public BLLStudent_Performance_SubClassActLbl()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_SubClassActLbl objdal = new DALStudent_Performance_SubClassActLbl();



    #region 'Start Properties Declaration'

    public int SubKndItmLbl_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Description { get; set; }
    public int Main_Organistion_Id { get; set; }
    public int Status_Id { get; set; }
    public int KndItmHd_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int OrderOfPer { get; set; }
    


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_SubClassActLblAdd(BLLStudent_Performance_SubClassActLbl _obj)
        {
        return objdal.Student_Performance_SubClassActLblAdd(_obj);
        }

    public int Student_Performance_SubClassActLblGeneralPerformanceInsert(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLblGeneralPerformanceInsert(_obj);
    }

    public int Student_Performance_SubClassActLblUpdate(BLLStudent_Performance_SubClassActLbl _obj)
        {
        return objdal.Student_Performance_SubClassActLblUpdate(_obj);
        }

    public int Student_Performance_SubClassActLblGeneralPerformanceUpdate(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLblGeneralPerformanceUpdate(_obj);
    }


    public int Student_Performance_SubClassActLblDelete(BLLStudent_Performance_SubClassActLbl _obj)
        {
        return objdal.Student_Performance_SubClassActLblDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_SubClassActLblFetch(BLLStudent_Performance_SubClassActLbl _obj)
        {
        return objdal.Student_Performance_SubClassActLblSelect(_obj);
        }

    public DataTable Student_Performance_SubClassActLblFetchByStatusID(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLblSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_SubClassActLblFetch(int _id)
      {
        return objdal.Student_Performance_SubClassActLblSelect(_id);
      }

    public DataTable Student_Performance_SubClassActLbl_SelectAllByOrgIdClassIdSubjectId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLbl_SelectAllByOrgIdClassIdSubjectId(_obj);
    }

    public DataTable Student_Performance_SubClassActLbl_SelectAllByTermGroupId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLbl_SelectAllByTermGroupId(_obj);
    }


    public DataTable Student_Performance_SubClassActLbl_SelectAllBySubKndItmLblId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLbl_SelectAllBySubKndItmLblId(_obj);
    }

    public DataTable Student_Performance_SubClassActLbl_SelectAllByTermGroupIdSubKndItmLblId(BLLStudent_Performance_SubClassActLbl _obj)
    {
        return objdal.Student_Performance_SubClassActLbl_SelectAllByTermGroupIdSubKndItmLblId(_obj);
    }

    #endregion

    }
