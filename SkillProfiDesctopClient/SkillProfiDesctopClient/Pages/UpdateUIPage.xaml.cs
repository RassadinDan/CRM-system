using System;
using System.Collections.Generic;
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
using ModelLibrary.UISettings;
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для UpdateUIPage.xaml
	/// </summary>
	public partial class UpdateUIPage : Page
	{
		public UISettingsManager _settingsManager;
		public MainSettings _settings;
		public UpdateUIPage(MainSettings settings)
		{
			InitializeComponent();
			
			_settingsManager = new UISettingsManager(Connection.httpClient);
			_settings = settings;

			MainBox.Text = _settings.MainHeader;
			ProjectsBox.Text = _settings.ProjectsHeader;
			BlogsBox.Text = _settings.BlogHeader;
			ServicesBox.Text = _settings.ServicesHeader;
			ContactsBox.Text = _settings.ContactsHeader;
		}

		private async void UpdateBut_OnClick(object sender, RoutedEventArgs e)
		{
			_settings.MainHeader = MainBox.Text;
			_settings.ProjectsHeader = ProjectsBox.Text;
			_settings.BlogHeader = BlogsBox.Text;
			_settings.ServicesHeader = ServicesBox.Text;
			_settings.ContactsHeader = ContactsBox.Text;

			bool res = await _settingsManager.UpdateSettings(_settings);
			if (res)
			{ 
				MessageBox.Show("Заголовки успешно обновлены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
		}
	}
}
