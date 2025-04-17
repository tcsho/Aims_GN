<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsSurvey.aspx.cs" Inherits="PresentationLayer_TCS_LmsSurvey" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Teacher Survey"></asp:Label>
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
                                       <%-- <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>--%>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" OnClick="btnCompose_Click">Add New</asp:LinkButton>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tr style="width: 100%">
                                                    <td align="right" style="height: 19px; text-align: right; width: 40%">
                                                        <%--Work Site :--%>
                                                    </td>
                                                    <td align="right" colspan="13" style="height: 19px; text-align: right; width: 60%">
                                                        <asp:DropDownList ID="ddlWorkSite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged"
                                                            Width="200px" Visible="False">
                                                        </asp:DropDownList>
                                                        <img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                                                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" 
                                                        style="height: 19px; text-align: right; width: 40%; color: #0000FF; font-size: small;">
                                                          Work Site :
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Label ID="lblWorksitename" runat="server" Font-Size="Small" 
                                                            ForeColor="#0000CC"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">
                                            Teacher Survey
                                        </td>
                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="gvDetail_PageIndexChanging"
                                                PageSize="15" SkinID="GridView" Width="100%" onsorting="gvDetail_Sorting">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:BoundField DataField="Poll_ID" HeaderText="Poll_ID" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="WrkTool_ID" HeaderText="WrkTool_ID" Visible="False"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="QstText" HeaderText="QstText"
                                                        HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AddInstructions" HeaderText="AddInstructions">
                                                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IsPublished" HeaderText="IsPublished">
                                                        <HeaderStyle Width="15px" />
                                                        <ItemStyle Width="15px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GblAccessType_ID" HeaderText="GblAccessType_ID">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OpningDate" HeaderText="OpningDate">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ClosingDate" HeaderText="ClosingDate" >
                                                        <HeaderStyle Width="300px" HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        <HeaderStyle HorizontalAlign="Left" Width="300px" />
                                                        <ItemStyle Width="300px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("Survey_ID") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("Survey_ID") %>'
                                                                ImageUrl="~/images/delete.gif" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Show Question">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnShowQuestion" runat="server" 
                                                            CommandArgument='<%# Eval("Survey_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/viewIcon.gif" OnClick="btnShowQuestion_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Show Question" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Question Add">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnQuestionAdd" runat="server" 
                                                            CommandArgument='<%# Eval("Survey_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/transfericon.gif" OnClick="btnQuestionAdd_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Question Add" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                </Columns>
                                                <SelectedRowStyle CssClass="tr_select" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                            <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trCDT" runat="server" visible="false">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Add / Update Teacher Survey
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                            <table>
                                                

                                                <tr id="trDate" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;;width:25%">
                                                        Opening Date:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Enter Date"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="TrDate2" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Closing Date:
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate2" runat="server" ToolTip="Enter Date"></asp:TextBox><cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtDate2" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate2" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                <tr id="trDayType" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Qusetion Title :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        &nbsp;<asp:TextBox ID="txtTitle" runat="server" 
                                                                Width="159px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr id="trCDTEnt" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Add Instruction :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 300px; text-align: left;">
                                                        
                                                        &nbsp;<cc2:Editor ID="Editor1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="trchkbox" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Is Published :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:CheckBox ID="chPublised" runat="server" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>

                                                 <tr id="trchkbox2" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Is Global Access :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:CheckBox ID="chGlobal" runat="server" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trGVOpt" runat="server" visible="false">
                                        <td align="right" colspan="13" style="height: 19px; text-align: right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="but_save_Click"
                                ValidationGroup="a" Text="Save" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="1" style="height: 150px">
                            <asp:Panel ID="pan_QestGrid" runat="server" Width="100%" Height="50%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td  style="height: 22px" class="titlesection" >
                                               Question Detail Option
                                            </td>
                                        </tr>
                                         <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvQestOption" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvQuestion_RowDataBound" Width="100%" OnSorting="gvQuestion_Sorting"
                                            OnRowCommand="gvQuestion_RowCommand" 
                                            onselectedindexchanged="gvQuestion_SelectedIndexChanged" 
                                            onselectedindexchanging="gvQuestion_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="QuestionDetailOption" 
                                                    HeaderText="QuestionDetailOption" >

                                                <HeaderStyle HorizontalAlign="Left" Width="75%" />
                                                <ItemStyle HorizontalAlign="Left" Width="75%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Score" SortExpression="Score" 
                                                    HeaderText="Score">
                                                    <HeaderStyle HorizontalAlign="Left" Width="50px"  />
                                                    <ItemStyle HorizontalAlign="Left" Width="50px"  />
                                                </asp:BoundField>
                                               
                                               
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                        <tr>
                                        <td>
                                        </td>
                                        </tr>
                                         <tr>
                                            <td  style="height: 22px" class="titlesection" >
                                               Survey Question Detail
                                            </td>
                                        </tr>
                                         <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvQuestion_RowDataBound" Width="100%" OnSorting="gvQuestion_Sorting"
                                            OnRowCommand="gvQuestion_RowCommand" 
                                            onselectedindexchanged="gvQuestion_SelectedIndexChanged" 
                                            onselectedindexchanging="gvQuestion_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="PollDetail_ID" SortExpression="PollDetail_ID" 
                                                    HeaderText="PollDetail_ID" Visible="False">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Poll_ID" 
                                                    HeaderText="Poll_ID" Visible="False">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="QstDetails" HeaderText="QstDetails" >

                                                    <HeaderStyle HorizontalAlign="Left" Width="75%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="75%" />

                                                <HeaderStyle HorizontalAlign="Left" Width="75%" />
                                                <ItemStyle HorizontalAlign="Left" Width="75%" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnQuestionDTEdit" runat="server" 
                                                            CommandArgument='<%# Eval("SurveyDetail_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnQuestionDTEdit_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" Visible="False">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnQuestionDTdelete" runat="server" 
                                                         CommandArgument='<%# Eval("SurveyDetail_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/delete.gif" OnClick="btnQuestionDTdelete_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" onClientClick = "javascript:return confirm('Are you sure you want to Delete Records?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                   
                                                  
                                               
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                            &nbsp;</td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            &nbsp;</td>
                                                        
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
                                                        <td style="width: 8px; height: 19px" class="label">
                                                        </td>
                                                        <td style="height: 19px" class="label" align="center" colspan="2">
                                                            &nbsp;&nbsp;&nbsp;
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
                    <tr>
                        <td valign="top" colspan="3" style="height: 150px">
                            <asp:Panel ID="pan_new2" runat="server" Width="100%" Height="50%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td  style="height: 22px" class="titlesection" >
                                               Update / Add New Question
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                   
                                                  
                                               
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                            Question:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtQuestion" runat="server" Width="461px"></asp:TextBox>
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
                                                        <td style="width: 8px; height: 19px" class="label">
                                                        </td>
                                                        <td style="height: 19px" class="label" align="center" colspan="2">
                                                            <asp:Button ID="btnQuestionSave" OnClick="btnQuestionSave_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save Question" Width="132px"></asp:Button>&nbsp;<asp:Button 
                                                                ID="btnCalnalQuestion" OnClick="btnCalnalQuestion_Click"
                                                                    runat="server" CssClass="btn btn-primary" CausesValidation="False" 
                                                                Text="Cancel">
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

                    <tr id="btnGen" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                            &nbsp;
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
