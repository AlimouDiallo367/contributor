using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Contributor.ViewModels.Converters
{
    public class BoolToIllegaleConverter : IValueConverter
    {
        // Conversion du Model vers la View 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool illegale = (bool)value;
            return illegale ? "Oui" : "Non"; 
        }

        // Conversion de la View vers le Model 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }
    }
}
