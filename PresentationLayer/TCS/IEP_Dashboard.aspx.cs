using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Drawing;


public partial class PresentationLayer_TCS_IEP_Dashboard : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        //  DataTable dt = new DataTable();
        //  dt = exec_SP(0);
        //   string JSONresult;
        //   hdnfld.Value = JsonConvert.SerializeObject(dt);
        //return "JSONresult";

        BLLCenter objCen = new BLLCenter();
        objCen.Region_Id = Convert.ToInt32(Session["RegionID"]);
        DataTable dt = objCen.CenterFetchByRegionID(objCen);
        objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
        gridbind();
    }

    protected void gridbind() {
        DataTable dt_class = exec_SPgrid("4");
        Grid_IEPStudents.DataSource = dt_class;
        Grid_IEPStudents.DataBind();
    }
    public  DataSet exec_SP(string action,string schoolname = "")
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@User_id", Session["UserId"]);
        param[1] = new SqlParameter("@Session_id", Convert.ToInt32(Session["Session_Id"]));
        param[2] = new SqlParameter("@Action", action);
        param[3] = new SqlParameter("@Center_id", schoolname);
        DataSet ds = objBase.sqlcmdFetch_DS("sp_Dashboard", param);
        
        ds.Dispose();
        return ds;
    }
    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid_IEPStudents.Rows.Count > 0)
            {
                Grid_IEPStudents.UseAccessibleHeader = false;
                Grid_IEPStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public DataTable exec_SPgrid(string Action)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_id", Convert.ToInt32(Session["Session_Id"]));
        param[1] = new SqlParameter("@Action", Action);
        DataTable dt = objBase.sqlcmdFetch("sp_iep_kpis", param);
        dt.Dispose();
        return dt;
    }
    protected void Grid_IEPStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cnt = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //If Salary is less than 10000 than set the row Background Color to Cyan  
            if (e.Row.Cells[3].Text == "Yes" && e.Row.Cells[4].Text == "Yes" && e.Row.Cells[5].Text == "Yes" && e.Row.Cells[6].Text == "Yes")
            {
                e.Row.BackColor = Color.Red;
            }
            if (e.Row.Cells[3].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[4].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[5].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[6].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[7].Text == "Yes")
            {
                cnt++;
            }
            if (e.Row.Cells[8].Text == "Yes")
            {
                cnt++;
            }
            e.Row.Cells[9].Text = cnt.ToString();

            if (cnt == 6)
            {
                e.Row.Cells[10].Text = "Privatized";
            }
            else
            {
                e.Row.Cells[10].Text = "Enrolled";

            }
        }
    }
    [WebMethod]
   
    public static string grap()
    {
        PresentationLayer_TCS_IEP_Dashboard p = new PresentationLayer_TCS_IEP_Dashboard();
       
        DataSet ds = new DataSet();
        ds = p.exec_SP("1");
        string JSONresult;
        // string JSONresult1;
        //JavaScriptSerializer ser = new JavaScriptSerializer();
        //JSONresult = ser.Serialize(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });//JsonConvert.SerializeObject(ds.Tables[0]);


         JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1]});
        return JSONresult;

    }
    [WebMethod]
    public static string grap2()
    {
        PresentationLayer_TCS_IEP_Dashboard p = new PresentationLayer_TCS_IEP_Dashboard();

        DataSet ds = new DataSet();
        ds = p.exec_SP("2");
        string JSONresult;
     
        //JavaScriptSerializer ser = new JavaScriptSerializer();
        //JSONresult = ser.Serialize(new { tab1 = ds.Tables[0], tab2 = ds.Tables[1] });//JsonConvert.SerializeObject(ds.Tables[0]);


        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0] });
        return JSONresult;



    }
    [WebMethod]
    public static string grap3(string schoolname)
    {


        PresentationLayer_TCS_IEP_Dashboard p = new PresentationLayer_TCS_IEP_Dashboard();
        
        DataSet ds = new DataSet();
        ds = p.exec_SP("3", schoolname);
        string JSONresult;

      

        JSONresult = JsonConvert.SerializeObject(new { tab1 = ds.Tables[0] });
        return JSONresult;



    }

    //protected void list_center_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
            
              

    //      int centerid = Int32.Parse(list_center.SelectedValue.ToString());
               


            
    //       // grap3(centerid);
           



    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}


}