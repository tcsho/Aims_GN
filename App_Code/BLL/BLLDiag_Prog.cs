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
/// Summary description for BLLDiag_Prog
/// </summary>



public class BLLDiag_Prog
    {
    public BLLDiag_Prog()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALDiag_Prog objdal = new DALDiag_Prog();



    #region 'Start Properties Declaration'
    public int DP_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Criteria_Id { get; set; }
    public string Section_Name { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
  
    public int Topic { get; set; }
    public int Unit_Id { get; set; }


    public int Region_Id { get; set; }



    // For Student Term Days

    public int Session_Id { get; set; }
    //////////////public int Evaluation_Criteria_Type_Id { get; set; }
    public int Student_Id { get; set; }
    public int FirstTermDays { get; set; }
    public int SecondTermDays { get; set; }
    public string FirstTermDaysCH { get; set; }
    public string SecondTermDaysCH { get; set; }

    public int DaysAttend { get; set; }
    public int Section_Id { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int Diag_ProgAdd(BLLDiag_Prog _obj)
        {
        return objdal.Diag_ProgAdd(_obj);
        }

    public int Student_TermDaysAdd(BLLDiag_Prog _obj)
    {
        return objdal.Student_TermDaysAdd(_obj);
    }
    public int Student_TermDaysDelete(BLLDiag_Prog _obj)
    {
        return objdal.Student_TermDaysDelete(_obj);
    }
    public int Diag_ProgUpdate(BLLDiag_Prog _obj)
        {
        return objdal.Diag_ProgUpdate(_obj);
        }
    public int Diag_ProgDelete(BLLDiag_Prog _obj)
        {
        return objdal.Diag_ProgDelete(_obj);

        }
    public int  Diag_Prog_DetailUpdateLockMarks(BLLDiag_Prog obj)
    {
         return objdal.Diag_Prog_DetailUpdateLockMarks(obj);
    }

    #endregion
    #region 'Start Fetch Methods'
    public DataTable Diag_ProgSelectCenters(int i)
    {
        return objdal.Diag_ProgSelectCenters(i);
    }
    public DataTable Diag_ProgSelectEvalCriteriaId(BLLDiag_Prog obj)
    { 
        return objdal.Diag_ProgSelectEvalCriteriaId(obj);
    }
    public DataTable Diag_ProgFetch(BLLDiag_Prog _obj)
        {
        return objdal.Diag_ProgSelect(_obj);
        }

    public DataTable Diag_ProgFetchByStatusID(BLLDiag_Prog _obj)
    {
        return objdal.Diag_ProgSelectByStatusID(_obj);
    }



    public DataTable Diag_ProgFetch(int _id)
      {
        return objdal.Diag_ProgSelect(_id);
      }

    public DataTable Diag_ProgSelectTopic(BLLDiag_Prog obj)
    {
        return objdal.Diag_ProgSelectTopic(obj);
    }
    public DataTable Diag_ProgSelectAllByClassSubjectTermId(BLLDiag_Prog _obj)
    {
        return objdal.Diag_ProgSelectAllByClassSubjectTermId(_obj);
    }

    public DataTable Diag_ProgSelectAllByDPId(BLLDiag_Prog _obj)
    {
        return objdal.Diag_ProgSelectAllByDPId(_obj);
    }


    public DataTable Diag_ProgManageCenterWiseAccess(BLLDiag_Prog _obj)
    {
        return objdal.Diag_ProgManageCenterWiseAccess(_obj);
    }


    public DataTable Diag_Prog_Question_TypeSelectAll(BLLDiag_Prog _obj)
    {
        return objdal.Diag_Prog_Question_TypeSelectAll(_obj);
    }





    #endregion

    }
