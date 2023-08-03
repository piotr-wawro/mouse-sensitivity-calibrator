using System.Windows;
using System.Windows.Controls;

namespace MouseSensitivityCalibrator.Views.Components;


public partial class SensitivityInput : UserControl {
    public static readonly DependencyProperty HorizontalSensitivityProperty =
        DependencyProperty.Register("HorizontalSensitivity", typeof(string), typeof(SensitivityInput));
    public static readonly DependencyProperty VerticalSensitivityProperty =
        DependencyProperty.Register("VerticalSensitivity", typeof(string), typeof(SensitivityInput));

    public string HorizontalSensitivity {
        get { return (string)GetValue(HorizontalSensitivityProperty); }
        set { SetValue(HorizontalSensitivityProperty, value); }
    }
    public string VerticalSensitivity {
        get { return (string)GetValue(VerticalSensitivityProperty); }
        set { SetValue(VerticalSensitivityProperty, value); }
    }

    public SensitivityInput() {
        InitializeComponent();
    }
}
