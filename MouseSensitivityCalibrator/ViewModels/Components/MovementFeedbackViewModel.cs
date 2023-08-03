namespace MouseSensitivityCalibrator.ViewModels.Components;


public class MovementFeedbackViewModel : BaseViewModel {
    private double _horizontal;
    private double _vertical;
    private bool _horizontalLocked;
    private bool _verticalLocked;

    public double Horizontal {
        get { return _horizontal; }
        set {
            if(HorizontalLocked) return;
            _horizontal = value;
            OnPropertyChanged(nameof(Horizontal));
        }
    }

    public double Vertical {
        get { return _vertical; }
        set {
            if(VerticalLocked) return;
            _vertical = value;
            OnPropertyChanged(nameof(Vertical));
        }
    }

    public bool HorizontalLocked {
        get { return _horizontalLocked; }
        set {
            _horizontalLocked = value;
            OnPropertyChanged(nameof(HorizontalLocked));
        }
    }

    public bool VerticalLocked {
        get { return _verticalLocked; }
        set {
            _verticalLocked = value;
            OnPropertyChanged(nameof(VerticalLocked));
        }
    }
}
