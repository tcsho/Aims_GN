<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TermSubjectComments.aspx.cs" Inherits="PresentationLayer_TCS_TermSubjectComments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
      
  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
   <cc1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePageMethods="true">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/jquery-3.6.4.min.js" />
        <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
    </Scripts>
</cc1:ToolkitScriptManager>


    <br />
  

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

<script type="text/javascript" src="https://cdn.rawgit.com/eKoopmans/html2pdf/v0.10.1/dist/html2pdf.bundle.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/eKoopmans/html2pdf/v0.10.1/dist/html2pdf.bundle.js.map"></script>
 <script type="text/javascript" src="path/to/FileSaver.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.17.4/xlsx.full.min.js"></script>

   <script type="text/javascript">
       // Define a class to represent a row of data
       class DataRow {
           
           constructor() {
               this.columns = [];
               this.values = [];
           }
       }

       function ImportExcel() {
           debugger;
           var fileInput = $("#<%= fileUpload.ClientID %>")[0];
           var file = fileInput.files[0];
           var isCheckSRChecked = $("#<%= CheckSR.ClientID %>").prop("checked");
           var isCheckNRChecked = $("#<%= checkNR.ClientID %>").prop("checked");
           var isCheckCRChecked = $("#<%= checkCR.ClientID %>").prop("checked");
           if (file) {
               var formData = new FormData();
               formData.append('file', file);

               var reader = new FileReader();
               reader.onload = function (e) {
                   var data = new Uint8Array(e.target.result);
                   var workbook = XLSX.read(data, { type: 'array' });
                   var sheet = workbook.Sheets[workbook.SheetNames[0]];
                   var rows = XLSX.utils.sheet_to_json(sheet, { header: 1, defval: '' });

                   
                   var dataRows = [];
                   for (var i = 1; i < rows.length; i++) {
                       var dataRow = new DataRow();
                       dataRow.columns = rows[0];
                       dataRow.values = rows[i];
                       dataRows.push(dataRow);
                   }

                   $.ajax({
                       url: 'TermSubjectComments.aspx/UploadDataTable',
                       type: 'POST',
                       contentType: 'application/json; charset=utf-8',
                       data: JSON.stringify({
                           DataRow_excel: dataRows, isCheckSRChecked: isCheckSRChecked,
                           isCheckNRChecked: isCheckNRChecked, isCheckCRChecked: isCheckCRChecked
                       }),
                       dataType: 'json',
                       success: function (response) {
                           console.log(response);
                           alert(response.d);
                       },
                       error: function (error) {
                           console.error('Error:', error.responseText);
                           // Additional error handling if needed
                       }
                   });
               };

               reader.readAsArrayBuffer(file);
           } else {
               alert("Please select a file.");
           }
       }



   </script>
<script type="text/javascript">
  
    function downloadFile() {
        // Use Fetch API to initiate a request to the server-side method
        fetch('TermSubjectComments.aspx/DownloadExcelFile', {
            method: 'POST', // Use POST for WebMethods
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                // Convert the Base64 string received from the server to a Blob
                const byteCharacters = atob(data.d);
                const byteNumbers = new Array(byteCharacters.length);
                for (let i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }
                const byteArray = new Uint8Array(byteNumbers);

                // Create a Blob with the correct MIME type
                const blob = new Blob([byteArray], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });

                // Check if the browser supports the download attribute
                if (navigator.msSaveBlob) {
                    // For Internet Explorer
                    navigator.msSaveBlob(blob, 'SubjectStaticCommnets.xlsx');
                } else {
                    // For other browsers
                    // Create a Blob URL and trigger the download
                    const blobUrl = URL.createObjectURL(blob);
                    const link = document.createElement('a');
                    link.href = blobUrl;
                    link.download = 'SubjectStaticCommnets.xlsx';
                    document.body.appendChild(link);
                    link.click();

                    // Clean up
                    URL.revokeObjectURL(blobUrl);
                    document.body.removeChild(link);
                }
            })
            .catch(error => console.error('Error downloading file:', error));
    }
    function b64toBlob(b64Data, contentType = '', sliceSize = 512) {
        const byteCharacters = atob(b64Data);
        const byteArrays = [];

        for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);

            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            const byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }

        const blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }


