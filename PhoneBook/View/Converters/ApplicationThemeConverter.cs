using ModernWpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhoneBook.View.Converters
{
    public class ApplicationThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter is string s)
            {
                parameter = Enum.Parse(typeof(ApplicationTheme), s);
            }
            if(value is ApplicationTheme type && parameter is ApplicationTheme p1)
            {
                return type == p1;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
