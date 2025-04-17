using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using City.Library.SQL;
using City.Library.Utility;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

public partial class PresentationLayer_Century_Student : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    Utility obj_Utility = new Utility();


    DataTable Exec(string query)
    {
        DataTable dt = new DataTable();

        string SQL_Path = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(SQL_Path);
        SqlDataAdapter adp = new SqlDataAdapter(query, conn);
        adp.Fill(dt);
        adp.Dispose();
        dt.Dispose();
        return dt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = Exec("select distinct rank() over(order by Century_Id) as No, Century_Id 'code' ,century_centerName 'name' from Center_Century");
            objBase.FillDropDown(dt, ddl_CenturyCenter, "code", "name");
        }

    }
    public string GetTeachersByCenter(string sOrgID, string sBearer)
    {
        //Respones.APIResponseGetDigest ParseObj = null; ;
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        int status_code = 0;
        string sAPIResponse = "";
        string URL = "https://api.century.tech/accounts/v2/users?class=&org=" + sOrgID + "&select=personal,contact,profile,isTest,isEnabled&role=student";
        //string URL = "https://api.century.tech/accounts/v2/users/?email=Iram.Mustafa@csn.edu.pk";

        HttpClient req = new HttpClient();
        req.DefaultRequestHeaders.Add("cache-control", "no-cache, no-store, max-age=0, must-revalidate");
        req.DefaultRequestHeaders.Add("pragma", "no-cache");
        req.DefaultRequestHeaders.Add("transfer-encoding", "chunked");
        req.DefaultRequestHeaders.Add("x-content-type-options", "nosniff");
        req.DefaultRequestHeaders.Add("x-frame-options", "DENY");
        req.DefaultRequestHeaders.Add("x-xss-protection", "1; mode=block");
        req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sBearer);
        req.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
            HttpResponseMessage http_res = req.GetAsync(URL).Result;
            status_code = (int)http_res.StatusCode;
            sAPIResponse = http_res.Content.ReadAsStringAsync().Result;
        }
        catch (Exception)
        {
            throw;
        }
        return sAPIResponse;
    }
    string GetBearer(string OrgID)
    {
        string tkn = null;
        try
        {
            DataTable dt = new DataTable();
            dt = Exec("exec GetTockenFor_Century_jssha01 '" + OrgID + "'");
            dt.Dispose();
            if (dt.Rows.Count > 0)
            {
                tkn = dt.Rows[0][0].ToString();
            }
            else
            {
                tkn = null;
            }

        }
        catch (Exception ex)

        {
            lblMessage.Text = ex.Message;
        }

        return tkn;
    }
    string InsertResponse(string OrgID, string resp)
    {
        string rtn = null;
        try
        {
            DataTable dt = new DataTable();
            dt = Exec("sp_Import_century_org_Json '" + OrgID + "', '" + resp + "',2");
            dt.Dispose();
            if (dt.Rows.Count > 0)
            {
                rtn = dt.Rows[0][0].ToString();
            }
            else
            {
                rtn = null;
            }

        }
        catch (Exception ex)

        {
            lblMessage.Text = ex.Message;
        }

        return rtn;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtGetResp = new DataTable();
            dtGetResp.Columns.Add("Org");
            dtGetResp.Columns.Add("Resp");
            Exec("delete from Import_century_org_Json where BatchID =2");
            string _token = GetBearer(ddl_CenturyCenter.SelectedValue);
            string resp = GetTeachersByCenter(ddl_CenturyCenter.SelectedValue, _token);
            DataRow dr = dtGetResp.NewRow();
            dr[0] = ddl_CenturyCenter.SelectedValue;
            dr[1] = resp;
            dtGetResp.Rows.Add(dr);
            string r = InsertResponse(ddl_CenturyCenter.SelectedValue, resp);
            DataTable dt = Exec("sp_fetchCentury 2,'" + ddl_CenturyCenter.SelectedValue + "'");
            dt.Dispose();
            GV_Student.DataSource = dt;
            GV_Student.DataBind();

        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
        }

    }

    protected void GV_Student_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }
}