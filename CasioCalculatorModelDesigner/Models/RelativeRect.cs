using CommunityToolkit.Mvvm.ComponentModel;

namespace CasioCalculatorModelDesigner
{
    public partial class NormalizedRect : ObservableObject
    {
        [ObservableProperty]
        private double _x;

        [ObservableProperty]
        private double _y;

        [ObservableProperty]
        private double _width;

        [ObservableProperty]
        private double _height;

        public void NotifyAllChanged()
        {
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
        }
    }
}
