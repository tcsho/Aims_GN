using System;
using System.Data;


/// <summary>
/// Summary description for BLLTCS_HlpDskSubCatg
/// </summary>
public class BLLTCS_HlpDskSubCatg
{
    _DALTCS_HlpDskSubCatg objDAL = new _DALTCS_HlpDskSubCatg();

    private int hDSubCat_ID;
    private int mCatg_ID;
    private string hDSubDesc;
    private int status_ID;



    public int HDSubCat_ID { get { return hDSubCat_ID; } set { hDSubCat_ID = value; } }
    public int MCatg_ID { get { return mCatg_ID; } set { mCatg_ID = value; } }
    public string HDSubDesc { get { return hDSubDesc; } set { hDSubDesc = value; } }
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }




    public DataTable TCS_HlpDskSubCatgSelectAll()
    {
        return objDAL.TCS_HlpDskSubCatgSelectAll();
    }

	public BLLTCS_HlpDskSubCatg()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TCS_HlpDskSubCatgInsert(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgInsert(objbll);
    }

    public int TCS_HlpDskSubCatgUpdate(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgUpdate(objbll);
    }

    public DataTable TCS_HlpDskSubCatgSelectById(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgSelectById(objbll);
    }

    public int TCS_HlpDskSubCatgDelete(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgDelete(objbll);
    }

    public DataTable TCS_HlpDskSubCatgSelectByMCatgId(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgSelectByMCatgId(objbll);
    }

    /*public DataTable TCS_HlpDskSubCatgSelectByCenterId(BLLTCS_HlpDskSubCatg objbll)
    {
        return objDAL.TCS_HlpDskSubCatgSelectByCenterId(objbll);
    }*/
}
