<%@ Page Title="Dashboard BI Strength" Language="C#" MasterPageFile="~/PresentationLayer/MasterPageBIDashboard.master"
    AutoEventWireup="true" CodeFile="dashboardBIFinancials.aspx.cs" Inherits="PresentationLayer_BIDashboard_dashboardBIFinancials" Theme="BlueTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Coming Soon</title>
        <%--<link rel="stylesheet" href="styles.css">--%>

        <style type="text/css">
            /*body {
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                color: #333;
                display: flex;
                align-items: center;
                justify-content: center;
                height: 100vh;
                margin: 0;
            }  
            */

            .container {
                text-align: center;
                background: white;
                padding: 40px;
                border-radius: 8px;
            }

            h1 {
                font-size: 3em;
                margin: 0;
                color: #333;
                text-align: center;
            }

            p {
                font-size: 1.2em;
                margin: 10px 0;
                text-align: center;
            }

            .countdown {
                margin-top: 20px;
            }

            #timer {
                display: flex;
                justify-content: center;
                margin-top: 10px;
            }

            .time {
                font-size: 2em;
                margin: 0 10px;
                background: #333;
                color: white;
                padding: 10px;
                border-radius: 4px;
            }

            #days {
                background: #f44336;
            }

            #hours {
                background: #ff9800;
            }

            #minutes {
                background: #4caf50;
            }

            #seconds {
                background: #2196f3;
            }
        </style>
        <script type="text/javascript">
            function updateCountdown() {
                const endDate = new Date('2024-12-31T23:59:59'); // Set your target date and time
                const now = new Date();
                const remainingTime = endDate - now;

                if (remainingTime <= 0) {
                    document.querySelector('.container').innerHTML = '<h1>We have launched!</h1>';
                    return;
                }

                const days = Math.floor(remainingTime / (10000 * 60 * 60 * 24));
                const hours = Math.floor((remainingTime % (10000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                const minutes = Math.floor((remainingTime % (10000 * 60 * 60)) / (1000 * 60));
                const seconds = Math.floor((remainingTime % (10000 * 60)) / 1000);

                document.getElementById('days').textContent = `${days}d`;
                document.getElementById('hours').textContent = `${hours}h`;
                document.getElementById('minutes').textContent = `${minutes}m`;
                document.getElementById('seconds').textContent = `${seconds}s`;
            }

            //setInterval(updateCountdown, 1000);
            //updateCountdown(); // Initial call to display the countdown immediately
</script>
    </head>
    <body>
        <div class="container">
            <h1>Coming Soon</h1>
            <p>This page is currently under construction. Stay tuned!</p>
            <%--<div class="countdown">
                <p>Launches in:</p>
                <div id="timer">
                    <div class="time" id="days"></div>
                    <div class="time" id="hours"></div>
                    <div class="time" id="minutes"></div>
                    <div class="time" id="seconds"></div>
                </div>
            </div>--%>
        </div>
    </body>
    </html>
</asp:Content>