using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

public partial class PresentationLayer_UploadEducationalArchives : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    public string Rdata { get; set; }
    public string Subject { get; set; }
    public string Name { get; set; }
    public string CandNo { get; set; }
    public string RollNo { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        showerror.InnerText = "";

        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];

            if (!IsPostBack)
            {
                loadOrg(sender, e);
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    ddl_MOrg.SelectedValue = row["Main_Organisation_Id"].ToString();
                    ddl_MOrg_SelectedIndexChanged(sender, e);
                }

                FillActiveSessions();

                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = true;


                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);
                    ddl_country.Enabled = false;



                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;


                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;

                }
                // PageInformation();

                loadResultMonth();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }




    }

    protected void loadOrg(object sender, EventArgs e)
    {

        try
        {

            BLLMain_Organisation oDALMainOrgnization = new BLLMain_Organisation();
            DataTable dt = new DataTable();
            dt = oDALMainOrgnization.Main_OrganisationFetch(oDALMainOrgnization);

            DataRow row = (DataRow)Session["rightsRow"];


            if (row["User_Type"].ToString() == "Admin")
            {
                ddl_MOrg.Items.Add(new ListItem(row["Main_Organisation_Name"].ToString(), row["Main_Organisation_Id"].ToString()));

                ddl_MOrg.SelectedIndex = 1;

                ddl_MOrg_SelectedIndexChanged(sender, e);

            }
            else
            {
                objBase.FillDropDown(dt, ddl_MOrg, "Main_Organisation_Id", "Main_Organisation_Name");
            }
            ddl_country.Items.Clear();
            ddl_country.Items.Add(new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void loadCountries()
    {
        try
        {

            BLLMain_Organisation_Country oDALMainOrgCountry = new BLLMain_Organisation_Country();
            oDALMainOrgCountry.Main_Organisation_Id = Convert.ToInt32(ddl_MOrg.SelectedValue.ToString());

            DataTable dt = new DataTable();
            dt = oDALMainOrgCountry.Main_Organisation_CountryFetch(oDALMainOrgCountry);

            objBase.FillDropDown(dt, ddl_country, "Main_Organisation_Country_Id", "Country_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    private void loadResultMonth()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            objBase.FillDropDown(dt, ddlResultMonth, "ResultSeries_Id", "ResultSeries");

            //if (DateTime.Now.Month > 9)
            //{
            //    ddlResultMonth.SelectedIndex = 2;
            //}
            //else
            //{
            //    ddlResultMonth.SelectedIndex = 1;
            //}
            UploadSettings();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //   loadRegions();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddl_MOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCountries();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void FileUpload()
    {
        bool retchk = false;
        BLLCIE_Student_Mapping obj = new BLLCIE_Student_Mapping();
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            DataTable dtDup = obj.CIE_Check_File_Duplication(FileName.Trim());

            if (dtDup.Rows.Count > 0)
            {
                ImpromptuHelper.ShowPrompt("Uploaded File Name Already Exists");
                showerror.InnerText = "Uploaded File Name Already Exists";
            }
            else
            {
                BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();

                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FilePath = Server.MapPath(FolderPath + FileName);

                if (Extension == ".xls" || Extension == ".xlsx")
                {

                    objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                    objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                    FileUpload1.SaveAs(FilePath);
                    string conStr = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                     .ConnectionString;
                            break;
                        case ".xlsx": //Excel 07
                            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                      .ConnectionString;
                            break;
                    }
                    conStr = String.Format(conStr, FilePath, "Yes");

                    OleDbConnection connExcel = new OleDbConnection(conStr);
                    OleDbCommand cmdExcel = new OleDbCommand();
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    DataTable dt = new DataTable();
                    cmdExcel.Connection = connExcel;

                    //Get the name of First Sheet
                    connExcel.Open();
                    DataTable dtExcelSchema;
                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    int AlreadIn = 0;
                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        string F_Name = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString().ToUpper().Trim();

                        if (F_Name == "RESULT1$" || F_Name == "RESULT2$" || F_Name == "RESULT3$")
                        {
                            string SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();

                            cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
                            oda.SelectCommand = cmdExcel;
                            oda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                /*Validate the Headers*/
                                if (ValidateHeaderNames(dt))
                                {
                                    objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                                    objStd.FileName = FileUpload1.FileName;
                                    objStd.Records = dt.Rows.Count;
                                    objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);

                                    if (AlreadIn.ToString() == "0")
                                    {
                                        AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);
                                    }
                                    if (Convert.ToInt32(AlreadIn) > 0)
                                    {
                                        objStd.CIE_FileUp_Id = AlreadIn;
                                        retchk = BulkCopy(dt, AlreadIn);
                                    }
                                }
                                else
                                {
                                    ImpromptuHelper.ShowPrompt("Please upload the valid CAIE excel template!");
                                    showerror.InnerText = "Please upload the valid CAIE excel template!";
                                }
                            }
                            else
                            {
                                ImpromptuHelper.ShowPrompt("No data exist to upload.");
                                showerror.InnerText = "No data exist to upload.";
                            }
                            dt.Rows.Clear();
                        }
                    }

                    connExcel.Close();
                    ImpromptuHelper.ShowPrompt("Student Result file uploaded successfully.");
                    BindHistoryGrid();

                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Please select Excel 2007 version.");
                    showerror.InnerText = "Please select Excel 2007 version.";
                }
            }
        }

    }
    protected void btnStudentMapping_Click(object sender, EventArgs e)
    {
        UplodedFileStudentMapping();
    }
    private void UplodedFileStudentMapping()
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
        objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
        objStd.CIE_FileUploadProcess(objStd);
        ImpromptuHelper.ShowPrompt("Student Result file mapped successfully.");
        BindHistoryGrid();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        DocumentUpload();
        //FileUpload();
        //showerror.InnerText = "";

        //if (FileUpload1.HasFile)
        //{
        //    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //    BLLCIE_Student_Mapping obj = new BLLCIE_Student_Mapping();
        //    DataTable dtDup = obj.CIE_Check_File_Duplication(FileName.Trim());

        //    if (dtDup.Rows.Count > 0)
        //    {
        //        ImpromptuHelper.ShowPrompt("Uploaded File Name Already Exists");
        //        showerror.InnerText = "Uploaded File Name Already Exists";

        //    }
        //    else
        //    {
        //        dtDup = null;
        //        UploadDataInDatabaseAllInOne();
        //        showerror.InnerText = "";

        //    }
        //}



    }

    private void UploadDataInDatabaseAllInOne()
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
        Session["AlreadIn"] = "0";
        bool retchk = false;

        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath(FolderPath + FileName);

            if (Extension == ".xls" || Extension == ".xlsx")
            {

                objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                DataTable dtHistory = objStd.CIE_FileUploadHistoryAllInOneSelectByRecord(objStd);

                if (dtHistory.Rows.Count > 0)
                {
                    ImpromptuHelper.ShowPrompt("Data has already been uploaded");

                    FileUploadGrid.Visible = false;
                    UplodDesc.Visible = false;
                    BindHistoryGrid();
                }
                else
                {

                    /*Save data on Drive*/

                    FileUpload1.SaveAs(FilePath);


                    //Import_To_Grid(FilePath, Extension, "Yes");

                    /*Fetch Data from Excel File*/
                    string conStr = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                     .ConnectionString;
                            break;
                        case ".xlsx": //Excel 07
                            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                      .ConnectionString;
                            break;
                    }
                    conStr = String.Format(conStr, FilePath, "Yes");
                    OleDbConnection connExcel = new OleDbConnection(conStr);
                    OleDbCommand cmdExcel = new OleDbCommand();
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    DataTable dt = new DataTable();
                    cmdExcel.Connection = connExcel;

                    //Get the name of First Sheet
                    connExcel.Open();
                    DataTable dtExcelSchema;
                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //DataRow[] result = dtExcelSchema.Select("TABLE_NAME IN ('Result1$','Result2$','Result3$')");
                    //********************************Today*****************************************

                    //******************************************************************************
                    //for (int i = 0; i < result.Length; i++)

                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        //string F_Name = result[i]["TABLE_NAME"].ToString().ToUpper().Trim();
                        string F_Name = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString().ToUpper().Trim();
                        //if (F_Name.Contains("UPLOAD"))
                        //if (F_Name == "RESULT" + i + "$")
                        if (F_Name == "RESULT1$" || F_Name == "RESULT2$" || F_Name == "RESULT3$")
                        {

                            //string ABC = "A";
                            string SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
                            oda.SelectCommand = cmdExcel;
                            oda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                /*Validate the Headers*/
                                if (ValidateHeaderNames(dt))

                                {



                                    objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                                    objStd.FileName = FileUpload1.FileName;
                                    objStd.Records = dt.Rows.Count;
                                    objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                                    int AlreadIn = 0;
                                    if (Session["AlreadIn"].ToString() == "0")
                                    {
                                        AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);//80;
                                        Session["AlreadIn"] = AlreadIn.ToString();
                                    }


                                    //if (AlreadIn > 0)
                                    if (Convert.ToInt32(Session["AlreadIn"]) > 0)
                                    {


                                        //objStd.CIE_FileUp_Id = AlreadIn;
                                        objStd.CIE_FileUp_Id = Convert.ToInt32(Session["AlreadIn"]);
                                        //retchk = BulkCopy(dt, AlreadIn);
                                        retchk = BulkCopy(dt, Convert.ToInt32(Session["AlreadIn"]));
                                        /*Student Mapping of Cand Id with Roll number Process*/
                                        //************Temporary**************int ProcessStatus = objStd.CIE_FileUploadProcess(objStd);


                                        //if (retchk == true && ProcessStatus == 1)
                                        //if (retchk == true)
                                        //{
                                        //    ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");
                                        //    GridView1.DataSource = null;
                                        //    GridView1.DataBind();
                                        //    FileUploadGrid.Visible = false;
                                        //    UplodDesc.Visible = false;
                                        //    BindHistoryGrid();
                                        //}
                                    }
                                }
                                else
                                {
                                    ImpromptuHelper.ShowPrompt("Please upload the valid CAIE excel template!");
                                    showerror.InnerText = "Please upload the valid CAIE excel template!";
                                }
                            }
                            else
                            {
                                ImpromptuHelper.ShowPrompt("No data exist to upload.");
                                showerror.InnerText = "No data exist to upload.";
                            }

                            connExcel.Close();
                            dt.Rows.Clear();

                        }
                    }
                    //if (retchk == true)
                    if (retchk == true)
                    {
                        objStd.CIE_FileUploadProcess(objStd);
                        //ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");

                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        FileUploadGrid.Visible = false;
                        UplodDesc.Visible = false;
                        BindHistoryGrid();
                        showerror.InnerText = "";
                        showerror.Visible = false;

                    }

                    //**********************************

                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select Excel 2007 version.");
                showerror.InnerText = "Please select Excel 2007 version.";
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select a CIE Excel Template.");

        }

        //ImpromptuHelper.ShowPrompt("Total Records Read from Excel");
        //showerror.InnerText = "Total Records Read from Excel" + objStd.Records.ToString();

    }




    //private void UploadDataInDatabaseAllInOne()
    //{
    //    BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
    //    Session["AlreadIn"] = "0";
    //    bool retchk = false;

    //    if (FileUpload1.HasFile)
    //    {
    //        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
    //        string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
    //        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
    //        string FilePath = Server.MapPath(FolderPath + FileName);

    //        if (Extension == ".xls" || Extension == ".xlsx")
    //        {

    //            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //            objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
    //            DataTable dtHistory = objStd.CIE_FileUploadHistoryAllInOneSelectByRecord(objStd);

    //            if (dtHistory.Rows.Count > 0)
    //            {
    //                ImpromptuHelper.ShowPrompt("Data has already been uploaded");

    //                FileUploadGrid.Visible = false;
    //                UplodDesc.Visible = false;
    //                BindHistoryGrid();
    //            }
    //            else
    //            {

    //                /*Save data on Drive*/

    //                FileUpload1.SaveAs(FilePath);


    //                //Import_To_Grid(FilePath, Extension, "Yes");

    //                /*Fetch Data from Excel File*/
    //                string conStr = "";
    //                switch (Extension)
    //                {
    //                    case ".xls": //Excel 97-03
    //                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
    //                                 .ConnectionString;
    //                        break;
    //                    case ".xlsx": //Excel 07
    //                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
    //                                  .ConnectionString;
    //                        break;
    //                }
    //                conStr = String.Format(conStr, FilePath, "Yes");
    //                OleDbConnection connExcel = new OleDbConnection(conStr);
    //                OleDbCommand cmdExcel = new OleDbCommand();
    //                OleDbDataAdapter oda = new OleDbDataAdapter();
    //                DataTable dt = new DataTable();
    //                cmdExcel.Connection = connExcel;

    //                //Get the name of First Sheet
    //                connExcel.Open();
    //                DataTable dtExcelSchema;
    //                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

    //                //********************************Today*****************************************

    //                //******************************************************************************
    //                //for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
    //                //{


    //                int a = 5;

    //                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    //                connExcel.Close();

    //                //Read Data from First Sheet
    //                connExcel.Open();
    //                cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
    //                oda.SelectCommand = cmdExcel;
    //                dt.Columns.Add("Id", typeof(int));
    //                dt.Columns[0].AutoIncrementSeed = 1;
    //                dt.Columns[0].AutoIncrement = true;
    //                oda.Fill(dt);



    //                DataTable dt2 = new DataTable();
    //                DataRow[] result = dt.Select("Id <= '" + a + "'");
    //                //DataTable result1 = dt.Select("Id <= '" + a + "'");
    //                //dt2.Merge(result);
    //                //dt.AsEnumerable().Where(c => c.Field<int>("id") <= 7).CopyToDataTable(dt2, LoadOption.OverwriteChanges);
    //                //dt2.Rows.Add(dt.Select("Id <= '" + a + "'"));
    //                dt2.Merge(dt);
    //                dt2.Rows.Add(dt.Select("Id <= '" + a + "'"));
    //                //int abc = Rows.IndexOf(dt_argument(“Column1”));
    //                if (dt.Rows.Count > 0)
    //                {
    //                    /*Validate the Headers*/
    //                    if (ValidateHeaderNames(dt))
    //                    {



    //                        objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
    //                        objStd.FileName = FileUpload1.FileName;
    //                        objStd.Records = dt.Rows.Count;
    //                        objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
    //                        int AlreadIn = 0;
    //                        if (Session["AlreadIn"].ToString() == "0")
    //                        {
    //                            AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);//80;
    //                            Session["AlreadIn"] = AlreadIn.ToString();
    //                        }


    //                        //if (AlreadIn > 0)
    //                        if (Convert.ToInt32(Session["AlreadIn"]) > 0)
    //                        {


    //                            //objStd.CIE_FileUp_Id = AlreadIn;
    //                            objStd.CIE_FileUp_Id = Convert.ToInt32(Session["AlreadIn"]);
    //                            //retchk = BulkCopy(dt, AlreadIn);
    //                            retchk = BulkCopy(dt, Convert.ToInt32(Session["AlreadIn"]));
    //                            /*Student Mapping of Cand Id with Roll number Process*/
    //                            //************Temporary**************int ProcessStatus = objStd.CIE_FileUploadProcess(objStd);


    //                            //if (retchk == true && ProcessStatus == 1)
    //                            //if (retchk == true)
    //                            //{
    //                            //    ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");
    //                            //    GridView1.DataSource = null;
    //                            //    GridView1.DataBind();
    //                            //    FileUploadGrid.Visible = false;
    //                            //    UplodDesc.Visible = false;
    //                            //    BindHistoryGrid();
    //                            //}
    //                        }
    //                    }
    //                    else
    //                    {
    //                        ImpromptuHelper.ShowPrompt("Please upload the valid CAIE excel template!");
    //                        showerror.InnerText = "Please upload the valid CAIE excel template!";
    //                    }
    //                }
    //                else
    //                {
    //                    ImpromptuHelper.ShowPrompt("No data exist to upload.");
    //                    showerror.InnerText = "No data exist to upload.";
    //                }

    //                connExcel.Close();
    //                dt.Rows.Clear();


    //                //}for end
    //                if (retchk == true)
    //                    if (retchk == true)
    //                    {
    //                        objStd.CIE_FileUploadProcess(objStd);
    //                        //ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");

    //                        GridView1.DataSource = null;
    //                        GridView1.DataBind();
    //                        FileUploadGrid.Visible = false;
    //                        UplodDesc.Visible = false;
    //                        BindHistoryGrid();
    //                        //ImpromptuHelper.ShowPrompt("Student mapping process completed");
    //                        //showerror.InnerText = "Student mapping process completed";

    //                    }

    //                //**********************************











    //            }
    //        }
    //        else
    //        {
    //            ImpromptuHelper.ShowPrompt("Please select Excel 2007 version.");
    //            showerror.InnerText = "Please select Excel 2007 version.";
    //        }
    //    }
    //    else
    //    {
    //        ImpromptuHelper.ShowPrompt("Please select a CIE Excel Template.");

    //    }

    //    //ImpromptuHelper.ShowPrompt("Total Records Read from Excel");
    //    //showerror.InnerText = "Total Records Read from Excel" + objStd.Records.ToString();

    //}

    private static bool ValidateHeaderNames(DataTable dt)
    {
        bool headerok = true;
        foreach (DataColumn c in dt.Columns)  //loop through the columns. 
        {
            if (c.Ordinal == 0 && c.ColumnName != "School Group") { headerok = false; break; }
            if (c.Ordinal == 1 && c.ColumnName != "Centre") { headerok = false; break; }
            if (c.Ordinal == 2 && c.ColumnName != "Cand") { headerok = false; break; }
            if (c.Ordinal == 3 && c.ColumnName != "Centre Name") { headerok = false; break; }
            if (c.Ordinal == 4 && c.ColumnName != "Region") { headerok = false; break; }
            if (c.Ordinal == 5 && c.ColumnName != "Candidate Name") { headerok = false; break; }
            if (c.Ordinal == 6 && c.ColumnName != "Gender") { headerok = false; break; }
            if (c.Ordinal == 7 && c.ColumnName != "DOB") { headerok = false; break; }
            if (c.Ordinal == 8 && c.ColumnName != "Citzenship No") { headerok = false; break; }
            if (c.Ordinal == 9 && c.ColumnName != "Series") { headerok = false; break; }
            if (c.Ordinal == 10 && c.ColumnName != "Qual") { headerok = false; break; }
            if (c.Ordinal == 11 && c.ColumnName != "Syllabus") { headerok = false; break; }
            if (c.Ordinal == 12 && c.ColumnName != "Title") { headerok = false; break; }
            if (c.Ordinal == 13 && c.ColumnName != "Result") { headerok = false; break; }
            if (c.Ordinal == 14 && c.ColumnName != "Private Cand") { headerok = false; break; }
            if (c.Ordinal == 15 && c.ColumnName != "Oral Endorsement") { headerok = false; break; }

        }
        return headerok;
    }

    private void UploadDataInDatabasePart1()
    {
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath(FolderPath + FileName);

            if (Extension == ".xls" || Extension == ".xlsx")
            {
                BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
                objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                DataTable dt = objStd.CIE_FileUploadHistorySelectByRecord(objStd);

                if (dt.Rows.Count > 0)
                {
                    ImpromptuHelper.ShowPrompt("Data has already been uploaded");
                    /*Are you want to delete the previous data??*/
                }
                else
                {


                    FileUpload1.SaveAs(FilePath);
                    Import_To_Grid(FilePath, Extension, "Yes");

                }
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please select Excel 2007 version.");
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select a CIE Excel Template.");

        }
    }
    private void UploadDataInDatabasePart2()
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();

        DataTable dt = (DataTable)ViewState["dtProcessed"];

        if (dt.Rows.Count > 0)
        {
            bool retchk = false;

            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objStd.FileName = FileUpload1.FileName;
            objStd.Records = dt.Rows.Count;
            objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
            int AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);
            if (AlreadIn > 0)
            {

                objStd.CIE_FileUp_Id = AlreadIn;
                retchk = BulkCopy(dt, AlreadIn);

                int ProcessStatus = objStd.CIE_FileUploadProcess(objStd);

                if (retchk == true && ProcessStatus == 1)
                {
                    ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    FileUploadGrid.Visible = false;
                    UplodDesc.Visible = false;
                    BindHistoryGrid();
                }
            }

        }
        else
        {
            ImpromptuHelper.ShowPrompt("No data exist to upload.");
        }
    }
    private void Import_To_Grid(string FilePath, string Extension, string isHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                         .ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                          .ConnectionString;
                break;
        }
        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;

        //Get the name of First Sheet
        connExcel.Open();
        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();






        //Bind Data to GridView




        GridView1.Caption = Path.GetFileName(FilePath);

        ViewState["dtProcessed"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();



    }

    private DataTable ProcessData(DataTable dtNew)
    {

        bool isintrupt = false;

        DataTable dt3 = new DataTable();

        dt3.Columns.Add(new DataColumn("Centre", typeof(string)));
        dt3.Columns.Add(new DataColumn("Centre_Name", typeof(string)));
        dt3.Columns.Add(new DataColumn("Cand", typeof(string)));
        dt3.Columns.Add(new DataColumn("Candidate_Name", typeof(string)));
        dt3.Columns.Add(new DataColumn("Citzenship_No", typeof(string)));
        dt3.Columns.Add(new DataColumn("Gender", typeof(string)));
        dt3.Columns.Add(new DataColumn("DOB", typeof(string)));
        dt3.Columns.Add(new DataColumn("Private_Cand", typeof(string)));
        dt3.Columns.Add(new DataColumn("Series", typeof(string)));
        dt3.Columns.Add(new DataColumn("Qual", typeof(string)));
        dt3.Columns.Add(new DataColumn("Syllabus", typeof(string)));
        dt3.Columns.Add(new DataColumn("Title", typeof(string)));
        dt3.Columns.Add(new DataColumn("Result", typeof(string)));
        dt3.Columns.Add(new DataColumn("Oral_Endorsement", typeof(string)));
        dt3.Columns.Add(new DataColumn("Session_Id", typeof(int)));
        dt3.Columns.Add(new DataColumn("ResultSeries_Id", typeof(int)));




        for (int i = 0; i < dtNew.Rows.Count; i++)
        {
            dt3.NewRow();

            for (int j = 0; j < dtNew.Columns.Count; j++)
            {

                if (j == 1)
                {
                    string canName = dtNew.Rows[i][j].ToString();

                    if (canName == "Candidate name")
                    {
                        isintrupt = true;
                        break;

                    }

                }
                else if (j > 1)
                {
                    if (dtNew.Rows[i][j].ToString().Length > 0)
                    {


                        dt3.Rows.Add(
                            Convert.ToInt32(ddlSession.SelectedValue),
                            // txtPKNo.Text,
                            // ddlGradeLevel.SelectedValue,
                            dtNew.Rows[i][0].ToString(),
                            dtNew.Rows[i][1].ToString(),
                            dtNew.Columns[j].ColumnName.ToString(),
                            dtNew.Rows[i][j].ToString(),
                            // Convert.ToInt32(ddl_center.SelectedValue),
                            Convert.ToInt32(ddlResultMonth.SelectedValue)
                            );


                    }
                }
            }

            if (isintrupt == true)
            {

                break;
            }
        }
        if (isintrupt == true)
        {

            ImpromptuHelper.ShowPrompt("Attached file formating is not valid, please remove top 4 empty records.");

        }



        return dt3;
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        string FileName = GridView1.Caption;
        string Extension = Path.GetExtension(FileName);
        string FilePath = Server.MapPath(FolderPath + FileName);

        Import_To_Grid(FilePath, Extension, "Yes");

        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        ImpromptuHelper.ShowPrompt("Data has been Imported. Please review before uploading on the server");


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();

    }


    public void downloadsample()
    {

        Response.ContentType = "application/x-msexcel";
        Response.AppendHeader("Content-Disposition", "attachment; filename=CAIEDataUploadFormat.xlsx");

        // Write the file to the Response  
        const int bufferLength = 10000;
        byte[] buffer = new Byte[bufferLength];
        int length = 0;
        Stream download = null;
        try
        {
            download = new FileStream(Server.MapPath("~/PresentationLayer/TCS/Files/CAIEDataUploadFormat.xlsx"),
                                                           FileMode.Open,
                                                           FileAccess.Read);
            do
            {
                if (Response.IsClientConnected)
                {
                    length = download.Read(buffer, 0, bufferLength);
                    Response.OutputStream.Write(buffer, 0, length);
                    buffer = new Byte[bufferLength];
                }
                else
                {
                    length = -1;
                }
            }
            while (length > 0);
            Response.Flush();
            Response.End();
        }
        finally
        {
            if (download != null)
                download.Close();
        }
    }

    protected void btnsample_Click(object sender, EventArgs e)

    {
        try
        {
            //UploadDataInDatabaseAllInOne();



            //downloadsample();
            string strURL = "\\PresentationLayer\\TCS\\Files";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath(FolderPath + "CAIEDataUploadFormat.xlsx");

            WebClient req
 = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;

            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.ContentType = "Application/x-msexcel";

            response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "CAIEDataUploadFormat.xlsx\"");
            byte[] data = req.DownloadData(Server.MapPath(strURL));

            //response.AddHeader("Content-Disposition", "attachment;filename=\"" + FolderPath + "CAIEDataUploadFormat.xlsx\"");
            //byte[] data = req.DownloadData(FolderPath);


            response.BinaryWrite(data);
            response.End();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);

        }


    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        showerror.InnerText = "";
        //UploadDataInDatabasePart2();

    }



    protected bool BulkCopy(DataTable dt, int CIE_FileUp_Id)
    {

        bool chk = false;

        DataColumn dcolColumn = new DataColumn("Session_Id", typeof(int));
        DataColumn dcolColumnRes = new DataColumn("ResultSeries_Id", typeof(int));
        DataColumn dcolColumnFile = new DataColumn("CIE_FileUp_Id", typeof(int));
        dt.Columns.Add(dcolColumn);
        dt.Columns.Add(dcolColumnRes);
        dt.Columns.Add(dcolColumnFile);


        /* You then added the created column to your DataTable, so it should be working */
        foreach (DataRow row in dt.Rows)
        {
            row["Session_Id"] = ddlSession.SelectedValue;
            row["ResultSeries_Id"] = ddlResultMonth.SelectedValue;
            row["CIE_FileUp_Id"] = CIE_FileUp_Id;

        }

        string consString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.CIE_UploadData_AllInOne";
                sqlBulkCopy.BatchSize = 3000;

                sqlBulkCopy.ColumnMappings.Add("Centre", "Centre");
                sqlBulkCopy.ColumnMappings.Add("Centre Name", "Centre_Name");
                sqlBulkCopy.ColumnMappings.Add("Cand", "Cand");
                sqlBulkCopy.ColumnMappings.Add("Candidate Name", "Candidate_Name");
                sqlBulkCopy.ColumnMappings.Add("Citzenship No", "Citzenship_No");
                sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                sqlBulkCopy.ColumnMappings.Add("DOB", "DOB");
                sqlBulkCopy.ColumnMappings.Add("Private Cand", "Private_Cand");
                sqlBulkCopy.ColumnMappings.Add("Series", "Series");
                sqlBulkCopy.ColumnMappings.Add("Qual", "Qual");
                sqlBulkCopy.ColumnMappings.Add("Syllabus", "Syllabus");
                sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                sqlBulkCopy.ColumnMappings.Add("Result", "Result");
                sqlBulkCopy.ColumnMappings.Add("Oral Endorsement", "Oral_Endorsement");
                sqlBulkCopy.ColumnMappings.Add("Session_Id", "Session_Id");
                sqlBulkCopy.ColumnMappings.Add("ResultSeries_Id", "ResultSeries_Id");
                sqlBulkCopy.ColumnMappings.Add("CIE_FileUp_Id", "CIE_FileUp_Id");

                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
                chk = true;
            }
        }

        //*************************************
        dt.Columns.Remove(dcolColumn);
        dt.Columns.Remove(dcolColumnRes);
        dt.Columns.Remove(dcolColumnFile);
        //*************************************

        return chk;
    }
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            ddlSession.SelectedValue = Session["Session_Id"].ToString();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void btnUpload0_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            ImpromptuHelper.ShowPrompt(FileName);
        }
        else
        {

            ImpromptuHelper.ShowPrompt("Please select a CIE Excel Template.");

        }
    }
    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            ImpromptuHelper.ShowPrompt(Extension);
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please select a CIE Excel Template.");

        }
    }

    protected void BindHistoryGrid()
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
        DataTable dt = new DataTable();

        objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
        objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
        dt = objStd.CIE_Student_MappingSelect(objStd);
        if (dt.Rows.Count > 0)
        {
            gvMatchStudent.DataSource = dt;
            gvMatchStudent.DataBind();
        }
    }


    protected void ddlResultMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        UploadSettings();

    }

    private void UploadSettings()
    {
        if (ddlResultMonth.SelectedIndex > 0 && ddlSession.SelectedIndex > 0)
        {
            BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();
            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);

            DataTable dt = objStd.CIE_FileUploadHistoryAllInOneSelectByRecord(objStd);

            if (dt.Rows.Count > 0)
            {
                FileUploadGrid.Visible = false;
                UplodDesc.Visible = false;
                BindHistoryGrid();
            }
            else
            {
                FileUploadGrid.Visible = true;
                UplodDesc.Visible = true;
                gvMatchStudent.DataSource = null;
                gvMatchStudent.DataBind();
            }
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Please Select Academic Year and Result Series!");
        }


    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        showerror.InnerText = "";
        UploadSettings();
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {

            BLLCIE_Student_Mapping objCIE = new BLLCIE_Student_Mapping();
            int AlreadyIn = 0;

            LinkButton btnEdit = (LinkButton)(sender);
            objCIE.CIE_FileUp_Id = Convert.ToInt32(btnEdit.CommandArgument);
            //2023-Aug-08*******
            objCIE.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objCIE.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
            //******************

            AlreadyIn = objCIE.CIE_Student_MappingDeleteAllRecords(objCIE);


            ImpromptuHelper.ShowPrompt("All Records has been successfully deleted!");

            UploadSettings();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {

            BLLCIE_Student_Mapping objCIE = new BLLCIE_Student_Mapping();

            LinkButton btnEdit = (LinkButton)(sender);
            objCIE.CIE_FileUp_Id = Convert.ToInt32(btnEdit.CommandArgument);
            DataTable dtAllData = objCIE.CIE_FileUploadAllInDataSelectById(objCIE);
            if (dtAllData.Rows.Count > 0)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.DataSource = dtAllData;
                GridView1.DataBind();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }




    //****************************************************************************************************************
    private void DocumentUpload()
    {
        bool retchk = false;
        BLLCIE_Student_Mapping obj = new BLLCIE_Student_Mapping();
        if (FileUpload1.HasFile)
        {
            HttpFileCollection uploadedFiles = Request.Files;
            Span1.Text = string.Empty;
            for (int i = 0; i < uploadedFiles.Count; i++)
            //foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                //postedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), uploadedFile.FileName));
                //listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                HttpPostedFile postedFile = uploadedFiles[i];

                string FileName = postedFile.FileName; //Path.GetFileName(FileUpload1.PostedFile.FileName);
                //DataTable dtDup = obj.CIE_Check_File_Duplication(FileName.Trim());

                //if (dtDup.Rows.Count > 0)
                if (1 == 0)
                {
                    ImpromptuHelper.ShowPrompt("Uploaded File Name Already Exists");
                    showerror.InnerText = "Uploaded File Name Already Exists";
                }
                else
                {
                    BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();

                    // HttpPostedFile postedFile = this.FileUpload1.PostedFile;
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName);

                    if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".docx" || Extension.ToLower() == ".pdf" || Extension.ToLower() == ".png")
                    {
                        string MaxId;
                        int contentLength = postedFile.ContentLength;
                        byte[] buffer = new byte[contentLength];
                        postedFile.InputStream.Read(buffer, 0, contentLength);
                        string fileName = FileUpload1.PostedFile.FileName.ToString();
                        string additionals;
                        additionals = DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');

                        //FileStream stream = new FileStream(base.Server.MapPath("~\\PresentationLayer\\TCS\\Files\\" + fName + Path.GetExtension(postedFile.FileName).ToLower()), FileMode.Create);
                        FileStream stream = new FileStream(base.Server.MapPath("~\\PresentationLayer\\TCS\\Files\\" + additionals + "_" + 9999 + "_" + FileName), FileMode.Create);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Close();
                        string addstamp;
                        //download = new FileStream(Server.MapPath("~/PresentationLayer/TCS/Files/CAIEDataUploadFormat.xlsx"),
                        Span1.Text += String.Format("{0}<br />", FileName);
                    }

                    //return;





                    //if (Extension == ".xls" || Extension == ".xlsx")
                    //{

                    //    objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                    //    objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                    //    FileUpload1.SaveAs(FilePath);
                    //    string conStr = "";
                    //    switch (Extension)
                    //    {
                    //        case ".xls": //Excel 97-03
                    //            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                    //                     .ConnectionString;
                    //            break;
                    //        case ".xlsx": //Excel 07
                    //            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                    //                      .ConnectionString;
                    //            break;
                    //    }
                    //    conStr = String.Format(conStr, FilePath, "Yes");

                    //    OleDbConnection connExcel = new OleDbConnection(conStr);
                    //    OleDbCommand cmdExcel = new OleDbCommand();
                    //    OleDbDataAdapter oda = new OleDbDataAdapter();
                    //    DataTable dt = new DataTable();
                    //    cmdExcel.Connection = connExcel;

                    //    //Get the name of First Sheet
                    //    connExcel.Open();
                    //    DataTable dtExcelSchema;
                    //    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //    int AlreadIn = 0;
                    //    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    //    {
                    //        string F_Name = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString().ToUpper().Trim();

                    //        if (F_Name == "RESULT1$" || F_Name == "RESULT2$" || F_Name == "RESULT3$")
                    //        {
                    //            string SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();

                    //            cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
                    //            oda.SelectCommand = cmdExcel;
                    //            oda.Fill(dt);
                    //            if (dt.Rows.Count > 0)
                    //            {
                    //                /*Validate the Headers*/
                    //                if (ValidateHeaderNames(dt))
                    //                {
                    //                    objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                    //                    objStd.FileName = FileUpload1.FileName;
                    //                    objStd.Records = dt.Rows.Count;
                    //                    objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);

                    //                    if (AlreadIn.ToString() == "0")
                    //                    {
                    //                        AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);
                    //                    }
                    //                    if (Convert.ToInt32(AlreadIn) > 0)
                    //                    {
                    //                        objStd.CIE_FileUp_Id = AlreadIn;
                    //                        retchk = BulkCopy(dt, AlreadIn);
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    ImpromptuHelper.ShowPrompt("Please upload the valid CAIE excel template!");
                    //                    showerror.InnerText = "Please upload the valid CAIE excel template!";
                    //                }
                    //            }
                    //            else
                    //            {
                    //                ImpromptuHelper.ShowPrompt("No data exist to upload.");
                    //                showerror.InnerText = "No data exist to upload.";
                    //            }
                    //            dt.Rows.Clear();
                    //        }
                    //    }

                    //    connExcel.Close();
                    //    ImpromptuHelper.ShowPrompt("Student Result file uploaded successfully.");
                    //    BindHistoryGrid();

                    //}
                    //else
                    //{
                    //    ImpromptuHelper.ShowPrompt("Please select Excel 2007 version.");
                    //    showerror.InnerText = "Please select Excel 2007 version.";
                    //}
                }
            }
        }
        else
        {
            Span1.Text = "There's issue with uploaded files please select again....";
        }

    }



    //protected void uploadFile_Click(object sender, EventArgs e)
    //{
    //    if (UploadImages.HasFiles)
    //    {
    //        foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
    //        {
    //            uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), uploadedFile.FileName));
    //            listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
    //        }
    //    }
    //}

}