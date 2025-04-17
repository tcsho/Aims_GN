<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="SefEvaluation.aspx.cs" Inherits="PresentationLayer_SefEvaluation"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--Bootstrap tabs--%>
            <asp:ScriptReference Path="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                function closeModalTest() {

                    $('#TestModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                $(function () {
                    $("#tabs").tabs();
                });


               // function printPageArea(areaID) {
               //     var printContent = document.getElementById(areaID).innerHTML;
               //     var originalContent = document.body.innerHTML;
               //     document.body.innerHTML = printContent;
               //     window.print();
               //     document.body.innerHTML = originalContent;
               // }

                    function printPageArea(areaID) {
    var printContent = document.getElementById(areaID).innerHTML;

    // The CSS styles you're using
    var styles = `
        <style>
            body {
                margin: 0;
                padding: 0;
                overflow: visible !important; /* Ensure no scrollbar */
            }
            html, body {
                width: auto;
                height: auto;
            }
            .tableCon {
                width: 100%;
                border-collapse: collapse;
            }
            .tableCon th, .tableCon td {
                padding: 8px 12px;
                border: 1px solid #ccc;
                text-align: center;
                font-family: Inter, sans-serif;
            }
            .tablemainheader {
                text-align: left;
            }
            .tableCon th {
                background-color: #f4f4f4;
                font-weight: 600;
            }
            .year, .category {
                background-color: #203764 !important;
                color: #fff;
            }
            .mainHeader {
                background-color: #808080 !important;
                text-align: left !important;
                color: #fff;
            }
            .SecondRow {
                background-color: #D9E1F2 !important;
                color: #000;
            }
            .subject {
                background-color: #eff0f0;
            }
            .resultrow {
                background-color: #203764;
                color: #fff;
            }
            .value {
                color: #2a2e3e;
            }
            .consolidationTable {
                height: auto; /* Ensure it grows with content */
                overflow: visible !important; /* No scrollbars */
                border: 1px solid #777777;
            }
            .category {
                position: sticky;
                top: 0;
                z-index: 2;
            }
        </style>
    `;

    // Open a new window for printing without setting width and height explicitly
    var printWindow = window.open('', 'PrintWindow', '');

    // Write the content to the new window, including styles and the printable content
    printWindow.document.write(`
        <html>
        <head>
<title>SIQA Endorsed School Grade</title>
            ${styles} <!-- Include your styles here -->
        </head>
        <body>
            ${printContent}
        </body>
        </html>
    `);

    // Ensure the document is fully loaded before triggering print
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
   // printWindow.close();
}

            </script>



            <style>
                .tableCon {
                    width: 100%;
                    border-collapse: collapse;
                }

                    .tableCon th, .tableCon td {
                        padding: 8px 12px;
                        border: 1px solid #ccc;
                        text-align: center;
                        font-family: Inter, sans-serif;
                    }

                .tablemainheader {
                    text-align: left;
                }

                .tableCon th {
                    background-color: #f4f4f4;
                    font-weight: 600;
                }

                .year, .category {
                    background-color: #203764 !important;
                    color: #fff;
                }

                .mainHeader {
                    background-color: #808080 !important;
                    text-align: left !important;
                    color: #fff;
                }

                .SecondRow {
                    background-color: #D9E1F2 !important;
                    color: #000;
                }

                .subject {
                    background-color: #eff0f0;
                }

                .resultrow {
                    background-color: #203764;
                    color: #fff;
                }

                .value {
                    color: #2a2e3e;
                }

                .consolidationTable {
                    height: 500px;
                    overflow: scroll;
                    border: 1px solid #777777;
                }

                .category {
                    position: sticky;
                    top: 0;
                    z-index: 2;
                }
            </style>
            <div class="main_div" style="align=center;">
                <br />
                <div class="titlesection" runat="server" id="divSearchCriteria">
                    Self-evaluation Form
                </div>
                <br />
                <div style="height: 15px" align="right">
                    <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                        Text="Search"></asp:Button>&nbsp;&nbsp;
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary"
                                Text="Save" OnClick="btnsave_Click"></asp:Button>



                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary"
                        Text="Cancel" OnClick="Button1_Click1"></asp:Button>

                    <asp:Button ID="btnprint" runat="server" CssClass="btn btn-success"
                                Text="Print" OnClientClick="printPageArea('ConsolidationHistory')"></asp:Button>
                    
                </div>
                <div cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0" runat="server" id="tblSearch">
                    <div class="row">
                        <div class="col-xl-2 col-lg-2 col-md-2"></div>
                        <div class="col-xl-8 col-lg-8 col-md-8">
                            <div class="form-group">
                                <label class="TextLabelMandatory40">Region :</label>
                                <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="true" CssClass="dropdownlist form-control"
                                    OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="250px">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="TextLabelMandatory40">Center :</label>
                                <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist form-control"
                                    Width="250px" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="TextLabelMandatory40">Session :</label>
                                <asp:DropDownList ID="ddl_Session" runat="server" CssClass="dropdownlist form-control"
                                    Width="250px" OnSelectedIndexChanged="ddl_Session_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="TextLabelMandatory40">Key Stages :</label>
                                <asp:DropDownList ID="ddl_grouphead" runat="server" AutoPostBack="true" CssClass="dropdownlist form-control" Width="250px"
                                    OnSelectedIndexChanged="ddl_grouphead_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-xl-2 col-lg-2 col-md-2"></div>
                    </div>
                </div>
                <asp:Label ID="lblerror" runat="server"></asp:Label>
            </div>
            <div id="show_Ph" runat="server" visible="false">
                <div>
                    <div class="vh-100" id="tabs">
                        <ul class="nav nav-tabs" id="PS_Tabs" runat="server">
                            <li><a data-toggle="tab" href="#PS1">PS 1</a></li>
                            <li><a data-toggle="tab" href="#PS2">PS 2</a></li>
                            <li><a data-toggle="tab" href="#PS3">PS 3</a></li>
                            <li><a data-toggle="tab" href="#PS4">PS 4</a></li>
                            <li><a data-toggle="tab" href="#PS5">PS 5</a></li>
                            <li><a data-toggle="tab" href="#PS6">PS 6</a></li>
                            <li><a data-toggle="tab" href="#Consolidation">CONSOLIDATION</a></li>
                            <li><a data-toggle="tab" href="#ConsolidationHistory">SIQA Endorsed Consolidations</a></li>
                        </ul>
                        <%--<asp:label id="lblerror" runat="server"></asp:label>--%>
                        <div class="tab-content" runat="server">
                            <div id="PS1" class="tab-pane fade">
                                <div id="PS1Container" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Performance Standard 1: Student Achievement</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Overall grade</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="4">1.3 Learning skills</th>
                                            </tr>
                                            <tr>
                                                <td>1.3.1</td>
                                                <td>Students' engagement in, and responsibility for, their own learning</td>
                                                <td rowspan="4" title="LO:Student_Learning_Skills_Grade_Final">
                                                    <asp:DropDownList ID="ddl_1_3_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_1_3_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1.3.2</td>
                                                <td>Students' interactions, collaboration and communcation skills</td>
                                            </tr>
                                            <tr>
                                                <td>1.3.3</td>
                                                <td>Application of learning to the world and making connections between areas of learning</td>
                                            </tr>
                                            <tr>
                                                <td>1.3.4</td>
                                                <td>Innovation, enterprise, enquiry, research, critical thinking and use of learning technologies</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:Panel ID="ps1_child" runat="server">
                                        <asp:GridView ID="gvps1child" SkinID="GridView" runat="server" AutoGenerateColumns="False" class="div div-dark"
                                            AllowSorting="true" AllowPaging="true" PageSize="500" OnRowDataBound="gvps1child_RowDataBound" DataKeyNames="PSI_ID"
                                            EmptyDataText="No Record Exists." Width="100%">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="100%">
                                                    <ItemTemplate>
                                                        <div cellpadding="0" cellspacing="0" style="div-layout: fixed; height: 92%; width: 100%; vertical-align: top;">
                                                            <div align="left" valign="top" style="word-wrap: break-word" class="studentgrid">
                                                                <div class="row" id="divsubcomments" runat="server">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <%--<span class="rollno"><%# Eval("Subject_Name") %></span>--%>
                                                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject_Name") %>'></asp:Label>
                                                                        <asp:Label ID="lblsubjectid" runat="server" Text='<%# Eval("Subject_Id")  %>' Visible="false"></asp:Label>
                                                                    </div>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <table class="main_table col-lg-12" border="1">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th colspan="2">Indicator</th>
                                                                                    <th>Grade</th>
                                                                                    <th>Overall grade</th>
                                                                                    <th colspan="2">Indicator</th>
                                                                                    <th>Grade</th>
                                                                                    <th>Overall grade</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <th colspan="4">1.1 Attainment</th>
                                                                                    <th colspan="4">1.2 Progress</th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>1.1.1</td>
                                                                                    <td>Attainment EoY (AIMS+ reports)</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddl_1_1_1_grade" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td rowspan="3">
                                                                                        <asp:DropDownList ID="ddl_1_1_overall_grade" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>1.2.1</td>
                                                                                    <td>Progress of students (AIMS+ reports)</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddl_1_2_1_grade" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td rowspan="3">
                                                                                        <asp:DropDownList ID="ddl_1_2_overall_grade" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>1.1.2</td>
                                                                                    <td style="font-weight: bold" title="NB:Knowledge_Skills_1_1_2_Grade_final">Knowledge, skills, understanding</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddl_1_1_2_grade" runat="server" CssClass="form-control">
                                                                                            <%-- <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                    <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                    <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>--%>
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td rowspan="2">1.2.2</td>
                                                                                    <td rowspan="2" style="font-weight: bold" title="LO:Student_Progress_Grade_Final">Progress in lessons (LO consolidation)</td>
                                                                                    <td rowspan="2">
                                                                                        <asp:DropDownList ID="ddl_1_2_2_grade" runat="server" CssClass="form-control">
                                                                                            <%--    <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                    <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                    <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>--%>
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>1.1.3</td>
                                                                                    <td>Attainment trends (AIMS+ reports)</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddl_1_1_3_grade" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                                                            <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                                                            <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="divheader" />
                                            <SelectedRowStyle CssClass="div_select" BackColor="#FFE0C0" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div id="PS2" class="tab-pane fade">
                                <div id="PS2Container" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Performance Standard 2: Students’ personal, social and emotional development, and their innovation skills</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="6">2.1. Personal Development</th>
                                            </tr>
                                            <tr>
                                                <td>2.1.1<br />
                                                    2.1.2</td>
                                                <td>Attitudes, behaviour and relationships (triangulate with 5.2.1, and use the LO consolidation sheet)</td>
                                                <td title="LO:Attitudes_Relationships_Grade_Final">
                                                    <%--<asp:DropDownList ID="ddl_2_1_1_and_2_1_2_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                                    <asp:DropDownList ID="ddl_2_1_1_and_2_1_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_2_1_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkbx_2_1_1_and_2_1_2_lo_form" runat="server" />
                                                    LO Form<br />
                                                    <asp:CheckBox ID="chkbx_2_1_1_and_2_1_2_dlws" runat="server" />
                                                    DLWs<br />
                                                    <asp:CheckBox ID="chkbx_2_1_1_and_2_1_2_incident_log" runat="server" />
                                                    Incident log<br />
                                                    <asp:CheckBox ID="chkbx_2_1_1_and_2_1_2_survey_responses" runat="server" />
                                                    Survey reponses<br />
                                                    <asp:CheckBox ID="chkbx_2_1_1_and_2_1_2_uniform_defaulter_log" runat="server" />
                                                    Uniform defaulter log
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_2_1_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2.1.3</td>
                                                <td>Adoption of safe and healthy lifestyles (triangulate with 5.1.4)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_2_1_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkbx_2_1_3_dlws" runat="server" />
                                                    DLWs
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2.1.4</td>
                                                <td>Attendance and punctuality</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_2_1_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkbx_2_1_4_attendance_registers" runat="server" />
                                                    Attendance registers<br />
                                                    <asp:CheckBox ID="chkbx_2_1_4_tardy_late_arrival_log" runat="server" />
                                                    Tardy/Late arrival log
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl2_1_5" runat="server" Text="2.1.5" Font-Size="11px"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl2_1_5Desc" runat="server" Text="Care and classroom routines (use the LO consolidation sheet)" Font-Size="11px" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_2_1_5_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkbx_2_1_5_lo_consolidation" runat="server" />
                                                    LO consolidation
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="5">2.2. Social Values</th>
                                            </tr>
                                            <tr>
                                                <td>2.2.1</td>
                                                <td>Students' appreciation of social values and respect for Pakistani heritage and culture</td>
                                                <td rowspan="2">
                                                    <asp:DropDownList ID="ddl_2_2_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:CheckBox ID="chkbx_2_2_evidence_source_dlws" runat="server" />
                                                    DLWs<br />
                                                    <asp:CheckBox ID="chkbx_2_2_evidence_source_incident_log" runat="server" />
                                                    Incident log<br />
                                                    <asp:CheckBox ID="chkbx_2_2_evidence_source_survey_responses" runat="server" />
                                                    Survey responses<br />
                                                    <asp:CheckBox ID="chkbx_2_2_evidence_source_impressions_from_lo" runat="server" />
                                                    Impressions from LO
                                                </td>
                                                <td rowspan="2">
                                                    <asp:TextBox ID="txt_2_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2.2.2</td>
                                                <td>Understanding & appreciation of world cultures and respect for all religions</td>
                                            </tr>
                                            <tr>
                                                <th colspan="5">2.3. Social Responsibility and Innovation Skills</th>
                                            </tr>
                                            <tr>
                                                <td>2.3.1</td>
                                                <td>Community involvement, volunteering and social contribution</td>
                                                <td rowspan="2">
                                                    <asp:DropDownList ID="ddl_2_3_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:CheckBox ID="chkbx_2_3_evidence_source_dlws" runat="server" />
                                                    DLWs<br />
                                                    <asp:CheckBox ID="chkbx_2_3_evidence_source_cocurricular_activities" runat="server" />
                                                    Co-curricular activities
                                                </td>
                                                <td rowspan="2">
                                                    <asp:TextBox ID="txt_2_3_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2.3.2</td>
                                                <td>Environmental awareness and actions</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div id="PS3" class="tab-pane fade">
                                <div id="PS3Container" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Performance Standard 3: Teaching and Assessment</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Overall grade</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="4">3.1 Teaching for effective learning</th>
                                            </tr>
                                            <tr>
                                                <td>3.1.1</td>
                                                <td>Teachers' knowledge of their subjects and how students learn them</td>
                                                <td rowspan="5" title="LO:Lesson_Planning_Grade_Final">
                                                    <asp:DropDownList ID="ddl_3_1_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="5">
                                                    <asp:TextBox ID="txt_3_1_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3.1.2</td>
                                                <td>Lesson planning</td>
                                            </tr>
                                            <tr>
                                                <td>3.1.3</td>
                                                <td>Teaching strategies to meet the needs of individual and group of students</td>
                                            </tr>
                                            <tr>
                                                <td>3.1.4</td>
                                                <td>Classroom interactions and student engagement</td>
                                            </tr>
                                            <tr>
                                                <td>3.1.5</td>
                                                <td>Classroom management</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="6">3.2 Assessment</th>
                                            </tr>
                                            <tr>
                                                <td>3.2.1</td>
                                                <td>Internal assessment processes (use the overall grading of the quality of tasks from the NB consolidation as well)</td>
                                                <td title="NB:Quality_of_Tasks_Grade_Final">
                                                    <asp:DropDownList ID="ddl_3_2_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="3">
                                                    <asp:DropDownList ID="ddl_3_2_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:CheckBox ID="chkbx_3_2_evidence_source_progress_trackers" runat="server" />
                                                    Progress trackers<br />
                                                    <asp:CheckBox ID="chkbx_3_2_evidence_source_ieps" runat="server" />
                                                    IEPs<br />
                                                    <asp:CheckBox ID="chkbx_3_2_evidence_source_assessment_formats" runat="server" />
                                                    Assessment formats<br />
                                                    <asp:CheckBox ID="chkbx_3_2_evidence_source_aims_reports" runat="server" />
                                                    AIMS + reports
                                                </td>
                                                <td rowspan="3">
                                                    <asp:TextBox ID="txt_3_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3.2.2</td>
                                                <td>Analysis of assessment data to monitor students' progress (reflect on the quality of IEPs as well and the use of these to inform teaching)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_3_2_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3.2.3</td>
                                                <td>Use of assessment information to support students' learning (use the overall assessment grades from the NB consolidation)</td>
                                                <td title="NB:Assessment_Grade_Final">
                                                    <asp:DropDownList ID="ddl_3_2_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkbx_3_2_evidence_source_nb_consolidation" runat="server" />
                                                    NB consolidation
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div id="PS4" class="tab-pane fade">
                                <div id="PS4Container" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Performance Standard 4: Curriculum</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="5">4.1 Curriculum Implementation</th>
                                            </tr>
                                            <tr runat="server" id="Conditional_row_ps_4_for_eyfs_ks1_ks2_ks3">
                                                <td>4.1.2</td>
                                                <td colspan="2">Cross-curricular links (triangulate with the overall grade for 3.1)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_1_overall_grade_eyfs_ks1_ks2_ks3" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_4_1_explain_judgements_eyfs_ks1_ks2_ks3" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Conditional_row1_ps_4_for_ks4_ks5_matric">
                                                <td>4.1.1</td>
                                                <td>Curricular choices</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_1_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList ID="ddl_4_1_overall_grade_ks4_ks5_matric" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:TextBox ID="txt_4_1_explain_judgements_ks4_ks5_matric" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Conditional_row2_ps_4_for_ks4_ks5_matric">
                                                <td>4.1.2 </td>
                                                <td>Cross-curricular links (triangulate with the overall grade for 3.1)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_1_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="6">4.2 Curriculum adaptation</th>
                                            </tr>
                                            <tr>
                                                <td>4.2.1</td>
                                                <td style="font-weight: bold" title="LO:Need_Ability_Group_Grade_Final">Adaptation of curriculum to meet the needs of all students</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_2_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <%-- <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="3">
                                                    <asp:DropDownList ID="ddl_4_2_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="3">
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_lo_consolidation" runat="server" />
                                                    LO Consolidation<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_nb_consolidation" runat="server" />
                                                    NB Consolidation<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_co_extra_curricular_activities" runat="server" />
                                                    Co and extra curricular activities<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_clubs_societies" runat="server" />
                                                    Clubs and societies<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_event_log" runat="server" />
                                                    Event log<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_morning_assemblies" runat="server" />
                                                    Morning assemblies<br />
                                                    <asp:CheckBox ID="Chkbx_4_2_evidence_source_activity_calendar" runat="server" />
                                                    Activity calendar
                                                </td>
                                                <td rowspan="3">
                                                    <asp:TextBox ID="txt_4_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4.2.2</td>
                                                <td>Enhancement, enterprise and innovation</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_2_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4.2.3</td>
                                                <td>Links with Pakistani culture and society</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_4_2_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div id="PS5" class="tab-pane fade">
                                <div id="PS5Container" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Performance Standard 5: The protection, care, guidance and support of students</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="6">5.1 Health and safety, including arrangements for safeguarding</th>
                                            </tr>
                                            <tr>
                                                <td>5.1.1</td>
                                                <td>Care, welfare and safeguarding of students</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_1_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_5_1_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_5_1_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_5_1_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5.1.2</td>
                                                <td>Record keeping</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_1_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5.1.3</td>
                                                <td>Maintenance of premises and facilities</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_1_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5.1.4</td>
                                                <td>Provision for, and promotion of healthy lifestyles (triangulate with 2.1.3)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_1_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="6">5.2 Care and Support</th>
                                            </tr>
                                            <tr>
                                                <td>5.2.1</td>
                                                <td>Staff-student relationships and behaviour management (triangulate with 2.1.1, 2.1.2, 2.1.5)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_2_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_5_2_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_5_2_eveidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_5_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>5.2.2 </td>
                                                <td>Promotion and management of attendance and punctuality (match it with 2.1.4)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_2_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5.2.3</td>
                                                <td>Identification and support of students with additional education needs (AEN) (triangulate with PI 3.2)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_2_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Condional_row_ps_5_for_ks3_ks4_ks5_matric">
                                                <td>5.2.4</td>
                                                <td>Career guidance and counselling</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_5_2_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <div id="PS6" class="tab-pane fade">
                                <div id="PS6Container" runat="server" clientidmode="Static">
                                    <h3 style="color: #FFFFFF; background: -webkit-linear-gradient(left, #0c4da2 , White); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 20px; text-align: left;">Performance Standard 6: Leadership and Management</h3>
                                    <table class="main_table col-lg-12" border="1">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Indicator</th>
                                                <th>Grade</th>
                                                <th>Overall grade</th>
                                                <th>Evidence source</th>
                                                <th>Explain the judgements</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th colspan="6">6.1 The effectiveness of leadership</th>
                                            </tr>
                                            <tr>
                                                <td>6.1.1</td>
                                                <td>Vision and direction</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_1_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_6_1_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_1_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_1_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.1.2 </td>
                                                <td>Educational leadership (match with the quality of teaching)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_1_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.1.3</td>
                                                <td>Relationships and communication</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_1_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.1.4</td>
                                                <td>Capacity to innovate and improve (triangulate with 6.2.4)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_1_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="6">6.2 Self-evaluation and improvement planning</th>
                                            </tr>
                                            <tr>
                                                <td>6.2.1</td>
                                                <td>Processes for school self-evaluation</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_2_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_6_2_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_2_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.2.2 </td>
                                                <td>The processes and impact of school improvement planning</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_2_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.2.3</td>
                                                <td>Monitoring and evaluation of teaching and learning in relation to students’ achievement (match with the quality of teaching)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_2_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.2.4</td>
                                                <td>Improvement over time (reflect on the previous SEF grades and SIQA reports)</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_2_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="6">6.3 Partnerships with parents and community</th>
                                            </tr>
                                            <tr>
                                                <td>6.3.1</td>
                                                <td>Parental involvement</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_3_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_6_3_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_3_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_3_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.3.2 </td>
                                                <td>Communication and reporting</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_3_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.3.3</td>
                                                <td>Community, national and relevant international partnerships</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_3_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="6">6.4 Management, staffing, facilities and resources</th>
                                            </tr>
                                            <tr>
                                                <td>6.4.1</td>
                                                <td>Management of the day-to-day life of the school</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_4_1_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:DropDownList ID="ddl_6_4_overall_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_4_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txt_6_4_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.4.2 </td>
                                                <td>Sufficiency, deployment and development of suitably qualified staff to optimize student achievements</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_4_2_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.4.3</td>
                                                <td>Allocation of space and utilization of learning facilities</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_4_3_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6.4.4</td>
                                                <td>The relevance and range of resources for effective teaching and learning</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_6_4_4_grade" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                        <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <%--<div id="PS6" class="tab-pane fade">
                        <div id="PS6Container" runat="server" clientidmode="Static">
                            <h3 class="titlesection">Performance Standard 6: Leadership and Management</h3>
                            <table class="main_table col-lg-12" border="1">
                                <thead>
                                    <tr>
                                        <th colspan="2">Indicator</th>
                                        <th>Grade</th>
                                        <th>Overall grade</th>
                                        <th>Evidence source</th>
                                        <th>Explain the judgements</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th colspan="6">6.1 The effectiveness of leadership</th>
                                    </tr>
                                    <tr>
                                        <td>6.1.1</td>
                                        <td>Vision and direction</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_1_1_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:DropDownList ID="ddl_6_1_overall_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_1_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_1_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.1.2 </td>
                                        <td>Educational leadership (match with the quality of teaching)</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_1_2_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.1.3</td>
                                        <td>Relationships and communication</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_1_3_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.1.4</td>
                                        <td>Capacity to innovate and improve (triangulate with 6.2.4)</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_1_4_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="6">6.2 Self-evaluation and improvement planning</th>
                                    </tr>
                                    <tr>
                                        <td>6.2.1</td>
                                        <td>Processes for school self-evaluation</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_2_1_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:DropDownList ID="ddl_6_2_overall_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_2_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_2_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.2.2 </td>
                                        <td>The processes and impact of school improvement planning</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_2_2_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.2.3</td>
                                        <td>Monitoring and evaluation of teaching and learning in relation to students’ achievement (match with the quality of teaching)</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_2_3_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.2.4</td>
                                        <td>Improvement over time (reflect on the previous SEF grades and SIQA reports)</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_2_4_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="6">6.3 Partnerships with parents and community</th>
                                    </tr>
                                    <tr>
                                        <td>6.3.1</td>
                                        <td>Parental involvement</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_3_1_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:DropDownList ID="ddl_6_3_overall_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_3_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_3_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.3.2 </td>
                                        <td>Communication and reporting</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_3_2_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.3.3</td>
                                        <td>Community, national and relevant international partnerships</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_3_3_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="6">6.4 Management, staffing, facilities and resources</th>
                                    </tr>
                                    <tr>
                                        <td>6.4.1</td>
                                        <td>Management of the day-to-day life of the school</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_4_1_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:DropDownList ID="ddl_6_4_overall_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_4_evidence_source" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td rowspan="4">
                                            <asp:TextBox ID="txt_6_4_explain_judgements" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Justify the grade and list down specific elements/areas that need improvement"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.4.2 </td>
                                        <td>Sufficiency, deployment and development of suitably qualified staff to optimize student achievements</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_4_2_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.4.3</td>
                                        <td>Allocation of space and utilization of learning facilities</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_4_3_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6.2.4</td>
                                        <td>The relevance and range of resources for effective teaching and learning</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_6_4_4_grade" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="Acc" Value="Acc"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>--%>
                            <div id="Consolidation" class="tab-pane fade">
                                <div id="ConContainer" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">Consolidations</h3>
                                    <div class="consolidationTable">
                                        <table class="tableCon">

                                            <tr>
                                                <th colspan="2" class="category"></th>
                                                <%--<th class="category">Year</th>--%>
                                                <th class="category">EYFS</th>
                                                <th class="category">KS1</th>
                                                <th class="category">KS2</th>
                                                <th class="category">KS3</th>
                                                <th class="category">KS4</th>
                                                <th class="category">KS5</th>
                                                <th class="category">Matric</th>
                                            </tr>
                                            <tr>
                                                <th class="mainHeader" colspan="10">Performance Standard 1: Student Achievement</th>
                                            </tr>
                                            <asp:Literal ID="Htmlbody" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 2: Students’ personal, social and emotional development</th>
                                            </tr>

                                            <asp:Literal ID="HtmlPS2" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 3: Teaching and assessment</th>
                                            </tr>

                                            <asp:Literal ID="HtmlPS3" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 4: Curriculum</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS4" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 5: The protection, care, guidance and support of students</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS5" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 6: Leadership and management</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS6" runat="server"></asp:Literal>



                                            <asp:Literal ID="HtmlKeyStage" runat="server"></asp:Literal>



                                            <tr>
                                                <td class='resultrow' rowspan='1' colspan='2'>Key stage-wise judgement</td>
                                                <%-- <td><asp:Label ID="sessionKeyJudg" CssClass="fontsizelbl" runat="server"></asp:Label></td>--%>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_EYFS" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS1" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS2" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS3" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS4" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS5" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_Matric" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>



                                            </tr>

                                            <tr>
                                                <td colspan="10"></td>
                                            </tr>


                                            <asp:Literal ID="htmlOverallPerfJudg" runat="server"></asp:Literal>


                                            <tr>
                                                <td class='resultrow' rowspan='1' colspan='2'>Overall performance judgement (School's Grade)</td>
                                                <%-- <td><asp:Label ID="sessionOverallJudg" CssClass="fontsizelbl" runat="server"></asp:Label></td>--%>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_Overall_Perf_All" runat="server" CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <%--<td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_KS1" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>
            <td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_KS2" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>
            <td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_KS3" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>
            <td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_KS4" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>
            <td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_KS5" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>
            <td style="padding:0px"><asp:DropDownList ID="ddl_Overall_Perf_Matric" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                    </asp:DropDownList></td>--%>
                                            </tr>
                                        </table>
                                        <br />
                                        <div style="height: 15px" align="center">


                                            <table class="table" width="100%">
                                                <tr align="center">
                                                    <td colspan="3">
                                                        <asp:Button ID="btn_ConSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btn_ConSave_Click"></asp:Button></td>
                                                    <td>
                                                        <asp:Button ID="btn_ConSiqaEndrosed" runat="server" CssClass="btn btn-primary"
                                                            Text="SIQA Endorsed" OnClick="btn_ConSiqaEndrosed_Click"></asp:Button></td>
                                                </tr>
                                            </table>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="ConsolidationHistory" class="tab-pane fade">
                                <div id="ConContainerHistory" runat="server" clientidmode="Static">
                                    <h3 class="titlesection">SIQA Endorsed School Grade</h3>
                                    <div class="consolidationTable">
                                        <table class="tableCon">
                                            <tr>
                                                <th colspan="2" class="category"></th>
                                                <th class="category">EYFS</th>
                                                <th class="category">KS1</th>
                                                <th class="category">KS2</th>
                                                <th class="category">KS3</th>
                                                <th class="category">KS4</th>
                                                <th class="category">KS5</th>
                                                <th class="category">Matric</th>
                                            </tr>
                                            <tr>
                                                <th class="mainHeader" colspan="10">Performance Standard 1: Student Achievement</th>
                                            </tr>
                                            <asp:Literal ID="HtmlbodyHistory" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 2: Students’ personal, social and emotional development</th>
                                            </tr>

                                            <asp:Literal ID="HtmlPS2History" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 3: Teaching and assessment</th>
                                            </tr>

                                            <asp:Literal ID="HtmlPS3History" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 4: Curriculum</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS4History" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 5: The protection, care, guidance and support of students</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS5History" runat="server"></asp:Literal>

                                            <tr>
                                                <th class="mainHeader" colspan="9">Performance Standard 6: Leadership and management</th>
                                            </tr>
                                            <asp:Literal ID="HtmlPS6History" runat="server"></asp:Literal>
                                            <asp:Literal ID="HtmlKeyStageHistory" runat="server"></asp:Literal>
                                            <tr>
                                                <td class='resultrow' rowspan='1' colspan='2'>Key stage-wise judgement</td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_EYFSHistory" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS1History" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS2History" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS3History" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS4History" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_KS5History" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_KS_wise_MatricHistory" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td colspan="10"></td>
                                            </tr>
                                            <asp:Literal ID="htmlOverallPerfJudgHistory" runat="server"></asp:Literal>
                                            <tr>
                                                <td class='resultrow' rowspan='1' colspan='2'>Overall performance judgement (School's Grade)</td>

                                                <td style="padding: 0px">
                                                    <asp:DropDownList ID="ddl_Overall_Perf_AllHistory" runat="server" CssClass="form-control" Enabled="false">
                                                        <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    </asp:DropDownList></td>

                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/loading.gif" Height="100%"
                    Width="100%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            color: #000000;
            font-size: medium;
        }

        .auto-style2 {
            color: #000066;
            font-size: medium;
        }

        .form-control {
            display: inline-block !important;
        }


        th {
            font-size: 1.4em;
            padding: 5px 0px;
            font-weight: 700;
        }

        .fontsizelbl {
            font-size: 11px;
        }
    </style>
</asp:Content>

