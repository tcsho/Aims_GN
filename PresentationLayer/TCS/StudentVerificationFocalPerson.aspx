<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="StudentVerificationFocalPerson.aspx.cs" Inherits="PresentationLayer_TCS_StudentVerificationFocalPerson" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
      <!-- Include the script for numeric validation -->
    <script type="text/javascript">
        function isNumeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>
      
            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Verification Focal Person"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
                </div>
                <br />
                <br />

                <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                            <tr style="width: 100%">
    <td  id="ddMonth" runat="server" style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
        Month*:
    </td>
    <td style="width: 60%" align="left">
        
                        <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="230" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged">
                        </asp:DropDownList>
    </td>
</tr>
                        <tr style="width: 100%">
    <td  id="tdRegion" runat="server" style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
        Region*:
    </td>
    <td style="width: 60%" align="left">
        <asp:DropDownList ID="ddl_region" runat="server"  OnSelectedIndexChanged="list_region_SelectedIndexChanged" CssClass="dropdownlist" Width="230px"
            AutoPostBack="True">
        </asp:DropDownList>
    </td>
</tr>
    <td id="TdCenter" runat="server" style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
        Center*:
    </td>
    <td style="width: 60%" align="left">
        <asp:DropDownList ID="ddl_Center" OnSelectedIndexChanged="ddl_Center_SelectedIndexChanged" runat="server" CssClass="dropdownlist" Width="230px"
            AutoPostBack="True">
        </asp:DropDownList>
    </td>
</tr>
                </table>
                <%-- <div class="row" style="display:flex;justify-content:center">
                            <div class="col-md-6 offset-md-3" style="width:25%">
                              
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="50%">
                                  
                                </asp:DropDownList>
                            </div>
                        </div>

                       
                        <div class="row" style="display:flex;justify-content:center">
                            <div class="col-md-6 offset-md-3" style="width:25%">
                                
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                   
                                </asp:DropDownList>
                            </div>
                        </div>--%>


                    <br />
       <asp:GridView ID="gvFocaPerson" DataKeyNames="Focal_Person_Id" OnRowCommand="gvFocaPerson_RowCommand" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="datatable table table-striped table-responsive">
    <Columns>
        <asp:BoundField DataField="Focal_Person_Id" Visible="false" HeaderText="Focal Person ID" />
       <%-- <asp:TemplateField HeaderText="Employee code">
            <ItemTemplate>
    <div class="row">
        <div class="col-md-6">
          <asp:TextBox ID="TextBox1" runat="server" Width="100%" Rows="2" Text='<%# Eval("Employee_code") %>' onkeypress="return isNumeric(event);"></asp:TextBox>

        </div>
        <div class="col-md-6">
            <asp:Button ID="FetchDataButton" runat="server" Text="Fetch Data" OnClick="FetchDataButton_Click" CssClass="btn btn-primary btn-md" />
        </div>
    </div>
</ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Employee code">
    <ItemTemplate>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="TextBox1" runat="server" Width="100%" Rows="2" Text='<%# Eval("Employee_code") %>' onkeypress="return isNumeric(event);"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" style="color: #333; font-size: 11px; font-family: Arial, Helvetica, sans-serif;"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Button ID="FetchDataButton" runat="server" Text="Fetch Data" OnClick="FetchDataButton_Click" CssClass="btn btn-primary btn-md" />
            </div>
        </div>
    </ItemTemplate>
</asp:TemplateField>



                                    <asp:TemplateField HeaderText="User Name">
    <ItemTemplate>
        <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("User_name") %>' style="color: #333;font-size: 11px;font-family: Arial, Helvetica, sans-serif;;"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                            
                                            <asp:TemplateField HeaderText="Designation">
    <ItemTemplate>
        <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("DesigName") %>' style="color: #333;font-size: 11px; font-family: Arial, Helvetica, sans-serif;"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">
    <ItemTemplate>
        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' style="color: #333;font-size: 11px; font-family: Arial, Helvetica, sans-serif;"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


                            <asp:BoundField DataField="Created_on" Visible="false"  HeaderText="Created On" />
                            <asp:BoundField DataField="Created_by" Visible="false" HeaderText="Created By" />
                            <asp:BoundField DataField="Modify_on" Visible="false" HeaderText="Modify On" />
                            <asp:BoundField DataField="Modify_by" Visible="false" HeaderText="Modify By" />
                            <asp:BoundField DataField="Status_id" HeaderText="Status ID" Visible="false" />
                            <asp:BoundField DataField="Month_name" HeaderText="Month Name" />
                            <asp:BoundField DataField="Center_id" HeaderText="Center ID" />
                            <asp:BoundField DataField="Region_id" HeaderText="Region ID" />
                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name" />
                       <asp:CommandField ShowEditButton="True" HeaderText="Save" EditText="Save">
    <ControlStyle CssClass="btn btn-primary" />
</asp:CommandField>




    </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                        <AlternatingRowStyle CssClass="tr2" />
                        <EmptyDataTemplate>
                            <div align="center" style="color: red;">No records found.</div>
                        </EmptyDataTemplate>
                    </asp:GridView>

                   
                    <div runat="server" visible="false" id="notFoundUnidentifiedStudents" align="center" style="color: red; border-style: double; margin-top: 20px; padding: 4px 0 4px 0;">No records found.</div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle" HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
