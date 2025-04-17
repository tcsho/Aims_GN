using System;
using System.Data;


/// <summary>
/// Summary description for BLLEvaluation_Type
/// </summary>



public class BLLEvaluation_Type
    {
    public BLLEvaluation_Type()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALEvaluation_Type objdal = new DALEvaluation_Type();



    #region 'Start Properties Declaration'

    public int Evaluation_Type_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public string Name { get; set; }
    public int Status_Id { get; set; }
    public bool IsExam { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_TypeAdd(BLLEvaluation_Type _obj)
        {
        return objdal.Evaluation_TypeAdd(_obj);
        }
    public int Evaluation_TypeUpdate(BLLEvaluation_Type _obj)
        {
        return objdal.Evaluation_TypeUpdate(_obj);
        }
    public int Evaluation_TypeDelete(BLLEvaluation_Type _obj)
        {
        return objdal.Evaluation_TypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_TypeFetch(BLLEvaluation_Type _obj)
        {
        return objdal.Evaluation_TypeSelect(_obj);
        }

    public DataTable Evaluation_TypeFetchByStatusID(BLLEvaluation_Type _obj)
    {
        return objdal.Evaluation_TypeSelectByStatusID(_obj);
    }



    public DataTable Evaluation_TypeFetch(int _id)
      {
        return objdal.Evaluation_TypeSelect(_id);
      }


    

    public DataTable Evaluation_TypeSelectByOrgId(BLLEvaluation_Type _obj)
    {
        return objdal.Evaluation_TypeSelectByOrgId(_obj);
    }

    #endregion

    }
