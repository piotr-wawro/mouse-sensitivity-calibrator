using MouseSensitivityCalibrator.Converters;
using MouseSensitivityCalibrator.Models;
using MouseSensitivityCalibrator.RawInput;
using MouseSensitivityCalibrator.ViewModels;
using MouseSensitivityCalibrator.Views.Components;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;

namespace MouseSensitivityCalibrator;


public partial class MainWindow : Window {
    private MainWindowViewModel _viewModel = new MainWindowViewModel();
    public const int WM_INPUT = 0x00FF;
    private HwndSource? _hwndSource;
    private RawInput.Mouse _mouse;
    private RawInput.Keyboard _keyboard;
    private RawInput.RawInputHandler _rawInputHandler = new RawInputHandler();
    private bool[] _keyStates = new bool[256];

    public MainWindow() {
        InitializeComponent();
        DataContext = _viewModel;
        Loaded += Window_Loaded;
        Closed += Window_Closed;
        _mouse = new RawInput.Mouse();
        _keyboard = new RawInput.Keyboard();
        _rawInputHandler = new RawInputHandler();

        _viewModel.Configuration.PropertyChanged += ViewModel_PropertyChanged;
    }

    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
        switch(e.PropertyName) {
            case nameof(_viewModel.Configuration.SelectedConversion):
            case nameof(_viewModel.Configuration.Cpi):
                CreateBinding(source, MovementFeedback.HorizontalMovementProperty, "Source.Horizontal");
                CreateBinding(source, MovementFeedback.VerticalMovementProperty, "Source.Vertical");
                CreateBinding(record1, Recording.HorizontalMovementProperty, "Record1.MovementFeedback.Horizontal");
                CreateBinding(record1, Recording.VerticalMovementProperty, "Record1.MovementFeedback.Vertical");
                CreateBinding(record2, Recording.HorizontalMovementProperty, "Record2.MovementFeedback.Horizontal");
                CreateBinding(record2, Recording.VerticalMovementProperty, "Record2.MovementFeedback.Vertical");
                break;
        }
    }

    private void CreateBinding(DependencyObject target, DependencyProperty dp, string path) {
        var conversion = _viewModel.Configuration.SelectedConversion;
        var cpi = _viewModel.Configuration.Cpi;

        var bind = new Binding() {
            Path = new PropertyPath(path),
            Converter = SelectConverter(conversion),
            ConverterParameter = cpi,
            Mode = BindingMode.OneWay
        };
        BindingOperations.SetBinding(target, dp, bind);
    }

    private IValueConverter SelectConverter(ConversionType conversion) {
        if(conversion == ConversionType.CountsPerInch) {
            return new DoubleToString();
        }
        else if(conversion == ConversionType.Centimeters) {
            return new CpiToCm();
        }
        else if(conversion == ConversionType.Inches) {
            return new CpiToInch();
        }
        else {
            throw new NotImplementedException();
        }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
        _hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
        _hwndSource.AddHook(WndProc);
        _rawInputHandler.OnMouseInputReceived += Mouse_OnMouseInputReceived;
        _rawInputHandler.OnKeyboardInputReceived += Keyboard_OnKeyboardInputReceived;
        _keyboard.RegisterDevice(_hwndSource.Handle);
    }

    private void Window_Closed(object? sender, EventArgs e) {
        _hwndSource.RemoveHook(WndProc);
        _hwndSource.Dispose();
        _hwndSource = null;
    }

    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
        if(msg == WM_INPUT) {
            _rawInputHandler.HandleRawInput(lParam);
        }
        return IntPtr.Zero;
    }

    private void Mouse_OnMouseInputReceived(object? sender, (int x, int y) e) {
        _viewModel.TrueSourceX += e.x;
        _viewModel.TrueSourceY += e.y;
    }

    private void Keyboard_OnKeyboardInputReceived(object? sender, (Key key, uint flags) e) {
        if(e.flags == 0x0000) {
            _keyStates[(int)e.key] = true;
        }
        else if(e.flags == 0x0001) {
            _keyStates[(int)e.key] = false;
        }

        if(_viewModel.Configuration.StartRecording?.IsPressed(_keyStates) == true) {
            _viewModel.TrueSourceX = 0;
            _viewModel.TrueSourceY = 0;
            _mouse.RegisterDevice(_hwndSource.Handle);
        }
        else if(_viewModel.Configuration.StopRecording?.IsPressed(_keyStates) == true) {
            _mouse.UnregisterDevice();
        }
    }
}
