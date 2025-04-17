<%@ Page Title="Marks Lock Unlock" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MarksUnlock.aspx.cs" Inherits="PresentationLayer_TCS_MarksUnlock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
        <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            
    </Scripts>

</cc1:ToolkitScriptManager>

    <br />

    <script type="text/javascript">

        function showCompileConfirmation() {
            // Customize this function based on your logic for checking selected records
            var selectedRecords = getSelectedRecords(); // Implement this function to get selected records

            // Check if any records are selected
            if (selectedRecords.length > 0) {
                // Show the modal
                $('#myModal').modal('show');
                return false; // Prevent the server-side click event
            } else {
                // No records selected, you can show an alert or perform other actions
                alert('Please select records before compiling.');
                return false; // Prevent the server-side click event
            }
        }

        function getSelectedRecords() {
            // Implement this function to get the selected records
            // You can use jQuery to iterate through checkboxes and find selected records
            // Example:
            var selectedRecords = [];
            $('#<%= gv_CenterGrid.ClientID %> input[type="checkbox"]:checked').each(function () {
            selectedRecords.push($(this).closest('tr').find('.yourRecordIdColumn').text()); // Replace 'yourRecordIdColumn' with the actual column class or ID
        });
        return selectedRecords;
    }

        Sys.Application.add_init(function () {
            // Initialization code here, meant to run once.

            jq(document).ready(document_Ready);


            function document_Ready() {

                jq(document).ready(function () {

                    //****************************************************************

                    try {
                        jq('table.datatable').DataTable({
                            destroy: true,
                            // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                            //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                     //       dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     //"<'row'<'col-sm-12'tr>>" +
                     //       //                     "<'row'<'col-sm-12'l>>" +
                     //           "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                            "dom": 'Blfrtip',
                            "buttons": [
                                {
                                    extend: 'excel',
                                    exportOptions: {
                                        columns: ':not(:last-child)',
                                    }
                                }
                            ],
                            "columnDefs": [

                                           { orderable: false, targets: [8, 9]} //disable sorting on toggle button
                            ]

                                ,
                            tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection


                         ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 200, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": false
         , //--- Dynamic Language---------
                            "oLanguage": {
                                "sZeroRecords": "There are no Records that match your search critera",
                                //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                "sInfoFiltered": "(filtered from _MAX_ total records)",
                                "sEmptyTable": 'No Rows to Display.....!',
                                "sSearch": "Search :"
                            }
                        }
                   );
                    }
                    catch (err) {
                        alert('datatable ' + err);
                    }

                    //****************************************************************



                }
   );

            } //end of documnet_ready()



            //Re-bind for callbacks
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                jq(document).ready(document_Ready);
                //            document_Ready();
                //            alert('call back done');
            }
);

        });
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Result Compilation,Marks Lock & Unlock"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server">
                        <div class="pull-right">
                            <asp:Button ID="btnComplie" runat="server" CssClass="btn btn-primary" OnClick="btnCompile_Click"
                                Text="Compile"/>
                            <asp:Button ID="btnLock" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                OnClick="btnLocking_Click" Text="Lock Marks"></asp:Button>
                            <asp:Button ID="btnUnlock" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                OnClick="btnUnlocking_Click" Text="Unlock Marks"></asp:Button>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label1" CssClass="TextLabelMandatory40" Text="*Term: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlTerm" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label3" CssClass="TextLabelMandatory40" Text="*Session: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlSession" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label6" CssClass="TextLabelMandatory40" Text="Class: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlClass" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label8" CssClass="TextLabelMandatory40" Text="*Evaluation Type: "
                                runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlEvaluationType" AutoPostBack="true"
                            Width="250px" Visible="false">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="CourseWork"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Exam/Theory"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label4" CssClass="TextLabelMandatory40" Text="Region: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlRegion" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label5" CssClass="TextLabelMandatory40" Text="Center: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlCenter" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label7" CssClass="TextLabelMandatory40" Text="Section: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlSection" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div id="Div1" class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server">
                        <div class="pull-right">
                            <asp:Button ID="btnLockedSection" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                OnClick="btnLockedSection_Click" Text="Locked Sections"></asp:Button>
                            <asp:Button ID="btnUnLockedSection" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                OnClick="btnUnLockedSection_Click" Text="Unlocked Sections"></asp:Button>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server"
                        id="GridTestTitle" visible="false">
                        Center Class Sections
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:GridView ID="gv_CenterGrid" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-striped table-responsive"
                            DataKeyNames="Center_Id" OnRowCommand="gv_CenterGrid_RowCommand" OnPreRender="gv_CenterGrid_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Id" HeaderText="Region_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Id" HeaderText="Region_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Region_Name" HeaderText="Region Name ">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name ">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CurrentStudents" HeaderText="Current Students">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ResultCompiled" HeaderText="Result Compiled">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NotCompiled" HeaderText="Not Compiled">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Lock /Unlock Marks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Visible='<%#(int )( Eval("Class_Id"))>6 && Convert.ToBoolean( Eval("LockMark"))==false%> '
                                            ForeColor="Red" class="">Unlocked</asp:Label>
                                        <asp:Label ID="Label3" runat="server" Visible='<%# (int )( Eval("Class_Id"))>6 && Convert.ToBoolean( Eval("LockMark"))==true%> '
                                            ForeColor="Green" class="">Locked</asp:Label>
                                       
                                       
                                        <asp:Label ID="Label9" runat="server" Visible='<%#(int )( Eval("Class_Id"))<=6 && Convert.ToBoolean( Eval("LockMarkEYE"))==false%> '
                                            ForeColor="Red" class="">Unlocked</asp:Label>
                                        <asp:Label ID="Label10" runat="server" Visible='<%#(int )( Eval("Class_Id"))<=6 && Convert.ToBoolean( Eval("LockMarkEYE"))==true%> '
                                            ForeColor="Green" class="">Locked</asp:Label>
                                        <%--   <asp:Button ID="btnLock" runat="server" CausesValidation="False" CssClass="btn btn-warning" CommandArgument='<%# Eval("Section_Id") %>'
                                            Visible='<%# Convert.ToBoolean( Eval("LockMark"))==false%> ' Text="Lock Marks" OnClick="btnLockMarks"></asp:Button>
                                        <asp:Button ID="btnUnlock" runat="server" CausesValidation="False" CssClass="btn btn-danger" OnClick="btnUnlockMarks"
                                            CommandArgument='<%# Eval("Section_Id") %>' Visible='<%# Convert.ToBoolean( Eval("LockMark"))==true%> ' Text="Unlock Marks"></asp:Button>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
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
    <!-- Add this section at the end of your page -->
<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Confirmation</h4>
            </div>
            <div class="modal-body">
                <h5>Are you sure you want to compile the more then 1 records?</h5>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
             <%--<button type="button" class="btn btn-primary" OnClick="btnYes_Click">Yes</button>--%>
<asp:Button ID="btnYes" class="btn btn-primary" runat="server" Text="Yes" OnClick="btnYes_Click" />





            </div>
        </div>
    </div>
</div>

<%--<script type="text/javascript">
    function callConfomation() {
        $.ajax({
            type: "POST",
            url: "MarksUnlock.aspx/confomation",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Handle the response if needed
                alert("Success!");
            },
            error: function (error) {
                // Handle the error if any
                alert("Error: " + error.responseText);
            }
        });
        $(document).ready(function () {
            // Add click event handler for the "Yes" button
            $("#btnYes").click(function () {
                // Call the server-side method using Page Methods
                PageMethods.confomation(onSuccess, onError);

                // Close the modal
                $("#myModal").modal("hide");
            });

        // Callback function for success
        function onSuccess() {
            // Handle success if needed
        }

        // Callback function for error
        function onError(error) {
            // Handle error if needed
            console.error(error);
        }
    });



</script>--%>

</asp:Content>


