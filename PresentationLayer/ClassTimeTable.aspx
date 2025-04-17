<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ClassTimeTable.aspx.cs" Inherits="PresentationLayer_ClassTimeTable"
    Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--Bootstrap tabs--%>
            <asp:ScriptReference Path="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>



    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2>Class Timetable</h2>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="4">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>

                                        <td id="tdFrmHeading" class="formheading">
                                            <%--<asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="LO Consolidation"></asp:Label>--%>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 13px" class="leftlink" align="right" colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="main_table col-lg-12" cellspacing="0" cellpadding="0" <%--main_table col-lg-8 col-md-8 col-xs-8 col-sm-8--%>
                                                border="0">
                                                <tr class="row">

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Region :</label>
                                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">School :</label>
                                                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control"
                                                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Session :</label>
                                                            <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Teacher :</label>
                                                            <asp:DropDownList ID="ddlteacher" runat="server" CssClass="dropdownlist form-control"
                                                                Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlteacher_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>


                                                </tr>
                                                <tr class="row">
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Class :</label>
                                                            <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Subject :</label>
                                                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Start Time :</label>
                                                            <%--   <asp:DropDownList ID="ddl_grouphead" runat="server" CssClass="dropdownlist form-control"
                                                                Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_grouphead_SelectedIndexChanged">
                                                            </asp:DropDownList>--%>
                                                            <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" CssClass="dropdownlist form-control" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">End Time :</label>
                                                            <asp:TextBox ID="txtendtime" runat="server" TextMode="Time" CssClass="dropdownlist form-control" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <%-- <td class="col-lg-3"></td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="vh-100">
                <%--   
                <ul class="nav nav-tabs">
                    
                    <li class="active"><a data-toggle="tab" href="#home">Home</a></li>
                    <li><a data-toggle="tab" href="#menu1">View Report Data</a></li>

                </ul>--%>

                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <%-- <h3>HOME</h3>--%>


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
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0" <%--main_table col-lg-8 col-md-8 col-xs-8 col-sm-8--%>
                                            border="0">
                                            <tr class="row">
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary savebtn" OnClick="btnSave_Click" Text="Save" CausesValidation="false" />&nbsp;&nbsp;
                            <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary savebtn" OnClick="btncancel_Click" Text="Cancel" ValidationGroup="valSave" />

                                    </td>
                                </tr>

                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Class Timetable View</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <asp:GridView ID="dg_timetable" runat="server" AutoGenerateColumns="False"
                                        Height="100%" OnRowCommand="dg_timetable_RowCommand" PageSize="50" Width="100%"
                                        SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Region_Name" HeaderText="Region" />
                                            <asp:BoundField DataField="Center_Name" HeaderText="Center" />
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class" />
                                            <asp:BoundField DataField="FullName" HeaderText="Teacher" />
                                            <asp:BoundField DataField="Subject_Name" HeaderText="Subject" />
                                            <asp:BoundField DataField="Starttime" HeaderText="Start Time" />
                                            <asp:BoundField DataField="Endtime" HeaderText="End Time" />
                                            <asp:TemplateField HeaderText="Deactivate Status" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtndelete" runat="server" OnClick="lbtndelete_Click" OnClientClick="return confirm('Are you sure?');" CommandArgument='<%#Eval("TimetableId") %>'>Deactive</asp:LinkButton>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                    <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>

                                </tr>


                                <tr>
                                    <td colspan="7">&nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="savearea" runat="server">
                        </div>
                        <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender2"
                            runat="server"
                            TargetControlID="savearea"
                            VerticalSide="Top"
                            HorizontalSide="Right">
                        </cc1:AlwaysVisibleControlExtender>

                    </div>
                    <div id="menu1" class="tab-pane fade">
                        <h3>LO Consolidation Report</h3>

                        <div class="container horizontal-scrollable ">
                            <%--  <section>--%>
                            <table class="table">
                                <tr>
                                    <th class="text-center" colspan="10">Information</th>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3f2f7;">&nbsp;</td>
                                    <td>Lesson Planning</td>
                                    <td style="background-color: lightgray;">&nbsp;</td>
                                    <td>Teaching</td>
                                    <td style="background-color: #c4f2c4;">&nbsp;</td>
                                    <td>Student Learning Skills</td>
                                    <td style="background-color: #f7d2c3;">&nbsp;</td>
                                    <td>Attitudes, relationships</td>
                                    <td style="background-color: #f7f7cd;">&nbsp;</td>
                                    <td>Care and Classroom Routines (EYFS and KS1)</td>
                                </tr>
                                <tr>
                                    <td colspan="10"></td>
                                </tr>
                            </table>
                            <div class="table-responsive text-nowrap">
                                <%--********************************CssClass="datatable table table-striped table-bordered table-hover"*************************************--%>
                                <%--<table class="table table-striped><tbody><tr><td>--%>











                                <%--</td></tr></tbody></table>--%>

                                <%--*********************************************************************--%>
                            </div>

                            <%--</section>--%>
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

    <style type="text/css">
        .TextLabelMandatory40 {
            font-size: 12px !important;
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
            ht: 30px;
            ize: 14px;
            gridtxt size: 14px !important;
            .stuna e, rolln, .ge font weigh .upperheadng

        {
            ound: 0c4da px;
            /* margi :
            nt; */
            border d border-radius: 1 p .upperheadi color: #f f
        }

        .right-align.for
        direction: rtl !
        }

        gn.form-control
        t

        portant;
        .urdutxtright {
            : rtl !important;
            *
             /*float:right ! mpor
         
        splay: f e
              justif -cont
        e

         }

   ft {
        t

        ortant;*/
   lay: f ex;
            */ ntent: end;
            .hid txt

        {
            one;
            .showtxt

        {
            displ
        }

        .ufloat_ri

        t: right
        .tet-r ght {
            x ht;
            .no_pa ding

        {
            g portant;
            padding-right 0px !impor a .grid in: 5px 0p !important;
            .hid btn

        {
            isplay non
        }



        i

        an:nth-chi d
        r {
            ontent: " م .absentdi (1)

        {
            ight;
            e margin-left: 3px;
        }



        .absentdiv {
            text-align: right !important;
        }

        .lbltxtabsent {
            float: right;
            margin-left: 8px;
        }
    </style>





    <script type="text/javascript">
        function SetActiveTab() {
            event.preventDefault();
            //$(".saved").fadeIn(500).fadeOut(500);
            $('a[href="#menu1"]').click()
        }
    </script>
</asp:Content>



