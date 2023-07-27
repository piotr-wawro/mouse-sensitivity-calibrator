using System;
using System.Runtime.InteropServices;

namespace MouseSensitivityCalibrator.RawInput;


public abstract class HumanInterfaceDevice : IRegistable {
    protected RAWINPUTDEVICE rid;

    public void RegisterDevice(nint HwndTarget) {
        rid.dwFlags = (uint)RIDEV.INPUTSINK;
        rid.hwndTarget = HwndTarget;

        if(!User32Dll.RegisterRawInputDevices(new RAWINPUTDEVICE[] { rid }, 1, (uint)Marshal.SizeOf(rid)))
            throw new Exception("Could not register RawInputDevice! Error: " + Marshal.GetLastWin32Error());
    }

    public void UnregisterDevice() {
        rid.dwFlags = (uint)RIDEV.REMOVE;
        rid.hwndTarget = IntPtr.Zero;


        if(!User32Dll.RegisterRawInputDevices(new RAWINPUTDEVICE[] { rid }, 1, (uint)Marshal.SizeOf(rid)))
            throw new Exception("Could not unregister RawInputDevice! Error: " + Marshal.GetLastWin32Error());
    }
}
