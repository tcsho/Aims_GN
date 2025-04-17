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
/// Summary description for BLLStudent_Without_First_Term
/// </summary>



public class BLLStudent_Without_First_Term
{
    public BLLStudent_Without_First_Term()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Without_First_Term objdal = new DALStudent_Without_First_Term();



    #region 'Start Properties Declaration'
    public int Student_Without_First_Term_Id { get; set; }
    public int Student_Id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public string Student_Name { get; set; }
    public int Class_Id { get; set; }
    public string Class_Name { get; set; }
    public int Section_Id { get; set; }
    public int Session_Id { get; set; }
    public string Section_Name { get; set; }
    public bool IsProcess { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Student_Without_First_TermAdd(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_Without_First_TermAdd(_obj);
    }
    public int Student_Without_First_TermUpdate(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_Without_First_TermUpdate(_obj);
    }
    public int Student_Without_First_TermDelete(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_Without_First_TermDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Without_First_TermFetch(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_Without_First_TermSelect(_obj);
    }


    public DataTable Student_SelectAllByStudentNoForStudentWithoutFirstTerm(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_SelectAllByStudentNoForStudentWithoutFirstTerm(_obj);
    }


    public DataTable Student_Without_First_TermFetchByStatusID(BLLStudent_Without_First_Term _obj)
    {
        return objdal.Student_Without_First_TermSelectByStatusID(_obj);
    }



    public DataTable Student_Without_First_TermFetch(int _id)
    {
        return objdal.Student_Without_First_TermSelect(_id);
    }


    #endregion

}
