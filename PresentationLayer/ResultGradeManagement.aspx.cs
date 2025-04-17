using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;


public partial class PresentationLayer_ResultGradeManagement : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    string Result_GradeIdGe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblSave.Text = "";
                FillClassSection();
                pan_New.Attributes.CssStyle.Add("display", "none");
                ViewState["tMood"] = "check";
                ViewState["SortDirection"] = "ASC";
                trSave.Visible = false;

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

                //====== End Page Access settings ======================
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }

    private void FillClassSection()
    {
        try
        {
            lblSave.Text = "";
            BLLResult_Grade obj = new BLLResult_Grade();


            int moID = Int32.Parse(Session["moID"].ToString());
            obj.Main_Organisation_Id = moID;



            DataTable dt = (DataTable)obj.Class_SelectByOrgId(obj);

            objBase.FillDropDown(dt, List_ClassSection, "Class_Id", "Class_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            pan_New.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    private void BindGrid()
    {
        try
        {
            BLLResult_Grade objClsSec = new BLLResult_Grade();

            DataTable dtsub = new DataTable();

            objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());

            if (ViewState["dtDetails"] == null)
            {
                dtsub = (DataTable)objClsSec.Result_GradeSelectAll(objClsSec);
            }
            else
            {
                dtsub = (DataTable)ViewState["dtDetails"];
            }

            if (dtsub.Rows.Count > 0)
            {
                gvSubjects.DataSource = dtsub;
            }
            gvSubjects.DataBind();
            ViewState["tMood"] = "check";
            trSave.Visible = true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }




    protected void gvSubjects_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable _dt = (DataTable)ViewState["dtDetails"];
            _dt.DefaultView.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            BindGrid();

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
            pan_New.Attributes.CssStyle.Add("display", "inline");
            BLLResult_Grade objClsSec = new BLLResult_Grade();

            DataTable dtsub = new DataTable();
            ViewState["mode"] = "Edit";
            ImageButton btn = (ImageButton)(sender);
            string ResultGradeValue = btn.CommandArgument;

            Result_GradeIdGe = ResultGradeValue;

            ViewState["ResultGrade"] = ResultGradeValue;


            objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
            objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
            objClsSec.Result_Grade_Id = Convert.ToInt32(ResultGradeValue.ToString());


            dtsub = (DataTable)objClsSec.Result_GradeSelectAllByResultGradeId(objClsSec);

            txtGrade.Text = dtsub.Rows[0]["Grade"].ToString().Trim();
            txtUpperlimt.Text = dtsub.Rows[0]["Upper_Limit"].ToString().Trim(); ;
            txtLowerlimt.Text = dtsub.Rows[0]["Lower_Limit"].ToString().Trim(); ;

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
            BLLResult_Grade objClsSec = new BLLResult_Grade();
            int AlreadyIn = 0;
            ImageButton btn = (ImageButton)(sender);
            string ResultGradeValue = btn.CommandArgument;

            ViewState["ResultGrade"] = ResultGradeValue;

            objClsSec.Result_Grade_Id = Convert.ToInt32(ViewState["ResultGrade"]);

            AlreadyIn = objClsSec.Result_GradeDelete(objClsSec);


            ViewState["dtDetails"] = null;

            ImpromptuHelper.ShowPrompt("Delete Record successfully");
            pan_New.Attributes.CssStyle.Add("display", "none");
            BindGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void but_new_Click(object sender, EventArgs e)
    {
        try
        {
            pan_New.Attributes.CssStyle.Add("display", "inline");
            ViewState["mode"] = "Add";
            txtGrade.Text = "";
            txtUpperlimt.Text = "";
            txtLowerlimt.Text = "";
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }


    protected void but_save_Click(object sender, EventArgs e)
    {
        try
        {

            if (ValidateGrades())
            {


                int AlreadyIn = 0;
                DataTable dt = new DataTable();

                BLLResult_Grade objClsSec = new BLLResult_Grade();




                string mode = Convert.ToString(ViewState["mode"]);
                int? classId = null;
                classId = Convert.ToInt32(List_ClassSection.SelectedValue);

                int moId = Convert.ToInt32(Session["moID"]);
                string grade = txtGrade.Text;
                double lowerLimt = Double.Parse(txtLowerlimt.Text);
                double upperLimit = Double.Parse(txtUpperlimt.Text);


                objClsSec.Result_Grade_Id = Convert.ToInt32(ViewState["ResultGrade"]);
                objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
                objClsSec.Grade = txtGrade.Text;
                objClsSec.Upper_Limit = Convert.ToDecimal(txtUpperlimt.Text);
                objClsSec.Lower_Limit = Convert.ToDecimal(txtLowerlimt.Text);
                //objClsSec.KPI = Convert.ToDecimal("0.0");

                if (mode != "Edit")
                {


                    dt = (DataTable)objClsSec.Result_GradeSelectAllByGradeDescription(objClsSec);
                    if (dt.Rows.Count == 0)
                    {


                        AlreadyIn = objClsSec.Result_GradeAdd(objClsSec);


                        ViewState["dtDetails"] = null;
                        if (AlreadyIn == 0)
                        {
                            ImpromptuHelper.ShowPrompt("Grade was successfully added.");
                            pan_New.Attributes.CssStyle.Add("display", "none");
                            BindGrid();

                        }


                    }
                    else
                    {

                        ImpromptuHelper.ShowPrompt("Grade with this name already exists.");
                    }
                }

                else
                {



                    AlreadyIn = objClsSec.Result_GradeUpdate(objClsSec);


                    ViewState["dtDetails"] = null;
                    if (AlreadyIn == 0)
                    {
                        ImpromptuHelper.ShowPrompt("Grade successfully updated.");
                        pan_New.Attributes.CssStyle.Add("display", "none");
                        BindGrid();
                    }
                }
            }
            else
                ImpromptuHelper.ShowPrompt("Cannot Incorporate Changes!");
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
            pan_New.Attributes.CssStyle.Add("display", "none");
            gvSubjects.SelectedRowStyle.Reset();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }

    protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvSubjects_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gvSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (List_ClassSection.SelectedValue != "0")
            {
                BindGrid();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                gvSubjects.DataSource = null;
                gvSubjects.DataBind();
                pan_New.Attributes.CssStyle.Add("display", "none");
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected bool ValidateGrades()
    {


        ////// Comment for testing by ilyas ahmed khan 26 dec 2014
        BLLResult_Grade objClsSec = new BLLResult_Grade();

        DataTable dt = new DataTable();

        objClsSec.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
        objClsSec.Class_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());



        dt = (DataTable)objClsSec.Result_GradeSelectAll(objClsSec);

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            decimal upperLimit = decimal.Parse(this.txtUpperlimt.Text);
            decimal lowerLimit = decimal.Parse(this.txtLowerlimt.Text);
            if (this.txtGrade.Text != dt.Rows[i]["Grade"].ToString().Trim())
            {
                //if ((upperLimit <= decimal.Parse(dt.Rows[i]["Upper_Limit"].ToString().Trim()) && upperLimit >= decimal.Parse(dt.Rows[i]["Lower_Limit"].ToString().Trim())) ||
                //    (lowerLimit <= decimal.Parse(dt.Rows[i]["Upper_Limit"].ToString().Trim()) && lowerLimit >= decimal.Parse(dt.Rows[i]["Upper_Limit"].ToString().Trim())))
                //{

                //    return false;
                //}
            }
            else if (upperLimit > 100)
            {
                ImpromptuHelper.ShowPrompt("Upper Limit Can't exceed from 100");
                return false;
            }
            else if (lowerLimit < 0)
            {

                ImpromptuHelper.ShowPrompt("Lower Limit Can't less then from 0");
                return false;
            }

        }
        return true;



    }
}