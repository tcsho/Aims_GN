<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="EvaluationCriteriaCenter.aspx.cs" Inherits="PresentationLayer_TCS_EvaluationCriteriaCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="A Level midyear Exam Criteria"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                    </td>
                                    <td style="width: 60%" align="right">
                                        <asp:Button runat="server" ID="btnLockcenter" Text="Lock Center" CssClass="btn btn-danger"
                                            OnClick="btnLockcenter_click" Visible="false" />
                                        <asp:Button runat="server" ID="btnUnlock" Text="Unlock Center" CssClass="btn btn-warning"
                                            OnClick="btnUnLockcenter_click" Visible="false" />
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Region*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="217px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Center*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="217px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Class*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_Class" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_AdmTest_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Term*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Subject*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            Width="217px" AppendDataBoundItems="True" OnSelectedIndexChanged="list_AdmTestDetail_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                    </td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        &nbsp;
                                    </td>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%" colspan="2">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px" class="titlesection" colspan="2">
                            Subject Wise Component Details
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%; text-align: center" colspan="2">
                            <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                Width="100%" OnSelectedIndexChanged="gvQuestions_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:BoundField DataField="ECC_Id" SortExpression="ECC_Id" HeaderText="ECC_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Evaluation_Criteria_Id" SortExpression="Evaluation_Criteria_Id"
                                        HeaderText="Evaluation_Criteria_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Criteria" HeaderText="Criteria">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Marks" HeaderText="Total Marks">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Weightage" HeaderText="Weightage">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Weightage" HeaderText="Subject Weightage">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("ECC_Id") %>'
                                                Visible='<%# Convert.ToBoolean( Eval("Lock"))==false %>' OnClick="btnEdit_Click"
                                                ToolTip="Edit Record">
                                                <span class="glyphicon glyphicon-pencil"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Visible='<%# Convert.ToBoolean( Eval("Lock"))==true %>'>
                                               
                                                <span class="glyphicon glyphicon-ban-circle"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("ECC_Id") %>'
                                                Visible='<%# Convert.ToBoolean( Eval("Lock"))==false %>' OnClick="btnDelete_Click"
                                                ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');">
                                                <span class="glyphicon glyphicon-trash"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ECC_Id") %>'
                                                Visible='<%# Convert.ToBoolean( Eval("Lock"))==true %>'>
                                                 
                                                <span class="glyphicon glyphicon-ban-circle"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <RowStyle CssClass="tr1" />
                            </asp:GridView>
                        </td>
                    </tr>
                     <tr>
     <td style="height: 22px" class="titlesection" colspan="2">
         Subject Wise Component Details Deleted
     </td>
 </tr>
 <asp:GridView ID="gvNewGrid" runat="server" AutoGenerateColumns="False" BorderStyle="None"
    Width="100%" OnSelectedIndexChanged="gvNewGrid_SelectedIndexChanged" OnRowDataBound="gvNewGrid_RowDataBound"
    CssClass="table table-striped table-bordered table-hover">
    <Columns>
        <asp:BoundField DataField="ECC_Id" SortExpression="ECC_Id" HeaderText="ECC_Id">
            <ItemStyle CssClass="hide" />
            <HeaderStyle CssClass="hide" />
        </asp:BoundField>
        <asp:BoundField DataField="Evaluation_Criteria_Id" SortExpression="Evaluation_Criteria_Id"
            HeaderText="Evaluation_Criteria_Id">
            <ItemStyle CssClass="hide" />
            <HeaderStyle CssClass="hide" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Sr. #">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" Width="5%" />
            <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px" />
        </asp:TemplateField>
        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
            <HeaderStyle HorizontalAlign="Left" Width="25%" />
            <ItemStyle HorizontalAlign="Left" Width="25%" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Criteria" HeaderText="Criteria">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Total_Marks" HeaderText="Total Marks">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Weightage" HeaderText="Weightage">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:BoundField DataField="Total_Weightage" HeaderText="Subject Weightage">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Undo">
            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemTemplate>
    <asp:LinkButton ID="btnrevert" runat="server" CommandArgument='<%# Eval("ECC_Id") %>'
         OnClick="btnRevert_Click"
        ToolTip="Record Undo" OnClientClick="javascript:return confirm('Are you sure you want to Undo Records?');">
        <span class="glyphicon glyphicon-repeat"></span>
    </asp:LinkButton>
</ItemTemplate>

        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
    <RowStyle CssClass="tr1" />
</asp:GridView>


                    <tr id="trSave" runat="server" style="width: 100%">
                        <td style="height: 19px; text-align: center" align="right" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr1" runat="server" style="width: 100%">
                        <td style="height: 19px; text-align: center" align="right" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr2" runat="server" style="width: 100%">
                        <td style="height: 19px; text-align: center" align="right" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%; text-align: center" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
            </table>
            </td> </tr>
            <tr>
                <td valign="top" colspan="3" style="height: 200px">
                    <asp:Panel ID="pan_New" runat="server" Width="100%" Height="75%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="height: 22px" class="titlesection">
                                        Subject Component Detail
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td style="height: 10px" class="tr2">
                                                </td>
                                                <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right">
                                                </td>
                                                <td style="width: 510px; height: 10px" class="tr2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 8px; height: 21px" class="tr2">
                                                </td>
                                                <td class="TextLabelMandatory40">
                                                    Component Code:
                                                </td>
                                                <td style="width: 75px; height: 25px" class="tr2">
                                                    <asp:TextBox ID="txtCriteria" runat="server" Width="250px" ReadOnly="true" BackColor="Khaki"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 8px; height: 21px" class="tr2">
                                                </td>
                                                <td class="TextLabelMandatory40">
                                                    Total Marks:
                                                </td>
                                                <td style="width: 75px; height: 25px" class="tr2">
                                                    <asp:TextBox ID="txtTotalMarks" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 8px; height: 21px" class="tr2">
                                                </td>
                                                <td class="TextLabelMandatory40">
                                                    Weightage:
                                                </td>
                                                <td style="width: 75px; height: 25px" class="tr2">
                                                    <asp:TextBox ID="txtWeitage" runat="server" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 8px; height: 11px" class="tr2">
                                                </td>
                                                <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                </td>
                                                <td style="width: 510px; height: 11px" class="tr2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 19px; text-align: center; width: 100%" align="center" colspan="3">
                                                    <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                        Text="Save"></asp:Button>&nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                                            runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel">
                                                        </asp:Button>&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    &nbsp;
                </td>
            </tr>
            </tbody> </table>
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
