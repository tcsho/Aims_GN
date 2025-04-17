using System;
using System.Linq;
using ADG.JQueryExtenders.Impromptu;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class PresentationLayer_ResultCompilationStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { if (!IsPostBack)
        {

            try
            {
                if (Session["ContactID"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }

                BLLResult_Grade bllrg = new BLLResult_Grade();
                bllrg.Session_Id = Convert.ToInt32(Session["Session_Id"].ToString());
                bllrg.TermGroup_Id = 1;

                DataTable dt = bllrg.HO_ResultCompilationRegionalComparisonClassWise(bllrg);
              
                FillGChart(dt);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }
        }
    }
    private void FillGChart(DataTable _dt)
    {

        DataRow rowMaster = (DataRow)Session["rightsRow"];
        string Charttitle = "";


        if (Convert.ToInt32(rowMaster["UserLevel_ID"].ToString()) == 1)//Administrator Officer
        {
            Charttitle = string.Format(rowMaster[23].ToString(), "Statistics");
        }
        else if (Convert.ToInt32(rowMaster["UserLevel_ID"].ToString()) == 2)//Head Officer
        {
            Charttitle = string.Format(rowMaster[23].ToString(), "Statistics");
        }
        else if (Convert.ToInt32(rowMaster["UserLevel_ID"].ToString()) == 3)//Regional Officer
        {
            Charttitle = string.Format(rowMaster[17].ToString() + "-" + rowMaster[24].ToString(), "Statistics");
        }
        else if (Convert.ToInt32(rowMaster["UserLevel_ID"].ToString()) == 4)//Campus Officer
        {
            Charttitle = string.Format(rowMaster[13].ToString() + "-" + rowMaster["Center_name"].ToString(), "Statistics");
        }
        else if (Convert.ToInt32(rowMaster["UserLevel_ID"].ToString()) == 5)//Teacher
        {
            Charttitle = "Teacher Statistics";
        }
        else
        {
            Charttitle = string.Format(rowMaster["Center_name"].ToString(), "Statistics");
        }



        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();
        StringBuilder strScriptD = new StringBuilder();

        try
        {
            dsChartData = _dt;

            if (dsChartData.Rows.Count > 0)
            {

                drawGoogleCharts(dsChartData, strScript);
                drawLineChart(Charttitle, strScript);
                //drawBarChart(Charttitle, strScript);

                drawGoogleCharts(dsChartData, strScriptD);
                //drawPieChart(Charttitle, strScriptD);
                drawBarChart(Charttitle, strScriptD);


            }

        }

        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
        // }
    }

    protected void drawGoogleCharts(DataTable dsChartData, StringBuilder strScript)
    {
        strScript.Append(@"<script type='text/javascript'>  
                    google.charts.load('current', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Result Completion', 'CR', 'NR','SR'],");

        string Name = dsChartData.Columns[1].ColumnName;
        string crdata = dsChartData.Columns[2].ColumnName;
        string nrdata = dsChartData.Columns[3].ColumnName;
        string srdata = dsChartData.Columns[4].ColumnName;


        foreach (DataRow row in dsChartData.Rows)
        {
            strScript.Append("['" + row[Name] + "'," + row[crdata] + "," + row[nrdata] + "," + row[srdata] + "],");
        }
        strScript.Remove(strScript.Length - 1, 1);
        strScript.Append("]);");
    }

    protected void drawPieChart(string Charttitle, StringBuilder strScript)
    {
        strScript.Append(@" var options = {   
                             title: ");
        strScript.Append("'" + Charttitle + "'");
        strScript.Append(", pieSliceText: 'data',pieHole: 0.4,};");

        strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('donutchart'));          
                                chart.draw(data, options);        
                                }    
                            google.charts.setOnLoadCallback(drawVisualization);  
                            ");
        strScript.Append(" </script>");


        ltScriptsD.Dispose();
        ltScriptsD.Text = "";
        ltScriptsD.Text = strScript.ToString();
    }

    protected void drawBarChart(string Charttitle, StringBuilder strScript)
    {
        strScript.Append("var options = { title :");
        strScript.Append("'" + Charttitle + "'");

        strScript.Append(", vAxis: {title: 'Students'},  hAxis: {title: 'The City School'},seriesType: 'bars', series: {3: {type: 'area'}} };");
        strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('barchart'));  chart.draw(data, options); } google.charts.setOnLoadCallback(drawVisualization);");
        strScript.Append(" </script>");

        ltScripts.Dispose();
        ltScripts.Text = "";
        ltScripts.Text = strScript.ToString();

    }

    protected void drawLineChart(string Charttitle, StringBuilder strScript)
    { 
    
    
            strScript.Append("var options = { title :");
        strScript.Append("'" + Charttitle + "'");

        strScript.Append(" , curveType: 'function',legend: { position: 'bottom' },vAxis: { 'maxValue': 100 },lineWidth: 2};");
        strScript.Append(" var chart = new google.visualization.LineChart(document.getElementById('barchart'));  chart.draw(data, options); } google.charts.setOnLoadCallback(drawVisualization);");
        strScript.Append(" </script>");

        ltScripts.Dispose();
        ltScripts.Text = "";
        ltScripts.Text = strScript.ToString();
    }


}