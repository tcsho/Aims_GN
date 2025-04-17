using System;
using System.Data;
using System.Text;
using ADG.JQueryExtenders.Impromptu; 
public partial class PresentationLayer_ResultCompilationStatus : System.Web.UI.Page
{
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
                FillActiveSessions();
                FillChartddl();
                GoogleCharts();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }
    public void FillChartddl()
    {
        ddlChartType.DataSource = Enum.GetNames(typeof(GoogleChartType));
        ddlChartType.DataBind();

    }
    public void GoogleCharts()
    {
        if (ddlSession.SelectedIndex > 0 && ddlTerm.SelectedIndex > 0 && ddlReport.SelectedIndex > 0)
        {
            DataTable dt = new DataTable();
            GoogleChartType empType = (GoogleChartType)Enum.Parse(typeof(GoogleChartType), ddlChartType.SelectedValue);

            if (Session["Data"] != null)
            {
                dt = (DataTable)Session["Data"];

            }
            else
            {
                BLLResult_Grade bllrg = new BLLResult_Grade();
                bllrg.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
                bllrg.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);

                if (ddlReport.SelectedValue == "1")
                {
                    dt = bllrg.HO_ResultCompilationRegionalComparisonClassWise(bllrg);
                }
                else if (ddlReport.SelectedValue == "2")
                {
                    dt = bllrg.HO_PromotionalRegionalComparisonClassWise(bllrg);
                }

                Session["Data"] = dt;
            }
            FillGChart(dt, empType);
        }
    }

    private void FillGChart(DataTable _dt, GoogleChartType chTy)
    {

        DataRow rowMaster = (DataRow)Session["rightsRow"];

        StringBuilder strScript = new StringBuilder();

        DataTable _dt1 = new DataTable();
        DataTable _dt2 = new DataTable();
        DataTable _dt3 = new DataTable();
        DataTable _dt4 = new DataTable();

        try
        {
            if (_dt.Rows.Count > 0)
            {
                strScript.Append(@"<script type='text/javascript'>  
                               
google.charts.load('current', {'packages':['corechart','table']});
                            
                            ");

                if (ddlReport.SelectedValue == "1")
                {

                    _dt1 = _dt.Select(" Class_Name in ('Playgroup','Nursery','Kindergarten','Class 1','Class 2')").CopyToDataTable();
                    _dt2 = _dt.Select(" Class_Name in ('Class 3','Class 4','Class 5','Class 6','Class 7','Class 8')").CopyToDataTable();
                    _dt3 = _dt.Select(" Class_Name in ('Class 9 (O Level)','Class 10 (O Level)','Class 11 (O Level)')").CopyToDataTable();
                    _dt4 = _dt.Select(" Class_Name in ('A-1 (A Level)','A-2 (A Level)')").CopyToDataTable();


                    if (_dt1.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt1, strScript, "drawChart1"); //Step 1 
                        drawChart("EYE", strScript, "Chart1", chTy);
                    }


                    if (_dt2.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt2, strScript, "drawChart2"); // Step1
                        drawChart("Class 3 to Class 8", strScript, "Chart2", chTy);
                    }

                    if (_dt3.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt3, strScript, "drawChart3"); //Step 1 
                        drawChart("O Level", strScript, "Chart3", chTy);
                    }

                    if (_dt4.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt4, strScript, "drawChart4"); //Step 1 
                        drawChart("A Level", strScript, "Chart4", chTy);
                    }
                }
                else
                {
                    _dt1 = _dt;
                    _dt2 = _dt;
                    _dt3 = _dt;
                    _dt4 = _dt;


                    if (_dt1.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt1, strScript, "drawChart1"); //Step 1 
                        drawChart("Class 3 to Class 8", strScript, "Chart1", GoogleChartType.Line);
                    }


                    if (_dt2.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt2, strScript, "drawChart2"); // Step1
                        drawChart("Class 3 to Class 8", strScript, "Chart2", GoogleChartType.Bar);
                    }

                    if (_dt3.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt3, strScript, "drawChart3"); //Step 1 
                        drawChart("Class 3 to Class 8", strScript, "Chart3", GoogleChartType.Combo);
                    }

                    if (_dt4.Rows.Count > 0)
                    {
                        drawGooglePrepareData(_dt4, strScript, "drawChart4"); //Step 1 
                        drawChart("Class 3 to Class 8", strScript, "Chart4", GoogleChartType.Table);
                    }
                }

                strScript.Append(" </script>");


                ltScripts.Dispose();
                ltScripts.Text = "";
                ltScripts.Text = strScript.ToString();
            }
            else
            {
                ltScripts.Dispose();
                ltScripts.Text = "";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
        finally
        {
            _dt.Dispose();
            strScript.Clear();
        }

    }
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
    protected void drawChart(string Charttitle, StringBuilder strScript, string _chartName, GoogleChartType ch)
    {
        try
        {
            switch (ch)
            {
                case GoogleChartType.Line:
                    strScript.Append(@"
                var options = {
                    title: ");
                    strScript.Append("'" + Charttitle + "'");
                    strScript.Append(@",curveType: 'function',
                    legend: { position: 'bottom' }
                };

                var chart = new google.visualization.LineChart(document.getElementById('" + _chartName + @"'));

                chart.draw(data, options);
            }
");
                    break;

                case GoogleChartType.Bar:
                    strScript.Append("var options = { title :");
                    strScript.Append("'" + Charttitle + "'");

                    strScript.Append(@", vAxis: {title: 'Results Percentage'},  
                                 hAxis: {title: '" + DateTime.Now.Year.ToString() + @"'},
                                 vAxis: {minValue: 95},
                                 seriesType: 'bars', 
                                 series: {3: {type: 'area'}} 
                                            
                                            };");

                    strScript.Append(@" var chart = new google.visualization.ComboChart(document.getElementById('" + _chartName + @"')); 
                                    chart.draw(data, options); }");
                    break;

                case GoogleChartType.Combo:
                    strScript.Append(@"
                              var options = {
                              title : '" + Charttitle + @"',
                              vAxis: { title: 'Result Percentage'},
                              vAxis: {minValue: 95},
                              hAxis: { title: '" + DateTime.Now.Year.ToString() + @"'},
                              seriesType: 'bars',
                              series: { 5: { type: 'line'} }
                        };

                        var chart = new google.visualization.ComboChart(document.getElementById('" + _chartName + @"'));
                        chart.draw(data, options);
                          }");
                    break;

                case GoogleChartType.Pie:
                    strScript.Append(@" var options = {   
                             title: ");
                    strScript.Append("'" + Charttitle + "'");
                    strScript.Append(", pieSliceText: 'data',pieHole: 0.4,};");

                    strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('" + _chartName + @"'));          
                                chart.draw(data, options);        
                                }    
                            ");
                    break;
                case GoogleChartType.Table:
                    strScript.Append(@"
                        var table = new google.visualization.Table(document.getElementById('" + _chartName + @"'));

                                table.draw(data, {showRowNumber: true, width: '100%', height: '100%'});
                        }

                        ");
                    break;
            }



        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }



    protected void FillActiveSessions()
    {
        DALBase objBase = new DALBase();
        try
        {
            BLLSession objBll = new BLLSession();
            DataTable dt = new DataTable();
            dt = objBll.SessionSelectAllActive();
            objBase.FillDropDown(dt, ddlSession, "Session_ID", "Description");
            int session = Convert.ToInt16(Session["Session_Id"].ToString());
            session = session - 1;
            ddlSession.SelectedValue = session.ToString();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void default_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GoogleCharts();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["Data"] = null;
            GoogleCharts();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void btnResultCompletion_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSection objClsSec = new BLLSection();
            if(ddlTerm.SelectedIndex<=0)
            {
                ShowPrompt("Please select a Term",false);
                return;
            }
            if (ddlSession.SelectedIndex <= 0)
            {
                ShowPrompt("Please select a Session", false);
                return;
            }
            objClsSec.TermGroup_Id = Convert.ToInt32(ddlTerm.SelectedValue);
            objClsSec.Session_Id = Convert.ToInt32(ddlSession.SelectedValue);
            int k = objClsSec.ResultCompletion(objClsSec);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void ShowPrompt(string message , bool success)
    {
        ImpromptuHelper.ShowPrompt(message);
    }
}