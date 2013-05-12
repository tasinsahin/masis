
function DisableButton(buttonName)
{
	if (buttonName == "")
		return;		
	var button = document.getElementById(buttonName);
	if (typeof(button) == "undefined")
		return;		
	button.enabled = false;
	button.className="toolButtonDisabled";
}
function EnableButton(buttonName)
{
	if (buttonName == "")
		return;		
	var button = document.getElementById(buttonName);
	if (typeof(button) == "undefined")
		return;		
	button.enabled = true
	button.className="toolButton";

}

function getElem(Jb)
{
    return document.getElementById(Jb);
}
function getOpenerElem(Jb)
{
	return window.opener.document.getElementById(Jb);
}
function SetObjectEqualTo(sControl, NewValue)
{
	
	var oObject = getElem(sControl);
	oObject.value = NewValue;
	return oObject;
}
function SetOpenerObjectEqualTo(sControl, NewValue)
{
	var oObject = window.opener.document.getElementById(sControl);
	oObject.value = NewValue;
	return oObject;
}		
function displayFixedDecimal(value) 
{
	var formattedValue;
	if (value.indexOf(".") == -1) 
		value = value + ".00";
	else
		if (value.indexOf(".") + 1 != value.length - value.indexOf(".")) value = value + "0";
	var decimalPos = value.indexOf('.');
	if (decimalPos > -1) 
	{
		var decimalLength = value.length - (decimalPos + 1);
		if (decimalPos == 0) 
		{
			value = "0" + value;
			decimalPos += 1;
		}

		if (decimalLength > 2) {
			//incase get formattedValue such as 17.253
			formattedValue = value.substr(0, decimalPos + 3);
		} else if (decimalLength == 2) {
			formattedValue = value + "";
		} else if (decimalLength == 1) {
			formattedValue = value + "0";
		} else if (decimalLength == 0) {
			formattedValue = value + "00";
		} else {
			formattedValue = value + ".00";
		}		
		if (formattedValue.indexOf('.') == 0) formattedValue = "0" + formattedValue;
	} 
	
	return formattedValue;
}
 
function GetCellValue(oTable, RowNumber, ColumnNumber, OnlyReadOnly)
{		
	var sValue;
	var dValue=0;
	var dReturn=0;
	var oCell = oTable.rows(RowNumber).cells(ColumnNumber);	
	if (oCell.innerText=="" || oCell.innerHTML=="")
	{
		if (OnlyReadOnly == false)
		{			
			sValue = oCell.childNodes.item(0).value;
			dValue = parseFloat(sValue);
			if (isNaN(dValue))
			{}
			else
				dReturn = dValue;
		}
	}
	else
	{
		// must be a read only row
		dValue = parseFloat(oCell.innerText);
		if (isNaN(dValue))
		{
		}
		else
			dReturn = dValue;
	}
	oCell = null;
	return dReturn;
	
}
function GetCellText(oTable, RowNumber, ColumnNumber, OnlyReadOnly, ChildNodeNumber)
{		
	var sReturn="";
	if (ChildNodeNumber == null) ChildNodeNumber = 0;
	var oCell = oTable.rows(RowNumber).cells(ColumnNumber);	
	if (oCell.getElementsByTagName("SELECT").length==1 && OnlyReadOnly == false)
	{
		sReturn = oCell.childNodes.item(ChildNodeNumber).value;
	}
	else if (oCell.getElementsByTagName("INPUT").length==1 && OnlyReadOnly == false)
	{
		sReturn = oCell.childNodes.item(ChildNodeNumber).value;
	}
	else if (oCell.getElementsByTagName("TEXTAREA").length==1 && OnlyReadOnly == false)
	{
		sReturn = oCell.childNodes.item(ChildNodeNumber).value;
	}
	else if (oCell.getElementsByTagName("A").length==1 && OnlyReadOnly == false)
	{
		sReturn = oCell.childNodes.item(ChildNodeNumber).value;
	}
	else
		sReturn = oCell.innerText;	
	oCell = null;
	return sReturn;
	
}

function ClearTable(sTable)
{
	// Clear the table
	if (typeof(sTable) != "object")
	{
		//Try to create it (in case the string was passed)
		oTable=getElem(sTable)
		if (oTable == null) return
	}
	else
	{
		oTable = sTable
	}	
	var iCount = oTable.rows.length-1
	for (i = 0; oTable.rows.length; i++)
	{
		oTable.deleteRow(0);
	}
}
function SelectTableRow(TableId, RowId, RowNumber)
{
	var oTable = getElem(TableId);	
	for(i=0;i<oTable.rows.length;i++)
	{
		var row = getElem(RowId + i)
		
		if (i==RowNumber)
		{
			if (i % 2 ==0)
				row.className="DataGridItemAltSelectedItem"
			else
				row.className="DataGridItemSelectedItem"
		}
		else
		{
			if (i % 2 ==0)
				row.className="DataGridItemAlt"
			else
				row.className="DataGridItem"
		}

	}
}

