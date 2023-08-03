using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;

namespace MouseSensitivityCalibrator.Converters;


[ValueConversion(typeof(int), typeof(string))]
public class CpiToInch : MarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        // counts / cpi => inch
        return ((double)value / (double)parameter).ToString("N2");
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }
    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}
