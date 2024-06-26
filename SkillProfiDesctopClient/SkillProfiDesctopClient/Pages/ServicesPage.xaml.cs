using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using ModelLibrary.Data;
using ModelLibrary.Services;
using System.Net.Http.Headers;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для ServicesPage.xaml
	/// </summary>
	public partial class ServicesPage : Page
	{
		private ServiceDataService _serviceData;
		public ObservableCollection<Service> Services;
		public ServicesPage()
		{
			InitializeComponent();
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_serviceData = new ServiceDataService(httpClient);
			Loaded += async (sender, e) =>
			{
				IEnumerable<Service> data = await _serviceData.GetServicesAsync();
				Services = new ObservableCollection<Service>(data);
				ServicesListBox.ItemsSource = Services;
			};
		}
	}
}
