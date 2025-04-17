using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Diagnostics;
using System.Threading;


public partial class PresentationLayer_TCS_AdmRegComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        LoadStudentData();
        BindGrid();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void LoadStudentData()
    {
        try
        {
        BLLAdmTestSubmissions ObjADS = new BLLAdmTestSubmissions();
        ObjADS.User_ID = Int32.Parse(Session["ContactID"].ToString());
        DataTable dt = ObjADS.AdmTestSubmissionsSelectInfromationByUserId(ObjADS);
        if (dt.Rows.Count > 0)
        {
            tdReg.InnerText = dt.Rows[0]["Regisration_Id"].ToString();
            tdSName.InnerText = dt.Rows[0]["StudentName"].ToString();
            tdClass.InnerText = dt.Rows[0]["Class_Name"].ToString();
            tdCName.InnerText = dt.Rows[0]["Center_Name"].ToString();
        }

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
            gvRackData.DataSource = null;
            gvRackData.DataBind();

            DataTable dt = new DataTable();

            BLLAdmTestSubmissions objBll = new BLLAdmTestSubmissions();
            objBll.User_ID = Int32.Parse(Session["ContactID"].ToString());

            if (ViewState["RackData"] == null)
            {
                dt = objBll.AdmTestSubmissionsSelectResultByUserId(objBll);

            }
            else
            {
                dt = (DataTable)ViewState["RackData"];

            }


            gvRackData.DataSource = dt;
            gvRackData.DataBind();
            gvRackData.FooterRow.Visible = true;

            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("MarksObtained"));
            gvRackData.FooterRow.Cells[2].Text = "Total";
            gvRackData.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvRackData.FooterRow.Cells[2].Font.Size = FontUnit.Large;
            gvRackData.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            gvRackData.FooterRow.Cells[3].Font.Size = FontUnit.Large;
            gvRackData.FooterRow.Cells[3].Text = total.ToString("N2");
            gvRackData.FooterRow.ForeColor = System.Drawing.Color.White;
            gvRackData.FooterRow.BackColor = System.Drawing.Color.Gray;
            gvRackData.FooterRow.Cells[5].BackColor = System.Drawing.Color.White;

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void gvRackData_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        int _classId = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


              Image btnTick = (Image)e.Row.FindControl("btnScanTick");
              Image btnCross = (Image)e.Row.FindControl("btnScanCross");
              Image btnNoAnswer = (Image)e.Row.FindControl("btnScanNoAnswer");
                try
                {

                      if (e.Row.Cells[0].Text == "0")
                        {
                        btnTick.Visible= false;
                        btnCross.Visible= false;
                        btnNoAnswer.Visible= true;
                      
                      }
                      else if (e.Row.Cells[0].Text == "1")
                        {
                        btnTick.Visible= true;
                        btnCross.Visible= false;
                        btnNoAnswer.Visible= false;
                      
                      }
                      else if (e.Row.Cells[0].Text == "2")
                        {
                        btnTick.Visible= false;
                        btnCross.Visible= true;
                        btnNoAnswer.Visible= false;
                      
                      }


                }
                catch (Exception ex)
                {
                    Session["error"] = ex.Message;
                    Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
                }


            }
          
    }
}