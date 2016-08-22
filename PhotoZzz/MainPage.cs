using System;
using System.Collections.Generic;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace PhotoZzz
{
	public class MainPage : ContentPage
	{
		ObjectMain Posts;
		List<Vegetable> vege = new List<Vegetable>();
		ListView lista = new ListView();
		public MainPage()
		{

			LoadPosts();

			var addb = new ToolbarItem
			{
				Priority = 0,
				Text = " + ",
				Command = new Command(async () => await Navigation.PushModalAsync(new NavigationPage( new AddDunno())))
			};

			this.ToolbarItems.Add(addb);
			Title = "List";
			lista.ItemTemplate = new DataTemplate(typeof(CustomListChuchu));
			lista.HasUnevenRows = true;
			StackLayout layout = new StackLayout()
			{
				Children =
				{
					lista
				}
			};



			Content = layout;
		}

		private async void LoadPosts()
		{
			Posts = await App.Get.FetchPosts();
			vege = Posts.vegetables;
			lista.ItemsSource = vege;
			lista.BindingContext = vege;
		}
	}
	class CustomListChuchu : ViewCell
	{



		public CustomListChuchu()
		{
			
			CachedImage images = new CachedImage
			{
				LoadingPlaceholder ="http://image.fg-a.com/backgrounds/black-planet-surface-1920.jpg",
				ErrorPlaceholder ="http://image.fg-a.com/backgrounds/black-planet-surface-1920.jpg",
				WidthRequest = 50,
				HeightRequest = 50,
				CacheDuration = TimeSpan.FromDays(30),
				RetryCount = 3,
				RetryDelay = 500
					
			};
			images.SetBinding(CachedImage.SourceProperty, new Binding("photo.url"));

			Label name = new Label
			{
				TextColor = Color.Accent,
				FontSize = 20,
				FontAttributes = Xamarin.Forms.FontAttributes.Italic,
			};
			name.SetBinding(Label.TextProperty, "name");


			StackLayout main = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				//BackgroundColor = Color.Gray,
				Children = { new StackLayout { HeightRequest = 50, WidthRequest = 50, Children = { images } }, name}
			};

			View = main;
		}
	


	}
}


