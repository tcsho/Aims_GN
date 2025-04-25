<%@ Page Title="Dashboard BI" Language="C#" MasterPageFile="~/PresentationLayer/MasterPageBIDashboard.master"
    AutoEventWireup="true" CodeFile="dashboardBIMIS.aspx.cs" Inherits="PresentationLayer_dashboardBI" Theme="BlueTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
        <link href="https://fonts.googleapis.com/css2?family=Gothic+A1:wght@300;400;500;600;700&display=swap" rel="stylesheet" />
        <title>Dashboard</title>

        <%--<link rel="stylesheet" href="dashboardBI.css" />--%>
        <link rel="stylesheet" href="BIDashboard.css" />
    </head>
    <body>
        <div class="dashboard">
            <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
                <div class="dropdown col-lg-2">
                    <%--<label for="region">Region:</label>--%>
                    <asp:DropDownList ID="lstRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstRegion_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Select Region" Value="-1"></asp:ListItem>--%>
                        <asp:ListItem Text="Central" Value="40000000"></asp:ListItem>
                        <asp:ListItem Text="North" Value="30000000"></asp:ListItem>
                        <asp:ListItem Text="South" Value="20000000"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dropdown col-lg-2">
                    <%--<label for="cluster">Cluster:</label>--%>
                    <asp:DropDownList ID="lstCluster" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstCluster_SelectedIndexChanged">
                        <%-- <asp:ListItem Text="Select Cluster" Value="-1"></asp:ListItem>--%>
                        <asp:ListItem Text="Cluster 1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Cluster 2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Cluster 3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Cluster 4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Cluster 5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Cluster 6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Cluster 7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Cluster 8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Cluster 9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="Cluster Zero" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dropdown col-lg-2">
                    <%--<label for="cluster">Cluster:</label>--%>
                    <asp:DropDownList ID="lstCenters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstCenters_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Select Center" Value="-1"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="dropdown col-lg-2">
                    <%--<label for="cluster">Cluster:</label>--%>
                    <asp:DropDownList ID="lstClasses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstClasses_SelectedIndexChanged">
                        <%-- <asp:ListItem Text="Select Class" Value="-1"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="dropdown col-lg-2">
                    <%--<label for="year">Year:</label>--%>
                    <asp:DropDownList ID="lstYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstYear_SelectedIndexChanged">
                        <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                        <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dropdown col-lg-2">
                    <%-- <label for="month">Month:</label>--%>
                    <asp:DropDownList ID="lstMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstMonth_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Select Month" Value="-1"></asp:ListItem>--%>
                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                        <asp:ListItem Text="March" Value="3"></asp:ListItem>
                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="June" Value="6"></asp:ListItem>
                        <asp:ListItem Text="July" Value="7"></asp:ListItem>
                        <asp:ListItem Text="August" Value="8"></asp:ListItem>
                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="container new-styles">
                <div class="row custom-row">
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Opening Strength</label>
                        <div class="row">
                            <div class="col-lg-12">
                                <p id="txtOpeningStrength" runat="server"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Registrations</label>
                        <div class="row">
                            <div class="col-lg-12">
                                <p id="txtRegistrations" runat="server">
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Withdrawals</label>
                        <div class="row">
                            <div class="col-lg-4">
                                <p id="txtWithdrawalsActual" runat="server">
                                </p>
                            </div>
                            <div class="col-lg-4">
                                <span id="SpanWithdrawalsStatus" runat="server"></span>
                                <br />
                                <p id="txtWithdrawalsDiff" runat="server" style="font-size: 18px; color: #12AD2B"></p>
                            </div>
                            <div class="col-lg-4">
                                <p id="txtWithdrawalsPrv" runat="server" style="height: 5px;"></p>
                                <br />
                                <span style="font-size: 11px !important; font-weight: bold;">SPLY</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row custom-row">
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Closing Strength</label>
                        <div class="row">
                            <div class="col-lg-12">
                                <p id="txtClosingStrength" runat="server"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Admissions</label>
                        <div class="row">
                            <div class="col-lg-4">
                                <p id="txtAdmissions1" runat="server">
                                </p>
                            </div>
                            <div class="col-lg-4">
                                <span id="SpanAdmissions2" runat="server"></span>
                                <br />
                                <p id="txtAdmissions3" runat="server" style="font-size: 18px; color: #12AD2B">
                                </p>
                            </div>
                            <div class="col-lg-4">
                                <p id="txtAdmissions2" runat="server" style="height: 5px;"></p>
                                <br />
                                <span style="font-size: 11px !important; font-weight: bold;">SPLY</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Strength</label>
                        <div class="row">
                            <div class="col-lg-4">
                                <p id="txtStrengthActual" runat="server">
                                </p>
                            </div>
                            <div class="col-lg-4">
                                <span id="SpanStrengthStatus" runat="server"></span>
                                <br />
                                <p id="txtStrengthDiff" runat="server" style="font-size: 18px;"></p>
                            </div>
                            <div class="col-lg-4">
                                <p id="txtStrengthPrv" runat="server" style="height: 5px;"></p>
                                <br />
                                <span style="font-size: 11px !important; font-weight: bold;">Target</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row custom-row">
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Net Growth</label>
                        <div class="row">
                            <div class="col-lg-12">
                                <p id="txtNetGrowth" runat="server" style="color: #12AD2B"></p>
                                <p id="txtNetGrowthPerc" runat="server" style="font-size: 18px;"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <label class="heading">Registrations to Admissions Conversion(YTD)</label>
                        <div class="row">
                            <div class="col-lg-12">
                                <p id="txtRegistrationsToAdmissionsConversion" runat="server">
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-lg-4 custom-col">
                        <div class="row">
                            <div class="col-lg-12">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tblContainer">
                <table id="myTable">
                    <thead>
                        <tr>
                            <th>Center Name</th>
                            <th>Registrations</th>
                            <th>Admissions</th>
                            <th>Admissions Pattern</th>
                            <th>Admissions SPLY</th>
                            <th>Withdrawals</th>
                            <th>Withdrawals Pattern</th>
                            <th>Withdrawals SPLY</th>
                        </tr>
                    </thead>
                    <tbody id="tbody" runat="server">
                    </tbody>
                </table>
            </div>
        </div>
    </body>
    </html>
</asp:Content>