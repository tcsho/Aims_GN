using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Diagnostics;
using System.Threading;

public partial class PresentationLayer_TCS_Diag_Prog_Unit_Topic : System.Web.UI.Page
{
    BLLDiag_Prog_Unit_Topic objtopic = new BLLDiag_Prog_Unit_Topic();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            pan_New.Visible = false;
            lblSubject.Text = (String)Session["SubjectName"];
            lblClass.Text = (String)Session["ClassName"];
            lblDescription.Text = (String)Session["UnitDescription"];
            lblPercentage.Text = "";
            lblhidden.Text = Session["UnitPercentage"].ToString();
            ViewState["ClassID"] = Session["ClassID"].ToString();
            string s = Session["ClassID"].ToString();
            string c = Session["EvaluationID"].ToString();
            ViewState["EvaluationID"] =Session["EvaluationID"].ToString();
            lblhidden.Visible = false;
            Session["UnitPercentage"] = lblhidden.Text;
            DurationCal();
            BindGrid();
      
        }
    }
    protected void DurationCal()
    {
        BLLEvaluation_Criteria_Type obj = new BLLEvaluation_Criteria_Type();
        int d = Convert.ToInt32((String)Session["EvaluationID"]);
        decimal totalPercentage; 
        DataTable dt = obj.Evaluation_Criteria_TypeSelectWeeks(d);
        int week = Convert.ToInt32(dt.Rows[0]["Working_Weeks"]);
        ViewState["TotalWeeks"] = week;
        totalPercentage = Math.Round(Convert.ToDecimal(Session["UnitPercentage"]));
        ViewState["TotalPercentage"] = totalPercentage;
      
      
    }
    private void BindGrid()
    {
       
        UnitView.DataSource = null;
        UnitView.DataBind();
        try
        {
            DataTable dtsub = new DataTable();
            objtopic.Unit_Id = Convert.ToInt32(Session["UnitId"]);
          
            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objtopic.Diag_Prog_Unit_TopicFetchByUnitId(objtopic.Unit_Id);
                ViewState["dtDetails"] = dtsub;
                
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
                
            }

            if (dtsub.Rows.Count > 0)
            {
                UnitView.DataSource = dtsub;
                UnitView.DataBind();
                lblPercentage.Text = Session["Per"].ToString();
                PercentageCal();
                tdSearch.Visible = true;
                lblSave.Text = "";
            }
            else
            {
                tdSearch.Visible = false;
                lblSave.Text = "No Data to Display";
                //ViewState["Percentage"] = 0;
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void PercentageCal()
    {
        BLLDiag_Prog_Unit obj = new BLLDiag_Prog_Unit();
        int total = Convert.ToInt32(ViewState["TotalWeeks"].ToString());
        obj.Unit_Id = Convert.ToInt32(Session["UnitId"].ToString());            
        decimal weeks = CalculateDuration();
        obj.Percentage= (decimal)((weeks*100)/ total);
        ViewState["Percentage"] = obj.Percentage;
        lblPercentage.Text = (obj.Percentage/100).ToString("P");
        int k = obj.Diag_Prog_UnitUpdatePercentage(obj);
        if (k == 0)
            {
                //ImpromptuHelper.ShowPrompt("Percentage Updated!");
            }
          
        }

    public void UnitView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dtDetails"];
        string sortingDirection = string.Empty;
        if (direction == SortDirection.Ascending)
        {
            direction = SortDirection.Descending;
            sortingDirection = "Desc";

        }
        else
        {
            direction = SortDirection.Ascending;
            sortingDirection = "Asc";

        }

        dt.DefaultView.Sort = e.SortExpression + " " + sortingDirection;
        UnitView.DataSource = dt;
        UnitView.DataBind();
    }

    public SortDirection direction
    {
        get
        {
            if (ViewState["directionState"] == null)
            {
                ViewState["directionState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["directionState"];
        }
        set
        {
            ViewState["directionState"] = value;
        }
    }
    protected void UnitView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UnitView.PageIndex = e.NewPageIndex;
        BindGrid();
    }
   
    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
            
            String s = ViewState["TotalPercentage"].ToString(); 
            if (Convert.ToDecimal(ViewState["TotalPercentage"].ToString()) != 100 || Convert.ToDecimal(ViewState["TotalPercentage"].ToString()) < 100)
            {
                txtTopicDescription.Text = "";
                txtObective.Text = "";
                txtDuration.Text = "";
                ViewState["tmode"] = "insert";
                pan_New.Visible = true;
            }
            else
            {
                decimal i=Math.Round(Convert.ToDecimal(ViewState["TotalPercentage"].ToString()));
                ImpromptuHelper.ShowPrompt("Your Total percentage is"+i+"% thus you cannot enter any further topic ");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

       
    }
    protected void UnitView_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (UnitView.Rows.Count > 0)
            {
                UnitView.UseAccessibleHeader = false;
                UnitView.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void but_save_Click(object sender, EventArgs e)
    {
        int k=-1;
        
        try
        {
            //int pe = Convert.ToInt16(Session["TotalPercentage"].ToString());
            objtopic.Topic_Description = txtTopicDescription.Text;
            objtopic.Unit_Id = Convert.ToInt32(Session["UnitId"]);
            objtopic.Objective = txtObective.Text;
            objtopic.Duration = Convert.ToDecimal(txtDuration.Text);
            int weeks = Convert.ToInt32(ViewState["TotalWeeks"]);
            decimal percentage = (decimal)(objtopic.Duration *100/weeks );
            string s= ViewState["TotalPercentage"].ToString();
            decimal finalper = Convert.ToDecimal(ViewState["TotalPercentage"].ToString()) + Math.Round(percentage);


            if (ViewState["tmode"].ToString() == "insert" && (finalper<100 || finalper==100))
            {
                objtopic.CreatedBy = Convert.ToInt32(Session["ContactID"]);
                k = objtopic.Diag_Prog_Unit_TopicInsert(objtopic);
                ViewState["TotalPercentage"] = finalper;
               
            }
            else if (ViewState["tmode"].ToString() == "edit")
            {
                decimal old = Convert.ToDecimal(ViewState["OldDuration"]);
                decimal oldpercentage = (decimal)(old * 100 / weeks);
                finalper = finalper - oldpercentage;
                finalper = Math.Round(finalper);
                if (finalper==100||finalper<100 )
                {
                   // objtopic.Duration = Convert.ToDecimal(txtDuration.Text);
                    objtopic.Topic_Id = Convert.ToInt32(ViewState["Topic_Id"]);
                    objtopic.ModifiedBy = Convert.ToInt32(Session["ContactID"]);
                    k = objtopic.Diag_Prog_Unit_TopicUpdate(objtopic);
                    ViewState["TotalPercentage"] = finalper;
                }
                
            }
            
            if (finalper > 100)
            {
                ImpromptuHelper.ShowPrompt("Your Total Percentage will become : "+Math.Round(finalper )+"%"); 
                pan_New.Visible = false;
            }
            if (k == 0)
            {
                ViewState["dtDetails"] = null;
                
                BindGrid();
                pan_New.Visible = false;
                ImpromptuHelper.ShowPrompt("Record Saved Successfully !");
                
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
       
    }
  
    protected void but_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Visible=false ;
            UnitView.SelectedRowStyle.Reset();
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
            ImageButton btnEdit = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            UnitView.SelectedIndex = gvr.RowIndex;
            txtTopicDescription.Text = gvr.Cells[2].Text;
            txtObective.Text = gvr.Cells[3].Text;
            txtDuration.Text = gvr.Cells[4].Text;
            ViewState["OldDuration"] = txtDuration.Text;
            pan_New.Visible = true;
            ViewState["tmode"] = "edit";
            ViewState["Topic_Id"] = Convert.ToInt32(btnEdit.CommandArgument);
            lblWeek.Text = "Week(s)";
        
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BLLDiag_Prog_Unit obj =  new BLLDiag_Prog_Unit();
            ImageButton btndel = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btndel.NamingContainer; 
            ViewState["dtDetails"] = null; 
            objtopic.Topic_Id = Convert.ToInt32(btndel.CommandArgument);
            int k = objtopic.Diag_Prog_Unit_TopicDelete(objtopic); 
            decimal getdur = Convert.ToDecimal(gvr.Cells[4].Text);
            int weeks = Convert.ToInt32(ViewState["TotalWeeks"]);
            decimal finalper = Convert.ToDecimal(ViewState["TotalPercentage"].ToString()) -((getdur / weeks) * 100);
            BindGrid();  
            if (UnitView.Rows.Count>1|| UnitView.Rows.Count==1)
            {
                ViewState["TotalPercentage"] =  finalper;
            }
            else
            {
                ViewState["TotalPercentage"] = 0;
            }
            
            //obj.Unit_Id = Convert.ToInt32(Session["UnitId"]);
            //obj.Percentage = Convert.ToDecimal(ViewState["TotalPercentage"]);
            decimal d = Math.Round(Convert.ToDecimal(ViewState["Percentage"].ToString()),2);
            lblPercentage.Text =  d+" % ";
            //int j = obj.Diag_Prog_UnitUpdatePercentage(obj);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    
    protected bool checkDuration()
    {

        DataTable dt = (DataTable)ViewState["dtDetails"];
        int total = Convert.ToInt32(ViewState["TotalWeeks"].ToString());
        bool parameter = false;
        if (dt.Rows.Count > 0)
        {
            int sum = 0;
            foreach (DataRow dtRow in dt.Rows)
            {

                int s = Convert.ToInt32(dtRow["Duration"].ToString());
                sum = sum + s;
                if (sum > total )
                {
                    parameter = true;
                }
            }
        }

        return parameter;
    }

   
    protected decimal CalculateDuration()
    {
       decimal sum = 0; 
        DataTable dt = (DataTable)ViewState["dtDetails"];
        foreach (DataRow dtRow in dt.Rows)
        {
            decimal s = Convert.ToDecimal(dtRow["Duration"].ToString());
            sum = sum + s;

        }
        return sum;
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["ClassID"] = Session["ClassID"];
        String s = Session["EvaluationID"].ToString();
        Session["EvaluationID"] = s;
        Session["Mode"] = "Back";
        Session["SubjectInfo"] = Session["SubjectInfo"];
        Session["SubjectName"] = Session["SubjectName"].ToString();
        PercentageCal(); 
        Response.Redirect("Diag_Prog_Unit.aspx");
    }
}