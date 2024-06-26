﻿using System;
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
		public AuthWindow()
		{
			InitializeComponent();
		}

		private async void LogInBut_OnClick(object sender, RoutedEventArgs e)
		{
			HttpClient httpClient = new HttpClient();
			var authService = new AuthService(httpClient);
			var authRequest = new LoginRequest
			{
				UserName = UsernameBox.Text,
				Password = PasswdBox.Password
			};
			var result = await authService.LoginAsync(authRequest);
			
			if(result != null)
			{
				AuthSession.IsAuthenticated = true;
				AuthSession.User = result.User;
				AuthSession.Token = result.Token;
				httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthSession.Token);
				Connection.httpClient = httpClient;

				var workbench = new WorkbenchWindow();
				workbench.Show();
				this.Close();
			}
		}

		private void RegisterBut_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new RegistrationWindow();
			window.Show();
		}
	}
}
