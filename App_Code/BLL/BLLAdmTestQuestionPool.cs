using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmTestQuestionPool
/// </summary>



public class BLLAdmTestQuestionPool
{
    public BLLAdmTestQuestionPool()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTestQuestionPool objdal = new DALAdmTestQuestionPool();



    #region 'Start Properties Declaration'
    public int Pool_Id { get; set; }
    public string Description { get; set; }
    public int AdmTestDetail_Id { get; set; }
    public int Status_Id { get; set; }
    public int TimeInSeconds { get; set; }
    public decimal MarksPerQuestion { get; set; }
    public int? MinQuest { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestQuestionPoolAdd(BLLAdmTestQuestionPool _obj)
    {
        return objdal.AdmTestQuestionPoolAdd(_obj);
    }
    public int AdmTestQuestionPoolUpdate(BLLAdmTestQuestionPool _obj)
    {
        return objdal.AdmTestQuestionPoolUpdate(_obj);
    }
    public int AdmTestQuestionPoolDelete(BLLAdmTestQuestionPool _obj)
    {
        return objdal.AdmTestQuestionPoolDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'
    public DataTable AdmTestQuestionsPoolFetch(int _id)
    {
        return objdal.AdmTestQuestionsPoolSelect(_id);
    }

    public DataTable AdmTestQuestionPoolFetch(BLLAdmTestQuestionPool _obj)
    {
        return objdal.AdmTestQuestionPoolSelectAll(_obj);
    }

    public DataTable AdmTestQuestionPoolFetchByStatusID(BLLAdmTestQuestionPool _obj)
    {
        return objdal.AdmTestQuestionPoolSelectByStatusID(_obj);
    }




    #endregion

}
