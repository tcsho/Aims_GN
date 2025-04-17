<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="filevista.ascx.cs" Inherits="GleamTech.Web.Controls.FileVistaControl" %>
<%=InsertInfo%>
<div id="divFileVistaControl" class="fileVistaControl"<%=InsertStyle%>>
    <div style="position:relative">
        <div id="divLeftPane" style="position: absolute; top:0px; left:0px; width: 214px;" class="nonSelectableText"></div>
        <div id="divPaneSeparator" style="position: absolute; top:0px; left: 214px; width: 6px;" class="separator nonSelectableText"></div>
        <div id="divRightPane" style="position: absolute; top:0px; left: 222px;" class="nonSelectableText">
	        <div id="divToolbar" style="height: 40px;"></div>
	        <div id="divFolderInfo" style="height: 50px; visibility: hidden;">
		        <table cellpadding="0" cellspacing="3" border="0">
			        <tr>
				        <td><img id="infoFolderImage" width="48" height="48" style="border: none" src="<%=ResolveClientUrl("images/bigfolder.png")%>" alt="" /></td>
				        <td style="width: 150px">
					        <span id="infoFolderName" class="generalText" style="font-weight: bold;">&nbsp;</span>
				        </td>
				        <td style="width: 50px"></td>
				        <td style="white-space: nowrap" class="generalText">
					        <span id="infoSubfoldersText">&nbsp;</span><br />
					        <span id="infoFilesText">&nbsp;</span>, <span id="infoSize" style="font-weight: bold;">&nbsp;</span></td>
				        <td style="width: 50px"></td>
			        </tr>
		        </table>
	        </div>
	        <div id="divGrid" style="width: 100%; overflow: auto; padding-top: 2px;"></div>
        </div>

        <iframe id="frameDownload" src="javascript:false;" style="visibility:hidden; width:0px; height:0px; border: 0px"></iframe>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>    
    </div>
</div>
