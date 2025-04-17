using System;
using System.Data;


/// <summary>
/// Summary description for BLLClass
/// </summary>



public class BLLGL
{
    public BLLGL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALGL objdal = new DALGL();



    #region 'Start Properties Declaration'
    public int Student_Id { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public DateTime Date_Of_Birth { get; set; }
    public string Gender { get; set; }
    public string Group { get; set; }
    public string Class_Name { get; set; }
    public string Region_Name { get; set; }

    #endregion

    #region 'Start Fetch Methods'
    public DataTable ClassFetchSearch(string selectionCriteria, int Session_Id)//int Center, int Region, int Grade, int Class
    {
        return objdal.GLSearch(selectionCriteria, Session_Id);//Center, Region,Grade, Class
    }
    #endregion

}
