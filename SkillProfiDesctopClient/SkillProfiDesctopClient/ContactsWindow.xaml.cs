using ModelLibrary.Contacts;
using ModelLibrary.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Net.Http.Headers;

namespace SkillProfiDesctopClient
{
	/// <summary>
	/// Логика взаимодействия для ContactsWindow.xaml
	/// </summary>
	public partial class ContactsWindow : Window
	{
		private ContactDataService _contactData {  get; set; }
		public ObservableCollection<Contact> Contacts { get; set; }
		public ContactsWindow()
		{
			InitializeComponent();
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_contactData = new ContactDataService(httpClient);
			Loaded += async (sender, e) =>
			{
				var data = await _contactData.GetContactsAsync();
				Contacts = new ObservableCollection<Contact>(data);
				ContactsListBox.ItemsSource = Contacts;
			};
		}
	}
}