</script>


            <script type="text/javascript">


                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);


                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************

                            try {
                                //jq('table.datatable').DataTable({
                                //    destroy: true,
                                //    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                //    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                //    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                //        "<'row'<'col-sm-12'tr>>" +
                                //        //                     "<'row'<'col-sm-12'l>>" +
                                //        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                //    "columnDefs": [

                                //        //{ orderable: false, targets: [8]} //disable sorting on toggle button
                                //    ]

                                //    ,
                                //    tableTools:
                                //    { //Start of tableTools collection
                                //        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                //        "aButtons":
                                //            [ //start of button main/master collection



                                //                { // ******************* Start of child collection for export button
                                //                    "sExtends": "collection",
                                //                    "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                //                    "sToolTip": "Export Data",
                                //                    "aButtons":
                                //                        [ //start of button export buttons collection

                                //                            // ******************* Start of copy button
                                //                            {
                                //                                "sExtends": "copy",
                                //                                "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                //                                "sToolTip": "Copy Data"
                                //                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                            } // ******************* end of copy button

                                //                            // ******************* Start of csv button
                                //                            , {
                                //                                'sExtends': 'csv',
                                //                                'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                //                                ,
                                //                                "sFileName": "DataInCSVFormat - *.csv",
                                //                                "sToolTip": "Save as CSV",
                                //                                //'sButtonText': 'Save as CSV',
                                //                                "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                //                                "sNewLine": "auto"
                                //                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                            }  // ******************* end of csv button

                                //                            // ******************* Start of excel button
                                //                            , {
                                //                                'sExtends': 'xls',
                                //                                'bShowAll': false,
                                //                                "sFileName": "DataInExcelFormat.xls",
                                //                                //'sButtonText': 'Save to Excel',
                                //                                "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                //                                "sToolTip": "Save as Excel"
                                //                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                            }  // ******************* End of excel button


                                //                            // ******************* Start of PDF button
                                //                            , {
                                //                                'sExtends': "pdf",
                                //                                'bShowAll': false,
                                //                                "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                //                                //'sButtonText': 'Save to PDF',
                                //                                "sFileName": "DataInPDFFormat.pdf",
                                //                                "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                //                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                                //,"sPdfMessage": "Your custom message would go here."
                                //                            } // *********************  End of PDF button 

                                //                        ]// ******************* end of Export buttons collection
                                //                }    // ******************* end of child of export buttons collection
                                //            ] // ******************* end of button master Collection
                                //    } // ******************* end of tableTools
                                //    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                //    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                //    , //--- Dynamic Language---------
                                //    "oLanguage": {
                                //        "sZeroRecords": "There are no Records that match your search critera",
                                //        //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                //        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                //        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                //        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                //        "sEmptyTable": 'No Rows to Display.....!',
                                //        "sSearch": "Search :"
                                //    }
                                //}
                                //);

                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',
                                    //"retrieve": true,
                                    //"processing": true, //Optional, only useful for *large* tables
                                    //"serverSide": true,
                                    //"bPaginate": true,
                                    //"bLengthChange": true,
                                    //"bFilter": true,
                                    //"bInfo": true,
                                    //"buttons": [
                                    //    "copy", "excel"
                                    //],

                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [5, 9, 10, 11, 6, 7]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                               //// alert('datatable ' + err);
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
            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
                    $('#PoolConfig').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#PoolConfig').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalQuestion() {
                    $('#PoolQuestion').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalQuestion() {

                    $('#PoolQuestion').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalAnswer() {
                    $('#AnswerModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalAnswer() {

                    $('#AnswerModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalTest() {
                    //                    $('#myModal').modal('show');
                    $('#TestModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalTest() {

                    $('#TestModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>

            <div class="form-group">


                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Term Subject Static Commnets"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>

                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label1" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Region: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="list_region" runat="server"  OnSelectedIndexChanged="list_region_SelectedIndexChanged" CssClass="dropdownlist" AutoPostBack="True" Width="218px">
                            </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*term: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="True"
                                    CssClass="dropdownlist"
                                    OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="217px">
                                </asp:DropDownList>
                            </div>
                        </div>



                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblClass" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="*Class : "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="218px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
    <div class="row">
        <asp:Label ID="Region" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
            Text="*Region : "></asp:Label>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <asp:CheckBox ID="CheckSR" OnCheckedChanged="Checkbox_CheckedChanged" runat="server" Text="South" Checked="true" AutoPostBack="true" />
            <asp:CheckBox ID="checkCR" OnCheckedChanged="Checkbox_CheckedChanged" runat="server" Text="Central" Checked="true" AutoPostBack="true" />
            <asp:CheckBox ID="checkNR" OnCheckedChanged="Checkbox_CheckedChanged" runat="server" Text="North" Checked="false" AutoPostBack="true" />
        </div>
    </div>
    <div class="row">
        <asp:Label runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12"></asp:Label>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <asp:Button ID="Button" CssClass="btn btn-primary" runat="server" Text="Import Excel" OnClientClick="ImportExcel()" />
            <asp:Button ID="btnDownloadTemplate" runat="server" CssClass="btn btn-primary" Text="Download Template" OnClientClick="downloadFile(); return false;" />
            <asp:FileUpload ID="fileUpload" CssClass="btn btn-light ml-2" runat="server" />
        </div>
    </div>
</div>


                    </div>
                    <div runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                        <div class="pull-right">
                            <asp:Button ID="btnAddTest" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                                OnClick="btnAddTest_Click" Text="Add New" Visible="false" />

                        </div>
                             
</div>

                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTestTitle" visible="false">
                    Subject Comments
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
                    <asp:GridView ID="gvStaticComments" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <%--1--%>
                            <asp:BoundField DataField="GenCom_Id" HeaderText="GenCom_Id" SortExpression="GenCom_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--2--%>
                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--3--%>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--4--%>
                            <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--5--%>
                            <asp:BoundField DataField="TermGroup_Id" HeaderText="TermGroup_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--6--%>
                            <asp:TemplateField HeaderText="Sr. #">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--7--%>

                            <asp:BoundField DataField="Subject_Name" HeaderText="Subjects">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <%--8--%>
                            <asp:BoundField DataField="Comments" HeaderText="Comments">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <%--9--%>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("GenCom_Id") %>'
                                        ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                        ToolTip="Edit Record">
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--10--%>
                            <asp:BoundField DataField="Session_Name" HeaderText="Session">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--11--%>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--12--%>
                             <asp:BoundField DataField="Region_Name" HeaderText="Region_Name">
     <ItemStyle CssClass="hide" />
     <HeaderStyle CssClass="hide" />
 </asp:BoundField>
                            <asp:BoundField DataField="TermGroup_Name" HeaderText="TermGroup Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                           

                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                </div>


                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                    <p>
                        <br />
                        <asp:Label ID="lblGridStatus" runat="server" Visible="false"
                            CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>
                    </p>
                </div>

                <div class="container">

                    <div class="modal fade" id="TestModal" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Edit Subject Static Comments</h4>
                                </div>
                                <div class="modal-body">

                                    <p>
                                        <asp:Label ID="Subject" runat="server" CssClass="TextLabelMandatory40" Text="subject"></asp:Label>
                                        <asp:DropDownList ID="ddlsubject" runat="server" CssClass=" dropdownlist  form-control">
                                        </asp:DropDownList>

                                    </p>

                                    <p>
                                        <asp:Label ID="lblTestName" runat="server" CssClass="TextLabelMandatory40" Text="Static Comments:"></asp:Label>
                                        <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName"
                                            ErrorMessage="Comments Required" ForeColor="Red" ValidationGroup="test" />

                                    </p>


                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                        Text="Save" CausesValidation="true" ValidationGroup="test" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        OnClick="btnCancel_Click" Text="Cancel" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>

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
    <style>
        .dt-buttons {
            position: relative;
            float: none !important;
            text-align: center !important;
        }

            .dt-buttons button {
                background: #9eb5d5;
                border: white !important;
            }

                .dt-buttons button span {
                    color: white !important;
                    /* border: #fff !important; */
                }
    </style>
</asp:Content>