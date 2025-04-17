<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CEPD_Certificate.aspx.cs" Inherits="CEPD_Certificate" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Print Certificate</title>
<style>
    body {
        margin: 0;
        padding: 0;
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        background-color: #f0f0f0;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
    }
    #certificateContainer {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        width: 100%;
    }
    .certificate {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        width: 100%;
        max-width: 800px;
        background: white;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        overflow: hidden;
        position: relative;
        margin: 10px;
        page-break-inside: avoid; /* Avoid breaking inside the certificate */
    }
    .certificate-images {
        display: flex;
        width: 100%;
    }
    .certificate-images img {
        height: auto;
    }
    .certificate-images img:nth-child(1) {
        width: 60%;
    }
    .certificate-images img:nth-child(2) {
        width: 40%;
    }
    .certificate-content 
    {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        position: absolute;
        top: 10%;
        left: 10%;
        width: 80%;
        height: 80%;
        text-align: left;
        padding: 20px;
        box-sizing: border-box;
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
    .certificate-content h1 {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
       /* font-size: 125%;*/
        font-weight: normal;
        text-align: center;
        margin: 0;
        color: ghostwhite;
        position: absolute;
        bottom: 424px;
        left: 16px;
    }
    .certificate-content p {
        font-family: 'Times New Roman', Times, serif;
        font-size:16px;
        margin: 5px 0;
       /* font-size: 1em;*/
        font-weight: normal;
        color: #ffffff;
    }

    .certificate-content h4 {
        font-family: 'Times New Roman', Times, serif;
        font-size:19px;
        margin: 5px 0;
       /* font-size: 1em;*/
        font-weight: normal;
        color: #ffffff;
    }
    .certificate-content .name {
        font-family: 'Times New Roman', Times, serif;
        font-size:40px;
       /* font-size: 1.5em;*/
        color: #ff0000;
    }
    .footer {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        display: flex;
        justify-content: space-between;
        position: absolute;
        bottom: 1%;
        width: 45%;
        right: 10%;
        left: 30px;
        color: #ffffff;
        text-align: center;
    }
    .footer div {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        right: 10px;
    }
    .footer .line {
        font-family: 'Times New Roman', Times, serif;
        font-size:18px;
        border-top: 1px solid #fff;
        width: 94px;
        margin-top: 5px;
    }
    .no-print {
        display: block;
        position: fixed;
        top: 10px;
        right: 10px;
        padding: 10px 20px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        z-index: 1000;
    }
    @media print {
    @page {
        size: A4;
        margin: 0;
    }
    body, html {
        margin: 0;
        padding: 0;
        height: auto;
        overflow: hidden;
    }
    #certificateContainer {
        width: 100%;
        height: auto;
        display: block;
    }
    .certificate {
        width: 100%;
        height: 100vh;
        max-width: none;
        box-shadow: none;
        margin: 0;
        page-break-inside: avoid;
    }
    .certificate-content h1 {
         font-family: 'Times New Roman', Times, serif;
        font-size:18px;
       /* font-size: 125%;*/
        font-weight: normal;
        text-align: center;
        margin: 0;
        color: ghostwhite;
        position: absolute;
        /*font-size:18px;
        
        bottom: 100px;*/ /* Adjust this value as needed */
    }
    .certificate-images {
        display: flex;
        width: 100%;
        height: 100%;
    }
    .certificate-images img {
        width: 50%;
        height: 100%;
        object-fit: cover;
    }
    .certificate-content {
        width: 100%;
        padding: 20px;
        box-sizing: border-box;
    }
    .certificate-content h1 {
        font-size: 125%;
        font-weight: normal;
        text-align: center;
        margin: 0;
        color: white;
        position: absolute;
        bottom: 600px;
        left: 16px;
    }
     .certificate-content .name {
        font-family: 'Times New Roman', Times, serif;
        font-size:40px;
       /* font-size: 1.5em;*/
        color: #ff0000;
    }
    .certificate-content p {
        margin: 5px 0;
        font-size: 1em;
        font-weight: normal;
        color: #ffffff;
    }
    .no-print {
        display: none;
    }
}
    /*@media print {
        @page {
            size: A4;*/ /* Define the size of the print page */
            /*margin: 0;
        }
        body, html {
            margin: 0;
            padding: 0;
            height: auto;
            overflow: hidden;
        }
        #certificateContainer {
            width: 100%;
            height: auto;
            display: block;
        }
        .certificate {
            width: 100%;
            height: 100vh;  Ensure each certificate takes up a full page height 
            max-width: none;
            box-shadow: none;
            margin: 0;
            page-break-after: always;
            page-break-inside: avoid;  Ensure each certificate does not break within 
        }
      
    .certificate-content h1 {
        font-size: 20px;*/ /* Adjust font size for printing */
        /*bottom: 100px;*/ /* Adjust position for printing */
    /*}
        .certificate-images {
            display: flex;
            width: 100%;
            height: 100%;
        }
        .certificate-images img {
            width: 50%;
            height: 100%;
            object-fit: cover;
        }
        .certificate-content {
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }
        .certificate-content h1 {
            font-size: 125%;
            font-weight: bold;
            text-align: center;
            margin: 0;
            color: white;
            position: absolute;
            bottom: 600px;
            left: 16px;
        }
        .certificate-content p {
            margin: 5px 0;
            font-size: 1em;
            font-weight: bold;
            color: #ffffff;
        }
        .no-print {
            display: none;
        }
    }*/
</style>
</head>
<body>
    <button class="no-print" onclick="printCertificate()">Print Certificate</button>
    <div id="certificateContainer" runat="server"></div>
    <script>
        function printCertificate() {
            window.print();
        }
    </script>
</body>
</html>
