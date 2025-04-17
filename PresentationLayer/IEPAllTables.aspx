<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="IEPAllTables.aspx.cs" Inherits="PresentationLayer_IEPAllTables" %>

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
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="IEP Master Audit"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Student ID :
                                    </td>
                                    <td align="left" style="width: 60%">
                                        
                                        <asp:TextBox ID="txtStudentID" runat="server" Width="218px"></asp:TextBox>
                                        
                                        <%--<asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                             Width="218px">
                                        </asp:DropDownList>--%>
                                    </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        
                                    </td>
                                    <td align="left" style="width: 60%">
                                        
                                        <asp:Button Text="Show Record" ID="btnShowRecord" runat="server" OnClick="btnShowRecord_click" />
                                    </td>
                                </tr>

                               <%-- <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Class Section*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Subject*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Subject_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Term*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;">
                                        &nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">
                                        &nbsp;
                                       
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;
                                        <h3>IEP MASTER</h3>
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_details" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center" OnRowDataBound="dv_details_RowDataBound"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IEP_Id" HeaderText="IEP_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="Student_Id" HeaderText="Student #"></asp:BoundField>
                                                <asp:BoundField DataField="Region_Id" HeaderText="Region_Id"></asp:BoundField>
                                                
                                                <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" />
                                                <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" />
                                                <asp:BoundField DataField="Section_Id" HeaderText="Section_Id" />
                                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id" />
                                                <asp:BoundField DataField="Term_Group_Id" HeaderText="Term_Group_Id" />
                                                <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id" />
                                                <asp:BoundField DataField="Marks" HeaderText="Marks" />
                                                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                                                <asp:BoundField DataField="Weak_Topic_Areas" HeaderText="Weak_Topic_Areas" />
                                                <asp:BoundField DataField="Academic_Potential" HeaderText="Academic_Potential" />
                                                <asp:BoundField DataField="Suggested_Study_Hours" HeaderText="Suggested_Study_Hours" />
                                                <asp:BoundField DataField="Suggested_Work_Plan" HeaderText="Suggested_Work_Plan" />
                                                <asp:BoundField DataField="Academic_Concerns_Struggles" HeaderText="Academic_Concerns_Struggles" />
                                                <asp:BoundField DataField="Created_On" HeaderText="Created_On" />
                                                <asp:BoundField DataField="Remarks1" HeaderText="Remarks1" />
                                                <asp:BoundField DataField="Remarks2" HeaderText="Remarks2" />
                                                <asp:BoundField DataField="Remarks3" HeaderText="Remarks3" />
                                                <asp:BoundField DataField="Recommendation_Teacher_Name_1" HeaderText="Recommendation_Teacher_Name_1" />
                                                <asp:BoundField DataField="Recommendation_Teacher_Name_2" HeaderText="Recommendation_Teacher_Name_2" />
                                                <asp:BoundField DataField="Recommendation_Subject_Taught_1" HeaderText="Recommendation_Subject_Taught_1" />
                                                <asp:BoundField DataField="Recommendation_Subject_Taught_2" HeaderText="Recommendation_Subject_Taught_2" />
                                                <asp:BoundField DataField="Acknowledge_By_Class_Teacher" HeaderText="Acknowledge_By_Class_Teacher" />
                                                <asp:BoundField DataField="Acknowledge_On_Class_Teacher" HeaderText="Acknowledge_On_Class_Teacher" />
                                                <asp:BoundField DataField="Acknowledge_By_School_Head" HeaderText="Acknowledge_By_School_Head" />
                                                <asp:BoundField DataField="Acknowledge_On_School_Head" HeaderText="Acknowledge_On_School_Head" />
                                                <asp:BoundField DataField="Acknowledge_By_Counselor" HeaderText="Acknowledge_By_Counselor" />
                                                <asp:BoundField DataField="Acknowledge_On_Counselor" HeaderText="Acknowledge_On_Counselor" />
                                                <asp:BoundField DataField="Acknowledge_By_Parent" HeaderText="Acknowledge_By_Parent" />
                                                <asp:BoundField DataField="Acknowledge_On_Parent" HeaderText="Acknowledge_On_Parent" />
                                                <asp:BoundField DataField="batch_Id" HeaderText="batch_Id" />
                                                <asp:BoundField DataField="IsSubmit" HeaderText="IsSubmit" />
                                                <asp:BoundField DataField="Expected_Graduation_Year" HeaderText="Expected_Graduation_Year" />
                                                <asp:BoundField DataField="Progressto_A_Level" HeaderText="Progressto_A_Level" />
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>



                                   
                                </tr>
                                 <tr style="width: 100%">
                                  <td style="width: 100%">
                                        &nbsp;
                                      <h3>RAISEC</h3>
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_IepRaisec" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Type_Id" HeaderText="IEP_Type_Id"></asp:BoundField>
                                                <asp:BoundField DataField="Set_Id" HeaderText="Set_Id"></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Value" HeaderText="IEP_Value"></asp:BoundField>
                                                <asp:BoundField DataField="Entry_By" HeaderText="Entry_By"></asp:BoundField>
                                                <asp:BoundField DataField="Entry_On" HeaderText="Entry_On"></asp:BoundField>
                                               
                                                
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>
                                     </tr>


                                  <tr style="width: 100%">
                                  <td style="width: 100%">
                                        &nbsp;
                                      <h3>Counselor Recommendations</h3>
                                     
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_IEPC_Recom" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IEP_ECA_Id" HeaderText="IEP_ECA_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Id" HeaderText="IEP_Id"></asp:BoundField>
                                                <asp:BoundField DataField="Extra_Curricular_Activities" HeaderText="Extra_Curricular_Activities"></asp:BoundField>
                                                <asp:BoundField DataField="Activity_Title_and_Organization" HeaderText="Activity_Title_and_Organization"></asp:BoundField>
                                                <asp:BoundField DataField="Role_and_Responsibilities" HeaderText="Role_and_Responsibilities"></asp:BoundField>
                                                <asp:BoundField DataField="Hours_Week" HeaderText="Hours_Week"></asp:BoundField>
                                                <asp:BoundField DataField="Timeline" HeaderText="Timeline"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_By" HeaderText="Entery_By"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_On" HeaderText="Entery_On"></asp:BoundField>
                                                <asp:BoundField DataField="Organization" HeaderText="Organization"></asp:BoundField>
                                               
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>
                                     </tr>

                                 <tr style="width: 100%">
                                  <td style="width: 100%">
                                        &nbsp;
                                      <h3> Extra-Curricular Activities</h3>
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_IEPExtra_C" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IEP_ECA_Id" HeaderText="IEP_ECA_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Id" HeaderText="IEP_Id"></asp:BoundField>
                                                <asp:BoundField DataField="Extra_Curricular_Activities" HeaderText="Extra_Curricular_Activities"></asp:BoundField>
                                                <asp:BoundField DataField="Activity_Title_and_Organization" HeaderText="Activity_Title_and_Organization"></asp:BoundField>
                                                <asp:BoundField DataField="Role_and_Responsibilities" HeaderText="Role_and_Responsibilities"></asp:BoundField>
                                                <asp:BoundField DataField="Hours_Week" HeaderText="Hours_Week"></asp:BoundField>
                                                <asp:BoundField DataField="Timeline" HeaderText="Timeline"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_By" HeaderText="Entery_By"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_On" HeaderText="Entery_On"></asp:BoundField>
                                                <asp:BoundField DataField="Organization" HeaderText="Organization"></asp:BoundField>
                                               
                                                
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>
                                     </tr>
                                

                                       <tr style="width: 100%">
                                      <td style="width: 100%">
                                        &nbsp;
                                          <h3> HONOR AWARDS</h3>
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_IepHonorAwards" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IEP_HA_Id" HeaderText="IEP_HA_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Id" HeaderText="IEP_Id"></asp:BoundField>
                                                <asp:BoundField DataField="Award_Honor" HeaderText="Award_Honor"></asp:BoundField>
                                                <asp:BoundField DataField="Awarding_Body" HeaderText="Awarding_Body"></asp:BoundField>
                                                <asp:BoundField DataField="Year" HeaderText="Year"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_By" HeaderText="Entery_By"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_On" HeaderText="Entery_On"></asp:BoundField>
                                               
                                               
                                                
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>
                                     </tr>


                                  <tr style="width: 100%">
                                  <td style="width: 100%">
                                        &nbsp;
                                        <h3>DREAM UNIVERSITY</h3>
                                        <div style="overflow-x:auto;width:1200px">
                                             
                                         <asp:GridView ID="dv_IEP_DU" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="500" SkinID="GridView" Width="100%">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IEP_DU_Id" HeaderText="IEP_DU_Id" ></asp:BoundField>
                                                <asp:BoundField DataField="IEP_Id" HeaderText="IEP_Id"></asp:BoundField>
                                                <asp:BoundField DataField="SubType" HeaderText="SubType"></asp:BoundField>
                                                <asp:BoundField DataField="International" HeaderText="International"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_By" HeaderText="Entery_By"></asp:BoundField>
                                                <asp:BoundField DataField="Entery_On" HeaderText="Entery_On"></asp:BoundField>
                                              
                                               
                                                
                                               
                                               
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                        </div>
                                        
                                    </td>
                                     </tr>


                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
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
