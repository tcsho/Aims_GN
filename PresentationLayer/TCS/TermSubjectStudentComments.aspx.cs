using ADG.JQueryExtenders.Impromptu;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_TermSubjectStudentComments : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    static DataTable dd = new DataTable();
    //BLLAdmTest obj = new BLLAdmTest();

    BLLEvaluation_Criteria_StudentCommentsBank obj = new BLLEvaluation_Criteria_StudentCommentsBank();

    BLLAdmTestDetail objDetail = new BLLAdmTestDetail();

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
                // ======== Page Access Settings ========================//
                //DALBase objBase = new DALBase();
                //DataRow row = (DataRow)Session["rightsRow"];
                //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                //string sRet = oInfo.Name;


                //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                //{
                //    Session.Abandon();
                //    Response.Redirect("~/login.aspx", false);
                //}

                //  ====== End Page Access settings ======================//
                loadRegions();
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

    }

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
            obj.Region_Id = Convert.ToInt32(list_region.SelectedValue);
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

    }


    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindReGrid();

    }
    protected void list_term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            //ViewState["Data"] = null;
            //BindGrid();

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
            //foreach (DataRow r in dt.Rows)
            //{
            //    if (r["Status_Id"].ToString() == "1")
            //    {
            //        ddlSession.SelectedValue = r["Session_Id"].ToString();
            //        ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
            //        break;
            //    }
            //}
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
            obj.CommCat_Id = Convert.ToInt32(ddlCommentCat.SelectedValue);


            if (ViewState["Mode"].ToString() == "Add")
            {
                obj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                obj.CreatedOn = DateTime.Now;
                k = obj.Evaluation_Criteria_StudentCommentsBankAdd(obj);

            }
            if (ViewState["Mode"].ToString() == "Edit")
            {
                obj.ComBank_Id = Convert.ToInt32(ViewState["ComBank_Id"].ToString());
                obj.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                obj.ModifiedOn = DateTime.Now;

                k = obj.Evaluation_Criteria_StudentCommentsBankUpdate(obj);

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

            if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlClass.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            {
                ViewState["Mode"] = "Add";
                ddlCommentCat.SelectedIndex = 0;
                txtTestName.Text = string.Empty;
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


                GridTitleAns.Visible = false;
                Gridtitle.Visible = false;
                GridTestTitle.Visible = false;
                divTestButtons.Visible = false;


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

            if (ddlClass.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlSession.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                obj.Subject_Id = Convert.ToInt32(ddlsubject.SelectedValue);

                btnAddTest.Visible = true;
                //btnextpdf.Visible = true;


                if (ViewState["Data"] == null)
                {
                    dt = obj.Evaluation_Criteria_StudentCommentsBankSelectByParam(obj);
                    ViewState["Data"] = dt;
                }
                else
                {
                    dt = (DataTable)ViewState["Data"];
                }
            }

            if (dt.Rows.Count > 0)
            {
                gvStaticComments.DataSource = dt;
                dd = dt;
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
            obj.ComBank_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["ComBank_Id"] = obj.ComBank_Id;

            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvStaticComments.SelectedIndex = gvr.RowIndex;

            txtTestName.Text = gvr.Cells[8].Text;
            ddlCommentCat.SelectedValue = gvr.Cells[5].Text;



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

            objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void extpdf_Click(object sender, EventArgs e)
    {
        if (dd.Rows.Count > 0)
        {
            int pdfRowIndex = 1;
            string downloadsfolder = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            string filename = ddlSession.SelectedValue + ddlClass.SelectedValue + ddlsubject.SelectedValue;
            string filepath = Server.MapPath("\\") + "" + filename + ".pdf";
            Document document = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
            Font font2 = FontFactory.GetFont(FontFactory.COURIER, 8);

            float[] columnDefinitionSize = { 2F, 5F, 2F, 5F };
            PdfPTable table;
            PdfPCell cell;

            table = new PdfPTable(columnDefinitionSize)
            {
                WidthPercentage = 100
            };

            cell = new PdfPCell
            {
                BackgroundColor = new BaseColor(0xC0, 0xC0, 0xC0)
            };

            table.AddCell(new Phrase("ProductId", font1));
            table.AddCell(new Phrase("ProductName", font1));
            table.AddCell(new Phrase("Price", font1));
            table.AddCell(new Phrase("ProductDescription", font1));
            table.HeaderRows = 1;

            foreach (DataRow data in dd.Rows)
            {
                table.AddCell(new Phrase(data[0].ToString(), font2));
                table.AddCell(new Phrase(data[1].ToString(), font2));
                table.AddCell(new Phrase(data[2].ToString(), font2));
                table.AddCell(new Phrase(data[3].ToString(), font2));

                pdfRowIndex++;
            }

            document.Add(table);
            document.Close();
            document.CloseDocument();
            document.Dispose();
            writer.Close();
            writer.Dispose();
            fs.Close();
            fs.Dispose();

            FileStream sourceFile = new FileStream(filepath, FileMode.Open);
            float fileSize = 0;
            fileSize = sourceFile.Length;
            byte[] getContent = new byte[Convert.ToInt32(Math.Truncate(fileSize))];
            sourceFile.Read(getContent, 0, Convert.ToInt32(sourceFile.Length));
            sourceFile.Close();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Length", getContent.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + ".pdf;");
            Response.BinaryWrite(getContent);
            Response.Flush();
        }
        else
        {

        }
    }
}