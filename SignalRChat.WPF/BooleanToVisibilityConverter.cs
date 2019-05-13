using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SignalRChat.WPF
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = (bool)value;
            if (parameter != null && bool.Parse(parameter.ToString()) == true) visible ^= true;
            return visible ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
