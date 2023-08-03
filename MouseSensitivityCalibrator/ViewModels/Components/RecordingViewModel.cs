namespace MouseSensitivityCalibrator.ViewModels.Components;


class RecordingViewModel {
    public SensitivityInputViewModel SensitivityInput { get; } = new();
    public MovementFeedbackViewModel MovementFeedback { get; } = new();
}
