using System.Text;
using System.Windows.Input;

namespace MouseSensitivityCalibrator.Views.Controls;


public class Hotkey
{
    public Key Key { get; }
    public ModifierKeys Modifiers { get; }

    public Hotkey(Key key, ModifierKeys modifiers)
    {
        Key = key;
        Modifiers = modifiers;
    }

    public override string ToString()
    {
        var str = new StringBuilder();

        if (Modifiers.HasFlag(ModifierKeys.Control))
            str.Append("Ctrl + ");
        if (Modifiers.HasFlag(ModifierKeys.Shift))
            str.Append("Shift + ");
        if (Modifiers.HasFlag(ModifierKeys.Alt))
            str.Append("Alt + ");
        if (Modifiers.HasFlag(ModifierKeys.Windows))
            str.Append("Win + ");

        str.Append(Key);

        return str.ToString();
    }

    internal bool IsPressed(bool[] keyStates)
    {
        if (Modifiers.HasFlag(ModifierKeys.Control) && !keyStates[(int)Key.LeftCtrl] && !keyStates[(int)Key.RightCtrl])
            return false;
        if (Modifiers.HasFlag(ModifierKeys.Shift) && !keyStates[(int)Key.LeftShift] && !keyStates[(int)Key.RightShift])
            return false;
        if (Modifiers.HasFlag(ModifierKeys.Alt) && !keyStates[(int)Key.LeftAlt] && !keyStates[(int)Key.RightAlt])
            return false;
        if (Modifiers.HasFlag(ModifierKeys.Windows) && !keyStates[(int)Key.LWin] && !keyStates[(int)Key.RWin])
            return false;
        if (!keyStates[(int)Key])
            return false;

        return true;
    }
}
