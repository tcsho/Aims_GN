using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Registration_Result_ERP
/// </summary>



public class BLLStudent_Registration_Result_ERP
{
    public BLLStudent_Registration_Result_ERP()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Registration_Result_ERP objdal = new DALStudent_Registration_Result_ERP();



    #region 'Start Properties Declaration'

    public int Registration_Id { get; set; }
    public string StudentStatus { get; set; }
    public string StudentDetail { get; set; }
    public int Class_Id{ get; set; }
    public int Center_Id { get; set; }
    public int Region_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Registration_Result_ERPAdd(BLLStudent_Registration_Result_ERP _obj)
    {
        return objdal.Student_Registration_Result_ERPAdd(_obj);
    }
    public int Student_Registration_Result_ERPUpdate(BLLStudent_Registration_Result_ERP _obj)
    {
        return objdal.Student_Registration_Result_ERPUpdate(_obj);
    }
    public int Student_Registration_Result_ERPDelete(BLLStudent_Registration_Result_ERP _obj)
    {
        return objdal.Student_Registration_Result_ERPDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Registration_Result_ERPFetch(BLLStudent_Registration_Result_ERP _obj)
    {
        return objdal.Student_Registration_Result_ERPSelect(_obj);
    }

    public DataTable Student_Registration_Result_ERPFetchByStatusID(BLLStudent_Registration_Result_ERP _obj)
    {
        return objdal.Student_Registration_Result_ERPSelectByStatusID(_obj);
    }



    public DataTable Student_Registration_Result_ERPFetch(int _id)
    {
        return objdal.Student_Registration_Result_ERPSelect(_id);
    }


    #endregion

}
