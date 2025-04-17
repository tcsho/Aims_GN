using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Change_Reasons
/// </summary>



public class BLLClass_Change_Reasons
{
    public BLLClass_Change_Reasons()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALClass_Change_Reasons objdal = new DALClass_Change_Reasons();



    #region 'Start Properties Declaration'

    public int CCReason_Id { get; set; }
    public string Reason_Description { get; set; }
    public int? Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Class_Change_ReasonsAdd(BLLClass_Change_Reasons _obj)
    {
        return objdal.Class_Change_ReasonsAdd(_obj);
    }
    public int Class_Change_ReasonsUpdate(BLLClass_Change_Reasons _obj)
    {
        return objdal.Class_Change_ReasonsUpdate(_obj);
    }
    public int Class_Change_ReasonsDelete(BLLClass_Change_Reasons _obj)
    {
        return objdal.Class_Change_ReasonsDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Class_Change_ReasonsFetch()
    {
        return objdal.Class_Change_ReasonsSelect();
    }

    public DataTable Class_Change_ReasonsFetchByStatusID(BLLClass_Change_Reasons _obj)
    {
        return objdal.Class_Change_ReasonsSelectByStatusID(_obj);
    }



    public DataTable Class_Change_ReasonsFetch(int _id)
    {
        return objdal.Class_Change_ReasonsSelect(_id);
    }


    #endregion

}
