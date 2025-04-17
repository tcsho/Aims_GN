using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADG.JQueryExtenders.Impromptu;
using System.IO;
using System.Text;
using System.Data.OleDb;
//using GleamTech.Reflection;

public partial class PresentationLayer_TCS_GLResultUpload : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnSave.Click += btnSave_Click;
        btnSave.OnClientClick = @"return getConfirmationValue();";
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btnExport);

        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (!Page.IsPostBack)
            {
                btnExport.Enabled = false;
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                GridView1.DataSource = null;
                btnSave.Visible = false;
                ddlSession.Visible = false;
                listTermGroup.Visible = false;
                lblSession.Visible = false;
                lblTG.Visible = false;
                bindTermGroupList();
                FillActiveSessions();

            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            BLLGL objClass = new BLLGL();
            btnExport.Enabled = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void bindTermGroupList()
    {
        try
        {

            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, listTermGroup, "TermGroup_Id", "Type");
            //listTermGroup.SelectedValue = "2";
            //ddlTerm.SelectedIndex = 1;
            //}

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
            //ddlSession.SelectedValue = "11";
            //BindCheckBoxListControl(dt, lstSessions, "Session_ID", "Description");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            bindTermGroupList();
            FillActiveSessions();
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnSave.Visible = false;
            ddlSession.Visible = false;
            listTermGroup.Visible = false;
            lblSession.Visible = false;
            lblTG.Visible = false;
            lblsessionerror.Visible = false;
            lbltermgrouperror.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text, 0);
            }
            
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
            bool type = false;
            if (hfWasConfirmed.Value == "true")
            {
                //If clicks OK button


                lbltermgrouperror.Visible = false;
                lblsessionerror.Visible = false;
                if (ddlSession.SelectedValue == "0")
                {
                    lblsessionerror.Visible = true;
                }
                if (listTermGroup.SelectedValue == "0")
                {
                    lbltermgrouperror.Visible = true;
                }
                else if (ddlSession.SelectedValue != "0" && listTermGroup.SelectedValue != "0")
                {
                    BLLGLResult GLObject = new BLLGLResult();

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        GLObject.Student_Id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                        GLObject.TestName = GridView1.Rows[i].Cells[0].Text.ToString();
                        GLObject.StandardAgeScore = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                        GLObject.OverallStanine = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                        if (GLObject.TestName.Substring(0, 3) != "PTE")
                        {
                            GLObject.PercentileRank = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                        }
                        GLObject.SessionID = Convert.ToInt32(ddlSession.SelectedValue);
                        GLObject.TermGroupID = Convert.ToInt32(listTermGroup.SelectedValue);

                        GLObject.GLResultAdd(GLObject);
                    }
                    string message = "GL Result Data have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnSave.Visible = false;
                    ddlSession.Visible = false;
                    listTermGroup.Visible = false;
                    lblSession.Visible = false;
                    lblTG.Visible = false;
                    bindTermGroupList();
                    FillActiveSessions();
                    //MsgBox("Result data save successfully!!");
                    //ImpromptuHelper.ShowPromptGeneric("Student(s) Result successfully Add.",01);
                    lblsessionerror.Visible = false;
                    lbltermgrouperror.Visible = false;
                }

            }
            else
            {
                //If clicks CANCEL button
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.")
            {
                string message = "Please provide proper excel file some date is missing!!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                //Session["error"] = "Please provide proper excel file some column is missing!!";
                //Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
            else
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }

    }

    private void MsgBox(string sMessage)
    {
        string msg = "<script language=\"javascript\">";
        msg += "alert('" + sMessage + "');";
        msg += "</script>";
        Response.Write(msg);
    }

    private void Import_To_Grid(string FilePath, string Extension, string isHDR, int check)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dtname = new DataTable();
            string strTestName = "";

            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT [Test Name] From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dtname);

            //for (int i = 0; i < dtname.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtname.Columns.Count; j++)
            //    {
            strTestName = dtname.Rows[0].ItemArray[0].ToString();
            //    }
            //}

            strTestName = strTestName.Substring(0, 3);

            if (strTestName.Substring(0, 3) == "PTE")
            {
                cmdExcel.CommandText = "SELECT [Test Name],[Student ID],[Standard Age Score],[Overall Stanine],'' as [Percentile Rank] From [" + SheetName + "]";
            }
            else
            {
                cmdExcel.CommandText = "SELECT [Test Name],[Student ID],[Standard Age Score],[Overall Stanine],[Percentile Rank] From [" + SheetName + "]";
            }
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            if (check == 0)
            {
                BindGrid(FilePath, dt);
            }
            btnSave.Visible = true;
            ddlSession.Visible = true;
            listTermGroup.Visible = true;
            lblSession.Visible = true;
            lblTG.Visible = true;
        }
        catch (Exception ex)
        {
            string message = "Please provide proper .xlsx extension file.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

            //Session["error"] = ex.Message;
            //Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);

        }
    }
    private void BindGrid(string FilePath, DataTable dt)
    {
        //Bind Data to GridView
        GridView1.Caption = Path.GetFileName(FilePath);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FileName = GridView1.Caption;
            string Extension = Path.GetExtension(FileName);
            string FilePath = Server.MapPath(FolderPath + FileName);

            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text, 0);
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void but_export_Click(object sender, EventArgs e)
    {
        try
        {
            ////////Export to Word//////////////
            //Response.Clear();

            //Response.Buffer = true;

            //Response.AddHeader("content-disposition",

            //"attachment;filename=GridViewExport.doc");

            //Response.Charset = "";

            //Response.ContentType = "application/vnd.ms-word ";

            //StringWriter sw = new StringWriter();

            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //dg_class.AllowPaging = false;

            //dg_class.RenderControl(hw);

            //Response.Output.Write(sw.ToString());

            //Response.Flush();

            //Response.End();


            ////////Export to Excel//////////////
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            //"attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //dg_class.AllowPaging = false;
            ////Change the Header Row back to white color
            //dg_class.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Apply style to Individual Cells
            //dg_class.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //dg_class.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //dg_class.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //for (int i = 0; i < dg_class.Rows.Count; i++)
            //{
            //    GridViewRow row = dg_class.Rows[i];
            //    //Change Color back to white
            //    row.BackColor = System.Drawing.Color.White;
            //    //Apply text style to each Row
            //    row.Attributes.Add("class", "textmode");
            //    //Apply style to Individual Cells of Alternating Row
            //    if (i % 2 != 0)
            //    {
            //        row.Cells[0].Style.Add("background-color", "#C2D69B");
            //        row.Cells[1].Style.Add("background-color", "#C2D69B");
            //        row.Cells[2].Style.Add("background-color", "#C2D69B");
            //    }
            //}
            //dg_class.RenderControl(hw);
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            ////style to format numbers to string
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();

            ////////Export to CSV//////////////
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GLData.csv");
            //Response.Charset = "";
            //Response.ContentType = "application/text";
            //dg_class.AllowPaging = false;

            //StringBuilder sb = new StringBuilder();
            //for (int k = 0; k < dg_class.Columns.Count; k++)
            //{
            //    //add separator
            //    sb.Append(dg_class.Columns[k].HeaderText + ',');
            //}
            ////append new line
            //sb.Append("\r\n");

            //for (int i = 0; i < dg_class.Rows.Count; i++)
            //{
            //    for (int k = 0; k < dg_class.Columns.Count; k++)
            //    {
            //        //add separator
            //        sb.Append(dg_class.Rows[i].Cells[k].Text + ',');
            //    }
            //    //append new line
            //    sb.Append("\r\n");
            //}
            //Response.Output.Write(sb.ToString());
            //Response.Flush();
            //Response.End();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}
