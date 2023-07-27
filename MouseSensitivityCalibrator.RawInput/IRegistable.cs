using System;
using System.Runtime.InteropServices;

namespace MouseSensitivityCalibrator.RawInput;


internal interface IRegistable {
    void RegisterDevice(IntPtr HwndTarget);
    void UnregisterDevice();
}
