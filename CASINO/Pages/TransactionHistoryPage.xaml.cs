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
    /// Логика взаимодействия для TransactionHistoryPage.xaml
    /// </summary>
    public partial class TransactionHistoryPage : Page
    {
        public TransactionHistoryPage()
        {
            InitializeComponent();
            LoadTransactionHistory();
        }

        private void LoadTransactionHistory()
        {
            using (var context = new CASINOEntities())
            {
                int userId = ConnectionClass.IsOnlineUserId; // Текущий пользователь
                var transactionHistory = context.FinancialOperations
                    .Where(fo => fo.UserId == userId)
                    .Select(fo => new
                    {
                        fo.OperationType,
                        fo.Amount,
                        fo.DateTime
                    })
                    .ToList();

                TransactionHistoryDataGrid.ItemsSource = transactionHistory;
            }
        }


    }
}
