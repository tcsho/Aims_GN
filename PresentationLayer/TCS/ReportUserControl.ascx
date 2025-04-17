<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportUserControl.ascx.cs"
    Inherits="PresentationLayer_TCS_ReportUserControl" %>
<asp:GridView ID="grdControl" runat="server" OnRowCreated="grdControl_RowCreated"
    OnRowDataBound="grdControl_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Remove">
            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="20px" />
            <ItemTemplate>
                <asp:ImageButton ID="btnRemove" runat="server" ForeColor="#004999" OnClick="btnRemove_Click"
                    Style="text-align: center;" ToolTip="Remove Value" ImageUrl="~/images/delete.gif"
                    OnClientClick="javascript:return confirm('Are you sure to delete this record?');">
                </asp:ImageButton>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
