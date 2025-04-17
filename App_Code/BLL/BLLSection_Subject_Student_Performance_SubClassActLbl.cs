using System;
using System.Data;


/// <summary>
/// Summary description for BLLSection_Subject_Student_Performance_SubClassActLbl
/// </summary>



public class BLLSection_Subject_Student_Performance_SubClassActLbl
    {
    public BLLSection_Subject_Student_Performance_SubClassActLbl()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Student_Performance_SubClassActLbl objdal = new DALSection_Subject_Student_Performance_SubClassActLbl();



    #region 'Start Properties Declaration'

    public int SSSKIL_Id { get; set; }
    public int Section_Subject_Id { get; set; }
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
    public int OrderOfPer { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_Student_Performance_SubClassActLblAdd(BLLSection_Subject_Student_Performance_SubClassActLbl _obj)
        {
        return objdal.Section_Subject_Student_Performance_SubClassActLblAdd(_obj);
        }
    public int Section_Subject_Student_Performance_SubClassActLblUpdate(BLLSection_Subject_Student_Performance_SubClassActLbl _obj)
        {
        return objdal.Section_Subject_Student_Performance_SubClassActLblUpdate(_obj);
        }
    public int Section_Subject_Student_Performance_SubClassActLblDelete(BLLSection_Subject_Student_Performance_SubClassActLbl _obj)
        {
        return objdal.Section_Subject_Student_Performance_SubClassActLblDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_Student_Performance_SubClassActLblFetch(BLLSection_Subject_Student_Performance_SubClassActLbl _obj)
        {
        return objdal.Section_Subject_Student_Performance_SubClassActLblSelect(_obj);
        }

    public DataTable Section_Subject_Student_Performance_SubClassActLblFetchByStatusID(BLLSection_Subject_Student_Performance_SubClassActLbl _obj)
    {
        return objdal.Section_Subject_Student_Performance_SubClassActLblSelectByStatusID(_obj);
    }



    public DataTable Section_Subject_Student_Performance_SubClassActLblFetch(int _id)
      {
        return objdal.Section_Subject_Student_Performance_SubClassActLblSelect(_id);
      }


    #endregion

    }
