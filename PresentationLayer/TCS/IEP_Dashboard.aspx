<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Dashboard.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <contenttemplate>
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <title>The City School</title>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">

            <!--Default installation-->
            <link rel="stylesheet" href="../Styles/iep_dashboardfile/jquery-ui.min.css" />
            <link rel="stylesheet" href="../Styles/iep_dashboardfile/bootstrap/css/bootstrap.min.css" />
            <!-- <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.min.css"/> -->


            <!--Installation using bower. Preferred!!! -->
            <!--<link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css"/>-->
            <!--<link rel="stylesheet" href="bower_components/jquery-ui/themes/ui-lightness/jquery-ui.min.css"/>-->
            <!--Run `bower install font-awesome` and uncomment this line to see font awesome examples-->
            <!--<link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css"/>-->

            <link rel="stylesheet" href="../Styles/iep_dashboardfile/lobipanel.css" />

            <!-- <link rel="stylesheet" href="lib/highlight/github.css"/> -->
            <!-- <link rel="stylesheet" href="demo/documentation.css"/> -->
            <!-- <link rel="stylesheet" href="demo/demo.css"/> -->
        </head>
        <body>
            <!--four boxes-->
            <%--<div id="root" class="margintp">
                <div class="container pt-5">
                    <div class="row align-items-stretch">
                        <div class="c-dashboardInfo col-lg-3 col-md-6">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Bifrucated</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo col-lg-3 col-md-6">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Undertaking</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_under">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo col-lg-3 col-md-6">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Above 60% Criteria</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_above">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo col-lg-3 col-md-6">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Below 60% Criteria</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_below">0</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!--four boxes-->
            <div class="row margintp" >
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                  <div class="c-dashboardInfo">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Bifrucated</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Undertaking</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_under">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Above 60% Criteria</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_above">0</span>
                            </div>
                        </div>
                        <div class="c-dashboardInfo">
                            <div class="wrap">
                                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Below 60% Criteria</h4>
                                <span class="hind-font caption-12 c-dashboardInfo__count total_below">0</span>
                            </div>
                        </div>
            </div>
                 <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                <div class="bs-example">
                                    <div id="lobipanel-basic" class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                List Of Students
                                            </div>
                                        </div>
                                        <div class="panel-body">
                       <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" CssClass="datatable table table-bordered table-condensed"
                    OnRowDataBound="Grid_IEPStudents_RowDataBound" OnPreRender="gv_details_PreRender"
                    EmptyDataText="No Record Exists." EmptyDataRowStyle-HorizontalAlign="Center">
                    <Columns>
                         <asp:BoundField HeaderText="Student ID" DataField="Student_Id" />
                        <asp:BoundField HeaderText="Name" DataField="First_Name" />
                        <asp:BoundField HeaderText="Campus" DataField="Campus" />
                        <asp:BoundField HeaderText="Class 8 1st Term" DataField="Class 8 1st Term" />
                           <asp:BoundField HeaderText="Class 8 2nd Term" DataField="Class 8 2nd Term" />
                        <asp:BoundField HeaderText="Class 9(O Level) 1st Term" DataField="Class 9(O Level) 1st Term" />
                           <asp:BoundField HeaderText="Class 9(O Level) 2nd Term" DataField="Class 9(O Level) 2nd Term" />
                        <asp:BoundField HeaderText="Class 10(O Level) 1st Term" DataField="Class 10(O Level) 1st Term" />
                          <asp:BoundField HeaderText="Class 10(O Level) 2nd Term" DataField="Class 10(O Level) 2nd Term" />
                     
                        <asp:TemplateField HeaderText="Total Undertaking" ItemStyle-Width="150" SortExpression="1">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_cnd" runat="server" Text='' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="150" SortExpression="1">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemarks" runat="server" Text='' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>


               
                </div>
                <div id="lobipanel">
                    <div class="container">

                        <div id="lobipanel-examples">

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="bs-example">
                                    <div id="lobipanel-basic" class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                               Undertaking Students
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <figure class="highcharts-figure">
                                                <div id="container"></div>

                                            </figure>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-4 col-xs-12">
                                <div class="bs-example">
                                    <div id="lobipanel-basic" class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                Bifrucated Student (Class Wise)
                               <%--       <select class="col-lg-3 col-md-3 pull-right form-control graphtxtbox">
                                    <option value="1">Class 8</option>
                                     <option value="2">Class 9</option>
                                     <option value="3">Class 10</option>
                                </select>--%>

                                                <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist col-lg-3 col-md-3 pull-right form-control graphtxtbox schoolchange">
                                                </asp:DropDownList>


                                            </div>
                                        </div>
                                        <div class="panel-body">


                                            <figure class="highcharts-Subjectwise">
                                                <div id="container_highcharts-Subjectwise"></div>

                                            </figure>
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </div>
                    </div>
                </div>



                <!--Default installation-->

                <script src="../Styles/iep_dashboardfile/jquery.1.11.min.js"></script>
                <script src="../Styles/iep_dashboardfile/jquery-ui.min.js"></script>
                <script src="../Styles/iep_dashboardfile/jquery.ui.touch-punch.min.js"></script>
                <script src="../Styles/iep_dashboardfile/bootstrap.min.js"></script>

                <!--Installation using bower. Preferred!!! -->
                <!--<script src="bower_components/jquery/dist/jquery.min.js"></script>-->
                <!--<script src="bower_components/jquery-ui/jquery-ui.min.js"></script>-->
                <!--<script src="bower_components/jquery-ui-touch-punch-improved/jquery.ui.touch-punch-improved.js"></script>-->
                <!--<script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>-->

                <script src="../Styles/lobipanel.js"></script>

                <!-- <script src="lib/highlight/highlight.pack.js"></script> -->
                <script src="https://code.highcharts.com/highcharts.js"></script>
                <script src="https://code.highcharts.com/modules/data.js"></script>
                <script src="https://code.highcharts.com/modules/drilldown.js"></script>
                <script src="https://code.highcharts.com/modules/exporting.js"></script>
                <script src="https://code.highcharts.com/modules/export-data.js"></script>
                <script src="https://code.highcharts.com/modules/accessibility.js"></script>
                <script>
                    $(document).ready(function () {


                        $('table.datatable').DataTable({
                            destroy: true,
                            "dom": 'Blfrtip',

                            buttons: [

                                {
                                    extend: 'excel',
                                    title: 'Student Data '
                                }
                            ],
                            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                        });




                        //    $('#lobipanel-basic')
                        //            .on('beforeUnpin.lobiPanel', function () {
                        //                console.log("beforeClose");
                        //            })
                        //            .on('onClose.lobiPanel', function () {
                        //                console.log("onClose");
                        //            })
                        //            .on('onTitleChange.lobiPanel', function () {
                        //                console.log(this, arguments);

                        //            })
                        //            .lobiPanel();


                        //});
                        // Data retrieved from https://netmarketshare.com

                        /**FOUR BOXES */
                        $.ajax({
                            type: "POST",
                            url: "IEP_Dashboard.aspx/grap2",
                            data: {},
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                var tab = JSON.parse(result.d)
                                var fourboxes = tab.tab1;
                                console.log(fourboxes[0]);
                                var abv60 = fourboxes[0].Above60;
                                var blw60 = fourboxes[0].Below60;
                                var bifr = fourboxes[0].Bifurcated;
                                var undr = fourboxes[0].Undertaking;

                                $(".total_bifr").text(bifr);
                                $(".total_under").text(undr);
                                $(".total_above").text(abv60);
                                $(".total_below").text(blw60);
                            }
                        });
                        /**FOUR BOXES */
                        var alreadyt = "";
                        var Student_array = [];
                        Student_array.length = 0;
                        var datademo = [];
                        datademo.length = 0;
                        var phase1 = [];
                        phase1.length = 0;
                        //var datas=[{"Center":"C004-(TCS) Ravi Campus LHR","name":"Class 11 (O Level)","y":1}];
                        //var drillphase1 = [];
                        //var drillphase2 = [];
                        /**Ajax */
                        $.ajax({
                            type: "POST",
                            url: "IEP_Dashboard.aspx/grap",
                            data: {},
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                var tab = JSON.parse(result.d)
                                var drillphase1 = tab.tab1;
                                var drillphase2 = tab.tab2;
                                console.log("Tab1" + JSON.stringify(drillphase1));
                                console.log("Tab2" + JSON.stringify(drillphase2));


                                //var drillphase1 = [{ "name": "C001-(TCS) DHA Campus LHR", "y": 3, "drilldown": 40107001 }, { "name": "C004-(TCS) Ravi Campus LHR", "Y": 1, "drilldown": 40106001 }]
                                //var drillphase2 = [{ "Class_Name": "Class 10 (O Level)", "Y": 1, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }, { "Class_Name": "Class 11 (O Level)", "Y": 1, "name": "C004-(TCS) Ravi Campus LHR", "Center_Id": 40106001 }, { "Class_Name": "Class 8", "Y": 1, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }, { "Class_Name": "Class 9 (O Level)", "Y": 2, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }];

                                $.each(drillphase1, function (i, item) {
                                    phase1.push({
                                        name: drillphase1[i].name,
                                        y: drillphase1[i].Y,

                                        drilldown: drillphase1[i].Center_Id
                                    })
                                });



                                $.each(drillphase2, function (i, item) {
                                    // alert(drillphase2[i].Center);

                                    /***SAME CENTER CHILD**/
                                    if (alreadyt != drillphase2[i].Center_Id) {
                                        /**FIRST tIME USER**/
                                        if (alreadyt == "") {
                                            Student_array.push(
                                                [
                                                    drillphase2[i].Class_Name,
                                                    drillphase2[i].Y
                                                ]
                                            );

                                            datademo.push({

                                                name: drillphase2[i].Center_Id,
                                                id: drillphase2[i].Center_Id,

                                                data: Student_array

                                            });
                                            alreadyt = drillphase2[i].Center_Id;
                                        }
                                        /**FIRST tIME USER**/

                                        else {
                                            Student_array = [];
                                            Student_array.push(
                                                [
                                                    drillphase2[i].Class_Name,
                                                    drillphase2[i].Y
                                                ]
                                            );

                                            datademo.push({

                                                name: drillphase2[i].Center_Id,
                                                id: drillphase2[i].Center_Id,

                                                data: Student_array
                                            });
                                            alreadyt = drillphase2[i].Center_Id;
                                        }
                                    }
                                    else {
                                        Student_array.push(
                                            [
                                                drillphase2[i].Class_Name,
                                                drillphase2[i].Y
                                            ]
                                        );
                                    }
                                    /**SAME CNETR CHILD**/

                                });
                                console.log("datademo" + JSON.stringify(datademo));
                                // Create the chart
                                Highcharts.chart('container', {
                                    chart: {
                                        type: 'column'
                                    },
                                    title: {
                                        align: 'left',
                                        text: 'Bifrucated Student'
                                    },
                                    subtitle: {
                                        align: 'left',
                                        text: ''
                                    },
                                    accessibility: {
                                        announceNewData: {
                                            enabled: true
                                        }
                                    },
                                    xAxis: {
                                        type: 'category'
                                    },
                                    yAxis: {
                                        title: {
                                            text: 'Total Bifrucated Student(Center)'
                                        }

                                    },
                                    legend: {
                                        enabled: false
                                    },
                                    plotOptions: {
                                        series: {
                                            borderWidth: 0,
                                            dataLabels: {
                                                enabled: true,
                                                format: '{point.y}'
                                            }
                                        }
                                    },

                                    tooltip: {
                                        headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                                        pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> of total<br/>'
                                    },

                                    series: [
                                        {
                                            name: "Centers",
                                            colorByPoint: true,
                                            data: phase1
                                        }
                                    ],





                                    drilldown: {
                                        breadcrumbs: {
                                            position: {
                                                align: 'right'
                                            }
                                        },
                                        series: datademo

                                    }
                                });

                            }
                        });
                        /**ajax */

                        // Tab1[{ "name": "C001-(TCS) DHA Campus LHR", "Y": 3, "Center_Id": 40107001 }, { "name": "C004-(TCS) Ravi Campus LHR", "Y": 1, "Center_Id": 40106001 }]
                        // Tab2[{ "Class_Name": "Class 10 (O Level)", "Y": 1, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }, { "Class_Name": "Class 11 (O Level)", "Y": 1, "name": "C004-(TCS) Ravi Campus LHR", "Center_Id": 40106001 }, { "Class_Name": "Class 8", "Y": 1, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }, { "Class_Name": "Class 9 (O Level)", "Y": 2, "name": "C001-(TCS) DHA Campus LHR", "Center_Id": 40107001 }]


                        /***SCHOOL CHNAGE**/
                        /**studentname */
                        var alreadyt2 = "";
                        var Student_array2 = [];
                        Student_array2.length = 0;
                        var datademo2 = [];
                        datademo2.length = 0;
                        var phase2 = [];
                        phase2.length = 0;
                        /**studentname */
                        /**subject wise */
                        var alreadytsub2 = "";
                        var Studentsub_array2 = [];
                        Studentsub_array2.length = 0;
                        var overall_array2 = [];
                        overall_array2.length = 0;
                        var datademosub2 = [];
                        datademosub2.length = 0;
                        var phasesub2 = [];
                        phasesub2.length = 0;
                        /**subject wise */

                        /**overall wise */

                        /**overall wise */
                        $(".schoolchange").change(function () {
                            /**studentname */
                            alreadyt2 = "";
                            Student_array2 = [];
                            Student_array2.length = 0;
                            datademo2 = [];
                            datademo2.length = 0;
                            phase2 = [];
                            phase2.length = 0;
                            /**studentname */
                            /**subject wise */
                            alreadytsub2 = "";
                            Studentsub_array2 = [];
                            Studentsub_array2.length = 0;
                            overall_array2 = [];
                            overall_array2.length = 0;
                            datademosub2 = [];
                            datademosub2.length = 0;
                            phasesub2 = [];
                            phasesub2.length = 0;
                            /**subject wise */

                            /**overall wise */
                            alreadytover = "";
                            Studentover_array = [];
                            Studentover_array.length = 0;
                            datademoover = [];
                            datademoover.length = 0;
                            phaseover = [];
                            phaseover.length = 0;
                            /**overall wise */

                            var current_school = $(this).val();
                            //current_school=parseInt(current_school);
                            $(".labcentervalue").text(current_school);

                            $.ajax({
                                type: "POST",
                                url: "IEP_Dashboard.aspx/grap3",
                                data: '{schoolname:' + current_school + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (result) {
                                    var tabschool = JSON.parse(result.d);
                                    var drillphaseschool = tabschool.tab1;
                                    console.log("drillphaseschool" + JSON.stringify(drillphaseschool));
                                    /**Student name**/
                                    $.each(drillphaseschool, function (i, item) {
                                        // alert(drillphase2[i].Center);

                                        /***SAME CENTER CHILD**/
                                        if (alreadyt2 != drillphaseschool[i].Student_Id) {
                                            /**FIRST tIME USER**/
                                            if (alreadyt2 == "") {
                                                Student_array2.push(
                                                    [
                                                        drillphaseschool[i].StudentName
                                                    ]
                                                );


                                                alreadyt2 = drillphaseschool[i].Student_Id;
                                            }
                                            /**FIRST tIME USER**/

                                            else {
                                                //Student_array2 = [];
                                                Student_array2.push(
                                                    [
                                                        drillphaseschool[i].StudentName
                                                    ]
                                                );

                                                alreadyt2 = drillphaseschool[i].Student_Id;
                                            }
                                        }
                                        //else {
                                        //    Student_array2.push(
                                        //        [
                                        //            drillphaseschool[i].StudentName
                                        //        ]
                                        //    );
                                        //}
                                        /**SAME CNETR CHILD**/



                                    });
                                    /**Student name**/

                                    /**Overall Percentage**/

                                    /**Overall Percentage**/

                                    /***subject wise data**/
                                    $.each(drillphaseschool, function (i, item) {
                                        if (alreadytsub2 != drillphaseschool[i].Subject_Id) {
                                            /**FIRST tIME USER**/
                                            if (alreadytsub2 == "") {
                                                Studentsub_array2.push(

                                                    drillphaseschool[i].Marks

                                                );

                                                overall_array2.push(
                                                    drillphaseschool[i].Overall_P
                                                )

                                                datademosub2.push({

                                                    name: drillphaseschool[i].Subject_Name,


                                                    data: Studentsub_array2

                                                });
                                                alreadytsub2 = drillphaseschool[i].Subject_Id;
                                            }
                                            /**FIRST tIME USER**/

                                            else {
                                                Studentsub_array2 = [];
                                                overall_array2 = [];
                                                Studentsub_array2.push(

                                                    drillphaseschool[i].Marks

                                                );

                                                overall_array2.push(
                                                    drillphaseschool[i].Overall_P
                                                )

                                                datademosub2.push({

                                                    name: drillphaseschool[i].Subject_Name,


                                                    data: Studentsub_array2

                                                });
                                                alreadytsub2 = drillphaseschool[i].Subject_Id;
                                            }
                                        }
                                        else {
                                            Studentsub_array2.push(

                                                drillphaseschool[i].Marks

                                            );

                                            overall_array2.push(
                                                drillphaseschool[i].Overall_P
                                            )
                                        }
                                    });

                                    datademosub2.push({

                                        name: "Overall",


                                        data: overall_array2

                                    });
                                    /***subject wise data**/


                                    console.log("   Studentsub_array2" + JSON.stringify(datademosub2));
                                    /***SUBJECT WISE***/
                                    Highcharts.chart('container_highcharts-Subjectwise', {
                                        chart: {
                                            type: 'column'
                                        },
                                        title: {
                                            text: 'Subject Wise'
                                        },
                                        subtitle: {
                                            text: ''
                                        },
                                        xAxis: {
                                            //categories: [
                                            //    'Raja',
                                            //    'Parvaiz',
                                            //    'Fahad',
                                            //    'Rameez'
                                            //],
                                            categories: Student_array2,
                                            crosshair: true
                                        },
                                        yAxis: {
                                            min: 0,
                                            title: {
                                                text: 'Subject Wise (Marks)'
                                            }
                                        },
                                        tooltip: {
                                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                                '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                                            footerFormat: '</table>',
                                            shared: true,
                                            useHTML: true
                                        },
                                        plotOptions: {
                                            column: {
                                                pointPadding: 0.2,
                                                borderWidth: 0
                                            }
                                        },
                                        series: datademosub2
                                        //series: [{
                                        //    name: 'English',
                                        //    data: [49.9]

                                        //}, {
                                        //    name: 'Urdu',
                                        //    data: [83.6]

                                        //    }, {
                                        //        name: 'Mathematics',
                                        //        data: [83.6]

                                        //    }, {
                                        //        name: 'Science',
                                        //        data: [83.6]

                                        //    }]

                                    });
                                    /***SUBJECT WISE**/
                                },
                                error: function (request, status, error) {
                                    alert(request.responseText);
                                }


                            });

                        });
                        $(".schoolchange").val($(".schoolchange option:nth-child(2)").val());
                        $(".schoolchange").change();
                        /***SCHOOL CHNAGE**/






                        /**3LAYER DRILLDOWN***/


                        // Create the chart
                        //var drillphase_layerwise1 = [{ "name": "C004-(TCS) Ravi Campus LHR", "y": 1, "drilldown": "C005" }];
                        //$('#threelayer').highcharts({
                        //    chart: {
                        //        type: 'column'
                        //    },
                        //    title: {
                        //        text: 'Basic drilldown'
                        //    },
                        //    xAxis: {
                        //        type: 'category'
                        //    },

                        //    legend: {
                        //        enabled: false
                        //    },

                        //    plotOptions: {
                        //        series: {
                        //            borderWidth: 0,
                        //            dataLabels: {
                        //                enabled: true,
                        //            }
                        //        }
                        //    },

                        //    series: [{
                        //        name: 'Things',
                        //        colorByPoint: true,
                        //        data: drillphase_layerwise1
                        //    }],
                        //    drilldown: {
                        //        series: [{
                        //            id: 'animals',
                        //            data: [
                        //                ['Cats', 4, 'animals2'],
                        //                ['Dogs', 2, 'fruits2'],
                        //            ],
                        //            keys: ['name', 'y', 'drilldown']
                        //        }, {
                        //            id: 'animals2',
                        //            data: [
                        //                ['Cats', 4],
                        //                ['Dogs', 2],
                        //                ['Cows', 1],
                        //                ['Sheep', 2],
                        //                ['Horse', 1]
                        //            ]
                        //        }, {
                        //            id: 'fruits2',
                        //            data: [
                        //                ['Apples', 4],
                        //                ['Oranges', 2]
                        //            ]
                        //        }]
                        //    }
                        //})


                        /**3 LAYER DRILLDOWN**/
                    });
                </script>
        </body>
        <style>
            .highcharts-figure,
            .highcharts-data-table table {
                min-width: 320px;
                max-width: 800px;
                margin: 1em auto;
            }

            .highcharts-data-table table {
                font-family: Verdana, sans-serif;
                border-collapse: collapse;
                border: 1px solid #ebebeb;
                margin: 10px auto;
                text-align: center;
                width: 100%;
                max-width: 500px;
            }

            .highcharts-data-table caption {
                padding: 1em 0;
                font-size: 1.2em;
                color: #555;
            }

            .highcharts-data-table th {
                font-weight: 600;
                padding: 0.5em;
            }

            .highcharts-data-table td,
            .highcharts-data-table th,
            .highcharts-data-table caption {
                padding: 0.5em;
            }

            .highcharts-data-table thead tr,
            .highcharts-data-table tr:nth-child(even) {
                background: #f8f8f8;
            }

            .highcharts-data-table tr:hover {
                /*background: #f1f7ff;*/
            }

            input[type="number"] {
                min-width: 50px;
            }

            .highcharts-title {
                visibility: hidden;
            }

            .graphtxtbox {
                width: auto;
                height: auto;
                padding: 1px;
                line-height: 0px !important;
                font-size: 12px;
            }

            /**four boxes*/
            .c-dashboardInfo {
                margin-bottom: 15px;
            }

                .c-dashboardInfo .wrap {
                    background: #ffffff;
                    box-shadow: 2px 10px 20px rgba(0, 0, 0, 0.1);
                    border-radius: 7px;
                    text-align: center;
                    position: relative;
                    overflow: hidden;
                    padding:27px 20px 25px 20px;
                    height: 100%;
                }

            .c-dashboardInfo__title,
            .c-dashboardInfo__subInfo {
                color: #6c6c6c;
                font-size: 1.18em;
            }

            .c-dashboardInfo span {
                display: block;
                text-align: center;
            }

            .c-dashboardInfo__count {
                font-weight: 600;
                font-size: 2.5em;
                /*line-height: 64px;*/
                color: #323c43;
            }

            .c-dashboardInfo .wrap:after {
                display: block;
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 10px;
                content: "";
            }

            .c-dashboardInfo:nth-child(1) .wrap:after {
                background: linear-gradient(82.59deg, #00c48c 0%, #00a173 100%);
            }

            .c-dashboardInfo:nth-child(2) .wrap:after {
                background: linear-gradient(81.67deg, #0084f4 0%, #1a4da2 100%);
            }

            .c-dashboardInfo:nth-child(3) .wrap:after {
                background: linear-gradient(69.83deg, #0084f4 0%, #00c48c 100%);
            }

            .c-dashboardInfo:nth-child(4) .wrap:after {
                background: linear-gradient(81.67deg, #ff647c 0%, #1f5dc5 100%);
            }

            .c-dashboardInfo__title svg {
                color: #d7d7d7;
                margin-left: 5px;
            }

            .MuiSvgIcon-root-19 {
                fill: currentColor;
                width: 1em;
                height: 1em;
                display: inline-block;
                font-size: 24px;
                transition: fill 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
                user-select: none;
                flex-shrink: 0;
            }

            .margintp {
                margin-top: 10px !important;
            }

            .panel-heading {
                background: #0c4da2 !important;
                color: #fff !important;
                /* border: 1px solid; */
                border-radius: 6px 6px 0px 0px;
            }

            .panel-default {
                border-radius: 9px !important;
            }

            .c-dashboardInfo__title {
                font-size: 20px !important;
            }

            .highcharts-credits {
                display: none !important;
            }
            /**four boxes*/
            .highcharts-figure {
            margin-top:0px !important;
            }
        </style>
        </html>
    </contenttemplate>

</asp:Content>
