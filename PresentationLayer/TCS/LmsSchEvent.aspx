<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsSchEvent.aspx.cs" Inherits="PresentationLayer_TCS_LmsSchEvent" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Teacher Scheduling"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr style="width: 100%">
                                       <%-- <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>--%>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" OnClick="btnCompose_Click">Add New</asp:LinkButton>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tr style="width: 100%">
                                                    <td align="right" style="height: 19px; text-align: right; width: 40%">
                                                       <%-- Work Site :--%>
                                                    </td>
                                                    <td align="right" colspan="13" style="height: 19px; text-align: right; width: 60%">
                                                        <asp:DropDownList ID="ddlWorkSite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkSite_SelectedIndexChanged"
                                                            Width="200px" Visible="False">
                                                        </asp:DropDownList>
                                                        <img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                                                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" 
                                                        style="height: 19px; text-align: right; width: 40%; color: #0000FF; font-size: small;">
                                                          Work Site :
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Label ID="lblWorksitename" runat="server" Font-Size="Small" 
                                                            ForeColor="#0000CC"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">
                                            Teacher Scheduling Information
                                        </td>
                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="gvDetail_PageIndexChanging"
                                                PageSize="15" SkinID="GridView" Width="100%" onsorting="gvDetail_Sorting">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:BoundField DataField="Event_ID" HeaderText="Event_ID" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="WrkTool_ID" HeaderText="WrkTool_ID" Visible="False"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EventTitle" HeaderText="EventTitle"
                                                        HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EventType" HeaderText="EventType">
                                                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FrequencyType" HeaderText="FrequencyType">
                                                        <HeaderStyle Width="15px" />
                                                        <ItemStyle Width="15px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EventDate" HeaderText="EventDate">
                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" >
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                                                    <asp:BoundField DataField="Message" HeaderText="Message" />
                                                    <asp:BoundField DataField="EventLocation" HeaderText="EventLocation" />
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("Event_ID") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("Event_ID") %>'
                                                                ImageUrl="~/images/delete.gif" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <SelectedRowStyle CssClass="tr_select" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                            <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trCDT" runat="server" visible="false">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Add / Update Teacher Scheduling
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                            <table>
                                                 <tr id="trDayType" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                       Event Title :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtTitle" runat="server" 
                                                                Width="250px" ></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>



                                                        

                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>

                                                <tr id="trDate" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;;width:25%">
                                                        &nbsp;Date:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Enter Date"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr id="trstarttime" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;;width:25%">
                                                        Start Time:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtStartTime" runat="server" ToolTip="Enter Date" 
                                                            ontextchanged="txtStartTime_TextChanged"></asp:TextBox>
                                                             <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtStartTime"
                                Mask="99:99"
                                MaskType="Time"
                                CultureName="en-us"
                                MessageValidatorTip="true"
                                AcceptAMPM="true"
                                runat="server">
        </cc1:MaskedEditExtender>


                                                       <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartTime"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>--%>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStartTime" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                 <tr id="trevduration" runat="server" visible="false">
                                                        
                                                        <td align="right"  style="width: 350px; height: 18px" valign="top">
                                                            Event Duration :</td>
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_Hour" runat="server" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px" onselectedindexchanged="list_Hour_SelectedIndexChanged">
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                                <asp:ListItem>8</asp:ListItem>
                                                                <asp:ListItem>9</asp:ListItem>
                                                                <asp:ListItem>10</asp:ListItem>
                                                                <asp:ListItem>11</asp:ListItem>
                                                                <asp:ListItem>12</asp:ListItem>
                                                                <asp:ListItem>13</asp:ListItem>
                                                                <asp:ListItem>14</asp:ListItem>
                                                                <asp:ListItem>15</asp:ListItem>
                                                                <asp:ListItem>16</asp:ListItem>
                                                                <asp:ListItem>17</asp:ListItem>
                                                                <asp:ListItem>18</asp:ListItem>
                                                                <asp:ListItem>19</asp:ListItem>
                                                                <asp:ListItem>20</asp:ListItem>
                                                                <asp:ListItem>21</asp:ListItem>
                                                                <asp:ListItem>22</asp:ListItem>
                                                                <asp:ListItem>23</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; Hours</td>

                                                       
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_minute" runat="server" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px">
                                                                <asp:ListItem>0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                                <asp:ListItem>8</asp:ListItem>
                                                                <asp:ListItem>9</asp:ListItem>
                                                                <asp:ListItem>10</asp:ListItem>
                                                                <asp:ListItem>11</asp:ListItem>
                                                                <asp:ListItem>12</asp:ListItem>
                                                                <asp:ListItem>13</asp:ListItem>
                                                                <asp:ListItem>14</asp:ListItem>
                                                                <asp:ListItem>15</asp:ListItem>
                                                                <asp:ListItem>16</asp:ListItem>
                                                                <asp:ListItem>17</asp:ListItem>
                                                                <asp:ListItem>18</asp:ListItem>
                                                                <asp:ListItem>19</asp:ListItem>
                                                                <asp:ListItem>20</asp:ListItem>
                                                                <asp:ListItem>21</asp:ListItem>
                                                                <asp:ListItem>22</asp:ListItem>
                                                                <asp:ListItem>23</asp:ListItem>
                                                                <asp:ListItem>24</asp:ListItem>
                                                                <asp:ListItem>25</asp:ListItem>
                                                                <asp:ListItem>26</asp:ListItem>
                                                                <asp:ListItem>27</asp:ListItem>
                                                                <asp:ListItem>28</asp:ListItem>
                                                                <asp:ListItem>29</asp:ListItem>
                                                                <asp:ListItem>30</asp:ListItem>
                                                                <asp:ListItem>31</asp:ListItem>
                                                                <asp:ListItem>32</asp:ListItem>
                                                                <asp:ListItem>33</asp:ListItem>
                                                                <asp:ListItem>34</asp:ListItem>
                                                                <asp:ListItem>35</asp:ListItem>
                                                                <asp:ListItem>36</asp:ListItem>
                                                                <asp:ListItem>37</asp:ListItem>
                                                                <asp:ListItem>38</asp:ListItem>
                                                                <asp:ListItem>39</asp:ListItem>
                                                                <asp:ListItem>40</asp:ListItem>
                                                                <asp:ListItem>41</asp:ListItem>
                                                                <asp:ListItem>42</asp:ListItem>
                                                                <asp:ListItem>43</asp:ListItem>
                                                                <asp:ListItem>44</asp:ListItem>
                                                                <asp:ListItem>45</asp:ListItem>
                                                                <asp:ListItem>46</asp:ListItem>
                                                                <asp:ListItem>47</asp:ListItem>
                                                                <asp:ListItem>48</asp:ListItem>
                                                                <asp:ListItem>49</asp:ListItem>
                                                                <asp:ListItem>50</asp:ListItem>
                                                                <asp:ListItem>51</asp:ListItem>
                                                                <asp:ListItem>52</asp:ListItem>
                                                                <asp:ListItem>53</asp:ListItem>
                                                                <asp:ListItem>54</asp:ListItem>
                                                                <asp:ListItem>55</asp:ListItem>
                                                                <asp:ListItem>56</asp:ListItem>
                                                                <asp:ListItem>57</asp:ListItem>
                                                                <asp:ListItem>58</asp:ListItem>
                                                                <asp:ListItem>59</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp; Minutes</td>
                                                        
                                                    </tr>

                                                <tr id="TrDate2" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        End Time:
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtEndTime" runat="server" ToolTip="Enter Date" 
                                                            ontextchanged="txtEndTime_TextChanged"></asp:TextBox>

                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="txtEndTime"
                                Mask="99:99"
                                MaskType="Time"
                                CultureName="en-us"
                                MessageValidatorTip="true"
                                AcceptAMPM="true"
                                runat="server">
        </cc1:MaskedEditExtender>

                                                       <%-- <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtEndTime" 
                                                            Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>--%>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEndTime" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                               
                                                <tr id="trCDTEnt" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Message:
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 300px; text-align: left;">
                                                        
                                                        &nbsp;<cc2:Editor ID="Editor1" runat="server" />
                                                    </td>
                                                </tr>

                                                <tr id="treventhead" runat="server" visible="false">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Event Type And Location
                                        </td>
                                    </tr>
                                     <tr id="Treventtype" runat="server" visible="false">
                                                        
                                                        <td align="right"  style="width: 350px; height: 18px" valign="top">
                                                            Event Type :</td>
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_EventType" runat="server" AutoPostBack="True" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>


                                               <tr id="treventloc" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Event Location :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtEventLoc" runat="server" 
                                                                Width="159px" ></asp:TextBox>
                                                                </tr>
                                                                 <tr id="trfreqhead" runat="server" visible="false">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Manage Frequency
                                        </td>
                                    </tr>

                                    <tr id="Trfreqevent" runat="server" visible="false">
                                                        
                                                        <td align="right"  style="width: 350px; height: 18px" valign="top">
                                                            Frequency Of Event :</td>
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_Frqtype" runat="server" AutoPostBack="True" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px" onselectedindexchanged="list_Frqtype_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>


                                                     <tr id="trevery" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Every :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtEvery" runat="server" 
                                                                Width="159px" ></asp:TextBox>
                                                                <cc1:NumericUpDownExtender ID="NumericUpDownExtender4" Width="50" TargetControlID="txtEvery"
                                                        Maximum="31" Minimum="1" Tag="1" runat="server">
                                                    </cc1:NumericUpDownExtender>
                                                    <asp:Label ID="lblFreqGap" runat="server" Text="Event occures once."></asp:Label>
                                                                </td>
                                                                </tr>

                                                                 <tr id="trend" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        <strong>Ends :</strong>
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        &nbsp;</td>
                                                                </tr>

