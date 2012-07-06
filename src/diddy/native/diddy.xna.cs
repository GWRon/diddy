class diddy
{
	public static int systemMillisecs()
	{
		DateTime centuryBegin = new DateTime(1970, 1, 1);
		DateTime currentDate = DateTime.Now;
		long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
		TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

		int millisecs = (int)elapsedSpan.TotalSeconds * 1000;

		return millisecs;
	}

	public static void flushKeys()
	{
		for( int i=0;i<512;++i ){
			gxtkApp.game.app.input.keyStates[i]&=0x100;
		}
	}
	
	public static int getUpdateRate()
	{
		return gxtkApp.game.app.updateRate;
	}
	public static int getPixel(int x, int y)
	{
		if ((x > 0 && y > 0 && x < gxtkApp.game.app.graphics.Width()) && (y < gxtkApp.game.app.graphics.Height()))
		{
			Texture2D backBufferData = new Texture2D(
				gxtkApp.game.app.graphics.device,
				gxtkApp.game.app.graphics.Width(),
				gxtkApp.game.app.graphics.Height());

			Rectangle sourceRectangle =	new Rectangle(x, y, 1, 1);

			Color[] retrievedColor = new Color[1];

			backBufferData.GetData<Color>(
				0,
				sourceRectangle,
				retrievedColor,
				0,
				1);
				
			bb_std_lang.Print("x="+x+",y="+y+" col="+retrievedColor[0].ToString());
		}
		return 0;
	}	
	public static void showMouse()
	{
		gxtkApp.game.IsMouseVisible=true;
	}
	public static void hideMouse()
	{
		gxtkApp.game.IsMouseVisible=false;
	}
	public static void setGraphics(int w, int h)
	{
	}
	public static void setMouse(int x, int y)
	{
	}
	public static void showKeyboard()
	{
	}
	public static void launchBrowser(String address, String windowName)
	{
#if WINDOWS
		System.Diagnostics.Process.Start(address);
#elif WINDOWS_PHONE
		MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
		marketplaceDetailTask.ContentIdentifier = address;
		marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
		marketplaceDetailTask.Show();
#endif
	}
	public static void launchEmail(String email, String subject, String text)
	{
#if WINDOWS
		string message = string.Format("mailto:{0}?subject={1}&body={2}",email, subject, text);
		System.Diagnostics.Process.Start(message);
#endif
	}

	public static void startVibrate(int millisecs)
	{
	}
	public static void stopVibrate()
	{
	}
	
	public static int getDayOfMonth()
	{
		DateTime d = DateTime.Now;
		return d.Day;
	}
	
	public static int getDayOfWeek()
	{
		DateTime d = DateTime.Now;
		return (int)(d.DayOfWeek);
	}
	
	public static int getMonth()
	{
		DateTime d = DateTime.Now;
		return d.Month;
	}
	
	public static int getYear()
	{
		DateTime d = DateTime.Now;
		return d.Year;
	}
	
	public static int getHours()
	{
		DateTime d = DateTime.Now;
		return d.Hour;
	}
	
	public static int getMinutes()
	{
		DateTime d = DateTime.Now;
		return d.Minute;
	}
	
	public static int getSeconds()
	{
		DateTime d = DateTime.Now;
		return d.Second;
	}
	
	public static int getMilliSeconds()
	{
		DateTime d = DateTime.Now;
		return d.Millisecond;
	}
	
	public static void startGps()
	{
	}
	public static String getLatitiude()
	{
		return "";
	}
	public static String getLongitude()
	{
		return "";
	}
	public static void showAlertDialog(String title, String message)
	{ }
	public static String getInputString()
	{
		return "";
	}
	
}
