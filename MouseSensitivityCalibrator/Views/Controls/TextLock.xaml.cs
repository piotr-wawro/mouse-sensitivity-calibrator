using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MouseSensitivityCalibrator.Views.Controls;


public partial class TextLock : UserControl {
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextLock));

    public static readonly DependencyProperty IsLockedProperty =
        DependencyProperty.Register("IsLocked", typeof(bool), typeof(TextLock),
            new PropertyMetadata(false, LockChange));

    public string Text {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public bool IsLocked {
        get { return (bool)GetValue(IsLockedProperty); }
        set { SetValue(IsLockedProperty, value); }
    }

    private static void LockChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var box = (TextLock)d;

        box.lockImage.ToolTip = box.IsLocked
            ? "Unlock"
            : "Lock";
        box.lockImage.Source = box.IsLocked
            ? new BitmapImage(new Uri("pack://application:,,,/Resources/lock.png"))
            : new BitmapImage(new Uri("pack://application:,,,/Resources/lock_open.png"));
        box.border.BorderBrush = box.IsLocked
            ? System.Windows.Media.Brushes.Red
            : System.Windows.Media.Brushes.Green;
    }

    public TextLock() {
        InitializeComponent();
    }

    private void Lock(object sender, RoutedEventArgs e) {
        IsLocked = !IsLocked;
    }
}
