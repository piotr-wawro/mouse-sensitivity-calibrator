using System.ComponentModel;

namespace MouseSensitivityCalibrator.ViewModels;


public class BaseViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
