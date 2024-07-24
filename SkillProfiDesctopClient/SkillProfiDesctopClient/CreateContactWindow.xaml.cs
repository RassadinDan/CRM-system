using ModelLibrary.Contacts;
using ModelLibrary.Data;
using SkillProfiDesctopClient.Tools;
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

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для OneContactWindow.xaml
    /// </summary>
    public partial class CreateContactWindow : Window
    {
        private ContactDataService _contactData;
        public CreateContactWindow()
        {
            InitializeComponent();
            _contactData = new ContactDataService(Connection.httpClient);
        }

        private async void CreateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != null && EmailBox.Text != null && AddressBox.Text != null && PhoneBox.Text != null)
            {
                var model = new ContactModel()
                {
                    Name = NameBox.Text,
                    Email = EmailBox.Text,
                    Address = AddressBox.Text,
                    Phone = PhoneBox.Text
                };

                bool res = await _contactData.CreateContactAsync(model);

                if (res)
                {
                    MessageBox.Show("Контакт успешно создан", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Контакт не удалось сохранить", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
        }
    }
}
