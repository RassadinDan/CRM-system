using ModelLibrary.Applications;
using ModelLibrary.Data;
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
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для NewAppPage.xaml
	/// </summary>
	public partial class NewAppPage : Page
	{
		private GuestDataService _guestData;
		public NewAppPage()
		{
			InitializeComponent();
			_guestData = new GuestDataService(Connection.httpClient);
		}

		private async void SubmitBut_OnClick(object sender, RoutedEventArgs e)
		{
			ApplicationRequest request = new ApplicationRequest()
			{
				Name = NameBox.Text,
				Email = EmailBox.Text,
				Text = ApplicationText.Text
			};

			bool res = await _guestData.PostApplicationAsync(request);
			if (res)
			{
				MessageBox.Show("Заявка успешно отправлена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
				NameBox.Text = string.Empty;
				EmailBox.Text = string.Empty;
				ApplicationText.Text = string.Empty;
			}
			else
			{
				MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
