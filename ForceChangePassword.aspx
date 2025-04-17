<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForceChangePassword.aspx.cs" Inherits="ForceChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Password Expired!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="60%">
                <tr style="height:10px;text-align:right">
                    <td colspan="5">
            <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.gif" border="0"
                cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2a.gif" border="0"
                            cellpadding="0" cellspacing="0" style="background-repeat: no-repeat; height: 35px;"
                            width="100%">
                            <tr>
                                <td style="height: 19px" width="2%">
                                    &nbsp;</td>
                                <td id="wrkTitle" runat="server" class="formheading" style="height: 19px; text-align: left;"
                                    width="98%">
                                    <span style="color: #ffffff">
                                    Password Expired ! </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>              
            <table style="width: 90%; margin-left: 5px" cellspacing="0" cellpadding="0">
                <tr style="height: 3px">
                    <td colspan="2" style="height: 3px;text-align:center;font-size:xx-large">
                    Valid Password Example: PaSs1
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        Enter New Password:
                    </td>
                    <td align="left" valign="top" style="width: 100%px">
                        

                        <asp:TextBox ID="txtNPass" runat="server" Width="25%" MaxLength="50" ValidationGroup="S"
                            TextMode="Password" CssClass="textbox"></asp:TextBox>

                       <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtNPass"
                            ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$" 
                            ErrorMessage="Password must contain: Minimum 5 characters atleast 1 Alphabet and 1 Number" 
                            ForeColor="Red" ValidationGroup="A" />


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNPass"
                            ErrorMessage="*New Password Required" ValidationGroup="A" InitialValue="0"></asp:RequiredFieldValidator></td>
                </tr>
                <tr style="height: 3px; color: #000000;">
                    <td colspan="2">
                    </td>
                </tr>
                <tr style="color: #000000">
                    <td style="width: 165px; height: 24px;">
                        Confirm New Pasword:
                    </td>
                    <td style="height: 24px; width: 299px;" align="left" valign="top">
                        <asp:TextBox ID="txtNPassC" runat="server" Width="25%" MaxLength="50" TextMode="Password"
                            CssClass="textbox"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNPassC"
                            ControlToValidate="txtNPass" ErrorMessage="CompareValidator" ValidationGroup="A">Passwords do not match!</asp:CompareValidator>
                    </td>
                </tr>
                <tr style="height: 3px">
                    <td colspan="2">
                    </td>
                </tr>
                <tr style="height: 3px;font-size:larger;color:Red;">
                    <td colspan="2">
                        Your password has been expired, please reset your password to proceed. &nbsp;</td>
                </tr>
                <tr style="height: 18px" align="center">
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                            Text="Save" ValidationGroup="A" />
                    </td>
                </tr>
            </table>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </tr>
            </table>

    </div>
    </form>
</body>
</html>
