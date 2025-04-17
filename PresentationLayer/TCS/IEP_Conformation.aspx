<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IEP_Conformation.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Conformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="Link3" rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.css"
        runat="server" />
    <link id="Link1" rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css"
        runat="server" />
    <link runat="server" id="link2" href="https://cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.min.css"
        rel="stylesheet" type="text/css" />

    <!--new file-->
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css" />
    <link runat="server" id="link7" href="https://cdn.datatables.net/buttons/2.0.0/css/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />

    <!--new file-->

    <link id="Link4" rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css"
        runat="server" />
    <link id="Link5" rel="stylesheet" runat="server" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"
        integrity="sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ=="
        crossorigin="anonymous" />
    <link id="Link6" rel="stylesheet" runat="server" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css"
        integrity="sha384-aUGj/X2zp5rLCbBxumKTCw2Z50WgIr1vs/PFN4praOTvYXWlVyh2UtNUU0KAUhAX"
        crossorigin="anonymous" />
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">


        <div class="row marginrow">



            <div class="row text-center marginrow">
                <img src="Component_Marks/ReportCard/images/newlogo.png" class="logos" />

            </div>
            <div class="row text-center marginrow" runat="server" id="dv1" visible="false">
                <div style="margin-top: 10px;">

                    <h1 class="text-center thanku">Thank you for Your Acknowledgement</h1>
                    <i class="fa fa-check main-content__checkmark tick"></i>
                    <h3 class="text-center txtrq">Your Request has been Received</h3>
                </div>
            </div>

            <div class="row text-center marginrow" runat="server" id="DV2" visible="false">
                <div style="margin-top: 10px;">

                    <h1 class="text-center thanku">Something was wrong</h1>
                   <i class="fa fa-remove main-content__checkmark tick-danger text-danger"></i>
                </div>
            </div>


        </div>

    </form>





    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script|Source+Sans+Pro" rel="stylesheet">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>



    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"></script>

    <!--new file-->

    <script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.0/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>

    <script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.0/js/buttons.html5.min.js"></script>
    <!--new file-->
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>

    <script src="Component_Marks/ReportCard/jquery-ui-1.10.4.custom.js" type="text/JavaScript" language="javascript"></script>
    <script src="Component_Marks/ReportCard/jquery.PrintArea.js" type="text/JavaScript" language="javascript"></script>

    <link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/css/ui-lightness/jquery-ui-1.10.4.custom.css" />

    <link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/SalmanReport.css" />
    <!--PrintArea3 SalmanReport-->
    <link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/Raja_iep_report.css" />
    <!--PrintArea3 Raja IEP Report-->
    <%--<link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/Bifraction_Letter.css" />--%>
    <link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/media_all.css" media="all" />
    <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="" href="Component_Marks/ReportCard/empty.css" />
    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="noPrint" href="Component_Marks/ReportCard/noPrint.css" />
    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/media_none.css" media="xyz" />
    <!-- N : media not in [all,print,empty,undefined] -->
    <link type="text/css" href="Component_Marks/ReportCard/no_rel.css" media="print" />
    <!-- N : no rel attribute -->
    <link type="text/css" href="Component_Marks/ReportCard/no_rel_no_media.css" />
    <!-- N : no rel, no media attributes -->
    <style>
        .thanku {
            font-family: fantasy;
            text-transform: uppercase;
        }

        .logos {
            width: 15%;
            margin-top: 10px !important;
        }

        .themed {
            background: #2980B9; /* fallback for old browsers */
            background: -webkit-linear-gradient(to right, #FFFFFF, #6DD5FA, #2980B9); /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to right, #FFFFFF, #6DD5FA, #2980B9); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        }

        .marginrow {
            margin: 0px !important;
        }

        .tick {
            font-size: 200px;
            color: green;
        }
        .tick-danger {
            font-size: 200px;
            color: red;
        }
        .txtrq {
            text-transform: uppercase;
            font-family: system-ui;
        }
        /***new*/
        * {
            box-sizing: border-box;
            /* outline:1px solid ;*/
        }

        body {
            background: #ffffff;
            background: linear-gradient(to bottom, #ffffff 0%,#e1e8ed 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#e1e8ed',GradientType=0 );
            height: 100%;
            margin: 0;
            background-repeat: no-repeat;
            background-attachment: fixed;
        }

        .wrapper-1 {
            width: 100%;
            height: 100vh;
            display: flex;
            flex-direction: column;
        }

        .wrapper-2 {
            padding: 30px;
            text-align: center;
        }

        h1 {
            font-family: 'Kaushan Script', cursive;
            font-size: 4em;
            letter-spacing: 3px;
            color: #2957a4;
            margin: 0;
            margin-bottom: 20px;
        }

        .wrapper-2 p {
            margin: 0;
            font-size: 1.3em;
            color: #aaa;
            font-family: 'Source Sans Pro', sans-serif;
            letter-spacing: 1px;
        }

        .go-home {
            color: #fff;
            background: #5892FF;
            border: none;
            padding: 10px 50px;
            margin: 30px 0;
            border-radius: 30px;
            text-transform: capitalize;
            box-shadow: 0 10px 16px 1px rgba(174, 199, 251, 1);
        }

        .footer-like {
            margin-top: auto;
            background: #D7E6FE;
            padding: 6px;
            text-align: center;
        }

            .footer-like p {
                margin: 0;
                padding: 4px;
                color: #5892FF;
                font-family: 'Source Sans Pro', sans-serif;
                letter-spacing: 1px;
            }

                .footer-like p a {
                    text-decoration: none;
                    color: #5892FF;
                    font-weight: 600;
                }

        @media (min-width:360px) {
            h1 {
                font-size: 4.5em;
            }

            .go-home {
                margin-bottom: 20px;
            }
        }

        @media (min-width:600px) {
            .content {
                max-width: 1000px;
                margin: 0 auto;
            }

            .wrapper-1 {
                height: initial;
                max-width: 620px;
                margin: 0 auto;
                margin-top: 50px;
                box-shadow: 4px 8px 40px 8px rgba(88, 146, 255, 0.2);
            }
        }
        /**new*/
    </style>
</body>
</html>
