using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ViewerCryptocurrencies.Models
{
    /// <summary>
    /// Abstract INotifyPropertyChanged implemented object
    /// </summary>
    public abstract class NotifyObject : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Default OnPropertyChanged
        /// </summary>
        /// <param name="propertyName">Property name, update of which need's to be invoked</param>
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
