using MouseSensitivityCalibrator.Models;
using MouseSensitivityCalibrator.Views.Controls;
using System.Windows;
using System.Windows.Controls;

namespace MouseSensitivityCalibrator.Views.Components;


public partial class Configuration : UserControl {
    public static readonly DependencyProperty StartRecordingProperty =
        DependencyProperty.Register("StartRecording", typeof(Hotkey), typeof(Configuration));
    public static readonly DependencyProperty StopRecordingProperty =
        DependencyProperty.Register("StopRecording", typeof(Hotkey), typeof(Configuration));
    public static readonly DependencyProperty SelectedConversionProperty =
        DependencyProperty.Register("SelectedConversion", typeof(ConversionType), typeof(Configuration));
    public static readonly DependencyProperty CpiProperty =
        DependencyProperty.Register("Cpi", typeof(double), typeof(Configuration));

    public Hotkey StartRecording {
        get { return (Hotkey)GetValue(StartRecordingProperty); }
        set { SetValue(StartRecordingProperty, value); }
    }
    public Hotkey StopRecording {
        get { return (Hotkey)GetValue(StopRecordingProperty); }
        set { SetValue(StopRecordingProperty, value); }
    }
    public ConversionType SelectedConversion {
        get { return (ConversionType)GetValue(SelectedConversionProperty); }
        set { SetValue(SelectedConversionProperty, value); }
    }
    public double Cpi {
        get { return (double)GetValue(CpiProperty); }
        set { SetValue(CpiProperty, value); }
    }

    public Configuration() {
        InitializeComponent();
    }
}
