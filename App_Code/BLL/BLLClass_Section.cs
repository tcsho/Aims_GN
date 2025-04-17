using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Section
/// </summary>



public class BLLClass_Section
    {
    public BLLClass_Section()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALClass_Section objdal = new DALClass_Section();



    #region 'Start Properties Declaration'
    public int Class_Section_Id { get; set; }
    public int Class_Id { get; set; }
    public int Section_Id { get; set; }
    public int Center_Id { get; set; }
    public int Employee_Id { get; set; }
    public int Session_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Class_SectionAdd(BLLClass_Section _obj)
        {
        return objdal.Class_SectionAdd(_obj);
        }
    public int Class_SectionUpdate(BLLClass_Section _obj)
        {
        return objdal.Class_SectionUpdate(_obj);
        }
    public int Class_SectionDelete(BLLClass_Section _obj)
        {
        return objdal.Class_SectionDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Class_SectionFetch(BLLClass_Section _obj)
        {
        return objdal.Class_SectionSelect(_obj);
        }

    public DataTable Class_SectionFetchByStatusID(BLLClass_Section _obj)
    {
        return objdal.Class_SectionSelectByStatusID(_obj);
    }



    public DataTable Class_SectionFetch(int _id)
      {
        return objdal.Class_SectionSelect(_id);
      }


    public DataTable Class_SectionByCenterId(int _id)
    {
        return objdal.Class_SectionByCenterId(_id);
    }

    public DataTable Class_SectionByEmployeeId(int _id)
    {
        return objdal.Class_SectionByEmployeeId(_id);
    }

    public DataTable Class_SectionByEmployeeIdForDiag_Prog(int _id)
    {
        return objdal.Class_SectionByEmployeeIdForDiag_Prog(_id);
    }


    public DataTable Class_SectionByClassTeacherId(BLLClass_Section _obj)
    {
        return objdal.Class_SectionByClassTeacherId(_obj);
    }

    public DataTable Class_SectionWelcomeByClassTeacherId(BLLClass_Section _obj)
    {
        return objdal.Class_SectionWelcomeByClassTeacherId(_obj);
    }

    public DataTable Class_SectionByCenterSectionId(BLLClass_Section _obj)
    {
        return objdal.Class_SectionByCenterSectionId(_obj);
    }

    public DataTable Class_SectionSubjectsValues(BLLClass_Section _obj)
    {
        return objdal.Class_SectionSubjectsValues(_obj);
    }

    public DataTable Employee_ProfileByCenterId(BLLClass_Section _obj)
    {
        return objdal.Employee_ProfileByCenterId(_obj);
    }

    public DataTable Employee_ProfileByEmployeeId(BLLClass_Section _obj)
    {
        return objdal.Employee_ProfileByEmployeeId(_obj);
    }

    public DataTable Class_SectionByTeacherId(BLLClass_Section _obj)
    {
        return objdal.Class_SectionByTeacherId(_obj);
    }
    public DataTable Class_SectionBySessionTeacherId(BLLClass_Section _obj)
    {
        return objdal.Class_SectionBySessionTeacherId(_obj);
    }

    #endregion

    }
