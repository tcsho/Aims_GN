using System;
using System.Data;


/// <summary>
/// Summary description for BLLTCS_HlpDskMainCatg
/// </summary>
public class BLLTCS_HlpDskMainCatg
{
    _DALTCS_HlpDskMainCatg objDAL = new _DALTCS_HlpDskMainCatg();

    private int mCatg_ID;
    private string mCatDesc;
    private int status_Id;
    private int main_Organisation_Id;


    public int MCatg_ID { get { return mCatg_ID; } set { mCatg_ID = value; } }
    public string MCatDesc { get { return mCatDesc; } set { mCatDesc = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public int Main_Organisation_Id { get { return main_Organisation_Id; } set { main_Organisation_Id = value; } }



    public DataTable TCS_HlpDskMainCatgSelectAll()
    {
        return objDAL.TCS_HlpDskMainCatgSelectAll();
    }

	public BLLTCS_HlpDskMainCatg()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TCS_HlpDskMainCatgInsert(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgInsert(objbll);
    }

    public int TCS_HlpDskMainCatgUpdate(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgUpdate(objbll);
    }

    public DataTable TCS_HlpDskMainCatgSelectById(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgSelectById(objbll);
    }

    public int TCS_HlpDskMainCatgDelete(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgDelete(objbll);
    }

    /*public DataTable TCS_HlpDskMainCatgSelectByCenterId(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgSelectByCenterId(objbll);
    }*/

    public DataTable TCS_HlpDskMainCatgSelectByMainOrgID(BLLTCS_HlpDskMainCatg objbll)
    {
        return objDAL.TCS_HlpDskMainCatgSelectByMainOrgID(objbll);
    }
}
