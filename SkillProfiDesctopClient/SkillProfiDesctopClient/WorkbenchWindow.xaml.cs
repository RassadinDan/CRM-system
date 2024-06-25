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
using SkillProfiDesctopClient.Pages;
using ModelLibrary.Projects;
using ModelLibrary.Blogs;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для WorkbenchWindow.xaml
	/// </summary>
	public partial class WorkbenchWindow : Window
	{
		public WorkbenchWindow()
		{
			InitializeComponent();
			mainFrame.Navigate(new WorkbenchPage());
		}

		private void ProjectsBut_OnClick(object sender, RoutedEventArgs e)
		{
			var page = new ProjectsPage();
			mainFrame.Navigate(page);
			page.ProjectsListBox.SelectionChanged += (s, e) => 
			{
				Project project = page.ProjectsListBox.SelectedItem as Project;
				OneProjectPage oneProject = new OneProjectPage(project);
				mainFrame.Navigate(oneProject);
			};
		}

		private void BlogsBut_OnClick(object sender, RoutedEventArgs e)
		{
			var page = new BlogsPage();
			mainFrame.Navigate(page);
			page.BlogsListBox.SelectionChanged += (s, e) =>
			{
				Blog blog = page.BlogsListBox.SelectedItem as Blog;
				OneBlogPage oneBlog = new OneBlogPage(blog);
				mainFrame.Navigate(oneBlog);
			};
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
	}
}
