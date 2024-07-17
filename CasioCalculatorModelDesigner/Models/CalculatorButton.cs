using CommunityToolkit.Mvvm.ComponentModel;

namespace CasioCalculatorModelDesigner
{
    public partial class CalculatorButton : ObservableObject
    {
        [ObservableProperty]
        private string _displayName = string.Empty;

        [ObservableProperty]
        private int _inputOutput;

        public NormalizedRect NormalizedRect { get; } = new();
    }
}
