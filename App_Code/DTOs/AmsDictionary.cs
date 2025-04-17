using System.Collections.Generic;


public static class  AmsDictionary
{
    public static Dictionary<int, string> IdToDisplayAttendanceType = new Dictionary<int, string>
     {
            { 1, "P" },
            { 2, "A" },
            { 3, "L" },
            { 6, "SL" },
            { 21, "HD" },
        };

    public static Dictionary<string, int> AttendanceTypeToDisplayId = new Dictionary<string, int>
     {
            { "P",1 },
            { "A",2 },
            { "L" ,3},
            { "SL" ,6},
            { "HD" ,21},
        };

  
    public static string GetAttendanceTypeToDisplay(int key)
    {  
        if (IdToDisplayAttendanceType.ContainsKey(key))
        {
            return IdToDisplayAttendanceType[key];
        }
        else
        {
            return "Key Not Present";
        }
    }

    public static int GetAttandanceTypeIdToDisplay(string key)
    {
        if (AttendanceTypeToDisplayId.ContainsKey(key))
        {
            return AttendanceTypeToDisplayId[key];
        }
        else
        {
            return 0;
        }
    }

}