<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsSchEventMainStudentLevel.aspx.cs" Inherits="PresentationLayer_TCS_LmsSchEventMainStudentLevel" validateRequest="false" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>


<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <html>
<head>
    <title> </title>


  
<script type="text/javascript">

    
</script>
</head>
<body>

</body>
</html>

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Main Scheduling "></asp:Label>
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
                                    <td align="right" colspan="1" 
                                        style="height: 18px; text-align: right; width: 40%;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 60%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">

                                <tr>
                                <td>
                                &nbsp;&nbsp;
                                </td>
                                </tr>

                                 <tr style="width: 100%">
                                      
                                        
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" OnClick="btnSchForm_Click">Detail View Scheduling Event</asp:LinkButton>
                                        </td>
                                    </tr>

                                     <tr style="width: 100%">
                                                   
                                                    <td align="right" colspan="13" style="height: 19px; text-align: right; width: 60%">
                                                        <img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                                                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                                                    </td>
                                                </tr>



                                    

                                 <tr style="width: 100%">
                                       <%-- <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>--%>
                                        <td style="height: 18px; width: 40%; text-align: left" align="left" colspan="1">
                                             <div  align = "left" >
                                   
                                      &nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnPrevious" runat="server" CausesValidation="False" OnClick="btnPrevious_Click">Previous&nbsp;&nbsp;</asp:LinkButton>|
                                      &nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" OnClick="btnNext_Click">Next&nbsp;&nbsp;</asp:LinkButton>|
                                  
</div>
                                        </td>
                                    </tr>


                                     <tr>
                                <td>
                                &nbsp;&nbsp;
                                </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">
        <daypilot:daypilotcalendar 
                                             id="DayPilotCalendar1" 
                                             runat="server" 
                                             DataStartField="eventstart" 
                                             DataEndField="eventend"
                                             DataTextField="name" 
                                             DataValueField="id" 
                                             Days="10" 
                                             OnEventMove="DayPilotCalendar1_EventMove" 
                                            EventMoveHandling="CallBack" BackColor="#FFFFD5" BorderColor="#000000" CssClassPrefix="calendar_default" 
                                            DataIdField="id" DataSourceID="SqlDataSource2" DayFontFamily="Tahoma" 
                                            DayFontSize="10pt" DurationBarColor="Blue" EventBackColor="#FFFFFF" 
                                            EventBorderColor="#000000" EventClickHandling="PostBack" 
                                            EventFontFamily="Tahoma" EventFontSize="8pt" EventHoverColor="#DCDCDC" 
                                            EventResizeHandling="PostBack" HourBorderColor="#EAD098" 
                                            HourFontFamily="Tahoma" HourFontSize="16pt" HourHalfBorderColor="#F3E4B1" 
                                            HourNameBackColor="#ECE9D8" HourNameBorderColor="#ACA899" HoverColor="#FFED95" 
                                            NonBusinessBackColor="#FFF4BC" ScrollPositionHour="9" ShowEventStartEnd="True" 
                                            StartDate="2015-08-20" Width="100%">
    </daypilot:daypilotcalendar>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:isl_amsoConnectionString %>" 
                                            SelectCommand="LmsSchEventSelectAllForScheduleControl" 
                                            SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 75%">
                                       
                                       <div>


                                           

                                         </div>
                                         <div>
                                         </div>
                                    </td>
                                </tr>
                                <tr>
                                    <div>
                                    </div>
                                </tr>
                                </caption>
                               
                           
                                </div>
                               
                            </table>
                        </td>
                    </tr>
                    
                    </caption>
                </tbody>
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
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />
                    
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
  
  
</asp:Content>

 

