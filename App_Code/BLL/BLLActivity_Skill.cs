using System;
using System.Data;


/// <summary>
/// Summary description for BLLActivity_Skill
/// </summary>



public class BLLActivity_Skill
    {
    public BLLActivity_Skill()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALActivity_Skill objdal = new DALActivity_Skill();



    #region 'Start Properties Declaration'
    public int Activity_Skill_Id { get; set; }
    public int Activity_Id { get; set; }
    public string Skill { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Activity_SkillAdd(BLLActivity_Skill _obj)
        {
        return objdal.Activity_SkillAdd(_obj);
        }
    public int Activity_SkillUpdate(BLLActivity_Skill _obj)
        {
        return objdal.Activity_SkillUpdate(_obj);
        }
    public int Activity_SkillDelete(BLLActivity_Skill _obj)
        {
        return objdal.Activity_SkillDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Activity_SkillFetch(BLLActivity_Skill _obj)
        {
        return objdal.Activity_SkillSelect(_obj);
        }

    public DataTable Activity_SkillFetchByStatusID(BLLActivity_Skill _obj)
    {
        return objdal.Activity_SkillSelectByStatusID(_obj);
    }



    public DataTable Activity_SkillFetch(int _id)
      {
        return objdal.Activity_SkillSelect(_id);
      }

    public DataTable Activity_Skill_SelectAllByActivityId(BLLActivity_Skill _obj)
    {
        return objdal.Activity_Skill_SelectAllByActivityId(_obj);
    }

    public DataTable Activity_Skill_SelectAllValuesByActivityIdSkillId(BLLActivity_Skill _obj)
    {
        return objdal.Activity_Skill_SelectAllValuesByActivityIdSkillId(_obj);
    }

    public DataTable Activity_Skill_SelectToCheckExistingActivitySkillDescription(BLLActivity_Skill _obj)
    {
        return objdal.Activity_Skill_SelectToCheckExistingActivitySkillDescription(_obj);
    }

    #endregion

    }
