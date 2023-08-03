namespace MouseSensitivityCalibrator.ViewModels.Components;


class SensitivityInputViewModel : BaseViewModel {
    private double _horizontal;
    private double _vertical;

    public double Horizontal {
        get { return _horizontal; }
        set {
            _horizontal = value;
            OnPropertyChanged(nameof(Horizontal));
        }
    }

    public double Vertical {
        get { return _vertical; }
        set {
            _vertical = value;
            OnPropertyChanged(nameof(Vertical));
        }
    }
}
