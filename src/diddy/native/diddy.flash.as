import flash.ui.Mouse;

class diddy
{
	static public function systemMillisecs():Number
	{
		return (new Date).getTime();
	}

	static public function flushKeys():void
	{
		for( var i:int=0;i<512;++i ){
			bb_input_device.keyStates[i]=0;
		}
	}
	
	static public function showMouse():void
	{
		Mouse.show();
	}

	static public function hideMouse():void
	{
		Mouse.hide();
	}
	static public function setGraphics(w:int, h:int):void
	{
	}
	static public function setMouse(x:int, y:int):void
	{
		
	}
	
	static public function getUpdateRate():Number
	{
		return app.updateRate;
	}
	
	static public function showKeyboard():void
	{
	}
	
	static public function launchBrowser(address:String):void
	{
		var adobeURL:URLRequest = new URLRequest(address);
		navigateToURL(adobeURL);
	}
	
	static public function launchEmail(email:String, subject:String, text:String):void
	{
		var adobeURL:URLRequest = new URLRequest("mailto:"+email+"&subject="+subject+"&body="+text+"");
		navigateToURL(adobeURL, "_self");
	}
}