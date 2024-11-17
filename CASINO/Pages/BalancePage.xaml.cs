using CASINO.DBModel;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для BalancePage.xaml
    /// </summary>
    public partial class BalancePage : Page
    {
        public BalancePage()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
            if (user != null)
                balanceTxt.Text = user.Balance.ToString();
            else
                balanceTxt.Text = "Unknown user";
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs(out decimal amount))
            {
                var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
                user.Balance += amount; // Пополнение баланса

                FinancialOperations financialOperations = new FinancialOperations()
                {
                    DateTime = DateTime.Now,
                    UserId = ConnectionClass.IsOnlineUserId,
                    OperationType = "Пополнение средств",
                    Amount = amount,
                };
                ConnectionClass.db.FinancialOperations.Add(financialOperations);

                ConnectionClass.db.SaveChanges();

                balanceTxt.Text = user.Balance.ToString("N2");
                CustomMessageBox successMessage = new CustomMessageBox("Баланс успешно пополнен!");
                successMessage.ShowDialog();
                ClearInputs();
                InitData();
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs(out decimal amount))
            {
                var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
                if (amount <= user.Balance)
                {
                    user.Balance -= amount; // Снятие средств

                    FinancialOperations financialOperations = new FinancialOperations()
                    {
                        DateTime = DateTime.Now,
                        UserId = ConnectionClass.IsOnlineUserId,
                        OperationType = "Вывод средств",
                        Amount = amount,
                    };
                    ConnectionClass.db.FinancialOperations.Add(financialOperations);

                    ConnectionClass.db.SaveChanges();

                    balanceTxt.Text = user.Balance.ToString("N2");
                    CustomMessageBox successMessage = new CustomMessageBox("Средства успешно сняты!");
                    successMessage.ShowDialog();
                    ClearInputs();
                    InitData();
                }
                else
                {
                    MessageBox.Show("Недостаточно средств на балансе!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Метод проверки данных
        private bool ValidateInputs(out decimal amount)
        {
            amount = 0;

            // Проверка номера карты (16 цифр)
            if (string.IsNullOrWhiteSpace(cardNumberTxt.Text) || !Regex.IsMatch(cardNumberTxt.Text, @"^\d{16}$"))
            {
                MessageBox.Show("Пожалуйста, введите корректный номер карты (16 цифр).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Проверка CVV (3 цифры)
            if (string.IsNullOrWhiteSpace(cvvTxt.Password) || !Regex.IsMatch(cvvTxt.Password, @"^\d{3}$"))
            {
                MessageBox.Show("Пожалуйста, введите корректный CVV код (3 цифры).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Проверка суммы
            if (string.IsNullOrWhiteSpace(amountTxt.Text) || !decimal.TryParse(amountTxt.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму для операции.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        // Метод очистки полей ввода после успешной операции
        private void ClearInputs()
        {
            cardNumberTxt.Text = string.Empty;
            cvvTxt.Password = string.Empty;
            amountTxt.Text = string.Empty;
        }
    }
}
