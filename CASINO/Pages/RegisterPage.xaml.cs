using CASINO.DBModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CASINO.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string email = EmailTextBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;

            // Валидация полей
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(email) ||
                birthDate == null)
            {
                ShowError("Все поля должны быть заполнены.");
                return;
            }

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                ShowError("Пароли не совпадают.");
                return;
            }

            // Валидация email
            if (!IsValidEmail(email))
            {
                ShowError("Некорректный email.");
                return;
            }

            // Проверка возраста (должно быть больше 18 лет)
            int age = CalculateAge(birthDate.Value);
            if (age < 18)
            {
                ShowError("Ошибка! Пользователю должно быть больше 18 лет.");
                return;
            }

            // Вставка данных в базу
            using (var context = new CASINOEntities())
            {
                if (context.Users.Any(u => u.Login == login))
                {
                    ShowError("Пользователь с таким логином уже существует.");
                    return;
                }

                // Создание нового пользователя
                var newUser = new Users
                {
                    Login = login,
                    Password = password, // Желательно захешировать пароль перед сохранением
                    Email = email,
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Перенаправление на страницу входа или главную
                NavigationService.Navigate(new AuthorisationPage());
            }
        }

        // Метод для показа сообщения об ошибке
        private void ShowError(string message)
        {
            ErrorMessageTextBlock.Text = message;
            ErrorMessageTextBlock.Visibility = Visibility.Visible;
        }

        // Метод для проверки валидности email
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Метод для расчета возраста
        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--; // Учитываем, если день рождения еще не наступил в этом году
            return age;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length > 0)
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordBox.Password.Length > 0)
            {
                ConfirmPasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                ConfirmPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VisiblePasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorisationPage());
        }
    }
}
