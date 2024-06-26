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
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
			_contactData = new ContactDataService(httpClient);

			Loaded += async (sender, e) =>
			{
				IEnumerable<Contact> data = await _contactData.GetContactsAsync();
				Contacts = new ObservableCollection<Contact>(data);
				ContactsListBox.ItemsSource = Contacts;
			};
		}
	}
}
