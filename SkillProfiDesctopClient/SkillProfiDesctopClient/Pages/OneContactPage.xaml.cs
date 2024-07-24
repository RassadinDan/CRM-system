using ModelLibrary.Contacts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillProfiDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для OneContactPage.xaml
    /// </summary>
    public partial class OneContactPage : Page
    {
        public Contact Contact;
        public OneContactPage(Contact contact)
        {
            InitializeComponent();
            Contact = contact;

            NameBlock.Text = Contact.Name;
            EmailBlock.Text = Contact.Email;
            AddressBlock.Text = Contact.Address;
            PhoneBlock.Text = Contact.Phone;
        }

        private void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new UpdateContactWindow(Contact);
            window.Show();
        }
    }
}
