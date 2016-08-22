using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PhotoZzz
{
	public class Photo
	{
		private  string _url = "http://image.fg-a.com/backgrounds/black-planet-surface-1920.jpg";
		public string url 
		{
			get { return _url; } 
			set { _url = value; } 
		}
	}

	public class Vegetable
	{
		public string created_at { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public Photo photo { get; set; }
		public string updated_at { get; set; }
	}

	public class ObjectMain
	{
		public List<Vegetable> vegetables { get; set; }
		public string message { get; set; }
	}


	public class CreatePic
	{
		public string name { get; set; }
		public string image { get; set; }
	}

}

