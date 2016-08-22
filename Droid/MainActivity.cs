using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Forms.Services;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Forms;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms;

namespace PhotoZzz.Droid
{
	[Activity(Label = "PhotoZzz.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		public static float hayt { get; set; }
		public static float wid { get; set; }

		protected override void OnCreate(Bundle bundle)
		{
			//TabLayoutResource = Resource.Layout.Tabbar;
			//ToolbarResource = Resource.Layout.Toolbar;

		}
			base.OnCreate(bundle);

				var container = new SimpleContainer();
				container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
				container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
				container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
				container.Register<IMediaPicker>(t => t.Resolve<IDevice>().MediaPicker);
				Resolver.SetResolver(container.GetResolver());

			CachedImageRenderer.Init();

			global::Xamarin.Forms.Forms.Init(this, bundle);

			var xs = (float)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

			var ys = (float)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density;

			hayt = xs;
			wid = ys;
			LoadApplication(new App());


		}
	
	}
}

