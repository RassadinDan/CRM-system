﻿using ModelLibrary.Data;
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
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_projectData = new ProjectDataService(httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Project> data = await _projectData.GetProjectsAsync();
				Projects = new ObservableCollection<Project>(data);
				ProjectsListBox.ItemsSource = Projects;
			};
		}

		private void CreateBut_OnClick(object sender, RoutedEventArgs e)
		{
			CreateProjectWindow window = new CreateProjectWindow();
			window.Show();
		}
	}
}
