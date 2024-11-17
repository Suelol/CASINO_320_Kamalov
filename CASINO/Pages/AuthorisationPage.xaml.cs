using CASINO.DBModel;
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

namespace CASINO.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationPage.xaml
    /// </summary>
    public partial class AuthorisationPage : Page
    {
        public AuthorisationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения логина и пароля из полей ввода
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            // Проверяем, не пустые ли поля логина и пароля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                //MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка авторизации");
                CustomMessageBox successMessage = new CustomMessageBox("Пожалуйста, заполните все поля");
                successMessage.ShowDialog();
                return;
            }

            // Проверяем логин и пароль на соответствие с данными из БД
            var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                // Авторизация успешна, можно открыть главное окно приложения
                //MessageBox.Show("Авторизация успешна", "Успех");
                CustomMessageBox successMessage = new CustomMessageBox("Авторизация успешна!");
                successMessage.ShowDialog();

                ConnectionClass.IsOnlineUserId = user.Id;
                // Открываем главное окно приложения
                //NavigationService.Navigate(new CactusKatalog());
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.EnableButtons();
                NavigationService.Navigate(new PersonalInfo());
            }
            else
            {
                // Авторизация неуспешна, показываем сообщение об ошибке
                //MessageBox.Show("Неправильный логин или пароль", "Ошибка авторизации");
                CustomMessageBox successMessage = new CustomMessageBox("Неправильный логин или пароль");
                successMessage.ShowDialog();
            }
        }





        private bool isSyncing = false; // Флаг для предотвращения циклической синхронизации

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (isSyncing)
                return;

            isSyncing = true;
            PasswordTextBox.Text = PasswordBox.Password;
            PasswordPlaceholder.Visibility = PasswordBox.Password.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
            isSyncing = false;
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isSyncing)
                return;

            isSyncing = true;
            PasswordBox.Password = PasswordTextBox.Text;
            isSyncing = false;
        }

        private void ShowPasswordIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // При нажатии на иконку, показываем пароль
            PasswordBox.Visibility = Visibility.Collapsed;
            PasswordTextBox.Visibility = Visibility.Visible;
        }

        private void ShowPasswordIcon_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Когда мышь отпускается, снова скрываем пароль
            PasswordBox.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
