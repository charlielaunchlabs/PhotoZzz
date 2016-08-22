using System;
using System.Diagnostics;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;

namespace PhotoZzz
{
	public class App : Application
	{
		private static GetAll _get;
		public static GetAll Get
		{
			get { return _get ?? (_get = new GetAll()); }
		}

		private static HelpeR _help;
		public static  HelpeR help
		{
			get { return _help ?? (_help = new HelpeR()); }
		}

		public App()
		{
			Init();


			MainPage = new NavigationPage(new MainPage());
		}

		public static void Init()
		{

			var app = Resolver.Resolve<IXFormsApp>();
			if (app == null)
			{
				return;
			}

			app.Closing += (o, e) => Debug.WriteLine("Application Closing");
			app.Error += (o, e) => Debug.WriteLine("Application Error");
			app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
			app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
			app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
			app.Startup += (o, e) => Debug.WriteLine("Application Startup");
			app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

