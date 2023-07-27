using System;
using System.Runtime.InteropServices;

namespace MouseSensitivityCalibrator.RawInput;


[StructLayout(LayoutKind.Sequential)]
public struct RAWINPUT {
    public RAWINPUTHEADER header;
    public RAWDATA data;
}

[StructLayout(LayoutKind.Sequential)]
public struct RAWINPUTHEADER {
    public uint dwType;
    public uint dwSize;
    public IntPtr hDevice;
    public IntPtr wParam;
}

[StructLayout(LayoutKind.Explicit)]
public struct RAWDATA {
    [FieldOffset(0)]
    public RAWMOUSE Mouse;
    [FieldOffset(0)]
    public RAWKEYBOARD Keyboard;
    [FieldOffset(0)]
    public RAWHID Hid;
}

[StructLayout(LayoutKind.Sequential)]
public struct RAWMOUSE {
    public ushort usFlags;
    public MOUSEBUTTONS mouseButtons;
    public uint ulRawButtons;
    public int lLastX;
    public int lLastY;
    public uint ulExtraInformation;
}

[StructLayout(LayoutKind.Explicit)]
public struct MOUSEBUTTONS {
    [FieldOffset(0)]
    public uint ulButtons;
    [FieldOffset(0)]
    public FLAGSANDDATA flagsAndData;
}

[StructLayout(LayoutKind.Sequential)]
public struct FLAGSANDDATA {
    public ushort usButtonFlags;
    public ushort usButtonData;
}

[StructLayout(LayoutKind.Sequential)]
public struct RAWKEYBOARD {
    public ushort MakeCode;
    public ushort Flags;
    public ushort Reserved;
    public ushort VKey;
    public uint Message;
    public uint ExtraInformation;
}

[StructLayout(LayoutKind.Sequential)]
public struct RAWHID {
    public uint dwSizeHid;
    public uint dwCount;
    public byte bRawData;
}

[StructLayout(LayoutKind.Sequential)]
public struct RAWINPUTDEVICE {
    public ushort usUsagePage;
    public ushort usUsage;
    public uint dwFlags;
    public IntPtr hwndTarget;
}

public enum HID_USAGE_PAGE {
    GENERIC = 0x01,
}

public enum HID_USAGE_GENERIC {
    MOUSE = 0x02,
    KEYBOARD = 0x06,
}

public enum RIDEV {
    REMOVE = 0x00000001,
    INPUTSINK = 0x00000100,
}

