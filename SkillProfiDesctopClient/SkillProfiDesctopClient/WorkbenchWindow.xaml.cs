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

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для WorkbenchWindow.xaml
	/// </summary>
	public partial class WorkbenchWindow : Window
	{
		private IEnumerable<ModelLibrary.Applications.Application> applications {get; set;}
		private AdminDataService _dataService {get; set;}
		public WorkbenchWindow()
		{
			_dataService = new AdminDataService();
			FillTheList();
			InitializeComponent();
		}

		private void FillTheList()
		{
			applications = _dataService.GetApplicationsAsync().Result;
		}
	}
}
