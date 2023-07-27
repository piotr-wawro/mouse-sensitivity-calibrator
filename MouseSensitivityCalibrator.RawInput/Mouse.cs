namespace MouseSensitivityCalibrator.RawInput;


public class Mouse : HumanInterfaceDevice {
    public Mouse() {
        rid = new RAWINPUTDEVICE {
            usUsagePage = (ushort)HID_USAGE_PAGE.GENERIC,
            usUsage = (ushort)HID_USAGE_GENERIC.MOUSE,
        };
    }
}
