<%@ Page Title="TRAINER PROFILE FORM" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_TrainerProfile.aspx.cs"
    Inherits="PresentationLayer_CEPD_TrainerProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">
        $(document).ready(function () {
            // Bind onchange event to checkboxes
            $('input[type="checkbox"]').change(function () {
                updateHiddenFields(); // Call function to update hidden fields
            });
        });

        // Function to update hidden fields
        function updateHiddenFields() {
            var selectedTrainings = [];
            var selectedTrainingTexts = [];
            $('input[type="checkbox"]:checked').each(function () {
                selectedTrainings.push($(this).val());
                selectedTrainingTexts.push($(this).parent().text().trim());
            });
            $('#<%= hidSelectedTrainings.ClientID %>').val(selectedTrainings.join(','));
            $('#<%= hidSelectedTrainingText.ClientID %>').val(selectedTrainingTexts.join(','));
        }
    </script>

    <script type="text/javascript">
    

            $(document).ready(function () {
                $('input[type=\"checkbox\"]').change(function () {
                    var selectedTrainings = [];
                    var selectedTrainingTexts = [];
                    $('input[type=\"checkbox\"]:checked').each(function () {
                        selectedTrainings.push($(this).val());
                        selectedTrainingTexts.push($(this).parent().text().trim());
                    });
                    $('#" + hidSelectedTrainings.ClientID + "').val(selectedTrainings.join(','));
                    $('#" + hidSelectedTrainingText.ClientID + "').val(selectedTrainingTexts.join(','));
                });
            });

        $('.search-input').on('input', function () {
            let searchText = $(this).val().toLowerCase();
            $('.options-container label').each(function () {
                let optionText = $(this).text().toLowerCase();
                if (optionText.includes(searchText)) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });
        $(document).ready(function () {
            try {
                // Populate selected training IDs dynamically based on the checkboxes that are checked
                var selectedTrainingIds = [];

                $('input[type="checkbox"]:checked').each(function () {
                    selectedTrainingIds.push($(this).attr('id').replace('chk_', ''));
                });

                // Update hidden fields with selected training IDs and texts
                var selectedTrainings = selectedTrainingIds;
                var selectedTrainingTexts = selectedTrainingIds.map(function (trainingId) {
                    return $('#chk_' + trainingId).parent().text().trim();
                });

                $('#hidSelectedTrainings').val(selectedTrainings.join(','));
                $('#hidSelectedTrainingText').val(selectedTrainingTexts.join(','));
            } catch (ex) {
                // Handle exceptions
                console.log("Error: " + ex.message); // Debugging statement
                sessionStorage.setItem("error", ex.message);
                window.location.href = "/presentationlayer/ErrorPage.aspx";
            }
        });


    </script>
    <asp:HiddenField ID="hidSelectedTrainings" runat="server" />
    <asp:HiddenField ID="hidSelectedTrainingText" runat="server" />


    <script type="text/javascript">
        function appendOptions(html) {
            debugger
            $('.options-container').html(html);
        }
    </script>

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <div class="form-group formheading">
        <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="TRAINER PROFILE FORM"></asp:Label>
        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
    </div>
    <br />
    <div class="form-content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <style type="text/css">
                    .form-group {
                        margin-bottom: 15px;
                    }

                    .form-label {
                        font-weight: bold;
                        margin-bottom: 5px;
                    }

                    .form-control {
                        width: 100%;
                        padding: 8px;
                        font-size: 14px;
                        border: 1px solid #ccc;
                        border-radius: 4px;
                    }

                    .btn-primary {
                        background-color: #007bff;
                        color: #fff;
                        border: none;
                        padding: 10px 20px;
                        border-radius: 4px;
                        cursor: pointer;
                    }

                        .btn-primary:hover {
                            background-color: #0056b3;
                        }

                    .form-content {
                        margin-top: 20px; /* Add margin to separate form content from the title */
                    }


                    .search-input {
                        margin: 10px 0;
                    }

                    .options-container {
                        max-height: 200px;
                        overflow-y: auto;
                    }

                    .dropdown-menu label {
                        display: block;
                        padding: 5px 20px;
                    }

                        .dropdown-menu label:hover {
                            background-color: #f0f0f0;
                        }

                    .tag-container {
                        display: inline-block;
                    }


                    .tag:hover {
                        background: #0056b3;
                    }

                    .tag {
                        position: relative; /* Ensure the close icon is positioned relative to the tag */
                        display: inline-block;
                        background: #007bff;
                        color: #fff;
                        padding: 2px;
                        margin-right: 5px;
                        margin-bottom: 5px;
                        border-radius: 5px;
                        cursor: pointer;
                    }

                    .close {
                        position: absolute;
                        top: -5px; /* Adjust as needed to position the cross icon */
                        right: -5px; /* Adjust as needed to position the cross icon */
                        color: black;
                        cursor: pointer;
                    }

                    .no-padding {
                        padding: 5px 25px;
                    }
                </style>

                <!-- Trainer Information Fields -->
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="ERP#:" AssociatedControlID="txtERPNumber" />
                            <div class="input-container" style="display: flex;">
                                <input runat="server" id="txtTrainerId" value="0" type="hidden" />
                                <asp:TextBox runat="server" ID="txtERPNumber" placeholder="ERP#" CssClass="form-control input-field" Style="flex: 1;" />
                                <asp:Button runat="server" ID="btnFetchData" Text="Fetch Details" OnClick="Btn_GetProfile" CssClass="btn btn-primary input-button no-padding" />
                            </div>
                        </div>


                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Name:" AssociatedControlID="txtTrainerName" />
                            <asp:TextBox runat="server" ID="txtTrainerName" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Designation:" AssociatedControlID="txtDesignation" />
                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Current Branch/RO/HO:" AssociatedControlID="txtBranch" />
                            <asp:TextBox runat="server" ID="txtBranch" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Area of Expertise:" AssociatedControlID="txtExpertise" />
                            <asp:TextBox runat="server" ID="txtExpertise" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Experience With TCS:" AssociatedControlID="txtExperienceTCS" />
                            <asp:TextBox runat="server" ID="txtExperienceTCS" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Total Experience (in Years) Outside TCS:" AssociatedControlID="txtExperienceOutsideTCS" />
                            <asp:TextBox runat="server" ID="txtExperienceOutsideTCS" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="col-md-3" hidden="hide">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Academic Qualification:" AssociatedControlID="txtAcademicQualification" />
                            <asp:TextBox runat="server" ID="txtAcademicQualification" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                      <div class="col-md-3">
                        <div class="form-group">
                            <label class="form-label" runat="server" for="ddlproQualif">Academic Qualification</label>
                            <div class="dropdown">
                                <button class="btn btn-secondary dropdown-toggle" style="width: 100%; text-align: left" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Academic Qualification
                                </button>
                                <div class="dropdown-menu" runat="server" style="width: 100%; text-align: left" id="ddlTrainingRequired" aria-labelledby="dropdownMenuButton">


                                    <input type="text" class="search-input form-control" placeholder="Search...">
                                    <div class="options-container">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="form-label" Text="Professional Qualification With TCS:" AssociatedControlID="ddlProfessionalQualificationTCS" />
                            <asp:DropDownList runat="server" ID="ddlProfessionalQualificationTCS" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="form-group">
                            <%--<asp:Label runat="server" CssClass="form-label" Text="Professional Qualification Outside TCS:" AssociatedControlID="ddlProfessionalQualificationOutsideTCS" />--%>
                          <%--  <asp:DropDownList runat="server" ID="ddlProfessionalQualificationOutsideTCS" CssClass="form-control">
                            </asp:DropDownList>--%>
                            <asp:Label runat="server" CssClass="form-label" Text="Qualification Outside TCS:"  />
                            <asp:TextBox runat="server" ID="txtProfessionalQualificationOutsideTCS" CssClass="form-control" /> 
                        </div>
                    </div>


                  

                </div>

                <div class="row">
                    <div class="col-md-9">
                        <div class="selected-items" style="max-height: 200px; overflow-y: auto;">
                        </div>
                    </div>
                    <div class="col-md-3 text-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Btn_Save" CssClass="btn btn-primary" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="panel-title titlesection" style="color: white">Academic Training</h3>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridtrainerProfile" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                            <asp:BoundField DataField="ERPNumber" HeaderText="ERP#" />
                            <asp:BoundField DataField="TrainerName" HeaderText="Name" />
                            <asp:BoundField DataField="Designation" HeaderText="Designation" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" />
                            <asp:BoundField DataField="ExperienceTCS" HeaderText="Experience" />
                            <asp:BoundField DataField="ExperienceOutsideTCS" HeaderText="Experience Outside TCS" />
                            <asp:BoundField DataField="AcademicQualification" HeaderText="Academic Qualification" visible="false"/>
                            <asp:BoundField DataField="ProfessionalQualificationTCS" HeaderText="Professional Qualification TCS" />
                            <asp:BoundField DataField="ProfessionalQualificationOutsideTCS" HeaderText="Professional Qualification Outside TCS" />
                            <asp:BoundField DataField="Expertise" HeaderText="Area of Expertise" />
                            <asp:BoundField DataField="Trainings" HeaderText="Trainings" Visible="false" />
                            <asp:BoundField DataField="Training_Name" HeaderText="Academic Qualification" />
                            <%-- <asp:BoundField DataField="created_on" HeaderText="Created_On" />
                    <asp:BoundField DataField="created_by" HeaderText="Created_By" />--%>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" OnClick="Edit" runat="server"
                                        CommandArgument='<%# String.Format("{0}", Eval("Id")) %>'
                                        CommandName='<%# Eval("Id") %>'
                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                        ToolTip="Edit Record" />


                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--      <asp:TemplateField HeaderText="Delete">
                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" OnClick="btnSubCateDelete_Click" 
                                CommandArgument='<%# Eval("subcategory_id") %>' ForeColor="#004999" 
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
</asp:Content>
