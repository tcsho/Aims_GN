<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchStudent.ascx.cs"
    Inherits="PresentationLayer_TCS_SearchStudent" %>
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

                        //       { orderable: false, targets: [9, 11, 12] } //disable sorting on toggle button
                                    ]

                                   ,
                        tableTools:
                       { //Start of tableTools collection
                           "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                           "aButtons":
                            [ //start of button main/master collection
                                                                        ] // ******************* end of button master Collection
                       } // ******************* end of tableTools
            , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true
            , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
<table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
    border="0">
    <tbody>
        <tr>
            <td colspan="7">
                <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                    border="0">
                    <tbody>
                        <tr>
                            <td style="height: 100%" width=".5%">
                            </td>
                            <%--  <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Search Students"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>--%>
                        </tr>
                    </tbody>
                </table>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="text_dateOfBirth">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="height: 15px" align="right">
                <%--    <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>--%>
                <%-- <asp:Button ID="but_Export" TabIndex="4" OnClick="but_Export_Click" runat="server"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>--%>
            </td>
        </tr>
        <tr>
            <td style="height: 15px" align="right">
            </td>
        </tr>
        <tr>
            <td class="titlesection" colspan="7">
                Search Criteria
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="7">
                <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                    <tbody>
                        <tr class="tr2">
                            <td width="2%" height="25">
                                &nbsp;
                            </td>
                            <td class="TextLabel">
                                First Name :
                            </td>
                            <td style="width: 160px">
                                <asp:TextBox ID="text_firstName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="TextLabel">
                                Middle Name :
                            </td>
                            <td width="26%">
                                <asp:TextBox ID="text_middleName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td style="height: 25px" width="2%">
                                &nbsp;
                            </td>
                            <td class="TextLabel">
                                Last Name :
                            </td>
                            <td style="width: 160px; height: 25px">
                                <asp:TextBox ID="text_lastName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="TextLabel">
                                Date of Birth :
                            </td>
                            <td style="height: 25px">
                                <asp:TextBox ID="text_dateOfBirth" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td style="height: 25px">
                            </td>
                            <td class="TextLabel">
                                Gender :
                            </td>
                            <td style="width: 160px; height: 25px">
                                <asp:DropDownList ID="list_gender" runat="server" CssClass="dropdownlist">
                                </asp:DropDownList>
                            </td>
                            <td class="TextLabel">
                                Student No :
                            </td>
                            <td style="height: 25px">
                                <asp:TextBox ID="text_studentNo" runat="server" CssClass="textbox" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td height="25">
                            </td>
                            <td class="TextLabel">
                                Region :
                            </td>
                            <td style="width: 160px">
                                <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                    OnSelectedIndexChanged="list_region_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lab_region" runat="server"></asp:Label>
                            </td>
                            <td class="TextLabel">
                                 <asp:Label ID="lbl_StdStatus" runat="server" Text="Student Status :" class="TextLabel" ></asp:Label>  
                            </td>
                            <td>
                                <asp:DropDownList ID="list_studentStatus" runat="server" CssClass="dropdownlist">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td height="25">
                            </td>
                            <td class="TextLabel">
                                Center :
                            </td>
                            <td style="width: 160px">
                                <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_center_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lab_center" runat="server"></asp:Label>
                            </td>
                            <td class="TextLabel">
                               <asp:Label ID="lblClass" runat="server" Text="Class :" class="TextLabel" ></asp:Label>  
                            </td>
                            <td>
                                <asp:DropDownList ID="list_class" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                    OnSelectedIndexChanged="list_class_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td height="25">
                            </td>
                            <td class="TextLabel">
                                 <asp:Label ID="lbl_teacher" runat="server" Text="Teacher :" class="TextLabel"></asp:Label> 
                            </td>
                            <td style="width: 160px">
                                <asp:DropDownList ID="list_teacher" runat="server" CssClass="dropdownlist">
                                </asp:DropDownList>
                                <asp:Label ID="lab_teacher" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lab_section" runat="server" Text="Section :" ></asp:Label>
                            </td>
                            <td style="width: 160px">
                                <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;
            </td>
        </tr>
    </tbody>
</table>
