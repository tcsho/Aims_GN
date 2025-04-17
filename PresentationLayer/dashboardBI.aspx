<%@ Page Title="Dashboard BI" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="dashboardBI.aspx.cs" Inherits="PresentationLayer_dashboardBI" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                function ViewStudentDetail() {
                    $('#ViewStudentDetailModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }


                function ViewUnregisteredParents() {
                    $('#ViewUnregisteredParentsModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }


                function ViewUnRegisteredStudentDetail() {
                    $('#ViewUnRegisteredStudentDetailModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }


                function ViewUnmarkedhomeworkdiaryDetail() {
                    $('#ViewUnmarkedhomeworkdiaryModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }

                function ViewUnmarkedDailyworkDetail() {
                    $('#ViewUnmarkedDailyworkDetailModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }

                function ViewUnmarkedDailyworkDetail() {
                    $('#ViewClasstestresultDetailModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }


                function showSpinner() {
                    document.getElementById('myspindiv').style.display = 'block';
                }


            </script>
            <!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>Dashboard</title>
                <link rel="stylesheet" href="dashboardBI.css">
                <style type="text/css">
                    .dropdownClass {
                        box-shadow: 1px 1px 5px 3px #eee;
                        padding: 1% 1% 1% 1%;
                    }

                    .vertical-row {
                        Float: left;
                        height: 100px;
                        width: 1px; /* edit this if you want */
                        background-color: blue
                    }

                    .scrollable-container {
                        overflow-x: auto; /* Enable horizontal scrolling */
                        width: 100%; /* Full width of the modal */
                        max-height: 400px; /* Optional: limit the height if needed */
                        white-space: nowrap; /* Prevent the table from wrapping */
                    }

                    .datatable {
                        width: auto; /* Ensure the table width adjusts based on content */
                        min-width: 150%; /* Optional: set a minimum width */
                    }
                </style>
            </head>
            <body>
                <div class="dashboard">

                    <div class="row" style="margin-top: 10px; margin-bottom: 10px; border-bottom: 3px solid #eee;">
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Select Session:</label>
                            <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True"
                                CssClass="dropdownlist form-control">
                            </asp:DropDownList>

                        </div>
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Select Region:</label>
                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" onchange="showSpinner();">
                            </asp:DropDownList>
                        </div>
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Date:</label>
                            <asp:TextBox ID="text_date" runat="server" CssClass="textbox" MaxLength="50" Height="34px" AutoPostBack="true" OnTextChanged="text_date_TextChanged" onchange="showSpinner();"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="text_date">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Select School:</label>
                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True"
                                CssClass="dropdownlist form-control"
                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" onchange="showSpinner();">
                            </asp:DropDownList>

                        </div>
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Select Class:</label>
                            <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" onchange="showSpinner();">
                            </asp:DropDownList>

                        </div>
                        <div class="dropdownClass col-lg-2">
                            <label for="category">Select Subject:</label>
                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged" onchange="showSpinner();">
                            </asp:DropDownList>

                        </div>
                        <div id="myspindiv" style="display: none;">
                            <center>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="10%"
                                    Width="10%" /></center>

                        </div>
                    </div>

                    <div class="">
                        <div class="row">
                            <%--1--%>
                            <div class="col-lg-6" style="text-align: center; border-right: 1px solid #eee;">
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">
                                        <%-- <div class="col-lg-12" style="text-align: left">
                                            <asp:Label ID="Label9" runat="server" class="heading" Style="font-size: 25px; color: black;">Mobile App Registration</asp:Label>
                                             
                                        </div>--%>
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="sfsdfds" runat="server" class="heading" Style="font-size: 22px; color: blue;">Parents</asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblregisteredparents" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label1" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1">Registered</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">

                                                    <div>
                                                        <%--<asp:Label ID="lbltotalparents_percentage" runat="server" Text="" Style="font-size: 40px; color: black;"></asp:Label>--%>
                                                        <asp:LinkButton ID="lbltotalparents_percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lbltotalparents_percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lbltotalparents" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label2" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1;">Total</asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">

                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="Label6" runat="server" class="heading" Style="font-size: 22px; color: blue;">Attendance</asp:Label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblmarkedatten" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label8" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1">Present</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div>
                                                        <%--<asp:Label ID="lbltstudents_percentage" runat="server" Text="" Style="font-size: 40px; color: black"></asp:Label>--%>
                                                        <asp:LinkButton ID="lbltstudents_percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lbltstudents_percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lbltstudents" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label11" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1;">Total</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="Label7" runat="server" class="heading" Style="font-size: 22px; color: blue;">Classwork</asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblclasswork" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label10" runat="server" class="heading" Text="Class Work" Style="font-size: 18px; color: #b9b1b1"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <%--<asp:Label ID="lblclasswork_Percentage" runat="server" Style="font-size: 40px; color: black"></asp:Label>--%>
                                                        <asp:LinkButton ID="lblclasswork_Percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lblclasswork_Percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <a id="lblclassworktotal" runat="server" style="font-size: 22px; font-weight: bold; color: black"></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">

                                                        <asp:Label ID="lblss" runat="server" class="heading" Text="Total" Style="font-size: 18px; color: #b9b1b1;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              <%--  <div style="">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div style="text-align: center">
                                                <asp:Label ID="Label23" runat="server" class="heading" Style="font-size: 22px; color: blue;">Queries and complaints </asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label24" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label25" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label26" runat="server" Style="font-size: 22px; color: #b9b1b1"> Coming Soon</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <a id="A2" runat="server" style="font-size: 22px; font-weight: bold; color: black"></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">

                                                        <asp:Label ID="Label27" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="col-lg-6" style="text-align: center; border-right: 1px solid #eee;">
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">
                                        <div class="col-lg-12" style="text-align: left">
                                            <%--<asp:Label ID="Label13" runat="server" class="heading" Style="font-size: 25px; color: black;">Mobile App</asp:Label>--%>
                                            <%-- <br /><br />--%>
                                        </div>
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="Label5" runat="server" class="heading" Style="font-size: 22px; color: blue;">Students</asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblregisteredstudents" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label3" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1">Registered</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <%--<asp:Label ID="lbltotalstudents_percentage" runat="server" Style="font-size: 40px; color: black"></asp:Label>--%>
                                                        <asp:LinkButton ID="lbltotalstudents_percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lbltotalstudents_percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <a id="lbltotalstudents" runat="server" style="font-size: 22px; font-weight: bold; color: black"></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">

                                                        <asp:Label ID="Label4" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1;">Total</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="Label12" runat="server" class="heading" Style="font-size: 22px; color: blue;">Homework diary </asp:Label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblactivesections" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label14" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1">Diary Marked</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <%--    <asp:Label ID="lbltotalsections_percentage" runat="server" Style="font-size: 40px; color: black"></asp:Label>--%>
                                                        <asp:LinkButton ID="lbltotalsections_percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lbltotalsections_percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lbltotalsections" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">

                                                        <asp:Label ID="Label16" runat="server" class="heading" Style="font-size: 18px; color: #b9b1b1;">Total</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="border-bottom: 3px solid #eee">
                                    <div class="row">
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Label ID="Label17" runat="server" class="heading" Style="font-size: 22px; color: blue;">Class Test Results </asp:Label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lblclasstestresult" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"> </asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="Label19" runat="server" class="heading" Text="Test Result" Style="font-size: 18px; color: #b9b1b1"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <%--  <asp:Label ID="lblResult_percentage" runat="server" Style="font-size: 40px; color: black"></asp:Label>--%>
                                                        <asp:LinkButton ID="lblResult_percentage" runat="server" Text="" Style="font-size: 40px; color: black" OnClick="lblResult_percentage_Click" OnClientClick="$('#myspindiv').show();"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">
                                                        <asp:Label ID="lbltotalstudentsforclassresult" runat="server" Text="" Style="font-size: 22px; font-weight: bold; color: black"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div style="text-align: center">

                                                        <asp:Label ID="Label22" runat="server" Text="Total" class="heading" Style="font-size: 18px; color: #b9b1b1;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
            </body>
            </html>

            <div class="container">
                <div class="modal fade" id="ViewStudentDetailModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Absent Students</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="but_Export" TabIndex="4" OnClick="but_Export_Click" runat="server"
                                        CssClass="btn btn-primary" Text="Export"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvstudentdetail" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvstudentdetail_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="First_Name" HeaderText="Student Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Student_Email" HeaderText="Student Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FatherEmail" HeaderText="Father Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Father_CellNo" HeaderText="Father Mobile #">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="container">
                <div class="modal fade" id="ViewUnregisteredParentsModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Unregistered Parents</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="btnunregisteredexport" TabIndex="4" runat="server" OnClick="btnunregisteredexport_Click"
                                        CssClass="btn btn-primary" Text="Export"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvunregisteredparents" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvunregisteredparents_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Father_CNIC" HeaderText="Father CNIC">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FatherEmail" HeaderText="Father Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Father_CellNo" HeaderText="Father Mobile #">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="container">
                <div class="modal fade" id="ViewUnRegisteredStudentDetailModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Unregistered Students</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="btnunregisteredstudentexport" TabIndex="4" OnClick="btnunregisteredstudentexport_Click" runat="server"
                                        CssClass="btn btn-primary" Text="Export"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvunregisteredstudentdetail" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvunregisteredstudentdetail_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="First_Name" HeaderText="Student Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Student_Email" HeaderText="Student Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FatherEmail" HeaderText="Father Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Father_CellNo" HeaderText="Father Mobile #">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="container">
                <div class="modal fade" id="ViewUnmarkedhomeworkdiaryModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Unmarked Homework Diary</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="btnunmarkedhomeworkdiaryexport" TabIndex="4" OnClick="btnunmarkedhomeworkdiaryexport_Click" runat="server"
                                        CssClass="btn btn-primary" Text="Export"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvunmarkedhomeworkdiary" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvunmarkedhomeworkdiary_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubjectName" HeaderText="Subject">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="container">
                <div class="modal fade" id="ViewUnmarkedDailyworkDetailModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Unmarked Classwork</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="Btnexportunmarkedclasswork" TabIndex="4" runat="server"
                                        CssClass="btn btn-primary" Text="Export" OnClick="Btnexportunmarkedclasswork_Click"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvunmarkedClasswork" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvunmarkedhomeworkdiary_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubjectName" HeaderText="Subject">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="container">
                <div class="modal fade" id="ViewClasstestresultDetailModal">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Missing Class Test Result</h4>
                            </div>
                            <div class="modal-body">
                                <!-- Scrollable container -->
                                <div style="margin-left: 88%;">
                                    <asp:Button ID="btnmissingclasstestresultexport" TabIndex="4" runat="server"
                                        CssClass="btn btn-primary" Text="Export" OnClick="btnmissingclasstestresultexport_Click"></asp:Button>
                                </div>
                                <div class="scrollable-container">
                                    <asp:GridView ID="gvclasstestresultdetail" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvclasstestresultdetail_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--   <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="First_Name" HeaderText="Student Name">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
