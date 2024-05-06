using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using ModelLibrary.Applications;
using System.Net.Http.Headers;

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

        private async void SubmitBut_OnClick(object sender, RoutedEventArgs e)
        {
            var url = "https://localhost:7044/api/guest/postapplication";

            var model = new ApplicationRequest();
            if(NameBox.Text != string.Empty && EmailBox.Text != string.Empty && ApplicationText.Text != string.Empty)
            {
                model.Name = NameBox.Text;
                model.Email = EmailBox.Text;
                model.Text = ApplicationText.Text;
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
                var r = await httpClient.PostAsJsonAsync(url, model);
                if(r.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ваша заявка успешно принята", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    NameBox.Text = string.Empty;
                    EmailBox.Text = string.Empty;
                    ApplicationText.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Что-то пошло не так: {r.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля формы должны быть заполнены", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
