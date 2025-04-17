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
/// Summary description for BLLStudent_Diag_Prog
/// </summary>



public class BLLStudent_Diag_Prog
    {
    public BLLStudent_Diag_Prog()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Diag_Prog objdal = new DALStudent_Diag_Prog();



    #region 'Start Properties Declaration'

    public int SSDPD_Id { get; set; }
    public int Student_Section_Subject_Id { get; set; }
    public decimal Marks_Obtained { get; set; }
    public bool Lock_Marks { get; set; }

    public int Section_Subject_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }

    public string XMLData { get; set; }

    public int Student_Id { get; set; }
    public int Section_Id { get; set; }





    #endregion

    #region 'Start Executaion Methods'

    public int Student_Diag_ProgAdd(BLLStudent_Diag_Prog _obj)
        {
        return objdal.Student_Diag_ProgAdd(_obj);
        }
    public int Student_Diag_ProgUpdate(BLLStudent_Diag_Prog _obj)
        {
        return objdal.Student_Diag_ProgUpdate(_obj);
        }
    public int Student_Diag_ProgDelete(BLLStudent_Diag_Prog _obj)
        {
        return objdal.Student_Diag_ProgDelete(_obj);

        }

    public int Student_Diag_ProgInsertMissingStudent(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgInsertMissingStudent(_obj);
    }


    public int Student_Diag_ProgUpdateXML(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgUpdateXML(_obj);
    }


    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Diag_ProgFetch(BLLStudent_Diag_Prog _obj)
        {
        return objdal.Student_Diag_ProgSelect(_obj);
        }

    public DataTable Student_Diag_ProgFetchByStatusID(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgSelectByStatusID(_obj);
    }

    public DataTable Student_Diag_ProgFetchByGrid(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgSelectByGrid(_obj);
    }

    public DataTable Student_Diag_ProgFetch(int _id)
      {
        return objdal.Student_Diag_ProgSelect(_id);
      }

    public DataTable Student_Diag_ProgBySectionSubjectIdForExistStudent(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgBySectionSubjectIdForExistStudent(_obj);
    }


    public DataTable Student_Diag_ProgSelectBySectionSubjectIdForInsertStudent(BLLStudent_Diag_Prog _obj)
    {
        return objdal.Student_Diag_ProgSelectBySectionSubjectIdForInsertStudent(_obj);
    }

    #endregion

    }
