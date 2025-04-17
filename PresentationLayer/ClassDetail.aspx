
<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ClassDetail.aspx.cs" Inherits="PresentationLayer_ClassDetail" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <%--<asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />--%>
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="../Scripts/jquery.timepicker.js" />
            <asp:ScriptReference Path="../Scripts/jquery.timepicker.css"/>--%>

            <%-- <link href="../Scripts/jquery.timepicker.css" rel="stylesheet" />
            <script type="text/javascript" src="../Scripts/jquery.timepicker.js"></script>
            --%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />


    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
                TargetControlID="popup" HorizontalSide="Center" VerticalSide="Middle" HorizontalOffset="0"
                VerticalOffset="100">
            </cc1:AlwaysVisibleControlExtender>
            <div id="popup" runat="server" style="background-image: url(../images/divbg.gif); background-repeat: no-repeat; text-align: center; width: 300px; height: 149px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="35"></td>
                    </tr>
                    <tr align="center">
                        <td height="100">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" ImageAlign="AbsMiddle" />
                            <br />
                            <br />
                            Loading Please Wait...
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnPreRender="UpdatePanel1_PreRender">
        <ContentTemplate>
            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.gif"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table style="background-repeat: no-repeat" cellspacing="0" cellpadding="0" width="80%"
                                                background="<%= Page.ResolveUrl("~")%>images/new_img_center2a.gif" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 19px" width="2%">&nbsp;</td>
                                                        <td class="formheading" width="98%">Create Class</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <%--<tr>
                <td align="right" height="15">
                    <asp:Button ID="but_back" OnClick="but_back_Click" runat="server" CssClass="button"
                        Text="Back" OnClientClick="history.go(-1);"></asp:Button></td>
            </tr>--%>
                  <td>
                        <asp:Label ID="lab_region" runat="server">Region*:</asp:Label>
                        <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True" Style="margin-left: 92px; width: 412px;">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="167px" ForeColor="Red"
                            ErrorMessage="Select Region" Display="Dynamic" ControlToValidate="list_region"
                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>

                    </td>
                    <tr>
                        <td align="right" height="18">
                            <asp:Button ID="but_new" OnClick="but_new_Click1" runat="server" CssClass="btn btn-primary"
                                CausesValidation="False" Font-Bold="False" Text="Add New Class"></asp:Button>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="titlesection">Class List</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gv_criteriaList" runat="server" Width="100%" OnSorting="gv_criteriaList_Sorting" SkinID="GridView"
                                OnSelectedIndexChanging="gv_criteriaList_SelectedIndexChanging" OnRowDeleting="gv_criteriaList_RowDeleting"
                                OnRowDataBound="gv_criteriaList_RowDataBound" OnRowCommand="gv_criteriaList_RowCommand"
                                OnPageIndexChanging="gv_criteriaList_PageIndexChanging" HorizontalAlign="Center"
                                AutoGenerateColumns="False" OnRowCreated="gv_criteriaList_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Grade_Id" HeaderText="Grade1" ></asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Grade">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetGrade(Eval("Grade_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Grade" HeaderText="Grade" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class"></asp:BoundField>
                                    <%--<asp:BoundField DataField="Status_Id" HeaderText="Status1"></asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetStatus(Eval("Status_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Class_Id" HeaderText="Program_ID" ItemStyle-CssClass="hide"
                                        HeaderStyle-CssClass="hide"></asp:BoundField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Delete" Visible="false">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                ImageUrl="~/images/edit.gif" Text="Edit" />
                                            &nbsp;--%>
                                            <asp:ImageButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Class_Id") %>' CausesValidation="False" CommandName="Delete"
                                                ImageUrl="~/images/delete.gif" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assign Subjects">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnAssignSubjects" runat="server" Text="Assign Subjects"
                                                CommandArgument='<%#Eval("Class_Id") %>' CommandName='<%#Eval("Class_Name") %>' OnClick="btnAssignSubjects_Click" CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Assign Subjects">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnViewSubjects" runat="server" Text="View Assigned Subjects"
                                                CommandArgument='<%#Eval("Class_Id") %>' CommandName='<%#Eval("Class_Name") %>' OnClick="btnViewSubjects_Click" CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <SelectedRowStyle CssClass="tr_select"></SelectedRowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Visible="False" Text="No Data Exists."></asp:Label></td>
                    </tr>

                    <tr>
                        <td id="TD1" valign="top" runat="server">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="titlesection" colspan="5">Class Detail&nbsp;</td>
                                        </tr>

                                        <%--<tr class="tr2">
                                            <td width="2%" height="25">
                                            </td>
                                            <td align="right" width="21%">
                                                Grade* :</td>
                                            <td style="width: 159px">
                                                <asp:DropDownList ID="list_grade" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                    OnSelectedIndexChanged="list_grade_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="class"
                                                    SetFocusOnError="True" ErrorMessage="Grade is a required field" Display="Dynamic"
                                                    ControlToValidate="list_grade"></asp:RequiredFieldValidator></td>
                                            <td width="24%">
                                            </td>
                                            <td style="width: 159px">
                                            </td>
                                        </tr>--%>
                                        <tr class="tr1">
                                            <td width="2%" height="25">&nbsp;</td>
                                            <td align="right" width="21%">Class Name* :</td>
                                            <td style="width: 159px">
                                                <asp:TextBox ID="text_className" runat="server" CssClass="textbox" ValidationGroup="class"
                                                    MaxLength="50"></asp:TextBox>
                                                <span style="background-color: #ffffff"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="class"
                                                    SetFocusOnError="True" ErrorMessage="Class name is a required field" Display="Dynamic"
                                                    ControlToValidate="text_className"></asp:RequiredFieldValidator></td>
                                            <td style="color: #000000" width="24%">&nbsp;
                                                <asp:LinkButton ID="lb_checkAvailability" OnClick="lb_checkAvailability_Click" runat="server"
                                                    ValidationGroup="class">Check availability</asp:LinkButton></td>
                                            <td style="width: 159px">
                                                <asp:Label ID="lab_availability" runat="server"></asp:Label></td>
                                        </tr>

                                        <tr class="tr2">
                                            <td width="2%" height="25"></td>
                                            <td align="right" style="display: none;" width="21%">Maximum Age(Years)* :</td>
                                            <td style="width: 159px">
                                                <%-- <igtxt:WebNumericEdit ID="txtMaxAge" runat="server" Width="46px" MaxLength="4">
                                                </igtxt:WebNumericEdit>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="class"
                                                    SetFocusOnError="True" ErrorMessage="Maximum age is required" Display="Dynamic"
                                                    ControlToValidate="txtMaxAge"></asp:RequiredFieldValidator>
                                                --%>
                                            </td>
                                            <td width="24%"></td>
                                            <td style="width: 159px"></td>
                                        </tr>






                                        <tr class="tr2">
                                            <td height="25">&nbsp;</td>
                                            <td align="right">Comments :</td>
                                            <td colspan="7">
                                                <label>
                                                    <asp:TextBox ID="ta_comments" runat="server" CssClass="textarea" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr class="tr1">
                                            <td style="height: 25px" width="2%"></td>
                                            <td style="height: 25px" width="21%"></td>
                                            <td style="width: 159px; height: 25px" align="right">&nbsp;
                                                <asp:Button ID="but_saveClass" OnClick="but_saveClass_Click" runat="server" CssClass="btn btn-primary"
                                                    Text="Save" ValidationGroup="class"></asp:Button>
                                                &nbsp;
                                                <asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                                                    CausesValidation="False" Text="Cancel"></asp:Button>
                                            </td>
                                            <td style="height: 25px" width="24%"></td>
                                            <td style="width: 159px; height: 25px"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top"></td>
                    </tr>
                    <tr>
                        <td id="TD2" valign="top" runat="server">
                            <asp:Panel ID="pnlAssignedSubjects" runat="server" Visible="false">
                                <table style="width: 100%">
                                    <tr>
                                        <td id="titlesection" class="titlesection" runat="server">Assigned Subjects
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td align="right">
                                            <asp:LinkButton ID="btnShowAllSubj" runat="server" OnClick="btnShowAllSubj_Click">Show All Subjects</asp:LinkButton>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvAssignedSubjects" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView"
                                                HorizontalAlign="Center" EmptyDataText="No record found.">
                                                <Columns>
                                                    <asp:BoundField DataField="Subject_Id" HeaderText="Subject_ID">
                                                        <ItemStyle CssClass="hide" />
                                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Subject_Code" HeaderText="Subject Code"></asp:BoundField>--%>
                                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name"></asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnUnAssign" runat="server" OnClientClick="return confirm('Are you sure?');" OnClick="btnUnAssign_Click">UnAssign</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="tr1" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                                <SelectedRowStyle CssClass="tr_select" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td id="TD3" valign="top" runat="server">
                            <asp:Panel ID="pnlAllSubjects" runat="server" Visible="false">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="titlesection">Available Subjects
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="dg_subject" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                                Height="100%" OnRowCommand="dg_subject_RowCommand" PageSize="50" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Subject_Id" HeaderText="Subject" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                    <asp:TemplateField HeaderText="#">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Subject_Code" HeaderText="Subject Code" />
                                                    <asp:ButtonField CommandName="name" DataTextField="Subject_Name" HeaderText="Subject Name" />
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <RowStyle CssClass="tr1" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                            <asp:Label ID="Label1" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnAssign" OnClick="btnAssign_Click" runat="server" CssClass="button"
                                                Text="Assign Selected Subjects" CausesValidation="false"></asp:Button>
                                            &nbsp;
                                                <asp:Button ID="btnCancelAssign" OnClick="btnCancelAssign_Click" runat="server" CssClass="button"
                                                    CausesValidation="False" Text="Cancel"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <%--<tr>
                        <td id="TD4" valign="top" colspan="7" runat="server">
                            <asp:Panel ID="pnlAssignSubjects" runat="server" Visible="false">
                                     <tr>
                                        <td class="titlesection">
                                          Assign New Subjects
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                       
                                        <td>
                                            Assign New Subject
                                        </td> 
                                        <td style="width:100%">
                                            <asp:label runat="server" Text="Class Name"></asp:label>
                                        </td>
                                        <td align="left">
                                            <asp:label runat="server" Text="Subject"></asp:label>
                                        </td>
                                        <td  align="left">
                                         
                                        </td >
                                         <td  align="left"">
                                            <asp:Button runat="server" ID="btnassignsub" OnClick="btnassignsub_Click" Text="Assign Subject" CssClass="btn btn-primary" /> </td>
                                        <td width="24%">
                                        </td>
                                      
                                    </tr>
                               
                            </asp:Panel>
                        </td>
                    </tr>--%>
                    <tr class="tr1">

                        <asp:Panel ID="pnlAssignSubjects" runat="server" Visible="false">

                            <td class="titlesection">Assign Subject
                            </td>
                            <tr style="margin-top: 20px">
                                <td>
                                    <asp:Label ID="Label2" runat="server">Class Name*:</asp:Label><asp:Label runat="server" ID="lblClassName"></asp:Label>
                                    <asp:DropDownList ID="list_Section" runat="server" CssClass="dropdownlist" ValidationGroup="s"
                                        OnSelectedIndexChanged="list_Section_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" ForeColor="Red"
                                        ErrorMessage="Select Subject First" Display="Dynamic" ControlToValidate="list_Section"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr style="margin-left: 150px;">
                                <td>
                                    <asp:Button runat="server" ID="btnassignsub" ValidationGroup="s" Style="margin-left: 35%; margin-top: 20px" OnClick="btnassignsub_Click" Text="Assign Subject" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                        </asp:Panel>
                    </tr>
                    <tr class="buttonsection">
                        <td style="height: 22px" class="label" align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </tbody>
            </table>
            <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                Enabled="false">
            </cc1:ModalPopupExtender>
            <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
            <asp:Panel ID="msgBox" runat="server" Visible="False" Width="400">
                <table cellspacing="0" cellpadding="0" width="400" border="0">
                    <tbody>
                        <tr>
                            <td style="background-repeat: no-repeat; height: 25px" valign="middle" background="../images/popup_top.png">
                                <asp:Panel Style="cursor: move" ID="msgDrag" runat="server" Width="100%" Height="25px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="height: 25px"></td>
                                            <td style="height: 25px;" align="right">
                                                <asp:Image Style="cursor: pointer;" ID="msgCross" runat="server" ImageUrl="~/images/btncross.jpg" />
                                            </td>
                                            <td style="height: 25px; width: 2px;"></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-repeat: repeat-y" background="../images/popup_center.jpg">
                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 1px; height: 14px"></td>
                                            <td style="width: 10px; height: 14px"></td>
                                            <td style="width: 5px; height: 14px"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 10px"></td>
                                            <td>
                                                <asp:Label ID="msgNote" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 10px"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1px; height: 17px"></td>
                                            <td style="width: 10px; height: 17px"></td>
                                            <td style="width: 5px; height: 17px"></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="background-repeat: repeat-y" align="right" background="../images/popup_center.jpg">
                                <asp:Button ID="msgOK" runat="server" Width="75px" Text="OK"></asp:Button>
                                <asp:Button ID="msgNo" runat="server" Width="75px" Text="No" Visible="False"></asp:Button>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img height="4" src="../images/popup_bot.png" width="400" alt="img" /></td>
                        </tr>

                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>


