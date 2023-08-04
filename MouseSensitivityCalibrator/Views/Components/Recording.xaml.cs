using System.Windows;
using System.Windows.Controls;

namespace MouseSensitivityCalibrator.Views.Components;


public partial class Recording : UserControl {
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register("Label", typeof(string), typeof(Recording));
    public static readonly DependencyProperty HorizontalSensitivityProperty =
        DependencyProperty.Register("HorizontalSensitivity", typeof(string), typeof(Recording));
    public static readonly DependencyProperty VerticalSensitivityProperty =
        DependencyProperty.Register("VerticalSensitivity", typeof(string), typeof(Recording));
    public static readonly DependencyProperty HorizontalMovementProperty =
        DependencyProperty.Register("HorizontalMovement", typeof(string), typeof(Recording));
    public static readonly DependencyProperty VerticalMovementProperty =
        DependencyProperty.Register("VerticalMovement", typeof(string), typeof(Recording));
    public static readonly DependencyProperty HorizontalLockedProperty =
    DependencyProperty.Register("HorizontalLocked", typeof(bool), typeof(Recording));
    public static readonly DependencyProperty VerticalLockedProperty =
        DependencyProperty.Register("VerticalLocked", typeof(bool), typeof(Recording));

    public string Label {
        get { return (string)GetValue(LabelProperty); }
        set { SetValue(LabelProperty, value); }
    }
    public string HorizontalSensitivity {
        get { return (string)GetValue(HorizontalSensitivityProperty); }
        set { SetValue(HorizontalSensitivityProperty, value); }
    }
    public string VerticalSensitivity {
        get { return (string)GetValue(VerticalSensitivityProperty); }
        set { SetValue(VerticalSensitivityProperty, value); }
    }
    public string HorizontalMovement {
        get { return (string)GetValue(HorizontalMovementProperty); }
        set { SetValue(HorizontalMovementProperty, value); }
    }
    public string VerticalMovement {
        get { return (string)GetValue(VerticalMovementProperty); }
        set { SetValue(VerticalMovementProperty, value); }
    }
    public bool HorizontalLocked {
        get { return (bool)GetValue(HorizontalLockedProperty); }
        set { SetValue(HorizontalLockedProperty, value); }
    }
    public bool VerticalLocked {
        get { return (bool)GetValue(VerticalLockedProperty); }
        set { SetValue(VerticalLockedProperty, value); }
    }

    public Recording() {
        InitializeComponent();
    }
}
