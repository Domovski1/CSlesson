using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MenuList.Classes
{
    class ConverterClass : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return "Информация отсуствует";
            }

            var bytes = int.Parse(value.ToString());

                if (bytes > 1000 && bytes < 1000000)
                    return (bytes / 1000 + " Килобайт"); 
                else if (bytes > 1000000 && bytes < 1000000000)
                    return (bytes / 1000000 + " Мегебайт"); // Мегабайт
                else if (bytes > 1000000000)
                    return (bytes / 1000000000 + " гигабайт");// Гигабайт

            
                return bytes + " Byte";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
