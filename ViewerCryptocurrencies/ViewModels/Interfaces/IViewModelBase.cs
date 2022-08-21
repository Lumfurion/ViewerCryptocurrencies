using System;
using System.ComponentModel;

namespace ViewerCryptocurrencies.UI.ViewModels.Interfaces
{
    public interface IViewModelBase : IDisposable
    {
        event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string? propertyName = null);
    }

}
