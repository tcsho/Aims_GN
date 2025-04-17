<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Tcs_Mobile_App_Dashboard2.aspx.cs" Inherits="PresentationLayer_Tcs_Mobile_App_Dashboard2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <contenttemplate>
      <!DOCTYPE html>
      <html lang="en">
         <head>
            <title>The City School</title>
            <link rel="stylesheet" href="mobileappdashboard.css">
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <!--Default installation-->
            <link rel="stylesheet" href="../Styles/iep_dashboardfile/jquery-ui.min.css" />
            <link rel="stylesheet" href="../Styles/iep_dashboardfile/bootstrap/css/bootstrap.min.css" />
            <link rel="stylesheet" href="../Styles/iep_dashboardfile/lobipanel.css" />
         </head>
         <body>
            <br />
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
               border="0">
               <tbody>
                  <tr align="center">
                     <td style="height: 22px" class="titlesection" colspan="3">
                        <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                           Visible="true" Font-Overline="False" Class="formheading">Please Select Criteria.</asp:Label>
                     </td>
                     
                    
                        
                    
                  </tr>
                 
               </tbody>
            </table>
              <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
               border="0">
               <tbody>
                <tr align="center">
                    <td>
                       <div class="dashboard">
                           <div class="row" style="margin-top:10px;margin-bottom:10px;">
                               <div class="dropdown col-lg-4">
                                 <label for="category">Select Session:</label>
                                 <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True"
                                 CssClass="dropdownlist form-control"
                                 Width="100%">
                                </asp:DropDownList>
                                             
                              </div>
                              <div class="dropdown col-lg-4">
                                 <label for="category">Select Region:</label>
                                     <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                     OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%">
                                     </asp:DropDownList>
                              </div>
                              <div class="dropdown col-lg-4">
                                 <label for="category">Select School:</label>
                                  <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True"
                                  CssClass="dropdownlist form-control"
                                  OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                  </asp:DropDownList>
                           
                              </div>
                              <div class="dropdown col-lg-4">
                                 <label for="category">Select Class:</label>
                                  <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                  CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                  Width="100%">
                                  </asp:DropDownList>
                                           
                              </div>
                              
                           </div>
                        </div>
                        </td>
                   </tr>



                 
               </tbody>
            </table>




            <br />
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
               border="0">
               <tbody>
                  <tr align="center">
                     <td style="height: 22px" class="titlesection" colspan="3">
                        <asp:Label ID="Label1" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                           Visible="true" Font-Overline="False" Class="formheading">Results based on above selection.</asp:Label>
                     </td>
                  </tr>
               </tbody>
            </table>            
            <%--****************************************--%>
          <%-- <div class="row margintp">
              
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Registered Students</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr" style="color:#40C057;"><img src="../../regdb.png"" alt="Icon"/>100</span>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">UnRegistered Students</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_under"style="color:#FA5252;"><img src="../../unregdb.png"" alt="Icon"/>20</span>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Above 60% Criteria</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_above">0</span>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Below 60% Criteria</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_below">0</span>

            </div>
        </div>
    </div>
