using System;
using System.Data;


/// <summary>
/// Summary description for BLLSubject
/// </summary>



public class BLLClassTimetable
{
    public BLLClassTimetable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALClassTimetable objdal = new DALClassTimetable();



    #region 'Start Properties Declaration'




   
   
    public bool IsActive { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string UpdateDate { get; set; }
    public int TimetableId { get; set; }
    public int Session_id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int Teacher_Id { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public DateTime Starttime { get; set; }
    public DateTime Endtime { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    //public int Group_Add(BLLClassTimetable _obj)
    //{
    //    return objdal.Group_Add(_obj);
    //}

    //public int Add_classes(BLLClassTimetable _obj)
    //{
    //    return objdal.Add_classes(_obj);
    //}

    //public int Group_Inactive(BLLClassTimetable _obj)
    //{
    //    return objdal.Group_Inactive(_obj);

    //}

    #endregion
    #region 'Start Fetch Methods'




    public DataTable SubjectSelectAllWithSubNameGroup(BLLClassTimetable _obj)
    {
        return objdal.SubjectSelectAllWithSubNameGroup(_obj);
    }


    public DataTable SubjectFetchByStatusID(BLLClassTimetable _obj)
    {
        return objdal.SubjectSelectByStatusID(_obj);
    }




    #endregion


  
    //public int GroupNameAvailability(BLLClassTimetable _obj)
    //{
    //    return objdal.GroupNameAvailability(_obj);
    //}

    public DataTable GetClasses()
    {
        return objdal.GetClasses();
    }

  
  


    public DataTable Get_Indicators(int Group_ID, int PS_ID)
    {
        return objdal.Get_Indicators(Group_ID, PS_ID);
    }

    public DataTable Get_Sections(int Center_ID, int Class_ID)
    {
        return objdal.Get_Sections(Center_ID, Class_ID);
    }

    public int TimeTable_Insert(BLLClassTimetable _obj)
    {
        return objdal.TimeTable_Insert(_obj);
    }

    

    //public int Lo_Consolidation_Update(BLLClassTimetable _obj)
    //{
    //    return objdal.Lo_Consolidation_Update(_obj);
    //}

    public DataTable Get_Timetabledata(
        string Region_ID, 
        string Center_id 
        //string teacher_id, 
        //string class_id, 
        //string subject_id, 
        //string Term_Group_id,
        //string keystage
        )
    {
        return objdal.Get_Timetabledata(Region_ID, Center_id);
    }





    //***********************************************PS1 Insertion*******************************************************************

    





   

   

    
   

 


    public int TimetableDelete(int id)
    {
        return objdal.TimetableDelete(id);

    }
}
