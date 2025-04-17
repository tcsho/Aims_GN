<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LMSTeacherWorkspaceMain.aspx.cs" Inherits="PresentationLayer_LMSTeacherWorkspaceMain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<html>
<head  >
    <meta charset="utf-8">
  <title> </title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
  
   <style>
 .tdata
  {
  	float:left;
  	width:48%;
  	height:200px;
  	margin-bottom:20px;
  	margin-left:10px;
  }
  .dialogbox
  {
  	width:90%;
  	float:left;
  	border: solid 1px #CCC;
  }
  .dialogbox .header
  {
  	background: #CCC;
  	color:#FFF;
  	padding:10px;
  	box-sizing:border-box;
  }
  .dialogbox .header h1
  {
  	display:inline-block;
  }
  .dialogbox .body
  {
  	float:left;
  	width:100%;
  	padding:10px;
  	box-sizing:border-box;
  }
  .close_dialog
  {
  	float:right;
    cursor:pointer;
  }
  </style>


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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Teacher Workspace - Worksite Wise All Information"></asp:Label>
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
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                    <asp:TemplateField HeaderText="No.">
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

                                                    <asp:TemplateField HeaderText="Title">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkBtnWrk" runat="server" OnClick="lnkBtnWrk_Click" Text='<%# Eval("Title") %>'
                                                            CommandArgument='<%# Eval("Section_Subject_Id") %>' CommandName='<%# Eval("Title") %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="330px" HorizontalAlign="Left"  />
                                                    <ItemStyle Width="330px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Show" Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" 
                                                            CommandArgument='<%# Eval("Section_Subject_Id") %>' ForeColor="#004999" 
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
                                    <div >
                                            <div id="div1" class="tdata">
                                               <div class="dialogbox">
                                                    <div class="header">
                                                        <h1>What is an LMS?</h1>
                                                        <h2 class="close_dialog">X</h2>
                                                    </div>
                                                    <div class="body">
                                                    <p> A learning management system (LMS)  is a software application for the</p>
                                                    
                                                    <ul>
                                                        <li> Administration</li>
                                                        <li>Documentation</li>
                                                        <li> Tracking</li>
                                                        <li>Delivery of electronic educational technology</li>
                                                    </ul>
                                                    
                                                    </div>
                                                </div> 
                                            </div>
                                            <div id="div2" class="tdata" >
                                            <div class="dialogbox">
                                                    <div class="header">
                                                        <h1>Components of an LMS</h1>
                                                        <h2 class="close_dialog">X</h2>
                                                    </div>
                                                    <div class="body">
                                                    <p> Components of an LMS</p>
                                                    <ul>
                                                        <li>Upload and management of documents containing curricular content.</li>
                                                        <li>Methods of assessment and testing (like creating pop quizzes).</li>
                                                        <li>Interaction between and among students, such as instant messaging, email, and discussion forums.</li>
                                                       <%-- <li>Four</li>--%>
                                                    </ul>
                                                    
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="div3" class="tdata" >
                                             <div class="dialogbox">
                                                    <div class="header">
                                                        <h1>Advantages of an LMS</h1>
                                                        <h2 class="close_dialog">X</h2>
                                                    </div>
                                                    <div class="body">
                                                    <p> Advantages of an LMS</p>
                                                    <ul>
                                                        <li>Easily adapting and reusing materials over time.</li>
                                                        <li>Creating economies of scale that make it less costly for organizations to develop and maintain content for which they used to rely on third parties.</li>
                                                        <%--<li>Teaching Materials</li>
                                                        <li>Four</li>--%>
                                                    </ul>
                                                    
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="div4" class="tdata" >
                                             <div class="dialogbox">
                                                    <div class="header">
                                                        <h1>The Future of LMS</h1>
                                                        <h2 class="close_dialog">X</h2>
                                                    </div>
                                                    <div class="body">
                                                    <p> The Future of LMS</p>

                                                    <ul>
                                                        <li>New uses for e-learning content, ranging from the arts to marketing communications.</li>
                                                        <li>Migration of data storage to network-based methods, commonly known as “the cloud.”</li>
                                                        <%--<li>Further integration with talent management software systems.</li>--%>
                                                        <%--<li>Four</li>--%>
                                                    </ul>
                                                    
                                                    </div>
                                                </div>
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
  </script>
</asp:Content>

 

