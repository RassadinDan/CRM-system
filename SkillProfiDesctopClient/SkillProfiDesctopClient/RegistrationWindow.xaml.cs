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
using ModelLibrary.Auth.Dto;
using ModelLibrary.Auth;
using System.Net.Http;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private async void RegisterBut_OnClick(object sender, RoutedEventArgs e)
		{
			if(PasswdBox.Password == ConfirmPasswdBox.Password)
			{
				var registerReq = new RegistrationRequest()
				{
					UserName = UsernameBox.Text,
					Password = PasswdBox.Password,
					ConfirmPassword = ConfirmPasswdBox.Password,
					Role = "Guest"
				};
				var authService = new AuthService(new HttpClient());
				bool result = await authService.RegisterAsync(registerReq);
				if (result)
				{
					MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
					this.Close();
				}
				else
				{
					MessageBox.Show("Ошибка во время регистрации! Пожалуйста, проверьте поля формы.", "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Пароли должны совпадать", "Что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void BackBut_OnClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
