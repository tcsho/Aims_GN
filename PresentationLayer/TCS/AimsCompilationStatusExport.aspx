<%@ Page Title="Compilation Status (AIMS)" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true"
    CodeFile="AimsCompilationStatusExport.aspx.cs" Inherits="PresentationLayer_TCS_AimsCompilationStatusExport" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .aims-comp-wrap { max-width: 720px; margin: 16px auto; padding: 0 12px; font-family: Arial, Helvetica, sans-serif; }
        .aims-comp-wrap p { color: #333; line-height: 1.45; }
        .aims-comp-wrap .btn-row { margin: 20px 0; display: flex; flex-wrap: wrap; gap: 12px; }
        .aims-comp-wrap .btn-row .btn { min-width: 220px; }
        .aims-comp-msg { margin-top: 12px; }
    </style>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="aims-comp-wrap">
        <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr>
                <td class="formheading">
                    <asp:Label ID="lblHeading" runat="server" CssClass="lblFormHead" Text="Compilation Status (AIMS)"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            Export lists from end-of-term compilation checks. Each button runs the corresponding database procedure and downloads an Excel file (.xls).
        </p>
        <div class="btn-row">
            <asp:Button ID="btnSuccessful" runat="server" CssClass="btn btn-primary" Text="Successful compilations" OnClick="btnSuccessful_Click" />
            <asp:Button ID="btnUnsuccessful" runat="server" CssClass="btn btn-primary" Text="Unsuccessful compilations" OnClick="btnUnsuccessful_Click" />
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="aims-comp-msg" ForeColor="Red" EnableViewState="false"></asp:Label>
    </div>
</asp:Content>
