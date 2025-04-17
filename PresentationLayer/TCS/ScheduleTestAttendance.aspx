<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ScheduleTestAttendance.aspx.cs" Inherits="PresentationLayer_TCS_ScheduleTestAttendance"
    Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
<%--            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />--%>

        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                <tbody>
               
                <tr>
                   <td colspan="5">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Schedule Test Attendance"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                </tr>
                <tr style="height: 5px">
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 100%" align="center">
                                 <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                                 <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Student No *:</td>
                                    <td align="left" style="width: 60%">
                                        <asp:TextBox ID="txtStudentNo" runat="server" Width="140px" CssClass="text"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnSearchStudent" runat="server" CausesValidation="false" 
                                                    CssClass="btn btn-primary" OnClick="btnSearchStudent_Click" Text="Search Student" 
                                                    Width="157px" />
                                    </td>
                                </tr>
                                <tr>
                        <td class="titlesection" colspan="7">
                            Student Detail
                        </td>
                    </tr>

                     <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    <tr class="tr1">
                                        <td width="2%" height="25">
                                            &nbsp;
                                        </td>
                                        <td align="right" width="21%">
                                            Student No :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:Label ID="lblStudentNo" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" width="24%">
                                            First Name :
                                        </td>
                                        <td width="26%">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td style="height: 25px" width="2%">
                                            &nbsp;
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Date of Birth:
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Gender :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td style="height: 25px">
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Class :
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:Label ID="lblClass" runat="server"></asp:Label>
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Section :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:Label ID="lblSection" runat="server"></asp:Label>
                                            <asp:Label ID="lblsectionid" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25">
                                        </td>
                                        <td align="right">
                                            Region :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            Center :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCenter" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td height="25">
                                        </td>
                                        <td align="right">
                                            Phone No :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            Term:</td>
                                        <td>
                                            <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" 
                                                CssClass="dropdownlist" 
                                                OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="180px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                        </td>
                    </tr>

                                  
                                 </table>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="2">
                                   <asp:GridView ID="gvShowAck" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" 
                                EmptyDataText="No Record Exists." onrowcommand="gvShowAck_RowCommand" 
                                        onsorting="gvShowAck_Sorting">
                                <Columns>

                                    <asp:BoundField DataField="SSECDt_Id" HeaderText="SSECDt_Id" 
                                    ItemStyle-CssClass = "hide" HeaderStyle-CssClass = "hide" >
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                    <asp:BoundField DataField="Student_Section_Subject_Id" 
                                        HeaderText="Student_Section_Subject_Id" ItemStyle-CssClass = "hide" HeaderStyle-CssClass = "hide" >
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="No.">
                                        <ItemStyle Font-Size="X-Small" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="X-Small" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="X-Small" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="X-Small" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Test_Name" HeaderText="Test Name" />
                                     <asp:TemplateField HeaderText="Status">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToBoolean(Eval("isAbsent"))==true?true:false%>' />


                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToBoolean(Eval("isAbsent"))==false?true:false%>' />

                                                 
                                                 <asp:Label ID="test" runat="server" Visible='<%# Convert.ToBoolean(Eval("isAbsent"))==false?true:false%>'> Present </asp:Label>
                                                 <asp:Label ID="Label1" runat="server" Visible='<%# Convert.ToBoolean(Eval("isAbsent"))==true?true:false%>'> Absent </asp:Label>


                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="10%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Toggle Check" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRating" runat="server" Enabled='<%# Convert.ToBoolean(Eval("isAbsent"))==false?true:false%>' />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Toggle Check</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Mark Absent">
                                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Absent" runat="server" CommandArgument='<%# Eval("SSECDt_Id") %>'
                                                                ImageUrl="~/images/weekout.png" OnClick="btnAbsent_Click" ToolTip="Absent" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                     </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mark Present">
                                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("SSECDt_Id") %>'
                                                                ImageUrl="~/images/Presentnew.png" OnClick="btnEdit_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                     </asp:TemplateField>

                                    
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                            </asp:GridView>
                                </td>
                            </tr>

                            <tr id="btns" runat="server" >
                        <td colspan="3" style="height: 6px; text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="lnkAddCal_Click"
                                ValidationGroup="a" Text="Save" Visible="False" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" Visible="False" />
                        </td>
                    </tr>

                        </table>
                    </td>
                </tr>
            </table>
             </tbody>
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
