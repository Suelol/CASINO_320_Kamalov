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
    /// Логика взаимодействия для GameHistoryPage.xaml
    /// </summary>
    public partial class GameHistoryPage : Page
    {
        public GameHistoryPage()
        {
            InitializeComponent();
            LoadGameHistory();
        }

        private void LoadGameHistory()
        {
            using (var context = new CASINOEntities())
            {
                int userId = ConnectionClass.IsOnlineUserId; // Текущий пользователь
                var gameHistory = context.GameHistory
                    .Where(gh => gh.UserId == userId)
                    .Select(gh => new
                    {
                        gh.Bet,
                        gh.Result,
                        gh.DateTime
                    })
                    .ToList();

                GameHistoryDataGrid.ItemsSource = gameHistory;
            }
        }

        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CASINOEntities())
            {
                int userId = ConnectionClass.IsOnlineUserId; // Текущий пользователь
                var gameResults = context.GameHistory
                    .Where(gh => gh.UserId == userId)
                    .ToList();

                int wins = gameResults.Count(gh => gh.Result >= 2); // Предполагается, что выигрыши имеют положительное значение
                int losses = gameResults.Count(gh => gh.Result < 1); // Предполагается, что проигрыши имеют отрицательное значение

                MessageBox.Show($"Выигрыши: {wins}\nПроигрыши: {losses}", "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
    }
}
