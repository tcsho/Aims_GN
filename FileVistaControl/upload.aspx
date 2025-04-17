<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="GleamTech.Web.Controls.FileVistaUploadPage" EnableSessionState="ReadOnly" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title><%=language.GetString("103")%></title>
		<script type="text/javascript" src="scripts/library/grid.js"></script>
		<script type="text/javascript" src="scripts/library/menu.js"></script>
		<script type="text/javascript" src="scripts/library/utility.js"></script>
		<script type="text/javascript" src="scripts/swfupload/swfupload.js"></script>
		<script type="text/javascript" src="scripts/upload.js"></script>
		<link href="styles/default.css" rel="stylesheet" />
        <style type="text/css">
	        .swfupload {
		        position: absolute;
		        z-index: 1;
	        }
        </style>		
	</head>
	<body class="dialog" onload="onPageLoad(<%=InsertRefresh%>)">
		<iframe name="frameUpload" src="javascript:false;" style="visibility:hidden; width:0px; height:0px; border: 0px" onload="checkUploadResult()"></iframe>
        <input type="hidden" id="extensionIcons" value="<%=InsertExtensionIcons%>" />
        <input type="hidden" id="allowedFileTypes" value="<%=InsertAllowedFileTypes%>" />
        <input type="hidden" id="quotaSize" value="<%=InsertQuotaSize%>" />
        <input type="hidden" id="remainingQuotaSize" value="<%=InsertRemainingQuotaSize%>" />
        <input type="hidden" id="preConditionError" value="<%=InsertPreConditionError%>" />
        <input type="hidden" id="ajaxUploadAvailable" value="<%=InsertAjaxUploadAvailable%>" />
        <div style="position: absolute; top: 10px; left: 10px; width: 480px;" class="nonSelectableText">
			<table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;" class="generalText">
				<tr style="height: 50px">
					<td style="width: 50px"><img width="48" height="48" style="border: none" src="images/uploadfolder.png" alt="" /></td>
					<td style="white-space: nowrap" align="left">
						<span style="font-weight: bold;"><%=language.GetString("227")%></span><br />
						<input type="text" value="<%=InsertUploadPath%>" readonly="readonly" class="dialog" style="border: 0px; width: 420px" />
					</td>
				</tr>
				<tr><td colspan="2" style="height: 5px; border-top: #d6d2c2 2px solid;">&nbsp;</td></tr>
			</table>
		</div>
		<div id="divUpload" style="position: absolute; top: 65px; left: 10px; width: 480px; height: 180px;" class="nonSelectableText">
		    <div style="text-align: right;"><span id="spanFileCountText">&nbsp;</span></div>
            <div id="divGrid" style="width: 100%; height:150px; overflow:auto; background-color: white; border: #d4d0c8 1px solid; border-top: none; margin-bottom: 10px;"></div>
			<div style="float:left;">
			    <span id="spanButtonPlaceholder"></span>
				<input id="buttonAdd" type="button" value="<%=language.GetString("230")%>" style="z-index:1; width: 75px"
				/>&nbsp;&nbsp;&nbsp;<input id="buttonRemove" type="button" value="<%=language.GetString("231")%>" style="width: 75px" onclick="removeSelected()"
				/>&nbsp;&nbsp;&nbsp;<input id="buttonRemoveAll" type="button" value="<%=language.GetString("232")%>" onclick="initFileChooser()" />
			</div>
			<div style="clear:right; text-align: right;">
				<input id="buttonUpload" type="button" value="<%=language.GetString("233")%>" onclick="startUpload()"
				/>&nbsp;&nbsp;&nbsp;<input type="button" value="<%=language.GetString("234")%>" onclick="parent.ModalDialog.close()" />
			</div>
            <form id="formUpload" action="<%=InsertFormAction%>" method="post" enctype="multipart/form-data"></form>
		</div>
		<div id="divProgress" style="visibility:hidden; position: absolute; top: 65px; left: 10px; width: 480px; height: 180px;" class="nonSelectableText">
			<table border="0" cellpadding="0" cellspacing="2" class="generalText" style="height: 150px">
				<tr>
					<td><%=language.GetString("236")%></td>
					<td rowspan="6" style="width: 20px;">&nbsp;</td>
					<td><span id="spanStatus" style="font-weight: bold;">&nbsp;</span></td>
				</tr>
				<tr>
					<td><%=language.GetString("237")%></td>
					<td><img id="imgCurrentFile" src="" alt="" width="16" height="16" style="vertical-align: top; margin-right:2px; margin-top:2px;"/><input id="inputCurrentFile" type="text" value="" readonly="readonly" class="dialog" style="border: 0px; font-weight: bold; width: 300px;" /></td>
				</tr>
				<tr valign="top">
					<td><%=language.GetString("238")%></td>
					<td>
						<div id="divProgressBar" style="background-color: white; width: 320px; height: 20px; border: black 1px solid;"><div style="background-color: #316ac5; width: 0px; height: 100%;"></div></div>
						<div style="text-align: center"><span id="spanTransferred" style="font-weight: bold;">&nbsp;</span></div>
					</td>
				</tr>
				<tr>
					<td><%=language.GetString("239")%></td>
					<td><span id="spanElapsedTime" style="font-weight: bold;">&nbsp;</span></td>
				</tr>
				<tr>
					<td><%=language.GetString("240")%></td>
					<td><span id="spanEstimatedTimeLeft" style="font-weight: bold;">&nbsp;</span></td>
				</tr>
				<tr>
					<td><%=language.GetString("241")%></td>
					<td><span id="spanTransferRate" style="font-weight: bold;">&nbsp;</span></td>
				</tr>
			</table>
			<div style="text-align: right;">
				<br /><input id="buttonNewUpload" type="button" value="<%=language.GetString("235")%>" onclick="showDivUpload()"
				/>&nbsp;&nbsp;&nbsp;<input id="buttonClose"  type="button" value="<%=language.GetString("234")%>" onclick="parent.ModalDialog.close()"
				/>&nbsp;&nbsp;&nbsp;<input id="buttonCancel" type="button" value="<%=language.GetString("221")%>" onclick="cancelUpload()" />
			</div>
		</div>		
	</body>
</html>
