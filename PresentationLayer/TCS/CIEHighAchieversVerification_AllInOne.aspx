<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CIEHighAchieversVerification_AllInOne.aspx.cs"
    Inherits="PresentationLayer_TCS_CIEHighAchieversVerification_AllInOne" Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);


                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************

                            try {
                                jq('table.datatable').DataTable({
                                    destroy: true,
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                        "<'row'<'col-sm-12'tr>>" +
                                        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                    ]

                                    ,
                                    tableTools:
                                    {
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [

                                            ]
                                    }
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": -1, 'bLengthChange': true
                                    , "order": [[0, "asc"]], "paging": true, "ordering": false, "searching": true, "info": true, "scrollX": false
                                    , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                        "sEmptyTable": 'No Rows to Display.....!',
                                        "sSearch": "Search :"
                                    }
                                }
                                );
                            }
                            catch (err) {
                                alert('datatable ' + err);
                            }

                            //****************************************************************



                        }
                        );

                    } //end of documnet_ready()



                    //Re-bind for callbacks
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {
                        jq(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    }
                    );

                });
            </script>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="CAIE High Achievers Verification"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr style="width: 100%">
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1"></td>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">Select Criteria
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr id="trMoId" runat="server">
                                                    <td class="TextLabelMandatory40">Main Organization* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                            Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="rfv_mOrg" runat="server" Width="200px" Enabled="False"
                                                            ErrorMessage="Mian Org is a required Field" Display="Dynamic" ControlToValidate="ddl_MOrg"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trCountry" runat="server">
                                                    <td class="TextLabelMandatory40">Main Organization Country* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                                            ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>


                                                <tr id="trregion" runat="server">
                                                    <td class="TextLabelMandatory40">Region :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr id="tr3" runat="server">
                                                    <td class="TextLabelMandatory40">School:
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>



                                                <tr id="tr2">
                                                    <td class="TextLabelMandatory40">Academic Year* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="167px"
                                                            Enabled="False" ErrorMessage="Academic Year is a required Field" Display="Dynamic"
                                                            ControlToValidate="ddlSession" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                              <%--  <tr id="trclass">
                                                    <td class="TextLabelMandatory40">Grade Level* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlclass" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
                                                            <asp:ListItem Enabled="true" Text="Select Month" Value="-1"></asp:ListItem>
                                                            <asp:ListItem Text="GCE O LEVEL" Value="GCE O LEVEL"></asp:ListItem>
                                                            <asp:ListItem Text="GCE AS & A Level" Value="GCE AS & A Level"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="167px"
                                                            Enabled="False" ErrorMessage="Grade Level is a required Field" Display="Dynamic"
                                                            ControlToValidate="ddlclass" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>--%>
                                                <tr id="tr4">
                                                    <td class="TextLabelMandatory40" valign="top">Result Month and Level* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlResultMonth" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlResultMonth_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="167px" Enabled="False"
                                                            ErrorMessage="Result Month is a required Field" Display="Dynamic" ControlToValidate="ddlResultMonth"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="trSave" runat="server" style="text-align: center">
                                        <td colspan="13">
                                            
                                            <asp:Button ID="btnUnVerified" runat="server" CssClass="btn btn-danger active" OnClick="btnUnVerified_Click"
                                                Text="Unlocked"></asp:Button>
                                            <asp:Button ID="btnVerifiefd" runat="server" CssClass="btn btn-success active" OnClick="btnVerified_Click"
                                                Text="Locked"></asp:Button>
                                            <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn-info" OnClick="btnShowAll_Click"
                                                Text="Show All"></asp:Button>

                                        <%--    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                             
                                           

                                            <asp:Button ID="btnAcknowledge" runat="server" CssClass="btn btn-success active" OnClick="btnAcknowledge_Click"
                                                Text="Acknowledge"></asp:Button>

                                        </td>
                                    </tr>

                                    <tr id="trCDT" runat="server" visible="True">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">List of student(s) appeard in CIE
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                                <table>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trGVOpt" runat="server" visible="false">
                                        <td align="right" colspan="13" style="height: 19px; text-align: right">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                CssClass="datatable table table-striped table-bordered table-hover"
                                                AllowPaging="false"
                                                OnPreRender="dg_student_PreRender">
                                                <HeaderStyle Font-Bold="true" />
                                                <Columns>
                                                    <asp:BoundField DataField="HA_Id" HeaderText="HA_Id">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="SortOrder" HeaderText="SortOrder" SortExpression="SortOrder">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="IsVerify" HeaderText="Studnet IsVerify">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IsLock" HeaderText="Studnet IsLock">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Sr. #">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="GLevel" HeaderText="Class Name">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Student_Id" HeaderText="Roll #">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CIEStudentName" HeaderText="Student Name">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:BoundField>


                                                    <asp:BoundField DataField="AStarCalculated" HeaderText="A* (AIMS)">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:BoundField>


                                                    <asp:BoundField DataField="AGradeCalculated" HeaderText="A (AIMS)">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="A* (Campus Verified)">
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemTemplate>
                                                            <span id="Span31" runat="server" visible='<%# (Eval("isLock").ToString())=="True" %>'
                                                                style="font-size: 14px;">
                                                                <%# Eval("AStar")%></span>

                                                            <asp:TextBox runat="server" ID="txtAStar" CssClass="form-control"
                                                                Visible='<%# (Eval("isLock").ToString())=="False" %>'
                                                                Text='<%# Eval("AStar")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="A (Campus Verified)">
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemTemplate>
                                                            <span id="Span3" runat="server" visible='<%# (Eval("isLock").ToString())=="True" %>'
                                                                style="font-size: 14px;">
                                                                <%# Eval("A")%></span>

                                                            <asp:TextBox runat="server" ID="txtAGrade" CssClass="form-control"
                                                                Visible='<%# (Eval("isLock").ToString())=="False" %>'
                                                                Text='<%# Eval("A")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Verification Status">
                                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnVerify" runat="server" CommandArgument='<%# Eval("HA_Id") %>'
                                                                ToolTip="Click to Verify" CssClass="btn btn-danger active"
                                                                Visible='<%# Convert.ToBoolean(Eval("IsVerify"))==false  && Convert.ToBoolean(Eval("IsLock"))==false  %>' Text="Not Verified" OnClick="BtnVerify_Click">
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="btnUnverify" runat="server" CommandArgument='<%# Eval("HA_Id") %>'
                                                                ToolTip="Verified" CssClass="btn btn-success active"
                                                                Visible='<%# Convert.ToBoolean(Eval("IsVerify"))==true && Convert.ToBoolean(Eval("IsLock"))==false   %>' Text="Verified" OnClick="btnUnverify_Click">
                                     
                                                            </asp:LinkButton>


                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("HA_Id") %>'
                                                                ToolTip="Unlock" CssClass="btn btn-warning"
                                                                Visible='<%# Convert.ToBoolean(Eval("IsLock"))==true && (Session["UserType_Id"].ToString()=="5")  %>' Text="UnLock"
                                                                OnClick="BtnUnlock_Click">
                                     
                                                            </asp:LinkButton>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>




                                                </Columns>
                                            </asp:GridView>
                                            <asp:Label ID="lblNoDatadt" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;"></td>
                    </tr>
                    <tr id="Tr1" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center"></td>
                    </tr>
                    <tr id="btnGen" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%"
                    Width="100%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>


