using System;
using System.Data;
using GleamTech.Web.Controls;

public partial class PresentationLayer_TCS_TCSGResourcesDownloadControl : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        //////}
        //////catch (Exception ex)
        //////{
        //////    Session["error"] = ex.Message;
        //////    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //////}

        if (!IsPostBack)
        {
            //======== Page Access Settings ========================

            // comment on testing
            //////////////////////////////string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //////////////////////////////System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //////////////////////////////string sRet = oInfo.Name;
            //////////////////////////////DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            //////////////////////////////this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();

            //////////////////////////////if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            //////////////////////////////{
            //////////////////////////////    Session.Abandon();
            //////////////////////////////    Response.Redirect("~/login.aspx",false);
            //////////////////////////////}
            //////////////////////////////Session["AddCriteria"] = null;

            //====== End Page Access settings ======================
        }

        

        if (Session["Module"].ToString() == "CMN")
        {
            CreateRootFolderCMN();
        }
        else if (Session["Module"].ToString() == "DropBox")
        {
            CreateRootFolderDropBox();
        }

        else if (Session["Module"].ToString() == "LMSResource")
        {
            CreateRootFolderLMSResource();
        }
        else if (Session["Module"].ToString() == "LMSDropbox")
        {
            CreateRootFolderLMSDropbox();
        }
        else
        {
            CreateRootFolder();
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void CreateRootFolder()
    {
        try
        {
        string strDirectoryName = "";
        string strDirectoryPath = "";

        //====================== Root Folder Creation ==============================

        DataTable dt = new DataTable();
        strDirectoryName = Session["CatName"].ToString();

        DataRow row = (DataRow)Session["rightsRow"];
        if (Session["Module"].ToString() == "GNR")
        {
            if (Session["View"] != null && Session["View"].ToString() == "campus")
            {
                BLLTssGResources objBll = new BLLTssGResources();
                objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
                objBll.Session_ID = Convert.ToInt32(Session["SessionID"]);
                objBll.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);
                objBll.GResourceCat_ID = Convert.ToInt32(Session["ResCat"]);
                objBll.Class_ID = Convert.ToInt32(Session["ClassID"]);
                objBll.Subject_ID = Convert.ToInt32(Session["SubjectID"]);

                dt = objBll.TssGResourcesDetailSelectByCatagory(objBll);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (Convert.ToBoolean(dr["isAllow"]))
                    {

                        strDirectoryPath = dr["GResourcePath"].ToString();
                        FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, strDirectoryPath);
                        rootFolder.Permissions = rootFolder.Permissions =
                        FileVistaPermissions.Traverse |
                        FileVistaPermissions.List |
                        FileVistaPermissions.Copy |
                        FileVistaPermissions.Download;

                        FileVistaControl.RootFolders.Add(rootFolder);
                    }
                }
            }
            else if (Session["View"] != null && Session["View"].ToString() == "ho")
            {
                FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());
                rootFolder.Permissions = rootFolder.Permissions =
                FileVistaPermissions.Full;

                FileVistaControl.RootFolders.Add(rootFolder);
            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {


    }

    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        try
        {
        if (Session["Module"].ToString() == "GNR")
        {
            if (Session["View"] != null)
            {
                if (Session["View"].ToString() == "ho")
                {
                    Response.Redirect("~/PresentationLayer/TCS/TCSGResources.aspx");
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/TCS/TCSGResourcesDownload.aspx");
                }
            }
        }
        else if (Session["Module"].ToString() == "DropBox")
        {
            if (Session["View"] != null)
            {
                if (Session["View"].ToString() == "ho")
                {
                    Response.Redirect("~/PresentationLayer/TCS/TCSHOCenterResources.aspx");
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/Default.aspx");
                }
            }
        }

        else if (Session["Module"].ToString() == "LMSResource")
        {
            if (Session["View"] != null)
            {
                if (Session["View"].ToString() == "ho")
                {
                    Response.Redirect("~/PresentationLayer/TCS/LMSTeacherWorkspaceDetail.aspx");

                    //////Response.Redirect("~/PresentationLayer/TCS/LmsResource.aspx");
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/Default.aspx");
                }
            }
        }
        else if (Session["Module"].ToString() == "LMSDropbox")
        {
            if (Session["View"] != null)
            {
                if (Session["View"].ToString() == "ho")
                {
                    Response.Redirect("~/PresentationLayer/TCS/LMSTeacherWorkspaceDetail.aspx");

                    ////Response.Redirect("~/PresentationLayer/TCS/LmsDropBoxTeacherLevel.aspx");
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/TCS/LmsStudentDropbox.aspx");
                }
            }
        }

        else
        {
            if (Session["View"] != null)
            {
                if (Session["View"].ToString() == "ho")
                {
                    Response.Redirect("~/PresentationLayer/TCS/TCSCommonResources.aspx");
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/TCS/TCSCMNResourcesDownload.aspx");
                }
            }


        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void CreateRootFolderCMN()
    {
        try
        {
        string strDirectoryName = "";
        string strDirectoryPath = "";

        //====================== Root Folder Creation ==============================

        DataTable dt = new DataTable();
        strDirectoryName = Session["CatName"].ToString();

        DataRow row = (DataRow)Session["rightsRow"];
        if (Session["Module"].ToString() == "CMN")
        {
            if (Session["View"] != null && Session["View"].ToString() == "campus")
            {
                BLLTssCMNResources objBll = new BLLTssCMNResources();
                objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
                objBll.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);
                objBll.CMNResource_ID = Convert.ToInt32(Session["ResCat"]);

                dt = objBll.TssCMNResourcesDetailSelectByCatagory(objBll);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (Convert.ToBoolean(dr["isAllow"]))
                    {

                        strDirectoryPath = dr["GResourcePath"].ToString();
                        FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, strDirectoryPath);
                        rootFolder.Permissions = rootFolder.Permissions =
                        FileVistaPermissions.Traverse |
                        FileVistaPermissions.List |
                        FileVistaPermissions.Copy |
                        FileVistaPermissions.Download;

                        FileVistaControl.RootFolders.Add(rootFolder);
                    }
                }
            }
            else if (Session["View"] != null && Session["View"].ToString() == "ho")
            {
                FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());
                rootFolder.Permissions = rootFolder.Permissions =
                FileVistaPermissions.Full;

                FileVistaControl.RootFolders.Add(rootFolder);
            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void CreateRootFolderDropBox()
    {
        try
        {
        string strDirectoryName = "";
        string strDirectoryPath = "";

        //====================== Root Folder Creation ==============================

        DataTable dt = new DataTable();
        strDirectoryName = Session["CatName"].ToString();
      

        DataRow row = (DataRow)Session["rightsRow"];
        if (Session["Module"].ToString() == "DropBox")
        {
            if (Session["View"] != null && Session["View"].ToString() == "campus")
            {
                BLLTCS_DropBox objBll = new BLLTCS_DropBox();
                objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
                objBll.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);


                dt = objBll.TCS_DrobBoxSelectCenterByCenterId(objBll);
                if (dt.Rows.Count > 0)
                {
                   

                        
                        //////strDirectoryPath = dr["GResourcePath"].ToString();
                        strDirectoryPath = dt.Rows[0]["DropBoxResourcePath"].ToString();
                        FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, strDirectoryPath);
                        //////////rootFolder.Permissions = rootFolder.Permissions =
                        //////////FileVistaPermissions.Traverse |
                        //////////FileVistaPermissions.List |
                        //////////FileVistaPermissions.Copy |
                        //////////FileVistaPermissions.Download;
                        rootFolder.Permissions = rootFolder.Permissions =
                        FileVistaPermissions.Full;

                        FileVistaControl.RootFolders.Add(rootFolder);
                    
                }
            }
            else if (Session["View"] != null && Session["View"].ToString() == "ho")
            {
                FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());
                rootFolder.Permissions = rootFolder.Permissions =
                FileVistaPermissions.Full;

                FileVistaControl.RootFolders.Add(rootFolder);
            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void CreateRootFolderLMSResource()
    {
        try
        {
        string strDirectoryName = "";
        string strDirectoryPath = "";

        //====================== Root Folder Creation ==============================

        DataTable dt = new DataTable();
        strDirectoryName = Session["CatName"].ToString();


        DataRow row = (DataRow)Session["rightsRow"];
        if (Session["Module"].ToString() == "LMSResource")
        {
            if (Session["View"] != null && Session["View"].ToString() == "campus")
            {
                BLLTCS_DropBox objBll = new BLLTCS_DropBox();
                objBll.Center_ID = Convert.ToInt32(row["Center_Id"].ToString());
                objBll.Main_Organisation_ID = Convert.ToInt32(Session["moID"]);


                dt = objBll.TCS_DrobBoxSelectCenterByCenterId(objBll);
                if (dt.Rows.Count > 0)
                {



                    //////strDirectoryPath = dr["GResourcePath"].ToString();
                    strDirectoryPath = dt.Rows[0]["DropBoxResourcePath"].ToString();
                    FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, strDirectoryPath);
                    //////////rootFolder.Permissions = rootFolder.Permissions =
                    //////////FileVistaPermissions.Traverse |
                    //////////FileVistaPermissions.List |
                    //////////FileVistaPermissions.Copy |
                    //////////FileVistaPermissions.Download;
                    rootFolder.Permissions = rootFolder.Permissions =
                    FileVistaPermissions.Full;

                    FileVistaControl.RootFolders.Add(rootFolder);

                }
            }
            else if (Session["View"] != null && Session["View"].ToString() == "ho")
            {
                FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());
                rootFolder.Permissions = rootFolder.Permissions =
                FileVistaPermissions.Full;

                FileVistaControl.RootFolders.Add(rootFolder);
            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void CreateRootFolderLMSDropbox()
    {
        try
        {
        string strDirectoryName = "";
        string strDirectoryPath = "";

        //====================== Root Folder Creation ==============================

        DataTable dt = new DataTable();
        strDirectoryName = Session["CatName"].ToString();


        DataRow row = (DataRow)Session["rightsRow"];
        if (Session["Module"].ToString() == "LMSDropbox")
        {
            if (Session["View"] != null && Session["View"].ToString() == "std")
            {
                

                    FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());

                    rootFolder.Permissions = rootFolder.Permissions =
                    FileVistaPermissions.Traverse |
                    FileVistaPermissions.List |
                    FileVistaPermissions.Copy |
                    FileVistaPermissions.Download;
                    

                    FileVistaControl.RootFolders.Add(rootFolder);

                
            }
            else if (Session["View"] != null && Session["View"].ToString() == "ho")
            {
                FileVistaRootFolder rootFolder = new FileVistaRootFolder(strDirectoryName, Session["FolderPath"].ToString());
                rootFolder.Permissions = rootFolder.Permissions =
                FileVistaPermissions.Full;

                FileVistaControl.RootFolders.Add(rootFolder);
            }
        }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



}
