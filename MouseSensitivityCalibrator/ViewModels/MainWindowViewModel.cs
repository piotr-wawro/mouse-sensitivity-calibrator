using CommunityToolkit.Mvvm.Input;
using MouseSensitivityCalibrator.ViewModels.Components;
using System.Windows.Input;

namespace MouseSensitivityCalibrator.ViewModels;


internal class MainWindowViewModel : BaseViewModel {
    private int _trueSourceX;
    private int _trueSourceY;

    public int TrueSourceX {
        get => _trueSourceX;
        set {
            _trueSourceX = value;
            OnPropertyChanged(nameof(TrueSourceX));
        }
    }
    public int TrueSourceY {
        get => _trueSourceY;
        set {
            _trueSourceY = value;
            OnPropertyChanged(nameof(TrueSourceY));
        }
    }


    public ConfigurationViewModel Configuration { get; } = new ConfigurationViewModel();
    public MovementFeedbackViewModel Source { get; } = new MovementFeedbackViewModel();
    public RecordingViewModel Record1 { get; } = new RecordingViewModel();
    public RecordingViewModel Record2 { get; } = new RecordingViewModel();


    private double _outputHorizontalSensitivity;
    private double _outputVerticalSensitivity;

    public double OutputHorizontalSensitivity {
        get { return _outputHorizontalSensitivity; }
        set {
            _outputHorizontalSensitivity = value;
            OnPropertyChanged(nameof(OutputHorizontalSensitivity));
        }
    }
    public double OutputVerticalSensitivity {
        get { return _outputVerticalSensitivity; }
        set {
            _outputVerticalSensitivity = value;
            OnPropertyChanged(nameof(OutputVerticalSensitivity));
        }
    }

    public MainWindowViewModel() {
        PropertyChanged += MainWindowViewModel_PropertyChanged;
    }

    private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {
        switch(e.PropertyName) {
            case nameof(TrueSourceX):
                Source.Horizontal = TrueSourceX;
                Record1.MovementFeedback.Horizontal = TrueSourceX;
                Record2.MovementFeedback.Horizontal = TrueSourceX;
                break;
            case nameof(TrueSourceY):
                Source.Vertical = TrueSourceY;
                Record1.MovementFeedback.Vertical = TrueSourceY;
                Record2.MovementFeedback.Vertical = TrueSourceY;
                break;
        }
    }

    public ICommand CalculateSensitivity => new RelayCommand(Calculate);

    private void Calculate() {
        OutputHorizontalSensitivity = CalcSensitivity(
            Record1.MovementFeedback.Horizontal,
            Record2.MovementFeedback.Horizontal,
            Record1.SensitivityInput.Horizontal,
            Record2.SensitivityInput.Horizontal,
            Source.Horizontal
       );
        OutputVerticalSensitivity = CalcSensitivity(
            Record1.MovementFeedback.Vertical,
            Record2.MovementFeedback.Vertical,
            Record1.SensitivityInput.Vertical,
            Record2.SensitivityInput.Vertical,
            Source.Vertical
       );
    }

    private double CalcSensitivity(double movement1, double movement2, double sensitivity1, double sensitivity2, double movement0) {
        var a = (sensitivity2 - sensitivity1) / (movement2 - movement1);
        var b = sensitivity1 - a * movement1;
        return a * movement0 + b;
    }
}