</div>--%>

         
 <%--  <div class="row margintp">
    
   
                <div class="col-lg-12 col-md-4 col-sm-12 col-xs-12">
        <div class="heading-container">
            <h2 class="heading heading5 hind-font medium-font-weight">Registered & Unregistered Parents</h2>
        </div>
       <div class="row">
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr" style="color:#40C057;">
                    <asp:Label ID="lbltotalparents" runat="server" Text=""></asp:Label>
                </span>
            </div>
        </div>
    </div>
               <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo" id="specific-dashboard2" style="background:linear-gradient(#FA5252)">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Registered Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_under" style="color:#FA5252;">
               
                        <asp:Label ID="lblregisteredparents" runat="server" Text="" ></asp:Label>
                </span>
            </div>
        </div>
    </div>
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
        <div class="c-dashboardInfo" id="specific-dashboard" style="background:linear-gradient(#FA5252)">
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">UnRegistered Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_under" style="color:#40C057;">
                 
                        <asp:Label ID="lblunregisteredparents" runat="server" Text="" ></asp:Label>
                </span>
            </div>
        </div>
    </div>

</div>

    </div>


</div>--%>


             
<div class="row margintp">

    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr" style="color:#40C057;">100</span>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 right-align">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Registered Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_under" style="color:#40C057;">80</span>
            </div>
        </div>
    </div>

    <!-- Vertical Separator -->
    <div class="separator-vertical"></div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Total Students</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_above" style="color:#40C057;">80</span>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 right-align">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">Registered Students</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_below" style="color:#40C057;">70</span>
            </div>
        </div>
    </div>
</div>

<div class="row margintp">

    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">UnRegistered Parents</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_bifr" style="color:#FA5252;">20</span>
            </div>
        </div>
    </div>
  

    <!-- Vertical Separator -->
    <div class="separator-vertical"></div>
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
        <div>
            <div class="wrap">
                <h4 class="heading heading5 hind-font medium-font-weight c-dashboardInfo__title">UnRegistered Students</h4>
                <span class="hind-font caption-12 c-dashboardInfo__count total_above" style="color:#FA5252;">10</span>
            </div>
        </div>
    </div>
  
</div>


  
            <!--Default installation-->
            <script src="../Styles/iep_dashboardfile/jquery.1.11.min.js"></script>
            <script src="../Styles/iep_dashboardfile/jquery-ui.min.js"></script>
            <script src="../Styles/iep_dashboardfile/jquery.ui.touch-punch.min.js"></script>
            <script src="../Styles/iep_dashboardfile/bootstrap.min.js"></script>
            <script src="../Styles/lobipanel.js"></script>
            <script src="https://code.highcharts.com/highcharts.js"></script>
            <script src="https://code.highcharts.com/modules/data.js"></script>
            <script src="https://code.highcharts.com/modules/drilldown.js"></script>
            <script src="https://code.highcharts.com/modules/exporting.js"></script>
            <script src="https://code.highcharts.com/modules/export-data.js"></script>
            <script src="https://code.highcharts.com/modules/accessibility.js"></script>
          
         </body>
        <style>
            .highcharts-figure,
            .highcharts-data-table table {
                min-width: 320px;
                max-width: 800px;
                margin: 1em auto;
            }

            .highcharts-data-table table {
                font-family: Verdana, sans-serif;
                border-collapse: collapse;
                border: 1px solid #ebebeb;
                margin: 10px auto;
                text-align: center;
                width: 100%;
                max-width: 500px;
            }

            .highcharts-data-table caption {
                padding: 1em 0;
                font-size: 1.2em;
                color: #555;
            }

            .highcharts-data-table th {
                font-weight: 600;
                padding: 0.5em;
            }

            .highcharts-data-table td,
            .highcharts-data-table th,
            .highcharts-data-table caption {
                padding: 0.5em;
            }

            .highcharts-data-table thead tr,
            .highcharts-data-table tr:nth-child(even) {
                background: #f8f8f8;
            }

            .highcharts-data-table tr:hover {
                /*background: #f1f7ff;*/
            }

            input[type="number"] {
                min-width: 50px;
            }

            .highcharts-title {
                visibility: hidden;
            }

            .graphtxtbox {
                width: auto;
                height: auto;
                padding: 1px;
                line-height: 0px !important;
                font-size: 12px;
            }

            /**four boxes*/
            .c-dashboardInfo {
                margin-bottom: 15px;
            }

                .c-dashboardInfo .wrap {
                    background: #ffffff;
                    box-shadow: 2px 10px 20px rgba(0, 0, 0, 0.1);
                    border-radius: 7px;
                    text-align: center;
                    position: relative;
                    overflow: hidden;
                    padding: 27px 20px 25px 20px;
                    height: 100%;
                }


            .c-dashboardInfo__title,
            .c-dashboardInfo__subInfo {
                color: #6c6c6c;
                font-size: 1.18em;
            }

            .c-dashboardInfo span {
                display: block;
                text-align: center;
            }

            .c-dashboardInfo__count {
                font-weight: 600;
                font-size: 2.5em;
                /*line-height: 64px;*/
                color: #323c43;
            }

            .c-dashboardInfo .wrap:after {
                display: block;
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 10px;
                content: "";
            }

            .c-dashboardInfo:nth-child(1) .wrap:after {
                background: linear-gradient(82.59deg, #00c48c 0%, #00a173 100%);
            }





            .c-dashboardInfo__title svg {
                color: #d7d7d7;
                margin-left: 5px;
            }

            .MuiSvgIcon-root-19 {
                fill: currentColor;
                width: 1em;
                height: 1em;
                display: inline-block;
                font-size: 24px;
                transition: fill 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
                user-select: none;
                flex-shrink: 0;
            }

            .margintp {
                margin-top: 10px !important;
            }

            .panel-heading {
                background: #0c4da2 !important;
                color: #fff !important;
                /* border: 1px solid; */
                border-radius: 6px 6px 0px 0px;
            }

            .panel-default {
                border-radius: 9px !important;
            }

            .c-dashboardInfo__title {
                font-size: 20px !important;
            }

            .highcharts-credits {
                display: none !important;
            }
            /**four boxes*/
            .highcharts-figure {
                margin-top: 0px !important;
            }


            .heading-container {
                background-color: #87A7D1; /* Background color for the heading */
                padding: 10px; /* Padding for the heading */
                margin-bottom: 20px; /* Space between the heading and the columns */
            }

                .heading-container h2 {
                    margin: 0; /* Remove default margin from h2 */
                    color: #FFFFFF;
                }

            #specific-dashboard .wrap:after {
                display: block;
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 10px;
                content: "";
                background: linear-gradient(82.59deg, #FA5252 0%, #FA5252 100%);
            }

            .row.margintp {
                display: flex;
                justify-content: space-between;
                align-items: stretch;
            }

            .separator-vertical {
                width: 1px;
                background-color: #ddd;
                margin: 0 15px;
            }

            /* Ensure each col div takes equal width */
            .col-lg-3, .col-md-3, .col-sm-6, .col-xs-12 {
                flex: 1;
            }

            .right-align {
                text-align: right;
            }
        </style>
      </html>
   </contenttemplate>
</asp:Content>
