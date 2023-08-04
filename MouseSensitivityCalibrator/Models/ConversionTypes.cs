using System.ComponentModel;

namespace MouseSensitivityCalibrator.Models;


public enum ConversionType {
    [Description("Counts")]
    Counts,
    [Description("Centimeters")]
    Centimeters,
    [Description("Inches")]
    Inches
}
