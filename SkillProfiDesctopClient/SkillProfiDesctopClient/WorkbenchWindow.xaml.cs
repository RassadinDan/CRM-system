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
		//private AdminDataService _dataService {get; set;}
		//public ObservableCollection<ModelLibrary.Applications.Application> Applications {get; set;}
		public WorkbenchWindow()
		{
			InitializeComponent();
			mainFrame.Source = new Uri("Pages/WorkbenchPage.xaml", UriKind.Relative);
		}

		private void ProjectsBut_OnClick(object sender, RoutedEventArgs e)
		{
			mainFrame.Source = new Uri("Pages/ProjectsPage.xaml", UriKind.Relative);
		}

		private void BlogsBut_OnClick(object sender, RoutedEventArgs e)
		{
			mainFrame.Source = new Uri("Pages/BlogsPage.xaml", UriKind.Relative);
		}

		private void ContactsBut_OnClick(object sender, RoutedEventArgs e)
		{
			ContactsWindow window = new ContactsWindow();
			window.Show();
		}

		private void ServiceBut_OnClick(object sender, RoutedEventArgs e)
		{
			ServicesWindow window = new ServicesWindow();
			window.Show();
		}

		//private void MainBut_OnClick(object sender, RoutedEventArgs e)
		//{

		//}
	}
}
