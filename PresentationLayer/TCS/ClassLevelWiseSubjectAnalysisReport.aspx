<%@ Page Title="Class Level Wise Subject Analysis" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ClassLevelWiseSubjectAnalysisReport.aspx.cs" Inherits="PresentationLayer_TCS_ClassLevelWiseSubjectAnalysisReport" %>



<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <style type="text/css">

        .cls-subj-report { font-family: Arial, Helvetica, sans-serif; padding: 12px 0 20px; background: #f5f5f5; box-sizing: border-box; color: #222; }

        .cls-subj-report span, .cls-subj-report td, .cls-subj-report th,

        .cls-subj-report .titles h1, .cls-subj-report .titles h2 { color: #222; }

        .cls-subj-report .report-shell { max-width: 1100px; margin: 0 auto; width: 100%; box-sizing: border-box; }

        .cls-subj-report .page { background: #fff; border: 1px solid #ccc; padding: 20px 24px 28px; }

        .cls-subj-report .hdr-top {

            display: grid;

            grid-template-columns: minmax(72px, 120px) 1fr minmax(72px, 120px);

            align-items: start;

            column-gap: 10px;

            margin-bottom: 4px;

        }

        .cls-subj-report .titles { text-align: center; padding: 0 4px; }

        .cls-subj-report .hdr-logo-wrap { justify-self: end; text-align: right; line-height: 0; }

        .cls-subj-report .hdr-logo-wrap .logo { display: block; max-width: 118px; max-height: 96px; width: auto; height: auto; object-fit: contain; }

        .cls-subj-report .titles h1 { font-size: 22px; margin: 0 0 8px; font-weight: bold; }

        .cls-subj-report .titles h2 { font-size: 17px; margin: 0; font-weight: bold; }

        .cls-subj-report .class-meta-line { margin-bottom: 6px; font-size: 14px; white-space: nowrap; }

        .cls-subj-report .class-session-line { margin-bottom: 10px; font-size: 14px; white-space: nowrap; }

        .cls-subj-report .class-block { margin-bottom: 28px; page-break-inside: avoid; }

        .cls-subj-report .class-block:last-child { margin-bottom: 0; }

        .cls-subj-report table.rpt { width: 100%; border-collapse: collapse; font-size: 14px; }

        .cls-subj-report table.rpt th, .cls-subj-report table.rpt td { border: 1px solid #000; padding: 8px 10px; }

        .cls-subj-report table.rpt th { background: #f0f0f0; font-weight: bold; text-align: center; }

        .cls-subj-report table.rpt td.lbl { text-align: left; font-weight: bold; }

        .cls-subj-report table.rpt td.num { text-align: center; }

        .cls-subj-report tr.total td { font-weight: bold; }

        .cls-subj-report .err { color: #b00020; margin-top: 12px; }

        .cls-subj-report .toolbar {

            margin-bottom: 14px; padding: 10px 24px; background: #fff;

            border: 1px solid #ccc; border-radius: 4px;

        }

        .cls-subj-report .toolbar-inner { display: flex; flex-wrap: wrap; align-items: center; gap: 10px; }

        .cls-subj-report .toolbar .btn {

            display: inline-block; padding: 8px 16px; font-size: 14px;

            border-radius: 4px; border: 1px solid #1a5490; background: #1a6fb5;

            color: #fff !important; text-decoration: none !important; cursor: pointer;

        }

        .cls-subj-report .toolbar .btn-secondary {

            background: #fff; color: #1a3d66 !important; border-color: #a8b8c8;

        }

        @media print {

            .cls-subj-report { background: #fff; padding: 0; }

            .cls-subj-report .toolbar { display: none; }

            .cls-subj-report .class-block { page-break-after: always; }

            .cls-subj-report .class-block:last-child { page-break-after: auto; }

        }

    </style>

</asp:Content>



<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="cls-subj-report">

        <div class="report-shell">

            <div class="toolbar">

                <div class="toolbar-inner">

                    <button type="button" class="btn" onclick="window.print();">Print</button>

                    <asp:HyperLink ID="lnkPdf" runat="server" Visible="false" Text="Download PDF" CssClass="btn" />

                    <asp:HyperLink ID="lnkExcel" runat="server" Visible="false" Text="Download Excel (.xls)" CssClass="btn" />

                    <asp:HyperLink ID="lnkBack" runat="server" Visible="false" Text="Back to reports" CssClass="btn btn-secondary" />

                </div>

            </div>

            <div class="page" id="printArea">

                <div class="hdr-top">

                    <div aria-hidden="true"></div>

                    <div class="titles">

                        <h1><asp:Literal ID="litTitleMain" runat="server" /></h1>

                        <h2><asp:Literal ID="litSubtitle" runat="server" /></h2>

                    </div>

                    <div class="hdr-logo-wrap">

                        <asp:Image ID="imgLogo" runat="server" CssClass="logo" AlternateText="The City School" />

                    </div>

                </div>

                <asp:Literal ID="litError" runat="server" EnableViewState="false" />

                <asp:Panel ID="pnlSections" runat="server" Visible="false">

                    <asp:Repeater ID="rptClasses" runat="server" OnItemDataBound="rptClasses_ItemDataBound">

                        <ItemTemplate>

                            <div class="class-block">

                                <div class="class-meta-line">
                                    <strong>Center:</strong> <%# Eval("Center") %>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <strong>Region:</strong> <%# Eval("Region") %>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <strong>Class:</strong> <%# Eval("ClassName") %>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <strong>Term:</strong> <%# Eval("Term") %>
                                </div>
                                <div class="class-session-line">
                                    <strong>Session:</strong> <%# Eval("Session") %>
                                </div>

                                <table class="rpt">

                                    <thead>

                                        <tr>

                                            <th style="width: 34%;"></th>

                                            <th style="width: 10%;">students</th>

                                            <th style="width: 10%;">Total LOs</th>

                                            <th style="width: 11%;">EME</th>

                                            <th style="width: 11%;">EXC</th>

                                            <th style="width: 12%;">EXP</th>

                                            <th style="width: 12%;">N.I</th>

                                        </tr>

                                    </thead>

                                    <tbody>

                                        <asp:Repeater ID="rptSubjects" runat="server" OnItemDataBound="rptSubjects_ItemDataBound">

                                            <ItemTemplate>

                                                <tr id="trRow" runat="server">

                                                    <td class="lbl"><%# Eval("DisplaySubject") %></td>

                                                    <td class="num"><%# Eval("DisplayTotalStudents") %></td>

                                                    <td class="num"><%# Eval("DisplayTotalLos") %></td>

                                                    <td class="num"><%# Eval("DisplayEme") %></td>

                                                    <td class="num"><%# Eval("DisplayExc") %></td>

                                                    <td class="num"><%# Eval("DisplayExp") %></td>

                                                    <td class="num"><%# Eval("DisplayNi") %></td>

                                                </tr>

                                            </ItemTemplate>

                                        </asp:Repeater>

                                    </tbody>

                                </table>

                            </div>

                        </ItemTemplate>

                    </asp:Repeater>

                </asp:Panel>

            </div>

        </div>

    </div>

</asp:Content>

