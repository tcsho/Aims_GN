<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LMSTeacherWorkspaceDetail.aspx.cs" Inherits="PresentationLayer_LMSTeacherWorkspaceDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<html>
<head  >
    <meta charset="utf-8">
  <title> </title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
  

</head>
<body>
</body>
</html>

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <asp:ScriptReference Path="http://code.jquery.com/jquery-1.10.2.js" />
                <asp:ScriptReference Path="http://code.jquery.com/ui/1.11.4/jquery-ui.js" />

           
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Teacher Workspace Detail - Worksite Wise All Information"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                              
                               
                               
                            
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" 
                                        style="height: 18px; text-align: right; width: 40%;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 60%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 40%">
                                        &nbsp;</td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 25%">
                                       
                                        <asp:GridView ID="dv_details" runat="server" AllowPaging="True" 
                                            AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Left" 
                                            OnRowDataBound="dv_details_RowDataBound" OnSorting="dv_details_Sorting" 
                                            PageSize="500" SkinID="GridView" Width="100%" 
                                            onrowcommand="dv_details_RowCommand">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                    <asp:TemplateField HeaderText="No." Visible="False">
                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                    <asp:BoundField DataField="Title" HeaderText="Title" 
                                                        ItemStyle-CssClass = "hide" HeaderStyle-CssClass = "hide" >
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="Section_Subject_Id" 
                                                    HeaderText="Section_Subject_Id" Visible="False" />
                                                     <asp:BoundField DataField="WrkTool_ID" HeaderText="WrkTool_ID" 
                                                        ItemStyle-CssClass = "hide"  HeaderStyle-CssClass = "hide">
                                                         <HeaderStyle CssClass="hide" />
                                                         <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                  <asp:BoundField DataField="ProjectTool" HeaderText="ProjectTool"  
                                                        ItemStyle-CssClass = "hide" HeaderStyle-CssClass = "hide" >

                                                      <HeaderStyle CssClass="hide" />
                                                      <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>

                                                <asp:TemplateField HeaderText="ProjectTool">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkBtnWrk" runat="server" OnClick="lnkBtnWrk_Click" Text='<%# Eval("ProjectTool") %>'
                                                            CommandArgument='<%# Eval("WrkTool_ID") %>' CommandName='<%# Eval("ProjectTool") %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="330px" HorizontalAlign="Left"  />
                                                    <ItemStyle Width="330px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                               
                                                     <asp:BoundField DataField="PagePath" HeaderText="PagePath" 
                                                        ItemStyle-CssClass = "hide" HeaderStyle-CssClass = "hide" >
                                                         <HeaderStyle CssClass="hide" />
                                                         <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                     <asp:TemplateField HeaderText="Show" Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" 
                                                            CommandArgument='<%# Eval("WrkTool_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnShow_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                               
                                            </Columns>

                                            <SelectedRowStyle CssClass="tr_select" />
                                <SelectedRowStyle CssClass="tr_select" />
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                       
                                    </td>
                                    <td style="width: 75%"align="left">
                                    <div id="accordion">
  <h3>Announcements </h3>
  <div>
    <p>
    Announcements are a versatile form of communication with members of a
    subject or community. Announcements can include text, images, media content,
    and links to websites and other files (subject to copyright).
    Each subject or community site can have an Announcements page
    </p>
  </div>
  <h3>Scheduling</h3>
  <div>
    <p>
    When you bring your Learning Management System online, you can say
    goodbye to hand-written schedule books and inputting class lists in
    Outlook and Excel. Your LMS manages scheduling and facilities,
    and provides information and data that is easily accessible, 
    just like reporting and tracking.
       </p>
  </div>
  <h3>Dropbox & Resources</h3>
  <div>
    <p>
   Dropbox is many things — a multifaceted tool that’s so powerful,
   you’ll continue to discover new ways to use it. But the short and
   sweet of it is this: you can use it to store and sync documents
   and files across computers, tablets, and smart phones.
   I can write a lecture or lesson plan on my computer at home,
   put it in my Dropbox folder, and whoosh – it’s synced with my work computer. 
   During my free period at school, I can open that file, make a few changes.
    </p>
    <%--<ul>
      <li>List item one</li>
      <li>List item two</li>
      <li>List item three</li>
    </ul>--%>
  </div>
  <h3>News & Events</h3>
  <div>
    <p>
   Here you’ll find our latest eNews editions,
   news and conference appearances, including the
   CourseStage User Group Meeting. Stay up to date with Web Courseworks 
   by subscribing to our eNews email update.
    </p>
  </div>
</div>
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
    <script>
        $(function () {
            $("#accordion").accordion();
        });

        //Re-bind for callbacks
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#accordion").accordion();
        });
  </script>
</asp:Content>

 

