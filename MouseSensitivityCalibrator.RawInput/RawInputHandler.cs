using System.Runtime.InteropServices;
using System;
using System.Windows.Input;

namespace MouseSensitivityCalibrator.RawInput;


public class RawInputHandler {
    private const int RID_INPUT = 0x10000003; // Get the raw data from the RAWINPUT structure.
    private const int RIM_TYPEMOUSE = 0;      // Raw input from mouse.
    private const int RIM_TYPEKEYBOARD = 1;   // Raw input from keyboard.

    public event EventHandler<(int x, int y)> OnMouseInputReceived;
    public event EventHandler<(Key key, uint flags)> OnKeyboardInputReceived;

    public void HandleRawInput(IntPtr hRawInput) {
        var dwSize = 0;
        User32Dll.GetRawInputData(hRawInput, RID_INPUT, IntPtr.Zero, ref dwSize, Marshal.SizeOf<RAWINPUTHEADER>());

        var buffer = Marshal.AllocHGlobal(dwSize);
        var outSize = User32Dll.GetRawInputData(hRawInput, RID_INPUT, buffer, ref dwSize, Marshal.SizeOf<RAWINPUTHEADER>());

        try {
            if(outSize == -1) throw new Exception("Could not get raw data! Error: " + Marshal.GetLastWin32Error());

            var rawInput = Marshal.PtrToStructure<RAWINPUT>(buffer);
            if(rawInput.header.dwType == RIM_TYPEMOUSE) {
                OnMouseInputReceived?.Invoke(this, (rawInput.data.Mouse.lLastX, rawInput.data.Mouse.lLastY));
            }
            else if(rawInput.header.dwType == RIM_TYPEKEYBOARD) {
                OnKeyboardInputReceived?.Invoke(this, (KeyInterop.KeyFromVirtualKey(rawInput.data.Keyboard.VKey), rawInput.data.Keyboard.Flags));
            }
        }
        finally {
            Marshal.FreeHGlobal(buffer);
        }
    }
}
