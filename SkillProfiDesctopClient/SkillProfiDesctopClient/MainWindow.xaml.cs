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
using ModelLibrary.Applications;
using Newtonsoft.Json;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitBut_OnClick(object sender, RoutedEventArgs e)
        {
            var url = "https://localhost:7044/api/guest/postapplication";

            var model = new ApplicationModel();
            model.Name = NameBox.Text;
            model.Email = EmailBox.Text;
            model.Text = ApplicationText.Text;
            
            var httpClient = new HttpClient();
            var r = await httpClient.PostAsJsonAsync(url, model);

        }
    }
}
