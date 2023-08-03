using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;

namespace MouseSensitivityCalibrator.Converters;


[ValueConversion(typeof(int), typeof(string))]
public class CpiToCm : MarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        // counts / cpi * 2.54 => cm
        return ((double)value / (double)parameter * 2.54).ToString("N2");
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return Double.Parse((string)value) * (double)parameter / 2.54;
    }
    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}
