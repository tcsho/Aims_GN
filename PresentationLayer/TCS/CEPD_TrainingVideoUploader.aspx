<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_TrainingVideoUploader.aspx.cs"
    Inherits="PresentationLayer_CEPD_TrainingVideoUploader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <style type="text/css">
              
            </style>
            <script type="text/javascript">
                function validateFileUpload() {
                    var fileUpload = document.getElementById('<%= fileVideo.ClientID %>');
                    var fileExtension = fileUpload.value.split('.').pop().toLowerCase();

                    // Allowed video file extensions
                    var allowedExtensions = ['mp4'];

                    // Check if the selected file's extension is in the allowed list
                    if (allowedExtensions.indexOf(fileExtension) === -1) {
                        // Clear the file selection
                        fileUpload.value = '';
                        // Display an error message
                        alert("Please select a video file (MP4).");
                    }
                }

                window.onload = function () {
                    var fileUpload = document.getElementById('fileVideo');
                    fileUpload.setAttribute('accept', '.mp4');
                };


            </script>



            </script>

            <script type="text/javascript">

                function copyToClipboard(text) {
                    debugger;
                    // Create a temporary textarea element to hold the text to be copied
                    var textarea = document.createElement("textarea");
                    textarea.value = text;
                    document.body.appendChild(textarea);

                    // Select the text in the textarea
                    textarea.select();

                    // Copy the selected text to the clipboard
                    document.execCommand("copy");

                    // Remove the temporary textarea
                    document.body.removeChild(textarea);

                    // Optionally, provide feedback to the user
                    alert('Text copied to clipboard.');
                }
            </script>

            <div class="form-group formheading">
                <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="Training Video Uploader"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
            </div>
            <br />
            <div class="form-group">
                <div class="row justify-content-center">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtTraining">Training:</label>
                                <asp:TextBox runat="server" ID="txtTraining" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="txtDescription">Description:</label>
                                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="fileVideo">Upload Video:</label>
                                <asp:FileUpload runat="server" ID="fileVideo" CssClass="form-control" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="StopTime">Stop Time(In Seconds):</label>
                                <asp:TextBox runat="server" ID="StopTime" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-4">
                            <div class="form-group" style="display: none;">
                                <label class="form-label" for="txtLink">Link:</label>
                                <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4" style="margin-top: 25px;">
                            <div class="form-group">
                                <asp:Button ID="Copy" runat="server" Text="Copy" CssClass="btn btn-primary" Style="display: none;" />
                            </div>
                        </div>
                        <div class="col-md-4 text-right" style="margin-top: 25px;">
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" OnClick="Btn_VidoeUpload" Text="Save" CssClass="btn btn-primary" />


                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="col-md-12">
                        <!-- GridView with added space -->
                        <div class="form-group" style="margin-top: 20px;">
                            <!-- Adjust margin-top as needed -->
                            <asp:GridView ID="GridView" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                    <asp:BoundField DataField="Training" HeaderText="Training" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Path" HeaderText="Path" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Link" DataNavigateUrlFormatString="{0}" DataTextField="Link" HeaderText="Link" Target="_blank" />
                                    <%-- <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" OnClick="Edit" runat="server" CommandArgument='<%# Eval("Id") %>' ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Id") %>' ForeColor="#004999" ImageUrl="~/images/delete.gif" Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
