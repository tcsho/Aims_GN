using System;
using System.Data;


/// <summary>
/// Summary description for BLLLmsAppPages
/// </summary>



public class BLLLmsAppPages
{
    public BLLLmsAppPages()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALLmsAppPages objdal = new DALLmsAppPages();



    #region 'Start Properties Declaration'
    private int page_ID;
    private string pageCode;
    private string pageName;
    private string pageTitle;
    private string pagePath;
    private int projectTool_ID;
    private int status_Id;
    private string pageCaption;


    public int Page_ID { get { return page_ID; } set { page_ID = value; } }
    public string PageCode { get { return pageCode; } set { pageCode = value; } }
    public string PageName { get { return pageName; } set { pageName = value; } }
    public string PageTitle { get { return pageTitle; } set { pageTitle = value; } }
    public string PagePath { get { return pagePath; } set { pagePath = value; } }
    public int ProjectTool_ID { get { return projectTool_ID; } set { projectTool_ID = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public string PageCaption { get { return pageCaption; } set { pageCaption = value; } }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsAppPagesAdd(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesAdd(_obj);
    }
    public int LmsAppPagesUpdate(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesUpdate(_obj);
    }
    public int LmsAppPagesDelete(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'
    public DataTable LmsAppPagesFetch(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesSelect(_obj);
    }


    public DataTable LmsAppPagesFetchByPageName(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesSelectByPageName(_obj);
    }

    public DataTable LmsAppPagesFetchByStatusID(BLLLmsAppPages _obj)
    {
        return objdal.LmsAppPagesSelectByStatusID(_obj);
    }



    public DataTable LmsAppPagesFetch(int _id)
    {
        return objdal.LmsAppPagesSelect(_id);
    }


    #endregion

}
