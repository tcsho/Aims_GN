using System;
using System.Data;


/// <summary>
/// Summary description for BLLLmsAppPagesFAQ
/// </summary>
public class BLLLmsAppPagesFAQ
{
    _DALLmsAppPagesFAQ objDAL = new _DALLmsAppPagesFAQ();

    public int FAQ_ID { get { return fAQ_ID; } set { fAQ_ID = value; } }	private int fAQ_ID;
    public int Page_ID { get { return page_ID; } set { page_ID = value; } }	private int page_ID;
    public int OrderNo { get { return orderNo; } set { orderNo = value; } }	private int orderNo;
    public string Question { get { return question; } set { question = value; } }	private string question;
    public string Answer { get { return answer; } set { answer = value; } }	private string answer;
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }	private int status_ID;
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }	private DateTime createdOn;
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }	private int createdBy;
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }	private DateTime modifiedOn;
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }	private int modifiedBy;



    public DataTable LmsAppPagesFAQSelectAll()
    {
        return objDAL.LmsAppPagesFAQSelectAll();
    }

	public BLLLmsAppPagesFAQ()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int LmsAppPagesFAQInsert(BLLLmsAppPagesFAQ objbll)
    {
        return objDAL.LmsAppPagesFAQInsert(objbll);
    }

    public int LmsAppPagesFAQUpdate(BLLLmsAppPagesFAQ objbll)
    {
        return objDAL.LmsAppPagesFAQUpdate(objbll);
    }

    public DataTable LmsAppPagesFAQSelectById(BLLLmsAppPagesFAQ objbll)
    {
        return objDAL.LmsAppPagesFAQSelectById(objbll);
    }

    public int LmsAppPagesFAQDelete(BLLLmsAppPagesFAQ objbll)
    {
        return objDAL.LmsAppPagesFAQDelete(objbll);
    }

    public DataTable LmsAppPagesFAQSelectByPageID(BLLLmsAppPagesFAQ objbll)
    {
        return objDAL.LmsAppPagesFAQSelectByPageID(objbll);
    }
}
