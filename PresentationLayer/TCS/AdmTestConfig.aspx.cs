using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
 
public partial class PresentationLayer_TCS_AdmTestConfig : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    BLLAdmTest obj = new BLLAdmTest();
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
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx", false);
                }

              //  ====== End Page Access settings ======================//
                FillActiveSessions();
                BindGrid();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
                if (Session["Session"] != null && Session["Class"] != null && Session["TestType"] != null)
                {
                    ddlSession.SelectedValue = Session["Session_Id"].ToString();
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlClass.SelectedValue = Session["Class_Id"].ToString();
                    ddlClass_SelectedIndexChanged(this, EventArgs.Empty);
                    
                    chkTestType.SelectedValue = Session["TestType_Id"].ToString();
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
        try
        {
            FillClass();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            ViewState["Data"] = null;
            BindGrid();
            chkTestType.Enabled = true;
            FillTestType();
            //btnEnglish.CssClass = btnEnglish.CssClass.Replace("active", "").Trim();
            //BtnUrdu.CssClass = BtnUrdu.CssClass.Replace("active", "").Trim();
            //BtnMaths.CssClass = BtnMaths.CssClass.Replace("active", "").Trim();
            //btnScience.CssClass = btnScience.CssClass.Replace("active", "").Trim();
        
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
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void FillTestType()
    {
        try
        {
            DataTable dt = obj.AdmTestFetchTestType(obj);
            chkTestType.DataSource = dt;
            chkTestType.DataTextField = "Description";
            chkTestType.DataValueField = "TestType_Id";
            chkTestType.DataBind();
            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);

            dt = obj.AdmTestFetchTestType(obj);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (Convert.ToInt32(r["flag"].ToString()) == 1)
                    {
                        chkTestType.SelectedValue = r["TestType_Id"].ToString();
                        break;
                    }
                }
                //btnDeleteTest.Visible = true;
                //btnAddTest.Visible = true;
                chkTestType_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                if (chkTestType.Enabled == true)
                {
                    btnDeleteTest.Visible = false;
                    btnAddTest.Visible = true;
                }
                chkTestType.Enabled = true;
            }
            objBase.FillDropDown(dt, chkTestType, "TestType_Id", "Description");
            //chkTestType.DataSource = dt;
            //chkTestType.DataTextField = "Description";
            //chkTestType.DataValueField = "TestType_Id";
            //chkTestType.DataBind();
         
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void FillPool()
    {
        try
        {
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
            DataTable dt = new DataTable();
            obj.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
            dt = obj.AdmTestQuestionsPoolFetch(obj.AdmTestDetail_Id);
            //objBase.FillDropDown(dt, ddlPool, "Pool_Id", "Description");

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
            foreach(DataRow r in dt.Rows)
            {
                if (r["Status_Id"].ToString() == "1")
                {
                    ddlSession.SelectedValue = r["Session_Id"].ToString();
                    ddlSession_SelectedIndexChanged(this, EventArgs.Empty);
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
            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();
            //dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 14).CopyToDataTable();
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
            Session["TestType_Id"] = chkTestType.SelectedValue;
            Session["TestTypeDesc"] = chkTestType.SelectedItem.Text;
            Response.Redirect("~/PresentationLayer/TCS/AdmTestAssignCenters.aspx", false);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    #region 'Test'
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int k = 0;

            obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            obj.AdmTestType_Id = Convert.ToInt32(chkTestType.SelectedValue);
            if (ViewState["Mode"].ToString() == "Add")
            {
                obj.CreatedBy = Convert.ToInt32(Session["ContactID"].ToString());
                k = obj.AdmTestAdd(obj);
            }
            if (ViewState["Mode"].ToString() == "Edit")
            {
                obj.Title = txtTestName.Text;
                
                obj.PublishStatus_ID = 1;
                objDetail.TotalMarks = Convert.ToDecimal(txtMarks.Text);
                obj.ModifiedBy = Convert.ToInt32(Session["ContactID"].ToString());
                objDetail.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());
                objDetail.TestDesc = txtTestName.Text+ " Description";
                obj.AdmTest_Id = Convert.ToInt32(ViewState["AdmTest_Id"].ToString());
                k = obj.AdmTestUpdate(obj, objDetail);
                ViewState["Data"] = null;
                BindGrid();
            }
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Cannot apply changes!");
            }
              btnCancel_Click(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";

            if (ddlClass.SelectedIndex > 0 && chkTestType.SelectedIndex > -1)
            {
                 
                ViewState["Mode"] = "Add";
                btnSave_Click(this, EventArgs.Empty);

            }
            else
                ImpromptuHelper.ShowPrompt("Please Select a Class");
            ViewState["Data"] = null;
            BindGrid();
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

            if (chkTestType.SelectedIndex > -1)
            {
                ViewState["Mode"] = "Delete";
                BLLAdmTest obj = new BLLAdmTest();
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.AdmTestType_Id = Convert.ToInt32(chkTestType.SelectedValue);
                int k = obj.AdmTestDelete(obj);
                //if (k == 1)
                //    ImpromptuHelper.ShowPrompt("Cannot incorporate changes!");
                ViewState["Data"] = null;
                BindGrid();

                gvQuestions.DataSource = null;
                gvQuestions.DataBind();
                gvAnswerList.DataSource = null;
                gvAnswerList.DataBind();
                GridTitleAns.Visible = false;
                Gridtitle.Visible = false;
                GridTestTitle.Visible = false;
                divTestButtons.Visible = false;
               
                divPoolConf.Visible = false;
                FillTestType();
                chkTestType.Enabled = true;
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
            gvTest.DataSource = null;
            gvTest.DataBind();
            GridTestTitle.Visible = false;
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            Gridtitle.Visible = false;
            GridTitleAns.Visible = false;
            if (ddlClass.SelectedIndex > 0)
                obj.Class_Id = Convert.ToInt32(ddlClass.SelectedValue);
            if (ddlSession.SelectedIndex > 0)
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            if (chkTestType.SelectedIndex > -1)
                obj.AdmTestType_Id = Convert.ToInt32(chkTestType.SelectedValue);
            else
                return;
            DataTable dt = new DataTable();
            if (ViewState["Data"] == null)
            {
                dt = obj.AdmTestFetch(obj);
                ViewState["Data"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["Data"];
            }
            if (dt.Rows.Count > 0)
            {
                PopulateTreeView(dt , null);
                btnAddTest.Visible = false;
                btnDeleteTest.Visible = true;
                btnAssignCenters.Visible = true;
                if (dt.Rows[0]["AdmTestType_Id"].ToString() == "3")//Manual Entry by Campus Officer
                {
                    ViewState["TestType"] = null;
                    
                    divTestButtons.Visible = false;
                    divPoolConf.Visible = false;
                    GridTestTitle.Visible = true;
                    gvTest.DataSource = dt;
                    gvTest.DataBind();
                }
               
                else   //Adaptive 
                {
                    trvw_test.Nodes.Clear();
                    PopulateTreeView(dt, null);
                    divTestButtons.Visible = true;
                }
            }
            else if (dt.Rows.Count == 0)
            {
                btnAssignCenters.Visible = false;
                btnAddTest.Visible = true;
                btnDeleteTest.Visible = false;
                divPoolConf.Visible = false;
                divTestButtons.Visible = false;
               
                gvAnswerList.DataSource = null;
                gvAnswerList.DataBind();
                gvQuestions.DataSource = null;
                gvQuestions.DataBind();
                gvTest.DataSource = null;
                gvTest.DataBind();
                GridTestTitle.Visible = false;
                GridTitleAns.Visible = false;
                Gridtitle.Visible = false;
            }
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
            
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
            if (gvTest.Rows.Count > 0)
            {
                gvTest.UseAccessibleHeader = false;
                gvTest.HeaderRow.TableSection = TableRowSection.TableHeader;

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
            ddlClass.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            ViewState["Mode"] = "Edit";
            LinkButton btnEdit = (LinkButton)(sender);
            obj.AdmTest_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["AdmTest_Id"] = obj.AdmTest_Id;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvTest.SelectedIndex = gvr.RowIndex;
            txtTestName.Text = gvr.Cells[5].Text+ " - "+ gvr.Cells[8].Text;
            txtMarks.Text = gvr.Cells[11].Text;
            txtTotal.Text = gvr.Cells[13].Text;
            ViewState["AdmTestDetail_Id"] = gvr.Cells[3].Text;
            btnCancelAnswer_Click(this, EventArgs.Empty);
            btnCancelQuestion_Click(this, EventArgs.Empty);
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            Gridtitle.Visible = false;
            GridTitleAns.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void PopulateTreeView(DataTable dtParent, TreeNode treeNode)
    {
        int i = 0;
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode n = new TreeNode();
            n.Value = row["AdmTestDetail_Id"].ToString();
            n.Text = row["AdmTestName"].ToString();
            trvw_test.Nodes.Add(n);
            
            DataTable dtChild = new DataTable();
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
            obj.AdmTestDetail_Id = Convert.ToInt32(row["AdmTestDetail_Id"].ToString());
            dtChild = obj.AdmTestQuestionPoolFetch(obj);
            foreach (DataRow r in dtChild.Rows)
            { 
                TreeNode child = new TreeNode
                {
                    Text = r["Description"].ToString(),
                    Value = r["Pool_Id"].ToString()
                };
                child.SelectAction = TreeNodeSelectAction.Select;
                trvw_test.Nodes[i].ChildNodes.Add(child);
            }
            i++;

        }
    }
    protected void trvw_test_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (trvw_test.SelectedNode.Parent == null)
            return;
            if (trvw_test.SelectedNode.Parent != null)
        {
            ViewState["AdmTestDetail_Id"] = trvw_test.SelectedNode.Parent.Value;
            ViewState["pool"] = null;
            BindgvPool();
        }
        btnPool_Click(Convert.ToInt16(trvw_test.SelectedNode.Value));
        GridTitleAns.Visible = false;
        
    }
    #endregion
    #region 'Pool'
    protected void btnShowPool_Click(object sender, EventArgs e)
    {
        try
        {
            //btnEnglish.CssClass = btnEnglish.CssClass.Replace("active", "").Trim();
            //BtnUrdu.CssClass = BtnUrdu.CssClass.Replace("active", "").Trim();
            //BtnMaths.CssClass = BtnMaths.CssClass.Replace("active", "").Trim();
            //btnScience.CssClass = btnScience.CssClass.Replace("active", "").Trim();
            if (ViewState["TestType"]!=null && ViewState["TestType"].ToString() == "Non-Adaptive")
            {
                gvQuestions.DataSource = null;
                gvQuestions.DataBind();
                gvAnswerList.DataSource = null;
                gvAnswerList.DataBind();
                ViewState["pool"] = ViewState["Data"];
 
                return;
            }
            
            LinkButton btnEdit = (LinkButton)(sender);
            btnEdit.CssClass = btnEdit.CssClass + " active";
            ViewState["AdmTestDetail_Id"] = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["pool"] = null;
            BindgvPool();

            divPoolConf.Visible = false;
          
            
            GridTestTitle.Visible = false;
            Gridtitle.Visible = false;
            GridTitleAns.Visible = false;
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            lblGridStatus.Visible = false;
           
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindgvPool()
    {
        try
        {
            BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
           
            ViewState["AdmTestDetail_Id"] = trvw_test.SelectedNode.Parent.Value;
            obj.AdmTestDetail_Id = Convert.ToInt32(ViewState["AdmTestDetail_Id"].ToString());

            DataTable dt = new DataTable();
            if (ViewState["pool"] == null)
            {
                dt = obj.AdmTestQuestionPoolFetch(obj);
                ViewState["pool"] = dt;
            }
            else
                dt = (DataTable)ViewState["pool"];            
        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancelPool_Click(object sender, EventArgs e)
    {
        try
        {
            //divEditPool.Visible = false;
            BindQuestion();
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnPool_Click(int val)
    {
        lblGridStatus.Visible = false;
        ResetFilterPool();
        ViewState["Pool_Id"] = val;
        divPoolConf.Visible = true;
        BindQuestion();
        GridTestTitle.Visible = false;
        ViewState["QuestionId"] = null;
        gvAnswerList.DataSource = null;
        gvAnswerList.DataBind();
        btnAddQuestion.CommandArgument = val.ToString();
        btnEditPool.CommandArgument = val.ToString();
        btnViewPoolConfig.CommandArgument = val.ToString();
        btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
        btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
        btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
    }
    protected void btnEditPool_Click(object sender, EventArgs e)
    {
        try
        {
           
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass + " active";
            lblGridStatus.Visible = false;
           
            
            ViewState["mode"] = "EditPool";
            LinkButton btn = (LinkButton)(sender);
            ViewState["Pool_Id"] = btn.CommandArgument;
            //divEditPool.Visible = true;
            DataTable dt = new DataTable();

            if (ViewState["pool"] != null)
            {
                ResetFilterPool();
                ApplyPoolFilter(1, Convert.ToInt32(ViewState["Pool_Id"].ToString()));
                dt = (DataTable)ViewState["filteredpool"];
                txtMarksQuestion.Text = dt.Rows[0]["MarksPerQuestion"].ToString();
                txtTotal.Text = dt.Rows[0]["MinQuest"].ToString();
                txtAnsInSec.Text = dt.Rows[0]["TimeInSeconds"].ToString();
               // divPoolTitle.InnerText = "Edit  Test Configuration";
                txtAnsInSec.Enabled = true;
                txtTotal.Enabled = true;
                txtMarksQuestion.Enabled = true;
                btnSavepool.Visible = true;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnViewPool_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            lblGridStatus.Visible = false;
           
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass + " active";

            ViewState["mode"] = "EditPool";
            LinkButton btn = (LinkButton)(sender);
            ViewState["Pool_Id"] = btn.CommandArgument;
            DataTable dt = new DataTable();

            if (ViewState["pool"] != null)
            {
                ApplyPoolFilter(1, Convert.ToInt32(ViewState["Pool_Id"].ToString()));
                dt = (DataTable)ViewState["filteredpool"];
                txtMarksQuestion.Text = dt.Rows[0]["MarksPerQuestion"].ToString();
                txtTotal.Text = dt.Rows[0]["MinQuest"].ToString();
                txtAnsInSec.Text = dt.Rows[0]["TimeInSeconds"].ToString();
                //divPoolTitle.InnerText = "View  Test Configuration";
                txtAnsInSec.Enabled = false;
                txtTotal.Enabled = false;
                txtMarksQuestion.Enabled = false;
                btnSavepool.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ApplyPoolFilter(int _FilterCondition, int value)
    {
        try
        {

            if (ViewState["pool"] != null)
            {

                DataView dv;
                DataTable dt = (DataTable)ViewState["pool"];
                dv = dt.DefaultView;
                string strFilter = "";
                switch (_FilterCondition)
                {
                    case 1: // 9 Olevels Stream
                        {

                            strFilter = "Pool_Id = " + value ;
                            break;
                        }
                }
                dv.RowFilter = strFilter;
                DataTable filtered = dt.Clone();

                //fill the clone with the filtered rows
                foreach (DataRowView drv in dt.DefaultView)
                {
                    filtered.Rows.Add(drv.Row.ItemArray);
                }
              
                ViewState["filteredpool"] = filtered;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void ResetFilterPool()
    {
        try
        {
             BindgvPool();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnSavePool_Click(object sender, EventArgs e)
    {
        try
        {
            int k = -1;
            if (ViewState["mode"].ToString() == "EditPool")
            {
                BLLAdmTestQuestionPool obj = new BLLAdmTestQuestionPool();
                obj.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"]);
                obj.MarksPerQuestion = Convert.ToDecimal(txtMarksQuestion.Text);
                obj.TimeInSeconds = Convert.ToInt32(txtAnsInSec.Text);
                obj.MinQuest = Convert.ToInt32(txtTotal.Text);
                k = obj.AdmTestQuestionPoolUpdate(obj);
            }
            if (k == 1)
                ImpromptuHelper.ShowPrompt("Cannot Incorporate changes!");
          
            btnCancelPool_Click(this, EventArgs.Empty);
            ViewState["pool"] = null;
            if (ViewState["TestType"] != null && ViewState["TestType"].ToString() == "Non-Adaptive")
            {
                ViewState["Data"] = null;
                BindGrid();
                ViewState["pool"] = ViewState["Data"];
                divPoolConf.Visible = true;

            }
            else
                BindgvPool();
            BindQuestion();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    #endregion
    #region 'Question'
    protected void gvQuestions_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvQuestions.Rows.Count > 0)
            {
                gvQuestions.UseAccessibleHeader = false;
                gvQuestions.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindQuestion()
    {
        try
        {
            BLLAdmTestQuestions objClsSec = new BLLAdmTestQuestions();
            DataTable dtsub = new DataTable();
            if (ViewState["Pool_Id"] != null)
                objClsSec.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"].ToString());
            else
                return;
            dtsub = (DataTable)objClsSec.AdmTestQuestionsSelectAllByAdmTestDetailId(objClsSec);

            if (dtsub.Rows.Count > 0)
            {
                gvQuestions.DataSource = dtsub;
                Gridtitle.Visible = true;
                Gridtitle.InnerText = "Question List";
                lblGridStatus.Visible = false;
            }

            else
            {
                lblGridStatus.Visible = true;
                Gridtitle.Visible = false;
                Gridtitle.InnerText = "";
                GridTitleAns.Visible = false;

            }
            gvQuestions.DataBind();
            ViewState["tMood"] = "check";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAddQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            imgAnswer.Visible = true;
            lblError.Text = "";
            lblGridStatus.Visible = false;
            btnAddQuestion.CssClass = btnAddQuestion.CssClass + " active";
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
          
            ViewState["Mode"] = "AddQuestion";
            LinkButton btnEdit = (LinkButton)(sender);
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions();
            obj.Pool_Id = Convert.ToInt32(btnEdit.CommandArgument);
            ResetFilterPool();
            ApplyPoolFilter(1, obj.Pool_Id);
            DataTable dt = (DataTable)ViewState["filteredpool"];
            
            if (dt.Rows.Count > 0)
            {
                if(Convert.ToDecimal(dt.Rows[0]["MarksPerQuestion"].ToString())<=0)
                {
                    ImpromptuHelper.ShowPrompt("Please Update Pool Configuration first");
                    return;
                }
                txtPValue.Text = dt.Rows[0]["MarksPerQuestion"].ToString();
                lblPooldesc.Text = dt.Rows[0]["AdmTestName"].ToString() + " " + dt.Rows[0]["Description"].ToString();
            }
           // divQuestion.Visible = true;
            txtNValue.Text = "";
            txtQuestion.Text = "";
            txtComments.Text = "";
            lblAnnswer.Visible = true;
            txtAddAnswer.Visible = true;
            txtAddAnswer.Text = "";
            txtAddAnswer.Rows = 5;
            txtAddAnswer.MaxLength = 500;
            txtAddAnswer.TextMode = TextBoxMode.MultiLine;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalQuestion();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnEditQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            imgAnswer.Visible = false;
            GridTestTitle.Visible = false;
            ViewState["Mode"] = "EditQuestion";
            LinkButton btnEdit = (LinkButton)(sender);
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions();
            obj.Quest_ID = Convert.ToInt32(btnEdit.CommandArgument);
            ViewState["Quest_ID"] = obj.Quest_ID;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            gvQuestions.SelectedIndex = gvr.RowIndex;
            txtQuestion.Focus();  
            txtQuestion.Text = gvr.Cells[3].Text;
            txtPValue.Text = gvr.Cells[4].Text;
            txtNValue.Text = gvr.Cells[5].Text;
            txtComments.Text = gvr.Cells[6].Text;
            txtAnsInSec.Text = gvr.Cells[7].Text;
            ViewState["AdmTestDetail_Id"] = gvr.Cells[1].Text;
            lblPooldesc.Text = gvr.Cells[12].Text;
            lblAnnswer.Visible = false;
            txtAddAnswer.Visible = false;
            FillPool();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalQuestion();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnDeleteQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            //divQuestion.Visible = false;
            ViewState["Mode"] = "DeleteQuestion";
            LinkButton btnEdit = (LinkButton)(sender);
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions();
            obj.Quest_ID = Convert.ToInt32(btnEdit.CommandArgument);
            int AlreadyIn = obj.AdmTestQuestionsDelete(obj);
            if (AlreadyIn == 0)
            {
                ImpromptuHelper.ShowPrompt("Deleted");

            }

            ViewState["Data"] = null;
            
            BindQuestion();
            gvAnswerList.DataSource = null;
            gvAnswerList.DataBind();
            GridTitleAns.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnShowAnswer_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)(sender);
            string QuestionId = btn.CommandArgument;
            ViewState["QuestionId"] = QuestionId;
            BindAnswerGrid();
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnSaveQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            BLLAdmTestQuestions obj = new BLLAdmTestQuestions(); int k = -1;
            if (txtQuestion.Text.Length >= 500 || txtAddAnswer.Text.Length >= 500  || txtComments.Text.Length >= 100)
            {
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalQuestion();", true);
                lblError.Text = "Your text exceeds the available limit!";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            obj.AnsPointValue = Convert.ToDecimal(txtPValue.Text);
            if (!String.IsNullOrEmpty(txtNValue.Text))
                obj.NegtvPointValue = Convert.ToDecimal(txtNValue.Text);
            else
                obj.NegtvPointValue = 0;
            obj.QuesText = txtQuestion.Text;
            obj.Comments = "Comments";
            obj.Pool_Id = Convert.ToInt32(ViewState["Pool_Id"].ToString());

            if (ViewState["Mode"].ToString() == "AddQuestion")
            {
                k = obj.AdmTestQuestionsAdd(obj);
                ViewState["QuestionId"] = k;
                ViewState["mode"] = "Add";
                btnAnswerSave_Click(this, EventArgs.Empty);
                ViewState["dtDetails"] = null;
                BindAnswerGrid();
            }
            else if (ViewState["Mode"].ToString() == "EditQuestion")
            {
                obj.Quest_ID = Convert.ToInt32(ViewState["Quest_ID"].ToString());
                k = obj.AdmTestQuestionsUpdate(obj);
            }
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("You cannot change questions!");
            }
            ViewState["Pool_Id"] = obj.Pool_Id;
            btnCancelQuestion_Click(this, EventArgs.Empty);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalQuestion();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnCancelQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            //divQuestion.Visible = false;
            txtAnsInSec.Text = "";
            txtComments.Text = "";
            txtNValue.Text = "";
            txtPValue.Text = "";
            txtQuestion.Text = "";
            BindQuestion();
            btnAddQuestion.CssClass = btnAddQuestion.CssClass.Replace("active", "").Trim();
            btnEditPool.CssClass = btnEditPool.CssClass.Replace("active", "").Trim();
            btnViewPoolConfig.CssClass = btnViewPoolConfig.CssClass.Replace("active", "").Trim();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    #endregion
    #region 'Answer'
    protected void btnCancelAnswer_Click(object sender, EventArgs e)
    {
        try
        {
           
            BindQuestion();
            BindAnswerGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    private void BindAnswerGrid()
    {
        try
        {
            BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();
            DataTable dtsub = new DataTable();
            if (ViewState["QuestionId"] == null)
                return;
            objClsSec.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);


            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.AdmTestQuestionsDetailSelectAllByQuestId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                lblGridStatus.Visible = false;
                gvAnswerList.DataSource = dtsub;
                GridTitleAns.Visible = true;
                GridTitleAns.InnerText = "Answer Options";
            }
            else
            {
                lblGridStatus.Visible = true;
                ImpromptuHelper.ShowPrompt("No Answer Options found!");
                GridTitleAns.Visible = false;
                GridTitleAns.InnerText = "";

            }
            gvAnswerList.DataBind();
            ViewState["tMood"] = "check";


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAnswerAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAnswer();", true);
            LinkButton btn = (LinkButton)(sender);
            string QuestionId = btn.CommandArgument;
            lblQuesDesc.Visible = true;
            lblQuestion.Visible = true;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvQuestions.SelectedIndex = gvr.RowIndex;
            lblQuesDesc.Text = gvr.Cells[3].Text;
            
            ViewState["QuestionId"] = QuestionId;
            txtAnswer.Text = "";
            ddlAnswOption.SelectedValue = "0";
            ViewState["mode"] = "AddExtra";
            txtAnswer.TextMode = TextBoxMode.MultiLine;
            txtAnswer.Rows = 5;
            ddlAnswOption.Visible = false;
            lblAnswerOption.Visible = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void BindAnswerOption()
    {
        try
        {
            DataTable dt = null;
            BLLAdmTestAnswerOptions ObjECT = new BLLAdmTestAnswerOptions();
            dt = ObjECT.AdmTestAnswerOptionsFetch(ObjECT);
            objBase.FillDropDown(dt, ddlAnswOption, "AnswerOption_ID", "AnswerOptionDesc");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAnswerEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAnswer();", true);
            lblQuesDesc.Visible = false;
            lblQuestion.Visible = false;
            BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();
            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            LinkButton btn = (LinkButton)(sender);
            string QuestionDetailId = btn.CommandArgument;
            ViewState["QuestionDetailId"] = QuestionDetailId;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvAnswerList.SelectedIndex = gvr.RowIndex;
            txtAnswer.Focus();
            txtAnswer.Text = gvr.Cells[3].Text;

            if (gvr.Cells[4].Text == "True")
                ddlAnswOption.SelectedValue = "1";
            else
                ddlAnswOption.SelectedValue = "0";
            ViewState["QuestionId"] = gvr.Cells[2].Text;

            ddlAnswOption.Visible = true;
            txtAnswer.Rows = 1;
            txtAnswer.TextMode = TextBoxMode.SingleLine;
            lblAnswerOption.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void btnAnswerDelete_Click(object sender, EventArgs e)
    {
        try
        {

            BLLAdmTestQuestionsDetail obj = new BLLAdmTestQuestionsDetail();
            LinkButton btn = (LinkButton)(sender);
            obj.QuestDetail_ID = Convert.ToInt32(btn.CommandArgument);
            int k = obj.AdmTestQuestionsDetailDelete(obj);
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvAnswerList.SelectedIndex = gvr.RowIndex;
            ViewState["QuestionId"] = gvr.Cells[2].Text;
            BindAnswerGrid();
            if (k == 0)
                ImpromptuHelper.ShowPrompt("Record Deleted!");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    protected void btnAnswerSave_Click(object sender, EventArgs e)
    {
        try
        {
            int AlreadyIn = 0;
            DataTable dt = new DataTable();
            BLLAdmTestQuestionsDetail objClsSec = new BLLAdmTestQuestionsDetail();
            DataTable dtsub = new DataTable();
            objClsSec.Quest_ID = Convert.ToInt32(ViewState["QuestionId"]);
            string mode = Convert.ToString(ViewState["mode"]);
            DataTable dtMCQsOptions = new DataTable();
            if(mode== "AddExtra")
            {
                dtMCQsOptions.Columns.Add("QuestionId");
                dtMCQsOptions.Columns.Add("Description");
                dtMCQsOptions.Columns.Add("IsCorrect");
                DataRow drMCQsOptions = null;
                ViewState["addMCQsOptions"] = null;

                foreach (string line in this.txtAnswer.Text.Split('\n'))
                {
                    if (line.Length > 1 || line.Length == 1)
                    {
                        drMCQsOptions = dtMCQsOptions.NewRow();
                        drMCQsOptions["QuestionId"] = 0;

                        if (line.Substring(0, 1) == "*")
                        {
                            drMCQsOptions["Description"] = line.Substring(1, line.Length - 1).Trim();
                            drMCQsOptions["IsCorrect"] = true;

                        }
                        else
                        {
                            drMCQsOptions["Description"] = line.Trim();
                            drMCQsOptions["IsCorrect"] = false;

                        }
                        dtMCQsOptions.Rows.Add(drMCQsOptions);
                    }
                }
                foreach (DataRow r in dtMCQsOptions.Rows)
                {
                    objClsSec.Options = r["Description"].ToString();
                    objClsSec.IsCorrect = Convert.ToBoolean(r["IsCorrect"].ToString());
                    AlreadyIn = objClsSec.AdmTestQuestionsDetailAdd(objClsSec);
                }
                ViewState["dtDetails"] = null;
                if (AlreadyIn == 1)
                {
                    ImpromptuHelper.ShowPrompt("Cannot add Answer!");
                }
            }
            if (mode == "Add")
            {
                dtMCQsOptions.Columns.Add("QuestionId");
                dtMCQsOptions.Columns.Add("Description");
                dtMCQsOptions.Columns.Add("IsCorrect");
                DataRow drMCQsOptions = null;
                ViewState["addMCQsOptions"] = null;
                
                foreach (string line in this.txtAddAnswer.Text.Split('\n'))
                {
                    if (line.Length > 1 || line.Length == 1)
                    {
                        drMCQsOptions = dtMCQsOptions.NewRow();
                        drMCQsOptions["QuestionId"] = 0;

                        if (line.Substring(0, 1) == "*")
                        {
                            drMCQsOptions["Description"] = line.Substring(1, line.Length - 1).Trim();
                            drMCQsOptions["IsCorrect"] = true;

                        }
                        else
                        {
                            drMCQsOptions["Description"] = line.Trim();
                            drMCQsOptions["IsCorrect"] = false;

                        }
                        dtMCQsOptions.Rows.Add(drMCQsOptions);
                    }
                }
                foreach (DataRow r in dtMCQsOptions.Rows)
                {
                    objClsSec.Options = r["Description"].ToString();
                    objClsSec.IsCorrect = Convert.ToBoolean(r["IsCorrect"].ToString());
                    AlreadyIn = objClsSec.AdmTestQuestionsDetailAdd(objClsSec);
                }
                ViewState["dtDetails"] = null;
                if (AlreadyIn == 1)
                {
                    ImpromptuHelper.ShowPrompt("Cannot add Answer!");
                }
            }
            else
            {
                objClsSec.QuestDetail_ID = Convert.ToInt32(ViewState["QuestionDetailId"]);
                if (ddlAnswOption.SelectedValue.ToString() == "0")
                    objClsSec.IsCorrect = false;
                else
                    objClsSec.IsCorrect = true;
                objClsSec.Options = txtAnswer.Text;
                AlreadyIn = objClsSec.AdmTestQuestionsDetailUpdate(objClsSec);
                ViewState["dtDetails"] = null;
                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Answer was successfully updated to this Question.");
                }
                else
                    ImpromptuHelper.ShowPrompt("Cannot Incorporate changes!");
            }
            BindAnswerGrid();
            BindQuestion();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalQuestion();", true);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void gvAnswerList_Prerender(object sender, EventArgs e)
    {
        try
        {
            if (gvAnswerList.Rows.Count > 0)
            {
                gvAnswerList.UseAccessibleHeader = false;
                gvAnswerList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    #endregion

}