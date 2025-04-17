using System;
using System.Data;


/// <summary>
/// Summary description for BLLClass
/// </summary>



public class BLLGLResult
{
    public BLLGLResult()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALGL objdal = new DALGL();



    #region 'Start Properties Declaration'
    public int Student_Id { get; set; }
    public string TestName { get; set; }
    public int StandardAgeScore { get; set; }
    public int OverallStanine { get; set; }
    public int PercentileRank { get; set; }
    public int SessionID { get; set; }
    public int TermGroupID { get; set; }

    #endregion

    #region 'Start Fetch Methods'
    public DataTable ClassFetchSearch(string selectionCriteria, int Session_Id)//int Center, int Region, int Grade, int Class
    {
        return objdal.GLSearch(selectionCriteria, Session_Id);//Center, Region,Grade, Class
    }

    public DataTable GLResultSearch(string SelectionCriteria)//int Center, int Region, int Session, int Term, int Class,int Subject
    {
        return objdal.GLResultSearch(SelectionCriteria);// Center,  Region,  Session,  Term,  Class, Subject
    }

    public void GLResultAdd(BLLGLResult _obj)
    {
        objdal.GlResultAdd(_obj);
    }
    #endregion

}
