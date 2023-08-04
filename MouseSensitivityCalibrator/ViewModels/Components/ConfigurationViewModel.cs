using MouseSensitivityCalibrator.Models;
using MouseSensitivityCalibrator.Views.Controls;
using System.Windows.Input;

namespace MouseSensitivityCalibrator.ViewModels.Components;


class ConfigurationViewModel : BaseViewModel {
    private double _cpi = 600;
    private ConversionType _selectedConversion = ConversionType.Counts;
    private Hotkey _startRecording = new Hotkey(Key.D1, ModifierKeys.Control);
    private Hotkey _stopRecording = new Hotkey(Key.D4, ModifierKeys.Control);

    public Hotkey StartRecording {
        get { return _startRecording; }
        set {
            _startRecording = value;
            OnPropertyChanged(nameof(StartRecording));
        }
    }

    public Hotkey StopRecording {
        get { return _stopRecording; }
        set {
            _stopRecording = value;
            OnPropertyChanged(nameof(StopRecording));
        }
    }

    public double Cpi {
        get { return _cpi; }
        set {
            _cpi = value;
            OnPropertyChanged(nameof(Cpi));
        }
    }

    public ConversionType SelectedConversion {
        get { return _selectedConversion; }
        set {
            _selectedConversion = value;
            OnPropertyChanged(nameof(SelectedConversion));
        }
    }
}
