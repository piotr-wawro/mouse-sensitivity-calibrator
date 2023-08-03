using System.Windows;
using System.Windows.Controls;

namespace MouseSensitivityCalibrator.Views.Components;


public partial class MovementFeedback : UserControl {
    public static readonly DependencyProperty HorizontalMovementProperty =
        DependencyProperty.Register("HorizontalMovement", typeof(string), typeof(MovementFeedback));
    public static readonly DependencyProperty VerticalMovementProperty =
        DependencyProperty.Register("VerticalMovement", typeof(string), typeof(MovementFeedback));
    public static readonly DependencyProperty HorizontalLockedProperty =
        DependencyProperty.Register("HorizontalLocked", typeof(bool), typeof(MovementFeedback));
    public static readonly DependencyProperty VerticalLockedProperty =
        DependencyProperty.Register("VerticalLocked", typeof(bool), typeof(MovementFeedback));

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

    public MovementFeedback() {
        InitializeComponent();
    }
}
