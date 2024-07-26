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
using System.Net.Http;
using ModelLibrary.Auth;
using ModelLibrary.Auth.Dto;
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для AuthWindow.xaml
	/// </summary>
	public partial class AuthWindow : Window
	{
		private HttpClient _httpClient;
		private AuthService _authService;
		public AuthWindow()
		{
			InitializeComponent();
			_httpClient = new HttpClient();
			_authService = new AuthService(_httpClient);
        }

		private async void LogInBut_OnClick(object sender, RoutedEventArgs e)
		{
			var authRequest = new LoginRequest
			{
				UserName = UsernameBox.Text,
				Password = PasswdBox.Password
			};
			var result = await _authService.LoginAsync(authRequest);
			
			if(result != null)
			{
				AuthSession.IsAuthenticated = true;
				AuthSession.User = result.User;
				AuthSession.Token = result.Token;
				_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthSession.Token);
				Connection.httpClient = _httpClient;

				var workbench = new WorkbenchWindow();
				workbench.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Неправильное имя пользователя или пароль", "Не удалось войти в систему");
			}
		}

		private void RegisterBut_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new RegistrationWindow();
			window.Show();
		}
	}
}
