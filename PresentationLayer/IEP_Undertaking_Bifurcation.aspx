<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Undertaking_Bifurcation.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Undertaking_Bifurcation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.3.1/jspdf.umd.min.js"></script>
    <script type="text/javascript">
        function printPage() {
            window.print();
        }

        // Wait for the document to fully load
        window.onload = function () {
            // Add event listener for beforeprint event
            window.addEventListener('beforeprint', function () {
                // Create a new style element
                var style = document.createElement('style');
                style.type = 'text/css';
                style.innerHTML = '@media print { @page { size: Portrait; } @page :first { size: auto; } @page :nth-of-type(odd) { display: none; } }';

                // Append the style to the document head
                document.head.appendChild(style);
            });
        };
    </script>
    
    <br />
    <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Bifurcation Student"></asp:Label>
    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%" border="0" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center">
                <asp:Button ID="btnSave" runat="server" Text="Print and Send Email" OnClick="btnSave_Click" CssClass="button btn btn-primary" OnClientClick="printPage(); return false;" Visible="false" />
                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button btn btn-primary" OnClientClick="printPage(); return false;" Visible="true" />
                
            </div>

            <asp:Label ID="lblCenter_Id" runat="server" CssClass="bi_visibility"></asp:Label>
            <asp:Label ID="lblSession_Id" runat="server" CssClass="bi_visibility"></asp:Label>
            <asp:Label ID="lblClass_Id" runat="server" CssClass="bi_visibility"></asp:Label>
            <asp:Label ID="lblfatheremail" runat="server" CssClass="bi_visibility"></asp:Label>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center" style="padding:10px;">
                <!-- Add other controls here as needed -->
            </div>

            <!-- Undertaking form -->
            <div id="Retain1" runat="server">
                <div class="PrintArea area1 all demo" id="Retain" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 Biletter_main" id="Biletter_main">
                        <!-- Tab 2 -->
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="row rowdisplayflex headerwithlogo">
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass"></div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                                    <h2 class="schoolname">The City School</h2>
                                    <asp:Label runat="server" ID="bi_lettersubheading" CssClass="bi_lettersubheading"></asp:Label>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                                    <%--<img src="Component_Marks/ReportCard/images/newlogo.png" />--%>
                                    <%--<img src="../images/lgo.png" />--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                            <p class="bifirstpra">
                                I, the parent/guardian of
                                <asp:Label runat="server" ID="txt_Student_Name1" CssClass="bi_label bi_labelsection"></asp:Label>
                                <%--<asp:TextBox ID="txt_Student_Name1" CssClass="bi_label bi_label_student text-center" runat="server" Enabled="false"></asp:TextBox>--%>
                                , ERP # 
                                <asp:Label runat="server" ID="lblStudent_Id" CssClass="bi_label bi_labelsection"></asp:Label> studying in 
                                <asp:Label runat="server" ID="bi_classchange" CssClass="bi_classchange fontsze"></asp:Label> Section 
                                <%--<asp:TextBox ID="txt_Student_Section" CssClass="bi_label bi_labelsection" runat="server" Enabled="false"></asp:TextBox>--%>
                                <asp:Label runat="server" ID="txt_Student_Section" CssClass="bi_classchange fontsze"></asp:Label> confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:
                            </p>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <ul class="bi_bullet_list" runat="server" id="ul_List">
                                <li>1) That the school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</li>
                                <li>2) However, at my insistence, the school has provisionally allowed my child to sit in Class 8 and take final examinations for the O level stream.</li>
                                <li>3) Accept the responsibility that my child must pass the Class 8 Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</li>
                                <li>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</li>
                                <li>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</li>
                            </ul>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <hr class="remark_line hide"/>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 rmarkheading text-center">
                            <span class="hide">Parent’s Remarks</span>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 parentremarkmain hide">
                            <p class="parentremark">
                                <span>I,</span> <input type="text" class="bi_label bi_label_father" disabled="true"/><span> father/mother/guardian of </span><input type="text" class="bi_label" disabled="true"/><span id="spn_class" runat="server">Class 8</span>
                            </p>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 signdivmain">
                            <!-- Signature fields -->
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label runat="server" visible="false" id="lblrcv">This undertaking is received from parent/guardian's email address, in response to the email sent by the school on</label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center" style="padding:10px;">
                <!-- Additional buttons if needed -->
            </div>

            <!-- Print settings -->
            <div style="border: solid 2px #999fff; float: left; margin-left: 20px;" class="SettingsBox">
                <div style="width: 400px; padding: 20px;">
                    <div style="padding: 0 10px 10px;" class="buttonBar">
                        <div class="button b1">Print</div>
                        <div class="toggleDialog">open dialog</div>
                    </div>
                    <div style="font-weight: bold; border-top: solid 1px #999fff; padding-top: 10px;">Settings</div>
                    <table>
                        <tbody>
                            <tr>
                                <td><input value="popup" name="mode" id="popup" checked="" type="radio"> Popup</td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px;"><input value="popup" name="popup" id="closePop" type="checkbox"> Close popup</td>
                            </tr>
                            <tr>
                                <td><input value="iframe" name="mode" id="iFrame" type="radio"> IFrame</td>
                            </tr>
                            <tr>
                                <td>Extra css: <input type="text" name="extraCss" size="50" class="extraCss"></td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="padding: 20px;">
                        <input id="Print_Button" type="button" value="Print" onclick="window.print()" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
