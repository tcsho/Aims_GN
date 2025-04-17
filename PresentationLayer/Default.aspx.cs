using Newtonsoft.Json;
using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DALHomePageStats ObjHPS = new DALHomePageStats();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

            try
            {

                if (Session["ContactID"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }
                DataTable dt = new DataTable();
                loadAllHomeDetails();

                TrCampus.Visible = false;
                //TrDhCampus.Visible = false;
                TrTeacher.Visible = false;
                //TrDhRegion.Visible = false;
                if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 5)//Head Office
                {
                    //btnSendEmail.Visible = true;
                    btnSendEmail.Visible = false;
                    Button1.Visible = true;
                }
                else
                {
                    btnSendEmail.Visible = false;
                   
                }


                if (Convert.ToInt32(Session["UserType_Id"].ToString()) == 3)//Head Office
                {
                    //btnSendEmail.Visible = true;
                    btnSendEmail.Visible = false;
                    Button1.Visible = true;
                }
                else
                {
                    btnSendEmail.Visible = false;
                    
                }




            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }
    private void loadAllHomeDetails()
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            int userId = Convert.ToInt32(row["User_Id"].ToString());


            BLLLogin ObjL = new BLLLogin();
            ObjL.User_Id = userId;

            dt = ObjL.LoginFetchUserByID(ObjL);

            if (dt.Rows.Count > 0)
            {
                DateTime currDate = DateTime.Now;
                DateTime dat = Convert.ToDateTime(dt.Rows[0]["LastPassChangedOn"]);
                DateTime dateExpire = dat.AddDays(Convert.ToInt32(row["PassExpDays"].ToString()));

                if (dateExpire < currDate)
                {
                    Response.Redirect("~/ForceChangePassword.aspx", false);
                }
            }


            dt = ObjHPS.get_HomePageStatsBarChart(userId);
            dt2 = ObjHPS.get_HomePageStatsBarChartAdmissions(userId);

            int sess_id = Convert.ToInt32(Session["Session_Id"]);


            dt3 = ObjHPS.get_HomePagePromotionStats(userId, sess_id);
            if (dt != null && dt.Rows.Count != 0)
            {
                // LoadGrid();
                FillGChart(dt, dt2, dt3);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
        finally
        {
            dt = null;
        }
    }
    private void FillGChart(DataTable _dt, DataTable _dt2, DataTable _dt3)
    {


        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();


        try
        {
            dsChartData = _dt;

            if (dsChartData.Rows.Count > 0)
            {

                strScript.Append(@"<script type='text/javascript'>  
                               
                    google.charts.load('current', {'packages':['corechart','table']});
                            
                            ");



                drawGooglePrepareData(dsChartData, strScript, "drawBar"); //Step 1 
                drawBarChart("Student Strength", strScript); //Step 2 



                if (_dt2.Rows.Count > 0)
                {
                    drawGooglePrepareData(_dt2, strScript, "drawLine"); // Step1
                    drawLineChart("Yearly Admission Comparison", strScript); //Step2
                }

                drawGooglePrepareData(_dt3, strScript, "drawCol"); //Step 1 
                drawComboChart("Promotion Detention Summary"+" AY 2020 - 2021", strScript); //Step 2 


                drawGooglePrepareData(_dt3, strScript, "drawTab"); //Step 1 
                drawTableChart("Promotion Detention Summary" + " AY 2020 - 2021", strScript); //Step 2 

                strScript.Append(" </script>");


                ltScripts.Dispose();
                ltScripts.Text = "";
                ltScripts.Text = strScript.ToString();
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
        // }
    }


    //    protected void drawGoogleCharts(DataTable dsChartData, StringBuilder strScript,int _Columns)
    //    {
    //        try
    //        {
    //            strScript.Append(@"<script type='text/javascript'>  
    //                               google.charts.load('current', {packages: ['corechart']}); ");

    //            strScript.Append(@"function drawVisualization() {         
    //                                                var data = google.visualization.arrayToDataTable([  
    //                                                ['The City School', 'Students', { role: 'annotation' }],");

    //            string Name = dsChartData.Columns[0].ColumnName;
    //            string data = dsChartData.Columns[1].ColumnName;


    //            foreach (DataRow row in dsChartData.Rows)
    //            {

    //                switch (_Columns)
    //                {
    //                    case 1:
    //                        strScript.Append("['" + row[Name] + "],");
    //                        break;
    //                    case 2:
    //                        strScript.Append("['" + row[Name] + "'," + row[data] + "],");
    //                        break;
    //                    case 3:
    //                        strScript.Append("['" + row[Name] + "'," + row[data] + "," + row[data] + "],");
    //                        break;
    //                    default:
    //                        break;
    //                }
    //            }
    //            strScript.Remove(strScript.Length - 1, 1);
    //            strScript.Append("]);");
    //        }
    //        catch (Exception ex)
    //        {
    //            Session["error"] = ex.Message;
    //            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //        }
    //    }


    protected void drawGooglePrepareData(DataTable dsChartData, StringBuilder strScript, string _functionName)
    {
        try
        {

            strScript.Append(@"
                                google.charts.setOnLoadCallback(" + _functionName + @");

                               function " + _functionName + @"() {

                                var data = new google.visualization.DataTable();

                                ");
            foreach (DataColumn col in dsChartData.Columns)
            {
                string colstr = "";
                switch (col.DataType.ToString())
                {
                    case "System.String":
                        colstr = "string";
                        break;
                    case "System.Int32":
                        colstr = "number";
                        break;
                    case "System.Decimal":
                        colstr = "number";
                        break;
                    default:
                        break;
                }


                strScript.Append(@"
                                            data.addColumn('" + colstr + "','" + col.ColumnName + "');");
            }

            strScript.Append(@"
data.addRows([
");

            for (int row = 0; row < dsChartData.Rows.Count; row++)
            {

                strScript.Append(@"
[");

                for (int col = 0; col < dsChartData.Columns.Count; col++)
                {

                    switch (dsChartData.Columns[col].DataType.ToString())
                    {
                        case "System.String":
                            strScript.Append("'" + dsChartData.Rows[row][col].ToString() + "',");
                            break;
                        case "System.Int32":
                            strScript.Append("" + dsChartData.Rows[row][col].ToString() + ",");
                            break;
                        case "System.Decimal":
                            strScript.Append("" + dsChartData.Rows[row][col].ToString() + ",");
                            break;
                        default:
                            break;
                    }

                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append(@"
]);
");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }


    protected void drawPieChart(string Charttitle, StringBuilder strScript)
    {
        try
        {
            strScript.Append(@" var options = {   
                             title: ");
            strScript.Append("'" + Charttitle + "'");
            strScript.Append(", pieSliceText: 'data',pieHole: 0.4,};");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('donutchart'));          
                                chart.draw(data, options);        
                                }    
                            ");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void drawBarChart(string Charttitle, StringBuilder strScript)
    {
        try
        {
            strScript.Append("var options = { title :");
            strScript.Append("'" + Charttitle + "'");

            strScript.Append(@", vAxis: {title: ''},  
                                 hAxis: {title: '" + DateTime.Now.Year.ToString() + @"'},
                                 seriesType: 'bars', 
                                 series: {3: {type: 'area'}} 
                                            
                                            };");

            strScript.Append(@" var chart = new google.visualization.ComboChart(document.getElementById('barchart')); 
                                    chart.draw(data, options); }");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void drawLineChart(string Charttitle, StringBuilder strScript)
    {
        try
        {

            strScript.Append(@"
                var options = {
                    title: ");
            strScript.Append("'" + Charttitle + "'");
            strScript.Append(@",curveType: 'function',
                    legend: { position: 'bottom' }
                };

                var chart = new google.visualization.LineChart(document.getElementById('donutchart'));

                chart.draw(data, options);
            }
");

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void drawComboChart(string Charttitle, StringBuilder strScript)
    {
        try
        {

            strScript.Append(@"
      var options = {
      title : '" + Charttitle + @"',
      vAxis: { title: 'Percentage'},
      hAxis: { title: 'Regions'},
      seriesType: 'bars',
      series: { 5: { type: 'line'} }
};

var chart = new google.visualization.ComboChart(document.getElementById('promotions'));
chart.draw(data, options);
  }");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void drawTableChart(string Charttitle, StringBuilder strScript)
    {
        try
        {

            strScript.Append(@"
var table = new google.visualization.Table(document.getElementById('PromTab'));

        table.draw(data, {showRowNumber: true, width: '100%', height: '100%'});
}

");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void fillbarchart(DataTable dt)
    {
        //try
        //{
        //    DataRow row = (DataRow)Session["rightsRow"];
        //    string[] x = new string[dt.Rows.Count];
        //    decimal[] y = new decimal[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][1]);
        //    }
        //    BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y, BarColor = "#0c4da2", Name = "Students" });
        //    BarChart1.CategoriesAxis = string.Join(",", x);
        //    BarChart1.ChartType = AjaxControlToolkit.ChartType.Column;


        //    if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1)//Administrator Officer
        //    {
        //        BarChart1.ChartTitle = string.Format(row[23].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2)//Head Officer
        //    {
        //        BarChart1.ChartTitle = string.Format(row[23].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3)//Regional Officer
        //    {
        //        BarChart1.ChartTitle = string.Format(row[17].ToString() + "-" + row[24].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4)//Campus Officer
        //    {
        //        BarChart1.ChartTitle = string.Format(row[13].ToString() + "-" + row["Center_name"].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
        //    {
        //        BarChart1.ChartTitle = "Class Section Statistics";
        //    }
        //    else
        //    {
        //        BarChart1.ChartTitle = string.Format(row["Center_name"].ToString(), "Statistics");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}

    }

    //DataTable Group(DataTable _dt)
    //{
    //    DataTable dTable = new DataTable();
    //    dTable.Columns.Add("Region_Name", typeof(string));
    //    dTable.Columns.Add("PrecentComplete", typeof(Decimal));
    //    var query = from row in _dt.AsEnumerable()
    //                group row by row.Field<string>("Region_Name") into grp
    //                select new
    //                {
    //                    Region_Name = grp.Key,
    //                    PrecentComplete = grp.Average(r => r.Field<Decimal>("PrecentComplete"))
    //                };
    //    foreach (var grp in query)
    //    {

    //        //dTable.Rows.Add(grp., grp.sum);
    //        dTable.Rows.Add(grp.Region_Name,grp.PrecentComplete);

    //        //Response.Write(String.Format("The Sum of '{0}' is {1}", grp.Id, grp.sum));
    //    }

    //    return dTable;

    //}

    //DataTable Pivot(DataTable table, string pivotColumnName)
    //{
    //    // TODO make sure the table contains at least two columns

    //    // get the data type of the first value column
    //    var dataType = table.Columns[1].DataType;

    //    // create a pivoted table, and add the first column
    //    var pivotedTable = new DataTable();
    //    pivotedTable.Columns.Add("Row Name", typeof(string));

    //    // determine the names of the remaining columns of the pivoted table
    //    var additionalColumnNames = table
    //        .AsEnumerable()
    //        .Select(x => x[pivotColumnName].ToString());

    //    // add the remaining columns to the pivoted table
    //    foreach (var columnName in additionalColumnNames)
    //        pivotedTable.Columns.Add(columnName, dataType);

    //    // determine the row names for the pivoted table
    //    var rowNames = table.Columns
    //        .Cast<DataColumn>()
    //        .Select(x => x.ColumnName)
    //        .Where(x => x != pivotColumnName);

    //    // fill in the pivoted data
    //    foreach (var rowName in rowNames)
    //    {
    //        // get the value data from the appropriate column of the input table
    //        var pivotedData = table
    //            .AsEnumerable()
    //            .Select(x => x[rowName]);

    //        // make the rowName the first value
    //        var data = new object[] { rowName }
    //            .Concat(pivotedData)
    //            .ToArray();

    //        // add the row
    //        pivotedTable.Rows.Add(data);
    //    }

    //    return pivotedTable;
    //}
    //protected void gvRegionResult_PreRender(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridHeaderSetting(gvRegionResult);
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    //protected void gvResultCompletion_PreRender(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridHeaderSetting(gvResultCompletion);
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    //protected void gvCenterResult_PreRender(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridHeaderSetting(gvCenterResult);
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
    //    }

    //}

    public void GridHeaderSetting(GridView _gd)
    {
        try
        {
            if (_gd.Rows.Count > 0)
            {
                _gd.UseAccessibleHeader = false;
                _gd.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }




    protected void fillPiechart(DataTable dt)
    {
        //try
        //{
        //    DataRow row = (DataRow)Session["rightsRow"];
        //    string[] x = new string[dt.Rows.Count];
        //    decimal[] y = new decimal[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][1]);
        //    }
        //  //  pieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue{ Data = y });


        //    //BarChart1.CategoriesAxis = string.Join(",", x);

        //    if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1)//Administrator Officer
        //    {
        //        pieChart1.ChartTitle = string.Format(row[23].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2)//Head Officer
        //    {
        //        pieChart1.ChartTitle = string.Format(row[23].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3)//Regional Officer
        //    {
        //        pieChart1.ChartTitle = string.Format(row[17].ToString() + "-" + row[24].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4)//Campus Officer
        //    {
        //        pieChart1.ChartTitle = string.Format(row[13].ToString() + "-" + row["Center_name"].ToString(), "Statistics");
        //    }
        //    else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
        //    {
        //        pieChart1.ChartTitle = "Class Section Statistics";
        //    }
        //    else
        //    {
        //        pieChart1.ChartTitle = string.Format(row["Center_name"].ToString(), "Statistics");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}

    }



    //private void LoadGrid()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        DataRow row = (DataRow)Session["rightsRow"];
    //        int userId = Convert.ToInt32(row["User_Id"].ToString());

    //        if (ViewState["Stats"] != null)
    //        {
    //            dt = (DataTable)ViewState["Stats"];
    //        }
    //        else
    //        {
    //            if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 1)//Administrator Officer
    //            {
    //                dt = ObjHPS.get_HomePageStats(userId);
    //            }
    //            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 2)//Head Officer
    //            {
    //                dt = ObjHPS.get_HomePageStats(userId);
    //            }
    //            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 3)//Regional Officer
    //            {
    //                dt = ObjHPS.get_HomePageStats(userId);
    //            }
    //            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 4)//Campus Officer
    //            {
    //                dt = null;
    //            }
    //            else if (Convert.ToInt32(row["UserLevel_ID"].ToString()) == 5)//Teacher
    //            {
    //                dt = null;
    //            }

    //            ViewState["Stats"] = dt;
    //        }



    //        if (dt != null && dt.Rows.Count != 0)
    //        {
    //            gvUser.DataSource = dt;
    //            gvUser.DataBind();
    //        }
    //        else
    //        {
    //            //lblMessage.Visible = true;
    //            //lblMessage.Text = "No Statistics Available";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //    finally
    //    {
    //        dt = null;
    //    }

    //}

    private void FillInformation()
    {
        try
        {
            DataTable dt = new DataTable();
            try
            {

                DataRow row = (DataRow)Session["rightsRow"];

                int userId = Convert.ToInt32(row["User_Id"].ToString());

                dt = ObjHPS.get_HomePageContactInfo(userId);
                if (dt != null && dt.Rows.Count != 0)
                {
                    //       gvUserDetail.DataSource = dt;
                    //      gvUserDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void gvResultCompletion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            HtmlTableRow rwGP = (HtmlTableRow)e.Row.FindControl("trGP");
            HtmlTableRow rwECM = (HtmlTableRow)e.Row.FindControl("trECM");
            HtmlTableRow rwACS = (HtmlTableRow)e.Row.FindControl("trACS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (e.Row.Cells[1].Text == "0")
                    {
                        rwGP.Visible = false;

                    }
                    else
                    {
                        rwGP.Visible = true;
                    }


                    if (e.Row.Cells[2].Text == "0")
                    {
                        rwECM.Visible = false;
                    }
                    else
                    {
                        rwECM.Visible = true;
                    }


                    if (e.Row.Cells[3].Text == "0")
                    {
                        rwACS.Visible = false;
                    }
                    else
                    {
                        rwACS.Visible = true;
                    }

                }
                catch (Exception ex)
                {

                    Session["error"] = ex.Message;
                    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
                }

            }

        }

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void btnEmail_Click(object sender, EventArgs e)
    {

        try
        {
            EmailSummary();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void EmailSummary()
    {
        try
        {
            string EmailId = "";

            bool flag = false;
            BLLStudent_Conditionally_Promoted_Request objClsSec = new BLLStudent_Conditionally_Promoted_Request();
            BLLSendEmail objEmail = new BLLSendEmail();
            string strEmailMsg = "<br><br>Dear Sir,<br><br> ";
            BLLRegion bllreg = new BLLRegion();
            bllreg.Main_Organisation_Country_Id = 1;
            DataTable dtreg = bllreg.RegionFetch(bllreg);
            DataTable _dt = new DataTable();
            if (dtreg.Rows.Count > 0)
            {
                foreach (DataRow row in dtreg.Rows)
                {
                    objClsSec.Region_Id = Convert.ToInt32(row["Region_Id"].ToString());
                    _dt = objClsSec.Student_Conditionally_Promoted_RequestEmailSummary(objClsSec);
                    if (_dt.Rows.Count > 0)
                    {
                        //strEmailMsg += "<b>Following Students were promoted by Reignoal Director of " + row["Region_Name"] + " : </b><br><br>";
                        strEmailMsg += "<p style=font-size:30px;><b>Following Students were promoted by Regional Director of " + row["Region_Name"] + " : </b></p><br><br>";
                        foreach (DataRow r in _dt.Rows)
                        {
                            strEmailMsg = strEmailMsg + r["Student_Id"].ToString() + "-" + r["StudentName"] + "<br>";
                            strEmailMsg += "<b>Class: </b>" + r["Class_Name"].ToString() + "<br/>";
                            strEmailMsg += "<b>Date: </b>" + String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now) + "<br/>";
                            strEmailMsg += "<b>Campus : </b>" + r["Center_Name"] + "<br/>";
                            string reason = r["ResultStatus"].ToString();
                            reason = reason.Replace("&amp;#8195;", "&#8195;");
                            reason = reason.Replace("&amp;#8201;", "&#8201;");
                            reason = reason.Replace("&amp;#8194;", "&#8194;");
                            reason = reason.Replace("&lt;br /&gt;", "<br/>");
                            reason = reason.Replace("&amp;#10006;", "&#10006;");
                            reason = reason.Replace("&amp;#10004;", "&#10004;");
                            strEmailMsg += "<br/>He/ She was detained due to following reason(s) <br/><br/> <div>" + reason + "</div>";
                            strEmailMsg += "<br/><br/><b>Days Attended</b>: " + r["DaysPresent"].ToString() + "";
                            strEmailMsg += "<br/><br/><b> School Head Remarks: </b>" + r["Remarks"].ToString();
                            strEmailMsg += "<br/><br/><b> Regional Director Approval Remarks: </b>" + r["RD_Remarks"].ToString();
                            strEmailMsg += "<br><br>===================================================================================<br><br>";

                            EmailId = EmailId + r["Student_Id"].ToString() + ",";
                            flag = true;
                        }

                    }
                }
                if (flag == true)
                {
                    strEmailMsg += "<br><br><b>Note: </b><i>This is a system generated message. Please do not reply to this message.</i><br><br>";
                    bool issend = objEmail.SendEmail(1, "Discretionary Promotion Alert", strEmailMsg, "Discretionary Promotion");
                    objClsSec.studentist = EmailId.TrimEnd(',');
                    /*Update Previous Data*/
                    if (issend)
                    {
                        objClsSec.Student_Conditionally_Promoted_RequestUpdateEmailSent(objClsSec);
                    }

                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            BLLClass_Change_Request objreq = new BLLClass_Change_Request();
            DataTable dt = new DataTable();
            if (Session["UserType_Id"].ToString() == "20")
            {
                objreq.Approved_By = Convert.ToInt32(Session["ContactID"].ToString());
                dt = objreq.Class_Change_RequestNotification(objreq);
                if (dt.Rows.Count > 0)
                {
                    divNotif.Visible = true;
                    divNotif.InnerHtml = " <h4>" + dt.Rows[0]["TotalPending"].ToString() + " </h4>";
                }

            }
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

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
       // System.Threading.Thread.Sleep(3000);
        Response.Redirect("~/PresentationLayer/dashboardBI.aspx", false);
    }
}