// String Extensions
String.prototype.lTrim=function()
{
    return this.replace(/^(\s|\xA0)*/,"");
};
String.prototype.rTrim=function()
{
    return this.replace(/(\s|\xA0)*$/,"");
};
String.prototype.trim=function()
{
    return this.rTrim().lTrim();
};
String.prototype.endsWith=function(c)
{
    return this.substr(this.length-c.length)==c;
};
String.prototype.startsWith=function(e)
{
    return this.substr(0,e.length)==e;
};
String.prototype.format=function()
{
    var s=this;
    for(var i=0;
    i<arguments.length;i++)
    {
        s=s.replace("{"+i+"}",arguments[i]);
    }
    return s;
};
String.prototype.removeSpaces=function()
{
    return this.replace(/ /ig,"");
};
String.prototype.removeExtraSpaces=function()
{
    return this.replace(String.prototype.removeExtraSpaces.re," ");
};
String.prototype.removeExtraSpaces.re=new RegExp("\\s+","g");
String.prototype.removeSpaceDelimitedString=function(r)
{
    var s=" "+this.trim()+" ";
    return s.replace(" "+r,"").rTrim();
};
String.prototype.encodeURI=function()
{
    var returnString;
    returnString=escape(this);
    returnString=returnString.replace(/\+/g,"%2B");
    return returnString;
};
String.prototype.decodeURI=function()
{
    return unescape(this);
};
String.prototype.encodeHtml=function()
{
    var returnString=this.replace(/\>/g,"&gt;").replace(/\</g,"&lt;").replace(/\&/g,"&amp;").replace(/\'/g,"&#039;").replace(/\"/g,"&quot;");
    return returnString;
};

// Array Extensions
Array.prototype.indexOf=function(R)
{
    for(var i=0;
    i<this.length;i++)
    {
        if(this[i]==R)
            return i;
    }
    return -1;
};
Array.prototype.exists=function(S)
{
    return this.indexOf(S)!=-1;
};
Array.prototype.add=Array.prototype.queue=function(T)
{
    this.push(T);
};
Array.prototype.addRange=function(U)
{
    var length=U.length;
    if(length!=0)
        for(var index=0;
        index<length;index++)
        {
            this.push(U[index]);
        }
};
Array.prototype.contains=function(V)
{
    var index=this.indexOf(V);
    return index>=0;
};
Array.prototype.dequeue=function()
{
    return this.shift();
};
Array.prototype.insert=function(W,X)
{
    this.splice(W,0,X);
};
Array.prototype.clone=function()
{
    var clonedArray=[];
    var length=this.length;
    for(var index=0;
    index<length;index++)
    {
        clonedArray[index]=this[index];
    }
    return clonedArray;
};
Array.prototype.removeAt=function(Y)
{
    return this.splice(Y,1);
};
Array.prototype.remove=function(o)
{
    var i=this.indexOf(o);
    if(i>-1)
        this.splice(i,1);
    return i>-1;
};
Array.prototype.clear=function()
{
    if(this.length>0)
        this.splice(0,this.length);
}




function Anthem_PreCallBack() {
			var loading = document.createElement("div");
			loading.id = "loading";
			loading.style.color = "black";
			loading.style.backgroundColor = "red";
			loading.style.paddingLeft = "5px";
			loading.style.paddingRight = "5px";
			loading.style.position = "absolute";
			loading.style.right = "10px";
			loading.style.top = "10px";
			loading.style.zIndex = "9999";
			loading.innerHTML = "Yükleniyor...";
			document.body.appendChild(loading);
		}
		function Anthem_CallBackCancelled() {
			alert("Your call back was cancelled!");
		}
		function Anthem_PostCallBack() {
			var loading = document.getElementById("loading");
			document.body.removeChild(loading);
		}		
		
			function disableButton(buttonID) {
				document.getElementById(buttonID).disabled=true;
			}



function CallPrint(strid)
{
 var prtContent = document.getElementById(strid);
 var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
 WinPrint.document.write(prtContent.innerHTML);
 WinPrint.document.close();
 WinPrint.focus();
 WinPrint.print();
 WinPrint.close();
 //prtContent.innerHTML=strOldOne;
}

function SetValue(obj, str) 
{       
        switch (obj.type) {
			 case "text":
				elem.value = str;
                break;
            case "radio":
				elem.checked = str;
                break;
            case "checkbox":
                elem.checked = str;
                break;
            case "select-one":
                elem.selectedIndex = str;
                break;
            case "select-multiple":
                elem.selectedIndex = str;
                break;
            default:
                elem.value = unescape(str);
        }    
}


function GetUnitDetails()
{
var Units = document.getElementById("ddlUnits");
var UnitId = Units.options[Units.selectedIndex].value;

ProductDetails.GetUnitDetails(ProductId,UserId,UnitId,GetUnitDetails_CallBack);
}
function GetUnitDetails1()
{
var Units = document.getElementById("ddlUnits");
var UnitId = Units.options[Units.selectedIndex].value;

ProductDetailsList.GetUnitDetails(ProductId,UserId,UnitId,GetUnitDetails_CallBack);
}
function GetUnitDetails_CallBack(response)
{
//alert(response.value);
	if (response.error != null)
	{
	return;
	}
	if (response.value == null)
	{
	return;
	}
	
		var s = response.value.split("|");
		var lblPrice = document.getElementById("lblPrice");
		var lblCur = document.getElementById("lblCur");
		var lblCur1 = document.getElementById("lblCur1");
		var lblMainPrice = document.getElementById("lblMainPrice");
		var lblOzelFiyat = document.getElementById("lblOzelFiyat");
		var lblTransferFiyat = document.getElementById("lblTransferFiyat");
		var img = document.getElementById("img");
	lblPrice.innerText=s[0]
	lblCur.innerText=s[1]
	//lblCur1.innerText=s[1]
	lblMainPrice.innerText=s[2]
	if (lblOzelFiyat  != null)
	{
	lblOzelFiyat.innerText=s[3]
	}
	if (lblCur1  != null)
	{
	lblCur1.innerText=s[1]
	}
	if (lblTransferFiyat  != null)
	{
	lblTransferFiyat.innerText=s[4]
	}
}

    function ShowViewStateSize()
    {
        var buf = document.forms[0]["__VIEWSTATE"].value;
        alert("View state is " + buf.length + " bytes");
    }

function adjustIFrameSize (iframeWindow) {
  if (iframeWindow.document.height) {
    var iframeElement = document.getElementById(iframeWindow.name);
    iframeElement.style.height = iframeWindow.document.height + 'px';
    iframeElement.style.width = iframeWindow.document.width + 'px';
  }
  else if (document.all) {
    var iframeElement = document.all[iframeWindow.name];
    if (iframeWindow.document.compatMode &&
        iframeWindow.document.compatMode != 'BackCompat') 
    {
      iframeElement.style.height = iframeWindow.document.documentElement.scrollHeight +  'px';
      iframeElement.style.width = iframeWindow.document.documentElement.scrollWidth + 'px';
    }
    else {
      iframeElement.style.height = iframeWindow.document.body.scrollHeight + 'px';
      iframeElement.style.width = iframeWindow.document.body.scrollWidth + 'px';
    }
  }
}
function tabOnClick(ID)
{
	var oElement = null;
	for (var i = 0; i < tabs.length; i++)
	{
		oElement = document.getElementById(i);
		oElement.className = "TabItem";
	}

	oElement = document.getElementById(ID);
	oElement.className = "TabSelected";
	var tab = tabs[ID].split("|");
	divTabFrame.innerHTML = "<IFRAME ID='iframeName' NAME='iframeName' SCROLLING='NO' FRAMEBORDER='0' WIDTH='100%' HEIGHT='100%' SRC="+tab[1]+" ></IFRAME>";
	document.body.focus();
	//
}

function tabLoad()
{
	var HTML = "";
	HTML += "<P >";
	for (var i = 0; i < tabs.length; i++)
	{
		var tab = tabs[i].split("|");
		HTML += "<a href='#Tabs'  ID="+i+" CLASS='TabItem'  onClick='tabOnClick("+i+")'>"+tab[0]+"</a>";
	}

	divTabButtons.innerHTML = HTML;
	for (var i = 0; i < tabs.length; i++)
	{
		var tab = tabs[i].split("|");
		if (tab[2] == "*")
		{
			tabOnClick(i);	
			break;			
		}
	}
}
function Search()
{

var txt = document.getElementById('txtSearch');
var Cat = document.getElementById('ddlCategories');
var Mark = document.getElementById('ddlMarks');
var P1 = document.getElementById('txtPrice1');
var P2 = document.getElementById('txtPrice2');
var url ='ProductSearch.aspx?';
var btn = document.getElementById('lnkWord');
var cName=document.getElementById('chkName');
var cDetails=document.getElementById('chkDetails');
//if (txt.value.length > 1)
//{
url=url + 'value='+ txt.value
//Category
if (Cat  != null)
	{
	var CatId = Cat.options[Cat.selectedIndex].value;
	url=url + '&CatId='+ CatId
	}
if (Mark  != null)
	{
	var MarkId = Mark.options[Mark.selectedIndex].value;
	url=url + '&MarkId='+ MarkId
	}
if (P1  != null)
	{
	url=url + '&P1='+ P1.value
	}
if (P2  != null)
	{
	url=url + '&P2='+ P2.value
	}
if (cDetails.checked)
	{
	url=url + '&Details=True'
	}
if (cName.checked)
	{
	url=url + '&Name=True'
	}
else
	{
	url=url + '&Name=False'
	}
	
//btn.style.cursor='wait';
//txt.style.cursor='wait';
document.location.href=url
//}
//if (txt.value.length < 2)
//{
//alert('Arama Kriteri olarak en az iki harf girmelisiniz.')
//event.returnValue=false;
//}
}

function LigthSearch(txt,btn)
{
var txt = document.getElementById(txt);
var url ='/store/productsearch.aspx?';
var btn = document.getElementById(btn);
if (txt.value.length > 2)
{
btn.style.cursor='wait';
txt.style.cursor='wait';
url=url + 'value='+ txt.value
document.location.href=url
//event.returnValue=false;
}
if (txt.value.length <= 2)
{

alert('Arama Kriteri olarak en az üç harf girmelisiniz.');
//event.returnValue=false;
}

}

function ContentSearch(txt)
{
var txt = document.getElementById(txt);
var url ='/search.aspx?';
if (txt.value.length > 2)
{
txt.style.cursor='wait';
url=url + 'value='+ txt.value
document.location.href=url
}
if (txt.value.length <= 2)
{
alert('Arama Kriteri olarak en az üç harf girmelisiniz.');
//event.returnValue=false;
}
}

function FilterCategory(Cat,Mark,_tabId)
{
DisableControls()
CategoriesMarksFilter.GetCategoryDetails(Cat.options[Cat.selectedIndex].value,Mark.options[Mark.selectedIndex].value,Mark.options[Mark.selectedIndex].text,GetCategoryDetails_CallBack);
}
function FilterCategoryb2b(Cat,Mark,_tabId)
{
DisableControls()
CategoriesMarksFilterb2b.GetCategoryDetails(Cat.options[Cat.selectedIndex].value,Mark.options[Mark.selectedIndex].value,Mark.options[Mark.selectedIndex].text,GetCategoryDetails_CallBack);
}
function GetCategoryDetails_CallBack(response)
{
if (response.value != null)
{
document.location.href=response.value	
}
else
{
EnableControls()
}
	
}
function FilterMark(Cat,Mark,_tabId)
{
DisableControls()
CategoriesMarksFilter.GetMarkDetails(Cat.options[Cat.selectedIndex].value,Mark.options[Mark.selectedIndex].value,Mark.options[Mark.selectedIndex].text,GetCategoryDetails_CallBack);
}
function FilterMarkb2b(Cat,Mark,_tabId)
{
DisableControls()
CategoriesMarksFilterb2b.GetMarkDetails(Cat.options[Cat.selectedIndex].value,Mark.options[Mark.selectedIndex].value,Mark.options[Mark.selectedIndex].text,GetCategoryDetails_CallBack);
}
//LigthSearch1(cntrlCat,cntrlMark,cntrlTabId,cntrltxtSearch,cntrlbtnSearch);
function LigthSearch1(Cat,Mark,_tabId,txt,btn)
{
if (txt.value.length > 2)
{
DisableControls()
btn.style.cursor='wait';
txt.style.cursor='wait';
CategoriesMarksFilterb2b.GetSearchDetails(Cat.options[Cat.selectedIndex].value,Mark.options[Mark.selectedIndex].value,Mark.options[Mark.selectedIndex].text,txt.value,GetCategoryDetails_CallBack);
//event.returnValue=false;
}
if (txt.value.length <= 2)
{
alert('Arama Kriteri olarak en az üç harf girmelisiniz.');
//event.returnValue=false;
}
}
function DisableControls()
{
cntrlCat.disabled='disabled';
cntrlMark.disabled='disabled';
if (cntrlbtnSearch != null)
{
cntrlbtnSearch.disabled='disabled';
}
if (cntrltxtSearch != null)
{
cntrltxtSearch.disabled='disabled';
}
}
function EnableControls()
{
cntrlCat.disabled='';
cntrlMark.disabled='';
if (cntrlbtnSearch != null)
{
cntrlbtnSearch.disabled='';
}
if (cntrltxtSearch != null)
{
cntrltxtSearch.disabled='';
}
}
  function GetMainProducts() 
        {
        HomeProducts.LoadMainPageProducts1(GetMainProductsCallback);
        }
    function GetMainProductsCallback(res)
        {
      
        document.getElementById("_ctl4_pnlList").innerHTML = res.value;
        }
 
 function flash(w,h,u,t) 
 {
	document.write("<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='"+w+"' height='"+h+"'><param name='movie' value='"+u+"'><param name='quality' value='high'>");
	if(t=="y")
	{
		document.write("<param name='wmode' value='transparent'>");
	}
	document.write("<embed src='"+u+"' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='"+w+"' height='"+h+"'></embed></object>");
}

  
    function CheckAllDataGridCheckBoxes(aspCheckBoxID, checkVal) {

        re = new RegExp(aspCheckBoxID) 
        for(i = 0; i < document.forms[0].elements.length; i++) 
        {
            elm = document.forms[0].elements[i]
            if (elm.type == 'checkbox') 
			{
				if (re.test(elm.name)) 
				{
				elm.checked = checkVal
                }
            }
        }
    }



function GetVaryantDetails()
{
var Units = document.getElementById("ddlUnits");
var UnitId = Units.options[Units.selectedIndex].value;
var rpt=document.getElementById("rptQuestions");
ProductDetails.GetVaryantDetails(ProductId,UserId,UnitId,rpt,GetVaryantDetails_CallBack);
}

function GetVaryantDetails_CallBack(response)
{
//alert(response.value);
	if (response.error != null)
	{
	return;
	}
	if (response.value == null)
	{
	return;
	}
	
		var s = response.value.split("|");
		var lblPrice = document.getElementById("lblPrice");
		var lblCur = document.getElementById("lblCur");
		var lblCur1 = document.getElementById("lblCur1");
		var lblMainPrice = document.getElementById("lblMainPrice");
		var lblOzelFiyat = document.getElementById("lblOzelFiyat");
		var lblTransferFiyat = document.getElementById("lblTransferFiyat");
		var img = document.getElementById("img");
	lblPrice.innerText=s[0]
	lblCur.innerText=s[1]
	//lblCur1.innerText=s[1]
	lblMainPrice.innerText=s[2]
	if (lblOzelFiyat  != null)
	{
	lblOzelFiyat.innerText=s[3]
	}
	if (lblCur1  != null)
	{
	lblCur1.innerText=s[1]
	}
	if (lblTransferFiyat  != null)
	{
	lblTransferFiyat.innerText=s[4]
	}
}
function resizeWin() 
{
winHeight=document.getElementById('bodyArea').offsetHeight; 
winWidth=document.getElementById('bodyArea').offsetWidth; 
window.resizeTo(winWidth+50,winHeight+ 100); 
if (window.moveTo) window.moveTo((screen.availWidth-winWidth)/2,(screen.availHeight-winHeight)/2); 
} 

 function openChat() 
 { 
  var ref =""
  if (document.referrer != '')
  {
  ref=document.referrer;
  }
 var win = window.open(BaseUrl + '/chat.aspx?referrer=' + ref, 'chat', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,width=630,height=450'); 
 win.focus(); 
 win.opener = window; 
 return false; 
 } 
 
/* vindow resize */
function resizeWin(maxX,maxY,speed,delay,win){ 
    this.obj = "resizeWin" + (resizeWin.count++); 
    eval(this.obj + "=this"); 
    if (!win)     this.win = self;    else this.win = eval(win); 
    if (!maxX)    this.maxX = 400;    else this.maxX = maxX; 
    if (!maxY)    this.maxY = 300;    else this.maxY = maxY; 
    if (!speed)   this.speed = 1/5;   else this.speed = 1/speed; 
    if (!delay)   this.delay = 0;    else this.delay = delay; 
    this.doResize = (document.all || document.getElementById); 
    this.stayCentered = false; 

    this.initWin =     function(){ 
        if (this.doResize){ 
            this.resizeMe(); 
            } 
        else { 
            this.win.resizeTo(this.maxX + 10, this.maxY - 20); 
            } 
        } 

    this.resizeMe = function(){ 
        this.win.focus(); 
        this.updateMe(); 
        } 

    this.resizeTo = function(x,y){ 
        this.maxX = x; 
        this.maxY = y; 
        this.resizeMe(); 
        } 

    this.stayCentered = function(){ 
        this.stayCentered = true; 
        } 

    this.updateMe = function(){ 
        this.resizing = true; 
        var x = Math.ceil((this.maxX - this.getX()) * this.speed); 
        var y = Math.ceil((this.maxY - this.getY()) * this.speed); 
        if (x == 0 && this.getX() != this.maxX) { 
            if (this.getX() > this.maxX) x = -1; 
            else  x = 1; 
            } 
        if (y == 0 && this.getY() != this.maxY){ 
            if (this.getY() > this.maxY) y = -1; 
            else y = 1; 
            } 
        if (x == 0 && y == 0) { 
            this.resizing = false; 
            } 
        else { 
            this.win.top.resizeBy(parseInt(x),parseInt(y)); 
            if (this.stayCentered == true) this.win.moveTo((screen.width - this.getX()) / 2,(screen.height - this.getY()) / 2); 
            setTimeout(this.obj + '.updateMe()',this.delay) 
            } 
        } 

    this.write =  function(text){ 
        if (document.all && this.win.document.all["coords"]) this.win.document.all["coords"].innerHTML = text; 
        else if (document.getElementById && this.win.document.getElementById("coords")) this.win.document.getElementById("coords").innerHTML = text; 
        } 

    this.getX =  function(){ 
        if (document.all) return (this.win.top.document.body.clientWidth + 10) 
        else if (document.getElementById) 
            return this.win.top.outerWidth; 
        else return this.win.top.outerWidth - 12; 
    } 

    this.getY = function(){ 
        if (document.all) return (this.win.top.document.body.clientHeight + 29) 
        else if (document.getElementById) 
            return this.win.top.outerHeight; 
        else return this.win.top.outerHeight - 31; 
    } 

    this.onResize =  function(){ 
        if (this.doResize){ 
            if (!this.resizing) this.resizeMe(); 
            } 
        } 

    return this; 
} 
resizeWin.count = 0;  

// popup
PositionX = 100;
PositionY = 100;
defaultWidth  = 50;
defaultHeight = 50;
var AutoClose = true;
if (parseInt(navigator.appVersion.charAt(0))>=4){
var isNN=(navigator.appName=="Netscape")?1:0;
var isIE=(navigator.appName.indexOf("Microsoft")!=-1)?1:0;}
var optNN='scrollbars=no,width='+defaultWidth+',height='+defaultHeight+',left='+PositionX+',top='+PositionY;
var optIE='scrollbars=no,width=100,height=100,left='+PositionX+',top='+PositionY;
function popImage(imageURL,imageTitle){
if (isNN){imgWin=window.open('about:blank','',optNN);}
if (isIE){imgWin=window.open('about:blank','',optIE);}
with (imgWin.document){
writeln('<html><head><title>Yükleniyor...</title><style>body{margin:0px;}</style>');writeln('<sc'+'ript>');
writeln('var isNN,isIE;');writeln('if (parseInt(navigator.appVersion.charAt(0))>=4){');
writeln('isNN=(navigator.appName=="Netscape")?1:0;');writeln('isIE=(navigator.appName.indexOf("Microsoft")!=-1)?1:0;}');
writeln('function reSizeToImage(){');writeln('if (isIE){');writeln('window.resizeTo(300,300);');
writeln('width=300-(document.body.clientWidth-document.images[0].width);');
writeln('height=300-(document.body.clientHeight-document.images[0].height);');
writeln('window.resizeTo(width,height);}');writeln('if (isNN){');       
writeln('window.innerWidth=document.images["myimg"].width;');writeln('window.innerHeight=document.images["myimg"].height;}}');
writeln('function doTitle(){document.title="'+imageTitle+'";}');writeln('</sc'+'ript>');
if (!AutoClose) writeln('</head><body  scroll="no" onload="reSizeToImage();doTitle();self.focus()">')
else writeln('</head><body scroll="no" onload="reSizeToImage();doTitle();self.focus()" onblur="self.close()">');
writeln('<center><img title="Kapat" onclick="window.close()" name="myimg" src='+imageURL+' style="display:block"><center/></body></html>');
close();		
}}

function createReq()
{
    // Create XMLHTTP compatible in various browsers
    try
    {
         req = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch(e)
    {
         try
         {
              req = new ActiveXObject("Microsoft.XMLHTTP");
         }
         catch(oc)
         {
              req = null;
         }
    }

    if (!req && typeof XMLHttpRequest != "undefined")
    {
        req = new XMLHttpRequest();
    }
    
    return req;
}


 



function doUrl(str){
var s =str.toLowerCase()
     return s.replace(/ /g, "-").replace(/&/g, "-").replace("|", "-").replace('"', '-').replace(/ı/g, "i").replace(/ğ/g, "g").replace(/ü/g, "u").replace(/ş/g, "s").replace(/ö/g, "o").replace(/ç/g, "c").replace(/î/g, "i").replace(/é/g, "e").replace(/â/g, "a").replace("?", "").replace(".", "").replace("'", "-").replace(",", "").replace("\\", "-").replace("*", "-").replace(":", "-").replace(";", "-").replace("(", "-").replace(")", "-").replace("index.html", "-")
     //return s.replace(/ /g, "-").replace(/&/g, "-").replace(/|/g, "-").replace('"', '-').replace(/ı/g, "i").replace(/ğ/g, "g").replace(/ü/g, "u").replace(/ş/g, "s").replace(/ö/g, "o").replace(/ç/g, "c").replace(/î/g, "i").replace(/é/g, "e").replace(/â/g, "a").replace(/?/g, "").replace(/./g, "").replace("'", "-").replace(/,/g, "").replace("\\", "-").replace("*", "-").replace(/:/g, "-").replace(/;/g, "-").replace(/(/g, "-").replace(/)/g, "-").replace("/", "-")
  } 
    
//productsearch.ascx
function LigthSearchx(txt,btn)
{
var txt = document.getElementById(txt);
var url ='/store/productsearch.aspx?';
var btn = document.getElementById(btn);
if (txt.value.length > 2)
{
btn.style.cursor='wait';
txt.style.cursor='wait';
document.location.href=url + 'value='+ txt.value;
//event.returnValue=false;
}
if (txt.value.length < 3)
{
alert('Arama Kriteri olarak en az üç harf girmelisiniz.');
//event.returnValue=false;
}

}

if(typeof deconcept=="undefined"){var deconcept=new Object();}
if(typeof deconcept.util=="undefined"){deconcept.util=new Object();}
if(typeof deconcept.SWFObjectUtil=="undefined"){deconcept.SWFObjectUtil=new Object();}
deconcept.SWFObject=function(_1,id,w,h,_5,c,_7,_8,_9,_a,_b){if(!document.getElementById){return;}
this.DETECT_KEY=_b?_b:"detectflash";
this.skipDetect=deconcept.util.getRequestParameter(this.DETECT_KEY);
this.params=new Object();
this.variables=new Object();
this.attributes=new Array();
if(_1){this.setAttribute("swf",_1);}
if(id){this.setAttribute("id",id);}
if(w){this.setAttribute("width",w);}
if(h){this.setAttribute("height",h);}
if(_5){this.setAttribute("version",new deconcept.PlayerVersion(_5.toString().split(".")));}
this.installedVer=deconcept.SWFObjectUtil.getPlayerVersion();
if(c){this.addParam("bgcolor",c);}
var q=_8?_8:"high";
this.addParam("quality",q);
this.setAttribute("useExpressInstall",_7);
this.setAttribute("doExpressInstall",false);
var _d=(_9)?_9:window.location;
this.setAttribute("xiRedirectUrl",_d);
this.setAttribute("redirectUrl","");
if(_a){this.setAttribute("redirectUrl",_a);}};
deconcept.SWFObject.prototype={setAttribute:function(_e,_f){
this.attributes[_e]=_f;
},getAttribute:function(_10){
return this.attributes[_10];
},addParam:function(_11,_12){
this.params[_11]=_12;
},getParams:function(){
return this.params;
},addVariable:function(_13,_14){
this.variables[_13]=_14;
},getVariable:function(_15){
return this.variables[_15];
},getVariables:function(){
return this.variables;
},getVariablePairs:function(){
var _16=new Array();
var key;
var _18=this.getVariables();
for(key in _18){_16.push(key+"="+_18[key]);}
return _16;},getSWFHTML:function(){var _19="";
if(navigator.plugins&&navigator.mimeTypes&&navigator.mimeTypes.length){
if(this.getAttribute("doExpressInstall")){
this.addVariable("MMplayerType","PlugIn");}
_19="<embed type=\"application/x-shockwave-flash\" src=\""+this.getAttribute("swf")+"\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\"";
_19+=" id=\""+this.getAttribute("id")+"\" name=\""+this.getAttribute("id")+"\" ";
var _1a=this.getParams();
for(var key in _1a){_19+=[key]+"=\""+_1a[key]+"\" ";}
var _1c=this.getVariablePairs().join("&");
if(_1c.length>0){_19+="flashvars=\""+_1c+"\"";}_19+="/>";
}else{if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","ActiveX");}
_19="<object id=\""+this.getAttribute("id")+"\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\">";
_19+="<param name=\"movie\" value=\""+this.getAttribute("swf")+"\" />";
var _1d=this.getParams();
for(var key in _1d){_19+="<param name=\""+key+"\" value=\""+_1d[key]+"\" />";}
var _1f=this.getVariablePairs().join("&");
if(_1f.length>0){_19+="<param name=\"flashvars\" value=\""+_1f+"\" />";}_19+="</object>";}
return _19;
},write:function(_20){
if(this.getAttribute("useExpressInstall")){
var _21=new deconcept.PlayerVersion([6,0,65]);
if(this.installedVer.versionIsValid(_21)&&!this.installedVer.versionIsValid(this.getAttribute("version"))){
this.setAttribute("doExpressInstall",true);
this.addVariable("MMredirectURL",escape(this.getAttribute("xiRedirectUrl")));
document.title=document.title.slice(0,47)+" - Flash Player Installation";
this.addVariable("MMdoctitle",document.title);}}
if(this.skipDetect||this.getAttribute("doExpressInstall")||this.installedVer.versionIsValid(this.getAttribute("version"))){
var n=(typeof _20=="string")?document.getElementById(_20):_20;
n.innerHTML=this.getSWFHTML();return true;
}else{if(this.getAttribute("redirectUrl")!=""){document.location.replace(this.getAttribute("redirectUrl"));}}
return false;}};
deconcept.SWFObjectUtil.getPlayerVersion=function(){
var _23=new deconcept.PlayerVersion([0,0,0]);
if(navigator.plugins&&navigator.mimeTypes.length){
var x=navigator.plugins["Shockwave Flash"];
if(x&&x.description){_23=new deconcept.PlayerVersion(x.description.replace(/([a-zA-Z]|\s)+/,"").replace(/(\s+r|\s+b[0-9]+)/,".").split("."));}
}else{try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7");}
catch(e){try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6");
_23=new deconcept.PlayerVersion([6,0,21]);axo.AllowScriptAccess="always";}
catch(e){if(_23.major==6){return _23;}}try{axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash");}
catch(e){}}if(axo!=null){_23=new deconcept.PlayerVersion(axo.GetVariable("$version").split(" ")[1].split(","));}}
return _23;};
deconcept.PlayerVersion=function(_27){
this.major=_27[0]!=null?parseInt(_27[0]):0;
this.minor=_27[1]!=null?parseInt(_27[1]):0;
this.rev=_27[2]!=null?parseInt(_27[2]):0;
};
deconcept.PlayerVersion.prototype.versionIsValid=function(fv){
if(this.major<fv.major){return false;}
if(this.major>fv.major){return true;}
if(this.minor<fv.minor){return false;}
if(this.minor>fv.minor){return true;}
if(this.rev<fv.rev){
return false;
}return true;};
deconcept.util={getRequestParameter:function(_29){
var q=document.location.search||document.location.hash;
if(q){var _2b=q.substring(1).split("&");
for(var i=0;i<_2b.length;i++){
if(_2b[i].substring(0,_2b[i].indexOf("="))==_29){
return _2b[i].substring((_2b[i].indexOf("=")+1));}}}
return "";}};
deconcept.SWFObjectUtil.cleanupSWFs=function(){if(window.opera||!document.all){return;}
var _2d=document.getElementsByTagName("OBJECT");
for(var i=0;i<_2d.length;i++){_2d[i].style.display="none";for(var x in _2d[i]){
if(typeof _2d[i][x]=="function"){_2d[i][x]=function(){};}}}};
deconcept.SWFObjectUtil.prepUnload=function(){__flash_unloadHandler=function(){};
__flash_savedUnloadHandler=function(){};
if(typeof window.onunload=="function"){
var _30=window.onunload;
window.onunload=function(){
deconcept.SWFObjectUtil.cleanupSWFs();_30();};
}else{window.onunload=deconcept.SWFObjectUtil.cleanupSWFs;}};
if(typeof window.onbeforeunload=="function"){
var oldBeforeUnload=window.onbeforeunload;
window.onbeforeunload=function(){
deconcept.SWFObjectUtil.prepUnload();
oldBeforeUnload();};
}else{window.onbeforeunload=deconcept.SWFObjectUtil.prepUnload;}
if(Array.prototype.push==null){
Array.prototype.push=function(_31){
this[this.length]=_31;
return this.length;};}
var getQueryParamValue=deconcept.util.getRequestParameter;
var FlashObject=deconcept.SWFObject;
var SWFObject=deconcept.SWFObject;

function fncInputNumericValuesOnly(evt)	
{
var charCode = (evt.which) ? evt.which : event.keyCode

if(!(charCode==45||charCode==46||charCode==48||charCode==49||charCode==50||charCode==51||charCode==52||charCode==53||charCode==54||charCode==55||charCode==56||charCode==57 || charCode == 8 || charCode == 44 || charCode == 37 || charCode == 39 || charCode == 16))		
{
return false;
}
}

function PopupCenter(pageURL, title,w,h) {

var left = (screen.width/2)-(w/2);
var top = (screen.height/2)-(h/2);
var settings ="toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width="+w+", height="+h+", top="+top+", left="+left
var targetWin = window.open(pageURL, "",settings );
} 

