using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_TCS_StudentJoinedInNewSession : System.Web.UI.Page
{
    DALBase objbase = new DALBase();
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
                Response.Redirect("~/login.aspx", false);
            }
            BindNewStudents();


        }
    }
    protected void btnAddPanel_Click(object sender, EventArgs e)
    {
        try
        {
            btnAddPanel.Visible = false;
            SearchPanel.Visible = true;
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
            btnAddPanel.Visible = true;
            SearchPanel.Visible = false;
            dg_student.DataSource = null;
            dg_student.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void gvNewStudents_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (gvNewStudents.Rows.Count > 0)
            {
                gvNewStudents.UseAccessibleHeader = false;
                gvNewStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvNewStudents.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void BindNewStudents()
    {
        gvNewStudents.DataSource = null;
        gvNewStudents.DataBind();
        BLLStudent_Joined_In_NewSession bll = new BLLStudent_Joined_In_NewSession();
        DataRow userrow = (DataRow)Session["rightsRow"];
        DataTable dtn = new DataTable();


        ////////////bll.Center_Id = Convert.ToInt32(Session["cId"].ToString());
        if (!String.IsNullOrEmpty(userrow["Region_Id"].ToString()))
            bll.Region_Id = Convert.ToInt32(userrow["Region_Id"].ToString());
        else
            bll.Region_Id = 0;

        if (!String.IsNullOrEmpty(userrow["Center_Id"].ToString()))
            bll.Center_Id = Convert.ToInt32(userrow["Center_Id"].ToString());
        else
            bll.Center_Id = 0;

        dtn = bll.Student_Joined_In_NewSessionFetch(bll);


        if (dtn.Rows.Count > 0)
        {
            ViewState["LoadData"] = dtn;
            gvNewStudents.DataSource = dtn;
            gvNewStudents.DataBind();

        }
        else
        {
            lblNoDatadt.Visible = true;
            lblNoDatadt.Text = "No Data Found";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BLLStudent_Joined_In_NewSession objClsSec = new BLLStudent_Joined_In_NewSession();
     
        LinkButton btn = (LinkButton)(sender);
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        dg_student.SelectedIndex = gvr.RowIndex;
        
        int AlreadyIn = 0;
        
        DataTable dt = new DataTable();
        //for (int i = 0; i < dg_student.Rows.Count; i++) 
        //{
        //CheckBox cb = dg_student.Rows[i].FindControl("chkAdd") as CheckBox;
        //if (cb.Checked == true)
        //{
        objClsSec.Student_Id = Int32.Parse(gvr.Cells[2].Text);
        objClsSec.Region_Id = Int32.Parse(gvr.Cells[13].Text);
        objClsSec.Center_Id = Int32.Parse(gvr.Cells[14].Text);
        objClsSec.Student_Name = gvr.Cells[3].Text;
        objClsSec.Class_Id = Int32.Parse(gvr.Cells[8].Text);
        objClsSec.Class_Name = gvr.Cells[7].Text;
        objClsSec.Section_Id = Int32.Parse(gvr.Cells[10].Text);
        objClsSec.Section_Name = gvr.Cells[9].Text;
        objClsSec.Session_Id = Int32.Parse(gvr.Cells[11].Text);
        //studenlist += gvr.Cells[2].Text + ",";
        AlreadyIn = objClsSec.Student_Joined_In_NewSessionAdd(objClsSec);
        //}
        //}
        //studenlist = studenlist.Trim(',');
        //studenlist += "'";

        if (AlreadyIn == 0)
        {
            ImpromptuHelper.ShowPrompt("Record successfully updated.");
            gvNewStudents.DataSource = null;
            gvNewStudents.DataBind();
            BindNewStudents();
        }
        else
        {
            ImpromptuHelper.ShowPrompt("Record Already exist.");
            gvNewStudents.DataSource = null;
            gvNewStudents.DataBind();
        }
        BindGridSearch();
        //btnCancel_Click(this, EventArgs.Empty);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        
	{
            
		//DataRow row = (DataRow)Session["UserId"];
            
		DataRow row = (DataRow)Session["rightsRow"];
            
		LinkButton btn = (LinkButton)(sender);
            
		GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            
		gvNewStudents.SelectedIndex = gvr.RowIndex;
 
            		BLLStudent_Joined_In_NewSession obj = new BLLStudent_Joined_In_NewSession();
            		obj.Student_Joined_In_NewSession_Id = Convert.ToInt32(btn.CommandArgument);
            
		obj.DeletedBy = Convert.ToInt32		(Session["ContactID"].ToString());
           
		obj.DeletedDate= DateTime.Now;
            
		obj.Session_Id=  Convert.ToInt32		(Session["Session_Id"].ToString());
 
            
		int k = obj.Student_Joined_In_NewSessionDelete(obj);
 
            		ViewState["LoadData"] = null;
            
		BindNewStudents();
        
	}
        
	catch (Exception ex)
        
	{
            		Session["error"] = ex.Message;
            
		Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        
	}
    
}
    protected void dg_student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (dg_student.Rows.Count > 0)
            {
                dg_student.UseAccessibleHeader = false;
                dg_student.HeaderRow.TableSection = TableRowSection.TableHeader;
                dg_student.FooterRow.TableSection = TableRowSection.TableFooter;
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
            BindGridSearch();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    private void BindGridSearch()
    {
        try
        {
            string student = "";
            for (int i = 0; i < gvNewStudents.Rows.Count; i++)
            {
                if (i == gvNewStudents.Rows.Count - 1)
                    student += gvNewStudents.Rows[i].Cells[5].Text;
                else
                    student += gvNewStudents.Rows[i].Cells[5].Text + " , ";
            }
            BLLSearchStudent objSer = new BLLSearchStudent();
            ContentPlaceHolder cp = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = cp.FindControl("SearchStudent1") as UserControl;
            objSer.First_Name = (uc.FindControl("text_firstName") as TextBox).Text;
            objSer.Last_Name = (uc.FindControl("text_lastName") as TextBox).Text;
            objSer.Middle_Name = (uc.FindControl("text_middleName") as TextBox).Text;
            objSer.Date_Of_Birth = (uc.FindControl("text_dateOfBirth") as TextBox).Text;
            objSer.Gender_Id = (uc.FindControl("list_gender") as DropDownList).SelectedValue;
            objSer.Student_No = (uc.FindControl("text_studentNo") as TextBox).Text;
            objSer.Region_Id = (uc.FindControl("list_region") as DropDownList).SelectedValue;
            objSer.Student_Status_Id = (uc.FindControl("list_studentStatus") as DropDownList).SelectedValue;
            objSer.Center_Id = (uc.FindControl("list_center") as DropDownList).SelectedValue;

            objSer.Grade_Id = (uc.FindControl("list_class") as DropDownList).SelectedValue;
            objSer.Section_Id = (uc.FindControl("list_section") as DropDownList).SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = (uc.FindControl("list_teacher") as DropDownList).SelectedValue;

            DataTable dt = objSer.SearchStudentFetchCount(objSer);
            if (dt.Rows.Count > 0)
            {
                int total = Convert.ToInt32(dt.Rows[0]["StudenCount"].ToString());

                ViewState["total"] = total;

                objSer.First_Name = (uc.FindControl("text_firstName") as TextBox).Text;
                objSer.Last_Name = (uc.FindControl("text_lastName") as TextBox).Text;
                objSer.Middle_Name = (uc.FindControl("text_middleName") as TextBox).Text;
                objSer.Date_Of_Birth = (uc.FindControl("text_dateOfBirth") as TextBox).Text;
                objSer.Gender_Id = (uc.FindControl("list_gender") as DropDownList).SelectedValue;
                objSer.Student_No = (uc.FindControl("text_studentNo") as TextBox).Text;
                objSer.Region_Id = (uc.FindControl("list_region") as DropDownList).SelectedValue;
                objSer.Student_Status_Id = (uc.FindControl("list_studentStatus") as DropDownList).SelectedValue;
                objSer.Center_Id = (uc.FindControl("list_center") as DropDownList).SelectedValue;

                objSer.Grade_Id = (uc.FindControl("list_class") as DropDownList).SelectedValue;
                objSer.Section_Id = (uc.FindControl("list_section") as DropDownList).SelectedValue;
                objSer.Main_Organisation_Id = Session["moId"].ToString();
                objSer.Teacher_Id = (uc.FindControl("list_teacher") as DropDownList).SelectedValue;

                objSer.EndIndex = "";
                objSer.StartIndex = "";
                dt = objSer.SearchStudentFetch(objSer);
                if (dt.Rows.Count > 0)
                {
                    SearchTitle.Visible = true;
                    if (!String.IsNullOrEmpty(student))
                    {
                        DataRow[] tblROWS = dt.Select("Student_No not in(" + student + ")");
                        if (tblROWS.Length > 0)
                            dt = dt.Select("Student_No not in(" + student + ")").CopyToDataTable();

                        else
                        {
                            SearchTitle.Visible = false;
                            dt = null;
                        }
                    }

                    dg_student.DataSource = dt;
                    ViewState["studentDT"] = dt;
                }
                dg_student.DataBind();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
