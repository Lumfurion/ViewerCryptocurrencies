using System;
using System.Threading;
using System.Windows.Input;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.Commands;
using ViewerCryptocurrencies.UI.Services;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    class SideMenuViewModel : NotifyObject,ISideMenuViewModel 
    {
        public ICommand NavigateHomeCommand  { get; }
        public ICommand NavigateShowCourseCommand { get; }
        public ICommand NavigateSetingsCommand { get; }

        public SideMenuViewModel(INavigationService homeNavigationService,
            INavigationService showCourseNavigationService,
            INavigationService setingsNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateShowCourseCommand = new NavigateCommand(showCourseNavigationService);
            NavigateSetingsCommand = new NavigateCommand(setingsNavigationService);

            
        }

        #region IDisposable Members
        public event EventHandler? Disposed;
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Disposed?.Invoke(this, EventArgs.Empty);
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
