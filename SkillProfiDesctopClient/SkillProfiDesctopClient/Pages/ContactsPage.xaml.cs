using ModelLibrary.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModelLibrary.Contacts;
using System.Net.Http;
using System.Net.Http.Headers;
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для ContactsPage.xaml
	/// </summary>
	public partial class ContactsPage : Page
	{
		private ContactDataService _contactData;
		public ObservableCollection<Contact> Contacts;
		public ContactsPage()
		{
			InitializeComponent();
			_contactData = new ContactDataService(Connection.httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Contact> data = await _contactData.GetContactsAsync();
				Contacts = new ObservableCollection<Contact>(data);
				ContactsListBox.ItemsSource = Contacts;

				if(AuthSession.User.Role != "Administrator")
				{
					CreateBut.Visibility = Visibility.Hidden;
				}	
			};
		}

		private void CreateBut_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new CreateContactWindow();
			window.Show();
		}

		public async void Delete(int id)
		{
			bool res = await _contactData.DeleteContactAsync(id);
            if (res)
            {
                MessageBox.Show("Запись удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
	}
}
