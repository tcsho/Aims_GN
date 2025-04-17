<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsSurveySubmission.aspx.cs" Inherits="PresentationLayer_TCS_LmsSurveySubmission" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Survey Submission"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                       Survey Information :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_Survey" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" 
                                            Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvSurveyQuestion" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvSurveyQuestion_RowDataBound" Width="100%" OnSorting="gvSurveyQuestion_Sorting"
                                            OnRowCommand="gvSurveyQuestion_RowCommand">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="Survey_ID" SortExpression="Survey_ID" 
                                                    HeaderText="Survey_ID">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SurveyDetail_ID" 
                                                    HeaderText="SurveyDetail_ID">
                                                     <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QuestionDetailOption_Id" 
                                                    SortExpression="QuestionDetailOption_Id" HeaderText="QuestionDetailOption_Id">
                                                      <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="QstDetails" SortExpression="QstDetails" 
                                                    HeaderText="Questions">
                                                   
                                                    <HeaderStyle HorizontalAlign="Left" Width="55%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="55%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Participant_ID" HeaderText="Participant_ID" 
                                                    HeaderStyle-CssClass = "hide" ItemStyle-CssClass = "hide" >
                                                  

                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                  

                                                <asp:BoundField DataField="QuestionDetailOption" 
                                                    HeaderText="QuestionDetailOption" HeaderStyle-CssClass = "hide" 
                                                    ItemStyle-CssClass = "hide" >
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LmsSurveySubmissionsUser_ID" 
                                                    HeaderText="LmsSurveySubmissionsUser_ID" HeaderStyle-CssClass = "hide" 
                                                    ItemStyle-CssClass = "hide" >
                                                    

                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                    

                                                <asp:TemplateField HeaderText="Answer">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                        <asp:DropDownList ID="listAnswerOption" runat="server" AutoPostBack="True" 
                                                            CssClass="dropdownlist" Height="18px" Width="98%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="listAnswerOption" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                            Height="18px" Width="98%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="35%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="35%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="cb">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Copy">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" ForeColor="#004999" OnClick="btnCopy_Click"
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Copy" ImageUrl="~/images/edit.gif"
                                                            CommandArgument='<%# Eval("Survey_ID") %>'></asp:ImageButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="77px"
                                            CssClass="btn btn-primary" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />
                    
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
