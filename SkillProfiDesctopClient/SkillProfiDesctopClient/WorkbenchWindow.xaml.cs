using System;
using System.Collections.Generic;
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
using ModelLibrary.Data;
using ModelLibrary.Applications;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для WorkbenchWindow.xaml
	/// </summary>
	public partial class WorkbenchWindow : Window
	{
		private AdminDataService _dataService {get; set;}
		public ObservableCollection<ModelLibrary.Applications.Application> Applications {get; set;}
		public WorkbenchWindow()
		{
			InitializeComponent();
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_dataService = new AdminDataService(httpClient);
			Loaded += async (sender, e) =>
			{
				var data = await _dataService.GetApplicationsAsync();
				Applications = new ObservableCollection<ModelLibrary.Applications.Application>(data);
				ApplicationsListBox.ItemsSource = Applications;
			};
		}
	}
}
