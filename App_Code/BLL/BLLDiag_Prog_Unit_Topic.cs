using System;
using System.Data;

/// <summary>
/// Summary description for BLLDiag_Prog_Unit_Topic
/// </summary>



public class BLLDiag_Prog_Unit_Topic
    {
    public BLLDiag_Prog_Unit_Topic()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALDiag_Prog_Unit_Topic objdal = new DALDiag_Prog_Unit_Topic();



    #region 'Start Properties Declaration'

  public  int Topic_Id {get;set;}
  public  int Unit_Id {get;set;}
  public  string Topic_Description {get;set;}
  public decimal Duration { get; set; }
  public string Objective { get; set; }
  public  int ? Status_Id {get;set;}
  public int CreatedBy { get; set; }
  public DateTime CreatedOn { get; set; }
  public int? ModifiedBy { get; set; }
  public DateTime? ModifiedOn { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Diag_Prog_Unit_TopicInsert(BLLDiag_Prog_Unit_Topic _obj)
        {
        return objdal.Diag_Prog_Unit_TopicInsert(_obj);
        }
    public int Diag_Prog_Unit_TopicUpdate(BLLDiag_Prog_Unit_Topic _obj)
        {
        return objdal.Diag_Prog_Unit_TopicUpdate(_obj);
        }
    public int Diag_Prog_Unit_TopicDelete(BLLDiag_Prog_Unit_Topic _obj)
        {
        return objdal.Diag_Prog_Unit_TopicDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Diag_Prog_Unit_TopicFetch(BLLDiag_Prog_Unit_Topic _obj)
        {
        return objdal.Diag_Prog_Unit_TopicSelect(_obj);
        }

    public DataTable Diag_Prog_Unit_TopicFetchByStatusID(BLLDiag_Prog_Unit_Topic _obj)
    {
        return objdal.Diag_Prog_Unit_TopicSelectByStatusID(_obj);
    }



    public DataTable Diag_Prog_Unit_TopicFetchByUnitId(int _id)
      {
          return objdal.Diag_Prog_Unit_TopicSelectByUnitId(_id);
      }


    #endregion

    }
