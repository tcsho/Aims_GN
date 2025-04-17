using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using City.Library.SQL;
using City.Library.Utility;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_frmCentury : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    Utility obj_Utility = new Utility();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillDDL(); Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

    }
    public void FillDDL()
    {
        DataTable DT = ExecuteProcedureCentury("S", "");
        DT.Dispose();
        if (DT.Rows.Count > 0)
        {
            ddlSession.DataSource = DT;
            ddlSession.DataValueField = "code";
            ddlSession.DataTextField = "name";
            ddlSession.DataBind();
        }
        else { ddlSession.Items.Insert(0, new ListItem("--No Data Found--", "0")); }
    }
    public void FillGrid(ref DataTable dt)
    {
        tbMainGV.Visible = true;
        GV_Teacher.DataSource = dt;
        GV_Teacher.DataBind();
    }
    public void File_Upload()
    {
        string connStr = "";
        string directory = "";
        XmlDocument doc = new XmlDocument();
        try
        {
            if (FL_SD.HasFile)
            {
                directory = Server.MapPath("~/Upload/");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                if (File.Exists(directory + "\\" + FL_SD.FileName)) { File.Delete(directory + "\\" + FL_SD.FileName); }

                FL_SD.SaveAs(directory + "\\" + FL_SD.FileName);
                if (File.Exists(directory + "\\" + FL_SD.FileName))
                    ViewState["Filepath"] = directory + FL_SD.FileName;
                else
                {
                    return;
                }

                string filename = Path.GetFileName(FL_SD.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FL_SD.PostedFile.FileName);
                var filelocation = ViewState["Filepath"];
                if (fileExtension == ".xls" || fileExtension == ".XLS")
                {
                    connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
                {
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + "; Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("please select the .xlsx/.xls file only.");

                    return;
                }

                OleDbConnection conn = new OleDbConnection(connStr);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = dtSheet.Rows[0]["table_name"].ToString();
                cmd.CommandText = "select * from [" + sheetName + "]";
                da.SelectCommand = cmd;
                da.Fill(dt);


                if ("EMAIL ADDRESS" == dt.Columns[0].ColumnName.ToUpper().Trim() && "EMPLOYEE ID" == dt.Columns[1].ColumnName.ToUpper().Trim())
                {
                    if (dt.Rows.Count > 0)
                    {
                        // ViewState["GV_TeacherDT"] = dt;
                        FillGrid(ref dt);
                        btnsubmitfile.Visible = true;
                        btnRolBack.Visible = true;
                        BtnUpload.Visible = false;
                        trTeacher.Visible = false;
                    }
                    else
                    {
                        ImpromptuHelper.ShowPrompt("Data no found");
                    }
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Invalid File Format");
                }
                conn.Close();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("please select the file.");
            }
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
    }
    protected void RadioListST_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridDataSummary.Visible = true;

        string SAction = "";
        if (RadioListST.SelectedValue == "S")
        {
            trSetupStudent.Visible = true;
            trSetupTeacher.Visible = false;
            SAction = "SDS";
            trTeacher.Visible = false;
            btnDownload.Visible = true;
            // tdFormat.Visible = true;
            BtnUpload.Visible = false;
            TrSession.Visible = true;
            lblHead.Text = "You've Chosen The Student";
            tbMainGV.Visible = false;
            btnRolBack.Visible = false;
            btnsubmitfile.Visible = false;
        }
        else if (RadioListST.SelectedValue == "T")
        {
            SAction = "TDS";
            trSetupStudent.Visible = false;
            if (GV_Teacher.Rows.Count > 0)
            {
                tbMainGV.Visible = true;
                TrSession.Visible = true;
                btnRolBack.Visible = true;
                btnsubmitfile.Visible = true;
                trSetupTeacher.Visible = false;
                trTeacher.Visible = false;
                trTeacher.Visible = false;
                BtnUpload.Visible = false;

            }
            else
            {
                BtnUpload.Visible = true;
                trSetupTeacher.Visible = true;
                trTeacher.Visible = true;
            }
            // tdFormat.Visible = false;
            btnDownload.Visible = false;
            TrSession.Visible = false;
            lblHead.Text = "You've Chosen The Teacher";
        }
        DataTable DT = ExecuteProcedureCentury(SAction, "");
        DT.Dispose();
        if (DT.Rows.Count > 0)
        {
            GV_Summary.DataSource = DT;
            GV_Summary.DataBind();
        }
    }
    DataTable ExecuteProcedure(string sSessionID, string SPName)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand(SPName);
        obj_Access.AddParameter("Session_Id", sSessionID, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    DataTable ExecuteProcedureCentury(string sAction, string sXMLD)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_CenturyTeacherUpload");
        obj_Access.AddParameter("P_XMLDataD", sXMLD.Replace("&nbsp;", ""), DataAccess.SQLParameterType.Clob, true);
        obj_Access.AddParameter("P_Session", ddlSession.SelectedValue, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DataTable temp_dt = null;
        if (RadioListST.SelectedValue == "S")
        {
            temp_dt = ExecuteProcedure(ddlSession.SelectedValue.ToString(), "Century_Export_Students");
            temp_dt.Dispose();
        }
        else if (RadioListST.SelectedValue == "T")
        {
            temp_dt = ExecuteProcedure(ddlSession.SelectedValue.ToString(), "Century_Export_Teachers");
            temp_dt.Dispose();
        }

        if (temp_dt.Rows.Count > 0)
        {
            GridView Exp_GV = new GridView();
            Exp_GV.AutoGenerateColumns = false;

            for (int i = 0; i < temp_dt.Columns.Count; i++)
            {
                BoundField obj_Bound = new BoundField();
                obj_Bound.DataField = temp_dt.Columns[i].ColumnName;
                obj_Bound.HeaderText = temp_dt.Columns[i].ColumnName;
                Exp_GV.Columns.Add(obj_Bound);
            }

            Exp_GV.DataSource = temp_dt;
            Exp_GV.DataBind();
            ExportGridToCSV(ref Exp_GV);
        }
        else { obj_Utility.MassageBox("No Data Found", ref UpdatePanel1); }
    }
    void ExportToExcel(ref GridView SrcGV)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Export_Data" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        SrcGV.GridLines = GridLines.Both;
        SrcGV.HeaderStyle.Font.Bold = true;
        SrcGV.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }
    private void ExportGridToCSV(ref GridView SrcGV)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Export_Data.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        SrcGV.AllowPaging = false;
        SrcGV.DataBind();
        StringBuilder columnbind = new StringBuilder();
        for (int k = 0; k < SrcGV.Columns.Count; k++)
        {
            columnbind.Append(SrcGV.Columns[k].HeaderText + ',');
        }
        columnbind.Append("\r\n");
        for (int i = 0; i < SrcGV.Rows.Count; i++)
        {
            for (int k = 0; k < SrcGV.Columns.Count; k++)
            {
                columnbind.Append(SrcGV.Rows[i].Cells[k].Text.Replace("&nbsp;", "") + ',');
            }
            columnbind.Append("\r\n");
        }
        Response.Output.Write(columnbind.ToString());
        Response.Flush();
        Response.End();
    }
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        File_Upload();
    }
    protected void btnRolBack_Click(object sender, EventArgs e)
    {
        try
        {
            if (GV_Teacher.Rows.Count > 0)
            {
                // ViewState["GV_TeacherDT"] = null;
                tbMainGV.Visible = false;
                GV_Teacher.DataSource = null;
                GV_Teacher.DataBind();
                GV_Teacher.Dispose();
                BtnUpload.Visible = true;
                trTeacher.Visible = true;
                btnsubmitfile.Visible = false;
                btnRolBack.Visible = false;
                ImpromptuHelper.ShowPrompt("Record Successfully Roll back");
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Data not Found");
            }
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
    }
    //protected void GV_Teacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        GV_Teacher.PageIndex = e.NewPageIndex;
    //        GV_Teacher.DataSource = (DataTable)ViewState["GV_TeacherDT"];
    //        GV_Teacher.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);

    //    }

    //}
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/presentationlayer/frmCentury.aspx", false);

    }
    protected void btnsubmitfile_Click(object sender, EventArgs e)
    {
        try
        {
            string sXMLD = "<TeacherData>";

            if (GV_Teacher.Rows.Count > 0)
            {
                for (int x = 0; x < GV_Teacher.Rows.Count; x++)
                {
                    sXMLD += "<Row>";
                    sXMLD += "<EmailAddress>" + GV_Teacher.Rows[x].Cells[1].Text.Trim() + "</EmailAddress>";
                    sXMLD += "<EmployeeID>" + GV_Teacher.Rows[x].Cells[2].Text.Trim() + "</EmployeeID>";
                    sXMLD += "</Row>";
                }

            }
            sXMLD += "</TeacherData>";

            DataTable DT = ExecuteProcedureCentury("I", sXMLD);
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {
                btnsubmitfile.Visible = false;
                // ViewState["GV_TeacherDT"] = null;
                tbMainGV.Visible = false;
                GV_Teacher.DataSource = null;
                GV_Teacher.DataBind();
                GV_Teacher.Dispose();
                btnDownload.Visible = true;
                // tdFormat.Visible = true;
                TrSession.Visible = true;
                btnRolBack.Visible = false;
            }
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
    }
    protected void GV_Summary_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GV_Summary.Rows.Count > 0)
            {
                GV_Summary.UseAccessibleHeader = false;
                GV_Summary.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void GV_Teacher_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GV_Teacher.Rows.Count > 0)
            {
                GV_Teacher.UseAccessibleHeader = false;
                GV_Teacher.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}