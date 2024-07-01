using ModelLibrary.Data;
using ModelLibrary.Projects;
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
	/// Логика взаимодействия для ProjectsPage.xaml
	/// </summary>
	public partial class ProjectsPage : Page
	{
		private ProjectDataService _projectData;
		public ObservableCollection<Project> Projects;
		public ProjectsPage()
		{
			InitializeComponent();
			_projectData = new ProjectDataService(Connection.httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Project> data = await _projectData.GetProjectsAsync();
				Projects = new ObservableCollection<Project>(data);
				ProjectsListBox.ItemsSource = Projects;
			};
		}

		public async void Delete(int id)
		{
			bool res = await _projectData.DeleteProjectAsync(id);
			if (res)
			{
				MessageBox.Show("Запись удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else 
			{
				MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void CreateBut_OnClick(object sender, RoutedEventArgs e)
		{
			CreateProjectWindow window = new CreateProjectWindow();
			window.Show();
		}
	}
}
