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
/// Summary description for BLLStudent_Evaluation_SubjectRemarks
/// </summary>



public class BLLStudent_Evaluation_SubjectRemarks
{
    public BLLStudent_Evaluation_SubjectRemarks()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALStudent_Evaluation_SubjectRemarks objdal = new _DALStudent_Evaluation_SubjectRemarks();



    #region 'Start Properties Declaration'

    public int Std_Com_Id { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Student_Id { get; set; }
    public string Remarks { get; set; }
    public int Effort { get; set; }
    public int Employee_Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int GoodOne { get; set; }
    public int GoodTwo { get; set; }
    public int ImprovOne { get; set; }
    public int ImprovTwo { get; set; }
    public bool isAbsent { get; set; }



    #endregion

    #region 'Start Executaion Methods'


    public int Student_Evaluation_SubjectRemarksUpsert_correction(BLLStudent_Evaluation_SubjectRemarks _obj)
    {
        return objdal.Student_Evaluation_SubjectRemarksUpsert_correction(_obj);
    }
    public int Student_Evaluation_SubjectRemarksUpsert(BLLStudent_Evaluation_SubjectRemarks _obj)
    {
        return objdal.Student_Evaluation_SubjectRemarksUpsert(_obj);
    }
    public int Student_Evaluation_SubjectRemarksUpdate(BLLStudent_Evaluation_SubjectRemarks _obj)
    {
        return objdal.Student_Evaluation_SubjectRemarksUpdate(_obj);
    }
    public int Student_Evaluation_SubjectRemarksDelete(BLLStudent_Evaluation_SubjectRemarks _obj)
    {
        return objdal.Student_Evaluation_SubjectRemarksDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Evaluation_SubjectRemarksFetch(BLLStudent_Evaluation_SubjectRemarks _obj)
    {
        return objdal.Student_Evaluation_SubjectRemarksSelectAll(_obj);
    }

    public DataTable Student_Evaluation_SubjectRemarksFetch(int _id)
    {
        return objdal.Student_Evaluation_SubjectRemarksSelectById(_id);
    }


    #endregion

}
