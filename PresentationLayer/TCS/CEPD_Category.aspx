<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_Category.aspx.cs"
    Inherits="PresentationLayer_CEPD_Category" %>

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
     $(document).ready(function () {
         // Explicitly set the active tab to Subcategory when Save Sub Category button is clicked
         $('#<%= Btn_SubCat.ClientID %>').click(function () {
                        $('.nav-tabs a[href="#Subcategory"]').tab('show');
                    });
                });
 </script>
            <div class="form-group formheading">
                <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="Category & SubCategory"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
            </div>
            <br />
            <div class="form-group">
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#Category" style="font-weight: bold;">Category</a></li>
                    <li><a data-toggle="tab" href="#Subcategory" style="font-weight: bold;">Subcategory</a></li>
                </ul>
            </div>

            <div class="tab-content">
                <!-- Category Tab -->
                <div id="Category" class="tab-pane fade in active" style="position: relative;">
                    <div class="panel-heading">
                        <h3 class="panel-title titlesection" style="color: white">Category</h3>
                    </div>
                    <br />
                    <div class="row justify-content-center">
                        <div class="col-md-6">
                            <!-- Category Input Fields -->
                            <div class="form-group">
                                <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                    Text="Category:" AssociatedControlID="txtcategory">
                                </asp:Label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <input id="catID" runat="server" type="hidden" />
                                    <asp:TextBox runat="server" ID="txtcategory" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 text-right">
                            <asp:Button ID="BtnCategory" OnClick="Btn_Category" runat="server" Text="Save Category" CssClass="btn btn-primary" />
                        </div>
                    </div>


                    <br />

                    <div class="row justify-content-center">
                        <div class="col-md-12">
                            <!-- GridView with added space -->
                            <div class="form-group" style="margin-top: 20px;">
                                <!-- Adjust margin-top as needed -->
                                <asp:GridView ID="GridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="category_id" HeaderText="Category_Id" Visible="false" />
                                        <asp:TemplateField HeaderText="Srno">
                                            <ItemStyle Width="50px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="category_name" HeaderText="Category_Name" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" OnClick="btnEdit_Click"
                                                    CommandArgument='<%# Eval("category_id") %>' CommandName='<%# Eval("category_name") %>'
                                                    ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                                    ToolTip="Edit Record" />
                                            </ItemTemplate>


                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" OnClick="btnDelete_Click"
                                                    CommandArgument='<%# Eval("category_id") %>' ForeColor="#004999"
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
                <div id="Subcategory" class="tab-pane fade">
                    <div class="panel-heading">
                        <h3 class="panel-title titlesection" style="color: white">Sub Category</h3>
                    </div>
                    <br />
                    <div class="row justify-content-center">
                        <div class="col-md-6">
                            <!-- Category and Subcategory Input Fields -->
                            <div class="form-group">
                                <input id="subCat_id" runat="server" type="hidden"/>
                                <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                    Text="Category:" AssociatedControlID="ddlCategory">
                                </asp:Label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                    Text="Subcategory:" AssociatedControlID="txtSubcategory">
                                </asp:Label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <asp:TextBox runat="server" ID="txtSubcategory" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- Button aligned to the top-right corner -->
                        <div class="col-md-6 text-right">
                            <asp:Button ID="Btn_SubCat" runat="server" Text="Save Subcategory" OnClick="Btn_SubCategory" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <!-- GridView with added space -->
                   <div class="row justify-content-center">
    <div class="col-md-12">
        <div class="form-group" style="margin-top: 20px;">
            <asp:GridView ID="GridSubCategory" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="subcategory_id" HeaderText="Subcategory_Id" Visible="false" />
                    <asp:BoundField DataField="category_name" HeaderText="category" />
                    <asp:BoundField DataField="subcategory_name" HeaderText="Subcategory" />
                    <asp:BoundField DataField="category_id" HeaderText="Category_Id" Visible="false" />
                   <%-- <asp:BoundField DataField="created_on" HeaderText="Created_On" />
                    <asp:BoundField DataField="created_by" HeaderText="Created_By" />--%>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
          
                         <ItemTemplate>
                                        <asp:ImageButton ID="btnSubCat" runat="server" OnClick="btnSubCatEdit_Click"
    CommandArgument='<%# String.Format("{0},{1},{2}", Eval("category_id"), Eval("subcategory_id"), Eval("subcategory_name")) %>'
    CommandName='<%# Eval("category_id") %>'
    ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
    ToolTip="Edit Record" />


                                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" OnClick="btnSubCateDelete_Click" 
                                CommandArgument='<%# Eval("subcategory_id") %>' ForeColor="#004999" 
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




                <%--</div>--%>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>