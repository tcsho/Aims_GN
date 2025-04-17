using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;

public partial class PresentationLayer_TCS_UploadStudentForecastedGrade : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            if (!IsPostBack)
            {
                //ViewState["dt"] = null;
                BindGrid(null, 1);
                FillActiveSessions();
                loadResultMonth();
                Load_Grid();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void BindGrid(DataTable dt, int GV)
    {

        if (GV == 1)
        {
            gv_details.DataSource = dt;
            gv_details.DataBind();
        }
        else
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
    protected void FillActiveSessions()
    {
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt.Dispose();
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
    private void loadResultMonth()
    {

        try
        {
            BLLCIE_Student_Mapping objCen = new BLLCIE_Student_Mapping();

            DataTable dt = new DataTable();
            dt = objCen.CIE_ResultSeriesSelectAll();
            dt.Dispose();
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
    private void UploadDataInDatabaseAllInOne()
    {
        lblerror.Text = "";
        lblerror.CssClass = "";
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath(FolderPath + FileName);

            if (Extension == ".xls" || Extension == ".xlsx")
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
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();
                dtExcelSchema.Dispose();
                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
                dt.Dispose();

                if (dt.Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                    btnValidate.Enabled = false;
                    /*Validate the Headers*/
                    if (ValidateHeaderNames(dt))
                    {
                        dt.Columns.Add("Status");
                        ViewState["dt"] = dt;
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    btnValidate.Enabled = true;
                    lblerror.Text = "No data exist to upload.";
                    lblerror.CssClass = "label label-danger text-center";
                }

            }
            else
            {
                lblerror.Text = "Please select Excel 2007 version.";
                lblerror.CssClass = "label label-danger text-center";
            }
        }
        else
        {
            lblerror.Text = "Please select a Excel Template.";
            lblerror.CssClass = "label label-danger text-center";
        }



    }




    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count > 0)
            {
                gv_details.UseAccessibleHeader = false;
                gv_details.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public DataSet exec_SP(string action, string student_id = null, string hfUP_Id = null, DataTable dt = null)
    {
        if (action == "S")
        {
            dt = new DataTable();
            dt = (DataTable)ViewState["dt2"];
        }
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@ForcastedType", dt);
        param[1] = new SqlParameter("@user_id", Session["UserId"].ToString());
        param[2] = new SqlParameter("@Session_Id", ddlSession.SelectedValue);
        param[3] = new SqlParameter("@ResultSeries_Id", ddlResultMonth.SelectedValue);
        param[4] = new SqlParameter("@Glevel", ddlGlevel.SelectedValue);
        param[5] = new SqlParameter("@Student_id", student_id);
        param[6] = new SqlParameter("@UP_Id", hfUP_Id);
        param[7] = new SqlParameter("@Action", action);

        DataSet ds = objBase.sqlcmdFetch_DS("SP_ForCasted_Grades", param);
        ds.Dispose();
        return ds;
    }
    protected void btnValidate_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        lblerror.CssClass = "";
        rdbtn.Visible = true;

        try
        {
            //UploadDataInDatabaseAllInOne();
            UploadData();


        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        lblerror.CssClass = "";
        rdbtn.Visible = false;

        try
        {
            DataTable dttemp = new DataTable(); //(DataTable)ViewState["dt"];
            DataSet ds = exec_SP("S", null, null, dttemp);
            ds.Dispose();
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSave.Enabled = false;
                lblerror.Text = ds.Tables[0].Rows[0][0].ToString();
                lblerror.CssClass = "label label-success text-center";
            }
        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        //Response.Redirect("UploadStudentForecastedGrade.aspx");
        //lblStudentName1.Text = "";
        //lblStudentName2.Text = "";
        //ddlSession.SelectedIndex = 0;
        //ddlResultMonth.SelectedIndex = 0;
        //ddlGlevel.SelectedIndex = 0;
        //lblerror.Text = "";
        //lblerror.CssClass = "";
        //btnSave.Enabled = false;
        //btnValidate.Enabled = true;
        //BindGrid(null,0);
        //BindGrid(null, 1);
        //rdbtn.Visible = false;

        try
        {

            BLLCIE_Student_Mapping objCIE = new BLLCIE_Student_Mapping();
            int AlreadyIn = 0;

            //LinkButton btnEdit = (LinkButton)(sender);
            //objCIE.CIE_FileUp_Id = Convert.ToInt32(btnEdit.CommandArgument);
            //2023-Aug-08*******
            objCIE.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            objCIE.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);
            //******************

            AlreadyIn = objCIE.CIE_Delete_Forecasted_Grade_Data(objCIE);
            lblerror.Text = "Records deleted successfully";
            lblerror.CssClass = "label label-danger text-center";

            ///ImpromptuHelper.ShowPrompt("All Records has been successfully deleted!");

            ///UploadSettings();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //If Salary is less than 10000 than set the Cell BackColor to Red and ForeColor to White  
            if (e.Row.Cells[15].Text == "Not Mapped")
            {
                (e.Row.FindControl("txtStudentID") as TextBox).Enabled = true;
                e.Row.BackColor = Color.LightPink;
            }
        }
    }

    protected void txtStudentID_TextChanged(object sender, EventArgs e)
    {
        TextBox txtStudentID = sender as TextBox;
        GridViewRow gvr = (GridViewRow)txtStudentID.Parent.Parent;
        int rowIndex = gvr.RowIndex;
        string stdName = gv_details.Rows[rowIndex].Cells[5].Text;
        HiddenField gv_hfUP_Id = gvr.FindControl("gv_hfUP_Id") as HiddenField;

        lblStudentName1.Text = "";
        lblStudentName2.Text = "";
        hpStdID.Value = "";
        hfUP_Id.Value = gv_hfUP_Id.Value;
        iconSuccess.Visible = false;
        iconFailed.Visible = true;

        try
        {
            DataSet ds = exec_SP("SL", txtStudentID.Text, gv_hfUP_Id.Value);
            ds.Dispose();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //lblStudentName1.Text = stdName;
                //lblStudentName2.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
                //if (ds.Tables[0].Rows[0]["fullname"].ToString().Contains(stdName))
                //{

                gvr.Cells[10].Text = ds.Tables[0].Rows[0]["fullname"].ToString();
                hpStdID.Value = txtStudentID.Text;

                //    iconSuccess.Visible = true;
                //    iconFailed.Visible = false;
                //}
                //else
                //{
                //    iconSuccess.Visible = false;
                //    iconFailed.Visible = true;
                //}
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal()", true);
                gv_details.DataBind();
            }
        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }



    }

    protected void btnMapped_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        lblerror.CssClass = "";

        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal()", true);
            DataSet ds = exec_SP("M", hpStdID.Value, hfUP_Id.Value);
            ds.Dispose();
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                BindGrid(ds.Tables[0], 1);
                lblerror.Text = ds.Tables[1].Rows[0][0].ToString();
                lblerror.CssClass = "label label-success text-center";
            }
        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }

    }

    protected void rdbtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dttemp = (DataTable)ViewState["dt"];
        //DataSet ds = new DataSet();

        //F2
        string rd_value = "";

        rd_value = rdbtn.SelectedValue;
        if (rd_value.ToString() == "2")
        {
            DataTable dttemp = (DataTable)ViewState["dt"];
            DataSet ds = new DataSet();
            //gv_details.Visible = true;
            //GridView1.Visible = false;
            ds = exec_SP("F2", null, null, dttemp);
            ds.Dispose();
            gv_details.Visible = false;
            GridView1.Visible = true;
            BindGrid(ds.Tables[0], 1);
            dttemp = null;
            ds = null;
        }
        else
        {
            DataTable dttemp = (DataTable)ViewState["dt"];
            DataSet ds = new DataSet();
            ds = exec_SP("F1", null, null, dttemp);
            ds.Dispose();
            gv_details.Visible = false;
            GridView1.Visible = true;
            BindGrid(ds.Tables[0], 2);
            dttemp = null;
            ds = null;
        }
        //dttemp = null;
        //ds = null;
        // lblerror.Text = ds.Tables[1].Rows[0][0].ToString();
        // lblerror.CssClass = "label label-success text-center";


    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = false;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }



    private void UploadData()
    {
        bool retchk = false;
        lblerror.Text = "";
        lblerror.CssClass = "";
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FilePath = Server.MapPath(FolderPath + FileName);

            if (Extension == ".xls" || Extension == ".xlsx")
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
                //*********************************************************************************
                int AlreadIn = 0;
                for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                {
                    string F_Name = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString().ToUpper().Trim();

                    if (F_Name == "RESULT1$" || F_Name == "RESULT2$" || F_Name == "RESULT3$")
                    {
                        string sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();

                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "] Where Centre IS NOT NULL";
                        oda.SelectCommand = cmdExcel;
                        oda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            /*Validate the Headers*/
                            if (ValidateHeaderNames(dt))
                            {
                                //objStd.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                                //objStd.FileName = FileUpload1.FileName;
                                //objStd.Records = dt.Rows.Count;
                                //objStd.ResultSeries_Id = Convert.ToInt32(ddlResultMonth.SelectedValue);

                                if (AlreadIn.ToString() == "0")
                                {
                                    //AlreadIn = objStd.CIE_FileUploadHistoryAllInOneInsert(objStd);
                                }
                                //if (Convert.ToInt32(AlreadIn) > 0)
                                //{
                                //objStd.CIE_FileUp_Id = AlreadIn;
                                retchk = BulkCopy(dt);
                                //}
                            }
                            else
                            {
                                // ImpromptuHelper.ShowPrompt("Please upload the valid CAIE excel template!");
                                showerror.InnerText = "Please upload the valid CAIE excel template!";
                            }
                        }
                        else
                        {
                            //ImpromptuHelper.ShowPrompt("No data exist to upload.");
                            showerror.InnerText = "No data exist to upload.";
                        }
                        dt.Rows.Clear();
                    }
                }

                connExcel.Close();
                lblerror.Text = "File uploaded successfully.";
                //lblerror.CssClass = "label label-success text-center";
                //showerror.InnerText = "File uploaded successfully.";

                //*********************************************************************************





                //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                //connExcel.Close();
                //dtExcelSchema.Dispose();
                ////Read Data from First Sheet
                //connExcel.Open();
                //cmdExcel.CommandText = "SELECT * From [" + SheetName + "] Where Centre IS NOT NULL";
                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                //connExcel.Close();
                //dt.Dispose();

                //if (dt.Rows.Count > 0)
                //{
                //    btnSave.Enabled = true;
                //    btnValidate.Enabled = false;
                //    /*Validate the Headers*/
                //    if (ValidateHeaderNames(dt))
                //    {
                //        dt.Columns.Add("Status");
                //        ViewState["dt"] = dt;
                //    }
                //}
                //else
                //{
                //    btnSave.Enabled = false;
                //    btnValidate.Enabled = true;
                //    lblerror.Text = "No data exist to upload.";
                //    lblerror.CssClass = "label label-danger text-center";
                //}

            }
            else
            {
                lblerror.Text = "Please select Excel 2007 version.";
                lblerror.CssClass = "label label-danger text-center";
            }
        }
        else
        {
            lblerror.Text = "Please select a Excel Template.";
            lblerror.CssClass = "label label-danger text-center";
        }



    }


    protected bool BulkCopy(DataTable dt) //, int CIE_FileUp_Id
    {

        bool chk = false;


        DataColumn dcolColumnRes = new DataColumn("ResultSeries_Id", typeof(int));
        DataColumn dcolColumnFile = new DataColumn("Status", typeof(string));
        DataColumn dcolColumn = new DataColumn("Session_Id", typeof(int));
        dt.Columns.Add(dcolColumnRes);
        dt.Columns.Add(dcolColumnFile);
        dt.Columns.Add(dcolColumn);


        /* You then added the created column to your DataTable, so it should be working */
        foreach (DataRow row in dt.Rows)
        {
            row["ResultSeries_Id"] = ddlResultMonth.SelectedValue;
            row["Status"] = "Not Mapped";
            row["Session_Id"] = ddlSession.SelectedValue;

        }

        string consString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.TMP_CIE_ForcastedGrade";
                sqlBulkCopy.BatchSize = 3000;

                sqlBulkCopy.ColumnMappings.Add("School Group", "SchoolGroup");
                sqlBulkCopy.ColumnMappings.Add("Centre", "Centre");
                sqlBulkCopy.ColumnMappings.Add("Cand", "Cand");
                sqlBulkCopy.ColumnMappings.Add("Centre Name", "CentreName");
                sqlBulkCopy.ColumnMappings.Add("Region", "Region");
                sqlBulkCopy.ColumnMappings.Add("Candidate Name", "CandidateName");
                sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                sqlBulkCopy.ColumnMappings.Add("DOB", "DOB");
                sqlBulkCopy.ColumnMappings.Add("Citzenship No", "CitzenshipNo");
                sqlBulkCopy.ColumnMappings.Add("Series", "Series");
                sqlBulkCopy.ColumnMappings.Add("Qual", "Qual");
                sqlBulkCopy.ColumnMappings.Add("Syllabus", "Syllabus");
                sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                sqlBulkCopy.ColumnMappings.Add("Result", "Result");
                sqlBulkCopy.ColumnMappings.Add("Private Cand", "PrivateCand");
                sqlBulkCopy.ColumnMappings.Add("Oral Endorsement", "OralEndorsement");
                sqlBulkCopy.ColumnMappings.Add("ResultSeries_Id", "ResultSeries_Id");
                sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                sqlBulkCopy.ColumnMappings.Add("Session_Id", "Session_Id");


                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
                chk = true;
            }
        }

        //*************************************

        dt.Columns.Remove(dcolColumnRes);
        dt.Columns.Remove(dcolColumnFile);
        dt.Columns.Remove(dcolColumn);
        //*************************************

        return chk;
    }


    private void Load_Grid()
    {
        BLLCIE_Student_Mapping ob = new BLLCIE_Student_Mapping();
        DataSet ds = CIE_Student_Mapping_For_ForcastedGrade();
        ds.Dispose();
        if (ds.Tables[0].Rows.Count > 0)
        {
            BindGrid(ds.Tables[0], 1);
            //ViewState["dt"] = ds.Tables[0];
            //ViewState["dt2"] = ds.Tables[1];
            lblerror.Text = ds.Tables[2].Rows[0][0].ToString();
            lblerror.CssClass = "label label-success text-center";
        }
        ds.Dispose();
    }
    protected void btnmapping_Click(object sender, EventArgs e)
    {
        try
        {
            Load_Grid();
            if (gv_details.Rows.Count <= 0)
            {
                lblerror.Text = "File mapped successfully.";
            }
            
        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }

    public DataSet CIE_Student_Mapping_For_ForcastedGrade()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", ddlSession.SelectedValue);
        param[1] = new SqlParameter("@ResultSeries_Id", ddlResultMonth.SelectedValue);
        DataSet ds = objBase.sqlcmdFetch_DS("CIE_Student_Mapping_For_ForcastedGrade", param);
        ds.Dispose();
        return ds;
    }


    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Grid();
    }
}