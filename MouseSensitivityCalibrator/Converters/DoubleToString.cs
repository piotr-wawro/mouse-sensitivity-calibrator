using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;

namespace MouseSensitivityCalibrator.Converters;


[ValueConversion(typeof(int), typeof(string))]
public class DoubleToString : MarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return ((double)value).ToString("N2");
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return Double.Parse((string)value);
    }
    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}
