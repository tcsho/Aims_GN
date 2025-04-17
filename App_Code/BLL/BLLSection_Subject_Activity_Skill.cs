using System;
using System.Data;

/// <summary>
/// Summary description for BLLSection_Subject_Activity_Skill
/// </summary>



public class BLLSection_Subject_Activity_Skill
    {
    public BLLSection_Subject_Activity_Skill()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Activity_Skill objdal = new DALSection_Subject_Activity_Skill();



    #region 'Start Properties Declaration'

    public int SSAS_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Activity_Skill_Id { get; set; }
    public int Activity_Id { get; set; }
    public string Skill { get; set; }
    public int SSA_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_Activity_SkillAdd(BLLSection_Subject_Activity_Skill _obj)
        {
        return objdal.Section_Subject_Activity_SkillAdd(_obj);
        }
    public int Section_Subject_Activity_SkillUpdate(BLLSection_Subject_Activity_Skill _obj)
        {
        return objdal.Section_Subject_Activity_SkillUpdate(_obj);
        }
    public int Section_Subject_Activity_SkillDelete(BLLSection_Subject_Activity_Skill _obj)
        {
        return objdal.Section_Subject_Activity_SkillDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_Activity_SkillFetch(BLLSection_Subject_Activity_Skill _obj)
        {
        return objdal.Section_Subject_Activity_SkillSelect(_obj);
        }

    public DataTable Section_Subject_Activity_SkillFetchByStatusID(BLLSection_Subject_Activity_Skill _obj)
    {
        return objdal.Section_Subject_Activity_SkillSelectByStatusID(_obj);
    }

    public DataTable Activity_SkillFetchByActivityId(BLLSection_Subject_Activity_Skill _obj)
        {
            return objdal.Activity_SkillFetchByActivityId(_obj);
        }
    



    public DataTable Section_Subject_Activity_SkillFetch(int _id)
      {
        return objdal.Section_Subject_Activity_SkillSelect(_id);
      }


    #endregion

    }
