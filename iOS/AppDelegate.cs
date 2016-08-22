using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;

namespace PhotoZzz.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate :global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			

			//SetIoc();
			global::Xamarin.Forms.Forms.Init();

			CachedImageRenderer.Init();

			var container = new SimpleContainer();
			container.Register<IDevice>(t => AppleDevice.CurrentDevice);
			container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
			container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
			container.Register<IMediaPicker>(t => t.Resolve<IDevice>().MediaPicker );
			Resolver.SetResolver(container.GetResolver());



			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

	
	}
}

