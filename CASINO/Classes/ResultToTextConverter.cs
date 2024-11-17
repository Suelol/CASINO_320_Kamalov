using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CASINO.Classes
{
    internal class ResultToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal result)
            {
                if (result == 0)
                {
                    return "Проигрыш";
                }
                else if (result == 1)
                {
                    return "Выиграл";
                }
                else if (result == 2)
                {
                    return "Ничья";
                }
                else
                {
                    return "Неизвестный результат";
                }
            }

            return "Неизвестный результат";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        

        
    }
}
