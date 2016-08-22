using System;
using PhotoZzz;
using PhotoZzz.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(EntryC))]
namespace PhotoZzz.iOS
{
	public class EntryC : EntryRenderer
	{
		public EntryC ()
		{

		}
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);


		}
	}
}

