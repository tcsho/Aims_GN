<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsForumTopicView.aspx.cs" Inherits="PresentationLayer_TCS_LmsForumTopicView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Forum Topic View"></asp:Label>
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
                                        Forum Topic Information :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ForumTopic" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ForumTopic_SelectedIndexChanged" 
                                            Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                        <td style="height: 18px;width:100%;" class="leftlink" align="right" colspan="5" >
                                            <asp:LinkButton ID="but_Reply" runat="server" CssClass="leftlink" CausesValidation="False"
                                                Font-Bold="False" OnClick="but_Reply_Click">Reply</asp:LinkButton>&nbsp;</td>
                                    </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                 <table cellspacing="0" cellpadding="1" width="100%" border="0">
                                <tbody>

                                    <tr id="trCDT" runat="server" visible="false">
                                        <td style="height: 22px" class="titlesection" colspan="5">
                                                                Forum Topic View</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px; width: 8px;">
                                        </td>
                                        <td style="height: 10px" valign="top" align="right">
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                        <td style="height: 10px" class="tr2">
                                        </td>
                                    </tr>
                                    <tr id="trLabl1" runat="server" visible="false">
                                        <td style="width: 8px; height: 11px" class="tr2">
                                        </td>
                                        <td class="tr2" valign="top" align="right" style="height: 11px">
                                            Short Description:</td>
                                        <td style="height: 11px" class="tr2">
                                            &nbsp;
                                            <asp:Label ID="lblShortDesc" runat="server" Width="550px" Height="43px"></asp:Label></td>
                                        <td style="height: 11px" class="tr2">
                                        </td>
                                    </tr>
                                    <tr id="Tr9" runat="server">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl2" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr1" style="height: 11px" valign="top">
                                            Long Description:</td>
                                        <td class="tr1" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblLongDesc" runat="server" Width="550px" Height="150px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr10" runat="server">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl3" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr2" style="height: 11px" valign="top">
                                            Topic Locked:</td>
                                        <td class="tr2" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblisLock" runat="server" Width="550px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr11" runat="server" visible="false">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl4" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr1" style="height: 11px" valign="top">
                                            Grade Topic:</td>
                                        <td class="tr1" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblisGradeBook" runat="server" Width="550px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr13" runat="server" visible="false">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl5" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr2" style="height: 11px" valign="top">
                                            Total Grade:</td>
                                        <td class="tr2" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblTtlGrade" runat="server" Width="550px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr15" runat="server" visible="false">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl6" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr1" style="height: 11px" valign="top">
                                            Reply Type:</td>
                                        <td class="tr1" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblPostType" runat="server" Width="550px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr16" runat="server">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl7" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr2" style="height: 11px" valign="top">
                                            Topic Type:</td>
                                        <td class="tr2" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblThreadType" runat="server" Width="550px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="Tr23" runat="server">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl8" runat="server" visible="false">
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr1" style="height: 11px" valign="top">
                                            Created On:</td>
                                        <td class="tr1" style="height: 11px">
                                            &nbsp;
                                            <asp:Label ID="lblCreatedOn" runat="server" Width="190px"></asp:Label>
                                            By: &nbsp;<asp:Label ID="lblCreatedBy" runat="server" Width="98px"></asp:Label></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                    <tr id="trLabl9" runat="server" visible="false" >
                                        <td class="tr2" style="width: 8px; height: 11px">
                                        </td>
                                        <td align="right" class="tr1" style="height: 11px" valign="top">
                                        </td>
                                        <td class="tr1" style="height: 11px">
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="False" /></td>
                                        <td class="tr2" style="height: 11px">
                                        </td>
                                    </tr>
                                     <tr id="Tr1" runat="server">
                                        <td style="width: 8px; height: 5px">
                                        </td>
                                        <td valign="top" align="right" style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>

                                </tbody>
                            </table>

                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvTopic" SkinID="GridView" runat="server" Width="100%" OnPageIndexChanging="gvTopic_PageIndexChanging"
                                                AllowPaging="True" ShowHeader="False" AutoGenerateColumns="False" 
                                                EmptyDataText="No Post are Available">
                                                <RowStyle CssClass="tr1"></RowStyle>
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <table style="table-layout: fixed; width:100%; vertical-align: top;">
                                                                <tr class="tr2">
                                                                    <td style="color: #5A83BA; font-size: 12px; font-family: Calibri">
                                                                        <%# Eval("CreatedBy") %>
                                                                    </td>
                                                                </tr>
                                                                <tr class="tr1">
                                                                    <td>
                                                                        ..............
                                                                    </td>
                                                                </tr>
                                                                <tr class="tr2">
                                                                    <td style="color: #01115f; font-size: 12px; font-family: Calibri">
                                                                        <i>Reply On
                                                                            <%# Eval("CreatedOn") %>
                                                                        </i>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="25%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  ItemStyle-Width="75%">
                                                        <ItemTemplate>
                                                            <table style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;"
                                                                cellspacing="0" cellpadding="0">
                                                                <tr class="tr2" style="height:28%">
                                                                    <td valign="top" id="T" runat="server" style="height:5px" align="right">
                                                                        <asp:LinkButton ID="LnkBtnRate" Width="150px" runat="server" CommandArgument='<%# Eval("Response_ID") %>'
                                                                             Font-Underline="true" ToolTip="Grade this Post" OnClick="LnkBtnRate_Click">Save Grade</asp:LinkButton>
                                                                        <asp:LinkButton ID="LnkBtnDelete" Width="50px" runat="server" CommandArgument='<%# Eval("Response_ID") %>'
                                                                            Font-Underline="true" ToolTip="Delete this Post" OnClick="LnkBtnDelete_Click">Delete</asp:LinkButton>
                                                                        <asp:LinkButton ID="LnkBtnReply"  Width="50px" runat="server" CommandArgument='<%# Eval("Response_ID") %>'
                                                                            Font-Underline="true" ToolTip="Reply this Post" OnClick="LnkBtnReply_Click">Reply</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr class="tr1" style="height:72%">
                                                                    <td align="left" valign="top" style="word-wrap: break-word">
                                                                        <%# Eval("Message").ToString()%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td style="color: #01115f; font-size: 12px; font-family: Calibri">
                                                                <asp:Label ID="lblGrade" runat="server" Text="Marks: " style="color: #01115f; font-size: 12px; font-family: Calibri"></asp:Label>
                                                                <asp:TextBox ID="txtObtMarks" runat="server" Width="50px"></asp:TextBox>
                                                                
                                                                <asp:Label ID="lblPoints" runat="server" Text='<%# Eval("ObtainePoints").ToString()%>' style="color: #01115f; font-size: 12px; font-family: Calibri"></asp:Label>
                                                                </td>
                                                                    
                                                                </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="75%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <SelectedRowStyle CssClass="tr_select"></SelectedRowStyle>
                                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                            </asp:GridView>
                                            <asp:Label ID="lab_dataStatus" runat="server" Visible="False" Text="No Data Exists."></asp:Label>
                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                                <table cellspacing="0" cellpadding="1" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 22px" class="titlesection" colspan="5">
                                                                Post a Message</td>
                                                        </tr>
                                                        <tr>
                                                            
                                                           
                                                            <td style="height: 10px">
                                                            </td>
                                                            <td style="height: 10px" class="tr2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            
                                                            <td class="tr2" valign="top" align="right">
                                                                Message:</td>
                                                            <td align="right" colspan="12" style="height: 300px; text-align: left;">
                                                                <cc2:Editor ID="Editor1" runat="server" />
                                                            </td>
                                                            <td class="tr2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            
                                                            <td align="right" style="height: 11px" valign="top" class="tr2">
                                                            </td>
                                                            <td style="height: 11px" class="tr2">
                                                            </td>
                                                            <td class="tr2" style="height: 11px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 8px" class="label">
                                                            </td>
                                                            <td class="label" valign="top" align="center" colspan="2">
                                                                <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                                    Text="Save" ValidationGroup="a"></asp:Button>
                                                                &nbsp;
                                                                <asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                                                                    CausesValidation="False" Text="Cancel"></asp:Button></td>
                                                            <td class="label">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                </td>
                                </tr>
                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>
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
