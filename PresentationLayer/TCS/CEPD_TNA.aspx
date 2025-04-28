<%@ Page Title="Training Needs Analysis" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_TNA.aspx.cs"
    Inherits="PresentationLayer_CEPD_TNA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function TrainingType() {
            var TriningValue = $('#ddlTrainingRequired').find(":selected").val();
            //alert(conceptName);
            if (TriningValue == 1) {
                $('#spTrainingType').text('Academic Training');
            }
            else {
                $('#spTrainingType').text('Non-Academic Training');
            }
        }
        $(document).ready(function () {
            // ================ For Multiselect Teachers Start ========================
            var checkboxesKeyStage = $(".options-container_KefStage input");
            var checkboxesTeacher = $(".options-container-Teacher input");
            checkboxesKeyStage.on("change", function () {
                updateKeyStageHiddenFields(); // Call function to update hidden fields
            });
            checkboxesTeacher.on("change", function () {
                updateTeacherHiddenFields(); // Call function to update hidden fields
            });

           <%-- $('#<%= list_region.ClientID %>').click(function () {
                $('.nav-tabs a[href="#TNAList"]').tab('show');
            });
            $('#<%= but_search.ClientID %>').click(function () {
                $('.nav-tabs a[href="#TNAList"]').tab('show');
            });--%>
        });
        function updateKeyStageHiddenFields() {
            // alert('KeyStage');            
            var selectedKeyStage = [];
            var selectedKeyStageText = [];

            $('.options-container_KefStage input[type=\"checkbox\"]:checked').each(function () {
                // alert($(this).val());
                selectedKeyStage.push($(this).val());
                selectedKeyStageText.push($(this).parent().text().trim());

            });
            //alert(selectedKeyStage);
            //alert(selectedKeyStageText);
            $('#<%= hidSelectedKeyStage.ClientID %>').val(selectedKeyStage.join(','));
            $('#<%= hidSelectedKeyStageText.ClientID %>').val(selectedKeyStageText.join(','));
            $('#hidSelectedKeyStage').val(selectedKeyStage.join(','));
            $('#hidSelectedKeyStageText').val(selectedKeyStageText.join(','));

            //alert($('#hidSelectedKeyStage').val());
        }
        function updateTeacherHiddenFields() {
            //alert('Teacher');
            //var checkboxesTeacher = $(".options-container-Teacher input");
            var selectedTeachers = [];
            var selectedTeachersText = [];
            var value = 0;
            $('.options-container-Teacher input[type=\"checkbox\"]:checked').each(function () {
                selectedTeachers.push($(this).val());
                selectedTeachersText.push($(this).parent().text().trim());
                value = value + 1;
            });
            $('#<%= hidSelectedTeacher.ClientID %>').val(selectedTeachers.join(','));
            $('#<%= hidSelectedTeacherText.ClientID %>').val(selectedTeachersText.join(','));
            $('#hidSelectedTeacher').val(selectedTeachers.join(','));
            $('#hidSelectedTeacherText').val(selectedTeachersText.join(','));

            $('#txtConfirmedTrainees').val(value);
            $('#<%= hdConfirmedTrainees.ClientID %>').val(value);
            $('#hdConfirmedTrainees').val(value);
        }
       //  ================ For Multiselect Teachers End ========================

       // ================ For Multiselect KeyStage Start ========================
    </script>
    <asp:HiddenField ID="hidSelectedKeyStage" runat="server" />
    <asp:HiddenField ID="hidSelectedKeyStageText" runat="server" />
    <asp:HiddenField ID="hidSelectedTeacher" runat="server" />
    <asp:HiddenField ID="hidSelectedTeacherText" runat="server" />



    <script type="text/javascript">
        function appendTeachers(html) {

            // debugger          
            $('.options-container-Teacher').html(html);
            updateTeacherHiddenFields();
        }
        function appendKeyStage(html) {
            //debugger           
            $('.options-container_KefStage').html(html);
            updateKeyStageHiddenFields();
        }


    </script>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <style>
        .search-input {
            margin: 10px 0;
        }

        .options-container_KefStage {
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
    </style>

    <br />
    <div class="form-group formheading">
        <asp:Label ID="lblTitle" CssClass="lblFormHead" runat="server" Text="TNA FORM"></asp:Label>
        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />
    </div>
    <br />
    <div class="formheading ">
        <h3 class="panel-title titlesection" style="color: white">TNA</h3>
    </div>
    <br />
    <div runat="server" id="divMessage" visible="false">
        <div class="alert alert-success" role="alert">
            <span runat="server" id="spanMessage"></span>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtSchoolHead">Campus Code:</label>
                    <div class="input-container" style="display: flex;">
                        <input runat="server" id="txtcenter" value="0" type="hidden" />
                        <asp:TextBox runat="server" ID="txtSchoolHead" placeholder="Please enter Code.." CssClass="form-control input-field" Style="flex: 1;" AutoPostBack="true" OnTextChanged="Btn_GetDetails" />
                        <span style="color: red; font-size: x-large; font-weight: bold" id="spanSchoolHead" runat="server" visible="false">*</span>
                        <asp:Button runat="server" ID="btnFetchData" Text="Fetch Details" OnClick="Btn_GetDetails" CssClass="btn btn-primary input-button no-padding" />
                    </div>
                </div>

            </div>
            <div class="col-md-4">
                <div class="form-group">

                    <label class="form-label" for="txtCampusName">Campus Name:</label>
                    <asp:TextBox runat="server" ID="txtCampusName" CssClass="form-control" ReadOnly="true" />

                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtCity">City:</label>
                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtRegion">Region:</label>
                    <asp:TextBox runat="server" ID="txtRegion" CssClass="form-control" ReadOnly="true" />
                    <asp:HiddenField runat="server" ID="hdRegionID" />
                    <asp:HiddenField runat="server" ID="hdTNAID" />
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <label class="form-label" for="txtLevels">Current Staff:</label>
                    <asp:TextBox runat="server" ID="txtCurrentStaff" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group" style="display: flex; align-items: center;">
                    <div style="flex-grow: 1;">
                        <label class="form-label" for="dropdownMenuButton">Key Stages </label>
                        <div class="dropdown">
                            <button class="btn btn-secondary dropdown-toggle" style="width: 100%; text-align: left" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Select Key Stages
                            </button>
                            <div class="dropdown-menu" runat="server" style="width: 90%; text-align: left" id="Div2" aria-labelledby="dropdownMenuButton">
                                <input type="text" class="search-input form-control" placeholder="Search...">
                                <div class="options-container_KefStage">
                                </div>
                            </div>
                            <span style="color: red; font-size: x-large; font-weight: bold; position: absolute" id="spanKeyStage" runat="server" visible="false">*</span>
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnTeachers" Text="Search" OnClick="Btn_GetTotalTeachers" CssClass="btn btn-primary input-button no-padding" Style="margin-left: 10px; margin-top: 5px; margin-bottom: -19px;" />

                </div>
            </div>

            <div class="col-md-2">
                <div class="form-group">
                    <label class="form-label" for="txtTotalTeachers">Total Teachers:</label>
                    <asp:TextBox runat="server" ID="txtTotalTeachers" CssClass="form-control" ReadOnly="true" />

                </div>
            </div>


        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlTrainingRequired">Training Required:</label>
                    <asp:DropDownList runat="server" ID="ddlTrainingRequired" class="form-control" onchange="TrainingType()" ClientIDMode="Static">
                        <%--<asp:ListItem Value="0">Choose One</asp:ListItem>--%>
                        <asp:ListItem Value="1">Academic</asp:ListItem>
                        <asp:ListItem Value="2">Non-Academic</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>


        </div>
    </div>
    <div class="formheading">
        <h3 class="panel-title titlesection" style="color: white" id="spTrainingType" runat="server" clientidmode="Static">Academic Training</h3>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlTrainingAreas">Training category:</label>
                    <asp:DropDownList runat="server" ID="ddlCategory" Style="width: 95%" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <div style="position: absolute; right: 5%; bottom: 15%;">
                        <span style="color: red; font-size: x-large; font-weight: bold;" id="spanCategory" runat="server" visible="false">*</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlTrainingAreas">Training Sub category:</label>
                    <asp:DropDownList runat="server" Style="width: 95%" ID="ddlSubCategory" CssClass="form-control">
                    </asp:DropDownList>
                    <div style="position: absolute; right: 5%; bottom: 60%;">
                        <span style="color: red; font-size: x-large; font-weight: bold; position: absolute" id="spanSubCategory" runat="server" visible="false">*</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlLevel">Level:</label>
                    <asp:TextBox runat="server" ID="txtLevels" CssClass="form-control" />

                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlPreferredMode">Preferred mode of training:</label>
                    <asp:DropDownList runat="server" ID="ddlPreferredMode" CssClass="form-control">
                        <asp:ListItem Text="Online" Value="1" />
                        <asp:ListItem Text="Face to Face" Value="2" />
                        <asp:ListItem Text="Blended" Value="3" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtPreferredDateTime">Preferred Date and Time:</label>
                    <asp:TextBox runat="server" ID="txtPreferredDateTime" CssClass="form-control" type="date" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtExpectedTrainees">Expected Number of Trainees:</label>
                    <asp:TextBox runat="server" ID="txtExpectedTrainees" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="fuSIQAReport">SIQA Report (Optional):</label>
                    <asp:FileUpload runat="server" ID="fuSIQAReport" CssClass="form-control" />

                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group" style="margin-top: 10%;">
                    <asp:LinkButton Style="font-size: 14px; font-weight: bold;" runat="server" ID="lbtnSiqareport" Visible="false" OnClick="lbtnSiqareport_Click"></asp:LinkButton>
                    <asp:HiddenField runat="server" ID="hdSIQFilePath" />
                </div>
            </div>
        </div>
    </div>
    <div class="panel-heading formheading">
        <h3 class="panel-title titlesection" style="color: white">After Approval</h3>
    </div>
    <br />
    <div class="container">
        <div class="row" style="background-color: lightgray;">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="dropdownMenuButtonTeacher">Trainees ERP# </label>
                    <div class="dropdown">

                        <button class="btn btn-secondary dropdown-toggle" style="width: 100%; text-align: left" type="button" id="dropdownMenuButtonTeacher" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Select Teacher
                        </button>
                        <div class="dropdown-menu" runat="server" style="width: 100%; text-align: left" id="Div1" aria-labelledby="dropdownMenuButtonTeacher">


                            <input type="text" class="search-input form-control" placeholder="Search...">
                            <div class="options-container-Teacher">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtConfirmedTrainees">Confirmed Number of Trainees:</label>
                    <asp:TextBox runat="server" ID="txtConfirmedTrainees" CssClass="form-control" disabled ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hdConfirmedTrainees" Value="0" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlTrainer">Assigned Trainer:</label>
                    <asp:DropDownList runat="server" ID="ddlTrainer" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <%--<div class="row">
                <div class="col-md-4" hidden="hidden">
                    <div class="selected-items" style="max-height: 200px; overflow-y: auto;">
                    </div>
                    <div class="selected-items_training" style="max-height: 200px; overflow-y: auto;">
                    </div>
                </div>
            </div>--%>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12 text-right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
