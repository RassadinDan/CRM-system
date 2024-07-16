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
using SkillProfiDesctopClient.Tools;
using ModelLibrary.UISettings;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для WorkbenchWindow.xaml
	/// </summary>
	public partial class WorkbenchWindow : Window
	{
		private UISettingsManager _settingsManager;
		public WorkbenchWindow()
		{
			InitializeComponent();
			_settingsManager = new UISettingsManager(Connection.httpClient);

			if (AuthSession.User.Role == "Administrator")
			{
				mainFrame.Navigate(new WorkbenchPage());
			}
			else
			{
				mainFrame.Navigate(new NewAppPage());
				WorkbenchBut.Visibility = Visibility.Hidden;
			}

			MenuHeaders.Settings = _settingsManager.GetSettings();
			MainBut.Content = MenuHeaders.Settings.MainHeader;
			ProjectsBut.Content = MenuHeaders.Settings.ProjectsHeader;
			BlogsBut.Content = MenuHeaders.Settings.BlogHeader;
			ServicesBut.Content = MenuHeaders.Settings.ServicesHeader;
			ContactsBut.Content = MenuHeaders.Settings.ContactsHeader;
		}

		private void MainBut_OnClick(object sender, RoutedEventArgs e)
		{
			if (AuthSession.User.Role == "Administrator")
			{
				mainFrame.Navigate(new UpdateUIPage(MenuHeaders.Settings));
			}
			else
			{
				mainFrame.Navigate(new NewAppPage());
			}
		}

		private void WorkbenchBut_OnClick(object sender, RoutedEventArgs e)
		{
			WorkbenchPage page = new WorkbenchPage();
			mainFrame.Navigate(page);
		}

		private void ProjectsBut_OnClick(object sender, RoutedEventArgs e)
		{
			ProjectsPage page = new ProjectsPage();
			mainFrame.Navigate(page);
			page.ProjectsListBox.SelectionChanged += (s, e) => 
			{
				Project project = page.ProjectsListBox.SelectedItem as Project;
				OneProjectPage oneProject = new OneProjectPage(project);
				mainFrame.Navigate(oneProject);

				if(AuthSession.User.Role == "Administrator")
				{

					oneProject.DeleteBut.Click += (s, e) =>
					{
						page.Delete(oneProject.Project.Id);
						mainFrame.Navigate(page);
					};
				}
				else
				{
					oneProject.DeleteBut.Visibility = Visibility.Hidden;
					oneProject.UpdateBut.Visibility = Visibility.Hidden;
				}
			};
		}

		private void BlogsBut_OnClick(object sender, RoutedEventArgs e)
		{
			BlogsPage page = new BlogsPage();
			mainFrame.Navigate(page);

			page.BlogsListBox.SelectionChanged += (s, e) =>
			{
				Blog blog = page.BlogsListBox.SelectedItem as Blog;
				OneBlogPage oneBlog = new OneBlogPage(blog);
				mainFrame.Navigate(oneBlog);

				if (AuthSession.User.Role == "Administrator")
				{

					oneBlog.DeleteBut.Click += (s, e) =>
					{
						page.Delete(oneBlog.Blog.Id); 
						mainFrame.Navigate(page);
					};
				}
				else
				{
					oneBlog.UpdateBut.Visibility = Visibility.Hidden;
					oneBlog.DeleteBut.Visibility= Visibility.Hidden;
				}
			};
		}

		private void ContactsBut_OnClick(object sender, RoutedEventArgs e)
		{
			ContactsPage page = new ContactsPage();
			mainFrame.Navigate(page);
		}

		private void ServiceBut_OnClick(object sender, RoutedEventArgs e)
		{
			ServicesPage page = new ServicesPage();
			mainFrame.Navigate(page);
		}
	}
}
