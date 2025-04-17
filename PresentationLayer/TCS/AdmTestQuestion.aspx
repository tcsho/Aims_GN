<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmTestQuestion.aspx.cs" Inherits="PresentationLayer_TCS_AdmTestQuestion" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Question Management For Admission Test"></asp:Label>
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
                                        Test Name :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_AdmTest" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" 
                                            Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                  <tr style="width: 100%">
                                    <td style="height: 26px; width: 40%; text-align: right" align="right" colspan="1">
                                        Test Name Detail :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_AdmTestDetail" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            Width="217px" 
                                            AppendDataBoundItems="True" Height="16px" 
                                            onselectedindexchanged="list_AdmTestDetail_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                       
                                    </td>
                                   <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                       Font-Bold="False" ValidationGroup="btnNew">Add New Question</asp:LinkButton></td>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvQuestions_RowDataBound" Width="100%" OnSorting="gvQuestions_Sorting"
                                            OnRowCommand="gvQuestions_RowCommand" 
                                            onselectedindexchanged="gvQuestions_SelectedIndexChanged" 
                                            onselectedindexchanging="gvQuestions_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="Quest_ID" SortExpression="Quest_ID" 
                                                    HeaderText="Quest_ID">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AdmTestDetail_Id" HeaderText="AdmTestDetail_Id">
                                                <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="QuestText" HeaderText="QuestText" >

                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />

                                                <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="AnsPointValue" SortExpression="AnsPointValue" 
                                                    HeaderText="AnsPointValue">
                                                    <HeaderStyle HorizontalAlign="Center"  />
                                                    <ItemStyle HorizontalAlign="Center"  />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NegtvPointValue" 
                                                    HeaderText="NegtvPointValue">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Comments" HeaderText="Comments" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TimeInSeconds" HeaderText="TimeInSeconds" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" 
                                                            CommandArgument='<%# Eval("Quest_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" 
                                                         CommandArgument='<%# Eval("Quest_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record"  onClientClick = "javascript:return confirm('Are you sure you want to Delete Records?');"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Show Answer">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnShowAnswer" runat="server" 
                                                            CommandArgument='<%# Eval("Quest_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/viewIcon.gif" OnClick="btnShowAnswer_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Add Answer">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAnswerAdd" runat="server" 
                                                            CommandArgument='<%# Eval("Quest_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/transfericon.gif" OnClick="btnAnswerAdd_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                 <tr id="tr1" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td style="height: 22px" class="titlesection" colspan="2">
                                               Question Answer's Option
                                            </td>
                                </tr>
                                <tr id="tr2" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvAnswerList" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvSubjects_RowDataBound" Width="100%" OnSorting="gvSubjects_Sorting"
                                            OnRowCommand="gvSubjects_RowCommand" 
                                            onselectedindexchanged="gvSubjects_SelectedIndexChanged" 
                                            onselectedindexchanging="gvSubjects_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="QuestDetail_ID" SortExpression="QuestDetail_ID" 
                                                    HeaderText="QuestDetail_ID">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Quest_ID" HeaderText="Quest_ID" >

                                                <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />

                                                </asp:BoundField>

                                                <asp:BoundField DataField="Options" SortExpression="Options" 
                                                    HeaderText="Options">
                                                    <HeaderStyle HorizontalAlign="Left" Width="75%"  />
                                                    <ItemStyle HorizontalAlign="Left" Width="75%"  />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AnswerOption_ID" 
                                                    HeaderText="AnswerOption_ID">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AnswerOptionDesc" HeaderText="AnswerOptionDesc" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAnswerEdit" runat="server" 
                                                            CommandArgument='<%# Eval("QuestDetail_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnAnswerEdit_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" Visible="False">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAnswerDelete" runat="server" 
                                                         CommandArgument='<%# Eval("QuestDetail_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/delete.gif" OnClick="btnAnswerDelete_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" onClientClick = "javascript:return confirm('Are you sure you want to Delete Records?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top" colspan="3" style="height: 200px">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="75%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">
                                               Add / Update New Question
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
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            Question:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtQuestion" runat="server" Width="425px"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            Comments:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtComments" runat="server" Width="425px"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                           Answer Point Value:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtPValue" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPValue" runat="server" ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type ="Double"></asp:CompareValidator>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                             Answer Negative Point Value:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtNValue" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtNValue" runat="server" ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type ="Double"></asp:CompareValidator>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                           Answer In Seconds:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtAnsInSec" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtAnsInSec" runat="server" ErrorMessage="Please Enter Only Integer Values" Operator="DataTypeCheck" Type ="Integer"></asp:CompareValidator>
                                                        </td>
                                                        
                                                    </tr>
                                                   

                                                    
                                                    <tr id="Prom1" runat="server">
                                                        <td style="width: 8px; height: 18px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">
                                                            &nbsp;</td>
                                                        <td style="width: 510px; height: 18px" class="tr2">
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

                    <tr>
                        <td valign="top" colspan="3" style="height: 150px">
                            <asp:Panel ID="pan_new2" runat="server" Width="100%" Height="50%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td  style="height: 22px" class="titlesection" >
                                               Add / Update New Answer's Option
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                   
                                                  
                                               
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                            Answer:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtAnswer" runat="server" Width="461px"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>

                                                      <tr>
                                                        <td class="tr2" style="width: 8px; height: 18px">
                                                            &nbsp;</td>
                                                        <td align="right" class="tr2" style="width: 350px; height: 18px" valign="top">
                                                            Answer Options:</td>
                                                        <td class="tr2" style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="listAnswOption" runat="server" AutoPostBack="True" 
                                                                CssClass="dropdownlist" 
                                                                OnSelectedIndexChanged="listAnswOption_SelectedIndexChanged" Width="173px" 
                                                                Height="19px">
                                                            </asp:DropDownList>
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
                                                            <asp:Button ID="btnAnswerSave" OnClick="btnAnswerSave_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save Answer" Width="132px"></asp:Button>&nbsp;<asp:Button 
                                                                ID="btnCalnalSkill" OnClick="btnCalnalSkill_Click"
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
                </tbody>
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
