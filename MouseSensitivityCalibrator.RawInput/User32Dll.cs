using System.Runtime.InteropServices;
using System;

namespace MouseSensitivityCalibrator.RawInput;


public static class User32Dll {
    [DllImport("user32", SetLastError = true)]
    public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, uint uiNumDevices, uint cbSize);

    [DllImport("user32", SetLastError = true)]
    public static extern int GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref int pcbSize, int cbSizeHeader);
}
