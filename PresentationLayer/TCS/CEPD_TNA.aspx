<%@ Page Title="Training Needs Analysis" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CEPD_TNA.aspx.cs"
    Inherits="PresentationLayer_CEPD_TNA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
   <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtSchoolHead">School Head:</label>
                    <asp:TextBox runat="server" ID="txtSchoolHead" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtCampusName">Campus Name with School Code:</label>
                    <asp:TextBox runat="server" ID="txtCampusName" CssClass="form-control" AutoPostBack="true" />
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
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtLevels">Levels (number of current staff):</label>
                    <asp:TextBox runat="server" ID="txtLevels" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="txtTotalTeachers">Total Number of Teachers:</label>
                    <asp:TextBox runat="server" ID="txtTotalTeachers" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-label" for="ddlTrainingRequired">Training Required:</label>
                    <asp:DropDownList runat="server" ID="ddlTrainingRequired" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTrainingRequired_SelectedIndexChanged">
                        <asp:ListItem Text="Choose One" Value="0" />
                        <asp:ListItem Text="Academic" Value="1" />
                        <asp:ListItem Text="Non-Academic" Value="2" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlAcademicTraining" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title titlesection" style="color:white">Academic Training</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="ddlTrainingAreas">Training Needs:</label>
                                        <asp:DropDownList runat="server" ID="ddlTrainingAreas" CssClass="form-control">
                                            <asp:ListItem Text="Area 1" Value="1" />
                                            <asp:ListItem Text="Area 2" Value="2" />
                                            <asp:ListItem Text="Area 3" Value="3" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="ddlLevel">Level:</label>
                                        <asp:DropDownList runat="server" ID="ddlLevel" CssClass="form-control">
                                            <asp:ListItem Text="Option 1" Value="1" />
                                            <asp:ListItem Text="Option 2" Value="2" />
                                            <asp:ListItem Text="Option 3" Value="3" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="fuSIQAReport">SIQA Report (Optional):</label>
                                        <asp:FileUpload runat="server" ID="fuSIQAReport" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="ddlPreferredMode">Preferred mode of training:</label>
                                        <asp:DropDownList runat="server" ID="ddlPreferredMode" CssClass="form-control">
                                            <asp:ListItem Text="Mode 1" Value="1" />
                                            <asp:ListItem Text="Mode 2" Value="2" />
                                            <asp:ListItem Text="Mode 3" Value="3" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="txtPreferredDateTime">Preferred Date and Time:</label>
                                        <asp:TextBox runat="server" ID="txtPreferredDateTime" CssClass="form-control" />
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
                                        <label class="form-label" for="txtConfirmedTrainees">Confirmed Number of Trainees:</label>
                                        <asp:TextBox runat="server" ID="txtConfirmedTrainees" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="txtTeacherERP">Name of Teacher&ERP#:</label>
                                        <asp:TextBox runat="server" ID="txtTeacherERP" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="form-label" for="txtTrainerPreference">Trainer Preference:</label>
                                        <asp:TextBox runat="server" ID="txtTrainerPreference" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    <asp:Panel ID="pnlNonAcademicTraining" runat="server" Visible="false">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title titlesection" style="color:white">Non-Academic Training</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="ddlTrainingAreasNonAcademic">Training Needs:</label>
                                <asp:DropDownList runat="server" ID="ddlTrainingAreasNonAcademic" CssClass="form-control">
                                    <asp:ListItem Text="Area 1" Value="1" />
                                    <asp:ListItem Text="Area 2" Value="2" />
                                    <asp:ListItem Text="Area 3" Value="3" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="ddlEmployeeCategory">Employee Category:</label>
                                <asp:DropDownList runat="server" ID="ddlEmployeeCategory" CssClass="form-control">
                                    <asp:ListItem Text="Category 1" Value="1" />
                                    <asp:ListItem Text="Category 2" Value="2" />
                                    <asp:ListItem Text="Category 3" Value="3" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="ddlPreferredModeNonAcademic">Preferred training:</label>
                                <asp:DropDownList runat="server" ID="ddlPreferredModeNonAcademic" CssClass="form-control">
                                    <asp:ListItem Text="Mode 1" Value="1" />
                                    <asp:ListItem Text="Mode 2" Value="2" />
                                    <asp:ListItem Text="Mode 3" Value="3" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="txtPreferredDateTimeNonAcademic">Date and Time:</label>
                                <asp:TextBox runat="server" ID="txtPreferredDateTimeNonAcademic" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="txtExpectedTraineesNonAcademic">Expected Number of Trainees:</label>
                                <asp:TextBox runat="server" ID="txtExpectedTraineesNonAcademic" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="form-label" for="txtConfirmedTraineesNonAcademic">Confirmed Number of Trainees:</label>
                                <asp:TextBox runat="server" ID="txtConfirmedTraineesNonAcademic" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-label" for="txtTeacherERPNonAcademic">Name of Teacher & ERP#:</label>
                                <asp:TextBox runat="server" ID="txtTeacherERPNonAcademic" CssClass="form-control" />
                            </div>
                        </div>
                   
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="form-label" for="txtTrainerPreferenceNonAcademic">Trainer Preference:</label>
                                <asp:TextBox runat="server" ID="txtTrainerPreferenceNonAcademic" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
          <div class="row">
                    <div class="col-md-12 text-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
                    </div>
                </div>
    </div>
  
</asp:Content>
