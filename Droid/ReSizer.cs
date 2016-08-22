using System;
using System.IO;
using Android.Content.Res;
using Android.Graphics;
using PhotoZzz.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ReSizer))]
namespace PhotoZzz.Droid
{
	public class ReSizer : Sizer
	{
		
		public ReSizer()
		{
		}

		public byte[] ResizeImage(byte[] imageData, float width, float height)
		{
			// Load the bitmap
			Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
			Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

			using (MemoryStream ms = new MemoryStream())
			{
				resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
				return ms.ToArray();
			}
		}
		public  float deviceHeight()
		{
			return MainActivity.hayt;
		}
		public float deviceWidth()
		{
			return MainActivity.wid;
		}
	}
}


