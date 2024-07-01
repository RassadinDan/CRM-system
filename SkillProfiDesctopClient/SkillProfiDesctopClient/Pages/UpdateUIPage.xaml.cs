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

			MainBox.Text = settings.MainHeader;
			ProjectsBox.Text = settings.ProjectsHeader;
			BlogsBox.Text = settings.BlogHeader;
			ServicesBox.Text = settings.ServicesHeader;
			ContactsBox.Text = settings.ContactsHeader;
		}
	}
}
