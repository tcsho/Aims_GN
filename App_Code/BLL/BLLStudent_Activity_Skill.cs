using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Activity_Skill
/// </summary>



public class BLLStudent_Activity_Skill
{
    public BLLStudent_Activity_Skill()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Activity_Skill objdal = new DALStudent_Activity_Skill();



    #region 'Start Properties Declaration'

    public int Student_Activity_Skill_Id { get; set; }
    public int SSAS_Id { get; set; }
    public int Student_Section_Subject_Id { get; set; }
    public int Marks { get; set; }
    public bool Lock_Mark { get; set; }
    public int Student_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Activity_Id { get; set; }
    public int Activity_Skill_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Activity_SkillAdd(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillAdd(_obj);
    }
    public int Student_Activity_SkillUpdate(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillUpdate(_obj);
    }
    public int Student_Activity_SkillDelete(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Activity_SkillFetch(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillSelect(_obj);
    }

    public DataTable Student_Activity_SkillFetchByStatusID(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillSelectByStatusID(_obj);
    }

    public DataTable Student_Activity_SkillFetchBySectionSkill(BLLStudent_Activity_Skill _obj)
    {
        return objdal.Student_Activity_SkillSelectBySectionSkill(_obj);
    }


    public DataTable Student_Activity_SkillFetch(int _id)
    {
        return objdal.Student_Activity_SkillSelect(_id);
    }


    #endregion

}
