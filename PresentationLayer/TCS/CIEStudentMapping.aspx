<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CIEStudentMapping.aspx.cs" Inherits="PresentationLayer_TCS_CIEStudentMapping"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">

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
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                                    //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                            { orderable: false, targets: [2]} //disable sorting on toggle button
                                        ]

                                ,
                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection



              { // ******************* Start of child collection for export button
              "sExtends": "collection",
              "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
              "sToolTip": "Export Data",
              "aButtons":
                     [ //start of button export buttons collection

              // ******************* Start of copy button
                {
                "sExtends": "copy",
                "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                "sToolTip": "Copy Data"
                  , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
            } // ******************* end of copy button

              // ******************* Start of csv button
              , {
                  'sExtends': 'csv',
                  'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                  ,
                  "sFileName": "DataInCSVFormat - *.csv",
                  "sToolTip": "Save as CSV",
                  //               'sButtonText': 'Save as CSV',
                  "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                  "sNewLine": "auto"
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //                   'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //               'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": -1, 'bLengthChange': true // ,"bJQueryUI":true
         , "order": [[2, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Students Roll No. Mapping with CIE Candidate No."></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr style="width: 100%">
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">
                                            Select Criteria
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr id="trMoId" runat="server">
                                                    <td class="TextLabelMandatory40">
                                                        Main Organization* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                            Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="rfv_mOrg" runat="server" Width="200px" Enabled="False"
                                                            ErrorMessage="Mian Org is a required Field" Display="Dynamic" ControlToValidate="ddl_MOrg"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trCountry" runat="server">
                                                    <td class="TextLabelMandatory40">
                                                        Main Organization Country* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                            OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                                            ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trRegion" runat="server">
                                                    <td class="TextLabelMandatory40">
                                                        Region* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                            ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trCenter" runat="server">
                                                    <td class="TextLabelMandatory40">
                                                        Center*:
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtPKNo" CssClass="textbox" runat="server" ReadOnly="true" Visible="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                            ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr2">
                                                    <td class="TextLabelMandatory40">
                                                        Academic Year* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="167px"
                                                            Enabled="False" ErrorMessage="Academic Year is a required Field" Display="Dynamic"
                                                            ControlToValidate="ddlSession" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr3">
                                                    <td class="TextLabelMandatory40">
                                                        Grade Level* :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlGradeLevel" runat="server" CssClass="dropdownlist" Width="250px"
                                                            OnSelectedIndexChanged="ddlGradeLevel_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>GCE O Level</asp:ListItem>
                                                            <asp:ListItem>GCE AS & A Level</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="167px"
                                                            Enabled="False" ErrorMessage="Class Level is a required Field" Display="Dynamic"
                                                            ControlToValidate="ddlGradeLevel" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr id="trSave" runat="server" style="text-align: center">
                                        <td>
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="btnEdit_Click"
                                                Text="Save" ValidationGroup="a" />
                                        </td>
                                    </tr>
                                    <tr id="trCDT" runat="server" visible="True">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            List of student(s) appeard in CIE
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                                <table>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trGVOpt" runat="server" visible="false">
                                        <td align="right" colspan="13" style="height: 19px; text-align: right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvAttnTypedt" runat="server" AllowPaging="True" AllowSorting="True"
                                                CssClass="datatable table table-striped table-condensed table-responsive" OnPreRender="gvAttnTypedt_PreRender"
                                                OnRowDataBound="gvAttnTypedt_RowDataBound" AutoGenerateColumns="False" HorizontalAlign="Center"
                                                PageSize="2000" SkinID="GridView" Width="100%">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:BoundField DataField="CIE_Can_Id" HeaderText="CIE_Can_Id">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CandidateNo" HeaderText="CIE Candidate #"></asp:BoundField>
                                                    <asp:BoundField DataField="CIEStudentName" HeaderText="CIE Student Name"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="ERP Student #">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_Student_Id" runat="server" AutoPostBack="true" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblStudentName" HorizontalAlign="Left"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Campus">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCampus" CssClass=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Class">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblclass" CssClass=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Grade_Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblGrade_Id" CssClass=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Student_Id" HeaderText="Student_Id">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Center_Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCenter_Id" CssClass=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="StudentName" HeaderText="StudentName">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MappedCenter" HeaderText="MappedCenter">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Class_Name" HeaderText="Class_Name">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Registered As">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" CssClass="dropdownlist" ID="ddlRegis">
                                                                <asp:ListItem Value="0" Text="--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Regular"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Private"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:BoundField DataField="RegisteredAs" HeaderText="RegisteredAs">
                                                        <ItemStyle CssClass="hide"></ItemStyle>
                                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                                    </asp:BoundField>
                                                </Columns>
                                                <SelectedRowStyle CssClass="tr_select" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                            <asp:Label ID="lblNoDatadt" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                        </td>
                    </tr>
                    <tr id="btnGen" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
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
</asp:Content>
