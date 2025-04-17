using System;
using System.Data;

/// <summary>
/// Summary description for BLLDiag_Prog_Unit
/// </summary>



public class BLLDiag_Prog_Unit
    {
    public BLLDiag_Prog_Unit()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALDiag_Prog_Unit objdal = new DALDiag_Prog_Unit();



    #region 'Start Properties Declaration'

    public int Unit_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Unit_Description { get; set; }
    public string Duration { get; set; }
    public decimal Percentage { get; set; }
    public int Evaluation_Criteria_Id { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Diag_Prog_UnitAdd(BLLDiag_Prog_Unit _obj)
        {
        return objdal.Diag_Prog_UnitAdd(_obj);
        }
    public int Diag_Prog_UnitUpdate(BLLDiag_Prog_Unit _obj)
        {
        return objdal.Diag_Prog_UnitUpdate(_obj);
        }
    public int Diag_Prog_UnitDelete(BLLDiag_Prog_Unit _obj)
        {
        return objdal.Diag_Prog_UnitDelete(_obj);

        }
    public int Diag_Prog_UnitUpdatePercentage(BLLDiag_Prog_Unit _obj)
    {
        return objdal.Diag_Prog_UnitUpdatePercentage(_obj);
    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Diag_Prog_UnitFetch(BLLDiag_Prog_Unit _obj)
        {
        return objdal.Diag_Prog_UnitSelect(_obj);
        }

    public DataTable Diag_Prog_UnitFetchByStatusID(BLLDiag_Prog_Unit _obj)
    {
        return objdal.Diag_Prog_UnitSelectByStatusID(_obj);
    }

    public DataTable Diag_Prog_UnitSelectByClassSubject(BLLDiag_Prog_Unit _obj)
    {
        return objdal.Diag_Prog_UnitSelectByClassSubject(_obj);
    }


    public DataTable Diag_Prog_UnitSelectSubjectByUser_Id(int _user_Id)
    {
        return objdal.Diag_Prog_UnitSelectSubjectByUser_Id(_user_Id);
    }




    public DataTable Diag_Prog_UnitSelectClassBySubject_Id(BLLDiag_Prog_Unit _obj)
    {
        return objdal.Diag_Prog_UnitSelectClassBySubject_Id(_obj);
    }


    public DataTable Diag_Prog_UnitFetch(int _id)
      {
        return objdal.Diag_Prog_UnitSelect(_id);
      }


    #endregion

    }
