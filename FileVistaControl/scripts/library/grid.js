
Grid.count=0;function Grid(){this.index=Grid.count++;this.columns=new Array();this.rows=new Array();this.selectedRows=new Object();this.lastSelectedRow=null;this.selectedCount=0;this.rowTitleColumn=null;this.sortColumn=null;this.sortDescending=false;this.iconsPath="";this.iconWidth=0;this.iconHeight=0;this.table=null;this.columnRow=null;this.tbody=null;this.rendered=false;this.onColumnClick=this.columnClick;this.onRowContextMenu=null;this.onRowDoubleClick=null;this.onSelectionComplete=null;this.documentOnMouseUp=null;this.imgOrder=new Image();this.imgAscending=new Image();this.imgDescending=new Image();this.classGrid="grid";this.classGridColumn="gridColumn";this.classGridColumnHover="gridColumn GCHover";this.classGridColumnSelected="gridColumn GCSelected";this.classGridCell="gridCell";this.classGridSelection="gridSelection";this.styleGrid=null;this.styleSelection=null;}
Grid.prototype.setIconSize=function(width,height){this.iconWidth=width;this.iconHeight=height;}
Grid.prototype.addColumn=function(text,sortTypeName,alignRight,format,size){var column=new Column(text,sortTypeName,alignRight,format,size);column.grid=this;column.index=this.columns.length;this.columns[column.index]=column;return column;}
Grid.prototype.addRow=function(cellArray,icon){var row=new Row(cellArray,(this.iconsPath+icon));row.grid=this;row.index=this.rows.length;row.id="g"+this.index+"r"+row.index;this.rows[row.index]=row;return row;}
Grid.prototype.render=function(parentNode){if(!this.table){this.styleGrid=getStyleObject(this.classGrid);this.styleSelection=getStyleObject(this.classGridSelection);var table=document.createElement("table");table.border=0;table.cellPadding=0;table.cellSpacing=0;table.style.width="100%";table.className=this.classGrid;var thead=document.createElement("thead");var columnRow=document.createElement("tr");this.columnRow=columnRow;thead.appendChild(columnRow);var tbody=document.createElement("tbody");this.tbody=tbody;table.appendChild(thead);table.appendChild(tbody);this.table=table;this.imgOrder.style.marginTop="2px";this.imgOrder.style.marginLeft="10px";this.imgOrder.style.marginBottom="2px";this.imgOrder.style.marginRight="0px";}
for(var i=0;i<this.columns.length;i++)
this.columns[i].render(this.columnRow);for(var j=0;j<this.rows.length;j++){this.rows[j].index=j;this.rows[j].render(this.tbody);}
if(!this.rendered){parentNode.appendChild(table);this.rendered=true;}}
Grid.prototype.clear=function(){this.removeAllRows();for(var i=0;i<this.columns.length;i++){if(this.columns[i].cellElement)this.columnRow.removeChild(this.columns[i].cellElement);this.columns[i]=null;}
this.columns.length=0;}
Grid.prototype.removeRow=function(row){if(row.selected){delete this.selectedRows[row.id];this.selectedCount--;}
this.tbody.removeChild(row.rowElement);this.rows.splice(row.index,1);delete row;for(var j=0;j<this.rows.length;j++)
this.rows[j].index=j;}
Grid.prototype.removeAllRows=function(){for(var key in this.selectedRows)
delete this.selectedRows[key];this.lastSelectedRow=null;this.selectedCount=0;for(var j=0;j<this.rows.length;j++){if(this.rows[j]!=undefined){this.tbody.removeChild(this.rows[j].rowElement);delete this.rows[j];}}
this.rows.length=0;}
Grid.prototype.columnClick=function(e,column){if(column.index==this.sortColumn.index){this.reverse();}else{this.sort(column);}
this.refresh();}
Grid.prototype.sort=function(column1,column2,column3){if(!column1)return;var rowsCount=this.rows.length;var columnIndex1=column1.index;var comparableValueFunction1=column1.sortType.comparableValueFunction;var compareFunction1=column1.sortType.compareFunction;var comparableValues1=new Array(rowsCount);if(column2){var columnIndex2=column2.index;var comparableValueFunction2=column2.sortType.comparableValueFunction;var compareFunction2=column2.sortType.compareFunction;var comparableValues2=new Array(rowsCount);}
if(column3){var columnIndex3=column3.index;var comparableValueFunction3=column3.sortType.comparableValueFunction;var compareFunction3=column3.sortType.compareFunction;var comparableValues3=new Array(rowsCount);}
for(var j=0;j<rowsCount;j++){this.rows[j].index=j;comparableValues1[j]=comparableValueFunction1(this.rows[j].cells[columnIndex1]);if(column2)comparableValues2[j]=comparableValueFunction2(this.rows[j].cells[columnIndex2]);if(column3)comparableValues3[j]=comparableValueFunction3(this.rows[j].cells[columnIndex3]);}
var compare;if(column3){compare=function(row1,row2){var rowIndex1=row1.index;var rowIndex2=row2.index;var result1=compareFunction1(comparableValues1[rowIndex1],comparableValues1[rowIndex2]);if(result1!=0)return result1;var result2=compareFunction2(comparableValues2[rowIndex1],comparableValues2[rowIndex2]);if(result2!=0)return result2;var result3=compareFunction3(comparableValues3[rowIndex1],comparableValues3[rowIndex2]);return result3;}}else if(column2){compare=function(row1,row2){var rowIndex1=row1.index;var rowIndex2=row2.index;var result1=compareFunction1(comparableValues1[rowIndex1],comparableValues1[rowIndex2]);if(result1!=0)return result1;var result2=compareFunction2(comparableValues2[rowIndex1],comparableValues2[rowIndex2]);return result2;}}else{compare=function(row1,row2){var rowIndex1=row1.index;var rowIndex2=row2.index;var result1=compareFunction1(comparableValues1[rowIndex1],comparableValues1[rowIndex2]);return result1;}}
this.rows.sort(compare);this.sortColumn=column3||column2||column1;this.sortDescending=false;}
Grid.prototype.reverse=function(){this.rows.reverse();this.sortDescending=!this.sortDescending;}
Grid.prototype.refresh=function(){var column=this.sortColumn;if(column&&!column.hidden){this.imgOrder.src=this.sortDescending?this.imgDescending.src:this.imgAscending.src;column.cellElement.appendChild(this.imgOrder);}
var selectedRowsCache=new Object();for(var key in this.selectedRows){selectedRowsCache[key]=this.selectedRows[key];this.selectedRows[key].unselect();}
for(var j=0;j<this.rows.length;j++){this.rows[j].index=j;this.tbody.appendChild(this.rows[j].rowElement);;}
for(var key in selectedRowsCache)
selectedRowsCache[key].select();}
Grid.prototype.getSelectedFirstRow=function(){for(var key in this.selectedRows)
return this.selectedRows[key];return null;}
Grid.prototype.getSelectedLastRow=function(){var row=null;for(var key in this.selectedRows)
row=this.selectedRows[key];return row;}
Grid.prototype.selectAllRows=function(){for(var j=0;j<this.rows.length;j++)
this.rows[j].select();if(this.onSelectionComplete)
this.onSelectionComplete();}
Grid.prototype.unselectAllRows=function(){for(var j=0;j<this.rows.length;j++)
this.rows[j].unselect();if(this.onSelectionComplete)
this.onSelectionComplete();}
Grid.prototype.invertSelectedRows=function(){for(var j=0;j<this.rows.length;j++){if(this.rows[j].selected)
this.rows[j].unselect();else
this.rows[j].select();}
if(this.onSelectionComplete)
this.onSelectionComplete();}
function Column(text,sortTypeName,alignRight,format,size){this.text=text;this.alignRight=alignRight;this.format=format;this.hidden=false;this.grid=null;this.index=-1;this.sortType=(Sort.types[sortTypeName])?Sort.types[sortTypeName]:Sort.types["String"];this.formatFunction=this.sortType.defaultFormatFunction?this.sortType.defaultFormatFunction:null;this.size=size;this.cellElement=null;}
Column.prototype.render=function(parentNode){if(this.hidden)return;var column=this;var cellElement=document.createElement("td");cellElement.noWrap=true;cellElement.className=this.grid.classGridColumn;if(this.alignRight)cellElement.style.textAlign="right";cellElement.style.paddingTop="1px";cellElement.style.paddingLeft="5px";cellElement.style.paddingBottom="1px";cellElement.style.paddingRight="5px";cellElement.onmouseover=function(e){return column.onMouseOver(e);};cellElement.onmouseout=function(e){return column.onMouseOut(e);};cellElement.onmousedown=function(e){return column.onMouseDown(e);};cellElement.onmouseup=function(e){return column.onMouseUp(e);};cellElement.onclick=function(e){return column.onClick(e);};cellElement.oncontextmenu=cancelEvent;this.cellElement=cellElement;var textNode=document.createTextNode(this.text);cellElement.appendChild(textNode);if(this.index==this.grid.sortColumn.index){this.grid.imgOrder.src=this.grid.sortDescending?this.grid.imgDescending.src:this.grid.imgAscending.src;cellElement.appendChild(this.grid.imgOrder);}
parentNode.appendChild(cellElement);}
Column.prototype.onMouseOver=function(e){this.cellElement.className=this.grid.classGridColumnHover;this.cellElement.style.paddingTop="1px";this.cellElement.style.paddingLeft="5px";this.cellElement.style.paddingBottom="1px";this.cellElement.style.paddingRight="5px";}
Column.prototype.onMouseOut=function(e){this.cellElement.className=this.grid.classGridColumn;this.cellElement.style.paddingTop="1px";this.cellElement.style.paddingLeft="5px";this.cellElement.style.paddingBottom="1px";this.cellElement.style.paddingRight="5px";}
Column.prototype.onMouseDown=function(e){if(!e)var e=window.event
var mouseButton=(e.which)?e.which:e.button
if(mouseButton!=1)return;this.cellElement.className=this.grid.classGridColumnSelected;this.cellElement.style.paddingTop="2px";this.cellElement.style.paddingLeft="6px";this.cellElement.style.paddingBottom="0px";this.cellElement.style.paddingRight="4px";}
Column.prototype.onMouseUp=function(e){if(!e)var e=window.event
var mouseButton=(e.which)?e.which:e.button
if(mouseButton!=1)return;this.cellElement.className=this.grid.classGridColumnHover;this.cellElement.style.paddingTop="0px";this.cellElement.style.paddingLeft="5px";this.cellElement.style.paddingBottom="0px";this.cellElement.style.paddingRight="5px";}
Column.prototype.onClick=function(e){this.grid.onColumnClick(e,this);}
function Row(cellArray,icon){this.cells=cellArray;this.icon=icon;this.grid=null;this.index=-1;this.id="";this.rowElement=null;this.selected=false;this.isRow=true;}
Row.prototype.render=function(parentNode){var row=this;var rowElement=document.createElement("tr");if(this.grid.rowTitleColumn)rowElement.title=this.cells[this.grid.rowTitleColumn.index];rowElement.onmousedown=function(e){return row.onMouseDown(e);};rowElement.onmouseup=function(e){return row.onMouseUp(e);};rowElement.onmouseover=function(e){return row.onMouseOver(e);};rowElement.onmouseout=function(e){return row.onMouseOut(e);};rowElement.ondblclick=function(e){return row.onDoubleClick(e);};rowElement.oncontextmenu=function(e){return row.onContextMenu(e,row);};var first=true;for(var i=0;i<this.cells.length;i++){if(this.grid.columns[i].hidden)continue;var cellElement=document.createElement("td");cellElement.noWrap=true;cellElement.className=this.grid.classGridCell;cellElement.onmousedown=function(e){return false;};if(this.grid.columns[i].alignRight)cellElement.style.textAlign="right";cellElement.style.borderTopStyle="solid";cellElement.style.borderTopWidth="1px";cellElement.style.borderTopColor=this.grid.styleGrid.backgroundColor;cellElement.style.borderBottomStyle="solid";cellElement.style.borderBottomWidth="1px";cellElement.style.borderBottomColor=this.grid.styleGrid.backgroundColor;var spanElement=document.createElement("span");var text;var formatFunction=this.grid.columns[i].formatFunction;if(formatFunction)
text=formatFunction(this.cells[i],this.grid.columns[i].format,this);else
text=this.cells[i];if(this.grid.columns[i].size>0&&text.length>this.grid.columns[i].size)
text=text.substr(0,this.grid.columns[i].size)+"...";text=(text=="")?"\u00a0":text;var textNode=document.createTextNode(text);if(first){var imgIcon=new Image();imgIcon.src=this.icon;imgIcon.width=this.grid.iconWidth;imgIcon.height=this.grid.iconHeight;imgIcon.style.verticalAlign="middle";imgIcon.style.marginRight="2px";spanElement.appendChild(imgIcon);var spanElement2=document.createElement("span");spanElement2.style.verticalAlign="middle";spanElement2.appendChild(textNode);spanElement.appendChild(spanElement2);first=false;}
else
spanElement.appendChild(textNode);cellElement.appendChild(spanElement);rowElement.appendChild(cellElement);}
var firstCell=rowElement.firstChild;firstCell.style.borderLeftStyle="solid";firstCell.style.borderLeftWidth="1px";firstCell.style.borderLeftColor=this.grid.styleGrid.backgroundColor;var lastCell=rowElement.lastChild;lastCell.style.borderRightStyle="solid";lastCell.style.borderRightWidth="1px";lastCell.style.borderRightColor=this.grid.styleGrid.backgroundColor;this.rowElement=rowElement;parentNode.appendChild(rowElement);}
Row.prototype.onMouseDown=function(e){if(!e)var e=window.event;var leftButton=(e.which)?(e.which==1):(e.button==1);var rightButton=(e.which)?(e.which==3):(e.button==2);if(rightButton)leftButton=false;var multiSelectKey=e.metaKey||e.ctrlKey;this.grid.mouseDownRow=this;var row=this;this.grid.documentOnMouseUp=document.onmouseup;document.onmouseup=function(e){row.onMouseUp();};if(leftButton){if(e.shiftKey){var lastSelectedRow=this.grid.lastSelectedRow;for(var key in this.grid.selectedRows)
this.grid.selectedRows[key].unselect();var startIndex,endIndex,step;startIndex=(lastSelectedRow)?lastSelectedRow.index:0;endIndex=this.index;step=(startIndex<endIndex)?1:-1;for(var i=startIndex;i!=endIndex+step;i+=step)
this.grid.rows[i].select();this.grid.lastSelectedRow=lastSelectedRow;}else if(multiSelectKey){if(this.selected)this.unselect();else this.select();}else{for(var key in this.grid.selectedRows)
this.grid.selectedRows[key].unselect();this.select();}}else if(rightButton){var targetElement;if(e.target)targetElement=e.target;else if(e.srcElement)targetElement=e.srcElement;if(targetElement.nodeName!="TD"&&!this.selected){for(var key in this.grid.selectedRows)
this.grid.selectedRows[key].unselect();this.select();}}
return true;}
Row.prototype.onMouseUp=function(e){this.grid.mouseDownRow=null;document.onmouseup=this.grid.documentOnMouseUp;if(this.grid.onSelectionComplete)
this.grid.onSelectionComplete(e);return true;}
Row.prototype.onMouseOver=function(e){if(this.grid.mouseDownRow&&this.grid.mouseDownRow!=this){if(!this.grid.lastSelectedRow)return;var startIndex=this.grid.lastSelectedRow.index;var endIndex=this.index;var direction=(startIndex<=endIndex)?1:-1;startIndex+=direction;endIndex+=direction;for(var i=startIndex;i!=endIndex;i+=direction)
this.grid.rows[i].select();}}
Row.prototype.onMouseOut=function(e){if(this.grid.mouseDownRow&&this.grid.lastSelectedRow!=this){if(!this.grid.lastSelectedRow)return;var startIndex=this.grid.lastSelectedRow.index;var endIndex=this.index;var direction=(startIndex<endIndex)?1:-1;for(var i=startIndex;i!=endIndex;i+=direction)
this.grid.rows[i].unselect();}}
Row.prototype.onContextMenu=function(e,row){if(!e)var e=window.event;var targetElement;if(e.target)targetElement=e.target;else if(e.srcElement)targetElement=e.srcElement;if(targetElement.nodeName=="TD"&&!row.selected)
return false;if(this.grid.onRowContextMenu){this.grid.onRowContextMenu(e,this);return cancelEvent(e);}else
return true;}
Row.prototype.onDoubleClick=function(e){if(!e)var e=window.event;if(this.grid.onRowDoubleClick)
this.grid.onRowDoubleClick(e,this);}
Row.prototype.select=function(e){if(this.selected)return;this.selected=true;this.grid.selectedRows[this.id]=this;this.grid.lastSelectedRow=this;this.grid.selectedCount++;var previousRow=this.grid.rows[this.index-1];var nextRow=this.grid.rows[this.index+1];var previousRowSelected=(previousRow&&previousRow.selected);var nextRowSelected=(nextRow&&nextRow.selected);this.rowElement.style.backgroundColor=this.grid.styleSelection.backgroundColor;this.rowElement.firstChild.style.borderLeftColor=this.grid.styleSelection.borderLeftColor;this.rowElement.lastChild.style.borderRightColor=this.grid.styleSelection.borderRightColor;for(var i=0;i<this.rowElement.cells.length;i++){if(previousRowSelected){this.rowElement.cells[i].style.borderTopColor=this.grid.styleSelection.backgroundColor;previousRow.rowElement.cells[i].style.borderBottomColor=this.grid.styleSelection.backgroundColor;}else
this.rowElement.cells[i].style.borderTopColor=this.grid.styleSelection.borderTopColor;if(nextRowSelected){this.rowElement.cells[i].style.borderBottomColor=this.grid.styleSelection.backgroundColor;nextRow.rowElement.cells[i].style.borderTopColor=this.grid.styleSelection.backgroundColor;}else
this.rowElement.cells[i].style.borderBottomColor=this.grid.styleSelection.borderBottomColor;}}
Row.prototype.unselect=function(e){if(!this.selected)return;this.selected=false;delete this.grid.selectedRows[this.id];this.grid.lastSelectedRow=this;this.grid.selectedCount--;var previousRow=this.grid.rows[this.index-1];var nextRow=this.grid.rows[this.index+1];var previousRowSelected=(previousRow&&previousRow.selected);var nextRowSelected=(nextRow&&nextRow.selected);this.rowElement.style.backgroundColor=this.grid.styleGrid.backgroundColor;this.rowElement.firstChild.style.borderLeftColor=this.grid.styleGrid.backgroundColor;this.rowElement.lastChild.style.borderRightColor=this.grid.styleGrid.backgroundColor;for(var i=0;i<this.rowElement.cells.length;i++){if(previousRowSelected){this.rowElement.cells[i].style.borderTopColor=this.grid.styleGrid.backgroundColor;previousRow.rowElement.cells[i].style.borderBottomColor=this.grid.styleSelection.borderBottomColor;}else
this.rowElement.cells[i].style.borderTopColor=this.grid.styleGrid.backgroundColor;if(nextRowSelected){this.rowElement.cells[i].style.borderBottomColor=this.grid.styleGrid.backgroundColor;nextRow.rowElement.cells[i].style.borderTopColor=this.grid.styleSelection.borderTopColor;}else
this.rowElement.cells[i].style.borderBottomColor=this.grid.styleGrid.backgroundColor;}}
function getStyleObject(className){if(!document.styleSheets)return null;if(document.styleSheets[0].rules){for(var s=0;s<document.styleSheets.length;s++)
for(var r=0;r<document.styleSheets[s].rules.length;r++)
if(document.styleSheets[s].rules[r].selectorText&&document.styleSheets[s].rules[r].selectorText.toLowerCase()=="."+className.toLowerCase())
return document.styleSheets[s].rules[r].style;}
else if(document.styleSheets[0].cssRules){for(var s=0;s<document.styleSheets.length;s++)
for(var r=0;r<document.styleSheets[s].cssRules.length;r++)
if(document.styleSheets[s].cssRules[r].selectorText&&document.styleSheets[s].cssRules[r].selectorText.toLowerCase()=="."+className.toLowerCase())
return document.styleSheets[s].cssRules[r].style;}
return null;}
function Sort(){}
Sort.types={};Sort.addSortType=function(sortTypeName,comparableValueFunction,compareFunction,defaultFormatFunction){Sort.types[sortTypeName]={name:sortTypeName,comparableValueFunction:comparableValueFunction,compareFunction:compareFunction,defaultFormatFunction:defaultFormatFunction};}
Sort.compareBasic=function(a,b){if(a<b)
return-1;if(a>b)
return 1;return 0;}
Sort.getSelf=function(value){return value;}
Sort.getLowerCase=function(value){return value.toLowerCase();}
Sort.getNumber=function(value){return(+value);}
Sort.getDate=function(value){return new Date(value);}
Sort.formatSFDate=function(value,format){return value.substring(value.indexOf("|")+1,value.length);}
Sort.formatISODate=function(value,format){var str;var date=parseISODate(value);with(date){str=format;str=str.replace("dd",leadingZero(getDate()));str=str.replace("MM",leadingZero(getMonth()+1));str=str.replace("yyyy",getFullYear());str=str.replace("HH",leadingZero(getHours()));str=str.replace("mm",leadingZero(getMinutes()));}
return str;}
function leadingZero(num){return((num<10&&num>=0)?"0":"")+num;}
function parseISODate(value){var isOK,date;var oh=0,om=0;var re=/^(\d{4})?-?(\d\d)?-?(\d\d)?[T ]?(\d\d)?:?(\d\d)?:?(\d\d)?([Z+-])?(\d\d)?:?(\d\d)?$/;isOK=re.test(value);with(RegExp){if($7!="Z"){oh=$7+$8;if($9){om=$7+$9;}}
date=$7?new Date(Date.UTC($1||77,$2-1,$3,$4-oh,$5-om,$6)):new Date($1||77,$2-1,$3,$4,$5,$6);}
return(isOK)?date:null;}
Sort.addSortType("String",Sort.getSelf,Sort.compareBasic,null);Sort.addSortType("CaseInsensitiveString",Sort.getLowerCase,Sort.compareBasic,null);Sort.addSortType("Number",Sort.getNumber,Sort.compareBasic,null);Sort.addSortType("Date",Sort.getDate,Sort.compareBasic,null);Sort.addSortType("SortableFormattedDate",Sort.getSelf,Sort.compareBasic,Sort.formatSFDate);Sort.addSortType("ISODate",Sort.getSelf,Sort.compareBasic,Sort.formatISODate);