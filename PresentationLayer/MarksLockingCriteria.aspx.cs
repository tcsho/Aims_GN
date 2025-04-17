using ADG.JQueryExtenders.Impromptu;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;



public partial class PresentationLayer_MarksLockingCriteria : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    static DataTable dd = new DataTable();


    BLLMarksLockingCriteria obj = new BLLMarksLockingCriteria();
    
   
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
                ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                FillTermList();
                FillMLCTypes();
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                ViewState["Mode"] = "";
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

    private void FillMLCTypes()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)obj.MarksLockingCriteriaTypesFetch(obj);
            if (ddlTerm.SelectedValue.ToString() == "3") 
                //if (ddlTerm.SelectedItem.Text== "Mock Examination")
            {
                int[] excludedClassIds = new int[] { 3 };
                dt = dt.AsEnumerable().Where(r => !excludedClassIds.Contains(r.Field<int>("MLC_Type_Id"))).CopyToDataTable();
            }
            
            
            objBase.FillDropDown(dt, ddlType, "MLC_Type_Id", "MLC_Type");
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

        
            foreach (ListItem item in ddlTerm.Items)
            {
                if (item.Text == "Bifurcation Examination" && item.Value == "3")
                {
                    item.Text = "Mock Examination";
                }
            }



            if (dt.Rows.Count > 0)
            {
                DateTime date = DateTime.Now;
                if (date.Month >= 3 && date.Month <= 7)
                    ddlTerm.SelectedValue = "2";
                else
                    ddlTerm.SelectedValue = "1";
            }
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["chkSelect"] = "check";
        BindReGrid();
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindReGrid();
    }

    void chkTestType_SelectedIndexChanged(object sender, EventArgs e)
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
            Session["Type_Id"] = ddlType.SelectedValue;
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
            if (!chkunlock.Checked && !chkLock.Checked)
            {
                {
                    ImpromptuHelper.ShowPromptGeneric("Please select Lock / Unlock option :", 0);
                    return;
                }
            }
    

            obj.MLCri_Id = Convert.ToInt32(ViewState["MLCri_Id"]);
            obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);       
            obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            obj.Term_Name = ddlTerm.SelectedItem.Text.ToString().Trim();
            string selectedDateTime = hiddenDateTime.Value;
        
            if (!string.IsNullOrEmpty(selectedDateTime))
            {
                obj.LockingDate = DateTime.ParseExact(selectedDateTime, "yyyy-MM-dd HH", null);

            } if (string.IsNullOrEmpty(selectedDateTime))
            {
                ImpromptuHelper.ShowPromptGeneric("Please select Date & Time :", 0);
                return;

            }
            if (chkLock.Checked)
            {
                obj.isLock = true;
            }
            else if (chkunlock.Checked)
            {
                obj.isLock = false;
            }
            obj.Status_Id = 1;

            bool _ispro= Convert.ToBoolean(ViewState["IsProcessed"]);
            bool pre_lock= Convert.ToBoolean(ViewState["isLock"]);

            
            obj.ML_Criteria = Convert.ToString(ViewState["ML_Criteria"]);
            obj.Evaluation_Criteria_Type_Id = Convert.ToInt32(ViewState["Evaluation_Criteria_Type_Id"]);
            obj.MLC_Type_Id = Convert.ToInt32(ViewState["MLC_Type_Id"]);
            obj.Evaluation_Type_Id = Convert.ToInt32(ViewState["Evaluation_Type_Id"]);
            obj.Class_Id = Convert.ToInt32(ViewState["Class_Id"]);

            if (_ispro == true)
            {
                obj.Current_Status = "";
                k = obj.MarksLockingCriteriaAdd(obj);
            }
            else if (_ispro == false)
            {
                obj.Current_Status = "";
                k = obj.MarksLockingCriteriaUpdate(obj);

                ImpromptuHelper.ShowPrompt("Saved Successfull");
            }
            
            ClearFields();
            ViewState.Clear();

            ViewState["Data"] = null;
            BindGrid();
            if (k == 1)
            {
                ImpromptuHelper.ShowPrompt("Update Successfull");
            }
            else if (k == 2)
            {
                ImpromptuHelper.ShowPrompt("Update UnSuccessfull");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        btnCancel_Click(this, EventArgs.Empty);
    }
    private void ClearFields()
    {
        // Reset dropdowns
        //ddlSession.SelectedIndex = 0;
        //ddlTerm.SelectedIndex = 0;
        //ddlType.SelectedIndex = 0;

        // Uncheck checkboxes
        chkunlock.Checked = false;
        chkLock.Checked = false;

        // Clear hidden field
        hiddenDateTime.Value = string.Empty;
    }

    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Mode"] = "Add";

            if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlType.SelectedIndex > 0)
            {
                ViewState["Mode"] = "Add";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
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

    }
    protected void BindGrid()
    {
        try
        {
            gvLocking.DataSource = null;
            gvLocking.DataBind();
            DataTable dt = new DataTable();
            if (ddlType.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlSession.SelectedIndex > 0)
            {
                obj.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                obj.MCL_Type_Id = Convert.ToInt32(ddlType.SelectedValue);
                obj.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
                obj.Term_Name = ddlTerm.SelectedItem.Text.ToString().Trim();
                btnAddTest.Visible = false;
                if (ViewState["Data"] == null)
                {

                    dt = obj.MarksLockingCriteriaFetch(obj);
                    if (ddlType.SelectedValue.ToString() == "1" || ddlType.SelectedValue.ToString() == "2")
                    {
                        if (ddlTerm.SelectedItem.Text.ToString().Trim()== "Mock Examination")
                        {
                            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6 && r.Field<int>("Class_Id")!=91).CopyToDataTable();
                        }
                        else
                        {
                            dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") > 6).CopyToDataTable();//Course,Exam class 3 to onnward
                        }
                        
                    }
                    else
                    {
                        dt = dt.AsEnumerable().Where(r => r.Field<int>("Class_Id") < 7).CopyToDataTable();  //GP PGroup to Class 2
                    }
                    ViewState["Data"] = dt;
                }
                else
                {
                    dt = (DataTable)ViewState["Data"];
                }
            }

            if (dt.Rows.Count > 0)
            {
                gvLocking.DataSource = dt;
                dd = dt;
                gvLocking.DataBind();
            }
            else
            {
                gvLocking.DataSource = null;
                gvLocking.DataBind();
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
            if (gvLocking.Rows.Count > 0)
            {
                gvLocking.UseAccessibleHeader = false;
                gvLocking.HeaderRow.TableSection = TableRowSection.TableHeader;

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
            ClearFields();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTest();", true);
            ViewState["Mode"] = "Edit";

            LinkButton btnEdit = (LinkButton)(sender);
            string[] commandArgs = btnEdit.CommandArgument.Split(new char[] { ',' });

            int _MLCri_Id = 0;
            bool _isLock = false;
            bool _IsProcessed = false;
            string _ML_Criteria = "";
            int _Evaluation_Criteria_Type_Id = 0;
            int _MLC_Type_Id = 0;
            int _Evaluation_Type_Id = 0;
            int _Class_Id = 0;

            if (commandArgs.Length == 8 && !string.IsNullOrEmpty(commandArgs[0]))
            {
                _MLCri_Id = Convert.ToInt32(commandArgs[0]);
                _isLock = Convert.ToBoolean(commandArgs[1]);
                _IsProcessed = Convert.ToBoolean(commandArgs[2]);
                if(_IsProcessed)
                {
                    _isLock = !_isLock;
                }
                _ML_Criteria = Convert.ToString(commandArgs[3]);
                _Evaluation_Criteria_Type_Id = Convert.ToInt32(commandArgs[4]);
                _MLC_Type_Id = Convert.ToInt32(commandArgs[5]);
                _Evaluation_Type_Id = Convert.ToInt32(commandArgs[6]);
                _Class_Id = Convert.ToInt32(commandArgs[7]);

                ViewState["MLCri_Id"] = _MLCri_Id;
                ViewState["isLock"] = _isLock;
                ViewState["IsProcessed"] = _IsProcessed;
                ViewState["ML_Criteria"] = _ML_Criteria;
                ViewState["Evaluation_Criteria_Type_Id"] = _Evaluation_Criteria_Type_Id;
                ViewState["MLC_Type_Id"] = _MLC_Type_Id;
                ViewState["Evaluation_Type_Id"] = _Evaluation_Type_Id;
                ViewState["Class_Id"] = _Class_Id;

                GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
                gvLocking.SelectedIndex = gvr.RowIndex;

                
            }

            if (_isLock)
            {
                chkLock.Enabled = true;
                chkunlock.Enabled = false;

                //chkLock.Enabled = false;
                //chkunlock.Enabled = true;
            }
            else
            {
                chkLock.Enabled = false;
                chkunlock.Enabled = true;

                //chkLock.Enabled = true;
                //chkunlock.Enabled = false;
            }
        }
            
        
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        ImageButton btn = (ImageButton)sender;
        string dateTimeString = "";
        if (btn.CommandArgument.StartsWith("LOCK"))
        {
            dateTimeString = btn.CommandArgument.Substring("LOCK - ".Length);
        }
        if (btn.CommandArgument.Contains("UNLOCK"))
        {
            dateTimeString = btn.CommandArgument.Substring("UNLOCK - ".Length);
        }


        DateTime date = Convert.ToDateTime(dateTimeString);
        bool _isLock = Convert.ToBoolean(btn.CommandName);
        GridViewRow grv = (GridViewRow)btn.NamingContainer;
        CheckBox cb = null;
        date = Convert.ToDateTime(date);
        //date = Convert.ToDateTime(grv.Cells[4].Text);
        foreach (GridViewRow gvRow in gvLocking.Rows)
        {
            int _index = gvRow.RowIndex;
            cb = (CheckBox)gvRow.FindControl("chkSelect");
            if (cb.Checked)
            {
                try
                {
                    int k = 0;
                    int id = Convert.ToInt32(gvRow.Cells[0].Text.ToString());
                    obj.MLCri_Id = id;
                    obj.LockingDate = date;
                    obj.isLock = _isLock;
                    k = obj.MarksLockingCriteriaUpdate(obj);
                    if (k == 1)
                    {
                        ImpromptuHelper.ShowPrompt("Update Successfull");
                    }
                    else if (k == 2)
                    {
                        ImpromptuHelper.ShowPrompt("Update UnSuccessfull");
                    }
                }
                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                }
                cb.Checked = false;
            }
        }
        ViewState["Data"] = null;
        BindGrid();
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string currentStatus = DataBinder.Eval(e.Row.DataItem, "Current_Status").ToString();

            if (currentStatus == "Processed")
            {
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Green; // Change to the correct cell index
                e.Row.Cells[4].Font.Bold = true;
            }
            else if (currentStatus == "Pending")
            {
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Red; // Change to the correct cell index
                e.Row.Cells[4].Font.Bold = true;// Change to the correct cell index
            }
            else if (string.IsNullOrEmpty(currentStatus))
            {
                e.Row.Cells[4].Text = ""; // Change to the correct cell index
            }
        }
    }

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMLCTypes();
    }
}