<tr id="trafter" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        After :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtAfter" runat="server" 
                                                                Width="159px" ></asp:TextBox>
                                                                <cc1:NumericUpDownExtender ID="NumericUpDownExtender3" Width="50" TargetControlID="txtAfter"
                                                                    Maximum="100" Minimum="1" Tag="1" runat="server">
                                                                </cc1:NumericUpDownExtender>

                                                                </td>
                                                                </tr>

                                                                 <tr id="tron" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        On :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtOn" runat="server" 
                                                                Width="159px" ></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtOn_CalendarExtender" runat="server" TargetControlID="txtOn"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>

                                                                </td>
                                                                </tr>

                                                                 <tr id="Trmodftype" runat="server" visible="false">
                                                        
                                                        <td align="right"  style="width: 350px; height: 18px" valign="top">
                                                            Modification Type :</td>
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_Modifytype" runat="server" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px">
                                                                <asp:ListItem Value="Modified Only This Occurrence">Modified Only This 
                                                                Occurrence</asp:ListItem>
                                                                <asp:ListItem>Modified All Occurrences</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>

                                                     <tr id="Trremove" runat="server" visible="false">
                                                        
                                                        <td align="right"  style="width: 350px; height: 18px" valign="top">
                                                            Removal Type :</td>
                                                        <td  style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_Removetype" runat="server" 
                                                                CssClass="dropdownlist" 
                                                                 Width="159px" 
                                                                Height="19px">
                                                                <asp:ListItem>Remove Only This Occurrence</asp:ListItem>
                                                                <asp:ListItem>Remove All Occurrences</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>

                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTitle" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>



                                                        

                                                    </td>
                                                    
                                                </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trGVOpt" runat="server" visible="false">
                                        <td align="right" colspan="13" style="height: 19px; text-align: right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="but_save_Click"
                                ValidationGroup="a" Text="Save" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                        </td>
                    </tr>
                    <tr id="btnGen" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                            &nbsp;
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
