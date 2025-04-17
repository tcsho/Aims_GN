
Tree.count=0;function Tree(){this.index=Tree.count++;this.root=null;this.hideRoot=false;this.nodes=new Array();this.lastSelectedNodeId="";this.nodeIndentSize=20;this.textLoading="Loading...";this.imgPlus=new Image();this.imgMinus=new Image();this.imgLoading=new Image();this.icons=new Object();this.iconsSelected=new Object();this.onTreeNodeSelect=null;this.onTreeNodeExpand=null;this.onTreeNodeContextMenu=null;this.mouseOverSignEvent=null;this.mouseOverNodeEvent=null;this.classTreeTitleBar="treeTitleBar"
this.classNodeText="treeNodeText";this.classNodeTextHover="treeNodeText TNHover";this.classNodeTextSelected="treeNodeText TNSelected";this.classNodeTextSelectedHover="treeNodeText TNSelectedHover";this.classNodeSign="treeNodeSign";this.classNodeIcon="treeNodeIcon";this.classNodeLoading="treeNodeText TNLoading";}
Tree.prototype.createRoot=function(text){this.root=new TreeNode(this,text,"Root");this.root.id="root";this.nodes["root"]=this.root;this.root.expanded=true;return this.root;}
Tree.prototype.setTitle=function(titleText){this.textTitle.nodeValue=titleText?titleText:"\u00a0";}
Tree.prototype.setSignIcons=function(plusIcon,minusIcon){this.imgPlus.src=plusIcon;this.imgMinus.src=minusIcon;}
Tree.prototype.setNodeIcons=function(type,defaultIcon,selectedIcon){var img=new Image();img.src=defaultIcon;this.icons[type]=img;if(selectedIcon){var imgSelected=new Image();imgSelected.src=selectedIcon;this.iconsSelected[type]=imgSelected;}}
Tree.prototype.setLoadingIcon=function(loadingIcon){this.imgLoading.src=loadingIcon;}
Tree.prototype.setHeight=function(height){this.divTreeBody.style.height=(height-this.divTreeTitleBar.offsetHeight)+"px";}
Tree.prototype.render=function(parentNode){var divTreeTitleBar=document.createElement("div");divTreeTitleBar.className=this.classTreeTitleBar;var textNode=document.createTextNode("\u00a0");divTreeTitleBar.appendChild(textNode);var divTreeBody=document.createElement("div");divTreeBody.style.width="100%";divTreeBody.style.overflow="auto";divTreeBody.style.paddingLeft="2px";divTreeBody.style.paddingTop="2px";if(this.hideRoot){var divNode=document.createElement("div");var divChildNodes=document.createElement("div");divChildNodes.style.display=(this.root.expanded?"block":"none");for(var i=0;i<this.root.childNodes.length;i++)
this.root.childNodes[i].render(divChildNodes);divNode.appendChild(divChildNodes);divTreeBody.appendChild(divNode);this.root.divChildNodes=divChildNodes;}else
this.root.render(divTreeBody);var divTree=document.createElement("div");divTree.appendChild(divTreeTitleBar);divTree.appendChild(divTreeBody);parentNode.appendChild(divTree);this.textTitle=textNode;this.divTreeTitleBar=divTreeTitleBar;this.divTreeBody=divTreeBody;}
Tree.prototype.selectNode=function(rootFolderID,relativePath){var treeNode=null;var i,j,arr;var re;for(i=0;i<this.root.childNodes.length;i++){if(this.root.childNodes[i].value==rootFolderID){treeNode=this.root.childNodes[i];break;}}
if(!treeNode)return;arr=relativePath.split("/");for(i=0;i<arr.length;i++){for(j=0;j<treeNode.childNodes.length;j++)
if(treeNode.childNodes[j].text==arr[i]){treeNode=treeNode.childNodes[j];break;}}
if(treeNode.parent)
treeNode.parent.expand();treeNode.select(true);if(treeNode.childNodes.length>0||treeNode.expandable)
treeNode.expand();}
Tree.prototype.getNode=function(rootFolderID,relativePath){var treeNode=null;var i,j,arr;var re;for(i=0;i<this.root.childNodes.length;i++){if(this.root.childNodes[i].value==rootFolderID){treeNode=this.root.childNodes[i];break;}}
if(!treeNode)return null;arr=relativePath.split("/");for(i=0;i<arr.length;i++){for(j=0;j<treeNode.childNodes.length;j++)
if(treeNode.childNodes[j].text==arr[i]){treeNode=treeNode.childNodes[j];break;}}
return treeNode;}
function TreeNode(tree,text,type,value){this.tree=tree;this.text=text;this.type=type;this.value=value;this.indent=0;this.selected=false;this.expanded=false;this.contextSelected=false;this.loaded=false;this.loading=false;this.expandable=false;this.childNodes=new Array();this.parent=null;this.icon="";this.isTreeNode=true;}
TreeNode.prototype.addChildNode=function(text,expandable,type,value){var treeNode=new TreeNode(this.tree,text,type,value);treeNode.id=this.id+"_"+this.childNodes.length;treeNode.indent=this.indent+1;treeNode.expandable=expandable;treeNode.parent=this;this.childNodes[this.childNodes.length]=treeNode;this.tree.nodes[treeNode.id]=treeNode;return treeNode;}
TreeNode.prototype.render=function(parentNode){var treeNode=this;var divNode=document.createElement("div");divNode.title=this.text;var table=document.createElement("table");table.border=0;table.cellPadding=0;table.cellSpacing=0;var tbody=document.createElement("tbody");var row=document.createElement("tr");if(this.indent>1)
table.style.marginLeft=((this.indent-1)*this.tree.nodeIndentSize)+"px";if(this.indent>0){var cell2=document.createElement("td");cell2.style.paddingLeft="6px";if(this.childNodes.length>0||this.expandable){cell2.className=this.tree.classNodeSign;cell2.onmouseover=function(e){treeNode.onMouseOverSign(e);};cell2.onclick=function(e){treeNode.onClickSign(e);};var image1=new Image();image1.border=0;image1.width=9;image1.height=9;image1.src=(this.expanded?this.tree.imgMinus.src:this.tree.imgPlus.src);cell2.style.paddingRight="5px";cell2.appendChild(image1);}
else
cell2.style.paddingRight="14px";row.appendChild(cell2);}
var cell3=document.createElement("td");cell3.noWrap=true;cell3.style.paddingRight="4px";cell3.className=this.tree.classNodeIcon;cell3.onmouseover=function(e){treeNode.onMouseOver(e);};cell3.onmouseout=function(e){treeNode.onMouseOut(e);};cell3.onclick=function(e){treeNode.onClick(e);};cell3.oncontextmenu=function(e){treeNode.onContextMenu(e);};var image2=new Image();image2.border=0;image2.width=16;image2.height=16;image2.align="absmiddle";if(this.icon!="")
image2.src=this.icon;else
image2.src=this.tree.icons[this.type]?this.tree.icons[this.type].src:"";cell3.appendChild(image2);row.appendChild(cell3);var cell4=document.createElement("td");cell4.noWrap=true;cell4.className=this.tree.classNodeText;cell4.onmouseover=function(e){treeNode.onMouseOver(e);};cell4.onmouseout=function(e){treeNode.onMouseOut(e);};cell4.onclick=function(e){treeNode.onClick(e);};cell4.oncontextmenu=function(e){treeNode.onContextMenu(e);};var text1=document.createTextNode(this.text);cell4.appendChild(text1);row.appendChild(cell4);tbody.appendChild(row);table.appendChild(tbody);divNode.appendChild(table);this.cellNodeContent=cell4;this.cellSign=cell2;this.imgSign=image1;this.imgNode=image2;var divChildNodes=document.createElement("div");divChildNodes.style.display=(this.expanded?"block":"none");for(var i=0;i<this.childNodes.length;i++)
this.childNodes[i].render(divChildNodes);divNode.appendChild(divChildNodes);parentNode.appendChild(divNode);this.divChildNodes=divChildNodes;}
TreeNode.prototype.onMouseOver=function(e){if(!this.cellNodeContent)return;if(this.selected||this.contextSelected)
this.cellNodeContent.className=this.tree.classNodeTextSelectedHover;else
this.cellNodeContent.className=this.tree.classNodeTextHover;if(this.tree.mouseOverNodeEvent)this.tree.mouseOverNodeEvent(this);}
TreeNode.prototype.onMouseOut=function(e){if(!this.cellNodeContent)return;if(this.selected||this.contextSelected)
this.cellNodeContent.className=this.tree.classNodeTextSelected;else
this.cellNodeContent.className=this.tree.classNodeText;}
TreeNode.prototype.onClick=function(e){this.select();if(this.loaded)this.expand();}
TreeNode.prototype.onContextMenu=function(e){if(!e)var e=window.event;var treeNode=this;if(!this.contextSelected){this.cellNodeContent.className=this.tree.classNodeTextSelected;this.contextSelected=true;}
if(this.tree.onTreeNodeContextMenu)
this.tree.onTreeNodeContextMenu(e,this);return true;}
TreeNode.prototype.onContextMenuClose=function(e){if(!this.selected&&this.contextSelected)
this.cellNodeContent.className=this.tree.classNodeText;this.contextSelected=false;}
TreeNode.prototype.onMouseOverSign=function(e){if(this.tree.mouseOverSignEvent)this.tree.mouseOverSignEvent(this);}
TreeNode.prototype.onClickSign=function(e){if(this.expanded)
this.collapse();else
this.expand();}
TreeNode.prototype.collapse=function(){if(!this.expanded)return;this.expanded=false;this.imgSign.src=this.tree.imgPlus.src;this.divChildNodes.style.display="none";var re;re=new RegExp("^"+this.id+"_","g");if(re.test(this.tree.lastSelectedNodeId))
this.select();}
TreeNode.prototype.expand=function(){if(this.expanded)return;this.expanded=true;if(this.imgSign)this.imgSign.src=this.tree.imgMinus.src;this.divChildNodes.style.display="block";if(this.tree.onTreeNodeExpand)this.tree.onTreeNodeExpand(this);}
TreeNode.prototype.select=function(suppressEvent){if(this.selected)return;if(this.tree.lastSelectedNodeId!="")
this.tree.nodes[this.tree.lastSelectedNodeId].unselect();if(this.tree.iconsSelected[this.type])this.imgNode.src=this.tree.iconsSelected[this.type].src;this.cellNodeContent.className=this.tree.classNodeTextSelected;this.selected=true;this.tree.lastSelectedNodeId=this.id;if(this.tree.onTreeNodeSelect&&!suppressEvent)this.tree.onTreeNodeSelect(this);}
TreeNode.prototype.unselect=function(){if(!this.selected)return;if(this.tree.iconsSelected[this.type])this.imgNode.src=this.tree.icons[this.type].src;this.cellNodeContent.className=this.tree.classNodeText;this.selected=false;}
TreeNode.prototype.getRelativePath=function(){var treeNode;var i,arr,nid,path;path="";arr=this.id.split("_");if(arr.length>2){nid="root_"+arr[1];for(i=2;i<arr.length;i++){nid+="_"+arr[i];treeNode=this.tree.nodes[nid];path+=treeNode.text;if(i!=arr.length-1)path+="/";}}
return path;}
TreeNode.prototype.getRootValue=function(){var treeNode;var arr,nid,path;name="";arr=this.id.split("_");if(arr.length>1){nid="root_"+arr[1];treeNode=this.tree.nodes[nid];name=treeNode.value;}
return name;}
TreeNode.prototype.sortChildren=function(){if(this.childNodes.length==0)return;var compare=function(node1,node2){a=node1.text.toLowerCase();b=node2.text.toLowerCase();if(a<b)
return-1;if(a>b)
return 1;return 0;}
this.childNodes.sort(compare);}
TreeNode.prototype.loadChildren=function(){while(this.divChildNodes.hasChildNodes())
this.divChildNodes.removeChild(this.divChildNodes.firstChild);if(this.childNodes.length==0){if(this.imgSign){this.cellSign.removeChild(this.imgSign);this.imgSign=null;this.cellSign.style.paddingRight="14px";this.cellSign.className="";this.cellSign.onmouseover=null;this.cellSign.onclick=null;this.expandable=false;}
this.divChildNodes.style.display="none";}else{if(this.cellSign){this.cellSign.style.paddingRight="5px";var treeNode=this;this.cellSign.className=this.tree.classNodeSign;this.cellSign.onmouseover=function(e){treeNode.onMouseOverSign(e);};this.cellSign.onclick=function(e){treeNode.onClickSign(e);};if(!this.imgSign){var image1=new Image();image1.border=0;image1.width=9;image1.height=9;image1.src=this.tree.imgMinus.src
this.imgSign=image1;this.cellSign.appendChild(image1);}
else{this.cellSign.appendChild(this.imgSign);this.imgSign.src=this.tree.imgMinus.src;}}
this.expanded=true;this.divChildNodes.style.display="block";for(var i=0;i<this.childNodes.length;i++)
this.childNodes[i].render(this.divChildNodes);}
this.loaded=true;this.loading=false;}
TreeNode.prototype.unloadChildren=function(){while(this.divChildNodes.hasChildNodes())
this.divChildNodes.removeChild(this.divChildNodes.firstChild);for(var i=0;i<this.childNodes.length;i++){delete this.childNodes[i];}
this.childNodes.length=0;this.loaded=false;}
TreeNode.prototype.showLoadingNode=function(){if(this.divChildNodes.hasChildNodes())return;var table=document.createElement("table");table.border=0;table.cellPadding=0;table.cellSpacing=0;var tbody=document.createElement("tbody");var row=document.createElement("tr");table.style.marginLeft=((this.indent+1)*this.tree.nodeIndentSize)+"px";var cell2=document.createElement("td");cell2.noWrap=true;cell2.style.paddingRight="4px";cell2.className=this.tree.classNodeIcon;var image1=new Image();image1.border=0;image1.width=16;image1.height=16;image1.align="absmiddle";image1.src=this.tree.imgLoading.src;cell2.appendChild(image1);var cell3=document.createElement("td");cell3.className=this.tree.classNodeLoading;var text1=document.createTextNode(this.tree.textLoading);cell3.appendChild(text1);row.appendChild(cell2);row.appendChild(cell3);tbody.appendChild(row);table.appendChild(tbody);this.divChildNodes.appendChild(table);this.expanded=true;if(this.imgSign)this.imgSign.src=this.tree.imgMinus.src;this.divChildNodes.style.display="block";this.loading=true;}
TreeNode.prototype.hideLoadingNode=function(){if(!this.loading)return;this.divChildNodes.removeChild(this.divChildNodes.firstChild);this.expanded=false;if(this.imgSign)this.imgSign.src=this.tree.imgPlus.src;this.divChildNodes.style.display="none";this.loading=false;}