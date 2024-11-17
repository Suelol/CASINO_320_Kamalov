using CASINO.DBModel;
using CASINO.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
using Wpf.Ui.Controls;

namespace CASINO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new AuthorisationPage());
            DisableButtons();
        }

        // Метод для изменения состояния кнопок
        public void EnableButtons()
        {
            personalInfoBtn.IsEnabled = true; // Имя кнопки в XAML
            historyGame.IsEnabled = true; // Имя другой кнопки в XAML
            transactionBtn.IsEnabled = true; // Имя другой кнопки в XAML
            GamesBtn.IsEnabled = true; // Имя другой кнопки в XAML
            BalanceBtn.IsEnabled = true; // Имя другой кнопки в XAML
            ExitBtn.IsEnabled = true; // Имя другой кнопки в XAML
            colesoBtn.IsEnabled = true;
        }

        public void DisableButtons()
        {
            personalInfoBtn.IsEnabled = false; // Имя кнопки в XAML
            historyGame.IsEnabled = false; // Имя другой кнопки в XAML
            transactionBtn.IsEnabled = false; // Имя другой кнопки в XAML
            GamesBtn.IsEnabled = false; // Имя другой кнопки в XAML
            BalanceBtn.IsEnabled = false; // Имя другой кнопки в XAML
            ExitBtn.IsEnabled = false; // Имя другой кнопки в XAML
            colesoBtn.IsEnabled = false;
        }

        private void GamesBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new BlakjakPage());
        }

        private void colesoBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new RouletteGamePage());
        }

        private void historyGame_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new GameHistoryPage());
        }

        private void personalInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PersonalInfo());
        }

        private void BalanceBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new BalancePage());
        }

        private void transactionBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new TransactionHistoryPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new AuthorisationPage());
            ConnectionClass.IsOnlineUserId = -1;
            DisableButtons();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new RegisterPage());
        }

    }
}
