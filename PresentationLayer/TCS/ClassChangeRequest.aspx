<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ClassChangeRequest.aspx.cs" Inherits="PresentationLayer_TCS_ClassChangeRequest" %>

<%@ Register TagPrefix="uc" TagName="SearchStudent" Src="~/PresentationLayer/TCS/SearchStudent.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Class Change Request"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right ">
                <br />
                <asp:Button ID="btnall" runat="server" CssClass="btn btn-info" OnClick="btnAll_Click"
                    Visible="false" Text="All"></asp:Button>
                <asp:Button ID="btnPending" runat="server" CssClass="btn btn-warning" OnClick="btnPending_Click"
                    Text="Pending"></asp:Button>
                <asp:Button ID="btnShowApproved" runat="server" CssClass="btn btn-success" OnClick="btnShowApproved_Click"
                    Text="Approved"></asp:Button>
                <asp:Button ID="btnShowDisapproved" runat="server" CssClass="btn btn-danger" OnClick="btnShowDisApproved_Click"
                    Text="Disapproved"></asp:Button>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <uc:SearchStudent runat="server" ID="SearchStudent1" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right ">
                <br />
                <asp:Button ID="btnSearch" TabIndex="1" OnClick="btnSearch_Click" runat="server"
                    CssClass="btn btn-primary" Text="Search"></asp:Button>
                <asp:Button ID="btnCancel" TabIndex="1" OnClick="btnCancle_Click" runat="server"
                    CssClass="btn btn-danger" Text="Cancel" Visible="False"></asp:Button>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="divStudentTitle" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    &nbsp; Student List
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    OnPreRender="gvStudent_PreRender" OnRowDataBound="gvStudent_RowDataBound" CssClass="datatable table table-striped table-responsive">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="CCReq_Id" HeaderText="Request Number" SortExpression="CCReq_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ToClass_Id" HeaderText="To Class Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CCReason_Id" HeaderText="Reason Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="List of Students">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="form-horizontal">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Student # :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                            style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Student_Id")%>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Student Name :
                                        </div>
                                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            <%# Eval("fullname")%>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Region:
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                            style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Region_Name")%>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Center:
                                        </div>
                                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Center_Name")%>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Current Class:
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                            style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Class_Name")%>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Section Name:
                                        </div>
                                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Section_Name")%>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <br />
                                        <asp:Label runat="server" ID="lbllock" Text='<%# Eval("isLock") %>' Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Required Class:
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            <asp:Label runat="server" ID="lblToClass" Text='<%# Eval("ToClass_Id") %>' Visible="false"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlToClass" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            Reason for Class Change:
                                        </div>
                                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                            <asp:Label runat="server" ID="lblreason" Text='<%# Eval("CCReason_Id") %>' Visible="false"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlReason" CssClass="dropdownlist" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlReason_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" runat="server"
                                            id="lblOthers" visible="false">
                                            Please Specify:
                                        </div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8  form-group">
                                            <asp:TextBox CssClass="form-control textbox" runat="server" ID="txtOthers" Visible="false"
                                                TextMode="MultiLine" Width="720px" Rows="3"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="divComments"
                                        visible="false">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40 text-left" style="color: <%# Eval("Color") %>;">
                                        </div>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 TextLabelMandatory40 text-left"
                                            style="color: <%# Eval("Color") %>;">
                                            <%# Eval("Comments")%></div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-right">
                                            <asp:LinkButton runat="server" ID="btnSubmit" Text="Submit Request" CommandArgument='<%# Eval("Student_Id") %>'
                                                CssClass="btn btn-info active" Visible='<%# (int)( Eval("isSubmit"))==0 %>' OnClick="btnSubmit_Click"
                                                ToolTip="Submit Class Change Request">
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnReport" CommandArgument='<%# Eval("Student_Id") %>'
                                                Visible="false" OnClick="BindReportCardGrid" ToolTip="View Student History"> <span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvReportCard" runat="server" CssClass="datatable table table-striped table-bordered table-hover"
                    OnPreRender="gvReportCard_PreRender" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TermGroup_Id" HeaderText="TermGroup_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session" HeaderText="Session">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Term" HeaderText="Term">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="View Result Card">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnReport" CssClass="btn btn-info" CommandArgument='<%# Eval("Student_Id") %>'
                                    OnClick="btnViewReport_Click" Text="View Report" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle ForeColor="SlateGray" />
                    <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
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
