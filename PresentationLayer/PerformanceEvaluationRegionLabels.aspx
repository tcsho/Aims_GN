<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="PerformanceEvaluationRegionLabels.aspx.cs" Inherits="PresentationLayer_PerformanceEvaluationRegionLabels" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta charset="UTF-8">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="3600">
        <Scripts>
            <%-- <asp:ScriptReference Path="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" action="" autocomplete="off" method="POST" enctype="multipart/form-data">
        <ContentTemplate>
            <script type="text/javascript">             
                // New method added by Adil
                function adjustTextDirection() {
                    // Find all labels with class 'description-label'
                    var labels = document.getElementsByClassName('description-label');

                    for (var i = 0; i < labels.length; i++) {
                        var label = labels[i];
                        var text = label.innerText;

                        // Regular expression to check if the text contains Urdu characters
                        //var urduRegex = /[\u0600-\u06FF]/;
                        // Regular expression to check if the text contains Arabic characters
                        var urduRegex = /[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB1D-\uFB4F\uFE70-\uFEFF]/;
                      

                        if (urduRegex.test(text)) {
                            label.setAttribute('dir', 'rtl');
                            label.style.textAlign = 'right';
                            label.style.fontFamily = " Arial, sans-serif";
                        } else {
                            label.setAttribute('dir', 'ltr');
                            label.style.textAlign = 'left';
                            label.style.fontFamily = "Arial, sans-serif";
                        }
                    }
                }
                Sys.Application.add_load(function () {
                    adjustTextDirection();
                });
                function setUrdu() {

                    var txtBoxId = '<%= txtCritName.ClientID %>';
                    var style = document.createElement('style');
                    style.innerHTML = `#${txtBoxId} {direction: rtl; font-family: 'Nafees Nastaleeq', Arial, sans-serif; }`;
                    document.head.appendChild(style);
                };
                function setEnglish() {
                    var txtBoxId = '<%= txtCritName.ClientID %>';
                    var style = document.createElement('style');
                    style.innerHTML = `#${txtBoxId} {direction: ltr; font-family: 'Arial, sans-serif; }`;
                    document.head.appendChild(style);
                };

            </script>
            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);


                    function document_Ready() {

                        jq(document).ready(function () {



                            //****************************************************************



                            try {


                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',

                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [2, 4, 6, 7, 8]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
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
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Performance Activity Criteria"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">Class :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">Term:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_term" runat="server" AutoPostBack="True"
                                            CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1"></td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                                            Font-Bold="False" ValidationGroup="btnNew">
                                            Add New Activity</asp:LinkButton></td>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%" colspan="2">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">Add New Information
                                            </td>
                                        </tr>


                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">

                                            <tr>
                                                <td style="width: 8px; height: 21px" class="tr1"></td>
                                                <td style="width: 350px" class="tr1" valign="top" align="right">Subject :
                                                </td>
                                                <td style="width: 510px; height: 25px" class="tr1">
                                                    <asp:DropDownList ID="list_subject" runat="server" AutoPostBack="false" CssClass="dropdownlist"
                                                        Width="217px"
                                                        AppendDataBoundItems="True" Height="26px">
                                                    </asp:DropDownList>
                                                    <span class="pull-right">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldlist_subject" runat="server" InitialValue="0" ControlToValidate="list_subject" CssClass="label label-danger" ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator></span>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td style="width: 8px; height: 21px" class="tr1"></td>
                                                <td style="width: 350px" class="tr1" valign="top" align="right">Activity Name:
                                                </td>
                                                <td style="width: 510px; height: 25px" class="tr1">
                                                    <asp:TextBox ID="txtCritName" runat="server" ClientIDMode="Static" Width="400px"></asp:TextBox>
                                                    <span class="pull-right">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldActivity" runat="server" ControlToValidate="txtCritName" CssClass="label label-danger" ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator></span>
                                                    <button onclick="setUrdu()">Switch to Urdu</button>
                                                    <button onclick="setEnglish()">Switch to English</button></td>
                        </td>
                    </tr>

                    <tr>
                        <td class="tr1" style="width: 8px; height: 21px">&nbsp;</td>
                        <td align="right" class="tr1" style="width: 350px" valign="top">Sort Order in Result Card:</td>
                        <td class="tr1" style="width: 510px; height: 25px">
                            <asp:TextBox ID="txtSortOrder" runat="server" Width="80px" MaxLength="5" TextMode="Number"></asp:TextBox>
                            <span class="pull-right">
                                <asp:RequiredFieldValidator ID="RequiredFieldtxtSortOrder" runat="server" ControlToValidate="txtSortOrder" CssClass="label label-danger" ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td class="tr1" style="width: 8px; height: 18px">&nbsp;</td>
                        <td align="right" class="tr1" style="width: 350px; height: 18px" valign="top">Region :
                        </td>
                        <td style="width: 60%; height: 50%" align="left" class="tr1">
                            <asp:CheckBox ID="chkSoth" runat="server" Text="South" Checked="true" />
                            <asp:CheckBox ID="chkCentral" runat="server" Text="Central" Checked="true" />
                            <asp:CheckBox ID="chkNorth" runat="server" Text="North" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tr2" style="width: 8px; height: 18px">&nbsp;</td>
                        <td align="right" class="tr2" style="width: 350px; height: 18px" valign="top"></td>
                        <td class="tr2" style="width: 60%; height: 25px">
                            <asp:DropDownList ID="list_EvlType" runat="server" AutoPostBack="True"
                                CssClass="dropdownlist"
                                OnSelectedIndexChanged="list_EvlType_SelectedIndexChanged" Width="217px"
                                Height="16px" Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 8px; height: 19px" class=""></td>
                        <td style="height: 19px" class="" align="center" colspan="2">
                            <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" ValidationGroup="Submit" CssClass="btn btn-primary"
                                Text="Save"></asp:Button>
                            &nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;
                        </td>

                    </tr>
            </table>
            </asp:Panel>
                        </td>
                    </tr>


                    <tr style="width: 100%">
                        <td align="left" style="width: 100%;" colspan="2">
                            <asp:GridView ID="gvSubjects" runat="server"
                                AutoGenerateColumns="False"
                                CssClass="datatable table table-striped table-responsive"
                                EmptyDataText="No Record Exists." OnPreRender="gvSubjects_PreRender">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:BoundField DataField="SubKndItmLbl_Id" SortExpression="SubKndItmLbl_Id"
                                        HeaderText="SubKndItmLbl_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class_Name">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Type" SortExpression="Type"
                                        HeaderText="Type">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name"
                                        HeaderText="Subject_Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Head" HeaderText="Item_Head">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' CssClass='<%# Eval("Subject_Name").ToString() == "Urdu" ? "description-label" : "description-label1" %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OrderOfPer" HeaderText="Sort Order (Report)">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Region" HeaderText="Region Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server"
                                                CommandArgument='<%# Eval("SubKndItmLbl_Id") %>' ForeColor="#004999"
                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server"
                                                CommandArgument='<%# Eval("SubKndItmLbl_Id") %>' ForeColor="#004999"
                                                ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <RowStyle CssClass="tr1" />
                            </asp:GridView>
                        </td>
                    </tr>

            <tr id="trSave" runat="server" style="width: 100%">
                <td style="height: 19px; text-align: center" align="right" colspan="2">&nbsp;</td>
            </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>


