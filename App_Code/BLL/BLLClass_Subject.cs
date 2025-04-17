using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Subject
/// </summary>



public class BLLClass_Subject
{
    public BLLClass_Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALClass_Subject objdal = new DALClass_Subject();



    #region 'Start Properties Declaration'
    public int Class_Subject_ID { get; set; }
    public int Class_ID { get; set; }
    public int Subject_ID { get; set; }
    public int Status_ID { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Region_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Class_SubjectAdd(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectAdd(_obj);
    }
    public int Class_SubjectUpdate(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectUpdate(_obj);
    }
    public int Class_SubjectDelete(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'

    public DataTable Class_SubjectFetchOlevelsSubjects(BLLClass_Subject obj)
    {
        return objdal.Class_SubjectFetchOlevelsSubjects(obj);
    }
    public DataTable Class_SubjectFetch(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectSelect(_obj);
    }

    public DataTable Class_SubjectFetchByStatusID(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectSelectByStatusID(_obj);
    }



    public DataTable Class_SubjectFetch(int _id)
    {
        return objdal.Class_SubjectSelect(_id);
    }


    public DataTable Class_SubjectSelectAllByClassId(BLLClass_Subject _obj)
    {
        return objdal.Class_SubjectSelectAllByClassId(_obj);
    }


    public DataTable Class_SelectByOrgId(BLLClass_Subject _obj)
    {
        return objdal.Class_SelectByOrgId(_obj);
    }

    #endregion

}
