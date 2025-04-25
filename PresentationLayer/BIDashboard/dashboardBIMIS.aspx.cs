using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class PresentationLayer_dashboardBI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
                return;
            }

            int currentMonth = DateTime.Now.Month;  // Get the current month
            List<int> months = new List<int>();  // List to hold months

            // Loop through months from 1 to the current month
            for (int month = 1; month <= currentMonth; month++)
            {
                months.Add(month);  // Add each month to the list
            }

            // Convert the list of months to a comma-separated string
            string monthsString = string.Join(",", months);

            if (Session["UserType_Id"].ToString() == "37") //SLT
            {
                ViewState["RegionSelectedIndexValue"] = Int32.Parse(Session["RegionID"].ToString());
                lstRegion.SelectedValue = ViewState["RegionSelectedIndexValue"].ToString();
                lstRegion.Enabled = false;

                DataTable dt = new DataTable();
                dt = getClusters(Int32.Parse(Session["Center_Id"].ToString()));
                ViewState["ClusterSelectedIndexValue"] = dt.Rows[0]["Cluster_Id"];
                lstCluster.SelectedValue = ViewState["ClusterSelectedIndexValue"].ToString();
                lstCluster.Enabled = false;
                
                lstCenters.DataSource = null;
                lstCenters.DataSource = getCenters(Int32.Parse(Session["RegionID"].ToString()), Int32.Parse(lstCluster.SelectedValue));
                lstCenters.DataTextField = "Branch_Name";
                lstCenters.DataValueField = "Branch_Id";
                lstCenters.DataBind();                
                lstCenters.Enabled = false;
                lstCenters.SelectedValue = Session["Center_Id"].ToString();
                ViewState["CenterSelectedIndexValue"] = Int32.Parse(Session["Center_Id"].ToString());                

                lstClasses.DataSource = null;
                lstClasses.DataSource = getClasses(Int32.Parse(Session["Center_Id"].ToString()));
                lstClasses.DataTextField = "Class_Name";
                lstClasses.DataValueField = "Class_Name";                
                lstClasses.DataBind();
                lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
                lstClasses.Enabled = true; 
                ViewState["Classess"] = "-1";
            }
            else if (Session["UserType_Id"].ToString() == "38") //SLT HM
            {
                ViewState["RegionSelectedIndexValue"] = Int32.Parse(Session["RegionID"].ToString());
                lstRegion.SelectedValue = ViewState["RegionSelectedIndexValue"].ToString();
                lstRegion.Enabled = false;

                DataTable dt = new DataTable();
                dt = getClusters(Int32.Parse(Session["Center_Id"].ToString()));
                ViewState["ClusterSelectedIndexValue"] = dt.Rows[0]["Cluster_Id"];
                lstCluster.SelectedValue = ViewState["ClusterSelectedIndexValue"].ToString();
                lstCluster.Enabled = false;
                
                lstCenters.DataSource = null;
                lstCenters.DataSource = getCenters(Int32.Parse(Session["RegionID"].ToString()), Int32.Parse(lstCluster.SelectedValue));
                lstCenters.DataTextField = "Branch_Name";
                lstCenters.DataValueField = "Branch_Id";
                lstCenters.DataBind();
                lstCenters.Enabled = false;
                lstCenters.SelectedValue = Session["Center_Id"].ToString();
                ViewState["CenterSelectedIndexValue"] = Int32.Parse(Session["Center_Id"].ToString());

                string Class_Name = getClassesComaSepration(Int32.Parse(Session["User_Name"].ToString())).Trim();
                ViewState["Classess"] = RemoveSpacesAfterCommas(Class_Name);
            }
            else if (Session["UserType_Id"].ToString() == "39") //NP
            {
                ViewState["RegionSelectedIndexValue"] = Int32.Parse(Session["RegionID"].ToString());
                lstRegion.SelectedValue = ViewState["RegionSelectedIndexValue"].ToString();
                lstRegion.Enabled = false;

                lstCluster.DataSource = null;
                lstCluster.DataSource = getClusterFromEmp(Int32.Parse(Session["User_Name"].ToString()));
                lstCluster.DataTextField = "Cluster_Name";
                lstCluster.DataValueField = "Cluster_Id";
                lstCluster.DataBind();
                lstCluster.Enabled = true; 
                ViewState["ClusterSelectedIndexValue"] = Int32.Parse(lstCluster.SelectedValue);
                
                lstCenters.DataSource = null;
                lstCenters.DataSource = getCenters(Int32.Parse(Session["RegionID"].ToString()), Int32.Parse(lstCluster.SelectedValue));
                lstCenters.DataTextField = "Branch_Name";
                lstCenters.DataValueField = "Branch_Id";
                lstCenters.DataBind();
                lstCenters.Items.Insert(0, new ListItem("Select Center", "-1"));
                lstCenters.Enabled = true; 
                ViewState["CenterSelectedIndexValue"] = lstCenters.SelectedValue;

                lstClasses.DataSource = null;
                lstClasses.DataSource = getClasses(Int32.Parse(lstCenters.SelectedValue));
                lstClasses.DataTextField = "Class_Name";
                lstClasses.DataValueField = "Class_Name";
                lstClasses.DataBind();
                lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
                lstClasses.Enabled = true; 
                ViewState["Classess"] = lstClasses.SelectedValue;
            }
            else if (Session["UserType_Id"].ToString() == "40") //RD
            {
                ViewState["RegionSelectedIndexValue"] = Int32.Parse(Session["RegionID"].ToString());
                lstRegion.SelectedValue = ViewState["RegionSelectedIndexValue"].ToString();
                lstRegion.Enabled = false;

                ViewState["ClusterSelectedIndexValue"] = 0;
                lstCluster.SelectedValue = ViewState["ClusterSelectedIndexValue"].ToString();
                lstCluster.Enabled = true;
                
                lstCenters.DataSource = null;
                lstCenters.DataSource = getCenters(Int32.Parse(Session["RegionID"].ToString()), Int32.Parse(lstCluster.SelectedValue));
                lstCenters.DataTextField = "Branch_Name";
                lstCenters.DataValueField = "Branch_Id";
                lstCenters.DataBind();
                lstCenters.Items.Insert(0, new ListItem("Select Center", "-1"));
                lstCenters.Enabled = true;
                ViewState["CenterSelectedIndexValue"] = lstCenters.SelectedValue;

                lstClasses.DataSource = null;
                lstClasses.DataSource = getClasses(Int32.Parse(Session["Center_Id"].ToString()));
                lstClasses.DataTextField = "Class_Name";
                lstClasses.DataValueField = "Class_Name";
                lstClasses.DataBind();
                lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
                lstClasses.Enabled = true;
                ViewState["Classess"] = lstClasses.SelectedValue;
            }
            else //NW
            {
                ViewState["RegionSelectedIndexValue"] = -1;
                lstRegion.Items.Insert(0, new ListItem("Select Region", "-1"));
                lstRegion.SelectedValue = ViewState["RegionSelectedIndexValue"].ToString();
                lstRegion.Enabled = true;

                ViewState["ClusterSelectedIndexValue"] = -1;
                lstCluster.Items.Insert(0, new ListItem("Select Cluster", "-1"));
                lstCluster.SelectedValue = ViewState["ClusterSelectedIndexValue"].ToString();
                lstCluster.Enabled = true;
                
                lstCenters.DataSource = null;
                lstCenters.DataSource = getCenters(Int32.Parse(Session["RegionID"].ToString()), Int32.Parse(lstCluster.SelectedValue));
                lstCenters.DataTextField = "Branch_Name";
                lstCenters.DataValueField = "Branch_Id";
                lstCenters.DataBind();
                lstCenters.Items.Insert(0, new ListItem("Select Center", "-1"));
                lstCenters.Enabled = true; 
                ViewState["CenterSelectedIndexValue"] = lstCenters.SelectedValue;

                lstClasses.DataSource = null;
                lstClasses.DataSource = getClasses(Int32.Parse(lstCenters.SelectedValue));
                lstClasses.DataTextField = "Class_Name";
                lstClasses.DataValueField = "Class_Name";
                lstClasses.DataBind();
                lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
                lstClasses.Enabled = true; 
                ViewState["Classess"] = lstClasses.SelectedValue;
            }

            ViewState["MonthSelectedIndexValue"] = monthsString;
            lstMonth.SelectedValue = currentMonth.ToString();

            ViewState["YearSelectedIndexValue"] = Int32.Parse(lstYear.SelectedValue);

            BindData();
        }
    }
    static string RemoveSpacesAfterCommas(string input)
    {
        // Replace ", " (comma followed by space) with just "," (comma)
        return input.Replace(", ", ",");
    } 

    protected void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["RegionSelectedIndexValue"] = Int32.Parse(lstRegion.SelectedValue);

        lstCluster.DataSource = null; 
        lstCluster.DataSource = getClusters4Regions(Int32.Parse(lstRegion.SelectedValue));
        lstCluster.DataTextField = "Cluster_Name";
        lstCluster.DataValueField = "Cluster_Id";
        lstCluster.DataBind();

        // Check if there's any item selected after binding
        if (lstCluster.Items.Count >= 0)
        {
            //lstCluster.SelectedIndex = 0; // Optionally, set a default item
            lstCluster.Items.Insert(0, new ListItem("Select Cluster", "-1"));
        }

        lstCluster_SelectedIndexChanged(lstCluster, e); // Triggering the event to load centers and classes
        BindData();
    }

    protected void lstCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstCluster.SelectedItem != null && lstCluster.SelectedItem.Value != null)
        {
            ViewState["ClusterSelectedIndexValue"] = Int32.Parse(lstCluster.SelectedValue);
            lstCenters.DataSource = null;
            lstCenters.DataSource = getCenters(Int32.Parse(lstRegion.SelectedItem.Value), Int32.Parse(lstCluster.SelectedValue));
            lstCenters.DataTextField = "Branch_Name";
            lstCenters.DataValueField = "Branch_Id";
            lstCenters.DataBind();
            lstCenters.Items.Insert(0, new ListItem("Select Center", "-1"));
            lstCenters.Enabled = true;
            ViewState["CenterSelectedIndexValue"] = lstCenters.SelectedValue;

            lstClasses.DataSource = null;
            lstClasses.DataSource = getClasses(Int32.Parse(lstCenters.SelectedValue));
            lstClasses.DataTextField = "Class_Name";
            lstClasses.DataValueField = "Class_Name";
            lstClasses.DataBind();
            lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
            lstClasses.Enabled = true;
            ViewState["Classess"] = lstClasses.SelectedValue;

            BindData();
        }
    }
    protected void lstCenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CenterSelectedIndexValue"] = Int32.Parse(lstCenters.SelectedValue);
        lstClasses.DataSource = null;
        lstClasses.DataSource = getClasses(Int32.Parse(lstCenters.SelectedValue));
        lstClasses.DataTextField = "Class_Name";
        lstClasses.DataValueField = "Class_Name";
        lstClasses.DataBind();
        lstClasses.Items.Insert(0, new ListItem("Select Class", "-1"));
        lstClasses.Enabled = true;
        ViewState["Classess"] = lstClasses.SelectedValue;
        BindData();
    }
    protected void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Classess"] = lstClasses.SelectedValue;
        BindData();
    }
    protected void lstYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["YearSelectedIndexValue"] = Int32.Parse(lstYear.SelectedValue);
        BindData();
    }
    protected void lstMonth_SelectedIndexChanged(object sender, EventArgs e)
    { 
        int currentMonth = Int32.Parse(lstMonth.SelectedValue);  // Get the current month
        List<int> months = new List<int>();  // List to hold months

        // Loop through months from 1 to the current month
        for (int month = 1; month <= currentMonth; month++)
        {
            months.Add(month);  // Add each month to the list
        }

        // Convert the list of months to a comma-separated string
        string monthsString = string.Join(",", months);
 
        ViewState["MonthSelectedIndexValue"] = monthsString;

        BindData();
    }
    private void BindData()
    {
        int StrengthCur = 0;
        int StrengthPrv = 0;
        int targetStrength = 0;
        int AdmissionsCurYearAllMonth = 0;
        int WithdrawalsCurYearAllMonth = 0;         
        int registrationsCurYearAllMonth = 0;
        int AdmissionsPrvYearAllMonth = 0;
        int WithdrawalsPrvYearAllMonth = 0; 

        List<MyDataObject> dataListCurYear = getDashboardData();
        List<MyDataObject> dataListPrvYear = getDashboardDataPrvYear();
        List<MyDataObject> dataListCurYearAllMonth = getDashboardCurrentYearAllMonths();
        List<MyDataObject> dataListPrvYearAllMonth = getDashboardDataPrvYearAllMonth();

        var groupedLstCurYear = dataListCurYear
    .GroupBy(s => s.Center_Name)
    .Select(g => new
    {
        Center_Name = g.Key,
        //Admissions = g.Sum(s => s.Admissions),
        //Withdrawals = g.Sum(s => s.Withdrawals),
        Strength = g.Sum(s => s.Strength),
        Target_Strength = g.Sum(s => s.Target_Strength),
        //Registrations = g.Sum(s => s.Registrations)
    })
    .ToList();

        var groupedLstPrvYear = dataListPrvYear
.GroupBy(s => s.Center_Name)
.Select(g => new
{
    Center_Name = g.Key,
    //Admissions = g.Sum(s => s.Admissions),
    //Withdrawals = g.Sum(s => s.Withdrawals),
    Strength = g.Sum(s => s.Strength),
   //Registrations = g.Sum(s => s.Registrations)
})
.ToList();

        var groupedLstCurYearAllMonth = dataListCurYearAllMonth
.GroupBy(s => s.Center_Name)
.Select(g => new
{
Center_Name = g.Key,
Admissions = g.Sum(s => s.Admissions),
Withdrawals = g.Sum(s => s.Withdrawals),
//Strength = g.Sum(s => s.Strength),
Registrations = g.Sum(s => s.Registrations)
})
.ToList();

        var groupedLstPrvYearAllMonth = dataListPrvYearAllMonth
.GroupBy(s => s.Center_Name)
.Select(g => new
{
   Center_Name = g.Key,
   Admissions = g.Sum(s => s.Admissions),
   Withdrawals = g.Sum(s => s.Withdrawals),
   //Strength = g.Sum(s => s.Strength),
   //Registrations = g.Sum(s => s.Registrations)
})
.ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var item in groupedLstCurYear)
        {
            //actualAdmissions += item.Admissions;
            //actualWithdrawals += item.Withdrawals;
            StrengthCur += item.Strength;
            targetStrength += item.Target_Strength;
            //registrations += item.Registrations;
        }

        foreach (var item in groupedLstPrvYear)
        {
            //actualAdmissionsPrv += item.Admissions;
            //actualWithdrawalsPrv += item.Withdrawals;
            StrengthPrv += item.Strength;
            //registrationsPrv += item.Registrations;
        }

        foreach (var item in groupedLstCurYearAllMonth)
        {
            AdmissionsCurYearAllMonth += item.Admissions;
            WithdrawalsCurYearAllMonth += item.Withdrawals;
            //actualStrength += item.Strength;
            //targetStrength += item.Target_Strength;
            registrationsCurYearAllMonth += item.Registrations;
        }

        foreach (var item in groupedLstPrvYearAllMonth)
        {
            AdmissionsPrvYearAllMonth += item.Admissions;
            WithdrawalsPrvYearAllMonth += item.Withdrawals;
            //actualStrengthPrv += item.Strength;
            //registrationsPrv += item.Registrations;
        }
         
        // Loop through both lists using LINQ or indices to match up the rows
        for (int i = 0; i < groupedLstCurYear.Count; i++)
        {
            var currentItem = groupedLstCurYear[i];
            var previousItem = groupedLstPrvYear.FirstOrDefault(x => x.Center_Name == currentItem.Center_Name); // Match by center name or any unique identifier
            var ItemCurYearAllMonth = groupedLstCurYearAllMonth.FirstOrDefault(x => x.Center_Name == currentItem.Center_Name); // Match by center name or any unique identifier
            var ItemPrvYearAllMonth = groupedLstPrvYearAllMonth.FirstOrDefault(x => x.Center_Name == currentItem.Center_Name); // Match by center name or any unique identifier

            sb.Append("<tr>");
            sb.Append("<td>").Append(currentItem.Center_Name).Append("</td>");  // Assuming the center name is common to both lists

            // Current Year Data
            sb.Append("<td>").Append(ItemCurYearAllMonth.Registrations).Append("</td>");
            sb.Append("<td>").Append(ItemCurYearAllMonth.Admissions).Append("</td>");
            
            if (ItemPrvYearAllMonth != null)
            {
                // Compare Current Year Admissions vs Registrations
                if (ItemCurYearAllMonth.Admissions < ItemPrvYearAllMonth.Admissions)
                {
                    sb.Append("<td>").Append("<div class='arrowDownCodeBehindRed'></div>").Append("</td>");
                }
                else
                {
                    sb.Append("<td>").Append("<div class='arrowUpCodeBehindGreen'></div>").Append("</td>");
                }
            }

            // Previous Year Data (Make sure previousItem is not null)
            if (ItemPrvYearAllMonth != null)
            {
                sb.Append("<td>").Append(ItemPrvYearAllMonth.Admissions).Append("</td>");
                sb.Append("<td>").Append(ItemCurYearAllMonth.Withdrawals).Append("</td>");

                // Compare Previous Year Admissions vs Registrations
                if (ItemCurYearAllMonth.Withdrawals < ItemPrvYearAllMonth.Withdrawals)
                {
                    sb.Append("<td>").Append("<div class='arrowDownCodeBehindGreen'></div>").Append("</td>");
                }
                else
                {
                    sb.Append("<td>").Append("<div class='arrowUpCodeBehindRed'></div>").Append("</td>");
                }

                sb.Append("<td>").Append(ItemPrvYearAllMonth.Withdrawals).Append("</td>");
            }
            else
            {
                // Handle missing data for previous year if needed (e.g., append default or empty data)
                sb.Append("<td>-</td>");
                sb.Append("<td>-</td>");
                sb.Append("<td>-</td>");
                sb.Append("<td>-</td>");
            }

            // Additional comparisons and calculations can be added here for other columns like Withdrawals, Target_Strength, etc.

            sb.Append("</tr>");
        }
        // Inject the generated HTML into the <tbody> element
        tbody.InnerHtml = sb.ToString();

        txtOpeningStrength.InnerHtml = StrengthPrv.ToString();
        txtClosingStrength.InnerHtml = StrengthCur.ToString();

        // Convert InnerHtml to numeric values to perform subtraction
        int openingStrength = int.Parse(txtOpeningStrength.InnerHtml);  // or use double.Parse() if it's a floating point number
        int closingStrength = int.Parse(txtClosingStrength.InnerHtml);

        // Calculate NetGrowth
        int netGrowth = closingStrength - openingStrength;

        // Set the calculated NetGrowth to the InnerHtml property of txtNetGrowth
        txtNetGrowth.InnerHtml = netGrowth.ToString();
        // Ensure netGrowth and openingStrength are already defined as integers (or other numeric types)
        double netGrowthPerc = ((double)netGrowth / openingStrength) * 100;

        // Set the calculated percentage to the InnerHtml property of txtNetGrowthPerc
        txtNetGrowthPerc.InnerHtml = netGrowthPerc.ToString("F2") + "%"; // To display with 2 decimal places

        txtRegistrations.InnerHtml = registrationsCurYearAllMonth.ToString();

        txtAdmissions1.InnerHtml = AdmissionsCurYearAllMonth.ToString();
        txtAdmissions2.InnerHtml = AdmissionsPrvYearAllMonth.ToString();
        // Assuming registrations and registrationsPrv are numeric values (e.g., integers)
        int registrationsDifference = AdmissionsCurYearAllMonth - AdmissionsPrvYearAllMonth;

        // Set the difference as the InnerHtml of txtAdmissions3
        txtAdmissions3.InnerHtml = registrationsDifference.ToString();

        if (AdmissionsCurYearAllMonth < AdmissionsPrvYearAllMonth)
        {
            SpanAdmissions2.Attributes["class"] = "arrowDownRed";
            txtAdmissions3.Attributes.Add("style", "color: red;");
        }
        else
        {
            SpanAdmissions2.Attributes["class"] = "arrowUpGreen";
            txtAdmissions3.Attributes.Add("style", "color: green;");
        }

        // Ensure actualAdmissions and registrations are numeric (e.g., integers or doubles)
        if (registrationsCurYearAllMonth != 0)  // Check for division by zero
        {
            // Perform floating-point division to get a precise result
            double conversionRate = ((double)AdmissionsCurYearAllMonth / registrationsCurYearAllMonth) * 100;

            // Set the result as the InnerHtml of txtRegistrationsToAdmissionsConversion
            txtRegistrationsToAdmissionsConversion.InnerHtml = conversionRate.ToString("F2") + "%";  // Format to 2 decimal places
        }
        else
        {
            // Handle division by zero case
            txtRegistrationsToAdmissionsConversion.InnerHtml = "N/A";  // Or another appropriate message
        }

        txtWithdrawalsActual.InnerHtml = WithdrawalsCurYearAllMonth.ToString();
        txtWithdrawalsPrv.InnerHtml = WithdrawalsPrvYearAllMonth.ToString();
        // Assuming actualWithdrawals and actualWithdrawalsPrv are already numeric (int, double, etc.)
        int withdrawalsDifference = WithdrawalsCurYearAllMonth - WithdrawalsPrvYearAllMonth;

        // Assign the result to txtWithdrawalsDiff
        txtWithdrawalsDiff.InnerHtml = withdrawalsDifference.ToString();

        if (WithdrawalsCurYearAllMonth < WithdrawalsPrvYearAllMonth)
        {
            SpanWithdrawalsStatus.Attributes["class"] = "arrowDownGreen"; 
            txtWithdrawalsDiff.Attributes.Add("style", "color: green;");
        }
        else
        {
            SpanWithdrawalsStatus.Attributes["class"] = "arrowUpRed"; 
            txtWithdrawalsDiff.Attributes.Add("style", "color: red;");
        } 

        txtStrengthActual.InnerHtml = StrengthCur.ToString();
        txtStrengthPrv.InnerHtml = targetStrength.ToString();
        // Assuming actualWithdrawals and actualWithdrawalsPrv are already numeric (int, double, etc.)
        // Assuming actualStrength and targetStrength are numeric (e.g., int, double)
         
        if (targetStrength != 0) // Check for division by zero
        {
            // Perform floating-point division to get a precise result
            double targetPer = ((double)StrengthCur / targetStrength) * 100;

            // Assign the result to txtStrengthDiff
            txtStrengthDiff.InnerHtml = targetPer.ToString("F2") + "%";  // Format to 2 decimal places

            if (StrengthCur < targetStrength)
            {
                SpanStrengthStatus.Attributes["class"] = "arrowDown";
            }
            else
            {
                SpanStrengthStatus.Attributes["class"] = "arrowUp";
            }
        }
        else
        {
            // Handle division by zero case
            txtStrengthDiff.InnerHtml = "N/A"; // Or another appropriate message 
        }
    }
    private List<MyDataObject> getDashboardData()
    {
        DataTable dt = new DataTable();
        List<MyDataObject> dataList = new List<MyDataObject>();
        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        {
            using (SqlCommand cmd = new SqlCommand("ERP_BI_Data_Select", sqlcon))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Handling Region_SelectedIndex
                if (Convert.ToInt32(ViewState["RegionSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Region_Id", ViewState["RegionSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Region_Id", DBNull.Value);
                }

                // Handling Cluster_SelectedIndex
                if (Convert.ToInt32(ViewState["ClusterSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Cluster_Id", ViewState["ClusterSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Cluster_Id", DBNull.Value);
                }

                // Handling Center_SelectedIndex
                if (Convert.ToInt32(ViewState["CenterSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Center_Id", ViewState["CenterSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Center_Id", DBNull.Value);
                }

                // Handling Classess
                if (ViewState["Classess"] != null && ViewState["Classess"].ToString() != "-1")
                {
                    cmd.Parameters.AddWithValue("@Class_Name", ViewState["Classess"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Class_Name", DBNull.Value);
                }

                // Handling Year and Month 
                cmd.Parameters.AddWithValue("@Year", ViewState["YearSelectedIndexValue"]);
                //cmd.Parameters.AddWithValue("@Month", ViewState["MonthSelectedIndexValue"]);
                cmd.Parameters.AddWithValue("@Month", lstMonth.SelectedValue);
                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Initialize variables to hold parsed values
                        //int admissions, withdrawals, netGain, targetWithdrawal, targetNetGain, strength, targetStrength;
                        //int targetAdmissionFloat; int registrations;

                        int strength, targetStrength;

                        // Safely parse each field using TryParse
                        bool isStrengthParsed = int.TryParse(row["Strength"].ToString(), out strength);
                        //bool isAdmissionsParsed = int.TryParse(row["Admissions"].ToString(), out admissions);
                        //bool isTargetAdmissionParsed = int.TryParse(row["Target_Admission"].ToString(), out targetAdmissionFloat);
                        //bool isWithdrawalsParsed = int.TryParse(row["Withdrawals"].ToString(), out withdrawals);
                        //bool isTargetWithdrawalParsed = int.TryParse(row["Target_Withdrawal"].ToString(), out targetWithdrawal);
                        //bool isNetGainParsed = int.TryParse(row["NetGain"].ToString(), out netGain);
                        //bool isTargetNetGainParsed = int.TryParse(row["Target_NetGain"].ToString(), out targetNetGain);                        
                        bool isTargetStrengthParsed = int.TryParse(row["Target_Strength"].ToString(), out targetStrength);
                        //bool isRegistrationsParsed = int.TryParse(row["Registrations"].ToString(), out registrations);
                        // Add the data to the list, handling parsing failures if necessary
                        dataList.Add(new MyDataObject
                        {
                            Strength = isStrengthParsed ? strength : 0,
                            Center_Name = row["Center_Name"].ToString(),
                            //Admissions = isAdmissionsParsed ? admissions : 0,
                            //Target_Admission = isTargetAdmissionParsed ? targetAdmissionFloat : 0,
                            //Withdrawals = isWithdrawalsParsed ? withdrawals : 0,
                            //Target_Withdrawal = isTargetWithdrawalParsed ? targetWithdrawal : 0,
                            //NetGain = isNetGainParsed ? netGain : 0,
                            //Target_NetGain = isTargetNetGainParsed ? targetNetGain : 0,                            
                            Target_Strength = isTargetStrengthParsed ? targetStrength : 0,
                            //Registrations = isRegistrationsParsed ? registrations : 0
                        });
                    }
                }
            }
        }
        return dataList;
    }
    private List<MyDataObject> getDashboardDataPrvYear()
    {
        DataTable dt = new DataTable();
        List<MyDataObject> dataList = new List<MyDataObject>();
        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        {
            using (SqlCommand cmd = new SqlCommand("ERP_BI_Data_Select", sqlcon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                if (Convert.ToInt32(ViewState["RegionSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Region_Id", ViewState["RegionSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Region_Id", DBNull.Value);

                if (Convert.ToInt32(ViewState["ClusterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Cluster_Id", ViewState["ClusterSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Cluster_Id", DBNull.Value);

                if (Convert.ToInt32(ViewState["CenterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Center_Id", ViewState["CenterSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Center_Id", DBNull.Value);

                if (ViewState["Classess"].ToString() != "-1")
                    cmd.Parameters.AddWithValue("@Class_Name", ViewState["Classess"]);
                else
                    cmd.Parameters.AddWithValue("@Class_Name", DBNull.Value);

                int year = Convert.ToInt32(ViewState["YearSelectedIndexValue"]) - 1;
                cmd.Parameters.AddWithValue("@Year", year);
                string month = "12";
                cmd.Parameters.AddWithValue("@Month", month);
                //cmd.Parameters.AddWithValue("@Month", ViewState["MonthSelectedIndexValue"]);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Initialize variables to hold parsed values
                        //int admissions, withdrawals, netGain, targetWithdrawal, targetNetGain, strength, targetStrength;
                        //int targetAdmissionFloat; int registrations;

                        int strength;

                        // Safely parse each field using TryParse
                        bool isStrengthParsed = int.TryParse(row["Strength"].ToString(), out strength);
                        //bool isAdmissionsParsed = int.TryParse(row["Admissions"].ToString(), out admissions);
                        //bool isTargetAdmissionParsed = int.TryParse(row["Target_Admission"].ToString(), out targetAdmissionFloat);
                        //bool isWithdrawalsParsed = int.TryParse(row["Withdrawals"].ToString(), out withdrawals);
                        //bool isTargetWithdrawalParsed = int.TryParse(row["Target_Withdrawal"].ToString(), out targetWithdrawal);
                        //bool isNetGainParsed = int.TryParse(row["NetGain"].ToString(), out netGain);
                        //bool isTargetNetGainParsed = int.TryParse(row["Target_NetGain"].ToString(), out targetNetGain);
                        //bool isTargetStrengthParsed = int.TryParse(row["Target_Strength"].ToString(), out targetStrength);
                        //bool isRegistrationsParsed = int.TryParse(row["Registrations"].ToString(), out registrations);
                        // Add the data to the list, handling parsing failures if necessary
                        dataList.Add(new MyDataObject
                        {
                            Strength = isStrengthParsed ? strength : 0,
                            Center_Name = row["Center_Name"].ToString(),
                            //Admissions = isAdmissionsParsed ? admissions : 0,
                            //Target_Admission = isTargetAdmissionParsed ? targetAdmissionFloat : 0,
                            //Withdrawals = isWithdrawalsParsed ? withdrawals : 0,
                            //Target_Withdrawal = isTargetWithdrawalParsed ? targetWithdrawal : 0,
                            //NetGain = isNetGainParsed ? netGain : 0,
                            //Target_NetGain = isTargetNetGainParsed ? targetNetGain : 0,
                            //Target_Strength = isTargetStrengthParsed ? targetStrength : 0,
                            //Registrations = isRegistrationsParsed ? registrations : 0
                        });
                    }
                }
            }
        }
        return dataList;
    }
    private List<MyDataObject> getDashboardCurrentYearAllMonths()
    {
        DataTable dt = new DataTable();
        List<MyDataObject> dataList = new List<MyDataObject>();
        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        {
            using (SqlCommand cmd = new SqlCommand("ERP_BI_Data_Select", sqlcon))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Handling Region_SelectedIndex
                if (Convert.ToInt32(ViewState["RegionSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Region_Id", ViewState["RegionSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Region_Id", DBNull.Value);
                }

                // Handling Cluster_SelectedIndex
                if (Convert.ToInt32(ViewState["ClusterSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Cluster_Id", ViewState["ClusterSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Cluster_Id", DBNull.Value);
                }

                // Handling Center_SelectedIndex
                if (Convert.ToInt32(ViewState["CenterSelectedIndexValue"]) != -1)
                {
                    cmd.Parameters.AddWithValue("@Center_Id", ViewState["CenterSelectedIndexValue"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Center_Id", DBNull.Value);
                }

                // Handling Classess
                if (ViewState["Classess"] != null && ViewState["Classess"].ToString() != "-1")
                {
                    cmd.Parameters.AddWithValue("@Class_Name", ViewState["Classess"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Class_Name", DBNull.Value);
                }

                // Handling Year and Month 
                cmd.Parameters.AddWithValue("@Year", ViewState["YearSelectedIndexValue"]);
                cmd.Parameters.AddWithValue("@Month", ViewState["MonthSelectedIndexValue"]); 

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Initialize variables to hold parsed values
                        //int admissions, withdrawals, netGain, targetWithdrawal, targetNetGain, strength, targetStrength;
                        //int targetAdmissionFloat; int registrations;

                        int admissions, withdrawals, registrations;

                        // Safely parse each field using TryParse
                        //bool isStrengthParsed = int.TryParse(row["Strength"].ToString(), out strength);
                        bool isAdmissionsParsed = int.TryParse(row["Admissions"].ToString(), out admissions);
                        //bool isTargetAdmissionParsed = int.TryParse(row["Target_Admission"].ToString(), out targetAdmissionFloat);
                        bool isWithdrawalsParsed = int.TryParse(row["Withdrawals"].ToString(), out withdrawals);
                        //bool isTargetWithdrawalParsed = int.TryParse(row["Target_Withdrawal"].ToString(), out targetWithdrawal);
                        //bool isNetGainParsed = int.TryParse(row["NetGain"].ToString(), out netGain);
                        //bool isTargetNetGainParsed = int.TryParse(row["Target_NetGain"].ToString(), out targetNetGain);                        
                        //bool isTargetStrengthParsed = int.TryParse(row["Target_Strength"].ToString(), out targetStrength);
                        bool isRegistrationsParsed = int.TryParse(row["Registrations"].ToString(), out registrations);
                        // Add the data to the list, handling parsing failures if necessary
                        dataList.Add(new MyDataObject
                        {
                            //Strength = isStrengthParsed ? strength : 0,
                            Center_Name = row["Center_Name"].ToString(),
                            Admissions = isAdmissionsParsed ? admissions : 0,
                            //Target_Admission = isTargetAdmissionParsed ? targetAdmissionFloat : 0,
                            Withdrawals = isWithdrawalsParsed ? withdrawals : 0,
                            //Target_Withdrawal = isTargetWithdrawalParsed ? targetWithdrawal : 0,
                            //NetGain = isNetGainParsed ? netGain : 0,
                            //Target_NetGain = isTargetNetGainParsed ? targetNetGain : 0,                            
                            //Target_Strength = isTargetStrengthParsed ? targetStrength : 0,
                            Registrations = isRegistrationsParsed ? registrations : 0
                        });
                    }
                }
            }
        }
        return dataList;
    }
    private List<MyDataObject> getDashboardDataPrvYearAllMonth()
    {
        DataTable dt = new DataTable();
        List<MyDataObject> dataList = new List<MyDataObject>();
        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        {
            using (SqlCommand cmd = new SqlCommand("ERP_BI_Data_Select", sqlcon))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (Convert.ToInt32(ViewState["RegionSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Region_Id", ViewState["RegionSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Region_Id", DBNull.Value);

                if (Convert.ToInt32(ViewState["ClusterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Cluster_Id", ViewState["ClusterSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Cluster_Id", DBNull.Value);

                if (Convert.ToInt32(ViewState["CenterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Center_Id", ViewState["CenterSelectedIndexValue"]);
                else
                    cmd.Parameters.AddWithValue("@Center_Id", DBNull.Value);

                if (ViewState["Classess"].ToString() != "-1")
                    cmd.Parameters.AddWithValue("@Class_Name", ViewState["Classess"]);
                else
                    cmd.Parameters.AddWithValue("@Class_Name", DBNull.Value);

                int year = Convert.ToInt32(ViewState["YearSelectedIndexValue"]) - 1;
                cmd.Parameters.AddWithValue("@Year", year);  
                cmd.Parameters.AddWithValue("@Month", ViewState["MonthSelectedIndexValue"]);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Initialize variables to hold parsed values
                        //int admissions, withdrawals, netGain, targetWithdrawal, targetNetGain, strength, targetStrength;
                        //int targetAdmissionFloat; int registrations;

                        int admissions, withdrawals;


                        // Safely parse each field using TryParse
                        //bool isStrengthParsed = int.TryParse(row["Strength"].ToString(), out strength);
                        bool isAdmissionsParsed = int.TryParse(row["Admissions"].ToString(), out admissions);
                        //bool isTargetAdmissionParsed = int.TryParse(row["Target_Admission"].ToString(), out targetAdmissionFloat);
                        bool isWithdrawalsParsed = int.TryParse(row["Withdrawals"].ToString(), out withdrawals);
                        //bool isTargetWithdrawalParsed = int.TryParse(row["Target_Withdrawal"].ToString(), out targetWithdrawal);
                        //bool isNetGainParsed = int.TryParse(row["NetGain"].ToString(), out netGain);
                        //bool isTargetNetGainParsed = int.TryParse(row["Target_NetGain"].ToString(), out targetNetGain);
                        //bool isTargetStrengthParsed = int.TryParse(row["Target_Strength"].ToString(), out targetStrength);
                        //bool isRegistrationsParsed = int.TryParse(row["Registrations"].ToString(), out registrations);
                        // Add the data to the list, handling parsing failures if necessary
                        dataList.Add(new MyDataObject
                        {
                            //Strength = isStrengthParsed ? strength : 0,
                            Center_Name = row["Center_Name"].ToString(),
                            Admissions = isAdmissionsParsed ? admissions : 0,
                            //Target_Admission = isTargetAdmissionParsed ? targetAdmissionFloat : 0,
                            Withdrawals = isWithdrawalsParsed ? withdrawals : 0,
                            //Target_Withdrawal = isTargetWithdrawalParsed ? targetWithdrawal : 0,
                            //NetGain = isNetGainParsed ? netGain : 0,
                            //Target_NetGain = isTargetNetGainParsed ? targetNetGain : 0,
                            //Target_Strength = isTargetStrengthParsed ? targetStrength : 0,
                            //Registrations = isRegistrationsParsed ? registrations : 0
                        });
                    }
                }
            }
        }
        return dataList;
    }
    //private DataTable getClusters4Regions(int regionId)
    //{
    //    string query = "";
    //    DataTable dt = new DataTable();
    //    query = "SELECT DISTINCT Cluster_Id, Cluster_Name FROM [dbo].[ERP_BI_Branch_Cluster] " +
    //           "WHERE REGION_ID = @RegionId AND CLUSTER_ID <> 9";

    //    using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
    //    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
    //    {
    //        sqlcon.Open();
    //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    //        {
    //            da.Fill(dt);
    //        }
    //        sqlcon.Close();
    //    }
    //    return dt;
    //}
    private DataTable getClusters4Regions(int regionId)
    {
        string query = "SELECT DISTINCT Cluster_Id, Cluster_Name FROM [dbo].[ERP_BI_Branch_Cluster] " +
                       "WHERE REGION_ID = @RegionId AND CLUSTER_ID <> 9";
        DataTable dt = new DataTable();

        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            // Add the parameter to the command
            cmd.Parameters.AddWithValue("@RegionId", regionId);

            sqlcon.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            sqlcon.Close();
        }
        return dt;
    }

    private DataTable getClusters(int Branch_Id)
    {
        string query = "";
        DataTable dt = new DataTable();
        query = "SELECT DISTINCT Cluster_Id FROM [dbo].[ERP_BI_Branch_Cluster]" +
                    " WHERE Branch_Id = " + Branch_Id;

        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            sqlcon.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            sqlcon.Close();
        }
        return dt;
    }    
    private DataTable getClusterFromEmp(int EmployeeCode)
    {
        string query = "";
        DataTable dt = new DataTable();
        query = "SELECT DISTINCT Cluster_Id,Cluster_Name FROM [dbo].[ERP_BI_Branch_Cluster]" +
                    " WHERE EMP_NO = " + EmployeeCode;

        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            sqlcon.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            sqlcon.Close();
        }
        return dt;
    }
    private DataTable getCenters(int regionId, int clusterId)
    {
        string query = "";
        DataTable dt = new DataTable();
        query = "SELECT Branch_Id, Branch_Name FROM ERP_BI_Branch_Cluster" +
                    " WHERE Region_Id = " + regionId + " AND Cluster_Id = " + clusterId;

        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            sqlcon.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            sqlcon.Close();
        }
        return dt;
    }
    private string getClassesComaSepration(int EmployeeCode)
    {
        string query = "";
        string ClassesName = "";
        query = "SELECT Class_Name FROM [dbo].[ERP_BI_EMP_Classes]" +
                    " WHERE EmployeeCode = " + EmployeeCode;

        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            sqlcon.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Process the data
                while (reader.Read())
                {
                    // Example: Get values from the reader
                    //int id = reader.GetInt32(0); // Assuming the first column is an integer
                    ClassesName = reader.GetString(0); // Assuming the second column is a string 
                }
            }
            sqlcon.Close();
        }
        return ClassesName;
    }
    private DataTable getClasses(int centerId)
    {
        string query = "";
        DataTable dt = new DataTable();
        //query = "SELECT distinct Class_Name FROM [dbo].[ERP_BI_Data] " +
        // "WHERE Branch_Id = " + centerId + " ORDER BY classorder DESC;"; 

        query = "SELECT Class_Name FROM [dbo].[ERP_BI_Data] " +
        "WHERE Branch_Id = " + centerId + " " +
        "GROUP BY Class_Name " +
        "ORDER BY MAX(classorder) Asc;";


        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
        {
            sqlcon.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            sqlcon.Close();
        }
        return dt;
    }     
    private List<MyDataObjectNew> getCapcity()
    {
        DataTable dt = new DataTable();
        List<MyDataObjectNew> dataList = new List<MyDataObjectNew>();
        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=172.18.19.210;Initial Catalog=AIMS;Persist Security Info=True;User ID=sa;Password=City)(*!@#123"))
        {
            using (SqlCommand cmd = new SqlCommand("ERP_BI_Data_Branch_Capacity_Select", sqlcon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt32(ViewState["RegionSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Region_Id", ViewState["RegionSelectedIndexValue"]);
                if (Convert.ToInt32(ViewState["ClusterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Cluster_Id", ViewState["ClusterSelectedIndexValue"]);
                if (Convert.ToInt32(ViewState["CenterSelectedIndexValue"]) != -1)
                    cmd.Parameters.AddWithValue("@Center_Id", ViewState["CenterSelectedIndexValue"]);                
                cmd.Parameters.AddWithValue("@Year", ViewState["YearSelectedIndexValue"]); 

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Initialize variables to hold parsed values
                        int capacity;

                        // Safely parse each field using TryParse
                        bool isCapacityParsed = int.TryParse(row["CAPACITY"].ToString(), out capacity);
                        // Add the data to the list, handling parsing failures if necessary
                        dataList.Add(new MyDataObjectNew
                        {
                            Capacity = decimal.Parse(row["Capacity"].ToString()) 
                        });
                    }
                }
            }
        }
        return dataList;
    }
}
public class MyDataObject
{
    public string Center_Name { get; set; }
    public int Admissions { get; set; }
    public int Target_Admission { get; set; }
    public int Withdrawals { get; set; }
    public int Target_Withdrawal { get; set; }
    public int NetGain { get; set; }
    public int Target_NetGain { get; set; }
    public int Strength { get; set; }
    public int Target_Strength { get; set; }
    public int Registrations { get; set; }
}
public class MyDataObjectNew
{
    public decimal Capacity { get; set; } 
}