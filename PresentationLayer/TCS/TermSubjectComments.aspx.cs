using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;


public partial class PresentationLayer_TCS_TermSubjectComments : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string Template_path = "";
    int termval;
    int SesssionVal;
    //BLLAdmTest obj = new BLLAdmTest();

    BLLEvaluation_Criteria_GenericCommentsBank obj = new BLLEvaluation_Criteria_GenericCommentsBank();

    BLLAdmTestDetail objDetail = new BLLAdmTestDetail();
    DataRow_excel DataRow_excl = new DataRow_excel();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        if (!IsPostBack)
        {
            try
            {
                FillActiveSessions();
                FillClass();
                FillTermList();
                
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
                if (Session["Session"] != null && Session["Class"] != null && Session["TestType"] != null)
                {
                    ddlSession.SelectedValue = Session["Session_Id"].ToString();
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlClass.SelectedValue = Session["Class_Id"].ToString();
                    ddlClass_SelectedIndexChanged(this, EventArgs.Empty);

                    chkTestType_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindReGrid();
        Session["SesssionVal"] = int.Parse(ddlSession.SelectedValue);
       
    }
    //protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindReGrid();
    //}

    private void BindReGrid()
    {
        try
        {
            ViewState["Data"] = null;
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void FillSubjects()
    {

        try
        {

            BLLEvaluation_Criteria_Percentage obj = new BLLEvaluation_Criteria_Percentage();


            int moID = Int32.Parse(Session["moID"].ToString());
            obj.Main_Organisation_Id = moID;
            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            //obj.Region_Id = Convert.ToInt32(list_region.SelectedValue);
            DataTable dt = (DataTable)obj.Class_SubjectSelectAllByClassId(obj);

            objBase.FillDropDown(dt, ddlsubject, "subject_id", "Subject_Name");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void FillTermList()
    {

        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, ddlTerm, "TermGroup_Id", "Type");
            ddlTerm.SelectedIndex = 1;
            termval = ddlTerm.SelectedIndex;
            Session["excel"] = termval;
            

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubjects();
        BindReGrid();

    }


    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ViewState["Data"] = null;
            BindGrid();
             termval = int.Parse(ddlTerm.SelectedValue);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }




    protected void chkTestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ViewState["Data"] = null;
            BindGrid();


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
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
            foreach (DataRow r in dt.Rows)
            {
                if (r["Status_Id"].ToString() == "1")
                {
                    ddlSession.SelectedValue = r["Session_Id"].ToString();
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    SesssionVal = int.Parse(ddlSession.SelectedValue);
                    break;
                    
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillClass()
    {
        try
        {
            BLLClass objBLLClass = new BLLClass();
            DataTable dt = null;
            dt = objBLLClass.ClassFetch(objBLLClass);
            objBase.FillDropDown(dt, ddlClass, "Class_Id", "Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAssignCenters_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Session_Id"] = ddlSession.SelectedValue;
            Session["Session_Name"] = ddlSession.SelectedItem.Text;
            Session["Class_Id"] = ddlClass.SelectedValue;
            Session["ClassDesc"] = ddlClass.SelectedItem.Text;

            Response.Redirect("~/PresentationLayer/TCS/AdmTestAssignCenters.aspx", false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int k = 0;

            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Subject_Id = Convert.ToInt32(ddlsubject.SelectedValue);
            obj.Comments = txtTestName.Text;


            if (ViewState["Mode"].ToString() == "Add")
            {
                obj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                obj.CreatedOn = DateTime.Now;
                k = obj.Evaluation_Criteria_GenericCommentsBankAdd(obj);

            }
            if (ViewState["Mode"].ToString() == "Edit")
            {
                obj.GenCom_Id = Convert.ToInt32(ViewState["GenCom_Id"].ToString());
                obj.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                obj.ModifiedOn = DateTime.Now;

                k = obj.Evaluation_Criteria_GenericCommentsBankUpdate(obj);

            }
            ViewState["Data"] = null;
            BindGrid();
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Please enter comments");
            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPrompt("Value Already Exists");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        btnCancel_Click(this, EventArgs.Empty);
    }
    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";
            ddlsubject.SelectedIndex = 0;
            txtTestName.Text = string.Empty;
            if (ddlClass.SelectedIndex > 0)
            {
                ViewState["Mode"] = "Add";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);


                //btnSave_Click(this, EventArgs.Empty);

            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Class");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteTest_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlClass.SelectedIndex > -1)
            {
                ViewState["Mode"] = "Delete";
                BLLAdmTest obj = new BLLAdmTest();
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);

                int k = obj.AdmTestDelete(obj);

                ViewState["Data"] = null;
                BindGrid();



                GridTestTitle.Visible = false;



            }
            else
                ImpromptuHelper.ShowPrompt("Please Select  a Test Type First");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindGrid()
    {
        try
        {
            gvStaticComments.DataSource = null;
            gvStaticComments.DataBind();

            DataTable dt = new DataTable();
          
            List<string> selectedRegions = new List<string>();

            if (ddlClass.SelectedIndex > 0)
            {
                ///20000000 SR
                ///30000000 NR
                ///40000000 CR
                ///

                if (checkCR.Checked)
                {
                    selectedRegions.Add("40000000");
                }
                if (checkNR.Checked)
                {
                    selectedRegions.Add("30000000");
                }
                if (CheckSR.Checked)
                {
                    selectedRegions.Add("20000000");
                }

                string.Join(",", selectedRegions);
                obj.Regvalue = selectedRegions.Select(int.Parse).ToList();
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
               
                btnAddTest.Visible = true;


                //if (ViewState["Data"] == null)
                //{
                    dt = obj.Evaluation_Criteria_GenericCommentsBankFetch(obj);
                    ViewState["Data"] = dt;
                //}
                //else
                //{
                //    dt = (DataTable)ViewState["Data"];
                //}
            }

            if (dt.Rows.Count > 0)
            {
                gvStaticComments.DataSource = dt;
                gvStaticComments.DataBind();

            }
            else
            {
                gvStaticComments.DataSource = null;
                gvStaticComments.DataBind();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void gvTest_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvStaticComments.Rows.Count > 0)
            {
                gvStaticComments.UseAccessibleHeader = false;
                gvStaticComments.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            ViewState["Mode"] = "Edit";

            LinkButton btnEdit = (LinkButton)(sender);
            obj.GenCom_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["GenCom_Id"] = obj.GenCom_Id;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvStaticComments.SelectedIndex = gvr.RowIndex;

            txtTestName.Text = gvr.Cells[7].Text;
            ddlsubject.SelectedValue = gvr.Cells[3].Text;



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

            oDALRegion.Main_Organisation_Country_Id = 1;
            dt = oDALRegion.RegionFetch(oDALRegion);

            //objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    [WebMethod]
    public static string DownloadExcelFile()
    {
        try
        {
            DataTable newDt = GetDataFromDatabase();

            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Add headers to the worksheet
                worksheet.Cells[1, 1].Value = "Class_Id";
                worksheet.Cells[1, 2].Value = "Class_Name";
                worksheet.Cells[1, 3].Value = "Subject_Id";
                worksheet.Cells[1, 4].Value = "Subject_Name";
                worksheet.Cells[1, 5].Value = "Comment";

                // Add data rows to the worksheet
                for (int i = 0; i < newDt.Rows.Count; i++)
                {
                    for (int j = 0; j < newDt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = newDt.Rows[i][j];
                    }
                }

                // Convert Excel package to byte array
                byte[] byteArray = package.GetAsByteArray();

                // Convert the byte array to a Base64 string
                return Convert.ToBase64String(byteArray);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions or log them
            return "Error: " + ex.Message;
        }
    }

    private static DataTable GetDataFromDatabase()
    {
        DataTable dataTable = new DataTable();

        // Retrieve the connection string from your configuration
        string connectionString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(
                "select DISTINCT cs.Class_ID, C.Class_Name, cs.Subject_ID, S.Subject_Name " +
                "FROM Class_Subject cs " +
                "INNER JOIN Class C ON C.Class_Id = cs.Class_ID " +
                "INNER JOIN Subject S ON S.Subject_Id = CS.Subject_ID " +
                "WHERE cs.Status_ID = 1 AND c.Status_Id = 1 AND s.Status_Id = 1 " +
                "AND cs.Class_ID in (3,4,5,6,7,8) order by cs.Class_ID asc", connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
	    connection.Close();
        }

        return dataTable;
    }


    [WebMethod]
    public static string UploadDataTable(List<DataRow_excel> DataRow_excel, bool isCheckSRChecked, bool isCheckCRChecked, bool isCheckNRChecked)
    {
        try
        {
            // Convert the List<DataRow> to DataTable
            DataTable dt = ConvertToDataTable(DataRow_excel);
            string result = "";
            if (dt.Rows.Count > 0)
            {
                PresentationLayer_TCS_TermSubjectComments pageInstance = new PresentationLayer_TCS_TermSubjectComments();
                pageInstance.BulkCopy(dt, isCheckSRChecked, isCheckNRChecked, isCheckCRChecked, out result);
                //pageInstance.BindGrid();
                HttpResponse response = HttpContext.Current.Response;
            }

            // Assuming you need to return something meaningful here
            return "Data imported successfully.";
        }
        catch (Exception ex)
        {
            // Log the inner exceptions
            Exception innerEx1 = ex.InnerException;
            while (innerEx1 != null)
            {
                Console.WriteLine("Inner Exception: {innerEx1.GetType().Name} - {innerEx1.Message}");
                innerEx1 = innerEx1.InnerException;
            }

            // Return the error message
            return "Error: " + ex.Message;
        }
    }

    private static DataTable ConvertToDataTable(List<DataRow_excel> DataRow_excel)
    {
        DataTable table = new DataTable();

        if (DataRow_excel != null && DataRow_excel.Count > 0)
        {
            // Assume the first DataRow contains column names
            foreach (var column in DataRow_excel[0].Columns)
            {
                table.Columns.Add(column);
            }

            // Add data to DataTable
            foreach (var dataRow in DataRow_excel)
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < dataRow.Columns.Count; i++)
                {
                    // Check if the value is not null before adding
                    if (dataRow.Values[i] != null)
                    {
                        // Convert the value to string before checking for emptiness
                        string valueAsString = dataRow.Values[i].ToString();
                        if (!string.IsNullOrEmpty(valueAsString))
                        {
                            row[dataRow.Columns[i]] = valueAsString;
                        }
                    }
                }
                // Add row only if it contains non-empty values
                if (row.ItemArray.Any(value => value != DBNull.Value && !string.IsNullOrEmpty(value.ToString())))
                {
                    table.Rows.Add(row);
                }
            }

        }

        return table;
    }

    protected void Checkbox_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox checkbox = (System.Web.UI.WebControls.CheckBox)sender;

        BindGrid();

        
    }


    protected void BulkCopy(DataTable dt, bool isCheckSRChecked, bool isCheckNRChecked, bool isCheckCRChecked, out string result)
    {
        try
        {
            string chk = "";
            string Sr, NR, CR, RigionStr = "";


            //DataColumn dcolColumnRes = new DataColumn("Subject_Id", typeof(int));
            //DataColumn dcolColumnFile = new DataColumn("Class_Id", typeof(int));
            DataColumn dcolColumn = new DataColumn("Session_Id", typeof(int));
            DataColumn dcolColumn_term = new DataColumn("TermGroup_Id", typeof(int));
            DataColumn dcolColumn_rigion = new DataColumn("Region", typeof(string));
            DataColumn dcolColumn_CreatedOn = new DataColumn("CreatedOn", typeof(DateTime));
            DataColumn dcolColumn_CreatedBy = new DataColumn("CreatedBy", typeof(int));
            DataColumn dcolColumn_UniqueCode = new DataColumn("UniqueCode", typeof(string));
            //dt.Columns.Add(dcolColumnRes);
            //dt.Columns.Add(dcolColumnFile);
            dt.Columns.Add(dcolColumn);
            dt.Columns.Add(dcolColumn_term);
            dt.Columns.Add(dcolColumn_rigion);
            dt.Columns.Add(dcolColumn_CreatedOn);
            dt.Columns.Add(dcolColumn_CreatedBy);
            dt.Columns.Add(dcolColumn_UniqueCode);

            if (isCheckSRChecked)
            {
                if (RigionStr != null && RigionStr != "")
                {
                    RigionStr = RigionStr + "SR";
                }
                else
                {
                    RigionStr = "SR";
                }
            }
            if (isCheckNRChecked)
            {
                if (RigionStr != null && RigionStr != "")
                {
                    RigionStr = RigionStr + "/NR";
                }
                else
                {
                    RigionStr = "NR";
                }

            }
            if (isCheckCRChecked)
            {
                if (RigionStr != null && RigionStr != "")
                {
                    RigionStr = RigionStr + "/CR";
                }
                else
                {
                    RigionStr = "CR";
                }

            }
            string Code = Guid.NewGuid().ToString();
            /* You then added the created column to your DataTable, so it should be working */
            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row["Comment"].ToString()))
                {
                    //row["TermGroup_Id"] = termval;
                    int excelValue;
                    int session_v;
                    if (Session["excel"] != null && int.TryParse(Session["excel"].ToString(), out excelValue))
                    {
                        // Use excelValue as needed
                        row["TermGroup_Id"] = excelValue;
                    }
                    if (Session["SesssionVal"] != null && int.TryParse(Session["SesssionVal"].ToString(), out session_v))
                    {
                        // Use excelValue as needed
                        row["Session_Id"] = session_v;
                    }
                    row["CreatedOn"] = DateTime.Now;
                    row["CreatedBy"] = Session["ContactID"];
                    row["Region"] = RigionStr;
                    row["UniqueCode"] = Code;
                }
                   

            }
            var rowsToInsert = dt.AsEnumerable().Where(row => !string.IsNullOrEmpty(row.Field<string>("Comment"))).CopyToDataTable();
            string consString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
 
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Evaluation_Criteria_GenericCommentsBank";
                        sqlBulkCopy.BatchSize = 3000;

                        sqlBulkCopy.ColumnMappings.Add("Class_Id", "Class_Id");
                        sqlBulkCopy.ColumnMappings.Add("Subject_Id", "Subject_Id");
                        sqlBulkCopy.ColumnMappings.Add("Comment", "Comments");

                        sqlBulkCopy.ColumnMappings.Add("TermGroup_Id", "TermGroup_Id");
                        sqlBulkCopy.ColumnMappings.Add("Region", "Region");
                        // sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                        sqlBulkCopy.ColumnMappings.Add("Session_Id", "Session_Id");
                        sqlBulkCopy.ColumnMappings.Add("CreatedOn", "CreatedOn");
                        sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
                        sqlBulkCopy.ColumnMappings.Add("UniqueCode", "UniqueCode");


                        con.Open();
                    sqlBulkCopy.WriteToServer(rowsToInsert);
                    con.Close();

                        Console.WriteLine("First transaction (BulkCopy) succeeded.");
                        result = "Bulk Insertion in Evaluation_Criteria_GenericCommentsBank Completed Successfully";
                       

                        //*************************************

                        //dt.Columns.Remove(dcolColumnRes);
                        //dt.Columns.Remove(dcolColumnFile);
                        dt.Columns.Remove(dcolColumn);
                        dt.Columns.Remove(dcolColumn_term);
                        dt.Columns.Remove(dcolColumn_rigion);
                        dt.Columns.Remove(dcolColumn_CreatedOn);
                        dt.Columns.Remove(dcolColumn_CreatedBy);
                        dt.Columns.Remove(dcolColumn_UniqueCode);


                    }

                    string query = "SELECT * FROM Evaluation_Criteria_GenericCommentsBank WHERE UniqueCode = '" + Code + "'";


                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dts = new DataTable();
                    con.Open();
                    dts.Load(cmd.ExecuteReader());
                   
                    
                        {
                            string insertQuery = "INSERT INTO Evaluation_Criteria_GenericCommentsBankRegion (GenCom_Id, Region_Id,Status_Id) VALUES ";


                            // Use a StringBuilder to build the values part of the query
                            StringBuilder valuesClause = new StringBuilder();

                            // Iterate through the rows in the DataTable

                            if (dts.Rows.Count > 0)
                            {
                                //20000000==SR
                                //,30000000==NR
                                //,40000000==CR

                                if (RigionStr == "SR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 20000000, 1), ", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "SR/NR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);
                                        valuesClause.Append(String.Format("({0}, 20000000, 1), ({0}, 30000000, 1),", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "SR/NR/CR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 20000000, 1), ({0}, 30000000, 1), ({0}, 40000000, 1), ", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "SR/CR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 20000000, 1), ({0}, 40000000, 1), ", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "NR/CR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 30000000, 1), ({0}, 40000000, 1), ", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "CR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 40000000, 1), ", GenCom_Id));
                                    }
                                }
                                else if (RigionStr == "NR")
                                {
                                    foreach (DataRow row in dts.Rows)
                                    {
                                        int GenCom_Id = Convert.ToInt32(row["GenCom_Id"]);

                                        valuesClause.Append(String.Format("({0}, 30000000, 1), ", GenCom_Id));
                                    }
                                }
                            }

                            if (valuesClause.Length >= 2)
                            {
                                valuesClause.Length -= 2;
                            }

                            insertQuery += valuesClause.ToString();

                            {
                                SqlCommand cmds = new SqlCommand(insertQuery, con);
                                cmds.ExecuteNonQuery();
                                Console.WriteLine("Insertion in Evaluation_Criteria_GenericCommentsBankRegion succeeded.");
                                con.Close();
                                result = "Bulk Insertion Complete Successfully";
                                 HttpResponse response = HttpContext.Current.Response;
                        
                                return;
                            }


                        }


                }
           

        }
        catch (Exception ex)
        {
            // Log the inner exceptions
            Exception innerEx1 = ex.InnerException;
            while (innerEx1 != null)
            {
                Console.WriteLine("Inner Exception: {innerEx1.GetType().Name} - {innerEx1.Message}");
                innerEx1 = innerEx1.InnerException;
            }
            result = "Error: " + ex.Message;
            throw new Exception(result);
        }



    }
 


}
