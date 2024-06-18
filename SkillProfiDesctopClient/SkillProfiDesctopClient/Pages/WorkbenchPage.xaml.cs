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
	/// Логика взаимодействия для WorkbenchPage.xaml
	/// </summary>
	public partial class WorkbenchPage : Page
	{
		private AdminDataService _dataService { get; set; }
		public ObservableCollection<ModelLibrary.Applications.Application> Applications { get; set; }
		public WorkbenchPage()
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
