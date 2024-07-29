using ModelLibrary.Data;
using ModelLibrary.Services;
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
    /// Логика взаимодействия для CreateServiceWindow.xaml
    /// </summary>
    public partial class CreateServiceWindow : Window
    {
        private ServiceDataService _serviceData;
        public CreateServiceWindow()
        {
            InitializeComponent();
            _serviceData = new ServiceDataService(Connection.httpClient);
        }

        private async void CreateBut_OnCLick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != null && DescriptionBox.Text != null)
            {
                var model = new ServiceModel()
                {
                    Name = NameBox.Text,
                    Description = DescriptionBox.Text
                };
                bool res = await _serviceData.CreateServiceAsync(model);

                if (res)
                {
                    MessageBox.Show("Запись службы успешно создана", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось создать запись службы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
        }
    }
}
