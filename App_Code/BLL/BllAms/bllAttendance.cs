using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class BllAttendance
{
    DalAttendance dalAttendance = new DalAttendance();
    public DataTable GetCenerClasses(int centerId)
    {
        return dalAttendance.GetCenterClasses(centerId);
    }
}