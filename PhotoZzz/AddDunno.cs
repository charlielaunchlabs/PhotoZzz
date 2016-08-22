using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.IO;

namespace PhotoZzz
{
	public class AddDunno : ContentPage
	{
		private string stringg = "http://192.168.1.214:3000/v1/vegetables";
		CustomEntry names = new CustomEntry() { Text = "" };
		Image image = new Image() { };
		Image newImage = new Image() ;
		Button btn = new Button() { Text = "Select Image" };
		Button btns = new Button() { Text = "Save" };
		Button resize = new Button() { Text = "Resize" };
		XLabs.Platform.Services.Media.MediaFile selectedImage;
		float fullH, fullW;
		public string nm = "";

		public AddDunno()
		{
			var addb = new ToolbarItem
			{
				Priority = 0,
				Text = " + ",
				Command = new Command(async () => await Navigation.PushModalAsync(new NavigationPage(new MainPage()),false))
			};
			this.ToolbarItems.Add(addb);
			Title = "Add Image";
			var loadd = new ActivityIndicator();
			loadd.Color = Color.Red;
			names.WidthRequest = 250;
		

			var stack = new StackLayout
			{
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Thickness(20, 20, 20, 20),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {  btn, image, btns, loadd,resize,newImage,names }
			};

			var scroll = new ScrollView
			{
				Content = stack,
			};
			//names.Focused += (sender, e) =>scroll.;
			//names.Unfocused += (sender, e) => scroll.IsEnabled = true;

			Content = scroll;

			fullW = DependencyService.Get<Sizer>().deviceWidth();
			fullH = DependencyService.Get<Sizer>().deviceHeight();

			btn.Clicked += async (sender, e) =>
			{
				var device = Resolver.Resolve<IDevice>();
				var mp = device.MediaPicker;
				var options = new XLabs.Platform.Services.Media.CameraMediaStorageOptions();

				selectedImage = await mp.SelectPhotoAsync(options);

				var s = selectedImage.Source;

				image.Source = ImageSource.FromStream(() => s);
			};

			btns.Clicked += async (sender, e) =>
			{
				
				byte[] data = ReadFully(selectedImage.Source);
				string name = names.Text;
				string base64string = Convert.ToBase64String(data);

				Dictionary<string, object> xx = new Dictionary<string, object>
						 {
							{ "vegetable", new Dictionary<string, object>
								{
									{"name",name},
									{"photo",base64string}
								} 
							}
						}; 

				loadd.IsRunning = true;
				stack.IsEnabled = false;

				string json = JsonConvert.SerializeObject(xx, Formatting.Indented);
				await App.help.postRequest(stringg,json);

				loadd.IsRunning = false;
				stack.IsEnabled = true;

				await DisplayAlert("Done", "Meesage ", "OK");

			};
			resize.Clicked += async (sender, e) => 
			{
				float nHeight, nWidth;
				nWidth = selectedImage.Exif.Width;
				nHeight = selectedImage.Exif.Height;
				var n = nWidth / fullW;

				byte[] dats = ReadFully(selectedImage.Source);
				byte[] newData = DependencyService.Get<Sizer>().ResizeImage(dats,nWidth/n,nHeight/n);
				newImage.Source = ImageSource.FromStream(() => new MemoryStream(newData));

				await DisplayAlert("Done", "Meesage ", "OK");
			};
		}

		public static byte[] ReadFully(Stream input)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				input.CopyTo(ms);
				return ms.ToArray();
			}
		}
	}
}


