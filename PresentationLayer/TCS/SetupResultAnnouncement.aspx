<%@ Page Title="Setup Result Announcement" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="SetupResultAnnouncement.aspx.cs"
    Inherits="PresentationLayer_TCS_SetupResultAnnouncement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .setup-result-announce .err { color: #b00020; display: block; margin: 8px 0 12px; }
        .setup-result-announce .page-note {
            color: #1a6fb5; display: block; margin: 0 0 14px; padding: 8px 12px;
            background: #f0f7fc; border-left: 4px solid #1a6fb5; font-size: 13px; line-height: 1.45;
        }
        .save-loader-overlay {
            position: absolute; left: 0; top: 0; right: 0; bottom: 0;
            background: rgba(255, 255, 255, 0.75); z-index: 20;
            display: flex; align-items: center; justify-content: center;
            font-weight: bold; color: #1a6fb5;
        }
        .modal-content { position: relative; }
        .btn-save-loading { opacity: 0.65; pointer-events: none; }
    </style>
    <script type="text/javascript">
        function closeModal() {
            $('#myModal').modal('hide');
        }
        function confirmDelete(msg) {
            return confirm(msg || 'Delete this record?');
        }
        function beginSave() {
            var btn = document.getElementById('<%= btnSave.ClientID %>');
            if (btn) {
                btn.value = 'Saving...';
                btn.className = btn.className + ' btn-save-loading';
            }
            return true;
        }
        function resetSaveButton() {
            var btn = document.getElementById('<%= btnSave.ClientID %>');
            if (!btn) return;
            btn.className = btn.className.replace(' btn-save-loading', '');
            var idField = document.getElementById('<%= hfId.ClientID %>');
            btn.value = (idField && idField.value && idField.value !== '0') ? 'Update' : 'Save';
        }
        Sys.Application.add_init(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () { resetSaveButton(); });
        });
    </script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <div class="form-group setup-result-announce">
                <div class="form-group formheading">
                    <asp:Label ID="lblHeading" runat="server" CssClass="lblFormHead" Text="Setup Result Announcement"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~") %>images/h01.png" height="100%" width="100%" border="0" />
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="lblPageNote" runat="server" CssClass="page-note"
                        Text="Note: The selected date and time will control the availability of results page open via URL." />
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12" style="margin-bottom: 12px;">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary pull-right btn-xs"
                        Text="Add Result Announcement Dates" OnClick="btnAdd_Click" />
                </div>

                <asp:HiddenField ID="hfSessionId" runat="server" Value="0" />

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 form-group">
                        <asp:Label ID="lblSessionFilter" runat="server" CssClass="TextLabelMandatory40" Text="*Session:"></asp:Label>
                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="100%" Enabled="false" />
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 form-group">
                        <asp:Label ID="lblTermFilter" runat="server" CssClass="TextLabelMandatory40" Text="*Term:"></asp:Label>
                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdownlist" Width="100%"
                            AutoPostBack="True" OnSelectedIndexChanged="FilterChanged" />
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 form-group">
                        <asp:Label ID="lblClassFilter" runat="server" CssClass="TextLabel40" Text="Class:"></asp:Label>
                        <asp:DropDownList ID="ddlClassFilter" runat="server" CssClass="dropdownlist" Width="100%"
                            AutoPostBack="True" OnSelectedIndexChanged="FilterChanged" />
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 form-group">
                        <asp:Label ID="lblActiveFilter" runat="server" CssClass="TextLabel40" Text="Active:"></asp:Label>
                        <asp:DropDownList ID="ddlActiveFilter" runat="server" CssClass="dropdownlist" Width="100%"
                            AutoPostBack="True" OnSelectedIndexChanged="FilterChanged" />
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 form-group" style="padding-top: 22px;">
                        <asp:Button ID="btnClearFilters" runat="server" CssClass="btn btn-default btn-xs"
                            Text="Clear Filters" OnClick="btnClearFilters_Click" />
                    </div>
                </div>

                <asp:Panel ID="pnlGrid" runat="server" Visible="false">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        <h3 class="titlesection">Result Announcement Dates</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-top: 16px;">
                        <asp:Label ID="lblEmptyGrid" runat="server" Visible="false" CssClass="err"
                            Text="No announcement dates found for the selected filters." />
                        <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="Id" CssClass="datatable table table-striped table-responsive"
                            EmptyDataText="No announcement dates found for the selected filters."
                            OnPreRender="gvAnnouncements_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Session_Name" HeaderText="Session" />
                                <asp:BoundField DataField="Term_Name" HeaderText="Term" />
                                <asp:BoundField DataField="Class_Name" HeaderText="Class" />
                                <asp:BoundField DataField="AnnouncementDateTime" HeaderText="Announcement Date/Time"
                                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="False" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("IsActive")) ? "Yes" : "No" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="160px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CssClass="btn-sm btn-primary btn-xs" Text="Edit"
                                            CommandArgument='<%# Eval("Id") %>' OnClick="btnEdit_Click" CausesValidation="false" />
                                        <asp:LinkButton runat="server" CssClass="btn-sm btn-danger btn-xs" Text="Delete"
                                            CommandArgument='<%# Eval("Id") %>' OnClick="btnDelete_Click"
                                            OnClientClick="return confirmDelete('Delete this announcement?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="tableheader" />
                            <RowStyle CssClass="tr1" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="upModalSaveProgress" runat="server" AssociatedUpdatePanelID="upModal" DisplayAfter="0">
                        <ProgressTemplate>
                            <div class="save-loader-overlay">
                                <span>Saving, please wait...</span>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="Add Result Announcement Dates"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hfId" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Session *</label>
                                    <asp:DropDownList ID="ddlModalSession" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6">
                                    <label>Term *</label>
                                    <asp:DropDownList ID="ddlModalTerm" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-md-6">
                                    <label>Class</label>
                                    <asp:DropDownList ID="ddlModalClass" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <label>Date *</label>
                                    <asp:TextBox ID="txtAnnouncementDate" runat="server" CssClass="form-control" TextMode="Date" />
                                </div>
                                <div class="col-md-3">
                                    <label>Time *</label>
                                    <asp:TextBox ID="txtAnnouncementTime" runat="server" CssClass="form-control" TextMode="Time" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-md-12">
                                    <asp:Label ID="lblModalNote" runat="server" CssClass="page-note"
                                        Text="Note: The selected date and time will control the availability of results page open via URL." />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-md-12">
                                    <label>Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"
                                        MaxLength="200" TextMode="MultiLine" Rows="2" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-md-12">
                                    <asp:CheckBox ID="chkIsActive" runat="server" Text="Active" Checked="true" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info pull-left" type="button" data-dismiss="modal" aria-hidden="true">Close</button>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                ValidationGroup="saveAnnouncement" OnClick="btnSave_Click"
                                OnClientClick="return beginSave();" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
