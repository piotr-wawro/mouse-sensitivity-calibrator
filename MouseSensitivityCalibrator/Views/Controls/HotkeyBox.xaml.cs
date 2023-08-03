using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MouseSensitivityCalibrator.Views.Controls;


public partial class HotkeyBox : UserControl {
    public static readonly DependencyProperty HotkeyProperty =
         DependencyProperty.Register(nameof(Hotkey), typeof(Hotkey), typeof(HotkeyBox),
             new FrameworkPropertyMetadata(default(Hotkey), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
         );

    public Hotkey? Hotkey {
        get => (Hotkey)GetValue(HotkeyProperty);
        set => SetValue(HotkeyProperty, value);
    }

    public HotkeyBox() {
        InitializeComponent();
    }

    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e) {
        e.Handled = true;

        var modifiers = Keyboard.Modifiers;
        var key = (e.Key == Key.System ? e.SystemKey : e.Key);

        if(key == Key.Delete || key == Key.Back) {
            Hotkey = null;
            return;
        }
        if(key == Key.Escape) {
            Keyboard.ClearFocus();
            return;
        }
        if(key == Key.LeftShift || key == Key.RightShift || key == Key.LeftCtrl || key == Key.RightCtrl ||
           key == Key.LeftAlt || key == Key.RightAlt || key == Key.LWin || key == Key.RWin) {
            return;
        }

        Hotkey = new Hotkey(key, modifiers);
    }
}
