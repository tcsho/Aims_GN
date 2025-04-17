
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
/// Summary description for BLLEvaluation_Criteria_StudentCommentsBank
/// </summary>



public class BLLEvaluation_Criteria_StudentCommentsBank
    {
    public BLLEvaluation_Criteria_StudentCommentsBank()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALEvaluation_Criteria_StudentCommentsBank objdal = new _DALEvaluation_Criteria_StudentCommentsBank();



    #region 'Start Properties Declaration'

    public int ComBank_Id { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public string Comments { get; set; }
    public int CommCat_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_StudentCommentsBankAdd(BLLEvaluation_Criteria_StudentCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_StudentCommentsBankAdd(_obj);
        }
    public int Evaluation_Criteria_StudentCommentsBankUpdate(BLLEvaluation_Criteria_StudentCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_StudentCommentsBankUpdate(_obj);
        }
    public int Evaluation_Criteria_StudentCommentsBankDelete(BLLEvaluation_Criteria_StudentCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_StudentCommentsBankDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_StudentCommentsBankSelectByParam(BLLEvaluation_Criteria_StudentCommentsBank _obj)
        {
        return objdal.Evaluation_Criteria_StudentCommentsBankSelectByParam(_obj);
        }

    public DataTable Evaluation_Criteria_StudentCommentsBankFetch(int _id)
      {
        return objdal.Evaluation_Criteria_StudentCommentsBankSelectById(_id);
      }

    public DataTable Evaluation_Criteria_StudentCommentsBankFetch(BLLEvaluation_Criteria_StudentCommentsBank _obj)
    {
        return objdal.Evaluation_Criteria_StudentCommentsBankSelectAll(_obj);
    }


    #endregion

}
