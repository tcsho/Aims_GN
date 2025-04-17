using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;



public partial class PresentationLayer_StudentResultMarksView : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        DataRow row = (DataRow)Session["rightsRow"];

        string queryStr = Request.QueryString["id"];        

        if (!IsPostBack)
        {
            try
            {
                ViewState["MainOrgId"] = 0;
                ViewState["RegionId"] = 0;
                ViewState["CenterId"] = 0;
                /////////Setting ///////////////
                if (row["User_Type"].ToString() != "SAdmin")
                {
                    
                }


                if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1 || Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2) //Head Office
                {
                    
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = 0;
                    ViewState["CenterId"] = 0;

                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3) //Regional Officer
                {
                    
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = 0;


                }

                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4) //Campus Officer
                {
                    
                    ViewState["MainOrgId"] = row["Main_Organisation_Id"].ToString();
                    ViewState["RegionId"] = row["Region_Id"].ToString();
                    ViewState["CenterId"] = row["Center_Id"].ToString();



                }
                else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5) //Campus Officer
                {
                    

                }


                ////////////////////////////
                FillActiveSessions();
                BindTerm();
                trButtons.Visible = false;
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
       
            
    }

    
        


    private void BindGrid()
    {
        try
        {
            BLLResult_Grade objClsSec = new BLLResult_Grade();

            DataTable dtsub = new DataTable();

           

            objClsSec.Main_Organisation_Id = Convert.ToInt32(ViewState["MainOrgId"].ToString());
            objClsSec.Region_Id = Convert.ToInt32(ViewState["RegionId"].ToString());
            objClsSec.Center_Id = Convert.ToInt32(ViewState["CenterId"].ToString());
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue.ToString());
            objClsSec.TermGroup_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
            objClsSec.Student_Id = Convert.ToInt32(txtStudentNo.Text);

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.StudentResultMarksViewbyStudentId(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                dv_details.DataSource = dtsub;
                dv_details.DataBind();
            }
            else
            {
                dv_details.DataSource = null;
                dv_details.DataBind();


                if ((Convert.ToInt32(ViewState["RegionId"].ToString()) != 0) && (Convert.ToInt32(ViewState["CenterId"].ToString()) == 0))
                {
                    ImpromptuHelper.ShowPrompt("Result Not found! Desired student did't belong to current Region");
                }
                else if ((Convert.ToInt32(ViewState["RegionId"].ToString()) != 0) && (Convert.ToInt32(ViewState["CenterId"].ToString()) != 0))
                {
                    ImpromptuHelper.ShowPrompt("Result Not found! Desired student did't belong to current Center");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Result Not found! ");
                }

            }


            if (list_Term.SelectedItem.Text == "Mock Examination")
            {
                dv_details.Columns[8].Visible = false;
                dv_details.Columns[9].Visible = false;

            }
            else
            {
                dv_details.Columns[8].Visible = true;
                dv_details.Columns[9].Visible = true;

            }

      
            
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
   
    


    private void BindTerm()
    {

        try
        {


            DataTable dt = null;
            BLLEvaluation_Criteria_Type ObjECT = new BLLEvaluation_Criteria_Type();
            dt = ObjECT.Evaluation_Criteria_TypeFetch(ObjECT);
            objBase.FillDropDown(dt, list_Term, "TermGroup_Id", "Type");
        
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    

    
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
       
            txtStudentNo.Text = "";
            dv_details.DataSource = null;
            dv_details.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    
        
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSession.SelectedValue != "")
            {
                
                DDLReset(list_Term);
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void DDLReset(DropDownList _ddl)
    {
        try
        {
        if (_ddl.Items.Count > 0)
        {
            _ddl.SelectedValue = "0";
        }
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
    


    protected void btnSearchStudent_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtStudentNo.Text != "" && list_Term.SelectedIndex > 0  && ddlSession.SelectedIndex > 0)
            {
                
                BindGrid();
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Please enter Student No and select Term and Session!");
                txtStudentNo.Focus();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
}