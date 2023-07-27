namespace MouseSensitivityCalibrator.RawInput;


public class Keyboard : HumanInterfaceDevice {
    public Keyboard()  {
        rid = new RAWINPUTDEVICE {
            usUsagePage = (ushort)HID_USAGE_PAGE.GENERIC,
            usUsage = (ushort)HID_USAGE_GENERIC.KEYBOARD,
        };
    }
}
