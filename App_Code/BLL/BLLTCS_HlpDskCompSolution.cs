using System;
using System.Data;


/// <summary>
/// Summary description for BLLTCS_HlpDskCompSolution
/// </summary>
public class BLLTCS_HlpDskCompSolution
{
    _DALTCS_HlpDskCompSolution objDAL = new _DALTCS_HlpDskCompSolution();

    private int hDCompSol_ID;
    private int hDComplaint_ID;
    private string solutionRemarks;
    private string feedback;
    private DateTime feedBackOn;
    private int feedBackBy;
    private DateTime solutionOn;
    private int solutionBy;
    private bool isClear;
    private int hD_Resource_ID;




        public  int HDCompSol_ID{        get { return hDCompSol_ID;}        set { hDCompSol_ID= value;}    }
    public  int HDComplaint_ID{        get { return hDComplaint_ID;}        set { hDComplaint_ID= value;}    }
    public  string SolutionRemarks{        get { return solutionRemarks;}        set { solutionRemarks= value;}    }
    public  string Feedback{        get { return feedback;}        set { feedback= value;}    }
    public DateTime FeedBackOn { get { return feedBackOn; } set { feedBackOn = value; } }
    public  int FeedBackBy{        get { return feedBackBy;}        set { feedBackBy= value;}    }
    public  DateTime SolutionOn{        get { return solutionOn;}        set { solutionOn= value;}    }
    public  int SolutionBy{        get { return solutionBy;}        set { solutionBy= value;}    }
    public  bool IsClear{        get { return isClear;}        set { isClear= value;}    }
    public int HD_Resource_ID { get { return hD_Resource_ID; } set { hD_Resource_ID = value; } }



    public DataTable TCS_HlpDskCompSolutionSelectAll()
    {
        return objDAL.TCS_HlpDskCompSolutionSelectAll();
    }

	public BLLTCS_HlpDskCompSolution()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TCS_HlpDskCompSolutionInsert(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionInsert(objbll);
    }

    public int TCS_HlpDskCompSolutionUpdate(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionUpdate(objbll);
    }

    public DataTable TCS_HlpDskCompSolutionSelectById(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionSelectById(objbll);
    }

    public int TCS_HlpDskCompSolutionDelete(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionDelete(objbll);
    }

    public DataTable TCS_HlpDskCompSolutionSelectByComplaintId(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionSelectByComplaintId(objbll);
    }

    /*public DataTable TCS_HlpDskCompSolutionSelectByCenterId(BLLTCS_HlpDskCompSolution objbll)
    {
        return objDAL.TCS_HlpDskCompSolutionSelectByCenterId(objbll);
    }*/
}
