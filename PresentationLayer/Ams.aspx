<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Ams.aspx.cs" Inherits="PresentationLayer_AMS_Ams" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Attendance"></asp:Label>
                                        
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
                                    <td class="TextLabelMandatory40">Class*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="select_class" CssClass="dropdownlist" runat="server"  Width="217px"
                                            AutoPostBack="True"
                                            ToolTip="Select Class and Section" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </td>
                                </tr>




                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">Date*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:TextBox ID="datepicker" runat="server" data-zdp_readonly_element="false" CssClass="form-control datePicker_input" AutoPostBack="True" OnTextChanged="datepicker_TextChanged"   Width="217px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="datepicker_CalendarExtender" runat="server" TargetControlID="datepicker"
                                            Enabled="True" Format="MM/dd/yyyy">
                                        </cc1:CalendarExtender>

                                    </td>
                                </tr>



                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">View As*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="view_as" runat="server"
                                            CssClass="dropdownlist"
                                            AutoPostBack="true"
                                             Width="217px"
                                            OnSelectedIndexChanged="view_as_SelectedIndexChanged">
                                            <asp:ListItem Enabled="true" Text="Select View" Value=""></asp:ListItem>
                                            <asp:ListItem Text="daily" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Weekly" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Monthly" Value="3"></asp:ListItem>

                                        </asp:DropDownList>

                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
              <asp:GridView ID="gvAttnDaily" CssClass="table table-bordered"
                  OnRowCommand="gvAttnDaily_RowCommand" OnRowDataBound="gvAttnDaily_RowDataBound"
                  Style="width: 100%" runat="server" AutoGenerateColumns="false">
                  <Columns>

                      <asp:BoundField DataField="Attn_Id" HeaderText="Attn_Id">
                          <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                          <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                      </asp:BoundField>


                      <asp:BoundField DataField="AttnType_Id" HeaderText="AttnType_Id">
                          <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                          <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                      </asp:BoundField>
                      <asp:BoundField DataField="AttnType_Id" HeaderText="AttnType_Id">
                          <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                          <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="hide" />
                      </asp:BoundField>

                      <asp:TemplateField HeaderText="Sr. #">
                          <ItemTemplate>
                              <%# Container.DataItemIndex + 1 %>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center" />
                          <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:BoundField DataField="Student_Id" HeaderText="Roll Number">
                          <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="Name" HeaderText="Students">
                          <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                      </asp:BoundField>


                      <asp:TemplateField>
                          <HeaderTemplate>
                              Attandence                                                           
                          </HeaderTemplate>
                          <ItemTemplate>
                              <div id="track">
                                  <asp:LinkButton ID="oneDayAtt" CommandArgument='<%# Container.DataItemIndex %>' runat="server" CommandName="P" ForeColor="Green" Text="P" Font-Size="X-Large"></asp:LinkButton>
                              </div>
                          </ItemTemplate>
                          <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                      </asp:TemplateField>
                  </Columns>
                  <RowStyle CssClass="tr1" Font-Size="X-Large"></RowStyle>
                  <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                  <HeaderStyle Font-Size="Medium" />
              </asp:GridView>


                                        <asp:GridView ID="gvAttnWeekly" runat="server" Width="100%" SkinID="GridView" PageSize="150"
                                            HorizontalAlign="Center" AllowPaging="True" CssClass="table table-bordered"
                                            OnRowCreated="gvAttnWeekly_RowCreated" EnableViewState="true" OnRowDataBound="gvAttnWeekly_RowDataBound">
                                            <RowStyle CssClass="tr1" Font-Size="X-Large"></RowStyle>
                                            <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>

                                        </asp:GridView>
                                        <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>

                                        <asp:Button ID="btnSave" CssClass="btn btn-primary pull-right" runat="server" OnClick="btnSave_Click" Text="Save" />

                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">&nbsp;
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

