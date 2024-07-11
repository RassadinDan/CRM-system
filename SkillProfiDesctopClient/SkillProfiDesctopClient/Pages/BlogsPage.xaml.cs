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
using SkillProfiDesctopClient.Tools;

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
			_blogDataService = new BlogDataService(Connection.httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Blog> data = await _blogDataService.GetBlogsAsync();
				Blogs = new ObservableCollection<Blog>(data);
				BlogsListBox.ItemsSource = Blogs;
			};
		}

		private void CreateBut_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new CreateBlogWindow();
			window.Show();
		}

		public async void Delete(int id)
		{
			bool res = await _blogDataService.DeleteBlogAsync(id);
			if (res)
			{
				MessageBox.Show("Запись удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
