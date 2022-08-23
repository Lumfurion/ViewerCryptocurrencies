using System;
using System.ComponentModel;
using System.Windows.Input;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    class LayoutViewModel : NotifyObject, ILayoutViewModel
    {
        /// <summary>
        /// SideMenu ViewModel
        /// </summary>
        public ISideMenuViewModel SideMenuViewModel { get; }
        /// <summary>
        /// Current ContentViewModel
        /// </summary>
        public IViewModelBase ContentViewModel { get; }


        public LayoutViewModel(ISideMenuViewModel sideMenuViewModel, IViewModelBase contentViewModel)
        {
            SideMenuViewModel = sideMenuViewModel;
            ContentViewModel = contentViewModel;
        }

        #region IDisposable Members
        public event EventHandler? Disposed;
        private bool _disposed = false;

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                OnDispose(EventArgs.Empty);
                _disposed = true;
                SideMenuViewModel?.Dispose();
                ContentViewModel?.Dispose();
            }

        }
        #endregion 
    }
}
