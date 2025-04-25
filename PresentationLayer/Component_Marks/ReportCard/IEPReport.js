    

        var pathname = window.location.pathname; // Returns path only (/path/example.html)
        let pathnamess = pathname;
        const patharray = pathnamess.split("/");
        console.log(patharray[2]);

if (patharray[2] == "IEP_Reports.aspx")
{
            var cen_Id = centerIep;
var ssid = ssid_Iep;
var teacherid = teacherid_Iep;
        





            $(".ieppendingstudent").click(function () {
                var bipending = "";
                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    dataType: 'json',
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                   //url: 'http://localhost:52673/api/Setup/SP_BifurcationPendingStudent',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_BifurcationPendingStudent',
                    success: function (result) {
                        //console.log("PendingStudent" + JSON.stringify(result));
                        if (result == "" || result == " " || result == null) {
                            bipending += "<table class='table'>";
                            bipending += "<thead>";
                            bipending += "<tr>";
                            bipending += "<th>Id</th><th>Student</th><th>Class</th>";
                            bipending += "</tr>";
                            bipending += "</thead>";
                            bipending += "<tbody>";

                            bipending += "<tr>";
                            bipending += "<td colspan='3' style='text-align:center'>No Data Found</td>";
                            bipending += "</tr>";

                            bipending += "</tbody>";
                            bipending += "</table>";

                            $(".IEPModel .modal-body").html(bipending);
                            $('#IEPModel').modal('show');
                        }
                        else {
                            bipending += "<table class='table'>";
                            bipending += "<thead>";
                            bipending += "<tr>";
                            bipending += "<th>Id</th><th>Student</th><th>Class</th>";
                            bipending += "</tr>";
                            bipending += "</thead>";
                            bipending += "<tbody>";
                            for (var bi = 0; bi < result.length; bi++) {
                                bipending += "<tr>";
                                var biclass_names = "";
                                if (result[bi].ClassID == 12) { biclass_names = "Class 8" }
                                bipending += "<td>" + result[bi].StudentID + "</td><td>" + result[bi].StudentName + "</td><td>" + biclass_names + "</td>";
                                bipending += "</tr>";
                            }
                            bipending += "</tbody>";
                            bipending += "</table>";

                            $(".IEPModel .modal-body").html(bipending);

                            $('#IEPModel').modal('show');
                        }
                    }
                });
            });

            /**ON PAGE LOAD active li***/
            $(".classtab li.active").attr('data-id');
            $(".classnameofcurrent").val($(".classtab li.active").attr('data-id'));
            $(".classidofcurrent").val($(".classtab li.active").attr('data-value'));

            $(".classval").val($(".classtab li.active").attr('data-id'));
            var currid = $(".classtab li.active").attr('data-title');



            //var Class_Id = $(this).attr('data-value');
            var Class_Id = $(".classtab li.active").attr('data-value');//.data().value;
            var Student_list = "";
            $(".overlay").show();
            if (teacherid == null || teacherid == "" || teacherid == " ") {
                //$.ajax({
                //    type: 'GET',
                //    data: { Center_Id: cen_Id, Class_Id: Class_Id },
                //    url: 'http://localhost:52673/api/Setup/GetStudentByCenterandclasswise',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                var centeraction = 100;
                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    dataType: 'json',
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                    data: { P_Employee_Id: 0, P_Action: centeraction, P_ClassID: Class_Id, P_StudentID: 0, P_SessionID: ssid, P_CenterID: 40106001 },
                   // url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData_teacherwise',
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData_teacherwise',
                    success: function (result) {
                        //console.log(JSON.stringify(result));
                        Student_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                        for (var i = 0; i < result.length; i++) {
                            Student_list += '<option value="' + result[i].Student_Id + '" data-id="' + result[i].Student_Email + '" data-value="' + result[i].PrimaryContactNo + '">' + result[i].Student_Id + "-" + result[i].fullname + '</option>';
                        }
                        $("#" + currid + " .name").html(Student_list);

                    },
                    complete: function (result) {

                        $(".overlay").hide();
                    },
                    error: function (err) {

                        //console.log(JSON.stringify(err));

                    }
                });
            }
            else {
                var teacheraction = 1001;
                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    dataType: 'json',
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                    data: { P_Employee_Id: teacherid, P_Action: teacheraction, P_ClassID: Class_Id, P_StudentID: 0, P_SessionID: ssid, P_CenterID: 0 },
                    //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData_teacherwise',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData_teacherwise',
                    success: function (result) {
                        //console.log(JSON.stringify(result));
                        Student_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                        for (var i = 0; i < result.length; i++) {
                            Student_list += '<option value="' + result[i].Student_Id + '" data-id="' + result[i].Student_Email + '" data-value="' + result[i].PrimaryContactNo + '">' + result[i].Student_Id + "-" + result[i].fullname + '</option>';
                        }
                        $("#" + currid + " .name").html(Student_list);

                    },
                    complete: function (result) {

                        $(".overlay").hide();
                    },
                    error: function (err) {

                        //console.log(JSON.stringify(err));

                    }
                });
            }
            /***ON PAGE LOAD active li***/

            $(".classtab li").click(function () {

                /**checkbox check for print***/
                var index = $(this).index();

                $(".printwalecheckbox input").removeAttr('checked');
                //$(".printwalecheckbox input:nth-child('" +index+"')").setAttribute("checked", "checked");//.attr('checked', true);
                //.setAttribute("checked", "checked");

                $(".printwalecheckbox").children("input[type='checkbox']:eq(" + index + ")").prop("checked", true);//'"+index +"'
                /**checkbox check for print***/
                //alert($(this).attr('data-id') + "---" + $(this).attr('data-value'));
                $(".classnameofcurrent").val($(this).attr('data-id'));
                $(".classidofcurrent").val($(this).attr('data-value'));
                $(".rollno").val("");
                $(".classval").val($(this).attr('data-id'));
                var currid = $(this).attr('data-title');



                //var Class_Id = $(this).attr('data-value');
                var Class_Id = $(this).data().value;
                var Student_list = "";
                $(".overlay").show();
                if (teacherid == null || teacherid == "" || teacherid == " ") {
                    $.ajax({
                        type: 'GET',
                        crossDomain: true,
                        dataType: 'json',
                        headers: {
                            'accept': 'application/json',
                            'Access-Control-Allow-Origin': '*'
                        },
                        data: { Center_Id: cen_Id, Class_Id: Class_Id },
                        //url: 'http://localhost:52673/api/Setup/GetStudentByCenterandclasswise',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                        url: 'http://iepapi.csn.edu.pk:8111/api/Setup/GetStudentByCenterandclasswise',
                        success: function (result) {
                           // console.log(JSON.stringify(result));
                            Student_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                            for (var i = 0; i < result.length; i++) {
                                Student_list += '<option value="' + result[i].Student_Id + '" data-id="' + result[i].Student_Email + '" data-value="' + result[i].PrimaryContactNo + '">' + result[i].Student_Id + "-" + result[i].fullname + '</option>';
                            }
                            $("#" + currid + " .name").html(Student_list);

                        },
                        complete: function (result) {

                            $(".overlay").hide();
                        },
                        error: function (err) {

                            //console.log(JSON.stringify(err));

                        }
                    });

                }
                else {
                    var teacheraction = 1001;
                    $.ajax({
                        type: 'GET',
                        crossDomain: true,
                        dataType: 'json',
                        headers: {
                            'accept': 'application/json',
                            'Access-Control-Allow-Origin': '*'
                        },
                        data: { P_Employee_Id: teacherid, P_Action: teacheraction, P_ClassID: Class_Id, P_StudentID: 0, P_SessionID: ssid, P_CenterID: 0 },
                        //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData_teacherwise',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                        url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData_teacherwise',
                        success: function (result) {
                            //console.log(JSON.stringify(result));
                            Student_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                            for (var i = 0; i < result.length; i++) {
                                Student_list += '<option value="' + result[i].Student_Id + '" data-id="' + result[i].Student_Email + '" data-value="' + result[i].PrimaryContactNo + '">' + result[i].Student_Id + "-" + result[i].fullname + '</option>';
                            }
                            $("#" + currid + " .name").html(Student_list);

                        },
                        complete: function (result) {

                            $(".overlay").hide();
                        },
                        error: function (err) {

                            //console.log(JSON.stringify(err));

                        }
                    });

                }
                /**AUTOComplete */
                //var student_lista = [];
                //student_lista.length = 0;
                //$.ajax({
                //    type: 'GET',

                //    url: 'http://localhost:52673/api/Setup/GetStudentByCenterandclasswise',
                //    async: false,
                //    dataType: "json",
                //    data: { Center_Id: 2010201, Class_Id: Class_Id },

                //    success: function (result) {

                //        // student_lista = JSON.stringify(result);
                //        for (var tuu = 0; tuu < result.length; tuu++) {

                //            student_lista.push({
                //                value: result[tuu].Student_Id + "-" + result[tuu].fullname,
                //                label: result[tuu].Student_Id + "-" + result[tuu].fullname,
                //                id: result[tuu].Student_Id
                //            });

                //            // }

                //        }
                //    }
                //});

                //$("#" + currid + " .name").autocomplete({
                //    minLength: 3,
                //    source: student_lista,
                //    focus: function (event, ui) {
                //        $("#" + currid + " .name").val(ui.item.label);
                //        return false;
                //    },
                //    select: function (event, ui) {
                //        //$( "#topics" ).val( ui.item.label );
                //        //$("#stuID").val(ui.item.id);
                //        //$( "#results").text($("#topicID").val());    
                //        return false;
                //    }
                //})
                /**AUTOCOMPLETE */


                var Subject_list = "";
                var Subject_heading = "<th>Key value</th><th>Key Area</th>";
                var Subject_td = "";
                var teachersubject = "";
                $(".overlay").show();
                var classcond = $(this).attr('data-id');
                //if (classcond == 8 || classcond == 9) {
                //    $.ajax({
                //        type: 'GET',
                //        data: { OrgId: 1, Class_Id: Class_Id },
                //        url: 'http://localhost:52673/api/Setup/Class_SubjectSelectAllByClassId',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                //        success: function (result) {


                //            for (var i = 0; i < result.length; i++) {
                //                var ser = i + 1;
                //                Subject_list += '<tr>';

                //                Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + Class_Id+'"/></td>';

                //                    Subject_list += '</tr>';

                //                Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" +"Class-"+ classcond+ '</th>';
                //                Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + Class_Id + '"></td>';

                //            }
                //            $("#" + currid + " .academic_history tbody").html(Subject_list);

                //            /*****TEACHER FEEBACK***/

                //            teachersubject += '<table class="table table-bordered custom_table_styling">';
                //            teachersubject += '<thead>';
                //            teachersubject += '<tr>' + Subject_heading + '</tr>';

                //            teachersubject += '</thead>';
                //            teachersubject += '<tbody>';




                //            teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                //            teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                //            teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                //            teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                //            teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                //            teachersubject += '</tbody>';
                //            teachersubject += '</table>';
                //            /***TEACHER FEEDBACK***/
                //            $("#" + currid + " .teacherfeedbacktable").html(teachersubject);
                //        },
                //        complete: function (result) {

                //            $(".overlay").hide();
                //        },
                //        error: function (err) {

                //            //console.log(JSON.stringify(err));

                //        }
                //    });
                //}
                //if (classcond == 10) {


                //    var classcond_Id = "";
                //    var clas_id_8 = classcond - 2;
                //    if (clas_id_8 == 8) {
                //        classcond_Id = 12;
                //    }

                //        Subject_list = "";


                //           $.ajax({
                //                type: 'GET',

                //               data: { OrgId: 1, Class_Id: classcond_Id },
                //               async:false,
                //                url: 'http://localhost:52673/api/Setup/Class_SubjectSelectAllByClassId',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                //                success: function (result) {


                //                    for (var i = 0; i < result.length; i++) {
                //                        var ser = i + 1;
                //                        Subject_list += '<tr>';
                //                        Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id +'"/></td>';
                //                        Subject_list += '</tr>';

                //                        Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + "Class-" +clas_id_8+'</th>';
                //                        Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                //                    }
                //                    $("#" + currid + " .academic_history1 tbody").html(Subject_list);
                //        //            loadNext();

                //                },
                //                complete: function (result) {

                //                    $(".overlay").hide();
                //                },
                //                error: function (err) {

                //                    //console.log(JSON.stringify(err));

                //                }
                //            });


                //    var clas_id_9 = classcond - 1;
                //    if (clas_id_9 == 9) {
                //        classcond_Id = 13;
                //    }
                //    Subject_list = "";


                //    $.ajax({
                //        type: 'GET',
                //        async: false,
                //        data: { OrgId: 1, Class_Id: classcond_Id },
                //        url: 'http://localhost:52673/api/Setup/Class_SubjectSelectAllByClassId',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                //        success: function (result) {


                //            for (var i = 0; i < result.length; i++) {
                //                var ser = i + 1;
                //                Subject_list += '<tr>';
                //                Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id  +'"/></td>';
                //                Subject_list += '</tr>';

                //                Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + "Class-" + clas_id_9 +'</th>';
                //                Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                //            }
                //            $("#" + currid + " .academic_history2 tbody").html(Subject_list);
                //            //            loadNext();

                //        },
                //        complete: function (result) {

                //            $(".overlay").hide();
                //        },
                //        error: function (err) {

                //            //console.log(JSON.stringify(err));

                //        }
                //    });



                //    /*****TEACHER FEEBACK***/

                //    teachersubject += '<table class="table table-bordered custom_table_styling">';
                //    teachersubject += '<thead>';
                //    teachersubject += '<tr>' + Subject_heading + '</tr>';

                //    teachersubject += '</thead>';
                //    teachersubject += '<tbody>';




                //    teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                //    teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                //    teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                //    teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                //    teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                //    teachersubject += '</tbody>';
                //    teachersubject += '</table>';
                //    /***TEACHER FEEDBACK***/
                //    $("#" + currid + " .teacherfeedbacktable").html(teachersubject);

                //}
            });
            var ID = "";
            $(".name").change(function () {
                var cureparent = $(this).parent().parent().parent().parent().parent().parent(".tab-pane").attr('id');
                var rollval = $(this).val();
                var currid = $(".classtab li.active").attr('data-title');
                var currclassid = $(".classtab li.active").attr('data-value');
                var currclassname = $(".classtab li.active").attr('data-id');
                /***FOR EDIT***/

                var Subject_list = "";
                var Subject_heading = "<th>Key value</th><th>Key Area</th>";
                var Subject_td = "";
                var teachersubject = "";

                var alreadyteacher = "";

                var teachereditarray = [];
                teachereditarray.length = 0;
                var teachersubeditarray = [];
                teachersubeditarray.length = 0;
                var emaol = $(this).find(':selected').data('id');//find(':selected')
                var con = $(this).find(':selected').data('value');

                var activitiestable = "";
                var communitiestable = "";

                $(".overlay").show();
                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    dataType: 'json',
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                    data: { studentrollno: rollval },
                    //url: 'http://localhost:52673/api/Setup/FetchIEPDATAall',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/FetchIEPDATAall',
                    success: function (result) {

                        //console.log("EDIT DATA " + JSON.stringify(result));

                        if (result == null || result == "" || result == " ") {

                            $("#" + cureparent + " input").val("");
                            $("#" + cureparent + " text").val("");
                            $("#" + cureparent + " textarea").val("");
                            ID = "";
                            $("#" + cureparent + " .rollno").val(rollval);
                            $("#" + cureparent + " .contactno").val(con);
                            $("#" + cureparent + " .emailaddr").val(emaol);
                            $("#" + cureparent + " .classval").val($(".classnameofcurrent").val());

                            /***dynamilccity genarte table***/




                            if (currclassid == 12 || currclassid == 13) { //for class 8 and 9
                                $(".overlay").show();
                                var currclassname = $(".classtab li.active").attr('data-id');
                                if (teacherid == "" || teacherid == " " || teacherid == null) {
                                    teacherid = 0;
                                }
                                else {
                                    teacherid = teacherid;
                                }
                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: currclassname, P_ClassID: currclassid, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData',
                                    success: function (result) {
                                        //console.log("result" + JSON.stringify(result));

                                        var ccid = currclassid - 1;
                                        if (result == null || result == "") {
                                           
                                            Swal.fire(
                                                'No Academic History!',
                                                '',
                                                'error'
                                            )
                                        }
                                        else {
                                            for (var i = 0; i < result.length; i++) {




                                                var ser = i + 1;
                                                Subject_list += '<tr>';

                                                Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + result[i].Course_Work + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + ccid + '" value="' + result[i].Grade + '" disabled/></td>';

                                                Subject_list += '</tr>';

                                                Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + '</th>';
                                                Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + ccid + '"></td>';

                                            }


                                            $("#" + currid + " .academic_history tbody").html(Subject_list);

                                            /*****TEACHER FEEBACK***/

                                            teachersubject += '<table class="table table-bordered custom_table_styling">';
                                            teachersubject += '<thead>';
                                            teachersubject += '<tr>' + Subject_heading + '</tr>';

                                            teachersubject += '</thead>';
                                            teachersubject += '<tbody>';




                                            teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                                            teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                                            teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                                            teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                                            teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                                            teachersubject += '</tbody>';
                                            teachersubject += '</table>';
                                            /***TEACHER FEEDBACK***/
                                            $("#" + currid + " .teacherfeedbacktable").html(teachersubject);
                                        }





                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });
                            }

                            if (currclassid == 14) {

                                var currclassname = $(".classtab li.active").attr('data-id');
                                if (teacherid == "" || teacherid == " " || teacherid == null) {
                                    teacherid = 0;
                                }
                                else {
                                    teacherid = teacherid;
                                }
                                var classcond_Id = "";
                                var clas_id_8 = currclassname - 2;
                                var forclass10_8action = 102;
                                if (clas_id_8 == 8) {
                                    classcond_Id = 12;
                                    currclassname = 8;
                                }

                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass10_8action, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';

                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + result[i].Course_Work + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + "Class-" + clas_id_8 + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                                        }
                                        $("#" + currid + " .academic_history1 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });

                                var currclassname = $(".classtab li.active").attr('data-id');
                                var forclass10_9action = 103;
                                var clas_id_9 = currclassname - 1;
                                if (clas_id_9 == 9) {
                                    classcond_Id = 13;
                                    currclassname = 9;
                                }
                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass10_9action, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';


                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + result[i].Course_Work + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + "Class-" + clas_id_9 + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '" ></td>';

                                        }
                                        $("#" + currid + " .academic_history2 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });



                                /*****TEACHER FEEBACK***/

                                teachersubject += '<table class="table table-bordered custom_table_styling">';
                                teachersubject += '<thead>';
                                teachersubject += '<tr>' + Subject_heading + '</tr>';

                                teachersubject += '</thead>';
                                teachersubject += '<tbody>';




                                teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                                teachersubject += '</tbody>';
                                teachersubject += '</table>';
                                /***TEACHER FEEDBACK***/
                                $("#" + currid + " .teacherfeedbacktable").html(teachersubject);

                            }


                            if (currclassid == 15) {


                                var classcond_Id = "";

                                var currclassname = $(".classtab li.active").attr('data-id');
                                if (teacherid == "" || teacherid == " " || teacherid == null) {
                                    teacherid = 0;
                                }
                                else {
                                    teacherid = teacherid;
                                }
                                var forclass11_9action = 103;
                                var clas_id_9 = currclassname - 2;
                                if (clas_id_9 == 9) {
                                    classcond_Id = 13;
                                    currclassname = 9;
                                }
                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass11_9action, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/SP_FetchSubjectIEPData',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/SP_FetchSubjectIEPData',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';

                                            var cou = result[i].Course_Work == null ? "-" : result[i].Course_Work;
                                           
                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + cou+ '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + "Class-" + clas_id_9 + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '" ></td>';

                                        }
                                        $("#" + currid + " .academic_history1 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });


                                var classcond_Id = 11;

                                var currclassname = $(".classtab li.active").attr('data-id');
                                var forclass11_ciaeaction = 104;

                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass11_ciaeaction, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/CIAE_Result',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/CIAE_Result',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';
                                           var cou = result[i].Course_Work == null ? "-" : result[i].Course_Work;

                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + cou + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                                        }
                                        $("#" + currid + " .academic_history2 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });


                                /*****TEACHER FEEBACK***/

                                teachersubject += '<table class="table table-bordered custom_table_styling">';
                                teachersubject += '<thead>';
                                teachersubject += '<tr>' + Subject_heading + '</tr>';

                                teachersubject += '</thead>';
                                teachersubject += '<tbody>';




                                teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                                teachersubject += '</tbody>';
                                teachersubject += '</table>';
                                /***TEACHER FEEDBACK***/
                                $("#" + currid + " .teacherfeedbacktable").html(teachersubject);

                            }


                            if (currclassid == 20) {



                                var classcond_Id = 11;

                                var currclassname = $(".classtab li.active").attr('data-id');

                                if (teacherid == "" || teacherid == " " || teacherid == null) {
                                    teacherid = 0;
                                }
                                else {
                                    teacherid = teacherid;
                                }

                                var forclass11_ciaeaction = 105;

                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass11_ciaeaction, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/CIAE_Result',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/CIAE_Result',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';
                                            var cour = "";
                                            if (result[i].Course_Work == null) {
                                                cour = "-"
                                            }
                                            else {
                                                cour = result[i].Course_Work
                                            }

                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + cour + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                                        }
                                        $("#" + currid + " .academic_history1 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });


                                var classcond_Id = 11;

                                var currclassname = $(".classtab li.active").attr('data-id');
                                var forclass11_ciaeaction = 106;

                                Subject_list = "";


                                $.ajax({
                                    type: 'GET',
                                    crossDomain: true,
                                    dataType: 'json',
                                    headers: {
                                        'accept': 'application/json',
                                        'Access-Control-Allow-Origin': '*'
                                    },
                                    async: false,
                                    data: { P_Employee_Id: teacherid, P_Action: forclass11_ciaeaction, P_ClassID: classcond_Id, P_StudentID: rollval, P_SessionID: ssid, P_CenterID: 0 },
                                    //url: 'http://localhost:52673/api/Setup/CIAE_Result',//sURLVariableswithurl[0]+"?",//getsearchedpatient
                                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/CIAE_Result',
                                    success: function (result) {


                                        for (var i = 0; i < result.length; i++) {
                                            var ser = i + 1;
                                            Subject_list += '<tr>';
                                            var cour = "";
                                            if (result[i].Course_Work == null) {
                                                cour = "-"
                                            }
                                            else {
                                                cour = result[i].Course_Work
                                            }

                                            Subject_list += '<td>' + ser + '</td><td>' + result[i].Subject_Name + '</td><td>' + result[i].Subject_Id + '</td><td>' + cour + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value="' + classcond_Id + '" value="' + result[i].Grade + '" disabled/></td>';

                                            Subject_list += '</tr>';

                                            Subject_heading += '<th>' + result[i].Subject_Name + "--" + result[i].Subject_Id + "--" + '</th>';
                                            Subject_td += '<td class="subtds"><input type="text" class="teachersubjecttd form-control" data-id="' + result[i].Subject_Id + '" data-value="' + result[i].Subject_Name + '" data-name="' + classcond_Id + '"></td>';

                                        }
                                        $("#" + currid + " .academic_history2 tbody").html(Subject_list);
                                        //            loadNext();

                                    },
                                    complete: function (result) {

                                        $(".overlay").hide();
                                    },
                                    error: function (err) {

                                        //console.log(JSON.stringify(err));

                                    }
                                });


                                /*****TEACHER FEEBACK***/

                                teachersubject += '<table class="table table-bordered custom_table_styling">';
                                teachersubject += '<thead>';
                                teachersubject += '<tr>' + Subject_heading + '</tr>';

                                teachersubject += '</thead>';
                                teachersubject += '<tbody>';




                                teachersubject += '<tr><td>1</td><td>Subject Strengths</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                                teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';
                                teachersubject += '</tbody>';
                                teachersubject += '</table>';
                                /***TEACHER FEEDBACK***/
                                $("#" + currid + " .teacherfeedbacktable").html(teachersubject);

                            }
                            /***dynamilccity genarte table***/

                        }
                        else {
                            ID = result[0].Id;
                            /**PERSONAL INFO**/
                            $("#" + cureparent + " .rollno").val(result[0].Student_RollNo);
                            $("#" + cureparent + " .contactno").val(result[0].Contact_No);
                            $("#" + cureparent + " .emailaddr").val(result[0].Email);
                            $("#" + cureparent + " .graduationyear").val(result[0].Grad_Year);
                            $("#" + cureparent + " .plan_a").val(result[0].Career_goal_one);
                            $("#" + cureparent + " .plan_b").val(result[0].Career_goal_two);
                            $("#" + cureparent + " .dreamuni_1").val(result[0].Dream_uni1);
                            $("#" + cureparent + " .dreamuni_2").val(result[0].Dream_uni2);
                            $("#" + cureparent + " .dreamuni_3").val(result[0].Dream_uni3);
                            /***PERSONAL INFO***/
                            console.log("Class Wise Dept" + JSON.stringify(result[0].IEPReport_StudentSubject));
                            if (currclassid == 14) {//for class 10 edit 
                                var Subject_list1 = "";
                                var Subject_list2 = "";
                                for (var i = 0; i < result[0].IEPReport_StudentSubject.length; i++) {
                                    if (result[0].IEPReport_StudentSubject[i].Class_Id == 12) {
                                        var ser = i + 1;
                                        Subject_list1 += '<tr>';
                                        Subject_list1 += '<td>' + ser + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Name + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Id + '</td><td>' + result[0].IEPReport_StudentSubject[i].Marks + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_StudentSubject[i].Grade + '" data-value="' + result[0].IEPReport_StudentSubject[i].Class_Id + '" disabled/></td>';
                                        Subject_list1 += '</tr>';

                                        Subject_heading += '<th>' + result[0].IEPReport_StudentSubject[i].Subject_Name + "--" + result[0].IEPReport_StudentSubject[i].Subject_Id + '</th>';
                                        // Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_StudentSubject[i].Subject_Id + '" data-value="' + result[0].IEPReport_StudentSubject[i].Subject_Name + '"></td>';
                                    }
                                    if (result[0].IEPReport_StudentSubject[i].Class_Id == 13) {
                                        var ser = i + 1;
                                        Subject_list2 += '<tr>';
                                        Subject_list2 += '<td>' + ser + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Name + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Id + '</td><td>' + result[0].IEPReport_StudentSubject[i].Marks + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_StudentSubject[i].Grade + '" data-value="' + result[0].IEPReport_StudentSubject[i].Class_Id + '" disabled/></td>';
                                        Subject_list2 += '</tr>';

                                        Subject_heading += '<th>' + result[0].IEPReport_StudentSubject[i].Subject_Name + "--" + result[0].IEPReport_StudentSubject[i].Subject_Id + '</th>';
                                        // Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_StudentSubject[i].Subject_Id + '" data-value="' + result[0].IEPReport_StudentSubject[i].Subject_Name + '"></td>';
                                    }
                                }
                                $("#" + currid + " .academic_history1 tbody").html(Subject_list1);
                                $("#" + currid + " .academic_history2 tbody").html(Subject_list2);
                            }
                            if (currclassid == 15) {//for class 11 edit 
                                var Subject_list1 = "";
                                var Subject_list2 = "";
                                for (var i = 0; i < result[0].IEPReport_StudentSubject.length; i++) {
                                    if (result[0].IEPReport_StudentSubject[i].Class_Id == 13) {
                                        var ser = i + 1;
                                        Subject_list1 += '<tr>';
                                        Subject_list1 += '<td>' + ser + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Name + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Id + '</td><td>' + result[0].IEPReport_StudentSubject[i].Marks + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_StudentSubject[i].Grade + '" data-value="' + result[0].IEPReport_StudentSubject[i].Class_Id + '" disabled/></td>';
                                        Subject_list1 += '</tr>';

                                        Subject_heading += '<th>' + result[0].IEPReport_StudentSubject[i].Subject_Name + "--" + result[0].IEPReport_StudentSubject[i].Subject_Id + '</th>';
                                        // Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_StudentSubject[i].Subject_Id + '" data-value="' + result[0].IEPReport_StudentSubject[i].Subject_Name + '"></td>';
                                    }
                                    //if (result[0].IEPReport_StudentSubject[i].Class_Id == 20)//CIAE Result ID? {
                                    //    var ser = i + 1;
                                    //    Subject_list2 += '<tr>';
                                    //    Subject_list2 += '<td>' + ser + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Name + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Id + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_StudentSubject[i].Grade + '" data-value="' + result[0].IEPReport_StudentSubject[i].Class_Id + '" disabled/></td>';
                                    //    Subject_list2 += '</tr>';

                                    //    Subject_heading += '<th>' + result[0].IEPReport_StudentSubject[i].Subject_Name + "--" + result[0].IEPReport_StudentSubject[i].Subject_Id + '</th>';
                                    //    // Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_StudentSubject[i].Subject_Id + '" data-value="' + result[0].IEPReport_StudentSubject[i].Subject_Name + '"></td>';
                                    //}
                                }
                                $("#" + currid + " .academic_history1 tbody").html(Subject_list1);
                                //$("#" + currid + " .academic_history2 tbody").html(Subject_list2);
                            }
                            else {
                                for (var i = 0; i < result[0].IEPReport_StudentSubject.length; i++) {
                                    var ser = i + 1;
                                    Subject_list += '<tr>';
                                    Subject_list += '<td>' + ser + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Name + '</td><td>' + result[0].IEPReport_StudentSubject[i].Subject_Id + '</td><td>' + result[0].IEPReport_StudentSubject[i].Marks + '</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_StudentSubject[i].Grade + '" data-value="' + result[0].IEPReport_StudentSubject[i].Class_Id + '" disabled/></td>';
                                    Subject_list += '</tr>';

                                    Subject_heading += '<th>' + result[0].IEPReport_StudentSubject[i].Subject_Name + "--" + result[0].IEPReport_StudentSubject[i].Subject_Id + '</th>';
                                    // Subject_td += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_StudentSubject[i].Subject_Id + '" data-value="' + result[0].IEPReport_StudentSubject[i].Subject_Name + '"></td>';

                                }
                                $("#" + currid + " .academic_history tbody").html(Subject_list);
                            }
                            /*****TEACHER FEEBACK***/

                            /**TEACHER ARRAY**/
                            for (var ts = 0; ts < result[0].IEPReport_TeacherFeedback.length; ts++) {


                                if (alreadyteacher != result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue) {
                                    /**FIRST tIME USER**/
                                    if (alreadyteacher == "") {
                                        teachersubeditarray.push({
                                            Subject_Id: result[0].IEPReport_TeacherFeedback[ts].Subject_Id,
                                            Subject_Name: result[0].IEPReport_TeacherFeedback[ts].Subject_Name,
                                            Subject_Feeback: result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback


                                        });

                                        teachereditarray.push({
                                            Teacherfeedvalue: result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue,
                                            Teacherfeedname: result[0].IEPReport_TeacherFeedback[ts].Teacherfeedname,

                                            teachersubeditarray: teachersubeditarray

                                        });
                                        alreadyteacher = result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue;
                                    }
                                    /**FIRST tIME USER**/

                                    else {
                                        teachersubeditarray = [];
                                        teachersubeditarray.push({
                                            Subject_Id: result[0].IEPReport_TeacherFeedback[ts].Subject_Id,
                                            Subject_Name: result[0].IEPReport_TeacherFeedback[ts].Subject_Name,
                                            Subject_Feeback: result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback


                                        });

                                        teachereditarray.push({
                                            Teacherfeedvalue: result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue,
                                            Teacherfeedname: result[0].IEPReport_TeacherFeedback[ts].Teacherfeedname,

                                            teachersubeditarray: teachersubeditarray

                                        });
                                        alreadyteacher = result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue;
                                    }
                                }
                                else {
                                    teachersubeditarray.push({
                                        Subject_Id: result[0].IEPReport_TeacherFeedback[ts].Subject_Id,
                                        Subject_Name: result[0].IEPReport_TeacherFeedback[ts].Subject_Name,
                                        Subject_Feeback: result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback


                                    });
                                }
                                //console.log("niche wala" + datadd);
                            }
                            /**TEACHER ARRAY***/

                            console.log("niche wala" + JSON.stringify(teachereditarray));

                            teachersubject += '<table class="table table-bordered custom_table_styling">';
                            teachersubject += '<thead>';
                            teachersubject += '<tr>' + Subject_heading + '</tr>';

                            teachersubject += '</thead>';
                            teachersubject += '<tbody>';
                            for (var re = 0; re < teachereditarray.length; re++) {
                                teachersubject += '<tr><td>' + teachereditarray[re].Teacherfeedvalue + '</td><td>' + teachereditarray[re].Teacherfeedname + '</td>';

                                for (var ts = 0; ts < teachereditarray[re].teachersubeditarray.length; ts++) {

                                    teachersubject += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + teachereditarray[re].teachersubeditarray[ts].Subject_Id + '" data-value="' + teachereditarray[re].teachersubeditarray[ts].Subject_Name + '" value="' + teachereditarray[re].teachersubeditarray[ts].Subject_Feeback + '"></td>';

                                    //if (result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue == 2) {
                                    //    teachersubject += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Id + '" data-value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Name + '" value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback + '"></td>';
                                    //}
                                    //if (result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue == 3) {
                                    //    teachersubject += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Id + '" data-value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Name + '" value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback + '"></td>';
                                    //}
                                    //if (result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue == 4) {
                                    //    teachersubject += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Id + '" data-value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Name + '" value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback + '"></td>';
                                    //}
                                    //if (result[0].IEPReport_TeacherFeedback[ts].Teacherfeedvalue == 5) {
                                    //    teachersubject += '<td><input type="text" class="teachersubjecttd form-control" data-id="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Id + '" data-value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Name + '" value="' + result[0].IEPReport_TeacherFeedback[ts].Subject_Feeback + '"></td>';
                                    //}
                                    //teachersubject += '<tr><td>2</td><td>Subject areas to focus</td>' + Subject_td + '</tr>';
                                    //teachersubject += '<tr><td>3</td><td>Academic Potential</td>' + Subject_td + '</tr>';
                                    //teachersubject += '<tr><td>4</td><td>Suggested study hours</td>' + Subject_td + '</tr>';
                                    //teachersubject += '<tr><td>5</td><td>Suggested study pattern</td>' + Subject_td + '</tr>';

                                }
                                teachersubject += '</tr>';
                            }
                            teachersubject += '</tbody>';
                            teachersubject += '</table>';
                            /***TEACHER FEEDBACK***/
                            $("#" + currid + " .teacherfeedbacktable").html(teachersubject);

                            /****textarea Personal area***/
                            $("#" + currid + " .personal_info").val(result[0].IEPReport_PersonalInfo[0].Personal_Info);
                            $("#" + currid + " .hobbies_interest").val(result[0].IEPReport_PersonalInfo[0].Hobbies);
                            $("#" + currid + " .comments_counsler").val(result[0].IEPReport_PersonalInfo[0].Comment_Couns);

                            /***textarea Personal Area***/

                            /***QUESTION BUllet***/
                            $("#" + currid + " .personalstrength li:nth-child(1) input").val(result[0].IEPReport_Questionbullets[0].Personal_Strength1),
                                $("#" + currid + " .personalstrength li:nth-child(2) input").val(result[0].IEPReport_Questionbullets[0].Personal_Strength2),
                                $("#" + currid + " .personalstrength li:nth-child(3) input").val(result[0].IEPReport_Questionbullets[0].Personal_Strength3),
                                $("#" + currid + " .qualitydevelop li:nth-child(1) input").val(result[0].IEPReport_Questionbullets[0].Qualities1),
                                $("#" + currid + " .qualitydevelop li:nth-child(2) input").val(result[0].IEPReport_Questionbullets[0].Qualities2),
                                $("#" + currid + " .qualitydevelop li:nth-child(3) input").val(result[0].IEPReport_Questionbullets[0].Qualities3),
                                $("#" + currid + " .question_parent li:nth-child(1) input").val(result[0].IEPReport_Questionbullets[0].ParentQuestion1),
                                $("#" + currid + " .question_parent li:nth-child(2) input").val(result[0].IEPReport_Questionbullets[0].ParentQuestion2),
                                $("#" + currid + " .question_parent li:nth-child(3) input").val(result[0].IEPReport_Questionbullets[0].ParentQuestion3),
                                $("#" + currid + " .nameofcity li:nth-child(1) input").val(result[0].IEPReport_Questionbullets[0].Nameofteacher1),
                                $("#" + currid + " .nameofcity li:nth-child(2) input").val(result[0].IEPReport_Questionbullets[0].Nameofteacher2)
                            /***QUESTION BULLET***/

                            /***Activities table***/
                            for (var ac = 0; ac < result[0].IEPReport_Activities.length; ac++) {

                                activitiestable += '<tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_Activities[ac].Organization + '"/></td> <td class="nopadding_tds"><input type="text" class="form-control acasub_2" value="' + result[0].IEPReport_Activities[ac].Brief_description + '" /></td> <td class="nopadding_tds"><input type="text" class="form-control acasub_3" value="' + result[0].IEPReport_Activities[ac].Dates_participated + '"/></td> <td class="nopadding_tds"><input type="text" class="form-control acasub_4" value="' + result[0].IEPReport_Activities[ac].Leadership_Roles + '" /></td></tr>';

                            }
                            //activitiestable tbody
                            $("#" + currid + " .activitiestable tbody").html(activitiestable);
                            /***Activities table***/

                            /***communities table***/
                            for (var cc = 0; cc < result[0].IEPReport_CommunityService.length; cc++) {

                                communitiestable += '<tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" value="' + result[0].IEPReport_CommunityService[cc].Organization + '"/></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" value="' + result[0].IEPReport_CommunityService[cc].Brief_description + '"/></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" value="' + result[0].IEPReport_CommunityService[cc].Dates_participated + '"/></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" value="' + result[0].IEPReport_CommunityService[cc].Hours_spent + '"/></td></tr>';

                            }
                            //activitiestable tbody
                            $("#" + currid + " .communitiestable tbody").html(communitiestable);
                            /***communities table***/


                        }


                    },
                    complete: function (result) {

                        $(".overlay").hide();
                    },
                    error: function (err) {

                        //console.log(JSON.stringify(err));

                    }
                });



                /***FOR EDIT****/


            });




            //alert($(".classtab li .active").attr('data-value'));





            $(".IEP_btn").click(function () {


                console.log("what" + $(this).parent().parent().parent(".tab-pane").attr('id'));//.hasClass("active"));
                // $(this).parent().parent().parent(".tab-pane").firs
                //exit();
                var parentid = $(this).parent().parent().parent(".tab-pane").attr('id');
                var deliveryArr = [];

                deliveryArr.length = 0;

                var teacherarr = [];

                teacherarr.length = 0;

                var personalarr = [];

                personalarr.length = 0;


                var Questionarr = [];

                Questionarr.length = 0;

                var acarr = [];

                acarr.length = 0;

                var commrr = [];

                commrr.length = 0;
                if (parentid == "iep10") {
                    $.each($("#" + parentid + " .academchange tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });

                    //$.each($("#" + parentid + " .academic_history2 tbody tr"), function () {

                    //    deliveryArr.push({
                    //        Subject_Id: $(this).find('td:eq(2)').text(),
                    //        Subject_Name: $(this).find('td:eq(1)').text(),
                    //        Grade: $(this).find(".acasub_1").val(),
                    //        Class_Id: $(this).find(".acasub_1").attr("data-value")

                    //    });

                    //});
                }
                else if (parentid == "iep11") {
                    $.each($("#" + parentid + " .academic_history1 tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });

                    $.each($("#" + parentid + " .academic_history2 tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });
                }

                else if (parentid == "iepasa") {
                    $.each($("#" + parentid + " .academic_history1 tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });

                    $.each($("#" + parentid + " .academic_history2 tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });
                }
                else {
                    $.each($("#" + parentid + " .academic_history tbody tr"), function () {

                        deliveryArr.push({
                            Subject_Id: $(this).find('td:eq(2)').text(),
                            Subject_Name: $(this).find('td:eq(1)').text(),
                            Grade: $(this).find(".acasub_1").val(),
                            Class_Id: $(this).find(".acasub_1").attr("data-value"),
                            Marks: $(this).find('td:eq(3)').text()

                        });

                    });
                }
                console.log("subjects" + JSON.stringify(deliveryArr));

                /***TEACHER FEEDBACK ****/
                var tdlength = $("#" + parentid + " .teacherfeedbacktable tbody tr:eq(1) td").length;
                for (var tr = 0; tr < 5; tr++) {
                    //teacherarr.push({
                    //    teacherfeedvalue: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq(0)').text(),
                    //    teacherfeedname: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq(1)').text(),



                    //});
                    for (var td = 2; td < tdlength; td++) {
                        //.attr('data-id')
                        teacherarr.push({
                            Teacherfeedvalue: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq(0)').text(),
                            Teacherfeedname: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq(1)').text(),
                            Subject_Id: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq("' + td + '") input').attr('data-id'),
                            Subject_Name: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq("' + td + '") input').attr('data-value'),
                            Subject_Feeback: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq("' + td + '") input').val(),
                            Class_Id: $("#" + parentid + " .teacherfeedbacktable tbody tr:eq('" + tr + "')").find('td:eq("' + td + '") input').attr('data-name')

                        });
                    }

                }
                /***TEACHER FEEDBACK ****/


                console.log("teacher feeback" + JSON.stringify(teacherarr));

                /***PERSONAL INFO****/
                personalarr.push({
                    Personal_Info: $("#" + parentid + " .personal_info").val(),
                    Hobbies: $("#" + parentid + " .hobbies_interest").val(),
                    Comment_Couns: $("#" + parentid + " .comments_counsler").val()
                });
                /***PERSONAL INFO****/

                /***Question Bullet INFO****/
                Questionarr.push({
                    Personal_Strength1: $("#" + parentid + " .personalstrength li:nth-child(1) input").val(),
                    Personal_Strength2: $("#" + parentid + " .personalstrength li:nth-child(2) input").val(),
                    Personal_Strength3: $("#" + parentid + " .personalstrength li:nth-child(3) input").val(),
                    Qualities1: $("#" + parentid + " .qualitydevelop li:nth-child(1) input").val(),
                    Qualities2: $("#" + parentid + " .qualitydevelop li:nth-child(2) input").val(),
                    Qualities3: $("#" + parentid + " .qualitydevelop li:nth-child(3) input").val(),
                    ParentQuestion1: $("#" + parentid + " .question_parent li:nth-child(1) input").val(),
                    ParentQuestion2: $("#" + parentid + " .question_parent li:nth-child(2) input").val(),
                    ParentQuestion3: $("#" + parentid + " .question_parent li:nth-child(3) input").val(),
                    Nameofteacher1: $("#" + parentid + " .nameofcity li:nth-child(1) input").val(),
                    Nameofteacher2: $("#" + parentid + " .nameofcity li:nth-child(2) input").val(),
                });
                /***Question Bullet INFO****/

                /**ACADEMIC INFO ****/
                $.each($("#" + parentid + " .activitiestable tbody tr"), function () {
                    //.attr('data-id')
                    acarr.push({
                        Organization: $(this).find('td:eq(0) input').val(),
                        Brief_description: $(this).find('td:eq(1) input').val(),
                        Dates_participated: $(this).find('td:eq(2) input').val(),
                        Leadership_Roles: $(this).find('td:eq(3) input').val(),

                    });
                });
                /***ACADEMIC INFO ***/
                /**Community INFO ****/
                $.each($("#" + parentid + " .communitiestable tbody tr"), function () {
                    //.attr('data-id')
                    commrr.push({
                        Organization: $(this).find('td:eq(0) input').val(),
                        Brief_description: $(this).find('td:eq(1) input').val(),
                        Dates_participated: $(this).find('td:eq(2) input').val(),
                        Hours_spent: $(this).find('td:eq(3) input').val(),

                    });
                });
                /***Community INFO ***/






                if (ID == "") {

                    var dataadd_IEP = JSON.stringify({

                        //Student_Name: $(".IEP_ASA2 .name").val(),
                        //Student_RNo: $(".IEP_ASA2 .rollno").val(),
                        //Class_Id: $(".IEP_ASA2 .classval").val(),
                        //Contact_No: $(".IEP_ASA2 .contactno").val(), 

                        //Email_Address: $(".IEP_ASA2 .emailaddr").val(), 
                        //Graduation_Year: $(".IEP_ASA2 .graduationyear").val(),
                        //plan_a: $(".IEP_ASA2 .plan_a").val(),
                        //plan_b: $(".IEP_ASA2 .plan_b").val(),

                        //dream_Universities1: $(".dreamuni_1").val(),
                        //dream_Universities2: $(".dreamuni_2").val(),
                        //dream_Universities3: $(".dreamuni_3").val(),

                        //backup_Universities1: $(".backupuni_1").val(),
                        //backup_Universities2: $(".backupuni_2").val(),
                        //backup_Universities3: $(".backupuni_3").val(),





                        Student_Name: $("#" + parentid + " .name option:selected").text(),
                        Student_RollNo: $("#" + parentid + " .name").val(),//$("#" + parentid + " .rollno").val(),
                        Class_Id: $("#" + parentid + " .classval").val(),
                        Class_Name: $(".classnameofcurrent").val(),
                        Contact_No: $("#" + parentid + " .contactno").val(),
                        Email: $("#" + parentid + " .emailaddr").val(),
                        Grad_Year: $("#" + parentid + " .graduationyear").val(),
                        Career_goal_one: $("#" + parentid + " .plan_a").val(),
                        Career_goal_two: $("#" + parentid + " .plan_b").val(),
                        Dream_uni1: $("#" + parentid + " .dreamuni_1").val(),
                        Dream_uni2: $("#" + parentid + " .dreamuni_2").val(),
                        Dream_uni3: $("#" + parentid + " .dreamuni_3").val(),
                        Backup_uni1: $("#" + parentid + " .backupuni_1").val(),
                        Backup_uni2: $("#" + parentid + " .backupuni_2").val(),
                        Backup_uni3: $("#" + parentid + " .backupuni_3").val(),
                        IEPReport_StudentSubject: deliveryArr,
                        IEPReport_TeacherFeedback: teacherarr,
                        IEPReport_PersonalInfo: personalarr,
                        IEPReport_Questionbullets: Questionarr,
                        IEPReport_Activities: acarr,
                        IEPReport_CommunityService: commrr,
                    });


                    $.when(saveOrder_IEPA2(dataadd_IEP)).then(function (response) {
                        //console.log("RESPONSESSS" + response);
                    }).fail(function (err) {
                        alert("ERORRRR" + err);
                    });
                }
                else {
                    /*****EDIT***/
                    var dataedit_IEP = JSON.stringify({


                        Id: ID,
                        Student_Name: $("#" + parentid + " .name option:selected").text(),
                        Student_RollNo: $("#" + parentid + " .name").val(),//$("#" + parentid + " .rollno").val(),
                        Class_Id: $("#" + parentid + " .classval").val(),
                        Class_Name: $(".classnameofcurrent").val(),
                        Contact_No: $("#" + parentid + " .contactno").val(),
                        Email: $("#" + parentid + " .emailaddr").val(),
                        Grad_Year: $("#" + parentid + " .graduationyear").val(),
                        Career_goal_one: $("#" + parentid + " .plan_a").val(),
                        Career_goal_two: $("#" + parentid + " .plan_b").val(),
                        Dream_uni1: $("#" + parentid + " .dreamuni_1").val(),
                        Dream_uni2: $("#" + parentid + " .dreamuni_2").val(),
                        Dream_uni3: $("#" + parentid + " .dreamuni_3").val(),
                        Backup_uni1: $("#" + parentid + " .backupuni_1").val(),
                        Backup_uni2: $("#" + parentid + " .backupuni_2").val(),
                        Backup_uni3: $("#" + parentid + " .backupuni_3").val(),
                        IEPReport_StudentSubject: deliveryArr,
                        IEPReport_TeacherFeedback: teacherarr,
                        IEPReport_PersonalInfo: personalarr,
                        IEPReport_Questionbullets: Questionarr,
                        IEPReport_Activities: acarr,
                        IEPReport_CommunityService: commrr,
                    });


                    $.when(saveUpdate_IEPA2(dataedit_IEP)).then(function (response) {
                        //console.log("RESPONSESSS" + response);
                    }).fail(function (err) {
                        alert("ERORRRR" + err);
                    });
                    /***EDIT***/

                }

            });

            function saveOrder_IEPA2(dataadd_IEPA2) {
                console.log("save data" + dataadd_IEPA2);
                $('.overlay').show();


                return $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    type: 'POST',
                    crossDomain: true,
                  
                    data: dataadd_IEPA2,
                    //dataType: 'json',
                    dataType: 'json',
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                    //url: 'http://localhost:52673/api/Setup/Student_info',
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/Student_info',
                    success: function (result) {
                      
                        Swal.fire(
                            'Update Successfuly!',
                            '',
                            'success'
                        ).then(function () {
                            //resetaddmodel();
                            //fabrictable();
                            location.reload();
                        });

                    },
                    complete: function () {

                        $('.overlay').hide();
                    },
                    error: function () {
                        alert("error");
                    }
                });
            }


            function saveUpdate_IEPA2(dataedit_IEP) {
                //console.log(dataedit_IEP);

                $('.overlay').show();


                return $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    type: 'PUT',
                    crossDomain: true,
                    headers: {
                        'accept': 'application/json',
                        'Access-Control-Allow-Origin': '*'
                    },
                    data: dataedit_IEP,
                    //dataType: 'json',
                    dataType: 'json',
                    //url: 'http://localhost:52673/api/Setup/UpdateIEPData',
                    url: 'http://iepapi.csn.edu.pk:8111/api/Setup/UpdateIEPData',
                    success: function (result) {
                   
                        Swal.fire(
                            'Update Successfuly!',
                            '',
                            'success'
                        ).then(function () {
                            //resetaddmodel();
                            //fabrictable();
                            location.reload();
                        });
                        //alert("Save");
                      

                    },
                    complete: function () {

                        $('.overlay').hide();
                    },
                    error: function () {
                        alert("error");
                    }
                });
            }
        }
  
     
