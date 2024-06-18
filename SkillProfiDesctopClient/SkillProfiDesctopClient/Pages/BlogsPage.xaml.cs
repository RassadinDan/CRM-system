using ModelLibrary.Blogs;
using ModelLibrary.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
	/// Логика взаимодействия для BlogsPage.xaml
	/// </summary>
	public partial class BlogsPage : Page
	{
		private BlogDataService _blogDataService;
		public ObservableCollection<Blog> Blogs;
		public BlogsPage()
		{
			InitializeComponent();
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_blogDataService = new BlogDataService(httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Blog> data = await _blogDataService.GetBlogsAsync();
				Blogs = new ObservableCollection<Blog>(data);
				BlogsListBox.ItemsSource = Blogs;
			};
		}

		private void BlogsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Blog blog = BlogsListBox.SelectedItem as Blog;
			OneBlogWindow window = new OneBlogWindow(blog);
			window.Show();
		}
	}
}
