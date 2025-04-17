<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="NotificationGroup.aspx.cs" Inherits="PresentationLayer_TCS_NotificationGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Notifications"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div runat="server" id="div1" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                    </div>
                    <div runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                        <div class="pull-right">
                            <asp:Button ID="btnNewGroup" runat="server" CssClass="btn btn-primary active" Text="New Group"
                                OnClick="btnNewGroup_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="divNewGroup" runat="server"
                    visible="false">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection ">
                            Add New Group
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                            <br />
                            <asp:Button ID="btnSaveGroup" runat="server" CssClass="btn btn-primary success" Text="Save"
                                OnClick="btnSaveGroup_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12  ">
                            <br />
                            <br />
                            <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Notification
                                Group Name </span>
                            <asp:TextBox ID="txtName" runat="server" Width="320px" placeholder="Group Name" CssClass="form-control textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Group Name is Required Field"
                                ControlToValidate="txtName" Display="Dynamic" ValidationGroup="s"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Maximum of 200 characters allowed"
                                ControlToValidate="txtName" Display="Dynamic" ValidationExpression=".{0,200}"
                                ValidationGroup="s" />
                        </div>
                    </div>
                    <div class="row">
                        <br />
                        <br />
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Group Description</span>
                            <asp:TextBox ID="txtDescription" runat="server" Width="320px" placeholder="Group Description"
                                CssClass="form-control textbox" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Group Description is Required Field"
                                ControlToValidate="txtDescription" Display="Static" ValidationGroup="s"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexpDesc" runat="server" ErrorMessage="Maximum of 500 characters allowed"
                                ControlToValidate="txtDescription" Display="Dynamic" ValidationExpression=".{0,500}"
                                ValidationGroup="s" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <h3>
                                Group Members
                            </h3>
                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlRegion">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlCenter">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlNetwork">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlClass">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlSection">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <br />
                            <asp:GridView ID="gvUsers" runat="server" Width="100%" AutoGenerateColumns="False"
                                CssClass="datatable table table-hover table-responsive" SkinID="GridView" OnPreRender="gvUsers_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="User_Id" HeaderText="User_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="ID" SortExpression="EmployeeCode">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="First_Name">
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Region_Name" HeaderText="Region Name" SortExpression="Region_Name">
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center Name" SortExpression="Center Name">
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Allow">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" CssClass="checkbox" ID="cbAllow" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="divGroups" runat="server">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" >
                    Groups
                    <asp:GridView ID="gvGroups" runat="server" Width="100%" AutoGenerateColumns="False"
                        CssClass="datatable table table-hover table-responsive" SkinID="GridView" OnPreRender="gvUsers_PreRender">
                        <Columns>
                            <asp:BoundField DataField="NtGrp_Id" HeaderText="User_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Group_Name" HeaderText="Group Name">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Group_Description" HeaderText="Group Description">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalMembers" HeaderText="Total Members" SortExpression="TotalMembers">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Show Members">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnShowMembers" CssClass="glyphicon glyphicon-user"
                                        OnClick="BindGroupMembers" CommandArgument='<%#  Eval("NtGrp_Id") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                        <AlternatingRowStyle CssClass="tr2" />
                        <SelectedRowStyle CssClass="tr_select" />
                    </asp:GridView>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                    Group Members
                    <asp:GridView ID="gvMembers" runat="server" Width="100%" AutoGenerateColumns="False"
                        CssClass="datatable table table-hover table-responsive" SkinID="GridView" OnPreRender="gvUsers_PreRender">
                        <Columns>
                            <asp:BoundField DataField="User_Id" HeaderText="User_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeCode" HeaderText="ID" SortExpression="EmployeeCode">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="First_Name">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Name" HeaderText="Region Name" SortExpression="Region_Name">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name" SortExpression="Center Name">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Delete Member">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnDelete" CssClass="glyphicon glyphicon-trash"
                                         CommandArgument='<%#  Eval("NtGrp_Id") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                        <AlternatingRowStyle CssClass="tr2" />
                        <SelectedRowStyle CssClass="tr_select" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
