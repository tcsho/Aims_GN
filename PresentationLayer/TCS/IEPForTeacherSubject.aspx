<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="IEPForTeacherSubject.aspx.cs" Inherits="PresentationLayer_IEPForTeacherSubject" 
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        
        <Scripts>
           <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
         
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
                                            <%--<asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Exam/ Course Work and Theory Marks"></asp:Label>--%>
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="IEP For Teacher Subject"></asp:Label>
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
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;" class="TextLabelMandatory40">
                                        Class Section*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;" class="TextLabelMandatory40">
                                        Subject*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Subject_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;"  class="TextLabel">
                                        Student:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_student" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_student_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;"  class="TextLabelMandatory40">
                                        Term*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <%--<p class="msgred">*Entry of decimal number not allowed.</p>--%>
                            <p class="msgred" style="padding : 0px !important">*IEP entries will be available after marks compilation.</p>
                            <p class="msgred">*Digital IEP option only for Class 8 to Class O levels.</p>
                            <table class="main_table upds" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%" class="updsrow1">
                                    <td align="center" style="width: 100%">
                                        <asp:PlaceHolder ID="PlaceHolder1"  runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                                <tr style="width: 100%" >
                                    <td style="width: 100%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">
                                        <asp:Button ID="btnSave" runat="server" Visible="false" OnClick="btnSave_Click" Text="Save" Width="77px"
                                            CssClass="btn btn-primary" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" >
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
    <style>
        .msgred {
        color: red;
    text-align: center;
    font-size: 20px;
    padding: 10px;
        }
    </style>
 <script type="text/javascript">
     //$('.ok').bind('focus blur select change click dblclick mousedown mouseup mouseover mousemove mouseout keypress keydown keyup', function (e) {
     //    alert("ss");
     //});
     function decimal_notallowed(item)
     {
        // alert("ss" + item.value);
 
         //$(item).css('background-color', 'red');
         //alert("ss");
         //item.value = item.value.replace(/[^0-9\.]/g, '');
         //$(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        
         if (/\D/g.test(item.value)) {
                 // Filter non-digits from input value.
             item.value = item.value.replace(/\D/g, '');
             }
        


     }
       

     //console.log(document.getElementsByClassName("ok")[0]);
 </script>
</asp:Content>
    