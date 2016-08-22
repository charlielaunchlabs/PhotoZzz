using System;

using Xamarin.Forms;

namespace PhotoZzz
{
	public interface Sizer 
	{
		 byte[] ResizeImage(byte[] imageData, float width, float height);

		float deviceHeight();

		float deviceWidth();

	}
}


