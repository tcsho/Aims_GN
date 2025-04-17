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
/// Summary description for BLLEvaluation_Criteria_GenericCommentsBank
/// </summary>


public class DataRow_excel
{
    public List<string> Columns { get; set; }
    public List<object> Values { get; set; }
}
public class BLLEvaluation_Criteria_GenericCommentsBank
    {
    public BLLEvaluation_Criteria_GenericCommentsBank()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALEvaluation_Criteria_GenericCommentsBank objdal = new _DALEvaluation_Criteria_GenericCommentsBank();

    

    #region 'Start Properties Declaration'

    public int GenCom_Id { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public string Comments { get; set; }
    public int Region_id { get; set; }
    public List <int> Regvalue { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_GenericCommentsBankAdd(BLLEvaluation_Criteria_GenericCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_GenericCommentsBankAdd(_obj);
        }
    public int Evaluation_Criteria_GenericCommentsBankUpdate(BLLEvaluation_Criteria_GenericCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_GenericCommentsBankUpdate(_obj);
        }
    public int Evaluation_Criteria_GenericCommentsBankDelete(BLLEvaluation_Criteria_GenericCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_GenericCommentsBankDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_GenericCommentsBankFetchAll()
        {
        return objdal.Evaluation_Criteria_GenericCommentsBankSelectAll();
        }

    public DataTable Evaluation_Criteria_GenericCommentsBankFetch(BLLEvaluation_Criteria_GenericCommentsBank _obj)
    {
        return objdal.Evaluation_Criteria_GenericCommentsBankSelect(_obj);
    }

    public DataTable Evaluation_Criteria_GenericCommentsBankFetch(int _id)
      {
        return objdal.Evaluation_Criteria_GenericCommentsBankSelect(_id);
      }
    public int Evaluation_Criteria_GenericCommentsBankFetchField(int _Id)
        {
        return objdal.Evaluation_Criteria_GenericCommentsBankSelectField(_Id);
        }


    #endregion

    }
