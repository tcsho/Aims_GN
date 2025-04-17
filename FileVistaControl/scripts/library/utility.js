
function XmlRequest(method,url,parameters,onComplete,onError,debug){var xmlHttp;if((xmlHttp=createXMLHttp())!=null){xmlHttp.onreadystatechange=function(){onReadyStateChange(xmlHttp,onComplete,onError,debug);}
xmlHttp.open(method,url,true);xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded; charset=UTF-8");xmlHttp.send(parameters);}else{alert("A required object, XMLHttpRequest is not found!");}}
function createXMLHttp(){var xmlHttp;if(window.XMLHttpRequest){try{xmlHttp=new XMLHttpRequest();}catch(e){xmlHttp=null;}}else if(window.ActiveXObject){try{xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");}catch(e){try{xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");}catch(e){xmlHttp=null;}}}
return xmlHttp;}
function onReadyStateChange(xmlHttp,onComplete,onError,debug){var status,statusText;if(xmlHttp.readyState==4){try
{if(xmlHttp.status!==undefined&&xmlHttp.status!=0){status=xmlHttp.status;statusText=xmlHttp.statusText;}
else{status=13030;statusText="Network error";}}
catch(e){status=13030;statusText="Network error";}
if(status==200){if(onComplete)onComplete(xmlHttp);}else{if(status!=13030)statusText+=" (Error "+status+")";if(debug)statusText+="\n\nError details:\n"+xmlHttp.responseText;if(onError)onError(statusText);}}}
function formatSize(size){var units=["B","KB","MB","GB","TB"];var unitDecimals=[0,0,2,2,2];var unitsCount=units.length-1;if(size=="")return"";size=(+size);var i=0;while(size>=1024&&i<unitsCount){size/=1024;i++;}
return size.toFixed(unitDecimals[i])+" "+units[i];}
function trim(s){while(s.substring(0,1)==' ')
s=s.substring(1,s.length);while(s.substring(s.length-1,s.length)==' ')
s=s.substring(0,s.length-1);return s;}
function createUniqueID(){return(new Date()).getTime()+""+Math.floor((Math.random()*8999)+1000);}
function getClassName(obj)
{if(obj&&obj.constructor&&obj.constructor.toString)
{var arr=obj.constructor.toString().match(/function\s*(\w+)/);return arr&&arr.length==2?arr[1]:undefined;}
else
{return undefined;}}
function Language(){this.strings=new Object();}
Language.prototype.addString=function(key,value){this.strings[key]=value;}
Language.prototype.getString=function(key,r0,r1,r2){var value=this.strings[key];if(r0)value=value.replace(/\{0\}/g,r0);if(r1)value=value.replace(/\{1\}/g,r1);if(r2)value=value.replace(/\{2\}/g,r2);return value;}
function enableElement(id,enabled,value,keepValue){var element=document.getElementById(id);element.disabled=!enabled;if(keepValue)
return element;if(element.type=="text"||element.type=="password")
element.value=(value!=null)?value:"";else if(element.type=="checkbox"||element.type=="radio")
element.checked=(value!=null)?value:false;else if(element.type=="select-one")
element.selectedIndex=(value!=null)?value:-1;return element;}
function strf(str){var outp="";for(i=0;i<=str.length;i++){outp=str.charAt(i)+outp;}
return outp;}
function findPosition(element){var curleft=curtop=0;if(element.offsetParent){curleft=element.offsetLeft;curtop=element.offsetTop;while(element=element.offsetParent){curleft+=element.offsetLeft;curtop+=element.offsetTop;}}
return[curleft,curtop];}
function getCurrentTimeString(){var timeString;with(new Date())
timeString=((((getFullYear()*100+getMonth()+1)*100+getDate())*100+getHours())*100+getMinutes())*100+getSeconds();return timeString;}
function addEvent(obj,eventType,eventFunction){if(obj.addEventListener){obj.addEventListener(eventType,eventFunction,false);return true;}else if(obj.attachEvent){var r=obj.attachEvent("on"+eventType,eventFunction);return r;}else{return false;}}
function removeEvent(obj,eventType,eventFunction){if(obj.removeEventListener){obj.removeEventListener(eventType,eventFunction,false);return true;}else if(obj.detachEvent){var r=obj.detachEvent("on"+eventType,eventFunction);return r;}else{return false;}}
function cancelEvent(e){if(!e)var e=window.event;e.cancelBubble=true;if(e.stopPropagation)e.stopPropagation();e.returnValue=false;if(e.preventDefault)e.preventDefault();return false;}
function cancelEventExceptForTextInput(e){if(!e)var e=window.event;var targetElement;if(e.target)targetElement=e.target;else if(e.srcElement)targetElement=e.srcElement;if(targetElement.nodeType==3)
targetElement=targetElement.parentNode;if(targetElement.type=="text"||targetElement.type=="password"||targetElement.type=="textarea"||targetElement.type=="file")
return true;else
return cancelEvent(e);}
function PaneSeparator(elementContainer,elementLeftPane,elementSeparator,elementRightPane,containerMargin){this.dragging=false;this.elementContainer=elementContainer;this.elementLeftPane=elementLeftPane;this.elementSeparator=elementSeparator;this.elementRightPane=elementRightPane;this.containerMargin=containerMargin;var paneSeparator=this;this.elementSeparator.onmousedown=function(e){paneSeparator.onDragStart(e);};}
PaneSeparator.prototype.onDragStart=function(e){if(!e)var e=window.event;var leftButton=(e.which)?(e.which==1):(e.button==1);if(!leftButton)return;var paneSeparator=this;this.dragging=true;this.containerLeftPosition=findPosition(this.elementContainer)[0];this.elementContainer.onmouseup=function(e){paneSeparator.onDragStop(e);};this.elementContainer.onmousemove=function(e){paneSeparator.onDrag(e);};}
PaneSeparator.prototype.onDragStop=function(e){this.dragging=false;this.elementContainer.onmouseup=null;this.elementContainer.onmousemove=null;}
PaneSeparator.prototype.onDrag=function(e){if(!this.dragging)return;var posx=0;var posy=0;if(!e)var e=window.event;var pageWidth=this.elementContainer.offsetWidth-(this.containerMargin*2);posx=(e.pageX)?e.pageX:e.clientX+Viewport.getScrollLeft();posx-=this.containerLeftPosition;this.elementLeftPane.style.width=posx+"px";this.elementSeparator.style.left=posx+"px";this.elementRightPane.style.width=(pageWidth-posx-this.elementSeparator.offsetWidth)+"px";this.elementRightPane.style.left=(posx+this.elementSeparator.offsetWidth)+"px";}
function Viewport(){}
Viewport.getWidth=function(){var x;if(self.innerHeight){x=self.innerWidth;}else if(document.documentElement&&document.documentElement.clientHeight){x=document.documentElement.clientWidth;}else if(document.body){x=document.body.clientWidth;}
return x;}
Viewport.getHeight=function(){var y;if(self.innerHeight){y=self.innerHeight;}else if(document.documentElement&&document.documentElement.clientHeight){y=document.documentElement.clientHeight;}else if(document.body){y=document.body.clientHeight;}
return y;}
Viewport.getScrollLeft=function(){var x;if(self.pageXOffset||self.pageYOffset){x=self.pageXOffset;}else if(document.documentElement&&(document.documentElement.scrollLeft||document.documentElement.scrollTop)){x=document.documentElement.scrollLeft;}else if(document.body){x=document.body.scrollLeft;}
return x;}
Viewport.getScrollTop=function(){var y;if(self.pageXOffset||self.pageYOffset){y=self.pageYOffset;}else if(document.documentElement&&(document.documentElement.scrollLeft||document.documentElement.scrollTop)){y=document.documentElement.scrollTop;}else if(document.body){y=document.body.scrollTop;}
return y;}
Viewport.getScrollWidth=function(){var x;if(document.documentElement&&(document.documentElement.scrollWidth||document.documentElement.scrollHeight)){x=document.documentElement.scrollWidth;}else if(document.body){x=document.body.scrollWidth;}
return x;}
Viewport.getScrollHeight=function(){var y;if(document.documentElement&&(document.documentElement.scrollWidth||document.documentElement.scrollHeight)){y=document.documentElement.scrollHeight;}else if(document.body){y=document.body.scrollHeight;}
return y;}
function setOpacity(element,opacity){element.style.opacity=(opacity/10);element.style.filter="alpha(opacity="+(opacity*10)+")";}
function selectInputText(field,start,end){if(field.createTextRange){var selRange=field.createTextRange();selRange.collapse(true);selRange.moveStart('character',start);selRange.moveEnd('character',end-start);selRange.select();}else if(field.setSelectionRange){field.setSelectionRange(start,end);}else if(field.selectionStart){field.selectionStart=start;field.selectionEnd=end;}
field.focus();}
function getNameWithoutExtension(fullName){var name;var dotIndex=fullName.lastIndexOf(".");if(dotIndex>0)
name=fullName.substr(0,dotIndex);else
name=fullName;return name;}
function getExtension(fullName){var extension;var dotIndex=fullName.lastIndexOf(".");if(dotIndex>0)
extension=fullName.substr(dotIndex+1,fullName.length);else
extension="";return extension;}
function calculateDimensions(element,callback){var hiddenParentNodes=[];var currentNode=element;while(currentNode&&currentNode!==document){if(currentNode.style.display=="none"){hiddenParentNodes.push(currentNode);}
currentNode=currentNode.parentNode;}
if(hiddenParentNodes&&hiddenParentNodes.length>0){var styles={visibility:"hidden",display:"block"};for(var i=0;i<hiddenParentNodes.length;i++){var currentNode=hiddenParentNodes[i];currentNode.originalStyle={};for(var name in styles){currentNode.originalStyle[name]=currentNode.style[name];currentNode.style[name]=styles[name];}}
callback(element);for(var i=0;i<hiddenParentNodes.length;i++){var currentNode=hiddenParentNodes[i];for(var name in styles){currentNode.style[name]=currentNode.originalStyle[name];}
try{delete currentNode.originalStyle;}catch(e){currentNode.originalStyle=null}}}else{callback(element);}}
function selectRange(elementID){deSelectAllRanges();if(document.selection){var range=document.body.createTextRange();range.moveToElementText(document.getElementById(elementID));range.select();}
else if(window.getSelection){var range=document.createRange();range.selectNode(document.getElementById(elementID));window.getSelection().addRange(range);}}
function deSelectAllRanges(){if(document.selection)
document.selection.empty();else if(window.getSelection)
window.getSelection().removeAllRanges();}