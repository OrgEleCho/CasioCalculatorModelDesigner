using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CasioCalculatorModelDesigner
{
    public partial class CalculatorModel : ObservableObject
    {
        [ObservableProperty]
        private string _modelName = "GenshinStart";

        [ObservableProperty]
        private string _interfacePath = string.Empty;

        [ObservableProperty]
        private string _romPath = string.Empty;

        [ObservableProperty]
        private string _flashPath = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ScreenColorRed))]
        private Color _screenColor = Color.FromRgb(173, 184, 173);

        public ObservableCollection<CalculatorButton> Buttons { get; } = new();


        public int ScreenColorRed
        {
            get => ScreenColor.R;
            set => ScreenColor = Color.FromRgb((byte)value, ScreenColor.G, ScreenColor.B);
        }

        public int ScreenColorGreen
        {
            get => ScreenColor.G;
            set => ScreenColor = Color.FromRgb(ScreenColor.R, (byte)value, ScreenColor.B);
        }

        public int ScreenColorBlue
        {
            get => ScreenColor.B;
            set => ScreenColor = Color.FromRgb(ScreenColor.R, ScreenColor.G, (byte)value);
        }
    }
}
