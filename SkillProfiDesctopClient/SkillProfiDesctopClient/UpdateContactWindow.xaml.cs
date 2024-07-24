using ModelLibrary.Contacts;
using ModelLibrary.Data;
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
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для UpdateContactWindow.xaml
    /// </summary>
    public partial class UpdateContactWindow : Window
    {
        private Contact Contact;
        private ContactDataService _contactData;
        public UpdateContactWindow(Contact contact)
        {
            InitializeComponent();
            Contact = contact;
            _contactData = new ContactDataService(Connection.httpClient);
            NameBox.Text = Contact.Name;
            EmailBox.Text = Contact.Email;
            AddressBox.Text = Contact.Address;
            PhoneBox.Text = Contact.Phone;
        }

        private async void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if(NameBox.Text != null && EmailBox.Text != null && AddressBox.Text != null && PhoneBox.Text != null)
            {
                var model = new ContactModel()
                {
                    Name = NameBox.Text,
                    Email = EmailBox.Text,
                    Address = AddressBox.Text,
                    Phone = PhoneBox.Text
                };
                bool res = await _contactData.UpdateContactAsync(Contact.Id, model);
                if (res)
                {
                    MessageBox.Show("Контакт успешно обновлен", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Контакт не удалось обновить", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
        }
    }
}
