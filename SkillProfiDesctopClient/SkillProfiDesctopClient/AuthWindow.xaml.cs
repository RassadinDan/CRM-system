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

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для AuthWindow.xaml
	/// </summary>
	public partial class AuthWindow : Window
	{
		public AuthWindow()
		{
			InitializeComponent();
		}

		private async void LogInBut_OnClick(object sender, RoutedEventArgs e)
		{
			var authService = new AuthService(new HttpClient());
			var authRequest = new LoginRequest
			{
				UserName = UsernameBox.Text,
				Password = PasswdBox.Password
			};
			var result = await authService.LoginAsync(authRequest);
			this.Close();
		}
	}
}
