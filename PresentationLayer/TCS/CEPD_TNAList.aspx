<%@ Page Title="Training Needs Analysis" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_TNAList.aspx.cs"
    Inherits="PresentationLayer_CEPD_TNAList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.2/jspdf.min.js"></script>

 
    <script type="text/javascript">
       
    </script>
      


    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>

   

    <div class="form-group formheading">
        <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="TNA FORM"></asp:Label>
        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
    </div>
    <br />
    <div class="form-group formheading">
        <h3 class="panel-title titlesection" style="color: white">Search</h3>
    </div>
    <br />
    <div runat="server" id="divMessage" visible="false">
        <div class="alert alert-success" role="alert">
            <span runat="server" id="spanMessage"></span>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">

            <div class="col-md-3">
                <div class="form-group " style="text-align: right">
                    <label class="form-label" for="list_region">Region:</label>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <div class="input-container" style="display: flex;">
                        <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                            OnSelectedIndexChanged="list_region_SelectedIndexChanged" Style="width: 100%" ClientIDMode="Static">
                        </asp:DropDownList>
                        <asp:Label ID="lab_region" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-1">
                <div class="form-group" style="text-align: right">
                    <label class="form-label" for="list_center">Center:</label>

                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <div class="input-container" style="display: flex;">
                        <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist" Style="width: 100%">
                        </asp:DropDownList>
                        <asp:Label ID="lab_center" runat="server"></asp:Label>
                    </div>

                </div>
            </div>
            <div class="col-md-2">
            </div>
        </div>
        <div class="row">

            <div class="col-md-3">
                <div class="form-group " style="text-align: right">
                    <label class="form-label" for="list_region">Status:</label>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <div class="input-container" style="display: flex;">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist"
                            Style="width: 100%" ClientIDMode="Static">
                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group" style="text-align: left">
                </div>
            </div>
        </div>
        <div class="row">

            <div class="col-md-3">
                <div class="form-group " style="text-align: right">
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <div class="input-container" style="display: flex;">
                        <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                            Text="Search" ClientIDMode="Static"></asp:Button>

                    </div>
                </div>
                 </div>
            <div class="col-md-6">
                <div class="form-group" style="text-align: left">
                </div>
            </div>
        </div>
    </div>

    <div class="form-group formheading">
        <h3 class="panel-title titlesection" style="color: white">TNA List</h3>
    </div>
    <br />
    <div class="form-group ">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group" style="margin-top: 20px;">
                    <asp:GridView ID="gvTNAList" runat="server" CssClass="datatable table table-striped table-bordered" AutoGenerateColumns="false" OnRowDataBound="gvTNAList_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="TNA_ID" HeaderText="TNA_ID" Visible="false" />
                            <asp:BoundField DataField="Center_ID" HeaderText="Center_ID" Visible="false" />
                            <asp:BoundField DataField="Region_Name" HeaderText="Region" />
                            <asp:BoundField DataField="Center_Name" HeaderText="Center" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="TotalTeacher" HeaderText="Total Teacher" />
                            <asp:BoundField DataField="KeyStagesName" HeaderText="Key Stages" />
                            <asp:BoundField DataField="KSTotalTeacher" HeaderText="Key Stage Total Teacher" />
                            <asp:BoundField DataField="TeacherName" HeaderText="Trainees ERP" />
                            <asp:BoundField DataField="ConfirmedTraineesCount" HeaderText="Total Trainees" />
                            <asp:BoundField DataField="TrainingType" HeaderText="Training Type" />
                            <asp:BoundField DataField="AssignedTrainerName" HeaderText="Assigned Trainer" />
                            <asp:BoundField DataField="STATUS" HeaderText="Status" />

                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" OnClick="btnEdit_Click" runat="server"
                                        CommandArgument='<%# String.Format("{0}", Eval("TNA_ID")) %>'
                                        CommandName='<%# Eval("TNA_ID") %>'
                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                        ToolTip="Edit Record" />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnApproved" OnClick="btnApproved_Click" runat="server"
                                        CommandArgument='<%# String.Format("{0},{1}", Eval("TNA_ID"),Eval("Center_ID")) %>'
                                        CommandName='<%# Eval("TNA_ID") %>' AlternateText="Approved"
                                        ForeColor="#004999" ImageUrl="~/images/approve.png" Style="text-align: center; font-weight: bold;"
                                        ToolTip="Approved" />
                                </ItemTemplate>

                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Reject">
    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
    <ItemTemplate>
        <asp:ImageButton ID="btnReject" OnClick="btnReject_Click" runat="server"
            CommandArgument='<%# String.Format("{0},{1}", Eval("TNA_ID"),Eval("Center_ID")) %>'
            CommandName='<%# Eval("TNA_ID") %>' AlternateText="Rejected"
            ForeColor="#004999" ImageUrl="~/images/close-button.png" Style="text-align: center"
            ToolTip="Rejected"  Width="20px" Height="20px"  />
    </ItemTemplate>
</asp:TemplateField>
   <asp:TemplateField HeaderText="Certificate">
                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server"
                                        CommandArgument='<%# String.Format("{0}", Eval("TeacherName")) %>'
                                        AlternateText="Certificate"
                                        ForeColor="#004999" ImageUrl="~/images/icons8-certificates-64.png" Style="text-align: center; font-weight: bold; width: 32px; height: 32px;"
                                        ToolTip="Certificate"  OnClick="OnCertificate_Click"/>
                                </ItemTemplate>
      
                            </asp:TemplateField>
               

                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>