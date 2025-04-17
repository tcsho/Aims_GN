using System;
using System.Data;

/// <summary>
/// Summary description for BLLDiag_Prog_Topic
/// </summary>



public class BLLDiag_Prog_Topic
    {
    public BLLDiag_Prog_Topic()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALDiag_Prog_Topic objdal = new DALDiag_Prog_Topic();



    #region 'Start Properties Declaration'

   	public  int DP_Topic_ID {get;set;}
	public  int DP_ID {get;set;}
	public  int Topic_Id {get;set;}


    #endregion

    #region 'Start Executaion Methods'

    public int Diag_Prog_TopicAdd(BLLDiag_Prog_Topic _obj)
        {
        return objdal.Diag_Prog_TopicAdd(_obj);
        }
    public int Diag_Prog_TopicUpdate(BLLDiag_Prog_Topic _obj)
        {
        return objdal.Diag_Prog_TopicUpdate(_obj);
        }
    public int Diag_Prog_TopicDelete(BLLDiag_Prog_Topic _obj)
        {
        return objdal.Diag_Prog_TopicDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Diag_Prog_TopicCheckLockMarks(BLLDiag_Prog_Topic obj)
    {
        return objdal.Diag_Prog_TopicCheckLockMarks(obj);
    }
    public DataTable Diag_Prog_TopicFetch(BLLDiag_Prog_Topic _obj)
        {
        return objdal.Diag_Prog_TopicSelect(_obj);
        }

    public DataTable Diag_Prog_TopicFetchByStatusID(BLLDiag_Prog_Topic _obj)
    {
        return objdal.Diag_Prog_TopicSelectByStatusID(_obj);
    }



    public DataTable Diag_Prog_TopicFetch(int _id)
      {
        return objdal.Diag_Prog_TopicSelect(_id);
      }

    public DataTable Diag_Prog_TopicSelectTopicDetails(BLLDiag_Prog_Topic obj)
    {
        return objdal.Diag_Prog_TopicSelectTopicDetails(obj);
    }
    public DataTable Diag_Prog_TopicSelectTopic(BLLDiag_Prog_Topic obj)
    {
        return objdal.Diag_Prog_TopicSelectTopic(obj);
    }
    #endregion

    }
