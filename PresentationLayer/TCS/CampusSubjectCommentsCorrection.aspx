<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="CampusSubjectCommentsCorrection.aspx.cs" Inherits="PresentationLayer_TCS_CampusSubjectCommentsCorrection"
    Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
    </cc1:ToolkitScriptManager>



    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">


        <ContentTemplate>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>

                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Subject Wise Comments"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>


                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right" colspan="3"></td>
                    </tr>

                    <tr>
                        <td>
                            <table class="main_table col-lg-10 col-md-10 col-xs-10 col-sm-10" cellspacing="0" cellpadding="0"
                                border="0">
                                <tr class="row">

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">

                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Region :</label>
                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>

                                    </td>

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">School :</label>
                                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Class :</label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="100%">
                                                <%--disabled="disabled"--%>
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Term Group :</label>
                                            <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Subject :</label>
                                            <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="list_Subject_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>

                    <tr align="center">
                        <td style="height: 22px" class="titlesection" colspan="3">
                            <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                Visible="true" Font-Overline="False" Class="formheading">Please save your work regularly to avoid data loss.</asp:Label>
                        </td>
                    </tr>


                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvRegStudents" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvRegStudents_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="Student_Id" SortExpression="Student_Id" HeaderText="0">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Std_Com_Id" SortExpression="Std_Com_Id" HeaderText="1">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GoodOne" SortExpression="GoodOne" HeaderText="2">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GoodTwo" SortExpression="GoodTwo" HeaderText="3">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ImprovOne" SortExpression="ImprovOne" HeaderText="4">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ImprovTwo" SortExpression="ImprovTwo" HeaderText="5">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Effort" SortExpression="Effort" HeaderText="6">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="fullname" SortExpression="fullname" HeaderText="7">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Gender" SortExpression="Gender" HeaderText="8">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="isAbsent" SortExpression="isAbsent" HeaderText="9">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:TemplateField ItemStyle-Width="100%">
                                        <ItemTemplate>
                                            <table style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;"
                                                cellspacing="0" cellpadding="0">
                                                <tr class="tr1" style="height: 5px;">
                                                    <td></td>
                                                </tr>
                                                <tr class="tr2" style="height: 72%">
                                                    <td align="left" valign="top" style="word-wrap: break-word" class="studentgrid">
                                                        <table class="col-lg-12 col-md-12 col-xs-12 col-sm-12" cellspacing="0" cellpadding="0">
                                                            <tr class="row text-center">
                                                                <td class="col-lg-12 col-md-12 col-sm-12 col-xs-12 upperheading">
                                                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                        <span class="rollno">Roll # :</span><span class="student_id"> <%# Eval("Student_Id") %></span>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                        <span class="stuname">Student Name :</span><span class="student_nameid">  <%# Eval("StudentNameId")%></span>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                        <span class="gendername">Gender:</span><span class="gender_nameid"> <%# Eval("Gender")%></span>
                                                                    </div>
                                                                </td>

                                                                <%--               <td class="col-lg-4 col-md-4 col-sm-12 col-xs-12 upperheading">
                                                                </td>
                                                               

                                                                <td class="col-lg-4 col-md-4 col-sm-12 col-xs-12 upperheading">
                                                                </td>--%>
                                                            </tr>

                                                            <tr style="width: 100%; height: 10px">
                                                                <td colspan="5"></td>
                                                            </tr>
                                                            <tr class="row" id="trsubcomments" runat="server">


                                                                <%-- <td style="width: 35%; color: black; font-size: 13px;" colspan="5">
                                                                    
                                                                    </td>--%>
                                                                <td>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <h3 id="Strong1" runat="server" class="gridchildheading">Subject Teacher's Comments: </h3>
                                                                    </div>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <%--     <p class="gridtxt" ID="pleasetxteng">I am pleased with <%# Eval("fullname")%>’s</p> --%>
                                                                        <%--<p class="gridtxt" ID="pleasetxturdu"> <%# Eval("fullname")%>’s میں</p>--%>
                                                                        <p class="gridtxt">
                                                                            <asp:Label runat="server" ID="pleasetxtengtest">I am pleased with </asp:Label><%--<%# Eval("fullname")%>’s--%></p>



                                                                        <%-- <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding" >--%>
                                                                        <asp:Panel ID="listG1div" CssClass="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding" runat="server">
                                                                            <asp:DropDownList ID="listG1" runat="server" CssClass="dropdownlist dropdownlist1 form-control">
                                                                                <%--dir="rtl"--%>
                                                                            </asp:DropDownList>
                                                                        </asp:Panel>
                                                                        <%--   </div>--%>
                                                                        <%-- <div class="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp" >--%>
                                                                        <asp:Panel runat="server" CssClass="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp" ID="andp">
                                                                            <asp:Label runat="server" ID="andtxt">and</asp:Label>
                                                                        </asp:Panel>
                                                                        <%--  </div> --%>

                                                                        <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">

                                                                            <asp:DropDownList ID="listG2" runat="server" CssClass="dropdownlist form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <p class="gridtxt">
                                                                            <asp:Label runat="server" ID="improtxt1">Areas for improvement
                                                                        <%--I would like to see an improvement in  --%>
                                                                    <%--#((Eval("Gender").ToString()=="M")?"his":"her")--%>
                                                                            </asp:Label>

                                                                        </p>
                                                                        <%-- <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">--%>
                                                                        <asp:Panel ID="listImp1div" CssClass="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding" runat="server">
                                                                            <asp:DropDownList ID="listImp1" runat="server" CssClass="dropdownlist form-control">
                                                                            </asp:DropDownList>
                                                                        </asp:Panel>
                                                                        <%--</div>--%>
                                                                        <%-- <p class="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp">--%>
                                                                        <asp:Panel runat="server" CssClass="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp" ID="andp2">
                                                                            <asp:Label runat="server" ID="improtxtand">
                                                                        and<%-- also in --%><%--#((Eval("Gender").ToString()=="M")?"his":"her")--%>
                                                                            </asp:Label>
                                                                        </asp:Panel>
                                                                        <%-- </p>--%>
                                                                        <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                                            <asp:DropDownList ID="listImp2" runat="server" CssClass="dropdownlist form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <%-- <p class="gridtxt " style="float:right">--%>
                                                                        <asp:Panel runat="server" CssClass="col-lg-12 col-md-12 col-xs-12 col-sm-12 ufloat_right gridtxt no_padding" ID="gridtxt">
                                                                            <asp:Label runat="server" ID="improtxt2" CssClass="text-right">
                                                                         <%-- .میں بہتری  کے لیے پرامید ہوں  --%>   
                                                                            </asp:Label>
                                                                        </asp:Panel>

                                                                        <%-- </p>--%>
                                                                    </div>

                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%; height: 10px">
                                                                <td colspan="5"></td>
                                                            </tr>

                                                            <tr class="row" id="treffort" runat="server">

                                                                <%--  <td colspan="4">
                                                                    
                                                                        
                                                                                
                                                                       </td>--%>
                                                                <td>
                                                                    <h3 id="Strong2" runat="server" class="gridchildheading col-lg-12 col-md-12 col-sm-12 col-xs-12">Effort: </h3>
                                                                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">

                                                                        <asp:DropDownList ID="listEffort" runat="server" CssClass="dropdownlist form-control">

                                                                            <asp:ListItem Text="Select" Value="0" />
                                                                            <asp:ListItem Text="Excellent: 1" Value="1" />
                                                                            <asp:ListItem Text="Good: 2" Value="2" />
                                                                            <asp:ListItem Text="Satisfactory: 3" Value="3" />
                                                                            <asp:ListItem Text="Needs improving: 4" Value="4" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
                                                                        <asp:Label ID="lblerror" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                                                                    </div>
                                                                </td>


                                                                <%-- <td>--%>

                                                                <%--</td>--%>
                                                            </tr>
                                                            <tr class="row" runat="server">

                                                                <td>
                                                                    <h3 id="Strong3" runat="server" class="hidden col-lg-12 col-md-12 col-sm-12 col-xs-12 gridchildheading">Absent from classes:</h3>
                                                                    <div class="hidden col-lg-6 col-md-6 col-xs-12 col-sm-12">

                                                                        <asp:CheckBox ID="chkAbsent" Text="Absent from classes" AutoPostBack="true" runat="server" OnCheckedChanged="chkAbsent_OnCheckedChanged" CssClass="absent_checkbox" />
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
                                                                        <asp:Panel ID="absentdiv" runat="server" CssClass="absentdiv">

                                                                            <asp:Label ID="lblabsenttxt" ForeColor="Red" runat="server" CssClass="lbltxtabsent"></asp:Label>
                                                                            <asp:Label ID="lblAbsent" ForeColor="Red" runat="server"></asp:Label>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </td>

                                                                <%--  <td>
                                                                      
                                                                </td>--%>
                                                            </tr>
                                                            <tr class="row" runat="server">
                                                                <%--     <td>
                                                                    <asp:Label ID="lblAbsent" ForeColor="Red" runat="server"></asp:Label>
                                                             </td>--%>
                                                            </tr>




                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="isLock" SortExpression="isLock" HeaderText="11">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="text-align: center"></td>
                    </tr>
                </tbody>
            </table>
            <div id="savearea" runat="server" class="savearea">
                <!---Style="margin-top:40%;margin-right:50px"-->
                <asp:Button Style="display: none;" ID="btn_save" runat="server" CssClass="btn btn-primary savebtn" OnClick="btnSave_Click" Text="Save" ValidationGroup="valSave" />
            </div>

            <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender2"
                runat="server"
                TargetControlID="savearea"
                VerticalSide="Top"
                HorizontalSide="Right">
            </cc1:AlwaysVisibleControlExtender>
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

    <style type="text/css">
        .TextLabelMandatory40 {
            font-size: 14px !important;
            font-weight: bold;
            color: black;
            width: 100% !important;
            text-align: left !important;
        }

        .gridchildheading {
            margin-bottom: 10px;
            padding-left: 0px;
            font-size: 15px !important;
        }

        .studentgrid {
            padding: 1% !important;
        }

        .absent_checkbox input {
            position: relative;
            top: 4px;
            margin-right: 10px !important;
        }

        .savearea {
            /*position: unset !important;*/
            padding: 10px 0px;
        }

        .andp {
            margin-bottom: 0px !important;
            line-height: 30px;
            font-size: 14px;
        }

        .gridtxt {
            font-size: 14px !important;
        }

        .stuname, .rollno, .gendername {
            font-weight: 700;
        }

        .upperheading {
            background: #0c4da2;
            padding: 10px;
            /* margin: 10px !important; */
            border: 1px solid #fff;
            border-radius: 10px;
        }

            .upperheading span {
                color: #fff;
            }

        .right-align.form-control {
            direction: rtl !important;
        }

        .left-align.form-control {
            direction: ltr !important;
        }

        .urdutxtright {
            /*direction: rtl !important;*/
            /*float:right !important;*/
            display: flex;
            justify-content: flex-end;
        }

        .urdutxtleft {
            /*direction:ltr !important;*/
            /*display: flex;*/
            justify-content: end;
        }

        .hidetxt {
            display: none;
        }

        .showtxt {
            display: block;
        }

        .ufloat_right {
            float: right;
        }

        .text-right {
            text-align: right;
        }

        .no_padding {
            padding-left: 0px !important;
            padding-right: 0px !important
        }

        .gridtxt {
            margin: 5px 0px !important;
        }

        .hidebtn {
            display: none !important;
        }


        .maiproblemabsent span:nth-child(1) span::after {
            content: " میں";
        }

        .absentdiv span:nth-child(1) {
            float: right;
            color: red;
            margin-left: 3px;
        }



        .absentdiv {
            text-align: right !important;
        }

        .lbltxtabsent {
            float: right;
            margin-left: 8px;
        }
    </style>
    <%-- <script>
        // var objsts = $('#listG1 option').length;
        function myddFunction(itemdd) {
        //$('.dropdownlist1').change(function () {
            //var list1 = $("#listG1 option:selected").text();
            //var len = $("option", itemdd).length);
            //for (var i = 0; i < len; i++) {
            $("option", itemdd).each(function () {
                    //$("#container").append(this.value + ' ');        // or $(this).val()
              
                var list1 = $(this).text();// $("option:selected", itemdd).text();
                var english = /^[A-Za-z0-9]*$/;

                //$.each(objsts, function () {
                //var $this = $(this);
                //if (!english.test($this.html()))
                if (!english.test(list1))
                    //$this.addClass('active');
                    //$("option:selected", itemdd).addClass('active');
                    $("option", itemdd).addClass('active');
                //});
                });
            //}
            //$("html[lang=ar]").attr("dir", "rtl")
        }

       
    </script>--%>
</asp:Content>



