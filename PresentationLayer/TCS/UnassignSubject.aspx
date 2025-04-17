<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="UnassignSubject.aspx.cs" Inherits="PresentationLayer_TCS_UnassignSubjectaspx" %>

<%@ Register TagPrefix="uc" TagName="SearchStudent" Src="~/PresentationLayer/TCS/SearchStudent.ascx" %>
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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Unassign Islamiat and Urdu"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <uc:SearchStudent runat="server" ID="SearchStudent1"></uc:SearchStudent>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right ">
                <br />
                <asp:Button ID="btnSearch" TabIndex="1" OnClick="but_search_Click" runat="server"
                    CssClass="btn btn-primary" Text="Search"></asp:Button>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    Student Information
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvStudentSubject" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                    CssClass="datatable table table-hover table-responsive" OnPreRender="gvStudentSubject_PreRender">
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_No" HeaderText="Student No" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Status">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <asp:Label runat="server" CssClass="TextLabel40" Visible='<%# (int)(Eval("is_Assigned"))==0%>'
                                    Text="Unassigned">
                                </asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="TextLabel40" Visible='<%# (int)(Eval("is_Assigned"))==1%>'
                                    Text="Assigned">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assign/Unassign">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnUnassign" runat="server" CommandArgument='<%# Eval("Subject_Id") %>'
                                    ToolTip="Uassign Urdu/Islamiat for foreign students" CssClass="btn btn-success active"
                                    OnClick="btnUnassign_Click" Visible='<%#(int)(Eval("isShow"))==1 &&  (int)(Eval("is_Assigned"))==1%>'
                                    Text="Unassign">
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnAssign" runat="server" CommandArgument='<%# Eval("Subject_Id") %>'
                                    ToolTip="Assign Urdu/Islamiat for foreign students" CssClass="btn btn-warning active"
                                    OnClick="btnAssign_Click" Visible='<%#(int)(Eval("isShow"))==1 &&  (int)(Eval("is_Assigned"))==0%>'
                                    Text="Assign">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
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
