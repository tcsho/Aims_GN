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
              
            </script>


<div class="form-group">
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#Category" style="font-weight: bold;">Category</a></li>
        <li><a data-toggle="tab" href="#Subcategory" style="font-weight: bold;">Subcategory</a></li>
    </ul>
</div>

            <div class="tab-content">
                <!-- Category Tab -->
<div id="Category" class="tab-pane fade in active" style="position: relative;">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <!-- Category Input Fields -->
            <div class="form-group">
                <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                    Text="Category:" AssociatedControlID="txtcategory">
                </asp:Label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:TextBox runat="server" ID="txtcategory" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    
    <br />
    <asp:Button ID="btnCategory" runat="server" Text="Save Category" CssClass="btn btn-primary" style="position: absolute; top: 0; right: 0;" />
    <div class="row justify-content-center">
        <div class="col-md-12">
            <!-- GridView with added space -->
          
             <div class="form-group" style="margin-top: 20px;"> <!-- Adjust margin-top as needed -->
                <asp:GridView ID="GridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="Category_Id" HeaderText="Category_Id" />
                        <asp:BoundField DataField="Category_Name" HeaderText="Category_Name" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
<div id="Subcategory" class="tab-pane fade">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <!-- Category and Subcategory Input Fields -->
            <div class="form-group">
                <asp:Label runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                    Text="Category:" AssociatedControlID="ddlCategory">
                </asp:Label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
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
            <asp:Button ID="Button2" runat="server" Text="Save SubCategory" CssClass="btn btn-primary" />
        </div>
    </div>
    <!-- GridView with added space -->
    <div class="row justify-content-center">
        <div class="col-md-12">
            <div class="form-group" style="margin-top: 20px;">
                <asp:GridView ID="yourSubcategoryGridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="Subcategory_ID" HeaderText="Subcategory_ID" />
                        <asp:BoundField DataField="Subcategory_Name" HeaderText="Subcategory_Name" />
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
