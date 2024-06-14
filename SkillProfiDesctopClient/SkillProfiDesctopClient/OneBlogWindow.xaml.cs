using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModelLibrary.Blogs;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для OneBlogWindow.xaml
	/// </summary>
	public partial class OneBlogWindow : Window
	{
		public Blog Blog { get; set; }
		public OneBlogWindow(Blog blog)
		{
			InitializeComponent();
			this.Blog = blog;
			TitleBlock.Text = Blog.Name;
			PreviewBlock.Text = Blog.Preview;
			DescriptionBlock.Text = Blog.Description;
			BlogImage.Source = LoadImage(Blog.ImageData);
		}

		private static BitmapImage LoadImage(byte[] imageData)
		{
			if (imageData == null || imageData.Length == 0) return null;
			var image = new BitmapImage();
			using (var mem = new MemoryStream(imageData))
			{
				mem.Position = 0;
				image.BeginInit();
				image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.UriSource = null;
				image.StreamSource = mem;
				image.EndInit();
			}
			image.Freeze();
			return image;
		}
	}
}
