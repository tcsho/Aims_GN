using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BllAssignSubjectToClass
/// </summary>
public class BllAssignSubjectToClass
{
    DllAssignSubjectToClass dllSubject = new DllAssignSubjectToClass();

    public int Subject_Id { get; set; }
    public string Subject_Name { get; set; }
    public string Subject_Code { get; set; }
    public int Status_Id { get; set; }
    public string Comments { get; set; }

    // Class Subject 

    public int Class_ID { get; set; }
    public int Subject_ID { get; set; }
    public int Status_ID { get; set; }
    public int OrderofSubject { get; set; }

    public int Class_Subject_Id { get; set; }



    public int AddNewSubject(BllAssignSubjectToClass subject)
    {
        return dllSubject.AddNewSubject(subject);
    }

    public DataTable GetAllSubjects(BllAssignSubjectToClass subject)
    {
        return dllSubject.GetAllSubjects(subject);
    }

    public int UpdateSubject(BllAssignSubjectToClass subject)
    {
        return dllSubject.UpdateSubject(subject);
    }

    public DataTable GetAllClasses(BllAssignSubjectToClass subject)
    {
        return dllSubject.GetAllClasses(subject);
    }

    public int AddClassSubject(BllAssignSubjectToClass subject)
    {
        return dllSubject.AddClassSubject(subject);
    }

    public int UpdateClassSubject(BllAssignSubjectToClass subject)
    {
        return dllSubject.UpdateClassSubject(subject);
    }
}

