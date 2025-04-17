<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ClassSectionSubjectComments2.aspx.cs" Inherits="PresentationLayer_TCS_ClassSectionSubjectComments2" %>

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
                                            <table class="main_table col-lg-12 col-md-12 col-xs-12 col-sm-12" cellspacing="0" cellpadding="0" 
                                                border="0">
                                                <tr class="row">
                                                    
                                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">

                                                         <div class="form-group">
                                                        <label class="TextLabelMandatory40">Class Section*:</label>
                                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                        </div>
                                                     
                                                    </td>

                                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                                         <div class="form-group">
                                                         <label class="TextLabelMandatory40">Subject*:</label>
                                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="list_Subject_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                             </div>
                                                    </td>
                                                      <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                                           <div class="form-group">
                                                         <label class="TextLabelMandatory40">Student:</label>
                                                        <asp:DropDownList ID="list_student" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="list_student_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                               </div>
                                                    </td>
                                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                                         <div class="form-group">
                                                          <label class="TextLabelMandatory40">Term*:</label>
                                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="100%">
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
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvRegStudents_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvRegStudents_RowDataBound"
                                OnRowCommand="gvRegStudents_RowCommand">
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
                                                                <td class="col-lg-4 col-md-4 col-sm-12 col-xs-12 upperheading"><span class="rollno">Roll # :</span><span class="student_id"> <%# Eval("Student_Id") %></span>
                                                                </td>
                                                                
                                                                <td class="col-lg-4 col-md-4 col-sm-12 col-xs-12 upperheading"><span class="stuname">Student Name :</span><span class="student_nameid">  <%# Eval("StudentNameId")%></span>
                                                                </td>
                                                               

                                                                <td class="col-lg-4 col-md-4 col-sm-12 col-xs-12 upperheading"><span class="gendername">Gender:</span><span class="gender_nameid"> <%# Eval("Gender")%></span>
                                                                </td>
                                                               
                                                            </tr>

                                                            <tr style="width: 100%; height: 10px">
                                                                <td colspan="5"></td>
                                                            </tr>
                                                            <tr class="row"  id="trsubcomments" runat="server">
                                                               
                                                                
                                                                <td style="width: 35%; color: black; font-size: 13px;" colspan="5">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <h3 id="Strong1"  runat="server" class="gridchildheading">Subject Teacher's Comments: </h3>
                                                                        </div>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <p class="gridtxt">I am really pleased with <%# Eval("fullname")%>’s</p> 
                                                                    <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                                    <asp:DropDownList ID="listG1" runat="server" CssClass="dropdownlist form-control">
                                                                    </asp:DropDownList>
                                                                        </div>
                                                                    <p class="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp">and</p> 
                                                                         <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                                    <asp:DropDownList ID="listG2" runat="server" CssClass="dropdownlist form-control">
                                                                    </asp:DropDownList>
                                                                        </div>
                                                                        </div>
                                                                    .<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <p class="gridtxt">I would like to see an improvement in  
                                                                    <%#((Eval("Gender").ToString()=="M")?"his":"her")%></p>
                                                                    <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                                    <asp:DropDownList ID="listImp1" runat="server"  CssClass="dropdownlist form-control">
                                                                    </asp:DropDownList>
                                                                     </div>
                                                                    <p class="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp">
                                                                        and also in <%#((Eval("Gender").ToString()=="M")?"his":"her")%>
                                                                        </p>
                                                                        <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                                    <asp:DropDownList ID="listImp2" runat="server"  CssClass="dropdownlist form-control">
                                                                    </asp:DropDownList>
                                                                        </div>
                                                                        </div>
                                                                    .
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%; height: 10px">
                                                                <td colspan="5"></td>
                                                            </tr>

                                                            <tr class="row" id="treffort" runat="server">
                                                              
                                                                <td colspan="4">
                                                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                        
                                                                                <h3 id="Strong2"  runat="server" class="gridchildheading">Effort: </h3>
                                                                        
                                                                    <asp:DropDownList ID="listEffort" runat="server"  CssClass="dropdownlist form-control">
                                                                        
                                                                        <asp:ListItem Text="Select" Value="0" />
                                                                        <asp:ListItem Text="Excellent: 1" Value="1" />
                                                                        <asp:ListItem Text="Good: 2" Value="2" />
                                                                        <asp:ListItem Text="Satisfactory: 3" Value="3" />
                                                                        <asp:ListItem Text="Needs improving: 4" Value="4" />
                                                                    </asp:DropDownList>
                                                                     <asp:Label ID="lblerror" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                                                                        </div>
                                                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                         <h3 id="Strong3"  runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 gridchildheading">Mark Absent:</h3>
                                                                    <asp:CheckBox ID="chkAbsent" Text="Absent" AutoPostBack="true" runat="server" OnCheckedChanged="chkAbsent_OnCheckedChanged" CssClass="absent_checkbox"/>
                                                                    <asp:Label ID="lblAbsent" ForeColor="Red" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                               
                                                            </tr>

                                                          
                                                           

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="text-align: center">
                           
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="savearea" runat="server" class="savearea"><!---Style="margin-top:40%;margin-right:50px"-->
                 <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary savebtn" OnClick="btnSave_Click" Text="Save" ValidationGroup="valSave" />
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
        margin-bottom:10px;
        padding-left:0px;
        font-size: 15px !important;
        }
        .studentgrid {
        padding:1% !important;
        }
        .absent_checkbox input {
    position: relative;
    top: 4px;
    margin-right: 10px !important;
}
        .savearea {
    position: unset !important;
    padding: 10px 0px;
}
        .andp {
        margin-bottom: 0px !important;
    line-height: 30px;
    font-size:14px;
        }
        .gridtxt {
        font-size:14px !important;
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
</style>


</asp:Content>
