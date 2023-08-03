using System.ComponentModel;

namespace MouseSensitivityCalibrator.Models;


public enum ConversionType {
    [Description("Counts Pre Inch")]
    CountsPerInch,
    [Description("Centimeters")]
    Centimeters,
    [Description("Inches")]
    Inches
}
