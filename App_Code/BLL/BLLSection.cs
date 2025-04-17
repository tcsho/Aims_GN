using System.Data;


/// <summary>
/// Summary description for BLLSection
/// </summary>



public class BLLSection
{
    public BLLSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALSection objdal = new DALSection();



    #region 'Start Properties Declaration'
    public int Section_Id { get; set; }
    public int Center_Id { get; set; }
    public int Region_Id { get; set; }
    public string Section_Name { get; set; }
    public int Class_Id { get; set; }
    public int Status_Id { get; set; }
    public string Comments { get; set; }
    public int Teacher_Id { get; set; }
    public int ClassTeacher_Id { get; set; }
    public int MainOrganization_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Student_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int ResultCompletion(BLLSection _obj)
    {
        return objdal.ResultCompletion(_obj);
    }
    public int SectionAdd(BLLSection _obj)
    {
        return objdal.SectionAdd(_obj);
    }
    public int SectionUpdate(BLLSection _obj)
    {
        return objdal.SectionUpdate(_obj);
    }
    public int SectionUpdateClassTeacher(BLLSection _obj)
    {
        return objdal.SectionUpdateClassTeacher(_obj);
    }

    public int SectionDelete(BLLSection _obj)
    {
        return objdal.SectionDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SectionFetch(BLLSection _obj)
    {
        return objdal.SectionSelect(_obj);
    }

    public DataTable SectionFetchByStatusID(BLLSection _obj)
    {
        return objdal.SectionSelectByStatusID(_obj);
    }

    public DataTable Section_ClassTeacherResultCompletionStatus(BLLSection _obj)
    {
        return objdal.Section_ClassTeacherResultCompletionStatus(_obj);
    }

    public DataTable Section_ClassCenterWiseResultCompletionStatus(BLLSection _obj)
    {
        return objdal.Section_ClassCenterWiseResultCompletionStatus(_obj);
    }

    public DataTable Section_ClassRegionWiseResultCompletionStatus(BLLSection _obj)
    {
        return objdal.Section_ClassRegionWiseResultCompletionStatus(_obj);
    }

    public DataTable SectionFetch(int _id)
    {
        return objdal.SectionSelect(_id);
    }

    public DataTable SectionFetchBySetionNameClassCenter_Id(BLLSection _obj)
    {
        return objdal.SectionSelectBySetionNameClassCenter_Id(_obj);
    }
    public DataTable SectionFetchByClassCenter(BLLSection _obj)
    {
        return objdal.SectionSelectByClassCenter(_obj);
    }
    public DataTable SectionSelectByClassTeacherCenter(BLLSection _obj)
    {
        return objdal.SectionSelectByClassTeacherCenter(_obj);
    }

    public DataTable SectionSelectClassTeacherBySection_Id(BLLSection _obj)
    {
        return objdal.SectionSelectClassTeacherBySection_Id(_obj);
    }


    public DataTable Section_ClassMainOrganizationWiseResultCompletionStatus(BLLSection _obj)
    {
        return objdal.Section_ClassMainOrganizationWiseResultCompletionStatus(_obj);
    }


    public DataTable Section_SelectForResultCard(BLLSection _obj)
    {
        return objdal.Section_SelectForResultCard(_obj);
    }
    public int Class_SectionDelete(BLLSection obj)
    {
        return objdal.Class_SectionDelete(obj);
    }
    #endregion

}
