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
/// Summary description for BLLStudent_Joined_In_NewSession
/// </summary>



public class BLLStudent_Joined_In_NewSession
{
    public BLLStudent_Joined_In_NewSession()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Joined_In_NewSession objdal = new DALStudent_Joined_In_NewSession();



    #region 'Start Properties Declaration'

    public int Student_Joined_In_NewSession_Id { get; set; }
    public int Student_Id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public string Student_Name { get; set; }
    public int Class_Id { get; set; }
    public string Class_Name { get; set; }
    public int Section_Id { get; set; }
    public string Section_Name { get; set; }
    public int Session_Id { get; set; }
    public bool IsProcess { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Joined_In_NewSessionAdd(BLLStudent_Joined_In_NewSession objbll)
    {
        return objdal.Student_Joined_In_NewSessionAdd(objbll);
    }
    public int Student_Joined_In_NewSessionUpdate(BLLStudent_Joined_In_NewSession _obj)
    {
        return objdal.Student_Joined_In_NewSessionUpdate(_obj);
    }
    public int Student_Joined_In_NewSessionDelete(BLLStudent_Joined_In_NewSession _obj)
    {
        return objdal.Student_Joined_In_NewSessionDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Joined_In_NewSessionFetch(BLLStudent_Joined_In_NewSession _obj)
    {
        return objdal.Student_Joined_In_NewSessionSelect(_obj);
    }

    public DataTable Student_Joined_In_NewSessionFetchByStatusID(BLLStudent_Joined_In_NewSession _obj)
    {
        return objdal.Student_Joined_In_NewSessionSelectByStatusID(_obj);
    }


    public DataTable Student_SelectAllByStudentNoForStudent_Joined_In_NewSession(BLLStudent_Joined_In_NewSession _obj)
    {
        return objdal.Student_SelectAllByStudentNoForStudent_Joined_In_NewSession(_obj);
    }

    public DataTable Student_Joined_In_NewSessionFetch(int _id)
    {
        return objdal.Student_Joined_In_NewSessionSelect(_id);
    }


    #endregion

}
