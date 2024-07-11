using ModelLibrary.Blogs;
using SkillProfiDesctopClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для OneBlogPage.xaml
	/// </summary>
	public partial class OneBlogPage : Page
	{
		public Blog Blog { get; set; }
		public OneBlogPage(Blog blog)
		{
			InitializeComponent();
			this.Blog = blog;
			TitleBlock.Text = Blog.Name;
			PreviewBlock.Text = Blog.Preview;
			DescriptionBlock.Text = Blog.Description;
			BlogImage.Source = ImageLoader.LoadImage(Blog.ImageData);
		}

		private void UpdateBut_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new UpdateBlogWindow(Blog);
			window.Show();
		}

	}
}
