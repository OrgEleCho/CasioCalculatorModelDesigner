using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace CasioCalculatorModelDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ObservableObject]
    public partial class MainWindow : Window
    {
        readonly OpenFileDialog openInterfaceFileDialog = new OpenFileDialog()
        {
            Filter = "Image|*.jpg;*.jpeg;*.png;*.bmp|Any|*.*",
            CheckFileExists = true,
        };

        readonly OpenFileDialog openRomFileDialog = new OpenFileDialog()
        {
            Filter = "Binary|*.bin|Any|*.*",
            CheckFileExists = true,
        };

        readonly OpenFileDialog openFlashFileDialog = new OpenFileDialog()
        {
            Filter = "Binary|*.bin|Any|*.*",
            CheckFileExists = true,
        };

        CalculatorButton? _currentAddingCalculatorButton;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        [ObservableProperty]
        private bool _isAddingCalculatorButton;

        public CalculatorModel CalculatorModel { get; } = new();



        [RelayCommand]
        public void OpenInterfaceFile()
        {
            if (openInterfaceFileDialog.ShowDialog() ?? false)
            {
                CalculatorModel.InterfacePath = openInterfaceFileDialog.FileName;
            }
        }


        [RelayCommand]
        public void OpenRomFile()
        {
            if (openRomFileDialog.ShowDialog() ?? false)
            {
                CalculatorModel.RomPath = openRomFileDialog.FileName;
            }
        }


        [RelayCommand]
        public void OpenFlashFile()
        {
            if (openFlashFileDialog.ShowDialog() ?? false)
            {
                CalculatorModel.FlashPath = openFlashFileDialog.FileName;
            }
        }

        [RelayCommand]
        public void StartAddCalculatorButton()
        {
            IsAddingCalculatorButton = true;
        }


        [RelayCommand]
        public void StopAddCalculatorButton()
        {
            IsAddingCalculatorButton = false;
        }

        [RelayCommand]
        public void DeleteCalculatorButton(CalculatorButton? calculatorButton)
        {
            if (calculatorButton is not null)
            {
                CalculatorModel.Buttons.Remove(calculatorButton);
            }
            else
            {
                CalculatorModel.Buttons.RemoveAt(CalculatorModel.Buttons.Count - 1);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;
            if (!IsAddingCalculatorButton)
                return;

            var relativePoint = e.GetPosition(element);
            var normalizedPoint = new Point(relativePoint.X / element.ActualWidth, relativePoint.Y / element.ActualHeight);

            _currentAddingCalculatorButton = new CalculatorButton();
            _currentAddingCalculatorButton.DisplayName = $"Button{CalculatorModel.Buttons.Count + 1}";
            _currentAddingCalculatorButton.NormalizedRect.X = normalizedPoint.X;
            _currentAddingCalculatorButton.NormalizedRect.Y = normalizedPoint.Y;

            CalculatorModel.Buttons.Add(_currentAddingCalculatorButton);

            element.CaptureMouse();
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;
            if (_currentAddingCalculatorButton is null)
                return;
            if (!IsAddingCalculatorButton)
                return;

            var relativePoint = e.GetPosition(element);
            var normalizedPoint = new Point(relativePoint.X / element.ActualWidth, relativePoint.Y / element.ActualHeight);

            _currentAddingCalculatorButton.NormalizedRect.Width = normalizedPoint.X - _currentAddingCalculatorButton.NormalizedRect.X;
            _currentAddingCalculatorButton.NormalizedRect.Height = normalizedPoint.Y - _currentAddingCalculatorButton.NormalizedRect.Y;

            Debug.WriteLine(_currentAddingCalculatorButton.NormalizedRect.Width);

            Debug.WriteLine("Moving");
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;
            if (!IsAddingCalculatorButton)
                return;

            _currentAddingCalculatorButton = null;

            if (element.IsMouseCaptured)
            {
                element.ReleaseMouseCapture();
            }

            StopAddCalculatorButton();
        }
    }
}