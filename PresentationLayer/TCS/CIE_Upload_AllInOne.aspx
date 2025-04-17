<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="CIE_Upload_AllInOne.aspx.cs" Inherits="PresentationLayer_TCS_CIE_Upload_AllInOne"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 100%" width=".5%"></td>
                        <td id="tdFrmHeading" class="formheading">
                            <asp:Label ID="Label3" CssClass="lblFormHead" runat="server" Text="Upload CAIE BroadSheets "></asp:Label>
                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                border="0" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <%--                <tr style="width: 100%">
                    <td class="titlesection" align="left" colspan="2">
                        CIE Data Upload
                    </td>
                </tr>--%>
                <tr style="width: 100%">
                    <td style="vertical-align: top">
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr id="trMoId" runat="server">
                                <td class="TextLabelMandatory40">Main Organization* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                        Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfv_mOrg" runat="server" Width="200px" Enabled="False"
                                        ErrorMessage="Mian Org is a required Field" Display="Dynamic" ControlToValidate="ddl_MOrg"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trCountry" runat="server">
                                <td class="TextLabelMandatory40">Main Organization Country* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                        OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                        ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr id="tr2">
                                <td class="TextLabelMandatory40" valign="top">Academic Year* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Academic Year is a required Field" Display="Dynamic" ControlToValidate="ddlSession"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr4">
                                <td class="TextLabelMandatory40" valign="top">Result Month and Level* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlResultMonth" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlResultMonth_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Result Month is a required Field" Display="Dynamic" ControlToValidate="ddlResultMonth"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <%-- <tr id="UplodDesc" runat="server" visible="false">
                                <td style="font-size: x-large" colspan="2">Step 1: Select Academic Year.
                            <br />
                                    Step 2: Browse CIE excel file from local computer.
                            <br />
                                    Step 3: Click on "Fill Data" button.
                            <br />
                                    Step 4: After verification of data, click on "Upload Data on Server" button.
                                </td>

                            </tr>--%>
                            <tr id="UplodDesc" runat="server" visible="false">
                                <td style="font-size: small" colspan="2">Step 1: Select "Result Month and Level".
                            <br />
                                    Step 2: Click "Choose File" and browse the excel file to upload. If there are more than 10,000 records, divide them into separate sheets and name them "result1," "result2," etc. 
                            <br />
                                    Step 3: Click "Upload Data on Server."
                            <br />
                                    Step 4: Once the data has been uploaded, select "Mapping Data on Server" to begin mapping with ERP numbers.
                                </td>

                            </tr>
                            <tr>
                                <td>

                                    <label id="showerror" runat="server" style="color: red; font-size: large;"></label>

                                </td>

                            </tr>

                            <tr id="FileUploadGrid" runat="server" visible="false">
                                <td valign="top" align="center"></td>
                                <td>
                                    <asp:Button ID="btnSampleFile" class="button" runat="server" OnClick="btnsample_Click" Text="Download Sample File" Visible="false" />



                                    <strong style="display: none;">Select CIE Excel Template:                                   
                                    </strong>
                                    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                    <br />
                                    <asp:Button ID="btnUpload" runat="server" class="button"
                                        OnClick="btnUpload_Click" Text="Upload Data On Server" ValidationGroup="s" />
                                    <asp:Button ID="btnStudentMapping" runat="server" class="button"
                                        OnClick="btnStudentMapping_Click" Text="Mapping Data On Server" />
                                    <asp:Button ID="btnLoad" class="button" runat="server" OnClick="btnLoad_Click" Text="Upload Data on Server" Visible="false" />

                                    <br />

                                    <%--                                    <asp:GridView ID="GridView1" runat="server" 
                                        AllowPaging="True" AllowCustomPaging="True" 
                                        Width="768px" CellSpacing="3" PageSize="600000" AutoGenerateColumns="true"
                                        SkinID="GridView">
                                    </asp:GridView>--%>





                                </td>
                            </tr>


                            <tr id="tr3" runat="server">
                                <td valign="top" colspan="2" align="center">

                                    <asp:GridView ID="gvMatchStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-bordered table-hover table-sm ">
                                        <HeaderStyle Font-Bold="true" />
                                        <Columns>

                                            <asp:BoundField DataField="Id" HeaderText="Id">
                                                <%-- <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />--%>
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:TemplateField>


                                            <asp:BoundField DataField="TotalRecords" HeaderText="Total Records">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="TotalStudents" HeaderText="Total Students">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="MatchedStudents" HeaderText="Matched Students">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="NotMatchedStudents" HeaderText="Not Matched Students">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:TemplateField HeaderText="Show Records">
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnshow" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                        ForeColor="#004999" OnClick="btnShow_Click" CssClass="btn-lg"
                                                        ToolTip="Delete Record">
                                                    <i class="glyphicon glyphicon-list TextLabelMandatory40 text-primary"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                        ForeColor="#004999" OnClick="btndelete_Click" CssClass="btn-lg"
                                                        ToolTip="Delete Record">
                                                    <i class="glyphicon glyphicon-trash TextLabelMandatory40 text-danger"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>




                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-bordered table-hover table-sm ">
                                        <HeaderStyle Font-Bold="true" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:TemplateField>


                                            <asp:BoundField DataField="Centre" HeaderText="PK #">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Centre_Name" HeaderText="Centre Name">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Cand" HeaderText="Cand. #">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Candidate_Name" HeaderText="Candidate Name">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>



                                            <asp:BoundField DataField="Citzenship_No" HeaderText="Citzenship No">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Qual" HeaderText="Class Level">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Subject" HeaderText="Subject">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Result" HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Student_Id" HeaderText="Roll #">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="MappedFrom" HeaderText="Mapping Criteria">
                                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>

                                </td>
                            </tr>



                        </table>
                    </td>
                </tr>
            </table>
            <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                Enabled="false">
            </cc1:ModalPopupExtender>
            <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
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
