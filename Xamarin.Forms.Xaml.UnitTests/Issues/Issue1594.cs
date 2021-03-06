﻿using System;
using NUnit.Framework;

namespace Xamarin.Forms.Xaml.UnitTests
{
	[TestFixture]
	public class Issue1594
	{
		[Test]
		public void OnPlatformForButtonHeight ()
		{
			var xaml = @"
				<Button 
					xmlns=""http://xamarin.com/schemas/2014/forms"" 
					xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml"" 
					xmlns:sys=""clr-namespace:System;assembly=mscorlib""
					x:Name=""activateButton"" Text=""ACTIVATE NOW"" TextColor=""White"" BackgroundColor=""#00A0FF"">
				        <Button.HeightRequest>
				           <OnPlatform x:TypeArguments=""sys:Double""
				                   iOS=""33""
				                   Android=""44""
				                   WinPhone=""44"" />
				         </Button.HeightRequest>
				 </Button>";

			Device.OS = TargetPlatform.iOS;
			var button = new Button ().LoadFromXaml (xaml);
			Assert.AreEqual (33, button.HeightRequest);

			Device.OS = TargetPlatform.Android;
			button = new Button ().LoadFromXaml (xaml);
			Assert.AreEqual (44, button.HeightRequest);

			Device.OS = TargetPlatform.WinPhone;
			button = new Button ().LoadFromXaml (xaml);
			Assert.AreEqual (44, button.HeightRequest);


		}

	}
}

