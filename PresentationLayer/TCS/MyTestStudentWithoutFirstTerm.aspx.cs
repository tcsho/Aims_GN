using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_StudentWithoutFirstTerm : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
        if (!IsPostBack)
        {

            //======== Page Access Settings ========================
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
                Response.Redirect("~/login.aspx",false);
            }
            bindGVDetail();

           
        }
    }

   
    protected void bindGV()
    {
        gvAttnType.DataSource = null;
        gvAttnType.DataBind();
        BLLStudent_Without_First_Term bll = new BLLStudent_Without_First_Term();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dt = new DataTable();

        bll.Student_Id = Int32.Parse(txtRollNo.Text);
        bll.Center_Id = Convert.ToInt32(Session["cId"].ToString());
        dt = bll.Student_SelectAllByStudentNoForStudentWithoutFirstTerm(bll);
        if (dt.Rows.Count > 0)
        {
            ViewState["LoadData"] = dt;
            gvAttnType.DataSource = dt;
            gvAttnType.DataBind();
            lblNoData.Visible = false;
            lblNoData.Text = "";
        }
        else
        {
            lblNoData.Visible = true;
            lblNoData.Text = "No Data Found";
        }
    }


    protected void bindGVDetail()
    {
        gvAttnTypedt.DataSource = null;
        gvAttnTypedt.DataBind();
        BLLStudent_Without_First_Term bll = new BLLStudent_Without_First_Term();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dtn = new DataTable();

   
        dtn = bll.Student_Without_First_TermFetch(bll);
        if (dtn.Rows.Count > 0)
        {
            ViewState["LoadData"] = dtn;
            gvAttnTypedt.DataSource = dtn;
            gvAttnTypedt.DataBind();
        
       }
        else
        {
            lblNoDatadt.Visible = true;
            lblNoDatadt.Text = "No Data Found";
        }
    }

   
    
   

    protected void ResetControls()
    {
        trCDT.Visible = false;
        
        btns.Visible = false;
        btnGen.Visible = false;
     

    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        bindGV();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        ResetControls();
    }

   
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        BLLStudent_Without_First_Term objClsSec = new BLLStudent_Without_First_Term();

        DataTable dtsub = new DataTable();
        ViewState["mode"] = "Edit";
        ImageButton btn = (ImageButton)(sender);
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        gvAttnType.SelectedIndex = gvr.RowIndex;

        string StudentNO = btn.CommandArgument;

        trCDT.Visible = true;
       
        btns.Visible = true;
       

        /////////////////  save value


        int AlreadyIn = 0;
            DataTable dt = new DataTable();

            
            objClsSec.Student_Id = Int32.Parse(StudentNO);
            objClsSec.Region_Id = Int32.Parse(gvr.Cells[4].Text);

            objClsSec.Center_Id = Int32.Parse(gvr.Cells[6].Text);
            objClsSec.Student_Name = gvr.Cells[3].Text;

            objClsSec.Class_Id = Int32.Parse(gvr.Cells[8].Text);
            objClsSec.Class_Name = gvr.Cells[9].Text;

            objClsSec.Section_Id = Int32.Parse(gvr.Cells[10].Text);
            objClsSec.Section_Name = gvr.Cells[11].Text;

            objClsSec.Session_Id = Int32.Parse(gvr.Cells[12].Text);
            


            string mode = Convert.ToString(ViewState["mode"]);

            if (mode != "Edit")
            {

                


            }

            else
            {



                

                AlreadyIn = objClsSec.Student_Without_First_TermAdd(objClsSec);

                if (AlreadyIn == 0)
                {
                    ImpromptuHelper.ShowPrompt("Record successfully updated.");
                    bindGVDetail();

                }

                if (AlreadyIn == -1)
                {
                    ImpromptuHelper.ShowPrompt("Record Already exist.");
                }

            }

      



        




    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    

    protected void gvAttnType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttnType.PageIndex = e.NewPageIndex;
        gvAttnType.DataSource = ViewState["LoadData"];
        gvAttnType.DataBind();
    }

    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        bindGV();
    }
}
