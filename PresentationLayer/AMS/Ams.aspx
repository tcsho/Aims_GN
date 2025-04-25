<%@ page title="" language="C#" masterpagefile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Ams.aspx.cs" Inherits="PresentationLayer_AMS_Ams" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<%--    <link rel="stylesheet" href="../AMSScripts/css/datatables.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/fixedColumns.dataTables.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/animate.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/colors.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/components.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/layout.min.css" />
    
    <link rel="stylesheet" href="../AMSScripts/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ"
        crossorigin="anonymous">--%>
    <link rel="stylesheet" href="../AMSScripts/css/ams.css" />
    <link rel="stylesheet" href="../AMSScripts/css/datatables.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/fixedColumns.dataTables.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/animate.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/colors.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/components.min.css" />
    <link rel="stylesheet" href="../AMSScripts/css/layout.min.css" />
    
    <link rel="stylesheet" href="../AMSScripts/css/bootstrap.min.css" />
<link rel="stylesheet" href="../AMSScripts/plugin/datepicker/dist/css/default/zebra_datepicker.min.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

            <asp:ScriptReference Path="../AMSScripts/js/jquery.js" />
            <asp:ScriptReference Path="../AMSScripts/js/jquery.dataTables.min.js" />
            <asp:ScriptReference Path="../AMSScripts/js/dataTables.fixedColumns.min.js" />
            <asp:ScriptReference Path="../AMSScripts/plugin/datepicker/dist/zebra_datepicker.min.js" />
            <asp:ScriptReference Path="../AMSScripts/js/dataTables.bootstrap.min.js" />
            <asp:ScriptReference Path="../AMSScripts/js/ams.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-content" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <div class="content-wrapper">
                    <div class="content">
                        <!-- Inner container -->
                        <div class="d-flex align-items-start flex-column flex-md-row">
                            <!-- Left content -->
                            <div class="w-100 overflow-auto order-2 order-md-1">
                                <div class="col-md-12">
                                    <div class="custom_card">
                                        <div class="card_panel">
                                            <div class="card_panel_head">
                                                <div class="panel_head_caption">
                                                    <h4>Select Class And Section For Attendance.</h4>
                                                </div>
                                            </div>
                                            <div class="card_panel_body">
                                                <div class="panel_body_content">
                                                    <div class="col-md-12 pull-left">


                                                        <div class="col-md-4 pull-left">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblClass" runat="server" class="control-label pull-left text-left">Class</asp:Label>
                                                                <div class="col-md-9">
                                                                    <asp:DropDownList ID="select_class" CssClass="form-control form-control-inline" runat="server"
                                                                        AutoPostBack="True"
                                                                        ToolTip="Select Class and Section" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 pull-left datepicker_selection datepickerweekly daily">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">Date</label>
                                                                <div class="col-md-9">
                                                                    <asp:TextBox ID="datepicker" runat="server" data-zdp_readonly_element="false" CssClass="form-control datePicker_input" AutoPostBack="True" OnTextChanged="datepicker_TextChanged"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4 pull-left">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">View As</label>
                                                                <div class="col-md-9">
                                                                    <asp:DropDownList ID="view_as" runat="server"
                                                                        CssClass="form-control form-control-inline"
                                                                        AutoPostBack="true"
                                                                        OnSelectedIndexChanged="view_as_SelectedIndexChanged">
                                                                        <asp:ListItem Enabled="true" Text="Select View" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="daily" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Weekly" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Monthly" Value="3"></asp:ListItem>

                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="table-responsive daily_table">
                                                        <asp:GridView ID="gvAttnDaily" CssClass="table table-bordered"
                                                            OnRowCommand="gvAttnDaily_RowCommand" OnRowDataBound="gvAttnDaily_RowDataBound"
                                                            Style="width: 100%" runat="server" AutoGenerateColumns="false">
                                                            <Columns>

                                                                <asp:BoundField DataField="Attn_Id" HeaderText="Attn_Id">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                </asp:BoundField>


                                                                <asp:BoundField DataField="AttnType_Id" HeaderText="AttnType_Id">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="AttnType_Id" HeaderText="AttnType_Id">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                                                                </asp:BoundField>

                                                                <asp:TemplateField HeaderText="Sr. #">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Student_Id" HeaderText="Roll Number">
                                                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Name" HeaderText="Students">
                                                                    <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                                                </asp:BoundField>


                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Attandence                                                           
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div id="track">
                                                                            <asp:LinkButton ID="oneDayAtt" CommandArgument='<%# Container.DataItemIndex %>' runat="server" CommandName="P" ForeColor="Green" Text="P" Font-Size="X-Large"></asp:LinkButton>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="tr1" Font-Size="X-Large"></RowStyle>
                                                            <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                                            <HeaderStyle Font-Size="Medium" />
                                                        </asp:GridView>

                                                    </div>
                                                    <div class="table-responsive daily_table">
                                                        <asp:GridView ID="gvAttnWeekly" runat="server" Width="100%" SkinID="GridView" PageSize="150"
                                                            HorizontalAlign="Center" AllowPaging="True" CssClass="table table-bordered"
                                                            OnRowCreated="gvAttnWeekly_RowCreated" EnableViewState="true" OnRowDataBound="gvAttnWeekly_RowDataBound">
                                                            <RowStyle CssClass="tr1" Font-Size="X-Large"></RowStyle>
                                                            <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                                            
                                                        </asp:GridView>
                                                        <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
                                                    </div>

                                                </div>
                                                <div class="" style="margin-top: 20px">
                                                    <asp:Button ID="btnSave" CssClass="btn btn-primary pull-right" runat="server" OnClick="btnSave_Click" Text="Save" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </table>



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

