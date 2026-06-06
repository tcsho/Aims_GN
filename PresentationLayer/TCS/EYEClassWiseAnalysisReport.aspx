<%@ Page Title="EYE Classwise Analysis" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="EYEClassWiseAnalysisReport.aspx.cs" Inherits="PresentationLayer_TCS_EYEClassWiseAnalysisReport" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .eye-cwa-report { font-family: Arial, Helvetica, sans-serif; padding: 12px 0 20px; background: #f5f5f5; box-sizing: border-box; color: #222; }
        /* Master site uses span { color: #009900 } in style.css — force neutral text in this report */
        .eye-cwa-report span,
        .eye-cwa-report td,
        .eye-cwa-report th,
        .eye-cwa-report .titles h1,
        .eye-cwa-report .titles h2 {
            color: #222;
        }
        .eye-cwa-report .report-shell {
            max-width: 960px;
            margin: 0 auto;
            width: 100%;
            box-sizing: border-box;
        }
        .eye-cwa-report .report-shell .toolbar,
        .eye-cwa-report .report-shell .page {
            width: 100%;
            box-sizing: border-box;
        }
        .eye-cwa-report .page { background: #fff; border: 1px solid #ccc; padding: 20px 24px 28px; position: relative; }
        .eye-cwa-report .hdr-top {
            display: grid;
            grid-template-columns: minmax(72px, 120px) 1fr minmax(72px, 120px);
            align-items: start;
            column-gap: 10px;
            margin-bottom: 4px;
        }
        .eye-cwa-report .hdr-pad { min-height: 1px; }
        .eye-cwa-report .titles { text-align: center; padding: 0 4px; box-sizing: border-box; }
        .eye-cwa-report .hdr-logo-wrap { justify-self: end; text-align: right; line-height: 0; }
        .eye-cwa-report .hdr-logo-wrap .logo {
            display: block;
            max-width: 118px;
            max-height: 96px;
            width: auto;
            height: auto;
            object-fit: contain;
        }
        .eye-cwa-report .titles h1 { font-size: 22px; margin: 0 0 8px; font-weight: bold; }
        .eye-cwa-report .titles h2 { font-size: 17px; margin: 0; font-weight: bold; }
        .eye-cwa-report .meta { display: flex; justify-content: space-between; margin-top: 18px; margin-bottom: 16px; font-size: 14px; }
        .eye-cwa-report .meta span { flex: 1; }
        .eye-cwa-report .meta .center { text-align: left; }
        .eye-cwa-report .meta .term { text-align: center; }
        .eye-cwa-report .meta .session { text-align: right; }
        .eye-cwa-report table.rpt { width: 100%; border-collapse: collapse; font-size: 14px; }
        .eye-cwa-report table.rpt th, .eye-cwa-report table.rpt td { border: 1px solid #000; padding: 8px 10px; }
        .eye-cwa-report table.rpt th { background: #f0f0f0; font-weight: bold; text-align: center; }
        .eye-cwa-report table.rpt td.lbl { text-align: left; font-weight: bold; }
        .eye-cwa-report table.rpt td.num { text-align: center; }
        .eye-cwa-report tr.total td { font-weight: bold; }
        .eye-cwa-report .err { color: #b00020; margin-top: 12px; }
        .eye-cwa-report .err span { color: #b00020; }
        .eye-cwa-report .toolbar {
            margin-bottom: 14px;
            padding: 10px 24px;
            background: #fff;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-shadow: 0 1px 2px rgba(0,0,0,.04);
        }
        .eye-cwa-report .toolbar-inner { display: flex; flex-wrap: wrap; align-items: center; gap: 10px; }
        .eye-cwa-report .toolbar .btn {
            display: inline-block;
            padding: 8px 16px;
            font-size: 14px;
            font-family: Arial, Helvetica, sans-serif;
            line-height: 1.2;
            border-radius: 4px;
            border: 1px solid #1a5490;
            background: #1a6fb5;
            color: #fff !important;
            text-decoration: none !important;
            cursor: pointer;
            box-sizing: border-box;
        }
        .eye-cwa-report .toolbar .btn:hover { background: #155a93; border-color: #134a78; }
        .eye-cwa-report .toolbar .btn:active { background: #124d7d; }
        .eye-cwa-report .toolbar .btn-secondary {
            background: #fff;
            color: #1a3d66 !important;
            border-color: #a8b8c8;
        }
        .eye-cwa-report .toolbar .btn-secondary:hover { background: #f0f4f8; border-color: #8a9bab; }
        .eye-cwa-report .toolbar .btn-print { min-width: 72px; }
        @media print {
            .eye-cwa-report { background: #fff; padding: 0; }
            .eye-cwa-report .toolbar { display: none; }
            .eye-cwa-report .report-shell { max-width: none; width: 100%; margin: 0; }
            .eye-cwa-report .page { border: none; box-shadow: none; }
        }
    </style>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="eye-cwa-report">
        <div class="report-shell">
            <div class="toolbar">
                <div class="toolbar-inner">
                    <button type="button" class="btn btn-print" onclick="window.print();">Print</button>
                    <asp:HyperLink ID="lnkPdf" runat="server" Visible="false" Text="Download PDF" CssClass="btn" />
                    <asp:HyperLink ID="lnkExcel" runat="server" Visible="false" Text="Download Excel (.xls)" CssClass="btn" />
                    <asp:HyperLink ID="lnkBack" runat="server" Visible="false" Text="Back to reports" CssClass="btn btn-secondary" />
                </div>
            </div>
            <div class="page" id="printArea">
                <div class="hdr-top">
                    <div class="hdr-pad" aria-hidden="true"></div>
                    <div class="titles">
                        <h1><asp:Literal ID="litTitleMain" runat="server" /></h1>
                        <h2>EYE Classwise Analysis</h2>
                    </div>
                    <div class="hdr-logo-wrap">
                        <asp:Image ID="imgLogo" runat="server" CssClass="logo" AlternateText="The City School" />
                    </div>
                </div>
                <div class="meta">
                    <span class="center"><strong>Center:</strong> <asp:Literal ID="litCenter" runat="server" /></span>
                    <span class="term"><strong>Term:</strong> <asp:Literal ID="litTerm" runat="server" /></span>
                    <span class="session"><strong>Session:</strong> <asp:Literal ID="litSession" runat="server" /></span>
                </div>
                <asp:Literal ID="litError" runat="server" EnableViewState="false" />
                <asp:Panel ID="pnlTable" runat="server" Visible="false">
                    <table class="rpt">
                        <thead>
                            <tr>
                                <th style="width: 18%;">Class name</th>
                                <th style="width: 10%;">Students</th>
                                <th style="width: 10%;">Total LOs</th>
                                <th style="width: 13%;">EXC</th>
                                <th style="width: 13%;">EXP</th>
                                <th style="width: 13%;">EME</th>
                                <th style="width: 13%;">N.I</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptRows" runat="server" OnItemDataBound="rptRows_ItemDataBound">
                                <ItemTemplate>
                                    <tr id="trRow" runat="server">
                                        <td class="lbl"><%# Eval("DisplayClass") %></td>
                                        <td class="num"><%# Eval("DisplayTotalStudents") %></td>
                                        <td class="num"><%# Eval("DisplayTotalLos") %></td>
                                        <td class="num"><%# Eval("DisplayExc") %></td>
                                        <td class="num"><%# Eval("DisplayExp") %></td>
                                        <td class="num"><%# Eval("DisplayEme") %></td>
                                        <td class="num"><%# Eval("DisplayNi") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
