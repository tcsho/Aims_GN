<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_professional_Qualification.aspx.cs"
    Inherits="PresentationLayer_CEPD_professional_Qualification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <style type="text/css">
              
            </style>

            <script type="text/javascript">

</script>
            <div class="form-group formheading">
                <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="Professional Qualification"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
            </div>
            <br />
            <div class="form-group">
                <div class="row justify-content-center">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <!-- Category Input Fields -->
                        <div class="form-group">
                            <input id="qualID" runat="server" type="hidden" />
                            <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                Text="Qualification:" AssociatedControlID="txtProQualification">
                            </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <asp:TextBox runat="server" ID="txtProQualification" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                Text="Category:">
                            </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                    <asp:ListItem Selected="True"  Text="--Select--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Academic Qualification" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Professional Qualification" Value="P"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                    </div>

                  
                </div>
                   
                <div style="border: 0px solid; margin-left: 630px;">
                    <asp:Button ID="BtnSave" runat="server" OnClick="Btn_QulificationSave" Text="Save" CssClass="btn btn-primary"  />
                </div>


                <br />

                <div class="row justify-content-center">
                    <div class="col-md-12">
                        <!-- GridView with added space -->
                        <div class="form-group" style="margin-top: 20px;">

                            <div class="vh-100">
                                <%-- <h2>LO Consolidation</h2>--%>

                                <!-- Adjust margin-top as needed -->
                                <asp:GridView ID="GridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id" Visible="false" />
                                        <asp:TemplateField HeaderText="Srno">
                                            <ItemStyle Width="50px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Qualification" HeaderText="Professional Qualification" />
                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" OnClick="btnEdit_Click"
                                                    CommandArgument='<%# Eval("id") %>' CommandName='<%# Eval("Qualification") %>' ValidationGroup='<%# Eval("Category") %>'
                                                    ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                                    ToolTip="Edit Record" />
                                            </ItemTemplate>


                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" OnClick="btnDelete_Click"
                                                    CommandArgument='<%# Eval("id") %>' ForeColor="#004999"
                                                    ImageUrl="~/images/delete.gif" Style="text-align: center; font-weight: bold;"
                                                    ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>



                </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
