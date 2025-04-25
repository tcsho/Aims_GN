<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_QuestionsforSelfPacedCourses.aspx.cs"
    Inherits="PresentationLayer_CEPD_QuestionsforSelfPacedCourses" %>

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
                <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="Questionnaire"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
            </div>
            <br />
            <div class="form-group">
                <div class="row justify-content-center">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-label" for="txtQuestion">Trainings:</label>
                            <asp:DropDownList runat="server" ID="ddl_Trainings" CssClass="form-control" required>
                                         
                                        </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-label" for="txtQuestion">Question:</label>
                                <asp:TextBox runat="server" id="txtQuestion" class="form-control" rows="1" required ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtOptionA">Option A:</label>
                                <asp:TextBox runat="server" ID="txtOptionA" CssClass="form-control" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtOptionB">Option B:</label>
                                <asp:TextBox runat="server" ID="txtOptionB" CssClass="form-control" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtOptionC">Option C:</label>
                                <asp:TextBox runat="server" ID="txtOptionC" CssClass="form-control" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtOptionD">Option D:</label>
                                <asp:TextBox runat="server" ID="txtOptionD" CssClass="form-control" required></asp:TextBox>
                            </div>
                        </div>
                    </div>
                  
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="ddlCorrectAnswer">Correct Answer:</label>
                                <asp:DropDownList runat="server" ID="ddlCorrectAnswer" CssClass="form-control" required>
                                    <asp:ListItem Text="Choose Answer" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="B" Value="B"></asp:ListItem>
                                    <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="D" Value="D"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="col-md-12 text-right">
                                  
                                                                <asp:Button ID="BtnCategory" OnClick="btnSave_traingquestions" runat="server" Text="Save Category" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <br />
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-12">
                            <!-- GridView with added space -->
                            <div class="form-group" style="margin-top: 20px;">
                                <!-- Adjust margin-top as needed -->
                                <asp:GridView ID="GridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:TemplateField HeaderText="Srno">
                                            <ItemStyle Width="50px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Question" HeaderText="Question" />
                                        <asp:BoundField DataField="OptionA" HeaderText="Option A" />
                                        <asp:BoundField DataField="OptionB" HeaderText="Option B" />
                                        <asp:BoundField DataField="OptionC" HeaderText="Option C" />
                                        <asp:BoundField DataField="OptionD" HeaderText="Option D" />
                                        <asp:BoundField DataField="CorrectAnswer" HeaderText="Correct Answer" />
                                        <asp:BoundField DataField="Training" HeaderText="Traning" />
                                        
                               <%--           <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" OnClick="Edit" runat="server"
                                        CommandArgument='<%# String.Format("{0}", Eval("Id")) %>'
                                        CommandName='<%# Eval("Id") %>'
                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                        ToolTip="Edit Record" />


                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                      <%--  <asp:TemplateField HeaderText="Delete">
                                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server"
                                                    CommandArgument='<%# Eval("Id") %>' ForeColor="#004999"
                                                    ImageUrl="~/images/delete.gif" Style="text-align: center; font-weight: bold;"
                                                    ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>

                </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
