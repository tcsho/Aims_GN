using System;
using System.Data;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;

public partial class PresentationLayer_TCS_CIE_Upload : System.Web.UI.Page
{

    DALBase objBase = new DALBase();
    
    public string Rdata { get; set; }
    public string Subject { get; set; }
    public string Name { get; set; }
    public string CandNo { get; set; }
    public string RollNo { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

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
                    ddl_region.Enabled = true;
                    ddl_center.Enabled = true;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;
                    ddl_center.Enabled = true;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                    ddl_country.SelectedIndex = 1;
                    ddl_country_SelectedIndexChanged(sender, e);

                    ddl_region.SelectedValue = row["Region_Id"].ToString();
                    ddl_Region_SelectedIndexChanged(sender, e);

                    ddl_center.SelectedValue = row["Center_Id"].ToString();
                    ddl_center_SelectedIndexChanged(sender, e);

                    ddl_country.Enabled = false;
                    ddl_region.Enabled = false;

                    ddl_center.Enabled = false;

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

            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            ddl_center.Items.Clear();
            ddl_center.Items.Add(new ListItem("Select", "0"));
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

            ddl_region.Items.Clear();
            ddl_region.Items.Add(new ListItem("Select", "0"));

            ddl_center.Items.Clear();
            ddl_center.Items.Add(new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    private void loadRegions()
    {
        try
        {
            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(ddl_country.SelectedValue.ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void loadCenter()
    {

        try
        {
            BLLCenter objCen = new BLLCenter();
            objCen.Region_Id = Convert.ToInt32(ddl_region.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = objCen.CenterFetchByRegionID_CIE(objCen);
            objBase.FillDropDown(dt, ddl_center, "Center_Id", "Center_Name");
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

            if (DateTime.Now.Month > 9)
            {
                ddlResultMonth.SelectedIndex = 2;
            }
            else
            {
                ddlResultMonth.SelectedIndex = 1;
            }


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
            loadRegions();
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
    protected void ddl_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadCenter();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void ddl_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddl_center.SelectedIndex>0)
            {
                DataTable dt = new DataTable();
                BLLCIE_Student_Mapping objcie = new BLLCIE_Student_Mapping();
                objcie.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
                dt = objcie.CIE_CenterMappingSelectByCenter_Id(objcie);
                if (dt.Rows.Count>0)
                {
                    txtPKNo.Text = dt.Rows[0]["PK_Id"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }





    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (txtPKNo.Text!=string.Empty)
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
                objStd.Center_Id=Convert.ToInt32(ddl_center.SelectedValue);
                objStd.Session_Id=Convert.ToInt32(ddlSession.SelectedValue);
                objStd.Glevel=ddlGradeLevel.SelectedValue;
                objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
                DataTable dt = objStd.CIE_FileUploadHistorySelectByRecord(objStd);

                if (dt.Rows.Count>0)
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
        else
        {
            ImpromptuHelper.ShowPrompt("There is no PK # of this Branch in AIMS+ .Unable to fill data.");
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
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();






        //Bind Data to GridView




        GridView1.Caption = Path.GetFileName(FilePath);
        DataTable dtProcessed = ProcessData(dt);
        ViewState["dtProcessed"] = dtProcessed;
        GridView1.DataSource = dtProcessed;
        GridView1.DataBind();



    }

    private DataTable ProcessData(DataTable dtNew)
    {

        bool isintrupt = false;

        DataTable dt3 = new DataTable();

        dt3.Columns.Add(new DataColumn("Session_Id", typeof(int)));
        dt3.Columns.Add(new DataColumn("PKNo", typeof(string)));
        dt3.Columns.Add(new DataColumn("GCE_level", typeof(string)));

        dt3.Columns.Add(new DataColumn("CandNo", typeof(string)));
        dt3.Columns.Add(new DataColumn("Name", typeof(string)));
        dt3.Columns.Add(new DataColumn("Subject", typeof(string)));
        dt3.Columns.Add(new DataColumn("Grade", typeof(string)));
        dt3.Columns.Add(new DataColumn("Center_ERP", typeof(int)));
        dt3.Columns.Add(new DataColumn("ResultSeries_Id", typeof(int)));
        for (int i = 0; i < dtNew.Rows.Count; i++)
        {
            dt3.NewRow();

            for (int j = 0; j < dtNew.Columns.Count; j++)
            {

                if (j==1)
                {
                    string canName = dtNew.Rows[i][j].ToString();

                    if (canName=="Candidate name")
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
                            txtPKNo.Text,
                            ddlGradeLevel.SelectedValue,
                            dtNew.Rows[i][0].ToString(),
                            dtNew.Rows[i][1].ToString(),
                            dtNew.Columns[j].ColumnName.ToString(),
                            dtNew.Rows[i][j].ToString(),
                            Convert.ToInt32(ddl_center.SelectedValue),
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
        if (isintrupt==true)
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

        //Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
        Import_To_Grid(FilePath, Extension, "Yes");

        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BLLCIE_Student_Mapping objStd = new BLLCIE_Student_Mapping();

        DataTable dt = (DataTable)ViewState["dtProcessed"];

        if (dt.Rows.Count>0)
        {

            objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objStd.Center_Id = Convert.ToInt32(ddl_center.SelectedValue);
            objStd.Glevel = ddlGradeLevel.SelectedValue;
            objStd.FileName="";
            objStd.Records = dt.Rows.Count;
            objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
            int AlreadIn = objStd.CIE_FileUploadHistoryInsert(objStd);
            if (AlreadIn>0)
            {
                BulkCopy(dt);
                objStd.CIE_FileUp_Id = AlreadIn;
                int AlreadInSub = objStd.CIE_Student_MappingAllAdd(objStd);
                if (AlreadInSub>0)
                {

                    ImpromptuHelper.ShowPrompt("Data has been uploaded successfully.");
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    
                }
                            
            }

        }
        else
        {
            ImpromptuHelper.ShowPrompt("No data exist to upload.");
        }

    }
    protected void BulkCopy(DataTable dt)
    {

        string consString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.CIE_UploadData";

                //[OPTIONAL]: Map the DataTable columns with that of the database table
                sqlBulkCopy.ColumnMappings.Add("Session_Id", "Session_Id");
                sqlBulkCopy.ColumnMappings.Add("PKNo", "PKNo");
                sqlBulkCopy.ColumnMappings.Add("GCE_Level", "Glevel");
                sqlBulkCopy.ColumnMappings.Add("CandNo", "CandNo");
                sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                sqlBulkCopy.ColumnMappings.Add("Subject", "Subject");
                sqlBulkCopy.ColumnMappings.Add("Grade", "RData");
                sqlBulkCopy.ColumnMappings.Add("Center_ERP", "Center_Id");
                sqlBulkCopy.ColumnMappings.Add("ResultSeries_Id", "ResultSeries_Id");
                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
            }
        }



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
    
}